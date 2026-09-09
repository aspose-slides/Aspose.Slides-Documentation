---
title: 使用 Python via Java 在演示文稿中管理文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/python-java/manage-textbox/
keywords:
- 文本框
- 文本框架
- 添加文本
- 更新文本
- 创建文本框
- 检查文本框
- 添加文本列
- 添加超链接
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 演示文稿中创建、识别、格式化和更新文本框。"
---
## **介绍**

在 Aspose.Slides for Python via Java 中，幻灯片文本存储在属于形状的文本框中。AutoShape 类代表最常见的承载文本的形状，并通过 AutoShape.getTextFrame 方法公开其文本。

{{% alert color="info" title="注意" %}}
每个自动形状都继承自 Shape，但并非所有形状都是自动形状或支持文本框。在处理现有演示文稿时，务必检查形状是否为 AutoShape 的实例后再访问其文本。
{{% /alert %}}

## **在幻灯片上创建文本框**

要创建文本框，需要向幻灯片添加自动形状，将文本写入其文本框，然后保存演示文稿。以下示例创建了一个矩形文本框：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

传递给 ShapeCollection.addAutoShape 的坐标和尺寸以点为单位。AutoShape.addTextFrame 使用提供的文本初始化文本框。

## **检查文本框形状**

使用 AutoShape.isTextBox 方法可确定自动形状是否被视为文本框。当演示文稿同时包含承载文本的自动形状和纯图形自动形状时，此方法很有用。

![文本框和形状](istextbox.png)

以下示例检查演示文稿中的每个自动形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

新添加的自动形状在包含非空文本之前不被视为文本框。可以通过 AutoShape.addTextFrame 或 TextFrame.setText 提供该文本。向文本框添加空字符串或分配空字符串会导致 AutoShape.isTextBox 返回 `False`：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

前两次调用打印 `True`；后两次调用打印 `False`。

## **查找拥有文本框的形状**

通用的文本处理代码可能只接收到一个 TextFrame，却不知道它属于哪个演示文稿对象。使用只读的 TextFrame.getParentShape 方法可返回其所属的 Shape。

对于由自动形状或其他承载文本的形状拥有的文本框，TextFrame.getParentShape 返回所有者，而 TextFrame.getParentCell 返回 `None`。访问之前请检查返回值。要同时识别形状和表格单元格所有者（包括与 SmartArt 节点关联的形状），请参阅 [搜索和替换文本](/slides/zh/python-java/search-and-replace-text/)。

## **向文本框添加列**

TextFrameFormat.setColumnCount 方法将文本框划分为多列，TextFrameFormat.setColumnSpacing 方法以点为单位设置列间距。这两个设置属于 TextFrameFormat，可通过现有文本框的文本框进行更改。文本在同一形状内部的列之间重新流动，不会延伸到其他形状。

以下示例创建了一个三列文本框，列间距为 10 点，保存演示文稿后读取保存的设置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **从单独列中提取文本**

使用 TextFrame.splitTextByColumns 可获取现有文本框中每个可视列分配的文本。该方法按列的阅读顺序返回每列的字符串。单列文本框返回仅含一个元素的数组，空列则返回空字符串。返回的字符串仅包含纯文本，不保留段落级别的格式。

这在以下场景中非常有用：

- 在保留列顺序的情况下提取文本。
- 索引或比较多列幻灯片的内容。
- 将每列导出到单独的文件、数据库字段或其他目标。
- 检查在使用 TextFrameFormat.setColumnCount、更改列间距 TextFrameFormat.setColumnSpacing、字体或文本框大小后，文本如何重新分配。

该方法报告当前 TextFrame 内部的文本分布，不会自动在不同形状或文本框之间流动。列的分布可能受可用字体和其他文本布局设置影响，因此在需要一致结果时请确保所需字体可用。

以下示例加载演示文稿，找到第一个具有多列文本框的自动形状，读取其列数配置，并将每列的文本写入单独的文件。未提供文本框的形状将被跳过。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **更新文本**

要在整个演示文稿中更新文本，遍历幻灯片和形状，筛选自动形状，然后编辑其文本段落。在段落层面工作可同时更改文本和字符格式。

以下示例将所有自动形状文本中出现的 `years` 替换为 `months`，并将受影响的段落设为粗体：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此遍历仅更新自动形状中的文本。表格、图表、SmartArt 或组合形状中的文本需要遍历这些对象各自的集合。

## **添加带超链接的文本框**

超链接可以分配给特定的文本段落，使只有该段落可点击。使用 HyperlinkManager.setExternalHyperlinkClick 将段落关联到外部 URL。

以下示例创建了带链接的文本并保存到演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**文本框与母版或布局幻灯片上的占位符有什么区别？**

占位符 (/slides/zh/python-java/manage-placeholder/) 可从母版幻灯片或布局幻灯片继承位置和格式。普通文本框是创建所在幻灯片上的独立形状，布局更改时不会获得占位符行为。

**如何在不更改图表、表格或 SmartArt 中文本的情况下替换文本？**

如“更新文本”示例所示，将遍历限制在 AutoShape 实例上。图表、表格和 SmartArt 在各自的对象模型中存储文本，循环不会修改它们。