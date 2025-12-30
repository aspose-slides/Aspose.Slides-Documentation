---
title: 在 Python 中自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/python-net/custom-font/
keywords:
- 字体
- 自定义字体
- 外部字体
- 加载字体
- 管理字体
- 字体文件夹
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "通过 Aspose.Slides for Python（基于 .NET）在 PowerPoint 幻灯片中嵌入自定义字体，以确保您的演示文稿在任何设备上都保持清晰一致。"
---

## **概述**

Aspose.Slides for Python 允许您在运行时提供自定义字体，从而即使在主机系统未安装所需字体，演示文稿也能正确渲染。导出为 PDF 或图像时，您可以提供字体文件夹或内存中的字体数据，以保留文本布局、字形度量和排版。这使得服务器端渲染在不同环境下保持可预测，消除操作系统级别的字体依赖，并防止不希望的回退或重排。本文展示了如何注册字体来源。

Aspose.Slides 通过 `load_external_font` 和 `load_external_fonts` 方法，使用 [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) 类加载以下字体：

- TrueType（.ttf）和 TrueType 集合（.ttc）字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
- OpenType（.otf）字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿使用的字体。这会影响导出输出——如 PDF、图像及其他受支持的格式——从而使生成的文档在各环境中保持一致。字体从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。  
2. 调用静态 [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) 方法，从这些文件夹加载字体。  
3. 加载并渲染/导出演示文稿。  
4. 调用 [FontsLoader.clear_cache](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/clear_cache/) 清除字体缓存。

下面的代码示例演示了字体加载过程：
```py
import aspose.slides as slides

# 定义包含自定义字体文件的文件夹。
font_folders = [ external_font_folder1, external_font_folder2 ]

# 从指定的文件夹加载自定义字体。
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # 使用已加载的字体渲染/导出演示文稿（例如 PDF、图像或其他格式）。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# 工作完成后清除字体缓存。
slides.FontsLoader.clear_cache()
```


{{% alert color="info" title="注意" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) 会向字体搜索路径添加额外的文件夹，但不会改变字体初始化顺序。  
字体按以下顺序初始化：

1. 默认的操作系统字体路径。  
1. 通过 [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) 加载的路径。  
{{%/alert %}}

## **获取自定义字体文件夹**

Aspose.Slides 提供 `get_font_folders` 方法来检索字体文件夹。它返回通过 `load_external_fonts` 添加的文件夹以及系统字体文件夹。

下面的 Python 代码展示了如何使用 `get_font_folders`：
```python
import aspose.slides as slides

# 此调用返回检查字体文件的文件夹。
# 这些包括通过 load_external_fonts 方法添加的文件夹以及系统字体文件夹。
font_folders = slides.FontsLoader.get_font_folders()
```


## **为演示文稿指定自定义字体**

Aspose.Slides 提供 `document_level_font_sources` 属性，允许您为演示文稿指定外部字体。

以下 Python 示例演示了如何使用 `document_level_font_sources`：
```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # 对演示文稿进行操作。
    # CustomFont1、CustomFont2 以及来自 assets\fonts 和 global\fonts 文件夹（及其子文件夹）的字体可供演示文稿使用。
    # ...
    print(len(presentation.slides))
```


## **从二进制数据加载外部字体**

Aspose.Slides 提供 `load_external_font` 方法，从二进制数据加载外部字体。

以下 Python 示例演示了从字节数组加载字体：
```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# 从字节数组加载外部字体。
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # 外部字体在此演示文稿实例的整个生命周期内可用。
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **常见问题**

**自定义字体会影响所有导出格式（PDF、PNG、SVG、HTML）吗？**  
是的。已连接的字体将在所有导出格式的渲染过程中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**  
不会。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的 [嵌入功能](/slides/zh/python-net/embedded-font/)。

**当自定义字体缺少某些字形时，能否控制回退行为？**  
可以。配置 [字体替代](/slides/zh/python-net/font-substitution/)、[替换规则](/slides/zh/python-net/font-replacement/) 和 [回退集](/slides/zh/python-net/fallback-font/) 可精确定义在请求的字形缺失时使用哪种字体。

**能否在 Linux/Docker 容器中使用字体而无需系统范围安装？**  
可以。指向您自己的字体文件夹或从字节数组加载字体即可，这样就消除了容器镜像对系统字体目录的依赖。

**关于许可证——是否可以在没有限制的情况下嵌入任何自定义字体？**  
您必须自行负责字体许可证的合规性。许可证条款各不相同，有些禁止嵌入或商业使用。分发输出前请始终查阅字体的最终用户许可协议（EULA）。