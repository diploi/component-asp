#!/usr/bin/env bash
set -eu

WATCH_PID_FILE=/tmp/dotnet-watch.pid

echo "---REBUILDING PROJECT---"
dotnet build

if [[ -f "$WATCH_PID_FILE" ]]; then
    PID=$(cat "$WATCH_PID_FILE")
    echo "Restarting dotnet watch (PID=$PID)"
    kill -TERM "$PID" 2>/dev/null || true
    rm -f "$WATCH_PID_FILE"
fi
