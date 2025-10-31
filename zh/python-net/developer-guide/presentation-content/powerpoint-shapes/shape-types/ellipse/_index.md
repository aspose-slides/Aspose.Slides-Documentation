---
title: 在 Python 中向演示文稿添加椭圆
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
description: "了解如何在 Aspose.Slides for Python via .NET 中创建、格式化和操作椭圆形状，适用于 PPT、PPTX 和 ODP 演示文稿——附带代码示例。"
---

## **创建椭圆**
在本主题中，我们将向开发者介绍如何使用 Aspose.Slides for Python via .NET 向幻灯片添加椭圆形状。Aspose.Slides for Python via .NET 提供了一套更简便的 API，只需几行代码即可绘制各种形状。要在演示文稿的选定幻灯片上添加一个简单的椭圆，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
2. 使用索引获取幻灯片的引用
3. 使用 IShapes 对象提供的 AddAutoShape 方法添加椭圆类型的 AutoShape
4. 将修改后的演示文稿保存为 PPTX 文件

下面的示例在第一张幻灯片上添加了一个椭圆。

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
要在幻灯片上添加格式更佳的椭圆，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
2. 使用索引获取幻灯片的引用
3. 使用 IShapes 对象提供的 AddAutoShape 方法添加椭圆类型的 AutoShape
4. 将椭圆的填充类型设置为实心
5. 使用与 IShape 对象关联的 FillFormat 对象的 SolidFillColor.Color 属性设置椭圆的颜色
6. 设置椭圆线条的颜色
7. 设置椭圆线条的宽度
8. 将修改后的演示文稿保存为 PPTX 文件

下面的示例在演示文稿的第一张幻灯片上添加了一个格式化的椭圆。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加椭圆类型的自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 对椭圆形状应用一些格式设置
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 对椭圆的线条应用一些格式设置
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # 将 PPTX 文件写入磁盘
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**如何相对于幻灯片的单位设置椭圆的精确位置和尺寸？**

坐标和尺寸通常以 **点** 为单位指定。为获得可预期的结果，请基于幻灯片尺寸进行计算，并在赋值前将所需的毫米或英寸转换为点。

**如何将椭圆置于其他对象之上或之下（控制堆叠顺序）？**

通过将对象置于前面或发送到后面来调整绘图顺序。这使得椭圆可以覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调动画？**

[Apply](/slides/zh/python-net/shape-animation/) 入口、强调或退出效果到该形状，并配置触发器和时间安排，以决定动画的播放时机和方式。