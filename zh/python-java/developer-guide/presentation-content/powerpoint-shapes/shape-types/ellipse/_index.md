---
title: 在 Python（通过 Java）中向演示文稿添加椭圆
linktitle: 椭圆
type: docs
weight: 30
url: /zh/python-java/ellipse/
keywords:
- 椭圆
- 形状
- 添加椭圆
- 创建椭圆
- 绘制椭圆
- 格式化椭圆
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中创建、格式化和操作椭圆形状，支持 PPT 和 PPTX 演示文稿——附带 Python 代码示例。"
---
## **概述**

本文展示了如何使用 Aspose.Slides 向 PowerPoint 幻灯片中添加椭圆形。内容包括创建普通椭圆、创建格式化椭圆，以及将更新后的演示文稿保存为 PPTX 文件。还涉及与椭圆位置和大小、控制堆叠顺序以及应用动画效果等相关的问题。

## **创建椭圆**

要向演示文稿的选定幻灯片中添加普通椭圆，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
- 通过索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/) 对象的 [addAutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addAutoShape) 方法添加椭圆。
- 将修改后的演示文稿写入为 PPTX 文件。

下面的示例将在第一张幻灯片上添加一个椭圆：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 实例化表示 PPTX 文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加椭圆形状。
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # 将 PPTX 文件写入磁盘。
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **创建格式化椭圆**

要在幻灯片中添加格式化椭圆，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
- 通过索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/) 对象的 [addAutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addAutoShape) 方法添加椭圆。
- 将椭圆的填充类型设置为实心。
- 通过关联的 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 对象上的 [FillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/) 对象，使用 [getSolidFillColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/#getSolidFillColor) 设置椭圆的填充颜色。
- 设置椭圆轮廓的颜色。
- 设置椭圆轮廓的宽度。
- 将修改后的演示文稿写入为 PPTX 文件。

下面的示例将在演示文稿的第一张幻灯片上添加一个格式化椭圆：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# 实例化表示 PPTX 文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加椭圆形状。
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # 格式化椭圆的填充。
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # 格式化椭圆的轮廓。
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # 将 PPTX 文件写入磁盘。
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**如何根据幻灯片单位设置椭圆的精确位置和大小？**

坐标和尺寸通常以 **点** 为单位指定。为获得可预期的结果，请以幻灯片尺寸为依据，在赋值前将所需的毫米或英寸转换为点。

**如何将椭圆放置在其他对象之上或之下（控制堆叠顺序）？**

通过将对象置于前面或发送到后面来调整绘图顺序。这可使椭圆覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调动画？**

[应用](/slides/zh/python-java/shape-animation/) 进入、强调或退出效果到形状，并配置触发器和时间安排，以决定动画何时以及如何播放。