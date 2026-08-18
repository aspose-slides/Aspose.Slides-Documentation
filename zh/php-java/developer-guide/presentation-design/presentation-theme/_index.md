---
title: 管理 PHP 中的演示文稿主题
linktitle: 演示文稿主题
type: docs
weight: 10
url: /zh/php-java/presentation-theme/
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
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中管理演示文稿主题，以创建、定制和转换具有一致品牌标识的 PowerPoint 文件。"
---
## **概述**

演示文稿主题定义了一套协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题可以一次性更新许多对象。

在 Aspose.Slides 中，演示文稿级别的主题可通过[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)获取。演示文稿还可以在更低层级包含主题覆盖。母版可以通过[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterthememanager/)覆盖演示文稿主题，而布局或单个幻灯片可以通过[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/)覆盖其继承的主题。实际使用中，幻灯片的有效主题通过以下继承链解析：演示文稿主题、母版覆盖、布局覆盖和幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

以下章节展示了最常见的主题工作流：检查主题、 更改颜色和字体、复制或应用主题、 更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/)对象通过[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/)和[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/)公开主题的配色方案、字体方案和格式方案。在更改这些集合之前先检查它们尤为有用，因为来自外部源的演示文稿其样式条目数量和内容可能各不相同。

下面的示例读取主要主题属性，并报告主题中存储了多少背景、填充、线条和效果样式：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

如果文件使用了多个母版，请不要认为每个幻灯片的有效主题都相同。检查与幻灯片关联的母版，并在可能存在布局或幻灯片覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文本可以引用[SchemeColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/schemecolor/)枚举中的逻辑颜色。当你在[ColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colorscheme/)中更改对应条目时，所有仍然引用该主题颜色的对象都会使用新值解析。使用直接 RGB 颜色的对象不会受到主题颜色更新的影响。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色改为红色，保存演示文稿，重新打开并打印有效填充颜色：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

由于矩形仍然链接到 `Accent4`，主题更改后其可见颜色变为红色。如果你在形状上将方案颜色替换为直接颜色，则以后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过应用颜色转换从主题颜色生成更浅和更深的变体。Aspose.Slides 通过[ColorTransformOperation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colortransformoperation/)枚举公开这些转换。

![主主题颜色以及从附加调色板生成的更浅和更深颜色](additional-palette-colors.png)

**1** - 主主题颜色。

**2** - 从主主题颜色生成的更浅和更深变体。

下面的示例基于 `Accent4` 创建六个矩形，对其中五个应用亮度转换，并保存结果：

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

这些变体仍然基于主题颜色。如果之后更改 `Accent4`，转换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/schemecolor/)枚举使用 `Text1`、`Background1`、`Text2` 和 `Background2`，而[ColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colorscheme/)将相同的主题槽位显示为 `Dark1`、`Light1`、`Dark2` 和 `Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题槽位的别名， 并不是在运行时相互转换的值。

## **更改主题字体**

主题字体方案包含标题的主字体集和正文的次要字体集。 [FontScheme.getMajor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontscheme/) 和 [FontScheme.getMinor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontscheme/) 方法公开这些集合。

PowerPoint 兼容的主题字体标识符可在文本格式化时使用：

* `+mn-lt` - 正文字体 Latin（次要 Latin 字体）
* `+mj-lt` - 标题字体 Latin（主要 Latin 字体）
* `+mn-ea` - 正文字体 East Asian（次要 East Asian 字体）
* `+mj-ea` - 标题字体 East Asian（主要 East Asian 字体）

下面的示例创建一个使用主 Latin 主题字体的标题和一个使用次要 Latin 主题字体的正文行。随后更改主题字体并保存结果：

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

标题遵循主字体，正文遵循次要字体。使用显式字体名称而不是主题标识符的文本在主题字体方案改变时不会自动切换。

{{% alert color="info" title="Tip" %}}
有关演示文稿字体的更多信息，请参阅[PowerPoint Fonts](/slides/zh/php-java/powerpoint-fonts/)。
{{% /alert %}}

## **复制或应用主题**

常见的两种工作流解决不同的问题。

### **在移动幻灯片时保留源主题**

如果要将幻灯片移动到另一个演示文稿并保留其原始设计，请使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/)将源母版克隆到目标演示文稿，然后使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/)克隆幻灯片及其克隆的母版。这会将母版、其布局以及关联的主题一起携带。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

当需要在目标位置保持源幻灯片外观一致时，这是一种首选工作流。仅将内容克隆到与目标母版无关的母版上可能会更改受主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持在当前母版和布局上，请从源主题初始化幻灯片级别的覆盖。 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/) 和 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/) 方法会将三大主题组件复制到覆盖中。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

此操作会更改该幻灯片使用的主题，而不会更改其他幻灯片继承的主题。要移除本地覆盖并恢复继承值，请调用 [OverrideTheme.clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)。

### **将主题覆盖应用于布局**

布局级别的覆盖适用于使用该布局的幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可通过[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslidethememanager/)使用：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

当许多布局和幻灯片应共享相同的基础设计时，请使用母版或演示文稿级别的主题；当某个布局系列需要不同的样式时使用布局覆盖；仅在真正的例外情况下使用幻灯片覆盖。过多的幻灯片级别覆盖会使以后全局主题更改的预测变得困难。

## **更新主题背景样式**

主题的背景填充存储在[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)中。PowerPoint 在 UI 中可以呈现的背景选项多于此集合实际存储的填充定义，因为 UI 可以将主题填充与主题颜色和其他样式引用组合使用。

![PowerPoint 演示文稿主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，检查存储的集合以及当前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)。`0` 表示无主题填充；正值表示主题背景样式引用。这不同于直接对 PHP 集合进行索引时 `get_Item(0)` 表示第一项。不要假设每个演示文稿都包含相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题化的背景引用分配给第一个母版，并保存演示文稿：

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

可见结果取决于母版引用的主题条目以及布局或幻灯片级别的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要知道继承后最终背景时，请使用[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
不要将样式索引视为零基集合索引。也避免硬编码某个文件的样式编号并假设在另一个文件中具有相同外观；主题样式定义是针对特定演示文稿的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅[Presentation Background](/slides/zh/php-java/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过[FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)和[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)公开的独立填充、线条和效果样式集合。典型的 Office 主题通常包含三个主要样式条目，分别对应细微、适中和强烈的格式化，但代码应检查每个集合而不是假设固定数量。

![对同一形状应用的细微、适中和强烈主题效果](presentation-design_10.png)

在 PHP 中访问这些集合时，集合索引为零基：`get_Item(0)` 是第一项，`get_Item(2)` 是第三项。形状的样式引用索引是另一概念，由[ShapeStyle](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapestyle/)公开。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外阴影，并保存结果：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

对于引用这些槽位的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 磅的外阴影。确切的视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式化覆盖主题。

![更改线条、填充和阴影设置后主题效果样式](presentation-design_11.png)

## **读取有效主题值**

原始主题对象告诉你在特定层级上定义了什么。有效值告诉你幻灯片或形状在继承和本地覆盖解析后实际使用的内容。对于幻灯片，调用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/)。对于背景，使用[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)，对于填充，使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/)。

下面的示例读取幻灯片的有效主题、背景以及第一形状的填充：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

使用有效数据进行渲染诊断、验证和比较。如果只检查[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)，可能会遗漏母版、布局、幻灯片或形状的覆盖，从而导致最终外观不同。

## **FAQ**

**是否可以在不更改母版的情况下将主题应用于单个幻灯片？**

可以。使用幻灯片的[SlideThemeManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidethememanager/)并初始化其覆盖主题。更改仅局限于该幻灯片，其他幻灯片继续继承其现有主题。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方法是什么？**

在移动幻灯片并保留源外观时，使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/)将源母版克隆到目标演示文稿，并使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/)克隆该幻灯片及其母版。这会将母版、布局和主题一起保留下来。

**如何查看继承和覆盖后的有效值？**

对于幻灯片或布局主题，使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/)。对于格式对象，如[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)和[FillFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/)，使用相应的有效数据方法。这些 API 返回在继承和覆盖应用后解析出的值。