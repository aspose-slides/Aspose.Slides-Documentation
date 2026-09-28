---
title: 適用於 .NET 6 及更高版本的跨平台套件
linktitle: 跨平台套件
type: docs
weight: 235
url: /zh-hant/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- 跨平台
- .NET 6 支援
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "了解何時使用 Aspose.Slides.NET6.CrossPlatform 套件：它存在的原因、支援的平臺，以及在 Linux 上取代 libgdiplus 的需求。"
---
## **簡介**

Aspose.Slides for .NET 以兩個 NuGet 套件形式發行。[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 透過 Microsoft 的 System.Drawing.Common 函式庫繪製投影片。[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 則改用自行的圖形引擎。本篇說明第二個套件存在的原因、可執行的平台、在 Linux 上的需求，以及如何在同一個專案中與 System.Drawing.Common 共存。

## **為何使用獨立套件**

從 .NET 6 開始，Microsoft 只在 Windows 上支援 System.Drawing.Common [only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)。因此，在 Linux 上 Aspose.Slides.NET 需要 `System.Drawing.EnableUnixSupport` 開關以及 `libgdiplus` 程式庫；若專案參考 System.Drawing.Common 7 或更新版本，就會在 Linux 失敗。[系統需求](/slides/zh-hant/net/system-requirements/) 說明了這些條件。

Aspose.Slides.NET6.CrossPlatform 不使用 System.Drawing.Common 或 `libgdiplus`。它的圖形引擎是套件內含的原生程式庫，每支援平台都有一個建置。兩個套件提供相同的 Aspose.Slides 命名空間與類別，因此切換套件只需要更改套件參考，程式碼本身不需要變更。

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| 圖形 | System.Drawing.Common | 套件內含的原生圖形引擎 |
| 目標框架 | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux 要求 | `libgdiplus` 與 `System.Drawing.EnableUnixSupport` 開關 | `fontconfig` |
| Alpine Linux | 支援 | 不支援 |

## **支援平台**

Aspose.Slides.NET6.CrossPlatform 在以下平台上可與 .NET 6 及更高版本一起使用：

- **Windows**：x86 與 x64。原生程式庫使用 Microsoft Visual C++ 執行時；請參閱[系統需求](/slides/zh-hant/net/system-requirements/)。
- **Linux**：x64（glibc 2.23 以上）以及 ARM64（glibc 2.39 以上）。
- **macOS**：x64（Intel）與 ARM64（Apple silicon）。

它不支援 Windows ARM64、基於 musl 的 Alpine Linux 或其他使用舊版 glibc（例如 CentOS 7）的發行版。這些系統請使用 Aspose.Slides.NET。

## **在 Linux 上安裝**

在 Linux 上，套件只需要 `fontconfig` 程式庫，無需 `libgdiplus`。在 Debian 和 Ubuntu 上，先安裝 `fontconfig`，再將套件加入專案：

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

在 Debian 和 Ubuntu 上，`libfontconfig1` 也會安裝 DejaVu 字型，因此文字可以直接呈現，無需額外的字型套件。若缺少 `fontconfig`，建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 會拋出 `TypeInitializationException`，其內部的 `DllNotFoundException` 會指出找不到 `libfontconfig.so.1`。[系統需求](/slides/zh-hant/net/system-requirements/) 含有一段簡短程式碼可檢查設定。

## **雲端與容器主機**

因為不需要 `libgdiplus`，在無法安裝 `libgdiplus` 的 Linux 主機上，應使用 Aspose.Slides.NET6.CrossPlatform。仍然需要 `fontconfig` 與字型，最小化基礎映像可能缺少這些。例如 .NET 8 的 AWS Lambda 基礎映像就兩者皆無。於基於該映像的容器中，執行 `dnf install -y fontconfig`，即可同時安裝 Noto Sans 字型。

欲取得特定雲端平台的操作指南，請參閱 [Aspose.Slides 在雲端平台](/slides/zh-hant/net/slides-on-cloud-platforms/)。

## **在同一專案中使用 System.Drawing.Common (CS0433)**

使用 Aspose.Slides.NET6.CrossPlatform 的專案也可以同時參考 System.Drawing.Common，無論是直接或透過其他套件。Aspose.Slides 目前的版本在 `System` 命名空間中未公開任何類型，因此兩個函式庫不會衝突，您可以在同一檔案中同時 `using Aspose.Slides` 與 `using System.Drawing`。

若編譯器因 `Image`、`Graphics` 等型別同時存在於 Aspose.Slides 與 System.Drawing.Common 而回報 CS0433，表示您的專案使用了較舊的 Aspose.Slides 版次。請將套件升級至最新版本。Aspose.Slides 會以 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 物件回傳渲染後的圖像，相關說明請見 [現代 API](/slides/zh-hant/net/modern-api/)。

## **常見問題**

**切換從 Aspose.Slides.NET 到 Aspose.Slides.NET6.CrossPlatform 時，需要修改程式碼嗎？**

不需要。兩個套件提供相同的 Aspose.Slides 命名空間與類別，您只需更換套件參考。Aspose.Slides.NET6.CrossPlatform 不需要 `System.Drawing.EnableUnixSupport` 開關。專案中只加入其中一個套件即可。

**可以在 .NET Framework 專案中使用 Aspose.Slides.NET6.CrossPlatform 嗎？**

不行。此套件僅支援 .NET 6 及更高版本。欲在 .NET Framework 4.6.2 以上使用，請改用 Aspose.Slides.NET。