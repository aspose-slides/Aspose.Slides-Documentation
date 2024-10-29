---
title: コネクタ
type: docs
weight: 10
url: /ja/java/connector/
keywords: "図形を接続, コネクタ, PowerPoint図形, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPoint図形を接続する"
---

PowerPointのコネクタは、2つの図形をつなげ、指定されたスライド上で移動または再配置されても図形に付着している特別な線です。

コネクタは通常、すべての図形にデフォルトで存在する*接続ポイント*（緑の点）に接続されています。カーソルが接続ポイントに近づくと、接続ポイントが表示されます。

特定のコネクタにのみ存在する*調整ポイント*（オレンジの点）は、コネクタの位置や形を変更するために使用されます。

## **コネクタの種類**

PowerPointでは、直線、肘（角度付き）、および曲線コネクタを使用できます。

Aspose.Slidesでは、これらのコネクタを提供しています：

| コネクタ                          | 画像                                                          | 調整ポイントの数 |
| ------------------------------ | ------------------------------------------------------------ | ----------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                 |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                 |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                 |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                 |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                 |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                 |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                 |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                 |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                 |

## **コネクタを使用して図形を接続する**

1. [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを指定してスライドへの参照を取得します。
1. `Shapes`オブジェクトが公開する`addAutoShape`メソッドを使用して、スライドに2つの[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape)を追加します。
1. コネクタタイプを定義して、`Shapes`オブジェクトが公開する`addConnector`メソッドを使用してコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. `reroute`メソッドを呼び出して、最短の接続パスを適用します。
1. プレゼンテーションを保存します。

このJavaコードは、2つの図形（楕円と長方形）の間にコネクタ（屈曲コネクタ）を追加する方法を示しています：

```Java
// PPTXファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 特定のスライドの図形コレクションにアクセス
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // 楕円オートシェイプを追加
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // 長方形オートシェイプを追加
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // スライドの図形コレクションにコネクタシェイプを追加
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // コネクタを使用して図形を接続
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // 図形間の自動的な最短パスを設定するrerouteを呼び出す
    connector.reroute();
    
    // プレゼンテーションを保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="注意"  color="warning"   %}} 

`Connector.reroute`メソッドは、コネクタを再ルートし、図形間で可能な限り最短の経路を取るように強制します。目的を達成するために、メソッドは`setStartShapeConnectionSiteIndex`および`setEndShapeConnectionSiteIndex`ポイントを変更する場合があります。 

{{% /alert %}} 

## **接続ポイントの指定**

特定の図形の接続ポイントを使用してコネクタが2つの図形をリンクするようにするためには、次のように好みの接続ポイントを指定する必要があります：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを指定してスライドへの参照を取得します。
1. `Shapes`オブジェクトが公開する`addAutoShape`メソッドを使用して、スライドに2つの[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape)を追加します。
1. コネクタタイプを定義して、`Shapes`オブジェクトが公開する`addConnector`メソッドを使用してコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. 図形上の好みの接続ポイントを設定します。 
1. プレゼンテーションを保存します。

このJavaコードは、好みの接続ポイントが指定された操作を示しています：

```java
// PPTXファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 特定のスライドの図形コレクションにアクセス
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // 楕円オートシェイプを追加
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 長方形オートシェイプを追加
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // スライドの図形コレクションにコネクタシェイプを追加
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // コネクタを使用して図形を接続
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // 楕円形の接続ポイントのインデックスを指定
    int wantedIndex = 6;

    // 指定したインデックスが最大サイトインデックス数より小さいかチェック
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // 楕円オートシェイプの好みの接続ポイントを設定
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // プレゼンテーションを保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **コネクタポイントの調整**

既存のコネクタは、その調整ポイントを介して調整できます。調整ポイントを持つコネクタのみ、このように変更できます。**[コネクタの種類](/slides/ja/java/connector/#types-of-connectors)**の下の表を参照してください。

#### **単純なケース**

2つの図形（AとB）間のコネクタが、3つ目の図形（C）を通過している場合を考えてみましょう：

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

3つ目の図形を避けるために、コネクタの垂直線を左に移動して調整します：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **複雑なケース** 

より複雑な調整を行うには、次のことを考慮する必要があります：

* コネクタの調整ポイントは、その位置を計算し決定する式に強くリンクされています。したがって、ポイントの位置を変更すると、コネクタの形も変わる可能性があります。
* コネクタの調整ポイントは、配列で厳密に順序定義されています。調整ポイントはコネクタの開始点から終了点にかけて番号が付けられています。
* 調整ポイントの値は、コネクタ形状の幅/高さのパーセンテージを反映しています。
  * 形状は、コネクタの開始点と終了点で制約されています。
  * 最初のポイント、2番目のポイント、および3番目のポイントは、それぞれ幅からのパーセンテージ、高さからのパーセンテージ、および再度幅からのパーセンテージを定義します。
* コネクタの調整ポイントの座標を決定する計算には、コネクタの回転とその反射を考慮する必要があります。**注意**：**[コネクタの種類](/slides/ja/java/connector/#types-of-connectors)**の下に示されているすべてのコネクタの回転角度は0です。

#### **ケース1**

コネクタを介して2つのテキストフレームオブジェクトが接続されているケースを考えます：

![connector-shape-complex](connector-shape-complex.png)

```java
// PPTXファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    // コネクタを介して結合される図形を追加
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // コネクタを追加
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // コネクタの方向を指定
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // コネクタの色を指定
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // コネクタの線の太さを指定
    connector.getLineFormat().setWidth(3);
    
    // コネクタで図形を結合
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // コネクタの調整ポイントを取得
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**調整**

コネクタの調整ポイントの値を、幅と高さのパーセンテージをそれぞれ20%と200%増加させて変更できます：

```java
// 調整ポイントの値を変更
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの個々の部分の座標と形状を決定するモデルを定義するために、connector.getAdjustments().get_Item(0)ポイントでのコネクタの水平成分に対応する形状を作成しましょう：

```java
// コネクタの垂直コンポーネントを描画
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース2**

**ケース1**では、基本的な原則を使用した単純なコネクタ調整操作を示しました。通常の状況では、コネクタの回転とその表示（これらはconnector.getRotation()、connector.getFrame().getFlipH()、およびconnector.getFrame().getFlipV()で設定されます）を考慮する必要があります。今、プロセスを示します。

まず、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し、既存のオブジェクトと接続する新しい（緑色の）コネクタを作成します。

```java
// 新しいバインディングオブジェクトを作成
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 新しいコネクタを作成
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// 新しく作成したコネクタを使用してオブジェクトを接続
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// コネクタの調整ポイントを取得
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 調整ポイントの値を変更
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

結果：

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイントconnector.getAdjustments().get_Item(0)を通過するコネクタの水平コンポーネントに対応する形状を作成します。コネクタデータからconnector.getRotation()、connector.getFrame().getFlipH()、およびconnector.getFrame().getFlipV()の値を使用し、特定の座標の人気のある変換式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

この場合、オブジェクトの回転角は90度であり、コネクタは垂直に表示されるため、以下のコードになります：

```java
// コネクタの座標を保存
x = connector.getX();
y = connector.getY();
// コネクタが表示される場合、コネクタの座標を補正
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// 調整ポイントの値を座標として取得
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
// 角度回転の座標を変換（Sin(90) = 1 および Cos(90) = 0）
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 水平コンポーネントの幅を2番目の調整ポイントの値を使用して決定
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

単純な調整と複雑な調整ポイント（回転角度を持つ調整ポイント）を伴う計算を示しました。習得した知識を使用して、`GraphicsPath`オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイントの値を設定するモデル（またはコード）を開発できます。

## **コネクタ線の角度を見つける**

1. クラスのインスタンスを作成します。
1. インデックスを指定してスライドへの参照を取得します。
1. コネクタ線シェイプにアクセスします。
1. 線の幅、高さ、シェイプフレームの高さ、幅を使用して角度を計算します。

このJavaコードは、コネクタ線シェイプの角度を計算した操作を示しています：

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