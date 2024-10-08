---
title: 形状有效属性
type: docs
weight: 50
url: /python-net/shape-effective-properties/
keywords: "形状属性, 相机属性, 灯光设置, 斜角形状, 文本框, 文本样式, 字体高度值, 表格填充格式, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中获取PowerPoint演示文稿中的有效形状属性"
---

在本主题中，我们将讨论**有效**和**本地**属性。当我们在这些层级直接设置值时

1. 在部分属性上，位于部分的幻灯片上。
1. 在布局或母板幻灯片上的原型形状文本样式中（如果部分的文本框形状有一个）。
1. 在演示文稿的全局文本设置中。

那么这些值被称为**本地**值。在任何层级上，**本地**值都可以被定义或省略。但最终，当应用程序需要知道部分应该是什么样子时，它使用**有效**值。您可以通过使用**getEffective()**方法从本地格式中获取有效值。

以下示例展示了如何获取有效值。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    localTextFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = localTextFrameFormat.get_effective()

    localPortionFormat = shape.text_frame.paragraphs[0].portions[0].portion_format
    effectivePortionFormat = localPortionFormat.get_effective()
```



## **获取相机的有效属性**
Aspose.Slides for Python via .NET允许开发者获取相机的有效属性。为此，Aspose.Slides中增加了**CameraEffectiveData**类。CameraEffectiveData类表示一个不可变对象，包含有效的相机属性。**CameraEffectiveData**类的一个实例作为**ThreeDFormatEffectiveData**类的一部分使用，这是ThreeDFormat类的有效值对。

以下代码示例展示了如何获取相机的有效属性。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= 有效相机属性 =")
	print("类型: " + str(threeDEffectiveData.camera.camera_type))
	print("视野: " + str(threeDEffectiveData.camera.field_of_view_angle))
	print("缩放: " + str(threeDEffectiveData.camera.zoom))
```


## **获取灯光设置的有效属性**
Aspose.Slides for Python via .NET允许开发者获取灯光设置的有效属性。为此，Aspose.Slides中增加了**LightRigEffectiveData**类。LightRigEffectiveData类表示一个不可变对象，包含有效的灯光设置属性。**LightRigEffectiveData**类的一个实例作为**ThreeDFormatEffectiveData**类的一部分使用，这是ThreeDFormat类的有效值对。

以下代码示例展示了如何获取灯光设置的有效属性。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= 有效灯光设置属性 =")
	print("类型: " + str(threeDEffectiveData.light_rig.light_type))
	print("方向: " + str(threeDEffectiveData.light_rig.direction))
```


## **获取斜角形状的有效属性**
Aspose.Slides for Python via .NET允许开发者获取斜角形状的有效属性。为此，Aspose.Slides中增加了**ShapeBevelEffectiveData**类。ShapeBevelEffectiveData类表示一个不可变对象，包含有效形状的面浮雕属性。**ShapeBevelEffectiveData**类的一个实例作为**ThreeDFormatEffectiveData**类的一部分使用，这是ThreeDFormat类的有效值对。

以下代码示例展示了如何获取斜角形状的有效属性。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= 有效形状的顶部面浮雕属性 =")
	print("类型: " + str(threeDEffectiveData.bevel_top.bevel_type))
	print("宽度: " + str(threeDEffectiveData.bevel_top.width))
	print("高度: " + str(threeDEffectiveData.bevel_top.height))
```



## **获取文本框的有效属性**
使用Aspose.Slides for Python via .NET，您可以获取文本框的有效属性。为此，Aspose.Slides中增加了**TextFrameFormatEffectiveData**类，包含有效的文本框格式属性。

以下代码示例展示了如何获取有效的文本框格式属性。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	shape = pres.slides[0].shapes[0]

	textFrameFormat = shape.text_frame.text_frame_format
	effectiveTextFrameFormat = textFrameFormat.get_effective()


	print("锚定类型: " + str(effectiveTextFrameFormat.anchoring_type))
	print("自动适应类型: " + str(effectiveTextFrameFormat.autofit_type))
	print("文本垂直类型: " + str(effectiveTextFrameFormat.text_vertical_type))
	print("边距")
	print("   左: " + str(effectiveTextFrameFormat.margin_left))
	print("   上: " + str(effectiveTextFrameFormat.margin_top))
	print("   右: " + str(effectiveTextFrameFormat.margin_right))
	print("   下: " + str(effectiveTextFrameFormat.margin_bottom))
```



## **获取文本样式的有效属性**
使用Aspose.Slides for Python via .NET，您可以获取文本样式的有效属性。为此，Aspose.Slides中增加了**TextStyleEffectiveData**类，包含有效的文本样式属性。

以下代码示例展示了如何获取有效的文本样式属性。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    effectiveTextStyle = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effectiveTextStyle.get_level(i)
        print("= 风格级别 #" + str(i) + " 的有效段落格式 =")

        print("深度: " + str(effectiveStyleLevel.depth))
        print("缩进: " + str(effectiveStyleLevel.indent))
        print("对齐: " + str(effectiveStyleLevel.alignment))
        print("字体对齐: " + str(effectiveStyleLevel.font_alignment))

```


## **获取有效字体高度值**
使用Aspose.Slides for Python via .NET，您可以获取字体高度的有效属性。以下代码演示了在不同的演示文稿结构层级上设置本地字体高度值后，部分的有效字体高度值的变化。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    newShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    newShape.add_text_frame("")
    newShape.text_frame.paragraphs[0].portions.clear()

    portion0 = slides.Portion("第一部分的示例文本")
    portion1 = slides.Portion(" 和第二部分。")

    newShape.text_frame.paragraphs[0].portions.add(portion0)
    newShape.text_frame.paragraphs[0].portions.add(portion1)

    print("创建后有效字体高度:")
    print("部分 #0: " + str(portion0.portion_format.get_effective().font_height))
    print("部分 #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("设置整个演示文稿的默认字体高度后有效字体高度:")
    print("部分 #0: " + str(portion0.portion_format.get_effective().font_height))
    print("部分 #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 40

    print("设置段落默认字体高度后有效字体高度:")
    print("部分 #0: " + str(portion0.portion_format.get_effective().font_height))
    print("部分 #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 55

    print("设置部分 #0 字体高度后有效字体高度:")
    print("部分 #0: " + str(portion0.portion_format.get_effective().font_height))
    print("部分 #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[1].portion_format.font_height = 18

    print("设置部分 #1 字体高度后有效字体高度:")
    print("部分 #0: " + str(portion0.portion_format.get_effective().font_height))
    print("部分 #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **获取表格的有效填充格式**
使用Aspose.Slides for Python via .NET，您可以获取不同表格逻辑部分的有效填充格式。为此，Aspose.Slides中增加了**IFillFormatEffectiveData**接口，包含有效的填充格式属性。请注意，单元格格式总是优先于行格式，行格式优先于列格式，列格式优先于整个表格。

因此，**CellFormatEffectiveData**属性始终用于绘制表格。以下代码示例展示了如何获取不同表格逻辑部分的有效填充格式。

```py
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
	tbl = pres.slides[0].shapes[0]
	tableFormatEffective = tbl.table_format.get_effective()
	rowFormatEffective = tbl.rows[0].row_format.get_effective()
	columnFormatEffective = tbl.columns[0].column_format.get_effective()
	cellFormatEffective = tbl[0, 0].cell_format.get_effective()

	tableFillFormatEffective = tableFormatEffective.fill_format
	rowFillFormatEffective = rowFormatEffective.fill_format
	columnFillFormatEffective = columnFormatEffective.fill_format
	cellFillFormatEffective = cellFormatEffective.fill_format
```