---
title: 使用 Python 存取簡報中的投影片
linktitle: 存取投影片
type: docs
weight: 20
url: /zh-hant/python-net/access-slide-in-presentation/
keywords:
- 存取投影片
- 投影片索引
- 投影片 ID
- 投影片位置
- 變更位置
- 投影片屬性
- 投影片編號
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Python via .NET 存取與管理 PowerPoint 與 OpenDocument 簡報中的投影片。透過程式碼範例提升生產力。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python 存取 PowerPoint 簡報中的特定投影片。它展示了如何開啟簡報、依索引或唯一 ID 參照投影片，以及讀取檔案內導覽所需的基本投影片資訊。透過這些技巧，您可以可靠地定位想要檢視或處理的確切投影片。

## **依索引存取投影片**

簡報中的投影片依位置編號，起始值為 0。第一張投影片的索引為 0，第二張為 1，以此類推。

[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別（代表簡報檔案）透過 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 內的 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 物件公開投影片集合。

以下 Python 程式碼示範如何依索引存取投影片：

```python
import aspose.slides as slides

# 建立一個代表簡報檔案的 Presentation。
with slides.Presentation("sample.pptx") as presentation:
    # 依索引取得投影片。
    slide = presentation.slides[0]
```

## **依 ID 存取投影片**

簡報中的每張投影片都有唯一的 ID。您可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別公開的 [get_slide_by_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_slide_by_id/) 方法來針對該 ID。

以下 Python 程式碼示範如何提供有效的投影片 ID，並透過 [get_slide_by_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_slide_by_id/) 方法存取該投影片：

```python
import aspose.slides as slides

# 建立一個代表簡報檔案的 Presentation。
with slides.Presentation("sample.pptx") as presentation:
    # 取得投影片 ID。
    id = presentation.slides[0].slide_id
    # 依 ID 存取投影片。
    slide = presentation.get_slide_by_id(id)
```

## **更改投影片位置**

Aspose.Slides 允許您變更投影片的位置。例如，您可以讓第一張投影片變為第二張。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得欲變更位置的投影片參考。
1. 透過 [slide_number](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/slide_number/) 屬性設定投影片的新位置。
1. 儲存已修改的簡報。

以下 Python 程式碼會將位置 1 的投影片移動至位置 2：

```python
import aspose.slides as slides

# 建立一個代表簡報檔案的 Presentation 物件。
with slides.Presentation("sample.pptx") as presentation:
    # 取得將被變更位置的投影片。
    slide = presentation.slides[0]
    # 設定投影片的新位置。
    slide.slide_number = 2
    # 儲存已修改的簡報。
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

第一張投影片變為第二張；第二張投影片變為第一張。變更投影片位置時，其他投影片會自動調整。

## **設定投影片編號**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別公開的 [first_slide_number](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/first_slide_number/) 屬性，您可以為簡報的第一張投影片指定新的編號。此操作會重新計算其他投影片的編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 設定投影片編號。
1. 儲存已修改的簡報。

以下 Python 程式碼示範將第一張投影片的編號設定為 10：

```python
import aspose.slides as slides

# 建立一個代表簡報檔案的 Presentation 物件。
with slides.Presentation("sample.pptx") as presentation:
    # 設定投影片編號。
    presentation.first_slide_number = 10
    # 儲存已修改的簡報。
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

如果您想略過第一張投影片，也可以從第二張投影片開始編號（並隱藏第一張投影片的編號），方式如下：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # 設定簡報中第一張投影片的編號。
    presentation.first_slide_number = 0

    # 顯示所有投影片的投影片編號。
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # 隱藏第一張投影片的投影片編號。
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # 儲存已修改的簡報。
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**使用者看到的投影片編號是否與集合的零基索引相同？**

投影片上顯示的編號可以從任意值（例如 10）開始，並不一定要與索引相符；兩者的關係由簡報的 [first slide number](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/first_slide_number/) 設定控制。

**隱藏的投影片會影響索引嗎？**

會。隱藏的投影片仍保留在集合中，且會被計入索引；「隱藏」僅指顯示狀態，並不影響其在集合中的位置。

**當其他投影片被新增或移除時，投影片的索引會變動嗎？**

會。索引始終反映目前投影片的順序，並在插入、刪除或移動操作後重新計算。