---
title: 在 Android 上將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/androidjava/convert-powerpoint-to-markdown/
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
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 將 PPT 匯出為 MD
- 匯出 PPTX 為 MD
- PowerPoint
- 簡報
- Markdown
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 透過 Java，將 PowerPoint 投影片（PPT、PPTX）轉換為乾淨的 Markdown，自動化文件編寫並保持格式。"
---
## **簡介**

Aspose.Slides 讓您可以將 PowerPoint 簡報轉換為 Markdown，這在文件工作流程、靜態網站產生、內容遷移以及受版本控制的文字發佈時相當有用。此 API 支援直接從 PPT 與 PPTX 簡報匯出為 MD 檔，並提供額外選項，以控制投影片內容在產生的 Markdown 文件中的呈現方式。

您可以將簡報匯出為純 Markdown，選擇多種 Markdown 風格（例如 CommonMark 與 GitHub Flavored Markdown），並設定匯出時圖像的處理方式。對於包含視覺內容的簡報，Aspose.Slides 也允許您將圖像另存於獨立資料夾，並在產生的 Markdown 檔中引用這些圖像。

Aspose.Slides 支援簡報至 Markdown 的轉換。

{{% alert color="warning" %}} 
PowerPoint 轉 Markdown 的匯出預設**不含圖像**。若要匯出包含圖像的 PowerPoint 文件，必須設定 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`，並同時設定 `BasePath`，以指定 Markdown 文件中引用的圖像要儲存的位置。 
{{% /alert %}} 

## **將 PowerPoint 轉換為 Markdown**

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例，以代表簡報物件。  
2. 使用 [Save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 方法將物件儲存為 Markdown 檔案。

以下 Java 程式碼示範如何將 PowerPoint 轉換為 Markdown：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **將 PowerPoint 轉換為特定 Markdown 風格**

Aspose.Slides 允許您將 PowerPoint 轉換為 Markdown（包含基本語法）、CommonMark、GitHub Flavored Markdown、Trello、XWiki、GitLab 以及其他 17 種 Markdown 風格。

以下 Java 程式碼示範如何將 PowerPoint 轉換為 CommonMark：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

23 種支援的 Markdown 風格列於 [Flavor 列舉](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/flavor/) 中，屬於 [MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 類別。

## **將含圖像的簡報轉換為 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 類別提供屬性與列舉，讓您為產生的 Markdown 檔設定特定選項或設定。例如，可將 [MarkdownExportType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownexporttype/) 列舉設定為 `Sequential`、`TextOnly`、`Visual`，以決定圖像的呈現或處理方式。

### **逐一轉換圖像**

若希望圖像在產生的 Markdown 中依序單獨顯示，請選擇 sequential 選項。以下 Java 程式碼示範如何將含圖像的簡報轉換為 Markdown：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **視覺化轉換圖像**

若希望圖像在產生的 Markdown 中一起顯示，請選擇 visual 選項。此情況下，圖像會儲存於應用程式的當前目錄（並在 Markdown 文件中建立相對路徑），或是您自行指定的路徑與資料夾名稱。

以下 Java 程式碼演示此操作：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**超連結在匯出為 Markdown 後會保留嗎？**

會。文字 [hyperlinks](/slides/zh-hant/androidjava/manage-hyperlinks/) 會保留為標準的 Markdown 連結。投影片 [transitions](/slides/zh-hant/androidjava/slide-transition/) 與 [animations](/slides/zh-hant/androidjava/powerpoint-animation/) 則不會被轉換。

**可以透過多執行緒加速轉換嗎？**

可以在檔案層面平行處理，但請 **不要在執行緒間共享** 同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例。每個檔案應使用獨立的實例或行程，以避免衝突。

**圖像會怎麼處理——儲存位置與路徑是相對的嗎？**

[Images](/slides/zh-hant/androidjava/image/) 會匯出至專屬資料夾，Markdown 檔預設以相對路徑引用它們。您可以設定基礎輸出路徑與資產資料夾名稱，以維持可預測的儲存庫結構。