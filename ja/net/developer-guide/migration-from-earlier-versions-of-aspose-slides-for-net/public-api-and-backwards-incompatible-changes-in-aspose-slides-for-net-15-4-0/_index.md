---
title: .NET 15.4.0 用 Aspose.Slides のパブリック API と後方互換性がない変更
linktitle: .NET 用 Aspose.Slides 15.4.0
type: docs
weight: 150
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---

{{% alert color="primary" %}} 

このページには、Aspose.Slides for .NET 15.4.0 APIで導入されたすべての[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)または[削除された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)クラス、メソッド、プロパティなどが一覧表示されています。

{{% /alert %}} 
## **パブリック API の変更**
#### **Enum OrganizationChartLayoutType が追加されました**
Aspose.Slides.SmartArt.OrganizationChartLayoutType enum は、組織図の子ノードの書式設定タイプを表します。
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts が追加されました**
Method Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts は、箇条書きが有効な場合に、効果的な段落インデントと左余白に対してデフォルトの非ゼロシフトを設定します（PowerPoint が段落の箇条書き/番号付けを有効にしたときの動作と同様）。箇条書きが無効な場合は、段落インデントと左余白をリセットします（PowerPoint が無効にしたときの動作と同様）。

例は[こちら](/slides/ja/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)をご覧ください：
#### **Method IConnector.Reroute が追加されました**
Method Aspose.Slides.IConnector.Reroute は、接続先の図形間で最短経路を取るようにコネクタを再ルーティングします。このため、Reroute() メソッドは StartShapeConnectionSiteIndex と EndShapeConnectionSiteIndex を変更する場合があります。

``` csharp
using(Presentation input = new Presentation())
{
  IShapeCollection shapes = input.Slides[0].Shapes;
  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
  connector.StartShapeConnectedTo = ellipse;
  connector.EndShapeConnectedTo = rectangle;
  connector.Reroute();
  input.Save("output.pptx", SaveFormat.Pptx);
}
```
#### **Method IPresentation.GetSlideById が追加されました**
Method Aspose.Slides.IPresentation.GetSlideById(System.UInt32) は、スライド ID に基づいて Slide、MasterSlide、または LayoutSlide を返します。

``` csharp
using (Presentation presentation = new Presentation())
{
    uint id = presentation.Slides[0].SlideId;
    IBaseSlide slide = presentation.GetSlideById(id);
    Debug.Assert(presentation.Slides[0] == slide);
}
```
#### **Property IShape.ConnectionSiteCount が追加されました**
Property Aspose.Slides.IShape.ConnectionSiteCount は、図形上の接続サイトの数を返します。

``` csharp
using(Presentation input = new Presentation())
{
  IShapeCollection shapes = input.Slides[0].Shapes;
  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);
  connector.StartShapeConnectedTo = ellipse;
  connector.EndShapeConnectedTo = rectangle;
  uint wantedIndex = 6;
  if (ellipse.ConnectionSiteCount > wantedIndex)
  {
    connector.StartShapeConnectionSiteIndex = wantedIndex;
  }
  input.Save("output.pptx", SaveFormat.Pptx);
}
```
#### **Property ISmartArt.IsReversed が追加されました**
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed は、SmartArt 図が LTR（左から右）または RTL（右から左）に反転できるかどうかの状態を取得または設定します。

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
  smart.IsReversed = true;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
```
#### **Property ISmartArt.Nodes が追加されました**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes は、SmartArt オブジェクト内のルートノードコレクションを返します。

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);
  ISmartArtNode node = smart.Nodes[1]; // 2 番目のルートノードを選択
  node.TextFrame.Text = "Second root node";
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
```
#### **Property ISmartArtNode.IsHidden が追加されました**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden は、データモデル内でこのノードが非表示ノードであるかどうかを示す true を返します。

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
  ISmartArtNode node = smart.AllNodes.AddNode();
  bool hidden = node.IsHidden; // true が返ります
  if(hidden)
  {
    // 何らかの処理や通知を行う
  }
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
```
#### **Property ISmartArtNode.OrganizationChartLayout が追加されました**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout は、現在のノードに関連付けられた組織図タイプを取得または設定します。

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
```
#### **Set method for property ISmartArt.Layout が追加されました**
Property Aspose.Slides.SmartArt.ISmartArt.Layout の set メソッドが追加されました。これにより、既存の図のレイアウトタイプを変更できます。

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
  smart.Layout = SmartArtLayoutType.BasicProcess;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
```
#### **Minor API changes**
**マイナー API 変更の一覧です:**

|Enum Aspose.Slides.BevelColorMode |削除、未使用の列挙体 |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |削除、未使用のプロパティ |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |追加 |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |削除 |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |廃止済みとして削除 |