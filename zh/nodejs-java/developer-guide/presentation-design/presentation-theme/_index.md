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
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中掌握演示文稿主题，以创建、定制和转换具有一致品牌形象的 PowerPoint 文件。"
---
## **介绍**

演示文稿主题定义了一组配套的颜色、字体、背景样式、填充、线条和效果。主题感知的对象引用这些共享定义，而不是将每个视觉属性存为固定值，因此更改主题可以一次性更新许多对象。

在 Aspose.Slides 中，可通过[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getmastertheme/)获取演示文稿级别的主题。演示文稿还可以在更低层级包含主题覆盖。母版可以通过[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterthememanager/)覆盖演示文稿主题，而布局或单个幻灯片可以通过[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseoverridethememanager/)覆盖其继承的主题。实际上，幻灯片的有效主题通过以下继承链解析：演示文稿主题、母版覆盖、布局覆盖和幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

下面的章节展示了最常见的主题工作流：检查主题、修改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mastertheme/)对象通过[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mastertheme/)和[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mastertheme/)公开主题的配色方案、字体方案和格式方案。在更改之前检查这些集合特别有用，因为来自外部来源的演示文稿其样式条目数量和内容可能各不相同。

以下示例读取主要主题属性并报告主题中存储了多少背景、填充、线条和效果样式：

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

如果文件使用了多个母版，请不要假设每张幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在布局或幻灯片可能存在覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

主题感知的填充、线条和文本可以引用[SchemeColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/schemecolor/)枚举中的逻辑颜色。当您更改[ColorScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/colorscheme/)中的相应条目时，所有仍引用该主题颜色的对象都会使用新值进行解析。使用直接 RGB 颜色的对象不会因主题颜色更新而改变。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色更改为红色，保存演示文稿，重新打开它，并打印有效的填充颜色：

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

由于矩形仍然链接到 `Accent4`，主题更改后其可见颜色会变为红色。如果您在形状上用直接颜色替换方案颜色，则以后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换来生成更亮和更暗的变体。Aspose.Slides 通过[ColorTransformOperation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/colortransformoperation/)枚举公开这些变换。

![主主题颜色以及从附加调色板生成的更亮和更暗颜色](additional-palette-colors.png)

**1** - 主主题颜色。  
**2** - 从主主题颜色生成的更亮和更暗变体。

以下示例基于 `Accent4` 创建六个矩形，对其中五个应用亮度变换，并保存结果：

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

这些变体仍基于主题颜色。如果 `Accent4` 稍后更改，变换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/schemecolor/) 枚举使用 `Text1`、`Background1`、`Text2` 和 `Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/colorscheme/) 将相同的主题槽位公开为 `Dark1`、`Light1`、`Dark2` 和 `Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题槽位的别名；它们不是从一种形式动态转换为另一种形式的值。

## **更改主题字体**

主题字体方案包含用于标题的主要字体集和用于正文的次要字体集。`[FontScheme.getMajor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontscheme/)` 和 `[FontScheme.getMinor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontscheme/)` 方法公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体 拉丁文（次要拉丁字体）
* `+mj-lt` - 标题字体 拉丁文（主要拉丁字体）
* `+mn-ea` - 正文字体 东亚文（次要东亚字体）
* `+mj-ea` - 标题字体 东亚文（主要东亚字体）

以下示例创建一个使用主要拉丁主题字体的标题和一个使用次要拉丁主题字体的正文行。随后更改主题字体并保存结果：

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

标题遵循主要字体，正文遵循次要字体。采用显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

主要和次要字体集合还可以包含针对特定书写系统（如西里尔文、阿拉伯文、日文、格鲁吉亚文和塔纳文）的字体映射。要检查、添加、替换或删除这些映射，请参阅[特定脚本的主题字体](/slides/zh/nodejs-java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲了解有关演示文稿字体的更多信息，请参阅[PowerPoint 字体](/slides/zh/nodejs-java/powerpoint-fonts/)。
{{% /alert %}}

## **复制或应用主题**

常见的两种工作流解决不同的问题。

### **在移动幻灯片时保留源主题**

如果要将幻灯片移至另一个演示文稿并保留其原始设计，请使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslidecollection/)将源母版克隆到目标演示文稿中，然后使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidecollection/)克隆幻灯片及其克隆的母版。这样会一起携带母版、布局以及关联的主题。

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

