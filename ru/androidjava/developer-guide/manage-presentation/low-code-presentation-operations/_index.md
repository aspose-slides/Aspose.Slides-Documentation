---
title: Операции low-code с презентациями на Android
linktitle: API low-code
type: docs
weight: 50
url: /ru/androidjava/low-code-presentation-operations/
keywords:
- API low-code для презентаций
- конвертация презентации
- объединение презентаций
- перебор слайдов
- перебор фигур
- перебор текста
- сбор фигур
- сжатие презентации
- удаление неиспользуемых мастер-слайдов
- удаление неиспользуемых макетных слайдов
- сжатие встроенных шрифтов
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides на Android для конвертации и объединения презентаций, перебора содержимого, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пакет [com.aspose.slides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/) предоставляет статические вспомогательные классы для обычных операций с презентациями. Эти помощники инкапсулируют часто используемые рабочие процессы объектной модели в целевых методах, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим объёмом кода.

Помощники low-code наиболее полезны, когда операция применяется ко всему файлу или презентации и стандартный рабочий процесс удовлетворяет вашим требованиям. Используйте полную [Aspose.Slides object model](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/) при необходимости тонкого контроля над отдельными слайдами, шаблонами, макетами, фигурами, параметрами экспорта или взаимосвязями между элементами презентации.

Ниже представлена таблица, суммирующая доступные помощники:

| Помощник | Для чего использовать |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/convert/) | Конвертация презентации в другой формат с прямым вызовом файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/) | Удаление неиспользуемых шаблонов и макетов и уменьшение встроенных данных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert.autoByExtension](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути вывода и записывает результат.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/convert/) также предоставляет специализированные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо просмотреть или изменить презентацию перед экспортом или настроить параметр экспорта, который не доступен выбранному помощнику. См. [Convert Presentation](/slides/ru/androidjava/convert-presentation/) для рабочих процессов и параметров, специфичных для формата.

## **Объединить презентации**

Используйте [Merger.process](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь один и тот же формат файла.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Помощник подходит, когда все слайды должны быть добавлены к одному результату без индивидуального выбора или переназначения. Используйте полную объектную модель, если нужно объединить выбранные слайды, применить целевой шаблон или макет, явно сохранить разделы или согласовать различные размеры слайдов. См. [Merge Presentations](/slides/ru/androidjava/merge-presentation/) для таких сценариев.

## **Итерировать элементы презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Он избавляет от вложенных циклов перебора коллекций и удобен для инспекции или изменения форматирования по всей презентации.

Следующий пример использует [ForEach.slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), и [ForEach.portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) для проверки соответствующих элементов:

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

По умолчанию перебор фигур и текста по всей презентации включает обычные, шаблонные и макетные слайды. Перегруженные методы с параметром `includeNotes` позволяют также обрабатывать слайды заметок. Используйте прямые циклы перебора, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальный контроль иерархии.

## **Собрать фигуры**

Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) когда требуется коллекция всех фигур в презентации, а не обратный вызов для каждой фигуры. Это полезно, если один и тот же набор будет фильтроваться, подсчитываться или обрабатываться более одного раза.

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

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) если каждую фигуру можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/) может удалять неиспользуемые структурные элементы и уменьшать объём встроенных данных шрифтов:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) удаляет макетные слайды, которые не используются ни одним обычным слайдом.
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

Удаляйте неиспользуемые макеты до неиспользуемых шаблонов, чтобы шаблон, ставший без ссылки после очистки макетов, также мог быть удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут понадобиться исходные шаблоны, макеты или полные данные встроенных шрифтов. Для получения более подробной информации см. [Slide Master](/slides/ru/androidjava/slide-master/) и [Embedded Font](/slides/ru/androidjava/embedded-font/).

## **FAQ**

**Когда следует использовать low-code API вместо полной объектной модели?**

Используйте low-code помощники, когда стандартная операция применяется к полному файлу или презентации и не требует детального контроля над отдельными элементами. Используйте полную объектную модель, если необходимо выбрать конкретные слайды, управлять связями шаблонов и макетов, просматривать промежуточное состояние или настраивать поведение, которое помощник не предоставляет.

**Может ли Merger объединять презентации разных форматов файлов?**

Нет. [Merger.process](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) требует, чтобы входные презентации имели один и тот же формат. Сначала преобразуйте входные файлы в общий формат, например с помощью [Convert.autoByExtension](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), а затем объедините преобразованные файлы.

**Обрабатывает ли ForEach шаблонные, макетные и слайды заметок?**

[ForEach.slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) перебирает обычные слайды презентации. По всей презентации операции [ForEach.shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), и [ForEach.portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) включают обычные, шаблонные и макетные слайды по умолчанию. Используйте их перегруженные варианты с `includeNotes` = `true`, чтобы включить слайды заметок.

**В чем разница между ForEach.shape и Collect.shapes?**

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) для обработки каждой фигуры сразу через обратный вызов. Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) когда нужен итерируемый результат, который можно сохранить, фильтровать, подсчитывать или обходить несколько раз.

**Необходимо ли Compress всегда уменьшать размер файла презентации?**

Не обязательно. Результат зависит от наличия в презентации неиспользуемых макетов, шаблонов или встроенных шрифтов с неиспользуемыми символами. Если их нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, внесённые ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/compress/), вызовите [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) для записи результата.

## **Связанные статьи**

- [Конвертировать презентацию](/slides/ru/androidjava/convert-presentation/)
- [Объединить презентации](/slides/ru/androidjava/merge-presentation/)
- [Шаблон слайда](/slides/ru/androidjava/slide-master/)
- [Управление текстовым полем](/slides/ru/androidjava/manage-textbox/)
- [Встроенный шрифт](/slides/ru/androidjava/embedded-font/)