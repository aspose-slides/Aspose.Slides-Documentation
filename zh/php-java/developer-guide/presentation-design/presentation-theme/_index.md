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
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中管理演示文稿主题，以创建、定制和转换具有一致品牌标识的 PowerPoint 文件。"
---
## **简介**

演示文稿主题定义了一套协调一致的颜色、字体、背景样式、填充、线条和效果。主题感知对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题可以一次性更新许多对象。

在 Aspose.Slides 中，可通过 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 获取演示文稿级别的主题。演示文稿还可以在更低层级包含主题覆盖。Master 可以通过 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterthememanager/) 覆盖演示文稿主题，而布局或单个幻灯片可以通过 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/) 覆盖其继承的主题。实际上，幻灯片的有效主题通过以下继承链解析：演示文稿主题 → Master 覆盖 → 布局覆盖 → 幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

以下章节展示最常见的主题工作流：检查主题、更改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/) 对象通过 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/) 和 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mastertheme/) 暴露主题的配色方案、字体方案和格式方案。在更改之前检查这些集合尤为有用，因为来自外部来源的演示文稿的样式条目数量和内容可能各不相同。

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

如果文件使用了多个母版，不要假设每个幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在布局或幻灯片可能存在覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

主题感知的填充、线条和文本可以引用 [SchemeColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/schemecolor/) 枚举中的逻辑颜色。当你在 [ColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colorscheme/) 中更改相应条目时，所有仍然引用该主题颜色的对象都会使用新值进行解析。使用直接 RGB 颜色的对象不会因主题颜色更新而改变。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色改为红色，保存演示文稿，重新打开它，并打印有效的填充颜色：

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

因为矩形仍然链接到 `Accent4`，主题更改后其可见颜色会变成红色。如果在形状上用直接颜色替换了方案颜色，之后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过应用颜色变换从主题颜色派生出更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colortransformoperation/) 枚举公开这些变换。

![主要主题颜色以及从附加调色板生成的更亮和更暗的颜色](additional-palette-colors.png)

**1** - 主要主题颜色。

**2** - 基于主要主题颜色生成的更亮和更暗的变体。

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

