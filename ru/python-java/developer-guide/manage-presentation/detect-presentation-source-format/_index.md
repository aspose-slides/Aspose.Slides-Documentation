---
title: Определить исходный формат презентации в Python через Java
linktitle: Исходный формат
type: docs
weight: 35
url: /ru/python-java/detect-presentation-source-format/
keywords:
- исходный формат
- определение формата презентации
- PowerPoint
- OpenDocument
- презентация
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Читайте оригинальный формат загруженной презентации в Python через Java с помощью Aspose.Slides for Python via Java, сравните API обнаружения и работайте с файлами, потоками и устаревшими форматами."
---
## **Обзор**

После загрузки презентации вызовите метод [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSourceFormat), чтобы определить её исходный формат. Используйте его, когда последующая обработка зависит от формата, из которого была загружена текущая копия.

Исходный формат отличается от выбранного для выходного файла [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/). Сохранение в другой формат не изменяет исходный формат уже существующего экземпляра.

Для примеров требуется Aspose.Slides for Python via Java и совместимая среда выполнения Java. Каждый пример запускает JVM, если она ещё не запущена.

## **Чтение исходного формата файла**

Этот пример требует существующего файла `sample.pptx`. Он загружает файл и выбирает политику обработки приложения, используя [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSourceFormat), а не имя файла. Измените путь входного файла, чтобы протестировать другие форматы. Пример выводит выбранную политику; замените сообщения своей логикой приложения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Определение поддерживаемых значений**

Класс [SourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sourceformat/) определяет целочисленные константы, различающие следующие форматы презентаций. Ниже приведённые расширения являются условными и не являются восстановлением оригинального имени файла.

| Значение SourceFormat | Расширение | Формат |
| --- | --- | --- |
| `Ppt` | `.ppt` | Презентация PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Презентация Office Open XML |
| `Pptm` | `.pptm` | Презентация Office Open XML с поддержкой макросов |
| `Pps` | `.pps` | Слайд-шоу PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Слайд-шоу Office Open XML |
| `Ppsm` | `.ppsm` | Слайд-шоу Office Open XML с поддержкой макросов |
| `Pot` | `.pot` | Шаблон PowerPoint 97–2003 |
| `Potx` | `.potx` | Шаблон Office Open XML |
| `Potm` | `.potm` | Шаблон Office Open XML с поддержкой макросов |
| `Odp` | `.odp` | Презентация OpenDocument |
| `Otp` | `.otp` | Шаблон OpenDocument |
| `Fodp` | `.fodp` | Плоская XML‑ODF презентация |
| `Xml` | `.xml` | Презентация PowerPoint XML |

## **Чтение исходного формата из потока**

Этот пример требует существующего файла `sample.pps`. Чтение его байтов в поток памяти моделирует ввод без имени файла, например значение из базы данных или загруженный массив байтов. Конструктор [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) получает только поток. Python считывает байты файла, а JPype преобразует их в массив Java‑байтов для Java‑потока памяти.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS и POT используют один и тот же базовый бинарный формат. При загрузке по пути к файлу расширение может помочь различить слайд‑шоу или шаблон. Без имени файла наследуемый контент PPS и POT может быть определён как `SourceFormat.Ppt`; пример PPS выше выводит целочисленное значение `SourceFormat.Ppt`.

Если приложению необходимо сохранять различие, храните оригинальное имя файла или метаданные подтипа отдельно. Расширение служит полезной подсказкой для этих наследуемых подтипов, но не должно быть единственной основой для идентификации произвольного содержимого презентации.

## **Сравнение определения до и после загрузки**

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo) и [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#getLoadFormat), когда необходимо проанализировать файл до полной загрузки его модели объектов. Используйте [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSourceFormat), если экземпляр уже существует.

Этот пример требует `sample.pptx` и выводит целочисленные значения `LoadFormat.Pptx` и `SourceFormat.Pptx` соответственно. На продакшене выбирайте API, соответствующее вашему этапу обработки; уже загруженная презентация не нуждается во второй проверке только для получения её исходного формата.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Результаты используют константы из разных классов: [LoadFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadformat/) и [SourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sourceformat/). Не сравнивайте их числовые значения и не предполагаете, что каждый формат имеет одинаковые результаты обнаружения. PowerPoint XML может быть определён как `LoadFormat.Unknown` до загрузки и как `SourceFormat.Xml` после загрузки.

## **Разделение исходного и целевого форматов**

Этот пример требует `sample.pptx` и записывает `converted.odp`. Он выводит целочисленное значение `SourceFormat.Pptx` как до, так и после сохранения исходного экземпляра. Только новый экземпляр, загруженный из ODP‑вывода, сообщает `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Презентация, созданная с нуля с помощью `Presentation()`, сообщает `SourceFormat.Pptx`. У неё нет входного файла: это значение по умолчанию для нового экземпляра, а не доказательство того, что был загружен файл PPTX. Отслеживайте, создал ли ваш код экземпляр или загрузил его, если это различие имеет значение.

## **Отображение исходного формата в расширение**

Следующий пример требует `sample.pptx`. Он сопоставляет каждый поддерживаемый в настоящее время значение [SourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sourceformat/) с условным расширением, не разбирая имя входного файла. При отсутствии соответствия используется резервный вариант, избегающий тихого назначения расширения неизвестному значению.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Это сопоставление не конвертирует файл и не восстанавливает наследуемый подтип PPS/POT, потерянный при загрузке из потока. Для реального сохранения явно указывайте [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/) или используйте конверсию, показанную в разделе [Save Presentations in Their Original Format](/slides/ru/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Проверка форматов путем сохранения и повторного открытия**

Этот автономный пример создает презентацию и записывает три файла в рабочий каталог, перезаписывая файлы с теми же именами. Он повторно открывает каждый вывод как по пути, так и через поток памяти. Для PPTX и ODP оба пути сообщают сохранённый формат. Для PPS загрузка по пути сообщает `Pps`, тогда как загрузка тех же байтов без имени файла сообщает `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

В таблице ниже суммированы результаты определения исходного формата для презентаций с совпадающими расширениями. Имена обозначают константы; примеры Python выводят их целочисленные значения:

| Сохранённый формат | SourceFormat из пути к файлу | SourceFormat из потока без имени |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` соответственно | То же, что и путь к файлу |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` соответственно | То же, что и путь к файлу |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` соответственно | То же, что и путь к файлу |
| ODP, OTP | `Odp`, `Otp` соответственно | То же, что и путь к файлу |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Контент PPS/POT определяется как `Ppt` для потоков без имени. Таблица описывает идентификацию формата, а не сохранение всех возможностей презентации при конвертации.

## **FAQ**

**Изменит ли сохранение в ODP исходный формат презентации, загруженной из PPTX?**

Нет. Существующий экземпляр по‑прежнему сообщает `Pptx`. Экземпляр, загруженный из сохранённого ODP‑файла, сообщает `Odp`.

**Всегда ли поток может различать наследуемую презентацию, слайд‑шоу и шаблон?**

Нет. PPT, PPS и POT используют один и тот же бинарный формат. Храните имя файла или метаданные подтипа отдельно, если требуется различие.

**Какой API использовать, если презентация уже загружена?**

Читайте [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSourceFormat). Для предварительной инспекции используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo).