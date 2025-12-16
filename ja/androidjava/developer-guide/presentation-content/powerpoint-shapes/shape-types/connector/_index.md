---
title: Android でのプレゼンテーションにおけるコネクタの管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/androidjava/connector/
keywords:
- コネクタ
- コネクタの種類
- コネクタのポイント
- コネクタ線
- コネクタ角度
- シェイプの接続
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 上の PowerPoint スライドで、Java アプリが線を描画し、接続し、自動経路設定できるようにし、直線、肘型、曲線コネクタを完全に制御できます。"
---

PowerPoint のコネクタは、2 つのシェイプを接続またはリンクする特別な線で、スライド上でシェイプが移動または再配置されてもシェイプに固定されたままです。

コネクタは通常、*接続点*（緑の点）に接続されます。接続点はすべてのシェイプにデフォルトで存在し、カーソルが近づくと表示されます。

*調整ポイント*（オレンジの点）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPoint では、直線、肘（角度）および曲線コネクタを使用できます。

Aspose.Slides は次のコネクタを提供します。

| コネクタ | 画像 | 調整ポイント数 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **コネクタでシェイプを接続する**

1. [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使ってスライドの参照を取得します。  
1. `Shapes` オブジェクトが提供する `addAutoShape` メソッドを使い、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) を追加します。  
1. `Shapes` オブジェクトが提供する `addConnector` メソッドでコネクタの種類を指定してコネクタを追加します。  
1. コネクタを使ってシェイプを接続します。  
1. `reroute` メソッドを呼び出して最短接続経路を適用します。  
1. プレゼンテーションを保存します。  

この Java コードは、2 つのシェイプ（楕円と長方形）の間に曲げコネクタを追加する方法を示しています。  
```Java
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 特定のスライドのシェイプ コレクションにアクセスする
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // 楕円のオートシェイプを追加する
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // 四角形のオートシェイプを追加する
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // スライドのシェイプ コレクションにコネクタ シェイプを追加する
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // コネクタを使用してシェイプを接続する
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // シェイプ間の自動最短パスを設定する reroute を呼び出す
    connector.reroute();
    
    // プレゼンテーションを保存する
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.reroute` メソッドはコネクタの経路を再計算し、シェイプ間の最短経路を強制的に取らせます。そのため、メソッドは `setStartShapeConnectionSiteIndex` および `setEndShapeConnectionSiteIndex` のポイントを変更することがあります。 

{{% /alert %}} 

## **接続点を指定する**

コネクタをシェイプ上の特定の点で接続したい場合は、以下の手順で希望の接続点を指定します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使ってスライドの参照を取得します。  
1. `Shapes` オブジェクトが提供する `addAutoShape` メソッドでスライドに 2 つの [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) を追加します。  
1. `Shapes` オブジェクトが提供する `addConnector` メソッドでコネクタの種類を指定してコネクタを追加します。  
1. コネクタでシェイプを接続します。  
1. シェイプ上で希望の接続点を設定します。  
1. プレゼンテーションを保存します。  

この Java コードは、接続点を指定した操作の例を示しています。  
```java
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 特定のスライドのシェイプ コレクションにアクセスする
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // 楕円のオートシェイプを追加する
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 矩形のオートシェイプを追加する
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // スライドのシェイプ コレクションにコネクタ シェイプを追加する
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // コネクタを使用してシェイプを接続する
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // 楕円シェイプの優先接続点インデックスを設定する
    int wantedIndex = 6;

    // 優先インデックスが最大サイトインデックス数未満かチェックする
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // 楕円オートシェイプに優先接続点を設定する
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // プレゼンテーションを保存する
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **コネクタのポイントを調整する**

既存のコネクタは調整ポイントを使って変更できます。調整ポイントを持つコネクタだけがこの方法で変更可能です。詳しくは **[コネクタの種類](/slides/ja/androidjava/connector/#types-of-connectors)** の表をご覧ください。

### **単純なケース**

2 つのシェイプ (A と B) を結ぶコネクタが、3 番目のシェイプ (C) を通過する場合を考えます。

![コネクタ遮蔽](connector-obstruction.png)  
```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```


3 番目のシェイプを回避するために、コネクタの垂直線を左側に移動して次のように調整します。

![コネクタ遮蔽修正済み](connector-obstruction-fixed.png)  
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **複雑なケース**

より複雑な調整を行うには、以下の点に留意する必要があります。

* コネクタの調整ポイントは、位置を計算・決定する数式に強く結び付いています。そのため、ポイントの位置を変更するとコネクタの形状が変わります。  
* 調整ポイントは配列内で厳密な順序で定義されます。ポイントはコネクタの開始点から終了点へ向かって番号付けされます。  
* 調整ポイントの値は、コネクタ形状の幅/高さに対するパーセンテージを表します。  
  * 幅/高さはコネクタの開始点と終了点を 1000 倍したものです。  
  * 第 1, 第 2, 第 3 のポイントはそれぞれ幅のパーセンテージ、高さのパーセンテージ、再び幅のパーセンテージを定義します。  
* 調整ポイントの座標を算出する際は、コネクタの回転と反転を考慮しなければなりません。**注意**: **[コネクタの種類](/slides/ja/androidjava/connector/#types-of-connectors)** に示されたすべてのコネクタの回転角度は 0 です。  

#### **ケース 1**

2 つのテキストフレーム オブジェクトがコネクタでリンクされているケースを考えます。

![コネクタ形状複雑](connector-shape-complex.png)  
```java
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    // コネクタで結合されるシェイプを追加します
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // コネクタを追加します
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // コネクタの方向を指定します
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // コネクタの色を指定します
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // コネクタの線の太さを指定します
    connector.getLineFormat().setWidth(3);
    
    // コネクタでシェイプ同士をリンクします
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // コネクタの調整ポイントを取得します
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```


**調整**

対応する幅と高さのパーセンテージをそれぞれ 20% と 200% 増加させて、コネクタの調整ポイントの値を変更できます。  
```java
// 調整ポイントの値を変更します
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


