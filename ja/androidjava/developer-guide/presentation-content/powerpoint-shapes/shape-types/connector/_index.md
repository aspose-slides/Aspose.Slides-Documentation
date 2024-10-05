---
title: コネクタ
type: docs
weight: 10
url: /androidjava/connector/
keywords: "図形を接続、コネクタ、PowerPoint 図形、PowerPoint プレゼンテーション、Java、Aspose.Slides for Android via Java"
description: "JavaでPowerPoint図形を接続する"
---

PowerPointのコネクタは、2つの図形を接続またはリンクする特別なラインであり、与えられたスライド上で移動または再配置されても図形に付随しています。

コネクタは通常、すべての図形にデフォルトで存在する*接続ポイント*（緑の点）に接続されます。カーソルが近づくと接続点が表示されます。

*調整ポイント*（オレンジの点）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPointでは、ストレート、肘（角度付き）、および曲線のコネクタを使用できます。

Aspose.Slidesは次のコネクタを提供します：

| コネクタ                          | 画像                                                          | 調整ポイント数          |
| --------------------------------- | ------------------------------------------------------------ | ----------------------- |
| `ShapeType.Line`                  | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                       |
| `ShapeType.StraightConnector1`    | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                       |
| `ShapeType.BentConnector2`        | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                       |
| `ShapeType.BentConnector3`        | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                       |
| `ShapeType.BentConnector4`        | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                       |
| `ShapeType.BentConnector5`        | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                       |
| `ShapeType.CurvedConnector2`      | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                       |
| `ShapeType.CurvedConnector3`      | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                       |
| `ShapeType.CurvedConnector4`      | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                       |
| `ShapeType.CurvedConnector5`      | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                       |

## **コネクタを使用して図形を接続する**

