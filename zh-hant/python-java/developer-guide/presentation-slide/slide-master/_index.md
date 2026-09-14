---
title: 使用 Python via Java 管理簡報投影片母片
linktitle: 投影片母片
type: docs
weight: 70
url: /zh-hant/python-java/slide-master/
keywords:
- 投影片母片
- 母片投影片
- PPT 母片投影片
- 多個母片投影片
- 比較母片投影片
- 背景
- 佔位元
- 複製母片投影片
- 拷貝母片投影片
- 重複母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理投影片母片：在 PowerPoint 與 OpenDocument 簡報中存取、編輯、複製、比較及移除母片投影片。"
---
## **概觀**

一個 **投影片母片** 定義了一組投影片的共用設計設定。它可以包含共用的圖形、標誌、背景、文字樣式、主題設定以及頁眉頁腳設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常用方式，無需在每張投影片上重複相同的格式設定。

Aspose.Slides for Python via Java 支援相同的模型。簡報可以包含一個或多個母片投影片，而每個母片投影片可以包含多個版面投影片。普通投影片通常不會直接參考母片投影片。相反地，普通投影片會使用版面投影片，而該版面投影片屬於某個母片投影片。

層級結構如下：

1. **投影片母片** - 定義共用的設計與主題。  
1. **版面投影片** - 定義佔位元的特定排列與版面層級的格式設定。  
1. **普通投影片** - 包含實際的簡報內容，使用一個版面投影片。

![投影片母片、版面投影片與普通投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片以 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/) 類別表示。簡報中所有的母片投影片可透過 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasters) 集合取得，該集合以 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/) 表示。

{{% alert color="info" title="Inheritance" %}}
當同一屬性在多個層級中都有定義時，較具體的層級會優先。舉例來說，若母片投影片與版面投影片同時定義了背景，則基於該版面的投影片會使用版面的背景。欲取得更多關於版面投影片的資訊，請參閱 [Apply or Change Slide Layouts](/slides/zh-hant/python-java/slide-layout/)。
{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，可從 **檢視** > **投影片母片** 開啟投影片母片檢視。

![PowerPoint「檢視」索引標籤中的「投影片母片」指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasters) 集合來存取母片投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

您也可以透過普通投影片的版面取得其所使用的母片投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **投影片母片包含哪些內容**

母片投影片是一種類似投影片的物件。它繼承自 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/)，因此具有許多普通投影片與版面投影片共用的屬性。母片專屬的成員列於 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/) API 頁面。

常用的母片投影片成員包括：

| 成員 | 用途 |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getBackground) | 設定母片層級的投影片背景。 |
| [getShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getShapes) | 儲存放置於母片上的圖形，例如標誌、圖片框和共用文字。 |
| [getLayoutSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/#getLayoutSlides) | 儲存屬於母片的版面投影片。 |
| [getThemeManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/#getThemeManager) | 提供存取母片主題的 API。 |
| [getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | 控制母片及其子版面的頁首、頁尾、日期與投影片編號。 |
| [getDependingSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/#getDependingSlides) | 返回依賴於母片且透過版面使用的普通投影片。 |

## **在投影片母片上新增圖像**

將圖像加入母片投影片時，會顯示在使用該母片版面的投影片上。這對於標誌、水印、裝飾條紋或其他需重複出現的視覺元素非常有用。

以下範例在第一個母片投影片上加入標誌：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

欲取得更多關於圖片框的資訊，請參閱 [Picture Frame](/slides/zh-hant/python-java/picture-frame/)。

## **使用佔位元**

佔位元通常在版面投影片上定義。母片投影片提供共用的樣式與主題，供這些版面繼承，而每個版面決定哪些佔位元可用以及它們的放置位置。

在 PowerPoint 中，佔位元指令可在投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的「插入佔位元」指令](slide-master_5.png)

若要使用 Aspose.Slides 新增佔位元，請對屬於母片的版面投影片進行操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

您也可以格式化已存在於母片投影片上的佔位元圖形。以下範例找到標題佔位元並套用線性漸層填色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![普通投影片繼承的已格式化標題佔位元](slide-master_8.png)

欲取得更多佔位元與文字格式化的選項，請參閱 [Set Prompt Text in Placeholder](/slides/zh-hant/python-java/manage-placeholder/) 與 [Text Formatting](/slides/zh-hant/python-java/text-formatting/)。

## **變更投影片母片背景**

母片背景會被版面與未自行覆寫背景的投影片繼承。以下範例為第一個母片投影片設定單色背景：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

相關主題請參閱 [Presentation Background](/slides/zh-hant/python-java/presentation-background/) 與 [Presentation Theme](/slides/zh-hant/python-java/presentation-theme/)。

## **將投影片母片複製到其他簡報**

使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/#addClone) 可將母片投影片複製到另一個簡報。複製後的母片即可供目標簡報的版面與投影片使用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

若需同時複製普通投影片及其母片，請參閱 [Clone Slides](/slides/zh-hant/python-java/clone-slides/)。

## **新增多個投影片母片**

簡報可以包含多個母片投影片。當不同章節需要不同的品牌、版面結構或主題設定時，這非常實用。

![PowerPoint 插入與管理母片投影片的指令](slide-master_9.jpg)

以下範例會複製預設母片、為複製品設定不同的背景、在該複製母片下建立版面，並依據該版面新增投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **比較投影片母片**

母片投影片可使用從 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/) 繼承的 [equals](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#equals) 方法進行比較。比較會檢查結構與靜態內容，例如圖形、文字、格式、動畫與其他投影片設定。它不會比較唯一識別碼（如投影片 ID）或動態佔位元值（如當前日期）。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

欲取得更多資訊，請參閱 [Compare Presentation Slides](/slides/zh-hant/python-java/compare-slides/)。

## **將投影片母片檢視設為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/) 上的 [setLastView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#setLastView) 方法，可控制 PowerPoint 首次開啟時的檢視模式。以下範例在投影片母片檢視中開啟簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

欲取得更多檢視設定，請參閱 [Save Presentation](/slides/zh-hant/python-java/save-presentation/)。

## **移除未使用的投影片母片**

簡報有時會包含已不再被任何普通投影片使用的母片投影片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 [removeUnused](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/#removeUnused) 方法，從 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasters) 集合中移除未使用的母片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

您也可以使用低程式碼的 [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/#removeUnusedMasterSlides) 方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**投影片母片與版面投影片有何差異？**

投影片母片定義共用的設計設定，如主題、背景、共用圖形與文字樣式。版面投影片屬於母片，並定義佔位元的具體排列。普通投影片使用版面投影片，因此會同時繼承版面與母片的設定。

**一個簡報可以包含多個投影片母片嗎？**

可以。簡報可以包含多個投影片母片。當不同章節需要不同的視覺系統或品牌時，請使用多個母片。

**應該在母片還是版面投影片上新增佔位元？**

大多數情況下，應在版面投影片上新增佔位元。將共用的視覺元素與共用格式放在母片上，然後在普通投影片會使用的版面上放置內容佔位元。

**我可以刪除仍在使用中的母片嗎？**

不行。具有相依投影片的母片無法直接安全地刪除。請先將這些投影片移動至其他母片的版面，或使用僅移除未使用母片的清理方法。