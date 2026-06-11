---
title: Publikt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 15.4.0
linktitle: Aspose.Slides för .NET 15.4.0
type: docs
weight: 150
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="primary" %}}

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) klasser, metoder, egenskaper osv., samt andra förändringar som införts med Aspose.Slides för .NET 15.4.0 API.

{{% /alert %}}
## **Offentliga API-ändringar**
#### **Enum OrganizationChartLayoutType har lagts till**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType representerar formateringstypen för de underordnade noderna i ett organisationsdiagram.
#### **Metod IBulletFormat.ApplyDefaultParagraphIndentsShifts har lagts till**
Metoden Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts sätter standardvärden för icke‑nollförskjutningar för effektiv styckeindrag och vänster marginal när punkter är aktiverade (på samma sätt som PowerPoint gör om du aktiverar styckepunkter/numrering). Om punkter är avstängda återställs bara styckeindrag och vänster marginal (som PowerPoint gör om du inaktiverar styckepunkter/numrering).

Se exempel [här](/slides/sv/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Metod IConnector.Reroute har lagts till**
Metoden Aspose.Slides.IConnector.Reroute omdirigerar anslutningslinjen så att den tar den kortaste möjliga vägen mellan formerna den kopplar ihop. För att göra detta kan Reroute()-metoden ändra StartShapeConnectionSiteIndex och EndShapeConnectionSiteIndex.

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
#### **Metod IPresentation.GetSlideById har lagts till**
Metoden Aspose.Slides.IPresentation.GetSlideById(System.UInt32) returnerar en Slide, MasterSlide eller LayoutSlide baserat på slide‑Id.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

```
#### **Egenskap IShape.ConnectionSiteCount har lagts till**
Egenskapen Aspose.Slides.IShape.ConnectionSiteCount returnerar antalet anslutningspunkter på formen.

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
#### **Egenskap ISmartArt.IsReversed har lagts till**
Egenskapen Aspose.Slides.SmartArt.ISmartArt.IsReversed möjliggör att hämta eller ange diagrammets tillstånd avseende (vänster‑till‑höger) LTR eller (höger‑till‑vänster) RTL, om diagrammet stöder omvändning.

``` csharp

 using (Presentation pres = new Presentation())

{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
  smart.IsReversed = true;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
```
#### **Egenskap ISmartArt.Nodes har lagts till**
Egenskapen Aspose.Slides.SmartArt.ISmartArt.Nodes returnerar en samling av rot‑noder i SmartArt‑objektet.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // välj den andra rotnoden

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
```
#### **Egenskap ISmartArtNode.IsHidden har lagts till**
Egenskapen Aspose.Slides.SmartArt.ISmartArtNode.IsHidden returnerar true om denna nod är en dold nod i datamodellen.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //returnerar true

  if(hidden)

  {

    //utför några åtgärder eller notifikationer

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
```
#### **Egenskap ISmartArtNode.OrganizationChartLayout har lagts till**
Egenskapen Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout möjliggör att hämta eller ange organisationsdiagramtyp som är associerad med den aktuella noden.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Set‑metod för egenskap ISmartArt.Layout har lagts till**
Set‑metoden för egenskapen Aspose.Slides.SmartArt.ISmartArt.Layout har lagts till. Den möjliggör att ändra layout‑typ för ett befintligt diagram.

``` csharp

 using (Presentation pres = new Presentation())

{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
  smart.Layout = SmartArtLayoutType.BasicProcess;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
```
#### **Mindre API‑ändringar**
**Detta är listan över mindre API‑ändringar:**

|Enum Aspose.Slides.BevelColorMode |borttagen, oanvänd enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |borttagen, oanvänd egenskap |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |tillagd |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |borttagen |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |borttagen som föråldrad |