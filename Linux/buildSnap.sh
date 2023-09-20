#!/bin/sh
chmod 777 snap/local/linux.x86_64
snapcraft clean
snapcraft
sudo snap install game-collector_1.0.8_amd64.snap --dangerous
snapcraft upload --release=stable game-collector_1.0.8_amd64.snap
