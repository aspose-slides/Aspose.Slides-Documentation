---
title: Управление шаблонами слайдов презентации в JavaScript
linktitle: Шаблон слайда
type: docs
weight: 70
url: /ru/nodejs-java/slide-master/
keywords:
- шаблон слайда
- шаблон слайда
- шаблон PPT
- несколько шаблонов слайдов
- сравнение шаблонов слайдов
- фон
- заполнитель
- клонирование шаблона слайда
- копирование шаблона слайда
- дублирование шаблона слайда
- неиспользуемый шаблон слайда
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте шаблонами слайдов в Aspose.Slides для Node.js через Java: получайте доступ, редактируйте, клонируйте, сравнивайте и удаляйте шаблоны слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Шаблон слайда** определяет общие настройки дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, настройки темы и параметры колонтитулов. В PowerPoint редактирование шаблона слайда обычно используется для обеспечения согласованности презентации без необходимости повторять одно и то же форматирование на каждом слайде.

Aspose.Slides for Node.js via Java поддерживает ту же модель. Презентация может содержать один или несколько шаблонов слайдов, каждый из которых может включать несколько макетов слайдов. Обычные слайды обычно не ссылаются напрямую на шаблон слайда. Вместо этого обычный слайд использует макетный слайд, который принадлежит шаблону слайда.

Иерархия выглядит так:

1. **Шаблон слайда** – определяет общий дизайн и тему.  
1. **Макетный слайд** – определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Обычный слайд** – содержит фактическое содержимое презентации и использует один макетный слайд.

