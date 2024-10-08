---
title: 嵌入字体
type: docs
weight: 40
url: /zh/python-net/embedded-font/
keywords: "字体, 嵌入字体, 添加字体, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中使用 PowerPoint 演示文稿中的嵌入字体"
---

**PowerPoint 中的嵌入字体** 在您希望演示文稿在任何系统或设备上正确显示时非常有用。如果您使用了第三方或非标准字体，因为您在工作中富有创意，那么您更有理由嵌入您的字体。否则（没有嵌入字体），幻灯片上的文本或数字、布局、样式等可能会改变或变成令人困惑的矩形。

[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 类、[FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) 类、[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) 类及其接口包含了您在 PowerPoint 演示文稿中处理嵌入字体所需的大多数属性和方法。

## **获取或移除演示文稿中的嵌入字体**

Aspose.Slides 提供了 `get_embedded_fonts()` 方法（由 [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 类公开），允许您获取（或查明）嵌入到演示文稿中的字体。要移除字体，可以使用 `remove_embedded_font(font_data)` 方法（由同一类公开）。

以下 Python 代码演示了如何获取和移除演示文稿中的嵌入字体：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # 渲染一个包含使用嵌入字体 "FunSized" 的文本框的幻灯片
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture1_out.png", slides.ImageFormat.PNG)

    fontsManager = presentation.fonts_manager

    # 获取所有嵌入字体
    embeddedFonts = fontsManager.get_embedded_fonts()

    # 查找 "Calibri" 字体

    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # 移除 "Calibri" 字体
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # 渲染演示文稿；"Calibri" 字体被替换为现有字体
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture2_out.png", slides.ImageFormat.PNG)

    # 将没有嵌入 "Calibri" 字体的演示文稿保存到磁盘
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **向演示文稿添加嵌入字体**

使用 [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) 枚举和 `add_embedded_font(font_data, embed_font_rule)` 方法的两个重载，您可以选择您的首选（嵌入）规则来将字体嵌入到演示文稿中。以下 Python 代码演示了如何嵌入和添加字体到演示文稿：

```python
import aspose.slides as slides

# 加载演示文稿
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 加载要替换的源字体
    sourceFont = slides.FontData("Arial")

    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # 将演示文稿保存到磁盘
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **压缩嵌入字体**

为了让您可以压缩嵌入演示文稿中的字体并减少文件大小，Aspose.Slides 提供了 `compress_embedded_fonts` 方法（由 [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) 类公开）。

以下 Python 代码演示了如何压缩嵌入的 PowerPoint 字体：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```