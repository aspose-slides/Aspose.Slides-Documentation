---
title: 在 Python 中檢索與更新簡報資訊
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
description: "使用 Python 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資訊，以更快速的洞察與更智慧的內容稽核。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中檢查簡報資訊。它解釋了如何在不載入完整檔案的情況下判斷簡報的目前格式、讀取其文件屬性，以及在需要時更新這些屬性。

範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) API，示範了處理簡報中繼資訊的常見操作。

## **檢查簡報格式**

在處理簡報之前，您可能想先查明該簡報目前的格式（PPT、PPTX、ODP 等）。

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

以下 Python 程式碼說明如何取得簡報屬性（簡報的相關資訊）：

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

您也可以參考 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/#properties) 類別下的屬性。

## **更新簡報屬性**

Aspose.Slides 提供 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) 方法，讓您可以修改簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![Original document properties of the PowerPoint presentation](input_properties.png)

以下程式碼示範如何編輯部分簡報屬性：

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

變更文件屬性的結果如下所示。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **相關連結**

若想取得有關簡報及其安全屬性的更多資訊，以下連結可能對您有幫助：

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/zh-hant/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/zh-hant/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/zh-hant/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/zh-hant/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常見問題**

**如何檢查是否已嵌入字型以及是哪一些字型？**

在簡報層級查找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)，再將這些項目與 [fonts actually used across content](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_fonts/) 進行比對，即可辨識出對渲染關鍵的字型。

**如何快速判斷檔案中是否有隱藏投影片以及數量？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)，檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/hidden/)。

**我可以偵測是否使用自訂投影片尺寸與方向，且是否與預設值不同嗎？**

可以。比較目前的 [slide size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slide_size/) 與方向是否與標準預設相同；此資訊有助於預測列印與匯出的行為。

**有沒有快速的方法查看圖表是否引用外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/)，檢查其 [data source](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/data_source_type/)，並註明資料是內部還是連結型式，包括是否有斷開的連結。

**如何評估可能減慢渲染或 PDF 匯出的「較重」投影片？**

對每張投影片，統計物件數量並檢查是否有大型影像、透明度、陰影、動畫與多媒體，給予粗略的複雜度分數，以標示潛在的效能瓶頸。