---
title: Встраивание шрифтов в презентации с Python
linktitle: Встроенные шрифты
type: docs
weight: 40
url: /ru/python-net/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
- встраивание шрифта
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте встроенными шрифтами в PowerPoint с помощью Aspose.Slides for Python via .NET. Используйте Python для добавления, получения, удаления и сжатия шрифтов, чтобы сохранить внешний вид текста и уменьшить размер файла."
---
## **Введение**

Встраивание шрифтов сохраняет данные шрифта внутри презентации PowerPoint. Когда просмотрщик поддерживает встроенные шрифты, он может отображать текст с этими шрифтами, даже если они не установлены в целевой системе. Это помогает сохранить разрывы строк, интервалы между текстом и расположение слайдов.

Aspose.Slides for Python via .NET позволяет получать, добавлять и удалять встроенные шрифты через свойство [fonts_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/fonts_manager/) объекта [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Вы также можете уменьшить размер данных встроенного шрифта, удалив символы, которые презентация не использует.

Приведённые ниже примеры работают с файлами PPTX. Перед встраиванием шрифта убедитесь, что его данные доступны Aspose.Slides и его лицензия допускает встраивание.

## **Получение и удаление встроенных шрифтов**

Используйте [get_embedded_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) для перечисления шрифтов, хранящихся в презентации. Чтобы удалить шрифт, передайте один из шрифтов из этого списка в [remove_embedded_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/remove_embedded_font/), затем сохраните презентацию.

Следующий пример выводит список встроенных шрифтов в `EmbeddedFonts.pptx` и удаляет Calibri, если он присутствует:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Удаление встроенного шрифта удаляет его сохранённые данные; это не меняет шрифт, назначенный тексту. Если шрифт установлен в целевой системе, текст всё равно может его использовать. В противном случае при рендеринге может потребоваться [font substitution](/slides/ru/python-net/font-substitution/), что может повлиять на разметку.

## **Проверка данных шрифта и разрешений на встраивание**

Используйте класс [FontsManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/) для проверки шрифтов перед их встраиванием. Вызовите [get_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_fonts/) для получения шрифтов, используемых в презентации. Для каждого шрифта передайте объект [FontData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontdata/) и требуемое значение [FontStyleType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontstyletype/) в [get_font_bytes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_font_bytes/). Метод возвращает двоичные данные для данного стиля шрифта или `None`, если запрашиваемый шрифт или стиль недоступны. Не передавайте результат `None` в [get_font_embedding_level](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), поскольку этот метод требует массив байтов.

[EmbeddingLevel](https://reference.aspose.com/slides/ru/python-net/aspose.slides/embeddinglevel/) — это перечисление флагов, которое сообщает ограничения встраивания, сохранённые в шрифте:

- `INSTALLABLE` позволяет встраивание и постоянную установку на другой системе при соблюдении лицензии шрифта.
- `RESTRICTED` запрещает встраивание, если не получено разрешение от правообладателя шрифта, когда это единственный флаг разрешения использования.
- `PREVIEW_PRINT` позволяет временное использование для просмотра и печати; документ, содержащий шрифт, должен быть только для чтения.
- `EDITABLE` разрешает временное использование и позволяет редактировать и сохранять документ.
- `NO_SUBSETTING` — дополнительное ограничение, запрещающее встраивание только подмножества глифов. При наличии этого флага необходимо встраивать все символы.
- `BITMAP_ONLY` — дополнительное ограничение, позволяющее встраивать только растровые представления, а не контурные данные. Если у шрифта нет растровых представлений, его нельзя встроить.

Первые четыре значения описывают разрешения на использование, в то время как `NO_SUBSETTING` и `BITMAP_ONLY` могут комбинироваться с ними. Проверяйте модификаторы с помощью побитовых операций. Поскольку `INSTALLABLE` имеет значение ноль, маскируйте биты разрешения использования и сравнивайте результат с `INSTALLABLE`. Текущие шрифты должны устанавливать не более одного бита разрешения использования. Для совместимости со старыми шрифтами, которые устанавливают несколько бит, вспомогательная функция ниже выбирает наименее ограничительное разрешение: `EDITABLE`, затем `PREVIEW_PRINT`, затем `RESTRICTED`.

Следующий пример проверяет обычные, полужирные, курсивные и полужирно‑курсивные данные, доступные для каждого шрифта, возвращённого `get_fonts`. Он пропускает недоступные стили, ограниченные шрифты, шрифты только с растровыми данными, шрифты, ограниченные только просмотром и печатью, поскольку результат остаётся редактируемым, а также уже встроенные шрифты. Если любой доступный стиль имеет `NO_SUBSETTING`, встраиваются все символы данной семейства шрифтов.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Эта проверка сообщает ограничения, закодированные в каждом файле шрифта. Она не выдаёт лицензию, не доказывает законность получения шрифта и не заменяет проверку лицензионного соглашения шрифта перед распространением встроенной копии.

## **Добавление встроенных шрифтов**

Используйте [add_embedded_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/add_embedded_font/) для встраивания шрифта. Его перегрузки принимают либо объект [FontData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontdata/), либо массив байтов, содержащий данные шрифта. Перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/embedfontcharacters/) управляет тем, какие символы включаются:

- [ALL](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/embedfontcharacters/) встраивает все символы шрифта. Используйте эту опцию, когда получатели должны иметь возможность редактировать презентацию и вводить новый текст.
- [ONLY_USED](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/embedfontcharacters/) встраивает только символы, использованные в презентации, чтобы уменьшить размер файла. Выбирайте эту опцию для готовой презентации, предназначенной в основном для просмотра.

Следующий пример использует [get_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_fonts/) для получения шрифтов, использованных в `Fonts.pptx`, и встраивает те, которые ещё не встроены. Шрифты для добавления должны быть доступны на машине, где выполняется код. Существующие встроенные шрифты сохраняют свои текущие наборы символов.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Сжатие встроенных шрифтов**

[compress_embedded_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) уменьшает данные встроенного шрифта, удаляя неиспользуемые символы. Он работает с уже встроенными шрифтами, поэтому степень снижения размера зависит от количества неиспользуемых данных шрифта в презентации.

Следующий пример сжимает шрифты в `EmbeddedFonts.pptx` и сохраняет результат в отдельный файл:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Сохраняйте оригинальный файл, если получатели могут позже добавить текст. Символы, удалённые во время сжатия, более недоступны из встроенного шрифта, даже если изначально был встроен весь набор символов.

## **FAQ**

**Как проверить, будет ли встроенный шрифт всё равно заменён при рендеринге?**

Вызовите [get_substitutions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_substitutions/) в среде, где вы рендерите презентацию, чтобы увидеть, какие шрифты Aspose.Slides заменит. Также проверьте настройки [font substitution](/slides/ru/python-net/font-substitution/) и правила [font fallback](/slides/ru/python-net/fallback-font/). Fallback обрабатывает отсутствующие символы, поэтому встраивание шрифта не решает проблему символов, которых в самом шрифте нет.

**Стоит ли встраивать распространённые шрифты, такие как Arial и Calibri?**

Принимайте решение, исходя из целевой среды. Если необходимые шрифты доступны на каждом устройстве, которое открывает или рендерит презентацию, их встраивание может лишь увеличить размер файла без необходимости. Если у получателей или серверов могут отсутствовать эти шрифты, их встраивание может помочь сохранить ожидаемое оформление, при условии, что лицензии позволяют это.