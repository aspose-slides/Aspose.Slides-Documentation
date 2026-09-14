---
title: 在 Python via Java 中管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/python-java/presentation-header-and-footer/
keywords:
- 页眉
- 页眉文本
- 页脚
- 页脚文本
- 设置页眉
- 设置页脚
- 讲义
- 备注
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 管理幻灯片、备注页和讲义上的页脚、日期/时间、幻灯片编号和页眉占位符。"
---
## **概述**

PowerPoint 根据页面类型使用不同的页眉和页脚占位符。Aspose.Slides for Python via Java 允许您通过页眉/页脚管理器类控制这些占位符的文本和可见性。

可用占位符取决于作用域：

| 作用域 | 页眉 | 页脚 | 日期/时间 | 幻灯片/页码 |
|---|---|---|---|---|
| 常规幻灯片 | 否 | 是 | 是 | 是 |
| 备注母版 | 是 | 是 | 是 | 是 |
| 备注幻灯片 | 是 | 是 | 是 | 是 |
| 讲义母版 | 是 | 是 | 是 | 是 |

常规演示幻灯片没有页眉占位符。页眉仅在备注页和讲义页上可用。对于常规幻灯片，请使用页脚、日期/时间和幻灯片编号占位符。

更改的作用域取决于所使用的管理器。[SlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideheaderfootermanager/) 类控制单个常规幻灯片。 [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notesslideheaderfootermanager/) 类控制单个备注幻灯片。母版和布局管理器还可以将设置传播到从属幻灯片，而 [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) 类控制讲义母版。

## **在常规幻灯片上设置页脚、日期/时间和幻灯片编号**

对于常规幻灯片，基本工作流是访问每张幻灯片的页眉/页脚管理器，设置页脚和日期/时间文本，启用所需占位符，然后保存演示文稿。幻灯片编号由演示文稿生成，您只需要控制其可见性。

使用 [setFooterText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) 和 [setDateTimeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) 设置文本，使用 [setFooterVisibility](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)、[setDateTimeVisibility](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) 和 [setSlideNumberVisibility](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) 显示相应占位符。

下面的端到端示例将相同的页脚、日期/时间文本和幻灯片编号可见性应用于所有常规幻灯片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果只需更新一张幻灯片，请通过 [getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides) 方法直接访问该幻灯片，而不是遍历整个集合。

## **在备注母版上设置页眉和页脚**

备注母版定义了备注页的通用格式和占位符行为。仅需更改备注母版本身时，请使用 [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/) 类。

下面的示例在备注母版上设置页眉、页脚和日期/时间文本，并使该母版上所有受支持的占位符可见：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

当演示文稿不包含备注母版时，`getMasterNotesSlide` 方法返回 `None`。

## **将备注母版设置应用于子备注幻灯片**

备注母版可以将页眉和页脚设置应用于自身以及所有从属备注幻灯片。当需要在整个备注层次结构中应用相同设置时，请使用 [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/) 的专用传播方法。

例如， [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) 和 [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) 会更新备注母版的页眉以及所有子页眉。页脚、日期/时间和幻灯片编号也有相应的方法。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

上述使用的传播方法包括 [setFooterAndChildFootersText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)、[setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)、[setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)、[setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) 与 [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility)。

## **在单个备注幻灯片上设置页眉和页脚**

备注幻灯片属于特定的常规幻灯片。仅需自定义该备注页时，请使用其 [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notesslideheaderfootermanager/) 类。

[addNotesSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notesslidemanager/#addNotesSlide) 方法返回当前幻灯片的备注幻灯片，如果不存在则创建一个。以下示例配置与第一张演示幻灯片关联的备注页：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果先从备注母版传播设置，然后再更改单个备注幻灯片，后面的每页设置可让您独立自定义该备注页。

## **在讲义母版上设置页眉和页脚**

讲义页使用讲义母版来放置页眉、页脚、日期/时间和页码占位符。与备注页不同，讲义设置通过讲义母版管理，而不是通过单独的讲义幻灯片。

使用 `getMasterHandoutSlide` 方法访问讲义母版。如果不存在，请调用 `setDefaultMasterHandoutSlide` 创建默认讲义母版。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **了解作用域和继承**

选择与您要更改的作用域匹配的页眉/页脚管理器：

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideheaderfootermanager/) 更改单个常规幻灯片的页脚、日期/时间和幻灯片编号设置。
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslideheaderfootermanager/) 控制布局幻灯片，并可将受支持的设置传播到从属幻灯片。
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslideheaderfootermanager/) 控制常规幻灯片母版，并可将受支持的设置传播到从属幻灯片。
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslideheaderfootermanager/) 控制备注母版，并可将设置传播到所有从属备注幻灯片。
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notesslideheaderfootermanager/) 更改单个备注幻灯片，并支持页眉占位符以及页脚、日期/时间和幻灯片编号。
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) 更改讲义母版，并支持所有四种占位符类型。

当相同设置应在整个层次结构中应用时，请使用母版或布局的传播功能。当需要为单页提供本地设置时，请使用单个幻灯片或备注幻灯片管理器。

## **常见问答**

**我可以在常规幻灯片上添加页眉吗？**

不能。PowerPoint 未为常规幻灯片定义页眉占位符。常规幻灯片请使用页脚、日期/时间和幻灯片编号占位符。页眉占位符仅在备注页和讲义页上可用。

**如果页脚、日期/时间或幻灯片编号占位符不可见怎么办？**

使用相应的页眉/页脚管理器检查其可见性并在需要时启用。例如， [isFooterVisible](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) 报告页脚占位符是否存在， [setFooterVisibility](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) 可更改其可见性。

**如何让幻灯片编号从除 1 之外的值开始？**

调用演示文稿的 [setFirstSlideNumber](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#setFirstSlideNumber) 方法。随后幻灯片编号占位符将使用更新后的编号序列。

**在导出为 PDF、图像或 HTML 时，页眉和页脚会怎样？**

可见的页眉和页脚元素会与演示文稿的其余内容一起在输出格式中渲染。其外观取决于导出的页面类型以及对应的占位符可见性设置。