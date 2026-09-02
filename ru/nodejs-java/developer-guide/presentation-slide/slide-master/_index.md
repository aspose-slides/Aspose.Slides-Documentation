---
title: Управление слайд‑мастерами презентации в JavaScript
linktitle: Слайд‑мастер
type: docs
weight: 70
url: /ru/nodejs-java/slide-master/
keywords:
- слайд‑мастер
- мастер‑слайд
- PPT‑мастер‑слайд
- множество мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонирование мастер‑слайда
- копирование мастер‑слайда
- дублирование мастер‑слайда
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управление слайд‑мастерами в Aspose.Slides для Node.js через Java: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Слайд‑мастер** определяет общие настройки дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, настройки темы и параметры нижнего колонтитула. В PowerPoint редактирование слайд‑мастера — обычный способ поддерживать согласованность презентации без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for Node.js via Java поддерживает ту же модель. Презентация может содержать один или несколько слайд‑мастеров, и каждый слайд‑мастер может содержать несколько макетных слайдов. Обычные слайды обычно не ссылаются напрямую на слайд‑мастер. Вместо этого обычный слайд использует макетный слайд, а этот макетный слайд принадлежит слайд‑мастеру.

Иерархия выглядит так:

1. **Слайд‑мастер** — определяет общие дизайн и тему.  
1. **Макетный слайд** — определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Обычный слайд** — содержит фактическое содержимое презентации и использует один макетный слайд.

![Иерархия слайд‑мастеров, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides слайд‑мастер представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/). Все слайд‑мастера в презентации доступны через коллекцию `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на нескольких уровнях, приоритет имеет более конкретный уровень. Например, если слайд‑мастер и макетный слайд оба задают фон, слайды, основанные на этом макете, используют фон макета. Подробнее о макетных слайдах см. в статье [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Доступ к слайд‑мастерам**

В PowerPoint вы можете открыть режим просмотра Слайд‑мастер через **View** > **Slide Master**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `getMasters()` для доступа к слайд‑мастерам:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Вы также можете получить слайд‑мастер, используемый обычным слайдом, через его макет:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Что содержит слайд‑мастер**

Слайд‑мастер — объект, похожий на слайд. Он наследует общие свойства слайдов от [BaseSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/), поэтому предоставляет многие те же свойства, которые используются в обычных и макетных слайдах. Члены, специфичные для мастера, перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/).

Часто используемые члены слайд‑мастера включают:

| Член | Назначение |
| --- | --- |
| `getBackground()` | Задает фон слайда уровня мастера. |
| `getShapes()` | Содержит фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides()` | Содержит макетные слайды, принадлежащие мастеру. |
| `getThemeManager()` | Предоставляет доступ к API темы мастера. |
| `getHeaderFooterManager()` | Управляет верхними/нижними колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `getDependingSlides()` | Возвращает обычные слайды, зависящие от мастера через их макеты. |

## **Добавление изображения в слайд‑мастер**

Когда вы добавляете изображение в слайд‑мастер, оно отображается на слайдах, использующих макеты из этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип на первый слайд‑мастер:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Подробнее о рамках изображений см. в статье [Picture Frame](/nodejs-java/picture-frame/).

## **Работа с заполнителями**

Заполнители обычно определяются на макетных слайдах. Слайд‑мастер предоставляет общий стиль и тему, которые наследуют эти макеты, а каждый макет решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в режиме просмотра Слайд‑мастер.

![Команда Insert Placeholder в режиме просмотра Slide Master в PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетным слайдом, принадлежащим мастеру:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Вы также можете изменить форматирование фигур‑заполнителей, уже существующих на слайд‑мастере. Следующий пример находит заполнитель заголовка и применяет линейную градиентную заливку:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Больше вариантов форматирования заполнителей и текста см. в статьях [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) и [Text Formatting](/nodejs-java/text-formatting/).

## **Изменение фона слайд‑мастера**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. Следующий пример задаёт сплошной цвет фона для первого слайд‑мастера:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

См. связанные темы: [Presentation Background](/nodejs-java/presentation-background/) и [Presentation Theme](/nodejs-java/presentation-theme/).

## **Клонирование слайд‑мастера в другую презентацию**

Используйте `MasterSlideCollection.addClone` для копирования слайд‑мастера в другую презентацию. Скопированный мастер затем может использоваться макетами и слайдами в целевой презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Если необходимо клонировать обычные слайды вместе с их мастером, см. в статье [Clone Slides](/nodejs-java/clone-slides/).

## **Добавление нескольких слайд‑мастеров**

Презентация может содержать несколько слайд‑мастеров. Это полезно, когда разные разделы требуют различного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления слайд‑мастерами](slide-master_9.jpg)

Следующий пример клонирует мастер по умолчанию, задаёт клону другой фон, создаёт макет под этим клонированным мастером и добавляет новый слайд на основе этого макета:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сравнение слайд‑мастеров**

Слайд‑мастера можно сравнивать методом `equals`, унаследованным от [BaseSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Подробнее см. в статье [Compare Presentation Slides](/slides/ru/nodejs-java/compare-slides/).

## **Установка просмотра слайд‑мастера по умолчанию**

Используйте метод `setLastView` на [ViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/) для управления тем, какой вид PowerPoint откроет первым. Следующий пример открывает презентацию в режиме просмотра Слайд‑мастер:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Больше настроек просмотра см. в статье [Save Presentation](/slides/ru/nodejs-java/save-presentation/).

## **Удаление неиспользуемых слайд‑мастеров**

В презентациях иногда остаются слайд‑мастера, которые больше не используются ни одним обычным слайдом. Удаление неиспользуемых мастеров может уменьшить размер файла и упростить обслуживание шаблонов.

Используйте `removeUnused` для удаления неиспользуемых мастеров из коллекции `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Вы также можете воспользоваться методом низкокодового API `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### В чём разница между слайд‑мастером и макетным слайдом?

Слайд‑мастер определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит слайд‑мастеру и задаёт конкретное расположение заполнителей. Обычный слайд использует макетный слайд, поэтому наследует свойства и от макета, и от мастера.

### Может ли одна презентация содержать несколько слайд‑мастеров?

Да. Презентация может включать несколько слайд‑мастеров. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендинга.

### Куда лучше добавлять заполнители: в слайд‑мастер или в макетный слайд?

В большинстве случаев заполнители добавляют в макетные слайды. Общие визуальные элементы и общие форматирования помещаются в слайд‑мастер, а заполнители контента — в макеты, которые будут использовать обычные слайды.

### Можно ли удалить слайд‑мастер, который всё ещё используется?

Нет. Слайд‑мастер, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала перенесите эти слайды к макетам другого мастера или используйте метод очистки неиспользуемых мастеров, который удаляет только те мастеры, которые не задействованы.