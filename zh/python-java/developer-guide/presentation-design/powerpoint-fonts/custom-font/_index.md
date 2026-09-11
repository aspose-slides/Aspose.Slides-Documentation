---
title: 在 Python 中通过 Java 定制 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/python-java/custom-font/
keywords:
- 字体
- 自定义字体
- 外部字体
- 加载字体
- 管理字体
- 字体文件夹
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 定制 PowerPoint 幻灯片中的字体，使您的演示在任何设备上都保持清晰一致。"
---
## **概述**

Aspose.Slides 允许您在演示文稿中使用自定义字体，而无需在操作系统上安装它们。您可以从自定义文件夹加载字体，通过文档级字体源为特定演示文稿提供字体，或直接从二进制数据加载外部字体。

加载的字体会在渲染或导出演示文稿时使用，例如导出为 PDF、图像以及其他受支持的格式。这有助于在不同环境中保持演示文稿输出的一致性。本文还说明了如何检查 Aspose.Slides 使用的字体文件夹以及在使用外部字体后如何清除字体缓存。

为渲染注册自定义字体与将字体嵌入 PPTX 文件是分开的。如果必须将字体存储在演示文稿内部，请显式使用字体嵌入功能。

演示文稿主题可以为各个书写系统引用不同的字体系列。这些映射仅存储字体名称，但不安装或加载字体文件。请参阅[Script-Specific Theme Fonts](/slides/zh/python-java/script-specific-font-mappings/)以管理映射，并使用下面的加载选项使引用的字体可用于一致的渲染。

{{% alert color="info" title="注意" %}}
Aspose.Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#loadExternalFonts) 方法加载这些字体：

* TrueType（.ttf）和 TrueType Collection（.ttc）字体。参见[TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType（.otf）字体。参见[OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不在系统上安装的情况下加载演示文稿中使用的字体。这会影响导出输出——例如 PDF、图像和其他受支持的格式——从而使生成的文档在各环境中保持一致。字体从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#loadExternalFonts) 方法从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#clearCache) 清除字体缓存。

以下代码示例演示了字体加载过程：

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# 定义包含自定义字体文件的文件夹。
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# 从指定的文件夹加载自定义字体。
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # 使用已加载的字体渲染/导出演示文稿。
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # 完成工作后清除字体缓存。
    FontsLoader.clearCache()
```

{{% alert color="info" title="注意" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#loadExternalFonts) 会向字体搜索路径添加额外的文件夹，但不会改变字体初始化顺序。字体按照以下顺序初始化：

1. 默认的操作系统字体路径。
1. 通过 [FontsLoader](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/) 加载的路径。
{{%/alert %}}

## **获取自定义字体文件夹**

Aspose.Slides 提供了 [getFontFolders](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#getFontFolders) 方法，帮助您查找字体文件夹。该方法返回通过 [loadExternalFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#loadExternalFonts) 方法添加的文件夹以及系统字体文件夹。

下面的 Python 代码展示了如何使用 [getFontFolders](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# 获取通过 loadExternalFonts 添加的文件夹以及系统字体文件夹。
font_folders = FontsLoader.getFontFolders()
```

## **为演示文稿指定使用的自定义字体**

Aspose.Slides 提供了 [getDocumentLevelFontSources](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) 方法，允许您指定将在演示文稿中使用的外部字体。

下面的 Python 代码展示了如何使用 [getDocumentLevelFontSources](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) 方法：

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # 对演示文稿进行操作。
    # CustomFont1、CustomFont2，以及来自 assets/fonts 和 global/fonts 的字体
    # 以及它们的子文件夹在演示文稿中可用。
    pass
finally:
    presentation.dispose()
```

## **外部管理字体**

Aspose.Slides 提供了 [loadExternalFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#loadExternalFont) 方法，允许您从二进制数据加载外部字体。

下面的 Python 代码演示了字节数组字体加载过程：

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # 外部字体在演示文稿的整个生命周期内加载。
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **常见问题**

**自定义字体是否会影响导出到所有格式（PDF、PNG、SVG、HTML）？**

是的。已连接的字体会被渲染器在所有导出格式中使用。

**自定义字体是否会自动嵌入生成的 PPTX 中？**

否。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起保存，必须显式使用[嵌入功能](/slides/zh/python-java/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**

可以。通过配置[字体替代](/slides/zh/python-java/font-substitution/)、[替换规则](/slides/zh/python-java/font-replacement/)和[回退集](/slides/zh/python-java/fallback-font/)，可精确定义在请求的字形缺失时使用哪种字体。

**我能在 Linux/Docker 容器中使用字体而无需系统范围安装吗？**

可以。指向您自己的字体文件夹或从字节数组加载字体。这消除了容器镜像对系统字体目录的任何依赖。

**关于许可证——我可以在没有限制的情况下嵌入任何自定义字体吗？**

您需自行负责字体许可证的合规性。许可证条款各不相同；有些许可证禁止嵌入或商业使用。始终在分发输出之前检查字体的最终用户许可协议 (EULA)。