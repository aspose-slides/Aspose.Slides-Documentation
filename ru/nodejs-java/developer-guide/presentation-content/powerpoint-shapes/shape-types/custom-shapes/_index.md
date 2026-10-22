---
title: Настройка форм презентаций в JavaScript
linktitle: Пользовательская форма
type: docs
weight: 20
url: /ru/nodejs-java/custom-shape/
keywords:
- пользовательская форма
- добавить форму
- создать форму
- изменить форму
- геометрия формы
- геометрический путь
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- скруглённый угол
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью JavaScript и Aspose.Slides для Node.js: геометрические пути, скруглённые углы, составные формы."
---
## **Обзор**

Эта статья объясняет, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы через точки редактирования и геометрические пути. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к форме.

Также демонстрируется, как создавать пользовательские и составные формы, строить формы со скруглёнными углами, определять, закрыта ли геометрия формы, исследовать элементы формы и преобразовывать контуры текста Java AWT в геометрические пути.

## **Изменение формы с помощью точек редактирования**

В PowerPoint можно использовать **Edit Points** для изменения квадрата:

* Перемещение угла внутрь или наружу.
* Регулировка кривизны в точке.
* Добавление новых точек.

Редактирование точек позволяет менять контур формы или использовать существующую форму как основу для новой.

## **Советы по редактированию формы**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из якорных точек, соединённых сегментами.
* Сегмент может быть прямым или кривым. Якорные точки и управляющие рукоятки определяют его форму.
* Якорные точки бывают угловыми, прямыми или гладкими:
  * В угловой точке смежные сегменты могут встречаться под углом.
  * В гладкой точке две управляющие рукоятки выровнены и находятся на одинаковом расстоянии от якорной точки.
  * В прямой точке две управляющие рукоятки выровнены, но могут находиться на разном расстоянии от якорной точки.
