---
title: Android でプレゼンテーション シェイプをカスタマイズする
linktitle: カスタム シェイプ
type: docs
weight: 20
url: /ja/androidjava/custom-shape/
keywords:
- カスタムシェイプ
- シェイプを追加
- シェイプを作成
- シェイプを変更
- シェイプジオメトリ
- ジオメトリパス
- パスポイント
- 編集ポイント
- ポイントを追加
- ポイントを削除
- 編集操作
- 曲線コーナー
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides で PowerPoint プレゼンテーションのシェイプを作成およびカスタマイズします：ジオメトリパス、曲線コーナー、複合シェイプ。"
---
## **概要**

この記事では、編集ポイントとジオメトリパスを使用してシェイプのジオメトリを編集することで、Aspose.Slides のプレゼンテーション シェイプをカスタマイズする方法を説明します。[GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) および [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) を使用して既存シェイプを変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリをシェイプに適用する方法を示します。

また、カスタムおよび複合シェイプの作成、角が丸いシェイプの構築、シェイプジオメトリが閉じているかどうかの判定、Android のポイント配列を使用したシェイプ要素の検査方法も実演します。

## **編集ポイントでシェイプを変更する**

PowerPoint では **Edit Points** を使用して四角形を変更できます。

* 角を内側または外側に移動します。
* 点の曲率を調整します。
* 新しい点を追加します。

編集ポイントを使用すると、シェイプの輪郭を変更したり、既存のシェイプを新しいシェイプのベースとして使用したりできます。

## **シェイプ編集のヒント**

![概要画像](custom_shape_0.png)

PowerPoint シェイプを編集する際は、次の概念を覚えておいてください。

* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* シェイプのパスはアンカーポイントとそれらを結ぶセグメントで構成されます。
* セグメントは直線または曲線になる可能性があります。アンカーポイントとコントロールハンドルが形状を決定します。
* アンカーポイントはコーナー、直線、スムーズのいずれかです：
  * コーナーでは、隣接するセグメントが角度を持って接続できます。
  * スムーズポイントでは、2 つのコントロールハンドルが揃っており、アンカーポイントから同距離です。
  * 直線ポイントでは、2 つのコントロールハンドルが揃っていますが、距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、シェイプの輪郭が変わります。

編集ポイントを介して PowerPoint シェイプを編集するために、**Aspose.Slides** は [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) クラスと [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) インターフェイスを提供します。

* [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) インスタンスは、[IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) オブジェクトのジオメトリ パスを表します。
* [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) を取得するには、[IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) メソッドを使用します。
* シェイプに [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) を設定するには、単一パスの場合は [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) を、複数パスの場合は [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) を使用します。
* セグメントを追加するには、[IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) のメソッドを使用します。
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) および [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) メソッドでジオメトリ パスの外観を設定できます。
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) メソッドを使用すると、[GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) のジオメトリ パスをパス セグメントの配列として取得できます。

## **シンプルな編集操作**

ジオメトリ パスを編集するには以下のメソッドを使用します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入します。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 2 つのコントロールポイントと終点を持つ 3 次ベジエ曲線を追加または挿入します。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 1 つのコントロールポイントと終点を持つ 2 次ベジエ曲線を追加または挿入します。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 指定された寸法と角度（度単位）で楕円弧を追加します。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| エンドポイントを開始点に接続して現在の図形を閉じます。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| 図形の開始点を設定します。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| ゼロベース インデックスでセグメントを削除します。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **シェイプにカスタムポイントを追加する**

