---
title: Low-Code операции с презентациями в Python
linktitle: Low-Code API
type: docs
weight: 50
url: /ru/python-net/low-code-presentation-operations/
keywords:
- low-code API презентаций
- конвертация презентации
- объединение презентаций
- сбор фигур
- сжатие презентации
- удаление неиспользуемых слайдов-шаблонов
- удаление неиспользуемых макетных слайдов
- сжатие встроенных шрифтов
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в Python для конвертации и объединения презентаций, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Модуль [aspose.slides.lowcode](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/) предоставляет вспомогательные классы для часто используемых операций с презентациями. Эти помощники инкапсулируют типовые сценарии работы с объектной моделью в удобные методы, позволяя конвертировать или объединять файлы, собирать фигуры и удалять неиспользуемый контент с минимальным объёмом кода.

Помощники low‑code наиболее полезны, когда операция применяется ко всему файлу или презентации и стандартный рабочий процесс полностью удовлетворяет требованиям. Используйте полную [модель объектов Aspose.Slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/), если требуется детальный контроль над отдельными слайдами, шаблонами, макетами, фигурами, параметрами экспорта или взаимосвязями элементов презентации.

Ниже приведена таблица с доступными помощниками:

| Помощник | Для чего использовать |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/convert/) | Конвертация презентации в другой формат с помощью прямого вызова «файл‑в‑файл». |
| [Merger](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/merger/) | Объединение полных файлов презентаций одного и того же формата. |
| [Collect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/collect/) | Получение фигур из всей презентации для последующей обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/) | Удаление неиспользуемых шаблонов и макетов и уменьшение встроенных данных шрифтов. |

## **Конвертация презентации**

Используйте [Convert.auto_by_extension](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/convert/auto_by_extension/), когда достаточно указать расширение выходного файла для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат из пути вывода и записывает результат.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Класс [Convert](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/convert/) также предоставляет специальные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, если нужно просмотреть или изменить презентацию перед экспортом или задать параметр экспорта, который не предусмотрен выбранным помощником. См. [Convert Presentation](/python-net/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединение презентаций**

Используйте [Merger.process](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/merger/process/) для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь один и тот же формат файла.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Этот помощник подходит, когда все слайды необходимо добавить к единому результату без индивидуального выбора или переназначения. Применяйте полную объектную модель, если нужно объединять выбранные слайды, задавать целевой шаблон или макет, явно сохранять секции или согласовывать различный размер слайдов. См. [Merge Presentations](/python-net/merge-presentation/) для таких сценариев.

## **Сбор фигур**

Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/collect/shapes/), когда требуется собрать все фигуры в презентации. Это удобно, если один и тот же набор фигур будет фильтровать, подсчитывать или обрабатывать более одного раза.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Применяйте прямые циклы сбора, когда важен порядок обхода, раннее прерывание, фильтрация до обработки или детальное управление иерархией родитель‑друг.

## **Сжатие содержимого презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/) может удалять неиспользуемые структурные элементы и уменьшать вложенные данные шрифтов:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) удаляет макетные слайды, на которые не ссылаются обычные слайды.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) удаляет шаблонные слайды, которые больше не используются.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) удаляет неиспользуемые символы из встроенных шрифтов.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые шаблоны, чтобы шаблон, ставший непосвящённым после очистки макетов, также был удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут понадобиться оригинальные шаблоны, макеты или полные данные встроенных шрифтов. Подробности см. в статьях [Slide Master](/python-net/slide-master/) и [Embedded Font](/python-net/embedded-font/).

## **FAQ**

**Когда следует использовать low‑code API вместо полной объектной модели?**

Применяйте low‑code помощники, когда стандартная операция охватывает весь файл или презентацию и не требует детального контроля над отдельными элементами. Используйте полную объектную модель, если необходимо выбрать конкретные слайды, управлять отношениями шаблон‑макет, просматривать промежуточное состояние или задавать поведение, недоступное через помощник.

**Может ли Merger объединять презентации разных форматов?**

Нет. [Merger.process](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/merger/process/) требует, чтобы входные презентации имели одинаковый формат. Сначала преобразуйте входные файлы в общий формат, например с помощью [Convert.auto_by_extension](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/convert/auto_by_extension/), а затем объедините полученные файлы.

**Что включает в себя Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/collect/shapes/) извлекает фигуры из презентации, чтобы их можно было сохранять, фильтровать, подсчитывать или обходить многократно. Используйте прямые циклы сбора, когда нужен точный контроль над типами слайдов или вложенными объектами, которые посещаются.

**Всегда ли Compress делает файл презентации меньше?**

Не обязательно. Результат зависит от наличия в презентации неиспользуемых макетов, шаблонов или встроенных шрифтов с неиспользуемыми символами. Если таких элементов нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, внесённые Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) в памяти. После вызова [Compress](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/) необходимо вызвать [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) для записи результата.

## **Связанные статьи**

- [Convert Presentation](/python-net/convert-presentation/)
- [Merge Presentations](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)