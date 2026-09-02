---
title: Управление фигурами презентации в JavaScript
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/nodejs-java/shape-manipulations/
keywords:
- фигура PowerPoint
- фигура презентации
- фигура на слайде
- поиск фигуры
- клонирование фигуры
- удаление фигуры
- скрытие фигуры
- изменение порядка фигур
- получение interop ID фигуры
- альтернативный текст фигуры
- точка регулировки фигуры
- предустановленная регулировка фигуры
- геометрия фигуры
- форматы макета фигур
- фигура как SVG
- фигура в SVG
- выравнивание фигуры
- отражение фигуры
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как идентифицировать, регулировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентаций с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides for Node.js via Java представляет фигуры на слайде как упорядоченную [Коллекцию фигур](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/). Эта коллекция одновременно служит местом, где вы находите и изменяете фигуры, и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

В этой статье рассматривается эта модель. Сначала объясняется, как надёжно определить фигуру и изменить предустановленные точки регулировки, затем показывается, как клонировать, удалять, скрывать и переупорядочивать фигуры. В заключительных разделах рассматриваются форматирование уровня макета, экспорт в SVG, выравнивание и настройки отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые нужны вашему рабочему процессу.

## **Определение и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигур может изменить их индексы. Выбирайте идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getname/) полезно для шаблонов, контролируемых разработчиком, и его легко увидеть в панели выбора PowerPoint. Имена можно изменять, но они не гарантируют уникальность, поэтому задайте соглашение об именовании, если код зависит от них.
- [AlternativeText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getalternativetext/) удобно, когда описание доступности или тег, добавленный автором, уже идентифицирует фигуру. Оно видно пользователям, может быть локализовано или переписано для доступности и также не гарантирует уникальность. Не используйте осмысленный текст доступности как ключ в базе данных без явного согласования.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) — идентификатор только для чтения, уникальный внутри слайда и соответствующий ID фигуры, используемому в interop PowerPoint. Используйте его при интеграции с PowerPoint или когда нужен однозначный ссылочный объект в течение жизни фигуры. Клонированная или воссозданная фигура — другая фигура и получает собственный ID.

Связанная методика [getUniqueId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getuniqueid/) возвращает идентификатор в пределах презентации, но он предназначен для надстроек и может быть переназначен. Его не следует рассматривать как постоянный внешний ключ. Если требуется долгосрочная идентичность, храните отображение в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Следующий пример ищет по имени с точным сравнением и выводит ID interop в пределах слайда. Когда шаблон не содержит ожидаемую фигуру, код сообщает об этом, вместо того чтобы продолжать работу с неправильным объектом.

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

Когда операция специфична для типа фигуры, проверьте класс во время выполнения перед использованием членов, характерных для типа. Этот пример обновляет текст и альтернативный текст только если именованный объект является [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/).

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

## **Определение и изменение предустановленных регулировок фигур**

Фигуры с предустановленной геометрией могут иметь точки регулировки, контролирующие такие свойства, как размер углов, соотношения стрелок или углы дуг. Доступ к ним осуществляется через только‑для‑чтения коллекцию [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/geometryshape/). Коллекция предоставляется фигурой, но каждый [AdjustValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/) содержит значение, которое можно изменить.

Не полагайтесь только на фиксированный индекс коллекции. Пройдите по регулировкам и изучите только‑для‑чтения метод [getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/), значение которого типа [ShapeAdjustmentType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapeadjustmenttype/) описывает, что регулируется. Метод только‑для‑чтения [getName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/getname/) предоставляет дополнительную идентифицирующую информацию и особенно полезен, когда предустановка содержит более одной регулировки с одинаковым семантическим типом.

Используйте метод значения, соответствующий смыслу регулировки:

