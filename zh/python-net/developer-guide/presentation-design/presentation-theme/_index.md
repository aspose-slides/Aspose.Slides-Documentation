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
- 外部主题
- THMX
- 主题颜色
- 附加调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中掌握演示文稿主题，以创建、定制和转换具有一致品牌的 PowerPoint 文件。"
---
## **简介**

演示主题定义了一组协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题可以一次性更新多个对象。

在 Aspose.Slides 中，演示级别的主题可通过 [Presentation.master_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/master_theme/) 属性访问。演示还可以在更低级别包含主题覆盖。母版可以通过 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/masterthememanager/override_theme/) 覆盖演示主题，版式可以通过 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) 覆盖其继承的主题，单个幻灯片也可以如此。实际上，幻灯片的有效主题是通过以下继承链解析的：演示主题 → 母版覆盖 → 版式覆盖 → 幻灯片覆盖。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下章节展示最常见的主题工作流：检查主题、更改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/mastertheme/) 对象公开主题的 [color_scheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/mastertheme/font_scheme/) 和 [format_scheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/mastertheme/format_scheme/) 属性。在更改它们之前检查这些集合特别有用，因为来自外部来源的演示文件的样式条目数量和内容可能不同。

以下示例读取主要主题属性并报告主题中存储了多少背景、填充、线条和效果样式：

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

如果文件使用多个母版，请勿假设每张幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在可能存在版式或幻灯片覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文本可以引用 [SchemeColor](https://reference.aspose.com/slides/zh/python-net/aspose.slides/schemecolor/) 枚举中的逻辑颜色。当您更改主题的 [ColorScheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/colorscheme/) 中相应的条目时，所有仍引用该主题颜色的对象都会解析为新值。使用直接 RGB 颜色的对象不会受到主题颜色更新的影响。

下面的端到端示例创建一个使用 `ACCENT4` 的形状，将主题的 `accent4` 颜色改为红色，保存演示，重新打开并打印有效填充颜色：

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

因为矩形仍链接到 `ACCENT4`，在主题更改后其可见颜色会变为红色。如果您在形状上用直接颜色替换了方案颜色，之后对 `accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换来生成更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/colortransformoperation/) 枚举公开这些变换。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主题主颜色。

**2** - 从主题主颜色生成的更亮和更暗变体。

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

这些变体仍基于主题颜色。如果稍后 `accent4` 发生变化，变换后的颜色会根据新的 `accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh/python-net/aspose.slides/schemecolor/) 枚举使用 `TEXT1`、`BACKGROUND1`、`TEXT2`、`BACKGROUND2`，而 [ColorScheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/colorscheme/) 将相同的主题插槽暴露为 `dark1`、`light1`、`dark2`、`light2`。映射是固定的：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

这些是同一主题插槽的别名；它们不是从一种形式动态转换得到的值。

## **更改主题字体**

主题字体方案包含用于标题的主字体集合和用于正文的次字体集合。[FontScheme.major](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/fontscheme/major/) 和 [FontScheme.minor](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/fontscheme/minor/) 属性公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体 Latin（次 Latin 字体）
* `+mj-lt` - 标题字体 Latin（主 Latin 字体）
* `+mn-ea` - 正文字体 East Asian（次 East Asian 字体）
* `+mj-ea` - 标题字体 East Asian（主 East Asian 字体）

下面的示例创建一个使用主 Latin 主题字体的标题和一个使用次 Latin 主题字体的正文行，然后更改主题字体并保存结果：

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

标题遵循主字体，正文文本遵循次字体。使用显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

主字体和次字体集合还可以包含针对特定书写系统（如西里尔文、阿拉伯文、日文、格鲁吉亚文和塔那文）的字体映射。要检查、添加、替换或删除这些映射，请参阅 [Script-Specific Theme Fonts](/slides/zh/python-net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
有关演示字体的更多信息，请参阅 [PowerPoint Fonts](/slides/zh/python-net/powerpoint-fonts/)。
{{% /alert %}}

## **复制或应用主题**

以下工作流解决不同的主题相关问题。

### **将外部主题应用于依赖于特定母版的幻灯片**

当您拥有 PowerPoint 主题文件（`.thmx`）并希望重新样式化所有依赖于特定母版的幻灯片时，请使用 [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/)。从 [Presentation.masters](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/masters/) 集合中选择母版（该集合实现了 [MasterSlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslidecollection/)），并将主题文件路径传给该方法。

该方法执行以下操作：

1. 基于选定的母版创建一个新母版幻灯片。  
1. 将外部主题应用到新母版。  
1. 将新母版分配给先前依赖于选定母版的所有幻灯片。  
1. 返回新创建的 [IMasterSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasterslide/)。

下面的示例将外部主题应用于依赖于第一个母版的幻灯片并保存演示：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

无效、损坏或不受支持的主题可能导致 [PptxException](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pptxexception/) 或其格式相关子类。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后保存演示。

仅重新分配依赖于所选母版的幻灯片。与其他母版关联的幻灯片保留其现有母版和主题。支持主题的颜色、字体、填充、线条、背景和效果会依据外部主题解析。直接分配的颜色、字体、填充和其他显式格式可能保持不变。版式级和幻灯片级的覆盖也可能优先于从新母版继承的值。

主题可能引用运行时环境中不存在的字体。为确保一致的渲染和导出，请安装所需字体、通过 [custom font sources](/slides/zh/python-net/custom-font/) 提供，或配置 [font substitution](/slides/zh/python-net/font-substitution/)。

这是一种直接的母版级工作流：该方法接受 `.thmx` 文件路径，无需手动创建幻灯片级或版式级主题覆盖。

### **在多母版演示中应用不同的外部主题**

当事先不知道相关母版时，可通过 [Slide.layout_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/layout_slide/) 和 [LayoutSlide.master_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/master_slide/) 从代表性幻灯片获取。在应用任何主题之前保存原始母版引用，因为每次调用都会在演示中创建另一个母版。

下面的示例使用两个章节的幻灯片定位其母版，并为每组应用不同的外部主题：

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

第一次调用仅影响依赖于 `first_group_master` 的幻灯片，第二次调用仅影响依赖于 `second_group_master` 的幻灯片。属于其他母版的幻灯片不会被重新样式化。

### **移动幻灯片时保留源主题**

如果希望将幻灯片移动到另一个演示并保留其原始设计，请使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslidecollection/add_clone/) 将源母版克隆到目标演示，然后使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/add_clone/) 将幻灯片连同克隆的母版一起克隆。这样可将母版、其版式以及关联的主题一起搬迁。

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

