---
title: コネクタ
type: docs
weight: 10
url: /ja/net/connector/
keywords: "図形を接続, コネクタ, PowerPoint 図形, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint 図形を接続する"
---

PowerPoint コネクタは、2 つの図形を接続またはリンクする特別な線であり、与えられたスライド上で図形が移動または再配置されても、図形に付随します。

コネクタは通常、すべての図形にデフォルトで存在する *接続点* (緑の点) に接続されています。接続点はカーソルが近づくと表示されます。

*調整ポイント* (オレンジの点) は特定のコネクタのみに存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPoint では、直線、肘 (角度あり)、および曲線コネクタを使用できます。

Aspose.Slides では、これらのコネクタを提供します：

| コネクタ                        | 画像                                                          | 調整ポイントの数 |
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

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. `Shapes` オブジェクトが公開する `AddAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。
1. コネクタの種類を定義することで、`Shapes` オブジェクトが公開する `AddConnector` メソッドを使用してコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. `Reroute` メソッドを呼び出し、最短接続パスを適用します。
1. プレゼンテーションを保存します。

この C# コードは、2 つの図形 (楕円と長方形) の間にコネクタ (曲がったコネクタ) を追加する方法を示しています：

```c#
// PPTX ファイルを表すプレゼンテーションクラスをインスタンス化
using (Presentation input = new Presentation())
{                
    // 特定のスライドの図形コレクションにアクセス
    IShapeCollection shapes = input.Slides[0].Shapes;

    // 楕円の自動図形を追加
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 長方形の自動図形を追加
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // スライドの図形コレクションにコネクタ形状を追加
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // コネクタを使用して図形を接続
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 自動的に図形間の最短パスを設定する reroute を呼び出す
    connector.Reroute();

    // プレゼンテーションを保存
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="注意"  color="warning"   %}} 

`Connector.Reroute` メソッドはコネクタを再経路化し、図形間の最短パスを取るように強制します。その目的を達成するために、メソッドは `StartShapeConnectionSiteIndex` および `EndShapeConnectionSiteIndex` ポイントを変更する可能性があります。 

{{% /alert %}} 

