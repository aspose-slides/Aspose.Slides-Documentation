---
title: Встраивание шрифтов в презентациях на Python через Java
linktitle: Встроенные шрифты
type: docs
weight: 40
url: /ru/python-java/embedded-font/
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
- Java
- Aspose.Slides
description: "Управляйте встроенными шрифтами в PowerPoint с помощью Aspose.Slides для Python через Java. Добавляйте, получайте, удаляйте и сжимайте шрифты, чтобы сохранять внешний вид текста и уменьшать размер файла."
---
## **Введение**

Встраивание шрифтов сохраняет данные шрифта внутри презентации PowerPoint. Когда средство просмотра поддерживает встроенные шрифты, оно может отображать текст с их использованием, даже если они не установлены в целевой системе. Это помогает сохранять разрывы строк, интервал между текстом и макет слайда.

Aspose.Slides for Python via Java позволяет получать, добавлять и удалять встроенные шрифты через класс [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) , возвращаемый методом [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getFontsManager) . Вы также можете уменьшить размер данных встроенного шрифта, удалив символы, которые не используются в презентации.

Приведённые ниже примеры работают с файлами PPTX. Перед встраиванием шрифта убедитесь, что его данные доступны Aspose.Slides и его лицензия позволяет встраивание.

## **Получение и удаление встроенных шрифтов**

Используйте [getEmbeddedFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) , чтобы получить список шрифтов, хранящихся в презентации. Чтобы удалить один из них, передайте шрифт из этого списка в [removeEmbeddedFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) , затем сохраните презентацию.

Следующий пример выводит список встроенных шрифтов в `EmbeddedFonts.pptx` и удаляет Calibri, если он присутствует:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Удаление встроенного шрифта удаляет его сохранённые данные; это не меняет шрифт, назначенный тексту. Если шрифт установлен в целевой системе, текст всё равно может его использовать. В противном случае при рендеринге может потребоваться замена шрифта, что может повлиять на макет.

## **Проверка данных шрифта и прав встраивания**

Используйте класс [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) для проверки шрифтов перед их встраиванием. Вызовите [FontsManager.getFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getFonts) , чтобы получить шрифты, используемые в презентации. Для каждого шрифта передайте объект [FontData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontdata/) и требуемое значение [FontStyleType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontstyletype/) в [FontsManager.getFontBytes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getFontBytes) . Метод возвращает бинарные данные для этого стиля шрифта или `None` , если запрашиваемый шрифт или стиль недоступны. Не передавайте результат `None` в [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) , поскольку этот метод требует массив байтов.

[EmbeddingLevel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/embeddinglevel/) — это перечисление флагов, которое сообщает ограничения встраивания, хранящиеся в шрифте:

- `Installable` разрешает встраивание и постоянную установку на другой системе, при условии соблюдения лицензии шрифта.
- `Restricted` запрещает встраивание, если не получено разрешение от законного владельца шрифта, когда это единственный флаг разрешения использования.
- `PreviewPrint` разрешает временное использование для просмотра и печати; документ, содержащий шрифт, должен быть только для чтения.
- `Editable` разрешает временное использование и позволяет документу быть отредактированным и сохранённым.
- `NoSubsetting` — дополнительное ограничение, запрещающее встраивание только подмножества глифов. При наличии этого флага необходимо встраивать все символы.
- `BitmapOnly` — дополнительное ограничение, позволяющее встраивать только растровые варианты шрифта, а не контурные данные. Если у шрифта нет растровых вариантов, его нельзя встраивать.

Первые четыре значения описывают разрешения использования, в то время как `NoSubsetting` и `BitmapOnly` могут комбинироваться с ними. Проверяйте модификаторы с помощью побитовых операций. Поскольку `Installable` равно нулю, маскируйте биты разрешения использования и сравнивайте результат с `Installable`, а не проверяйте его как флаг. Современные шрифты должны задавать не более одного бита разрешения использования. Для совместимости со старыми шрифтами, задающими более одного, вспомогательная функция ниже выбирает наименее ограничительное разрешение: `Editable`, затем `PreviewPrint`, затем `Restricted`.

Следующий пример проверяет обычные, полужирные, наклонные и полужирно‑наклонные данные, доступные для каждого шрифта, возвращённого `getFonts`. Он пропускает недоступные стили, ограниченные шрифты, шрифты только с растровыми вариантами, шрифты, ограниченные только просмотром и печатью, поскольку вывод остаётся редактируемым, а также шрифты, которые уже встроены. Если какой‑либо доступный стиль имеет `NoSubsetting`, он встраивает все символы для этой семейства шрифтов.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Эта проверка сообщает ограничения, закодированные в каждом файле шрифта. Она не предоставляет лицензии, не доказывает, что вы получили шрифт законным способом, и не заменяет проверку лицензионного соглашения шрифта перед распространением встроенной копии.

## **Добавление встроенных шрифтов**

Используйте [addEmbeddedFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) для встраивания шрифта. Его перегрузки принимают либо объект [FontData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontdata/) , либо массив байтов, содержащий данные шрифта. Перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/ru/python-java/aspose.slides/embedfontcharacters/) управляет тем, какие символы включаются:

- [All](https://reference.aspose.com/slides/ru/python-java/aspose.slides/embedfontcharacters/) встраивает все символы шрифта. Используйте эту опцию, когда получатели должны редактировать презентацию и вводить новый текст.
- [OnlyUsed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/embedfontcharacters/) встраивает только символы, использованные в презентации, чтобы уменьшить размер файла. Выберите эту опцию для готовой презентации, предназначенной в основном для просмотра.

Следующий пример использует [getFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getFonts) для получения шрифтов, используемых в `Fonts.pptx` , и встраивает те, которые ещё не встроены. Шрифты для добавления должны быть доступны на машине, где выполняется код. Существующие встроенные шрифты сохраняют свои текущие наборы символов.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Сжатие встроенных шрифтов**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#compressEmbeddedFonts) уменьшает данные встроенного шрифта, удаляя неиспользуемые символы. Он работает с уже встроенными шрифтами, поэтому степень уменьшения размера зависит от количества неиспользуемых данных шрифта в презентации.

Следующий пример сжимает шрифты в `EmbeddedFonts.pptx` и сохраняет результат в отдельный файл:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сохраните оригинальный файл, если получателям может потребоваться добавить текст позже. Символы, удалённые при сжатии, больше недоступны из встроенного шрифта, даже если изначально вы встраивали все символы.

## **FAQ**

**Как я могу проверить, будет ли встроенный шрифт заменён при рендеринге?**

Вызовите [getSubstitutions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getSubstitutions) в среде, где вы рендерите презентацию, чтобы увидеть, какие шрифты Aspose.Slides заменит. Также проверьте настройки замены шрифтов и правила резервных шрифтов. Резервирование обрабатывает отсутствующие символы, поэтому встраивание шрифта не решает проблему символов, которых сам шрифт не содержит.

**Стоит ли встраивать распространённые шрифты, такие как Arial и Calibri?**

Решение следует принимать, ориентируясь на целевую среду. Если необходимые шрифты доступны на каждом компьютере, который открывает или рендерит презентацию, их встраивание может добавить ненужный размер файла. Если у получателей или серверов может не быть этих шрифтов, их встраивание может помочь сохранить ожидаемый вид, при условии, что лицензии позволяют это.