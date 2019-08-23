''' simulates the supplier API '''
import sys
import json
import Connect

_, supplier = sys.argv

s_id = int(supplier)

def consume(ch, meth, prop, body):
    msg = body.decode()
    order = json.loads(msg)
    supplierid = order["SupplierId"]
    if s_id == supplierid:
        print("order incoming:\n{0}".format(order))
        ch.basic_ack(delivery_tag=meth.delivery_tag)
    else:
        print("rejected! - supplier is {0} expected was: {1}".format(supplierid, s_id))
        ch.basic_reject(delivery_tag=meth.delivery_tag)

channel = Connect.connect()

channel.basic_consume("notification_queue", consume)
channel.start_consuming()