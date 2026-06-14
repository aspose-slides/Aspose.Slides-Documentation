---
title: 安裝
type: docs
weight: 70
url: /zh-hant/cpp/installation/
keywords:
- 安裝 Aspose.Slides
- 下載 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何快速安裝 Aspose.Slides for C++。一步步指南、系統需求與程式碼範例 —— 立即開始使用 PowerPoint 簡報！"
---
## **概述**

本文說明如何在 Windows 上安裝 Aspose.Slides。它重點介紹基於 NuGet 的安裝，並展示如何透過 NuGet 套件管理員或套件管理員主控台在 Windows 上將此函式庫加入 Visual Studio 專案。它亦說明如何更新套件以及在需要時安裝預先發行版。

## **Windows**
NuGet 提供了在個人電腦上下載與安裝 Aspose C++ API 的最簡單途徑。 

### **選項一：從 NuGet 套件管理員安裝或更新 Aspose.Slides for C++**

1. 開啟 Microsoft Visual Studio。 
2. 建立一個簡易的主控台應用程式。或是開啟您偏好的專案。 
3. 依序選擇 **Tools** > **NuGet package manager**。 
4. 在 **Browse** 下，於文字欄位輸入 *Aspose.Slides.Cpp*。 

![todo:image_alt_text](installation_1.png)

3. 點選您需要的版本 **Aspose.Slides.Cpp**，然後點擊 **Install**。 
   * 如果您想要更新 Aspose.Slides（亦即已安裝過）則改點 **Update**。 

選取的 API 會被下載並在您的專案中加入參考。

### **選項二：透過套件管理員主控台安裝或更新 Aspose.Slides**

若要使用套件管理員主控台參考 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) ，請執行以下步驟：

1. 在 Visual Studio 中開啟您的解決方案/專案。

1. 依序選擇 **Tools** > **NuGet Package Manager** > **Package Manager Console**。 

套件管理員主控台會開啟。 

![todo:image_alt_text](installation_2.png)

4. 輸入以下指令：`Install-Package Aspose.Slides.Cpp` 
> 如果您想安裝 x86 版，請使用 Aspose.Slides.Cpp.x86 套件：`Install-Package Aspose.Slides.Cpp.x86`

5. 按下 Enter 鍵。

最新的完整發行版會安裝至您的應用程式中。 

* 或者，您也可以在指令後加上 `-prerelease` 後綴，以指定同時安裝最新發行版（含熱修復）。

![todo:image_alt_text](installation_3.png)

下載完成後，您應該會看到一些確認訊息。  

![todo:image_alt_text](installation_4.png)

如果您不熟悉 [Aspose EULA](https://about.aspose.com/legal/eula)，可能需要閱讀 URL 中參考的授權條款。 

在套件管理員主控台中，您可以執行 `Update-Package Aspose.Slides.Cpp` 指令來檢查 Aspose.Slides 套件的更新。若有更新，會自動安裝。您亦可使用 `-prerelease` 後綴來更新最新發行版。

### **使用 Include 與 lib 資料夾**
1. [下載](https://downloads.aspose.com/slides/zh-hant/cpp) 最新的 Aspose.Slides for C++ 版本。
1. 解壓縮該資料夾至正式環境。
1. 若要使用 Aspose.Slides for C++，於專案中參考 Include 與 lib 資料夾。

## **FAQ**

**是否有免費版或試用限制？**

是的，預設情況下，Aspose.Slides 以評估模式執行，會加上浮水印並可能有其他限制。若要解除限制，必須套用有效的 [license](/slides/zh-hant/cpp/licensing/)。