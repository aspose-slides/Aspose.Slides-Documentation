---
title: 上标和下标
type: docs
weight: 80
url: /zh/python-net/superscript-and-subscript/
keywords: "上标, 下标, 添加上标文本, 添加下标文本, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中向 PowerPoint 演示文稿添加上标和下标文本"
---

## **管理上标和下标文本**
您可以在任何段落部分内添加上标和下标文本。要在 Aspose.Slides 文本框中添加上标或下标文本，必须使用 **Escapement** 属性的 PortionFormat 类。

该属性返回或设置上标或下标文本（值范围从 -100%（下标）到 100%（上标）。例如：

- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 向幻灯片添加一个矩形类型的 IAutoShape。
- 访问与 IAutoShape 关联的 ITextFrame。
- 清除现有段落
- 创建一个新的段落对象以保存上标文本，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的部分对象
- 设置部分的 Escapement 属性在 0 到 100 之间以添加上标。（0 表示没有上标）
- 为部分设置一些文本，然后将其添加到段落的部分集合中。
- 创建一个新的段落对象以保存下标文本，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的部分对象
- 设置部分的 Escapement 属性在 0 到 -100 之间以添加下标。（0 表示没有下标）
- 为部分设置一些文本，然后将其添加到段落的部分集合中。
- 将演示文稿保存为 PPTX 文件。

上述步骤的实现如下所示。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # 获取幻灯片
    slide = presentation.slides[0]

    # 创建文本框
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    textFrame = shape.text_frame
    textFrame.paragraphs.clear()

    # 为上标文本创建段落
    superPar = slides.Paragraph()

    # 创建常规文本的部分
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superPar.portions.add(portion1)

    # 创建上标文本的部分
    superPortion = slides.Portion()
    superPortion.portion_format.escapement = 30
    superPortion.text = "TM"
    superPar.portions.add(superPortion)

    # 为下标文本创建段落
    paragraph2 = slides.Paragraph()

    # 创建常规文本的部分
    portion2 = slides.Portion()
    portion2.text = "a"
    paragraph2.portions.add(portion2)

    # 创建下标文本的部分
    subPortion = slides.Portion()
    subPortion.portion_format.escapement = -25
    subPortion.text = "i"
    paragraph2.portions.add(subPortion)

    # 将段落添加到文本框
    textFrame.paragraphs.add(superPar)
    textFrame.paragraphs.add(paragraph2)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```