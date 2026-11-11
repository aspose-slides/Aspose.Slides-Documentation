---
title: Управление зумом презентации в JavaScript
linktitle: Управление зумом
type: docs
weight: 60
url: /ru/nodejs-java/manage-zoom/
keywords:
- зум
- зум-рамка
- зум слайда
- зум раздела
- обзорный зум
- добавить зум
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: Создавайте и настраивайте Zoom с помощью Aspose.Slides для Node.js через Java — переходите между разделами, добавляйте миниатюры и переходы в презентациях PowerPoint.
---
## **Введение**

Zoom‑объекты PowerPoint позволяют переходить между конкретными слайдами и разделами во время показа слайдов. С помощью Aspose.Slides для Node.js через Java вы можете создавать зум‑слайды, зум‑разделы и зум‑резюме, а также настраивать их превью, границы и переходы.

![Обзор зумов PowerPoint](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Обзорный зум](#summary-zoom).
* Чтобы показывать только выбранные слайды, используйте [Slide Zoom](#slide-zoom).
* Чтобы показывать только один раздел, используйте [Section Zoom](#section-zoom).

## **Зум‑слайд**

Зумы слайдов позволяют исследовать связную информацию с одного обзорного слайда.

![Выбор слайдов для зум‑слайда](slidezoomsel.png)

Для объектов зум‑слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomimagetype/), класс [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) и методы класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/).

### **Создание Zoom‑рамок**

Используйте [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) для размещения ссылок на отдельные слайды на обзорном слайде. Этот пример создает два целевых слайда с разными фонами и метками, затем добавляет превью каждого на первый слайд и сохраняет презентацию в формате PPTX. Позиции и размеры рамок задаются в пунктах.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Создание Zoom‑рамок с пользовательскими изображениями**

Передайте пользовательское изображение в [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame), чтобы заменить стандартное превью целевого слайда. Этот пример использует локальное изображение, загружает его с помощью [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) и добавляет в презентацию через [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage). Получившаяся рамка отображает это изображение, оставаясь ссылкой на второй слайд.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    overviewSlide.getShapes().addZoomFrame(20, 20, 300, 200, slide, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Форматирование Zoom‑рамок**

В этом примере настраиваются две рамки зума слайдов. Первая рамка получает локальное изображение через [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage), а второй рамке задаётся пяти‑пунктовая штрихпунктирная розовая граница через [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat). Передача `false` в [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) скрывает фон второй рамки. Для пользовательского превью требуется локальное изображение; обе рамки сохраняют ссылки на свои слайды в сохранённом PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    let firstZoomFrame = overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    let secondZoomFrame = overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    firstZoomFrame.setZoomImage(previewImage);

    secondZoomFrame.getLineFormat().setWidth(5);
    secondZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 105, 180));
    secondZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    secondZoomFrame.setShowBackground(false);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Зум‑раздел**

Зум‑раздел связывает с разделом в вашей презентации. Используйте его, чтобы вернуться к теме или показать, как разные части презентации связаны между собой.

![Выбор раздела для зум‑раздела](seczoomsel.png)

Для объектов зум‑раздела Aspose.Slides предоставляет класс [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) и методы класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/).

### **Создание Zoom‑рамок разделов**

