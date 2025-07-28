---
title: 使用 Python 管理演示文稿中的形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/python-net/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 删除形状
- 隐藏形状
- 更改形状顺序
- 获取互操作形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转换为 SVG
- 对齐形状
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "学习使用 Aspose.Slides for Python 创建、编辑和优化形状，并生成高性能的 PowerPoint 和 OpenDocument 演示文稿。"
---

## **在幻灯片中查找形状**
本主题将描述一种简单的技术，使开发人员能够更容易地查找幻灯片上的特定形状，而不使用其内部 ID。重要的是要知道 PowerPoint 演示文稿文件没有任何识别幻灯片形状的方法，除了一个内部唯一 ID。对于开发人员来说，使用内部唯一 ID 查找形状似乎很困难。所有添加到幻灯片上的形状都有一些替代文本。我们建议开发人员使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为您计划将来修改的对象定义替代文本。

在设置任何所需形状的替代文本后，您可以使用 Aspose.Slides for Python via .NET 打开该演示文稿，并遍历添加到幻灯片的所有形状。在每次迭代中，您可以检查形状的替代文本，具有匹配替代文本的形状将是您所需的形状。为了更好地演示这种技术，我们创建了一种方法，[FindShape](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)，可以找到幻灯片中的特定形状并简单返回该形状。

```py
import aspose.slides as slides

# 使用其替代文本查找幻灯片中的形状的方法实现
def find_shape(slide, alttext):
    for i in range(len(slide.shapes)):
        if slide.shapes[i].alternative_text == alttext:
            return slide.shapes[i]
    return None
    
# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation(path + "FindingShapeInSlide.pptx") as p:
    slide = p.slides[0]
    # 要查找的形状的替代文本
    shape = find_shape(slide, "Shape1")
    if shape != None:
        print("形状名称: " + shape.name)
```



## **克隆形状**
要使用 Aspose.Slides for Python via .NET 将形状克隆到幻灯片：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 访问源幻灯片形状集合。
1. 向演示文稿添加新幻灯片。
1. 从源幻灯片形状集合克隆形状到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下示例将组合形状添加到幻灯片。

```py
import aspose.slides as slides

# 实例化 Presentation 类
with slides.Presentation(path + "Source Frame.pptx") as srcPres:
	sourceShapes = srcPres.slides[0].shapes
	blankLayout = srcPres.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
	destSlide = srcPres.slides.add_empty_slide(blankLayout)
	destShapes = destSlide.shapes
	destShapes.add_clone(sourceShapes[1], 50, 150 + sourceShapes[0].height)
	destShapes.add_clone(sourceShapes[2])                 
	destShapes.insert_clone(0, sourceShapes[0], 50, 150)

	# 将 PPTX 文件写入磁盘
	srcPres.save("CloneShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **移除形状**
Aspose.Slides for Python via .NET 允许开发人员移除任何形状。要从任何幻灯片中移除形状，请按照以下步骤操作：

1. 创建一个 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定替代文本的形状。
1. 移除该形状。
1. 将文件保存到磁盘。

```py
import aspose.slides as slides

# 创建演示文稿对象
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自动形状
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "用户定义"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[0]
        if ashp.alternative_text == alttext:
            sld.shapes.remove(ashp)

    # 将演示文稿保存到磁盘
    pres.save("RemoveShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **隐藏形状**
Aspose.Slides for Python via .NET 允许开发人员隐藏任何形状。要从任何幻灯片中隐藏形状，请按照以下步骤操作：

1. 创建一个 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定替代文本的形状。
1. 隐藏该形状。
1. 将文件保存到磁盘。

```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自动形状
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "用户定义"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[i]
        if ashp.alternative_text == alttext:
            ashp.hidden = True

    # 将演示文稿保存到磁盘
    pres.save("Hiding_Shapes_out.pptx", slides.export.SaveFormat.PPTX)
```



## **改变形状顺序**
Aspose.Slides for Python via .NET 允许开发人员重新排序形状。重新排序形状指定哪个形状在前或哪个形状在后。要从任何幻灯片重新排序形状，请按照以下步骤操作：

1. 创建一个 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 添加另一个具有相同坐标的形状。
1. 重新排序形状。
1. 将文件保存到磁盘。

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation1:
    slide = presentation1.slides[0]
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 365, 400, 150)
    shp3.fill_format.fill_type = slides.FillType.NO_FILL
    shp3.add_text_frame(" ")

    txtFrame = shp3.text_frame
    para = txtFrame.paragraphs[0]
    portion = para.portions[0]
    portion.text="水印文本 水印文本 水印文本"
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 200, 365, 400, 150)
    slide.shapes.reorder(2, shp3)
    presentation1.save("Reshape_out.pptx", slides.export.SaveFormat.PPTX)
