---
title: Java を使用したプレゼンテーションでのコネクタ管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/java/connector/
keywords:
- コネクタ
- コネクタ タイプ
- コネクタ ポイント
- コネクタ ライン
- コネクタ 角度
- 図形接続
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java アプリで PowerPoint スライド上に線を描画し、接続し、自動ルーティングできるようにし、直線、エルボー、曲線コネクタを完全に制御します。"
---

PowerPoint コネクタは、2 つの図形を接続またはリンクする特殊な線で、スライド上で図形を移動または再配置しても図形に貼り付いたままになります。

コネクタは通常、*接続点*（緑のドット）に接続されます。接続点はすべての図形にデフォルトで存在し、カーソルが近づくと表示されます。

*調整点*（オレンジのドット）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（角付き）、曲線コネクタを使用できます。

Aspose.Slides が提供するこれらのコネクタは次のとおりです。

| Connector                      | Image                                                        | Number of adjustment points |
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

## **コネクタで図形を接続する**

1. [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. `Shapes` オブジェクトが公開する `addAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) を追加します。  
1. `Shapes` オブジェクトが公開する `addConnector` メソッドでコネクタの種類を指定してコネクタを追加します。  
1. コネクタを使用して図形を接続します。  
1. `reroute` メソッドを呼び出して最短接続パスを適用します。  
1. プレゼンテーションを保存します。  

この Java コードは、2 つの図形（楕円と矩形）の間にベンドコネクタを追加する方法を示しています。  
```Java
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 特定のスライドのシェイプ コレクションにアクセスします
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // 楕円のオートシェイプを追加します
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // 矩形のオートシェイプを追加します
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // スライドのシェイプ コレクションにコネクタ シェイプを追加します
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // コネクタを使用してシェイプを接続します
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // シェイプ間の自動最短パスを設定する reroute を呼び出します
    connector.reroute();
    
    // プレゼンテーションを保存します
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.reroute` メソッドはコネクタを再ルーティングし、図形間で可能な限り最短のパスを取らせます。そのために `setStartShapeConnectionSiteIndex` と `setEndShapeConnectionSiteIndex` のポイントが変更されることがあります。 

{{% /alert %}} 

## **接続点を指定する**

特定の図形上の点でコネクタを接続したい場合は、以下の手順で希望の接続点を指定します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. `Shapes` オブジェクトが公開する `addAutoShape` メソッドでスライドに 2 つの [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) を追加します。  
1. `Shapes` オブジェクトが公開する `addConnector` メソッドでコネクタの種類を指定してコネクタを追加します。  
1. コネクタで図形を接続します。  
1. 図形上の希望する接続点を設定します。  
1. プレゼンテーションを保存します。  

この Java コードは、接続点を指定した操作例を示しています。  
```java
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 特定のスライドのシェイプ コレクションにアクセスします
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // 楕円のオートシェイプを追加します
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 矩形のオートシェイプを追加します
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // スライドのシェイプ コレクションにコネクタ シェイプを追加します
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // コネクタを使用してシェイプを接続します
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // 楕円シェイプの希望接続ドットインデックスを設定します
    int wantedIndex = 6;

    // 希望インデックスが最大サイトインデックス数未満か確認します
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // 楕円オートシェイプに希望接続ドットを設定します
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // プレゼンテーションを保存します
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **コネクタのポイントを調整する**

調整点を持つコネクタは、調整点を操作することで変更できます。**[コネクタの種類](/slides/ja/java/connector/#types-of-connectors)** の表を参照してください。

### **単純なケース**

2 つの図形 (A と B) の間のコネクタが 3 番目の図形 (C) を通過する場合を考えます。

![connector-obstruction](connector-obstruction.png)
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


3 番目の図形を回避するために、垂直線を左側に移動してコネクタを調整できます。

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **複雑なケース** 

より複雑な調整を行う場合は、以下の点に留意してください。

* コネクタの調整可能点は、その位置を計算する数式に強く結び付いています。点の位置を変更するとコネクタの形状が変わることがあります。  
* 調整点は配列内で厳密な順序で定義されており、コネクタの開始点から終了点へ向かって番号付けされています。  
* 調整点の値はコネクタ形状の幅/高さのパーセンテージを表します。  
  * 図形はコネクタの開始点と終了点に 1000 を掛けた範囲で制限されます。  
  * 第1点は幅のパーセンテージ、第2点は高さのパーセンテージ、第3点は再び幅のパーセンテージを表します。  
* 調整点の座標を算出する計算では、コネクタの回転と反転を考慮する必要があります。**注**：**[コネクタの種類](/slides/ja/java/connector/#types-of-connectors)** に示されたすべてのコネクタの回転角は 0 です。

#### **ケース 1**

2 つのテキストフレームオブジェクトがコネクタでリンクされているケースを考えます。

![connector-shape-complex](connector-shape-complex.png)
```java
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    // コネクタで結合される形状を追加します
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
    
    // コネクタで形状を結びつけます
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // コネクタの調整点を取得します
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```


**調整**

幅と高さのパーセンテージをそれぞれ 20% と 200% 増加させて、コネクタの調整点の値を変更できます。  
```java
// 調整点の値を変更します
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


結果:

![connector-adjusted-1](connector-adjusted-1.png)

個々のパーツの座標と形状を決定できるモデルを作成するために、`connector.getAdjustments().get_Item(0)` の点に対応する水平コンポーネントの形状を作成します。  
```java
// コネクタの垂直成分を描画します
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


結果:

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では基本原則を用いた単純なコネクタ調整操作を示しました。通常の状況では、`connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()` で設定されるコネクタの回転と表示を考慮する必要があります。以下にその手順を示します。

まず、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し、既存のオブジェクトに接続する新しい（緑色の）コネクタを作成します。  
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
// 新しく作成したコネクタを使用してオブジェクトを接続します
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// コネクタの調整点を取得します
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 調整点の値を変更します
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


結果:

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整点 `connector.getAdjustments().get_Item(0)` を通過する水平コンポーネントに対応する図形を作成します。回転角 `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()` の値を使用し、点 x0 周りの回転の座標変換式を適用します。

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

このケースではオブジェクトの回転角は 90 度で、コネクタは垂直に表示されるため、対応するコードは次のとおりです。  
```java
// コネクタの座標を保存します
x = connector.getX();
y = connector.getY();
// コネクタが反転している場合に座標を修正します
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// 調整点の値を座標として使用します
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  座標を変換します（Sin(90)=1 および Cos(90)=0）
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 第2調整点の値を使用して水平成分の幅を決定します
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```


結果:

![connector-adjusted-4](connector-adjusted-4.png)

単純な調整と回転角を伴う複雑な調整点の計算を示しました。この知識を活用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整点の値を設定したりするモデル（またはコード）を作成できます。

## **コネクタ線の角度を求める**

1. クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. コネクタ線の形状にアクセスします。  
1. 線の幅・高さ、図形フレームの幅・高さを使用して角度を計算します。  

この Java コードは、コネクタ線形状の角度を計算する操作例を示しています。  
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

**コネクタが特定の図形に「貼り付け」可能かどうかはどう確認できますか？**

図形が [connection sites](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getConnectionSiteCount--) を公開しているか確認してください。存在しない、またはカウントが 0 の場合は貼り付けは使用できません。その場合は自由端点を使用し、手動で位置を設定します。接続前にサイト数を確認するとよいでしょう。

**接続されている図形の一方を削除した場合、コネクタはどうなりますか？**

コネクタの端は切り離され、スライド上に普通の線として残ります（開始/終了が自由端点になります）。削除するか、接続を再割り当てし、必要に応じて [reroute](https://reference.aspose.com/slides/java/com.aspose.slides/connector/#reroute--) してください。

**スライドを別のプレゼンテーションにコピーしたとき、コネクタのバインディングは保持されますか？**

一般的に、対象の図形も同時にコピーすれば保持されます。接続された図形がコピー先に存在しない場合、端は自由端点となり、再度接続し直す必要があります。