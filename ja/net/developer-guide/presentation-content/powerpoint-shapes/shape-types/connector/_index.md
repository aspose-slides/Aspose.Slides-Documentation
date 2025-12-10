---
title: .NET のプレゼンテーションでコネクタを管理する
linktitle: コネクタ
type: docs
weight: 10
url: /ja/net/connector/
keywords:
- コネクタ
- コネクタの種類
- コネクタポイント
- コネクタライン
- コネクタ角度
- 図形を接続
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET アプリが PowerPoint スライド上で線を描画し、接続し、自動ルーティングできるようにし、直線、エルボー、曲線コネクタを完全に制御できるようにします。"
---

PowerPoint のコネクタは、2 つの図形を接続またはリンクする特別な線で、スライド上で図形が移動または再配置されても図形に付着したままです。

コネクタは通常、*接続点*（緑の点）に接続されます。接続点はすべての図形に既定で存在し、カーソルが近づくと表示されます。

*調整ポイント*（橙色の点）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（折れ線）、曲線のコネクタを使用できます。

Aspose.Slides は以下のコネクタを提供します。

| コネクタ | 画像 | 調整ポイント数 |
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

## **コネクタで図形を接続**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes` オブジェクトが提供する `AddAutoShape` メソッドを使って、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。
1. `Shapes` オブジェクトが提供する `AddConnector` メソッドでコネクタの種類を指定して追加します。
1. コネクタを使用して図形同士を接続します。
1. `Reroute` メソッドを呼び出して、最短の接続経路を適用します。
1. プレゼンテーションを保存します。

この C# コードは、2 つの図形（楕円と矩形）の間にベンドコネクタを追加する方法を示しています。
```c#
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
using (Presentation input = new Presentation())
{                
    // 特定のスライドのシェイプコレクションにアクセスします
    IShapeCollection shapes = input.Slides[0].Shapes;

    // 楕円オートシェイプを追加します
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 矩形オートシェイプを追加します
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // スライドのシェイプコレクションにコネクタシェイプを追加します
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // コネクタを使用してシェイプを接続します
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // シェイプ間の自動最短経路を設定する reroute を呼び出します
    connector.Reroute();

    // プレゼンテーションを保存します
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.Reroute` メソッドはコネクタの経路を再計算し、図形間の最短経路を強制します。目的を達成するために、`StartShapeConnectionSiteIndex` と `EndShapeConnectionSiteIndex` のポイントが変更されることがあります。 
{{% /alert %}} 

## **接続点を指定**

コネクタを特定の図形上の点で接続したい場合は、以下の手順で希望する接続点を指定します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes` オブジェクトが提供する `AddAutoShape` メソッドを使って、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。
1. `Shapes` オブジェクトが提供する `AddConnector` メソッドでコネクタの種類を指定して追加します。
1. コネクタを使用して図形同士を接続します。
1. 図形上の希望する接続点を設定します。
1. プレゼンテーションを保存します。

この C# コードは、接続点を指定した操作例を示しています。
```c#
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 特定のスライドのシェイプコレクションにアクセスします
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // スライドのシェイプコレクションにコネクタシェイプを追加します
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // 楕円のオートシェイプを追加します
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 矩形のオートシェイプを追加します
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // コネクタを使用してシェイプを接続します
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 楕円シェイプの希望接続ドットインデックスを設定します
    uint wantedIndex = 6;

    // 希望インデックスが最大サイトインデックス数未満かどうかを確認します
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // 楕円オートシェイプに希望接続ドットを設定します
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // プレゼンテーションを保存します
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **コネクタポイントの調整**

