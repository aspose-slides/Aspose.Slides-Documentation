---
title: 在 Java 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉換為 Markdown
type: docs
weight: 140
url: /zh-hant/java/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉換為 MD
- 簡報轉換為 MD
- 投影片轉換為 MD
- PPT 轉換為 MD
- PPTX 轉換為 MD
- 將 PowerPoint 儲存為 Markdown
- 將簡報儲存為 Markdown
- 將投影片儲存為 Markdown
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 將 PPT 匯出為 MD
- 將 PPTX 匯出為 MD
- PowerPoint
- 簡報
- Markdown
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 PowerPoint 投影片（PPT、PPTX）轉換為純淨的 Markdown，自動化文件編寫並保持格式。"
---
## **簡介**

Aspose.Slides 允許您將 PowerPoint 簡報轉換為 Markdown，這在文件工作流程、靜態網站生成、內容遷移以及受版本控制的文字發佈中都非常有用。API 支援直接將 PPT 與 PPTX 簡報匯出為 MD 檔案，並提供額外選項以控制投影片內容在產生的 Markdown 文件中的呈現方式。

您可以將簡報匯出為純 Markdown，從多種 Markdown 風格（如 CommonMark 和 GitHub Flavored Markdown）中選擇，並設定匯出過程中影像的處理方式。對於包含視覺內容的簡報，Aspose.Slides 還可以將影像存放到單獨的資料夾，並在生成的 Markdown 檔案中引用它們。

{{% alert color="warning" %}}
PowerPoint 匯出為 markdown 預設 **不含影像**。如果要匯出含有影像的 PowerPoint 文件，必須使用 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`，並同時設定 `setBasePath`，以指定 markdown 文件中引用的影像要儲存的位置。
{{% /alert %}}

## **將 PowerPoint 轉換為 Markdown**

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例，以代表簡報物件。  
2. 使用 [保存](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 方法將物件儲存為 markdown 檔案。

以下 Java 程式碼示範如何將 PowerPoint 轉換為 markdown：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **將 PowerPoint 轉換為 Markdown 風格**

Aspose.Slides 允許您將 PowerPoint 轉換為 markdown（包含基本語法）、CommonMark、GitHub flavored markdown、Trello、XWiki、GitLab，以及另外 17 種 markdown 風格。

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

支援的 23 種 markdown 風格可於 [MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 類別的 [Flavor 列舉](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/flavor/) 中查閱。

## **將含有圖像的簡報轉換為 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 類別提供屬性與列舉，讓您為產生的 markdown 檔案設定各種選項或設定。例如，[MarkdownExportType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownexporttype/) 列舉可設定為 `Sequential`、`TextOnly`、`Visual`，以決定影像的呈現或處理方式。

### **逐一轉換圖像**

若希望影像在產生的 markdown 中依次單獨出現，必須選擇 sequential（順序）選項。以下 Java 程式碼示範如何將含有影像的簡報轉換為 markdown：

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

若希望影像在產生的 markdown 中一起顯示，必須選擇 visual（視覺）選項。在此情況下，影像會儲存於應用程式的當前目錄（並在 markdown 文件中建立相對路徑），或您也可以自行指定路徑與資料夾名稱。

以下 Java 程式碼示範此操作：

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

**超連結在匯出為 Markdown 後會保留下來嗎？**

是的。文字 [超連結](/slides/zh-hant/java/manage-hyperlinks/) 會保留為標準的 Markdown 連結。投影片的 [轉場](/slides/zh-hant/java/slide-transition/) 與 [動畫](/slides/zh-hant/java/powerpoint-animation/) 不會被轉換。

**我可以透過多執行緒來加速轉換嗎？**

您可以在檔案層面平行處理，但請 **不要共用** 同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例於多個執行緒。每個檔案使用獨立的實例或程序，以避免争用。

**影像會怎麼處理——儲存位置在哪裡，路徑是否為相對路徑？**

[影像](/slides/zh-hant/java/image/) 會匯出至專屬資料夾，Markdown 檔案預設以相對路徑引用它們。您可以設定基礎輸出路徑與資產資料夾名稱，以保持倉儲結構的可預測性。