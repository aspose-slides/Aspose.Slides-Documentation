---
title: "Javaでプレゼンテーションシェイプをカスタマイズする"
linktitle: "カスタムシェイプ"
type: docs
weight: 20
url: /ja/java/custom-shape/
keywords:
- "カスタムシェイプ"
- "シェイプを追加"
- "シェイプを作成"
- "シェイプを変更"
- "シェイプジオメトリ"
- "ジオメトリパス"
- "パスポイント"
- "編集ポイント"
- "ポイントを追加"
- "ポイントを削除"
- "編集操作"
- "曲線コーナー"
- "PowerPoint"
- "プレゼンテーション"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションのシェイプを作成およびカスタマイズする：ジオメトリパス、曲線コーナー、複合シェイプ。"
---
## **概要**

この記事では、編集ポイントとジオメトリパスを使用してシェイプジオメトリを編集し、Aspose.Slides のプレゼンテーションシェイプをカスタマイズする方法を説明します。[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) と [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) を使用して既存のシェイプを変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリをシェイプに適用する方法を示します。

また、カスタムシェイプや複合シェイプの作成、曲線コーナーを持つシェイプの構築、シェイプジオメトリが閉じているかの判定、シェイプ要素の検査、Java AWT のテキストアウトラインをジオメトリパスに変換する方法も示しています。

## **編集ポイントを使用してシェイプを変更する**

PowerPoint では、**Edit Points** を使用して四角形を変更できます:
* 角を内側または外側に移動する。
* ポイントの曲率を調整する。
* 新しいポイントを追加する。

ポイントを編集することで、シェイプのアウトラインを変更したり、既存のシェイプを新しいシェイプのベースとして使用したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint のシェイプを編集する際は、次の概念を念頭に置いてください:
* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* シェイプのパスは、セグメントで接続されたアンカーポイントで構成されます。
* セグメントは直線または曲線のいずれかです。アンカーポイントと制御ハンドルがその形状を決定します。
* アンカーポイントはコーナーポイント、ストレートポイント、スムーズポイントとして存在します:
  * コーナーポイントでは、隣接するセグメントが角度で合わさります。
  * スムーズポイントでは、2 つの制御ハンドルが整列し、アンカーポイントから等距離にあります。
  * ストレートポイントでは、2 つの制御ハンドルが整列していますが、アンカーポイントからの距離は異なる場合があります。
* アンカーポイントを移動したり、ハンドルを調整したりすると、シェイプのアウトラインが変わります。

編集ポイントを使用して PowerPoint のシェイプを編集するには、**Aspose.Slides** が [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) クラスと [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) インターフェイスを提供します。
* [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) のインスタンスは、[IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) オブジェクトのジオメトリパスを表します。
* [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) を取得するには、[IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) メソッドを使用できます。
* シェイプに [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) を設定するには、単一パスのシェイプの場合は [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) を、複数パスのシェイプの場合は [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) を使用します。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) の下にあるメソッドを使用できます。
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) と [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) メソッドを使用して、[GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションへアクセスするには、[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) をその [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) で読み取り、セグメントを [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) に再現できます。

## **シンプルな編集操作**

ジオメトリパスを編集するには、以下のメソッドを使用します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 2 つの制御点と終点を持つ三次ベジエ曲線を追加または挿入する。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 1 つの制御点と終点を持つ二次ベジエ曲線を追加または挿入する。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 指定された寸法と角度（度）で楕円弧を追加する。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 終点と開始点を接続して現在の図形を閉じる。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| 図形の開始点を設定する。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| ゼロベースインデックスでセグメントを削除する。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **シェイプにカスタムポイントを追加する**

この例では、[GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) を使用して長方形シェイプに 2 つのポイントを挿入し、編集されたパスを [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で適用します。座標はシェイプに対してローカルで、2 つの新しいポイントはシェイプの中心にあり、左側から 100 ポイント、上側から 50 ポイントの位置です。セグメントインデックス 1 と 4 がそれぞれ上部と下部のエッジに配置され、これらのエッジを内側に引っ張ります。

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

## **シェイプからポイントを削除する**

この例では、[GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) を使用してゼロベースインデックス 2 のセグメントを削除し、ハート形のアウトラインを変更します。[IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で変更されたパスを適用すると、シェイプの輪郭が更新されます。

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

## **カスタムシェイプを作成する**

この例では、[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) を使用して5角形の星形を構築します。外側半径 100 ポイントと内側半径 50 ポイントを交互に設定して先端と凹みを定義し、72 度のステップで5つの先端を等間隔に配置します。[GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) でパスを閉じ、[IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) を使用して長方形シェイプに適用し、アウトラインを置き換えます。

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

## **複合カスタムシェイプを作成する**

この例では、シェイプの上部と下部の三分の一に対して 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) オブジェクトを定義します。[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) で両方のパスを適用すると、中央の三分の一に隙間のある単一の複合シェイプが作成されます。

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

## **曲線コーナー付きカスタムシェイプを作成する**

この例では、直線セグメントと [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) を組み合わせて内側に曲がったコーナーを持つシェイプを作成します。各コーナーサイズはアークの幅と高さ（ポイント）を設定し、-90 度のスイープで反時計回りの四分円弧を描きます。完成したパスは [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で適用され、プレゼンテーションは PPTX 形式で保存されます。

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

## **シェイプジオメトリが閉じているかを確認する**

以下のヘルパーは、すべての非空ジオメトリパスが閉じるセグメントで終わっているかを確認します。[IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) を読み取り、最終セグメントの [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) と [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) を比較します。非空パスがない場合は false を返します。このチェックは各パスの最終コマンドを確認するもので、パス内のすべてのサブフィギュアを検査するわけではありません。例では矩形に対して `true` を出力します。

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

## **シェイプ要素の抽出と検査**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) を使用して、パスポイントとポイントタイプを含む要素として既存のシェイプを検査します。返された各 [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) を [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) にキャストし、[getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) と [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) メソッドでポイント配列とタイプ配列を取得します。この表現は輪郭解析やジオメトリをカスタム描画ツールに渡す際に便利です。

この例では input.pptx を開き、最初のスライド上の最初のジオメトリシェイプを直接見つけてそのパスセグメントを出力します。直線と曲線のセグメントを持つシェイプが含まれるプレゼンテーションを使用すると、両方の出力を確認できます。グループ内は検索しません。

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
                int pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
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

配列はインデックスで対応しています: `points[i]` は点、`types[i]` はその役割を示します。タイプ `0` は図形の開始を表し、タイプ `1` は前の点から現在の点へ線を描きます。三次ベジエセグメントは前の終点から開始し、連続するタイプ `3` のエントリ3つ（2 つの制御点と新しい終点）を使用します。ループはこれら3つのエントリをまとめて処理し、終点が閉じているかを確認します。

ポイントタイプにはフラグも含まれます。`0x07` でマスクしてセグメントタイプを識別し、`0x80` を別途テストして閉じたサブパスかどうかを検出します。例として、`129`（`0x81`）はサブパスを閉じる線の終点、`131`（`0x83`）はサブパスを閉じるベジエの終点を意味します。Java はこれらのフラグを符号付きバイトで保持しているため、マスク処理で意図したビット値が保たれます。生の値を `1` や `3` のみと比較するとこれらのケースを見逃します。ダッシュ（`0x10`）やマーカー（`0x20`）などの他のフラグは基礎セグメントタイプを変更しません。

**座標と変換.**  
ポイントはポイント単位（1 イン­チの 1/72）で測定され、X は右方向に、Y は下方向に増加します。グループ化されていないシェイプの場合、抽出された座標はすでに [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) と [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) が返す位置を含み、現在の幅と高さを反映しています。たとえば、サイズ `120 × 80` の回転していない矩形が `(100, 200)` にある場合、輪郭の境界は `(100, 200)`–`(220, 280)` です。シェイプの位置を再度加算しないでください。X と Y を減算して、回転していないフレームに対する相対座標を取得します。

抽出されたポイントは、[getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) が返すシェイプの回転や水平・垂直の反転は適用されません。表示された輪郭を再現するには、シェイプの中心を基準にそれらの変換を適用してください。グループ化されたシェイプの場合、グループ座標のマッピングと変換も考慮します。抽出されたポイントが最終的なスライド座標であると想定したり、子フレームに既に反映されている平行移動やスケールを二重に適用したりしないでください。

**検査と編集の違い.** 抽出された配列は輪郭を記述しますが、変更しても元のシェイプは更新されません。ポイント/タイプ配列が必要な解析や描画コードの場合にこの方法を選択してください。シェイプのローカル座標系でジオメトリコマンドが必要な場合やジオメトリを編集したい場合は [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) を使用します。編集したパスは [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) または [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) を通じて適用します。

## **Java AWT Shape を GeometryPath に変換する**

この例では、矩形のアウトラインとジオメトリに変換されたテキストを組み合わせます。アウトラインの [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) メソッドで塗りつぶしを無効にします。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) が [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) にテキストのアウトラインを作成します。その [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) は move、line、quadratic、cubic、closing の各セグメントを提供し、例ではそれらを [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) に再現します。

テキストは 40 ポイントの Arial フォントを使用します。アウトラインは水平方向に 20 ポイントオフセットされ、視覚的な上端がシェイプの上端から 10 ポイント下に配置されます。テキストパスは塗りつぶされ、元の矩形はアウトラインのままです。[IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) で両方のパスを適用すると、矩形とテキストを含む単一のシェイプが生成されます。

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
    // 新しいシェイプを作成
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // シェイプのジオメトリパスを取得
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // テキストで新しいグラフィックパスを作成
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

    // シェイプに新しいジオメトリパスと元のジオメトリパスの組み合わせを設定
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```

![example5_image](custom_shape_5.png)

## **よくある質問**

**ジオメトリを置き換えた後、塗りつぶしとアウトラインはどうなりますか？**  
スタイルはシェイプに残り、輪郭だけが変わります。塗りつぶしとアウトラインは自動的に新しいジオメトリに適用されます。

**ジオメトリとともにカスタムシェイプを正しく回転させるにはどうすればよいですか？**  
[setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) メソッドを使用します。ジオメトリはシェイプの座標系にバインドされているため、シェイプとともに回転します。

**カスタムシェイプを画像に変換して結果を「ロック」できますか？**  
はい。必要な [slide](/slides/ja/java/convert-powerpoint-to-png/) 領域または [shape](/slides/ja/java/create-shape-thumbnails/) 自体をラスタ形式でエクスポートしてください。これにより、複雑なジオメトリの追加作業が簡略化されます。