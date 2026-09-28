---
title: 系統需求
type: docs
weight: 60
url: /zh-hant/net/system-requirements/
keywords:
- 系統需求
- 支援平台
- 目標框架
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在安裝 Aspose.Slides for .NET 之前，檢查其需求：每個 NuGet 套件的目標框架、支援的作業系統與處理器，以及 Linux 所需的函式庫與字型。"
---
## **簡介**

Aspose.Slides for .NET 是一個獨立的函式庫：它不需要 Microsoft PowerPoint 或 Microsoft Office。它以兩個 NuGet 套件的形式發佈，[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 和 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)。兩者提供相同的 Aspose.Slides 命名空間和類別；差異在於它們目標的框架以及繪製投影片的方式，這決定了它們的執行環境和需求。

本文列出每個套件支援的 .NET 版本與平台，以及 Linux 所需的系統函式庫與字型，最後提供一段程式碼來檢查您的環境。若要將套件加入專案，請參考[安裝](/slides/zh-hant/net/installation/)。

## **支援的 .NET 版本**

每個套件在每個目標框架中都包含一個 Aspose.Slides 的組建，NuGet 會選取與您專案目標框架相符合的組建。

| 套件 | 套件中的目標框架 | 您的專案可以針對 |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 或更新版本；.NET 6 或更新版本，包括 .NET 8、.NET 9 與 .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 或更新版本，包括 .NET 8、.NET 9 與 .NET 10 |

`netstandard2.0` 組建允許 .NET Standard 2.0 類別庫參考 Aspose.Slides.NET。使用此類別庫的應用程式會執行與其自身目標框架相符的組建：例如 .NET 8 應用程式會執行 `net6.0` 組建。

## **支援的作業系統與處理器**

