---
title: 使用 Python 在簡報中嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/python-net/embedded-font/
keywords:
- 添加字型
- 嵌入字型
- 字型嵌入
- 取得嵌入字型
- 新增嵌入字型
- 移除嵌入字型
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中嵌入 TrueType 字型，確保在所有平台上正確呈現。"
---
## **簡介**

**在 PowerPoint 中嵌入字型** 可確保您的簡報在不同系統上保持預期的外觀。無論是使用創意的特殊字型或是標準字型，嵌入字型都能防止文字與版面配置被破壞。

如果您因為創意而使用了第三方或非標準字型，則更應該將字型嵌入。否則（未嵌入字型），投影片上的文字或數字、版面配置、樣式等可能會變形或變成難以辨識的方塊。

使用 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/)，[FontData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontdata/)，以及 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 類別來管理嵌入的字型。

## **取得與移除嵌入字型**

使用 [get_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 與 [remove_embedded_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/remove_embedded_font/) 方法，您可以輕鬆地從簡報中取得或移除嵌入的字型。

以下 Python 程式碼示範如何取得與移除簡報中的嵌入字型：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # 呈現包含使用嵌入的 'FunSized' 字型之文字框的投影片。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # 取得所有嵌入的字型。
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # 尋找 'Calibri' 字型。
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # 移除 'Calibri' 字型。
    fonts_manager.remove_embedded_font(font_data)

    # 呈現投影片；'Calibri' 字型將被現有的字型取代。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # 將不含嵌入 'Calibri' 字型的簡報儲存至磁碟。
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **新增嵌入字型**

透過 [EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/embedfontcharacters/) 列舉以及 [add_embedded_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/add_embedded_font/) 方法的兩個重載，您可以選擇偏好的（嵌入）規則將字型嵌入簡報中。以下 Python 程式碼示範如何嵌入並新增字型至簡報：

```python
import aspose.slides as slides

# 載入簡報。
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # 將簡報儲存至磁碟。
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **壓縮嵌入字型**

使用 [compress_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) 壓縮嵌入的字型，以優化檔案大小。

以下為壓縮範例程式碼：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**我如何判斷即使已嵌入，簡報中的特定字型在呈現時仍會被替代？**

請檢查字型管理員中的 [字型替代資訊](/slides/zh-hant/python-net/font-substitution/) 以及 [備援/替代規則](/slides/zh-hant/python-net/fallback-font/)：若字型不存在或受限，系統將使用備援字型。

**嵌入如 Arial/Calibri 之類的「系統」字型值得嗎？**

通常不需要──這類字型幾乎總是可用。但在「精簡」環境（Docker、未預裝字型的 Linux 伺服器）中，若嵌入系統字型可避免意外的字型替代，確保完整的可攜性。