当源幻灯片必须在目标中保持相同外观时，这是首选工作流。仅将内容克隆到不相关的目标母版可能会改变基于主题的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持当前母版和版式，可从源主题初始化幻灯片级覆盖。[OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) 和 [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) 方法将三个主要主题组件复制到覆盖中。

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

此操作更改该幻灯片使用的主题，而不会影响其他幻灯片继承的主题。若要删除本地覆盖并恢复继承值，请调用 [OverrideTheme.clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/overridetheme/clear/)。

### **将主题覆盖应用于版式**

版式级覆盖适用于使用该版式的所有幻灯片，除非某个幻灯片拥有自己的覆盖。相同的初始化方法可通过版式的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/layoutslidethememanager/) 使用：

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

当许多版式和幻灯片应共享相同基础设计时使用母版或演示级主题；当某一版式族需要不同样式时使用版式覆盖；仅在真正的例外情况下使用幻灯片覆盖。过多的幻灯片级覆盖会使后续全局主题更改的预测变得困难。

## **更新主题背景样式**

主题的背景填充存储在 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) 中。PowerPoint 在 UI 中可以展示的背景选项往往多于此集合实际存储的填充定义，因为 UI 能将主题填充与主题颜色及其他样式引用组合使用。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

在使用背景样式之前，请检查存储的集合以及当前的 [Background.style_index](https://reference.aspose.com/slides/zh/python-net/aspose.slides/background/style_index/)。`style_index` 为 `0` 表示无主题填充；正值表示主题背景样式引用。这与直接对 Python 集合作索引不同，后者的 `[0]` 代表第一个存储项。不要假设每个演示都有相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题背景引用分配给第一个母版，并保存演示：

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

可见结果取决于母版引用的主题条目以及版式或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要获取继承后最终背景时，请使用 [Background.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/background/get_effective/)。

{{% alert color="warning" title="Warning" %}}
不要将 `style_index` 当作零基集合索引。也避免硬编码某个文件的样式编号并假设在另一个文件中表现相同；主题样式定义是针对特定演示的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅 [Presentation Background](/slides/zh/python-net/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含独立的 [FormatScheme.fill_styles](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/formatscheme/line_styles/) 和 [FormatScheme.effect_styles](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/formatscheme/effect_styles/) 集合。典型的 Office 主题通常包含三条主要样式条目，分别对应细腻、适中和强烈的视觉效果，但代码应检查每个集合，而不是假设固定数量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 Python 中访问这些集合时，集合索引为零基：`[0]` 为第一条存储的样式，`[2]` 为第三条。形状的样式引用索引是另一概念，透过 [IShapeStyle](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ishapestyle/) 暴露。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式、第三条填充样式，并在第三条效果样式中启用外部阴影，随后保存结果：

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

对于引用这些插槽的形状，第一条主题线条样式变为红色，第三条主题填充样式变为实心森林绿，第三条效果样式获得外部阴影，距离为 10 磅。具体视觉结果仍取决于每个形状引用的样式槽以及是否有直接格式覆盖主题。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **读取有效主题值**

原始主题对象只能告诉您在特定层级上定义了什么。有效值则告诉您在继承和本地覆盖解析后，幻灯片或形状实际使用的内容。对于幻灯片，请调用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。对于背景，使用 [Background.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/background/get_effective/)，对于填充，使用 [FillFormat.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fillformat/get_effective/)。

下面的示例读取幻灯片的有效主题、背景以及第一形状的填充：

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

使用有效数据进行渲染诊断、验证和比较。如果仅检查 [Presentation.master_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/master_theme/)，可能会错过母版、版式、幻灯片或形状的覆盖，从而导致最终外观不同。

## **常见问题**

**将外部主题应用于演示会影响每张幻灯片吗？**

不会。 [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) 只重新分配依赖于所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**我可以仅对单张幻灯片应用主题而不更改母版吗？**

可以。使用该幻灯片的 [SlideThemeManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/slidethememanager/) 并初始化其覆盖主题。更改仅局限于该幻灯片，其他幻灯片继续继承其现有主题。

**将主题从一个演示搬到另一个演示的最安全方式是什么？**

在迁移幻灯片并保留其源外观时，使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslidecollection/add_clone/) 将源母版克隆到目标演示，然后使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/add_clone/) 将幻灯片连同该母版一起克隆。这可保持母版、版式和主题一起迁移。

**如何查看继承和覆盖后的有效值？**

对幻灯片或版式主题使用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)，对格式对象（如背景和填充）使用相应的有效数据方法，如 [Background.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/background/get_effective/) 和 [FillFormat.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fillformat/get_effective/)。这些 API 在继承和覆盖应用后返回解析后的值。