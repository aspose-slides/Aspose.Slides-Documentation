---
title: Javaでプレゼンテーション形状をカスタマイズ
linktitle: カスタム形状
type: docs
weight: 20
url: /ja/java/custom-shape/
keywords:
- カスタム形状
- 形状の追加
- 形状の作成
- 形状の変更
- 形状ジオメトリ
- ジオメトリパス
- パスポイント
- 編集ポイント
- ポイントの追加
- ポイントの削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションの形状を作成・カスタマイズ：ジオメトリパス、曲線コーナー、複合形状。"
---
## **概要**

この記事では、編集ポイントとジオメトリパスを使用して形状ジオメトリを編集することで、Aspose.Slides のプレゼンテーション形状をカスタマイズする方法を説明します。既存の形状を変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリを形状に適用するために、[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) と [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) の使用方法を示します。

また、カスタム形状や複合形状の作成、曲線コーナーを持つ形状の構築、形状ジオメトリが閉じているかどうかの判定、形状要素の検査、Java AWT のテキストアウトラインをジオメトリパスに変換する方法も示します。

## **編集ポイントを使用して形状を変更する**

PowerPoint では、**編集ポイント** を使用して正方形を変更できます：

* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、形状のアウトラインを変更したり、既存の形状を新しい形状の基礎として使用したりできます。

## **形状編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint の形状を編集するときは、次の概念を覚えておいてください：

* 形状（またはそのパス）は閉じている場合と開いている場合があります。
* 形状のパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線になり得ます。アンカーポイントと制御ハンドルがその形状を決定します。
* アンカーポイントは、コーナーポイント、ストレートポイント、スムーズポイントのいずれかです：
  * コーナーポイントでは、隣接するセグメントが角度を持って接続できます。
  * スムーズポイントでは、2 つの制御ハンドルが揃っており、アンカーポイントから等距離です。
  * ストレートポイントでは、2 つの制御ハンドルは揃っていますが、アンカーポイントからの距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、形状のアウトラインが変わります。

編集ポイントを使用して PowerPoint の形状を編集するには、**Aspose.Slides** が [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) クラスと [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) のインスタンスは、[IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) オブジェクトのジオメトリパスを表します。
* [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) を取得するには、[IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) メソッドを使用できます。
* 形状の [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) を設定するには、単一パスの形状には [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) を、複数パスの形状には [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) を使用できます。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) のメソッドを利用できます。
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) と [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) メソッドを使用すると、[GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) のジオメトリパスをパスセグメントの配列として取得できます。
* 形状ジオメトリのカスタマイズオプションにさらにアクセスするには、[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) をその [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) で読み取り、セグメントを [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) に再現できます。

## **シンプルな編集操作**

以下のメソッドを使用してジオメトリパスを編集します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 2 つの制御ポイントと終点を持つ三次ベジエ曲線を追加または挿入する。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 1 つの制御ポイントと終点を持つ二次ベジエ曲線を追加または挿入する。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 指定された寸法と角度（度）で楕円弧を追加する。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 終点を開始点に接続して現在の図形を閉じる。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| 図形の開始点を設定する。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| ゼロベースインデックスでセグメントを削除する。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **形状にカスタムポイントを追加する**

