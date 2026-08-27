---
title: 在 Python 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/python-net/convert-powerpoint-to-markdown/
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
- 將投影片儲存為 Markdown
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- Markdown 影像匯出
- CDN 影像連結
- PowerPoint
- 簡報
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "在 Python 中將 PPT 與 PPTX 簡報轉換為 Markdown，並控制匯出影像的儲存位置以及產生的 Markdown 如何引用它們。"
---
## **概述**

Aspose.Slides for Python via .NET 可以將 PPT 與 PPTX 簡報轉換為 Markdown，以用於文件編寫、靜態網站、內容遷移以及版本控制工作流程。您可以選擇 Markdown 的風格、控制投影片內容的渲染方式，並決定匯出影像的儲存位置以及生成的 Markdown 如何引用它們。

預設情況下，Markdown 匯出僅使用文字輸出。若要匯出視覺內容，請將[MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/export_type/)屬性設定為[MarkdownExportType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownexporttype/)列舉中的 `SEQUENTIAL` 或 `VISUAL` 值。`SEQUENTIAL` 會分別且依序呈現投影片項目，而 `VISUAL` 則會將分組項目保持在一起，以保留它們的視覺關係。`TEXT_ONLY` 值不會產生影像資源。

## **將簡報轉換為 Markdown**

使用[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)類別載入來源檔案，然後呼叫[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ipresentation/save/)方法，並傳入[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)列舉中的 `MD` 值。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **選擇 Markdown 風格**

[MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/flavor/)屬性控制輸出所使用的 Markdown 規範。[Flavor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/flavor/)列舉包括 CommonMark、GitHub Flavored Markdown 以及其他支援的變體。

以下範例將簡報匯出為 CommonMark：

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **使用預設本機儲存行為匯出影像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/)類別提供兩個屬性以本機儲存影像：

- [base_path](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/base_path/) 指定 Markdown 文件及其資源的基本目錄。
- [images_save_folder_name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) 指定影像子目錄。其預設值為 `Images`。

以下範例渲染視覺內容，將影像寫入 `output/assets`，並在 Markdown 文件中建立相對影像參照：

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides 在匯出產生影像資源時會建立影像子目錄，但應用程式必須在儲存 Markdown 檔案之前建立 `base_path`。

## **為發佈準備 Markdown 與影像**

Aspose.Slides for Python via .NET 不會公開 .NET 的影像儲存回呼，以在匯出期間替換每個產生的影像連結。相反地，請將 Markdown 文件及其影像資料夾匯出至發佈目錄，然後在不變更相對結構的情況下發佈該目錄。

以下範例將 `cdn-origin/presentations/quarterly-report` 設為已掛載或同步的發佈目錄。範例本身不執行任何網路上傳：目錄在目標網站或 CDN 位置發佈後，產生的連結即為有效。

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

發佈 `presentation.md` 並同時發佈 `assets` 目錄。Markdown 文件使用相對影像參照，故兩項必須在目的地保持相同的關係。如果發佈系統需要絕對的外部 URL，請在所有影像檔案發佈完畢後，於後處理階段重新寫入產生的連結。

## **常見問題**

**在 Markdown 匯出期間，Python 回呼能否自訂單一影像檔案與連結？**

不行。Aspose.Slides for Python via .NET 不會公開 .NET 的 `ImageSaving` 與 `SvgImageSaving` 回呼。請使用[MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/base_path/)與[MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/)設定本機輸出，然後發佈或對產生的資源進行後處理。

**匯出的影像儲存在哪裡？**

影像位置由[MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/base_path/)與[MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/)控制。Markdown 文件以相對路徑參照這些影像。

**影像連結應使用哪種路徑分隔符？**

在 Markdown 連結與 URL 中使用斜線 (`/`)。僅在檔案系統路徑上使用 `os.path.join`，並在後處理時另行正規化任何產生的連結。

**在 Markdown 匯出時，超連結是否會被保留？**

會。文字[超連結](/slides/zh-hant/python-net/manage-hyperlinks/)會以標準 Markdown 連結方式保留。投影片[轉場](/slides/zh-hant/python-net/slide-transition/)與[動畫](/slides/zh-hant/python-net/powerpoint-animation/)則不會被轉換。

**能否平行將簡報轉換為 Markdown？**

可以平行處理不同的簡報檔案，但不要在執行緒之間共用同一個[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)實例。請遵循[multithreading guidelines](/slides/zh-hant/python-net/multithreading/)並為每個檔案使用獨立的實例。