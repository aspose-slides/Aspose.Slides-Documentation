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
description: "了解如何快速安裝 Aspose.Slides for .NET。步驟說明、系統需求與程式碼範例 —— 今天就開始使用 PowerPoint 簡報！"
---
## **概覽**

本文說明如何在 Windows 與 macOS 上安裝 Aspose.Slides for .NET。重點在於使用 NuGet 進行安裝，並展示如何在 Windows 上透過 NuGet 套件管理員或套件管理員主控台將函式庫加入 Visual Studio 專案。亦說明如何更新套件以及在需要時安裝預發佈版。

## **Windows**
NuGet 為在 PC 上下載與安裝 Aspose .NET API 提供最簡單的途徑。

### **方法 1：從 NuGet 套件管理員安裝或更新 Aspose.Slides**

1. 開啟 Microsoft Visual Studio。  
2. 建立簡單的主控台應用程式或開啟既有專案。  
3. 依序選取 **Tools** > **NuGet package manager**。  
4. 在 **Browse** 中的文字欄位搜尋 *Aspose Slides*。  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. 點選 **Aspose.Slides.NET**，再點選 **Install**。  
   * 若要更新已安裝的 Aspose.Slides，請點選 **Update**。

選取的 API 會下載並在專案中加入參照。

### **方法 2：透過套件管理員主控台安裝或更新 Aspose.Slides**

以下示範如何在套件管理員主控台中引用 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/)：

1. 開啟 Microsoft Visual Studio。  
2. 建立簡單的主控台應用程式或開啟既有專案。  
3. 依序選取 **Tools** > **Library Package Manager** > **Package Manager Console**。  
![todo:image_alt_text](installation_2.png)
4. 執行以下指令： `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
最新的正式版會安裝至您的應用程式中。

* 亦可在指令後加上 `-prerelease` 後綴，以安裝包含最新修補程式的預發佈版。

視窗底部會出現 **Installing Aspose.Slides.NET** 的提示。  
![todo:image_alt_text](installation_4.png)

下載完成後，您應會看到確認訊息。

如果您不熟悉 [Aspose EULA](https://about.aspose.com/legal/eula)，建議先閱讀網址中提供的授權條款。  
![todo:image_alt_text](installation_5.png)

在您的應用程式中，應可看到 Aspose.Slides 已成功加入並被參照。  
![todo:image_alt_text](installation_6.png)

在套件管理員主控台中，您可以執行 `Update-Package Aspose.Slides.NET` 以檢查 Aspose.Slides 套件是否有更新。若有更新會自動安裝，亦可使用 `-prerelease` 後綴更新至最新預發佈版。

#### **在共享伺服器環境執行時的考量**
我們強烈建議在 **Full Trust** 權限設定下執行所有 Aspose .NET 元件，因為某些 Aspose 元件可能需要存取註冊表設定或位於虛擬目錄以外的檔案——例如讀取字型時。

此外，Aspose.NET 元件基於 .NET 核心系統類別，而某些類別在特定情況下也需要 **Full Trust** 權限才能執行。

提供多家公司應用程式的 ISP 通常只允許 **Medium Trust** 安全等級。在 .NET 2.0 環境下，此安全等級可能會限制 Aspose.Slides 的以下操作：

- **RegistryPermission** 不可用，無法存取註冊表，導致無法列舉已安裝的字型以進行文件渲染。  
- **FileIOPermission** 受限，只能存取應用程式虛擬目錄層級內的檔案，亦可能導致匯出時無法讀取字型。

基於以上原因，我們強烈建議以 **Full Trust** 權限執行 Aspose.Slides。若採用 **Medium Trust**，可能會出現功能不一致的情況，例如渲染等功能在特定任務下無法正常運作。

## **macOS**

NuGet 為在 mac 上下載與安裝 Aspose.Slides for .NET 提供最簡單的途徑。

**安裝前置條件**

macOS 中的 `System.Drawing` 命名空間運作方式不同，必須安裝 mono-libgdiplus。

> 在 .NET 5 以及之前的版本中，[System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet 套件可在 Windows、Linux 與 macOS 上使用，但平台之間仍有差異。在 Linux 與 macOS 上，GDI+ 功能由 [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/) 函式庫實作。此函式庫在多數 Linux 發行版中預設未安裝，且在 Windows 與 macOS 上的 GDI+ 功能支援不完整。部分平台甚至根本沒有 libgdiplus。若要在 Linux 與 macOS 上使用 System.Drawing.Common 套件的型別，必須自行安裝 libgdiplus。更多資訊請參閱 [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) 或 [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s

若要在 mac 上獨立安裝 mono-libgdiplus，請參考 .NET 文件中的 [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)。

### **安裝 Aspose.Slides**

1. 開啟 Visual Studio。  
2. 建立簡單的主控台應用程式或開啟既有專案。  
3. 依序選取 **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. 在文字欄位輸入 *Aspose.Slides*。  
5. 點選 **Aspose.Slides for .NET**，再點選 **Add Package**。  
6. 加入簡單的程式碼片段。  
   * 您可以複製 [this page](/slides/zh-hant/net/create-presentation/) 中的程式碼。  
7. 執行應用程式。  
8. 開啟專案的 *folder/bin/Debug/presentation_file_name*。

## **FAQ**

**是否有免費版或試用限制？**

是的，預設情況下 Aspose.Slides 以評估模式執行，會加上浮水印並可能有其他限制。若要解除限制，必須套用有效的 [license](/slides/zh-hant/net/licensing/)。