この例では、[GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) を使用して矩形形状に 2 つのポイントを挿入し、[IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で編集されたパスを適用します。座標は形状に対してローカルで、2 つの新しいポイントは中心にあり、左から 100 ポイント、上から 50 ポイントの位置です。セグメントインデックス 1 と 4 はそれらを上部と下部のエッジに配置し、エッジを内側に引っ張ります。

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

## **形状からポイントを削除する**

この例では、ゼロベースインデックス 2 のセグメントを [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) で削除してハート形のアウトラインを変更します。[IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で変更されたパスを適用すると、形状の輪郭が更新されます。

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

## **カスタム形状を作成する**

この例では、[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) を使用して五角星を作成します。外側と内側の半径を 100 と 50 ポイントで交互に設定し、先端と凹みを定義します。72 度のステップで五つの先端が均等に配置されます。パスは [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) で閉じられ、[IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) を使用して矩形形状に適用され、アウトラインが置き換えられます。

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

## **複合カスタム形状を作成する**

この例では、形状の上部と下部の 3 分の 1 に対応する 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) オブジェクトを定義します。[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) で両方のパスを適用すると、中央の 3 分の 1 にギャップのある単一の複合形状が作成されます。

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

## **曲線コーナー付きカスタム形状を作成する**

この例では、直線セグメントと [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) を組み合わせて、内側に曲がったコーナーを持つ形状を作成します。各コーナーサイズは弧の幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの四分円弧を描きます。完成したパスは [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で適用され、プレゼンテーションは PPTX 形式で保存されます。

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

## **形状ジオメトリが閉じているか確認する**

以下のヘルパーは、すべての非空ジオメトリパスが閉じるセグメントで終わるかどうかを確認します。[IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) を読み取り、最後のセグメントの [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) を [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) と比較します。非空パスがない場合は false を返します。各パスの最終コマンドをチェックするだけで、パス内のすべてのサブフィギュアは検査しません。この例では矩形に対して `true` を出力します。

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

## **ジオメトリパスコマンドを検査する**

アプリケーションの作業ディレクトリに [contour.pptx](contour.pptx) をダウンロードして配置します。最初のスライドの最初の形状は、直線の上端、三次ベジエ曲線、直線の閉じる端を持ちます。[getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) を使用して形状のパスを読み取り、[getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) で各パスのセグメントを描画順に取得します。各セグメントについて、[getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) がコマンドを識別し、[getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) が返す値の解釈方法を決定します。

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

形状はスライド上で (200, 100) ポイントに配置されています。報告される座標は形状に対してローカルで、(0, 0) が左上隅にあり、x は右方向に、y は下方向に増加します。閉じるセグメントは追加の座標なしで開始点に戻ります。

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **形状要素の抽出と検査**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) を使用して、パス点と点タイプを含む要素として既存の形状を検査します。返された各 [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) を [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) にキャストし、[getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) と [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) メソッドで点とタイプの配列を取得します。この表現は輪郭解析やジオメトリをカスタム描画ツールに渡す際に役立ちます。

この例では input.pptx を開き、最初のスライド上の最初のジオメトリ形状を直接見つけて、そのパスセグメントを出力します。直線と曲線のセグメントを持つ形状が含まれるプレゼンテーションを使用すると、両方の出力を確認できます。グループ内部は検索しません。

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
                int pointType = types[i] & 0x07; // セグメントタイプを保持し、フラグは除外します。
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

配列はインデックスで対応します：`points[i]` は点、`types[i]` はその役割を示します。タイプ `0` は図形の開始、タイプ `1` は前の点から現在の点へ線を描きます。三次ベジエセグメントは前の終点から開始し、連続する 3 つのタイプ `3` エントリ（2 つの制御点と新しい終点）を使用します。ループはこれら 3 エントリをまとめて消費し、終点が閉じているかをチェックします。

ポイントタイプにはフラグも含まれます。`0x07` でマスクしてセグメントタイプを特定し、`0x80` を別途テストして閉じたサブパスかどうかを検出します。例として、`129`（`0x81`）はサブパスを閉じる線の終点を意味し、`131`（`0x83`）はサブパスを閉じるベジエの終点を意味します。Java はこれらのフラグを符号付きバイトで保持しており、マスクすることで意図したビット値が保たれます。生の値を `1` または `3` とだけ比較するとこれらのケースを見逃します。ダッシュ（`0x10`）やマーカー（`0x20`）などの他のフラグは、基本セグメントタイプを変更しません。

**座標と変換。** ポイントは points（1/72 インチ）で測定され、X は右方向に、Y は下方向に増加します。グループ化されていない形状の場合、抽出された座標はすでに [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) と [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) が返す位置を含み、現在の幅と高さを反映しています。例として、サイズ `120 × 80` の回転していない矩形が `(100, 200)` にある場合、輪郭境界は `(100, 200)`–`(220, 280)` となります。形状の位置を再度加算しないでください。X と Y を減算して、回転していないフレームに対する相対座標を取得します。

抽出されたポイントは、[getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) が返す形状の回転や水平・垂直の反転は適用されていません。表示された輪郭を再現するには、形状の中心を基準にこれらの変換を適用してください。グループ化された形状の場合は、グループ座標のマッピングと変換も考慮してください。抽出されたポイントが最終的なスライド座標であると想定したり、子フレームにすでに反映されている平行移動やスケールを二重に適用したりしないでください。

**検査と編集の違い。** 抽出された配列は輪郭を記述しており、それらを変更しても元の形状は更新されません。ポイント/タイプ配列が必要な分析や描画コードの場合にこの方法を選択してください。形状のローカル座標系でジオメトリコマンドが必要、またはジオメトリを編集したい場合は [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) を使用します。編集したパスは [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) または [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) を通じて適用してください。

## **Java AWT Shape を GeometryPath に変換する**

この例では、矩形のアウトラインとジオメトリに変換されたテキストを組み合わせます。アウトラインの [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) メソッドで塗りつぶしを無効にします。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) が [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) にテキストのアウトラインを作成します。その [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) が move、line、quadratic、cubic、閉じるセグメントを提供し、例ではそれらを [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) に再生します。

テキストは 40 ポイントの Arial フォントを使用します。アウトラインは水平方向に 20 ポイントオフセットし、視覚的な上部が形状の上端より 10 ポイント下に配置されます。テキストパスは塗りつぶされ、元の矩形はアウトラインのままです。[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) で両方のパスを適用すると、矩形とテキストを含む単一の形状が作成されます。

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
    // 新しい形状を作成
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 形状のジオメトリパスを取得
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // テキスト付きの新しいグラフィックパスを作成
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

    // グラフィックパスをジオメトリパスに変換
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

    // 新しいジオメトリパスと元のジオメトリパスの組み合わせを形状に設定
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしとアウトラインはどうなりますか？**

スタイルは形状に残り、輪郭だけが変わります。塗りつぶしとアウトラインは新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタム形状を正しく回転させるにはどうすればよいですか？**

形状の [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) メソッドを使用してください。ジオメトリは形状にバインドされた座標系に従うため、形状とともに回転します。

**カスタム形状を画像に変換して結果を「固定」できますか？**

はい。必要な [slide](/slides/ja/java/convert-powerpoint-to-png/) エリアもしくは [shape](/slides/ja/java/create-shape-thumbnails/) 自体をラスター形式でエクスポートしてください。これにより、複雑なジオメトリの後続処理が簡素化されます。