这是在目标中保持源幻灯片外观一致的首选工作流。仅将内容克隆到不相关的目标母版上可能会更改受主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持在其当前母版和布局上，请从源主题初始化幻灯片级别的覆盖。`[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/overridetheme/)`、`[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/overridetheme/)` 和 `[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/overridetheme/)` 方法会将三个主要主题组件复制到覆盖中。

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

这会更改该幻灯片使用的主题，而不影响其他幻灯片继承的主题。若要删除本地覆盖并恢复继承值，请调用 `[OverrideTheme.clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/overridetheme/)`。

### **将主题覆盖应用于布局**

布局级覆盖适用于使用该布局的所有幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可通过[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslidethememanager/)使用：

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

当许多布局和幻灯片应共享相同基础设计时，请使用母版或演示文稿级主题；当一个布局系列需要不同样式时使用布局覆盖；仅在真正例外的情况下使用幻灯片覆盖。过多的幻灯片级覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/formatscheme/)中。PowerPoint 在 UI 中可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 能够将主题填充与主题颜色和其他样式引用组合使用。

![PowerPoint 演示文稿主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，检查存储的集合以及当前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/background/)。`0` 表示没有主题填充；正值表示主题背景样式引用。这与直接对 JavaScript 集合进行索引不同，后者的 `0` 表示第一个存储项。不要假设每个演示文稿都有相同数量的背景填充样式。

以下示例报告可用的背景填充计数，将主题化背景引用分配给第一个母版，并保存演示文稿：

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

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要了解继承后最终背景时，请使用[Background.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
不要将样式索引视为零基集合索引。也不要硬编码某个文件中的样式编号并假设在另一文件中具有相同外观；主题样式定义是演示文稿特定的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅[演示文稿背景](/slides/zh/nodejs-java/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过[FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/formatscheme/)和[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/formatscheme/)公开的独立填充、线条和效果样式集合。典型的 Office 主题通常包含三个主要样式条目，分别对应微妙、适中和强烈的视觉效果，但代码应检查每个集合，而不是假设固定数量。

![对同一形状应用微妙、适中和强烈主题效果](presentation-design_10.png)

在 JavaScript 中访问这些集合时，集合索引是零基的：索引 `0` 为第一个存储的样式，索引 `2` 为第三个。形状的样式引用索引是另一个概念，通过[ShapeStyle](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapestyle/)公开。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

以下示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外阴影，并保存结果：

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

对于引用这些槽位的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 点的外阴影。具体视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式化覆盖主题。

![更改线条、填充和阴影设置后主题效果样式](presentation-design_11.png)

## **读取有效主题值**

原始主题对象告诉您在特定层级上定义了什么。有效值告诉您在继承和本地覆盖解析后，幻灯片或形状实际使用的是什么。对于幻灯片，请调用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseoverridethememanager/)。对于背景，使用[Background.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/background/)，对于填充，使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fillformat/)。

以下示例读取幻灯片的有效主题、背景以及第一形状的填充：

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

使用有效数据进行渲染诊断、验证和比较。如果仅检查[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getmastertheme/)，可能会漏掉改变最终外观的母版、布局、幻灯片或形状覆盖。

## **FAQ**

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。使用幻灯片的[SlideThemeManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidethememanager/)并初始化其覆盖主题。更改仅局限于该幻灯片，其他幻灯片继续继承其现有主题。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方法是什么？**

在移动幻灯片并保留源外观时，使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslidecollection/)将源母版克隆到目标位置，并使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidecollection/)克隆该母版对应的幻灯片。这会将母版、布局和主题一起保留下来。

**我如何查看继承和覆盖后的有效值？**

对幻灯片或布局主题使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseoverridethememanager/)，对格式对象（如[Background.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/background/) 和 [FillFormat.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fillformat/)）使用相应的有效数据方法。这些 API 返回在继承和覆盖应用后的解析值。