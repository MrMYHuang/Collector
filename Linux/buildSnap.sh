#!/bin/sh
snapcraft clean --destructive-mode
snapcraft --destructive-mode
#sudo snap install game-collector_1.0.1_amd64.snap --dangerous
snapcraft upload --release=stable game-collector_1.0.2_amd64.snap
