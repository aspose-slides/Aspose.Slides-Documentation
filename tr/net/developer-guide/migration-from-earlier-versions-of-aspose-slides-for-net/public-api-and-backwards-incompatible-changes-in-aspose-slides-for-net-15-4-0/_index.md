---
title: Aspose.Slides for .NET 15.4.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for .NET 15.4.0 API'siyle tanıtılan eklenen veya kaldırılan sınıfları, metodları, özellikleri ve benzeri diğer değişiklikleri listeler.

{{% /alert %}} 
## **Public API Değişiklikleri**
#### **Enum OrganizationChartLayoutType Eklendi**
The Aspose.Slides.SmartArt.OrganizationChartLayoutType enum represents formatting type the child nodes in an organization chart.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts Eklendi**
Method Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts sets default non-zero shifts for effective paragraph Indent and MarginLeft when bullets is enabled (like PowerPoint do if enable paragraph bullets/numbering in it). If bullets is disabled then just reset paragraph Indent and MarginLeft (like PowerPoint do if disable paragraph bullets/numbering in it).

See examples [here](/slides/tr/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute Eklendi**
Method Aspose.Slides.IConnector.Reroute reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the Reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

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
#### **Method IPresentation.GetSlideById Eklendi**
Method Aspose.Slides.IPresentation.GetSlideById(System.UInt32) returns a Slide, MasterSlide or LayoutSlide by slide Id.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount Eklendi**
Property Aspose.Slides.IShape.ConnectionSiteCount returns the number of connection sites on the shape.

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
#### **Property ISmartArt.IsReversed Eklendi**
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed allows get or sets the state of the SmartArt diagram with regard to (left-to-right) LTR or (right-to-left) RTL, if the diagram supports reversal.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes Eklendi**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes returns collection of root nodes in SmartArt object.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // ikinci kök düğümü seç

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden Eklendi**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden returns true if this node is a hidden node in the data model.

``` csharp

 using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
  ISmartArtNode node = smart.AllNodes.AddNode();
  bool hidden = node.IsHidden; //true döndürür
  if(hidden)
  {
    //bazı eylemler veya bildirimler yap
  }
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout Eklendi**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout allows get or sets organization chart type associated with current node.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout Eklendi**
The set method for property Aspose.Slides.SmartArt.ISmartArt.Layout has been added.It allows change layout type of an existing diagram.

``` csharp

 using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
  smart.Layout = SmartArtLayoutType.BasicProcess;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **Küçük API Değişiklikleri**
**Küçük API Değişikliklerinin Listesi:**

|Enum Aspose.Slides.BevelColorMode |silinmiş, kullanılmayan enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |silinmiş, kullanılmayan özellik |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |eklendi |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |silinmiş |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |silinmiş, artık kullanılmaz |