#!/bin/sh
bundleVersion=$(cat ../ProjectSettings/ProjectSettings.asset|grep bundleVersion|awk '{print $2}')
sed -i "" "s/^version: .*$/version: $bundleVersion/" ./snap/snapcraft.yaml
chmod 777 snap/local/linux.x86_64
docker run --rm -it -v ./build:/build -v ./snap:/build/snap -w /build -v .snapcraft:/root/.snapcraft snapcore/snapcraft snapcraft --destructive-mode

#snapcraft clean
#snapcraft

#sudo snap install game-collector_${bundleVersion}_amd64.snap --dangerous
#snapcraft upload --release=stable game-collector_${bundleVersion}_amd64.snap
