---
title: Операции над презентациями с низким кодом на Java
linktitle: API с низким кодом
type: docs
weight: 50
url: /ru/java/low-code-presentation-operations/
keywords:
- API с низким кодом для презентаций
- конвертировать презентацию
- объединить презентации
- перебор слайдов
- перебор фигур
- перебор текста
- сбор фигур
- сжатие презентации
- удалить неиспользуемые шаблоны слайдов
- удалить неиспользуемые макетные слайды
- сжатие встроенных шрифтов
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides для Java, чтобы конвертировать и объединять презентации, перебрать содержимое, собрать фигуры и уменьшить размер презентации."
---
## **Обзор**

Пакет [com.aspose.slides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/) предоставляет статические вспомогательные классы для распространённых операций с презентациями. Эти помощники инкапсулируют часто используемые рабочие процессы объектной модели в сфокусированных методах, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Помощники low‑code наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный рабочий процесс удовлетворяет требованиям. Используйте полную [object model Aspose.Slides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/), когда требуется тонкий контроль над отдельными слайдами, шаблонами, макетами, фигурами, параметрами экспорта или взаимосвязями между элементами презентации.

В следующей таблице приведено резюме доступных помощников:

| Помощник | Для чего использовать |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/java/com.aspose.slides/convert/) | Конвертирование презентации в другой формат вызовом файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/java/com.aspose.slides/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/) | Удаление неиспользуемых шаблонов и макетов и уменьшение объёма встроенных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert.autoByExtension](https://reference.aspose.com/slides/ru/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути вывода и записывает результат.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/java/com.aspose.slides/convert/) также предоставляет специальные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо просмотреть или изменить презентацию перед экспортом или настроить параметр экспорта, который не поддерживается выбранным помощником. Смотрите [Convert Presentation](/slides/ru/java/convert-presentation/) для рабочих процессов и опций, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger.process](https://reference.aspose.com/slides/ru/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь одинаковый формат файла.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Этот помощник подходит, когда все слайды должны быть добавлены к одному результату без индивидуального выбора или переназначения. Используйте полную объектную модель, когда необходимо объединить выбранные слайды, применить целевой шаблон или макет, явно сохранить разделы или согласовать разные размеры слайдов. Смотрите [Merge Presentations](/slides/ru/java/merge-presentation/) для подобных сценариев.

## **Итерация по элементам презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Он исключает вложенные циклы обхода коллекций и удобен для инспекции и изменения форматирования по всей презентации.

В следующем примере используются [ForEach.slide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), и [ForEach.portion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) для инспекции соответствующих элементов:

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

По умолчанию обход фигур и текста по всей презентации включает обычные, шаблонные и макетные слайды. Перегрузки с параметром `includeNotes` также могут обрабатывать слайды заметок. Используйте прямые циклы обхода коллекций, когда важен порядок обхода, ранний выход, фильтрация перед вызовом обратного вызова или детальный контроль родитель‑детский.

## **Собрать фигуры**

Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), когда вам требуется коллекция всех фигур в презентации, а не обратный вызов для каждой фигуры. Это удобно, если один и тот же набор будет фильтроваться, подсчитываться или обрабатываться более одного раза.

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

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), если каждая фигура может быть обработана сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/) может удалять неиспользуемые структурные элементы и уменьшать объём встроенных шрифтов:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) удаляет макетные слайды, на которые не ссылается ни один обычный слайд.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) удаляет шаблонные слайды, которые больше не используются.
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

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые шаблоны, чтобы шаблон, который становится без ссылок после очистки макетов, также мог быть удалён. Сохраните оптимизированную презентацию в новый файл, если позже вам могут потребоваться оригинальные шаблоны, макеты или полные данные встроенных шрифтов. Подробнее см. [Slide Master](/slides/ru/java/slide-master/) и [Embedded Font](/slides/ru/java/embedded-font/).

## **FAQ**

**Когда следует использовать low‑code API вместо полной объектной модели?**

Используйте low‑code помощники, когда стандартная операция применяется к полному файлу или презентации и не требует детального контроля над отдельными элементами. Используйте полную объектную модель, когда необходимо выбрать определённые слайды, управлять связями шаблонов и макетов, просматривать промежуточное состояние или настраивать поведение, которое не представлено помощником.

**Может ли Merger объединять презентации разных форматов файлов?**

Нет. [Merger.process](https://reference.aspose.com/slides/ru/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) требует, чтобы входные презентации были в одном формате. Сначала преобразуйте входные файлы в общий формат, например с помощью [Convert.autoByExtension](https://reference.aspose.com/slides/ru/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), а затем объедините преобразованные файлы.

**Обрабатывает ли ForEach шаблонные, макетные и слайды заметок?**

[ForEach.slide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) проходит по обычным слайдам презентации. Операции [ForEach.shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), и [ForEach.portion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) включают по умолчанию обычные, шаблонные и макетные слайды. Используйте их перегрузки с параметром `includeNotes`, установленным в `true`, чтобы включить слайды заметок.

**В чём разница между ForEach.shape и Collect.shapes?**

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), чтобы обрабатывать каждую фигуру сразу через обратный вызов. Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), когда нужен перебираемый результат, который можно сохранять, фильтровать, подсчитывать или обходить несколько раз.

**Всегда ли Compress уменьшает размер файла презентации?**

Не обязательно. Результат зависит от наличия в презентации неиспользуемых макетов, неиспользуемых шаблонов или встроенных шрифтов с неиспользуемыми символами. Если их нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, внесённые ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/java/com.aspose.slides/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/java/com.aspose.slides/compress/), вызовите [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-), чтобы записать результат.

## **Связанные статьи**

- [Конвертировать презентацию](/slides/ru/java/convert-presentation/)
- [Объединить презентации](/slides/ru/java/merge-presentation/)
- [Шаблон слайда](/slides/ru/java/slide-master/)
- [Управление текстовым полем](/slides/ru/java/manage-textbox/)
- [Встроенный шрифт](/slides/ru/java/embedded-font/)