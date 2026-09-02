---
title: Настройка шрифтов PowerPoint в Python
linktitle: Пользовательский Шрифт
type: docs
weight: 20
url: /ru/python-net/custom-font/
keywords:
- шрифт
- пользовательский шрифт
- внешний шрифт
- загрузка шрифта
- управление шрифтами
- папка шрифтов
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Внедрите пользовательские шрифты в слайды PowerPoint с помощью Aspose.Slides for Python через .NET, чтобы ваши презентации оставались чёткими и одинаковыми на любом устройстве."
---
## **Обзор**

Aspose.Slides for Python позволяет предоставлять пользовательские шрифты во время выполнения, чтобы презентации отображались корректно, даже если необходимые шрифты не установлены в системе. При экспорте в PDF или изображения можно указать папки со шрифтами или шрифты в памяти, чтобы сохранить макет текста, метрики глифов и типографику. Это делает серверный рендеринг предсказуемым в разных средах, устраняет зависимости от шрифтов ОС и предотвращает нежелательные подстановки или переформатирование. В статье показано, как зарегистрировать источники шрифтов.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем письма. Эти сопоставления хранят имена шрифтов, но не устанавливают и не загружают файлы шрифтов. См. [Шрифты темы, специфичные для сценария](/slides/ru/python-net/script-specific-font-mappings/), чтобы управлять сопоставлениями, и используйте варианты загрузки ниже, чтобы сделать указанные шрифты доступными для согласованного рендеринга.

Aspose.Slides позволяет загружать следующие шрифты с помощью методов `load_external_font` и `load_external_fonts` класса [FontsLoader](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsloader/):

- TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например, PDF, изображения и другие поддерживаемые форматы — чтобы полученные документы выглядели одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsloader/load_external_fonts/), чтобы загрузить шрифты из этих папок.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader.clear_cache](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsloader/clear_cache/), чтобы очистить кэш шрифтов.

Следующий пример кода демонстрирует процесс загрузки шрифтов:

```py
import aspose.slides as slides

# Определите папки, содержащие пользовательские файлы шрифтов.
font_folders = ["fonts", "external_fonts"]

# Загрузите пользовательские шрифты из указанных папок.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Очистите кэш шрифтов после завершения работы.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Примечание" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsloader/load_external_fonts/) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Получить папку пользовательских шрифтов**

Aspose.Slides предоставляет метод `get_font_folders` для получения папок шрифтов. Он возвращает как папки, добавленные через `load_external_fonts`, так и системные папки шрифтов.

Этот пример Python показывает, как использовать `get_font_folders`:

```python
import aspose.slides as slides

# Этот вызов возвращает папки, проверяемые на наличие файлов шрифтов.
# Они включают папки, добавленные через метод load_external_fonts, и системные папки шрифтов.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Указать пользовательские шрифты для презентации**

Aspose.Slides предоставляет свойство `document_level_font_sources`, которое позволяет указать внешние шрифты для использования в презентации.

Следующий пример Python демонстрирует использование `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Работа с презентацией.
    # CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts (и их подпапок) доступны презентации.
    # ...
    print(len(presentation.slides))
```

## **Загрузка внешних шрифтов из бинарных данных**

Aspose.Slides предоставляет метод `load_external_font` для загрузки внешних шрифтов из бинарных данных.

Следующий пример Python демонстрирует загрузку шрифта из массива байтов:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Загрузите внешние шрифты из массивов байтов.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
        # Внешние шрифты доступны в течение жизни этого экземпляра презентации.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **Вопросы и ответы**

### Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

### Встраиваются ли пользовательские шрифты автоматически в полученный PPTX?

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если необходимо, чтобы шрифт был включён в файл презентации, используйте явные [возможности встраивания](/slides/ru/python-net/embedded-font/).

### Можно ли управлять поведением подстановки, когда у пользовательского шрифта отсутствуют некоторые глифы?

Да. Настройте [замену шрифтов](/slides/ru/python-net/font-substitution/), [правила замены](/slides/ru/python-net/font-replacement/) и [наборы резервных шрифтов](/slides/ru/python-net/fallback-font/), чтобы точно определить, какой шрифт использовать, когда запрашиваемый глиф отсутствует.

### Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?

Да. Укажите свои папки со шрифтами или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

### Что насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.