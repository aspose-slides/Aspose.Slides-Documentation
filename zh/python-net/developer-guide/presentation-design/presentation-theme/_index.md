---
title: 用 Python 管理 PowerPoint 演示主题
linktitle: 演示主题
type: docs
weight: 10
url: /zh/python-net/presentation-theme/
keywords:
- PowerPoint 主题
- 演示主题
- 幻灯片主题
- 设置主题
- 更改主题
- 管理主题
- 主题颜色
- 附加调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- OpenDocument
- 演示
- Python
- Aspose.Slides
description: "通过 .NET 在 Aspose.Slides for Python 中掌握演示主题，以创建、定制和转换具有一致品牌标识的 PowerPoint 文件。"
---
## **简介**

演示主题定义了一套协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存为固定值，因此更改主题时可以一次性更新许多对象。

在 Aspose.Slides 中，演示级别的主题可通过 [Presentation.master_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/master_theme/) 属性获取。演示还可以在更低级别包含主题覆盖。母版可以通过 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/masterthememanager/override_theme/) 覆盖演示主题，版式可以通过 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) 覆盖其继承的主题，单个幻灯片也可以如此。实际中，幻灯片的有效主题通过以下继承链解析：演示主题 → 母版覆盖 → 版式覆盖 → 幻灯片覆盖。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

下面的章节展示了最常见的主题工作流：检查主题、更改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/mastertheme/) 对象公开主题的 [color_scheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/mastertheme/font_scheme/) 和 [format_scheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/mastertheme/format_scheme/) 属性。在更改之前检查这些集合尤其有用，因为来自外部来源的演示文件的样式条目数量和内容可能各不相同。

下面的示例读取主要主题属性，并报告主题中存储的背景、填充、线条和效果样式数量：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

如果文件使用多个母版，请不要假设每张幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在可能存在版式或幻灯片覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文字可以引用 [SchemeColor](https://reference.aspose.com/slides/zh/python-net/aspose.slides/schemecolor/) 枚举中的逻辑颜色。当你更改主题的 [ColorScheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/colorscheme/) 中对应的条目时，所有仍引用该主题颜色的对象都会使用新值解析。直接使用 RGB 颜色的对象不会因主题颜色更新而改变。

下面的端到端示例创建一个使用 `ACCENT4` 的形状，将主题的 `accent4` 颜色更改为红色，保存演示，重新打开，并打印有效的填充颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

因为矩形仍链接到 `ACCENT4`，主题更改后其可见颜色会变成红色。如果你在形状上将方案颜色替换为直接颜色，则以后对 `accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换来产生更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/colortransformoperation/) 枚举公开这些变换。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主要主题颜色。

**2** - 基于主要主题颜色生成的更亮和更暗变体。

下面的示例基于 `ACCENT4` 创建六个矩形，对其中五个应用亮度变换，并保存结果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

这些变体仍基于主题颜色。如果随后 `accent4` 发生变化，转换后的颜色会根据新的 `accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh/python-net/aspose.slides/schemecolor/) 枚举使用 `TEXT1`、`BACKGROUND1`、`TEXT2` 和 `BACKGROUND2`，而 [ColorScheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/colorscheme/) 将相同的主题插槽公开为 `dark1`、`light1`、`dark2` 和 `light2`。映射是固定的：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

这些是同一主题插槽的别名；它们不是从一种形式动态转换到另一种形式的值。

## **更改主题字体**

主题字体方案包含标题的主要字体集合和正文的次要字体集合。[FontScheme.major](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/fontscheme/major/) 和 [FontScheme.minor](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/fontscheme/minor/) 属性公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体拉丁文（Minor Latin Font）
* `+mj-lt` - 标题字体拉丁文（Major Latin Font）
* `+mn-ea` - 正文字体东亚文（Minor East Asian Font）
* `+mj-ea` - 标题字体东亚文（Major East Asian Font）

下面的示例创建一个使用主要拉丁主题字体的标题和一个使用次要拉丁主题字体的正文行，然后更改主题字体并保存结果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

标题遵循主要字体，正文遵循次要字体。使用显式字体名称而不是主题标识符的文本在主题字体方案更改时不会自动切换。

主要和次要字体集合还可以包含针对特定书写系统（如西里尔文、阿拉伯文、日文、格鲁吉亚文和 Thaana）的字体映射。要检查、添加、替换或删除这些映射，请参阅 [Script-Specific Theme Fonts](/slides/zh/python-net/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}

有关演示字体的更多信息，请参阅 [PowerPoint Fonts](/slides/zh/python-net/powerpoint-fonts/)。

{{% /alert %}}