結果:

![コネクタ調整-1](connector-adjusted-1.png)

個々のパーツの座標と形状を求めるモデルを作成するために、`connector.getAdjustments().get_Item(0)` のポイントに対応する水平成分のシェイプを作成します。  
```java
// コネクタの垂直成分を描画します
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


結果:

![コネクタ調整-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では基本原則を使った単純な調整操作を示しました。通常は、`connector.getRotation()`、`connector.getFrame().getFlipH()`、`connector.getFrame().getFlipV()` によって設定されるコネクタの回転と表示を考慮する必要があります。以下でその手順を示します。

まず、接続用に新しいテキストフレーム オブジェクト（**To 1**）をスライドに追加し、既存のオブジェクトに接続する新しい（緑色）コネクタを作成します。  
```java
// 新しいバインディングオブジェクトを作成します
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 新しいコネクタを作成します
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// 新しく作成したコネクタでオブジェクトを接続します
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


結果:

![コネクタ調整-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイント `connector.getAdjustments().get_Item(0)` を通過する水平成分に対応するシェイプを作成します。`connector.getRotation()`、`connector.getFrame().getFlipH()`、`connector.getFrame().getFlipV()` の値と、点 x0 を中心とした回転の座標変換式を使用します。

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

このケースではオブジェクトの回転角度は 90 度で、コネクタは垂直に表示されるため、対応するコードは次のとおりです。  
```java
// コネクタ座標を保存します
x = connector.getX();
y = connector.getY();
// 必要に応じてコネクタ座標を修正します
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// 調整ポイントの値を座標として取り込みます
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  座標を変換します（Sin(90) = 1 および Cos(90) = 0）
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 第2の調整ポイントの値を使用して水平成分の幅を決定します
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```


結果:

![コネクタ調整-4](connector-adjusted-4.png)

単純な調整と回転角度を伴う複雑な調整ポイントの計算例を示しました。ここで得た知識を活用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイント値を設定したりするモデル（またはコード）を作成できます。

## **コネクタ線の角度を求める**

1. クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. コネクタ線シェイプにアクセスします。  
1. 線の幅・高さ、シェイプフレームの幅・高さを使用して角度を計算します。  

この Java コードは、コネクタ線シェイプの角度を計算する操作を示しています。  
```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```
  
```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```


## **FAQ**

**コネクタが特定のシェイプに「貼り付け」可能かどうかはどう確認できますか？**  

シェイプが [connection sites](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--) を公開しているか確認してください。サイトがない、またはカウントが 0 の場合は貼り付けは利用できません。その場合は自由端点を使用し、手動で位置を設定します。接続前にサイト数をチェックするのが賢明です。

**接続されたシェイプの一方を削除した場合、コネクタはどうなりますか？**  

端点が切り離され、コネクタは自由な開始/終了点を持つ普通の線としてスライド上に残ります。削除するか、接続を再割り当てして必要に応じて [reroute](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/#reroute--) してください。

**スライドを別のプレゼンテーションにコピーしたとき、コネクタの結合は保持されますか？**  

通常は保持されますが、対象シェイプも一緒にコピーされていることが前提です。接続されたシェイプなしでスライドを別ファイルに挿入した場合、端点は自由になり、再度接続し直す必要があります。