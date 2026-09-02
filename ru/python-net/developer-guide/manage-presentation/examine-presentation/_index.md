---
title: Получить и обновить информацию о презентации на Python
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/python-net/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- прочитать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- проверить PPTX
- проверить PPT
- проверить ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Python для более быстрых выводов и более интеллектуального аудита контента."
---
## **Обзор**

Aspose.Slides может определить формат презентации и прочитать её метаданные без создания полной модели объектов презентации. Это полезно, когда нужно классифицировать файлы, создать инвентарь или проверить свойства перед решением о загрузке и обработке содержимого презентации.

В этой статье демонстрируется лёгкая инспекция с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/) и [PresentationInfo](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/), а также целенаправленные обновления через [DocumentProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/).

## **Проверка формата презентации**

Используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) для инспекции файла без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Свойство [PresentationInfo.load_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/load_format/) сообщает обнаруженный формат, например PPTX, PPT или ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Создание лёгкого инвентаря презентаций**

Когда вы обрабатываете множество файлов презентаций, может потребоваться компактный инвентарь для проверки, индексирования или системы управления документами. В этом случае используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) для получения объекта [PresentationInfo](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/), а затем вызовите [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/read_document_properties/) для чтения метаданных документа. Этот подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и не требует обхода полной модели объектов презентации.

Расширенные свойства, предоставляемые [DocumentProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/), дают следующие значения инвентаря:

| Свойство | Значение инвентаря |
| --- | --- |
| [slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/slides/ru/) | Общее количество слайдов. |
| [hidden_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/hidden_slides/) | Количество скрытых слайдов. |
| [notes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/notes/) | Количество слайдов, содержащих заметки. |
| [paragraphs](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/paragraphs/) | Общее количество абзацев, если доступно. |
| [words](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/words/) | Общее количество слов. |
| [multimedia_clips](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/multimedia_clips/) | Общее количество аудио‑ и видеоклипов. |

Следующий пример читает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и выводит компактный инвентарь. Он также объединяет [heading_pairs](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/heading_pairs/) с [titles_of_parts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/titles_of_parts/) для отображения групп содержимого, таких как шрифты, темы и названия слайдов.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Каждый [HeadingPair](https://reference.aspose.com/slides/ru/python-net/aspose.slides/headingpair/) содержит имя группы и количество элементов в ней. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/titles_of_parts/) — это плоская упорядоченная коллекция, поэтому следует использовать количество последовательных заголовков, указанное каждой парой заголовков.

### **Хранимые метаданные и ограничения формата**

Свойства инвентаря, возвращаемые [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/read_document_properties/), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объектов презентации для перерасчёта этих значений при данном вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, которое последним сохраняло файл, не обновило свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для подсчёта слайдов, заметок, скрытых слайдов, абзацев, слов и медиа‑клипов, а также пары заголовков и названия частей. Доступность зависит от того, какие свойства записал производитель документа.
- **PPT:** Бинарный формат может сохранять соответствующие свойства‑резюме документа. Если свойство отсутствует или не было обновлено производителем документа, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не рассчитывает его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не соответствуют каждому расширенному свойству PowerPoint. Метаданные скрытых слайдов, заметок, медиа, пар заголовков и названий частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не следует рассматривать нулевое значение или пустую коллекцию как окончательное доказательство отсутствия соответствующего содержимого.

Используйте лёгкий подход к метаданным для инвентарей и предварительных проверок. Загружайте презентацию и инспектируйте её живую модель объектов, когда результат должен отражать изменения в памяти или когда необходимо проверить фактическое содержимое презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/read_document_properties/), также можно изменять без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Примените изменения с помощью [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/update_document_properties/), а затем запишите связанную презентацию через [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Следующее изображение показывает оригинальные свойства документа.

![Original document properties of the PowerPoint presentation](input_properties.png)

Следующий пример изменяет заголовок и время последнего сохранения и записывает результат в новый файл:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Следующее изображение показывает обновлённые свойства документа.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Полезные ссылки**

Для связанных проверок безопасности и настроек защиты см. следующие статьи:

- [Password-Protect Presentations](/slides/ru/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/python-net/write-protected-presentation/)

## **FAQ**

**Как проверить, внедрены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation.fonts_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/fonts_manager/). Вызовите [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) для получения внедрённых шрифтов и [FontsManager.get_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_fonts/) для получения шрифтов, используемых в презентации. Сравните два результата, чтобы найти шрифты, необходимые для рендеринга, но не внедрённые.

**Как быстро определить, есть ли скрытые слайды и сколько их?**

Если достаточно хранимых метаданных документа, прочитайте [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/hidden_slides/) через [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) и [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/read_document_properties/). Это подходит для лёгкого инвентаря. Если презентация была изменена в памяти, хранимые метаданные могут отсутствовать или быть устаревшими, либо требуется проверка актуальных значений: пройдитесь по [Presentation.slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slides/ru/) и проверьте свойство [Slide.hidden](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/hidden/) каждого слайда.

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и прочитайте [Presentation.slide_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slide_size/). Проверьте [SlideSize.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidesize/size/) и [SlideSize.orientation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidesize/orientation/) для сравнения текущих настроек с ожидаемыми предустановленными размерами и ориентацией.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждую [Chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/) и проверьте [ChartData.data_source_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/data_source_type/). Для внешней книги прочитайте [ChartData.external_workbook_path](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Тип источника данных и путь указывают на внешнюю ссылку, но проверка доступности цели требует отдельной проверки ресурсов.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Единственного свойства сложности нет. Пройдитесь по [Presentation.slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slides/ru/) и коллекции [BaseSlide.shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/shapes/) каждого слайда. Используйте количество фигур и наличие крупных изображений, эффектов, анимаций или медиа‑элементов как сигналы, а также измерьте представительный рендер или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.