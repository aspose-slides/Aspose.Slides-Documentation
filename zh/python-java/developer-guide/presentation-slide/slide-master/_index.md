---
title: 使用 Python via Java 管理演示文稿幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 70
url: /zh/python-java/slide-master/
keywords:
- 幻灯片母版
- 母版幻灯片
- PPT 母版幻灯片
- 多个母版幻灯片
- 比较母版幻灯片
- 背景
- 占位符
- 克隆母版幻灯片
- 复制母版幻灯片
- 重复母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理幻灯片母版：访问、编辑、克隆、比较和删除 PowerPoint 与 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

**幻灯片母版** 定义了一组幻灯片的共享设计设置。它可以包含共同的形状、标志、背景、文字样式、主题设置以及页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性的常用方式，避免在每张幻灯片上重复相同的格式。

Aspose.Slides for Python via Java 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含若干版式幻灯片。普通幻灯片通常不直接引用母版幻灯片，而是使用版式幻灯片，而该版式幻灯片属于某个母版幻灯片。

层次结构如下：

1. **幻灯片母版** – 定义共享的设计和主题。  
1. **版式幻灯片** – 定义占位符的具体排列以及版式级别的格式。  
1. **普通幻灯片** – 包含实际的演示内容并使用一个版式幻灯片。

