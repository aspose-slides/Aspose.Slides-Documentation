---
title: Publika API och bakåtinkompatibla ändringar i Aspose.Slides för .NET 15.4.0
linktitle: Aspose.Slides för .NET 15.4.0
type: docs
weight: 150
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migration
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
description: "Granska publika API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP‑presentationslösningar."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) klasser, metoder, egenskaper med mera, samt andra ändringar som introducerats med Aspose.Slides för .NET 15.4.0 API.

{{% /alert %}} 
## **Publika API-ändringar**
#### **Enum OrganizationChartLayoutType har lagts till**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType representerar formateringstypen för barnnoder i ett organisationsdiagram.
#### **Metod IBulletFormat.ApplyDefaultParagraphIndentsShifts har lagts till**
Metoden Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts sätter standardvärdena för icke‑noll förskjutningar för effektiv styckeindrag och vänstermarginal när punkter är aktiverade (på samma sätt som PowerPoint gör när stycke‑punkter/numrering är aktiverade). Om punkter är inaktiverade återställs bara styckeindrag och vänstermarginal (så som PowerPoint gör när stycke‑punkter/numrering inaktiveras).

Se exempel [här](/slides/sv/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Metod IConnector.Reroute har lagts till**
Metoden Aspose.Slides.IConnector.Reroute omdirigerar anslutningen så att den tar den kortaste möjliga vägen mellan de former den ansluter. För att göra detta kan Reroute()-metoden ändra StartShapeConnectionSiteIndex och EndShapeConnectionSiteIndex.

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
#### **Metod IPresentation.GetSlideById har lagts till**
Metoden Aspose.Slides.IPresentation.GetSlideById(System.UInt32) returnerar en Slide, MasterSlide eller LayoutSlide baserat på slide‑Id.

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
#### **Egenskap IShape.ConnectionSiteCount har lagts till**
Egenskapen Aspose.Slides.IShape.ConnectionSiteCount returnerar antalet anslutningspunkter på formen.

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
#### **Egenskap ISmartArt.IsReversed har lagts till**
Egenskapen Aspose.Slides.SmartArt.ISmartArt.IsReversed möjliggör att hämta eller ange diagrammets tillstånd med avseende på (vänster‑till‑höger) LTR eller (höger‑till‑vänster) RTL, om diagrammet stödjer omvändning.

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
#### **Egenskap ISmartArt.Nodes har lagts till**
Egenskapen Aspose.Slides.SmartArt.ISmartArt.Nodes returnerar en samling av rot‑noder i SmartArt‑objektet.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // välj andra rotnod

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Egenskap ISmartArtNode.IsHidden har lagts till**
Egenskapen Aspose.Slides.SmartArt.ISmartArtNode.IsHidden returnerar true om denna nod är en dold nod i datamodellen.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //returnerar true

  if(hidden)

  {

    //utför vissa åtgärder eller aviseringar

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Egenskap ISmartArtNode.OrganizationChartLayout har lagts till**
Egenskapen Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout möjliggör att hämta eller ange diagramtyp för organisationsdiagram som är associerad med den aktuella noden.

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
#### **Set‑metod för egenskap ISmartArt.Layout har lagts till**
Set‑metoden för egenskapen Aspose.Slides.SmartArt.ISmartArt.Layout har lagts till. Den möjliggör att ändra layout‑typen för ett befintligt diagram.

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
#### **Mindre API‑ändringar**
**Det här är listan över mindre API‑ändringar:**

|Enum Aspose.Slides.BevelColorMode |borttagen, oanvänd enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |borttagen, oanvänd egenskap |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |tillagd |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |borttagen |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |borttagen som föråldrad |