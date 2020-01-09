import winrm

s = winrm.Session("192.168.33.30", auth=("vagrant", "vagrant"))
r = s.run_cmd("ipconfig", ["/all"])

out = r.std_out
print(out.decode('ascii'))
