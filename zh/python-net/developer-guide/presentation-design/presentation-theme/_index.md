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
description: "通过 .NET 的 Aspose.Slides for Python 掌握演示文稿主题，以创建、定制和转换具有一致品牌的 PowerPoint 文件。"
---
## **介绍**

演示文稿主题定义了一组协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题可以一次性更新许多对象。

在 Aspose.Slides 中，演示文稿级别的主题可通过 [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) 属性获取。演示文稿还可以在更低级别包含主题覆盖。母版可以通过 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/) 覆盖演示文稿主题，版式可以通过 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) 覆盖其继承的主题，单个幻灯片也可以如此操作。实际中，幻灯片的实际主题通过以下继承链解析：演示文稿主题 → 母版覆盖 → 版式覆盖 → 幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

下面的章节展示了最常见的主题工作流：检查主题、修改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取实际值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) 对象公开主题的 [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) 和 [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) 属性。在更改它们之前检查这些集合尤其有用，因为来自外部来源的演示文稿其样式条目数量和内容可能各不相同。

以下示例读取主要主题属性并报告主题中存储的背景、填充、线条和效果样式的数量：

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

如果文件使用了多个母版，请不要假设每个幻灯片都有相同的实际主题。检查与幻灯片关联的母版，并在可能存在版式或幻灯片覆盖时使用本文后续展示的实际主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文本可以引用 [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 枚举中的逻辑颜色。当您在主题的 [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) 中更改对应条目时，所有仍引用该主题颜色的对象都会使用新值解析。使用直接 RGB 颜色的对象不会受到主题颜色更新的影响。

以下端到端示例创建一个使用 `ACCENT4` 的形状，将主题的 `accent4` 颜色更改为红色，保存演示文稿，重新打开并打印实际填充颜色：

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

因为矩形仍链接到 `ACCENT4`，主题更改后其可见颜色变为红色。如果您在形状上用直接颜色替换了方案颜色，随后对 `accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换来生成更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) 枚举公开这些变换。

![主要主题颜色以及从附加调色板生成的更亮和更暗颜色](additional-palette-colors.png)

**1** - 主要主题颜色。

**2** - 基于主要主题颜色生成的更亮和更暗变体。

以下示例基于 `ACCENT4` 创建六个矩形，对其中五个应用亮度变换，并保存结果：

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

这些变体仍基于主题颜色。如果随后更改 `accent4`，变换后的颜色会根据新的 `accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 枚举使用 `TEXT1`、`BACKGROUND1`、`TEXT2` 和 `BACKGROUND2`，而 [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) 将相同的主题插槽公开为 `dark1`、`light1`、`dark2` 和 `light2`。映射是固定的：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

这些是同一主题插槽的别名；它们不是从一种形式动态转换为另一种形式的值。

## **更改主题字体**

主题字体方案包含标题的主要字体集和正文的次要字体集。[FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) 和 [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) 属性公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体 Latin（次要 Latin 字体）
* `+mj-lt` - 标题字体 Latin（主要 Latin 字体）
* `+mn-ea` - 正文字体 East Asian（次要 East Asian 字体）
* `+mj-ea` - 标题字体 East Asian（主要 East Asian 字体）
* `+mn-cs` - 正文字体 Complex Script（次要 Complex Script 字体）
* `+mj-cs` - 标题字体 Complex Script（主要 Complex Script 字体）

以下示例创建一个使用主要 Latin 主题字体的标题和一个使用次要 Latin 主题字体的正文行。随后更改主题字体并保存结果：

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

标题遵循主要字体，正文文本遵循次要字体。使用显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

主要和次要字体集合还可以包含针对单个书写系统（如西里尔、阿拉伯、日语、格鲁吉亚和塔纳）的字体映射。要检查、添加、替换或移除这些映射，请参阅 [脚本特定主题字体](/slides/zh/python-net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
有关演示文稿字体的更多信息，请参阅 [PowerPoint 字体](/slides/zh/python-net/powerpoint-fonts/)。
{{% /alert %}}

### **解析主题字体引用**

检查文本时，[FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) 可能包含类似 `+mn-lt` 的主题引用，而不是字体族名称。调用 [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) 并传入相应的 [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) 即可解析该引用。`+mj` 与 `+mn` 前缀选择主要和次要字体集；`-lt`、`-ea` 与 `-cs` 后缀分别选择它们的 Latin、East Asian 和 Complex Script 字体。

通过在适用主题的对象上调用 [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) 获取实际主题。对于普通幻灯片上的文本，使用 `slide.create_theme_effective` 可确保上下文包含该幻灯片继承的主题及本地覆盖。检查版式或母版本身时，使用其自身的实际主题。不要假设第一个母版的主题适用于每个幻灯片。

以下示例创建一个显式引用次要 Latin 字体的文本段落。它通过 [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) 初始化幻灯片字体方案，并将主要和次要 Latin 字体族设为 `Arial` 和 `Calibri`，使结果在没有输入文件的情况下可复现。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

输出为 `+mn-lt -> Calibri`，随后是 `Verdana -> Verdana`。存储的引用保持不变，而显式的族名称按原样返回。如果该段落使用 `+mj-lt`，则在此主题下会解析为 `Arial`。

解析主题引用可识别主题指定的字体族。它不检查字体可用性，也不确定在渲染期间替代或字形回退后最终使用的字体文件。有关这些独立步骤，请参阅 [字体选择顺序](/slides/zh/python-net/font-selection-sequence/) 与 [字体替代](/slides/zh/python-net/font-substitution/)。

## **复制或应用主题**

以下工作流解决不同的主题相关问题。

### **将外部主题应用于依赖母版的幻灯片**

当您拥有 PowerPoint 主题文件（`.thmx`）并希望重新样式化所有依赖特定母版的幻灯片时，请使用 [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/)。从 [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) 集合（[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)）中选择母版，并将主题文件路径传递给该方法。

该方法执行以下操作：

1. 基于选定的母版创建一个新母版幻灯片。
1. 将外部主题应用于新母版。
1. 将新母版分配给所有先前依赖选定母版的幻灯片。
1. 返回新创建的 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)。

以下示例将外部主题应用于依赖第一个母版的幻灯片并保存演示文稿：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

无效、损坏或不受支持的主题可能导致 [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) 或其格式相关子类。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后保存演示文稿。

仅重新分配依赖所选母版的幻灯片。与其他母版关联的幻灯片保留其现有母版和主题。支持主题的颜色、字体、填充、线条、背景和效果会依据外部主题解析。直接分配的颜色、字体、填充和其他显式格式可能保持不变。版式级别和幻灯片级别的覆盖也可能优先于从新母版继承的值。

主题可能引用运行时环境中不可用的字体。为确保一致的渲染和导出，请安装所需字体、通过 [自定义字体源](/slides/zh/python-net/custom-font/) 提供，或配置 [字体替代](/slides/zh/python-net/font-substitution/)。

这是一种直接的母版级工作流：该方法接受 `.thmx` 文件路径，不需要手动创建幻灯片级或版式级的主题覆盖。

### **在多母版演示文稿中应用不同的外部主题**

当事先不知道相关母版时，可通过 [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) 和 [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/) 从代表性幻灯片获取母版。应用任何主题之前请先存储原始母版引用，因为每次调用都会在演示文稿中创建另一个母版。

以下示例使用两个章节的幻灯片定位其母版，并为每组应用不同的外部主题：

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

第一次调用仅影响依赖 `first_group_master` 的幻灯片，第二次调用仅影响依赖 `second_group_master` 的幻灯片。属于其他母版的幻灯片不会被重新样式化。

### **移动幻灯片时保留源主题**

如果希望将幻灯片移动到另一演示文稿并保留其原始设计，请使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) 将源母版克隆到目标演示文稿，然后使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) 将幻灯片连同克隆的母版一起克隆。这会将母版、其版式及相关主题一起携带。

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

