---
title: JavaScriptでプレゼンテーションシェイプをカスタマイズする
linktitle: カスタムシェイプ
type: docs
weight: 20
url: /ja/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して PowerPoint プレゼンテーション内のシェイプを作成およびカスタマイズします: ジオメトリパス、曲線コーナー、複合シェイプ。"
---
## **概要**

この記事では、編集ポイントとジオメトリパスを使用してシェイプのジオメトリを編集することで、Aspose.Slides のプレゼンテーションシェイプをカスタマイズする方法を説明します。[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) を使用して既存のシェイプを変更し、基本的なパス編集操作を実行し、ポイントを追加または削除し、更新されたジオメトリをシェイプに適用する方法を示します。

また、カスタムおよび複合シェイプの作成、曲線コーナーを持つシェイプの構築、シェイプジオメトリが閉じているかの判定、シェイプ要素の検査、Java AWT のテキストアウトラインをジオメトリパスに変換する方法も実演します。

## **編集ポイントを使用したシェイプの変更**

PowerPoint では、**Edit Points** を使用して正方形を変更できます：

* 角を内側または外側に移動する。
* 点の曲率を調整する。
* 新しいポイントを追加する。

編集ポイントを使用すると、シェイプのアウトラインを変更したり、既存のシェイプを新しいシェイプのベースとして使用したりできます。

## **シェイプ編集のヒント**

![overview_image](custom_shape_0.png)

PowerPoint のシェイプを編集するときは、以下の概念を念頭に置いてください：

* シェイプ（またはそのパス）は閉じている場合と開いている場合があります。
* シェイプのパスは、セグメントで接続されたアンカーポイントから構成されます。
* セグメントは直線または曲線にできます。アンカーポイントと制御ハンドルがその形状を決定します。
* アンカーポイントはコーナーポイント、ストレートポイント、またはスムーズポイントとして存在します：
  * コーナーポイントでは、隣接するセグメントが角度を持って接続できます。
  * スムーズポイントでは、2 つの制御ハンドルが一直線に揃い、アンカーポイントから等距離に配置されます。
  * ストレートポイントでは、2 つの制御ハンドルは揃っていますが、アンカーポイントからの距離は異なる場合があります。
* アンカーポイントを移動したりハンドルを調整したりすると、シェイプのアウトラインが変更されます。

編集ポイントを介して PowerPoint のシェイプを編集するには、**Aspose.Slides** が [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) クラスを提供しています。

