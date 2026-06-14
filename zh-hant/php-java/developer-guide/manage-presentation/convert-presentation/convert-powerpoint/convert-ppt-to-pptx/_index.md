---
title: 在 PHP 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/php-java/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉 PPTX
- 將 PPT 儲存為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 快速將舊版 PPT 簡報轉換為現代 PPTX — 清晰的教學、免費程式碼範例，且不需 Microsoft Office 相依。"
---
## **概觀**

本文說明如何使用 PHP 以及線上 PPT 轉 PPTX 轉換應用程式，將 PowerPoint 簡報的 PPT 格式轉換為 PPTX 格式。涵蓋以下主題。

- 將 PPT 轉換為 PPTX

## **在 PHP 中將 PPT 轉換為 PPTX**

如需將 PPT 轉換為 PPTX 的 Java 範例程式碼，請參閱以下部分，即 [將 PPT 轉換為 PPTX](#convert-ppt-to-pptx)。它僅載入 PPT 檔案並以 PPTX 格式儲存。透過指定不同的儲存格式，您也可以將 PPT 檔案儲存為許多其他格式，如 PDF、XPS、ODP、HTML 等，詳情請參閱以下文章。

- [在 PHP 中將 PPT 轉換為 PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)
- [在 PHP 中將 PPT 轉換為 XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/)
- [在 PHP 中將 PPT 轉換為 HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)
- [在 PHP 中將 PPT 轉換為 ODP](/slides/zh-hant/php-java/save-presentation/)
- [在 PHP 中將 PPT 轉換為 PNG](/slides/zh-hant/php-java/convert-powerpoint-to-png/)

## **關於 PPT 轉換為 PPTX**

Convert old PPT format to PPTX with Aspose.Slides API. If you need to convert thousands of PPT presentations to PPTX format, the best solution is to do it programmatically. With Aspose.Slides API its possible to do it just in few lines of code. The API supports full compatibility to convert PPT presentation to PPTX and its possible to:

- 轉換包含精選母版、佈局與投影片的複雜結構。
- 轉換包含圖表的簡報。
- 轉換具有群組圖形、自動圖形（如矩形與橢圓）以及自訂幾何形狀的簡報。
- 轉換在自動圖形上使用紋理與圖片填充樣式的簡報。
- 轉換含有佔位符、文字框與文字持有者的簡報。

{{% alert color="primary" %}} 

請參閱 [**Aspose.Slides PPT 轉 PPTX 轉換**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 應用程式：

[](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

此應用程式建立於 [**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/php-java/)，因此您可以看到基本 PPT 轉 PPTX 轉換功能的即時示例。Aspose.Slides Conversion 是一個 Web 應用程式，可讓您拖放 PPT 格式的簡報檔案，並下載已轉換為 PPTX 的檔案。

尋找其他即時的 [**Aspose.Slides 轉換**](https://products.aspose.app/slides/zh-hant/conversion/) 範例。
{{% /alert %}} 

## **將 PPT 轉換為 PPTX**
Aspose.Slides for PHP via Java 現在讓開發人員能透過 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別實例存取 PPT，並將其轉換為相應的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。目前，它支援將 [PPT](https://docs.fileformat.com/presentation/ppt/) 部分轉換為 PPTX。如需瞭解在 PPT 轉換為 PPTX 時支援與不支援的功能細節，請參閱此文件 [link](/slides/zh-hant/php-java/ppt-to-pptx-conversion/).

Aspose.Slides for PHP via Java 提供了代表 **PPTX** 簡報檔案的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別。當建立物件時，Presentation 類別現在也可以存取 **PPT**。以下範例說明如何將 PPT 簡報轉換為 PPTX 簡報。

```php
  # 實例化一個代表 PPTX 檔案的 Presentation 物件
  $pres = new Presentation("Aspose.ppt");
  try {
    # 將 PPTX 簡報儲存為 PPTX 格式
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**圖示 : 原始 PPT 簡報**|

上述程式碼片段在轉換後產生以下 PPTX 簡報

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**圖示: 轉換後產生的 PPTX 簡報**|

## **常見問題**

**PPT 與 PPTX 格式有何差異？**

PPT 是 Microsoft PowerPoint 使用的較舊二進位檔案格式，而 PPTX 是自 Microsoft Office 2007 起引入的基於 XML 的新格式。PPTX 檔案提供了更佳的效能、更小的檔案大小，以及更好的資料復原能力。

**Aspose.Slides 是否支援將多個 PPT 檔案批次轉換為 PPTX？**

是的，您可以在迴圈中使用 Aspose.Slides 以程式方式將多個 PPT 檔案轉換為 PPTX，這使其適用於批次轉換情境。

**轉換後的內容與格式會被保留嗎？**

Aspose.Slides 在轉換簡報時保留高保真度。投影片佈局、動畫、圖形、圖表及其他設計元素在 PPT 轉換為 PPTX 時皆會被保留。

**我可以將 PPT 檔案轉換為其他格式，例如 PDF 或 HTML 嗎？**

是的，Aspose.Slides 支援將 PPT 檔案轉換為[多種格式](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/)，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等影像格式。

**是否能在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX？**

是的，Aspose.Slides 為獨立的 API，執行轉換時不需要 Microsoft PowerPoint 或任何第三方軟體。

**是否有線上工具可用於 PPT 轉換為 PPTX？**

是的，您可以使用免費的 [Aspose.Slides PPT 轉 PPTX 轉換器](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 網頁應用程式，在瀏覽器中直接執行轉換，無需撰寫任何程式碼。