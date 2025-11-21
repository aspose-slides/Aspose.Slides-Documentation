---
title: Пользовательская форма
type: docs
weight: 20
url: /ru/nodejs-java/custom-shape/
keywords:
- форма
- пользовательская форма
- создать форму
- геометрия
- геометрия формы
- геометрический путь
- точки пути
- точки редактирования
- PowerPoint
- презентация
- JavaScript
- Aspose.Slides для Node.js через Java
description: "Добавьте пользовательскую форму в презентацию PowerPoint с помощью JavaScript"
---

## **Изменение формы с помощью точек редактирования**

Рассмотрим квадрат. В PowerPoint, используя **точки редактирования**, вы можете 

* переместить угол квадрата внутрь или наружу
* задать кривизну для угла или точки
* добавить новые точки к квадрату
* манипулировать точками на квадрате и т.д. 

По сути, вы можете выполнять описанные действия с любой формой. Используя точки редактирования, вы можете изменить форму или создать новую форму из существующей.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

Прежде чем начинать редактировать формы PowerPoint с помощью точек редактирования, вам может быть полезно учесть следующие сведения о формах:

* Форма (или её путь) может быть закрытой или открытой.
* Когда форма закрыта, у неё нет начальной или конечной точки. Когда форма открыта, у неё есть начало и конец. 
* Все формы состоят как минимум из 2 фиксирующих точек, соединённых линиями
* Линия может быть прямой или кривой. Фиксирующие точки определяют характер линии. 
* Фиксирующие точки могут быть угловыми, прямыми или плавными:
  * Угловая точка — это точка, где две прямые линии соединяются под углом. 
  * Плавная точка — это точка, где два рычага находятся на одной прямой, и сегменты линии соединяются в плавную кривую. В этом случае все рычаги находятся на одинаковом расстоянии от фиксирующей точки. 
  * Прямая точка — это точка, где два рычага находятся на одной прямой, и сегменты линии соединяются в плавную кривую. В этом случае рычаги не обязаны находиться на одинаковом расстоянии от фиксирующей точки. 
* Перемещая или редактируя фиксирующие точки (что меняет угол линий), вы можете изменить внешний вид формы. 

Для редактирования форм PowerPoint с помощью точек редактирования **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) и класс [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) представляет геометрический путь объекта [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
* Чтобы получить `GeometryPath` из экземпляра `GeometryShape`, вы можете использовать метод [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).
* Чтобы задать `GeometryPath` для формы, вы можете использовать следующие методы: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) для *solid shapes* и [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) для *composite shapes*.
* Чтобы добавить сегменты, вы можете использовать методы из [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
* С помощью методов [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) и [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) вы можете задать внешний вид геометрического пути.
* С помощью метода [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#getPathData--) вы можете получить геометрический путь `GeometryShape` в виде массива сегментов пути.
* Чтобы получить доступ к дополнительным параметрам настройки геометрии формы, вы можете преобразовать [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Используйте методы [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) и [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (из класса [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil)) для преобразования [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) и обратно.

## **Простые операции редактирования**

Этот JavaScript‑код показывает, как

**Добавить линию** в конец пути
```javascript
lineTo(point);
lineTo(x, y);
```

**Добавить линию** в заданную позицию пути:
```javascript
lineTo(point, index);
lineTo(x, y, index);
```

**Добавить кубическую кривую Безье** в конец пути:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**Добавить кубическую кривую Безье** в заданную позицию пути:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**Добавить квадратичную кривую Безье** в конец пути:
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```

**Добавить квадратичную кривую Безье** в заданную позицию пути:
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```

**Добавить заданную дугу** к пути:
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```

**Замкнуть текущую фигуру** пути:
```javascript
closeFigure();
```

**Установить позицию следующей точки**:
```javascript
moveTo(point);
moveTo(x, y);
```

**Удалить сегмент пути** по заданному индексу:
```javascript
removeAt(index);
```


## **Добавить пользовательские точки к форме**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) и задайте тип [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) из формы.
3. Добавьте новую точку между двумя верхними точками пути.
4. Добавьте новую точку между двумя нижними точками пути.
5. Примените путь к форме.

Этот JavaScript‑код показывает, как добавить пользовательские точки к форме:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example1_image](custom_shape_1.png)

## **Удалить точки из формы**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) и задайте тип [ShapeType.Heart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) из формы.
3. Удалите сегмент пути.
4. Примените путь к форме.

Этот JavaScript‑код показывает, как удалить точки из формы:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example2_image](custom_shape_2.png)

## **Создать пользовательскую форму**

1. Вычислите точки для формы.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
5. Примените путь к форме.

Этот JavaScript показывает, как создать пользовательскую форму:
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example3_image](custom_shape_3.png)

## **Создать составную пользовательскую форму**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
4. Примените пути к форме.

Этот JavaScript‑код показывает, как создать составную пользовательскую форму:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example4_image](custom_shape_4.png)

## **Создать пользовательскую форму со скруглёнными углами**

Этот JavaScript‑код показывает, как создать пользовательскую форму со скруглёнными углами (внутренняя кривизна);
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Узнать, закрыта ли геометрия формы**

Закрытая форма определяется как та, в которой все её стороны соединены, образуя единую границу без разрывов. Такая форма может быть простой геометрической фигурой или сложным пользовательским контуром. Ниже приведён пример кода, показывающий, как проверить, закрыта ли геометрия формы:
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```


## **Преобразовать GeometryPath в java.awt.Shape**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
2. Создайте экземпляр класса [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Преобразуйте экземпляр [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) в экземпляр [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) с помощью [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil).
4. Примените пути к форме.

Этот JavaScript‑код — реализация вышеуказанных шагов — демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Создать новую форму
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Получить геометрический путь формы
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Создать новый графический путь с текстом
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Преобразовать графический путь в геометрический путь
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Установить комбинацию нового геометрического пути и исходного геометрического пути для формы
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и обводкой после замены геометрии?**

Стиль остаётся привязанным к форме; меняется только контур. Заливка и обводка автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую форму вместе с её геометрией?**

Используйте метод формы [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setrotation/), геометрия будет вращаться вместе с формой, так как привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы “зафиксировать” результат?**

Да. Экспортируйте нужную область [слайда](/slides/ru/nodejs-java/convert-powerpoint-to-png/) или саму [форму](/slides/ru/nodejs-java/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу с тяжёлыми геометриями.