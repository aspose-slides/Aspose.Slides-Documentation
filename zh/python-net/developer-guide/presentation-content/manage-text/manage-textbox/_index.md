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
description: "Aspose.Slides for Python via .NET 让您能够轻松在 PowerPoint 和 OpenDocument 文件中创建、编辑和克隆文本框，从而提升演示文稿自动化水平。"
---

## **概览**

幻灯片上的文本通常位于文本框或形状中。因此，要向幻灯片添加文本，必须先添加一个文本框，然后将文本放入该文本框。Aspose.Slides for Python 提供了 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 类，允许您添加包含文本的形状。

{{% alert title="信息" color="info" %}}

Aspose.Slides 还提供了 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类。但并非所有形状都能容纳文本。

{{% /alert %}}

{{% alert title="注意" color="warning" %}}

因此，当处理想要添加文本的形状时，您可能需要检查并确认它是通过 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 类进行转换的。只有这样，您才能使用位于 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 下的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 属性。请参阅本页的 [更新文本](/slides/zh/python-net/manage-textbox/#update-text) 部分。

{{% /alert %}}

## **在幻灯片上创建文本框**

在幻灯片上创建文本框的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 获取第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个 `ShapeType.RECTANGLE` 的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 设置形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中的文本。  
5. 将演示文稿保存为 PPTX 文件。

下面的 Python 示例演示了上述步骤：

```py
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation() as presentation:

    # 获取演示文稿中的第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个类型为 RECTANGLE 的 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # 将演示文稿保存到磁盘。
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **检查形状是否为文本框**

Aspose.Slides 在 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 类上提供了 [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) 属性，可用于判断形状是否为文本框。

![Text box and shape](istextbox.png)

下面的 Python 示例展示了如何检查形状是否被创建为文本框：

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

请注意，如果使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 类添加 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)，则该形状的 `is_text_box` 属性返回 `False`。但在您添加文本（通过 `add_text_frame` 方法或设置 `text` 属性）后，`is_text_box` 将返回 `True`。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box 为 false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box 为 true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box 为 false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box 为 true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box 为 false
    shape3.add_text_frame("")
    # shape3.is_text_box 为 false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box 为 false
    shape4.text_frame.text = ""
    # shape4.is_text_box 为 false
```

## **向文本框添加列**

Aspose.Slides 在 [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类上提供了 [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) 和 [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) 属性，可用于向文本框添加列。您可以指定列数并设置列之间的间距（单位为磅）。

下面的 Python 代码演示了此操作：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# 获取演示文稿中的第一张幻灯片。
	slide = presentation.slides[0]

	# 添加一个类型为 RECTANGLE 的 AutoShape。
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# 向矩形添加 TextFrame。
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# 获取 TextFrame 的文本格式。
	format = shape.text_frame.text_frame_format

	# 指定 TextFrame 中的列数。
	format.column_count = 3

	# 指定列之间的间距。
	format.column_spacing = 10

	# 保存演示文稿。
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **更新文本**

Aspose.Slides 允许您在单个文本框或整个演示文稿中更新文本。

下面的 Python 示例演示了如何更新演示文稿中的所有文本：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # 保存修改后的演示文稿。
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **添加带超链接的文本框** 

您可以在文本框中插入链接。单击文本框时，链接会打开。

要添加包含超链接的文本框，请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。  
2. 获取第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个 `ShapeType.RECTANGLE` 的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 设置形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中的文本。  
5. 获取 [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/) 的引用。  
6. 使用 `hyperlink_manager` 属性设置外部点击超链接。  
7. 将演示文稿保存为 PPTX 文件。

下面的 Python 示例展示了如何向幻灯片添加带超链接的文本框：

```py
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation() as presentation:

    # 获取演示文稿中的第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个类型为 RECTANGLE 的 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # 向框中添加文本。
    text_portion.text = "Aspose.Slides"

    # 为文字片段设置超链接。
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**在使用母版幻灯片时，文本框与文本占位符有什么区别？**

[text placeholder](/slides/zh/python-net/manage-placeholder/) 会从 [master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 继承样式/位置，并且可以在 [layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) 上被覆盖，而普通文本框是特定幻灯片上的独立对象，切换布局时不会改变。

**如何在不影响图表、表格和 SmartArt 中文本的前提下，对整个演示文稿执行批量文本替换？**

将遍历范围限制在具有文本框的 auto‑shape 上，并通过单独遍历或跳过对象类型的方式排除嵌入对象（[charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/python-net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)）。