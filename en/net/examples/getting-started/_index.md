---
title: "Run the .NET Examples"
type: docs
weight: 1
url: /net/examples/getting-started/
description: "Download, restore, build and run complete Aspose.Slides for .NET example projects in Rider, Visual Studio, VS Code or the .NET CLI."
---

Each [example](/slides/net/examples/) has a complete project download, including the examples in **Elements**. Extract the whole ZIP into a writable directory. Keep the included configuration, source, fixtures and fonts together.

## Install a supported SDK

Install the current [.NET 10 LTS SDK](https://dotnet.microsoft.com/download/dotnet/10.0) for your operating system and processor. An SDK includes the build tools and runtime; a runtime alone cannot build a project. Use an IDE version that supports your installed SDK.

These projects target `net8.0` with C# 12. The included `global.json` accepts stable SDKs from 8.0.100 onward; it does not require that exact SDK. Explicit major runtime roll-forward allows the application to run on .NET 10 when .NET 8 is absent. The target remains the same whichever SDK builds it. .NET 8 and 9 reach end of support on **November 10, 2026**; use .NET 10 for new installations. See Microsoft's [support policy](https://dotnet.microsoft.com/platform/support/policy) and [.NET 10 operating systems](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md).

## Open and run

| Environment | Steps |
| --- | --- |
| Rider | Open `Example.sln`, allow NuGet restore to finish, then run the `Example` project. The default restore and MSBuild restore both need a compatible installed SDK. |
| Visual Studio | Open `Example.sln` in a version supporting your SDK, wait for package restore, then start `Example`. Visual Studio 2022 can use its supported .NET 8 toolchain; a newer SDK may require a newer Visual Studio. |
| VS Code | Open the extracted folder and install Microsoft's **C#** extension. Select the included **Run example (evaluation)** debug configuration. Its build task restores packages before building. C# Dev Kit is optional. |
| Terminal | Run the commands below from the directory containing `Example.sln`. |

```text
dotnet restore Example.sln
dotnet build Example.sln -c Release --no-restore
dotnet run --project Example.csproj -c Release --no-build -- --mode evaluation
```

An ordinary `dotnet run --project Example.csproj -c Release` also restores and builds automatically. A direct MSBuild **Build** operation does not necessarily restore. For direct MSBuild, use separate **Restore** and **Build** operations with the same toolchain.

The initial restore needs HTTPS access to NuGet.org. The project-local `NuGet.Config` selects that public source so unrelated machine feeds do not block the examples. Package versions are specified in the project; consumer restore is not locked. Offline runs are possible after packages and any separately documented resources have been acquired.

## Native dependencies and fonts

The downloads use **Aspose.Slides.NET6.CrossPlatform 26.10.0**. This package does not require PowerPoint or `libgdiplus`. Its platform requirements and the chosen .NET runtime's OS requirements both apply. See [Aspose.Slides system requirements](/slides/net/system-requirements/) and the [cross-platform package guide](/slides/net/net6/).

| Platform | Prerequisites |
| --- | --- |
| Windows x64 | A supported Windows version and the Microsoft Visual C++ runtime required by the package. Use x64 SDKs for these downloads. |
| Linux x64 | glibc 2.23 or newer, fontconfig, usable fonts and ICU. Ubuntu 24.04 is a reference environment. |
| Linux ARM64 | glibc 2.39 or newer, fontconfig, usable fonts and ICU. Ubuntu 24.04 ARM64 meets the glibc minimum. |
| macOS x64 or ARM64 | A macOS version supported by the installed .NET runtime, plus fontconfig. For .NET 10, use macOS 15 or later. With Homebrew, install it using `brew install fontconfig`. |

On Ubuntu 24.04, install rendering dependencies using:

```text
sudo apt-get update
sudo apt-get install -y libfontconfig1 fonts-dejavu-core libicu74
```

Alpine/musl, native Windows ARM64 and older glibc environments require a different, separately validated package profile. Windows x86 is outside the verified download configuration.

Noto Sans and its OFL license are included and loaded by the example. Arabic/CJK font examples document their additional downloads. The Docker example supplies its own Linux dependency setup. Use each article's prerequisites for AI, certificates and host services.

## Evaluation and licensed runs

The default is evaluation mode when no license is configured. It produces real output with the SDK's evaluation watermark and text restrictions. The checks account for these restrictions without removing the watermark. A successful evaluation run does not promise unrestricted output or full text read-back.

For unrestricted operations, supply an authorized license covering the package release through `ASPOSE_LICENSE_PATH`, or use:

```text
dotnet run --project Example.csproj -c Release -- --mode licensed --license /path/to/Aspose.Slides.NET.lic
```

Explicit `--mode evaluation` ignores license settings. Do not add licenses, API credentials or certificate private keys to the downloaded project. AI examples require their documented licensed mode, model configuration and explicit network opt-in. An actionable missing-prerequisite message does not count as an AI operation passing.

## Outputs and results

The application prints its absolute output directory. By default it uses an `output` workspace beside the built application. Supply `--output DIRECTORY` to select another location. Fixtures are copied into this workspace; the originals in the download remain unchanged. Repeated runs can replace files in that selected output directory.

`execution.json` records the actions, semantic checks, evaluation/licensed mode and actual runtime used. Exit code **0** means the selected functional checks passed, **1** means a failure, and **2** means an unmet prerequisite. Elements projects run every displayed recipe in sequence; the source for each recipe is included separately.

Application integration examples have additional entry points. Follow their article commands for API self-tests, background-worker self-tests and container verification. Starting a service alone does not prove a request or conversion succeeded.

## Troubleshoot the first build

| Symptom | Resolution |
| --- | --- |
| `NETSDK1004`, missing `project.assets.json` | Restore `Example.sln` with the same compatible toolchain used for the build. Check the restore output first; the missing file is usually a consequence of a failed or omitted restore. |
| SDK not found | Install a supported SDK and check `dotnet --list-sdks`. In Rider, check the selected .NET CLI/MSBuild toolset. In Visual Studio, use a version supporting that SDK. |
| `NU1301` or download failure | Check HTTPS access to NuGet.org, your proxy and certificate settings. Keep the project-local NuGet configuration. |
| Native library/font error | Install the platform dependencies above and confirm the process architecture matches the SDK and native package. |
| Wrong font or missing glyph | Keep the supplied `Fonts` folder and acquire any additional fonts required by that article. |
| Exit code 2 | Read the named prerequisite in the console and `execution.json`; supply it and rerun that action. |

The repository's [.NET example workflow](https://github.com/aspose-slides/Aspose.Slides-Documentation/actions/workflows/examples-net.yml) restores, builds and runs fresh evaluation downloads on native Windows, Linux x64/ARM64 and macOS x64/ARM64 runners. Its results distinguish functional passes from expected prerequisite diagnostics for AI configuration or an unavailable Docker engine; a diagnostic does not verify that operation. It does not upload private licenses or AI credentials.
