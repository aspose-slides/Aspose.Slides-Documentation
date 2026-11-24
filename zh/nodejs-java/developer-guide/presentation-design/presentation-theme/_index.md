---
title: 在 JavaScript 中管理演示文稿主题
linktitle: 演示文稿主题
type: docs
weight: 10
url: /zh/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中管理主演示文稿主题，以创建、定制和转换具有一致品牌的 PowerPoint 文件。"
---
## **介绍**

演示文稿主题定义了一组协调的颜色、字体、背景样式、填充、线条和效果。主题感知对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题可以一次性更新许多对象。

在 Aspose.Slides 中，可通过 [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) 获取演示文稿级别的主题。演示文稿还可以在更低级别包含主题覆盖。母版可以通过 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/) 覆盖演示文稿主题，而布局或单个幻灯片可以通过 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) 覆盖其继承的主题。实际中，幻灯片的有效主题通过以下继承链解析：演示文稿主题、母版覆盖、布局覆盖和幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

以下各节展示了最常见的主题工作流：检查主题、修改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) 对象通过 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) 和 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) 暴露主题的配色方案、字体方案和格式方案。在更改之前检查这些集合尤其有用，因为来自外部源的演示文稿可能在样式条目数量和内容上有所不同。

下面的示例读取主要主题属性并报告主题中存储了多少背景、填充、线条和效果样式：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

如果文件使用了多个母版，请不要假设每个幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在可能存在布局或幻灯片覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

主题感知的填充、线条和文字可以引用 [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) 枚举中的逻辑颜色。当您在 [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) 中更改相应条目时，仍引用该主题颜色的所有对象都会解析到新值。直接使用 RGB 颜色的对象不会因主题颜色更新而改变。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色改为红色，保存演示文稿，重新打开并打印有效填充颜色：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);

    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

因为矩形仍链接到 `Accent4`，主题更改后其可见颜色变为红色。如果在形状上将方案颜色替换为直接颜色，则以后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换生成更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/) 枚举公开这些变换。

![主要主题颜色以及从附加调色板生成的更亮和更暗颜色](additional-palette-colors.png)

**1** - 主要主题颜色。

**2** - 从主要主题颜色生成的更亮和更暗变体。

下面的示例基于 `Accent4` 创建六个矩形，对其中五个应用亮度变换，并保存结果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

