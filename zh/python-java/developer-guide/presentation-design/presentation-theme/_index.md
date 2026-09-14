---
title: 通过 Java 使用 Python 管理演示主题
linktitle: 演示主题
type: docs
weight: 10
url: /zh/python-java/presentation-theme/
keywords:
- PowerPoint 主题
- 演示主题
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中掌控演示主题，以创建、定制并转换具有一致品牌标识的 PowerPoint 文件。"
---
## **简介**

演示主题定义了一组协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题时可以一次性更新许多对象。

在 Aspose.Slides 中，可通过 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasterTheme) 获取演示级别的主题。演示还可以在更低层级包含主题覆盖。母版可以通过 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterthememanager/#getOverrideTheme) 覆盖演示主题，而布局或单个幻灯片可以通过 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) 覆盖其继承的主题。在实际使用中，幻灯片的有效主题通过以下继承链解析：演示主题 → 母版覆盖 → 布局覆盖 → 幻灯片覆盖。

![主题组成：颜色、字体、背景样式和效果](theme-constituents.png)

下面的章节展示了最常见的主题工作流：检查主题、修改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/mastertheme/) 对象通过 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/mastertheme/#getColorScheme)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/mastertheme/#getFontScheme) 和 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/mastertheme/#getFormatScheme) 暴露主题的配色方案、字体方案和格式方案。在更改这些集合之前先检查它们尤其有用，因为来自外部来源的演示文件的样式条目数量和内容可能各不相同。

下面的示例读取主要主题属性，并报告主题中存储的背景、填充、线条和效果样式的数量：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

如果文件使用了多个母版，请不要假设每张幻灯片拥有相同的有效主题。检查与幻灯片关联的母版，并在布局或幻灯片可能存在覆盖时使用本文后面介绍的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文字可以引用 [SchemeColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/schemecolor/) 枚举中的逻辑颜色。当您更改 [ColorScheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/colorscheme/) 中对应的条目时，所有仍引用该主题颜色的对象都会解析为新的值。使用直接 RGB 颜色的对象不会受到主题颜色更新的影响。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色改为红色，保存演示，重新打开并打印有效填充颜色：

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

因为矩形仍链接到 `Accent4`，主题更改后其可见颜色会变为红色。如果在形状上用直接颜色替换了方案颜色，之后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色转换来生成更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/colortransformoperation/) 枚举公开这些转换。

![主主题颜色以及从附加调色板生成的更亮和更暗颜色](additional-palette-colors.png)

**1** - 主主题颜色。

**2** - 基于主主题颜色生成的更亮和更暗变体。

下面的示例基于 `Accent4` 创建六个矩形，对其中五个应用亮度转换，并保存结果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

