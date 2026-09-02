---
title: Операции с презентациями с низким кодом на JavaScript
linktitle: API низкого кода
type: docs
weight: 50
url: /ru/nodejs-java/low-code-presentation-operations/
keywords:
- API презентаций с низким кодом
- конвертировать презентацию
- объединить презентации
- перебор слайдов
- перебор фигур
- перебор текста
- собрать фигуры
- сжать презентацию
- удалить неиспользуемые образцовые слайды
- удалить неиспользуемые макетные слайды
- сжать встроенные шрифты
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Используйте API низкого кода Aspose.Slides на JavaScript для конвертации и объединения презентаций, перебора содержимого, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пространство имён `aspose.slides` предоставляет статические вспомогательные классы для общих операций с презентациями. Эти помощники инкапсулируют часто используемые рабочие процессы объектной модели в отдельные методы, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Помощники low-code наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный рабочий процесс удовлетворяет вашим требованиям. Используйте полную [Aspose.Slides object model](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/) при необходимости детального контроля над отдельными слайдами, образцами, макетами, фигурами, параметрами экспорта или связями между элементами презентации.

В следующей таблице перечислены доступные помощники:

| Помощник | Для чего использовать |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/convert/) | Конвертирование презентации в другой формат с помощью прямого вызова файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/) | Удаление неиспользуемых образцов и макетов и сокращение встроенных данных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert.autoByExtension](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/convert/#autoByExtension), когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат из пути выхода и записывает результат.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/convert/) также предоставляет отдельные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, если необходимо просмотреть или изменить презентацию перед экспортом или настроить параметр экспорта, который не доступен выбранному помощнику. См. [Конвертировать презентацию](/nodejs-java/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger.process](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/merger/#process) для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь один и тот же формат файла.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Этот помощник подходит, когда все слайды следует добавить к одному результирующему файлу без индивидуального выбора или переназначения. Используйте полную объектную модель, если необходимо объединять выбранные слайды, применять целевой образец или макет, явно сохранять разделы или согласовывать различный размер слайдов. См. [Объединить презентации](/nodejs-java/merge-presentation/) для этих сценариев.

## **Перебор элементов презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Это избегает вложенных циклов перебора коллекций и удобно для инспекции или изменения форматирования по всей презентации. В Node.js создавайте реализации интерфейсов обратного вызова с помощью `java.newProxy`.

В следующем примере используется [ForEach.slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#paragraph) и [ForEach.portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#portion) для проверки соответствующих элементов:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

По умолчанию обход фигур и текста по всей презентации включает обычные, образцовые и макетные слайды. Перегрузки с параметром `includeNotes` могут также обрабатывать слайды заметок. Используйте прямые циклы перебора, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальный контроль над родительско‑дочерними отношениями.

## **Собрать фигуры**

Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/collect/#shapes), когда требуется собрать все фигуры в презентации, а не вызывать обратный вызов для каждой фигуры. Это полезно, если один и тот же набор будет фильтроваться, подсчитываться или обрабатываться несколько раз.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#shape), если каждую фигуру можно обрабатывать сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/) может удалять неиспользуемые структурные элементы и уменьшать объём встроенных данных шрифтов:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) удаляет макетные слайды, на которые не ссылается ни один обычный слайд.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) удаляет образцовые слайды, которые больше не используются.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) удаляет неиспользуемые символы из встроенных шрифтов.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые образцы, чтобы образец, ставший неreferenced после очистки макетов, также был удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут потребоваться исходные образцы, макеты или полные данные встроенных шрифтов. Для получения более подробной информации см. [Слайд‑мастер](/nodejs-java/slide-master/) и [Встроенный шрифт](/nodejs-java/embedded-font/).

## **Вопросы и ответы**

**Когда следует использовать low-code API вместо полной объектной модели?**  
Используйте low-code помощники, когда стандартная операция применяется к полному файлу или презентации и не требует детального контроля над отдельными элементами. Используйте полную объектную модель, если необходимо выбрать конкретные слайды, управлять связями образцов и макетов, просматривать промежуточное состояние или настраивать поведение, которое не раскрывается помощником.

**Может ли Merger объединять презентации разных форматов файлов?**  
Нет. [Merger.process](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/merger/#process) требует, чтобы входные презентации были в одинаковом формате. Сначала конвертируйте входные файлы в общий формат, например с помощью [Convert.autoByExtension](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/convert/#autoByExtension), а затем объедините конвертированные файлы.

**Обрабатывает ли ForEach образцы, макеты и слайды заметок?**  
[ForEach.slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#slide) проходит по обычным слайдам презентации. Операции [ForEach.shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#paragraph) и [ForEach.portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#portion) по всей презентации включают по умолчанию обычные, образцовые и макетные слайды. Используйте их перегрузки с параметром `includeNotes`, установленным в `true`, чтобы включить слайды заметок.

**В чём разница между ForEach.shape и Collect.shapes?**  
Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#shape) для немедленной обработки каждой фигуры через обратный вызов. Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/collect/#shapes), когда нужен итерируемый результат, который можно сохранять, фильтровать, подсчитывать или обходить несколько раз.

**Всегда ли Compress уменьшает размер файла презентации?**  
Не обязательно. Результат зависит от наличия в презентации неиспользуемых макетов, неиспользуемых образцов или встроенных шрифтов с неиспользуемыми символами. Если их нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, сделанные ForEach или Compress, автоматически?**  
Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/) вызовите [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save), чтобы записать результат.

## **Связанные статьи**

- [Конвертировать презентацию](/nodejs-java/convert-presentation/)
- [Объединить презентации](/nodejs-java/merge-presentation/)
- [Слайд‑мастер](/nodejs-java/slide-master/)
- [Управление текстовым блоком](/nodejs-java/manage-textbox/)
- [Встроенный шрифт](/nodejs-java/embedded-font/)