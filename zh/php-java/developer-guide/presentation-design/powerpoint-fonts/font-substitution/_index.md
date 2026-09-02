---
title: 在 PHP 中配置演示文稿的字体替换
linktitle: 字体替换
type: docs
weight: 70
url: /zh/php-java/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替换
- 替换字体
- 字体更换
- 替代规则
- 更换规则
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在通过 Java 为 PHP 的 Aspose.Slides 渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，配置字体替换规则并检查被替换的字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在呈现或转换演示文稿时使用可用的字体来代替无法访问的字体。替换会影响渲染后的输出；但不会更改分配给演示文稿内容的字体。

您可以在特定字体不可用时定义要使用的字体，并且可以检查 Aspose.Slides 在渲染过程中将进行的替换。这有助于在安装了不同字体的环境之间保持输出的一致性。

## **获取字体替换**

使用 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/getsubstitutions/) 方法来确定在渲染演示文稿时将被替换的字体。该方法返回 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsubstitutioninfo/) 对象，标识原始字体和替代字体的名称。

以下 PHP 示例列出了演示文稿的所有字体替换：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **获取选定幻灯片的字体替换**

使用带有 `int[] slides` 参数的 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/getsubstitutions/) 重载，仅检查渲染特定幻灯片所需的替换。当您只渲染或导出演示文稿的一部分、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异时，此功能非常有用。

`slides` 数组包含基于 1 的幻灯片索引：`1` 表示第一张幻灯片。相比之下，[Presentation::getSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSlides) 集合访问器使用基于 0 的索引，因此相同的幻灯片可以通过 `$presentation->getSlides()->get_Item(0)` 访问。构建数组时请牢记此差异，以避免出现 off‑by‑one 错误。

通过 [Presentation::getFontsManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getFontsManager) 方法调用该重载。它仅返回在渲染所选幻灯片期间确定的替换。每个结果都是一个包含原始字体和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsubstitutioninfo/) 对象。结果反映了当前的字体环境、已配置的回退规则、存储在 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsubstrulecollection/) 中的替换规则以及 [externally loaded fonts](/slides/zh/php-java/custom-font/)。

同一替换可能被多个选定幻灯片所需要。在创建字体清单或预检报告时请对结果去重。以下示例报告每个返回的替换，然后创建唯一字体映射的排序列表：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/) 类提供了这两种重载。根据渲染操作的范围选择使用：

| 重载 | 使用场景 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | 您需要为整个演示文稿获取替换。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | 您需要为选定范围、增量检查或部分导出获取替换。 |

## **设置字体替换规则**

指定当源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsubstcondition/) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsubstrule/)。  
4. 将该规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsubstrulecollection/)。  
5. 通过调用 [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 方法分配该集合。  
6. 渲染或转换演示文稿。

以下 PHP 示例在 `SomeRareFont` 不可用时将 `Arial` 替代为 `SomeRareFont`，随后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
若要对整个演示文稿使用的字体进行无条件更改，请参阅 [Font Replacement](/slides/zh/php-java/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替换规则是渲染和转换期间使用的标准字体选择过程的一部分。当 Aspose.Slides 能够使用规则指定的可用字体替换不可访问的字体时，它们适用于普通文本。

Office Math 公式还有额外要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算并渲染公式布局。将 **Cambria Math** 替换为其他数学字体（例如 **STIX Two Math**）的规则无法满足此需求，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装该字体或将其作为 [external font](/slides/zh/php-java/custom-font/) 加载。

此限制仅适用于公式布局。上述替换规则仍然适用于普通演示文稿文本。

## **常见问题**

**什么是字体替换和字体替代之间的区别？**

[Font replacement](/slides/zh/php-java/font-replacement/) 会在整个演示文稿中有意将一种字体更改为另一种字体。字体替代则在满足配置条件（例如原始字体不可用）时为渲染输出选择字体。

**替代规则何时生效？**

规则参与渲染和转换期间的 [font selection sequence](/slides/zh/php-java/font-selection-sequence/)。使用 `WhenInaccessible` 时，仅在 Aspose.Slides 无法访问源字体时才使用该规则。

**当字体缺失且未配置替代规则会怎样？**

Aspose.Slides 会根据其字体选择过程选择最接近的可用字体。结果取决于运行时环境中可供使用的字体。

**我可以加载外部字体以避免替代吗？**

可以。您可以 [load external fonts](/slides/zh/php-java/custom-font/) 使 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 是否随库分发字体？**

不。您需自行提供字体并遵守其许可证。

**替代结果会在 Windows、Linux 和 macOS 之间不同吗？**

会。不同操作系统的已安装字体和字体搜索位置各不相同，某台机器可用的字体在另一台机器上可能需要替代。

**如何在批量转换中保持字体选择的一致性？**

在每台机器或容器上使用相同的字体文件和版本，[load required external fonts](/slides/zh/php-java/custom-font/)，并在许可允许的情况下 [embed fonts](/slides/zh/php-java/embedded-font/)。还可以在导出前调用 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/getsubstitutions/) 以识别意外的替代。