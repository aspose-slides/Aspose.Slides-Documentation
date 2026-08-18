---
title: 在 Python 中克隆 PowerPoint 投影片
linktitle: 克隆投影片
type: docs
weight: 40
url: /zh-hant/python-net/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 保存投影片
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 快速克隆或複製 PowerPoint 投影片。遵循我們清晰的程式碼範例與技巧，在數秒內自動化 PPT 製作，提高生產力，消除手動操作。"
---
## **簡介**

克隆是製作某物精確副本或複製的過程。Aspose.Slides 也允許您複製（克隆）任何投影片，然後將克隆的投影片插入當前簡報或任何其他開啟的簡報。投影片克隆會產生一個新投影片，開發人員可以修改它而不影響原始投影片。克隆投影片有以下幾種方式：

- 在簡報的尾端克隆。
- 在同一簡報的其他位置克隆。
- 在另一簡報的尾端克隆。
- 在另一簡報的其他位置克隆。
- 在另一簡報的特定位置克隆。

在 Aspose.Slides for Python via .NET 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件公開的 [slide collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 提供 `add_clone` 與 `insert_clone` 方法，以執行這些投影片克隆類型。

## **安裝**

```bash
pip install aspose.slides
```

## **在同一簡報內的尾端克隆**

如果您想在同一簡報內克隆投影片並將其附加至現有投影片的尾端，請使用 `add_clone` 方法。請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 從 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件取得投影片集合。
3. `add_clone` 方法呼叫於 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)，並傳入欲克隆的投影片。
4. 儲存已修改的簡報。

以下範例中，第一張投影片（索引 0）被克隆並附加至簡報的尾端。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示簡報檔案。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 將所需的投影片克隆至同一簡報的投影片集合尾端。
    presentation.slides.add_clone(presentation.slides[0])
    # 將已修改的簡報儲存至磁碟。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在同一簡報內的特定位置克隆**

如果您想在同一簡報內克隆投影片並將其放置於不同位置，請使用 `insert_clone` 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 從 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件取得投影片集合。
3. `insert_clone` 方法呼叫於 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)，並傳入欲克隆的投影片以及其新位置的目標索引。
4. 儲存已修改的簡報。

以下範例中，索引為 1（位置 2）的投影片被克隆至索引 2（位置 3）於同一簡報內。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示簡報檔案。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 將所需的投影片克隆至同一簡報內的指定位置（索引）。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 將已修改的簡報儲存至磁碟。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一簡報的尾端克隆**

如果您需要從一個簡報克隆投影片並將其附加至另一簡報的尾端：

1. 為來源簡報（包含欲克隆投影片的簡報）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 為目標簡報（將加入投影片的簡報）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
3. 從目標簡報取得投影片集合。
4. 在目標 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone`，並傳入來源簡報的投影片。
5. 儲存已修改的目標簡報。

以下範例中，來源簡報中索引 0 的投影片被克隆至目標簡報的尾端。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示來源簡報檔案。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 為目標 PPTX（將克隆投影片的地方）實例化 Presentation 類別。
    with slides.Presentation() as target_presentation:
        # 將所需的投影片從來源簡報克隆至目標簡報的投影片集合尾端。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 將目標簡報儲存至磁碟。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一簡報的特定位置克隆**

如果您需要從一個簡報克隆投影片並在另一簡報的特定位置插入：

1. 為來源簡報（包含欲克隆投影片的簡報）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 為目標簡報（將加入投影片的簡報）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
3. 從目標簡報取得投影片集合。
4. 在目標 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `insert_clone`，傳入來源簡報的投影片以及期望的目標索引。
5. 儲存已修改的目標簡報。

以下範例中，來源簡報中索引 0 的投影片被克隆至目標簡報的索引 2（位置 3）。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示來源簡報檔案。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 為目標 PPTX（要克隆投影片的地方）實例化 Presentation 類別。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # 在目標簡報的索引 2 處插入來源第一張投影片的克隆。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 將目標簡報儲存至磁碟。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **將投影片及其母片克隆至另一簡報**

如果您需要從一個簡報克隆包含其母片的投影片並在另一簡報中使用，首先將所需的母片從來源簡報克隆至目標簡報。然後在克隆投影片時使用該目標母片。`add_clone(Slide, MasterSlide)` 方法期望傳入 **目標簡報的母片**，而非來源的母片。

要克隆包含母片的投影片，請遵循以下步驟：

1. 為來源簡報（包含欲克隆投影片的簡報）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 為目標簡報建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
3. 取得欲克隆的來源投影片及其母片。
4. 從目標簡報的母片集合取得 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/)。
5. 在目標 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/) 上呼叫 `add_clone`，傳入來源母片以將其克隆至目標。
6. 從目標簡報的投影片集合取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)。
7. 在目標 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone`，傳入來源投影片以及已克隆的目標母片。
8. 儲存已修改的目標簡報。

以下範例中，來源簡報中索引 0 的投影片使用從來源克隆的母片，克隆至目標簡報的尾端。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示來源簡報檔案。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # 為要克隆投影片的目標簡報實例化 Presentation 類別。
    with slides.Presentation() as target_presentation:
        # 從來源簡報取得第一張投影片。
        source_slide = source_presentation.slides[0]
        # 取得第一張投影片使用的母片。
        source_master = source_slide.layout_slide.master_slide
        # 將母片克隆至目標簡報的母片集合中。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # 使用已克隆的母片，將來源簡報的投影片克隆至目標簡報的尾端。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 將目標簡報儲存至磁碟。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在指定區段的尾端克隆**

使用 Aspose.Slides for Python via .NET，您可以從簡報的一個區段克隆投影片，並將其插入同一簡報的另一個區段。為此，請使用 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 類別的 `add_clone(Slide, Section)` 方法。

以下 Python 範例示範如何克隆投影片並將克隆插入指定的區段：

```py
import aspose.slides as slides

# 建立一個新的空白簡報。
with slides.Presentation() as presentation:
    # 基於第一張投影片的版面配置新增一張空白投影片。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 在新投影片上加入橢圓形狀；此投影片稍後會被克隆。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 再基於第一張投影片的版面配置新增另一張空白投影片。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 建立名稱為「Section2」且起始於 slide2 的節。
    section = presentation.sections.add_section("Section2", slide2)
    # 將先前建立的投影片克隆至「Section2」節中。
    presentation.slides.add_clone(slide, section)
    # 將簡報儲存為 PPTX 檔案。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **確保投影片尺寸相同**

在將投影片克隆至另一簡報時，請確保目標簡報的投影片尺寸與來源相同。若尺寸不同，Aspose.Slides 不會自動調整克隆形狀的大小——其原始座標與尺寸會被保留，可能導致內容看起來錯位或超出投影片邊界。

您可以在克隆母片與投影片之前，將目標簡報的投影片尺寸設定為與來源相同：

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

請在克隆母片與投影片之前執行此操作。

## **常見問題**

**演講者備註與審閱者評論會被克隆嗎？**

是的。備註頁面與審閱評論會包含在克隆中。如果您不想要它們，請在插入後 [移除它們](/slides/zh-hant/python-net/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式設定與內嵌資料皆會被複製。若圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會以 [OLE 物件](/slides/zh-hant/python-net/manage-ole/) 形式保留。檔案移動後，請驗證資料可用性與重新整理行為。

**我可以控制克隆的插入位置與區段嗎？**

可以。您可以在特定投影片索引插入克隆，並將其放入選擇的 [區段](/slides/zh-hant/python-net/slide-section/)。若目標區段不存在，請先建立該區段，再將投影片移入其中。