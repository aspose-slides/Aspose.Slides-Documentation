---
title: 使用 Python 新增投影片至簡報
linktitle: 新增投影片
type: docs
weight: 10
url: /zh-hant/python-net/add-slide-to-presentation/
keywords:
- 新增投影片
- 建立投影片
- 空白投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Python via .NET 為 PowerPoint 與 OpenDocument 簡報新增投影片──即時、順暢且高效的投影片插入。"
---
## **概述**

在向簡報加入投影片之前，先了解 PowerPoint 如何組織投影片會很有幫助。每個簡報都包含一個母片（master slide）、可選的版面投影片（layout slides），以及一個或多個普通投影片。每張投影片都有唯一的 ID，普通投影片以從零開始的索引排序。本文說明如何使用 Aspose.Slides for Python 來建立投影片並選擇適當的版面配置。

## **將投影片加入簡報**

Aspose.Slides 允許您根據現有的版面投影片附加新投影片。下面的範例會遍歷簡報中的每個版面，新增一張使用該版面的投影片，然後儲存檔案。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)。
1. 對於 `presentation.layout_slides` 中的每個項目，呼叫 `add_empty_slide` 以附加使用該版面的投影片。
1. （可選）修改新加入的投影片。
1. 將簡報儲存為 PPTX 檔案。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    # 取得投影片集合。
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # 新增一張空白投影片到投影片集合。
        slides.add_empty_slide(layout_slide)

    # 對新加入的投影片進行一些操作。

    # 將簡報儲存至磁碟。
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以在特定位置插入新投影片，而不是只在最後嗎？**

可以。此函式庫支援投影片集合的 [insert](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/insert_clone/) 操作，您可以在所需的索引處加入投影片，而不必只能在結尾。

**在基於版面加入投影片時，主題/樣式會被保留嗎？**

會。版面會繼承其母片的格式，新投影片則繼承所選版面及其相關的母片。

**在加入投影片之前，新「空白」簡報中會有哪張投影片？**

新建立的簡報已預設包含一張索引為零的空白投影片。計算插入索引時需考慮到這一點。

**如果母片有許多選項，我該如何為新投影片選擇「正確」的版面？**

通常選擇符合所需結構的 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/)（例如 [Title and Content、Two Content 等](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidelayouttype/)）。如果缺少此類版面，您可以 [add it to the master](/slides/zh-hant/python-net/slide-layout/)，然後再使用它。