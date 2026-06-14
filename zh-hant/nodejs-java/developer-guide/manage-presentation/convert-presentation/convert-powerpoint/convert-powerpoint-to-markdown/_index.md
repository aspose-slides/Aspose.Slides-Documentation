---
title: 將 PowerPoint 簡報轉換為 JavaScript 中的 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 MD
- 簡報 轉 MD
- 投影片 轉 MD
- PPT 轉 MD
- PPTX 轉 MD
- 將 PowerPoint 儲存為 Markdown
- 將簡報儲存為 Markdown
- 將投影片儲存為 Markdown
- 儲存 PPT 為 MD
- 儲存 PPTX 為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- PowerPoint
- 簡報
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中將 PowerPoint 投影片（PPT、PPTX）轉換為乾淨的 Markdown，使用 Aspose.Slides for Node.js 透過 Java，自動化文件生成並保留格式。"
---
## **Introduction**

Aspose.Slides 允許您將 PowerPoint 簡報轉換為 Markdown，這對於文件工作流程、靜態網站生成、內容遷移以及版本控制的文字發布都很有用。該 API 支援直接從 PPT 和 PPTX 簡報匯出為 MD 檔，並提供額外選項，以控制投影片內容在產生的 Markdown 文件中的呈現方式。

您可以將簡報匯出為純 Markdown，從多種 Markdown 風格（例如 CommonMark 與 GitHub Flavored Markdown）中選擇，並設定匯出時圖像的處理方式。對於包含視覺內容的簡報，Aspose.Slides 亦允許您將圖像儲存至獨立資料夾，並在產生的 Markdown 檔案中引用它們。

{{% alert color="warning" %}} 
PowerPoint 轉 Markdown 匯出預設 **不含圖像**。若您想匯出包含圖像的 PowerPoint 文件，需要呼叫 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`，並同時設定 `BasePath`，以決定 Markdown 文件中引用的圖像儲存位置。
{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例，以代表簡報物件。
2. 使用 [save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) 方法將物件儲存為 markdown 檔案。

以下 JavaScript 程式碼示範如何將 PowerPoint 轉換為 markdown：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convert PowerPoint to Markdown Flavor**

Aspose.Slides 允許您將 PowerPoint 轉換為 markdown（含基本語法）、CommonMark、GitHub flavored markdown、Trello、XWiki、GitLab，以及另外 17 種 markdown 風格。

以下 JavaScript 程式碼示範如何將 PowerPoint 轉換為 CommonMark：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

這 23 種支援的 markdown 風格在 [Flavor 列舉](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/flavor/) 中列出，屬於 [MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 類別。

## **Convert Presentation Containing Images to Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownsaveoptions/) 類別提供屬性與列舉，讓您為產生的 markdown 檔案設定特定選項或設定。例如，[MarkdownExportType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/markdownexporttype/) 列舉可設定為決定圖像呈現或處理方式的值：`Sequential`、`TextOnly`、`Visual`。

### **Convert Images Sequentially**

如果您希望圖像在產生的 markdown 中逐一依序顯示，必須選擇 sequential（依序）選項。以下 JavaScript 程式碼示範如何將包含圖像的簡報轉換為 markdown：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Convert Images Visually**

如果您希望圖像在產生的 markdown 中一起顯示，必須選擇 visual（視覺）選項。此時，圖像會儲存至應用程式的當前目錄（並在 markdown 文件中建立相對路徑），或您亦可自行指定路徑與資料夾名稱。

以下 JavaScript 程式碼示範此操作：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Do hyperlinks survive the export to Markdown?**

會。文字 [hyperlinks](/slides/zh-hant/nodejs-java/manage-hyperlinks/) 會保留為標準的 Markdown 連結。投影片的 [transitions](/slides/zh-hant/nodejs-java/slide-transition/) 與 [animations](/slides/zh-hant/nodejs-java/powerpoint-animation/) 則不會被轉換。

**Can I speed up conversion by running it in multiple threads?**

您可以在檔案層面平行化處理，但請 [don’t share](/slides/zh-hant/nodejs-java/multithreading/) 同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例於多執行緒間。每個檔案請使用不同的實例或行程，以避免資源爭用。

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/zh-hant/nodejs-java/image/) 會匯出至專屬資料夾，Markdown 檔案預設以相對路徑引用它們。您可以設定基礎輸出路徑與資產資料夾名稱，以維持可預測的倉儲結構。