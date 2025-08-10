---
title: Встраивайте шрифты в презентации на Python
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
description: "Встраивайте шрифты TrueType в презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET, обеспечивая корректное отображение на всех платформах."
---

**Встроенные шрифты в PowerPoint** полезны, когда вы хотите, чтобы ваша презентация отображалась корректно при открытии на любой системе или устройстве. Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в своей работе, то у вас есть еще больше причин встроить свой шрифт. В противном случае (без встроенных шрифтов) текст или числа на ваших слайдах, оформление, стилизация и т. д. могут измениться или превратиться в запутанные прямоугольники.

Класс [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), класс [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), класс [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) и их интерфейсы содержат большинство свойств и методов, необходимых для работы с встроенными шрифтами в презентациях PowerPoint.

## **Получить или удалить встроенные шрифты из презентации**

Aspose.Slides предоставляет метод `get_embedded_fonts()` (предоставляемый классом [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)), который позволяет получить (или определить) шрифты, встроенные в презентацию. Для удаления шрифтов используется метод `remove_embedded_font(font_data)` (предоставляемый тем же классом).

Этот код на Python показывает, как получить и удалить встроенные шрифты из презентации:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создает объект Presentation, представляющий файл презентации
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # Отрисовывает слайд, содержащий текстовый фрейм, который использует встроенный "FunSized"
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture1_out.png", slides.ImageFormat.PNG)

    fontsManager = presentation.fonts_manager

    # Получает все встроенные шрифты
    embeddedFonts = fontsManager.get_embedded_fonts()

    # Ищет шрифт "Calibri"
    
    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # Удаляет шрифт "Calibri"
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # Отрисовывает презентацию; шрифт "Calibri" заменяется на существующий
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture2_out.png", slides.ImageFormat.PNG)

    # Сохраняет презентацию без встроенного шрифта "Calibri" на диск
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **Добавить встроенные шрифты в презентацию**

Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) и две перегрузки метода `add_embedded_font(font_data, embed_font_rule)`, вы можете выбрать желаемое (встраиваемое) правило для встраивания шрифтов в презентацию. Этот код на Python показывает, как встроить и добавить шрифты в презентацию:

```python
import aspose.slides as slides

# Загружает презентацию
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Загружает исходный шрифт для замены
    sourceFont = slides.FontData("Arial")


    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Сохраняет презентацию на диск
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Сжать встроенные шрифты**

Чтобы позволить вам сжать шрифты, встроенные в презентацию, и уменьшить её размер файла, Aspose.Slides предоставляет метод `compress_embedded_fonts` (предоставляемый классом [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)).

Этот код на Python показывает, как сжать встроенные шрифты PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```