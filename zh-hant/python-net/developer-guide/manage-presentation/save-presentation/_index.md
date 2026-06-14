---
title: 在 Python 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/python-net/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預定義檢視類型
- 嚴格 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中儲存簡報——匯出至 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **Overview**

[Open a Presentation in Python](/slides/zh-hant/python-net/open-presentation/) 介紹了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別開啟簡報。本文說明如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改既有簡報，完成後都需要儲存。使用 Aspose.Slides for Python，您可以儲存至 **檔案** 或 **串流**。本文說明儲存簡報的不同方式。

## **Save Presentations to Files**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的 `save` 方法即可將簡報儲存至檔案。將檔案名稱與儲存格式傳遞給此方法。以下範例示範如何使用 Aspose.Slides for Python 儲存簡報。

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    
    # 在此執行一些工作...

    # 將簡報儲存至檔案。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Save Presentations to Streams**

您可以通過將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的 `save` 方法將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例中，我們建立新簡報、向形狀新增文字，並將其儲存至串流。

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # 將簡報儲存至串流。
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Save Presentations with a Predefined View Type**

Aspose.Slides for Python 允許您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/) 類別設定產生的簡報開啟時 PowerPoint 使用的初始檢視。將 `last_view` 屬性設定為 [ViewType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewtype/) 列舉中的值。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Save Presentations in the Strict Office Open XML Format**

Aspose.Slides 允許您以 Strict Office Open XML 格式儲存簡報。儲存時使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/) 類別並設定其 conformance 屬性。若將 `Conformance.ISO_29500_2008_STRICT` 設為值，輸出檔案將以 Strict Office Open XML 格式儲存。

以下範例建立簡報並以 Strict Office Open XML 格式儲存。

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 以嚴格 Office Open XML 格式儲存簡報。
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

Office Open XML 檔案是 ZIP 壓縮檔，對任一檔案的未壓縮大小、壓縮後大小以及整個封存檔的總大小皆有限制為 4 GB (2^32 位元組)，且檔案數量上限為 65,535 (2^16-1)。ZIP64 格式擴充可將這些限制提升至 2^64。

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) 屬性讓您在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。此屬性提供以下模式：

- `IF_NECESSARY` 僅在簡報超過上述限制時使用 ZIP64 格式擴充。此為預設模式。
- `NEVER` 永不使用 ZIP64 格式擴充。
- `ALWAYS` 總是使用 ZIP64 格式擴充。

以下程式碼示範如何將簡報儲存為啟用 ZIP64 格式擴充的 PPTX：

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
當您使用 `Zip64Mode.NEVER` 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **Save Presentations without Refreshing the Thumbnail**

[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) 屬性控制將簡報儲存為 PPTX 時的縮圖產生方式：

- 若設為 `True`，儲存時會重新整理縮圖。這是預設值。
- 若設為 `False`，則保留現有縮圖。若簡報沒有縮圖，則不會產生。

以下程式碼將簡報儲存為 PPTX，且不重新整理其縮圖。

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
此選項有助於減少儲存 PPTX 格式簡報所需的時間。
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose 開發了一款使用其 API 的[免費 PowerPoint Splitter app](https://products.aspose.app/slides/zh-hant/splitter)。此應用程式可將簡報切割成多個檔案，透過將選取的投影片另存為新的 PPTX 或 PPT 檔案。
{{% /alert %}}

## **FAQ**

**是否支援「快速儲存」（增量儲存）只寫入變更？**

否。每次儲存都會重新產生完整目標檔案；不支援增量「快速儲存」。

**從多個執行緒同時儲存同一 Presentation 實例是否具備執行緒安全性？**

否。[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例 **不具備執行緒安全性**；請在單一執行緒中儲存。

**儲存時超連結和外部連結檔案會發生什麼情況？**

[Hyperlinks](/slides/zh-hant/python-net/manage-hyperlinks/) 會被保留。外部連結的檔案（例如以相對路徑的影片）不會自動複製—請確保所引用的路徑仍可存取。

**我可以設定/儲存文件的中繼資料（作者、標題、公司、日期）嗎？**

是。支援標準的[文件屬性](/slides/zh-hant/python-net/presentation-properties/)，在儲存時會寫入檔案。