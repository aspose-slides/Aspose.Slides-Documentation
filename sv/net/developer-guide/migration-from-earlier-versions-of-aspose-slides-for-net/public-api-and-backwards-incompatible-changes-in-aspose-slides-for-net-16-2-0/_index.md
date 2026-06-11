---
title: Offentligt API och bakåt inkompatibla förändringar i Aspose.Slides för .NET 16.2.0
linktitle: Aspose.Slides för .NET 16.2.0
type: docs
weight: 230
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migrering
- legacy‑kod
- modern kod
- legacy‑metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API‑uppdateringar och kritiska förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint‑PPT, PPTX‑ och ODP‑presentationslösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) klasser, metoder, egenskaper osv., samt andra förändringar som införts med Aspose.Slides för .NET 16.2.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
#### **Egenskaperna UpdateDateTimeFields och UpdateSlideNumberFields har tagits bort**
Egenskaperna UpdateDateTimeFields och UpdateSlideNumberFields har tagits bort från klassen Aspose.Slides.Presentation och från gränssnittet Aspose.Slides.IPresentation.
Text‑egenskapen i klasserna Aspose.Slides.TextFrame, Paragraph, Portion och i gränssnitten Aspose.Slides.ITextFrame, IParagraph, IPortion returnerar text med uppdaterade "datetime"-fält.
Dessutom blev egenskaperna Presentation.DocumentProperties.CreatedTime, LastSavedTime och LastPrinted skrivskyddade.
#### **Enum Slides.Charts.CategoryAxisType har gjorts offentlig**
Används i egenskaperna IAxis.CategoryAxisType och Axis.CategoryAxisType för att bestämma kategorisk axeltyp.
CategoryAxisType.Auto - kategorisk axeltyp kommer att bestämmas automatiskt under serialisering (detta beteende är ännu inte implementerat)
CategoryAxisType.Text - kategorisk axeltyp är Text
CategoryAxisType.Date - kategorisk axeltyp är DateTime
#### **Snabb textutdragning**
Den nya statiska metoden GetPresentationText har lagts till i Presentation‑klassen. Det finns två överlagringar av denna metod:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Argumentet ExtractionMode‑enum anger hur textresultatet ska organiseras och kan sättas till följande värden:
Unarranged - Råtext utan hänsyn till position på bilden
Arranged - Texten är placerad i samma ordning som på bilden

Unarranged‑läget kan användas när hastighet är kritisk, det är snabbare än Arranged‑läget.

PresentationText representerar den råa texten som extraherats från presentationen. Den innehåller en SlidesText‑egenskap från namnrymden Aspose.Slides.Util som returnerar en array av ISlideText‑objekt. Varje objekt representerar texten på den motsvarande bilden. ISlideText‑objektet har följande egenskaper:
ISlideText.Text - Texten på bildens former
ISlideText.MasterText - Texten på mastersidans former för denna bild
ISlideText.LayoutText - Texten på layoutsidans former för denna bild
ISlideText.NotesText - Texten på notes‑sidans former för denna bild

Det finns också en SlideText‑klass som implementerar ISlideText‑gränssnittet.

Den nya API:n kan användas så här:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **ILegacyDiagram‑gränssnittet och LegacyDiagram‑klassen har lagts till**
Gränssnittet Aspose.Slides.ILegacyDiagram och klassen Aspose.Slides.LegacyDiagram har lagts till för att representera ett legacy‑diagramobjekt. Legacy‑diagramobjekt är ett gammalt format av diagram från PowerPoint 97-2003.
Den nya klassen tillhandahåller metoder för att konvertera legacy‑diagram till ett modernt redigerbart SmartArt‑objekt eller till en redigerbar GroupShape.
#### **Ny Aspose.Slides.TextAlignment‑enum‑medlem tillagd (JustifyLow)**
En ny medlem har lagts till i TextAlignment‑enum:
JustifyLow - Kashida-justify låg.
#### **Nya egenskaper för Aspose.Slides.IOleObjectFrame och OleObjectFrame**
En ny egenskap har lagts till i gränssnittet IOleObjectFrame och i klassen OleObjectFrame som implementerar detta gränssnitt. Dessa egenskaper används för att ge information om ett objekt som är inbäddat i presentationen:
EmbeddedFileExtension - Returnerar filändelsen för det aktuella inbäddade objektet eller en tom sträng om objektet inte är en länk
EmbeddedFileLabel - Returnerar filnamnet på det inbäddade OLE‑objektet
EmbeddedFileName - Returnerar sökvägen till det inbäddade OLE‑objektet
#### **Ny egenskap CategoryAxisType har lagts till i IAxis‑ och Axis‑klasserna**
Egenskapen CategoryAxisType specificerar typen av kategori‑axel.

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
#### **Ny egenskap ShowLabelAsDataCallout har lagts till i DataLabelFormat‑klassen och IDataLabelFormat‑gränssnittet**
Egenskapen ShowLabelAsDataCallout bestämmer om diagrammets dataetikett ska visas som en data‑callout eller som en dataetikett.

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
#### **Egenskapen DrawSlidesFrame har lagts till i PdfOptions‑ och XpsOptions‑klasserna**
Den booleska egenskapen DrawSlidesFrame har lagts till i gränssnitten Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions samt i de relaterade klasserna Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.
Den svarta ramen runt varje bild kommer att ritas om denna egenskap sätts till 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```