![母版幻灯片、版式幻灯片和普通幻灯片的层次结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [MasterSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/) 类表示。演示文稿中的所有母版幻灯片可通过 [Presentation.getMasters](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasters) 集合访问，该集合由 [MasterSlideCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/) 表示。

{{% alert color="info" title="Inheritance" %}}
当同一属性在多个层级上定义时，层级更具体的值会生效。例如，如果母版幻灯片和版式幻灯片都定义了背景，则基于该版式的幻灯片使用版式背景。有关版式幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/slides/zh/python-java/slide-layout/)。
{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，您可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint “视图”选项卡上的幻灯片母版命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 [Presentation.getMasters](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasters) 集合访问母版幻灯片：

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

您也可以通过普通幻灯片的版式获取其使用的母版幻灯片：

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

## **幻灯片母版包含的内容**

母版幻灯片是类似幻灯片的对象。它继承自 [BaseSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/)，因此暴露了许多普通幻灯片和版式幻灯片使用的相同属性。母版专用成员列在 [MasterSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/) API 页面上。

常用的母版幻灯片成员包括：

| 成员 | 用途 |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getBackground) | 设置母版级别的幻灯片背景。 |
| [getShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getShapes) | 存储放置在母版上的形状，例如标志、图片框和共享文本。 |
| [getLayoutSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getLayoutSlides) | 存储属于该母版的版式幻灯片。 |
| [getThemeManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getThemeManager) | 提供对母版主题 API 的访问。 |
| [getHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | 控制母版及其子版式的页眉、页脚、日期和页码。 |
| [getDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getDependingSlides) | 返回通过版式依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图像**

向母版幻灯片添加图像后，使用该母版版式的幻灯片都会显示该图像。这在标志、水印、装饰条等需要重复出现的视觉元素时非常有用。

下面的示例向第一张母版幻灯片添加一个标志：

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

有关图片框的更多信息，请参阅 [Picture Frame](/slides/zh/python-java/picture-frame/)。

## **控制母版图形的可见性**

使用 [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#setShowMasterShapes) 可隐藏继承自母版的图形（如标志或装饰形状），而不会将它们从母版中删除。对需要省略这些图形的幻灯片调用 [Slide.setShowMasterShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#setShowMasterShapes) 并传入 `False`，在需要显示它们的幻灯片上保持 `True`。

下面的完整示例在母版上创建一个蓝色装饰条，并在两个使用同一空白版式的幻灯片中分别显示和隐藏该条。示例不需要输入演示文稿或图像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

该示例使用新建演示文稿自带的 **Blank** 版式，并移除初始幻灯片自带的占位符。

### **选择设置的作用范围**

普通幻灯片通过 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getLayoutSlide) 和 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getMasterSlide) 使用其母版。在单个幻灯片上设置属性只影响该幻灯片本身。将 `False` 传给 [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#setShowMasterShapes) 会隐藏使用该共享版式的所有幻灯片的母版图形，即使它们各自的设置为 `True`。若只想在一张幻灯片上隐藏图形，请修改该幻灯片的属性而保持共享版式不变。

该设置不支持在母版幻灯片本身上作为可见性控制使用。对母版调用 [getShowMasterShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getShowMasterShapes) 始终返回 `False`，而将 `True` 传入 [setShowMasterShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#setShowMasterShapes) 会抛出异常。请在普通幻灯片或版式上使用此功能。

### **将图形与背景区分**

| 操作 | 效果 |
| --- | --- |
| 隐藏母版图形 | 在不删除或更改幻灯片自身形状的前提下，控制继承自母版的形状可见性。 |
| 更改幻灯片背景填充 | 更改背景颜色、渐变或图像。母版图形是独立的形状，可在背景之上保持可见。参见 [Presentation Background](/slides/zh/python-java/presentation-background/)。 |
| 删除母版中的形状 | 移除共享源形状，导致使用该母版的任何幻灯片都不再拥有该形状。 |

## **使用占位符**

占位符通常在版式幻灯片上定义。母版提供共享的样式和主题，版式则决定哪些占位符可用以及它们的放置位置。

在 PowerPoint 中，占位符命令位于幻灯片母版视图中。

![PowerPoint 幻灯片母版视图中的 Insert Placeholder 命令](slide-master_5.png)

要在 Aspose.Slides 中添加新占位符，请操作属于母版的版式幻灯片：

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

您也可以格式化已经存在于母版幻灯片上的占位符形状。下面的示例查找标题占位符并应用线性渐变填充：

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

![普通幻灯片继承的已格式化标题占位符](slide-master_8.png)

有关更多占位符和文本格式化选项，请参阅 [Set Prompt Text in Placeholder](/slides/zh/python-java/manage-placeholder/) 和 [Text Formatting](/slides/zh/python-java/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被版式和未覆盖它的幻灯片继承。下面的示例为第一张母版幻灯片设置纯色背景：

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

相关主题请参阅 [Presentation Background](/slides/zh/python-java/presentation-background/) 和 [Presentation Theme](/slides/zh/python-java/presentation-theme/)。

## **将幻灯片母版克隆到另一个演示文稿**

使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/#addClone) 可将母版幻灯片复制到另一份演示文稿中。复制后的母版随后可供目标演示文稿中的版式和幻灯片使用。

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

如果需要同时克隆普通幻灯片及其母版，请参阅 [Clone Slides](/slides/zh/python-java/clone-slides/)。

## **添加多个幻灯片母版**

一个演示文稿可以包含多个母版幻灯片。这在不同章节需要不同品牌、页面结构或主题设置时非常有用。

![PowerPoint 插入和管理母版幻灯片的命令](slide-master_9.jpg)

下面的示例克隆默认母版，为克隆副本设置不同的背景，在该克隆母版下创建版式，并基于该版式添加新幻灯片：

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

## **比较幻灯片母版**

母版幻灯片可以使用从 [BaseSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/) 继承的 [equals](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#equals) 方法进行比较。比较检查结构和静态内容，例如形状、文本、格式、动画以及其他幻灯片设置。它不比较唯一标识符（如幻灯片 ID）或动态占位符值（如当前日期）。

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

更多信息请参阅 [Compare Presentation Slides](/slides/zh/python-java/compare-slides/)。

## **将幻灯片母版视图设为默认视图**

在 [ViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/) 上使用 [setLastView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#setLastView) 方法可控制 PowerPoint 首次打开时的视图。下面的示例在幻灯片母版视图中打开演示文稿：

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

更多视图设置请参阅 [Save Presentation](/slides/zh/python-java/save-presentation/)。

## **删除未使用的母版幻灯片**

有时演示文稿中会存在已不再被任何普通幻灯片使用的母版幻灯片。删除未使用的母版可以减小文件体积并简化模板维护。

使用 [removeUnused](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/#removeUnused) 可从 [Presentation.getMasters](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasters) 集合中移除未使用的母版：

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

您也可以使用低代码的 [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#removeUnusedMasterSlides) 方法：

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

## **常见问题解答**

**幻灯片母版和版式幻灯片有什么区别？**

幻灯片母版定义共享的设计设置，如主题、背景、公共形状和文字样式。版式幻灯片属于某个母版，定义占位符的具体排列。普通幻灯片使用版式幻灯片，从而同时继承版式和母版的设置。

**一个演示文稿可以包含多个幻灯片母版吗？**

可以。演示文稿可以包含多个母版幻灯片。当不同章节需要不同的视觉体系或品牌时，请使用多个母版。

**应当在母版幻灯片还是版式幻灯片上添加占位符？**

大多数情况下，请在版式幻灯片上添加占位符。将共享的视觉元素和共享格式放在母版上，然后在普通幻灯片将使用的版式上放置内容占位符。

**我可以删除仍被使用的母版幻灯片吗？**

不能。仍有从属幻灯片的母版不能直接安全删除。请先将这些幻灯片移动到另一个母版的版式下，或使用仅删除未被使用的母版的清理方法。