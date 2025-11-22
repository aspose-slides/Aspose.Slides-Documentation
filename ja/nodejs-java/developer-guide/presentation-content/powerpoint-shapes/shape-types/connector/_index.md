---
title: コネクタ
type: docs
weight: 10
url: /ja/nodejs-java/connector/
keywords: "図形の接続, コネクタ, PowerPoint 図形, PowerPoint プレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript で PowerPoint 図形を接続する"
---

PowerPoint のコネクタは、2 つの図形を接続またはリンクする特別な線で、スライド上で図形が移動または再配置されても図形に付着したままです。  

コネクタは通常、*connection dots*（緑のドット）に接続されます。connection dots はすべての図形に既定で存在し、カーソルが近づくと表示されます。  

*Adjustment points*（オレンジのドット）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。  

## **コネクタの種類**

PowerPoint では、直線、エルボー（角度付き）、および曲線のコネクタを使用できます。  

Aspose.Slides は以下のコネクタを提供します：

| コネクタ | Image | 調整ポイントの数 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **コネクタを使用して図形を接続する**

1. `[Presentation]` クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `[AutoShape]` を 2 つスライドに追加します。`Shapes` オブジェクトが提供する `addAutoShape` メソッドを使用します。  
4. `Shapes` オブジェクトが提供する `addConnector` メソッドを使用し、コネクタのタイプを指定してコネクタを追加します。  
5. コネクタを使用して図形を接続します。  
6. `reroute` メソッドを呼び出し、最短の接続パスを適用します。  
7. プレゼンテーションを保存します。  

この JavaScript コードは、2 つの図形（楕円と長方形）の間にコネクタ（曲がったコネクタ）を追加する方法を示しています：
```javascript
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 特定のスライドのシェイプコレクションにアクセスします
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // 楕円のオートシェイプを追加します
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // 長方形のオートシェイプを追加します
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // スライドのシェイプコレクションにコネクタシェイプを追加します
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // コネクタを使用してシェイプを接続します
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // シェイプ間の自動最短パスを設定する reroute を呼び出します
    connector.reroute();
    // プレゼンテーションを保存します
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` メソッドはコネクタの経路を再設定し、図形間で可能な限り最短のパスを取るように強制します。目的を達成するために、このメソッドは `setStartShapeConnectionSiteIndex` と `setEndShapeConnectionSiteIndex` のポイントを変更することがあります。  
{{% /alert %}} 

## **接続ドットの指定**

コネクタが図形上の特定のドットを使用して 2 つの図形をリンクさせたい場合は、以下の手順で希望する接続ドットを指定します：

1. `[Presentation]` クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `[AutoShape]` を 2 つスライドに追加します。`Shapes` オブジェクトが提供する `addAutoShape` メソッドを使用します。  
4. `Shapes` オブジェクトが提供する `addConnector` メソッドを使用し、コネクタのタイプを指定してコネクタを追加します。  
5. コネクタを使用して図形を接続します。  
6. 図形上で希望する接続ドットを設定します。  
7. プレゼンテーションを保存します。  

この JavaScript コードは、希望する接続ドットを指定する操作を示しています：
```javascript
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 特定のスライドのシェイプコレクションにアクセスします
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // 楕円オートシェイプを追加します
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // 長方形オートシェイプを追加します
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // スライドのシェイプコレクションにコネクタシェイプを追加します
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // コネクタを使用してシェイプを接続します
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // 楕円形状に対して優先接続ドットインデックスを設定します
    var wantedIndex = 6;
    // 優先インデックスが最大サイトインデックス数未満かをチェックします
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // 楕円オートシェイプに優先接続ドットを設定します
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // プレゼンテーションを保存します
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **コネクタポイントの調整**

既存のコネクタは、調整ポイントを使用して調整できます。調整ポイントがあるコネクタのみがこの方法で変更可能です。**[コネクタの種類](/slides/ja/nodejs-java/connector/#types-of-connectors)** の表を参照してください。  

### **単純なケース**

2 つの図形（A と B）を接続するコネクタが、3 番目の図形（C）を通過するケースを考えてみましょう：

![connector-obstruction](connector-obstruction.png)
```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


3 番目の図形を回避または通り抜けるために、コネクタの垂直線を左に移動させて調整できます：

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **複雑なケース** 

より複雑な調整を行うには、以下の点に留意する必要があります：

