---
title: Управление мастер‑слайдами презентации в JavaScript
linktitle: Мастер‑слайд
type: docs
weight: 70
url: /ru/nodejs-java/slide-master/
keywords:
- мастер‑слайд
- мастер‑слайд
- PPT мастер‑слайд
- множественные мастер‑слайды
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонировать мастер‑слайд
- скопировать мастер‑слайд
- дублировать мастер‑слайд
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте мастер‑слайдами в Aspose.Slides for Node.js via Java: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**slide master** определяет общие настройки дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, настройки темы и настройки нижнего колонтитула. В PowerPoint редактирование slide master — обычный способ поддерживать презентацию в едином стиле без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for Node.js via Java поддерживает ту же модель. Презентация может содержать один или несколько master slides, и каждый master slide может содержать несколько layout slides. Обычные слайды обычно не ссылаются напрямую на master slide. Вместо этого обычный слайд использует layout slide, который принадлежит master slide.

Иерархия выглядит так:

1. **Slide master** - определяет общий дизайн и тему.  
1. **Layout slide** - определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Normal slide** - содержит фактическое содержание презентации и использует один layout slide.

![Иерархия master slides, layout slides и normal slides](slide-master_2.jpg)

В Aspose.Slides slide master представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) . Все master slides в презентации доступны через коллекцию `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на более чем одном уровне, выигрывает более конкретный уровень. Например, если master slide и layout slide оба определяют фон, слайды, основанные на этом layout, используют фон layout. Для получения дополнительной информации о layout slides см. [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Доступ к Slide Masters**

В PowerPoint вы можете открыть представление Slide Master через **View** > **Slide Master**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `getMasters()` для доступа к master slides:

```javascript
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

Вы также можете получить master slide, используемый обычным слайдом, через его layout:

```javascript
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

## **Что содержит Slide Master**

master slide — объект, похожий на слайд. Он наследует общее поведение слайда от [BaseSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/), поэтому имеет многие свойства слайда, используемые обычными и layout слайдами. Специфические для master члены перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) .

Часто используемые члены master slide включают:

| Член | Назначение |
| --- | --- |
| `getBackground()` | Устанавливает фон уровня master. |
| `getShapes()` | Хранит фигуры, размещённые на master, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides()` | Хранит layout slides, принадлежащие master. |
| `getThemeManager()` | Предоставляет доступ к API темы master. |
| `getHeaderFooterManager()` | Управляет колонтитулами, датами и номерами слайдов для master и его дочерних layout. |
| `getDependingSlides()` | Возвращает обычные слайды, зависящие от master через их layout. |

## **Добавить изображение в Slide Master**

Когда вы добавляете изображение в master slide, оно появляется на слайдах, использующих layout из этого master. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип к первому master slide:

```javascript
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

Для получения дополнительной информации о рамках изображений см. [Picture Frame](/nodejs-java/picture-frame/).

## **Работа с заполнителями**

Заполнители обычно определяются на layout slides. master slide обеспечивает общий стиль и тему, которые наследуют эти layout, а каждый layout решает, какие заполнители доступны и где они размещаются.

В PowerPoint команды заполнителей доступны в представлении Slide Master.

![Команда Insert Placeholder в представлении Slide Master PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с layout slide, принадлежащим master:

```javascript
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

Вы также можете форматировать формы заполнителей, уже существующие на master slide. Следующий пример находит заполнитель заголовка и применяет линейную градиентную заливку:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Для дополнительных вариантов форматирования заполнителей и текста см. [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) и [Text Formatting](/nodejs-java/text-formatting/).

## **Изменить фон Slide Master**

Фон master наследуется layout‑ами и слайдами, которые его не переопределяют. Следующий пример задаёт сплошной цвет фона для первого master slide:

```javascript
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

Для смежных тем см. [Presentation Background](/nodejs-java/presentation-background/) и [Presentation Theme](/nodejs-java/presentation-theme/).

## **Клонировать Slide Master в другую презентацию**

Используйте `MasterSlideCollection.addClone`, чтобы скопировать master slide в другую презентацию. Скопированный master затем может использоваться layout‑ами и слайдами в целевой презентации.

```javascript
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

Если необходимо клонировать обычные слайды вместе с их master, см. [Clone Slides](/nodejs-java/clone-slides/).

## **Добавить несколько Slide Masters**

Презентация может содержать несколько master slides. Это полезно, когда разные разделы требуют разного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления master slides](slide-master_9.jpg)

Следующий пример клонирует мастер по умолчанию, задаёт клону иной фон, создаёт layout под этим клонированным master и добавляет новый слайд на основе этого layout:

```javascript
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

## **Сравнить Slide Masters**

Master slides можно сравнивать методом `equals`, унаследованным от [BaseSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, например slide ID, или динамические значения заполнителей, такие как текущая дата.

```javascript
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

Для получения дополнительной информации см. [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **Установить просмотр Slide Master как представление по умолчанию**

Используйте метод `setLastView` на [ViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/), чтобы задать представление, которое PowerPoint откроет первым. Следующий пример открывает презентацию в представлении Slide Master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для дополнительных настроек представления см. [Save Presentation](/nodejs-java/save-presentation/).

## **Удалить неиспользуемые Master Slides**

Иногда презентации содержат master slides, которые больше не используются ни одним обычным слайдом. Удаление неиспользуемых master может уменьшить размер файла и упростить обслуживание шаблонов.

Используйте `removeUnused`, чтобы удалить неиспользуемые master из коллекции `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Вы также можете воспользоваться методом низкого кода `Compress.removeUnusedMasterSlides`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**В чём разница между slide master и layout slide?**

slide master определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. layout slide принадлежит master slide и задаёт конкретное расположение заполнителей. Обычный слайд использует layout slide, поэтому наследует как от layout, так и от master.

**Может ли одна презентация содержать несколько slide masters?**

Да. Презентация может содержать несколько slide masters. Используйте несколько master, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в master slide или в layout slide?**

В большинстве случаев заполнители добавляют в layout slides. Общие визуальные элементы и общие форматы размещайте на master slide, а места для контента — на layout, которые будут использовать обычные слайды.

**Можно ли удалить master slide, который всё ещё используется?**

Нет. master slide, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в layout‑ы под другим master или используйте метод очистки неиспользуемых master, который удаляет только те master, которые не задействованы.