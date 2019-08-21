import pika


def connect():
    _credentials = pika.PlainCredentials('python_user', 'pypy')
    _connection_param = pika.ConnectionParameters(host='localhost', credentials=_credentials,
        virtual_host="merchant")

    _connection = pika.BlockingConnection(_connection_param)
    return _connection.channel()


