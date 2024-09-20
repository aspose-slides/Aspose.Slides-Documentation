---
title: Пользовательская форма
type: docs
weight: 20
url: /java/custom-shape/
keywords: "Форма PowerPoint, пользовательская форма, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Добавление пользовательской формы в презентацию PowerPoint на Java"
---

# Изменение формы с помощью точек редактирования
Рассмотрим квадрат. В PowerPoint, используя **точки редактирования**, вы можете

* перемещать углы квадрата внутрь или наружу
* задавать кривизну для угла или точки
* добавлять новые точки к квадрату
* манипулировать точками на квадрате и т. д.

По сути, вы можете выполнять описанные задачи с любой формой. Используя точки редактирования, вы можете изменить форму или создать новую форму на основе существующей.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

Перед тем, как начать редактировать формы PowerPoint через точки редактирования, вы можете учесть следующие моменты о формах:

* Форма (или ее контур) может быть либо замкнутой, либо незамкнутой.
* Когда форма замкнута, у нее нет начальной или конечной точки. Когда форма незамкнута, у нее есть начало и конец.
* Все формы состоят как минимум из 2 якорных точек, связанных между собой линиями.
* Линия может быть либо прямой, либо кривой. Якорные точки определяют характер линии.
* Якорные точки могут быть угловыми, прямыми или сглаженными:
  * Угловая точка — это точка, где сходятся 2 прямые линии под углом.
  * Сглаженная точка — это точка, где 2 ручки находятся на одной прямой, и сегменты линии соединяются сглаженной кривой. В этом случае все ручки отделены от якорной точки на равном расстоянии.
  * Прямая точка — это точка, где 2 ручки находятся на одной прямой, и сегменты линии этой линии соединяются сглаженной кривой. В этом случае ручки не должны находиться на равном расстоянии от якорной точки.
* Перемещая или редактируя якорные точки (что изменяет угол линий), вы можете изменить внешний вид формы.

Чтобы редактировать формы PowerPoint через точки редактирования, **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) представляет собой геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape).
* Чтобы получить `GeometryPath` из экземпляра `IGeometryShape`, вы можете использовать метод [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#getGeometryPaths--).
* Чтобы установить `GeometryPath` для формы, вы можете использовать следующие методы: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) для *сплошных форм* и [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) для *композитных форм*.
* Чтобы добавить сегменты, вы можете использовать методы из [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath).
* Используя методы [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) и [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setFillMode-byte-), вы можете задать внешний вид для геометрического пути.
* Используя метод [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#getPathData--), вы можете получить геометрический путь для `GeometryShape` в виде массива сегментов пути.
* Чтобы получить доступ к дополнительным параметрам настройки геометрии формы, вы можете преобразовать [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Используйте методы [geometryPathToGraphicsPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) и [graphicsPathToGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (из класса [ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil)), чтобы преобразовать [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) и наоборот.

## **Простые операции редактирования**

Этот код на Java показывает вам, как

**Добавить линию** в конец пути

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Добавить линию** в заданную позицию на пути:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Добавить кубическую кривую Безье** в конец пути:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Добавить кубическую кривую Безье** в заданную позицию на пути:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Добавить квадратичную кривую Безье** в конец пути:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Добавить квадратичную кривую Безье** в заданную позицию на пути:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Добавить заданную дугу** к пути:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Закрыть текущую фигуру** пути:

``` java
public void closeFigure();
```
**Установить позицию для следующей точки**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Удалить сегмент пути** по указанному индексу:

``` java
public void removeAt(int index);
```

## **Добавить пользовательские точки к форме**
1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape) и установите тип [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) из формы.
3. Добавьте новую точку между двумя верхними точками на пути.
4. Добавьте новую точку между двумя нижними точками на пути.
5. Примените путь к форме.

Этот код на Java показывает вам, как добавить пользовательские точки к форме:

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

## Удалить точки из формы

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape) и установите тип [ShapeType.Heart](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) из формы.
3. Удалите сегмент для пути.
4. Примените путь к форме.

Этот код на Java показывает вам, как удалить точки из формы:

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

## **Создать пользовательскую форму**

1. Рассчитайте точки для формы.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath).
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape).
5. Примените путь к форме.

Этот код на Java показывает вам, как создать пользовательскую форму:

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


## **Создать композитную пользовательскую форму**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape).
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath).
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath).
4. Примените пути к форме.

Этот код на Java показывает вам, как создать композитную пользовательскую форму:

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

## **Создать пользовательскую форму с закругленными углами**

Этот код на Java показывает вам, как создать пользовательскую форму с закругленными углами (внутрь);

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

## **Преобразовать GeometryPath в java.awt.Shape**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape).
2. Создайте экземпляр класса [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Преобразуйте экземпляр [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) в экземпляр [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath), используя [ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil).
4. Примените пути к форме.

Этот код на Java — реализация вышеописанных шагов — демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Создание новой формы
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Получение геометрического пути формы
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Создание нового графического пути с текстом
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Текст в форме";
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

    // Преобразование графического пути в геометрический путь
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Установка комбинации нового геометрического пути и оригинального геометрического пути в форму
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)