## **复制或应用主题**

常见的两种工作流解决不同的问题。

### **在移动幻灯片时保留源主题**

如果要将幻灯片移动到另一个演示并保留其原始设计，请使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslidecollection/add_clone/) 将源母版克隆到目标演示，然后使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/add_clone/) 将幻灯片与克隆的母版一起克隆。这会把母版、其版式和关联的主题一起携带。

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

当源幻灯片必须在目标中保持相同外观时，这是一种首选工作流。仅将内容克隆到不相关的目标母版上可能会更改受主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持其当前母版和版式，请从源主题初始化幻灯片级别的覆盖。使用 [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) 和 [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) 方法将三个主要主题组件复制到覆盖中。

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

这会在不更改其他幻灯片继承主题的情况下更改该幻灯片使用的主题。要移除本地覆盖并返回继承值，请调用 [OverrideTheme.clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/overridetheme/clear/)。

### **将主题覆盖应用于版式**

版式级别的覆盖适用于使用该版式的幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可以通过版式的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/layoutslidethememanager/) 使用：

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

当多个版式和幻灯片应共享相同基础设计时，请使用母版或演示级别的主题；当某一版式族需要不同样式时使用版式覆盖；仅在真正的例外情况下使用幻灯片覆盖。过多的幻灯片级别覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) 中。PowerPoint 在 UI 中提供的背景选项比此集合实际存储的填充定义更多，因为 UI 可以将主题填充与主题颜色和其他样式引用组合使用。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

在使用背景样式之前，检查存储的集合以及当前的 [Background.style_index](https://reference.aspose.com/slides/zh/python-net/aspose.slides/background/style_index/) 。`style_index` 为 `0` 表示无主题填充；正数值表示主题背景样式引用。这不同于直接对 Python 集合进行索引，其中 `[0]` 表示第一项。不要假设每个演示包含相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题化的背景引用分配给第一个母版，并保存演示：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

可见结果取决于母版引用的主题条目以及版式或幻灯片级别的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要了解继承后最终背景时，请使用 [Background.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/background/get_effective/)。

{{% alert color="warning" title="警告" %}}

不要将 `style_index` 当作零基集合索引。也不要硬编码来自某个文件的样式编号并假设在另一个文件中具有相同外观；主题样式定义是针对特定演示的。

{{% /alert %}}

{{% alert color="info" title="提示" %}}

有关直接背景格式化和背景继承，请参阅 [Presentation Background](/slides/zh/python-net/presentation-background/)。

{{% /alert %}}

## **更新主题效果**

主题格式方案包含独立的 [FormatScheme.fill_styles](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/formatscheme/line_styles/) 和 [FormatScheme.effect_styles](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/formatscheme/effect_styles/) 集合。典型的 Office 主题通常包含三条主要样式条目，对应于微妙、适度和强烈的格式，但代码应检查每个集合，而不是假设固定的计数。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 Python 中访问这些集合时，集合索引是从零开始的：`[0]` 是第一项，`[2]` 是第三项。形状的样式引用索引是另一个概念，由 [IShapeStyle](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ishapestyle/) 暴露。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外部阴影，并保存结果：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

对于引用这些槽位的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 点的外部阴影。确切的视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式化覆盖主题。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **读取有效主题值**

原始主题对象告诉你在特定层级上定义了什么。有效值告诉你幻灯片或形状在继承和本地覆盖解析后实际使用的内容。对于幻灯片，调用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。对于背景，使用 [Background.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/background/get_effective/)，对于填充，使用 [FillFormat.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fillformat/get_effective/)。

下面的示例读取幻灯片的有效主题、背景和第一形状的填充：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

使用有效数据进行渲染诊断、验证和比较。如果仅检查 [Presentation.master_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/master_theme/)，可能会错过改变最终外观的母版、版式、幻灯片或形状覆盖。

## **常见问题**

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。使用幻灯片的 [SlideThemeManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/slidethememanager/) 并初始化其覆盖主题。更改仅限于该幻灯片；其他幻灯片继续继承其现有主题。

**将主题从一个演示迁移到另一个演示的最安全方式是什么？**

在移动幻灯片并保留其源外观时，使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslidecollection/add_clone/) 将源母版克隆到目标，然后使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/add_clone/) 将幻灯片与该母版一起克隆。这会将母版、版式和主题一起保留下来。

**我如何查看继承和覆盖后的有效值？**

对于幻灯片或版式主题，使用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)；对于格式对象，如 [Background.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/background/get_effective/) 和 [FillFormat.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fillformat/get_effective/)，使用相应的有效数据方法。这些 API 在应用继承和覆盖后返回解析后的值。