这些变体仍基于主题颜色。如果稍后 `Accent4` 变化，变换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) 枚举使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) 将相同的主题插槽表示为 `Dark1`、`Light1`、`Dark2`、`Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题插槽的别名；它们不是动态转换的值。

## **更改主题字体**

主题字体方案包含标题的主要字体集和正文的次要字体集。[FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) 和 [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) 方法公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文字格式化：

* `+mn-lt` - 正文字体拉丁文（Minor Latin Font）
* `+mj-lt` - 标题字体拉丁文（Major Latin Font）
* `+mn-ea` - 正文字体东亚（Minor East Asian Font）
* `+mj-ea` - 标题字体东亚（Major East Asian Font）
* `+mn-cs` - 正文字体复杂脚本（Minor Complex Script Font）
* `+mj-cs` - 标题字体复杂脚本（Major Complex Script Font）

下面的示例创建一个使用主要拉丁文字体的标题和一个使用次要拉丁文字体的正文行。随后更改主题字体并保存结果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));

    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

标题遵循主要字体，正文遵循次要字体。使用明确字体名称而非主题标识符的文字在主题字体方案更改时不会自动切换。

主要和次要字体集合还可以包含针对特定书写系统（如西里尔文、阿拉伯文、日文、格鲁吉亚文和塔纳文）的字体映射。要检查、添加、替换或删除这些映射，请参阅 [Script-Specific Theme Fonts](/slides/zh/nodejs-java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
有关演示文稿字体的更多信息，请参阅 [PowerPoint Fonts](/slides/zh/nodejs-java/powerpoint-fonts/)。
{{% /alert %}}

### **解析主题字体引用**

检查文字时，[FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) 可能返回主题引用如 `+mn-lt` 而不是字体族名称。使用适当的有效主题调用 [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) 可解析该引用。`+mj` 和 `+mn` 前缀选择主要和次要字体集；`-lt`、`-ea`、`-cs` 后缀分别选择它们的拉丁文、东亚文和复杂脚本字体。

通过在适用于被检查文字的对象上调用 [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) 获取有效主题。对于普通幻灯片上的文字，在幻灯片上调用此方法即可，使上下文包含该幻灯片的继承主题和本地覆盖。检查布局或母版本身时，使用其自身的有效主题。不要假设第一个母版的主题适用于每个幻灯片。

下面的示例创建一个显式引用次要拉丁字体的文字段落。它通过 [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) 初始化幻灯片字体方案，并将主要和次要拉丁族设置为 `Arial` 和 `Calibri`，使结果在没有输入文件的情况下可复现。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

输出为 `+mn-lt -> Calibri`，随后是 `Verdana -> Verdana`。存储的引用保持不变，而显式的族名称原样返回。如果段落使用 `+mj-lt`，则会解析为本主题中的 `Arial`。

解析主题引用能够识别主题指定的字体族，但不检查字体可用性，也不决定在渲染期间替代或字形回退后实际使用的字体文件。有关这些独立步骤，请参阅 [Font Selection Sequence](/slides/zh/nodejs-java/font-selection-sequence/) 和 [Font Substitution](/slides/zh/nodejs-java/font-substitution/)。

## **复制或应用主题**

以下工作流解决不同的主题相关问题。

### **将外部主题应用于依赖特定母版的幻灯片**

当您拥有 PowerPoint 主题文件（`.thmx`）并希望重新样式化所有依赖特定母版的幻灯片时，请使用 [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) 。从 [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 集合中选择母版（该集合由 [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 表示），并将主题文件路径传递给该方法。

该方法执行以下操作：

1. 基于选定的母版创建一个新母版幻灯片。
1. 将外部主题应用于新母版。
1. 将选定母版之前依赖的所有幻灯片指派给新母版。
1. 返回新创建的 [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)。

下面的示例将外部主题应用于依赖第一个母版的幻灯片并保存演示文稿：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

无效、损坏或不受支持的主题可能导致 [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/)。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后保存演示文稿。

仅重新指派依赖于选定母版的幻灯片。与其他母版关联的幻灯片保留其现有母版和主题。主题感知的颜色、字体、填充、线条、背景和效果会根据外部主题解析。直接分配的颜色、字体、填充等显式格式可能保持不变。布局级和幻灯片级覆盖也可能优先于新母版继承的值。

主题可能引用运行时环境中不存在的字体。为确保一致的渲染和导出，请安装所需字体、通过 [custom font sources](/slides/zh/nodejs-java/custom-font/) 提供，或配置 [font substitution](/slides/zh/nodejs-java/font-substitution/)。

这是直接的母版级工作流：该方法接受 `.thmx` 文件路径，不需要手动创建幻灯片级或布局级主题覆盖。

### **在多母版演示文稿中为不同母版应用不同外部主题**

当事先不知道相关母版时，可通过 [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) 和 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) 从代表性幻灯片获取母版。在应用任何主题之前保存原始母版引用，因为每次调用都会在演示文稿中创建另一个母版。

下面的示例使用来自两个部分的幻灯片定位其母版，并为每组应用不同的外部主题：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

第一次调用仅影响依赖 `firstGroupMaster` 的幻灯片，第二次调用仅影响依赖 `secondGroupMaster` 的幻灯片。属于其他母版的幻灯片不会被重新样式化。

### **在移动幻灯片时保留源主题**

如果要将幻灯片移动到另一个演示文稿并保留其原始设计，请使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 将源母版克隆到目标演示文稿，然后使用 [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) 将幻灯片与克隆的母版一起克隆。这样会将母版、其布局以及关联的主题一起携带。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);

        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());

        target.getSlides().addClone(sourceSlide, clonedMaster, true);

        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

当源幻灯片必须在目标中保持相同外观时，这是首选工作流。仅将内容克隆到不相关的目标母版可能会更改受主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持其当前母版和布局，可从源主题初始化幻灯片级覆盖。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) 和 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) 方法将三个主要主题组件复制到覆盖中。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

这会更改该幻灯片使用的主题，而不影响其他幻灯片继承的主题。要删除本地覆盖并返回继承值，请调用 [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)。

### **将主题覆盖应用于布局**

布局级覆盖适用于使用该布局的幻灯片，除非特定幻灯片拥有自己的覆盖。相同的初始化方法可通过 [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/) 使用：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

当许多布局和幻灯片应共享相同基础设计时使用母版或演示文稿级主题；当某一布局族需要不同样式时使用布局覆盖；仅在真正例外的情况下使用幻灯片覆盖。过度的幻灯片级覆盖会使后续全局主题更改更难预测。

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*布局覆盖适用于使用该布局的幻灯片，除非幻灯片提供了更局部的覆盖。基于主题的值遵循其解析后的方案；显式格式化的对象可以保留本地外观。请将覆盖范围限制在预期的设计例外范围内。*
<!-- visual-explanation:presentation-theme:end -->

## **更新主题背景样式**

主题的背景填充存储在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) 中。PowerPoint 在 UI 中可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 可以将主题填充与主题颜色和其他样式引用组合使用。

![PowerPoint 背景样式库用于演示文稿主题](presentation-design_8.png)

在使用背景样式之前，检查存储的集合以及当前的 [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)。`0` 表示没有主题填充；正值表示主题背景样式引用。这与直接对 JavaScript 集合进行索引不同，后者的 `0` 表示第一项。不要假设每个演示文稿都有相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题化的背景引用分配给第一个母版，并保存演示文稿：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);

    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要了解继承后最终背景时，请使用 [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
不要将样式索引视为零基的集合索引。也避免硬编码来自某个文件的样式编号并假设在另一个文件中具有相同外观；主题样式定义是特定于演示文稿的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅 [Presentation Background](/slides/zh/nodejs-java/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) 和 [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) 公开的独立填充、线条和效果样式集合。典型的 Office 主题通常包含三个主要样式条目，分别对应微妙、适中和强烈的视觉效果，但代码应检查每个集合而不是假设固定计数。

![对同一形状应用的微妙、适中和强烈主题效果](presentation-design_10.png)

在 JavaScript 中访问这些集合时，集合索引是零基的：`0` 为第一项，`2` 为第三项。形状的样式引用索引是另一概念，通过 [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/) 暴露。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外阴影，并保存结果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);

    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对于引用这些插槽的形状，第一条主题线条样式变为红色，第三条主题填充样式变为实心森林绿，第三条效果样式获得距离为 10 点的外阴影。具体视觉效果仍取决于每个形状引用的样式插槽以及直接格式化是否覆盖主题。

![更改线条、填充和阴影设置后的主题效果样式](presentation-design_11.png)

## **为形状选择主题填充和线条样式**

形状可以通过 [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) 和 [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/) 独立选择填充和轮廓。对于任一方法，索引 `1` 选择对应主题集合中的第一项 (`get_Item(0)`)，索引 `2` 选择第二项 (`get_Item(1)`)。

下面的示例在新演示文稿的默认主题中设置两个填充样式（金色和天蓝色）和两个线条样式（6 pt 深蓝色和 12 pt 深红色），并在三个阶段保存幻灯片，以便在 PowerPoint 中比较结果。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 初始样式 | 更改右侧轮廓 | 编辑第一主题填充 |
|:---:|:---:|:---:|
| ![金色和天蓝色矩形，轮廓为细深蓝色](theme-style-initial.png) | ![天蓝色矩形现在具有粗深红色轮廓](theme-style-line-changed.png) | ![左侧矩形现在为绿色，两个轮廓保持不变](theme-style-fill-changed.png) |

选择不同的线条样式仅更改右侧矩形的轮廓。编辑第一主题填充会更新使用该填充的所有形状，此处仅左侧矩形变为绿色。

在已有形状上，本地填充颜色、线条颜色或线宽可以覆盖主题样式的相应部分。如果更改样式索引没有可见效果，请检查形状的 [direct formatting](/slides/zh/nodejs-java/shape-formatting/)。

## **确定有效实心填充是否使用主题颜色**

填充可以直接存储在对象上，也可以继承自段落、布局、母版、主题样式或其他格式层级。调用 [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) 可将该层级解析为不可变的有效填充快照。首先检查其 `getFillType` 值。仅当其为 `FillType.Solid` 时才读取实心填充属性。

对于实心填充，`getSolidFillColor` 返回在继承、主题查找和颜色变换后渲染的最终 RGB 值。`getSolidFillSchemeColor` 方法返回对应的逻辑 [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) 插槽，如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示有效实心填充并非基于方案颜色。在只使用主题颜色或直接 RGB 颜色的工作流中，该值标识直接 RGB 填充。

不要仅使用本地的 [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) 值来分类填充。例如，文字段落可能没有本地定义的方案颜色，其本地值为 `NotDefined`，但其有效填充继承自主题颜色并解析为 `Text1` 或 `Accent6`。相反，`getSolidFillSchemeColor` 告诉您是哪一个逻辑主题插槽产生了有效颜色，但不指明该插槽来自对象、段落、布局、母版或其他层级。

下面的示例加载演示文稿，审计形状填充和文字段落填充，打印每个最终 RGB 值及关联的方案颜色，并标记不会随主题颜色变化的实心填充：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` 分支提供了一个审计列表，列出在主题颜色槽更改时不会响应的实心填充。请在需要遵循新品牌调色板的演示文稿中检查这些对象。报告的 RGB 值仍显示当前外观，而方案值解释了该外观是否与主题相连。