![Иерархия шаблонов слайдов, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides шаблон слайда представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/). Все шаблоны слайдов в презентации доступны через коллекцию `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на нескольких уровнях, приоритет имеет более конкретный уровень. Например, если шаблон слайда и макетный слайд оба задают фон, слайды, основанные на этом макете, используют фон макетного слайда. Подробнее о макетных слайдах см. в разделе [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Доступ к шаблонам слайдов**

В PowerPoint вы можете открыть режим просмотра шаблона слайда через **View** > **Slide Master**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `getMasters()` для доступа к шаблонам слайдов:

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

Вы также можете получить шаблон слайда, используемый обычным слайдом, через его макет:

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

## **Что содержит шаблон слайда**

Шаблон слайда – это объект, похожий на слайд. Он наследует общие свойства слайдов от [BaseSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/), поэтому предоставляет многие из тех же свойств, что и обычные и макетные слайды. Специфические для шаблона члены перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/).

Часто используемые члены шаблона слайда включают:

| Член | Назначение |
| --- | --- |
| `getBackground()` | Устанавливает фон шаблона уровня слайда. |
| `getShapes()` | Сохраняет фигуры, размещённые на шаблоне, такие как логотипы, рамки изображений и общий текст. |
| `getLayoutSlides()` | Сохраняет макетные слайды, принадлежащие шаблону. |
| `getThemeManager()` | Предоставляет доступ к API темы шаблона. |
| `getHeaderFooterManager()` | Управляет колонтитулами, датами и номерами слайдов для шаблона и его дочерних макетов. |
| `getDependingSlides()` | Возвращает обычные слайды, зависящие от шаблона через их макеты. |

## **Добавление изображения в шаблон слайда**

Когда вы добавляете изображение в шаблон слайда, оно появляется на слайдах, использующих макеты этого шаблона. Это полезно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип на первый шаблон слайда:

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

Для получения дополнительной информации о рамках изображений см. раздел [Picture Frame](/nodejs-java/picture-frame/).

## **Управление видимостью графики шаблона**

Используйте [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes), чтобы скрыть унаследованную графику шаблона, такую как логотипы или декоративные фигуры, без их удаления из шаблона. Передайте `false` в [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#setShowMasterShapes) на слайде, где необходимо скрыть эту графику, и оставьте `true` на слайдах, где она должна отображаться.

Следующий автономный пример создаёт синюю декоративную полосу на шаблоне и два слайда, использующие один и тот же пустой макет. Полоса видима на первом слайде и скрыта на втором. Входная презентация или изображение не требуются.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Пример использует макет **Blank**, поставляемый с новой презентацией, и удаляет собственные заполняющие элементы первоначального слайда.

### **Выбор области применения настройки**

Обычный слайд использует свой шаблон через [Slide.getLayoutSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getLayoutSlide) и [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Установка свойства на отдельном слайде влияет только на него. Передача `false` в [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) скрывает графику шаблона для всех слайдов, использующих общий макет, даже если их собственная настройка `true`. Чтобы скрыть графику только на одном слайде, измените свойство самого слайда и оставьте общий макет без изменений.

Настройка не поддерживается как элемент управления видимостью непосредственно на шаблоне слайда. На шаблоне [getShowMasterShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) всегда возвращает `false`, а передача `true` в [setShowMasterShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) вызывает исключение. Применяйте её к обычному слайду или к макетному слайду.

### **Отличие графики от фона**

| Операция | Эффект |
| --- | --- |
| Скрыть графику шаблона | Управляет видимостью унаследованных фигур шаблона без их удаления или изменения собственных фигур слайда. |
| Изменить заливку фона слайда | Меняет цвет, градиент или изображение фона. Графика шаблона – отдельные фигуры и может оставаться видимой над этим фоном. См. раздел [Presentation Background](/slides/ru/nodejs-java/presentation-background/). |
| Удалить фигуру из шаблона | Убирает общую исходную фигуру, поэтому она больше недоступна ни одному слайду, использующему этот шаблон. |

## **Работа с заполнителями**

Заполнители обычно определяются на макетных слайдах. Шаблон слайда предоставляет общий стиль и тему, которые наследуются макетами, а каждый макет решает, какие заполнители доступны и где они размещаются.

В PowerPoint команды заполнителей доступны в режиме просмотра шаблона слайда.

![Команда Insert Placeholder в режиме просмотра шаблона слайда PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетным слайдом, принадлежащим шаблону:

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

Вы также можете форматировать уже существующие фигуры заполнителей на шаблоне слайда. В следующем примере находится заполнитель заголовка и применяется линейная градиентная заливка:

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

Для дополнительных параметров заполнителей и форматирования текста см. [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) и [Text Formatting](/nodejs-java/text-formatting/).

## **Изменение фона шаблона слайда**

Фон шаблона наследуется макетами и слайдами, которые его не переопределяют. Следующий пример задаёт сплошной цвет фона для первого шаблона слайда:

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

См. также разделы [Presentation Background](/nodejs-java/presentation-background/) и [Presentation Theme](/nodejs-java/presentation-theme/).

## **Клонирование шаблона слайда в другую презентацию**

Используйте `MasterSlideCollection.addClone`, чтобы скопировать шаблон слайда в другую презентацию. Скопированный шаблон затем может быть использован макетами и слайдами в целевой презентации.

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

Если требуется клонировать обычные слайды вместе с их шаблоном, см. раздел [Clone Slides](/nodejs-java/clone-slides/).

## **Добавление нескольких шаблонов слайдов**

Презентация может содержать несколько шаблонов слайдов. Это полезно, когда разные разделы требуют различного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления шаблонами слайдов](slide-master_9.jpg)

В следующем примере клонируется шаблон по умолчанию, клону задаётся другой фон, под этим клоном создаётся макет, и добавляется новый слайд, основанный на этом макете:

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

## **Сравнение шаблонов слайдов**

Шаблоны слайдов можно сравнивать методом `equals`, унаследованным от [BaseSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

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

Подробнее см. в разделе [Compare Presentation Slides](/slides/ru/nodejs-java/compare-slides/).

## **Установка просмотра шаблона слайда в качестве представления по умолчанию**

Используйте метод `setLastView` на [ViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/), чтобы задать представление, которое PowerPoint открывает первым. Следующий пример открывает презентацию в режиме просмотра шаблона слайда:

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

Для дополнительных параметров просмотра см. раздел [Save Presentation](/slides/ru/nodejs-java/save-presentation/).

## **Удаление неиспользуемых шаблонов слайдов**

Иногда презентации содержат шаблоны слайдов, которые больше не используются ни одним обычным слайдом. Удаление таких шаблонов может уменьшить размер файла и упростить обслуживание шаблонов.

Используйте `removeUnused`, чтобы удалить неиспользуемые шаблоны из коллекции `getMasters()`:

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

Можно также воспользоваться методом низкоуровневого кода `Compress.removeUnusedMasterSlides`:

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

**В чём разница между шаблоном слайда и макетным слайдом?**

Шаблон слайда определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит шаблону и определяет конкретное расположение заполнителей. Обычный слайд использует макетный слайд, тем самым наследуя свойства как от макета, так и от шаблона.

**Можно ли в одной презентации иметь несколько шаблонов слайдов?**

Да. Презентация может содержать несколько шаблонов слайдов. Используйте несколько шаблонов, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в шаблон слайда или в макетный слайд?**

В большинстве случаев заполнители добавляют в макетные слайды. Общие визуальные элементы и общие параметры форматирования помещайте в шаблон, а заполнители содержимого — в макеты, которые будут использовать обычные слайды.

**Можно ли удалить шаблон слайда, который всё ещё используется?**

Нет. Шаблон слайда, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала перенесите эти слайды в макеты другого шаблона или используйте метод очистки неиспользуемых шаблонов, который удаляет только те шаблоны, которые не задействованы.