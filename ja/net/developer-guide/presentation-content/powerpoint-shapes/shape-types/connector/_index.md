---
title: コネクタ
type: docs
weight: 10
url: /ja/net/connector/
keywords: "図形を接続, コネクタ, PowerPoint 図形, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint の図形を接続"
---

PowerPoint コネクタは、2 つの図形を接続またはリンクする特別な線で、スライド上で図形が移動または再配置されても図形に貼り付いたままです。

コネクタは通常、*接続点*（緑のドット）に接続されます。接続点はすべての図形にデフォルトで存在し、カーソルが近づくと表示されます。

*調整ポイント*（オレンジのドット）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（角度付き）、曲線コネクタを使用できます。

Aspose.Slides が提供するこれらのコネクタ:

| コネクタ | 画像 | 調整ポイントの数 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **コネクタで図形を接続する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. `Shapes` オブジェクトの `AddAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。  
1. `Shapes` オブジェクトの `AddConnector` メソッドでコネクタタイプを指定し、コネクタを追加します。  
1. コネクタで図形を接続します。  
1. `Reroute` メソッドを呼び出して最短接続パスを適用します。  
1. プレゼンテーションを保存します。

以下の C# コードは、2 つの図形（楕円と長方形）の間にベンドコネクタを追加する方法を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
    // 特定のスライドのシェイプ コレクションにアクセスします
    // 楕円のオートシェイプを追加します
    // 四角形のオートシェイプを追加します
    // スライドのシェイプ コレクションにコネクタ シェイプを追加します
    // コネクタを使用してシェイプを接続します
    // シェイプ間の自動最短パスを設定する reroute を呼び出します
    // プレゼンテーションを保存します
using (Presentation input = new Presentation())
{                
    IShapeCollection shapes = input.Slides[0].Shapes;
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;
    connector.Reroute();
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.Reroute` メソッドはコネクタの経路を再計算し、図形間の最短パスを強制的に取らせます。その過程で `StartShapeConnectionSiteIndex` と `EndShapeConnectionSiteIndex` が変更されることがあります。 

{{% /alert %}} 

## **接続点を指定する**
特定の接続点を使用して図形間をリンクしたい場合は、次の手順で接続点を指定します:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. `Shapes` オブジェクトの `AddAutoShape` メソッドで 2 つの [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) をスライドに追加します。  
1. `Shapes` オブジェクトの `AddConnector` メソッドでコネクタタイプを指定し、コネクタを追加します。  
1. コネクタで図形を接続します。  
1. 図形上の希望する接続点を設定します。  
1. プレゼンテーションを保存します。

以下の C# コードは、希望する接続点を指定する操作を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 特定のスライドのシェイプ コレクションにアクセスします
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // スライドのシェイプ コレクションにコネクタ シェイプを追加します
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // 楕円のオートシェイプを追加します
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 四角形のオートシェイプを追加します
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // コネクタを使用してシェイプを接続します
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 楕円シェイプの優先接続ドット インデックスを設定します
    uint wantedIndex = 6;

    // 優先インデックスが最大接続サイト数未満かを確認します
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // 楕円オートシェイプの優先接続ドットを設定します
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // プレゼンテーションを保存します
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```



## **コネクタポイントを調整する**

調整ポイントを使用して既存のコネクタを調整できます。調整ポイントを持つコネクタのみがこの方法で変更可能です。詳細は **[コネクタの種類](/slides/ja/net/connector/#types-of-connectors)** の表をご覧ください。

#### **単純なケース**

2 つの図形（A と B）の間のコネクタが 3 つ目の図形（C）を通過するケースを考えてみます:

![connector-obstruction](connector-obstruction.png)

コード:
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


3 つ目の図形を回避するため、コネクタの垂直線を左側に移動して調整できます:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **複雑なケース** 

より複雑な調整を行うには、次の点に留意してください:

* コネクタの調整ポイントは、その位置を計算する数式に強く結び付いています。ポイントの位置を変更するとコネクタの形状が変わる可能性があります。  
* 調整ポイントは配列内で厳密な順序で定義されます。開始点から終了点へ向かって番号が付けられます。  
* 調整ポイントの値はコネクタ形状の幅・高さに対するパーセンテージで表されます。  
  * 図形はコネクタの開始点と終了点に 1000 を掛けた範囲で制限されます。  
  * 第1ポイントは幅のパーセンテージ、第2ポイントは高さのパーセンテージ、第3ポイントは再び幅のパーセンテージを表します。  
* 調整ポイントの座標計算にはコネクタの回転と反転を考慮する必要があります。**注**: **[コネクタの種類](/slides/ja/net/connector/#types-of-connectors)** に示されたすべてのコネクタの回転角度は 0 です。

#### **ケース 1**

2 つのテキストフレームがコネクタでつながれているケース:

![connector-shape-complex](connector-shape-complex.png)

コード:
```c#
 // PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
 // プレゼンテーションの最初のスライドを取得します
