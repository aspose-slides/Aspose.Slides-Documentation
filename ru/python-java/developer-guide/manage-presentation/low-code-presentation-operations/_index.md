---
title: Операции над презентациями с низким уровнем кода в Python через Java
linktitle: API с низким уровнем кода
type: docs
weight: 50
url: /ru/python-java/low-code-presentation-operations/
keywords:
- API низкоуровневых операций с презентациями
- конвертировать презентацию
- объединять презентации
- перебор слайдов
- перебор форм
- перебор текста
- сбор форм
- сжать презентацию
- удалить неиспользуемые шаблоны слайдов
- удалить неиспользуемые макетные слайды
- сжать вложенные шрифты
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в Python через Java для конвертации и объединения презентаций, перебора содержимого, сбора форм и уменьшения размера презентации."
---
## **Обзор**

API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/ru/python-java/aspose.slides/) предоставляет статические вспомогательные классы для типовых операций с презентациями. Эти помощники инкапсулируют часто используемые сценарии объектной модели в удобных методах, поэтому вы можете конвертировать или объединять файлы, обрабатывать элементы презентации, собирать формы и удалять неиспользуемый контент с меньшим количеством кода.

Помощники с низким уровнем кода наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный сценарий соответствует вашим требованиям. Используйте полную [объектную модель Aspose.Slides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/) при необходимости детального управления отдельными слайдами, шаблонами, макетами, формами, настройками экспорта или связями между элементами презентации.

Ниже приведена таблица, суммирующая доступные помощники:

| Вспомогательный класс | Для чего используется |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/python-java/aspose.slides/convert/) | Конвертация презентации в другой формат с помощью прямого вызова файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/python-java/aspose.slides/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/) | Выполнение действия для каждого слайда, формы, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/collect/) | Получение форм из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/) | Удаление неиспользуемых шаблонов и макетов и сокращение данных вложенных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert.autoByExtension](https://reference.aspose.com/slides/ru/python-java/aspose.slides/convert/#autoByExtension), когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет нужный формат по пути вывода и записывает результат.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

Класс [Convert](https://reference.aspose.com/slides/ru/python-java/aspose.slides/convert/) также предоставляет отдельные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, если нужно просмотреть или изменить презентацию перед экспортом или настроить параметр экспорта, который не доступен через выбранный помощник. См. [Convert Presentation](/slides/ru/python-java/convert-presentation/) для сценариев и опций, специфичных для форматов.

## **Объединить презентации**

Вызовите [Merger.process](https://reference.aspose.com/slides/ru/python-java/aspose.slides/merger/#process) для объединения полных файлов презентаций одним вызовом. Входящие презентации должны иметь одинаковый формат файла.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

Этот помощник подходит, когда все слайды следует добавить к единому результату без выбора или переопределения их по отдельности. Используйте полную объектную модель, если нужно объединять выбранные слайды, применять целевой шаблон или макет, явно сохранять разделы или согласовывать разные размеры слайдов. См. [Merge Presentations](/slides/ru/python-java/merge-presentation/) для таких сценариев.

## **Итерация по элементам презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Это избавляет от вложенных циклов перебора и удобно для проверки или внесения изменений по всей презентации.

В следующем примере используются [ForEach.slide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#paragraph) и [ForEach.portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#portion) для инспекции соответствующих элементов:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

По умолчанию обход форм и текста по всей презентации включает обычные, шаблонные и макетные слайды. Перегрузки с параметром `includeNotes` могут также обрабатывать слайды с заметками. Используйте прямые циклы перебора, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальный контроль родитель‑дочерних отношений.

## **Сбор форм**

Применяйте [Collect.shapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/collect/#shapes), когда требуется собрать все формы презентации, а не обрабатывать их по одной через обратный вызов. Это полезно, если один и тот же набор будет отфильтрован, подсчитан или обработан несколько раз.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#shape), когда каждую форму можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/) может удалять неиспользуемые структурные элементы и уменьшать данные вложенных шрифтов:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) удаляет макетные слайды, на которые не ссылаются обычные слайды.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#removeUnusedMasterSlides) удаляет шаблонные слайды, которые больше не используются.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#compressEmbeddedFonts) удаляет неиспользуемые символы из вложенных шрифтов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые шаблоны, чтобы шаблон, ставший не ссылочным после очистки макетов, также был удалён. Сохраните оптимизированную презентацию в новый файл, если позже понадобится исходный набор шаблонов, макетов или полные данные вложенных шрифтов. Подробнее см. [Slide Master](/slides/ru/python-java/slide-master/) и [Embedded Font](/slides/ru/python-java/embedded-font/).

## **FAQ**

**Когда следует использовать API с низким уровнем кода вместо полной объектной модели?**

Используйте помощники с низким уровнем кода, когда стандартная операция применяется к полной презентации и не требует детального управления отдельными элементами. Применяйте полную объектную модель, если нужно выбрать конкретные слайды, управлять связями шаблон‑макет, просматривать промежуточное состояние или настраивать поведение, которое не предоставляет помощник.

**Может ли Merger объединять презентации разных форматов?**

Нет. Метод [Merger.process](https://reference.aspose.com/slides/ru/python-java/aspose.slides/merger/#process) требует, чтобы входные презентации имели одинаковый формат. Сначала конвертируйте входные файлы в общий формат, например с помощью [Convert.autoByExtension](https://reference.aspose.com/slides/ru/python-java/aspose.slides/convert/#autoByExtension), а затем объедините полученные файлы.

**Обрабатывает ли ForEach шаблонные, макетные и слайды с заметками?**

[ForEach.slide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#slide) перебирает обычные слайды презентации. Операции [ForEach.shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#paragraph) и [ForEach.portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#portion) по умолчанию включают обычные, шаблонные и макетные слайды. Используйте их перегрузки с параметром `includeNotes`, установленным в `True`, чтобы включить слайды с заметками.

**В чём разница между ForEach.shape и Collect.shapes?**

Применяйте [ForEach.shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/#shape) для немедленной обработки каждой формы через обратный вызов. Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/collect/#shapes), когда нужен итерируемый результат, который можно сохранить, отфильтровать, подсчитать или пройти несколько раз.

**Всегда ли Compress уменьшает размер файла презентации?**

Не обязательно. Результат зависит от того, содержит ли презентация неиспользуемые макеты, шаблоны или вложенные шрифты с неиспользуемыми символами. Если таких элементов нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, выполненные ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/python-java/aspose.slides/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/), вызовите [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save), чтобы записать результат.

## **Связанные статьи**

- [Конвертировать презентацию](/slides/ru/python-java/convert-presentation/)
- [Объединить презентации](/slides/ru/python-java/merge-presentation/)
- [Шаблон слайда](/slides/ru/python-java/slide-master/)
- [Управление текстовым полем](/slides/ru/python-java/manage-textbox/)
- [Встроенный шрифт](/slides/ru/python-java/embedded-font/)