* Перемещение якорных точек или изменение их рукояток меняет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) представляет геометрический путь объекта [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) из экземпляра [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), используйте метод [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) для формы, используйте методы: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) для форм с одним путём и [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) для форм с несколькими путями.
* Для добавления сегментов используйте методы класса [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* С помощью методов [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) и [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) можно задать внешний вид геометрического пути.
* Метод [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) позволяет получить геометрический путь [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) в виде массива сегментов пути.
* Для доступа к дополнительным возможностям настройки геометрии формы можно прочитать объект [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) через его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) и воспроизвести сегменты на [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Простые операции редактирования**

Используйте следующие методы для редактирования геометрического пути. Перегрузки, принимающие индекс, вставляют сегмент в указанную позицию (нумерация с нуля) в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Добавить или вставить кубическую кривую Безье с двумя управляющими точками и конечной точкой. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Добавить или вставить квадратичную кривую Безье с одной управляющей точкой и конечной точкой. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Задать начальную точку фигуры. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Удалить сегмент по индексу (нумерация с нуля). | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Добавление пользовательских точек к форме**

В этом примере вставляются две точки в прямоугольную форму с помощью [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) и применяются отредактированный путь через [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Координаты относительные к форме: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхних и нижних гранях, подтягивая эти грани внутрь.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Удаление точек из формы**

В этом примере изменяется контур сердца путём удаления сегмента с индексом 2 (нумерация с нуля) с помощью [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Применение изменённого пути через [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) обновляет контур формы.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Создание пользовательской формы**

В этом примере создаётся пятиконечная звезда при помощи [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов задают вершины и впадины; шаг в 72 градуса равномерно распределяет пять вершин. Путь замыкается методом [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) и применяется к прямоугольной форме через [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), заменяя её контур.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Создание составной пользовательской формы**

В этом примере определяются два замкнутых объекта [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей через [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт одну составную форму с пробелом в её средней трети.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Создание пользовательской формы со скруглёнными углами**

В этом примере комбинируются прямые сегменты с [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) для получения формы со скруглёнными внутрь углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а разворот ‑ 90° рисует против часовой стрелки четверть эллипса. Завершённый путь применяется методом [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), а презентация сохраняется в формате PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Определение, закрыта ли геометрия формы**

Следующая вспомогательная функция проверяет, заканчивается ли каждый непустой геометрический путь закрывающим сегментом. Она читает [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) и сравнивает команду последнего сегмента [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) с [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Возвращает `false`, когда нет непустых путей. Проверка касается финальной команды каждого пути; она не исследует каждую подпостановку внутри пути. Пример выводит `true` для прямоугольника.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Извлечение и анализ элементов формы**

Используйте [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) для получения существующей формы в виде элементов, содержащих точки пути и типы точек. Каждый возвращённый [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) позволяет получить массивы точек и типов через методы [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) и [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Такое представление удобно для анализа контура или передачи геометрии в пользовательские средства рисования.

В примере открывается `input.pptx`, находится первая геометрическая форма на первом слайде и выводятся её сегменты пути. Используйте презентацию, содержащую форму с прямыми и кривыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не производится.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Сохранить тип сегмента, исключая флаги.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Массивы соответствуют по индексу: `points[i]` — точка, а `types[i]` описывает её роль. Тип `0` начинает новую фигуру, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается в предыдущей конечной точке и использует три последовательных типа `3`: два управляющих узла и новую конечную точку. Цикл потребляет эти три записи совместно и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` определяет тип сегмента, а проверка `0x80` отдельно выявляет закрытый подпуть. Например, `129` (`0x81`) — конечная точка линии, закрывающая подпуть, а `131` (`0x83`) — конечная точка Безье, закрывающая подпуть. Java хранит эти флаги в знаковых байтах; маскирование сохраняет нужные битовые значения. Сравнение сырого значения только с `1` или `3` упустит такие случаи. Другие флаги, такие как пунктир (`0x10`) и маркер (`0x20`), не изменяют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), X растёт вправо, Y — вниз. Для разгруппированной формы извлечённые координаты уже включают позицию, возвращаемую [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) и [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY), а также её текущую ширину и высоту. Например, неротированный прямоугольник с левым верхним углом `(100, 200)` и размером `120 × 80` имеет границы контура `(100, 200)–(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно неротированного кадра.

Извлечённые точки не учитывают вращение формы, возвращаемое [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), и горизонтальные/вертикальные отражения. Чтобы восстановить отображённый контур, примените эти преобразования вокруг центра формы. Для сгруппированных форм также учитывайте преобразования координат группы; не предполагаете, что извлечённые точки уже являются окончательными координатами слайда, и не применяйте одинаковый сдвиг или масштаб дважды.

**Анализ vs редактирование.** Извлечённые массивы описывают контур; их изменение не обновляет оригинальную форму. Этот подход подходит, когда вашему коду анализа или рисования нужны массивы точек/типов. Используйте [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths), когда нужны команды геометрии в локальной системе координат формы или требуется редактировать её геометрию. Применяйте отредактированные пути через [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) или [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Преобразование Java AWT Shape в GeometryPath**

В этом примере комбинируется контур прямоугольника с текстом, преобразованным в геометрию. Метод [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) отключает заливку контура. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) создаёт контур текста в объекте [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) поставляет команды перемещения, линий, квадратичных, кубических и замыкания, которые пример воспроизводит на [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Мост Java использует явные значения типа float и byte для соответствующих параметров Java. Итератор записывает координаты в массив float; отражение читаем его обновлённые значения обратно в JavaScript. Текст выводится шрифтом Arial размером 40 пунктов. Контур сдвинут на 20 пунктов по горизонтали и расположен так, что его визуальная верхняя часть находится на 10 пунктов ниже верхнего края формы. Текстовый путь заполняется, тогда как исходный прямоугольник остаётся только контуром. Применение обоих путей через [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт одну форму, содержащую прямоугольник и текст.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Переместить к.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Линия к.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Квадратичная кривая Безье.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Кубическая кривая Безье.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Замкнуть фигуру.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и контуром после замены геометрии?**

Стиль остаётся у формы; меняется лишь контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую форму вместе с её геометрией?**

Используйте метод [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) формы; геометрия вращается вместе с формой, поскольку привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте нужную [slide](/slides/ru/nodejs-java/convert-powerpoint-to-png/) область или саму [shape](/slides/ru/nodejs-java/create-shape-thumbnails/) в растровый формат; это упростит дальнейшую работу со сложными геометриями.