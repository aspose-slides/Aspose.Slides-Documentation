---
title: Настройте шрифты PowerPoint презентации с помощью Python
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/python-net/custom-font/
keywords:
- шрифт
- пользовательский шрифт
- внешний шрифт
- загрузить шрифт
- управление шрифтами
- папка шрифтов
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Настраивайте пользовательские шрифты на слайдах PowerPoint с помощью Aspose.Slides for Python via .NET, чтобы ваши презентации оставались чёткими и единообразными на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода `load_external_fonts` класса [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, которые отображаются в презентациях, без необходимости устанавливать эти шрифты. Шрифты загружаются из пользовательского каталога.

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) и вызовите метод `load_external_fonts`.
2. Загрузите презентацию, которую необходимо отобразить.
3. Очистите кэш в классе [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

Этот код на Python демонстрирует процесс загрузки шрифтов:

```python
import aspose.slides as slides

# Путь к каталогу документов.
dataDir = "C:\\" 

# папки для поиска шрифтов
folders = [dataDir]

# Загружает шрифты из каталога пользовательских шрифтов
slides.FontsLoader.load_external_fonts(folders)

# Выполняем некоторые действия и производим рендеринг презентации/слайда
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# Очищает кэш шрифтов
slides.FontsLoader.clear_cache()
```

## **Получение папки с пользовательскими шрифтами**
Aspose.Slides предоставляет метод `get_font_folders()`, который позволяет находить папки со шрифтами. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот код на Python демонстрирует, как использовать `get_font_folders()`:

```python
# Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
# Это папки, добавленные через метод load_external_fonts и системные папки шрифтов.
fontFolders = slides.FontsLoader.get_font_folders()
```

## **Указание пользовательских шрифтов, используемых в презентации**
Aspose.Slides предоставляет свойство `document_level_font_sources`, позволяющее указывать внешние шрифты, которые будут использоваться в презентации.

Этот код на Python демонстрирует, как использовать свойство `document_level_font_sources`:

```python
import aspose.slides as slides

with open(path + "CustomFont1.ttf", "br") as font1:
    memoryFont1 = font1.read()
    with open(path + "CustomFont2.ttf", "br") as font2:
        memoryFont2 = font2.read()

        loadOptions = slides.LoadOptions()
        loadOptions.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"]
        loadOptions.document_level_font_sources.memory_fonts = [memoryFont1, memoryFont2]
        with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as presentation:
            # Работа с презентацией
            # CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts и их подпапок доступны для презентации
            print(len(presentation.slides))
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод `load_external_font`(data) для загрузки внешних шрифтов из двоичных данных.

Этот код на Python демонстрирует процесс загрузки шрифтов из массива байтов:

```python
from aspose.slides import FontsLoader, Presentation

def read_all_bytes(path):
    with open(path, "rb") as in_file:
        bytes = in_file.read()
    return bytes

FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with Presentation() as pres:
        # внешний шрифт загружен в течение времени жизни презентации
        print("обработка")
finally:
    FontsLoader.clear_cache()
```