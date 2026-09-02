---
title: Управление направляющими в презентациях на JavaScript
linktitle: Направляющие
type: docs
weight: 85
url: /ru/nodejs-java/drawing-guides/
keywords:
- направляющая
- горизонтальная направляющая
- вертикальная направляющая
- направляющая выравнивания
- просмотр слайда
- мастер‑слайд
- слайд‑макет
- мастер заметок
- мастер раздаточных материалов
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Добавляйте, получайте доступ и удаляйте горизонтальные и вертикальные направляющие в презентациях PowerPoint с помощью Aspose.Slides for Node.js via Java."
---
## **Обзор**

Направляющие — это регулируемые горизонтальные и вертикальные линии, помогающие пользователям последовательно выравнивать объекты при редактировании презентации в PowerPoint. Они особенно полезны, когда приложение генерирует презентацию, которую затем необходимо доработать вручную: приложение может сохранить те же вспомогательные линии выравнивания, которыми должны пользоваться авторы при добавлении или перемещении содержимого.

Направляющие являются вспомогательными средствами редактирования, а не содержимым слайда. Они не отображаются в режиме показа слайдов и не попадают в вывод. Aspose.Slides for Node.js via Java предоставляет их через класс [DrawingGuidesCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguidescollection/). Направляющая представлена объектом [DrawingGuide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguide/) и имеет ориентацию, позицию и цвет.

Позиция измеряется в пунктах от левого верхнего угла соответствующего слайда или шаблона. Вертикальная направляющая использует горизонтальную координату, обычно в диапазоне от нуля до ширины слайда. Горизонтальная направляющая использует вертикальную координату, обычно в диапазоне от нуля до высоты слайда.

## **Добавить направляющие в представление слайда**

Используйте [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) для управления направляющими, отображаемыми при редактировании обычных слайдов. Вызовите [DrawingGuidesCollection.add](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguidescollection/#add) с параметром [Orientation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/orientation/) и позицией в пунктах.

Следующий пример добавляет одну вертикальную направляющую справа от центра слайда и одну горизонтальную направляющую ниже её:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Доступ к направляющим**

Методы [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguidescollection/#getCount) и [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) предоставляют доступ к существующим направляющим. Методы [DrawingGuide.getOrientation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguide/#getPosition) и [DrawingGuide.getColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguide/#getColor) возвращают значения, которые также можно изменить с помощью соответствующих методов‑установщиков.

Следующий пример читает направляющие представления слайда из презентации, созданной выше:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Добавить направляющие к мастер‑слайдам и слайдам‑макетам**

Мастер‑слайд и каждый из его макетных слайдов могут иметь собственные коллекции направляющих. Используйте [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) для мастер‑слайда и [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) для макетного слайда.

Следующий пример добавляет вертикальную направляющую к первому мастер‑слайду и горизонтальную направляющую к первому макетному слайду:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавить направляющие к мастерам заметок и раздаточных материалов**

Мастера заметок и раздаточных материалов также поддерживают направляющие. Используйте [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) и [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) для доступа к их коллекциям. Если презентация не содержит один из этих мастеров, `MasterNotesSlideManager.setDefaultMasterNotesSlide` или `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` создаёт мастер по умолчанию и возвращает его.

Следующий пример добавляет горизонтальную направляющую к мастеру заметок и вертикальную направляющую к мастеру раздаточных материалов:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Очистить направляющие**

Вызовите [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguidescollection/#clear), чтобы удалить все направляющие из конкретной коллекции. Очистка одной коллекции не влияет на направляющие, хранящиеся в другой области.

Следующий пример очищает направляющие представления слайда и все направляющие на мастер‑слайдах, макетных слайдах, мастере заметок и мастере раздаточных материалов без создания отсутствующих мастеров:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Отображаются ли направляющие в режиме показа слайдов или в экспортированных изображениях?**

Нет. Направляющие — это вспомогательные средства выравнивания при редактировании и не рендерятся как содержимое презентации.

**Можно ли добавить направляющую непосредственно к отдельному обычному слайду?**

Направляющие для обычных слайдов хранятся в свойствах представления слайда презентации. Отдельные коллекции направляющих доступны для мастер‑слайдов, макетных слайдов, мастеров заметок и мастеров раздаточных материалов.

**Какие единицы измерения используются для позиций направляющих?**

Позиции указываются в пунктах, где 72 пункта = 1 дюйм. Вертикальные позиции измеряются от левого края, горизонтальные — от верхнего края.

**Удаляет ли очистка направляющих объекты или изменяет содержимое слайда?**

Нет. Метод [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/drawingguidescollection/#clear) удаляет только направляющие в выбранной коллекции. Объекты и другое содержимое слайда остаются без изменений.