この例は、[GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) を使用して矩形シェイプに 2 つのポイントを挿入し、編集されたパスを [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で適用します。座標はシェイプに対してローカルで、両方の新しいポイントはシェイプの中心にあり、左端から 100 ポイント、上端から 50 ポイントの位置です。セグメントインデックス 1 と 4 はそれぞれ上端と下端に配置され、これらのエッジを内側へ引っ張ります。

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

![例1画像](custom_shape_1.png)

## **シェイプからポイントを削除する**

この例は、[GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) を使用してゼロベース インデックス 2 のセグメントを削除することでハート形の輪郭を変更します。変更されたパスを [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で適用すると、シェイプの輪郭が更新されます。

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
![例2画像](custom_shape_2.png)

## **カスタム シェイプを作成する**

この例は、[GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) を使用して五角形の星形を構築します。外側半径 100、内側半径 50 の交互の半径が先端と凹みを定義し、72 度のステップで 5 つの先端を均等に配置します。パスは [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) で閉じられ、[IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) を使用して矩形シェイプに適用し、元の輪郭を置き換えます。

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
![例3画像](custom_shape_3.png)

## **複合カスタムシェイプを作成する**

この例は、シェイプの上部と下部の 3 分の 1 を表す 2 つの閉じた [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) オブジェクトを定義します。両方のパスを [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) で適用すると、中央の 3 分の 1 に隙間のある単一の複合シェイプが作成されます。

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
![例4画像](custom_shape_4.png)

## **角が丸いカスタムシェイプを作成する**

この例は、直線セグメントと [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) を組み合わせて、内側にカーブした角を持つシェイプを作成します。各角サイズはアークの幅と高さ（ポイント単位）を設定し、-90 度のスイープで反時計回りの 1/4 楕円を描きます。完成したパスは [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) で適用され、プレゼンテーションは PPTX 形式で保存されます。

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

## **シェイプジオメトリが閉じているか確認する**

次のヘルパーは、すべての非空ジオメトリ パスが閉じるセグメントで終わるかどうかをチェックします。[IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) を読み取り、最終セグメントの [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) を [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) と比較します。非空パスがない場合は false を返します。このチェックは各パスの最終コマンドのみを確認し、パス内のすべてのサブフィギュアは検査しません。例は矩形に対して `true` を出力します。

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

## **ジオメトリ パス コマンドを検査する**

[contour.pptx](contour.pptx) をダウンロードし、サンプル ファイル名をデバイス上のパスに置き換えてください。最初のスライドの最初のシェイプは、直線の上端、3 次ベジエ曲線、直線の閉じた下端を持ちます。[getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) を使用してシェイプのパスを取得し、[getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) で各パスのセグメントを描画順に読み取ります。各セグメントについて、[getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) がコマンドを識別し、[getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) が返す値の解釈方法を決定します。

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

シェイプはスライド上の (200, 100) ポイントに配置されています。報告された座標はシェイプに対してローカルで、左上隅が (0, 0)、X が右方向に増加、Y が下方向に増加します。閉じるセグメントは追加座標なしで開始点に戻ります。

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **シェイプ要素を抽出して検査する**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) を使用して、パスポイントとポイント タイプを含む要素として既存シェイプを検査します。返された各 [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) を [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) にキャストし、[getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) と [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) メソッドでポイント配列とタイプ配列を取得します。この表現は輪郭解析やカスタム描画ツールへのジオメトリ受け渡しに便利です。

例では input.pptx を開き、最初のスライド上の最初のジオメトリ シェイプを直接見つけて、そのパス セグメントを出力します。直線と曲線のセグメントを持つシェイプを含むプレゼンテーションを使用すると、両方の出力が確認できます。グループ内部は検索しません。

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
                int pointType = types[i] & 0x07; // フラグを除外してセグメントタイプだけを保持します。
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // 2 つの制御ポイントと終点の両方を消費します。
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

配列はインデックスで対応します：`points[i]` がポイント、`types[i]` がその役割を示します。タイプ `0` は図形の開始を、タイプ `1` は前のポイントから現在のポイントへの直線を表します。3 次ベジエ セグメントは前の終点から開始し、連続するタイプ `3` エントリ 3 つ（2 つのコントロールポイントと新しい終点）で構成されます。ループはこれら 3 エントリをまとめて消費し、終点が閉じているかをチェックします。

ポイント タイプにはフラグも含まれます。`0x07` でセグメント タイプを識別し、`0x80` を別途テストして閉じたサブパスを検出します。例として `129`（`0x81`）はサブパスを閉じる直線終点、`131`（`0x83`）はサブパスを閉じるベジエ終点を意味します。Java はこれらのフラグを符号付きバイトで保持するため、マスク処理でビット値を保持します。単に `1` または `3` と比較するだけではこれらのケースを見逃すことになります。ダッシュ（`0x10`）やマーカー（`0x20`）などのその他のフラグは基本セグメント タイプを変更しません。

**座標と変換。**ポイントはポイント単位（1/72 インチ）で測定され、X は右方向、Y は下方向に増加します。非グループ化シェイプの場合、抽出された座標にはすでに [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) と [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) が返す位置が含まれ、現在の幅と高さが反映されています。例として、`(100, 200)` に左上が置かれ、サイズ `120 × 80` の未回転矩形の輪郭は `(100, 200)`–`(220, 280)` です。シェイプの位置を再度加算しないでください。X と Y を差し引いて未回転フレームに対する相対座標を取得します。

抽出されたポイントは [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) が返す回転や水平・垂直フリップを適用しません。表示された輪郭を再現するには、シェイプの中心を基準にそれらの変換を適用してください。グループ化シェイプの場合は、グループ座標マッピングと変換も考慮する必要があります。抽出ポイントが最終的なスライド座標になると仮定したり、すでに子フレームに反映されている変換を二重に適用したりしないでください。

**検査と編集の違い。**抽出された配列は輪郭を記述しますが、変更しても元のシェイプは更新されません。ポイント/タイプ配列が必要な分析や描画コードの場合にこのアプローチを選択してください。シェイプのローカル座標系でジオメトリ コマンドが必要、またはジオメトリを編集したい場合は [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) を使用し、編集したパスは [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) または [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) を通じて適用してください。

## **FAQ**

**ジオメトリを置き換えた後、塗りつぶしと輪郭はどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしと輪郭は新しいジオメトリに自動的に適用されます。

**ジオメトリとともにカスタムシェイプを正しく回転させるにはどうすればよいですか？**

シェイプの [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) メソッドを使用してください。ジオメトリはシェイプの座標系にバインドされているため、シェイプとともに回転します。

**カスタムシェイプを画像に変換して「ロック」できますか？**

はい。必要な [スライド](/slides/ja/androidjava/convert-powerpoint-to-png/) 領域または [シェイプ](/slides/ja/androidjava/create-shape-thumbnails/) 自体をラスタ形式にエクスポートすると、複雑なジオメトリの後続作業が簡素化されます。