这些变体仍基于主题颜色。如果随后 `Accent4` 发生变化，变换后的颜色将根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `ColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/schemecolor/) 枚举使用 `Text1`、`Background1`、`Text2` 和 `Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colorscheme/) 将相同的主题槽位公开为 `Dark1`、`Light1`、`Dark2`、`Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题槽位的别名；它们不是会相互动态转换的值。

## **更改主题字体**

主题字体方案包含用于标题的主要字体集和用于正文的次要字体集。`[FontScheme.getMajor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontscheme/)` 和 `[FontScheme.getMinor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontscheme/)` 方法公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体拉丁文（Minor Latin Font）
* `+mj-lt` - 标题字体拉丁文（Major Latin Font）
* `+mn-ea` - 正文字体东亚文（Minor East Asian Font）
* `+mj-ea` - 标题字体东亚文（Major East Asian Font）

下面的示例创建一个使用主要拉丁主题字体的标题和一个使用次要拉丁主题字体的正文行。随后更改主题字体并保存结果：

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

主要和次要字体集合还可以包含针对特定书写系统（如西里尔文、阿拉伯文、日文、格鲁吉亚文和塔纳文）的字体映射。要检查、添加、替换或删除这些映射，请参阅 [脚本特定主题字体](/slides/zh/php-java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲获取更多关于演示文稿字体的信息，请参阅 [PowerPoint 字体](/slides/zh/php-java/powerpoint-fonts/)。
{{% /alert %}}

## **复制或应用主题**

下面的工作流解决不同的主题相关问题。

### **将外部主题应用于依赖特定母版的幻灯片**

当你有 PowerPoint 主题文件（`.thmx`）并希望重新样式化所有依赖特定母版的幻灯片时，使用 [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/)。从 [Presentation::getMasters](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 集合中选择母版（该集合由 [MasterSlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/) 表示），并将主题文件路径传入该方法。

该方法执行以下操作：

1. 基于选定的母版创建一个新母版幻灯片。
1. 将外部主题应用到新母版。
1. 将新母版分配给所有先前依赖选定母版的幻灯片。
1. 返回新创建的 [MasterSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/)。

下面的示例将外部主题应用于依赖第一个母版的幻灯片并保存演示文稿：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

无效、损坏或不受支持的主题可能导致 [PptxReadException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxreadexception/)。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后保存演示文稿。

仅重新分配依赖选定母版的幻灯片。与其他母版关联的幻灯片保留其现有母版和主题。主题感知的颜色、字体、填充、线条、背景和效果会依据外部主题进行解析。直接分配的颜色、字体、填充及其他显式格式可能保持不变。布局级和幻灯片级的覆盖也可能优先于从新母版继承的值。

主题可能引用运行时环境中不可用的字体。为确保一致的渲染和导出，请安装所需字体、通过 [自定义字体源](/slides/zh/php-java/custom-font/) 提供，或配置 [字体替换](/slides/zh/php-java/font-substitution/)。

这是直接的母版级工作流：该方法接受 `.thmx` 文件路径，无需手动创建幻灯片级或布局级主题覆盖。

### **在多母版演示文稿中为不同母版应用不同外部主题**

当事先不知道相关母版时，可通过 [Slide::getLayoutSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/) 和 [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/) 从代表性幻灯片获取母版。在应用任何主题之前先保存原始母版引用，因为每次调用都会在演示文稿中创建另一个母版。

下面的示例使用来自两个章节的幻灯片定位其母版，并为每组幻灯片应用不同的外部主题：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

第一次调用仅影响依赖 `$firstGroupMaster` 的幻灯片，第二次调用仅影响依赖 `$secondGroupMaster` 的幻灯片。属于其他母版的幻灯片不会被重新样式化。

### **在移动幻灯片时保留源主题**

如果希望将幻灯片移动到另一演示文稿并保留其原始设计，可使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/) 将源母版克隆到目标演示文稿，然后使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/) 将幻灯片与克隆的母版一起克隆。这样会连同母版、其布局和关联的主题一起迁移。

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

当源幻灯片必须在目标中保持相同外观时，这是首选工作流。仅将内容克隆到无关联的目标母版上可能导致主题驱动的颜色、字体、背景和效果发生变化。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持在当前母版和布局上，可从源主题初始化幻灯片级覆盖。`[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)`、`[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)` 和 `[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)` 方法会将三个主要主题组件复制到覆盖中。

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

此操作会更改该幻灯片使用的主题，而不影响其他幻灯片继承的主题。要移除本地覆盖并恢复继承值，请调用 `[OverrideTheme.clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/overridetheme/)`。

### **将主题覆盖应用于布局**

布局级覆盖适用于使用该布局的所有幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可通过 `[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslidethememanager/)` 使用：

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

当许多布局和幻灯片需要共享同一基础设计时，使用母版或演示文稿级主题；当某一布局族需要不同样式时使用布局覆盖；仅对真正例外使用幻灯片覆盖。过多的幻灯片级覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在 `[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)` 中。PowerPoint 在 UI 中可以展示比实际存储的填充定义更多的背景选项，因为 UI 可以将主题填充与主题颜色和其他样式引用组合使用。

![PowerPoint 演示文稿主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，请检查存储的集合以及当前的 `[Background.getStyleIndex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)`。`0` 表示无主题填充；正值表示主题背景样式引用。这与直接对 PHP 集合进行索引不同，`get_Item(0)` 表示第一项。不要假设每个演示文稿都包含相同数量的背景填充样式。

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

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能并不会影响该幻灯片。需要获取继承后最终背景时，请使用 `[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)`。

{{% alert color="warning" title="Warning" %}}
不要将样式索引当作零基集合索引使用。同时避免硬编码某个文件的样式编号并假设在另一个文件中表现相同；主题样式定义是针对具体演示文稿的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅 [演示文稿背景](/slides/zh/php-java/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过 `[FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)`、`[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)` 和 `[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh/php-java/aspose.slides/formatscheme/)` 公开的独立填充、线条和效果样式集合。典型的 Office 主题通常包含三个主要样式条目，分别对应细微、适中和强烈的视觉效果，但代码应检查每个集合而不是假设固定数量。

![对同一形状应用细微、适中和强烈主题效果](presentation-design_10.png)

在 PHP 中访问这些集合时，集合索引为零基：`get_Item(0)` 为第一条存储的样式，`get_Item(2)` 为第三条。形状的样式引用索引是另一个概念，通过 `[ShapeStyle](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapestyle/)` 暴露。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

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

对于引用这些槽位的形状，第一条主题线条样式会变为红色，第三条主题填充样式会变为实心森林绿，第三条效果样式会获得距离为 10pt 的外阴影。具体视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式化覆盖主题。

![更改线条、填充和阴影设置后的主题效果样式](presentation-design_11.png)

## **确定有效的实色填充是否使用主题颜色**

填充可以直接存储在对象上，也可以从段落、布局、母版、主题样式或其他格式层级继承。调用 `[FillFormat::getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/)` 可将该层级解析为不可变的有效填充数据。首先检查其 `getFillType` 结果。仅当返回 `FillType::Solid` 时才读取实色填充属性。

对于实色填充，`getSolidFillColor` 返回在继承、主题查找和颜色变换后最终渲染的 RGB 值。`getSolidFillSchemeColor` 方法返回对应的逻辑 `[SchemeColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/schemecolor/)` 槽位，如 `Text1` 或 `Accent6`。返回 `SchemeColor::NotDefined` 表示有效的实色填充不基于方案颜色。在仅使用主题颜色或直接 RGB 颜色的工作流中，此值标识直接 RGB 填充。

不要仅使用本地 `[ColorFormat::getSchemeColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colorformat/)` 值来分类填充。例如，文本片段可能没有本地定义的方案颜色，因此其本地值为 `NotDefined`，而其有效填充可能继承自主题颜色并解析为 `Text1` 或 `Accent6`。相反，`getSolidFillSchemeColor` 告诉你哪个逻辑主题槽位产生了有效颜色，但它并不告诉你该槽位来自对象、段落、布局、母版或其他层级。

下面的示例加载演示文稿，审计形状填充和文本片段填充，打印每个最终的 RGB 值及关联的方案颜色，并标记那些不会随主题颜色更改而变化的实色填充：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

`NotDefined` 分支提供了一个审计列表，列出不会响应主题颜色槽位更改的实色填充。在需要演示文稿遵循新品牌调色板时，请检查这些对象。报告的 RGB 值仍显示当前外观，而方案值解释了该外观是否与主题关联。

有效格式对象是快照。更改演示文稿主题、主题覆盖或任何继承的格式后，请再次调用 `getEffective` 并读取新的有效填充数据，然后再进行比较或报告颜色。

## **读取有效主题值**

原始主题对象告诉你在特定层级定义了什么。有效值告诉你在继承和本地覆盖解析后，幻灯片或形状实际使用了什么。对于幻灯片，调用 `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/)`。对于背景，使用 `[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)`；对于填充，使用 `[FillFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/)`。

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

使用有效数据进行渲染诊断、验证和比较。如果仅检查 `[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)`，可能会遗漏改变最终外观的母版、布局、幻灯片或形状覆盖。

## **FAQ**

**应用外部主题会影响演示文稿中的每一张幻灯片吗？**

不会。`[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/)` 仅重新分配依赖所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**我可以在不更改母版的情况下为单张幻灯片应用主题吗？**

可以。使用幻灯片的 `[SlideThemeManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidethememanager/)` 并初始化其覆盖主题。更改仅作用于该幻灯片，其他幻灯片继续继承各自的主题。

**将主题从一个演示文稿携带到另一个演示文稿的最安全方式是什么？**

在移动幻灯片并保留源外观时，使用 `[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/)` 将源母版克隆到目标演示文稿，然后使用 `[SlideCollection.addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/)` 将幻灯片与该克隆母版一起克隆。这样可保持母版、布局和主题共同迁移。

**如何在继承和覆盖后查看有效值？**

对幻灯片或布局主题使用 `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseoverridethememanager/)`，并对格式对象使用相应的有效数据方法，如 `[Background.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/background/)` 和 `[FillFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/)`。这些 API 返回在继承和覆盖应用后的解析值。