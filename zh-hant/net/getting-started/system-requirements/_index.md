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
description: "探索 Aspose.Slides for .NET 系統需求。確保在 Windows、Linux 與 macOS 上無縫支援 PowerPoint 與 OpenDocument。"
---
## **簡介**

Aspose.Slides for .NET 不需要安裝 Microsoft PowerPoint，因為 Aspose.Slides 是一個獨立的 Microsoft PowerPoint 文件建立、轉換、頁面佈局與渲染引擎。

## **支援的作業系統**

Aspose.Slides for .NET 支援任何已安裝 .NET 或 Mono 框架的 32 位元或 64 位元作業系統，包括（但不限於）：

### **Windows**

- Microsoft Windows 2000 伺服器 (x64, x86)
- Microsoft Windows 2003 伺服器 (x64, x86)
- Microsoft Windows 2022 伺服器
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8、8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
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
- COM Interop 支援 (COM、C++、VBScript)

### **Mono Framework**

- 在 MAC 與 Linux 平台上支援 MONO

## **開發環境**

Aspose.Slides for .NET 可在任何目標為 .NET 平台的開發環境中使用，但以下環境明確受支援：

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides 主要版本**

目前，Aspose.Slides 有兩個主要的 Build — Aspose.Slides.NET 與 Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

這是產品的主要版本。它使用標準的 .NET 圖形引擎。
- 在非 Windows 平台上，可能需要安裝 `libgdiplus` 程式庫及其相依性。
- 在 Aspose.Slides 25.3 版之前，於非 Windows 平台需要使用 Aspose.Slides ZIP 套件中的 .NET Standard 2.0 DLL。
- 從 Aspose.Slides 25.3 版開始，即使在非 Windows 系統上也能直接使用 NuGet 套件。
- 在非 Windows 系統執行時，應用程式必須在啟動時加入以下程式碼：
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **從 25.3 版開始，您可以在支援 .NET 的平台上使用此套件，例如 Linux aarch64 (ARM64)。**

#### **Linux Alpine 的其他套件**

在 Alpine Linux 容器中執行 Aspose.Slides for .NET 時，僅安裝 `libgdiplus` 可能不足。Alpine 容器預設通常不包含字型。若系統沒有字型，渲染或轉換操作可能會失敗並出現類似以下的錯誤：

```text
System.ArgumentException: Font '?' cannot be found
```
要在 Alpine 上使用 Aspose.Slides，需將 `libgdiplus` 與至少一個字型套件一起安裝。

**選項 1：DejaVu 字型**

建議的作法是安裝 ttf-dejavu 套件：

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` 套件會自動安裝所需的字型相關相依性，如 `fontconfig`、`encodings`、`mkfontscale` 與 `mkfontdir`。大多數情況下不需要額外的字型套件。

**選項 2：Microsoft Core Fonts**

如果簡報使用 Microsoft 特有的字型，如 Arial、Times New Roman、Courier New 或 Verdana，請改為安裝 Microsoft Core Fonts：

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

僅在需要 Microsoft 字型的簡報時才使用此選項。大多數情況下，安裝 `ttf-dejavu` 更簡單且更可靠。

**全球化的其他需求**

為在 Alpine 上啟用適當的全球化支援，請安裝 `icu-libs` 套件並關閉 invariant 模式：

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

這是 Aspose.Slides 使用由 Aspose.Slides 團隊開發的自訂跨平台圖形引擎的版本。  
在非 Windows 平台上，可能需要 `fontconfig` 程式庫。

**支援的平台**
- *Windows*：x86、x86_64  
- *Linux*：x86_64、ARM64 (aarch64)  
- *macOS*：x86_64、ARM64 (aarch64)

**不支援的平台**
- *Windows 11 ARM*（ARM64）—*目前不考慮支援*

{{%  alert  title="Notes"  color="primary"  %}}  
對於 Linux x64，需要 GLIBC 2.23 以上；對於 Linux ARM64，需要 GLIBC 2.39 以上。CentOS 7（GLIBC 2.14）等系統不受支援。如果需要在 CentOS 7 或其他不相容的系統（例如 Alpine）上執行 Aspose.Slides，請使用標準套件：[Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET)。  
{{% /alert %}} 

## **常見問題**

**我需要安裝 Microsoft PowerPoint 才能進行轉換和渲染嗎？**

不，需要。PowerPoint 並非必要；Aspose.Slides 是一個獨立的引擎，可用於[建立](/slides/zh-hant/net/create-presentation/)、修改、[轉換](/slides/zh-hant/net/convert-presentation/)以及[渲染](/slides/zh-hant/net/convert-powerpoint-to-png/)簡報。

**正確渲染需要哪些字型？**

簡報中使用的字型或其相容的替代字型必須在作業系統中可用。於 Linux 與 macOS 上，請安裝常見的字型套件以確保一致的渲染。  
對於 Alpine Linux 容器，除 `libgdiplus` 外，還需安裝至少一個字型套件。建議的最小配置為 `libgdiplus` 搭配 `ttf-dejavu`。若需要 Microsoft 字型（例如 Arial、Times New Roman、Courier New 或 Verdana），請同時安裝 `msttcorefonts-installer` 與 `fontconfig`。

**為何自訂字型在 Linux 上會以備援或缺少文字方式呈現？**

若字型檔的名稱表條目不一致或損毀，Linux 的字型匹配堆疊（FreeType/fontconfig）可能會選取無效的記錄，導致字型無法解析。使用已修正名稱表的字型版本或安裝一致的替代字型即可解決此問題。