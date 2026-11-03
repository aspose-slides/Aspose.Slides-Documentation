---
title: Управление заполнителями презентации в JavaScript
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/nodejs-java/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- заполнитель контента
- текст подсказки
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и контентные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Заполнитель — это фигура, резервирующая место для определённого типа содержимого в шаблоне презентации. Распространённые примеры — заполнители заголовка, основного текста, изображения, диаграммы и универсального контента. В отличие от обычной фигуры, заполнитель может наследовать своё положение, размер, форматирование и другие параметры от слайда‑макета или мастер‑слайда.

Aspose.Slides предоставляет информацию о заполнителе через метод [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). Метод возвращает объект [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) или `null` для обычной фигуры. Используйте [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType), чтобы определить, что заполнитель предназначен содержать.

Класс фигуры остаётся важным после определения типа заполнителя:

- Пустой текстовый, графический, диаграммный или контентный заполнитель обычно представлен объектом [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Заполненный графический заполнитель может быть представлен объектом [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Заполненный диаграммный заполнитель может быть представлен объектом [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Контентный заполнитель может содержать несколько видов содержимого. Проверяйте как [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType), так и класс фигуры во время выполнения, вместо того чтобы предполагать, что каждый заполнитель — это [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) описывает роль заполнителя; он не гарантирует тип фигуры во время выполнения. Всегда проверяйте тип перед доступом к членам текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Мастер‑слайд определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня мастера.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать от мастера.
3. Обычный слайд содержит заполнители для данного слайда и может наследовать от своего макета.

Вызовите [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder), чтобы перейти на один уровень выше в этой иерархии. Заполнитель слайда обычно возвращает его макетный заполнитель; макетный заполнитель может вернуть мастер‑заполнитель. Метод возвращает `null`, когда у фигуры нет базового заполнителя.

В следующем примере перечислены заполнители первого слайда и их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или меняет локальное переопределение для этого слайда. Изменение соответствующего макета или мастера может повлиять на все слайды, которые ещё наследуют данную настройку. Обычная локальная фигура не имеет базового заполнителя и не начинает наследовать только потому, что занимает те же координаты.

## **Удаление статуса заполнителя**

При адаптации шаблона используйте [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder), чтобы оставить существующий объект в виде обычной фигуры. Его метод [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) возвращает `null`, но фигура остаётся в коллекции слайда. В отличие от этого, [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) удаляет фигуру из этой коллекции.

В следующем примере требуется файл `template.pptx` минимум с одним слайдом и непустым текстовым заполнителем на первом слайде. Используйте заполнитель с форматированием, унаследованным от его макета или мастера, чтобы увидеть эффект удаления связи. Пример проверяет, что та же фигура остаётся, вызывает метод повторно для теперь уже обычной фигуры и сохраняет результат.

{{% alert color="warning" title="Warning" %}}
Удаление статуса заполнителя не сохраняет автоматически унаследованные параметры внешнего вида. Ниже приведённый пример намеренно оставляет эти параметры без изменений, поэтому вывод может выглядеть иначе. Фигура, позиция и размер которой полностью наследованы, может получить нулевые координаты и размеры после вызова и стать невидимой, хотя остаётся в коллекции.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Вызов метода на обычной фигуре не оказывает эффекта.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Для совпадающего заполнителя все три проверки выводят `true`. Текст остаётся, но унаследованные позиция, размер, вращение, шрифт, выравнивание абзаца, отступы текстового кадра, вертикальное привязка, заполнение и настройки линии могут измениться после удаления связи заполнителя. Например, унаследованное форматирование заголовка может вернуться к обычному текстовому форматированию. См. [Slide Layout](/slides/ru/nodejs-java/slide-layout/) для более подробной информации о макетах.

Чтобы сохранить требуемый внешний вид, зафиксируйте расчётные позицию, размер и вращение до вызова и скопируйте необходимые эффективные параметры форматирования в отдельные переменные. Получайте эти значения через [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) и [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Не полагайтесь только на объекты эффективного форматирования, так как их значения могут измениться после удаления связи. Явно примените зафиксированные значения к обычной фигуре позже, включая семейство шрифта, размер, стиль, цвет, параметры абзаца, настройки текстового кадра, заполнение и линию, используемые в вашем шаблоне.

Унаследованная геометрия фигуры также может потребовать явного назначения через [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). Для прямоугольного текстового заполнителя это означает назначение [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); восстановление только заполнения и линии может не восстановить видимый прямоугольник. Шаблоны с дополнительными эффектами или более сложным форматированием требуют также обработки этих настроек.

## **Изменение текста в заполнителе**

Заполнители заголовка, центрального заголовка, подзаголовка, тела и текста обычно поддерживают текст. Проверьте наличие [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) перед использованием его метода [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame).

В этом примере обновляется первый заполнитель заголовка на первом слайде и сохраняется результат:

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

Такой подход избегает обработки заполнителей изображения, диаграммы, таблицы или медиа как объектов [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс фигуры.

## **Установка текста подсказки в макете**

Текст подсказки — это инструкция, отображаемая в пустом заполнителе во время проектирования, например *Нажмите, чтобы добавить заголовок*. Задавайте пользовательский текст подсказки в заполнителе макета, а не через обычную коллекцию фигур слайда. Получите макет через [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) и пройдитесь по коллекции, возвращаемой [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

В следующем примере изменяются подсказки заголовка и подзаголовка в макете, который используется первым слайдом:

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

Текст подсказки не является обычным содержимым слайда. Он предназначен для пустых заполнителей в редакторах, таких как PowerPoint. Как только пользователь или программа вставит реальное содержимое, подсказка перестаёт отображаться. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление заполнителя изображения**

Существует два варианта обработки:

- Если графический заполнитель уже заполнен и представлен объектом [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), замените изображение через [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) и [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Если он всё ещё пустой, добавьте графический кадр в координаты заполнителя с помощью [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) и удалите пустой заполнитель.

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

Замена, созданная для пустого заполнителя, представляет собой локальный графический кадр, а не новый заполнитель, потому что [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) не предоставляет сеттер. Она сохраняет зарезервированное положение, но более не наследует поведение, специфичное для заполнителя. Если сохранение связи заполнителя критично, подготовьте и заполните заполнитель в PowerPoint сначала, затем обновите полученный [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для изображения, см. [Manage Picture Frames](/slides/ru/nodejs-java/picture-frame/). Эти операции относятся к графическому кадру или заливке изображения, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и контента**

Заполненный диаграммный заполнитель может быть представлен объектом [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Этот пример находит такую диаграмму по типу заполнителя и классу во время выполнения, меняет её заголовок и сохраняет файл:

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

Обычный контентный заполнитель обычно имеет [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). В PowerPoint он выступает в роли запускателя для нескольких типов содержимого, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверьте реальный класс фигуры, чтобы узнать, что она содержит. Специализированные макеты могут также использовать [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) или [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides не преобразует пустой [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) заполнитель в [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) просто изменяя [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); тип нельзя изменить через объект. Чтобы программно заполнить пустую диаграмму или область контента, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

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

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует свойства от макетного заполнителя. При необходимости заменять категории, серии или данные книги используйте специализированные статьи по управлению диаграммами ([chart management articles](/slides/ru/nodejs-java/powerpoint-charts/)).

## **Полный пример: обновление текста или изображения**

В следующем сквозном примере открывается шаблон, ищется первый слайд для заполнителя заголовка или изображения, проверяются типы заполнителя и фигуры, обновляется соответствующее содержимое и сохраняется результат. Пример намеренно избегает предположений о индексе фигуры или одинакового класса для всех заполнителей.

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

## **FAQ**

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующая фигура на макете или мастере, от которой наследуется другой заполнитель. Используйте [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder), чтобы получить его. Обычная локальная фигура возвращает `null`, потому что она не входит в иерархию заполнителей.

**Можно ли изменить все заголовки слайдов, редактируя заполнитель макета?**

Можно изменить унаследованное форматирование или текст подсказки через макет, но реальное содержимое заголовков хранится на обычных слайдах. Чтобы заменить фактический текст заголовков во всей презентации, пройдите по слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, заголовка и нижнего колонтитула?**

Используйте менеджеры заголовка и нижнего колонтитула на соответствующем уровне — слайд, макет, мастер, заметки или раздаточный материал. См. [Manage Presentation Header and Footer](/slides/ru/nodejs-java/presentation-header-and-footer/) для полных примеров.