---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 16.2.0
linktitle: Aspose.Slides voor .NET 16.2.0
type: docs
weight: 230
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migratie
- oude code
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de breaking changes in Aspose.Slides voor .NET om uw PowerPoint PPT-, PPTX- en ODP-presentatie-oplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Eigenschappen UpdateDateTimeFields en UpdateSlideNumberFields zijn verwijderd**
Eigenschappen UpdateDateTimeFields en UpdateSlideNumberFields zijn verwijderd uit de klasse Aspose.Slides.Presentation en uit de interface Aspose.Slides.IPresentation.
De Text‑eigenschap van de klassen Aspose.Slides.TextFrame, Paragraph, Portion en de interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion geeft tekst terug met bijgewerkte “datetime”-velden.
Ook zijn de eigenschappen Presentation.DocumentProperties.CreatedTime, LastSavedTime en LastPrinted nu alleen-lezen.
#### **Enum Slides.Charts.CategoryAxisType is openbaar gemaakt**
Wordt gebruikt in de eigenschappen IAxis.CategoryAxisType en Axis.CategoryAxisType om het type categorie-as te bepalen.
CategoryAxisType.Auto – type van de categorie‑as wordt automatisch bepaald tijdens serialisatie (dit gedrag is momenteel niet geïmplementeerd)  
CategoryAxisType.Text – type van de categorie‑as is Tekst  
CategoryAxisType.Date – type van de categorie‑as is Datum/tijd  
#### **Snelle tekstelextractie**
De nieuwe statische methode GetPresentationText is toegevoegd aan de klasse Presentation. Er zijn twee overloads voor deze methode:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Het enum‑argument ExtractionMode geeft de modus aan waarin het tekstresultaat wordt georganiseerd en kan de volgende waarden hebben:
Unarranged – de ruwe tekst zonder rekening te houden met de positie op de dia  
Arranged – de tekst wordt gepositioneerd in dezelfde volgorde als op de dia  

De Unarranged‑modus kan worden gebruikt wanneer snelheid cruciaal is; hij is sneller dan de Arranged‑modus.

PresentationText vertegenwoordigt de ruwe tekst die uit de presentatie is gehaald. Het bevat een SlidesText‑eigenschap uit de namespace Aspose.Slides.Util die een array van ISlideText‑objecten retourneert. Elk object vertegenwoordigt de tekst op de bijbehorende dia. ISlideText‑objecten hebben de volgende eigenschappen:

ISlideText.Text – de tekst op de vormen van de dia  
ISlideText.MasterText – de tekst op de vormen van de master‑pagina voor deze dia  
ISlideText.LayoutText – de tekst op de vormen van de lay‑outpagina voor deze dia  
ISlideText.NotesText – de tekst op de vormen van de notitiepagina voor deze dia  

Er is ook een SlideText‑klasse die de ISlideText‑interface implementeert.

De nieuwe API kan als volgt worden gebruikt:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Interface ILegacyDiagram en klasse LegacyDiagram zijn toegevoegd**
Interface Aspose.Slides.ILegacyDiagram en klasse Aspose.Slides.LegacyDiagram zijn toegevoegd om legacy‑diagramobjecten te vertegenwoordigen. Een legacy‑diagramobject is een oud diagramformaat uit PowerPoint 97‑2003.  
De nieuwe klasse biedt methoden om een legacy‑diagram om te zetten naar een modern bewerkbaar SmartArt‑object of naar een bewerkbare GroupShape.
#### **Nieuw lid toegevoegd aan enum Aspose.Slides.TextAlignment (JustifyLow)**
Een nieuw lid van de enum TextAlignment is toegevoegd:
JustifyLow – Kashida-justify low.
#### **Nieuwe eigenschappen voor Aspose.Slides.IOleObjectFrame en OleObjectFrame**
Er zijn nieuwe eigenschappen toegevoegd aan de interface IOleObjectFrame en de klasse OleObjectFrame die deze interface implementeert. Deze eigenschappen worden gebruikt om informatie te geven over een object dat in de presentatie is ingesloten:
EmbeddedFileExtension – geeft de bestandsextensie van het huidige ingesloten object terug of een lege string als het object geen koppeling is  
EmbeddedFileLabel – geeft de bestandsnaam van het ingesloten OLE‑object terug  
EmbeddedFileName – geeft het pad van het ingesloten OLE‑object terug  
#### **Nieuwe eigenschap CategoryAxisType toegevoegd aan de klassen IAxis en Axis**
Eigenschap CategoryAxisType geeft het type van de categorie‑as aan.

``` csharp

 using (Presentation pres = new Presentation(sourcePptxFileName))

{

   IChart chart = pres.Slides[0].Shapes[0] as IChart;

   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;

   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;

   chart.Axes.HorizontalAxis.MajorUnit = 1;

   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

   pres.Save(pptxOutPath, SaveFormat.Pptx);

}

``` 
#### **Nieuwe eigenschap ShowLabelAsDataCallout toegevoegd aan klasse DataLabelFormat en interface IDataLabelFormat**
Eigenschap ShowLabelAsDataCallout bepaalt of het datalabel van een opgegeven diagram wordt weergegeven als datum‑callout of als datalabel.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **Eigenschap DrawSlidesFrame toegevoegd aan PdfOptions en XpsOptions**
Boolean‑eigenschap DrawSlidesFrame is toegevoegd aan de interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions en aan de gerelateerde klassen Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Het zwarte kader rond elke dia wordt getekend als deze eigenschap op ‘true’ staat.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```