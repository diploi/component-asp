#!/usr/bin/env bash
set -eu

PORT=5103

echo "=== Waiting for port ${PORT} to be free ==="
while netstat -ltn 2>/dev/null | grep -q ":${PORT} "; do
    sleep 0.2
done

echo "=== Building project (fresh graph) ==="
dotnet build --no-incremental

echo "=== Starting dotnet watch ==="
exec dotnet watch run \
    --no-launch-profile \
    --non-interactive \
    /p:UseSharedCompilation=false