## **接続点の指定**
図形の特定の点を使用して 2 つの図形をリンクするコネクタを望む場合、次の方法で希望の接続点を指定する必要があります：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. `Shapes` オブジェクトが公開する `AddAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。
1. コネクタの種類を定義することで、`Shapes` オブジェクトが公開する `AddConnector` メソッドを使用してコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. 図形上の希望の接続点を設定します。 
1. プレゼンテーションを保存します。

この C# コードは、希望の接続点が指定されている操作を示します：

```c#
// PPTX ファイルを表すプレゼンテーションクラスをインスタンス化
using (Presentation presentation = new Presentation())
{
    // 特定のスライドの図形コレクションにアクセス
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // スライドの図形コレクションにコネクタ形状を追加
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // 楕円の自動図形を追加
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 長方形の自動図形を追加
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // コネクタを使用して図形を接続
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 楕円形状の希望の接続点インデックスを設定
    uint wantedIndex = 6;

    // 希望のインデックスが最大サイトインデックスカウントより小さいかどうかをチェック
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // 楕円の自動図形に希望の接続点を設定
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // プレゼンテーションを保存
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **コネクタポイントの調整**

既存のコネクタは、その調整ポイントを通じて調整できます。調整ポイントがあるコネクタのみ、この方法で変更できます。 **[コネクタの種類](/slides/ja/net/connector/#types-of-connectors)** の下の表を参照してください。

#### **単純なケース**

2 つの図形 (A と B) の間にコネクタがあり、3 番目の図形 (C) を通過する場合を考慮してください：

![connector-obstruction](connector-obstruction.png)

コード：

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

3 番目の図形を避けたりバイパスしたりするには、次の方法でコネクタを調整し、垂直線を左に移動できます：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **複雑なケース** 

より複雑な調整を行うには、次のことに注意する必要があります：

* コネクタの調整ポイントは、その位置を計算し決定する数式に強くリンクされています。したがって、ポイントの位置に対する変更は、コネクタの形状を変更する可能性があります。
* コネクタの調整ポイントは、厳格な順序で配列に定義されています。調整ポイントは、コネクタの開始点から終了点まで番号付けされています。
* 調整ポイントの値は、コネクタ形状の幅/高さのパーセンテージを反映します。 
  * 形状はコネクタの開始点と終了点を 1000 倍したもので制約されます。 
  * 最初のポイント、2 番目のポイント、および 3 番目のポイントは、それぞれ幅のパーセンテージ、高さのパーセンテージ、および幅のパーセンテージ (再度) を定義します。
* コネクタの調整ポイントの座標を決定する計算には、コネクタの回転とその反転を考慮する必要があります。 **注意**： **[コネクタの種類](/slides/ja/net/connector/#types-of-connectors)** の下に示されたすべてのコネクタの回転角度は 0 です。

#### **ケース 1**

2 つのテキストフレームオブジェクトがコネクタを介して接続されているケースを考えます：

![connector-shape-complex](connector-shape-complex.png)

コード：

```c#
// PPTX ファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation();
// プレゼンテーションの最初のスライドを取得
ISlide sld = pres.Slides[0];
// コネクタを介して結合される図形を追加
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// コネクタを追加
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// コネクタの方向を指定
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// コネクタの色を指定
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// コネクタの線の太さを指定
connector.LineFormat.Width = 3;

// コネクタで図形をリンク
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// コネクタの調整ポイントを取得
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**調整**

コネクタの調整ポイントの値を、それぞれ幅と高さのパーセンテージを 20% と 200% 増加させることによって変更できます：

```c#
// 調整ポイントの値を変更
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの調整ポイントの座標と形状を決定するモデルを定義するために、コネクタ.Adjustments[0] ポイントでコネクタの水平コンポーネントに対応する形状を作成しましょう：

```c#
// コネクタの垂直コンポーネントを描画

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では、基本的な原則を使用して単純なコネクタ調整操作を示しました。通常の状況では、コネクタの回転とその表示 (コネクタ.Rotation、connector.Frame.FlipH、および connector.Frame.FlipV によって設定された) を考慮する必要があります。これを示すプロセスを示します。

最初に、接続目的でスライドに新しいテキストフレームオブジェクト (To 1) を追加し、それを既に作成したオブジェクトに接続する新しい (緑の) コネクタを作成します。

```c#
// 新しいバインディングオブジェクトを作成
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// 新しいコネクタを作成
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// 新しく作成したコネクタを使用してオブジェクトを接続
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// コネクタの調整ポイントを取得
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// 調整ポイントの値を変更 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

結果：

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイント connector.Adjustments[0] を通過するコネクタの水平コンポーネントに対応する形状を作成します。コネクタのデータからの値を使用して、コネクタ.Rotation、connector.Frame.FlipH、および connector.Frame.FlipV の値を取得し、次の円周率座標変換公式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

この場合、オブジェクトの回転角度は 90 度であり、コネクタは垂直に表示されるため、次のコードになります：

```c#
// コネクタの座標を保存
x = connector.X;
y = connector.Y;
// コネクタの座標を修正
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// 調整ポイントの値を座標として取り込む
x += connector.Width * adjValue_0.RawValue / 100000;
// 座標を変換 (Sin(90) = 1 および Cos(90) = 0)
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// 2 番目の調整ポイント値を使用して水平コンポーネントの幅を決定する
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

単純な調整と複雑な調整ポイント (回転角度を持つ調整ポイント) に関する計算を示しました。習得した知識を使用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイントの値を設定したりするモデルを開発できます。

## **コネクタ線の角度を見つける**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. コネクタ線形状にアクセスします。 
1. 線の幅、高さ、形状フレームの高さ、および形状フレームの幅を使用して角度を計算します。

この C# コードは、コネクタ線形状の角度を計算する操作を示しています：

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```