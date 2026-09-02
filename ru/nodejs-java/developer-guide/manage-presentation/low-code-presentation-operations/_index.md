---
title: Операции с презентациями Low-Code в JavaScript
linktitle: Low-Code API
type: docs
weight: 50
url: /ru/nodejs-java/low-code-presentation-operations/
keywords:
- Low-Code API презентаций
- конвертация презентации
- объединение презентаций
- перебор слайдов
- перебор фигур
- перебор текста
- сбор фигур
- сжатие презентации
- удаление неиспользуемых мастер‑слайдов
- удаление неиспользуемых макетных слайдов
- сжатие встроенных шрифтов
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в JavaScript для конвертации и объединения презентаций, перебора содержимого, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пространство имён `aspose.slides` предоставляет статические вспомогательные классы для общих операций с презентациями. Эти вспомогательные классы инкапсулируют часто используемые рабочие процессы объектной модели в целевых методах, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим объёмом кода.

Вспомогательные средства low-code наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный рабочий процесс соответствует вашим требованиям. Используйте полную [Aspose.Slides объектную модель](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/) , когда требуется детальный контроль над отдельными слайдами, мастер‑слайдами, макетами, фигурами, параметрами экспорта или взаимоотношениями элементов презентации.

Следующая таблица суммирует доступные помощники:

| Помощник | Назначение |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/convert/) | Конвертация презентации в другой формат с прямым вызовом файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/merger/) | Объединение полных файлов презентаций одного формата. |
| [ForEach](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или фрагмента текста. |
| [Collect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/collect/) | Получение фигур из всей презентации для многократной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/) | Удаление неиспользуемых мастеров и макетов и сокращение встроенных данных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert.autoByExtension](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/convert/#autoByExtension), когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути вывода и записывает результат.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/convert/) также предоставляет специальные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда нужно просмотреть или изменить презентацию перед экспортом или настроить параметр экспорта, который не раскрыт выбранным помощником. См. [Convert Presentation](/slides/ru/nodejs-java/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger.process](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/merger/#process) для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь одинаковый формат файла.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Помощник подходит, когда все слайды должны быть добавлены к единому результату без выбора или переопределения их по отдельности. Используйте полную объектную модель, когда нужно объединять выбранные слайды, применять целевой мастер или макет, явно сохранять разделы или согласовывать разные размеры слайдов. См. [Merge Presentations](/slides/ru/nodejs-java/merge-presentation/) для этих сценариев.

## **Итерировать элементы презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Это избавляет от вложенных циклов коллекций и удобно для инспекции всей презентации или изменения форматирования. В Node.js создавайте реализации интерфейсов обратного вызова с помощью `java.newProxy`.

Следующий пример использует [ForEach.slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#paragraph) и [ForEach.portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#portion) для инспекции соответствующих элементов:

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

По умолчанию обход фигур и текста по всей презентации включает обычные, мастер‑ и макетные слайды. Перегрузки с параметром `includeNotes` могут также обрабатывать слайды заметок. Используйте прямые циклы коллекций, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальный контроль родитель‑дочерних отношений.

## **Собрать фигуры**

Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/collect/#shapes), когда вам нужна коллекция всех фигур в презентации, а не обратный вызов для каждой фигуры. Это удобно, если один и тот же набор будет отфильтрован, подсчитан или обработан более одного раза.

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

Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#shape) вместо этого, когда каждую фигуру можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/) может удалять неиспользуемые структурные элементы и сокращать встроенные данные шрифтов:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) удаляет макетные слайды, на которые не ссылается ни один обычный слайд.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) удаляет мастер‑слайды, которые больше не используются.
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

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые мастера, чтобы мастер, ставший нессылаемым после очистки макетов, также был удалён. Сохраните оптимизированную презентацию в новый файл, если позже может потребоваться оригинальные мастера, макеты или полные данные встроенных шрифтов. Для подробностей см. [Slide Master](/slides/ru/nodejs-java/slide-master/) и [Embedded Font](/slides/ru/nodejs-java/embedded-font/).

## **FAQ**

**Когда следует использовать low-code API вместо полной объектной модели?**  
Используйте low-code помощники, когда стандартная операция применяется к полному файлу или презентации и не требует детального управления отдельными элементами. Используйте полную объектную модель, когда нужно выбрать конкретные слайды, управлять связями мастеров и макетов, просматривать промежуточное состояние или настраивать поведение, не раскрытое помощником.

**Можно ли Merger объединять презентации разных форматов?**  
Нет. [Merger.process](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/merger/#process) требует, чтобы входные презентации имели одинаковый формат. Сначала преобразуйте входные файлы в общий формат, например с помощью [Convert.autoByExtension](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/convert/#autoByExtension), а затем объедините преобразованные файлы.

**Обрабатывает ли ForEach мастер‑слайды, макетные и слайды заметок?**  
[ForEach.slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#slide) проходит по обычным слайдам презентации. Операции [ForEach.shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#paragraph) и [ForEach.portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#portion) по умолчанию включают обычные, мастер‑ и макетные слайды. Используйте их перегрузки с параметром `includeNotes`, установленным в `true`, чтобы включить слайды заметок.

**В чём разница между ForEach.shape и Collect.shapes?**  
Используйте [ForEach.shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/foreach/#shape) для немедленной обработки каждой фигуры через обратный вызов. Используйте [Collect.shapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/collect/#shapes), когда нужен итерируемый результат, который можно сохранять, фильтровать, подсчитывать или проходить несколько раз.

**Всегда ли Compress уменьшает размер файла презентации?**  
Не обязательно. Результат зависит от наличия в презентации неиспользуемых макетов, мастеров или встроенных шрифтов с неиспользуемыми символами. Если их нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compress/) могут не снизить размер файла.

**Сохраняются ли изменения, внесённые ForEach или Compress, автоматически?**  
Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach] или после выполнения [Compress] вызовите [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save), чтобы записать результат.

## **Связанные статьи**

- [Convert Presentation](/slides/ru/nodejs-java/convert-presentation/)
- [Merge Presentations](/slides/ru/nodejs-java/merge-presentation/)
- [Slide Master](/slides/ru/nodejs-java/slide-master/)
- [Manage Text Box](/slides/ru/nodejs-java/manage-textbox/)
- [Embedded Font](/slides/ru/nodejs-java/embedded-font/)