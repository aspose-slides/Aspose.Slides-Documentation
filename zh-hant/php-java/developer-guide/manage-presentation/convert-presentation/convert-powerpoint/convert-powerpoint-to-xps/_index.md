---
title: 在 PHP 中將 PowerPoint 簡報轉換為 XPS
linktitle: PowerPoint 轉 XPS
type: docs
weight: 70
url: /zh-hant/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（透過 Java）將 PowerPoint PPT/PPTX 轉換為高品質、跨平台的 XPS。獲取逐步指南與範例程式碼。"
---
## **概觀**

Aspose.Slides 允許您透過將 PPT 或 PPTX 檔案儲存為 XPS 格式，將 PowerPoint 簡報轉換為 XPS。本文說明 XPS 格式何時可能有用，並展示如何使用 Aspose.Slides 透過預設設定或自訂的[XpsOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xpsoptions/) 設定執行轉換。

## **關於 XPS**

Microsoft 開發了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作為 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允許您透過輸出與 PDF 非常相似的檔案來列印內容。XPS 格式基於 XML。XPS 檔案的佈局或結構在所有作業系統和印表機上皆保持相同。

## **何時使用 Microsoft XPS 格式**

{{% alert color="primary" %}} 

若要了解 Aspose.Slides 如何將 PPT 或 PPTX 簡報轉換為 XPS 格式，您可以查看 [此免費線上轉換應用程式](https://products.aspose.app/slides/zh-hant/conversion)。 

{{% /alert %}} 

如果您想降低儲存成本，可以將 Microsoft PowerPoint 簡報轉換為 XPS 格式。如此一來，您將更容易儲存、分享與列印文件。 

Microsoft 持續在 Windows（甚至在 Windows 10）中實作對 XPS 的強力支援，因此您可能想考慮將檔案儲存為此格式。如果您使用 Windows 8.1、Windows 8、Windows 7 與 Windows Vista，則 XPS 可能實際上是某些作業的最佳選擇。 

- **Windows 8** 使用 OXPS（Open XPS）格式作為 XPS 檔案。OXPS 是原始 XPS 格式的標準化版本。Windows 8 提供比 PDF 檔案更好的 XPS 檔案支援。  
  - **XPS**：內建 XPS 檢視器/閱讀器，且提供列印至 XPS 的功能。  
  - **PDF**：提供 PDF 閱讀器，但沒有列印至 PDF 的功能。  

- **Windows 7** 與 **Windows Vista** 使用原始 XPS 格式。這些作業系統也提供比 PDF 更好的 XPS 檔案支援。  
  - **XPS**：內建 XPS 檢視器，且提供列印至 XPS 的功能。  
  - **PDF**：沒有 PDF 閱讀器，也沒有列印至 PDF 的功能。  

|<p>**輸入 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**輸出 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft 最終透過 Windows 10 的「列印至 PDF」功能實作了 PDF 的列印支援。先前，使用者需透過 XPS 格式列印文件。 

## **使用 Aspose.Slides 進行 XPS 轉換**

在適用於 Java 的 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/php-java/) 中，您可以使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別所提供的 [**Save**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法，將整個簡報轉換為 XPS 文件。  

將簡報轉換為 XPS 時，必須使用以下任一設定來儲存簡報：  

- 預設設定（不使用 [**XPSOptions**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xpsoptions)）  
- 自訂設定（使用 [**XPSOptions**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xpsoptions)）  

### **使用預設設定將簡報轉換為 XPS**

以下範例程式碼示範如何使用標準設定將簡報轉換為 XPS 文件：

```php
  # 建立代表簡報檔案的 Presentation 物件
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # 將簡報儲存為 XPS 文件
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **使用自訂設定將簡報轉換為 XPS**

以下範例程式碼示範如何使用自訂設定將簡報轉換為 XPS 文件：

```php
  # 建立代表簡報檔案的 Presentation 物件
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # 建立 TiffOptions 類別的實例
    $options = new XpsOptions();
    # 將 MetaFiles 儲存為 PNG
    $options->setSaveMetafilesAsPng(true);
    # 將簡報儲存為 XPS 文件
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問答**

**我可以將 XPS 儲存至串流而非檔案嗎？**

是的——Aspose.Slides 允許您直接匯出至串流，這對於 Web API、伺服器端管線，或任何需要在不觸及檔案系統的情況下傳送 XPS 的情境，都非常理想。  

**隱藏投影片會被轉換至 XPS 嗎？我可以排除它們嗎？**

預設情況下，只會呈現一般（可見）投影片。您可以在儲存為 XPS 前，透過 [匯出設定](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xpsoptions/) [包含或排除隱藏投影片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xpsoptions/setshowhiddenslides/)，確保輸出僅包含您想要的頁面。