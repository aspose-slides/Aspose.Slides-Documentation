---
title: 在 Python 中克隆 PowerPoint 投影片
linktitle: 克隆投影片
type: docs
weight: 40
url: /zh-hant/python-net/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 儲存投影片
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "快速使用 Aspose.Slides for Python via .NET 克隆或複製 PowerPoint 投影片。遵循我們清晰的程式碼範例與技巧，於數秒內自動化 PPT 建立，提高生產力，消除手動操作。"
---
## **簡介**

克隆是製作某物的完全相同副本或複製的過程。Aspose.Slides 也允許您複製（克隆）任何投影片，然後將克隆的投影片插入目前的簡報或任何其他開啟的簡報。投影片克隆會建立一個新投影片，開發人員可以在不影響原始投影片的情況下進行修改。有多種方式可以克隆投影片：

- 在簡報的末尾克隆投影片。
- 在同一簡報的其他位置克隆投影片。
- 在另一個簡報的結尾處克隆投影片。
- 在另一個簡報的其他位置克隆投影片。
- 在另一個簡報的特定位置克隆投影片。

在 Aspose.Slides for Python via .NET 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件公開的 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 提供 `add_clone` 和 `insert_clone` 方法，以執行這些投影片克隆類型。

## **安裝**

```bash
pip install aspose.slides
```

## **在同一簡報內的結尾處克隆**

如果您想在同一簡報內克隆投影片並將其添加到現有投影片的結尾，請使用 `add_clone` 方法。請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件取得投影片集合。
1. 在 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone` 方法，傳入要克隆的投影片。
1. 儲存已修改的簡報。

以下範例中，第一張投影片（索引 0）被克隆並附加至簡報的結尾。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以表示簡報檔案。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 將所需的投影片克隆到同一簡報中投影片集合的末尾。
    presentation.slides.add_clone(presentation.slides[0])
    # 將已修改的簡報儲存至磁碟。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在同一簡報內的特定位置克隆**

如果您想在同一簡報內克隆投影片並將其放置在不同位置，請使用 `insert_clone` 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件取得投影片集合。
1. 在 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `insert_clone` 方法，傳入要克隆的投影片以及其新位置的目標索引。
1. 儲存已修改的簡報。

以下範例中，索引 1（位置 2）的投影片被克隆到索引 2（位置 3）於同一簡報內。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以表示簡報檔案。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 將所需的投影片克隆到同一簡報中指定的位置（索引）。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 將已修改的簡報儲存至磁碟。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一個簡報的結尾處克隆**

如果您需要將投影片從一個簡報克隆並附加至另一個簡報的結尾：

1. 為來源簡報（包含要克隆的投影片）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 為目標簡報（將加入投影片的簡報）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從目標簡報取得投影片集合。
1. 在目標 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone`，傳入來源簡報的投影片。
1. 儲存已修改的目標簡報。

以下範例中，來源簡報的索引 0 投影片被克隆至目標簡報的結尾。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以表示來源簡報檔案。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 建立 Presentation 類別的實例以作為目標 PPTX（投影片將被克隆的地方）。
    with slides.Presentation() as target_presentation:
        # 將所需的投影片從來源簡報克隆到目標簡報中投影片集合的末尾。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 將目標簡報儲存至磁碟。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一個簡報的特定位置克隆**

如果您需要將投影片從一個簡報克隆並插入至另一個簡報的特定位置：

1. 為來源簡報（包含要克隆的投影片）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 為目標簡報（將加入投影片的簡報）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從目標簡報取得投影片集合。
1. 在目標 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `insert_clone`，傳入來源簡報的投影片以及目標索引。
1. 儲存已修改的目標簡報。

以下範例中，來源簡報的索引 0 投影片被克隆至目標簡報的索引 2（位置 3）。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以表示來源簡報檔案。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 建立 Presentation 類別的實例作為目標 PPTX（投影片將被克隆的地方）。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # 在目標簡報的索引 2 位置插入來源第一張投影片的克隆。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 將目標簡報儲存至磁碟。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **將投影片連同其母片克隆至另一個簡報**

如果您需要將投影片 **連同其母片** 從一個簡報克隆並在另一個簡報中使用，首先將所需的母片從來源簡報克隆至目標簡報，然後在克隆投影片時使用該目標母片。`add_clone(Slide, MasterSlide)` 方法預期的 **母片** 來自目標簡報，而非來源簡報。

請依照以下步驟克隆帶母片的投影片：

1. 為來源簡報（包含要克隆的投影片）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 為目標簡報建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 取得要克隆的來源投影片及其母片。
1. 從目標簡報的母片集合取得 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/)。
1. 在目標 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/) 上呼叫 `add_clone`，傳入來源母片以將其克隆至目標。
1. 從目標簡報的投影片集合取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)。
1. 在目標 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone`，傳入來源投影片以及剛才克隆的目標母片。
1. 儲存已修改的目標簡報。

以下範例中，來源簡報的索引 0 投影片使用從來源克隆的母片，並被克隆至目標簡報的結尾。

```py
import aspose.slides as slides

# 建立 Presentation 類別的實例以表示來源簡報檔案。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # 建立 Presentation 類別的實例作為目標簡報（投影片將被克隆的地方）。
    with slides.Presentation() as target_presentation:
        # 從來源簡報取得第一張投影片。
        source_slide = source_presentation.slides[0]
        # 取得第一張投影片使用的母片。
        source_master = source_slide.layout_slide.master_slide
        # 將母片克隆至目標簡報的母片集合中。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # 使用已克隆的母片，將來源簡報的投影片克隆至目標簡報的結尾。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 將目標簡報儲存至磁碟。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在指定區段的結尾處克隆**

使用 Aspose.Slides for Python via .NET，您可以將投影片從簡報的一個區段克隆並插入至同一簡報的另一個區段。為此，請使用 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 類別的 `add_clone(Slide, Section)` 方法。

以下 Python 範例說明如何克隆投影片並將克隆插入至指定區段：

```py
import aspose.slides as slides

# 建立新的空白簡報。
with slides.Presentation() as presentation:
    # 新增一張空白投影片，使用第一張投影片的版面配置。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 在新投影片上加入橢圓形狀；此投影片稍後會被克隆。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 再新增一張空白投影片，使用第一張投影片的版面配置。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 建立名稱為「Section2」的區段，起始於 slide2。
    section = presentation.sections.add_section("Section2", slide2)
    # 將先前建立的投影片克隆至「Section2」區段。
    presentation.slides.add_clone(slide, section)
    # 將簡報儲存為 PPTX 檔案。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

### 演講者備註與審閱者評論會被克隆嗎？

是的。備註頁面和審閱評論會包含在克隆中。如果您不想要它們，請在插入後[移除它們](/slides/zh-hant/python-net/presentation-notes/)。

### 圖表及其資料來源如何處理？

圖表物件、格式設定與嵌入的資料皆會被複製。如果圖表連結至外部來源（例如 OLE 嵌入的活頁簿），則會保留為[OLE 物件](/slides/zh-hant/python-net/manage-ole/)。在檔案之間移動後，請驗證資料的可用性與重新整理行為。

### 我能控制克隆的插入位置與區段嗎？

可以。您可以在特定的投影片索引插入克隆，並將其放入選擇的[區段](/slides/zh-hant/python-net/slide-section/)。如果目標區段不存在，請先建立該區段，然後再將投影片移入其中。