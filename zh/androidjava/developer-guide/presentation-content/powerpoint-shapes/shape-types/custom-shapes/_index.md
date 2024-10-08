---
title: 自定义形状
type: docs
weight: 20
url: /androidjava/custom-shape/
keywords: "PowerPoint 形状，自定义形状，PowerPoint 演示文稿，Java，Aspose.Slides for Android via Java"
description: "在 Java 中的 PowerPoint 演示文稿中添加自定义形状"
---

# 使用编辑点更改形状
考虑一个正方形。在 PowerPoint 中，通过使用 **编辑点**，您可以

* 将正方形的角向内或向外移动
* 指定一个角或点的曲率
* 向正方形添加新点
* 操作正方形上的点等。

实质上，您可以对任何形状执行上述任务。使用编辑点，您可以更改形状或从现有形状创建新形状。

## **形状编辑提示**

![overview_image](custom_shape_0.png)

在通过编辑点开始编辑 PowerPoint 形状之前，您可能想考虑以下关于形状的要点：

* 形状（或其路径）可以是封闭的或开放的。
* 当形状是封闭时，它没有起始或结束点。当形状是开放时，它有一个开始和结束。
* 所有形状至少由 2 个锚点通过线条连接在一起。
* 线条可以是直线或曲线。锚点决定线条的性质。
* 锚点存在为角点、直线点或平滑点：
  * 角点是两个直线在一个角度相交的点。
  * 平滑点是两个控制手柄在一条直线上存在并且线段以平滑的曲线相连接的点。在这种情况下，所有的手柄与锚点之间的距离是相等的。
  * 直线点是两个控制手柄在一条直线上存在，并且该线段的线条以平滑的曲线相连接的点。在这种情况下，手柄不需要与锚点之间的距离是相等的。
* 通过移动或编辑锚点（这会改变线条的角度），您可以改变形状的外观。

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 类和 [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) 接口。

* 一个 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 实例表示 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape) 对象的几何路径。
* 要从 `IGeometryShape` 实例中检索 `GeometryPath`，可以使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) 方法。
* 要为形状设置 `GeometryPath`，您可以使用以下方法： [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) 用于 *实心形状* 和 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) 用于 *组合形状*。
* 要添加段，您可以使用 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) 下的方法。
* 使用 [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) 和 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) 方法，您可以设置几何路径的外观。
* 使用 [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--) 方法，您可以将 `GeometryShape` 的几何路径检索为路径段数组。
* 要访问其他形状几何定制选项，您可以将 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 转换为 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* 使用 [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) 和 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) 方法（来自 [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) 类）将 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 转换为 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 反之亦然。

## **简单编辑操作**

这段 Java 代码向您展示了如何

**向路径的末尾添加一条线**

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**向路径上指定位置添加一条线**：

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**在路径的末尾添加一条三次贝塞尔曲线**：

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**在路径的指定位置添加一条三次贝塞尔曲线**：

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**在路径的末尾添加一条二次贝塞尔曲线**：

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**在路径的指定位置添加二次贝塞尔曲线**：

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**向路径追加给定的弧**：

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**关闭路径的当前图形**：

``` java
public void closeFigure();
```
**设置下一个点的位置**：

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**删除给定索引处的路径段**：

``` java
public void removeAt(int index);
```

## **向形状添加自定义点**
1. 创建 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) 类的实例，并设置 [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) 类型。
2. 从形状中获取 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 类的实例。
3. 在路径的两个顶点之间添加一个新点。
4. 在路径的两个底点之间添加一个新点。
5. 将路径应用于形状。

这段 Java 代码展示了如何向形状添加自定义点：

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

## 从形状中删除点

1. 创建 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) 类的实例，并设置 [ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) 类型。
2. 从形状中获取 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 类的实例。
3. 移除路径的段。
4. 将路径应用于形状。

这段 Java 代码展示了如何从形状中删除点：

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

## **创建自定义形状**

1. 计算形状的点。
2. 创建 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 类的实例。
3. 用点填充路径。
4. 创建 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) 类的实例。
5. 将路径应用于形状。

这段 Java 代码展示了如何创建自定义形状：

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


## **创建复合自定义形状**

1. 创建 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) 类的实例。
2. 创建第一个 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 类的实例。
3. 创建第二个 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 类的实例。
4. 将路径应用于形状。

这段 Java 代码展示了如何创建复合自定义形状：

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

## **创建具有圆角的自定义形状**

这段 Java 代码展示了如何创建一个具有圆角的自定义形状（向内）：

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

## **将 GeometryPath 转换为 java.awt.Shape** 

1. 创建 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) 类的实例。
2. 创建 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 类的实例。
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) 将 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 实例转换为 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) 实例。
4. 将路径应用于形状。

这段 Java 代码——实现了上述步骤——演示了 **GeometryPath** 到 **GraphicsPath** 的转换过程：

``` java
Presentation pres = new Presentation();
try {
    // 创建新形状
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 获取形状的几何路径
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // 创建带有文本的新图形路径
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "文本在形状中";
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

    // 将图形路径转换为几何路径
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // 将新几何路径和原始几何路径组合设置给形状
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)