---
title: 使用 Python 取得並更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/python-net/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Python 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概述**

本文說明如何檢查 Aspose.Slides 中的簡報資訊。它解釋了如何在不載入完整檔案的情況下判斷簡報的目前格式、讀取其文件屬性，以及在需要時更新這些屬性。

範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) API，示範了處理簡報中繼資料的典型操作。

## **檢查簡報格式**

在處理簡報之前，您可能想要了解目前簡報的檔案格式（PPT、PPTX、ODP 等）。

您可以在不載入簡報的情況下檢查其格式。請參考以下 Python 程式碼：

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **取得簡報屬性**

以下 Python 程式碼示範如何取得簡報屬性（簡報的資訊）：

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

您可能想查看 [DocumentProperties 類別下的屬性](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/#properties) 。

## **更新簡報屬性**

Aspose.Slides 提供 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) 方法，讓您可以修改簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下程式碼範例說明如何編輯部分簡報屬性：

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

變更文件屬性的結果如下所示。

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **相關連結**

若要取得有關簡報及其安全屬性的更多資訊，您可能會發現以下連結有用：

- [保護簡報密碼](/slides/zh-hant/python-net/password-protected-presentation/)
- [保護簡報寫入](/slides/zh-hant/python-net/write-protected-presentation/)

## **常見問題**

**如何檢查字型是否已嵌入以及是哪一些字型？**

請在簡報層級查找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)，然後將這些條目與 [實際在內容中使用的字型](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_fonts/) 集合進行比較，以辨識哪些字型對於呈現至關重要。

**如何快速判斷檔案是否有隱藏投影片以及有多少張？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)，檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/hidden/)。

**我能偵測是否使用自訂投影片尺寸與方向，且是否與預設值不同嗎？**

可以。將目前的 [slide size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slide_size/) 及方向與標準預設值比較；這有助於預測列印與匯出的行為。

**是否有快速方法檢查圖表是否引用外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/)，檢查其 [data source](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/data_source_type/)，並註明資料是內部還是基於連結的，包括任何斷開的連結。

**如何評估可能拖慢渲染或 PDF 匯出的「沉重」投影片？**

對每張投影片，統計物件數量並偵測大尺寸影像、透明度、陰影、動畫與多媒體；以此給予大致的複雜度分數，以標示潛在的效能瓶頸。