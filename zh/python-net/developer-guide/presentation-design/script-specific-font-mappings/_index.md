---
title: 在 Python 中管理脚本特定的主题字体
linktitle: 脚本特定主题字体
type: docs
weight: 15
url: /zh/python-net/script-specific-font-mappings/
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python（基于 .NET）检查、添加、替换和删除 PowerPoint 主题中的脚本特定字体映射。"
---
## **概览**

演示文稿主题可以为不同的书写系统选择不同的字体族。这使得仍然使用主题字体的多语言文本能够遵循统一的字体方案，同时为西里尔文、阿拉伯文、日文、格鲁吉亚文、Thaana 文等脚本使用合适的字体。

主题的[FontScheme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/fontscheme/)包含一个主要字体集合（通常用于标题）和一个次要字体集合（通常用于正文）。除了它们的拉丁文和东亚字体属性外，这两个集合还通过[Fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fonts/)类暴露书写系统标签到字体族名称的映射。

本文展示了如何检查和修改演示文稿主主题中的这些映射，并验证更改在保存并重新加载后仍然有效。

## **了解脚本标签**

脚本字体方法使用四字母 BCP 47 脚本子标签来标识书写系统。常见值包括：

| 脚本标签 | 书写系统 |
|---|---|
| `Cyrl` | 西里尔文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 简体中文 |
| `Jpan` | 日文 |
| `Geor` | 格鲁吉亚文 |
| `Thaa` | Thaana |

这些映射属于主题字体方案，而不是单个文本片段。演示文稿可以为主要和次要集合定义不同的映射，也可以省略某些脚本的映射。

## **访问并检查脚本字体映射**

使用[Presentation.master_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/master_theme/)来访问演示文稿级别的主题。[FontScheme.major](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/fontscheme/major/)和[FontScheme.minor](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/fontscheme/minor/)属性返回两个[Fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fonts/)集合。

调用[Fonts.get_script_font_map](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fonts/get_script_font_map/)可检索集合中的所有映射。要查询单个书写系统，请使用其脚本标签调用[Fonts.get_script_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fonts/get_script_font/)。当该集合未定义请求的映射时，`get_script_font`返回`None`。

## **修改映射并验证持久性**

使用[Fonts.set_script_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fonts/set_script_font/)创建映射或替换其当前字体族。使用[Fonts.remove_script_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fonts/remove_script_font/)删除映射。

以下端到端示例读取所有现有的主要和次要映射，查找日文主要字体，修改西里尔文主要字体，删除 Thaana 次要映射，保存演示文稿并重新打开以验证两项更改。为了使删除步骤独立于初始主题，示例仅在未定义 Thaana 映射时才创建该映射。

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

验证使用与普通查找相同的`None`行为：删除并保存后，`get_script_font("Thaa")`在次要集合中返回`None`。

## **区分主题映射和其他字体设置**

脚本特定的主题映射参与字体选择，但它们解决的问题不同于直接文本格式化、替换和回退：

| 机制 | 目的 | 更改主题映射的影响 |
|---|---|---|
| 脚本特定的主题字体映射 | 为特定书写系统选择主要或次要主题字体。 | 仍使用相应主题字体的文本可以解析为新的映射字体族。 |
| 明确分配给文本片段的字体 | 将请求的字体族固定在该片段上，而不依赖主题。 | 由于直接格式化覆盖了主题选择，文本可能保持不变。 |
| 字体替换 | 当请求的字体不可用或符合替换规则时替换该字体。 | 替换在请求字体之后发生；它不会重新定义主题的脚本映射。 |
| 字体回退 | 为选定字体未包含的字形提供补充，通常针对特定 Unicode 范围。 | 它填补缺失的字形覆盖；不会更改存储的主题映射。 |

有关后两种机制的更多信息，请参阅[Font Substitution](/slides/zh/python-net/font-substitution/)和[Fallback Fonts](/slides/zh/python-net/fallback-font/)。

在[Presentation.master_theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/master_theme/)中更改映射仅影响仍依赖该主题的有效格式化内容。当可见结果未遵循演示文稿级别的映射时，请检查母版、布局或幻灯片层级的主题覆盖，或检查是否使用了显式分配的字体。

## **确保映射的字体可用并验证结果**

脚本映射只存储字体族名称；它并不安装或加载对应的字体文件。为获得一致的渲染和导出，所有映射的字体必须在环境中安装，或通过自定义来源提供给 Aspose.Slides，例如[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsloader/load_external_fonts/)或[LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/document_level_font_sources/)。请参阅[Custom Fonts](/slides/zh/python-net/custom-font/)了解可用的加载选项。

验证已保存的映射只能确认主题定义被保留。它并不证明字体可用、包含所有必需字形或产生预期布局。请为每个必需的书写系统渲染代表性文本为图像或 PDF，并检查输出。这可以在演示文稿分发前捕获缺失字体、字形覆盖不完整、回退行为以及布局变化。参见[Convert PowerPoint Presentations](/slides/zh/python-net/convert-powerpoint/)获取渲染和导出示例。

## **FAQ**

**当脚本未映射时，`get_script_font` 返回什么？**

[Fonts.get_script_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fonts/get_script_font/) 在请求的脚本映射未在相应的主要或次要字体集合中定义时返回 `None`。

**当脚本已存在时，`set_script_font` 会添加第二个映射吗？**

不会。[Fonts.set_script_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fonts/set_script_font/) 在缺少映射时创建它，若相同脚本标签已存在则替换已映射的字体族。

**为什么更改主题映射后某些文本没有变化？**

文本可能已经显式分配了字体、通过覆盖继承了不同的主题，或在渲染时受到替换或回退的影响。演示文稿级别的脚本映射仅控制仍引用该主题字体集合的文本的有效格式化。

**保存并重新打开是否足以验证多语言输出？**

不足。重新打开只能验证主题数据的持久性。同样需要渲染每个必需书写系统的代表性文本，以确认映射的字体可用且包含必要的字形。