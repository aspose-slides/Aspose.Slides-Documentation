---
title: 在 Java 中定制演示文稿形状
linktitle: 自定义形状
type: docs
weight: 20
url: /zh/java/custom-shape/
keywords:
- 自定义形状
- 添加形状
- 创建形状
- 更改形状
- 形状几何
- 几何路径
- 路径点
- 编辑点
- 添加点
- 移除点
- 编辑操作
- 曲线角
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中创建并定制形状：几何路径、曲线角、复合形状。"
---
## **概述**

本文介绍如何通过编辑点和几何路径编辑形状几何来自定义 Aspose.Slides 中的演示文稿形状。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 和 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 来修改现有形状，执行基本的路径编辑操作，添加或删除点，并将更新后的几何应用回形状。

它还演示了如何创建自定义和复合形状，构建带曲线角的形状，判断形状几何是否闭合，检查形状元素，以及将 Java AWT 文本轮廓转换为几何路径。

## **使用编辑点更改形状**

* 将角点向内或向外移动。
* 调整点处的曲率。
* 添加新点。

编辑点可让您修改形状的轮廓，或以现有形状为基础创建新形状。

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

编辑 PowerPoint 形状时，请牢记以下概念：

* 形状（或其路径）可以是闭合的，也可以是开放的。
* 形状的路径由锚点和它们之间的线段组成。
* 线段可以是直的或曲的。锚点和控制柄决定其形状。
* 锚点可以是角点、直点或平滑点：
  * 在角点，相邻的线段可以成角相接。
  * 在平滑点，两个控制柄在同一直线上且距离锚点相等。
  * 在直点，两个控制柄仍在同一直线上，但距离锚点的距离可以不同。
* 移动锚点或调整其控制柄会改变形状的轮廓。

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 类和 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 接口。

* 一个 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 实例表示 [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 对象的几何路径。
* 要从 [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 实例检索 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)，可以使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) 方法。
* 要为形状设置 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)，可以使用以下方法：对单一路径的形状使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)，对多路径形状使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)。
* 要添加线段，可以使用 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 下的方法。
* 使用 [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) 和 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法，可以设置几何路径的外观。
* 使用 [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) 方法，可以将 [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) 的几何路径作为路径线段数组检索。
* 要访问更多形状几何自定义选项，可以通过其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 读取 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 并在 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 上重放这些线段。

## **简单编辑操作**

使用以下方法编辑几何路径。接受索引的重载会在路径的线段数组中零基位置插入线段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直线。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 追加或插入具有两个控制点和终点的三次 Bézier 曲线。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 追加或插入具有一个控制点和终点的二次 Bézier 曲线。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 追加具有指定尺寸和角度（度）的椭圆弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 通过将终点连接到起点来闭合当前图形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| 设置图形的起始点。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 删除指定索引（从0开始）的线段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **向形状添加自定义点**

此示例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) 向矩形形状插入两个点，并使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 应用编辑后的路径。坐标是相对于形状的局部坐标：两个新点位于形状中心，距左侧 100 点，距顶部 50 点。线段索引 1 和 4 将它们放在上、下边缘上，向内拉动这些边缘。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **从形状移除点**

此示例使用 [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) 删除零基索引 2 处的线段，从而更改心形轮廓。使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 应用修改后的路径会更新形状的轮廓。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **创建自定义形状**

此示例使用 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 构建一个五角星。交替的外半径 100 点和内半径 50 点定义了星尖和凹口；72 度的步进使五个星尖均匀分布。路径使用 [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) 闭合，并通过 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 应用于矩形形状，替换其轮廓。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **创建复合自定义形状**

此示例为形状的顶部和底部三分之一定义了两个闭合的 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 对象。使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 同时应用这两个路径，可创建一个在中部三分之一留有空隙的单一复合形状。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **创建带曲线角的自定义形状**

此示例将直线段与 [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) 组合，生成一个角部向内弯曲的形状。每个角的尺寸以点为单位设置弧的宽度和高度，-90 度的扫掠绘制逆时针四分之一椭圆。完成的路径使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 应用，演示文稿以 PPTX 格式保存。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **判断形状几何是否闭合**

