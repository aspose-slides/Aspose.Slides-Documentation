---
title: 在 Python 中複製簡報投影片
linktitle: 複製投影片
type: docs
weight: 35
url: /zh-hant/python-java/clone-slides/
keywords:
- 複製投影片
- 拷貝投影片
- 儲存投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 快速複製 PowerPoint 投影片。依照我們清晰的程式碼範例，在數秒內自動化 PPT 建立，省去手動操作。"
---
## **簡介**

Cloning 是製作完全相同副本或複製品的過程。Aspose.Slides for Python via Java 也可以讓您複製任意投影片，然後將該複製的投影片插入目前的簡報或任何其他開啟的簡報。投影片複製的過程會建立一張新投影片，開發人員可以在不更動原始投影片的情況下進行修改。複製投影片有多種可能的方式：

- 在簡報內的結尾處複製投影片。
- 在簡報內的其他位置複製投影片。
- 在另一個簡報的結尾處複製投影片。
- 在另一個簡報的其他位置複製投影片。
- 將投影片及其母片一起複製到另一個簡報中。

在 Aspose.Slides for Python via Java 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件所公開的投影片集合（[Slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 物件的集合）提供 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 和 [insertClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertClone) 方法，以執行上述投影片複製類型。

## **在簡報結尾處複製投影片**

如果您想要複製投影片，並在同一簡報檔案的現有投影片結尾處使用它，請依照以下步驟使用 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件公開的 Slides 集合，取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件。
3. 呼叫 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件所公開的 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法，並將欲複製的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法。
4. 寫入已修改的簡報檔案。

以下範例中，我們已將投影片（位於簡報的第一個位置 – 零索引 –）複製至簡報的結尾。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 實例化代表簡報檔案的 Presentation 類別
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # 將所需投影片複製至同一簡報中投影片集合的結尾
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # 將修改後的簡報寫入磁碟
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在簡報內的其他位置複製投影片**

如果您想要複製投影片，並在同一簡報檔案的不同位置使用它，請使用 [insertClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertClone) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 取得在 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件上呼叫 [getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 所返回的投影片集合參考。
3. 呼叫 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件所公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertClone) 方法，並將欲複製的投影片以及新位置的索引作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertClone) 方法。
4. 將已修改的簡報寫入為 PPTX 檔案。

以下範例中，我們已將投影片（位於索引 1 – 位置 2 – 的投影片）複製至索引 2 – 位置 3 – 的位置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 實例化代表簡報檔案的 Presentation 類別
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # 取得簡報中的投影片集合
    slides = presentation.getSlides()

    # 將所需投影片複製至同一簡報中指定的索引位置
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # 將修改後的簡報寫入磁碟
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在另一個簡報的結尾處複製投影片**

如果您需要從一個簡報複製投影片，並在另一個簡報檔案的結尾處使用它：

1. 建立包含欲從其複製投影片之簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
2. 建立包含目標簡報（投影片將被加入）的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
3. 取得由目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件上呼叫 [getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 所返回的投影片集合，並參考取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件。
4. 呼叫 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件所公開的 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法，並將來源簡報中的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法。
5. 寫入已修改的目標簡報檔案。

以下範例中，我們已將投影片（來源簡報的索引 0）複製至目標簡報的結尾。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 實例化 Presentation 類別以載入來源簡報檔案
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # 實例化 Destination PPTX 的 Presentation 類別（投影片將被複製至此）
    destination_presentation = Presentation()
    try:
        # 從來源簡報中將所需投影片複製至目標簡報的投影片集合結尾
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # 將目標簡報寫入磁碟
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **在另一個簡報的其他位置複製投影片**

如果您需要從一個簡報複製投影片，並在另一個簡報檔案的特定位置使用它：

1. 建立包含欲從其複製投影片之來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
2. 建立包含目標簡報（投影片將被加入）的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
3. 取得由目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件所公開的 Slides 集合，並參考取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件。
4. 呼叫 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件所公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertClone) 方法，並將來源簡報中的投影片以及期望的位置作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertClone) 方法。
5. 寫入已修改的目標簡報檔案。

