FROM python:3
WORKDIR /code
RUN apt-get update && apt-get upgrade -y
RUN apt-get install -y sqlite3
ADD requirements.txt /code/
RUN pip install --upgrade pip && pip install -r requirements.txt
ADD . /code/
RUN sqlite3 userdb.db < create_db.sql
CMD ["flask", "run", "--host=0.0.0.0"]
