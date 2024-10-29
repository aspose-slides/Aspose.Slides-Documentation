---
title: 椭圆
type: docs
weight: 30
url: /zh/python-net/ellipse/
keywords: "椭圆，PowerPoint形状，PowerPoint演示文稿，Python，Aspose.Slides for Python via .NET"
description: "在Python中创建PowerPoint演示文稿中的椭圆"
---


## **创建椭圆**
在本主题中，我们将介绍开发人员如何使用Aspose.Slides for Python via .NET将椭圆形状添加到他们的幻灯片中。Aspose.Slides for Python via .NET提供了一组更简单的API，只需几行代码即可绘制不同种类的形状。要将简单的椭圆添加到演示文稿的选定幻灯片中，请遵循以下步骤：

1. 创建一个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例
1. 通过使用其索引获取幻灯片的引用
1. 使用IShapes对象公开的AddAutoShape方法添加椭圆类型的AutoShape
1. 将修改后的演示文稿写入PPTX文件

在下面的示例中，我们已将椭圆添加到第一张幻灯片。

```py
import aspose.slides as slides

# 实例化表示PPTX的Presentation类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加椭圆类型的自定义图形
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 将PPTX文件写入磁盘
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **创建格式化的椭圆**
要向幻灯片添加更好格式化的椭圆，请遵循以下步骤：

1. 创建一个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 使用IShapes对象公开的AddAutoShape方法添加椭圆类型的AutoShape。
1. 将椭圆的填充类型设置为实心。
1. 使用与IShape对象关联的FillFormat对象公开的SolidFillColor.Color属性设置椭圆的颜色。
1. 设置椭圆线条的颜色。
1. 设置椭圆线条的宽度。
1. 将修改后的演示文稿写入PPTX文件。

在下面的示例中，我们已将格式化的椭圆添加到演示文稿的第一张幻灯片。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示PPTX的Presentation类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加椭圆类型的自定义图形
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 对椭圆形状应用一些格式设置
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 对椭圆的线条应用一些格式设置
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # 将PPTX文件写入磁盘
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```