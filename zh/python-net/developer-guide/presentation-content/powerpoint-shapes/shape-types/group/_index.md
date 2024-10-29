---
title: 组
type: docs
weight: 40
url: /zh/python-net/group/
keywords: "组形状, PowerPoint形状, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中向PowerPoint演示文稿添加组形状"
---

## **添加组形状**
Aspose.Slides支持在幻灯片上使用组形状。此功能帮助开发人员支持更丰富的演示文稿。Aspose.Slides for Python via .NET支持添加或访问组形状。可以向添加的组形状中添加形状以填充它，或访问组形状的任何属性。使用Aspose.Slides for Python via .NET向幻灯片添加组形状的方法如下：

1. 创建[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 向幻灯片添加组形状。
1. 向添加的组形状中添加形状。
1. 将修改后的演示文稿保存为PPTX文件。

下面的示例向幻灯片添加了一个组形状。

```py
import aspose.slides as slides

# 实例化Presentation类 
with slides.Presentation() as pres:
    # 获取第一张幻灯片 
    sld = pres.slides[0]

    # 访问幻灯片的形状集合 
    slideShapes = sld.shapes

    # 向幻灯片添加组形状 
    groupShape = slideShapes.add_group_shape()

    # 在添加的组形状中添加形状 
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # 添加组形状框架 
    groupShape.frame = slides.ShapeFrame(100, 300, 500, 40, -1, -1, 0)

    # 将PPTX文件写入磁盘 
    pres.save("GroupShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **访问AltText属性**
本主题展示了简单步骤，包含代码示例，用于添加组形状并访问幻灯片上组形状的AltText属性。使用Aspose.Slides for Python via .NET访问幻灯片中组形状的AltText的方法如下：

1. 实例化代表PPTX文件的`Presentation`类。
1. 通过使用其索引获取幻灯片的引用。
1. 访问幻灯片的形状集合。
1. 访问组形状。
1. 访问AltText属性。

下面的示例访问了组形状的替代文本。

```py
import aspose.slides as slides

# 实例化代表PPTX文件的Presentation类
with slides.Presentation(path + "AltText.pptx") as pres:

    # 获取第一张幻灯片
    sld = pres.slides[0]

    for i in range(len(sld.shapes)):
        # 访问幻灯片的形状集合
        shape = sld.shapes[i]

        if type(shape) is slides.GroupShape:
            # 访问组形状。
            for j in range(len(shape.shapes)):
                # 访问AltText属性
                print(shape.shapes[j].alternative_text)
```