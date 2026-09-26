---
title: 安裝
type: docs
weight: 70
url: /zh-hant/net/installation/
keywords:
- 安裝 Aspose.Slides
- 下載 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Windows、Linux 與 macOS 上，從 NuGet 安裝 Aspose.Slides for .NET：在兩個套件之間選擇，以 .NET CLI 或 Visual Studio 加入其中一個，並安裝 Linux 前置需求。"
---
## **概覽**

本文說明如何在 Windows、Linux 和 macOS 專案中加入 Aspose.Slides for .NET。Aspose.Slides 透過 NuGet 發佈。您可以在任何作業系統上使用 .NET CLI 加入，或在 Windows 的 Visual Studio 中使用 NuGet 套件管理員或套件管理員主控台。本文也說明兩個 NuGet 套件的選擇以及 Linux 需要的額外項目。

在安裝之前，請檢查於 [System Requirements](/slides/zh-hant/net/system-requirements/) 中支援的作業系統、.NET 實作以及其他相依性。

## **選擇套件**

Aspose.Slides for .NET 以兩個 NuGet 套件發佈。兩者提供相同的 Aspose.Slides 命名空間與類別，因此切換時程式碼不會變更；只有套件參考和平台需求不同。

| 套件 | 使用情境 | 其他需求 |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows 與 .NET Framework 應用程式 | 在 Linux 與 macOS 上：`libgdiplus` 函式庫，且在應用程式啟動時啟用 `System.Drawing.EnableUnixSupport` 開關 |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 或更新版本於 Windows、Linux 與 macOS 上 | 在 Linux 上：如果尚未安裝則需要 `fontconfig` 函式庫 |

如果不確定，請在 Windows 使用 Aspose.Slides.NET，於 Linux 與 macOS 使用 Aspose.Slides.NET6.CrossPlatform。於 Alpine Linux，或 glibc 版本低於 2.23（x64）或 2.39（ARM64）的 Linux 系統，請改用 Aspose.Slides.NET。[System Requirements](/slides/zh-hant/net/system-requirements/) 列出了每個套件支援的平台。

## **使用 .NET CLI 安裝**

以下步驟適用於 Windows、Linux 與 macOS，使用 .NET SDK 6 或更新版本。建立一個主控台應用程式：

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

然後為您的平台加入套件。請於專案中僅加入其中一個套件。

- 在 Windows：`dotnet add package Aspose.Slides.NET`
- 在 Linux 與 macOS：`dotnet add package Aspose.Slides.NET6.CrossPlatform`（在 Linux 上，請先安裝其前置條件；請參閱 [Linux](#linux)）

為驗證套件是否運作，請將 *Program.cs* 的內容取代為 [Create Presentations](/slides/zh-hant/net/create-presentation/) 中的第一個範例，然後執行 `dotnet run`。它會將 *hello.pptx* 儲存於專案資料夾中。

## **Windows**

### **方法 1：從 NuGet 套件管理員安裝或更新 Aspose.Slides**

1. 開啟 Microsoft Visual Studio。
2. 建立主控台應用程式或開啟現有專案。
3. 在 **Solution Explorer** 中，右鍵點擊專案並選取 **Manage NuGet Packages**（或前往 **Project** > **Manage NuGet Packages**）。
4. 在 **Browse** 下，搜尋 *Aspose.Slides*。
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. 點擊 **Aspose.Slides.NET**，再點擊 **Install**。  
   * 如果您已經安裝 Aspose.Slides 且想更新，請改點 **Update**。

套件已下載並在專案中加入參考。

### **方法 2：透過套件管理員主控台安裝或更新 Aspose.Slides**

以下說明如何透過套件管理員主控台參考 [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 套件：

1. 開啟 Microsoft Visual Studio。
2. 建立主控台應用程式或開啟現有專案。
3. 前往 **Tools** > **NuGet Package Manager** > **Package Manager Console**。
![Opening the Package Manager Console](installation_2.png)
4. 執行以下指令：`Install-Package Aspose.Slides.NET`
![Running the Install-Package command](installation_3.png)
最新版本已安裝於您的專案中。

視窗底部會出現 **Installing Aspose.Slides.NET** 訊息。
![Installation progress in the Package Manager Console](installation_4.png)

下載完成後，會顯示確認訊息。此套件依據 [Aspose EULA](https://about.aspose.com/legal/eula) 發佈。
![Installation confirmation messages](installation_5.png)

Aspose.Slides 現已加入您的專案並成為參考。
![Aspose.Slides referenced in the project](installation_6.png)

若要更新套件，請在套件管理員主控台執行 `Update-Package Aspose.Slides.NET`。

## **Linux**

請使用上述 .NET CLI 步驟。選擇套件並使用您的發行版套件管理員安裝其前置條件。在 Debian 與 Ubuntu 上：

- **Aspose.Slides.NET6.CrossPlatform**：安裝 `fontconfig`。  
  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**：安裝 `libgdiplus`，且在應用程式使用 Aspose.Slides 前啟用 System.Drawing 的 Unix 支援。  
  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

在應用程式開頭、任何 Aspose.Slides 呼叫之前加入此敘述。若在使用頂層語句的 *Program.cs* 中，請於 `using` 指令之後加入：  
```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

在 Alpine Linux 以及 glibc 版本過舊而無法使用 Aspose.Slides.NET6.CrossPlatform 的系統上，請使用此套件。

您簡報所使用的字型或相容替代字型必須安裝於系統上，才能正確呈現文字。[System Requirements](/slides/zh-hant/net/system-requirements/) 說明了 Aspose.Slides.NET 在 Alpine Linux 上所需的套件，包括字型。

## **macOS**

請使用上述 .NET CLI 步驟，搭配 **Aspose.Slides.NET6.CrossPlatform** 套件，該套件支援 Intel (x86_64) 與 Apple silicon (ARM64) 的 Mac：  
```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **常見問題**

**是否有免費版或試用限制？**

是。若未持有授權，Aspose.Slides 會以評估模式執行：會在每張儲存的投影片上加入評估水印，且會截斷從簡報中讀取的文字。若要移除這些限制，請套用有效的 [license](/slides/zh-hant/net/licensing/)。