在源幻灯片必须在目标中保持相同外观时，这是首选工作流。仅将内容克隆到不相关的目标母版上可能会更改受主题驱动的颜色、字体、背景和效果。

### **将主题值应用于已有幻灯片**

如果目标幻灯片必须保持当前母版和版式，请从源主题初始化幻灯片级覆盖。使用 [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) 和 [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) 方法将三个主要主题组件复制到覆盖中。

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

这会在不更改其他幻灯片继承的主题的前提下更改该幻灯片使用的主题。要移除本地覆盖并恢复继承值，请调用 [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/)。

### **将主题覆盖应用于版式**

版式级覆盖适用于使用该版式的幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可通过版式的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) 使用：

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

当许多版式和幻灯片应共享同一基础设计时使用母版或演示文稿级主题；当某一版式族需要不同样式时使用版式覆盖；仅在真正例外时使用幻灯片覆盖。过多的幻灯片级覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) 中。PowerPoint 在 UI 中可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 可以将主题填充与主题颜色及其他样式引用组合使用。

![PowerPoint 演示文稿主题的背景样式库](presentation-design_8.png)

使用背景样式前，请检查存储的集合以及当前的 [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/)。`style_index` 使用 `0` 表示无主题填充；正值表示主题背景样式引用。这与直接对 Python 集合进行索引不同，后者的 `[0]` 表示第一项。不要假设每个演示文稿拥有相同数量的背景填充样式。

