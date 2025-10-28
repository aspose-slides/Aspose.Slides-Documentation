---
title: Встраивание шрифтов в презентации с помощью Python
linktitle: Встраивание шрифта
type: docs
weight: 40
url: /ru/python-net/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
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
description: "Встраивание TrueType шрифтов в презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Python через .NET, обеспечивая точный рендеринг на всех платформах."
---

## **Обзор**

Встраивание шрифтов в PowerPoint гарантирует, что ваша презентация сохраняет задуманный внешний вид на различных системах. Независимо от того, используете ли вы уникальные шрифты для креативности или стандартные, встраивание шрифтов предотвращает нарушения текста и макета.

Если вы использовали шрифт сторонних разработчиков или нестандартный шрифт, потому что проявляли креативность в работе, у вас есть ещё больше причин встраивать шрифт. В противном случае (без встроенных шрифтов) текст или числа на слайдах, макет, стилизация и т.д. могут измениться или превратиться в запутанные прямоугольники. 

Используйте классы [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), и [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) для управления встроенными шрифтами.

## **Получение и удаление встроенных шрифтов**

Легко получайте или удаляйте встроенные шрифты из презентации с помощью методов [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) и [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Этот код на Python показывает, как получить и удалить встроенные шрифты из презентации:

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

## **Добавление встроенных шрифтов**

Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) и две перегрузки метода [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/), вы можете выбрать предпочтительное правило (встраивания) для включения шрифтов в презентацию. Этот код на Python показывает, как встроить и добавить шрифты в презентацию:

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

## **Сжатие встроенных шрифтов**

Оптимизируйте размер файла, сжимая встроенные шрифты с помощью [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Пример кода для сжатия:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Как я могу узнать, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [информацию о заменах](/slides/ru/python-net/font-substitution/) в менеджере шрифтов и [правила резервирования/замены](/slides/ru/python-net/fallback-font/): если шрифт недоступен или ограничен, будет использован резервный шрифт.

**Стоит ли встраивать «системные» шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Но для полной переносимости в «тонких» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может устранить риск неожиданных замен.