---
title: 管理文本框
type: docs
weight: 20
url: /zh/python-net/manage-textbox/
keywords: "文本框, 文本框架, 添加文本框, 带超链接的文本框, Python, Aspose.Slides for Python via .NET"
description: "在Python或.NET中将文本框或文本框架添加到PowerPoint演示文稿"
---

幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，您必须添加一个文本框，然后将一些文本放入文本框中。Aspose.Slides for Python via .NET提供了[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)接口，允许您添加包含一些文本的形状。

{{% alert title="信息" color="info" %}}

Aspose.Slides还提供了[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)接口，允许您向幻灯片添加形状。然而，通过`IShape`接口添加的所有形状都不能包含文本。但是通过[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)接口添加的形状可能包含文本。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

因此，在处理您希望添加文本的形状时，您可能希望检查并确认它是通过`IAutoShape`接口转换的。只有这样，您才能使用[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)属性，该属性属于`IAutoShape`。请参见此页面上的[更新文本](https://docs.aspose.com/slides/python-net/manage-textbox/#update-text)部分。

{{% /alert %}}

## **在幻灯片上创建文本框**

要在幻灯片上创建文本框，请按照以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
2. 获取新创建的演示文稿中第一张幻灯片的引用。
3. 在幻灯片的指定位置添加一个[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)对象，并将[ShapeType](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/)设置为`RECTANGLE`，并获取新添加的`IAutoShape`对象的引用。
4. 向`IAutoShape`对象添加一个`text_frame`属性，该属性将包含文本。在下面的示例中，我们添加了以下文本：*Aspose TextBox*
5. 最后，通过`Presentation`对象写入PPTX文件。

以下Python代码展示了如何向幻灯片添加文本：

```py
import aspose.slides as slides

# 实例化PresentationEx
with slides.Presentation() as pres:

    # 获取演示文稿中的第一张幻灯片
    sld = pres.slides[0]

    # 添加类型设置为矩形的AutoShape
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # 向矩形添加TextFrame
    ashp.add_text_frame(" ")

    # 访问文本框
    txtFrame = ashp.text_frame

    # 为文本框创建Paragraph对象
    para = txtFrame.paragraphs[0]

    # 为段落创建一个Portion对象
    portion = para.portions[0]

    # 设置文本
    portion.text = "Aspose TextBox"

    # 将演示文稿保存到磁盘
    pres.save("TextBox_out.pptx", slides.export.SaveFormat.PPTX)
```

## **检查文本框形状**

Aspose.Slides提供了`is_text_box`属性（来自[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)类），允许您检查形状并查找文本框。

![文本框和形状](istextbox.png)

以下Python代码演示了如何检查一个形状是否被创建为文本框：xxx

```python
from aspose.slides import Presentation, AutoShape

with Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if (type(shape) is AutoShape):
                print("形状是文本框" if shape.is_text_box else "形状不是文本框")
```

## **在文本框中添加列**

Aspose.Slides提供了[column_count](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)和[column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)属性（来自[ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)接口和[text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)类），允许您向文本框添加列。您可以指定文本框中的列数，并设置列之间的间距（以磅为单位）。

以下Python代码演示了所描述的操作：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	# 获取演示文稿中的第一张幻灯片
	slide = presentation.slides[0]

	# 添加类型设置为矩形的AutoShape
	aShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# 向矩形添加TextFrame
	aShape.add_text_frame("所有这些列都被限制在一个文本容器内 -- " +
	"您可以添加或删除文本，新的或剩余的文本会自动调整 " +
	"以流动在容器内。然而，您不能让文本从一个容器流到另一个容器 -- 我们告诉过您，PowerPoint的文本列选项是有限的！")

	# 获取TextFrame的文本格式
	format = aShape.text_frame.text_frame_format

	# 指定TextFrame中的列数
	format.column_count = 3

	# 指定列之间的间距
	format.column_spacing = 10

	# 保存演示文稿
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **在文本框架中添加列**
Aspose.Slides for Python via .NET提供了[ColumnCount](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)属性（来自[ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)接口），允许您在文本框架中添加列。通过该属性，您可以指定文本框架中您所需的列数。

以下Python代码展示了如何在文本框架中添加列：

```py
import aspose.slides as slides

outPptxFileName = "ColumnsTest.pptx"
with slides.Presentation() as pres:
    shape1 = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)
    format = shape1.text_frame.text_frame_format

    format.column_count = 2
    shape1.text_frame.text = """所有这些列被迫保持在一个文本容器内 -- 
        您可以添加或删除文本 - 并且新的或剩余的文本会自动调整 
        自身以保持在容器内。然而，您不能让文本溢出一个容器 
        到另一个容器，因为PowerPoint的文本列选项是有限的！"""
    
    pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_spacing = 20
    pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_count = 3
    format.column_spacing = 15
    pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)
```

## **更新文本**

Aspose.Slides允许您更改或更新文本框中包含的文本或演示文稿中包含的所有文本。

以下Python代码演示了一种操作，其中演示文稿中的所有文本被更新或更改：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # 保存修改后的演示文稿
    pres.save("text-changed.pptx", slides.export.SaveFormat.PPTX)
```

## **添加带超链接的文本框** 

您可以在文本框中插入链接。当点击文本框时，用户将被引导打开该链接。

要添加一个包含链接的文本框，请按照以下步骤操作：

1. 创建`Presentation`类的实例。
2. 获取新创建的演示文稿中第一张幻灯片的引用。
3. 在幻灯片的指定位置添加一个`AutoShape`对象，`ShapeType`设置为`RECTANGLE`，并获取新添加的AutoShape对象的引用。
4. 向`AutoShape`对象添加一个包含*Aspose TextBox*作为其默认文本的`text_frame`。
5. 实例化`hyperlink_manager`类。
6. 将`hyperlink_manager`对象分配给您的`TextFrame`中首选部分的[HyperlinkClick](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)属性。
7. 最后，通过`Presentation`对象写入PPTX文件。

以下Python代码展示了如何向幻灯片添加带超链接的文本框：

```py
import aspose.slides as slides

# 实例化表示PPTX的Presentation类
with slides.Presentation() as pptxPresentation:
    # 获取演示文稿中的第一张幻灯片
    slide = pptxPresentation.slides[0]

    # 添加类型设置为矩形的AutoShape对象
    pptxShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    # 访问与AutoShape相关的ITextFrame属性
    pptxShape.add_text_frame("")

    textFrame = pptxShape.text_frame

    # 为框架添加一些文本
    textFrame.paragraphs[0].portions[0].text = "Aspose.Slides"

    # 设置部分文本的超链接
    hm = textFrame.paragraphs[0].portions[0].portion_format.hyperlink_manager
    hm.set_external_hyperlink_click("http://www.aspose.com")
    # 保存PPTX演示文稿
    pptxPresentation.save("hLinkPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```