---
title: 在 Python（通过 Java）中管理脚本特定的主题字体
linktitle: 脚本特定的主题字体
type: docs
weight: 15
url: /zh/python-java/script-specific-font-mappings/
keywords:
- 脚本特定字体
- 主题字体映射
- 多语言演示文稿
- 书写系统
- 西里尔字体
- 阿拉伯字体
- 日文字体
- 格鲁吉亚字体
- Thaana 字体
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "检查、添加、替换和删除 PowerPoint 主题中的脚本特定字体映射，使用 Aspose.Slides for Python via Java."
---
## **概述**

演示文稿主题可以为不同的书写系统选择不同的字体系列。这使得仍使用主题字体的多语言文本能够遵循统一的字体方案，同时为西里尔文、阿拉伯文、日文、格鲁吉亚文、Thaana 文和其他脚本使用合适的字体。

主题的[FontScheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontscheme/)包含一个主要字体集合，通常用于标题，以及一个次要字体集合，通常用于正文。除了它们的拉丁和东亚字体设置外，这两个集合还通过[Fonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fonts/)类公开从书写系统标签到字体系列名称的映射。

本文展示了如何检查和修改演示文稿母版主题中的这些映射，并验证更改在保存并重新加载的循环中能够保留。

## **了解脚本标签**

脚本字体方法使用四字母 BCP 47 脚本子标签来标识书写系统。常见的取值包括：

| 脚本标签 | 书写系统 |
|---|---|
| `Cyrl` | 西里尔文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 简体中文 |
| `Jpan` | 日文 |
| `Geor` | 格鲁吉亚文 |
| `Thaa` | Thaana |

这些映射属于主题字体方案，而不是单独的文本段落。演示文稿可以为主要和次要集合定义不同的映射，也可以对某些脚本省略映射。

## **访问和检查脚本字体映射**

使用[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasterTheme)访问演示文稿级别的主题。[FontScheme.getMajor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontscheme/#getMajor)和[FontScheme.getMinor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontscheme/#getMinor)方法返回两个[Fonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fonts/)集合。

调用[Fonts.getScriptFontMap](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fonts/#getScriptFontMap)可检索集合中的所有映射。要查找单个书写系统，请使用其脚本标签调用[Fonts.getScriptFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fonts/#getScriptFont)。当该集合未定义请求的映射时，`getScriptFont`返回`None`。

## **修改映射并验证持久性**

使用[Fonts.setScriptFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fonts/#setScriptFont)创建映射或替换其当前的字体系列。使用[Fonts.removeScriptFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fonts/#removeScriptFont)删除映射。

下面的端到端示例读取所有现有的主要和次要映射，查找日文主要字体，修改西里尔文主要字体，删除 Thaana 次要映射，保存演示文稿并重新打开以验证两项更改。为了使删除步骤与初始主题无关，示例仅在尚未定义 Thaana 映射时先创建一个 Thaana 映射。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

验证使用与普通查找相同的 `None` 行为：删除后保存时，`getScriptFont(\"Thaa\")`在次要集合中返回 `None`。

## **区分主题映射与其他字体设置**

脚本特定的主题映射参与字体选择，但它们解决的是与直接文本格式化、替换和回退不同的问题：

| 机制 | 目的 | 更改主题映射的效果 |
|---|---|---|
| 脚本特定的主题字体映射 | 为某个书写系统选择主要或次要主题字体。 | 仍使用相应主题字体的文本可以解析为新的映射字体系列。 |
| 显式分配给文本段落的字体 | 在该段落上固定请求的字体系列，而不是依赖主题。 | 该段落可能保持不变，因为其直接格式覆盖了主题选择。 |
| 字体替换 | 当请求的字体不可用或满足替换规则时，替换请求的字体。 | 它在请求字体之后起作用；不会重新定义主题的脚本映射。 |
| 字体回退 | 提供所选字体不包含的字形，通常针对特定的 Unicode 范围。 | 它填补缺失的字形覆盖；不会更改已存储的主题映射。 |

有关后两种机制的更多信息，请参阅[Font Substitution](/slides/zh/python-java/font-substitution/)和[Fallback Fonts](/slides/zh/python-java/fallback-font/)。

在[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getMasterTheme)中更改映射仅影响仍依赖于该主题的有效格式的内容。文本也可能从母版、布局或幻灯片继承主题覆盖，或使用显式分配的字体。当可见结果未遵循演示文稿级别的映射时，请检查这些层级。

## **使映射的字体可用并验证结果**

脚本映射仅存储字体系列名称；它不会安装或加载对应的字体文件。为实现一致的渲染和导出，所有映射的字体必须在环境中安装，或通过自定义来源提供给 Aspose.Slides，例如[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#loadExternalFonts)或[LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources)。请参阅[Custom Fonts](/slides/zh/python-java/custom-font/)了解可用的加载选项。

验证已保存的映射仅确认主题定义已被保留。它并不能证明字体可用、包含所有必需字形或产生预期的布局。将每个必需书写系统的代表性文本渲染为图像或 PDF 并检查输出。这可以在演示文稿分发之前捕获缺失的字体、字形覆盖不完整、回退行为以及布局变化。请参阅[Convert PowerPoint Presentations](/slides/zh/python-java/convert-powerpoint/)了解渲染和导出示例。

## **常见问题**

**当脚本未映射时，`getScriptFont` 返回什么？**

[Fonts.getScriptFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fonts/#getScriptFont)在该主要或次要字体集合中未定义请求的脚本映射时返回 `None`。

**当脚本已存在时，`setScriptFont` 会添加第二个映射吗？**

不会。[Fonts.setScriptFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fonts/#setScriptFont)在缺失时创建映射，在相同脚本标签已存在时替换映射的字体系列。

**为什么更改主题映射后某些文本没有变化？**

文本可能已经显式分配了字体、通过覆盖继承了不同的主题，或在渲染期间受到替换或回退的影响。演示文稿级别的脚本映射仅控制仍引用该主题字体集合的有效格式文本。

**仅保存并重新打开是否足以验证多语言输出？**

不是。重新打开仅验证主题数据的持久性。还需渲染每个必需书写系统的代表性文本，以确认映射的字体可用且包含必要的字形。