下面的辅助方法检查每条非空几何路径是否以闭合线段结束。它读取 [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) 并将最终线段的 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) 与 [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) 比较。当不存在非空路径时返回 false。此检查每条路径的最终命令，而不检查路径内部的每个子图形。示例对矩形输出 `true`。

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **提取并检查形状元素**

使用 [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) 可将现有形状检查为包含路径点和点类型的元素。将每个返回的 [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) 强制转换为 [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) ，即可通过 [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) 和 [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) 方法获取点数组和类型数组。这种表示方式对轮廓分析或将几何传递给自定义绘图工具非常有用。

示例打开 `input.pptx`，在第一张幻灯片上直接找到第一个几何形状，并打印其路径线段。使用包含直线和曲线段的形状进行演示，可看到两种输出。它不会在组内部搜索。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // 保留线段类型，排除标志位。
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // 消耗两个控制点和终点。
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

数组按索引对应：`points[i]` 为一个点，`types[i]` 描述其角色。类型 `0` 开始一个图形，类型 `1` 从前一点绘制到当前点的直线。三次 Bézier 线段起始于前一个端点，使用连续的三个类型为 `3` 的条目：两个控制点后跟新的端点。循环一次性消费这三个条目并检查端点是否闭合。

点类型还包含标志位。使用 `0x07` 掩码可识别线段类型，单独测试 `0x80` 可检测闭合子路径。例如，`129` (`0x81`) 表示闭合子路径的直线端点，`131` (`0x83`) 表示闭合的 Bézier 端点。Java 将这些标志存储在有符号字节中；进行掩码可保留预期的位值。仅与 `1` 或 `3` 比较原始值会遗漏这些情况。其他标志，如虚线 (`0x10`) 和标记 (`0x20`)，不会改变基础线段类型。

**坐标与变换。** 点的单位为 point（1/72 英寸），X 向右递增，Y 向下递增。对于未分组的形状，提取的坐标已经包含了 [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) 和 [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) 返回的位置，并反映其当前宽度和高度。例如，未旋转的矩形位于 `(100, 200)`，尺寸为 `120 × 80`，其轮廓边界为 `(100, 200)`–`(220, 280)`。不要再次添加形状的位置。减去其 X 和 Y 可得到相对于未旋转框架的坐标。

提取的点不考虑由 [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) 返回的形状旋转，也不考虑水平和垂直翻转。要重现显示的轮廓，需要围绕形状中心应用这些变换。对于分组形状，还需考虑组坐标映射和变换；不要假设提取的点已经是最终渲染的幻灯片坐标，也不要在已经在子框架中体现的情况下再次平移或缩放。

**检查 vs 编辑。** 提取的数组仅描述轮廓，修改它们不会更新原始形状。仅在分析或绘图代码需要点/类型数组时使用此方法。需要在形状本地坐标系中获取几何命令或编辑几何时，请使用 [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--)。编辑后通过 [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 或 [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 应用。

## **将 Java AWT Shape 转换为 GeometryPath**

此示例将矩形轮廓与转换后的文本几何相结合。轮廓的 [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法关闭填充。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 在 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 中创建文本轮廓。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 提供移动、直线、二次、三次和闭合线段，示例将在 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 上重放这些线段。

文本使用 40 点 Arial 字体。轮廓水平偏移 20 点，且其可视顶部位于形状顶部以下 10 点。文本路径被填充，而原始矩形保持为轮廓。使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 同时应用两条路径，生成包含矩形和文本的单一形状。

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // 创建新形状
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 获取形状的几何路径
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // 使用文本创建新的图形路径
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // 将图形路径转换为几何路径
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // 将新的几何路径与原始几何路径组合并设置到形状
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **常见问题**

**替换几何后填充和轮廓会怎样？**

样式仍然保留在形状上；只有轮廓发生变化。填充和轮廓会自动应用到新的几何上。

**如何正确地连同几何一起旋转自定义形状？**

使用形状的 [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) 方法；几何会随形状一起旋转，因为它绑定在形状自己的坐标系上。

**是否可以将自定义形状转换为图像以“锁定”结果？**

可以。将所需的[幻灯片](/slides/zh/java/convert-powerpoint-to-png/)区域或[形状](/slides/zh/java/create-shape-thumbnails/)本身导出为光栅格式，这会简化对复杂几何的后续操作。