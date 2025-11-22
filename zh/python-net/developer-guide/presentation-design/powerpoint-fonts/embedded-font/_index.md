---
title: 使用 Python 嵌入演示文稿中的字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/python-net/embedded-font/
keywords:
- 添加字体
- 嵌入字体
- 字体嵌入
- 获取已嵌入的字体
- 添加已嵌入的字体
- 移除已嵌入的字体
- 压缩已嵌入的字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 通过 .NET 将 TrueType 字体嵌入 PowerPoint 和 OpenDocument 演示文稿，确保在所有平台上准确渲染。"
---

## **概述**

**在 PowerPoint 中嵌入字体** 可确保您的演示文稿在不同系统上保持预期的外观。无论是使用独特的创意字体还是标准字体，嵌入字体都能防止文本和布局被破坏。

如果您因创意而使用了第三方或非标准字体，那么您更应该嵌入该字体。否则（未嵌入字体），幻灯片上的文字或数字、布局、样式等可能会变化，甚至变成乱码的方框。

使用 [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)、[FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) 和 [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) 类来管理嵌入的字体。

## **获取和移除嵌入的字体**

使用 [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 和 [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/) 方法，轻松检索或移除演示文稿中的嵌入字体。

下面的 Python 代码演示了如何获取和移除演示文稿中的嵌入字体：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示演示文件的 Presentation 类。
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # 渲染包含使用嵌入的 'FunSized' 字体的文本框的幻灯片。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # 获取所有嵌入的字体。
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # 查找 'Calibri' 字体。
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # 移除 'Calibri' 字体。
    fonts_manager.remove_embedded_font(font_data)

    # 渲染幻灯片；'Calibri' 字体将被现有字体替换。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # 将没有嵌入的 'Calibri' 字体的演示文稿保存到磁盘。
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```


## **添加嵌入的字体**

使用 [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) 枚举和 [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) 方法的两个重载，您可以选择首选的（嵌入）规则，将字体嵌入到演示文稿中。下面的 Python 代码演示了如何嵌入并添加字体到演示文稿：
```python
import aspose.slides as slides

# 加载演示文稿。
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # 将演示文稿保存到磁盘。
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```


## **压缩嵌入的字体**

使用 [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) 对嵌入的字体进行压缩，以优化文件大小。

压缩的示例代码：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**如何判断即使嵌入后，演示文稿中的特定字体在渲染时仍会被替换？**

检查字体管理器中的 [substitution information](/slides/zh/python-net/font-substitution/) 和 [fallback/substitution rules](/slides/zh/python-net/fallback-font/)：如果字体不可用或受限，将使用回退字体。

**将 “系统” 字体（如 Arial/Calibri）嵌入是否值得？**

通常不需要——这些字体几乎总是可用。但在 “轻量” 环境（Docker、未预装字体的 Linux 服务器）中，为了完整的可移植性，嵌入系统字体可以消除意外替换的风险。