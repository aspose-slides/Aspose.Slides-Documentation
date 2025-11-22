---
title: 在 Python 中管理 PowerPoint 演示文稿主题
linktitle: 演示文稿主题
type: docs
weight: 10
url: /zh/python-net/presentation-theme/
keywords:
- PowerPoint 主题
- 演示文稿主题
- 幻灯片主题
- 设置主题
- 更改主题
- 管理主题
- 主题颜色
- 扩展调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "通过 .NET 在 Aspose.Slides for Python 中掌握演示文稿主题，以创建、定制和转换具有一致品牌形象的 PowerPoint 文件。"
---

## **概述**

演示文稿主题定义其设计元素的属性。选择主题时，即是选择一组协调的视觉元素及其属性。

在 PowerPoint 中，主题包含颜色、[字体](/slides/zh/python-net/powerpoint-fonts/)、[背景样式](/slides/zh/python-net/presentation-background/)、以及效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用一套特定的颜色。如果默认颜色不满意，可以通过应用新主题颜色来更改。Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 枚举中提供了可供选择的值，以便您选择新主题颜色。

下面的 Python 代码演示了如何更改主题的强调颜色：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```


您可以按以下方式确定生成颜色的实际值：
```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# 示例输出：
#
# ff8064a2 (Color [A=255, R=128, G=100, B=162])
```


为了进一步演示颜色更改，我们创建另一个元素，将其分配为初始步骤中的强调颜色，然后更新主题颜色。
```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```


新颜色会自动应用到两个元素上。

### **从扩展调色板设置主题颜色**

当您对主主题颜色（1）进行亮度变换时，会生成扩展调色板（2）中的颜色。随后可以设置并获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1** — 主主题颜色

**2** — 扩展调色板中的颜色

下面的 Python 代码演示了如何从主主题颜色派生扩展调色板颜色并在形状中使用它们：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 强调色 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # 强调色 4，亮度提高 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # 强调色 4，亮度提高 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # 强调色 4，亮度提高 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # 强调色 4，暗度提高 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # 强调色 4，暗度提高 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **更改主题字体**

为了让您能够为主题及其他用途选择字体，Aspose.Slides 使用以下特殊标识符（与 PowerPoint 中的相同）：

- **+mn-lt** — 正文字体 拉丁文（次要拉丁字体）
- **+mj-lt** — 标题字体 拉丁文（主要拉丁字体）
- **+mn-ea** — 正文字体 东亚文字（次要东亚字体）
- **+mj-ea** — 标题字体 东亚文字（主要东亚字体）

下面的 Python 代码演示了如何将拉丁字体分配给主题元素：
```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```


此 Python 示例展示了如何更改演示文稿的主题字体：
```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```


所有文本框都会更新为新字体。

{{% alert color="primary" title="TIP" %}}
欲了解更多信息，请参阅 [使用 Python 管理 PowerPoint 主字体](/slides/zh/python-net/powerpoint-fonts/)。
{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 提供 12 种预定义背景，但典型的演示文稿仅使用其中的 3 种。

![todo:image_alt_text](presentation-design_8.png)

例如，在 PowerPoint 中保存演示文稿后，您可以运行以下 Python 代码以确定其中包含了多少种预定义背景：
```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```


{{% alert color="warning" %}}
通过 [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) 类的 `background_fill_styles` 属性，您可以在 PowerPoint 主题中添加或访问背景样式。
{{% /alert %}}

以下 Python 示例展示了如何设置演示文稿的背景：
```python
presentation.masters[0].background.style_index = 2  # 0 表示无填充；索引从 1 开始。
```


{{% alert color="primary" title="TIP" %}}
欲了解更多信息，请参阅 [使用 Python 管理演示文稿背景](/slides/zh/python-net/presentation-background/)。
{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常在每个样式数组中包含三个值。这些数组组合为三种效果级别：细微、适中和强烈。例如，下面展示了将这些效果应用于特定形状后的结果：

![todo:image_alt_text](presentation-design_10.png)

通过 [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) 类的 `FillStyles`、`LineStyles` 和 `EffectStyles` 三个属性，您可以比在 PowerPoint 中更灵活地修改主题元素。

下面的 Python 代码演示了如何通过更改这些元素的部分属性来修改主题效果：
```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


结果更改包括填充颜色、填充类型、阴影效果以及其他属性的更新：

![todo:image_alt_text](presentation-design_11.png)

## **常见问题**

**我可以在不更改母版的情况下，仅对单张幻灯片应用主题吗？**

可以。Aspose.Slides 支持幻灯片级别的主题覆盖，您可以仅为该幻灯片应用本地主题，而保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/)）。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？**

使用 [克隆幻灯片](/slides/zh/python-net/clone-slides/) 并连同其母版一起复制到目标演示文稿。此方式会保留原始母版、布局以及关联的主题，从而确保外观保持一致。

**如何查看在所有继承和覆盖之后的“实际”值？**

使用 API 的 [“实际”视图](/slides/zh/python-net/shape-effective-properties/) 查看主题/颜色/字体/效果的实际值。这些视图返回在应用母版以及任何本地覆盖后解析得到的最终属性。