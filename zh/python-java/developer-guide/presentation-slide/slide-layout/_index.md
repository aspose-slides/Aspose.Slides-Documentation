---
title: 在 Python（通过 Java）中应用或更改幻灯片布局
linktitle: 幻灯片布局
type: docs
weight: 60
url: /zh/python-java/slide-layout/
keywords:
- 幻灯片布局
- 内容布局
- 占位符
- 演示文稿设计
- 幻灯片设计
- 未使用的布局
- 页脚可见性
- 标题幻灯片
- 标题和内容
- 章节标题
- 双内容
- 比较
- 仅标题
- 空白布局
- 带说明的内容
- 带说明的图片
- 标题和竖向文本
- 竖向标题和文本
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: 在 Aspose.Slides for Python（通过 Java）中应用、创建和修改幻灯片布局，添加占位符，删除未使用的布局，并控制页脚可见性。
---
## **概述**

幻灯片布局定义了占位符（如标题、文本、图片、图表和表格）的定位和格式。应用布局可为幻灯片提供一致的结构，同时允许每张幻灯片拥有各自的内容。

最常见的布局包括：

- **标题幻灯片**：包含标题和副标题占位符。  
- **标题和内容**：包含标题占位符和通用内容占位符。  
- **空白**：不包含任何内容占位符，适用于需要手动定位所有形状的情况。

## **了解布局继承**

一个演示文稿具有三个相关层级：

1. 一个[母版幻灯片](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/)定义主题、共享格式、背景和公共对象。  
1. 一个[布局幻灯片](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/)属于某个母版，定义特定的占位符排列。  
1. 一个[普通幻灯片](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/)使用一种布局，并存储该幻灯片输入的内容。

普通幻灯片从其布局继承主题和格式，布局又从其母版继承。直接在普通幻灯片上设置的值会覆盖该层级继承的值。创建普通幻灯片时，其占位符形状是根据所选布局生成的，而填入这些占位符的内容属于普通幻灯片。

在从布局创建幻灯片之前，请先向布局中添加所需的占位符。后来向布局再添加占位符不会自动在已有的普通幻灯片中创建对应的占位符形状。

此关系有两个重要影响：

- 更改布局上继承的格式或已有占位符的几何形状会更新所有依赖该布局的幻灯片。编辑已在使用的布局前，请检查其依赖的幻灯片并审阅生成的演示文稿。  
- 正在被幻灯片使用的布局不能被删除。请先将其依赖的幻灯片重新指派到其他布局，或仅删除未使用的布局。

有关此层级顶部的更多信息，请参阅[幻灯片母版](/slides/zh/python-java/slide-master/)。

若要在单个幻灯片或共享布局上隐藏继承的徽标或装饰性母版形状，请参阅[控制母版图形的可见性](/slides/zh/python-java/slide-master/)。示例比较了两张使用相同母版的幻灯片。

## **选择并应用幻灯片布局**

当演示文稿遵循标准 PowerPoint 布局定义时，请使用布局类型。布局名称可由用户编辑并本地化，因此除非您控制源模板，否则基于名称的选择可靠性较低。

下面的示例在第一个母版上查找**标题和内容**布局。如果该布局不可用，则有意回退到**空白**。第二个对`None`的检查是必要的，因为演示文稿可能只包含自定义布局。随后使用[Slide.setLayoutSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#setLayoutSlide)方法将选定的布局应用于第一张普通幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

更改幻灯片的布局不会删除直接添加到幻灯片的普通形状。但占位符位置、继承的格式以及现有占位符与新布局之间的对应关系可能会改变，因此在切换差异较大的布局时请检查输出。

## **添加布局幻灯片**

选择和创建是两个独立的操作。前面的示例仅选择了已有布局，并未创建新布局。要创建布局，请在目标母版的布局集合上调用[MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterlayoutslidecollection/#add)方法。

下面的示例始终添加一个名为`Report Title and Content`的新**标题和内容**布局，然后基于该布局添加一张普通幻灯片。布局名称在集合内必须唯一。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

仅在模板确实需要另一个可复用结构时才添加布局。如果已存在合适的布局，请选择并复用它，而不是创建重复布局。

## **向布局幻灯片添加占位符**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getPlaceholderManager)方法提供一个[LayoutPlaceholderManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/)用于向布局添加占位符形状。

| PowerPoint 占位符                | [LayoutPlaceholderManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/) 方法 |
| --------------------------------- | ------------------------------------------- |
| ![内容](content.png)              | [addContentPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![内容（竖向）](contentV.png)     | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![文本](text.png)                 | [addTextPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![文本（竖向）](textV.png)         | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![图片](picture.png)              | [addPicturePlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![图表](chart.png)                | [addChartPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![表格](table.png)                | [addTablePlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [addSmartArtPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![媒体](media.png)                | [addMediaPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![在线图片](onlineImage.png)      | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

下面的示例验证**空白**布局是否存在，向其添加四个占位符，然后创建使用该修改后布局的普通幻灯片。顺序是有意为之：先添加占位符，再创建普通幻灯片，这样 Aspose.Slides 能在该幻灯片上生成相应的占位符形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![布局幻灯片上的占位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
更改继承的格式或现有布局占位符的几何形状会影响依赖的幻灯片。新添加的布局占位符不会回填到已有的普通幻灯片中。请在演示文稿副本上测试布局更改，并检查每个依赖的幻灯片。
{{% /alert %}}

## **删除未使用的布局幻灯片**

使用[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#removeUnusedLayoutSlides)方法删除所有普通幻灯片未引用的布局。该方法会保留仍在使用的布局。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要删除特定布局，首先使用其[hasDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#hasDependingSlides)或[getDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getDependingSlides)方法。在调用[LayoutSlide.remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#remove)之前重新指派任何依赖的幻灯片。尝试删除正在使用的布局会抛出[PptxEditException](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxeditexception/)。

## **控制布局幻灯片的页脚可见性**

布局拥有自己的页脚、幻灯片编号和日期时间占位符。使用[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getHeaderFooterManager)方法可为单个布局控制这些占位符。这在例如内容布局需要显示页脚而标题布局不需要时非常有用。

下面的示例安全地选择一个布局并使其页脚元素可见：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制母版及其子布局的页脚可见性**

要在母版层级中统一页脚设置，请使用[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getHeaderFooterManager)方法。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslideheaderfootermanager/)的传播方法作用于母版及其依赖的布局幻灯片和普通幻灯片；它们不会仅针对单个普通幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题解答**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义演示文稿的主题和共享格式。布局幻灯片属于母版，用于定义一种可复用的占位符排列。普通幻灯片使用这些布局并存储特定于幻灯片的内容。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以。使用[addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/globallayoutslidecollection/#addClone)方法将副本添加到目标集合。跨演示文稿复制时，还需验证源布局使用的字体、主题、图片及其他资源。

**当我修改已在使用的布局时会发生什么？**

依赖的幻灯片会继承布局的更改，除非它们在本地覆盖了受影响的格式或对象。占位符的几何形状和继承的样式可能会一次性在多张幻灯片上改变。编辑布局前，可使用[getDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getDependingSlides)确定受影响的幻灯片。

**如果我删除仍在使用的布局会怎样？**

Aspose.Slides 会抛出[PptxEditException](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxeditexception/)。请先重新指派依赖的幻灯片，或使用[removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#removeUnusedLayoutSlides)只删除未被引用的布局。