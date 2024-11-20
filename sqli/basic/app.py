from flask import Flask, render_template, request, jsonify
from .db import select_data_access


app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/select_data', methods=['POST'])
def select_data():
    user_prompt = request.form.get('user_prompt')
    select_type = request.form.get('select_type')
    users = select_data_access(user_prompt, select_type)
    print("users:", users)
    return jsonify(users)
