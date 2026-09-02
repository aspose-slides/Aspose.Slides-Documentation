---
title: 在 Python 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/python-net/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存 簡報
- 儲存 投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預先定義的檢視類型
- 嚴格 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中儲存簡報──匯出為 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概觀**

[在 Python 中開啟簡報](/slides/zh-hant/python-net/open-presentation/)說明了如何使用[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)類別開啟簡報。本篇文章解釋如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要儲存。使用 Aspose.Slides for Python，您可以儲存至**檔案**或**串流**。本篇說明儲存簡報的不同方式。

## **將簡報儲存為檔案**

透過呼叫[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)類別的 `save` 方法，將簡報儲存至檔案。將檔名與儲存格式傳入方法。以下範例示範如何使用 Aspose.Slides for Python 儲存簡報。

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    
    # 在此執行一些工作...

    # 將簡報儲存至檔案。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **將簡報儲存為串流**

您可以將簡報儲存至串流，只需將輸出串流傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)類別的 `save` 方法。簡報可以寫入多種串流類型。以下範例建立新簡報並將其儲存至檔案串流。

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # 將簡報儲存至串流。
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **以預先定義的檢視類型儲存簡報**

Aspose.Slides for Python 允許您透過[ViewProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/)類別設定 PowerPoint 開啟產生的簡報時的初始檢視。將 `last_view` 屬性設為[ViewType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewtype/)列舉中的值。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **以嚴格 Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以嚴格 Office Open XML 格式儲存簡報。使用[PptxOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/)類別，並在儲存時設定其 `conformance` 屬性。如果將 `Conformance.ISO_29500_2008_STRICT` 設為 true，輸出檔案即以嚴格 Office Open XML 格式儲存。

以下範例建立簡報並以嚴格 Office Open XML 格式儲存。

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 以嚴格 Office Open XML 格式儲存簡報。
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

Office Open XML 檔案是 ZIP 壓縮檔，對未壓縮檔案大小、壓縮後檔案大小以及總檔案大小皆限制為 4 GB（2^32 位元組），且檔案數量上限為 65 535（2^16‑1）。ZIP64 格式延伸可將限制提升至 2^64。

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) 屬性讓您選擇在儲存 Office Open XML 檔案時是否使用 ZIP64 格式延伸。

此屬性提供以下模式：

- `IF_NECESSARY` 僅在簡報超過上述限制時才使用 ZIP64 格式延伸。此為預設模式。
- `NEVER` 絕不使用 ZIP64 格式延伸。
- `ALWAYS` 總是使用 ZIP64 格式延伸。

以下程式碼示範如何在啟用 ZIP64 格式延伸的情況下，將簡報儲存為 PPTX 檔案：

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
當您以 `Zip64Mode.NEVER` 儲存時，如果簡報無法以 ZIP32 格式儲存，會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式的簡報**

處理大型簡報時，您可以調整壓縮等級，以在檔案大小與處理時間之間取得平衡。根據需求，您可能偏好較快的處理速度或較小的輸出檔案。

Aspose.Slides 提供 [PptxOptions.compression_level](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/compression_level/) 屬性，讓您在以 Office Open XML 格式儲存簡報時指定壓縮等級。

可用的壓縮等級如下：

- [**NONE**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 不進行壓縮，檔案以原始方式保存。
- [**LEVEL1**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 壓縮速度最快，壓縮比最低。
- [**LEVEL2**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 壓縮速度較快，壓縮比略優於 **LEVEL1**。
- [**LEVEL3**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 壓縮比優於 **LEVEL2**，對處理時間影響適中。
- [**LEVEL4**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 壓縮比優於 **LEVEL3**。
- [**LEVEL5**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 在 **LEVEL4** 基礎上提升壓縮，比較多的處理時間。
- [**LEVEL6**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 標準壓縮，兼顧處理速度與檔案大小。此為*預設壓縮等級*。
- [**LEVEL7**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 壓縮比優於 **LEVEL6**，但處理較慢。
- [**LEVEL8**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 壓縮比優於 **LEVEL7**。
- [**LEVEL9**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/compressionlevel/): 最大壓縮比，產生最小檔案大小，但處理時間最長。

以下範例示範如何以*不壓縮*的方式儲存簡報為 PPTX 檔案：

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

此範例示範如何以*最高壓縮*的方式儲存簡報為 PPTX 檔案：

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **儲存簡報時不重新整理縮圖**

[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) 屬性控制在將簡報儲存為 PPTX 時是否產生縮圖：

- 設為 `True` 時，儲存期間會重新整理縮圖。此為預設值。
- 設為 `False` 時，保留現有縮圖。如果簡報沒有縮圖，則不會產生。

以下程式碼示範將簡報儲存為 PPTX 而不重新整理縮圖。

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
此選項有助於縮短以 PPTX 格式儲存簡報所需的時間。
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose 開發了[免費的 PowerPoint 分割器應用程式](https://products.aspose.app/slides/zh-hant/splitter)，透過其 API 實作。該應用程式可將簡報分割為多個檔案，將選取的投影片另存為新 PPTX 或 PPT 檔案。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）僅寫入變更？**

不支援。每次儲存都會產生完整的目標檔案，未提供增量「快速儲存」功能。

**從多個執行緒同時儲存相同的 Presentation 實例是否安全？**

不安全。[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)實例**不是執行緒安全**的；請在單一執行緒中進行儲存。

**儲存時超連結和外部連結檔案會發生什麼情況？**

[超連結](/slides/zh-hant/python-net/manage-hyperlinks/)會被保留。外部連結的檔案（例如使用相對路徑的影片）不會自動複製，請確保相關路徑仍可存取。

**是否可以設定/儲存文件中繼資料（作者、標題、公司、日期）？**

可以。支援標準的[文件屬性](/slides/zh-hant/python-net/presentation-properties/)，儲存時會寫入檔案。