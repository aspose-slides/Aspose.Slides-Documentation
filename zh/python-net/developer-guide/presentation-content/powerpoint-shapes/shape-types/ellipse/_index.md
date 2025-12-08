---
title: 添加椭圆到 Python 演示文稿
linktitle: 椭圆
type: docs
weight: 30
url: /zh/python-net/ellipse/
keywords:
- 椭圆
- 形状
- 添加椭圆
- 创建椭圆
- 绘制椭圆
- 格式化椭圆
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "学习如何在 Aspose.Slides for Python via .NET 中创建、格式化和操作椭圆形状，适用于 PPT、PPTX 和 ODP 演示文稿——包含代码示例。"
---

## **创建椭圆**
在本主题中，我们将向开发人员介绍如何使用 Aspose.Slides for Python via .NET 在幻灯片中添加椭圆形状。Aspose.Slides for Python via .NET 提供了一套更简便的 API，只需几行代码即可绘制各种形状。要向演示文稿的选定幻灯片添加一个简单的椭圆，请按照以下步骤操作：

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例  
1. 使用索引获取幻灯片的引用  
1. 通过 IShapes 对象的 AddAutoShape 方法添加 Ellipse 类型的 AutoShape  
1. 将修改后的演示文稿写入 PPTX 文件  

在下面的示例中，我们在第一张幻灯片上添加了一个椭圆。
```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加椭圆类型的自动形状
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 将 PPTX 文件写入磁盘
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **创建格式化椭圆**
要在幻灯片上添加格式更好的椭圆，请按照以下步骤操作：

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 通过 IShapes 对象的 AddAutoShape 方法添加 Ellipse 类型的 AutoShape。  
1. 将椭圆的填充类型设置为 Solid。  
1. 使用 FillFormat 对象关联的 IShape 对象的 SolidFillColor.Color 属性设置椭圆的颜色。  
1. 设置椭圆线条的颜色。  
1. 设置椭圆线条的宽度。  
1. 将修改后的演示文稿写入 PPTX 文件。  

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一个格式化的椭圆。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加椭圆类型的自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 为椭圆形状应用一些格式
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 为椭圆的线条应用一些格式
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # 将 PPTX 文件写入磁盘
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**如何根据幻灯片的单位设置椭圆的精确位置和大小？**

坐标和尺寸通常以 **点** 为单位指定。为获得可预测的结果，请基于幻灯片大小进行计算，并在赋值前将所需的毫米或英寸转换为点。

**如何将椭圆置于其他对象之上或之下（控制堆叠顺序）？**

通过将对象置前或置后调整绘制顺序。这样可以让椭圆覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调的动画效果？**

[Apply](/slides/zh/python-net/shape-animation/) 入口、强调或退出效果到该形状，并配置触发器和时间，以安排动画的播放方式和时机。