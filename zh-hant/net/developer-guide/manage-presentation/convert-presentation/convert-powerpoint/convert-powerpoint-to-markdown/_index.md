---
title: 在 .NET 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 PowerPoint 投影片（PPT、PPTX）轉換為純淨的 Markdown，自動化文件編寫並保留格式。"
---
## **簡介**

Aspose.Slides 允許您將 PowerPoint 簡報轉換為 Markdown，這在文件編寫工作流程、靜態網站生成、內容遷移以及受版本控制的文字發布中都相當有用。API 支援直接將 PPT 與 PPTX 簡報匯出為 MD 檔，並提供額外的選項，以控制投影片內容在最終 Markdown 文件中的呈現方式。

您可以將簡報匯出為純 Markdown，從多種 Markdown 風格（如 CommonMark 與 GitHub Flavored Markdown）中選擇，並設定匯出過程中圖片的處理方式。對於包含視覺內容的簡報，Aspose.Slides 也允許您將圖片儲存到獨立資料夾，並在產生的 Markdown 檔案中引用它們。

{{% alert color="warning" %}}

PowerPoint 轉 Markdown 匯出預設為 **不含圖片**。如果您想匯出包含圖片的 PowerPoint 文件，需要將 `ExportType = MarkdownExportType.Visual`，並指定 `BasePath`，圖片將會儲存於 Markdown 文件所引用的路徑下。

{{% /alert %}}

## **將 PowerPoint 轉換為 Markdown**

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例，以代表簡報物件。
2. 使用 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/methods/save) 方法將物件儲存為 markdown 檔案。

以下 C# 程式碼說明如何將 PowerPoint 轉換為 markdown：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **將 PowerPoint 轉換為 Markdown 風格**

Aspose.Slides 允許您將 PowerPoint 轉換為 markdown（基本語法）、CommonMark、GitHub flavored markdown、Trello、XWiki、GitLab 以及其他 17 種 markdown 風格。

以下 C# 程式碼說明如何將 PowerPoint 轉換為 CommonMark：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

23 種支援的 markdown 風格列於 [Flavor 列舉](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.dom.export.markdown.saveoptions/flavor/)，屬於 [MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 類別。

## **將包含圖片的簡報轉換為 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 類別提供屬性與列舉，讓您為最終的 markdown 檔案設定特定的選項或設定。例如，[MarkdownExportType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列舉可設為 `Sequential`、`TextOnly`、`Visual`，以決定圖片的呈現或處理方式。

### **順序轉換圖片**

若希望圖片在最終 markdown 中逐一呈現，請選擇 sequential（順序）選項。以下 C# 程式碼示範如何將包含圖片的簡報轉換為 markdown：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **視覺轉換圖片**

若希望圖片在最終 markdown 中一起顯示，請選擇 visual（視覺）選項。此情況下，圖片會儲存至應用程式的當前目錄（並在 markdown 文件中建立相對路徑），或您也可以自行指定路徑與資料夾名稱。

以下 C# 程式碼示範此操作：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **常見問題**

**超連結在匯出為 Markdown 後會保留下來嗎？**

是的。文字 [超連結](/slides/zh-hant/net/manage-hyperlinks/) 會以標準 Markdown 連結形式保留。投影片的 [轉場](/slides/zh-hant/net/slide-transition/) 與 [動畫](/slides/zh-hant/net/powerpoint-animation/) 則不會被轉換。

**我可以透過多執行緒來加速轉換嗎？**

可以對檔案進行平行處理，但請勿在多執行緒間 **共享** 同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。每個檔案請使用獨立的實例或行程，以避免資源爭用。

**圖片會怎麼處理——儲存位置在哪裡，路徑是否為相對路徑？**

[圖片](/slides/zh-hant/net/image/) 會匯出至專屬資料夾，Markdown 檔案預設以相對路徑引用它們。您可以設定基礎輸出路徑與資產資料夾名稱，以保持倉儲結構的可預測性。