以下示例报告可用的背景填充计数，将主题背景引用分配给第一个母版，并保存演示文稿：

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

可见结果取决于母版引用的主题条目以及版式或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要了解继承后最终背景时，请使用 [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/)。

{{% alert color="warning" title="Warning" %}}
不要将 `style_index` 视为零基集合索引。也避免硬编码来自一个文件的样式编号并假设在另一个文件中具有相同外观；主题样式定义是演示文稿特定的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅 [演示文稿背景](/slides/zh/python-net/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含独立的 [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) 和 [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/) 集合。典型的 Office 主题通常包含三个主要样式条目，分别对应于微妙、适中和强烈的视觉效果，但代码应检查每个集合，而不是假设固定计数。

![对同一形状应用的微妙、适中和强烈主题效果](presentation-design_10.png)

在 Python 中访问这些集合时，集合索引是零基的：`[0]` 是第一条存储的样式，`[2]` 是第三条。形状的样式引用索引是另一个概念，通过 [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/) 暴露。修改主题样式会影响引用该主题样式的形状；使用直接格式化的形状可能保持不变。

以下示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，启用第三条效果样式的外阴影，并保存结果：

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

对于引用这些插槽的形状，第一条主题线条样式变为红色，第三条主题填充样式变为实心森林绿，第三条效果样式获得距离为 10 点的外阴影。具体视觉结果仍取决于每个形状引用的样式插槽以及直接格式化是否覆盖主题。

![更改线条、填充和阴影设置后的主题效果样式](presentation-design_11.png)

## **为形状选择主题填充和线条样式**

形状可以通过 [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) 和 [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/) 独立选择填充和轮廓。对于这两个属性，索引 `1` 选择相应主题集合中的第一条条目（`fill_styles[0]` 或 `line_styles[0]`），索引 `2` 选择第二条条目。

以下示例在新演示文稿的默认主题中定义两种填充（金色和天蓝色）和两种轮廓（6 pt 深蓝色和 12 pt 深红色），并在三个阶段保存幻灯片，以便在 PowerPoint 中比较结果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| 初始样式 | 更改右侧轮廓 | 编辑第一主题填充 |
|:---:|:---:|:---:|
| ![金色和天蓝色矩形，配有细深蓝色轮廓](theme-style-initial.png) | ![天蓝色矩形现在具有粗深红色轮廓](theme-style-line-changed.png) | ![左侧矩形变为绿色，两个轮廓保持不变](theme-style-fill-changed.png) |

选择不同的线条样式仅更改右侧矩形的轮廓。编辑第一主题填充会更新使用该填充的所有形状，此处仅左侧矩形变为绿色。

在已有形状上，局部填充颜色、线条颜色或线条宽度可以覆盖主题样式的相应部分。如果更改样式索引后没有可见效果，请检查形状的 [直接格式化](/slides/zh/python-net/shape-formatting/)。

## **确定实际实色填充是否使用主题颜色**

填充可以直接存储在对象上，或从段落、版式、母版、主题样式或其他格式层继承。调用 [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) 将该层次结构解析为不可变的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/)。首先检查 [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/)。仅当其为 `FillType.SOLID` 时才读取实色填充属性。

