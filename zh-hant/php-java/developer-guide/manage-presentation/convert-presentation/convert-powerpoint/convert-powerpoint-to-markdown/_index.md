---
title: 在 PHP 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/php-java/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 MD
- 簡報轉 MD
- 投影片轉 MD
- PPT 轉 MD
- PPTX 轉 MD
- 將 PowerPoint 儲存為 Markdown
- 將簡報儲存為 Markdown
- 将投影片儲存為 Markdown
- 将 PPT 儲存為 MD
- 将 PPTX 儲存為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- PowerPoint
- 簡報
- Markdown
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 透過 Java，將 PowerPoint 投影片（PPT、PPTX）轉換為乾淨的 Markdown，自動化文件編寫並保留格式。"
---
## **簡介**

Aspose.Slides 允許您將 PowerPoint 簡報轉換為 Markdown，這對於文件工作流程、靜態網站生成、內容遷移以及受版本控制的文字發布都非常有用。此 API 支援直接將 PPT 與 PPTX 簡報匯出為 MD 檔，並提供其他選項以控制投影片內容在生成的 Markdown 文件中的呈現方式。

您可以將簡報匯出為純 Markdown，或從多種 Markdown 變體（如 CommonMark 與 GitHub Flavored Markdown）中選擇，並設定匯出時圖像的處理方式。對於包含視覺內容的簡報，Aspose.Slides 亦可將圖像儲存至單獨資料夾，並在產生的 Markdown 檔中引用它們。

{{% alert color="warning" %}}
PowerPoint 轉 Markdown 的匯出預設為 **不含圖像**。若要匯出包含圖像的 PowerPoint 文件，必須設定 `ExportType = MarkdownExportType::Visual` 並指定 `BasePath`，圖像將被儲存於 Markdown 文件所引用的路徑中。
{{% /alert %}}

## **將簡報轉換為 Markdown**

本節說明 Aspose.Slides 如何將 PowerPoint 與 OpenDocument 簡報（PPT、PPTX、ODP）轉換為乾淨的 Markdown，保留原始投影片層次、文字與核心格式，讓您能在文件或受版本控制的工作流程中直接重複使用內容，無需額外手動處理。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體，以代表簡報。
1. 使用 [save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 方法將其匯出為 Markdown 檔。

以下 PHP 程式碼示範如何將 PowerPoint 簡報轉換為 Markdown：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **將簡報轉換為特定 Markdown 變體**

Aspose.Slides 讓您不僅能將 PowerPoint 簡報轉換為基本語法的 Markdown，還能轉換為 CommonMark、GitHub‑flavored Markdown、Trello、XWiki、GitLab 以及其他十七種 Markdown 變體。

以下 PHP 程式碼示範如何將 PowerPoint 簡報轉換為 CommonMark：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

支援的 23 種 Markdown 變體列於 [Flavor enumeration](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/flavor/)。

## **將含圖像的簡報轉換為 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 類別提供屬性與列舉，可讓您設定產生的 Markdown 檔。例如，[MarkdownExportType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownexporttype/) 列舉指定圖像的處理方式：`Sequential`、`TextOnly` 或 `Visual`。

{{% alert color="warning" %}}
預設情況下，PowerPoint 轉 Markdown 的匯出 **不會包含圖像**。若要嵌入圖像，請呼叫 `markdownSaveOptions.setExportType(MarkdownExportType::Visual)`，並設定 `BasePath` 以指定圖像在 Markdown 檔中引用的儲存位置。
{{% /alert %}}

### **逐一轉換圖像**

若希望圖像在產生的 Markdown 中逐一出現（依序排列），必須選擇 `Sequential` 選項。以下 PHP 程式碼示範如何將含圖像的簡報轉換為 Markdown：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **視覺化轉換圖像**

若希望圖像在產生的 Markdown 中一起顯示，必須選擇 `Visual` 選項。此情況下，圖像會儲存於應用程式的目前目錄（Markdown 文件會產生相對路徑），或您亦可指定自訂的目錄與資料夾名稱。

以下 PHP 程式碼示範此操作：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**超連結在匯出為 Markdown 後會保留嗎？**

會。文字 [hyperlinks](/slides/zh-hant/php-java/manage-hyperlinks/) 會以標準 Markdown 連結保留。投影片的 [transitions](/slides/zh-hant/php-java/slide-transition/) 與 [animations](/slides/zh-hant/php-java/powerpoint-animation/) 則不會被轉換。

**可以透過多執行緒加速轉換嗎？**

您可以在檔案層面平行處理，但請勿在執行緒間共享相同的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例。每個檔案使用獨立的實例或行程，以避免競爭。

**圖像會怎樣處理——它們儲存在哪裡，路徑是否為相對路徑？**

[Images](/slides/zh-hant/php-java/image/) 會匯出至專用資料夾，預設情況下 Markdown 檔會以相對路徑引用它們。您可以設定基礎輸出路徑與資產資料夾名稱，以維持可預測的倉儲結構。