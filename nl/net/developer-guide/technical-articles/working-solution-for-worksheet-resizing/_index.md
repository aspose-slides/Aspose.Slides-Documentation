---
title: Werkende oplossing voor het herschalen van werkbladen
type: docs
weight: 40
url: /nl/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsschaling
- Excel
- werkblad
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Los het OLE-herschalingsprobleem van Excel-werkbladen in presentaties op: twee manieren om objectframes consistent te houden—het frame of het werkblad schalen—over de PPT- en PPTX-formaten."
---
{{% alert color="info" %}}
Er is geconstateerd dat Excel-werkbladen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed via Aspose‑componenten, na de eerste activering naar een onbekende schaal worden geschaald. Dit gedrag veroorzaakt een merkbaar visueel verschil in de presentatie tussen de status vóór en na de activering van het OLE‑object. We hebben dit probleem grondig onderzocht en een oplossing geboden, die in dit artikel wordt behandeld.
{{% /alert %}} 

## **Achtergrond**

In het artikel [Beheer OLE](/slides/nl/net/manage-ole/) legden we uit hoe je een OLE‑frame toevoegt aan een PowerPoint‑presentatie met Aspose.Slides for .NET. Om het [object preview issue](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied toegewezen aan het OLE‑objectframe. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding toont, wordt het Excel‑werkboek geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in het daadwerkelijke Excel‑werkboek en vervolgens terugkeren naar de dia door buiten het geactiveerde Excel‑werkboek te klikken. De grootte van het OLE‑objectframe zal wijzigen wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de grootte van het OLE‑objectframe en het ingesloten Excel‑werkboek. 

## **Oorzaak van de herschaling**

Aangezien het Excel‑werkboek een eigen venstergrootte heeft, probeert het bij de eerste activering zijn oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter een eigen afmeting. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer het Excel‑werkboek wordt geactiveerd, om ervoor te zorgen dat de juiste verhoudingen behouden blijven als onderdeel van het insluitproces. De herschaling vindt plaats op basis van de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑objectframe. 

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het herschalingseffect te voorkomen.

- Schaal de grootte van het OLE‑frame in de PowerPoint‑presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE‑frame.  
- Houd de grootte van het OLE‑frame constant en schaald de grootte van de betrokken rijen en kolommen zodat ze binnen de geselecteerde OLE‑framegrootte passen.  

### **Schaal de grootte van het OLE‑frame**

In deze benadering leren we hoe we de grootte van het OLE‑frame van het ingesloten Excel‑werkboek kunnen instellen zodat deze overeenkomt met de cumulatieve grootte van de betrokken rijen en kolommen in het Excel‑werkblad.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario wordt de grootte van het OLE‑objectframe eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de betrokken rijen en kolommen in het werkboek. Vervolgens stellen we de grootte van het OLE‑frame in op deze berekende waarde. Om het rode “EMBEDDED OLE OBJECT”‑bericht voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in het werkboek en stellen we deze in als de OLE‑frame‑afbeelding.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Stel de weergavegrootte in wanneer het werkboekbestand wordt gebruikt als OLE‑object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Haal de breedte en hoogte van de OLE‑afbeelding op in punten.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We moeten het aangepaste werkboek gebruiken.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Voeg de OLE‑afbeelding toe aan de presentatieresources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Maak het OLE‑objectframe.
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

### **Schaal de grootte van het celbereik**

In deze benadering leren we hoe we de hoogtes van de betrokken rijen en de breedtes van de betrokken kolommen kunnen schalen zodat ze passen bij een aangepaste OLE‑framegrootte.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario stellen we de grootte van het OLE‑frame in en schalen we de grootte van de rijen en kolommen die deelnemen aan het OLE‑frame‑gebied. Vervolgens slaan we het werkboek op in een stream om de wijzigingen toe te passen en converteren we het naar een byte‑array om het toe te voegen aan het OLE‑frame. Om het rode “EMBEDDED OLE OBJECT”‑bericht voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in het werkboek en stellen we deze in als de OLE‑frame‑afbeelding.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Stel de weergavegrootte in wanneer het werkboekbestand wordt gebruikt als OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Schaal het celbereik zodat het past in de framegrootte.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten het aangepaste werkboek gebruiken.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Voeg de OLE-afbeelding toe aan de presentatieresources.
var oleImage = presentation.Images.AddImage(imageStream);

// Maak het OLE-objectframe.
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

{{% alert color="info" %}}
Er zijn twee benaderingen om het probleem met de grootteaanpassing van het werkblad op te lossen. De keuze voor de juiste benadering hangt af van de specifieke vereisten en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, ongeacht of de presentaties vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.
{{% /alert %}}

## **FAQ**

### Waarom verandert de grootte van een ingesloten Excel‑werkblad bij de eerste activering in PowerPoint?
Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activering, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de aspectratio te behouden, wat kan leiden tot herschaling.

### Is het mogelijk om dit herschalingsprobleem volledig te voorkomen?
Ja. Door het OLE‑frame te schalen zodat het past bij de grootte van het Excel‑celbereik of door het celbereik te schalen zodat het past bij de gewenste OLE‑framegrootte, kun je ongewenste herschaling voorkomen.

### Welke schaalsmethode moet ik gebruiken, OLE‑frame‑schaling of celbereik‑schaling?
Kies **OLE‑frame‑schaling** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik‑schaling** als je een vaste grootte voor het OLE‑frame in je presentatie wilt hebben.

### Werken deze oplossingen als mijn presentatie is gebaseerd op een sjabloon?
Ja. Beide oplossingen werken voor presentaties die zijn gemaakt vanuit sjablonen en voor presentaties die vanaf nul zijn opgebouwd.

### Is er een limiet aan de grootte van het OLE‑frame bij gebruik van deze methoden?
Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

### Is er een manier om de “EMBEDDED OLE OBJECT”‑placeholdertekst in PowerPoint te vermijden?
Ja. Door een snapshot te maken van het gewenste Excel‑celbereik en deze in te stellen als de placeholder‑afbeelding van het OLE‑frame, kun je een aangepaste voorbeeldafbeelding weergeven in plaats van de standaard placeholder.

## **Gerelateerde artikelen**

[Een Excel‑grafiek maken en insluiten in een presentatie als OLE‑object](/slides/nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objecten automatisch bijwerken met een MS PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)