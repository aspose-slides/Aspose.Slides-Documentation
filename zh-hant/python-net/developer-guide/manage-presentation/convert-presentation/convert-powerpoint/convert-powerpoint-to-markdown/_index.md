---
title: 將 PowerPoint 簡報轉換為 Python 中的 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/python-net/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint 為 Markdown
- 轉換 OpenDocument 為 Markdown
- 轉換 簡報 為 Markdown
- 轉換 投影片 為 Markdown
- 轉換 PPT 為 Markdown
- 轉換 PPTX 為 Markdown
- 轉換 ODP 為 Markdown
- 轉換 PowerPoint 為 MD
- 轉換 OpenDocument 為 MD
- 轉換 簡報 為 MD
- 轉換 投影片 為 MD
- 轉換 PPT 為 MD
- 轉換 PPTX 為 MD
- 轉換 ODP 為 MD
- PowerPoint
- OpenDocument
- 簡報
- Markdown
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，將 PowerPoint 與 OpenDocument 投影片（PPT、PPTX、ODP）轉換為乾淨的 Markdown，自動化文件編寫並保留格式。"
---
## **簡介**

Aspose.Slides 允許您將 PowerPoint 簡報轉換為 Markdown，這對於文件工作流程、靜態站點生成、內容遷移以及版本控制的文字發布都很有用。該 API 支援直接將 PPT 和 PPTX 簡報匯出為 MD 檔案，並提供額外選項以控制投影片內容在產生的 Markdown 文件中的呈現方式。

您可以將簡報匯出為純 Markdown，從多種 Markdown 風格（如 CommonMark 與 GitHub Flavored Markdown）中選擇，並設定匯出時圖片的處理方式。對於包含視覺內容的簡報，Aspose.Slides 也允許您將圖片儲存到獨立資料夾，並在產生的 Markdown 檔案中引用它們。

{{% alert color="warning" %}}
PowerPoint 到 Markdown 的匯出預設 **不包含圖片**。若要匯出包含圖片的 PowerPoint 文件，您需要將 `export_type = MarkdownExportType.VISUAL` 設為相應值，並指定 `base_path`，圖片將儲存在該路徑，供 Markdown 文件引用。
{{% /alert %}}

## **將簡報轉換為 Markdown**

以下範例示範了使用 Aspose.Slides for Python via .NET 並採用預設設定，將 PowerPoint 簡報轉換為 Markdown 的最簡單方法。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 以載入簡報。
1. 呼叫 `save` 將其匯出為 Markdown 檔案。

使用以下 Python 程式碼片段執行轉換：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **將簡報轉換為 Markdown 風格**

Aspose.Slides 允許您將簡報轉換為多種 Markdown 格式，包含基本 Markdown、CommonMark、GitHub-flavored Markdown、Trello、XWiki、GitLab 以及其他 17 種 Markdown 風格。

以下 Python 範例示範如何將 PowerPoint 簡報轉換為 CommonMark：

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

在 [Flavor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 列舉以及 [MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 類別中列出了支援的 23 種 Markdown 風格。

## **將含有圖片的簡報轉換為 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 類別提供屬性與列舉，讓您設定產生的 Markdown 檔案。例如，[MarkdownExportType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列舉控制圖片的處理方式：`SEQUENTIAL`、`TEXT_ONLY` 或 `VISUAL`。

### **順序轉換圖片**

如果您希望圖片在產生的 Markdown 中依序單獨顯示，請選擇 `SEQUENTIAL` 選項。以下 Python 範例說明如何將含圖片的簡報轉換為 Markdown。

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **視覺化轉換圖片**

如果您希望圖片在結果 Markdown 中一起顯示，請選擇 `VISUAL` 選項。在此模式下，圖片會儲存到應用程式的當前目錄（Markdown 文件使用相對路徑），亦可自行指定輸出路徑與資料夾名稱。

以下 Python 範例展示此操作：

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **常見問題**

**超連結在匯出為 Markdown 後會保留嗎？**

是的。文字 [hyperlinks](/slides/zh-hant/python-net/manage-hyperlinks/) 會保留為標準的 Markdown 連結。投影片的 [transitions](/slides/zh-hant/python-net/slide-transition/) 與 [animations](/slides/zh-hant/python-net/powerpoint-animation/) 則不會被轉換。

**我可以透過多執行緒加速轉換嗎？**

您可以在檔案層面平行處理，但請 [don’t share](/slides/zh-hant/python-net/multithreading/) 同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例於多執行緒之間。建議為每個檔案使用獨立的實例或行程，以避免競爭。

**圖片會怎麼處理—保存在哪裡，路徑是否為相對路徑？**

[Images](/slides/zh-hant/python-net/image/) 會匯出至專屬資料夾，Markdown 檔案預設以相對路徑引用它們。您可以設定基礎輸出路徑與資產資料夾名稱，以維持可預測的倉儲結構。