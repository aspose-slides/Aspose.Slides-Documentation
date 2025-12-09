---
title: .NET でのプレゼンテーションにおけるコネクタの管理
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
- 図形の接続
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET アプリに PowerPoint スライド上で線を描画、接続、そして自動経路設定できるようにし、直線、エルボー、曲線コネクタを完全に制御します。"
---

PowerPoint コネクタは、2 つの図形を接続またはリンクする特殊な線で、図形がスライド上で移動または再配置された場合でも図形に付着したままです。

コネクタは通常、*接続ドット*（緑色のドット）に接続されます。接続ドットはすべての図形にデフォルトで存在し、カーソルが近づくと表示されます。

*調整ポイント*（オレンジのドット）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（折れ線）、および曲線のコネクタを使用できます。

Aspose.Slides は以下のコネクタを提供します：

| コネクタ                      | 画像                                                        | 調整ポイント数 |
| ------------------------------ | ------------------------------------------------------------ | -------------- |
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
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes` オブジェクトが提供する `AddAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。
1. `Shapes` オブジェクトが提供する `AddConnector` メソッドを使用し、コネクタのタイプを指定してコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. 最短の接続パスを適用するために `Reroute` メソッドを呼び出します。
1. プレゼンテーションを保存します。

この C# コードは、2 つの図形（楕円と長方形）の間にコネクタ（ベンドコネクタ）を追加する方法を示しています：
```c#
    // PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成
    using (Presentation input = new Presentation())
    {                
        // 特定のスライドのシェイプ コレクションにアクセス
        IShapeCollection shapes = input.Slides[0].Shapes;

        // 楕円オートシェイプを追加
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

        // 四角形オートシェイプを追加
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

        // スライドのシェイプ コレクションにコネクタ シェイプを追加
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // コネクタを使用してシェイプを接続
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // シェイプ間の自動最短パスを設定する reroute を呼び出す
        connector.Reroute();

        // プレゼンテーションを保存
        input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
    }
```


