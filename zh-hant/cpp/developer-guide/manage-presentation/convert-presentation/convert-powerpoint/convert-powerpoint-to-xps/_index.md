---
title: 在 C++ 中將 PowerPoint 簡報轉換為 XPS
linktitle: PowerPoint 轉 XPS
type: docs
weight: 70
url: /zh-hant/cpp/convert-powerpoint-to-xps
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 XPS
- 簡報轉 XPS
- 投影片轉 XPS
- PPT 轉 XPS
- PPTX 轉 XPS
- 將 PPT 儲存為 XPS
- 將 PPTX 儲存為 XPS
- 匯出 PPT 為 XPS
- 匯出 PPTX 為 XPS
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint PPT/PPTX 轉換為高品質、跨平台的 XPS。獲取逐步指南與範例程式碼。"
---
## **概觀**

Aspose.Slides 允許您透過將 PPT 或 PPTX 檔案儲存為 XPS 格式來將 PowerPoint 簡報轉換為 XPS。本文章說明 XPS 格式何時可能有用，並示範如何使用 Aspose.Slides 以預設設定或自訂的 [XpsOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/xpsoptions/) 設定執行轉換。

## **關於 XPS**

Microsoft 開發了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作為 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允許您透過輸出與 PDF 十分相似的檔案來列印內容。XPS 格式基於 XML。XPS 檔案的版面或結構在所有作業系統與印表機上皆保持相同。

## **何時使用 Microsoft XPS 格式**

{{% alert color="info" %}} 

要了解 Aspose.Slides 如何將 PPT 或 PPTX 簡報轉換為 XPS 格式，您可以查看[此免費線上轉換應用程式](https://products.aspose.app/slides/zh-hant/conversion)。 

{{% /alert %}} 

如果您想降低存儲成本，可以將 Microsoft PowerPoint 簡報轉換為 XPS 格式。如此一來，您會發現儲存、分享與列印文件更加容易。

Microsoft 持續在 Windows（包括 Windows 10）中實作對 XPS 的強力支援，因此您可能會考慮將檔案儲存為此格式。如果您使用 Windows 8.1、Windows 8、Windows 7 或 Windows Vista，XPS 可能是某些作業的最佳選擇。

- **Windows 8** 使用 OXPS（Open XPS）格式的 XPS 檔案。OXPS 是原始 XPS 格式的標準化版本。Windows 8 對 XPS 檔案的支援優於對 PDF 檔案的支援。  
  - **XPS**：內建 XPS 檢視器/閱讀器，並提供列印至 XPS 功能。  
  - **PDF**：提供 PDF 閱讀器，但沒有列印至 PDF 功能。  

- **Windows 7** 與 **Windows Vista** 使用原始 XPS 格式。這些作業系統亦提供比 PDF 更佳的 XPS 支援。  
  - **XPS**：內建 XPS 檢視器，並提供列印至 XPS 功能。  
  - **PDF**：無 PDF 閱讀器，亦無列印至 PDF 功能。  

|<p>**輸入 PPT(X)：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**輸出 XPS：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft 最終在 Windows 10 中透過「列印為 PDF」功能實作了 PDF 的列印支援。此前，使用者通常需要透過 XPS 格式列印文件。

## **使用 Aspose.Slides 進行 XPS 轉換**

在針對 C++ 的 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/cpp/) 中，您可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別公開的 [**Save**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法，將整個簡報轉換為 XPS 文件。

將簡報轉換為 XPS 時，必須使用以下任一設定儲存簡報：

- 預設設定（未使用 [**XPSOptions**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.xps_options)）  
- 自訂設定（使用 [**XPSOptions**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.xps_options)）

### **使用預設設定將簡報轉換為 XPS**

以下 C++ 範例程式碼示範如何使用標準設定將簡報轉換為 XPS 文件：

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantiate a Presentation object that represents a presentation file
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Saving the presentation to XPS document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **使用自訂設定將簡報轉換為 XPS**

以下範例程式碼示範如何在 C++ 中使用自訂設定將簡報轉換為 XPS 文件：

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// 實例化一個代表簡報檔案的 Presentation 物件
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// 實例化 TiffOptions 類別
auto options = System::MakeObject<XpsOptions>();

// 將 MetaFiles 儲存為 PNG
options->set_SaveMetafilesAsPng(true);

// 將簡報儲存為 XPS 文件
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **常見問題**

### 我可以將 XPS 儲存到串流而不是檔案嗎？

可以——Aspose.Slides 讓您直接匯出至串流，這對於 Web API、伺服器端管線或任何需要在不觸及檔案系統的情況下傳送 XPS 的情境皆相當理想。

### 隱藏投影片會被轉換為 XPS 嗎？我可以排除它們嗎？

預設情況下，只會渲染一般（可見）投影片。您可以透過 [匯出設定](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/xpsoptions/) 中的 [include or exclude hidden slides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) 來在儲存為 XPS 前包含或排除隱藏投影片，確保輸出僅包含您想要的頁面。