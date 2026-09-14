---
title: 在 Python 中向簡報新增投影片
linktitle: 新增投影片
type: docs
weight: 10
url: /zh-hant/python-java/add-slide-to-presentation/
keywords:
- 新增投影片
- 建立投影片
- 空白投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Python via Java，將投影片新增至您的 PowerPoint 與 OpenDocument 簡報——在數秒內完成無縫且高效的投影片插入。"
---
## **概觀**

Aspose.Slides 允許您以程式方式向 PowerPoint 簡報中新增投影片。一個簡報包含母片/版面投影片與一般投影片，且一般投影片以零基索引排序。每個投影片都有唯一的 ID，不支援沒有投影片的簡報檔案。

本文說明如何建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件、存取其投影片集合、加入空白投影片、處理新加入的投影片，並儲存更新後的簡報。亦說明相關主題，例如在特定位置插入投影片、使用版面配置，以及了解新建立的簡報中預設存在的空白投影片。

## **將投影片新增至簡報**

在討論如何向簡報檔案加入投影片之前，我們先回顧投影片的一些事實。每個 PowerPoint 簡報檔案包含 **master/layout** 投影片和 **normal** 投影片。簡報檔案至少包含一張投影片。Aspose.Slides for Python via Java 不支援沒有投影片的簡報檔案。每個投影片都有唯一的 ID，所有一般投影片依零基索引排列。

Aspose.Slides for Python via Java 允許開發人員向簡報加入空白投影片。要向簡報加入空白投影片，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件所提供的 [getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 方法取得對 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件的參照。
- 呼叫 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件所提供的 [addEmptySlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addEmptySlide) 方法，將空白投影片新增至簡報投影片集合的末端。
- 對新加入的空白投影片進行處理。
- 最後，使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件寫入簡報檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 實例化代表簡報檔案的 Presentation 類別。
presentation = Presentation()
try:
    # 取得投影片集合。
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # 向投影片集合新增空白投影片。
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # 在新加入的投影片上執行一些操作。

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**我可以在特定位置插入新投影片，而不只是在末端嗎？**

可以。函式庫支援投影片集合以及 [insert](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertClone) 操作，因而您可以在指定索引加入投影片，而不僅限於末端。

**在基於版面新增投影片時，主題/樣式會被保留嗎？**

會。版面會繼承其母片的格式，而新投影片則會繼承所選版面以及其相關的母片。

**在尚未加入投影片之前，新建立的「空」簡報中會有哪張投影片？**

新建立的簡報已預設包含一張索引為 0 的空白投影片。計算插入索引時必須考慮到這一點。

**如果母片有多種版面，如何為新投影片選擇「正確」的版面？**

通常，選取符合所需結構的 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/)（例如 [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidelayouttype/)）。若缺少此類版面，您可以[將其新增至母片](/slides/zh-hant/python-java/slide-layout/) 後再使用。