以下範例中，我們已將投影片（來源簡報的零索引）複製至目標簡報的索引 1（位置 2）。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 實例化 Presentation 類別以載入來源簡報檔案
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # 實例化 Presentation 類別用於目標 PPTX（投影片將被複製的地方）
    destination_presentation = Presentation()
    try:
        # 從來源簡報複製所需投影片至目標簡報的指定索引位置
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # 將目標簡報寫入磁碟
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **將投影片及其母片一起複製到另一個簡報**

如果您需要將投影片與母片一起從一個簡報複製到另一個簡報，必須先將來源簡報的目標母片複製至目標簡報，然後在複製投影片時使用該母片。[addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法需要的是目標簡報中的母片，而非來源簡報中的母片。請依照以下步驟進行：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別實例。
3. 取得要複製的投影片及其母片。
4. 取得由目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件所公開的 Masters 集合，並參考取得 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/) 物件。
5. 呼叫 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/) 物件所公開的 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/#addClone) 方法，並將來源 PPTX 中的母片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/#addClone) 方法。
6. 取得由目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件所公開的 Slides 集合，並參考取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件。
7. 呼叫 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 物件所公開的 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法，並將來源簡報的投影片以及剛剛複製的母片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法。
8. 寫入已修改的目標簡報檔案。

以下範例中，我們已將投影片（來源簡報的零索引）與其母片一起複製至目標簡報的結尾，使用來源投影片的母片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 實例化 Presentation 類別以載入來源簡報檔案
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # 實例化 Presentation 類別用於目標簡報（投影片將被複製的地方）
    destination_presentation = Presentation()
    try:
        # 從來源簡報的投影片集合中實例化投影片，並同時取得
        # 母片
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # 從來源簡報中複製所需母片至目標簡報的母片集合中
        # 目標簡報
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # 從來源簡報中以指定的母片複製所需投影片至目標簡報的投影片集合結尾
        # 目標簡報的投影片集合
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # 將目標簡報寫入磁碟
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **在指定分段的結尾處複製投影片**

如果您想要複製投影片，並在同一簡報檔案的不同分段中使用，請使用由 [**SlideCollection**](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 類別所公開的 [**addClone**](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 方法。Aspose.Slides for Python via Java 允許從第一個分段複製投影片，然後將該複製的投影片插入同一簡報的第二個分段。

以下程式碼片段示範如何複製投影片並將複製的投影片插入指定的分段。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # 將目標簡報寫入磁碟
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **確保投影片大小相符**

在將投影片複製至另一個簡報時，請確保目標簡報的投影片大小與來源簡報相同。若大小不同，Aspose.Slides 不會自動重新縮放複製的圖形——其原始座標與尺寸會被保留，可能導致內容出現錯位或超出投影片邊界。

您可以在複製母片與投影片之前，先將目標簡報的投影片大小設為與來源相同：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

在複製母片與投影片之前執行此操作。

## **常見問題**

**演講者備註與審閱者評論會被複製嗎？**

是。備註頁面和審閱評論會包含在複製品中。如果您不想要它們，請在插入後[移除它們](/slides/zh-hant/python-java/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式設定以及嵌入的資料都會被複製。如果圖表連結到外部來源（例如 OLE 嵌入的活頁簿），該連結會以 [OLE 物件](/slides/zh-hant/python-java/manage-ole/) 的形式保留。檔案移動後，請驗證資料是否可用並檢查重新整理的行為。

**我可以控制複製品的插入位置和分段嗎？**

可以。您可以在特定的投影片索引插入複製品，並將其放入選擇的 [分段](/slides/zh-hant/python-java/slide-section/)。如果目標分段不存在，請先建立該分段，然後再將投影片移入其中。