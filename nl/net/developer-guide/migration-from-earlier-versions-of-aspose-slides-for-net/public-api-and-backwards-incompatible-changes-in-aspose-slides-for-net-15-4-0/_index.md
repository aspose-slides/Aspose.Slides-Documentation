---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.4.0
linktitle: Aspose.Slides voor .NET 15.4.0
type: docs
weight: 150
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migratie
- oude code
- moderne code
- oude benadering
- moderne benadering
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de openbare API‑updates en breaking changes in Aspose.Slides voor .NET om uw PowerPoint PPT‑, PPTX‑ en ODP‑presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) klassen, methoden, eigenschappen enz., en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides voor .NET 15.4.0 API.

{{% /alert %}} 
## **Openbare API‑wijzigingen**
#### **Enum OrganizationChartLayoutType is toegevoegd**
De Aspose.Slides.SmartArt.OrganizationChartLayoutType‑enum vertegenwoordigt het opmaaktype van de kindknooppunten in een organigram.
#### **Methode IBulletFormat.ApplyDefaultParagraphIndentsShifts is toegevoegd**
Methode Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts stelt standaard niet‑nul verschuivingen in voor effectieve alinea‑insprong en marge‑links wanneer opsommingstekens zijn ingeschakeld (zoals PowerPoint dat doet als alinea‑opsomming/nummering is ingeschakeld). Als opsommingstekens zijn uitgeschakeld, worden alinea‑insprong en marge‑links gereset (zoals PowerPoint dat doet als alinea‑opsomming/nummering is uitgeschakeld).

Zie voorbeelden [hier](/slides/nl/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Methode IConnector.Reroute is toegevoegd**
Methode Aspose.Slides.IConnector.Reroute leidt de connector opnieuw zodat hij het kortste mogelijke pad tussen de vormen die hij verbindt neemt. Hiervoor kan de Reroute()-methode de StartShapeConnectionSiteIndex en EndShapeConnectionSiteIndex wijzigen.

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
#### **Methode IPresentation.GetSlideById is toegevoegd**
Methode Aspose.Slides.IPresentation.GetSlideById(System.UInt32) retourneert een Slide, MasterSlide of LayoutSlide op basis van een slide‑ID.

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
#### **Eigenschap IShape.ConnectionSiteCount is toegevoegd**
Eigenschap Aspose.Slides.IShape.ConnectionSiteCount geeft het aantal verbindingplaatsen op de vorm terug.

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
#### **Eigenschap ISmartArt.IsReversed is toegevoegd**
Eigenschap Aspose.Slides.SmartArt.ISmartArt.IsReversed maakt het mogelijk om de toestand van het SmartArt‑diagram te verkrijgen of in te stellen met betrekking tot (links‑naar‑rechts) LTR of (rechts‑naar‑links) RTL, indien het diagram omkering ondersteunt.

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
#### **Eigenschap ISmartArt.Nodes is toegevoegd**
Eigenschap Aspose.Slides.SmartArt.ISmartArt.Nodes retourneert een collectie van root‑knooppunten in het SmartArt‑object.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // selecteer tweede root-knooppunt

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Eigenschap ISmartArtNode.IsHidden is toegevoegd**
Eigenschap Aspose.Slides.SmartArt.ISmartArtNode.IsHidden retourneert true als dit knooppunt een verborgen knooppunt is in het datamodel.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //geeft true terug

  if(hidden)

  {

    //voer enkele acties of meldingen uit

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Eigenschap ISmartArtNode.OrganizationChartLayout is toegevoegd**
Eigenschap Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout maakt het mogelijk om het type organigram op te vragen of in te stellen dat aan het huidige knooppunt is gekoppeld.

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
#### **Set‑methode voor eigenschap ISmartArt.Layout is toegevoegd**
De set‑methode voor eigenschap Aspose.Slides.SmartArt.ISmartArt.Layout is toegevoegd. Deze maakt het mogelijk het lay-outtype van een bestaand diagram te wijzigen.

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
#### **Kleine API‑wijzigingen**
**Dit is de lijst met kleine API‑wijzigingen:**

|Enum Aspose.Slides.BevelColorMode |verwijderd, ongebruikte enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |verwijderd, ongebruikte eigenschap |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |toegevoegd |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |verwijderd |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |verwijderd omdat verouderd |