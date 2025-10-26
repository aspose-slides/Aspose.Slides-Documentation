---
title: Встраивание шрифтов в презентации с помощью Python
linktitle: Встраивание шрифта
type: docs
weight: 40
url: /ru/python-net/developer-guide/presentation-design/powerpoint-fonts/embedded-font/
keywords:
- добавить шрифт
- встраивание шрифта
- встраивание шрифтов
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Встраивание TrueType шрифтов в презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET, обеспечивая точный рендеринг на всех платформах."
---

## **Обзор**

**Встраивание шрифтов в PowerPoint** гарантирует, что ваша презентация сохраняет задуманный вид на разных системах. Независимо от того, используете ли вы уникальные шрифты для креативности или стандартные, встраивание шрифтов предотвращает нарушения текста и макета.

Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в работе, у вас есть ещё больше причин встраивать шрифт. В противном случае (без встроенных шрифтов) тексты или цифры на слайдах, макет, стиль и т.д. могут измениться или превратиться в непонятные прямоугольники.

Используйте классы [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), и [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) для управления встроенными шрифтами.

## **Получить и удалить встроенные шрифты**

Получайте или удаляйте встроенные шрифты из презентации без усилий с помощью методов [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) и [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Этот Python‑код показывает, как получить и удалить встроенные шрифты из презентации:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Render the slide containing a text frame that uses the embedded 'FunSized' font.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Get all embedded fonts.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Find the 'Calibri' font.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Remove the 'Calibri' font.
    fonts_manager.remove_embedded_font(font_data)

    # Render the slide; the 'Calibri' font will be replaced with an existing one.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Save the presentation without the embedded 'Calibri' font to disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Добавить встроенные шрифты**

Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) и две перегрузки метода [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/), вы можете выбрать нужное правило (встраивание) для включения шрифтов в презентацию. Этот Python‑код демонстрирует, как встраивать и добавлять шрифты в презентацию:

```python
import aspose.slides as slides

# Load a presentation.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Save the presentation to disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Сжать встроенные шрифты**

Оптимизируйте размер файла, сжимая встроенные шрифты с помощью [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Пример кода для сжатия:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Как можно определить, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [информацию о замещении](/slides/ru/python-net/font-substitution/) в менеджере шрифтов и [правила замещения/резерва](/slides/ru/python-net/fallback-font/): если шрифт недоступен или ограничен, будет использован резервный.

**Стоит ли встраивать системные шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Но для полной переносимости в «тонких» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может исключить риск неожиданных замен.