**Aspose.Slides.NET** 只包含與處理器無關的（AnyCPU）受管理程式碼，會在載入它的 .NET 執行階段的處理器架構上執行。它透過 Microsoft 的 System.Drawing.Common 函式庫繪製投影片，該函式庫僅在 Windows 上受支援[only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)。在 Linux 上，Aspose.Slides.NET 因此需要 `libgdiplus` 函式庫與啟動開關，相關說明請參閱[Linux](#linux)。它可在提供 `libgdiplus` 的 Linux 發行版上執行，例如 Debian、Ubuntu 與 Alpine Linux。

**Aspose.Slides.NET6.CrossPlatform** 使用自家的圖形引擎繪製投影片。此引擎是原生函式庫，套件在每個平台中各包含一個組建，因此套件僅能在下列平台上執行：

| 作業系統 | 處理器 | 備註 |
|---|---|---|
| Windows | x86, x64 | 不支援在 ARM64 上的 Windows。 |
| Linux | x64, ARM64 | 在 x64 上需要 glibc 2.23 或更新版本，在 ARM64 上需要 glibc 2.39 或更新版本。 |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform 無法在使用 musl 取代 glibc 的 Alpine Linux 或其他發行版，亦無法在 glibc 較舊的發行版（例如 CentOS 7）上執行。此類系統請使用 Aspose.Slides.NET。

在 Windows 上，Aspose.Slides.NET6.CrossPlatform 的原生函式庫使用 Microsoft Visual C++ 執行時庫（*MSVCP140.dll* 與 *VCRUNTIME140.dll*，以及 x64 上的 *VCRUNTIME140_1.dll*）。如果目標機器缺少這些檔案，請安裝[Microsoft Visual C++ 可轉發元件](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170)。

## **Linux**

兩個套件在 Linux 上皆需要額外的系統函式庫。若缺少這些函式庫，[建立簡報](/slides/zh-hant/net/create-presentation/) 範例的第一段程式會拋出例外而非成功儲存檔案。以下指令適用於 Debian 與 Ubuntu；在這些發行版中，每個函式庫亦會安裝 DejaVu 字型（`fonts-dejavu-core`），因此文字可在未安裝其他字型套件的情況下正確呈現。

### **Aspose.Slides.NET6.CrossPlatform**

此套件的 Linux 函式庫需要 `fontconfig` 函式庫：

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

如果缺少它，建立[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 會因 `TypeInitializationException`，其內部的 `DllNotFoundException` 會指出找不到 `libfontconfig.so.1` 而失敗。

最小基礎映像可能也不包含 `fontconfig`。例如 .NET 8 的 AWS Lambda 基礎映像既沒有 `fontconfig` 也沒有任何字型。若在其上建構容器映像，請執行 `dnf install -y fontconfig`，此指令亦會安裝 Noto Sans 字型。

### **Aspose.Slides.NET**

此套件在 Linux 上需要兩項內容：

1. `libgdiplus` 函式庫：

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. `System.Drawing.EnableUnixSupport` 開關，必須在任何 Aspose.Slides 呼叫之前於應用程式啟動時啟用。若使用包含頂層敘述式的 *Program.cs*，請在 `using` 指示詞之後加入：

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

如果沒有 `libgdiplus`，儲存簡報會因 `TypeInitializationException`（其內部的 `DllNotFoundException` 表示無法載入 `libgdiplus`）而失敗。若未啟用開關，內部例外會是 `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`。

{{% alert color="warning" title="Warning" %}}
此開關僅適用於 Aspose.Slides.NET 所依賴的 System.Drawing.Common 6 版。Microsoft 已在 System.Drawing.Common 7 中移除它。若您的專案直接或透過其他套件參考 System.Drawing.Common 7 或更新版，即使已安裝 `libgdiplus` 且啟用了開關，Aspose.Slides.NET 仍會在 Linux 上拋出 `PlatformNotSupportedException`。此情況請改用 Aspose.Slides.NET6.CrossPlatform。
{{% /alert %}}

### **Alpine Linux**

在 Alpine Linux 上，請使用帶有上述開關的 Aspose.Slides.NET。Alpine 映像通常不含任何字型，且單獨安裝 `libgdiplus` 也不會安裝字型，因此必須同時安裝 `libgdiplus` 與至少一個字型套件。缺少字型會導致儲存簡報時出現以下錯誤：

```text
System.ArgumentException: Font '?' cannot be found.
```

**選項 1：DejaVu 字型**

建議使用 `ttf-dejavu` 套件：

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

在目前的 Alpine 版本中，`ttf-dejavu` 會安裝 `font-dejavu` 套件，該套件同時會安裝 `fontconfig` 與其相依的字型工具。

**選項 2：Microsoft 核心字型**

若您的簡報使用 Microsoft 字型（例如 Arial、Times New Roman、Courier New 或 Verdana），可以改為安裝 Microsoft 核心字型。`update-ms-fonts` 步驟會在建構映像時下載字型，因此建構過程需要網路存取：

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **全球化支援**

兩個套件都需要 .NET 的全球化支援，Linux 上的 .NET 透過 ICU 函式庫提供。若以[globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) 執行，建立[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 會拋出 `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`。

某些容器映像會開啟此模式。例如 Alpine Linux 的 .NET 執行階段映像（`runtime-deps`、`runtime`、`aspnet`）會設定 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true`，且未包含 ICU。若在此類映像上建構，請安裝 ICU 並關閉此模式：

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

同時也請確保您的專案檔未將 `InvariantGlobalization` 屬性設為 `true`。

## **檢查設定**

要驗證套件與其需求是否已就位，請執行一個儲存簡報並將投影片渲染為影像的程式。儲存與渲染會使用圖形函式庫與字型，正是上述 Linux 要求所提供的。

建立一個主控台應用程式，依照[安裝](/slides/zh-hant/net/installation/)說明加入套件，將 *Program.cs* 內容取代為以下程式碼，然後執行 `dotnet run`。若在 Linux 上使用 Aspose.Slides.NET，請在 `using` 指示詞之後加入前述的 `System.Drawing.EnableUnixSupport` 開關敘述式。此程式使用頂層敘述式與 `using` 宣告，需要 C# 9 或更新版。目標 .NET 6 或更新版的專案預設使用較新 C# 版本；若目標 .NET Framework，請在專案檔的 `PropertyGroup` 中加入 `<LangVersion>latest</LangVersion>`。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

程式會在第一張投影片上加入帶文字的矩形，並使用 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法將簡報儲存為 *hello.pptx*。接著使用 [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) 渲染投影片，並以 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 以 [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 格式儲存為 *hello.png*。比例因子 1 會使每點對應一像素，因此預設的 720 × 540 點投影片會變成 720 × 540 像素的圖像，文字可見於矩形內。若未授權，兩個檔案皆會帶有評估水印；詳情請參閱[授權](/slides/zh-hant/net/licensing/)。若缺少任何需求，程式會因前述的例外而終止。

## **開發工具**

您可以使用任何支援專案目標框架的工具來建置使用 Aspose.Slides 的應用程式：Windows、Linux、macOS 上的 .NET SDK 及其 `dotnet` 命令列介面，或 Windows 上的 Visual Studio。[安裝](/slides/zh-hant/net/installation/) 內容已說明兩者的使用方式。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 來執行轉換與渲染嗎？**

不需要。PowerPoint 並非必備。Aspose.Slides 是一個獨立的引擎，可用於[建立](/slides/zh-hant/net/create-presentation/)、修改、[轉換](/slides/zh-hant/net/convert-presentation/)以及[渲染](/slides/zh-hant/net/convert-powerpoint-to-png/)簡報。

**我應該使用哪一個套件？**

在 Windows 上使用 Aspose.Slides.NET；在 Linux 與 macOS 上使用 Aspose.Slides.NET6.CrossPlatform。若是在 Alpine Linux、glibc 版本較舊的 Linux 系統，或是目標 .NET Framework 的專案，請使用 Aspose.Slides.NET。每個專案只能加入其中一個套件。

**需要哪些字型才能正確渲染？**

簡報中使用的字型（或相容的替代字型）必須在作業系統中可用。於 Linux 與 macOS 上，請安裝簡報所需的字型套件以確保渲染一致性。於 Alpine Linux 上，除 `libgdiplus` 外，請至少安裝一個字型套件，詳情請參考[Alpine Linux](#alpine-linux)。

**為什麼自訂字型在 Linux 上會被降級為備用字型或顯示為缺少文字？**

若字型檔的 name-table 記錄不一致或已損毀，Linux 的字型匹配堆疊（FreeType/fontconfig）可能會選取無效的記錄，導致字型無法解析。使用已修正 name-table 記錄的字型版本或安裝一致的替代字型即可解決此問題。