{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.Reroute` メソッドはコネクタの経路を再設定し、図形間で可能な限り最短のパスを取るよう強制します。その目的を達成するために、メソッドは `StartShapeConnectionSiteIndex` および `EndShapeConnectionSiteIndex` のポイントを変更することがあります。 
{{% /alert %}} 

## **接続ドットの指定**

コネクタを特定のドットで図形同士に接続したい場合は、以下のように好みの接続ドットを指定します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes` オブジェクトが提供する `AddAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。
1. `Shapes` オブジェクトが提供する `AddConnector` メソッドを使用し、コネクタのタイプを指定してコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. 図形上で希望する接続ドットを設定します。
1. プレゼンテーションを保存します。

この C# コードは、好みの接続ドットを指定する操作を示しています：
```c#
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成
using (Presentation presentation = new Presentation())
{
    // 特定のスライドのシェイプ コレクションにアクセス
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // スライドのシェイプ コレクションにコネクタ シェイプを追加
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // 楕円オートシェイプを追加
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 四角形オートシェイプを追加
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // コネクタを使用してシェイプを接続
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 楕円シェイプの優先接続ドットインデックスを設定
    uint wantedIndex = 6;

    // 優先インデックスが最大サイトインデックス数未満か確認
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // 楕円オートシェイプに優先接続ドットを設定
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // プレゼンテーションを保存
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **コネクタポイントの調整**

既存のコネクタは調整ポイントを使用して調整できます。調整ポイントを持つコネクタのみがこの方法で変更可能です。**[コネクタの種類](/slides/ja/net/connector/#types-of-connectors)** の表をご参照ください。

#### **単純なケース**

2 つの図形（A と B）間のコネクタが、3 番目の図形（C）を通過するケースを考えてみます：

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


3 番目の図形を回避または迂回するには、コネクタの垂直線を左側に移動させて調整できます：

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **複雑なケース**

より複雑な調整を行うには、以下の点を考慮する必要があります：

* `コネクタ` の調整ポイントは、その位置を計算・決定する数式と密接に関連しています。そのため、ポイントの位置を変更するとコネクタの形状が変わる可能性があります。
* `コネクタ` の調整ポイントは配列内で厳密な順序で定義されます。調整ポイントはコネクタの開始点から終了点へと番号付けされます。
* 調整ポイントの値はコネクタ形状の幅/高さのパーセンテージを表します。
  * 形状はコネクタの開始点と終了点を 1000 倍した範囲で制限されます。
  * 最初のポイント、2 番目のポイント、3 番目のポイントはそれぞれ幅のパーセンテージ、高さのパーセンテージ、再び幅のパーセンテージを表します。
* コネクタの調整ポイントの座標を算出する計算では、コネクタの回転および反転を考慮する必要があります。**注意**：**[コネクタの種類](/slides/ja/net/connector/#types-of-connectors)** に示されているすべてのコネクタの回転角度は 0 です。

#### **ケース 1**

2 つのテキストフレームオブジェクトがコネクタで接続されているケースを考えます：

![connector-shape-complex](connector-shape-complex.png)

コード：
```c#
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成
Presentation pres = new Presentation();
// プレゼンテーションの最初のスライドを取得
ISlide sld = pres.Slides[0];
// コネクタで結合される図形を追加
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

// コネクタで図形同士をリンク
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// コネクタの調整ポイントを取得
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**調整**

コネクタの調整ポイントの値は、対応する幅と高さのパーセンテージをそれぞれ 20% と 200% 増加させることで変更できます：
```c#
// 調整ポイントの値を変更します
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの個々の部品の座標と形状を決定できるモデルを定義するために、`connector.Adjustments[0]` ポイントに対応するコネクタの水平成分に相当する形状を作成しましょう：
```c#
// コネクタの垂直成分を描画

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では、基本原則を用いたシンプルなコネクタ調整操作を示しました。通常の状況では、コネクタの回転および表示（`connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` で設定）を考慮する必要があります。ここではその手順を示します。

最初に、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加（接続目的）し、既存のオブジェクトに接続する新しい（緑色の）コネクタを作成します。
```c#
// 新しいバインディング オブジェクトを作成します
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// 新しいコネクタを作成します
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// 新しく作成したコネクタを使用してオブジェクトを接続します
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


結果：

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイント `connector.Adjustments[0]` を通過するコネクタの水平成分に対応する形状を作成します。`connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` の値を使用し、特定の点 x0 周りの回転座標変換式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

このケースでは、オブジェクトの回転角度は 90 度で、コネクタは垂直に表示されるため、対応するコードは次のとおりです：
```c#
// コネクタの座標を保存
x = connector.X;
y = connector.Y;
// コネクタの座標がずれている場合に修正
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// 調整ポイントの値を座標として取得
x += connector.Width * adjValue_0.RawValue / 100000;
//  Sin(90)=1、Cos(90)=0 のため座標を変換
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// 第2調整ポイントの値を使用して水平成分の幅を決定
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```


結果：

![connector-adjusted-4](connector-adjusted-4.png)

シンプルな調整と、回転角度を伴う複雑な調整ポイントを含む計算を示しました。得られた知識を活用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイント値を設定するモデル（またはコード）を作成できます。

## **コネクタラインの角度を求める**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. コネクタラインの形状にアクセスします。
1. 線の幅・高さ、シェイプフレームの高さ・幅を使用して角度を計算します。

この C# コードは、コネクタライン形状の角度を計算する操作を示しています：
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

**コネクタが特定の図形に「貼り付け」可能かどうかを判断する方法は？**

`shape` が [connection sites](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/) を公開しているか確認してください。存在しない、またはカウントが 0 の場合、貼り付けは利用できません。その場合は、自由端点を使用して手動で位置を設定します。接続する前にサイト数を確認することが賢明です。

**接続された図形の一つを削除した場合、コネクタはどうなりますか？**

端点は切り離され、コネクタはスライド上に普通の線として残り、開始/終了が自由になります。削除するか、接続を再割り当てし、必要に応じて [reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/) を実行できます。

**スライドを別のプレゼンテーションにコピーした場合、コネクタのバインディングは保持されますか？**

一般的に、対象の図形もコピーされていれば保持されます。接続された図形がない状態でスライドを別ファイルに挿入した場合、端点は自由になり、再度接続し直す必要があります。