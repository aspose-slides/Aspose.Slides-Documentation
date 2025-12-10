---
title: Настройка фигур презентаций в Java
linktitle: Пользовательская фигура
type: docs
weight: 20
url: /ru/java/custom-shape/
keywords:
- пользовательская фигура
- добавить фигуру
- создать фигуру
- изменить фигуру
- геометрия фигуры
- путь геометрии
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- закруглённый угол
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint с помощью Aspose.Slides для Java: геометрические пути, закруглённые углы, составные фигуры."
---

# Изменение формы с помощью точек редактирования
Рассмотрим квадрат. В PowerPoint, используя **точки редактирования**, вы можете 

* перемещать угол квадрата внутрь или наружу
* задавать кривизну угла или точки
* добавлять новые точки к квадрату
* манипулировать точками на квадрате и т.д. 

По сути, вы можете выполнять описанные действия с любой фигурой. С помощью точек редактирования вы можете изменить форму или создать новую форму из существующей.

## **Советы по редактированию фигур**

![overview_image](custom_shape_0.png)

Прежде чем начать редактировать фигуры PowerPoint через точки редактирования, обратите внимание на следующие моменты относительно фигур:

* Фигура (или её путь) может быть замкнутой или открытой.
* Когда фигура замкнута, у неё нет начальной или конечной точки. Когда фигура открыта, у неё есть начало и конец. 
* Все фигуры состоят как минимум из 2 якорных точек, соединённых линиями.
* Линия может быть прямой или кривой. Якорные точки определяют характер линии. 
* Якорные точки бывают угловыми, прямыми или гладкими:
  * Угловая точка — это точка, где две прямые линии соединяются под углом. 
  * Гладкая точка — это точка, где два управляющих узла находятся на одной прямой, а сегменты линии соединяются плавной кривой. В этом случае все управляющие узлы находятся на одинаковом расстоянии от якорной точки. 
  * Прямая точка — это точка, где два управляющих узла находятся на одной прямой, а сегменты линии соединяются плавной кривой. В этом случае расстояния от управляющих узлов до якорной точки могут различаться. 
* Перемещая или редактируя якорные точки (что меняет угол линий), вы можете изменять внешний вид фигуры. 

Для редактирования фигур PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) представляет геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape). 
* Чтобы получить `GeometryPath` из экземпляра `IGeometryShape`, используйте метод [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#getGeometryPaths--). 
* Чтобы задать `GeometryPath` для фигуры, используйте методы: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) для *твердых фигур* и [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) для *композитных фигур*.
* Чтобы добавить сегменты, используйте методы из [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath). 
* С помощью методов [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) и [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) можно задать внешний вид геометрического пути.
* Методом [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#getPathData--) можно получить геометрический путь `GeometryShape` в виде массива сегментов пути. 
* Для доступа к дополнительным параметрам настройки геометрии фигуры вы можете преобразовать [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Используйте методы [geometryPathToGraphicsPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) и [graphicsPathToGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (из класса [ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil)) для преобразования [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) и обратно. 

## **Простые операции редактирования**

Этот Java‑код показывает, как

**Добавить линию** в конец пути
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```

**Добавить линию** в указанную позицию пути:
``` java
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```

**Добавить кубическую кривую Безье** в конец пути:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Добавить кубическую кривую Безье** в указанную позицию пути:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```

**Добавить квадратичную кривую Безье** в конец пути:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Добавить квадратичную кривую Безье** в указанную позицию пути:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```

**Присоединить заданную дугу** к пути:
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Замкнуть текущую фигуру** пути:
``` java
public void closeFigure();
```

**Задать позицию следующей точки**:
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```

**Удалить сегмент пути** по указанному индексу:
``` java
public void removeAt(int index);
```


## **Добавление пользовательских точек к фигуре**
1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape) и задайте тип [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType). 
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) из фигуры. 
3. Добавьте новую точку между двумя верхними точками пути. 
4. Добавьте новую точку между двумя нижними точками пути. 
5. Примените путь к фигуре. 

Этот Java‑код показывает, как добавить пользовательские точки к фигуре:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Удаление точек из фигуры**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape) и задайте тип [ShapeType.Heart](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType). 
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) из фигуры. 
3. Удалите сегмент пути. 
4. Примените путь к фигуре. 

Этот Java‑код показывает, как удалить точки из фигуры:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```

![example2_image](custom_shape_2.png)

## **Создание пользовательской фигуры**

1. Вычислите точки фигуры. 
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath). 
3. Заполните путь точками. 
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape). 
5. Примените путь к фигуре. 

Этот Java‑пример показывает, как создать пользовательскую фигуру:
``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example3_image](custom_shape_3.png)


## **Создание составной пользовательской фигуры**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape). 
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath). 
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath). 
4. Примените пути к фигуре. 

Этот Java‑код показывает, как создать составную пользовательскую фигуру:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```

![example4_image](custom_shape_4.png)

## **Создание пользовательской фигуры с закруглёнными углами**

Этот Java‑код показывает, как создать пользовательскую фигуру с закруглёнными углами (внутренняя кривая);
```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```


## **Определение, замкнута ли геометрия фигуры**

Замкнутая фигура определяется как та, у которой все стороны соединены, образуя единую границу без разрывов. Такая фигура может быть простой геометрической формой или сложным пользовательским контуром. Ниже приведён пример кода, показывающий, как проверить, замкнута ли геометрия фигуры:
```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```


## **Преобразование GeometryPath в java.awt.Shape** 

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape). 
2. Создайте экземпляр класса [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html). 
3. Преобразуйте экземпляр [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) в экземпляр [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) с помощью [ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil). 
4. Примените пути к фигуре. 

Этот Java‑код, реализующий описанные шаги, демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:
``` java
Presentation pres = new Presentation();
try {
    // Создать новую фигуру
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Получить геометрический путь фигуры
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Создать новый графический путь с текстом
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Преобразовать графический путь в геометрический путь
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Установить комбинацию нового геометрического пути и исходного геометрического пути для фигуры
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и контурами после замены геометрии?**

Стиль остаётся привязанным к фигуре; меняется лишь контур. Заливка и контур автоматически применяются к новой геометрии.

**Как корректно повернуть пользовательскую фигуру вместе с её геометрией?**

Вызовите метод фигуры [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-); геометрия будет повёрнута вместе с фигурой, так как она привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую фигуру в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте требуемую [slide](/slides/ru/java/convert-powerpoint-to-png/) или саму [shape](/slides/ru/java/create-shape-thumbnails/) в растровый формат; это упростит дальнейшую работу с тяжёлыми геометриями.