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
description: "使用 Aspose.Slides for Python via .NET 快速克隆或複製 PowerPoint 投影片。遵循我們清晰的程式碼範例和技巧，即可在數秒內自動化 PPT 製作，提高生產力，消除人工操作。"
---
## **簡介**

克隆是製作某物精確副本或複製的過程。Aspose.Slides 也允許您複製（克隆）任何投影片，然後將克隆的投影片插入當前簡報或任何其他開啟的簡報。投影片克隆會產生一個新投影片，開發人員可以在不影響原始投影片的情況下進行修改。克隆投影片有多種方式：

- 在簡報的末端克隆。
- 在簡報的其他位置克隆。
- 在另一簡報的末端克隆。
- 在另一簡報的其他位置克隆。
- 在另一簡報的特定位置克隆。

在 Aspose.Slides for Python via .NET 中，由 [投影片集合](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 所提供的 **Presentation** 物件可使用 `add_clone` 與 `insert_clone` 方法執行上述各類投影片克隆。

## **安裝**

```bash
pip install aspose.slides
```

## **在同一簡報內於結尾處克隆**

如果想在同一簡報內克隆投影片並將其追加至現有投影片的末端，請使用 `add_clone` 方法。步驟如下：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從 **Presentation** 物件取得投影片集合。
1. 在 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone` 方法，傳入要克隆的投影片。
1. 儲存已修改的簡報。

以下範例會克隆第一張投影片（索引 0）並將其追加至簡報的末端。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示簡報檔案。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 將所需的投影片克隆至同一簡報中投影片集合的末端。
    presentation.slides.add_clone(presentation.slides[0])
    # 將已修改的簡報儲存至磁碟。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在同一簡報內於特定位置克隆**

如果想在同一簡報內克隆投影片並將其放置於其他位置，請使用 `insert_clone` 方法：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 從 **Presentation** 物件取得投影片集合。
1. 在 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `insert_clone` 方法，傳入要克隆的投影片以及新位置的目標索引。
1. 儲存已修改的簡報。

以下範例會將索引 1（第 2 張） 的投影片克隆至索引 2（第 3 張） 位置，仍在同一簡報內。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示簡報檔案。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 將所需的投影片克隆至同一簡報中指定的位置（索引）。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 將已修改的簡報儲存至磁碟。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一簡報的結尾處克隆**

如果需要將投影片從一個簡報克隆並追加至另一簡報的末端：

1. 為來源簡報（包含要克隆之投影片）建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。
1. 為目標簡報（將加入投影片的簡報）建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。
1. 從目標簡報取得投影片集合。
1. 在目標的 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone`，傳入來源簡報的投影片。
1. 儲存已修改的目標簡報。

以下範例會將來源簡報索引 0 的投影片克隆至目標簡報的末端。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示來源簡報檔案。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 為目標 PPTX（投影片將被克隆的地方）實例化 Presentation 類別。
    with slides.Presentation() as target_presentation:
        # 將所需的投影片從來源簡報克隆至目標簡報中投影片集合的末端。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 將目標簡報儲存至磁碟。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一簡報的特定位置克隆**

如果需要將投影片從一個簡報克隆並插入另一簡報的特定位置：

1. 為來源簡報（包含要克隆之投影片）建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。
1. 為目標簡報（將加入投影片的簡報）建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。
1. 從目標簡報取得投影片集合。
1. 在目標的 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `insert_clone`，傳入來源簡報的投影片以及目標索引。
1. 儲存已修改的目標簡報。

以下範例會將來源簡報索引 0 的投影片克隆至目標簡報索引 2（第 3 張）的位置。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示來源簡報檔案。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 為目標 PPTX（投影片將被克隆的地方）實例化 Presentation 類別。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # 在目標簡報的索引 2 插入來源第一張投影片的克隆。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 將目標簡報儲存至磁碟。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **將投影片及其主投影片克隆至另一簡報**

如果需要將投影片 **連同其主投影片** 從一個簡報克隆至另一個簡報，必須先將來源簡報的需要的主投影片克隆至目標簡報，然後在克隆投影片時使用該目標主投影片。`add_clone(Slide, MasterSlide)` 方法期望的是 **目標簡報的主投影片**，而不是來源簡報的。

克隆帶有主投影片的投影片，步驟如下：

1. 為來源簡報（包含要克隆之投影片）建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。
1. 為目標簡報建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。
1. 取得要克隆的來源投影片以及其主投影片。
1. 從目標簡報的主投影片集合取得 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/)。
1. 在目標的 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/) 上呼叫 `add_clone`，傳入來源的主投影片以將其克隆至目標。
1. 從目標簡報的投影片集合取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)。
1. 在目標的 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 上呼叫 `add_clone`，傳入來源投影片以及剛克隆的目標主投影片。
1. 儲存已修改的目標簡報。

以下範例會將來源簡報索引 0 的投影片克隆至目標簡報的末端，並使用從來源克隆的主投影片。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示來源簡報檔案。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # 為投影片將被克隆的目標簡報實例化 Presentation 類別。
    with slides.Presentation() as target_presentation:
        # 從來源簡報取得第一張投影片。
        source_slide = source_presentation.slides[0]
        # 取得第一張投影片使用的主投影片。
        source_master = source_slide.layout_slide.master_slide
        # 將主投影片克隆至目標簡報的主投影片集合。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # 使用已克隆的主投影片，將來源簡報的投影片克隆至目標簡報的末端。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 將目標簡報儲存至磁碟。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在指定章節的結尾處克隆**

使用 Aspose.Slides for Python via .NET，您可以從簡報的某個章節克隆投影片，並將其插入同一簡報的另一章節。為此，請使用 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 類別的 `add_clone(Slide, Section)` 方法。

以下 Python 範例示範如何克隆投影片並將克隆插入指定章節：

```py
import aspose.slides as slides

# 建立一個新的空白簡報。
with slides.Presentation() as presentation:
    # 新增一張依據第一張投影片版面配置的空白投影片。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 在新投影片加入橢圓形狀；此投影片稍後將被克隆。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 再新增一張依據第一張投影片版面配置的空白投影片。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 建立名為「Section2」的章節，起始於 slide2。
    section = presentation.sections.add_section("Section2", slide2)
    # 將先前建立的投影片克隆至「Section2」章節中。
    presentation.slides.add_clone(slide, section)
    # 將簡報儲存為 PPTX 檔案。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **確保投影片尺寸相符**

在將投影片克隆至另一簡報時，請確保目標簡報的投影片尺寸與來源簡報相同。若尺寸不同，Aspose.Slides 不會自動重新縮放克隆的形狀——其原始座標與尺寸會保留，可能導致內容對齊不正確或超出投影片邊界。

您可以在克隆主投影片與投影片之前，先將目標簡報的投影片尺寸設定為與來源相同：

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

在克隆主投影片與投影片之前執行上述設定。

## **常見問題**

### **演講者備註與審閱者評論會被克隆嗎？**

是的。備註頁面與審閱評論會包含在克隆中。若不需要，可在插入後 [刪除它們](/slides/zh-hant/python-net/presentation-notes/)。

### **圖表及其資料來源如何處理？**

圖表物件、格式與內嵌資料皆會被複製。若圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會保留為 [OLE 物件](/slides/zh-hant/python-net/manage-ole/)。檔案移動後，請驗證資料可用性並重新整理。

### **我可以控制克隆的插入位置和章節嗎？**

可以。您可以在特定投影片索引插入克隆，並將其放入選定的 [章節](/slides/zh-hant/python-net/slide-section/)。若目標章節不存在，請先建立章節，然後再將投影片移入。