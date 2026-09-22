---
title: 在 Python 中儲存投影片
linktitle: 儲存投影片
type: docs
weight: 80
url: /zh-hant/python-net/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存投影片
- 儲存投影片頁
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 投影片至檔案
- 投影片至串流
- 預先定義的檢視類型
- 嚴格 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中將 PowerPoint 與 OpenDocument 投影片儲存至檔案或串流，並配置 PPTX 輸出選項。"
---
## **概觀**

在建立投影片或[開啟現有投影片](/slides/zh-hant/python-net/open-presentation/)之後，使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ipresentation/save/)方法寫入結果。Aspose.Slides for Python via .NET 能將投影片儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 以及其他格式。以下各節說明標準的儲存操作以及 PPTX 輸出的可用選項。

## **將投影片儲存到檔案**

要將投影片儲存到檔案，將輸出路徑與[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ipresentation/save/)方法。格式值決定 Aspose.Slides 產生的檔案類型。

以下範例建立投影片並將其儲存為 PPTX 檔案：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 新增或修改投影片內容於此。

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **將投影片以原始格式儲存**

有關檔案與串流偵測範例、新建立的投影片行為，以及來源與輸出格式之區別，請參閱[Determine the Original Presentation Format](/slides/zh-hant/python-net/detect-presentation-source-format/)。

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，從[Presentation.source_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/source_format/)屬性讀取其原始格式。將得到的[SourceFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sourceformat/)值傳遞給[SlideUtil.to_save_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/to_save_format/)以取得對應的[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)值，然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ipresentation/save/)寫入已修改的投影片。

以下完整範例處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存至輸出目錄：

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/to_save_format/)將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射到相應的投影片儲存格式。它僅映射投影片來源格式；不適用於選擇 PDF、HTML、TIFF 或影像等匯出格式。傳遞不支援或無效的[SourceFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sourceformat/)值會拋出例外。

舊版 PPT、PPS 與 POT 檔案使用相同的二進位容器。當此類投影片從沒有副檔名的串流載入時，PPS 或 POT 檔案可能會被辨識為 PPT。如果需要保留這些舊版子類型，請另行保留原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它。

## **將投影片儲存到串流**

若不依賴最終檔案路徑寫入投影片，可將可寫入的[BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO)串流與[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ipresentation/save/)方法。此方式在需從 Web 服務返回輸出、存入資料庫或在記憶體中處理時特別有用。

以下範例將新投影片儲存至檔案串流：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **以預定的檢視類型儲存投影片**

您可以指定 PowerPoint 開啟已儲存投影片時的預設檢視。將[ViewProperties.last_view](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/last_view/)屬性設定為[ViewType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewtype/)值，然後再儲存。

以下範例將投影片母片檢視設定為初始檢視：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **以嚴格 Office Open XML 格式儲存投影片**

若要建立符合 Office Open XML 嚴格規範的 PPTX 檔案，請建立[PptxOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/)實例，並將其[conformance](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/conformance/)屬性設為`Conformance.ISO_29500_2008_STRICT`。然後將該選項傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ipresentation/save/)方法。

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **以 Zip64 模式儲存 Office Open XML 格式投影片**

標準 ZIP 壓縮檔對每個項目的壓縮與未壓縮大小、總檔案大小以及項目數量都有上限。由於 PPTX 檔案本身即為 ZIP 壓縮檔，極大的投影片可能會超過這些限制。ZIP64 延伸可提升相關的大小與項目數限制。

使用[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/zip_64_mode/)屬性來控制 Aspose.Slides 是否寫入 ZIP64 延伸：

- `IF_NECESSARY` 僅在投影片超過標準 ZIP 限制時使用 ZIP64。這是預設模式。
- `NEVER` 停用 ZIP64 延伸。
- `ALWAYS` 始終寫入 ZIP64 延伸。

以下範例始終為輸出投影片啟用 ZIP64 延伸：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
如果使用 `Zip64Mode.NEVER` 且投影片無法在標準 ZIP 限制內容納，儲存操作會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式的投影片**

對於 PPTX 輸出，您可以透過設定[PptxOptions.compression_level](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/compression_level/)屬性，在儲存速度與檔案大小之間取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/) 列舉提供以下值：

- `NONE` 不進行壓縮，直接儲存資料。
- `LEVEL1` 壓縮速度最快，產生最大的壓縮檔。
- `LEVEL2`~`LEVEL5` 逐步偏好較小的輸出，犧牲儲存速度。
- `LEVEL6` 在儲存速度與檔案大小之間取得平衡。這是預設等級。
- `LEVEL7`、`LEVEL8` 進一步偏好較小的輸出，犧牲儲存速度。
- `LEVEL9` 提供最強的壓縮，需耗費最多的處理時間。

以下範例在不使用壓縮的情況下儲存投影片：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

以下範例使用最高壓縮等級：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **在儲存時不重新整理縮圖**

當投影片以 PPTX 格式儲存時，[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/)屬性控制其文件縮圖：

- `True` 在儲存過程中重新產生縮圖。這是預設值。
- `False` 保留現有縮圖。如果投影片沒有縮圖，Aspose.Slides 不會生成新的縮圖。

以下範例在儲存時不重新整理縮圖：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
停用縮圖重新整理可減少儲存 PPTX 檔案所需的時間。
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose 提供一個免費的[PowerPoint Splitter](https://products.aspose.app/slides/zh-hant/splitter)，利用 Aspose.Slides API 建置，可將投影片中的選定投影片另存為單獨的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援增量或「快速儲存」？**

不支援。每次儲存操作皆會寫入完整的輸出檔案，而非僅更新變更的部份。

**多執行緒可以同時儲存同一個 Presentation 實例嗎？**

不行。[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)實例**非執行緒安全**（/slides/zh-hant/python-net/multithreading/）。每次只能由單一執行緒存取與儲存該實例。

**儲存投影片時，超連結與外部連結的檔案會怎樣？**

[超連結](/slides/zh-hant/python-net/manage-hyperlinks/)會保留在投影片中。Aspose.Slides 不會複製外部連結的檔案，因此儲存後的投影片仍須能存取原始位置。

**我可以儲存文件的作者、標題、公司與建立日期等中繼資料嗎？**

可以。於儲存前設定相應的[文件屬性](/slides/zh-hant/python-net/presentation-properties/)，Aspose.Slides 會將它們寫入輸出檔案。