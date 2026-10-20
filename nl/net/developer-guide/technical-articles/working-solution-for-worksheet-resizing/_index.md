---
title: Werkende oplossing voor werkbladgrootte‑aanpassing
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
description: "Los het OLE‑formaat‑aanpassingsprobleem van Excel‑werkbladen in presentaties op: twee manieren om objectframes consistent te houden—schalen van het frame of van het blad—over de PPT‑ en PPTX‑formaten."
---
{{% alert color="info" title="Opmerking" %}}

Excel-werkbladen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingesloten met Aspose‑componenten, kunnen onverwacht van formaat veranderen na de eerste activatie. Dit gedrag leidt tot een duidelijk zichtbaar verschil tussen het OLE‑object vóór en na activatie. Dit artikel legt het probleem uit en beschrijft twee manieren om het op te lossen.

{{% /alert %}} 

## **Achtergrond**

In het artikel [OLE beheren](/slides/nl/net/manage-ole/) hebben we uitgelegd hoe je een OLE‑frame aan een PowerPoint‑presentatie toevoegt met Aspose.Slides for .NET. Om het [probleem met voorbeeldweergave van object](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/) op te lossen, hebben we een afbeelding van het geselecteerde werkbladgebied aan het OLE‑object‑frame gekoppeld. In de uiteindelijke presentatie activeert een dubbel‑klikken op het OLE‑object‑frame dat de werkbladafbeelding toont, het Excel‑werkboek. Eindgebruikers kunnen vervolgens gewenste wijzigingen aanbrengen in het daadwerkelijke Excel‑werkboek en daarna terugkeren naar de dia door buiten het geactiveerde Excel‑werkboek te klikken. De grootte van het OLE‑object‑frame wijzigt wanneer de gebruiker terugkeert naar de dia. De factor van de grootte‑aanpassing varieert afhankelijk van de grootte van het OLE‑object‑frame en het ingesloten Excel‑werkboek. 

## **Oorzaak van formaatverandering**

Aangezien het Excel‑werkboek zijn eigen venstergrootte heeft, probeert het bij de eerste activatie zijn oorspronkelijke grootte te behouden. Het OLE‑object‑frame heeft echter zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer het werkboek wordt geactiveerd, zodat de juiste verhoudingen behouden blijven als onderdeel van het insluitproces. De grootte‑aanpassing ontstaat door de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑object‑frame.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het formaat‑veranderings‑effect te voorkomen.

- Schaal het OLE‑frame in de PowerPoint‑presentatie zodat het overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen.  
- Houd de OLE‑framegrootte constant en schaal de geselecteerde rijen en kolommen zodat ze erin passen.

### **Schalen van de OLE-framegrootte**

Deze aanpak stelt de OLE‑framegrootte in zodat deze overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen in het ingesloten Excel‑werkblad.

Het voorbeeld laadt een bestaand Excel‑werkboek en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indices. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definieert het weer te geven bereik. De voorbeeldweergave wordt gerenderd op 96 DPI en de pixelafmetingen worden omgezet naar punten met 72 punten per inch. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) embedde het gewijzigde werkboek in een frame met die afmetingen. De voorbeeldweergave wordt toegewezen via [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) om de “EMBEDDED OLE OBJECT”‑plaatsaanduiding in de opgeslagen presentatie te vervangen.

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

// Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE‑object in PowerPoint.
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

// Voeg de OLE‑afbeelding toe aan de bronnen van de presentatie.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Maak het OLE‑objectframe aan.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

De preview‑helper stelt [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) in op het geselecteerde bereik en verwijdert marges, kop‑ en voetteksten. Met [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) ingeschakeld, renderen [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) het bereik als een PNG‑afbeelding. De helper herstart de afbeeldingsstroom voordat deze wordt geretourneerd voor gebruik in de presentatie.

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

### **Schalen van de celbereikgrootte**

Deze aanpak schaalt de hoogtes van de geselecteerde rijen en de breedtes van de geselecteerde kolommen zodat ze overeenkomen met een aangepaste OLE‑framegrootte.

Het voorbeeld laadt een bestaand Excel‑werkboek en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indices. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definieert het weergegeven bereik, en de onderstaande helper schaalt dat bereik zodat het past in een frame van 400 punten breed en 100 punten hoog. Na het opslaan van het gewijzigde werkboek in een stroom embedt [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) het in het opgegeven formaat. Een voorbeeldweergave die op 96 DPI is gerenderd, wordt toegewezen via [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), zodat de opgeslagen presentatie de geselecteerde cellen weergeeft in plaats van de standaard‑plaatsaanduiding.

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

// Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE‑object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Schaal het celbereik om in de framegrootte te passen.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten het gewijzigde werkboek gebruiken.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Voeg de OLE‑afbeelding toe aan de bronnen van de presentatie.
var oleImage = presentation.Images.AddImage(imageStream);

// Maak het OLE‑objectframe aan.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

De schaal‑helper berekent afzonderlijke breedte‑ en hoogte‑ratio’s voor het geselecteerde bereik, waardoor de relatieve breedtes van de kolommen en de relatieve hoogtes van de rijen behouden blijven. De berekende afmetingen worden omgezet van punten naar inches voordat ze worden toegepast met [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) en [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). Het geselecteerde bereik moet een niet‑nul breedte en hoogte hebben.

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

Deze preview‑helper renderde het vergrote bereik met [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Ze beperkt [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) tot dat bereik, verwijdert marges, kop‑ en voetteksten, en retourneert een PNG‑stroom die zich aan het begin bevindt.

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

{{% alert color="info" title="Opmerking" %}}

Er zijn twee benaderingen om het formaat‑veranderingsprobleem van werkbladen op te lossen. Kies de benadering die het best past bij uw eisen en gebruikssituatie. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑object‑frame in deze oplossing.

{{% /alert %}}

## **FAQ**

**Waarom verandert een ingesloten Excel‑werkblad van grootte wanneer het voor de eerste keer in PowerPoint wordt geactiveerd?**

Dit gebeurt omdat Excel bij activatie probeert de oorspronkelijke venstergrootte te behouden, terwijl het OLE‑object‑frame in PowerPoint eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, waardoor de grootte‑aanpassing optreedt.

**Is het mogelijk om dit formaat‑veranderingsprobleem volledig te voorkomen?**

Ja. Door het OLE‑frame te schalen zodat het overeenkomt met de Excel‑celbereikgrootte, of door het celbereik te schalen zodat het in het gewenste OLE‑frame past, kun je ongewenste grootte‑aanpassingen voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑frame‑schaal of celbereik‑schaal?**

Kies **OLE‑frame‑schaal** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik‑schaal** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

**Werken deze oplossingen als mijn presentatie is gebaseerd op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die zijn gemaakt vanuit sjablonen en voor presentaties die vanaf nul zijn opgebouwd.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**

Nee. Je kunt het OLE‑object‑frame elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de “EMBEDDED OLE OBJECT”‑plaatsaanduidingstekst in PowerPoint te vermijden?**

Ja. Door een snapshot van het gewenste Excel‑celbereik te maken en deze in te stellen als de placeholder‑afbeelding van het OLE‑frame, kun je een aangepaste voorbeeldafbeelding tonen in plaats van de standaard‑plaatsaanduiding.

## **Gerelateerde artikelen**

[Een Excel‑grafiek maken en inbedden in een presentatie als OLE‑object](/slides/nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objecten automatisch bijwerken met een MS PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)