对于实色填充，[IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) 返回在继承、主题查找和颜色变换后渲染的最终 RGB 值。[IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) 返回对应的逻辑 [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 插槽，如 `TEXT1` 或 `ACCENT6`。`SchemeColor.NOT_DEFINED` 表示实际实色填充不是基于方案颜色。在填充仅为主题颜色或直接 RGB 颜色的工作流中，此值标识直接 RGB 填充。

不要仅使用本地的 [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) 值来分类填充。例如，文本段落可能没有本地定义的方案颜色，其本地值为 `NOT_DEFINED`，而其实际填充继承自主题颜色并解析为 `TEXT1` 或 `ACCENT6`。相反，`solid_fill_scheme_color` 告诉您哪个逻辑主题插槽产生了实际颜色，但不说明该插槽来源于对象、段落、版式、母版或其他层级。

以下示例加载演示文稿，审计形状填充和文本段落填充，打印每个最终 RGB 值及关联的方案颜色，并标记不会随主题颜色更改的实色填充：

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

`NOT_DEFINED` 分支提供了一个审计列表，列出在主题颜色槽更改时不会响应的实色填充。审查这些对象以确保演示文稿遵循新的品牌调色板。报告的 RGB 值仍显示当前外观，而方案值说明该外观是否与主题相连。

实际格式对象是快照。更改演示文稿主题、主题覆盖或任何继承的格式后，重新调用 `get_effective` 并读取新的 `IFillFormatEffectiveData` 对象后再进行比较或报告颜色。

## **读取实际主题值**

原始主题对象告诉您在特定层级上定义了什么。实际值告诉您在继承和本地覆盖解析后，幻灯片或形状实际使用了什么。对于幻灯片，调用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。对于背景，使用 [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/)，对于填充，使用 [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/)。

以下示例读取幻灯片的实际主题、背景和第一形状填充：

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

使用实际数据进行渲染诊断、验证和比较。如果仅检查 [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/)，可能会遗漏更改最终外观的母版、版式、幻灯片或形状覆盖。

## **常见问题**

**将外部主题应用于演示文稿会影响每一张幻灯片吗？**

不会。[MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) 仅重新分配依赖所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**我可以在不更改母版的情况下将主题应用于单张幻灯片吗？**

可以。使用幻灯片的 [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) 并初始化其覆盖主题。更改仅局限于该幻灯片；其他幻灯片继续继承其现有主题。

**从一个演示文稿将主题迁移到另一个演示文稿的最安全方法是什么？**

在移动幻灯片并保留其源外观时，使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) 将源母版克隆到目标演示文稿，然后使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) 将幻灯片连同该母版一起克隆。这样可保持母版、版式和主题一起。

**如何查看继承和覆盖后的实际值？**

对于幻灯片或版式主题，使用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)；对于格式对象，如 [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) 和 [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/)，使用对应的实际数据方法。这些 API 返回在继承和覆盖应用后的解析值。