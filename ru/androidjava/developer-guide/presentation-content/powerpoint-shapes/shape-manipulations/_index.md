---
title: Управление фигурами презентации на Android
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/androidjava/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Поиск фигуры
- Клонирование фигуры
- Удаление фигуры
- Скрытие фигуры
- Изменение порядка фигур
- Получение interop ID фигуры
- Альтернативный текст фигуры
- Форматы макета фигуры
- Фигура как SVG
- Фигура в SVG
- Выравнивание фигуры
- Отражение фигуры
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как выявлять, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Aspose.Slides for Android via Java представляет фигуры на слайде как упорядоченную [IShapeCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/). Коллекция одновременно является местом, где вы находите и изменяете фигуры, и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

В этой статье рассматривается описанная модель. Сначала объясняется, как надёжно идентифицировать фигуру, затем показывается, как клонировать, удалять, скрывать и менять порядок фигур. В заключительных разделах рассматриваются форматирование на уровне макета, экспорт в SVG, выравнивание и параметры отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые требуются в вашем рабочем процессе.

## **Определение и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигуры может изменить её индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getName--) полезно для шаблонов, контролируемых разработчиком, и легко просматривается в панели выбора PowerPoint. Имена можно редактировать, но они не гарантируют уникальность, поэтому следует установить соглашение об именовании, если код зависит от них.
- [AlternativeText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getAlternativeText--) удобно, когда описание доступности или тег, добавленный автором, уже идентифицирует фигуру. Текст видим пользователям, может быть локализован или переписан для доступности и также не гарантирует уникальность. Не переиспользуйте значимый текст доступности в качестве ключа базы данных.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) — идентификатор только для чтения, уникальный в пределах слайда и соответствующий ID фигуры, используемому в PowerPoint interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный ссылка на протяжении существования фигуры. Клонированная или воссозданная фигура — другая фигура и получает свой собственный ID.

Связанным методом является [getUniqueId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getUniqueId--), который возвращает идентификатор в рамках презентации, но предназначен для надстроек и может быть переопределён. Его не следует рассматривать как постоянный внешний ключ. Если долгосрочная идентичность важна, храните соответствие в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

В следующем примере происходит поиск по имени с точным сравнением и выводится interop‑ID в рамках слайда. Когда в шаблоне отсутствует ожидаемая фигура, код сообщает об этом вместо продолжения работы с неверным объектом.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Когда операция специфична для типа фигуры, проверяйте интерфейс перед использованием членов, характерных для типа. Этот пример обновляет текст и альтернативный текст только если именованный объект является [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания работают с коллекцией сразу. Если операция меняет количество или порядок фигур, не продолжайте пользоваться индексами, полученными до этой операции.

### **Клонирование фигуры**

[addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) создаёт независимую копию и добавляет её в конец целевой коллекции. [insertClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) также создаёт копию, но помещает её в указанный индекс порядка z. Перегрузки, принимающие координаты, перемещают клон без изменения его размеров; перегрузки с шириной и высотой могут изменять размер.

В примере создаётся целевой слайд, клонируется помеченный прямоугольник в переднюю часть и вставляется второй клон в заднюю часть. Изменения любого из клонов не влияют на исходную фигуру.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присваивайте новые логические идентификаторы клону, когда эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений во время итерации по индексам обходите коллекцию с конца, чтобы каждый оставшийся индекс оставался корректным.

В этом примере удаляется каждая фигура с заданным именем. Чтение происходит по текущему индексу, а не по фиксированному элементу коллекции, и не выполняется лишнее приведение типа.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

После удаления меняются количество фигур и индексы последующих фигур. Ссылки на незатронутые фигуры остаются надёжнее, чем сохранённые индексы. Также учитывайте соединители, анимации и другие элементы презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить более, чем только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) в `true` сохраняет фигуру в коллекции, но препятствует её отображению в обычном показе слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Скрытие — это не удаление и не средство защиты. Объект всё ещё может быть найден и сделан видимым пользователем или кодом, и он остаётся частью файла презентации.

### **Изменение порядка Z**

Перекрывающиеся фигуры отрисовываются в порядке коллекции. [reorder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `size() - 1` — передний.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Прямоугольник создаётся первым и изначально находится позади эллипса. Перемещение его к конечному индексу помещает его спереди. Завершайте настройку порядка Z после добавления или клонирования всех связанных фигур, так как эти операции добавляют или вставляют новые элементы коллекции и могут изменить предполагаемый стек.

## **Осмотр фигур в макетных слайдах**

Обычные слайды, макетные слайды и слайды‑мастера имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогично расположенная фигура на обычном слайде. Просматривайте фигуры макета, когда нужно понять или изменить форматирование, предоставляемое макетом.

В следующем примере читаются [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getFillFormat--) и [LineFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getLineFormat--) каждой фигуры макета без предположения, что каждая фигура является `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Редактирование макета может затронуть несколько слайдов, использующих его. Перед изменением фигуры макета определите, наследует ли обычный слайд объект или содержит локальное переопределение, и протестируйте каждый слайд, использующий данный макет.

## **Экспорт фигуры в SVG**

[writeAsSvg](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) записывает отрендеренное содержимое одной фигуры в поток. Результат содержит только фигуру, без фонового изображения слайда или соседних фигур.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если требуется экспортировать всю композицию, экспортируйте слайд, а не отдельную фигуру. Поток принадлежит вызывающему коду и должен быть закрыт им.

## **Выравнивание фигур**

Метод [SlideUtil.alignShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) имеет перегрузки для выравнивания всех фигур или выбранных индексов коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapesalignmenttype/) задаёт сторону, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; установите в `false`, чтобы выравнивать выбранные фигуры относительно друг друга.

В примере три фигуры выравниваются по верхнему краю слайда. Ссылки на фигуры преобразуются в их текущие индексы непосредственно перед выравниванием.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Выравнивание изменяет позиции, но не порядок Z. Относительное выравнивание обычно требует минимум две фигуры, а горизонтальное или вертикальное распределение — достаточное количество фигур для определения промежутков. Пересчитайте индексы, если изменяете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapeframe/) хранит позицию, размер, настройки горизонтального и вертикального отражения и вращения. Его свойства `getFlipH` и `getFlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/nullablebool/): `True` включает отражение, `False` отключает, а `NotDefined` сохраняет неуказанное/значение по умолчанию.

Входная презентация ниже содержит одну неотражённую фигуру.

![The shape before flipping](shape_to_be_flipped.png)

Пример сохраняет все остальные параметры кадра и заменяет только два параметра отражения. Это важно, потому что назначение нового [Frame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) заменяет весь кадр полностью.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённая фигура зеркально отражена горизонтально и вертикально, при этом её позиция, размер и вращение остаются прежними.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции в качестве идентификатора фигуры?**

Только для кратковременной обработки, когда коллекция не будет изменена до использования индекса. Предпочтительно использовать проверенное соглашение о `Name` или `AlternativeText` для шаблонов, созданных вручную, либо `OfficeInteropShapeId` для работы с interop в пределах слайда.

**Удаляется ли скрытая фигура из порядка Z?**

Нет. Скрытая фигура остаётся в коллекции под тем же индексом. Её можно найти, переупорядочить, отредактировать или снова сделать видимой.

**Почему клонированная фигура появилась перед другой фигурой?**

`addClone` добавляет клон в конец коллекции, что соответствует передней части порядка Z. Используйте `insertClone`, чтобы выбрать начальный индекс, или `reorder` после добавления всех фигур.