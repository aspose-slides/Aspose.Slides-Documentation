---
title: 在 Android 上自定义演示文稿形状
linktitle: 自定义形状
type: docs
weight: 20
url: /zh/androidjava/custom-shape/
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
- 圆角
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 通过 Java 创建并自定义 PowerPoint 演示文稿中的形状：几何路径、圆角、复合形状。"
---
## **概述**

本文阐述了如何通过编辑点和几何路径来自定义 Aspose.Slides 中的演示文稿形状几何。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 与 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 修改现有形状、执行基本路径编辑操作、添加或移除点，并将更新后的几何重新应用到形状。

此外，还演示了如何创建自定义和复合形状、构建带圆角的形状、判断形状几何是否闭合，以及使用 Android 点数组检查形状元素。

## **使用编辑点更改形状**

在 PowerPoint 中，您可以使用 **编辑点** 来修改正方形：

* 将角向内或向外移动。
* 调整点处的曲率。
* 添加新点。

编辑点允许您修改形状的轮廓，或以现有形状为基础创建新形状。

## **形状编辑技巧**

![概览图](custom_shape_0.png)

编辑 PowerPoint 形状时，请牢记以下概念：

* 形状（或其路径）可以是闭合的也可以是开放的。
* 形状的路径由通过段连接的锚点组成。
* 段可以是直线或曲线。锚点和控制手柄决定其形状。
* 锚点有三种形式：拐角点、直线点或平滑点：
  * 在拐角点，邻接段可以以一定角度相交。
  * 在平滑点，两个控制手柄对齐且与锚点的距离相等。
  * 在直线点，两个控制手柄仍对齐，但到锚点的距离可以不同。
* 移动锚点或调整其手柄会改变形状的轮廓。

为通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 类和 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 接口。

* 一个 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 实例表示 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) 对象的几何路径。
* 要从 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) 实例获取 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)，可以使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 方法。
* 要为形状设置 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)，可以使用以下方法：单路径形状使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)，多路径形状使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)。
* 要添加段，可以使用 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 下的方法。
* 使用 [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) 和 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法，可以设置几何路径的外观。
* 使用 [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 方法，可以将 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) 的几何路径读取为路径段数组。

## **简单编辑操作**

使用以下方法编辑几何路径。接受索引的重载会在路径段数组的相应零基位置插入段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直线。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 追加或插入带有两个控制点和终点的三次 Bézier 曲线。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 追加或插入带有一个控制点和终点的二次 Bézier 曲线。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 追加具有指定尺寸和角度（以度为单位）的椭圆弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 通过将端点连接到起点来闭合当前图形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| 设置图形的起始点。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 移除零基索引处的段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **向形状添加自定义点**

此示例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) 向矩形形状插入两个点，并使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 应用编辑后的路径。坐标相对于形状本身：两个新点位于形状中心，左侧偏移 100 点，顶部偏移 50 点。段索引 1 和 4 将它们放置在顶部和底部边缘，从而将这两条边向内拉伸。

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

![示例1图](custom_shape_1.png)

## **从形状中移除点**

此示例通过使用 [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) 删除零基索引 2 处的段，来修改心形轮廓。随后使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 应用修改后的路径，从而更新形状的轮廓。

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
![示例2图](custom_shape_2.png)

## **创建自定义形状**

此示例使用 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 构建一个五角星。交替的外半径 100 点和内半径 50 点定义了星尖和凹槽；72 度的步长使五个星尖均匀分布。路径通过 [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) 闭合，并使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 应用到矩形形状上，替换其轮廓。

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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
![示例3图](custom_shape_3.png)

## **创建复合自定义形状**

此示例为形状的上三分之一和下三分之一定义了两个闭合的 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 对象。通过 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 同时应用两条路径，可创建一个在中间三分之一处留有空隙的单一复合形状。

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
![示例4图](custom_shape_4.png)

## **创建带圆角的自定义形状**

此示例将直线段与 [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) 结合，创建一个具有向内圆弧角的形状。每个角的大小决定弧线的宽高（单位为点），-90 度的扫角绘制逆时针四分之一椭圆。完成的路径通过 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 应用，并将演示文稿保存为 PPTX 格式。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

