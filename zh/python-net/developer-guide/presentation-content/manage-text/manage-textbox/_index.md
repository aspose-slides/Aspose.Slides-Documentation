---
title: 使用 Python 管理演示文稿中的文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/python-net/manage-textbox/
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建、识别、格式化和更新文本框。"
---
## **介绍**

在 Aspose.Slides for Python via .NET 中，幻灯片文本存储在属于形状的文本框中。[AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 类表示最常见的带文本形状，并通过 [AutoShape.text_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/text_frame/) 属性公开其文本。

{{% alert color="info" title="Note" %}}
每个自动形状都继承自 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/)，但并非所有形状都是自动形状或支持文本框。在处理现有演示文稿时，使用 `isinstance(shape, slides.AutoShape)` 在访问其文本之前检查形状类型。
{{% /alert %}}

## **在幻灯片上创建文本框**

要创建文本框，需要向幻灯片添加一个自动形状，在其文本框中添加文本，然后保存演示文稿。下面的示例创建了一个矩形文本框：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

[ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_auto_shape/) 接收的坐标和尺寸以点为单位。[AutoShape.add_text_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/add_text_frame/) 使用提供的文本初始化文本框。

## **检查是否为文本框形状**

使用 [AutoShape.is_text_box](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/is_text_box/) 属性来判断自动形状是否被视为文本框。当演示文稿同时包含带文本和纯图形的自动形状时，这很有用。

![文本框和形状](istextbox.png)

下面的示例检查演示文稿中的每个自动形状：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

新添加的自动形状在包含非空文本之前不会被视为文本框。可以通过 [AutoShape.add_text_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/add_text_frame/) 或 [TextFrame.text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/text/) 提供该文本。添加或赋予空字符串会使 [is_text_box](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/is_text_box/) 保持为 `False`：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

前两次调用打印 `True`；后两次打印 `False`。

## **查找拥有文本框的形状**

通用的文本处理代码可能会收到一个 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)，但不知道它所属的演示文稿对象。使用只读的 [TextFrame.parent_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/parent_shape/) 属性返回其拥有的 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/)。

对于由自动形状或其他带文本形状拥有的文本框，`parent_shape` 包含所有者，而 [TextFrame.parent_cell](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/parent_cell/) 为 `None`。在访问之前请检查返回值。要识别形状和表格单元格的所有者（包括与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/python-net/search-and-replace-text/)。

## **向文本框添加列**

[TextFrameFormat.column_count](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/column_count/) 属性将文本框划分为多列，而 [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/column_spacing/) 设置列间的间距（单位为点）。这两个设置均属于 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/)，可以通过现有文本框的文本框进行更改。文本在同一形状内的列之间重新流动；不会延续到其他形状。

下面的示例创建了一个包含三列、列间距为 10 点的文本框，保存演示文稿，并从输出文件中读取存储的设置：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **从单独列中提取文本**

使用 [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/split_text_by_columns/) 可以获取现有文本框中每个可视列分配的文本。该方法按列的阅读顺序为每列返回一个字符串。单列文本框返回仅包含一个元素的列表，空列则为一个空字符串。这些字符串仅包含纯文本；段落级的格式化不会被保留。

当您需要时，这很有用：

- 在保留列阅读顺序的同时提取文本。
- 对多列幻灯片的内容进行索引或比较。
- 将每列导出到单独的文件、数据库字段或其他目标。
- 检查在更改 [TextFrameFormat.column_count](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/column_count/)、[TextFrameFormat.column_spacing](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/column_spacing/)、字体或文本框大小后，文本是如何重新分配的。

该方法报告当前 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 内部分布的文本；不会在不同形状或文本框之间自动流动。列的分布可能受可用字体和其他文本布局设置的影响，因此在需要一致结果时，请确保所需字体可用。

下面的示例加载演示文稿，查找第一个带有文本框的多列自动形状，读取其配置的列数，并将每列的文本写入单独的文件。没有提供文本框的形状将被跳过。

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **更新文本**

要在整个演示文稿中更新文本，遍历幻灯片和形状，选择自动形状，然后编辑其文本段落。在段落级别工作可以同时更改文本和字符格式。

下面的示例将自动形状文本中出现的所有 `years` 替换为 `months`，并将受影响的段落设置为粗体：

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

此遍历仅更新自动形状中的文本。存储在表格、图表、SmartArt 或组合形状中的文本需要遍历这些对象各自的集合。

## **添加带超链接的文本框**

可以将超链接分配给特定的文本段落，这样只有该段文字会作为可点击的链接。使用 [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/zh/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) 将该段落与外部 URL 关联。

下面的示例创建带链接的文本并将其保存到演示文稿中：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**文本框和母版或版式幻灯片上的文本占位符有什么区别？**

[placeholder](/slides/zh/python-net/manage-placeholder/) 可以继承自 [master slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslide/) 或 [layout slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/) 的位置和格式。普通文本框是创建所在幻灯片上的独立形状，布局更改时不会获得占位符的行为。

**如何在不更改图表、表格或 SmartArt 中文本的情况下替换文本？**

如同 “更新文本” 示例所示，将遍历范围限制在 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 实例上。图表、表格和 SmartArt 在各自的对象模型中存储文本，因此该循环不会修改它们。