```


## **获取互操作形状 ID**
Aspose.Slides for Python via .NET 允许开发人员获取在幻灯片范围内的唯一形状标识符，而 UniqueId 属性允许获取在演示文稿范围内的唯一标识符。属性 OfficeInteropShapeId 已分别添加到 IShape 接口和 Shape 类。OfficeInteropShapeId 属性返回的值对应于 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id 值。下面给出了一个示例代码。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation.pptx") as presentation:
    # 获取幻灯片范围内的唯一形状标识符
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```



## **设置形状的替代文本**
Aspose.Slides for Python via .NET 允许开发人员设置任何形状的 AlternateText。 
演示文稿中的形状可以通过 AlternativeText 或 Shape Name 属性进行区分。 
AlternativeText 属性可以使用 Aspose.Slides 以及 Microsoft PowerPoint 进行读取或设置。 
使用此属性，您可以标记形状并执行不同的操作，比如移除形状、 
隐藏形状或在幻灯片上重新排序形状。
要设置形状的替代文本，请按照以下步骤操作：

1. 创建一个 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 添加任何形状到幻灯片。
1. 对新添加的形状进行一些操作。
1. 遍历形状以查找一个形状。
1. 设置替代文本。
1. 将文件保存到磁盘。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自动形状
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.gray

    for i in range(len(sld.shapes)):
        shape = sld.shapes[i]
        if shape != None:
            shape.alternative_text = "用户定义"

    # 将演示文稿保存到磁盘
    pres.save("Set_AlternativeText_out.pptx", slides.export.SaveFormat.PPTX)
```




## **访问形状的布局格式**
Aspose.Slides for Python via .NET 提供了一个简单的 API 来访问形状的布局格式。本文演示了如何访问布局格式。

下面给出示例代码。

```py
import aspose.slides as slides

with slides.Presentation("Set_AlternativeText_out.pptx") as pres:
    for layoutSlide in pres.layout_slides:
        fillFormats = list(map(lambda shape: shape.fill_format, layoutSlide.shapes))
        lineFormats = list(map(lambda shape: shape.line_format, layoutSlide.shapes))
```

## **将形状渲染为 SVG**
现在 Aspose.Slides for Python via .NET 支持将形状渲染为 SVG。 WriteAsSvg 方法（及其重载）已添加到 Shape 类和 IShape 接口。 该方法允许将形状的内容保存为 SVG 文件。 下面的代码片段显示了如何将幻灯片的形状导出为 SVG 文件。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with open("SingleShape.svg", "wb") as stream:
        pres.slides[0].shapes[0].write_as_svg(stream)
```

## 对齐形状

通过 [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) 重载方法，您可以 

* 相对于幻灯片的边距对齐形状。 请参见示例 1。 
* 相对于彼此对齐形状。 请参见示例 2。 

[ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) 枚举定义了可用的对齐选项。

### 示例 1

该 Python 代码向您展示如何将索引为 1、2 和 4 的形状沿幻灯片顶部边界对齐：
下面的源代码将索引为 1、2 和 4 的形状沿幻灯片的顶部边界对齐。

```py
import aspose.slides as slides

with slides.Presentation("OutputPresentation.pptx") as pres:
     slide = pres.slides[0]
     shape1 = slide.shapes[1]
     shape2 = slide.shapes[2]
     shape3 = slide.shapes[4]
     slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, pres.slides[0], [
            slide.shapes.index_of(shape1),
            slide.shapes.index_of(shape2),
            slide.shapes.index_of(shape3)])
```

### 示例 2

该 Python 代码向您展示如何相对于集合中的底部形状对齐整个形状集合：

```py
import aspose.slides as slides

with slides.Presentation("example.pptx") as pres:
    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_BOTTOM, False, pres.slides[0].shapes)
```