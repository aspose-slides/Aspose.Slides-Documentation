---
title: 系統需求
type: docs
weight: 60
url: /zh-hant/net/system-requirements/
keywords:
- 系統需求
- 作業系統
- 安裝
- 相依性
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 的系統需求。確保在 Windows、Linux 與 macOS 上順暢支援 PowerPoint 與 OpenDocument。"
---
## **簡介**

Aspose.Slides for .NET 不需要安裝 Microsoft PowerPoint，因為 Aspose.Slides 是一個獨立的 Microsoft PowerPoint 文件建立、轉換、頁面佈局與渲染引擎。

## **支援的作業系統**

Aspose.Slides for .NET 支援任何已安裝 .NET 或 Mono 框架的 32 位元或 64 位元作業系統，包括（但不限於）：

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux（Ubuntu、OpenSUSE、CentOS、Alpine 等）

### **Mac**

- Mac OS X

## **支援的框架**

Aspose.Slides for .NET 支援 .NET 與 Mono 框架：

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Mono 框架**

- 在 Mac 與 Linux 平台上支援 MONO

## **開發環境**

Aspose.Slides for .NET 可以在任何以 .NET 為目標的開發環境中開發應用程式，但以下環境已明確支援：

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides 主要建置**

目前，Aspose.Slides 有兩個主要建置——Aspose.Slides.NET 與 Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

這是產品的主要版本。它使用標準的 .NET 圖形引擎。
- 在非 Windows 平台上，可能需要安裝 `libgdiplus` 函式庫及其相依項。
- 在 Aspose.Slides 25.3 版之前，對於非 Windows 平台，需要使用來自 Aspose.Slides ZIP 套件的 .NET Standard 2.0 DLL。
- 從 Aspose.Slides 25.3 版開始，NuGet 套件可直接在非 Windows 系統上使用。
- 在非 Windows 系統上執行時，您的應用程式必須在啟動時加入以下程式碼行：
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **從 25.3 版起，您可以在支援 .NET 的平台（如 Linux aarch64 (ARM64)）上使用此套件。**

#### **Additional Packages for Linux Alpine**

在 Alpine Linux 容器中執行 Aspose.Slides for .NET 時，僅安裝 `libgdiplus` 可能不足。Alpine 容器預設通常不包含字型。如果沒有字型，可渲染或轉換作業會失敗，錯誤類似於：

```text
System.ArgumentException: Font '?' cannot be found
```
若要在 Alpine 上使用 Aspose.Slides，請同時安裝 `libgdiplus` 與至少一個字型套件。

**選項 1：DejaVu 字型**

建議的做法是安裝 ttf-dejavu 套件：

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` 套件會自動安裝所需的字型相關相依項，如 `fontconfig`、`encodings`、`mkfontscale` 與 `mkfontdir`。大多數使用情境不需要額外的字型套件。

**選項 2：Microsoft Core Fonts**

如果您的簡報使用 Microsoft 專屬字型（例如 Arial、Times New Roman、Courier New 或 Verdana），請改為安裝 Microsoft Core Fonts：

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

僅在處理的簡報確實需要 Microsoft 字型時才使用此選項。對於大多數情境，安裝 `ttf-dejavu` 更簡單且更可靠。

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

這是 Aspose.Slides 使用由 Aspose.Slides 團隊開發的自訂跨平台圖形引擎的版本。  
在非 Windows 平台上，可能需要 `fontconfig` 函式庫。

**支援的平台**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**不支援的平台**
- *Windows 11 ARM* (ARM64) — *目前尚未考慮*

{{%  alert  title="Notes"  color="primary"  %}}  
對於 Linux x64，需要 GLIBC 2.23 以上；對於 Linux ARM64，需要 GLIBC 2.39 以上。CentOS 7（GLIBC 2.14）等系統不受支援。如果需要在 CentOS 7 或其他不相容系統（例如 Alpine）上執行 Aspose.Slides，請改用標準套件：[Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET)。  
{{% /alert %}} 

## **常見問題**

**Do I need Microsoft PowerPoint installed for conversions and rendering?**

不需要安裝 PowerPoint；Aspose.Slides 是一個獨立的引擎，可用於[建立](/slides/zh-hant/net/create-presentation/)、修改、[轉換](/slides/zh-hant/net/convert-presentation/)以及[渲染](/slides/zh-hant/net/convert-powerpoint-to-png/)簡報。

**Which fonts are needed for correct rendering?**

簡報中使用的字型或其適當的替代字型必須在作業系統中可用。於 Linux 與 macOS 上，請安裝常見的字型套件以確保渲染一致。

對於 Alpine Linux 容器，必須在安裝 `libgdiplus` 之外，再安裝至少一個字型套件。建議的最小配置是 `libgdiplus` 搭配 `ttf-dejavu`。若需要 Microsoft 字型（如 Arial、Times New Roman、Courier New 或 Verdana），請同時安裝 `msttcorefonts-installer` 與 `fontconfig`。

**Why does a custom font render as a fallback or missing text on Linux?**

若字型檔的 name‑table 項目不一致或損毀，Linux 的字型匹配堆疊（FreeType/fontconfig）可能會選取無效的記錄，導致字型無法解析。使用已修正 name‑table 的字型版本或安裝一致的替代字型即可解決此問題。