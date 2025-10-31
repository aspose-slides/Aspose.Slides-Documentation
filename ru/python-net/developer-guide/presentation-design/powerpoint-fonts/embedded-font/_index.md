---
title: "Встраивание шрифтов в презентации с помощью Python"
linktitle: "Встраивание шрифта"
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
description: "Встраивание TrueType‑шрифтов в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, обеспечивая точный рендеринг на всех платформах."
---

## **Обзор**

**Встраивание шрифтов в PowerPoint** гарантирует, что ваша презентация сохраняет задуманное оформление на разных системах. Независимо от того, используете ли вы уникальные шрифты для креативных целей или стандартные, встраивание шрифтов предотвращает искажение текста и макета.

Если вы использовали сторонний или нестандартный шрифт, потому что стремились к оригинальности, у вас есть ещё больше причин встроить его. В противном случае (без встроенных шрифтов) текст или цифры на слайдах, их расположение, стили и т.д. могут измениться или превратиться в некрасивые прямоугольники.

Используйте классы [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), и [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) для управления встроенными шрифтами.

## **Получить и удалить встроенные шрифты**

Получайте или удаляйте встроенные шрифты из презентации без усилий с помощью методов [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) и [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Этот пример на Python показывает, как получить и удалить встроенные шрифты из презентации:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Отобразить слайд, содержащий текстовый фрейм, использующий встроенный шрифт 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Получить все встроенные шрифты.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Найти шрифт 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Удалить шрифт 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Отобразить слайд; шрифт 'Calibri' будет заменён существующим.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Сохранить презентацию без встроенного шрифта 'Calibri' на диск.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Добавить встроенные шрифты**

Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) и две перегрузки метода [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/), вы можете выбрать предпочтительное правило (встраивание) для добавления шрифтов в презентацию. Этот пример на Python показывает, как встроить и добавить шрифты в презентацию:

```python
import aspose.slides as slides

# Загрузить презентацию.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Сохранить презентацию на диск.
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

## **FAQ**

**Как определить, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**  
Проверьте [информацию о замене](/slides/ru/python-net/font-substitution/) в менеджере шрифтов и [правила fallback/замены](/slides/ru/python-net/fallback-font/): если шрифт недоступен или ограничен, будет использована резервная замена.

**Стоит ли встраивать «системные» шрифты, такие как Arial/Calibri?**  
Обычно нет — они почти всегда доступны. Но для полной переносимости в «тонких» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может устранить риск непредвидённых замен.