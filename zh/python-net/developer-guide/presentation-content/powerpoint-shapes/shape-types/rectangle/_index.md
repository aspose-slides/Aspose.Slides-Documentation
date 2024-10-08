---
title: 矩形
type: docs
weight: 80
url: /zh/python-net/rectangle/
keywords: "创建矩形, PowerPoint形状, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中创建PowerPoint演示文稿的矩形"
---


## **创建简单矩形**
与之前的主题一样，这个主题也关于添加形状，这次我们讨论的形状是矩形。在本主题中，我们描述了开发人员如何使用Aspose.Slides for Python via .NET向幻灯片添加简单或格式化的矩形。要向演示文稿的选定幻灯片添加简单矩形，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 使用 IShapes 对象暴露的 AddAutoShape 方法添加一个矩形类型的 IAutoShape。
1. 将修改后的演示文稿写入PPTX文件。

在下面给出的示例中，我们向演示文稿的第一张幻灯片添加了一个简单的矩形。

```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自定义形状
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 将 PPTX 文件写入磁盘
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **创建格式化矩形**
要向幻灯片添加格式化的矩形，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 使用 IShapes 对象暴露的 AddAutoShape 方法添加一个矩形类型的 IAutoShape。
1. 将矩形的填充类型设置为实心。
1. 使用与 IShape 对象关联的 FillFormat 对象暴露的 SolidFillColor.Color 属性设置矩形的颜色。
1. 设置矩形线条的颜色。
1. 设置矩形线条的宽度。
1. 将修改后的演示文稿写入PPTX文件。
   上述步骤在下面给出的示例中实现。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自定义形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 对矩形形状应用一些格式设置
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 对矩形的线条应用一些格式设置
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # 将 PPTX 文件写入磁盘
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```