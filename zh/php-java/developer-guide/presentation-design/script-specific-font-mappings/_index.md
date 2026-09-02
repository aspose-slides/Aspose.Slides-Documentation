---
title: 在 PHP 中管理特定脚本的主题字体
linktitle: 特定脚本主题字体
type: docs
weight: 15
url: /zh/php-java/script-specific-font-mappings/
keywords:
- 特定脚本字体
- 主题字体映射
- 多语言演示文稿
- 书写系统
- 西里尔字体
- 阿拉伯字体
- 日文字体
- 格鲁吉亚字体
- 塔纳字体
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 检查、添加、替换和移除 PowerPoint 主题中的特定脚本字体映射。"
---
## **概述**

演示文稿主题可以为不同的书写系统选择不同的字体族。这使得仍然使用主题字体的多语言文本能够遵循统一的字体方案，同时为西里尔文、阿拉伯文、日文、格鲁吉亚文、塔纳文等脚本使用合适的字体。

主题的[字体方案]({{guid}})包含一个主要字体集合，通常用于标题，以及一个次要字体集合，通常用于正文。除了它们的拉丁和东亚字体设置外，这两个[Fonts]({{guid}})集合还公开了从书写系统标签到字体族名称的映射。

本文展示了如何检查和修改演示文稿主主题中的这些映射，并验证更改在保存‑重新加载周期后仍然存在。

## **了解脚本标签**

脚本字体方法使用四字符 BCP 47 脚本子标签来标识书写系统。常见值包括：

| 脚本标签 | 文字系统 |
|---|---|
| `Cyrl` | 西里尔文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 简体中文 |
| `Jpan` | 日文 |
| `Geor` | 格鲁吉亚文 |
| `Thaa` | 塔纳文 |

这些映射属于主题字体方案，而不是单个文本片段。一个演示文稿可以为主要和次要集合定义不同的映射，也可以省略某些脚本的映射。

## **访问并检查脚本字体映射**

使用[Presentation::getMasterTheme]({{guid}})访问演示文稿级别的主题。通过[MasterTheme::getFontScheme]({{guid}})、[FontScheme::getMajor]({{guid}})和[FontScheme::getMinor]({{guid}})方法可以获取两个[Fonts]({{guid}})集合。

调用[Fonts::getScriptFontMap]({{guid}})检索集合中的所有映射。要查找单个书写系统，使用其脚本标签调用[Fonts::getScriptFont]({{guid}})。当该集合未定义请求的映射时，`Fonts::getScriptFont`返回`null`。

## **修改映射并验证持久性**

使用[Fonts::setScriptFont]({{guid}})创建映射或替换其当前字体族。使用[Fonts::removeScriptFont]({{guid}})删除映射。

下面的端到端示例读取所有现有的主要和次要映射，查找日文主要字体，修改西里尔文主要字体，删除塔纳文次要映射，保存演示文稿并重新打开以验证两项更改。为了使删除步骤独立于初始主题，示例仅在未定义塔纳文映射时才创建该映射。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

验证使用与普通查找相同的`null`行为：删除后保存时，`Fonts::getScriptFont("Thaa")`对次要集合返回`null`。

## **区分主题映射与其他字体设置**

脚本特定的主题映射参与字体选择，但它们解决的问题与直接文本格式化、替换和回退不同：

| 机制 | 目的 | 更改主题映射的效果 |
|---|---|---|
| 脚本特定的主题字体映射 | 为书写系统选择主要或次要主题字体。 | 仍使用相应主题字体的文本可以解析到新的映射族。 |
| 明确分配给文本片段的字体 | 将请求的字体族固定在该片段上，而不依赖主题。 | 由于直接格式化覆盖主题选择，片段可能保持不变。 |
| 字体替换 | 当请求的字体不可用或符合替换规则时替换它。 | 替换发生在请求字体之后；它不会重新定义主题的脚本映射。 |
| 字体回退 | 为所选字体未包含的字形提供支持，通常针对特定 Unicode 区块。 | 填补缺失的字形覆盖；不会更改存储的主题映射。 |

有关后两种机制的更多信息，请参阅[字体替换](/slides/zh/php-java/font-substitution/)和[回退字体](/slides/zh/php-java/fallback-font/)。

在[Presentation::getMasterTheme]({{guid}})中更改映射仅影响其有效格式仍依赖该主题的内容。当可见结果未遵循演示文稿级别映射时，请检查主母版、布局或幻灯片的主题覆盖，或检查是否使用了显式分配的字体。

## **使映射字体可用并验证结果**

脚本映射仅存储字体族名称；它不会安装或加载相应的字体文件。为实现一致的渲染和导出，必须在环境中安装每个映射字体，或通过自定义来源（例如[FontsLoader::loadExternalFonts]({{guid}})或[LoadOptions::getDocumentLevelFontSources]({{guid}})）提供给 Aspose.Slides。请参阅[自定义字体](/slides/zh/php-java/custom-font/)了解可用的加载选项。

验证已保存的映射只能确认主题定义被保留。它不证明字体是否可用、是否包含所有必需字形或是否产生预期布局。请为每个必需的书写系统渲染代表性文本为图像或 PDF 并检查输出。这可以在演示文稿分发前捕获缺失字体、不完整的字形覆盖、回退行为以及布局变化。请参阅[PowerPoint 演示文稿转换](/slides/zh/php-java/convert-powerpoint/)获取渲染和导出示例。

## **常见问题**

**当脚本未映射时，`Fonts::getScriptFont`返回什么？**

[Fonts::getScriptFont]({{guid}})在请求的脚本映射未在该主要或次要字体集合中定义时返回`null`。

**当脚本已存在时，`Fonts::setScriptFont`会添加第二个映射吗？**

不会。[Fonts::setScriptFont]({{guid}})在缺失时创建映射，在相同脚本标签已存在时替换已映射的字体族。

**为什么更改主题映射后某些文本没有变化？**

该文本可能已经显式分配了字体、通过覆盖继承了不同的主题，或在渲染时受到替换或回退的影响。演示文稿级别的脚本映射仅控制其有效格式仍引用该主题字体集合的文本。

**保存并重新打开是否足以验证多语言输出？**

不足。重新打开只能验证主题数据的持久性。还必须渲染每个必需书写系统的代表性文本，以确认映射字体可用且包含必要字形。