| Тип регулировки | Назначение | Значение для изменения |
|---|---|---|
| `CornerSize` | Размер закруглённых углов | [setRawValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Толщина хвоста стрелки | `setRawValue` |
| `ArrowheadLength` | Длина наконечника стрелки | `setRawValue` |
| `ArrowheadWidth` | Ширина наконечника стрелки | `setRawValue` |
| `StartAngle` | Начальный угол сектора или дуги | [setAngleValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Конечный угол сектора или дуги | `setAngleValue` |

`getType` и `getName` возвращают только‑для‑чтения информацию. `getRawValue` и `setRawValue` работают с целым числом в родных единицах геометрии предустановки, а `getAngleValue` и `setAngleValue` — с углом в градусах. Номер, порядок, смысл и допустимый диапазон регулировок зависят от предустановки [GeometryShape.getShapeType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/geometryshape/). Значение, корректное для одной предустановки, может быть некорректным или иметь иной эффект для другой.

Когда `getType` возвращает `ShapeAdjustmentType.Custom`, API не распознаёт стандартный семантический смысл. Проверьте `getName`, тип предустановки и существующее значение и оставьте регулировку без изменений, если ожидаемый смысл и диапазон неизвестны. Даже для распознанных типов проверьте, не встречается ли тот же тип более одного раза, прежде чем выбирать значение. Статья [Connector](/slides/ru/nodejs-java/connector/) демонстрирует эту ситуацию с регулировками изгиба соединителя.

Следующий полный пример создаёт стандартные и изменённые версии трёх предустановленных фигур. Он проходит по каждой регулировке, выводит её имя и тип, изменяет значения, связанные с размером, через `setRawValue`, меняет углы через `setAngleValue` и сохраняет результат. Левая колонка сохраняет исходную геометрию; правая показывает отрегулированный закруглённый прямоугольник, четырёхстрочную стрелку и сектор.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Добавляет заголовки для столбцов с фигурой по умолчанию и изменёнными параметрами.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Проверка семантического типа перед изменением значения делает код явным и избегает предположения, что конкретный индекс коллекции имеет одинаковый смысл для разных предустановок фигур.

## **Модификация коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочения работают с коллекцией сразу. Если операция меняет количество или порядок фигур, не продолжайте опираться на индексы, зафиксированные до этой операции.

### **Клонирование фигуры**

[addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/addclone/) создаёт независимую копию и добавляет её в конец целевой коллекции. [insertClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/insertclone/) также создаёт копию, но помещает её по заданному индексу Z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения его размеров; перегрузки с шириной и высотой могут изменить размер.

Пример создаёт слайд‑назначение, клонирует помеченный прямоугольник спереди и вставляет второй клон назад. Изменения любого клона не влияют на исходную фигуру.

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

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новым логическим идентификаторам клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[remove](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/remove/) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений во время итерации по индексам проходите с конца, чтобы каждый оставшийся индекс оставался валидным.

Этот пример удаляет каждую фигуру с заданным именем. Он читает фигуру по текущему индексу и не предполагает конкретный тип фигуры.

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

После удаления количество фигур и индексы последующих фигур меняются. Ссылки на неизменённые фигуры остаются более надёжными, чем сохранённые индексы. Также учитывайте соединители, анимацию и другие возможности презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить не только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/sethidden/) в `true` оставляет фигуру в коллекции, но предотвращает её отображение в обычном показе слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

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

Скрытие — не удаление и не механизм безопасности. Объект всё ещё может быть найден и сделан видимым пользователем или кодом, и остаётся частью файла презентации.

### **Изменение Z‑порядка**

Перекрывающиеся фигуры отрисовываются в порядке коллекции. [reorder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `size() - 1` — передний.

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

Прямоугольник создаётся первым и изначально находится позади эллипса. Перемещение его к последнему индексу помещает его спереди. Завершайте настройку Z‑порядка после добавления или клонирования всех связанных фигур, поскольку эти операции добавляют или вставляют новые элементы коллекции и могут изменить ожидаемый стек.

## **Проверка фигур на макетных слайдах**

Обычные слайды, макетные слайды и слайды‑материалы имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогично расположенная фигура на обычном слайде. Проводите проверку фигур макета, когда нужно понять или изменить форматирование, предоставляемое макетом.

Следующий пример считывает у каждой фигуры макета её [FillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getfillformat/) и [LineFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getlineformat/) без предположения, что каждая фигура является `AutoShape`.

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

Редактирование макета может повлиять на несколько слайдов, которые его используют. Прежде чем менять фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и протестируйте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[writeAsSvg](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/writeassvg/) записывает отрисованное содержимое одной фигуры в поток. Результат содержит только фигуру, а не весь фон слайда или соседние фигуры.

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

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Владелец потока — вызывающая сторона, и она должна закрыть поток.

## **Выравнивание фигур**

Перегрузки [SlideUtil.alignShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/alignshapes/) выравнивают либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapesalignmenttype/) указывает край, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; установите в `false`, чтобы выровнять выбранные фигуры относительно друг друга.

Этот пример выравнивает три фигуры по верхнему краю слайда. Ссылки на фигуры преобразуются в их текущие индексы непосредственно перед выравниванием.

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

Выравнивание меняет позиции, а не Z‑порядок. Относительное выравнивание обычно требует как минимум две фигуры, в то время как горизонтальное или вертикальное распределение требует достаточного количества фигур для определения промежутков. Пересчитайте индексы, если вы изменяете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapeframe/) хранит положение, размер, настройки горизонтального и вертикального отражения и вращения. Его значения `getFlipH` и `getFlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/nullablebool/): `True` — включить отражение, `False` — отключить, `NotDefined` — оставить неопределённым/по умолчанию.

Входная презентация ниже содержит одну неотражённую фигуру.

![Фигура до отражения](shape_to_be_flipped.png)

Пример сохраняет все остальные значения кадра и заменяет только два параметра отражения. Это важно, потому что присвоение нового [Frame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/setframe/) заменяет весь кадр.

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

Сохранённая фигура отражена по горизонтали и вертикали, при этом её положение, размер и вращение остаются прежними.

![Фигура после отражения](flipped_shape.png)

## **FAQ**

**Следует ли использовать индекс коллекции как идентификатор фигуры?**

Только для кратковременной обработки, когда коллекция не изменится до использования индекса. Предпочтительнее проверенный `Name` или соглашение об `AlternativeText` для шаблонов, созданных вручную, либо `OfficeInteropShapeId` для работы с interop в пределах слайда.

**Удаляет ли скрытие фигуры её из Z‑порядка?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно найти, переупорядочить, отредактировать или снова сделать видимой.

**Почему клонированная фигура появилась перед другой фигурой?**

`addClone` добавляет клон в конец коллекции, что соответствует переднему положению в Z‑порядке. Используйте `insertClone`, чтобы указать начальный индекс, или `reorder` после добавления всех фигур.

**Можно ли использовать фиксированный индекс для идентификации регулировки предустановленной фигуры?**

Только после проверки точной предустановки и компоновки коллекции. Предпочтительно проходить через `GeometryShape.getAdjustments` и проверять `AdjustValue.getType`; используйте `AdjustValue.getName` как дополнительную информацию, когда один и тот же семантический тип появляется более одного раза.