* [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) インスタンスは、[GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) オブジェクトのジオメトリパスを表します。
* [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) インスタンスから [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) を取得するには、[GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) メソッドを使用できます。
* シェイプに [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) を設定するには、単一パスのシェイプの場合は [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)、複数パスのシェイプの場合は [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) を使用します。
* セグメントを追加するには、[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) のメソッドを使用できます。
* [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) と [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) メソッドを使用して、ジオメトリパスの外観を設定できます。
* [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) メソッドを使用すると、[GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) のジオメトリパスをパスセグメントの配列として取得できます。
* 追加のシェイプジオメトリカスタマイズオプションにアクセスするには、[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) をその [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) で読み取り、セグメントを [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 上で再現できます。

## **シンプルな編集操作**

ジオメトリパスを編集するには以下のメソッドを使用します。インデックスを受け取るオーバーロードは、パスのセグメント配列のゼロベース位置にセグメントを挿入します。

| 操作 | メソッド |
| --- | --- |
| 直線を追加または挿入する。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| 2 つの制御点と終点を持つキュービックベジェ曲線を追加または挿入する。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 1 つの制御点と終点を持つ二次ベジェ曲線を追加または挿入する。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 指定された寸法と角度（度）で楕円弧を追加する。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| エンドポイントを開始点に接続して現在の図形を閉じる。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| 図形の開始点を設定する。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| ゼロベースインデックスの位置にあるセグメントを削除する。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **シェイプにカスタムポイントを追加**

この例では、[GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) を使用して長方形シェイプに 2 つのポイントを挿入し、編集されたパスを [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) で適用します。座標はシェイプに対してローカルで、2 つの新しいポイントはシェイプの中心にあり、左から 100 ポイント、上から 50 ポイントの位置です。セグメントインデックス 1 と 4 はそれぞれ上部と下部のエッジに配置し、これらのエッジを内側に引き込むようにします。

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

## **シェイプからポイントを削除**

この例では、[GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) を使用してゼロベースインデックス 2 のセグメントを削除し、ハート形のアウトラインを変更します。[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) で修正されたパスを適用すると、シェイプの輪郭が更新されます。

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

## **カスタムシェイプを作成**

この例では、[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) を使用して5角形の星形を構築します。外側と内側の半径をそれぞれ 100 と 50 ポイント交互に設定して先端と凹部を定義し、72 度のステップで5つの先端を均等に配置します。パスは [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) で閉じられ、[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) を使用して長方形シェイプに適用し、アウトラインを置き換えます。

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

## **複合カスタムシェイプを作成**

この例では、シェイプの上部と下部の3分の1に対して2つの閉じた [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) オブジェクトを定義します。[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) で両方のパスを適用すると、中央の3分の1に隙間のある単一の複合シェイプが作成されます。

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

## **曲線コーナー付きカスタムシェイプを作成**

この例では、直線セグメントと [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) を組み合わせて、内側に曲がったコーナーを持つシェイプを作成します。各コーナーサイズはアークの幅と高さ（ポイント単位）を設定し、-90 度のスイープで反時計回りの四分円を描きます。完成したパスは [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) で適用され、プレゼンテーションは PPTX 形式で保存されます。

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

## **シェイプジオメトリが閉じているか確認**

次のヘルパーは、すべての非空ジオメトリパスが閉じるセグメントで終わっているかを確認します。[GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) を読み取り、最後のセグメントの [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) を [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) と比較します。非空パスがない場合は false を返します。これは各パスの最終コマンドをチェックしますが、パス内のすべてのサブフィギュアは検査しません。例では長方形に対して `true` を出力します。

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

## **ジオメトリパスコマンドの検査**

アプリケーションの作業ディレクトリに [contour.pptx](contour.pptx) をダウンロードして配置します。最初のスライドの最初のシェイプは、直線の上辺、キュービックベジェ曲線、そして直線の閉じる辺を持ちます。[getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) を使用してシェイプのパスを読み取り、[getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) で各パスのセグメントを描画順に取得します。各セグメントについて、[getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) がコマンドを識別し、[getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData) が返す値の解釈方法を決定します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

シェイプはスライド上で (200, 100) ポイントの位置にあります。報告された座標はシェイプに対してローカルで、(0, 0) が左上隅、x は右方向に増加し、y は下方向に増加します。閉じるセグメントは追加の座標なしで開始点に戻ります。

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![上辺が直線で、右上から左下へ曲線のエッジ、左辺が直線の PowerPoint シェイプ](contour.png)

## **シェイプ要素の抽出と検査**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) を使用して、パスポイントとポイントタイプを含む要素として既存のシェイプを検査します。返された各 [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) を使用して、[getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) と [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) メソッドでポイント配列とタイプ配列を取得します。この表現は輪郭解析やジオメトリをカスタム描画ツールに渡す際に便利です。

この例では input.pptx を開き、最初のスライド上の最初のジオメトリシェイプを直接見つけて、そのパスセグメントを出力します。直線と曲線のセグメントを持つシェイプが含まれるプレゼンテーションを使用すれば、両方の出力が確認できます。グループ内部は検索しません。

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
                const pointType = types[i] & 0x07; // フラグを除き、セグメントタイプだけを保持します。
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // 制御点2つと終点を消費します。
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

配列はインデックスで対応しています：`points[i]` はポイント、`types[i]` はその役割を示します。タイプ `0` は図形の開始、タイプ `1` は前のポイントから現在のポイントへ線を描画します。キュービックベジェセグメントは前の終点から開始し、連続する 3 つのタイプ `3` エントリを使用します：2 つの制御点と新しい終点です。ループはこれら 3 つのエントリをまとめて消費し、終点が閉じているかを確認します。

ポイントタイプにはフラグも含まれます。`0x07` でマスクしてセグメントタイプを特定し、`0x80` を別途テストして閉じたサブパスかどうかを検出します。例えば、`129`（`0x81`）はサブパスを閉じる線の終点を意味し、`131`（`0x83`）はサブパスを閉じるベジェの終点を意味します。Java はこれらのフラグを符号付きバイトで保持しますが、マスクすることで意図したビット値が保たれます。生の値を `1` や `3` とだけ比較するとこれらのケースを見逃します。ダッシュ（`0x10`）やマーカー（`0x20`）などの他のフラグは基礎セグメントタイプを変更しません。

**座標と変換。** ポイントはポイント単位（1/72 インチ）で測定され、X は右方向に、Y は下方向に増加します。グループ化されていないシェイプの場合、抽出された座標はすでに [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) と [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) が返す位置を含み、現在の幅と高さを反映しています。例えば、位置が `(100, 200)` でサイズが `120 × 80` の回転していない長方形は、輪郭境界が `(100, 200)`–`(220, 280)` となります。シェイプの位置を再度加算しないでください。X と Y を減算して、回転していないフレームに対する相対座標を取得します。

抽出されたポイントは、[getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) が返すシェイプの回転や水平・垂直の反転は適用されていません。表示された輪郭を再現するには、シェイプの中心を基準にそれらの変換を適用してください。グループ化されたシェイプの場合、グループ座標のマッピングと変換も考慮します。抽出されたポイントが最終的なスライド座標であると想定したり、子フレームにすでに反映されている平行移動やスケールを二重に適用したりしないでください。

**検査と編集の違い。** 抽出された配列は輪郭を記述しますが、これらを変更しても元のシェイプは更新されません。解析や描画コードがポイント/タイプ配列を必要とする場合にこの方法を選択してください。シェイプのローカル座標系でジオメトリコマンドが必要な場合やジオメトリを編集したい場合は [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) を使用します。編集したパスは [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) または [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) で適用します。

## **Java AWT シェイプを GeometryPath に変換**

この例では、長方形のアウトラインとジオメトリに変換したテキストを組み合わせます。アウトラインの [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) メソッドで塗りつぶしを無効にします。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) が [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) にテキストアウトラインを作成します。その [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) が移動、直線、二次、三次、閉じるセグメントを提供し、例ではそれらを [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 上で再現します。

Java ブリッジは対応する Java パラメータに対して明示的な float と byte の値を使用します。イテレータは座標を Java の float 配列に書き込み、リフレクションで更新された値を JavaScript に読み戻します。テキストは 40 ポイントの Arial フォントを使用します。アウトラインは水平方向に 20 ポイントオフセットされ、視覚的な上部がシェイプの上端から 10 ポイント下に配置されます。テキストパスは塗りつぶされ、元の長方形はアウトラインのままです。[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) で両方のパスを適用すると、長方形とテキストを含む単一のシェイプが生成されます。

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
            case 0: // 移動。
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // 直線へ。
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // 二次ベジェ曲線。
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // 三次ベジェ曲線。
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // 図形を閉じる。
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

**ジオメトリを置き換えた後、塗りつぶしとアウトラインはどうなりますか？**

スタイルはシェイプに残り、輪郭だけが変更されます。塗りつぶしとアウトラインは自動的に新しいジオメトリに適用されます。

**ジオメトリとともにカスタムシェイプを正しく回転させるにはどうすればよいですか？**

[setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) メソッドを使用します。ジオメトリはシェイプの座標系にバインドされているため、シェイプとともに回転します。

**カスタムシェイプを画像に変換して結果を「ロック」できますか？**

はい。必要な [スライド](/slides/ja/nodejs-java/convert-powerpoint-to-png/) エリアまたは [シェイプ](/slides/ja/nodejs-java/create-shape-thumbnails/) 自体をラスタ形式でエクスポートできます。これにより、複雑なジオメトリの後続処理が簡素化されます。