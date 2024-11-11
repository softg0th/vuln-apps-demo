import sqlite3

import sqlalchemy
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

from .scheme import *

def select_data_access(data, access_type):
    data = str(data)
    alias = {
        'raw': select_raw_values(data),
        'parametrized': select_parametrized_values(data),
        'orm': select_orm_values(data)
    }
    output = alias.get(access_type)
    return output


def select_raw_values(data):
    connection = sqlite3.connect('userdb.db', check_same_thread=False)
    cursor = connection.cursor()
    sql = f"SELECT id, username, is_admin FROM users WHERE username='{data}'"  
    #   username' OR '1'='1
    try:
        cursor.execute(sql)
        results = cursor.fetchall()
        print(results)
        return results
    except Exception as ex:
        raise ex


def select_parametrized_values(data):
    connection = sqlite3.connect('userdb.db', check_same_thread=False)
    cursor = connection.cursor()
    sql = "SELECT id, username, is_admin FROM users WHERE username=?"
    try:
        cursor.execute(sql, (data,))
        results = cursor.fetchall()
        return results
    except Exception as ex:
        return ex


def select_orm_values(data):
    engine = create_engine("sqlite:///userdb.db", echo=True)
    Session = sessionmaker(autoflush=False, bind=engine)
    try:
        with Session(autoflush=False, bind=engine) as session:
            users = session.query(User).filter(User.username == data).all()
            result = [{'id': user.id, 'username': user.username, 'is_admin': user.is_admin} for user in users]
        return result
    except Exception as ex:
        return ex