ISlide sld = pres.Slides[0];
 // コネクタで結合される図形を追加します
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
 // コネクタを追加します
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
 // コネクタの方向を指定します
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
 // コネクタの色を指定します
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
 // コネクタの線の太さを指定します
connector.LineFormat.Width = 3;

 // コネクタで図形同士をリンクします
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

 // コネクタの調整ポイントを取得します
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**調整**

対応する幅と高さのパーセンテージをそれぞれ 20% と 200% 増やすことで、コネクタの調整ポイントの値を変更できます:
```c#
// 調整ポイントの値を変更します
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


結果:

![connector-adjusted-1](connector-adjusted-1.png)

個々のパーツの座標と形状を求めるモデルを定義するために、`connector.Adjustments[0]` の位置に対応する水平コンポーネントの図形を作成します:
```c#
 // コネクタの垂直成分を描画します

 float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
 float y = connector.Y;
 float height = connector.Height * adjValue_1.RawValue / 100000;
 sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


結果:

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では基本原則を用いた単純なコネクタ調整操作を示しました。通常状況では、コネクタの回転と表示（`connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` で設定）を考慮する必要があります。以下に手順を示します。

最初に、スライドに新しいテキストフレーム（**To 1**）を追加し、既存のオブジェクトと接続する新しい（緑色）コネクタを作成します。
```c#
 // 新しいバインディングオブジェクトを作成します
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
 // 新しいコネクタを作成します
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
 // 新しく作成したコネクタでオブジェクトを接続します
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
 // コネクタの調整ポイントを取得します
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
 // 調整ポイントの値を変更します 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


結果:

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイント `connector.Adjustments[0]` を通過する水平コンポーネントに対応する図形を作成します。`connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` の値を使用し、点 x0 周りの回転変換式を適用します:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

今回のオブジェクトの回転角は 90 度で、コネクタは垂直に表示されるため、対応するコードは次のとおりです:
```c#
 // コネクタの座標を保存します
x = connector.X;
y = connector.Y;
 // コネクタの座標が反転している場合に修正します
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
 // 調整ポイントの値を座標として取得します
x += connector.Width * adjValue_0.RawValue / 100000;
 //  Sin(90)=1、Cos(90)=0 なので座標を変換します
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
 // 第2調整ポイントの値を使用して水平成分の幅を決定します
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```


結果:

![connector-adjusted-4](connector-adjusted-4.png)

以上で、単純な調整と回転角を伴う複雑な調整ポイントの計算方法を示しました。この知識を活用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイント値を設定したりするモデルやコードを作成できます。

## **コネクタ線の角度を求める**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. コネクタ線形状にアクセスします。  
1. 線の幅・高さ、図形フレームの幅・高さを使用して角度を計算します。

以下の C# コードは、コネクタ線形状の角度を計算する操作を示しています:
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


## **FAQ**

**コネクタが特定の図形に「貼り付け」可能かどうかはどう確認できますか？**

図形が [connection sites](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/) を公開しているか確認してください。サイトがない、またはカウントが 0 の場合は貼り付けは利用できません。その場合は自由端点を使用して手動で位置を設定します。接続前にサイト数をチェックするのが賢明です。

**接続された図形の一方を削除すると、コネクタはどうなりますか？**

コネクタの端は切り離され、スライド上には自由な開始/終了点を持つ普通の線として残ります。削除するか、接続先を再割り当てし、必要に応じて [reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/) してください。

**スライドを別のプレゼンテーションにコピーすると、コネクタのバインディングは保持されますか？**

通常は保持されますが、対象の図形も同時にコピーされている必要があります。接続された図形がコピー先に存在しない場合、端は自由になり、再度接続し直す必要があります。