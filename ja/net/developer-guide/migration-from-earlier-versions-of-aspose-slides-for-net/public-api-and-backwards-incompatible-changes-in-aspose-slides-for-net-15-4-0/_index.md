---
title: Aspose.Slides for .NET 15.4.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 15.4.0
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
description: "Aspose.Slides for .NET のパブリック API の更新と重大な変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for .NET 15.4.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)または[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)されたクラス、メソッド、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Enum OrganizationChartLayoutType が追加されました**
Aspose.Slides.SmartArt.OrganizationChartLayoutType 列挙体は、組織図の子ノードの書式設定タイプを表します。
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts が追加されました**
Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts メソッドは、箇条書きが有効な場合（PowerPoint で段落の箇条書き/番号付けを有効にしたときと同様）に、実際の段落インデントと左余白に対してデフォルトの非ゼロシフトを設定します。箇条書きが無効な場合は、段落インデントと左余白をリセットします（PowerPoint で段落の箇条書き/番号付けを無効にしたときと同様）。

例は[こちら](/slides/ja/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)をご覧ください：
#### **Method IConnector.Reroute が追加されました**
Aspose.Slides.IConnector.Reroute メソッドは、接続された図形間の最短経路になるようにコネクタの経路を再設定します。そのために、Reroute() メソッドは StartShapeConnectionSiteIndex と EndShapeConnectionSiteIndex を変更する場合があります。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


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
Aspose.Slides.IPresentation.GetSlideById(System.UInt32) メソッドは、スライド ID に基づいて Slide、MasterSlide、または LayoutSlide を返します。

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Property IShape.ConnectionSiteCount が追加されました**
Aspose.Slides.IShape.ConnectionSiteCount プロパティは、シェイプ上の接続ポイントの数を返します。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


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
Aspose.Slides.SmartArt.ISmartArt.IsReversed プロパティは、SmartArt ダイアグラムが左右反転に対応している場合に、左から右 (LTR) または右から左 (RTL) の状態を取得または設定できるようにします。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.Nodes が追加されました**
Aspose.Slides.SmartArt.ISmartArt.Nodes プロパティは、SmartArt オブジェクトのルートノードのコレクションを返します。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 2番目のルートノードを選択

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden が追加されました**
Aspose.Slides.SmartArt.ISmartArtNode.IsHidden プロパティは、データモデルでこのノードが非表示ノードである場合に true を返します。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // true を返す

  if(hidden)

  {

    // 何らかの処理または通知を行う

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout が追加されました**
Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout プロパティは、現在のノードに関連付けられた組織図タイプを取得または設定できるようにします。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Set Method for Property ISmartArt.Layout が追加されました**
Aspose.Slides.SmartArt.ISmartArt.Layout プロパティのセットメソッドが追加されました。これにより、既存のダイアグラムのレイアウトタイプを変更できます。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **マイナー API の変更**
**これはマイナー API 変更の一覧です:**

|Enum Aspose.Slides.BevelColorMode |削除、未使用の列挙体 |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |削除、未使用のプロパティ |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |追加 |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |削除 |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |廃止として削除 |