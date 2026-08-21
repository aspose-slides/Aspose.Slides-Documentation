---
title: Управление руководящими линиями в презентациях на Android
linktitle: Руководящие линии
type: docs
weight: 85
url: /ru/androidjava/drawing-guides/
keywords:
- руководящая линия
- горизонтальная линия
- вертикальная линия
- линия выравнивания
- просмотр слайда
- мастер‑слайд
- макетный слайд
- мастер заметок
- мастер раздаточного материала
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Добавляйте, получайте доступ и очищайте горизонтальные и вертикальные руководящие линии в презентациях PowerPoint с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Руководящие линии – это регулируемые горизонтальные и вертикальные линии, помогающие пользователям последовательно выравнивать фигуры при редактировании презентации в PowerPoint. Они особенно полезны, когда приложение генерирует презентацию, которую затем необходимо доработать вручную: приложение может сохранить те же вспомогательные линии выравнивания, которым авторы должны следовать при добавлении или перемещении содержимого.

Руководящие линии являются средствами редактирования, а не содержимым слайда. Они не отображаются в показе слайдов и при рендеринге. Aspose.Slides for Android via Java предоставляет их через интерфейс [IDrawingGuidesCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguidescollection/). Руководящая линия представлена объектом [IDrawingGuide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguide/) и имеет ориентацию, позицию и цвет.

Позиция измеряется в пунктах от верхнего левого угла соответствующего слайда или шаблона. Вертикальная линия использует горизонтальную координату, обычно в диапазоне от нуля до ширины слайда. Горизонтальная линия использует вертикальную координату, обычно в диапазоне от нуля до высоты слайда.

## **Добавление руководящих линий в режим просмотра слайда**

Используйте [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) для управления линиями, отображаемыми при редактировании обычных слайдов. Вызовите [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) с значением [Orientation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/orientation/) и позицией в пунктах.

Следующий пример добавляет одну вертикальную линию справа от центра слайда и одну горизонтальную линию ниже него:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Доступ к руководящим линиям**

Методы [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) и [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) предоставляют доступ к существующим линиям. Методы [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguide/#getPosition--) и [IDrawingGuide.getColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguide/#getColor--) возвращают значения, которые также можно изменить с помощью соответствующих методов‑установщиков.

Следующий пример считывает руководящие линии режима просмотра слайда из презентации, созданной выше:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Добавление руководящих линий в мастер‑слайды и макетные слайды**

Мастер‑слайд и каждый из его макетных слайдов могут иметь собственные коллекции руководящих линий. Используйте [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) для мастер‑слайда и [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) для макетного слайда.

Следующий пример добавляет вертикальную линию к первому мастер‑слайду и горизонтальную линию к первому макетному слайду:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление руководящих линий в мастеры заметок и раздаточных материалов**

Мастера заметок и раздаточных материалов также поддерживают руководящие линии. Используйте [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) и [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) для доступа к их коллекциям. Если в презентации отсутствует один из этих мастеров, методы [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) или [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) создают мастер по умолчанию и возвращают его.

Следующий пример добавляет горизонтальную линию к мастеру заметок и вертикальную линию к мастеру раздаточных материалов:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Удаление руководящих линий**

Вызовите [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) для удаления всех линий из конкретной коллекции. Очистка одной коллекции не влияет на линии, хранящиеся в другой области.

Следующий пример очищает руководящие линии режима просмотра слайда и все линии на мастер‑слайдах, макетных слайдах, мастере заметок и мастере раздаточных материалов без создания отсутствующих мастеров:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Отображаются ли руководящие линии в показе слайдов или экспортированных изображениях?**

Нет. Руководящие линии являются вспомогательными средствами выравнивания при редактировании и не отображаются как содержимое презентации.

**Можно ли добавить руководящую линию непосредственно к отдельному обычному слайду?**

Руководящие линии редактирования обычных слайдов хранятся в свойствах режима просмотра слайда презентации. Отдельные коллекции линий доступны для мастер‑слайдов, макетных слайдов, мастеров заметок и мастеров раздаточных материалов.

**Какие единицы измерения используются для позиций линий?**

Позиции задаются в пунктах, где 72 пункта соответствуют одному дюйму. Вертикальные позиции измеряются от левой границы, а горизонтальные позиции — от верхней границы.

**Удаление руководящих линий удаляет формы или изменяет содержимое слайда?**

Нет. Метод [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) удаляет только линии в выбранной коллекции. Формы и другое содержимое слайда остаются без изменений.