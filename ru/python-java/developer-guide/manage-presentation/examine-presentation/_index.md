---
title: Получить и обновить информацию о презентации в Python через Java
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/python-java/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализировать PPTX
- анализировать PPT
- анализировать ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument, используя Python через Java, для более быстрых выводов и более умных проверок содержимого."
---
## **Обзор**

Aspose.Slides может определить формат презентации и прочитать её метаданные без создания полной модели объектов презентации. Это полезно, когда необходимо классифицировать файлы, создать инвентарь или проверить свойства перед принятием решения о загрузке и обработке содержимого презентации.

Примеры требуют Aspose.Slides for Python via Java и совместимую среду выполнения Java. Каждый пример запускает JVM, если она ещё не запущена. Предоставьте существующие файлы презентаций по путям, использованным в примерах.

Эта статья демонстрирует лёгкую инспекцию через [PresentationFactory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/) и [PresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/), а также целевые обновления через [DocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/).

## **Проверка формата презентации**

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo) для инспекции файла без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). Метод [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#getLoadFormat) сообщает обнаруженный формат, например PPTX, PPT или ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Создание легковесного инвентаря презентаций**

Когда вы обрабатываете множество файлов презентаций, вам может потребоваться компактный инвентарь для проверки, индексации или системы управления документами. В этом сценарии используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo) для получения объекта [PresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/), а затем вызовите [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#readDocumentProperties) для чтения метаданных документа. Такой подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и не требует обхода полной модели объектов презентации.

Расширенные свойства, предоставляемые [DocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/), дают следующие значения инвентаря:

| Метод | Значение инвентаря |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getSlides) | Общее количество слайдов. |
| [getHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Количество скрытых слайдов. |
| [getNotes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getNotes) | Количество слайдов, содержащих заметки. |
| [getParagraphs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getParagraphs) | Общее количество абзацев, если доступно. |
| [getWords](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getWords) | Общее количество слов. |
| [getMultimediaClips](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Общее количество аудио и видеоклипов. |

Следующий пример считывает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и выводит компактный инвентарь. Он также комбинирует [getHeadingPairs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getHeadingPairs) с [getTitlesOfParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getTitlesOfParts) для отображения групп содержимого, таких как шрифты, темы и заголовки слайдов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Каждый [HeadingPair](https://reference.aspose.com/slides/ru/python-java/aspose.slides/headingpair/) предоставляет имя группы и количество элементов в этой группе. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getTitlesOfParts) возвращает плоский упорядоченный массив, поэтому используйте количество последовательных заголовков, указанных каждой парой заголовков.

### **Хранимые метаданные и ограничения формата**

Свойства инвентаря, возвращаемые [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#readDocumentProperties), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объектов презентации для пересчёта этих значений при этом вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, последним сохранявшее файл, не обновило свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для подсчёта слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедиа, а также пары заголовков и названия частей. Доступность зависит от того, какие свойства были записаны создателем документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства‑сводки документа. Если свойство отсутствует или не было обновлено создателем документа, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не рассчитывает его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не отображаются на каждое расширенное свойство PowerPoint. Метаданные о скрытых слайдах, слайдах‑заметках, мультимедиа, парах заголовков и названиях частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное подтверждение отсутствия соответствующего содержимого.

Используйте лёгкий подход к метаданным для инвентарей и предварительных проверок. Загружайте презентацию и проверяйте её живую модель объектов, когда результат должен отражать изменения в памяти или когда необходимо подтвердить фактическое содержание презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#readDocumentProperties), также можно изменять без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). Примените изменения с помощью [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), а затем запишите привязанную презентацию через [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Следующее изображение показывает исходные свойства документа.

![Исходные свойства документа PowerPoint презентации](input_properties.png)

Следующий пример изменяет заголовок и время последнего сохранения и записывает результат в новый файл:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Следующее изображение показывает изменённые свойства документа.

![Изменённые свойства документа PowerPoint презентации](output_properties.png)

## **Полезные ссылки**

Для связанных проверок безопасности и параметров защиты см. следующие статьи:

- [Password-Protect Presentations](/slides/ru/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/python-java/write-protected-presentation/)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getFontsManager). Вызовите [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) для получения встроенных шрифтов и [FontsManager.getFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getFonts) для получения шрифтов, используемых в презентации. Сравните два результата, чтобы найти шрифты, необходимые для рендеринга, но не встроенные.

**Как быстро определить, есть ли в файле скрытые слайды и сколько их?**

Если хранимые метаданные документа достаточны, прочитайте [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getHiddenSlides) через [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/#getPresentationInfo) и [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Это подходит для лёгкого инвентаря. Если презентация была изменена в памяти, хранимые метаданные могут отсутствовать или быть устаревшими, или нужно проверить живые значения — пройдитесь по [Presentation.getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides) и проверьте у каждого слайда метод [Slide.getHidden](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getHidden).

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и вызовите [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlideSize). Используйте [SlideSize.getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesize/#getSize) и [SlideSize.getOrientation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesize/#getOrientation) для сравнения текущих настроек с ожидаемыми предустановками и размерами.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждую [Chart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/) и вызовите [ChartData.getDataSourceType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getDataSourceType). Для внешней рабочей книги вызовите [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Тип источника данных и путь указывают на внешнюю ссылку, но проверка доступности цели требует отдельной проверки ресурсов.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Единого свойства сложности нет. Пройдитесь по [Presentation.getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides) и по коллекции [BaseSlide.getShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getShapes) каждого слайда. Используйте количество фигур и наличие больших изображений, эффектов, анимаций или мультимедиа как сигналы отбора, и измерьте репрезентативный рендеринг или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.