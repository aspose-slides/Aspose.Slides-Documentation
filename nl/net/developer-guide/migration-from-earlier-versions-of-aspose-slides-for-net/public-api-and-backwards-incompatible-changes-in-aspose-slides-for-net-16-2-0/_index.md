---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 16.2.0
linktitle: Aspose.Slides voor .NET 16.2.0
type: docs
weight: 230
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migratie
- legacy code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de publieke API en de breaking changes in Aspose.Slides for .NET om uw PowerPoint PPT-, PPTX- en ODP‑presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina bevat een overzicht van alle [added](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) of [removed](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **Wijzigingen in de openbare API**
#### **Eigenschappen UpdateDateTimeFields en UpdateSlideNumberFields zijn verwijderd**
De eigenschappen UpdateDateTimeFields en UpdateSlideNumberFields zijn verwijderd uit de Aspose.Slides.Presentation‑klasse en uit de Aspose.Slides.IPresentation‑interface.  
De Text‑eigenschap van de klassen Aspose.Slides.TextFrame, Paragraph, Portion en van de interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion retourneert tekst met bijgewerkte “datetime”-velden.  
Ook zijn de eigenschappen Presentation.DocumentProperties.CreatedTime, LastSavedTime en LastPrinted alleen-lezen geworden.  
#### **Enum Slides.Charts.CategoryAxisType is openbaar gemaakt**
Wordt gebruikt in de eigenschappen IAxis.CategoryAxisType en Axis.CategoryAxisType om het type van de categorie‑as te bepalen.  
CategoryAxisType.Auto – het type van de categorie‑as wordt automatisch bepaald tijdens serialisatie (dit gedrag is momenteel niet geïmplementeerd)  
CategoryAxisType.Text – het type van de categorie‑as is Text  
CategoryAxisType.Date – het type van de categorie‑as is DateTime  
#### **Snelle tekstextractie**
De nieuwe statische methode GetPresentationText is toegevoegd aan de Presentation‑klasse. Er zijn twee overloads voor deze methode:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Het ExtractionMode‑enum‑argument geeft de modus aan om de uitvoer van het tekresultaat te organiseren en kan op de volgende waarden worden ingesteld:  
Unarranged – de ruwe tekst zonder rekening te houden met de positie op de dia  
Arranged – de tekst wordt geplaatst in dezelfde volgorde als op de dia  

De Unarranged‑modus kan worden gebruikt wanneer snelheid cruciaal is; hij is sneller dan de Arranged‑modus.  

PresentationText stelt de ruwe tekst voor die uit de presentatie is geëxtraheerd. Het bevat een SlidesText‑eigenschap uit de Aspose.Slides.Util‑namespace die een array van ISlideText‑objecten retourneert. Elk object vertegenwoordigt de tekst op de corresponderende dia. Een ISlideText‑object heeft de volgende eigenschappen:  

ISlideText.Text – de tekst op de vormen van de dia  
ISlideText.MasterText – de tekst op de vormen van de master‑pagina voor deze dia  
ISlideText.LayoutText – de tekst op de vormen van de lay‑out‑pagina voor deze dia  
ISlideText.NotesText – de tekst op de vormen van de notitie‑pagina voor deze dia  

Er is ook een SlideText‑klasse die de ISlideText‑interface implementeert.  

De nieuwe API kan als volgt worden gebruikt:

``` csharp
using System;
using Aspose.Slides;

// Extraheer de tekst zonder rekening te houden met de positie op de dia (de snelste modus).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Extraheer de tekst in dezelfde volgorde als op de dia.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **ILegacyDiagram‑interface en LegacyDiagram‑klasse zijn toegevoegd**
De interface Aspose.Slides.ILegacyDiagram en de klasse Aspose.Slides.LegacyDiagram zijn toegevoegd om een legacy‑diagramobject te vertegenwoordigen. Een legacy‑diagramobject is een oud formaat van diagrammen uit PowerPoint 97‑2003.  
De nieuwe klasse biedt methoden om een legacy‑diagram om te zetten naar een modern bewerkbaar SmartArt‑object of naar een bewerkbare GroupShape.  
#### **Nieuw lid JustifyLow toegevoegd aan Aspose.Slides.TextAlignment‑enum**
Er is een nieuw lid aan de TextAlignment‑enum toegevoegd: JustifyLow – Kashida‑uitvulling laag.  
#### **Nieuwe eigenschappen voor Aspose.Slides.IOleObjectFrame en OleObjectFrame**
Er zijn nieuwe eigenschappen toegevoegd aan de IOleObjectFrame‑interface en de OleObjectFrame‑klasse die deze interface implementeert. Deze eigenschappen worden gebruikt om informatie te geven over een object dat in de presentatie is ingebed:  
EmbeddedFileExtension – retourneert de bestandsextensie van het huidige ingebedde object of een lege string als het object geen link is  
EmbeddedFileLabel – retourneert de bestandsnaam van het ingebedde OLE‑object  
EmbeddedFileName – retourneert het pad van het ingebedde OLE‑object  
#### **Nieuwe eigenschap CategoryAxisType toegevoegd aan IAxis‑ en Axis‑klassen**
De eigenschap CategoryAxisType specificeert het type van de categorie‑as.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

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
#### **Nieuwe eigenschap ShowLabelAsDataCallout toegevoegd aan DataLabelFormat‑klasse en IDataLabelFormat‑interface**
De eigenschap ShowLabelAsDataCallout bepaalt of het gegevenslabel van het opgegeven diagram wordt weergegeven als gegevenscallout of als gegevenslabel.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

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
De booleaanse eigenschap DrawSlidesFrame is toegevoegd aan de interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions en aan de gerelateerde klassen Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Het zwarte kader rond elke dia wordt getekend als deze eigenschap op ‘true’ wordt gezet.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```