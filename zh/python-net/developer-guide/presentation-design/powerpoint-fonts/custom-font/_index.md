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
description: "通过 .NET 使用 Aspose.Slides for Python 将自定义字体嵌入 PowerPoint 幻灯片，以保持演示文稿在任何设备上都清晰一致。"
---

## **概述**

Aspose.Slides for Python 允许您在运行时提供自定义字体，即使所需字体未安装在主机系统上，演示文稿也能正确渲染。在导出为 PDF 或图像时，您可以提供字体文件夹或内存中的字体数据，以保留文本布局、字形度量和排版。这使得服务器端渲染在不同环境下保持可预测，消除对操作系统级别字体的依赖，防止出现不希望的回退或重新换行。本文展示了如何注册字体来源。

Aspose.Slides 允许您使用 `load_external_font` 和 `load_external_fonts` 方法从 [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) 类加载以下字体：

- TrueType (.ttf) 和 TrueType Collection (.ttc) 字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
- OpenType (.otf) 字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

## **加载自定义字体**

Aspose.Slides 允许您加载字体以渲染演示文稿，而无需安装它们。字体从自定义目录加载。

1. 从 [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) 调用 `load_external_fonts` 方法。
2. 加载要渲染的演示文稿。
3. 在 [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) 类中清除缓存。

```python
import aspose.slides as slides

# 用于搜索字体的文件夹。
font_folders = [ "C:\\MyFonts", "D:\\MyAdditionalFonts" ]

# 从自定义目录加载字体。
slides.FontsLoader.load_external_fonts(font_folders)

# 渲染演示文稿。
with slides.Presentation("Fonts.pptx") as presentation:
    presentation.save("Fonts_out.pdf", slides.export.SaveFormat.PDF)

# 清除字体缓存。
slides.FontsLoader.clear_cache()
```


## **获取自定义字体文件夹**

Aspose.Slides 提供 `get_font_folders` 方法以检索字体文件夹。它返回通过 `load_external_fonts` 添加的文件夹以及系统字体文件夹。

```python
import aspose.slides as slides

# 此调用返回检查字体文件的文件夹。
# 这些文件夹包括通过 load_external_fonts 方法添加的文件夹以及系统字体文件夹。
font_folders = slides.FontsLoader.get_font_folders()
```


## **为演示文稿指定自定义字体**

Aspose.Slides 提供 `document_level_font_sources` 属性，允许您为演示文稿指定要使用的外部字体。

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
    # 在演示文稿中工作。
    # CustomFont1、CustomFont2，以及来自 assets\\fonts 和 global\\fonts 文件夹（及其子文件夹）的字体均可在演示文稿中使用。
    # ...
    print(len(presentation.slides))
```


## **从二进制数据加载外部字体**

Aspose.Slides 提供 `load_external_font` 方法，以从二进制数据加载外部字体。

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

**自定义字体会影响所有格式（PDF、PNG、SVG、HTML）的导出吗？**

是的。连接的字体在所有导出格式中都由渲染器使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**

不会。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体包含在演示文稿文件中，必须使用显式的 [嵌入功能](/slides/zh/python-net/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**

可以。配置 [字体替换](/slides/zh/python-net/font-substitution/)、[替换规则](/slides/zh/python-net/font-replacement/) 和 [回退集](/slides/zh/python-net/fallback-font/) 可精确定义在请求的字形缺失时使用哪个字体。

**我可以在 Linux/Docker 容器中使用字体而无需系统范围安装吗？**

可以。指向您自己的字体文件夹或从字节数组加载字体。这消除了容器镜像中对系统字体目录的任何依赖。

**关于授权——我可以在没有限制的情况下嵌入任何自定义字体吗？**

您需自行负责字体授权合规。授权条款各不相同，有些授权禁止嵌入或商业使用。在分发输出之前，请务必查阅字体的 EULA。