* コネクタの調整ポイントは、その位置を計算・決定する数式と強く結びついています。そのため、ポイントの位置を変更するとコネクタの形状が変わる可能性があります。  
* コネクタの調整ポイントは配列内で厳密な順序で定義されます。調整ポイントはコネクタの開始点から終了点へと番号付けされています。  
* 調整ポイントの値は、コネクタ形状の幅/高さのパーセンテージを表します。  
  * 形状はコネクタの開始点と終了点に 1000 を掛けた範囲で定義されます。  
  * 最初のポイントは幅のパーセンテージ、2 番目は高さのパーセンテージ、3 番目は再び幅のパーセンテージをそれぞれ定義します。  
* コネクタの調整ポイントの座標を計算する際には、コネクタの回転と反転を考慮する必要があります。**注**：**[コネクタの種類](/slides/ja/nodejs-java/connector/#types-of-connectors)** に示されているすべてのコネクタの回転角度は 0 です。  

#### **ケース 1**

2 つのテキストフレームオブジェクトがコネクタで接続されているケースを考えてみましょう：

![connector-shape-complex](connector-shape-complex.png)
```javascript
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    var sld = pres.getSlides().get_Item(0);
    // コネクタで結合される形状を追加します
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // コネクタを追加します
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // コネクタの方向を指定します
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // コネクタの色を指定します
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // コネクタの線の太さを指定します
    connector.getLineFormat().setWidth(3);
    // コネクタで形状を連結します
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // コネクタの調整ポイントを取得します
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**調整**

コネクタの調整ポイントの値は、対応する幅と高さのパーセンテージをそれぞれ 20% と 200% 増加させて変更できます：

```javascript
// 調整ポイントの値を変更します
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの各部位の座標と形状を決定できるモデルを定義するために、connector.getAdjustments().get_Item(0) ポイントに対応するコネクタの水平方向コンポーネントに相当する形状を作成します：

```javascript
// コネクタの垂直成分を描画します
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```


結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では、基本原理を用いたシンプルなコネクタ調整操作を示しました。通常の状況では、コネクタの回転と表示（connector.getRotation()、connector.getFrame().getFlipH()、connector.getFrame().getFlipV() によって設定される）を考慮する必要があります。ここでその手順を示します。

まず、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し（接続用）、既に作成したオブジェクトに接続する新しい（緑色の）コネクタを作成します。

```javascript
// 新しいバインディングオブジェクトを作成します
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 新しいコネクタを作成します
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// 新しく作成したコネクタを使用してオブジェクトを接続します
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// コネクタの調整ポイントを取得します
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 調整ポイントの値を変更します
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


結果：

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイント connector.getAdjustments().get_Item(0) を通過するコネクタの水平成分に対応する形状を作成します。connector.getRotation()、connector.getFrame().getFlipH()、connector.getFrame().getFlipV() のデータを使用し、指定点 x0 周りの回転に対する一般的な座標変換式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

このケースでは、オブジェクトの回転角度は 90 度で、コネクタは垂直に表示されるため、対応するコードは以下の通りです：

```javascript
// コネクタの座標を保存します
x = connector.getX();
y = connector.getY();
// コネクタの座標が反転している場合に修正します
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// 調整ポイントの値を座標として使用します
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Sin(90)=1、Cos(90)=0 であるため座標を変換します
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// 第二の調整ポイントの値を使用して水平成分の幅を決定します
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


結果：

![connector-adjusted-4](connector-adjusted-4.png)

シンプルな調整と回転角度を伴う複雑な調整ポイントに関する計算を示しました。この知識を活用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイントの値を設定するモデル（またはコード）を作成できます。  

## **コネクタラインの角度を求める**

1. クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. コネクタラインの形状にアクセスします。  
4. 線の幅、高さ、形状フレームの高さ、形状フレームの幅を使用して角度を計算します。  

この JavaScript コードは、コネクタライン形状の角度を計算する操作を示しています：

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```


## **FAQ**

**コネクタが特定の図形に「貼り付け」可能かどうかを判断するにはどうすればよいですか？**  

図形が [connection sites](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getconnectionsitecount/) を公開しているか確認してください。接続サイトが存在しない、または数が 0 の場合は貼り付けは利用できません。その場合はフリーエンドポイントを使用し、手動で位置を調整します。貼り付ける前にサイト数を確認するのが賢明です。  

**接続されている図形の一方を削除した場合、コネクタには何が起こりますか？**  

端点が切り離され、コネクタはフリーな開始/終了点を持つ普通の線としてスライドに残ります。削除するか、接続を再割り当てし、必要に応じて [reroute](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/reroute/) してください。  

**スライドを別のプレゼンテーションにコピーしたとき、コネクタのバインディングは保持されますか？**  

一般に保持されますが、対象の図形も同時にコピーされている必要があります。接続された図形が含まれない状態でスライドを別ファイルに挿入した場合、端点はフリーになり、再度接続し直す必要があります。