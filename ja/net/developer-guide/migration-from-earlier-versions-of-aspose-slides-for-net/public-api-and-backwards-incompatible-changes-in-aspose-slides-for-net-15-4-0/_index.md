---
title: .NET 15.4.0のAspose.Slidesにおける公的APIと後方互換性のない変更
type: docs
weight: 150
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.4.0 APIで追加または削除されたすべてのクラス、メソッド、プロパティなどの変更をリストします。

{{% /alert %}} 
## **公的APIの変更**
#### **Enum OrganizationChartLayoutTypeが追加されました**
Aspose.Slides.SmartArt.OrganizationChartLayoutType列挙体は、組織図内の子ノードのフォーマットタイプを表します。
#### **メソッド IBulletFormat.ApplyDefaultParagraphIndentsShiftsが追加されました**
メソッドAspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShiftsは、箇条書きが有効になっている場合に、効果的な段落インデントとMarginLeftのデフォルトの非ゼロシフトを設定します（PowerPointが段落の箇条書き/番号付けを有効にする場合と同様）。箇条書きが無効になっている場合は、ただ段落インデントとMarginLeftをリセットします（PowerPointが段落の箇条書き/番号付けを無効にする場合と同様）。

例を[こちらで](/slides/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)ご覧ください：
#### **メソッド IConnector.Rerouteが追加されました**
メソッドAspose.Slides.IConnector.Rerouteは、接続する図形間の最短経路を取るようにコネクタを再ルートします。これを行うために、Reroute()メソッドはStartShapeConnectionSiteIndexとEndShapeConnectionSiteIndexを変更する場合があります。

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
#### **メソッド IPresentation.GetSlideByIdが追加されました**
メソッドAspose.Slides.IPresentation.GetSlideById(System.UInt32)は、スライドIDによってスライド、マスタースライド、またはレイアウトスライドを返します。

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **プロパティ IShape.ConnectionSiteCountが追加されました**
プロパティAspose.Slides.IShape.ConnectionSiteCountは、形状上の接続サイトの数を返します。

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
#### **プロパティ ISmartArt.IsReversedが追加されました**
プロパティAspose.Slides.SmartArt.ISmartArt.IsReversedは、SmartArt図の状態を（左から右）LTRまたは（右から左）RTLに関して取得または設定します。図が反転をサポートしている場合。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **プロパティ ISmartArt.Nodesが追加されました**
プロパティAspose.Slides.SmartArt.ISmartArt.Nodesは、SmartArtオブジェクト内のルートノードのコレクションを返します。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 二番目のルートノードを選択

  node.TextFrame.Text = "第二のルートノード";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **プロパティ ISmartArtNode.IsHiddenが追加されました**
プロパティAspose.Slides.SmartArt.ISmartArtNode.IsHiddenは、このノードがデータモデル内の隠れたノードである場合にtrueを返します。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // trueを返す

  if(hidden)

  {

    // 何らかのアクションまたは通知を行う

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **プロパティ ISmartArtNode.OrganizationChartLayoutが追加されました**
プロパティAspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayoutは、現在のノードに関連付けられた組織図タイプを取得または設定します。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **プロパティ ISmartArt.Layoutのsetメソッドが追加されました**
プロパティAspose.Slides.SmartArt.ISmartArt.Layoutのsetメソッドが追加されました。これは、既存の図のレイアウトタイプを変更することを可能にします。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **マイナーAPIの変更**
**これはマイナーAPIの変更のリストです：**

|Enum Aspose.Slides.BevelColorMode | 削除、未使用の列挙 |
| :- | :- |
|プロパティ ThreeDFormatEffectiveData.BevelColorMode | 削除、未使用のプロパティ |
|プロパティ Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>プロパティ Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent | 追加 |
|プロパティ Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>IParagraphFormatEffectiveDataからISlideComponentへの継承 <br>プロパティ Aspose.Slides.IThreeDFormat.AsISlideComponent <br>IThreeDFormatからISlideComponentへの継承 | 削除 |
|プロパティ Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>プロパティ Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>プロパティ Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>プロパティ Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>プロパティ Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>プロパティ Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle | 廃止されましたとして削除 |