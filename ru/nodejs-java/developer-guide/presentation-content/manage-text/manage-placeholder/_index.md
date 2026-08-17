---
title: Управление заполнителями презентации в JavaScript
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/nodejs-java/manage-placeholder/
keywords:
- заполнитель
- заполнитель текста
- заполнитель изображения
- заполнитель диаграммы
- заполнитель содержимого
- текст подсказки
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать заполнители текста, изображения, диаграммы и содержимого, а также понимать наследование заполнителей с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Заполнитель — это фигура, резервирующая позицию для определённого типа содержимого в шаблоне презентации. Распространённые примеры — заполнители заголовка, основного текста, изображения, диаграммы и общего назначения. В отличие от обычной фигуры, заполнитель может наследовать свою позицию, размер, форматирование и другие параметры от слайда‑разметки или шаблона‑маски.

Aspose.Slides предоставляет информацию о заполнителях через метод [Shape.getPlaceholder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getPlaceholder). Метод возвращает объект [Placeholder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholder/) или `null` для обычной фигуры. Используйте [Placeholder.getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholder/#getType), чтобы определить, что предполагается разместить в заполнителе.

Класс фигуры всё равно имеет значение после того, как известен тип заполнителя:

- Пустой заполнитель текста, изображения, диаграммы или содержимого обычно представлен объектом [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/).
- Заполненный заполнитель изображения может быть представлен объектом [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/).
- Заполненный заполнитель диаграммы может быть представлен объектом [Chart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/).
- Заполнитель содержимого может включать несколько типов содержимого. Проверяйте как [Placeholder.getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholder/#getType), так и класс фигуры во время выполнения, вместо предположения, что каждый заполнитель является [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholder/#getType) описывает роль заполнителя; он не гарантирует тип фигуры во время выполнения. Всегда проверяйте тип перед доступом к членам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Шаблон‑маска определяет переиспользуемые стили и, в некоторых случаях, заполняющие элементы уровня маски.
2. Слайд‑разметка определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать его от маски.
3. Обычный слайд содержит заполнители для данного слайда и может наследовать их от своей разметки.

Вызовите [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getBasePlaceholder), чтобы переместиться на один уровень выше в этой иерархии. Заполнитель обычного слайда обычно возвращает свой заполнитель разметки; заполнитель разметки может вернуть свой заполнитель маски. Метод возвращает `null`, когда у фигуры нет базового заполнителя.

Следующий пример выводит список заполнителей на первом слайде и сообщает их базовые заполнители:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Изменение соответствующей разметки или маски может повлиять на все слайды, которые всё ещё наследуют эту настройку. Обычная локальная фигура не имеет базового заполнителя и не начинает наследовать просто потому, что занимает те же координаты.

## **Изменение текста в заполнителе**

Заполнители заголовка, центрированного заголовка, подзаголовка, основного текста и текста обычно поддерживают ввод текста. Проверьте, является ли фигура [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/), прежде чем использовать её метод [getTextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Этот пример обновляет первый заполнитель заголовка на первом слайде и сохраняет результат:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Такой подход избегает обращения к заполнителям изображения, диаграммы, таблицы или медиа как к объектам [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс фигуры.

## **Установка текста подсказки в макете**

Текст подсказки — это инструкция во время дизайна, отображаемая в пустом заполнителе, например *Нажмите, чтобы добавить заголовок*. Устанавливайте собственный текст подсказки в заполнителе разметки, а не пытаясь достать его через коллекцию фигур обычного слайда. Доступ к разметке осуществляется через [Slide.getLayoutSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getLayoutSlide), а затем перебирайте коллекцию, возвращённую [BaseSlide.getShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/#getShapes).

Следующий пример меняет подсказки заголовка и подзаголовка в разметке, используемой первым слайдом:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Текст подсказки — это не обычное содержимое слайда. Он предназначен для пустых заполнителей в редакторах, таких как PowerPoint. Как только пользователь или программа предоставляют реальное содержимое, подсказка больше не отображается. Изменение подсказки также не заменяет существующий текст на слайдах, использующих эту разметку.

## **Обновление заполнителя изображения**

Существует два варианта обработки:

- Если заполнитель изображения уже заполнен и представлен объектом [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/), замените изображение через [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#getPicture) и [Picture.setImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/#setImage).
- Если это всё ещё пустой заполнитель, добавьте объект изображения в координаты заполнителя с помощью [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) и удалите пустой заполнитель.

Следующий пример поддерживает оба случая и сохраняет презентацию:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Замена, созданная для пустого заполнителя, представляет собой локальный объект [PictureFrame], а не новый заполнитель, поскольку [Shape.getPlaceholder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getPlaceholder) не предоставляет сеттер. Она сохраняет зарезервированную позицию, но больше не наследует поведение, специфичное для заполнителя. Если сохранение отношений заполнителя критично, подготовьте и заполните заполнитель в PowerPoint сначала, а затем обновите полученный [PictureFrame] с помощью Aspose.Slides.

Для управления прозрачностью изображения, обрезкой и другими эффектами, специфичными для изображений, см. [Manage Picture Frames](/slides/ru/nodejs-java/picture-frame/). Эти операции относятся к объекту изображения или заливке, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и содержимого**

Заполненный заполнитель диаграммы может быть представлен объектом [Chart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/). Этот пример ищет такую диаграмму как по типу заполнителя, так и по классу исполнения, меняет её заголовок и сохраняет файл:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Обычный заполнитель содержимого обычно имеет тип [PlaceholderType.Object](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholdertype/#Object). В PowerPoint он служит «запускателем» для нескольких типов содержимого, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверьте фактический класс фигуры, чтобы узнать, что она содержит. Специализированные разметки могут также экспонировать типы [PlaceholderType.Chart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholdertype/#Media) или [PlaceholderType.Diagram](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides не преобразует пустой заполнитель [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) в объект [Chart] лишь изменением [Placeholder.getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/placeholder/#getType); тип нельзя изменить через объект. Чтобы программно заполнить пустую область диаграммы или содержимого, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Добавленная диаграмма является обычной локальной диаграммой. Она занимает область заполнителя, но не наследует свойства заполнителя разметки. Используйте специальные статьи по управлению диаграммами [chart management articles](/slides/ru/nodejs-java/powerpoint-charts/), когда необходимо заменить её категории, серии или данные рабочей книги.

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде заполнитель заголовка или изображения, проверяет типы заполнителя и фигуры, обновляет соответствующее содержимое и сохраняет результат. Пример сознательно избегает предположений о индексе фигуры и о том, что каждый заполнитель относится к одному классу.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующая фигура в разметке или маске, от которой другой заполнитель наследует свойства. Используйте [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getBasePlaceholder), чтобы получить его. Обычная локальная фигура возвращает `null`, потому что она не является частью иерархии заполнителей.

**Могу ли я изменить все заголовки слайдов, отредактировав заполнитель в макете?**

Вы можете изменить наследуемое форматирование или текст подсказки через макет, но существующее содержимое заголовков хранится в обычных слайдах. Чтобы заменить реальный текст заголовка во всей презентации, пройдитесь по слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры верхних и нижних колонтитулов на соответствующем уровне — слайд, разметка, маска, заметки или раздача. См. [Manage Presentation Header and Footer](/slides/ru/nodejs-java/presentation-header-and-footer/) для полных примеров.