既存のコネクタは調整ポイントを使って変更できます。調整ポイントを持つコネクタだけがこの方法で変更可能です。**[コネクタの種類](/slides/ja/net/connector/#types-of-connectors)** の表をご参照ください。

### **シンプルなケース**

2 つの図形 (A と B) を結ぶコネクタが、3 番目の図形 (C) を通過するケースを考えてみます。

![コネクタ遮蔽](connector-obstruction.png)

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


3 番目の図形を回避または迂回するために、コネクタの垂直線を左側に移動して調整できます。

![コネクタ遮蔽修正](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **複雑なケース** 

より高度な調整を行うには、以下の点に留意する必要があります。

* コネクタの調整ポイントは、位置を算出する数式と強く結びついています。そのため、ポイントの位置を変更するとコネクタの形状が変わることがあります。
* 調整ポイントは配列内で厳密な順序で定義されます。開始点から終了点へ向かって番号が付けられます。
* 調整ポイントの値は、コネクタ形状の幅・高さに対するパーセンテージで表されます。  
  * 形状はコネクタの開始点と終了点を 1000 倍した範囲で制限されます。  
  * 第 1 ポイント、第 2 ポイント、第 3 ポイントはそれぞれ幅のパーセンテージ、高さのパーセンテージ、再び幅のパーセンテージを示します。
* 調整ポイントの座標を算出する際は、コネクタの回転と鏡像も考慮する必要があります。**注**：**[コネクタの種類](/slides/ja/net/connector/#types-of-connectors)** に示されたすべてのコネクタの回転角は 0 です。

#### **ケース 1**

2 つのテキストフレームオブジェクトがコネクタで結び付けられているケースを考えます。

![コネクタ形状複合](connector-shape-complex.png)

コード:
```c#
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation();
// プレゼンテーションの最初のスライドを取得します
ISlide sld = pres.Slides[0];
// コネクタで結合される形状を追加します
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

// コネクタで形状同士をリンクします
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// コネクタの調整ポイントを取得します
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**調整**

対応する幅と高さのパーセンテージをそれぞれ 20% と 200% 増加させて、コネクタの調整ポイント値を変更できます。

```c#
// 調整ポイントの値を変更します
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


結果:

![コネクタ調整-1](connector-adjusted-1.png)

コネクタの個別パーツの座標と形状を決定できるモデルを作成するために、`connector.Adjustments[0]` ポイントに対応する水平成分の形状を作成します。

```c#
// コネクタの垂直成分を描画します

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


結果:

![コネクタ調整-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では、基本原理を用いたシンプルな調整操作を示しました。通常の状況では、`connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` が設定するコネクタの回転と表示を考慮する必要があります。以下で手順を示します。

最初に、スライドに新しいテキストフレームオブジェクト (**To 1**) を追加し（接続用）、既存オブジェクトに接続する新しい（緑色の）コネクタを作成します。

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

![コネクタ調整-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイント `connector.Adjustments[0]` を通過する水平成分に対応する形状を作成します。`connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` の値を使用し、基準点 x0 周りの回転に対する座標変換式を適用します。

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

この例ではオブジェクトの回転角は 90 度で、コネクタは縦方向に表示されるため、対応するコードは以下のとおりです。

```c#
// コネクタの座標を保存します
x = connector.X;
y = connector.Y;
// コネクタの座標がずれている場合に修正します
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// 調整ポイントの値を座標として使用します
x += connector.Width * adjValue_0.RawValue / 100000;
//  座標を変換します（Sin(90)=1、Cos(90)=0 のため）
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// 第2の調整ポイントの値を使用して水平成分の幅を決定します
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```


結果:

![コネクタ調整-4](connector-adjusted-4.png)

シンプルな調整と回転角を伴う複雑な調整ポイントの計算を示しました。取得した知識を活用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイント値を設定したりするモデルやコードを作成できます。

## **コネクタ線の角度を求める**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. コネクタの線形状にアクセスします。
1. 線の幅・高さ、図形フレームの幅・高さを使用して角度を計算します。

この C# コードは、コネクタ線形状の角度を計算する操作例です。
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

**コネクタが特定の図形に「貼り付け」できるかどうかは、どう判断すればよいですか？**

その図形が [connection sites](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/) を公開しているか確認してください。存在しない、または数が 0 の場合は貼り付けは利用できません。その場合は自由端点を使用し、手動で位置を設定します。接続前にサイト数を確認するのが賢明です。

**接続されている図形の一方を削除した場合、コネクタはどうなりますか？**

端点が切り離され、コネクタは普通の線としてスライド上に残ります（開始/終了が自由になります）。削除するか、接続先を再設定し、必要に応じて [reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/) してください。

**スライドを別のプレゼンテーションにコピーしたとき、コネクタのバインディングは保持されますか？**

通常は保持されますが、対象の図形も一緒にコピーされている必要があります。接続された図形がコピーされていない場合、端点は自由になり、再度接続し直す必要があります。