---
title: 在 PHP 中將 PowerPoint 簡報轉換為 XML
linktitle: PowerPoint 轉 XML
type: docs
weight: 145
url: /zh-hant/php-java/convert-powerpoint-to-xml/
keywords:
- 將 PowerPoint 轉換為 XML
- 將簡報轉換為 XML
- PPT 轉 XML
- PPTX 轉 XML
- ODP 轉 XML
- PowerPoint XML 簡報
- SaveFormat.Xml
- 將簡報儲存為 XML
- 將簡報匯出為 XML
- XML 串流
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides for PHP via Java，將 PowerPoint 和 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **概述**

Aspose.Slides for PHP via Java 可以將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。XML 輸出在需要以文字形式檢視簡報結構、排除產生文件的問題、在自動化測試中比較輸出，或在需要使用 XML 而非簡報套件的工作流程中整合時很有用。

使用 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 方法，傳入來自 [SaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/) 列舉的 `Xml` 值。您可以直接將結果寫入檔案或寫入串流。

{{% alert color="info" title="Note" %}}

`SaveFormat::Xml` 會建立 PowerPoint XML 簡報。它不會提取儲存在 PPTX 套件中的個別 Office Open XML 部分。如果您需要確切的 PPTX 套件部件，例如 `ppt/presentation.xml` 或個別投影片 XML 檔案，請檢查 PPTX 套件本身。

{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑和 `SaveFormat::Xml` 傳遞給 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)。來源可以是任何支援載入的簡報格式，例如 PPT、PPTX 或 ODP。

以下範例將 PPTX 簡報轉換為 XML 檔案：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **將 XML 輸出寫入串流**

當 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存提供者或 XML 處理管道）時，使用 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 的串流重載。以下範例將結果寫入 [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 並取得產生的 XML 作為位元組陣列：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // 將 $xmlBytes 傳遞給工作流程中的下一個元件。
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` 會將所有產生的資料儲存在記憶體中，因此在呼叫 `toByteArray` 前不需要重設位置。

## **比較 XML 與簡報及匯出格式**

根據結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 典型用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 簡報 | 檢視結構、除錯、比較產生的輸出以及基於 XML 的整合 |
| PPT (`.ppt`) | 舊版二進位簡報檔案 | 相容於舊版 PowerPoint 工作流程 |
| PPTX (`.pptx`) | 包含多個部件的 Office Open XML 套件 | 一般 PowerPoint 編輯與簡報交換 |
| PDF or TIFF | 固定版面的頁面或多頁影像 | 檢視、列印與保存 |
| PNG, JPEG, or SVG | 單一投影片的渲染表示 | 縮圖、預覽與圖像資產 |
| HTML or HTML5 | 面向 Web 的簡報輸出 | 瀏覽器檢視與網站發布 |

與 PPT 與 PPTX 不同，XML 輸出主要用於檢查和資料導向工作流程。與 PDF、TIFF、HTML 與投影片影像格式不同，它表示簡報資料而非將投影片渲染為頁面或視覺資產。[supported file formats](/slides/zh-hant/php-java/supported-file-formats/) 表格將 PowerPoint XML 簡報列為僅可儲存的格式，因此在工作流程必須將匯出的檔案再次載入 Aspose.Slides 進行持續編輯時，請不要使用它。

## **常見問題**

**`SaveFormat::Xml` 與儲存 PPTX 檔案相同嗎？**

不是。PPTX 是包含多個 Office Open XML 部件的套件，而 `SaveFormat::Xml` 會建立 PowerPoint XML 簡報檔案。

**我可以在不在磁碟上建立檔案的情況下儲存 XML 輸出嗎？**

可以。將可寫入的串流傳遞給 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)。例如，使用 [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 進行記憶體內部處理。

**Aspose.Slides 能再次載入匯出的 XML 檔案嗎？**

不能。PowerPoint XML 簡報目前僅支援儲存，不支援載入。若需要往返編輯，請使用 PPTX 或其他支援的簡報格式。

**XML 轉換會將每張投影片渲染為頁面或影像嗎？**

不會。XML 轉換寫入結構化的簡報資料。若需要頁面導向的輸出，請使用 PDF 或 TIFF，若需要單張投影片影像，請使用 PNG、JPEG 與 SVG。