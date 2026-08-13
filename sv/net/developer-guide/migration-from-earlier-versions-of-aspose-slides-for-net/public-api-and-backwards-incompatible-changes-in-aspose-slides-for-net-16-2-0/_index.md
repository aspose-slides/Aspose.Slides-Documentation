---
title: Offentlig API och bakåt inkompatibla ändringar i Aspose.Slides för .NET 16.2.0
linktitle: Aspose.Slides för .NET 16.2.0
type: docs
weight: 230
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
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
description: "Granska offentliga API‑uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint‑PPT, PPTX‑ och ODP‑presentationslösningar."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) klasser, metoder, egenskaper och så vidare, samt andra förändringar som införts med Aspose.Slides för .NET 16.2.0 API.

{{% /alert %}} 
## **Offentliga API‑ändringar**
#### **Egenskaperna UpdateDateTimeFields och UpdateSlideNumberFields har tagits bort**
Egenskaperna UpdateDateTimeFields och UpdateSlideNumberFields har tagits bort från Aspose.Slides.Presentation‑klassen och från Aspose.Slides.IPresentation‑gränssnittet.  
Text‑egenskapen för Aspose.Slides.TextFrame, Paragraph, Portion‑klasserna och Aspose.Slides.ITextFrame, IParagraph, IPortion‑gränssnitten returnerar text med uppdaterade ”datetime”-fält.  
Dessutom har egenskaperna Presentation.DocumentProperties.CreatedTime, LastSavedTime och LastPrinted blivit skrivskyddade.  
#### **Enum Slides.Charts.CategoryAxisType har gjorts offentlig**
Används i IAxis.CategoryAxisType‑ och Axis.CategoryAxisType‑egenskaperna för att bestämma kategorisaxeltyp.  
CategoryAxisType.Auto – kategorisaxeltypen bestäms automatiskt under serialisering (detta beteende är ännu inte implementerat)  
CategoryAxisType.Text – kategorisaxeltypen är Text  
CategoryAxisType.Date – kategorisaxeltypen är DateTime  
#### **Snabb textutvinning**
Den nya statiska metoden GetPresentationText har lagts till i Presentation‑klassen. Det finns två överlagringar för denna metod:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Argumentet ExtractionMode‑enum anger hur resultattexten ska organiseras och kan sättas till följande värden:  
Unarranged – den råa texten utan hänsyn till position på bilden  
Arranged – texten placeras i samma ordning som på bilden  

Unarranged‑läget kan användas när hastigheten är kritisk; det är snabbare än Arranged‑läget.  

PresentationText representerar den råa texten som extraherats från presentationen. Den innehåller en SlidesText‑egenskap från Aspose.Slides.Util‑namnrymden som returnerar en array av ISlideText‑objekt. Varje objekt representerar texten på den motsvarande bilden. ISlideText‑objekt har följande egenskaper:

- ISlideText.Text – texten på bildens former  
- ISlideText.MasterText – texten på mastersidans former för denna bild  
- ISlideText.LayoutText – texten på layoutsidans former för denna bild  
- ISlideText.NotesText – texten på notersidans former för denna bild  

Det finns också en SlideText‑klass som implementerar ISlideText‑gränssnittet.  

Den nya API:n kan användas så här:

``` csharp
using System;
using Aspose.Slides;

// Extrahera texten utan hänsyn till dess position på bilden (det snabbaste läget).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Extrahera texten i samma ordning som på bilden.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **ILegacyDiagram‑gränssnittet och LegacyDiagram‑klassen har lagts till**
Gränssnittet Aspose.Slides.ILegacyDiagram och klassen Aspose.Slides.LegacyDiagram har lagts till för att representera ett legacy‑diagramobjekt. Legacy‑diagramobjektet är ett gammalt format för diagram från PowerPoint 97‑2003.  
Den nya klassen tillhandahåller metoder för att konvertera legacy‑diagram till ett modernt redigerbart SmartArt‑objekt eller till ett redigerbart GroupShape.  
#### **Ny medlem i Aspose.Slides.TextAlignment‑enum lagd till (JustifyLow)**
En ny medlem har lagts till i TextAlignment‑enum:  
JustifyLow – Kashida‑justering låg.  
#### **Nya egenskaper för Aspose.Slides.IOleObjectFrame och OleObjectFrame**
Nya egenskaper har lagts till i IOleObjectFrame‑gränssnittet och OleObjectFrame‑klassen som implementerar detta gränssnitt. Dessa egenskaper används för att tillhandahålla information om ett objekt som är inbäddat i presentationen:  
EmbeddedFileExtension – returnerar filändelsen för det aktuella inbäddade objektet eller en tom sträng om objektet inte är en länk  
EmbeddedFileLabel – returnerar filnamnet för det inbäddade OLE‑objektet  
EmbeddedFileName – returnerar sökvägen till det inbäddade OLE‑objektet  
#### **Ny egenskap CategoryAxisType har lagts till i IAxis och Axis‑klasserna**
Egenskapen CategoryAxisType specificerar typen av kategorisaxel.

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
#### **Ny egenskap ShowLabelAsDataCallout har lagts till i DataLabelFormat‑klassen och IDataLabelFormat‑gränssnittet**
Egenskapen ShowLabelAsDataCallout bestämmer om diagrammets dataetikett ska visas som en data‑callout eller som en dataetikett.

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
#### **Egenskapen DrawSlidesFrame har lagts till i PdfOptions och XpsOptions**
Den booleska egenskapen DrawSlidesFrame har lagts till i gränssnitten Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions samt i de relaterade klasserna Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
En svart ram runt varje bild kommer att ritas om egenskapen sätts till ‘true’.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```