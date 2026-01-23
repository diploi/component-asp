#!/usr/bin/env bash
set -eu

export DOTNET_USE_POLLING_FILE_WATCHER=1

echo "Dotnet build in process-------"
dotnet build


echo "Dotnet watch in process-------"
exec dotnet watch run \
    --no-launch-profile \
    --non-interactive \
    /p:UseSharedCompilation=false