---
title: Операции над презентациями с низким кодом на Android
linktitle: API с низким кодом
type: docs
weight: 50
url: /ru/androidjava/low-code-presentation-operations/
keywords:
- API низкокодовых презентаций
- конвертация презентации
- объединение презентаций
- итерация слайдов
- итерация фигур
- итерация текста
- сбор фигур
- сжатие презентации
- удаление неиспользуемых шаблонных слайдов
- удаление неиспользуемых макетных слайдов
- сжатие встроенных шрифтов
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides на Android для конвертации и объединения презентаций, итерации по содержимому, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пакет [com.aspose.slides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/) предоставляет статические вспомогательные классы для типовых операций с презентациями. Эти помощники инкапсулируют часто используемые процессы объектной модели в целевых методах, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Помощники low-code наиболее полезны, когда операция применяется ко всему файлу или презентации и стандартный рабочий процесс соответствует вашим требованиям. Используйте полную [Aspose.Slides object model](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/), когда требуется детальный контроль над отдельными слайдами, шаблонами, макетами, фигурами, параметрами экспорта или отношениями между элементами презентации.

Следующая таблица суммирует доступные помощники:

| Помощник | Для чего использовать |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/convert/) | Преобразование презентации в другой формат с прямым вызовом файл‑к‑файлу. |
| [Merger](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/) | Удаление неиспользуемых шаблонов и макетов и снижение объёма встроенных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert.autoByExtension](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), когда достаточно расширения выходного файла для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути вывода и записывает результат.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/convert/) также предоставляет специальные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо проанализировать или изменить презентацию перед экспортом или настроить параметр экспорта, который не доступен выбранному помощнику. См. [Convert Presentation](/androidjava/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger.process](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) для объединения полных файлов презентаций одним вызовом. Входные презентации должны быть в одинаковом формате.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Этот помощник подходит, когда все слайды должны быть добавлены к одному результату без индивидуального выбора или переназначения. Используйте полную объектную модель, когда необходимо объединять выбранные слайды, применять шаблон или макет назначения, явно сохранять разделы или согласовывать разные размеры слайдов. См. [Merge Presentations](/androidjava/merge-presentation/) для таких сценариев.

## **Итерировать элементы презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/) вызывает обратный вызов для каждого запрашиваемого типа элемента презентации. Он избавляет от вложенных циклов коллекций и удобен для проверки или изменения форматирования во всей презентации.

В следующем примере используется [ForEach.slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) и [ForEach.portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) для проверки соответствующих элементов:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

По умолчанию обход фигур и текста во всей презентации включает обычные, шаблонные и макетные слайды. Перегрузки с параметром `includeNotes` позволяют также обрабатывать слайды заметок. Используйте прямые циклы коллекций, когда важен порядок обхода, преждевременное прекращение, фильтрация до вызова обратного вызова или детальный контроль над иерархией.

## **Собрать фигуры**

Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), когда нужна коллекция всех фигур в презентации, а не обратный вызов для каждой фигуры. Это полезно, если один и тот же набор будет отфильтрован, подсчитан или обработан более одного раза.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), когда каждую фигуру можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/) может удалять неиспользуемые структурные элементы и уменьшать объём встроенных шрифтов:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) удаляет макетные слайды, на которые не ссылается ни один обычный слайд.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) удаляет шаблонные слайды, которые больше не используются.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) удаляет неиспользуемые символы из встроенных шрифтов.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые шаблоны, чтобы шаблон, ставший без ссылки после очистки макетов, также был удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут понадобиться оригинальные шаблоны, макеты или полный набор встроенных шрифтов. Для большей детализации смотрите [Slide Master](/androidjava/slide-master/) и [Embedded Font](/androidjava/embedded-font/).

## **FAQ**

**Когда следует использовать low-code API вместо полной объектной модели?**

Используйте low-code помощники, когда стандартная операция применяется к полному файлу или презентации и не требует детального управления отдельными элементами. Используйте полную объектную модель, когда нужно выбрать конкретные слайды, контролировать отношения шаблонов и макетов, проанализировать промежуточное состояние или настроить поведение, не открывающееся через помощник.

**Может ли Merger объединять презентации разных форматов файлов?**

Нет. [Merger.process](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) требует, чтобы входные презентации были в одинаковом формате. Сначала преобразуйте входные файлы в общий формат, например с помощью [Convert.autoByExtension](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), а затем объедините преобразованные файлы.

**Обрабатывает ли ForEach шаблонные, макетные и слайды заметок?**

[ForEach.slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) проходит только по обычным слайдам презентации. Во всей презентации [ForEach.shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) и [ForEach.portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) включают обычные, шаблонные и макетные слайды по умолчанию. Используйте их перегрузки с параметром `includeNotes`, установленным в `true`, чтобы включить слайды заметок.

**В чём разница между ForEach.shape и Collect.shapes?**

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), чтобы сразу обрабатывать каждую фигуру через обратный вызов. Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), когда нужен итерабельный результат, который можно сохранить, отфильтровать, подсчитать или обходить несколько раз.

**Всегда ли Compress делает файл презентации меньше?**

Необязательно. Результат зависит от наличия в презентации неиспользуемых макетов, неиспользуемых шаблонов или встроенных шрифтов с неиспользуемыми символами. Если ни один из этих элементов отсутствует, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, внесённые ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/), вызовите [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), чтобы записать результат.

## **Связанные статьи**

- [Конвертировать презентацию](/androidjava/convert-presentation/)
- [Объединить презентации](/androidjava/merge-presentation/)
- [Шаблон слайда](/androidjava/slide-master/)
- [Управление текстовым полем](/androidjava/manage-textbox/)
- [Встроенный шрифт](/androidjava/embedded-font/)