---
title: Операции low-code с презентациями в Java
linktitle: Low-Code API
type: docs
weight: 50
url: /ru/java/low-code-presentation-operations/
keywords:
- low-code API презентаций
- конвертировать презентацию
- объединить презентации
- перебор слайдов
- перебор фигур
- перебор текста
- сбор фигур
- сжатие презентации
- удалить неиспользуемые мастер‑слайды
- удалить неиспользуемые макетные слайды
- сжать встроенные шрифты
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в Java для конвертации и объединения презентаций, перебора содержимого, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пакет [com.aspose.slides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/) предоставляет статические вспомогательные классы для типовых операций с презентациями. Эти помощники упаковывают часто используемые сценарии объектной модели в целевые методы, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим объёмом кода.

Вспомогательные средства low‑code наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный рабочий процесс удовлетворяет требованиям. Используйте полную [Aspose.Slides object model](https://reference.aspose.com/slides/ru/java/com.aspose.slides/), когда требуется тонкая настройка отдельных слайдов, мастеров, макетов, фигур, параметров экспорта или взаимосвязей между элементами презентации.

Ниже приведена таблица с обзором доступных помощников:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/java/com.aspose.slides/convert/) | Конвертация презентации в другой формат с прямым вызовом файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/java/com.aspose.slides/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или текстовой части. |
| [Collect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/) | Удаление неиспользуемых мастеров и макетов и уменьшение встроенных данных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert.autoByExtension](https://reference.aspose.com/slides/ru/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути выхода и записывает результат.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/java/com.aspose.slides/convert/) также предоставляет специализированные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо проверить или изменить презентацию перед экспортом или настроить параметр экспорта, который не доступен выбранному помощнику. См. [Convert Presentation](/java/convert-presentation/) для сценариев и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger.process](https://reference.aspose.com/slides/ru/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь одинаковый файловый формат.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Этот помощник подходит, когда все слайды должны быть добавлены к одному результату без отдельного выбора или переопределения. Используйте полную объектную модель, когда нужно объединить выбранные слайды, применить целевой мастер или макет, явно сохранить разделы или согласовать различный размер слайдов. См. [Merge Presentations](/java/merge-presentation/) для таких сценариев.

## **Итерировать элементы презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Он избавляет от вложенных циклов обхода коллекций и удобен для инспекции или изменения формата на уровне всей презентации.

В следующем примере используются [ForEach.slide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) и [ForEach.portion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) для инспекции соответствующих элементов:

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

По умолчанию обход фигур и текста по всей презентации включает обычные, мастер‑ и макетные слайды. Перегруженные варианты с параметром `includeNotes` также могут обрабатывать слайды заметок. Используйте прямые циклы обхода, когда важен порядок traversal, раннее завершение, фильтрация до вызова обратного вызова или детальное управление родитель‑дочерними отношениями.

## **Собирать фигуры**

Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) когда нужен набор всех фигур в презентации, а не обратный вызов для каждой фигуры. Это удобно, если один и тот же набор будет фильтроваться, подсчитываться или обрабатываться более одного раза.

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

Применяйте [ForEach.shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) вместо этого, когда каждую фигуру можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/) может удалять неиспользуемые структурные элементы и уменьшать встроенные данные шрифтов:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) удаляет макетные слайды, на которые не ссылаются обычные слайды.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) удаляет мастера, которые более не используются.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) удаляет неиспользуемые символы из встроенных шрифтов.

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

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые мастера, чтобы мастер, ставший непосланным после очистки макетов, тоже мог быть удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут понадобиться оригинальные мастера, макеты или полные данные встроенных шрифтов. Подробнее см. [Slide Master](/java/slide-master/) и [Embedded Font](/java/embedded-font/).

## **FAQ**

**Когда следует использовать low‑code API вместо полной объектной модели?**

Используйте low‑code помощники, когда стандартная операция применяется к полному файлу или презентации и не требует детального управления отдельными элементами. Используйте полную объектную модель, когда необходимо выбрать конкретные слайды, контролировать связи мастеров и макетов, проверять промежуточное состояние или настраивать поведение, не доступное через помощник.

**Может ли Merger объединять презентации разных форматов?**

Нет. [Merger.process](https://reference.aspose.com/slides/ru/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) требует, чтобы входные презентации были в одинаковом формате. Сначала конвертируйте входные файлы в общий формат, например с помощью [Convert.autoByExtension](https://reference.aspose.com/slides/ru/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), а затем объединяйте уже конвертированные файлы.

**Обрабатывает ли ForEach мастеровские, макетные и слайды заметок?**

[ForEach.slide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) перебирает обычные слайды презентации. По всей презентации [ForEach.shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) и [ForEach.portion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) включают обычные, мастер‑ и макетные слайды по умолчанию. Используйте их перегрузки с `includeNotes` = `true`, чтобы включить слайды заметок.

**В чём разница между ForEach.shape и Collect.shapes?**

Применяйте [ForEach.shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) для немедленной обработки каждой фигуры через обратный вызов. Применяйте [Collect.shapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) когда нужен итерируемый результат, который можно сохранять, фильтровать, подсчитывать или обходить несколько раз.

**Всегда ли Compress делает файл презентации меньше?**

Не обязательно. Результат зависит от наличия в презентации неиспользуемых макетов, неиспользуемых мастеров или встроенных шрифтов с неиспользуемыми символами. Если их нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, внесённые ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/) вызовите [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) для записи результата.

## **Связанные статьи**

- [Convert Presentation](/java/convert-presentation/)
- [Merge Presentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Manage Text Box](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)