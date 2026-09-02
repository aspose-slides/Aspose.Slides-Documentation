---
title: ".NET でプレゼンテーションのコネクタを管理する"
linktitle: "コネクタ"
type: docs
weight: 10
url: /ja/net/connector/
keywords:
- "コネクタ"
- "コネクタ タイプ"
- "コネクタ ポイント"
- "コネクタ ライン"
- "コネクタ 角度"
- "接続サイト"
- "調整ポイント"
- "図形 を 接続"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して、PowerPoint の直線、曲がり、曲線コネクタを追加、接続、再経路化、調整、検査する方法を学びます。"
---
## **概要**

コネクタは、いずれかの図形が移動しても 2 つの図形に接続されたままでいられる線です。端点は PowerPoint の緑の点で表される接続サイトに接続されます。曲がったり湾曲したりしたコネクタの中には、オレンジの点で表される調整ポイントが公開されており、個々のコネクタ セグメントの位置を制御できます。

Aspose.Slides はコネクタを [IConnector](https://reference.aspose.com/slides/ja/net/aspose.slides/iconnector/) インターフェイスで表します。コネクタを作成し、端点を図形に接続し、接続サイトを選択し、経路を再計算し、調整ポイントを持つコネクタのジオメトリを変更できます。

## **コネクタの種類**

[ShapeType](https://reference.aspose.com/slides/ja/net/aspose.slides/shapetype/) 列挙型には、直線、曲がり、曲線のコネクタ プリセットが含まれます。以下の表は、利用可能なコネクタ ジオメトリと各プリセットで定義される調整ポイントの数を示しています。

| コネクタ | 画像 | 調整ポイントの数 |
|---|---|---|
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

調整ポイントの数と意味は選択されたコネクタ プリセットの一部です。2 つの異なるコネクタ タイプが同じコレクション レイアウトを公開するとは限らないことに留意してください。

## **2 つの図形を接続する**

[IShapeCollection.AddConnector](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addconnector/) を使用してコネクタを追加し、[StartShapeConnectedTo](https://reference.aspose.com/slides/ja/net/aspose.slides/connector/startshapeconnectedto/) および [EndShapeConnectedTo](https://reference.aspose.com/slides/ja/net/aspose.slides/connector/endshapeconnectedto/) プロパティに割り当てます。両端が接続されたら、[IConnector.Reroute](https://reference.aspose.com/slides/ja/net/aspose.slides/iconnector/reroute/) が図形間の最短経路を選択します。

次の例は、楕円と矩形を曲がったコネクタで接続します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}

`Reroute` を呼び出すと、[StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/net/aspose.slides/connector/startshapeconnectionsiteindex/) および [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/net/aspose.slides/connector/endshapeconnectionsiteindex/) の値が変わる可能性があります。これらのサイトを固定したままにしたい場合は、再経路化後に特定の接続サイトを割り当ててください。

{{% /alert %}}

## **接続サイトを選択する**

接続可能な各図形は、[ConnectionSiteCount](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/connectionsitecount/) を通じてサイト数を報告します。コネクタ端に割り当てる前に、0 ベースの希望インデックスが有効かどうかを検証してください。図形のジオメトリによりサイト数は異なります。

この例は、対象のサイトが存在する場合に楕円上の特定のサイトにコネクタを接続します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **コネクタ ポイントを調整する**

調整ポイントを持つコネクタは、[IGeometryShape.Adjustments](https://reference.aspose.com/slides/ja/net/aspose.slides/igeometryshape/adjustments/) を介してそれらを公開します。各 [IAdjustValue](https://reference.aspose.com/slides/ja/net/aspose.slides/iadjustvalue/) を調査し、[Type](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/type/) を確認してから [RawValue](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/rawvalue/) を変更してください。プリセット形状の調整を識別する一般的な規則は、[Shape Manipulation](/slides/ja/net/shape-manipulations/) に記載されています。

コネクタの調整は、プリセットに応じて数、順序、意味、および有効な値範囲が異なります。`Type` プロパティは読み取り専用で、調整値は書き込み可能です。同一の意味タイプが複数存在する場合、読み取り専用の [Name](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/name/) プロパティが追加の識別情報を提供します。

### **障害物の回り道**

以下のレイアウトでは、2 つの図形間の `BentConnector5` が 3 番目の図形を通過しています。

![connector-obstruction](connector-obstruction.png)

このコードは障害物があるコネクタを作成します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

垂直方向の曲げを移動すると、コネクタが障害物を回避するように経路が変わります。

![connector-obstruction-fixed](connector-obstruction-fixed.png)

コレクション インデックス `1` が常に垂直曲げを表すと仮定せず、`ConnectorBendPositionY` を検索し、期待される意味タイプが存在する場合にのみ変更する例です。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

`BentConnector5` には `ConnectorBendPositionX` が 2 つ、`ConnectorBendPositionY` が 1 つ存在します。必要なタイプが複数回出現する場合は、`Name` と既知のジオメトリを確認してから選択してください。調整が `ShapeAdjustmentType.Custom` を報告する場合、その意味と範囲はプリセット固有とみなし、契約が明らかになるまで変更しないでください。

## **調整値をコネクタ ジオメトリに関連付ける**

曲がったコネクタの場合、調整値を使用して個々のセグメントの位置を推定できます。これらの計算はコネクタ プリセット固有です。

- `BentConnector4` は通常、`ConnectorBendPositionX` と `ConnectorBendPositionY` をそれぞれ 1 つずつ公開します。
- これらの曲げ位置については、`RawValue / 100000f` が下記例で使用されたコネクタ フレームの幅または高さの割合を生成します。
- コネクタ フレームは回転または反転できるため、フレーム座標はスライド座標と比較する前に変換する必要があります。

以下の例は、まず `Type` を使用して調整を識別し、コレクション インデックスを移植可能な識別子として扱いません。

### **回転していないコネクタ**

最初のレイアウトには、`BentConnector4` で接続された 2 つのテキスト図形が含まれます。

![connector-shape-complex](connector-shape-complex.png)

この例はコネクタを調査し、水平および垂直曲げの調整を取得します。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

両方の曲げを変更するには、期待されるタイプをそれぞれ見つけ、両方が見つかった後に値を変更します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

結果として、水平セグメントと垂直セグメントが移動したコネクタが得られます。

![connector-adjusted-1](connector-adjusted-1.png)

意味タイプが判明したら、その値をコネクタ フレーム座標に変換できます。この例は、2 つの曲げ調整が制御する垂直セグメント上に細い矩形を描画します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

ガイド形状は計算されたセグメントを示しています。

![connector-adjusted-2](connector-adjusted-2.png)

### **回転または反転したコネクタ**

同じコネクタ ジオメトリが縦向きになると、[Frame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/frame/)、[FlipH](https://reference.aspose.com/slides/ja/net/aspose.slides/shapeframe/fliph/)、[FlipV](https://reference.aspose.com/slides/ja/net/aspose.slides/shapeframe/flipv/) の値が、コネクタ フレーム座標からスライド座標への変換に影響します。

この例は縦向きのコネクタを作成し、調整します。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

調整後のコネクタは図形間で縦向きに表示されます。

![connector-adjusted-3](connector-adjusted-3.png)

任意の回転角 α に対して、コネクタ フレーム点 `(x, y)` をフレーム中心 `(x0, y0)` の周りで回転させる式は次のとおりです。

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下のコードはこの例で使用される 90 度回転を処理し、対応するコネクタ セグメント上に赤いガイドを描画します。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

赤いガイドは座標変換後の計算されたセグメントを示しています。

![connector-adjusted-4](connector-adjusted-4.png)

これらの式は例で使用されたプリセットを説明したものであり、汎用的なコネクタ モデルを表すものではありません。別のプリセットに同じ計算を適用する前に、調整タイプ、フレームの向き、および値範囲を必ず検証してください。

## **コネクタの方向角を求める**

直線コネクタの方向は、幅と高さ、および水平・垂直フリップを考慮して計算できます。以下の例は、スライド座標系で正の水平軸から時計回りの角度を報告します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **FAQ**

**コネクタが図形に接続できるかどうかはどうやって判断しますか？**

図形の `ConnectionSiteCount` を確認してください。正のカウントがある場合、その図形は接続サイトを公開しています。コネクタ端に割り当てる前に、選択したサイトインデックスが有効かどうかを検証してください。

**コネクタの調整をコレクション インデックスで特定できますか？**

インデックスは既知のコネクタ プリセットとコレクション レイアウトに対してのみ意味があります。値を変更する前に `IAdjustValue.Type` を確認し、同一の意味タイプが複数出現する場合は `IAdjustValue.Name` を追加情報として使用してください。

**接続された図形が削除された場合はどうなりますか？**

該当するコネクタ端が切り離されます。コネクタはスライド上に残り、削除したり、フリーレインとして配置したり、別の図形に再接続したりできます。

**スライドをコピーしたときにコネクタのバインディングは保持されますか？**

接続された図形とともにスライドがコピーされる場合、バインディングは通常保持されます。コネクタだけがコピーされ、対象図形のいずれかが欠けている場合は、影響を受けた端を再度接続する必要があります。