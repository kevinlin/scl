# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

A .NET 10 CLI starter app demonstrating `System.CommandLine` (v2.0.3). It implements a single command that reads a file and prints its contents to stdout via `--file <path>`.

## Build & Run Commands

```bash
dotnet build                          # Build the project
dotnet run -- --file <path>           # Run with a file argument
dotnet watch run --project scl.csproj # Watch mode
```

There are no tests or linting configured.

## Architecture

This is a single-file project — all logic lives in `Program.cs` within the `scl` namespace.

**CLI pattern used:** Manual `ParseResult` inspection (not action-based dispatch). The code calls `rootCommand.Parse(args)`, checks `parseResult.Errors`, and extracts typed values via `parseResult.GetValue(fileOption)` with pattern matching.

## Conventions

- Explicit `class Program` with `static int Main` (not top-level statements, not async)
- Nullable reference types enabled
- Single NuGet dependency: `System.CommandLine` 2.0.3
