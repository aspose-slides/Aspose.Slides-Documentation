---
title: 在 Android 上管理脚本特定主题字体
linktitle: 脚本特定主题字体
type: docs
weight: 15
url: /zh/androidjava/script-specific-font-mappings/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（通过 Java）检查、添加、替换和删除 PowerPoint 主题中的脚本特定字体映射。"
---
## **概述**

演示文稿主题可以为不同的书写系统选择不同的字体系列。这使得使用主题字体的多语言文本能够遵循统一的字体方案，同时为西里尔文、阿拉伯文、日语、格鲁吉亚文、塔纳文以及其他脚本使用合适的字体。

主题的[IFontScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontscheme/)包含一个主要字体集合，通常用于标题，以及一个次要字体集合，通常用于正文。除了它们的拉丁文和东亚字体设置外，这两个集合还通过[IFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifonts/)接口公开从书写系统标签到字体系列名称的映射。

本文展示了如何检查和修改演示文稿母版主题中的这些映射，并验证更改在保存‑重新加载周期后仍然存在。

## **了解脚本标签**

脚本字体方法使用四字符 BCP 47 脚本子标签来标识书写系统。常见值包括：

| 脚本标签 | 书写系统 |
|---|---|
| `Cyrl` | 西里尔文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 简体中文 |
| `Jpan` | 日语 |
| `Geor` | 格鲁吉亚文 |
| `Thaa` | 塔纳文 |

这些映射属于主题字体方案，而不是单个文本片段。演示文稿可以为主要和次要集合定义不同的映射，也可以对某些脚本省略映射。

## **访问并检查脚本字体映射**

使用[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getMasterTheme--)获取演示文稿级别的主题。[IFontScheme.getMajor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontscheme/#getMajor--)和[IFontScheme.getMinor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontscheme/#getMinor--)方法返回两个[IFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifonts/)集合。

调用[IFonts.getScriptFontMap](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fonts/#getScriptFontMap--)检索集合中的所有映射。要查询单个书写系统，使用[IFonts.getScriptFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)并传入其脚本标签。若该集合未定义请求的映射，`getScriptFont` 返回 `null`。

## **修改映射并验证持久性**

使用[IFonts.setScriptFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)创建映射或替换当前的字体系列。使用[IFonts.removeScriptFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-)删除映射。

以下端到端示例读取所有现有的主要和次要映射，查找日语主要字体，修改西里尔文主要字体，移除塔纳文次要映射，保存演示文稿并重新打开以验证两项更改。为使移除步骤独立于初始主题，示例仅在未定义塔纳文映射时才创建该映射。

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

验证使用与普通查找相同的 `null` 行为：移除并保存后，`getScriptFont("Thaa")` 对次要集合返回 `null`。

## **区分主题映射与其他字体设置**

脚本特定的主题映射参与字体选择，但它们解决的是与直接文本格式化、替换和回退不同的问题：

| 机制 | 目的 | 更改主题映射的影响 |
|---|---|---|
| 脚本特定的主题字体映射 | 为特定书写系统选择主要或次要主题字体。 | 仍使用相应主题字体的文本可以解析到新的映射字体系列。 |
| 显式分配给文本段的字体 | 将请求的字体系列固定在该段落上，而不依赖主题。 | 该段落可能保持不变，因为直接格式化覆盖了主题选择。 |
| 字体替换 | 当请求的字体不可用或匹配替换规则时替换字体。 | 替换在字体请求之后执行；它不会重新定义主题的脚本映射。 |
| 字体回退 | 为所选字体未包含的字形提供补充，通常针对特定 Unicode 范围。 | 它填补缺失的字形覆盖；不会更改已存储的主题映射。 |

有关后两种机制的更多信息，请参阅[Font Substitution](/slides/zh/androidjava/font-substitution/)和[Fallback Fonts](/slides/zh/androidjava/fallback-font/)。

在[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getMasterTheme--) 中更改映射仅影响仍依赖该主题的有效格式化内容。当可见结果未遵循演示文稿级映射时，请检查母版、布局或幻灯片的主题覆盖，或查看是否使用了显式分配的字体。

## **使映射的字体可用并验证结果**

脚本映射仅存储字体系列名称；它不会安装或加载相应的字体文件。为实现一致的渲染和导出，必须在环境中安装每个映射的字体，或通过自定义来源如[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)或[LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) 将字体提供给 Aspose.Slides。有关可用加载选项，请参阅[Custom Fonts](/slides/zh/androidjava/custom-font/)。

验证已保存的映射仅能确认主题定义被保留，不能证明字体可用、包含所有必需字形或产生预期布局。请为每个必需的书写系统渲染代表性文本为图像或 PDF，并检查输出。这可以在演示文稿分发前捕获缺失字体、字形覆盖不足、回退行为以及布局变化。有关渲染和导出示例，请参阅[Convert PowerPoint Presentations](/slides/zh/androidjava/convert-powerpoint/)。

## **常见问题**

**当脚本未映射时，`getScriptFont` 返回什么？**  
[IFonts.getScriptFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) 在请求的脚本映射未在该主要或次要字体集合中定义时返回 `null`。

**当脚本已存在时，`setScriptFont` 会添加第二个映射吗？**  
不会。[IFonts.setScriptFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) 在缺失时创建映射，若相同脚本标签已存在则替换已映射的字体系列。

**为何更改主题映射后某些文本未变化？**  
文本可能已显式分配了字体、通过覆盖继承了不同的主题，或在渲染时受到了替换或回退的影响。演示文稿级的脚本映射仅控制仍引用该主题字体集合的文本。

**保存并重新打开是否足以验证多语言输出？**  
不足。重新打开只能验证主题数据的持久性。还需要渲染每个必需书写系统的代表性文本，以确认映射的字体可用并包含必要的字形。