---
title: 在 Python 中管理演示文稿幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 80
url: /zh/python-net/slide-master/
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
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中管理幻灯片母版：访问、编辑、克隆、比较以及删除 PowerPoint 和 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

**幻灯片母版** 定义了一组幻灯片的共享设计设置。它可以包含公共形状、标志、背景、文本样式、主题设置和页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性的常用方式，而无需在每张幻灯片上重复相同的格式设置。

Aspose.Slides for Python via .NET 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含多个布局幻灯片。普通幻灯片通常不直接引用母版幻灯片，而是使用布局幻灯片，而该布局幻灯片隶属于某个母版幻灯片。

层次结构为：

1. **幻灯片母版** - 定义共享的设计和主题。  
1. **布局幻灯片** - 定义占位符的具体排列和布局级别的格式。  
1. **普通幻灯片** - 包含实际的演示内容，并使用一个布局幻灯片。

![母版幻灯片、布局幻灯片和普通幻灯片的层次结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [MasterSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslide/) 类表示。演示文稿中的所有母版幻灯片可通过 `Presentation.masters` 集合访问。

{{% alert color="info" title="Inheritance" %}}

当同一属性在多个层级上定义时，层级更具体的会获胜。例如，若母版幻灯片和布局幻灯片都定义了背景，则基于该布局的幻灯片使用布局背景。有关布局幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/slides/zh/python-net/slide-layout/)。

{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint“视图”选项卡上的幻灯片母版命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `masters` 集合访问母版幻灯片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

您也可以通过普通幻灯片的布局获取其使用的母版幻灯片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **幻灯片母版包含哪些内容**

母版幻灯片是类幻灯片对象。它从 [BaseSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslide/) 类继承了通用幻灯片行为，因此公开了许多普通幻灯片和布局幻灯片使用的相同属性。母版特有的成员列在 [MasterSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslide/) API 页面上。

常用的母版幻灯片成员包括：

| 成员 | 用途 |
| --- | --- |
| `background` | 设置母版级别的幻灯片背景。 |
| `shapes` | 存储放置在母版上的形状，如标志、图片框和共享文本。 |
| `layout_slides` | 存储属于该母版的布局幻灯片。 |
| `theme_manager` | 提供对母版主题 API 的访问。 |
| `header_footer_manager` | 控制母版及其子布局的页眉、页脚、日期和幻灯片编号。 |
| `get_depending_slides` | 返回通过布局依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图像**

向母版幻灯片添加图像后，使用该母版布局的幻灯片都会显示该图像。这对于标志、水印、装饰条等重复视觉元素非常有用。

下面的示例向第一张母版幻灯片添加了一个标志：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

有关图片框的更多信息，请参阅 [Picture Frame](/slides/zh/python-net/picture-frame/)。

## **使用占位符**

占位符通常在布局幻灯片上定义。母版幻灯片提供共享的样式和主题，布局则决定哪些占位符可用以及它们的位置。

在 PowerPoint 中，占位符命令可在幻灯片母版视图中使用。

![PowerPoint 幻灯片母版视图中的“插入占位符”命令](slide-master_5.png)

要在 Aspose.Slides 中添加新占位符，请对属于母版的布局幻灯片进行操作：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

您也可以格式化已经存在于母版幻灯片上的占位符形状。下面的示例查找标题占位符并应用线性渐变填充：

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![普通幻灯片继承的已格式化标题占位符](slide-master_8.png)

有关占位符和文本格式化的更多选项，请参阅 [Set Prompt Text in Placeholder](/slides/zh/python-net/manage-placeholder/) 和 [Text Formatting](/slides/zh/python-net/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被布局和未覆盖它的幻灯片继承。下面的示例为第一张母版幻灯片设置纯色背景：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

相关主题请参阅 [Presentation Background](/slides/zh/python-net/presentation-background/) 和 [Presentation Theme](/slides/zh/python-net/presentation-theme/)。

## **将幻灯片母版克隆到另一演示文稿**

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslidecollection/) 类的 `add_clone` 方法，可将母版幻灯片复制到另一演示文稿中。复制后的母版即可被目标演示文稿中的布局和幻灯片使用。

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

如果需要连同母版一起克隆普通幻灯片，请参阅 [Clone Slides](/slides/zh/python-net/clone-slides/)。

## **添加多个幻灯片母版**

一个演示文稿可以包含多个母版幻灯片。当不同章节需要不同的品牌、页面结构或主题设置时，这非常有用。

![PowerPoint 插入和管理母版幻灯片的命令](slide-master_9.jpg)

下面的示例克隆默认母版，给克隆母版设置不同的背景，获取该克隆母版下的空白布局，并基于该布局添加新幻灯片：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **比较幻灯片母版**

母版幻灯片可以使用从 [BaseSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslide/) 类继承的 `equals` 方法进行比较。比较检查结构和静态内容，如形状、文本、格式、动画及其他幻灯片设置。它不比较唯一标识符（如幻灯片 ID）或动态占位符值（如当前日期）。

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

更多信息请参阅 [Compare Presentation Slides](/slides/zh/python-net/compare-slides/)。

## **将幻灯片母版视图设为默认视图**

使用演示文稿 [ViewProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/) 上的 `last_view` 属性，可控制 PowerPoint 首次打开时的视图。下面的示例在幻灯片母版视图中打开演示文稿：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

有关更多视图设置，请参阅 [Save Presentation](/slides/zh/python-net/save-presentation/)。

## **删除未使用的母版幻灯片**

有时演示文稿中会包含已不再被任何普通幻灯片使用的母版幻灯片。删除未使用的母版可以减小文件大小并简化模板维护。

使用 `remove_unused` 删除 `masters` 集合中未使用的母版：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

您也可以使用 [Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) 类的低代码方法 `remove_unused_master_slides`：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

### 幻灯片母版和布局幻灯片有什么区别？

幻灯片母版定义了共享的设计设置，如主题、背景、公共形状和文本样式。布局幻灯片属于某个母版，定义占位符的具体排列。普通幻灯片使用布局幻灯片，因此它既继承布局也继承母版。

### 一个演示文稿能包含多个幻灯片母版吗？

可以。一个演示文稿可以包含多个母版幻灯片。当不同章节需要不同的视觉体系或品牌时，请使用多个母版。

### 应该在母版幻灯片还是布局幻灯片上添加占位符？

大多数情况下，在布局幻灯片上添加占位符。将共享的视觉元素和共享格式放在母版幻灯片上，然后在普通幻灯片将使用的布局上放置内容占位符。

### 能删除仍在使用中的母版幻灯片吗？

不能。拥有依赖幻灯片的母版幻灯片不能直接安全删除。应首先将这些幻灯片移动到其他母版的布局下，或使用仅删除未使用母版的清理方法。