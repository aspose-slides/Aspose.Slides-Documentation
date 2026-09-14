---
title: 在 Python via Java 中管理演示文稿幻灯片母版
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
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理幻灯片母版：访问、编辑、克隆、比较并移除 PowerPoint 和 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

**幻灯片母版**定义了一组幻灯片的共享设计设置。它可以包含通用形状、徽标、背景、文本样式、主题设置和页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性的常用方式，避免在每张幻灯片上重复相同的格式。

Aspose.Slides for Python via Java 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含多个版式幻灯片。普通幻灯片通常不会直接引用母版幻灯片，而是使用版式幻灯片，而该版式幻灯片属于某个母版幻灯片。

层次结构如下：

1. **幻灯片母版** - 定义共享的设计和主题。  
1. **版式幻灯片** - 定义占位符的具体排列以及版式级别的格式。  
1. **普通幻灯片** - 包含实际的演示内容并使用一个版式幻灯片。

![母版幻灯片、版式幻灯片和普通幻灯片的层次结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [MasterSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/) 类表示。演示文稿中的所有母版幻灯片可通过 [Presentation.getMasters](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasters) 集合获取，该集合由 [MasterSlideCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/) 表示。

{{% alert color="info" title="Inheritance" %}}
当同一属性在多个层级上定义时，较具体的层级会覆盖更高层级。例如，如果母版幻灯片和版式幻灯片都定义了背景，则基于该版式的幻灯片会使用版式背景。有关版式幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/slides/zh/python-java/slide-layout/)。
{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，您可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint “视图”选项卡上的幻灯片母版命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 [Presentation.getMasters](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasters) 集合来访问母版幻灯片：

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

您还可以通过普通幻灯片的版式获取其使用的母版幻灯片：

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

母版幻灯片是类似幻灯片的对象。它继承自 [BaseSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/)，因此公开了许多普通幻灯片和版式幻灯片使用的相同属性。母版特有的成员列在 [MasterSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/) API 页面上。

常用的母版幻灯片成员包括：

| 成员 | 用途 |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getBackground) | 设置母版级别的幻灯片背景。 |
| [getShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getShapes) | 存储放置在母版上的形状，例如徽标、图片框和共享文本。 |
| [getLayoutSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getLayoutSlides) | 存储属于该母版的版式幻灯片。 |
| [getThemeManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getThemeManager) | 提供对母版主题 API 的访问。 |
| [getHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | 控制母版及其子版式的页眉、页脚、日期和幻灯片编号。 |
| [getDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getDependingSlides) | 返回通过版式依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图片**

向母版幻灯片添加图片后，使用该母版版式的幻灯片都会显示该图片。这对于徽标、水印、装饰条带以及其他重复的视觉元素非常有用。

以下示例在第一张母版幻灯片上添加徽标：

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

## **使用占位符**

占位符通常在版式幻灯片上定义。母版幻灯片提供共享的样式和主题，版式则决定哪些占位符可用以及它们的位置。

在 PowerPoint 中，占位符命令可在幻灯片母版视图中使用。

![PowerPoint 幻灯片母版视图中的“插入占位符”命令](slide-master_5.png)

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

您还可以格式化已存在于母版幻灯片上的占位符形状。以下示例查找标题占位符并应用线性渐变填充：

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

有关占位符和文本格式化的更多选项，请参阅 [Set Prompt Text in Placeholder](/slides/zh/python-java/manage-placeholder/) 和 [Text Formatting](/slides/zh/python-java/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被版式和未覆盖该背景的幻灯片继承。以下示例为第一张母版幻灯片设置纯色背景：

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

使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/#addClone) 可将母版幻灯片复制到另一个演示文稿。复制后的母版随后可供目标演示文稿中的版式和幻灯片使用。

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

以下示例克隆默认母版，为克隆副本设置不同的背景，在该克隆母版下创建版式，并基于该版式添加新幻灯片：

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

母版幻灯片可以使用从 [BaseSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/) 继承的 [equals](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#equals) 方法进行比较。比较检查结构和静态内容，如形状、文本、格式、动画以及其他幻灯片设置。它不比较唯一标识符（例如幻灯片 ID）或动态占位符值（例如当前日期）。

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

使用 [ViewProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/) 上的 [setLastView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#setLastView) 方法可控制 PowerPoint 首次打开时的视图。以下示例在幻灯片母版视图中打开演示文稿：

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

## **移除未使用的母版幻灯片**

有时演示文稿会包含已不再被任何普通幻灯片使用的母版幻灯片。移除未使用的母版可以减小文件体积并简化模板维护。

使用 [MasterSlideCollection.removeUnused](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/#removeUnused) 可从 [Presentation.getMasters](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasters) 集合中删除未使用的母版：

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

## **常见问题**

**幻灯片母版和版式幻灯片有什么区别？**

幻灯片母版定义共享的设计设置，例如主题、背景、通用形状和文本样式。版式幻灯片属于某个母版，定义占位符的具体排列。普通幻灯片使用版式幻灯片，因此会同时继承版式和母版的设置。

**一个演示文稿可以包含多个幻灯片母版吗？**

可以。演示文稿可以包含多个母版幻灯片。当不同章节需要不同的视觉系统或品牌时，请使用多个母版。

**应该在母版幻灯片还是版式幻灯片上添加占位符？**

大多数情况下，应在版式幻灯片上添加占位符。将共享的视觉元素和共享格式放在母版上，然后在普通幻灯片使用的版式上放置内容占位符。

**可以删除仍在使用的母版幻灯片吗？**

不能。拥有依赖幻灯片的母版不能直接安全删除。请先将这些幻灯片移动到另一个母版的版式下，或使用仅移除未使用母版的清理方法。