有效格式对象是快照。更改演示文稿主题、主题覆盖或任何继承的格式后，请再次调用 `getEffective` 并读取新的有效填充对象后再进行比较或报告颜色。

## **读取有效主题值**

原始主题对象告诉您在特定层级定义了什么。有效值告诉您在继承和本地覆盖解析后，幻灯片或形状实际使用了什么。对于幻灯片，调用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/)。对于背景，使用 [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)，对于填充，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/)。

下面的示例读取幻灯片的有效主题、背景以及第一个形状的填充：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();

    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());

    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

使用有效数据进行渲染诊断、验证和比较。如果仅检查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/)，可能会错过改变最终外观的母版、布局、幻灯片或形状覆盖。

## **常见问题**

**将外部主题应用于演示文稿是否会影响每个幻灯片？**

不会。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) 仅重新指派依赖所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。使用幻灯片的 [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) 并初始化其覆盖主题。更改仅局限于该幻灯片，其他幻灯片继续继承其现有主题。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？**

在移动幻灯片并保留源外观时，使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 将源母版克隆到目标演示文稿，再使用 [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) 将幻灯片与该母版一起克隆。这样可以保持母版、布局和主题一起。

**如何查看继承和覆盖后的有效值？**

对幻灯片或布局主题使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/)，对格式对象（如背景和填充）使用相应的有效数据方法，例如 [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) 和 [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/)。这些 API 返回在继承和覆盖应用后的解析值。