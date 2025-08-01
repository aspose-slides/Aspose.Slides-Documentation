---
title: 在演示文稿中使用 Python 调整形状大小
linktitle: 调整形状大小
type: docs
weight: 130
url: /zh/python-net/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 轻松调整 PowerPoint 和 OpenDocument 幻灯片中的形状大小——自动化幻灯片布局调整并提升工作效率。"
---

## **调整幻灯片上的形状大小**
Aspose.Slides for Python via .NET 客户最常问的一个问题是如何调整形状的大小，以便在幻灯片大小更改时数据不会被切断。这个简短的技术提示展示了如何实现这一点。

为了避免形状错位，幻灯片上的每个形状都需要根据新的幻灯片大小进行更新。

```py
import aspose.slides as slides

#加载演示文稿
with slides.Presentation("pres.pptx") as presentation:
    #旧幻灯片大小
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #更改幻灯片大小
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #新幻灯片大小
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #调整位置
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #如有必要，调整形状大小 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

    presentation.save("Resize-1.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

如果幻灯片中有任何表格，则上述代码将无法完美工作。在这种情况下，需要调整表格的每个单元格大小。

{{% /alert %}} 

如果需要调整包含表格的幻灯片大小，请在您的代码中使用以下代码。设置表格的宽度或高度是形状中的特殊情况，您需要更改每一行的高度和每一列的宽度，以更改表格的高度和宽度。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    #旧幻灯片大小
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #更改幻灯片大小
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #新幻灯片大小
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width


    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for master in presentation.masters:
        for shape in master.shapes:
            #调整位置
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #如有必要，调整形状大小 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

        for layoutslide in master.layout_slides:
            for shape in layoutslide.shapes:
                #调整位置
                shape.height = shape.height * ratioHeight
                shape.width = shape.width * ratioWidth

                #如有必要，调整形状大小 
                shape.y = shape.y * ratioHeight
                shape.x = shape.x * ratioWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #调整位置
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #如有必要，调整形状大小 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth
            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * ratioHeight
                for col in shape.columns:
                    col.width = col.width * ratioWidth

    presentation.save("Resize-2.pptx", slides.export.SaveFormat.PPTX)
```