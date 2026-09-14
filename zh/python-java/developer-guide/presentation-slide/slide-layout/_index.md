---
title: 在 Python via Java 中应用或更改幻灯片布局
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
- 节标题
- 双内容
- 比较
- 仅标题
- 空白布局
- 带字幕的内容
- 带字幕的图片
- 标题和垂直文本
- 垂直标题和文本
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中应用、创建和修改幻灯片布局，添加占位符，移除未使用的布局，并控制页脚可见性。"
---
## **概述**

幻灯片布局定义了标题、文本、图片、图表和表格等占位符的位置和格式。应用布局可为幻灯片提供一致的结构，同时允许每张幻灯片包含自己的内容。

最常用的布局包括：

- **标题幻灯片**：包含标题和副标题占位符。
- **标题和内容**：包含标题占位符和通用内容占位符。
- **空白**：不包含任何内容占位符，适用于需要手动定位每个形状的情况。

## **了解布局继承**

演示文稿有三个相关层级：

1. A [master slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/) 定义主题、共享格式、背景和公共对象。
2. A [layout slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/) 属于母版，定义特定的占位符排列。
3. A [normal slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 使用一个布局，并存储该幻灯片输入的内容。

普通幻灯片从其布局继承主题和格式，布局则从其母版继承。直接在普通幻灯片上设置的值会覆盖该层级继承的值。创建普通幻灯片时，其占位符形状会根据所选布局生成，而填入这些占位符的内容属于普通幻灯片。

在从布局创建幻灯片之前，请先向布局添加所需的占位符。随后向布局添加新的占位符不会自动为已存在的普通幻灯片添加对应的占位符形状。

此关系有两个重要的后果：

- 更改布局上继承的格式或已有占位符的几何形状会更新所有依赖该布局的幻灯片。编辑已在使用的布局前，请检查其依赖幻灯片并审阅生成的演示文稿。
- 仍被幻灯片使用的布局无法被删除。请先将其依赖的幻灯片重新分配到其他布局，或仅删除未使用的布局。

有关此层级顶部的更多信息，请参阅 [Slide Master](/slides/zh/python-java/slide-master/)。

## **选择并应用幻灯片布局**

当演示文稿遵循标准 PowerPoint 布局定义时使用布局类型。布局名称可编辑且可本地化，除非您控制源模板，否则基于名称的选择可靠性较低。

以下示例在第一个母版上查找 **标题和内容**。如果该布局不可用，则刻意回退到 **空白**。第二次检查 `None` 是必要的，因为演示文稿可能只包含自定义布局。随后通过 [Slide.setLayoutSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#setLayoutSlide) 方法将所选布局应用到第一个普通幻灯片。

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

更改幻灯片的布局不会删除直接添加到幻灯片的普通形状。然而，占位符位置、继承的格式以及已有占位符与新布局之间的对应关系可能会改变，因此在切换差异较大的布局时请检查输出。

## **添加布局幻灯片**

选择和创建是分开的操作。前面的示例仅选择了已有布局，并未创建新布局。要创建布局，请在目标母版的布局集合上调用 [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterlayoutslidecollection/#add) 方法。

以下示例始终添加一个名为 `Report Title and Content` 的新 **标题和内容** 布局，然后基于该布局添加普通幻灯片。布局名称在集合内必须唯一。

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

仅当模板确实需要另一个可重用结构时才添加布局。如果已有合适的布局，请选择并复用它，而不是创建重复的布局。

## **向布局幻灯片添加占位符**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getPlaceholderManager) 方法提供一个 [LayoutPlaceholderManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/) 用于向布局添加占位符形状。

| PowerPoint 占位符 | LayoutPlaceholderManager 方法 |
| ------------------- | ---------------------------- |
| ![Content](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

以下示例验证 **空白** 布局是否存在，向其添加四个占位符，然后创建使用该修改后布局的普通幻灯片。顺序有意为之：先添加占位符，再创建普通幻灯片，以便 Aspose.Slides 能在该幻灯片上生成对应的占位符形状。

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
更改布局上继承的格式或已有占位符的几何形状会影响依赖的幻灯片。新添加的布局占位符不会回填到已有的普通幻灯片中。请在演示文稿的副本上测试布局更改，并检查每个依赖幻灯片。
{{% /alert %}}

## **删除未使用的布局幻灯片**

使用 [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) 方法删除没有普通幻灯片引用的布局。该方法会保留仍在使用的布局。

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

若要删除特定布局，先使用其 [hasDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#hasDependingSlides) 或 [getDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getDependingSlides) 方法。调用 [LayoutSlide.remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#remove) 前请重新分配所有依赖的幻灯片。尝试删除正在使用的布局会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxeditexception/)。

## **控制布局幻灯片的页脚可见性**

布局拥有自己的页脚、幻灯片编号和日期时间占位符。使用 [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) 方法可为单个布局控制这些占位符。这在例如内容布局需要显示页脚而标题布局不需要时非常有用。

以下示例安全地选择布局并使其页脚元素可见：

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

要在母版层级中统一页脚设置，请使用 [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getHeaderFooterManager) 方法。 [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslideheaderfootermanager/) 的传播方法作用于母版及其依赖的布局幻灯片和普通幻灯片；它们不会仅针对单个普通幻灯片。

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

## **常见问题**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义演示文稿的主题和共享格式。布局幻灯片属于母版，定义一组可复用的占位符排列。普通幻灯片使用这些布局并保存特定于幻灯片的内容。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以。使用 [addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/globallayoutslidecollection/#addClone) 方法将副本添加到目标集合。跨文稿复制时，还需核实源布局使用的字体、主题、图像等资源。

**修改已在使用的布局会发生什么？**

依赖的幻灯片会继承布局的更改，除非它们在本地覆盖了受影响的格式或对象。占位符的几何形状和继承的样式可能会一次性在多张幻灯片上变化。编辑布局前，可使用 [getDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getDependingSlides) 确认受影响的幻灯片。

**如果删除仍在使用的布局会怎样？**

Aspose.Slides 会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxeditexception/)。请先重新分配依赖的幻灯片，或使用 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) 删除仅未被引用的布局。