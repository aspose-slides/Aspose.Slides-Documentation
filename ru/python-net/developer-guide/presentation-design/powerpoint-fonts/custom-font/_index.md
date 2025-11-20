---
title: Настройка шрифтов PowerPoint в Python
linktitle: Пользовательский шрифт
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
description: "Вставляйте пользовательские шрифты в слайды PowerPoint с помощью Aspose.Slides для Python через .NET, чтобы ваши презентации оставались четкими и согласованными на любом устройстве."
---

## **Обзор**

Aspose.Slides for Python позволяет предоставлять пользовательские шрифты во время выполнения, чтобы презентации отображались правильно даже если необходимые шрифты не установлены в системе. При экспорте в PDF или изображения можно указать папки со шрифтами или данные шрифтов в памяти, чтобы сохранить разметку текста, метрики глифов и типографику. Это делает серверный рендеринг предсказуемым в разных средах, устраняет зависимости от шрифтов операционной системы и предотвращает нежелательные подстановки или переразмещение. В статье показано, как регистрировать источники шрифтов.

Aspose.Slides позволяет загружать следующие шрифты с помощью методов `load_external_font` и `load_external_fonts` класса [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/):

- TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты для рендеринга презентаций без их установки. Шрифты загружаются из пользовательской директории.

1. Вызовите метод `load_external_fonts` из класса [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).
1. Загрузите презентацию, которую нужно отрендерить.
1. Очистите кэш в классе [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

```python
import aspose.slides as slides

# Папки для поиска шрифтов.
font_folders = [ "C:\\MyFonts", "D:\\MyAdditionalFonts" ]

# Загрузка шрифтов из пользовательских каталогов.
slides.FontsLoader.load_external_fonts(font_folders)

# Рендер презентации.
with slides.Presentation("Fonts.pptx") as presentation:
    presentation.save("Fonts_out.pdf", slides.export.SaveFormat.PDF)

# Очистка кэша шрифтов.
slides.FontsLoader.clear_cache()
```


## **Получить папку пользовательских шрифтов**

Aspose.Slides предоставляет метод `get_font_folders` для получения папок шрифтов. Он возвращает как папки, добавленные через `load_external_fonts`, так и системные папки шрифтов.

```python
import aspose.slides as slides

# Этот вызов возвращает папки, проверенные на наличие файлов шрифтов.
# Это включает папки, добавленные через метод load_external_fonts, и системные папки шрифтов.
font_folders = slides.FontsLoader.get_font_folders()
```


## **Указать пользовательские шрифты для презентации**

Aspose.Slides предоставляет свойство `document_level_font_sources`, которое позволяет указать внешние шрифты, используемые в презентации.

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

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Загрузка внешних шрифтов из массивов байтов.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Внешние шрифты доступны в течение жизни этого экземпляра презентации.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **Часто задаваемые вопросы**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключенные шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в полученный PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если требуется, чтобы шрифт находился внутри файла презентации, необходимо использовать явные [возможности встраивания](/slides/ru/python-net/embedded-font/).

**Могу ли я управлять поведением подстановки, когда у пользовательского шрифта отсутствуют определенные глифы?**

Да. Настройте [замену шрифтов](/slides/ru/python-net/font-substitution/), [правила замены](/slides/ru/python-net/font-replacement/), и [наборы резервных шрифтов](/slides/ru/python-net/fallback-font/), чтобы точно определить, какой шрифт будет использоваться, если запрашиваемый глиф отсутствует.

**Могу ли я использовать шрифты в контейнерах Linux/Docker без их установки в системе?**

Да. Укажите свои директории со шрифтами или загружайте шрифты из массивов байтов. Это устраняет любые зависимости от системных папок шрифтов в образе контейнера.

**Что насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение лицензионных условий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте лицензионное соглашение (EULA) шрифта перед распространением результатов.