Создайте раздел с помощью [SectionCollection.addSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#addSection), затем передайте полученный объект в [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame). Этот пример помещает зум‑раздел на первый слайд и связывает его с разделом, начинающимся с цветного слайда. Позиции и размеры рамки задаются в пунктах, презентация сохраняется в формате PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Создание Zoom‑рамок разделов с пользовательскими изображениями**

Перегрузка с изображением метода [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame) позволяет отображать пользовательское превью, не меняя целевой раздел. Пример требует локального изображения, которое загружается через [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) и добавляется через [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage). Сохранённая презентация содержит зум‑раздел на первом слайде, связанный с вновь созданным разделом.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Изменение целевого раздела зум‑раздела**

Используйте [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/#setTargetSection), чтобы перенаправить существующий зум‑раздел без его пересоздания. Выберите заполненный раздел из коллекции [Presentation.getSections](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSections) той же презентации. Передача пустого раздела оставляет текущий целевой раздел без изменений, поэтому перед назначением проверьте [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection). Смотрите [Управление разделами слайдов](/slides/ru/nodejs-java/slide-section/) для получения дополнительной информации о разделах.

В следующем примере загружается файл презентации, который должен содержать несколько заполненных разделов, существующий зум‑раздел с именем `Section navigation` и раздел с уникальным именем `Results`. Пример ищет зум‑раздел на всех слайдах и находит назначение по имени, а не по индексу в коллекции, который может измениться при переупорядочивании разделов. Если имена не уникальны, используйте [Section.getSectionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSectionId) для идентификации назначения.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("section-zoom.pptx");
try {
    let zoom = null;
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            const shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.ISectionZoomFrame") && shape.getName() === "Section navigation") {
                zoom = shape;
                break;
            }
        }
        if (zoom != null) {
            break;
        }
    }

    let targetSection = null;
    for (let i = 0; i < presentation.getSections().size(); i++) {
        const section = presentation.getSections().get_Item(i);
        if (section.getName() === "Results") {
            targetSection = section;
            break;
        }
    }

    if (zoom == null || targetSection == null) {
        console.log("The section zoom or destination section was not found.");
    } else if (targetSection.getSlidesListOfSection().size() == 0) {
        console.log("The destination section is empty.");
    } else {
        let currentSection = zoom.getTargetSection();
        console.log("Current section: " + (currentSection == null ? "" : currentSection.getName()));
        zoom.setTargetSection(targetSection);
        presentation.save("section-zoom-updated.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

### **Форматирование Zoom‑рамок разделов**

Этот пример перемещает и изменяет размер зум‑раздела до 100 × 75 пунктов, задаёт локальное изображение через [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) и применяет двум пунктовую штрихпунктирную коричневую границу. Он включает [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent), чтобы после завершения раздела вернуться к исходному слайду, отключает [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) и задаёт длительность перехода 1,5 секунды через [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration). Для пользовательского превью требуется локальное изображение.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);

    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    sectionZoomFrame.setZoomImage(previewImage);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    sectionZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    sectionZoomFrame.getLineFormat().setWidth(2.5);

    sectionZoomFrame.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Обзорный зум**

Обзорный зум предоставляет обзор разделов презентации. Во время показа слайдов вы можете использовать его для перехода к разделу, пропуска вперед или возврата к теме без следования порядку слайдов.

![Выбор разделов для обзорного зума](sumzoomsel.png)

Для объектов обзорного зума Aspose.Slides предоставляет классы [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/) и [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/), а также методы класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/).

### **Создание обзорного зума**

Используйте [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSummaryZoomFrame) для создания обзора разделов презентации. Этот пример создает четыре раздела с различными фонами слайдов и добавляет обзорный зум на первый слайд. Позиции и размеры рамки задаются в пунктах, итоговый обзор сохраняется в PPTX‑презентации.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 3", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 100, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 4", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Добавление и удаление раздела обзорного зума**

Обзорный зум хранит объекты [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/) в коллекции, получаемой через [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Этот пример создаёт обзор из двух разделов, добавляет третий раздел с помощью [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) и удаляет запись первого раздела через [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Удаление записи не затрагивает сами разделы и их слайды.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let firstSection = presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let thirdSection = presentation.getSections().addSection("Section 3", slide);

    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(thirdSection);

    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(firstSection);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Форматирование разделов обзорного зума**

В этом примере форматируется первая запись в [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) (индекс 0). Требуется локальное изображение для [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage), применяется 1,5‑пунктовая штрихпунктирная черная граница и задаётся длительность перехода 1,5 секунды через [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration). Передача `false` в [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) отключает автоматическое возвращение к обзорному слайду для этой записи.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    let summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    summarySection.setZoomImage(previewImage);
    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    summarySection.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    summarySection.getLineFormat().setWidth(1.5);

    summarySection.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Можно ли управлять возвратом к «родительскому» слайду после показа цели?**

Да. Вызовите [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) с параметром `true`, чтобы после отображения целевого содержимого вернуться к исходному слайду.

**Можно ли изменить «скорость» или длительность перехода зума?**

Да. Используйте [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) для задания длительности перехода в секундах.

**Существуют ли ограничения на количество объектов Zoom в презентации?**

Жёсткого ограничения API не задокументировано. Практические ограничения зависят от общей сложности презентации и производительности устройства просмотра. Вы можете добавить множество Zoom‑рамок, однако следует учитывать размер файла и время рендеринга.