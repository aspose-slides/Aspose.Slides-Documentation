---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides .NET 16.2.0-ban
linktitle: Aspose.Slides .NET 16.2.0-hez
type: docs
weight: 230
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a töréspontokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 16.2.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
#### **Az UpdateDateTimeFields és az UpdateSlideNumberFields tulajdonságok eltávolításra kerültek**
Az UpdateDateTimeFields és az UpdateSlideNumberFields tulajdonságok eltávolításra kerültek az Aspose.Slides.Presentation osztályból és az Aspose.Slides.IPresentation interfészből.
Az Aspose.Slides.TextFrame, Paragraph, Portion osztályok és az Aspose.Slides.ITextFrame, IParagraph, IPortion interfészek Text tulajdonsága frissített „datetime” mezőkkel rendelkező szöveget ad vissza.
Ezenkívül a Presentation.DocumentProperties.CreatedTime, LastSavedTime és LastPrinted tulajdonságok írásvédetté váltak.
#### **A Slides.Charts.CategoryAxisType felsorolás nyilvánossá vált**
Az IAxis.CategoryAxisType és Axis.CategoryAxisType tulajdonságokban használják a kategória tengely típusának meghatározására.
CategoryAxisType.Auto – a kategória tengely típusa automatikusan kerül meghatározásra a sorosítás során (ez a viselkedés jelenleg nincs megvalósítva)
CategoryAxisType.Text – a kategória tengely típusa Szöveg
CategoryAxisType.Date – a kategória tengely típusa DateTime
#### **Gyors szövegkinyerés**
Az új, statikus GetPresentationText metódus hozzá lett adva a Presentation osztályhoz. Ennek a metódusnak két túlterhelése van:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Az ExtractionMode felsorolás argumentuma határozza meg a szöveges eredmény kimenetének rendezési módját, és a következő értékekre állítható:
Unarranged – a nyers szöveg, amely nem veszi figyelembe a dia pozícióját
Arranged – a szöveg a dián lévő sorrend szerint van elrendezve

Az Unarranged mód akkor használható, ha a sebesség kritikus, gyorsabb, mint az Arranged mód.

A PresentationText a prezentációból kinyert nyers szöveget képviseli. Tartalmaz egy SlidesText tulajdonságot az Aspose.Slides.Util névtérből, amely egy ISlideText objektumok tömbjét adja vissza. Minden objektum a megfelelő dia szövegét tartalmazza. Az ISlideText objektumnak a következő tulajdonságai vannak:
ISlideText.Text – a dia alakzatainak szövege
ISlideText.MasterText – a mesteroldal alakzatainak szövege ehhez a diához
ISlideText.LayoutText – a elrendezésoldal alakzatainak szövege ehhez a diához
ISlideText.NotesText – a jegyzetoldal alakzatainak szövege ehhez a diához

Van továbbá egy SlideText osztály is, amely megvalósítja az ISlideText interfészt.

Az új API a következő módon használható:

``` csharp
using System;
using Aspose.Slides;

// Kivonja a szöveget a dia helyzetére való tekintés nélkül (a leggyorsabb mód).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Kivonja a szöveget a dián lévő sorrendben.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **Az ILegacyDiagram interfész és a LegacyDiagram osztály hozzáadva**
Az Aspose.Slides.ILegacyDiagram interfész és az Aspose.Slides.LegacyDiagram osztály hozzá lettek adva, hogy a régi diagramobjektumot képviseljék. A régi diagramobjektum a PowerPoint 97-2003 előtti diagramok régi formátuma.
Az új osztály módszereket biztosít a régi diagram modern, szerkeszthető SmartArt objektummá vagy szerkeszthető GroupShape objektummá konvertálásához.
#### **Új Aspose.Slides.TextAlignment felsorolás tag hozzáadva (JustifyLow)**
A TextAlignment felsoroláshoz egy új tag került hozzáadásra:
JustifyLow – alacsony Kashida igazítás.
#### **Új tulajdonságok az Aspose.Slides.IOleObjectFrame és OleObjectFrame számára**
Új tulajdonságok kerültek hozzáadásra az IOleObjectFrame interfészhez és az ezt az interfészt megvalósító OleObjectFrame osztályhoz. Ezek a tulajdonságok a prezentációba beágyazott objektumról nyújtanak információt:
EmbeddedFileExtension – visszaadja a jelenlegi beágyazott objektum fájlkiterjesztését, vagy üres stringet, ha az objektum nem link
EmbeddedFileLabel – visszaadja a beágyazott OLE objektum fájlnevét
EmbeddedFileName – visszaadja a beágyazott OLE objektum elérési útját
#### **Új CategoryAxisType tulajdonság került hozzáadásra az IAxis és Axis osztályokhoz**
A CategoryAxisType tulajdonság meghatározza a kategória tengely típusát.

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
#### **Új ShowLabelAsDataCallout tulajdonság került hozzáadásra a DataLabelFormat osztályhoz és az IDataLabelFormat interfészhez**
A ShowLabelAsDataCallout tulajdonság meghatározza, hogy a megadott diagram adatcímkéje adatfelhívásként vagy adatcímkéként jelenik meg.

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
#### **A DrawSlidesFrame tulajdonság hozzáadva a PdfOptions és XpsOptions osztályokhoz**
A DrawSlidesFrame logikai (bool) tulajdonság hozzá lett adva az Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions interfészekhez, valamint a kapcsolódó Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions osztályokhoz.
A fekete keret minden dia körül meg lesz rajzolva, ha ez a tulajdonság „true” értékre van állítva.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```