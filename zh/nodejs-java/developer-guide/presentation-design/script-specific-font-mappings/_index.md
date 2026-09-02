---
title: 管理 JavaScript 中的脚本特定主题字体
linktitle: 脚本特定主题字体
type: docs
weight: 15
url: /zh/nodejs-java/script-specific-font-mappings/
keywords:
- 脚本特定字体
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 检查、添加、替换和删除 PowerPoint 主题中的脚本特定字体映射。"
---
## **概述**

演示文稿主题可以为不同的书写系统选择不同的字体族。这使得使用主题字体的多语言文本能够在遵循统一字体方案的同时，为西里尔文、阿拉伯文、日文、格鲁吉亚文、塔纳文等脚本使用合适的字体。

主题的[FontScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontscheme/)包含一个主要字体集合（通常用于标题）和一个次要字体集合（通常用于正文）。除了它们的拉丁和东亚字体设置外，这两个集合还通过[Fonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fonts/)类公开从书写系统标签到字体族名称的映射。

本文展示了如何检查和修改演示文稿母版主题中的这些映射，并验证更改在保存‑重新加载循环中能够持久化。

## **了解脚本标签**

脚本字体方法使用四字符 BCP 47 脚本子标签来标识书写系统。常见值包括：

| 脚本标签 | 书写系统 |
|---|---|
| `Cyrl` | 西里尔文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 简体中文 |
| `Jpan` | 日文 |
| `Geor` | 格鲁吉亚文 |
| `Thaa` | 塔纳文 |

这些映射属于主题字体方案，而不是单个文本段落。演示文稿可以为主要和次要集合定义不同的映射，也可以对某些脚本省略映射。

## **访问和检查脚本字体映射**

使用[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getmastertheme/)来访问演示文稿级别的主题。`FontScheme.getMajor`和`FontScheme.getMinor`方法返回两个[Fonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fonts/)集合。

调用`Fonts.getScriptFontMap`以检索集合中的全部映射。要查询单个书写系统，请使用对应的脚本标签调用`Fonts.getScriptFont`。当该集合未定义请求的映射时，`getScriptFont`返回`null`。

## **修改映射并验证持久性**

使用`Fonts.setScriptFont`创建映射或替换当前的字体族。使用`Fonts.removeScriptFont`删除映射。

下面的端到端示例读取所有现有的主要和次要映射，查询日文主要字体，修改西里尔文主要字体，删除塔纳文次要映射，保存演示文稿并重新打开以验证两个更改。为了使删除步骤独立于初始主题，示例仅在未定义塔纳文映射时才创建该映射。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

验证使用与普通查询相同的`null`行为：删除保存后，`getScriptFont("Thaa")`对次要集合返回`null`。

## **区分主题映射与其他字体设置**

脚本特定的主题映射参与字体选择，但它们解决的问题不同于直接的文本格式化、替换和回退：

| 机制 | 目的 | 更改主题映射的影响 |
|---|---|---|
| 脚本特定的主题字体映射 | 为某书写系统选择主要或次要主题字体。 | 仍使用相应主题字体的文本可以解析到新的映射族。 |
| 显式分配给文本段落的字体 | 将请求的字体族固定在该段落上，而不是依赖主题。 | 由于直接格式化覆盖了主题选择，段落可能保持不变。 |
| 字体替换 | 当请求的字体不可用或匹配替换规则时替换该字体。 | 在请求字体之后执行；不会重新定义主题的脚本映射。 |
| 字体回退 | 为所选字体未包含的字形（通常是特定 Unicode 范围）提供字形。 | 填补缺失的字形覆盖；不会更改存储的主题映射。 |

有关后两种机制的更多信息，请参阅[Font Substitution](/slides/zh/nodejs-java/font-substitution/)和[Fallback Fonts](/slides/zh/nodejs-java/fallback-font/)。

在[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getmastertheme/)中更改映射仅影响其有效格式仍依赖该主题的内容。文本也可能从母版、布局或幻灯片继承主题覆盖，或使用显式分配的字体。当可见结果未遵循演示文稿级别映射时，请检查这些层级。

## **使映射字体可用并验证结果**

脚本映射存储的是字体族名称；它不会安装或加载相应的字体文件。为确保一致的渲染和导出，所有映射字体必须已安装在环境中，或通过自定义来源（例如[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)或[LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/)）提供给 Aspose.Slides。有关可用加载选项，请参阅[Custom Fonts](/slides/zh/nodejs-java/custom-font/)。

验证已保存的映射仅确认主题定义已保留，并不表示字体可用、包含所有必需字形或产生预期布局。应对每个必需书写系统的代表性文本进行渲染（生成图像或 PDF），并检查输出。这样可在演示文稿分发前捕获缺失字体、字形覆盖不完整、回退行为及布局变化等问题。请参阅[Convert PowerPoint Presentations](/slides/zh/nodejs-java/convert-powerpoint/)获取渲染和导出示例。

## **常见问题**

**当脚本未映射时，`getScriptFont` 返回什么？**

[Fonts.getScriptFont](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fonts/)在该主要或次要字体集合中未定义请求的脚本映射时返回`null`。

**`setScriptFont` 在脚本已存在时会添加第二个映射吗？**

不会。[Fonts.setScriptFont](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fonts/)在缺失时创建映射，若同一脚本标签已存在则替换已映射的字体族。

**为何更改主题映射后某些文本未改变？**

该文本可能显式分配了字体、通过覆盖继承了不同的主题，或在渲染时受到替换或回退的影响。演示文稿级别的脚本映射仅控制其有效格式仍引用该主题字体集合的文本。

**保存并重新打开是否足以验证多语言输出？**

不足。重新打开只能验证主题数据的持久性。还需对每个必需书写系统的代表性文本进行渲染，以确认映射字体可用且包含必要字形。