1. [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. `Shapes`オブジェクトによって公開されている`addAutoShape`メソッドを使用して、スライドに2つの[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape)を追加します。
1. コネクタのタイプを定義して、`Shapes`オブジェクトによって公開されている`addConnector`メソッドを使用して、コネクタを追加します。
1. コネクタを使用して図形を接続します。
1. `reroute`メソッドを呼び出して、最短接続パスを適用します。
1. プレゼンテーションを保存します。

このJavaコードは、2つの図形（楕円と長方形）の間にコネクタ（曲がったコネクタ）を追加する方法を示しています：

```Java
// PPTXファイルを表すプレゼンテーションクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 特定のスライドの図形コレクションにアクセス
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // 楕円の自動図形を追加
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // 長方形の自動図形を追加
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // スライドの図形コレクションにコネクタ形状を追加
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // コネクタを使用して図形を接続
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // 図形間の自動最短パスを設定するrerouteを呼び出し
    connector.reroute();
    
    // プレゼンテーションを保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="注意" color="warning" %}} 

`Connector.reroute`メソッドはコネクタの再経路を設定し、図形間の最短経路を取らせます。その目的を達成するために、メソッドは`setStartShapeConnectionSiteIndex`および`setEndShapeConnectionSiteIndex`ポイントを変更する場合があります。 

{{% /alert %}} 

## **接続点を指定する**

特定の図形上の指定した点を使用してコネクタに2つの図形をリンクさせたい場合、次のようにして希望する接続点を指定する必要があります：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. `Shapes`オブジェクトによって公開されている`addAutoShape`メソッドを使用して、スライドに2つの[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape)を追加します。
1. コネクタのタイプを定義して、`Shapes`オブジェクトによって公開されている`addConnector`メソッドを使用してコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. 図形上の希望する接続点を設定します。
1. プレゼンテーションを保存します。

このJavaコードは、指定された接続点を使用した操作を示しています：

```java
// PPTXファイルを表すプレゼンテーションクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 特定のスライドの図形コレクションにアクセス
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // 楕円の自動図形を追加
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 長方形の自動図形を追加
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // スライドの図形コレクションにコネクタ形状を追加
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // コネクタを使用して図形を接続
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // 楕円形状で希望する接続点インデックスを設定
    int wantedIndex = 6;

    // 希望するインデックスが最大サイトインデックスカウント未満か確認
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // 楕円の自動図形で希望する接続点を設定
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // プレゼンテーションを保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **コネクタポイントの調整**

既存のコネクタは、その調整ポイントを通じて調整できます。調整ポイントを持つコネクタのみがこの方法で変更可能です。詳細は **[コネクタの種類](/slides/androidjava/connector/#types-of-connectors)** の下の表を参照してください。

#### **簡単なケース**

2つの図形（A と B）の間のコネクタが3つ目の図形（C）を通過する場合を考えます：

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

3番目の形状を回避またはバイパスするために、次のようにしてコネクタの垂直ラインを左に移動させることで調整できます：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **複雑なケース** 

より複雑な調整を行うには、次の点に注意する必要があります：

* コネクタの調整ポイントは、その位置を計算し決定する数式に強くリンクされています。そのため、ポイントの位置の変更はコネクタの形状に影響を与える可能性があります。
* コネクタの調整ポイントは、配列で厳密な順序で定義されています。調整ポイントはコネクタの始点から終点にかけて番号付けされています。
* 調整ポイントの値は、コネクタの形状の幅/高さのパーセンテージを反映します。 
  * 形状はコネクタの開始点と終了点によって1000倍されます。 
  * 最初のポイント、2番目のポイント、3番目のポイントはそれぞれ幅からのパーセンテージ、高さからのパーセンテージ、再度幅からのパーセンテージを定義します。
* コネクタの調整ポイントの座標を決定する計算では、コネクタの回転や反射を考慮する必要があります。 **注意**してください、**[コネクタの種類](/slides/androidjava/connector/#types-of-connectors)** に示されるすべてのコネクタの回転角度は0です。

#### **ケース 1**

テキストフレームオブジェクト2つがコネクタを介して接続されているケースを考えます：

![connector-shape-complex](connector-shape-complex.png)

```java
// PPTXファイルを表すプレゼンテーションクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // プレゼンテーション内の最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    // コネクタを介して一緒に接続される図形を追加
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
    
    // コネクタで図形を接続
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

コネクタの調整ポイント値を、幅と高さのパーセンテージをそれぞれ20%と200%増加させることで変更できます：

```java
// 調整ポイントの値を変更
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの水平コンポーネントに対応する形状を作成するため、connector.getAdjustments().get_Item(0)ポイントでコネクタの座標と形状を決定するモデルを作成します：

```java
// コネクタの垂直コンポーネントを描画
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では、基本的な原則を使用して単純なコネクタ調整操作を示しました。通常の状況では、コネクタの回転および表示（これはconnector.getRotation()、connector.getFrame().getFlipH()、およびconnector.getFrame().getFlipV()によって設定されます）を考慮する必要があります。これを示すプロセスを行います。

まず、接続目的でスライドに新しいテキストフレームオブジェクト（**To 1**）を追加し、それを既に作成したオブジェクトに接続する新しい（緑色の）コネクタを作成します。

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

次に、新しいコネクタの調整ポイントconnector.getAdjustments().get_Item(0)を通過するコネクタに対応する形状を作成します。コネクタデータからのconnector.getRotation()、connector.getFrame().getFlipH()およびconnector.getFrame().getFlipV()の値を使用し、特定の点を回転させるための一般的な座標変換の公式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

この場合、オブジェクトの回転角度は90度で、コネクタは垂直に表示されます。したがって、次のコードになります：

```java
// コネクタの座標を保存
x = connector.getX();
y = connector.getY();
// コネクタの座標を修正（コネクタが表示される場合）
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
// Sin(90) = 1、Cos(90) = 0に基づいて座標を変換
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 2番目の調整ポイントの値を使用して水平コンポーネントの幅を決定
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

単純な調整と複雑な調整ポイント（回転角度を持つ調整ポイント）を含む計算を示しました。習得した知識を使用して、特定のスライド座標に基づいてコネクタの調整ポイント値を取得する`GraphicsPath`オブジェクトを開発したり、コーディングしたりすることができます。

## **コネクタラインの角度を見つける**

1. クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. コネクタライン形状にアクセスします。
1. ラインの幅、高さ、形状のフレームの高さ、および形状のフレームの幅を使用して角度を計算します。

このJavaコードは、コネクタライン形状の角度を計算する操作を示しています：

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