下面的辅助方法检查每个非空几何路径是否以闭合段结束。它读取 [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 并将最终段的 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) 与 [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) 进行比较。当不存在非空路径时返回 false。该检查只关注每条路径的最终命令；不会检查路径内部的每个子图形。示例对矩形输出 `true`。

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

## **检查几何路径命令**

下载 [contour.pptx](contour.pptx) 并将示例文件名替换为设备上的实际路径。第一张幻灯片的第一个形状拥有直的顶部边缘、一个三次 Bézier 曲线以及直的闭合边缘。使用 [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 读取形状的路径，随后使用 [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 按绘制顺序读取每条路径的段。对每个段，[getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) 标识命令类型，并决定如何解释 [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) 返回的数值。

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

该形状位于幻灯片上的 (200, 100) 点。报告的坐标相对于形状本身，(0, 0) 为左上角，X 向右递增，Y 向下递增。闭合段返回到起始点，不需要额外坐标。

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **提取并检查形状元素**

使用 [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) 可将已有形状检查为包含路径点和点类型的元素。将每个返回的 [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) 强转为 [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/)，即可通过 [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) 和 [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) 方法获取点数组和类型数组。这种表示方式适用于轮廓分析或将几何传递给自定义绘图工具。

示例打开 input.pptx，在第一张幻灯片直接查找第一个几何形状，并打印其路径段。使用包含直线段和曲线段的形状进行测试，以看到两种输出。它不会在组内进行搜索。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // 保留段类型，排除标志。
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
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

数组通过索引对应：`points[i]` 为一个点，`types[i]` 描述其角色。类型 `0` 表示开始一个图形，类型 `1` 表示从前一点画一条线到当前点。三次 Bézier 段从前一个端点开始，使用连续的三个类型 `3` 条目：两个控制点随后是新的端点。循环一次性消费这三条记录，并检查端点是否闭合。

点类型还包含标志位。用 `0x07` 掩码可识别段类型，单独检测 `0x80` 可判断是否闭合子路径。例如，`129`（`0x81`）表示一个闭合的线段端点，`131`（`0x83`）表示一个闭合的 Bézier 端点。Java 将这些标志存放在有符号字节中，掩码操作可保留预期的位值。仅与 `1` 或 `3` 比较原始值会遗漏这些情况。其他标志如虚线 (`0x10`) 和标记 (`0x20`) 不会改变基础段类型。

**坐标与变换。** 点的单位为点（1/72 英寸），X 向右递增，Y 向下递增。对于未分组的形状，提取的坐标已经包含了由 [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) 与 [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) 返回的位置，并反映其当前宽高。例如，位于 `(100, 200)`、尺寸为 `120 × 80` 的未旋转矩形，其轮廓边界为 `(100, 200)`–`(220, 280)`。不要再次添加形状的位置。要得到相对于未旋转框架的坐标，请减去其 X 与 Y。

提取的点不包含形状的旋转（由 [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) 返回）或水平、垂直翻转。若要复现显示的轮廓，需要围绕形状中心应用这些变换。对于分组形状，还必须考虑组坐标映射和相应的变换；不要假设提取的点已是最终渲染在幻灯片上的坐标，也不要在已有的子框架已考虑的情况下再次平移或缩放。

**检查 vs. 编辑。** 提取的数组仅描述轮廓，修改它们不会更新原始形状。当您的分析或绘图代码需要点/类型数组时，可采用此方式。若需要在形状本地坐标系下获取几何命令或编辑几何，请使用 [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--)。编辑后通过 [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 或 [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 应用。

## **常见问题**

**替换几何后填充和轮廓会怎样？**

样式仍然附着在形状上，只是轮廓发生变化。填充和轮廓会自动应用到新的几何上。

**如何让自定义形状连同几何一起正确旋转？**

使用形状的 [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) 方法；几何会随形状一起旋转，因为它绑定在形状自己的坐标系上。

**我可以将自定义形状转换为图像以“锁定”结果吗？**

可以。将所需的 [slide](/slides/zh/androidjava/convert-powerpoint-to-png/) 区域或 [shape](/slides/zh/androidjava/create-shape-thumbnails/) 本身导出为栅格格式，这会简化对复杂几何的后续处理。