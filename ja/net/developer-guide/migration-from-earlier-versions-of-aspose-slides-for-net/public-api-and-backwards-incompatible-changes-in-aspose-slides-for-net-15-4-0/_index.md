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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、および ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for .NET 15.4.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)または[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)されたクラス、メソッド、プロパティなど、その他の変更をすべて一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Enum OrganizationChartLayoutType が追加されました**
Aspose.Slides.SmartArt.OrganizationChartLayoutType 列挙体は、組織図の子ノードの書式設定タイプを表します。  
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts が追加されました**
Method Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts は、箇条書きが有効な場合に効果的な段落インデントと左余白に対してデフォルトの非ゼロシフトを設定します（PowerPoint が段落の箇条書き/番号付けを有効にしたときと同様）。箇条書きが無効な場合は、段落インデントと左余白をリセットします（PowerPoint が無効にしたときと同様）。

例は[こちら](/slides/ja/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)をご覧ください。  
#### **Method IConnector.Reroute が追加されました**
Method Aspose.Slides.IConnector.Reroute は、コネクタが接続する図形間の最短経路を取るように再ルーティングします。その際、Reroute() メソッドは StartShapeConnectionSiteIndex と EndShapeConnectionSiteIndex を変更する可能性があります。

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
Method Aspose.Slides.IPresentation.GetSlideById(System.UInt32) は、スライド ID によって Slide、MasterSlide、または LayoutSlide を返します。

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
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed は、SmartArt 図が左から右 (LTR) か右から左 (RTL) かの状態を取得または設定します（図が反転をサポートしている場合）。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes が追加されました**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes は、SmartArt オブジェクトのルート ノード コレクションを返します。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 2 番目のルート ノードを選択

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden が追加されました**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden は、このノードがデータモデルで非表示ノードであるかどうかを true で返します。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // true が返ります

  if(hidden)

  {

    // 何らかの処理や通知を行います

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.OrganizationChartLayout が追加されました**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout は、現在のノードに関連付けられた組織図の種類を取得または設定します。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout が追加されました**
Property Aspose.Slides.SmartArt.ISmartArt.Layout の set メソッドが追加されました。これにより、既存の図のレイアウト タイプを変更できます。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Minor API Changes**
**この一覧はマイナー API 変更の一覧です:**

|Enum Aspose.Slides.BevelColorMode |削除、未使用の列挙体 |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |削除、未使用のプロパティ |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |追加 |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |削除 |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |廃止として削除 |