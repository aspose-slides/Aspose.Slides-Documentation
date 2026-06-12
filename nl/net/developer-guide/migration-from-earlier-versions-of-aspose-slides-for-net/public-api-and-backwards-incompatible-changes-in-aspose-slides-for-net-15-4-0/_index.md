---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.4.0
linktitle: Aspose.Slides voor .NET 15.4.0
type: docs
weight: 150
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beoordeel de updates van de publieke API en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP presentaties soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) klassen, methoden, eigenschappen enz., en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides voor .NET 15.4.0 API.

{{% /alert %}} 
## **Publieke API-wijzigingen**
#### **Enum OrganizationChartLayoutType is toegevoegd**
De enum Aspose.Slides.SmartArt.OrganizationChartLayoutType geeft het formatteringstype van de onderliggende knooppunten in een organigram weer.
#### **Methode IBulletFormat.ApplyDefaultParagraphIndentsShifts is toegevoegd**
De methode Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts stelt standaard niet‑nul verschuivingen in voor de effectieve alinea‑inspringing en MarginLeft wanneer opsommingstekens zijn ingeschakeld (zoals PowerPoint doet als alinea‑opsomming/nummering wordt ingeschakeld). Als opsommingstekens zijn uitgeschakeld, worden alinea‑inspringing en MarginLeft gewoon gereset (zoals PowerPoint doet als alinea‑opsomming/nummering wordt uitgeschakeld).

Zie voorbeelden [hier](/slides/nl/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Methode IConnector.Reroute is toegevoegd**
De methode Aspose.Slides.IConnector.Reroute herleidt de connector zodat deze het kortste mogelijke pad tussen de vormen die het verbindt neemt. Hiervoor kan de Reroute()-methode de StartShapeConnectionSiteIndex en EndShapeConnectionSiteIndex aanpassen.

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
#### **Methode IPresentation.GetSlideById is toegevoegd**
De methode Aspose.Slides.IPresentation.GetSlideById(System.UInt32) retourneert een Slide, MasterSlide of LayoutSlide op basis van de slide‑Id.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Eigenschap IShape.ConnectionSiteCount is toegevoegd**
De eigenschap Aspose.Slides.IShape.ConnectionSiteCount geeft het aantal verbindingspunten van de vorm terug.

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
#### **Eigenschap ISmartArt.IsReversed is toegevoegd**
De eigenschap Aspose.Slides.SmartArt.ISmartArt.IsReversed stelt in of haalt de status van het SmartArt‑diagram op met betrekking tot (van links naar rechts) LTR of (van rechts naar links) RTL, indien het diagram omkering ondersteunt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Eigenschap ISmartArt.Nodes is toegevoegd**
De eigenschap Aspose.Slides.SmartArt.ISmartArt.Nodes retourneert een collectie van hoofdknooppunten in het SmartArt‑object.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // selecteer tweede hoofdknooppunt

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Eigenschap ISmartArtNode.IsHidden is toegevoegd**
De eigenschap Aspose.Slides.SmartArt.ISmartArtNode.IsHidden geeft true terug als dit knooppunt een verborgen knooppunt is in het datamodel.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //geeft true terug

  if(hidden)

  {

    //voer enkele acties of meldingen uit

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Eigenschap ISmartArtNode.OrganizationChartLayout is toegevoegd**
De eigenschap Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout stelt in of haalt het type organigram op dat aan het huidige knooppunt is gekoppeld.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set‑methode voor eigenschap ISmartArt.Layout is toegevoegd**
De set‑methode voor de eigenschap Aspose.Slides.SmartArt.ISmartArt.Layout is toegevoegd. Hiermee kan het layouttype van een bestaand diagram worden gewijzigd.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Kleine API-wijzigingen**
**Dit is de lijst van kleine API-wijzigingen:**

|Enum Aspose.Slides.BevelColorMode |verwijderd, ongebruikte enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |verwijderd, ongebruikte eigenschap |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |toegevoegd |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |verwijderd |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |verwijderd als verouderd |