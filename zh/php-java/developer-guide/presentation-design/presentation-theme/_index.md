---
title: 在 PHP 中管理演示文稿主题
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
description: 通过 Java 使用 Aspose.Slides for PHP 统一管理演示文稿主题，以创建、定制和转换具有一致品牌标识的 PowerPoint 文件。
---
## **介绍**

演示文稿主题定义了一组协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题时可以一次性更新许多对象。

在 Aspose.Slides 中，通过 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 可获取演示文稿级别的主题。演示文稿也可以在更低级别包含主题覆盖。母版可以通过 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterthememanager/) 覆盖演示文稿主题，而布局或单个幻灯片可以通过 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/) 覆盖其继承的主题。实际情况下，幻灯片的有效主题是通过以下继承链解析的：演示文稿主题 → 母版覆盖 → 布局覆盖 → 幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

下面的章节展示了最常见的主题工作流：检查主题、修改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/) 对象通过 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/) 和 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/) 暴露主题的配色方案、字体方案和格式方案。在修改之前检查这些集合尤其有用，因为来自外部来源的演示文稿其样式条目的数量和内容可能各不相同。

下面的示例读取主要主题属性并报告主题中存储了多少背景、填充、线条和效果样式：

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

如果文件使用了多个母版，请不要假设每张幻灯片拥有相同的有效主题。检查与幻灯片关联的母版，并在布局或幻灯片可能存在覆盖时，使用本文后面展示的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文字可以引用来自 [SchemeColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/schemecolor/) 枚举的逻辑颜色。当你修改 [ColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colorscheme/) 中的相应条目时，所有仍然引用该主题颜色的对象都会使用新值进行解析。直接使用 RGB 颜色的对象不会因主题颜色更新而改变。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色改为红色，保存演示文稿，重新打开并打印有效的填充颜色：

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

因为矩形仍然链接到 `Accent4`，主题更改后其可见颜色会变为红色。如果你在形状上用直接颜色替换了方案颜色，之后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换来产生更浅和更深的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colortransformoperation/) 枚举公开这些变换。

![主主题颜色及从附加调色板生成的更浅和更深颜色](additional-palette-colors.png)

**1** - 主主题颜色。

**2** - 基于主主题颜色产生的更浅和更深变体。

下面的示例基于 `Accent4` 创建六个矩形，对其中五个应用亮度变换，并保存结果：

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

