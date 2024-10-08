---
title: 演示主题
type: docs
weight: 10
url: /zh/python-net/presentation-theme/
keywords: "主题, PowerPoint 主题, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python 中的 PowerPoint 演示文稿主题"
---

演示主题定义了设计元素的属性。当您选择一个演示主题时，实际上是在选择一组特定的视觉元素及其属性。

在 PowerPoint 中，一个主题包括颜色、[字体](/slides/zh/python-net/powerpoint-fonts/)、[背景样式](/slides/zh/python-net/presentation-background/)和效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题使用一组特定的颜色来应用于幻灯片上的不同元素。如果您不喜欢这些颜色，可以通过应用新的主题颜色来更改它们。为了让您选择新的主题颜色，Aspose.Slides 提供了 [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 枚举中的值。

以下 Python 代码显示了如何更改主题的强调色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

您可以通过以下方式确定结果颜色的有效值：

```python
fillEffective = shape.fill_format.get_effective()
print("{0} ({1})".format(fillEffective.solid_fill_color.name, fillEffective.solid_fill_color)) # ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

为了进一步演示颜色更改操作，我们创建另一个元素并将强调色（来自初始操作）分配给它。然后我们在主题中更改颜色：

```python
otherShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
otherShape.fill_format.fill_type = slides.FillType.SOLID
otherShape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

pres.master_theme.color_scheme.accent4.color = draw.Color.red
```

新颜色会自动应用于两个元素。

### **从附加调色板设置主题颜色**

当您对主主题颜色(1)应用亮度变换时，将形成附加调色板(2)中的颜色。然后，您可以设置和获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1**- 主主题颜色

**2** - 附加调色板中的颜色。

以下 Python 代码演示了一种操作，其中从主主题颜色获取附加调色板颜色，然后在形状中使用：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 强调色 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # 强调色 4，亮度 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # 强调色 4，亮度 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # 强调色 4，亮度 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # 强调色 4，暗色 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # 强调色 4，暗色 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **更改主题字体**

为了让您选择主题和其他用途的字体，Aspose.Slides 使用这些特殊标识符（类似于 PowerPoint 中使用的）：

* **+mn-lt** - 正文字体拉丁文（次要拉丁字体）
* **+mj-lt** - 标题字体拉丁文（主要拉丁字体）
* **+mn-ea** - 正文字体东亚文（次要东亚字体）
* **+mj-ea** - 标题字体东亚文（主要东亚字体）

以下 Python 代码显示了如何将拉丁字体分配给主题元素：

```python
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)

paragraph = slides.Paragraph()
portion = slides.Portion("主题文本格式")
paragraph.portions.add(portion)
shape.text_frame.paragraphs.add(paragraph)
portion.portion_format.latin_font = slides.FontData("+mn-lt")
```

以下 Python 代码显示了如何更改演示主题字体：

```python
pres.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

所有文本框中的字体将会被更新。

{{% alert color="primary" title="提示" %}} 

您可能想查看 [PowerPoint 字体](/slides/zh/python-net/powerpoint-fonts/)。

{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用程序提供 12 种预定义背景，但在典型演示中仅保存其中的 3 种背景。

![todo:image_alt_text](presentation-design_8.png)

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 Python 代码来找出该演示文稿中预定义背景的数量：

```python
with slides.Presentation() as pres:
    numberOfBackgroundFills = len(pres.master_theme.format_scheme.background_fill_styles)
    print("主题背景填充样式的数量是 {0}".format(numberOfBackgroundFills))
```

{{% alert color="warning" %}} 

使用 [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) 类中的 `BackgroundFillStyles` 属性，您可以在 PowerPoint 主题中添加或访问背景样式。

{{% /alert %}}

以下 Python 代码显示了如何设置演示文稿的背景：

```python
pres.masters[0].background.style_index = 2
```

**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="提示" %}} 

您可能想查看 [PowerPoint 背景](/slides/zh/python-net/presentation-background/)。

{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常在每种样式数组中包含 3 个值。这些数组组合成 3 种效果：微妙、中等和强烈。例如，当效果应用于特定形状时的结果如下：

![todo:image_alt_text](presentation-design_10.png)

使用 [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) 类中的 3 个属性 (`FillStyles`, `LineStyles`, `EffectStyles`)，您可以更灵活地更改主题中的元素（甚至比 PowerPoint 中的选项更灵活）。

以下 Python 代码显示了如何通过更改元素的部分来更改主题效果：

```python
with slides.Presentation("combined_with_master.pptx") as pres:
    pres.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    pres.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    pres.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    pres.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", slides.export.SaveFormat.PPTX)
```

填充颜色、填充类型、阴影效果等的结果更改如下：

![todo:image_alt_text](presentation-design_11.png)