---
title: "Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 16.2.0 verzióban"
linktitle: "Aspose.Slides for .NET 16.2.0"
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
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és visszafelé nem kompatibilis változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációi megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 16.2.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Publikus API változások**
#### **Az UpdateDateTimeFields és az UpdateSlideNumberFields tulajdonságok eltávolításra kerültek**
Az UpdateDateTimeFields és az UpdateSlideNumberFields tulajdonságok eltávolításra kerültek az Aspose.Slides.Presentation osztályból és az Aspose.Slides.IPresentation interfészből.
Az Aspose.Slides.TextFrame, Paragraph, Portion osztályok, valamint az Aspose.Slides.ITextFrame, IParagraph, IPortion interfészek Text tulajdonsága szöveget ad vissza frissített "datetime" mezőkkel.
Emellett a Presentation.DocumentProperties.CreatedTime, LastSavedTime és LastPrinted tulajdonságok csak olvashatóvá váltak.
#### **A Slides.Charts.CategoryAxisType enumeráció publikusra váltott**
Az IAxis.CategoryAxisType és Axis.CategoryAxisType tulajdonságokban használatos a kategória tengely típusa meghatározásához.
- CategoryAxisType.Auto - a kategória tengely típusa automatikusan lesz meghatározva a sorosítás során (ez a viselkedés jelenleg nincs implementálva)
- CategoryAxisType.Text - a kategória tengely típusa Text
- CategoryAxisType.Date - a kategória tengely típusa DateTime
#### **Gyors szövegek kinyerése**
Az új statikus GetPresentationText módszer hozzá lett adva a Presentation osztályhoz. Ennek a metódusnak két túlterhelt változata van:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Az ExtractionMode enum argumentum azt a módot jelöli, ahogyan a szöveg eredmény kimenetét rendezni kell, és a következő értékekre állítható:
- Unarranged - a nyers szöveg a dia pozíciójára tekintet nélkül
- Arranged - a szöveg a dián lévő sorrendnek megfelelően helyezkedik el

Az Unarranged mód használható, ha a sebesség kritikus, gyorsabb, mint az Arranged mód.

A PresentationText a prezentációból kinyert nyers szöveget képviseli. Tartalmaz egy SlidesText tulajdonságot az Aspose.Slides.Util névtérből, amely ISlideText objektumok tömbjét adja vissza. Minden objektum a megfelelő dia szövegét tartalmazza. Az ISlideText objektumnak a következő tulajdonságai vannak:
- ISlideText.Text - a dia alakzatainak szövege
- ISlideText.MasterText - a mesteroldal alakzatainak szövege ehhez a diához
- ISlideText.LayoutText - a layout oldal alakzatainak szövege ehhez a diához
- ISlideText.NotesText - a jegyzet oldal alakzatainak szövege ehhez a diához

Létezik továbbá a SlideText osztály, amely az ISlideText interfészt valósítja meg.

Az új API így használható:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Az ILegacyDiagram interfész és a LegacyDiagram osztály hozzáadásra került**
Az Aspose.Slides.ILegacyDiagram interfész és az Aspose.Slides.LegacyDiagram osztály hozzá lett adva a régi diagram objektum reprezentálásához. A régi diagram egy régi formátumú diagram a PowerPoint 97-2003-ból.
Az új osztály módszereket biztosít a régi diagram modern, szerkeszthető SmartArt objektummá vagy szerkeszthető GroupShape objektummá konvertálásához.
#### **Új Aspose.Slides.TextAlignment enum érték került hozzáadásra (JustifyLow)**
A TextAlignment enum új tagja hozzá lett adva:
- JustifyLow - Kashida igazítás alul.
#### **Új tulajdonságok az Aspose.Slides.IOleObjectFrame és OleObjectFrame számára**
Új tulajdonságok lettek hozzáadva az IOleObjectFrame interfészhez és a ezt az interfészt megvalósító OleObjectFrame osztályhoz. Ezek a tulajdonságok információt szolgáltatnak a prezentációba beágyazott objektumról:
- EmbeddedFileExtension - visszaadja a jelenlegi beágyazott objektum fájlkiterjesztését, vagy üres karakterláncot, ha az objektum nem link
- EmbeddedFileLabel - visszaadja a beágyazott OLE objektum fájlnevét
- EmbeddedFileName - visszaadja a beágyazott OLE objektum elérési útját
#### **Új CategoryAxisType tulajdonság került hozzáadásra az IAxis és Axis osztályokhoz**
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
#### **Új ShowLabelAsDataCallout tulajdonság került hozzáadásra a DataLabelFormat osztályhoz és az IDataLabelFormat interfészhez**
A ShowLabelAsDataCallout tulajdonság meghatározza, hogy a megadott diagram adatcímkéje adatfelhívásként vagy adatcímkéként jelenik meg.

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
#### **A DrawSlidesFrame tulajdonság hozzáadásra került a PdfOptions és XpsOptions osztályokhoz**
Bool típusú DrawSlidesFrame tulajdonság lett hozzáadva az Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions interfészekhez, valamint a kapcsolódó Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions osztályokhoz.
A fekete keret minden dia körül meg lesz rajzolva, ha ez a tulajdonság 'true'-ra van állítva.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```