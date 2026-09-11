---
title: Настройка шрифтов PowerPoint в Python через Java
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/python-java/custom-font/
keywords:
- шрифт
- пользовательский шрифт
- внешний шрифт
- загрузка шрифта
- управление шрифтами
- папка шрифтов
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для Python через Java, чтобы ваши презентации были чёткими и согласованными на любых устройствах."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без установки их в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа, или загружать внешние шрифты непосредственно из бинарных данных.

Загруженные шрифты используются при визуализации или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять согласованность вывода презентации в разных средах. Статья также объясняет, как просматривать папки шрифтов, используемые Aspose.Slides, и как очистить кеш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для визуализации отличается от встраивания шрифтов в файл PPTX. Если шрифт должен быть сохранён внутри самой презентации, используйте функции встраивания шрифтов явно.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем письма. Эти сопоставления хранят имена шрифтов, но не устанавливают и не загружают файлы шрифтов. Смотрите [Script-Specific Theme Fonts](/slides/ru/python-java/script-specific-font-mappings/) для управления сопоставлениями и используйте параметры загрузки ниже, чтобы сделать указанные шрифты доступными для согласованной визуализации.

{{% alert color="info" title="Примечание" %}}

Aspose.Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например в PDF, изображения и другие поддерживаемые форматы — поэтому полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#loadExternalFonts) для загрузки шрифтов из этих папок.  
3. Загрузите и визуализируйте/экспортируйте презентацию.  
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#clearCache) для очистки кеша шрифтов.

Следующий пример кода демонстрирует процесс загрузки шрифтов:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Определите папки, содержащие пользовательские файлы шрифтов.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Загрузите пользовательские шрифты из указанных папок.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Визуализируйте/экспортируйте презентацию, используя загруженные шрифты.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Очистите кеш шрифтов после завершения работы.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Примечание" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#loadExternalFonts) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.  
Шрифты инициализируются в следующем порядке:

1. Путь шрифтов по умолчанию операционной системы.  
1. Путь, загруженный через [FontsLoader](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Получить пользовательские папки шрифтов**

Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#getFontFolders), позволяющий находить папки шрифтов. Этот метод возвращает папки, добавленные через метод [loadExternalFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#loadExternalFonts), а также системные папки шрифтов.

Этот код на Python показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Получите папки, добавленные через loadExternalFonts, и системные папки шрифтов.
font_folders = FontsLoader.getFontFolders()
```

## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет метод [getDocumentLevelFontSources](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources), позволяющий указать внешние шрифты, которые будут использоваться в презентации.

Этот код на Python показывает, как использовать метод [getDocumentLevelFontSources](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Работа с презентацией.
    # CustomFont1, CustomFont2 и шрифты из assets/fonts и global/fonts
    # а их подпапки доступны презентации.
    pass
finally:
    presentation.dispose()
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#loadExternalFont), позволяющий загружать внешние шрифты из бинарных данных.

Этот код на Python демонстрирует процесс загрузки шрифта из массива байтов:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Внешние шрифты загружаются в течение времени жизни презентации.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в полученный PPTX?**

Нет. Регистрация шрифта для визуализации не равна его встраиванию в PPTX. Если нужен шрифт внутри файла презентации, необходимо явно использовать [функции встраивания](/slides/ru/python-java/embedded-font/).

**Можно ли контролировать поведение fallback, когда у пользовательского шрифта отсутствуют отдельные глифы?**

Да. Настройте [font substitution](/slides/ru/python-java/font-substitution/), [replacement rules](/slides/ru/python-java/font-replacement/) и [fallback sets](/slides/ru/python-java/fallback-font/), чтобы точно определить, какой шрифт использовать, когда запрашиваемый глиф отсутствует.

**Можно ли использовать шрифты в Linux/Docker‑контейнерах без их установки в системе?**

Да. Укажите свои собственные папки шрифтов или загрузите шрифты из массивов байтов. Это устраняет любую зависимость от системных папок шрифтов в образе контейнера.

**Как обстоят дела с лицензированием — могу ли я встраивать любой пользовательский шрифт без ограничений?**

Вы отвечаете за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.