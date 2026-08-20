---
title: Управление фигурами презентации в JavaScript
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/nodejs-java/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Поиск фигуры
- Клонирование фигуры
- Удаление фигуры
- Скрытие фигуры
- Изменение порядка фигур
- Получить ID interop фигуры
- Альтернативный текст фигуры
- Форматы макета фигуры
- Фигура как SVG
- Фигура в SVG
- Выравнивание фигуры
- Отражение фигуры
- PowerPoint
- Презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как идентифицировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides for Node.js via Java представляет фигуры на слайде как упорядоченную [ShapeCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/). Коллекция служит одновременно местом, где вы находите и изменяете фигуры, и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

Эта статья следует этой модели. Сначала она объясняет, как надёжно идентифицировать фигуру, затем показывает, как копировать, удалять, скрывать и переупорядочивать фигуры. Заключительные разделы охватывают форматирование уровня макета, экспорт в SVG, выравнивание и настройки отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые требуются вашему рабочему процессу.

## **Идентификация и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигуры может изменить её индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getname/) полезен для шаблонов, управляемых разработчиком, и легко просматривается в панели выделения PowerPoint. Имена можно изменять, и они не гарантируют уникальность, поэтому установите соглашение об именовании, если код зависит от них.
- [AlternativeText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getalternativetext/) полезен, когда уже существует описание доступности или тег, заданный автором, идентифицирующий фигуру. Оно видимо пользователям, может быть локализовано или переписано для доступности и не гарантирует уникальность. Не переиспользуйте значимый текст доступности в качестве ключа базы данных.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) — лишь для чтения, уникален в пределах слайда и соответствует идентификатору фигуры, используемому в межоперационной работе PowerPoint. Используйте его при интеграции с PowerPoint или когда нужен однозначный ссылочный идентификатор в течение жизни фигуры. Склонированная или воссозданная фигура — это другая фигура и получает собственный идентификатор.

Связанный метод [getUniqueId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getuniqueid/) возвращает идентификатор в контексте презентации, но он предназначен для надстроек и может быть переназначен. Не следует рассматривать его как постоянный внешний ключ. Если требуется долгосрочная идентичность, храните сопоставление в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

В следующем примере осуществляется поиск по имени с точным сравнением и выводится межоперационный идентификатор, ограниченный слайдом. Когда шаблон не содержит ожидаемую фигуру, код сообщает об этом, а не продолжает работу с неверным объектом.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Если операция специфична для типа фигуры, проверьте класс во время выполнения перед использованием членов, характерных для типа. В этом примере обновляются текст и альтернативный текст только если именованный объект является [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Модификация коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания работают с коллекцией сразу. Если операция меняет количество или порядок фигур, не полагайтесь на индексы, захваченные до этой операции.

### **Клонирование фигуры**

[addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/addclone/) создаёт независимую копию и добавляет её в конец целевой коллекции. [insertClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/insertclone/) также создаёт копию, но помещает её в указанный индекс порядка Z. Перегрузки, принимающие координаты, перемещают клон без изменения размеров; перегрузки с шириной и высотой могут также изменить размер.

В примере создаётся целевой слайд, клонируется помеченный прямоугольник на передний план и вставляется второй клон в задний план. Изменения любого из клонов не влияют на исходную фигуру.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новые логические идентификаторы клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[remove](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/remove/) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений во время итерации по индексам, проходите от конца, чтобы каждый оставшийся индекс оставался действительным.

В этом примере удаляются все фигуры с заданным именем. Он читает фигуру по текущему индексу и не предполагает конкретный тип фигуры.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

После удаления меняются количество фигур и индексы последующих фигур. Ссылки на неизменённые фигуры остаются надёжнее, чем сохранённые индексы. Также учитывайте соединители, анимацию и другие возможности презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить больше, чем только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/sethidden/) в `true` сохраняет фигуру в коллекции, но не позволяет ей появляться в обычном показе слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Скрытие — это не удаление и не средство защиты. Объект всё ещё может быть обнаружен и сделан видимым пользователем или кодом, и он остаётся частью файла презентации.

### **Изменение порядка Z**

Перекрывающиеся фигуры рисуются в порядке коллекции. [reorder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `size() - 1` — передний.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Прямоугольник создаётся первым и изначально находится позади эллипса. Перемещение его к последнему индексу помещает его спереди. Завершите настройку порядка Z после добавления или клонирования всех связанных фигур, поскольку эти операции добавляют новые элементы в коллекцию и могут изменить желаемый стек.

## **Проверка фигур на макетных слайдах**

Обычные слайды, макетные слайды и мастер‑слайды имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогично размещённая фигура на обычном слайде. Проверяйте фигуры макета, когда необходимо понять или изменить форматирование, поставляемое макетом.

В следующем примере читаются [FillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getfillformat/) и [LineFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getlineformat/) каждой фигуры макета без предположения, что каждая фигура является `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Редактирование макета может затронуть несколько слайдов, которые его используют. Прежде чем менять фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и протестируйте каждый слайд, использующий данный макет.

## **Экспорт фигуры в SVG**

[writeAsSvg](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/writeassvg/) записывает отрендеренное содержимое одной фигуры в поток. Результат содержит только эту фигуру, а не весь фон слайда или соседние фигуры.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Оставляйте презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Владелец потока — вызывающая сторона, которая должна закрыть его.

## **Выравнивание фигур**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/alignshapes/) имеет перегрузки, позволяющие выравнивать либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapesalignmenttype/) задаёт сторону, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; установите в `false`, чтобы выравнивать выбранные фигуры относительно друг друга.

В этом примере три фигуры выравниваются по верхнему краю слайда. Ссылки на фигуры, возвращённые методом, сразу же преобразуются в их текущие индексы перед выравниванием.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Выравнивание меняет позиции, а не порядок Z. Относительное выравнивание обычно требует как минимум две фигуры, а горизонтальное или вертикальное распределение — достаточного количества фигур для определения промежутков. Пересчитайте индексы, если вы изменяете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapeframe/) хранит позицию, размер, настройки горизонтального и вертикального отражения и вращения. Его свойства `getFlipH` и `getFlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/nullablebool/): `True` включает отражение, `False` отключает, а `NotDefined` сохраняет неуказанное/по‑умолчанию состояние.

Входная презентация ниже содержит одну неотражённую фигуру.

![Фигура до отражения](shape_to_be_flipped.png)

В примере сохраняются все остальные значения кадра и заменяются только два параметра отражения. Это важно, потому что назначение нового [Frame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/setframe/) заменяет весь кадр.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённая фигура зеркально отражена по горизонтали и вертикали, при этом сохраняются её позиция, размер и вращение.

![Фигура после отражения](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции в качестве идентификатора фигуры?**

Только для краткоживущей обработки, когда коллекция не изменится до использования индекса. Предпочтительно использовать проверенный `Name` или соглашение о `AlternativeText` для управляемых шаблонов, либо `OfficeInteropShapeId` для работы с межоперационными идентификаторами в пределах слайда.

**Удаляет ли скрытие фигуры её из порядка Z?**

Нет. Скрытая фигура остаётся в коллекции с тем же индексом. Её можно находить, переупорядочивать, редактировать или снова сделать видимой.

**Почему склонированная фигура оказалась перед другой фигурой?**

`addClone` добавляет клон в конец коллекции, что соответствует переднему краю порядка Z. Используйте `insertClone`, чтобы выбрать начальный индекс, либо `reorder` после добавления всех фигур.