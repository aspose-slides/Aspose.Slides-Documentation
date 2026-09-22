---
title: Определить исходный формат презентации в Python
linktitle: Исходный формат
type: docs
weight: 35
url: /ru/python-net/detect-presentation-source-format/
keywords:
- исходный формат
- определение формата презентации
- PowerPoint
- OpenDocument
- презентация
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Прочитайте исходный формат загруженной презентации в Python с помощью Aspose.Slides for Python via .NET, сравните API обнаружения и обработайте файлы, потоки и наследуемые форматы."
---
## **Обзор**

После загрузки презентации прочитайте только для чтения свойство [Presentation.source_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/source_format/) чтобы определить её исходный формат. Используйте его, когда последующая обработка зависит от формата, из которого был загружен текущий экземпляр.

Исходный формат отличается от выбранного [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/) для выходного файла. Сохранение в другой формат не изменяет исходный формат существующего экземпляра.

## **Чтение исходного формата файла**

Этот пример требует существующий файл `sample.pptx`. Он загружает файл и выбирает политику обработки приложения, используя [Presentation.source_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/source_format/), а не имя файла. Измените путь ввода, чтобы попробовать другие форматы. Пример выводит выбранную политику; замените сообщения своей логикой приложения.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Распознавание поддерживаемых значений**

Перечисление [SourceFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sourceformat/) различает следующие форматы презентаций. Ниже перечисленные расширения являются условными, а не восстановлением оригинального имени файла.

| Значение SourceFormat | Расширение | Формат |
| --- | --- | --- |
| `PPT` | `.ppt` | Презентация PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Презентация Office Open XML |
| `PPTM` | `.pptm` | Презентация Office Open XML с поддержкой макросов |
| `PPS` | `.pps` | Слайд‑шоу PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Слайд‑шоу Office Open XML |
| `PPSM` | `.ppsm` | Слайд‑шоу Office Open XML с поддержкой макросов |
| `POT` | `.pot` | Шаблон PowerPoint 97–2003 |
| `POTX` | `.potx` | Шаблон Office Open XML |
| `POTM` | `.potm` | Шаблон Office Open XML с поддержкой макросов |
| `ODP` | `.odp` | Презентация OpenDocument |
| `OTP` | `.otp` | Шаблон презентации OpenDocument |
| `FODP` | `.fodp` | Плоская XML ODF презентация |
| `XML` | `.xml` | Презентация PowerPoint XML |

## **Чтение исходного формата из потока**

Этот пример требует существующий файл `sample.pps`. Чтение его байтов в поток памяти моделирует ввод без имени файла, например значение из базы данных или загруженный массив байтов. Конструктор [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) получает только поток.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

`PPT`, `PPS` и `POT` используют один и тот же базовый бинарный формат. При загрузке по пути к файлу расширение может помочь различить слайд‑шоу или шаблон. Без имени файла наследуемый контент `PPS` и `POT` может быть определён как `SourceFormat.PPT`; пример `PPS` выше сообщает `PPT`.

Если вашему приложению необходимо сохранять это различие, храните оригинальное имя файла или метаданные подтипа отдельно. Расширение служит полезным подсказкой для этих наследуемых подтипов, но не должно быть единственной основой для идентификации произвольного содержимого презентации.

## **Сравнение определения до и после загрузки**

Используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) и [PresentationInfo.load_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/load_format/) когда нужно проанализировать файл до полной загрузки модели объекта презентации. Используйте [Presentation.source_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/source_format/) когда экземпляр уже существует.

Этот пример требует `sample.pptx` и выводит `PPTX` для обоих проверок. В продакшене выбирайте API, соответствующее вашему этапу обработки; уже загруженная презентация не нуждается во второй проверке только для получения её исходного формата.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Результаты имеют разные типы перечислений: [LoadFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadformat/) и [SourceFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sourceformat/). Не сравнивайте их, приводя их числовые значения, и не предполагаете, что каждый формат имеет одинаковые результаты обнаружения. В проверке «сохранить‑и‑перезапустить», описанной ниже, PowerPoint XML до загрузки определялся как `LoadFormat.UNKNOWN`, а после загрузки — как `SourceFormat.XML`.

## **Разделяйте исходный и формат вывода**

Этот пример требует `sample.pptx` и записывает `converted.odp`. Он выводит `PPTX` как до, так и после сохранения оригинального экземпляра. Только новый экземпляр, загруженный из результата ODP, сообщает `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Презентация, созданная с нуля с помощью `slides.Presentation()`, сообщает `SourceFormat.PPTX`. У неё нет входного файла: это значение по умолчанию для новосозданного экземпляра, а не подтверждение того, что был загружен файл PPTX. Отслеживайте отдельно, была ли презентация создана или загружена, если это различие имеет значение.

## **Сопоставление исходного формата с расширением**

Следующий пример требует `sample.pptx`. Он сопоставляет каждое в данный момент поддерживаемое значение [SourceFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sourceformat/) с условным расширением, без анализа исходного имени файла. Резервный вариант избегает тихого назначения расширения нераспознанному значению.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Это сопоставление не конвертирует файл и не восстанавливает наследуемый подтип PPS/POT, потерянный при загрузке из потока. Для реального сохранения явно выбирайте [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/) или используйте конверсию, показанную в [Save Presentations in Their Original Format](/slides/ru/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Проверка форматов путем сохранения и повторного открытия**

Этот автономный пример создаёт презентацию и записывает три файла в текущий рабочий каталог, перезаписывая файлы с теми же именами. Он открывает каждый вывод как по пути, так и через поток памяти. Для PPTX и ODP оба пути сообщают сохранённый формат. Для PPS загрузка по пути сообщает `PPS`, а загрузка тех же байтов без имени файла сообщает `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Та же проверка со всеми форматами, перечисленными выше, дала следующие результаты для сгенерированных презентаций с соответствующими расширениями:

| Сохраненный формат | SourceFormat из пути к файлу | SourceFormat из безымянного потока |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` соответственно | Как путь к файлу |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` соответственно | Как путь к файлу |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` соответственно | Как путь к файлу |
| ODP, OTP | `ODP`, `OTP` соответственно | Как путь к файлу |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

В этих проверках единственной нормализацией исходного формата было преобразование PPS/POT в `PPT` для безымянных потоков. Таблица описывает идентификацию формата, а не сохранение всех особенностей презентации при конвертации.

## **Часто задаваемые вопросы**

**Изменяется ли исходный формат презентации, загруженной из PPTX, после сохранения в ODP?**

Нет. Существующий экземпляр по‑прежнему сообщает `PPTX`. Экземпляр, загруженный из сохранённого файла ODP, сообщает `ODP`.

**Может ли поток всегда различать наследуемую презентацию, слайд‑шоу и шаблон?**

Нет. `PPT`, `PPS` и `POT` используют один и тот же бинарный формат. Храните имя файла или метаданные подтипа отдельно, когда требуется различать их.

**Какой API использовать, если презентация уже загружена?**

Читайте [Presentation.source_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/source_format/). Для предварительной инспекции перед загрузкой используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/).