这些变体仍然基于主题颜色。如果随后 `Accent4` 发生改变，变换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/schemecolor/) 枚举使用 `Text1`、`Background1`、`Text2` 和 `Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colorscheme/) 将相同的主题插槽公开为 `Dark1`、`Light1`、`Dark2` 和 `Light2`。映射固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题插槽的别名；它们不是会在两种形式之间动态转换的值。

## **更改主题字体**

主题字体方案包含用于标题的主要字体集和用于正文的次要字体集。`[FontScheme.getMajor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontscheme/)` 和 `[FontScheme.getMinor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontscheme/)` 方法公开这些集合。

PowerPoint 兼容的主题字体标识符可以在文字格式化时使用：

* `+mn-lt` - 正文字体拉丁文（次要拉丁字体）
* `+mj-lt` - 标题字体拉丁文（主要拉丁字体）
* `+mn-ea` - 正文字体东亚文（次要东亚字体）
* `+mj-ea` - 标题字体东亚文（主要东亚字体）

下面的示例创建一个使用主要拉丁主题字体的标题和一个使用次要拉丁主题字体的正文行，然后更改主题字体并保存结果：

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

标题遵循主要字体，正文遵循次要字体。使用显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

主要和次要字体集合还可以包含针对特定书写系统的字体映射，例如西里尔文、阿拉伯文、日文、格鲁吉亚文和塔那文。要检查、添加、替换或删除这些映射，请参阅 [脚本特定主题字体](/slides/zh/php-java/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}

欲了解更多关于演示文稿字体的信息，请参阅 [PowerPoint 字体](/slides/zh/php-java/powerpoint-fonts/)。

{{% /alert %}}

## **复制或应用主题**

常见的两种工作流解决不同的问题。

### **在移动幻灯片时保留源主题**

如果要将幻灯片移动到另一个演示文稿并保留其原始设计，请使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/) 将源母版克隆到目标演示文稿，然后使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/) 将幻灯片与克隆的母版一起克隆。这会将母版、其布局以及关联的主题一起携带。

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

当源幻灯片必须在目标中保持一致外观时，这是首选工作流。仅将内容克隆到不相关的目标母版上可能会更改基于主题的颜色、字体、背景和效果。

### **将主题值应用到现有幻灯片**

如果目标幻灯片必须保持在当前母版和布局上，请从源主题初始化幻灯片级别的覆盖。`[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)`、`[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)` 和 `[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)` 方法将三个主要主题组件复制到覆盖中。

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

这会在不更改其他幻灯片继承主题的情况下更改该幻灯片使用的主题。要删除本地覆盖并恢复到继承值，请调用 `[OverrideTheme.clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)`。

### **将主题覆盖应用到布局**

布局级别的覆盖适用于使用该布局的所有幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可以通过 `[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslidethememanager/)` 使用：

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

当许多布局和幻灯片应共享相同的基础设计时使用母版或演示文稿级别主题；当某一布局系列需要不同的样式时使用布局覆盖；仅在真正例外的情况下使用幻灯片覆盖。过多的幻灯片级覆盖会使后期全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在 `[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)` 中。PowerPoint 在其 UI 中提供的背景选项数量可能多于此集合实际存储的填充定义，因为 UI 可以将主题填充与主题颜色及其他样式引用组合使用。

![PowerPoint 演示文稿主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，检查存储的集合以及当前的 `[Background.getStyleIndex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)`。`0` 表示没有主题填充；正数表示主题背景样式引用。这不同于直接索引 PHP 集合，其中 `get_Item(0)` 表示第一项。不要假设每个演示文稿都包含相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题背景引用分配给第一个母版，并保存演示文稿：

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

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要获取继承后最终背景时，请使用 `[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)`。

{{% alert color="warning" title="警告" %}}

不要把样式索引当作零基集合索引。另外，避免硬编码某个文件的样式编号并假设在另一个文件中具有相同外观；主题样式定义是针对特定演示文稿的。

{{% /alert %}}

{{% alert color="info" title="提示" %}}

有关直接背景格式化和背景继承，请参阅 [演示文稿背景](/slides/zh/php-java/presentation-background/)。

{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过 `[FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)`、`[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)` 和 `[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)` 暴露的独立填充、线条和效果样式集合。典型的 Office 主题通常包含三个主要样式条目，视觉上对应微妙、适中和强烈的格式，但代码应检查每个集合，而不要假设固定数量。

![对同一形状应用的微妙、适中和强烈主题效果](presentation-design_10.png)

在 PHP 中访问这些集合时，集合索引是零基的：`get_Item(0)` 是第一项，`get_Item(2)` 是第三项。形状的样式引用索引是另一个概念，通过 `[ShapeStyle](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapestyle/)` 暴露。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外部阴影，并保存结果：

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

对于引用这些插槽的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 点的外部阴影。具体视觉结果仍取决于每个形状引用的样式插槽以及是否有直接格式覆盖。

![更改线条、填充和阴影设置后主题效果样式](presentation-design_11.png)

## **读取有效主题值**

原始主题对象告诉你在特定层级上定义了什么。有效值告诉你幻灯片或形状在继承和本地覆盖解析后实际使用的内容。对于幻灯片，调用 `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/)`。对于背景，使用 `[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)`，对于填充，使用 `[FillFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/)`。

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

使用有效数据进行渲染诊断、验证和比较。如果仅检查 `[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)`，可能会错过改变最终外观的母版、布局、幻灯片或形状覆盖。

## **常见问题**

**我可以在不更改母版的情况下为单个幻灯片应用主题吗？**

可以。使用幻灯片的 `[SlideThemeManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidethememanager/)` 并初始化其覆盖主题。更改仅局部作用于该幻灯片，其他幻灯片继续继承各自的主题。

**从一个演示文稿向另一个演示文稿迁移主题的最安全方式是什么？**

在移动幻灯片并保留其源外观时，使用 `[MasterSlideCollection.addClone`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/) 将源母版克隆到目标演示文稿，并使用 `[SlideCollection.addClone`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/) 将幻灯片与该母版一起克隆。这样可以将母版、布局和主题一起保留。

**如何查看继承和覆盖后的有效值？**

对幻灯片或布局主题使用 `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/)`，对格式对象（如 `[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)`、`[FillFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/)`）使用相应的有效数据方法。这些 API 返回在继承和覆盖应用后解析出的值。