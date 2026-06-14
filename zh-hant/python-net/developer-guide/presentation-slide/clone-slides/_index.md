---
title: 在 Python 中克隆 PowerPoint 投影片
linktitle: 克隆投影片
type: docs
weight: 40
url: /zh-hant/python-net/clone-slides/
keywords:
- 複製投影片
- 拷貝投影片
- 儲存投影片
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 快速克隆或複製 PowerPoint 投影片。遵循我們清晰的程式碼範例與技巧，讓您在數秒內自動化 PPT 建立，提高生產力，並消除手動操作。"
---
## **簡介**

Clone（複製）是製作某物的完全相同副本的過程。Aspose.Slides 也允許您複製（clone）任何投影片，然後將複製的投影片插入目前的簡報或任何其他開啟的簡報中。投影片的複製會產生一個新投影片，開發者可以在不影響原始投影片的情況下進行修改。複製投影片有多種方式：

- 在簡報的末端複製。
- 在簡報中的其他位置複製。
- 在另一個簡報的末端複製。
- 在另一個簡報的其他位置複製。
- 在另一個簡報的特定位置複製。

在 Aspose.Slides for Python via .NET 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件所公開的 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 提供 `add_clone` 與 `insert_clone` 方法來執行上述各種投影片複製。

## **在同一簡報內的末端複製**

如果您想在同一簡報內複製投影片並將其加在現有投影片的末端，請使用 `add_clone` 方法。依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件取得投影片集合。
1. 在 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone` 方法，並傳入要複製的投影片。
1. 儲存已修改的簡報。

在下方範例中，第一張投影片（索引 0）被複製，並加在簡報的末端。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以代表簡報檔案。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 將所需的投影片複製到同一簡報中投影片集合的末端。
    presentation.slides.add_clone(presentation.slides[0])
    # 將已修改的簡報儲存到磁碟中。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在同一簡報內的特定位置複製**

如果您想在同一簡報內複製投影片並將其放置在不同位置，請使用 `insert_clone` 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件取得投影片集合。
1. 在 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `insert_clone` 方法，傳入要複製的投影片以及其新位置的目標索引。
1. 儲存已修改的簡報。

在下方範例中，索引 0（位置 1）的投影片被複製到同一簡報的索引 1（位置 2）。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以代表簡報檔案。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 將所需的投影片複製到同一簡報中指定的位置（索引）。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 將已修改的簡報儲存到磁碟中。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一個簡報的末端複製**

如果您需要將一個簡報的投影片複製並加在另一個簡報的末端：

1. 為來源簡報（含要複製之投影片）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 為目標簡報（要加入投影片的地方）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從目標簡報取得投影片集合。
1. 在目標的 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone`，傳入來源簡報的投影片。
1. 儲存已修改的目標簡報。

在下方範例中，來源簡報的索引 0 投影片被複製至目標簡報的末端。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以代表來源簡報檔案。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 為目標 PPTX（投影片將被複製的地方）建立 Presentation 類別的實例。
    with slides.Presentation() as target_presentation:
        # 將所需的投影片從來源簡報複製到目標簡報中投影片集合的末端。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 將目標簡報儲存到磁碟中。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一個簡報的特定位置複製**

如果您需要將一個簡報的投影片複製並插入到另一個簡報的特定位置：

1. 為來源簡報（含要複製之投影片）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 為目標簡報（要加入投影片的地方）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從目標簡報取得投影片集合。
1. 在目標的 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `insert_clone` 方法，傳入來源簡報的投影片以及欲插入的目標索引。
1. 儲存已修改的目標簡報。

在下方範例中，來源簡報的索引 0 投影片被複製至目標簡報的索引 1（位置 2）。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以代表來源簡報檔案。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 為目標 PPTX（要複製投影片的地方）建立 Presentation 類別的實例。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # 在目標簡報的索引 2 處插入來源第一張投影片的複製品。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 將目標簡報儲存到磁碟中。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **將投影片連同其母片一起複製到另一個簡報**

如果您需要將投影片**及其母片**一起從一個簡報複製並在另一個簡報中使用，首先必須先將所需的母片從來源簡報複製到目標簡報。然後在複製投影片時使用該目標母片。`add_clone(Slide, MasterSlide)` 方法期望的是**目標簡報的母片**，而非來源簡報的母片。

要複製帶母片的投影片，請遵循以下步驟：

1. 為來源簡報（含要複製之投影片）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 為目標簡報建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 取得要複製的來源投影片及其母片。
1. 從目標簡報的母片集合中取得 [母片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/)。
1. 在目標的 [母片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/) 上呼叫 `add_clone`，傳入來源母片以將其複製至目標簡報。
1. 從目標簡報的投影片集合中取得 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)。
1. 在目標的 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone`，傳入來源投影片以及剛剛複製的目標母片。
1. 儲存已修改的目標簡報。

在下方範例中，來源簡報的索引 0 投影片被複製至目標簡報的末端，且使用了從來源複製過來的母片。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以代表來源簡報檔案。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # 為要複製投影片的目標簡報建立 Presentation 類別的實例。
    with slides.Presentation() as target_presentation:
        # 取得來源簡報的第一張投影片。
        source_slide = source_presentation.slides[0]
        # 取得第一張投影片使用的母片。
        source_master = source_slide.layout_slide.master_slide
        # 將母片複製至目標簡報的母片集合中。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # 使用已複製的母片，將來源簡報的投影片複製到目標簡報的末端。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 將目標簡報儲存到磁碟中。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在指定章節的末端複製**

使用 Aspose.Slides for Python via .NET，您可以將投影片從簡報的一個章節複製，並插入到同一簡報的另一個章節。為此，請使用 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 類別的 `add_clone(Slide, Section)` 方法。

以下 Python 範例示範了如何複製投影片並將其插入指定章節：

```py
import aspose.slides as slides

# 建立一個新的空白簡報。
with slides.Presentation() as presentation:
    # 依照第一張投影片的版面配置新增一張空白投影片。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 在新投影片上新增橢圓形狀；此投影片稍後會被複製。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 再依照第一張投影片的版面配置新增另一張空白投影片。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 建立名稱為「Section2」且起始於 slide2 的章節。
    section = presentation.sections.add_section("Section2", slide2)
    # 將先前建立的投影片複製到「Section2」章節中。
    presentation.slides.add_clone(slide, section)
    # 將簡報儲存為 PPTX 檔案。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**會一起複製演講者備註與審閱者評論嗎？**

會。備註頁與審閱意見都會包含在複製的投影片中。若不想保留它們，請在插入後[移除它們](/slides/zh-hant/python-net/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式與嵌入的資料都會被複製。若圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會以 [OLE 物件](/slides/zh-hant/python-net/manage-ole/) 形式保留。搬移檔案後，請驗證資料可用性並檢查是否需要重新整理。

**我能控制複製品的插入位置與章節嗎？**

可以。您可以在特定的投影片索引插入複製品，並將其放入選定的[章節](/slides/zh-hant/python-net/slide-section/)。若目標章節不存在，請先建立章節，然後再將投影片移入其中。