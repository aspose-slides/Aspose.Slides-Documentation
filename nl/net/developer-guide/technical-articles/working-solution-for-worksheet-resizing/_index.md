---
title: Werkende oplossing voor het schalen van werkbladen
type: docs
weight: 40
url: /nl/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsgrootte aanpassen
- Excel
- werkblad
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Los het OLE-schaalprobleem van Excel-werkbladen op in presentaties: twee manieren om objectframes consistent te houden—schalen van het frame of van het blad—over de PPT- en PPTX-formaten."
---
{{% alert color="primary" %}} 

Er is geconstateerd dat Excel‑werkbladen die via Aspose‑componenten als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed, na de eerste activering naar een onbekende schaal worden geschaald. Dit gedrag veroorzaakt een duidelijk zichtbaar verschil in de presentatie tussen de toestand vóór en na de activering van het OLE‑object. We hebben dit probleem grondig onderzocht en een oplossing geboden, die in dit artikel wordt beschreven.

{{% /alert %}} 

## **Achtergrond**

In het artikel [OLE beheren](/slides/nl/net/manage-ole/) legden we uit hoe je een OLE‑frame aan een PowerPoint‑presentatie toevoegt met Aspose.Slides for .NET. Om het [probleem met voorbeeldweergave van object](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied toegewezen aan het OLE‑objectframe. In de gegenereerde presentatie activeert een dubbelklik op het OLE‑objectframe dat de werkbladafbeelding toont, de Excel‑werkmap. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de echte Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de grootte van het OLE‑objectframe en de ingebedde Excel‑werkmap. 

## **Oorzaak van grootteverandering**

Omdat de Excel‑werkmap een eigen venstergrootte heeft, probeert deze bij de eerste activering zijn oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer de Excel‑werkmap wordt geactiveerd, zodat de juiste verhoudingen behouden blijven als onderdeel van het insluitingsproces. De schaalverandering vindt plaats op basis van de verschillen tussen de Excel‑venstergrootte en de afmetingen en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het schaaleffect te vermijden.

- Schaal de OLE‑framegrootte in de PowerPoint‑presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE‑frame.
- Houd de OLE‑framegrootte constant en schaal de grootte van de deelnemende rijen en kolommen zodat ze passen binnen de geselecteerde OLE‑framegrootte.

### **Grootte van OLE‑frame schalen**

In deze benadering leren we hoe we de OLE‑framegrootte van de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de cumulatieve grootte van de deelnemende rijen en kolommen in het Excel‑werkblad.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario wordt de grootte van het OLE‑objectframe eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de deelnemende rijen en kolommen in de werkmap. Vervolgens stellen we de grootte van het OLE‑frame in op deze berekende waarde. Om het rode bericht “EMBEDDED OLE OBJECT” voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in de werkmap en stellen we deze in als OLE‑frame‑afbeelding.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Bereik van cellen schalen**

In deze benadering leren we hoe we de hoogten van de deelnemende rijen en de breedtes van de deelnemende kolommen kunnen schalen zodat ze overeenkomen met een aangepaste OLE‑framegrootte.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario stellen we de grootte van het OLE‑frame in en schalen we de grootte van de rijen en kolommen die deel uitmaken van het OLE‑frame‑gebied. Daarna slaan we de werkmap op naar een stream om de wijzigingen toe te passen en converteren we deze naar een byte‑array om toe te voegen aan het OLE‑frame. Om het rode bericht “EMBEDDED OLE OBJECT” voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in de werkmap en stellen we deze in als OLE‑frame‑afbeelding.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Stel de weergegeven grootte in wanneer het werkmapbestand wordt gebruikt als OLE‑object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Schaal het celbereik zodat het in de framegrootte past.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten de aangepaste werkmap gebruiken.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Voeg de OLE‑afbeelding toe aan de presentatieresources.
var oleImage = presentation.Images.AddImage(imageStream);

// Maak het OLE‑objectframe.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">De verwachte breedte van het celbereik in punten.</param>
/// <param name="height">De verwachte hoogte van het celbereik in punten.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Conclusie**

{{% alert color="primary" %}}

Er zijn twee benaderingen om het probleem met het schalen van het werkblad op te lossen. De keuze van de juiste benadering hangt af van de specifieke eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden aangemaakt. Bovendien is er in deze oplossing geen limiet aan de grootte van het OLE‑objectframe.

{{% /alert %}}

## **FAQ**

**Waarom verandert de grootte van een ingebed Excel‑werkblad bij de eerste activering in PowerPoint?**  
Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activering, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot een schaalverandering.

**Is het mogelijk om dit schaalprobleem volledig te voorkomen?**  
Ja. Door het OLE‑frame te schalen zodat het overeenkomt met de grootte van het Excel‑celbereik, of door het celbereik te schalen zodat het past in de gewenste OLE‑framegrootte, kun je ongewenste schaalveranderingen voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑frame‑schalen of celbereik‑schalen?**  
Kies **OLE‑frame‑schalen** als je de oorspronkelijke rij‑ en kolomgroottes van Excel wilt behouden. Kies **celbereik‑schalen** als je een vaste grootte voor het OLE‑frame in je presentatie wilt hebben.

**Werken deze oplossingen ook als mijn presentatie is gebaseerd op een sjabloon?**  
Ja. Beide oplossingen werken voor presentaties die zijn aangemaakt vanuit sjablonen en voor presentaties die vanaf nul zijn opgebouwd.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**  
Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de tekst “EMBEDDED OLE OBJECT” in PowerPoint te vermijden?**  
Ja. Door een snapshot van het doel‑Excel‑celbereik te nemen en deze in te stellen als placeholder‑afbeelding van het OLE‑frame, kun je een aangepast voorbeeldbeeld tonen in plaats van de standaard placeholder.

## **Gerelateerde artikelen**

[Een Excel‑diagram maken en insluiten in een presentatie als OLE‑object](/slides/nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objecten automatisch bijwerken met een MS PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)