这些变体仍基于主题颜色。如果以后 `Accent4` 发生变化，转换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/schemecolor/) 枚举使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/colorscheme/) 将相同的主题槽位暴露为 `Dark1`、`Light1`、`Dark2`、`Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题槽位的别名；它们不是会在两种形式之间动态转换的值。

## **更改主题字体**

主题字体方案包含用于标题的主要字体集和用于正文的次要字体集。[FontScheme.getMajor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontscheme/#getMajor) 和 [FontScheme.getMinor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontscheme/#getMinor) 方法公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体 拉丁文（Minor Latin Font）
* `+mj-lt` - 标题字体 拉丁文（Major Latin Font）
* `+mn-ea` - 正文字体 东亚文字（Minor East Asian Font）
* `+mj-ea` - 标题字体 东亚文字（Major East Asian Font）

下面的示例创建一个使用主要拉丁主题字体的标题和一个使用次要拉丁主题字体的正文行，然后更改主题字体并保存结果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

标题遵循主要字体，正文遵循次要字体。使用显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

主要和次要字体集合还可以包含针对特定书写系统（如西里尔文、阿拉伯文、日文、格鲁吉亚文和塔那文）的字体映射。要检查、添加、替换或删除这些映射，请参阅 [Script-Specific Theme Fonts](/slides/zh/python-java/script-specific-font-mappings/)。

{{% alert color="success" title="Tip" %}}
有关演示字体的更多信息，请参阅 [PowerPoint Fonts](/slides/zh/python-java/powerpoint-fonts/)。
{{% /alert %}}

## **复制或应用主题**

以下工作流解决不同的主题相关问题。

### **将外部主题应用于母版的从属幻灯片**

当您拥有一个 PowerPoint 主题文件（`.thmx`）并希望重新样式化所有依赖特定母版的幻灯片时，请使用 [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides)。从 [Presentation.getMasters](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasters) 集合中选择母版（该集合由 [MasterSlideCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/) 表示），并将主题文件路径传递给该方法。

该方法执行以下操作：

1. 基于选定的母版创建一个新母版幻灯片。  
1. 将外部主题应用到新母版。  
1. 将新母版分配给所有先前依赖选定母版的幻灯片。  
1. 返回新创建的 [MasterSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/)。

下面的示例将外部主题应用于依赖第一个母版的幻灯片并保存演示：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

无效、损坏或不受支持的主题可能导致 [PptxReadException](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxreadexception/)。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后保存演示。

仅重新分配依赖选定母版的幻灯片。与其他母版关联的幻灯片保留其现有母版和主题。主题感知的颜色、字体、填充、线条、背景和效果会根据外部主题解析。直接分配的颜色、字体、填充和其他显式格式可能保持不变。布局级和幻灯片级的覆盖也可能优先于新母版继承的值。

主题可能引用运行时环境中不可用的字体。为获得一致的渲染和导出，请安装所需字体、通过 [custom font sources](/slides/zh/python-java/custom-font/) 提供，或配置 [font substitution](/slides/zh/python-java/font-substitution/)。

这是一个直接的母版级工作流：该方法接受 `.thmx` 文件路径，无需手动创建幻灯片级或布局级主题覆盖。

### **在多母版演示中为不同母版应用不同外部主题**

当事先不知道相关母版时，可通过 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getLayoutSlide) 和 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getMasterSlide) 从代表性幻灯片获取母版。在应用任何主题之前保存原始母版引用，因为每次调用都会在演示中创建另一个母版。

下面的示例使用两个章节的幻灯片定位它们的母版，并为每组应用不同的外部主题：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

第一次调用仅影响依赖 `first_group_master` 的幻灯片，第二次调用仅影响依赖 `second_group_master` 的幻灯片。属于其他母版的幻灯片不会被重新样式。

### **在移动幻灯片时保留源主题**

如果希望将幻灯片移动到另一份演示并保留其原始设计，请使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/#addClone) 将源母版克隆到目标演示，然后使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addClone) 将幻灯片连同克隆的母版一起克隆。这样会将母版、其布局及关联的主题一起携带。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

当源幻灯片必须在目标中保持完全相同外观时，这是首选工作流。仅将内容克隆到一个不相关的目标母版上可能会改变主题驱动的颜色、字体、背景和效果。

### **将主题值应用于已有幻灯片**

如果目标幻灯片必须保持当前母版和布局，可从源主题初始化幻灯片级覆盖。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/overridetheme/#initColorSchemeFrom)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) 和 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) 方法将三个主要主题组件复制到覆盖中。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

此操作会更改该幻灯片使用的主题，而不影响其他幻灯片继承的主题。若要移除本地覆盖并恢复继承值，请调用 [OverrideTheme.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/overridetheme/#clear)。

### **将主题覆盖应用于布局**

布局级覆盖适用于使用该布局的所有幻灯片，除非特定幻灯片拥有自己的覆盖。相同的初始化方法可通过 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslidethememanager/) 使用：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

当许多布局和幻灯片应共享相同的基础设计时，使用母版或演示级主题；当某一布局系列需要不同的样式时使用布局覆盖；仅在真正例外的情况下使用幻灯片覆盖。过度的幻灯片级覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) 中。PowerPoint 在 UI 中可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 可以将主题填充与主题颜色和其他样式引用组合使用。

![PowerPoint 演示主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，请检查存储的集合以及当前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/background/#getStyleIndex)。索引为 `0` 表示没有主题填充；正数表示主题背景样式引用。这与直接索引集合不同，其中 `get_Item(0)` 表示第一项。不要假设每个演示都有相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题背景引用分配给第一个母版，并保存演示：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要获取继承后最终背景时，请使用 [Background.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/background/#getEffective)。

{{% alert color="warning" title="Warning" %}}
不要将样式索引视为零基集合索引。也避免将一个文件中的样式编号硬编码到另一个文件中，因为主题样式定义是演示特定的。
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅 [Presentation Background](/slides/zh/python-java/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh/python-java/aspose.slides/formatscheme/#getFillStyles)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh/python-java/aspose.slides/formatscheme/#getLineStyles) 和 [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh/python-java/aspose.slides/formatscheme/#getEffectStyles) 暴露的独立填充、线条和效果样式集合。常见的 Office 主题通常包含三条主要样式条目，对应于细微、适中和强烈的格式，但代码应检查每个集合，而不是假设固定数量。

![对同一形状应用细微、适中和强烈主题效果](presentation-design_10.png)

在 Python 通过 Java 访问这些集合时，集合索引是零基的：`get_Item(0)` 为第一条存储的样式，`get_Item(2)` 为第三条。形状的样式引用索引是另一概念，通过 [ShapeStyle](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapestyle/) 暴露。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外部阴影，并保存结果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

对于引用这些槽位的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 点的外部阴影。确切的视觉结果仍取决于每个形状引用的样式槽位以及是否存在直接格式覆盖。

![更改线条、填充和阴影设置后主题效果样式](presentation-design_11.png)

## **确定有效的纯色填充是否使用主题颜色**

填充可以直接存储在对象上，也可以从段落、布局、母版、主题样式或其他格式层级继承。调用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/#getEffective) 可将该层级解析为不可变的有效填充数据。首先在有效数据对象上检查 `getFillType`。仅当其为 `FillType.Solid` 时才读取纯色填充属性。

对于纯色填充，`getSolidFillColor` 返回在继承、主题查找和颜色转换后得到的最终 RGB 值。`getSolidFillSchemeColor` 返回对应的逻辑 [SchemeColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/schemecolor/) 槽位，如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示有效的纯色填充并非基于方案颜色。在只使用主题颜色或直接 RGB 颜色的工作流中，该值标识直接 RGB 填充。

不要仅依据本地的 [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/colorformat/#getSchemeColor) 值来分类填充。例如，文本片段可能没有本地定义的方案颜色，其本地值为 `NotDefined`，但其有效填充可能继承自主题颜色并解析为 `Text1` 或 `Accent6`。相反，`getSolidFillSchemeColor` 告诉您是哪一个逻辑主题槽生成了有效颜色，但并未说明该槽来自对象、段落、布局、母版还是其他层级。

下面的示例加载演示，审计形状填充和文本片段填充，打印每个最终的 RGB 值及关联的方案颜色，并标记不会随主题颜色变化的纯色填充：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

`NotDefined` 分支提供了一份审计列表，列出在主题颜色槽位更改时不会响应的纯色填充。审查这些对象以确保演示符合新的品牌调色板。报告的 RGB 值仍显示当前外观，而方案值说明该外观是否与主题关联。

有效格式对象是快照。更改演示主题、主题覆盖或任何继承格式后，请再次调用 `getEffective` 并读取新的有效填充数据对象，然后再进行比较或报告颜色。

## **读取有效主题值**

原始主题对象告诉您在特定层级上定义了什么。有效值告诉您在继承和本地覆盖解析后，幻灯片或形状实际使用了什么。对于幻灯片，调用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective)。对于背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/background/#getEffective)；对于填充，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/#getEffective)。

下面的示例读取幻灯片的有效主题、背景和第一形状填充：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

使用有效数据进行渲染诊断、验证和比较。如果仅检查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasterTheme)，可能会遗漏母版、布局、幻灯片或形状覆盖所带来的最终外观变化。

## **常见问题**

**将外部主题应用会影响演示中的每张幻灯片吗？**

不会。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) 只重新分配依赖所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。使用该幻灯片的 [SlideThemeManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidethememanager/) 并初始化其覆盖主题。更改仅局限于该幻灯片，其他幻灯片继续继承其已有主题。

**将主题从一个演示迁移到另一个演示的最安全方式是什么？**

在移动幻灯片并保留源外观时，使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslidecollection/#addClone) 将源母版克隆到目标演示，然后使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidecollection/#addClone) 将幻灯片连同该母版一起克隆。这样可以一起保留母版、布局和主题。

**如何查看继承和覆盖后的有效值？**

对于幻灯片或布局主题，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective)；对于格式对象，如背景和填充，则分别使用对应的有效数据方法 [Background.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/background/#getEffective) 和 [FillFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/#getEffective)。这些 API 返回继承和覆盖应用后的解析值。