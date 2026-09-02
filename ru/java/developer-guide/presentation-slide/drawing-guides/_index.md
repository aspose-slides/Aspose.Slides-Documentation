---
title: Управление направляющими при работе с презентациями в Java
linktitle: Направляющие
type: docs
weight: 85
url: /ru/java/drawing-guides/
keywords:
- направляющая
- горизонтальная направляющая
- вертикальная направляющая
- направляющая выравнивания
- просмотр слайда
- мастер‑слайд
- макетный слайд
- мастер заметок
- мастер раздаточного листа
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Добавьте, получите доступ и очистите горизонтальные и вертикальные направляющие в презентациях PowerPoint, используя Aspose.Slides для Java."
---
## **Обзор**

Линейки‑направляющие представляют собой регулируемые горизонтальные и вертикальные линии, помогающие пользователям последовательно выравнивать объекты при редактировании презентации в PowerPoint. Они особенно полезны, когда приложение генерирует презентацию, которая позже будет дорабатываться вручную: приложение может сохранять те же средства выравнивания, которым авторы должны следовать при добавлении или перемещении содержимого.

Линейки‑направляющие являются вспомогательными средствами редактирования, а не содержимым слайда. Они не отображаются в режиме показа слайдов и в выводимых файлах. Aspose.Slides for Java предоставляет их через интерфейс [IDrawingGuidesCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguidescollection/). Направляющая представлена объектом [IDrawingGuide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguide/) и имеет ориентацию, позицию и цвет.

Позиция измеряется в пунктах от верхнего левого угла соответствующего слайда или мастера. Вертикальная направляющая использует горизонтальную координату, обычно в диапазоне от нуля до ширины слайда. Горизонтальная направляющая использует вертикальную координату, обычно в диапазоне от нуля до высоты слайда.

## **Добавление направляющих в режиме просмотра слайда**

Используйте [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) для управления направляющими, отображаемыми при редактировании обычных слайдов. Вызовите [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) с значением [Orientation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/orientation/) и позицией в пунктах.

Следующий пример добавляет одну вертикальную направляющую справа от центра слайда и одну горизонтальную направляющую ниже него:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Доступ к направляющим**

Методы [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguidescollection/#getCount--) и [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) предоставляют доступ к существующим направляющим. Методы [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguide/#getPosition--) и [IDrawingGuide.getColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguide/#getColor--) возвращают значения, которые также можно изменить соответствующими методами‑установщиками.

Следующий пример читает направляющие режима просмотра слайда из презентации, созданной выше:

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

## **Добавление направляющих в мастер‑слайд и макеты**

Мастер‑слайд и каждый из его макетов могут иметь собственные коллекции направляющих. Используйте [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/#getDrawingGuides--) для мастера слайда и [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) для макетного слайда.

Следующий пример добавляет вертикальную направляющую к первому мастеру слайда и горизонтальную направляющую к первому макетному слайду:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление направляющих в мастера заметок и раздаточного листа**

Мастера заметок и раздаточного листа также поддерживают направляющие. Используйте [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) и [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) для доступа к их коллекциям. Если в презентации отсутствует один из этих мастеров, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) или [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) создаёт мастер по умолчанию и возвращает его.

Следующий пример добавляет горизонтальную направляющую к мастеру заметок и вертикальную направляющую к мастеру раздаточного листа:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Очистка направляющих**

Вызовите [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguidescollection/#clear--) для удаления всех направляющих из конкретной коллекции. Очистка одной коллекции не влияет на направляющие, хранящиеся в другой области.

Следующий пример очищает направляющие режима просмотра слайда и все направляющие на мастерах слайдов, макетных слайдах, мастере заметок и мастере раздаточного листа без создания отсутствующих мастеров:

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

## **FAQ**

**Отображаются ли направляющие в режиме показа слайдов или в экспортированных изображениях?**

Нет. Направляющие являются вспомогательными средствами выравнивания при редактировании и не отображаются как содержимое презентации.

**Можно ли добавить направляющую непосредственно к отдельному обычному слайду?**

Направляющие для обычных слайдов хранятся в свойствах просмотра слайдов презентации. Для мастеров слайдов, макетов, мастеров заметок и раздаточных листов доступны отдельные коллекции направляющих.

**В каких единицах задаются позиции направляющих?**

Позиции указываются в пунктах, где 72 пункта = один дюйм. Вертикальные позиции измеряются от левого края, горизонтальные — от верхнего края.

**Удаляет ли очистка направляющих фигуры или изменяет содержимое слайда?**

Нет. Метод [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idrawingguidescollection/#clear--) удаляет только направляющие из выбранной коллекции. Фигуры и другое содержимое слайда остаются без изменений.