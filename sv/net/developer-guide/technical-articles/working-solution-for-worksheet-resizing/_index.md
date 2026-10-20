---
title: Arbetslösning för storleksändring av arbetsblad
type: docs
weight: 40
url: /sv/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildstorleksändring
- Excel
- arbetsblad
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Åtgärda OLE‑storleksändring av Excel‑arbetsblad i presentationer: två sätt att hålla objektramarna konsekventa - skala ramen eller bladet - över PPT- och PPTX-formaten."
---
{{% alert color="info" title="Note" %}}

Excel-ark som är inbäddade som OLE-objekt i en PowerPoint-presentation med Aspose-komponenter kan ändra storlek oväntat efter sin första aktivering. Detta beteende skapar en märkbar visuell skillnad mellan OLE-objektet före och efter aktivering. Den här artikeln förklarar problemet och beskriver två sätt att åtgärda det.

{{% /alert %}} 

## **Background**

I artikeln [Hantera OLE](/slides/sv/net/manage-ole/) förklarade vi hur man lägger till en OLE-ram i en PowerPoint-presentation med Aspose.Slides för .NET. För att åtgärda [objektförhandsgranskningsproblem](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda arbetsbladets område till OLE-objektramen. I den resulterande presentationen, när du dubbelklickar på OLE-objektramen som visar arbetsbladsbilden, aktiveras Excel-arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel-arbetsboken. Storleken på OLE-objektramen kommer att förändras när användaren återvänder till bilden. Förstoringsfaktorn varierar beroende på storleken på OLE-objektramen och den inbäddade Excel-arbetsboken. 

## **Cause of Resizing**

Eftersom Excel-arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE-objektramen sin egen storlek. Enligt Microsoft förhandlar Excel och PowerPoint om storleken när Excel-arbetsboken aktiveras för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel-fönstrets storlek och OLE-objektrams storlek och position.

## **Working Solution**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE-ramen i PowerPoint-presentationen så att den matchar total höjd och bredd på de valda raderna och kolumnerna.
- Håll OLE-ramens storlek konstant och skala de valda raderna och kolumnerna så att de får plats i den.

### **Scale the OLE Frame Size**

Detta tillvägagångssätt sätter OLE-ramens storlek så att den matchar total höjd och bredd på de valda raderna och kolumnerna i det inbäddade Excel-arket.

Exemplet laddar en befintlig Excel-arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första arbetsblad med nollbaserade index. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definierar det visade området. Förhandsgranskningen renderas med 96 DPI och dess pixeldimensioner konverteras till punkter med 72 punkter per tum. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) bäddar in den modifierade arbetsboken i en ram med dessa dimensioner. Förhandsgranskningen tilldelas via [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) för att ersätta platshållaren "EMBEDDED OLE OBJECT" i den sparade presentationen.

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

// Ställ in den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Hämta bredden och höjden på OLE‑bilden i punkter.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Vi måste använda den modifierade arbetsboken.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Lägg till OLE‑bilden i presentationens resurser.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Skapa OLE‑objektramen.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Förhandsgranskningshjälpen ställer in [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) på det valda området och tar bort marginaler, sidhuvuden och sidfötter. Med [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) aktiverat renderar [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) området som en PNG-bild. Hjälpen spolar tillbaka bildströmmen innan den returneras för användning i presentationen.

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

### **Scale the Cell Range Size**

Detta tillvägagångssätt skalar höjderna på de valda raderna och bredden på de valda kolumnerna så att de matchar en anpassad OLE-ramstorlek.

Exemplet laddar en befintlig Excel-arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första arbetsblad med nollbaserade index. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definierar det visade området, och hjälpen nedan skalar det området för att passa en ram på 400 punkter i bredd och 100 punkter i höjd. Efter att den modifierade arbetsboken sparats till en ström bäddar [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) in den i den angivna storleken. En förhandsgranskning som renderas med 96 DPI tilldelas via [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), så att den sparade presentationen visar de valda cellerna istället för standardplatshållaren.

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

// Ställ in den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala cellområdet så att det passar rammans storlek.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Vi måste använda den modifierade arbetsboken.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Lägg till OLE‑bilden i presentationens resurser.
var oleImage = presentation.Images.AddImage(imageStream);

// Skapa OLE‑objektramen.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Skaleringshjälpen beräknar separata bredds- och höjdratioer för det valda området, och bevarar de relativa bredden på dess kolumner och de relativa höjderna på dess rader. Den konverterar de beräknade dimensionerna från punkter till tum innan de appliceras med [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) och [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). Det valda området måste ha en icke-noll bredd och höjd.

```cs
/// <param name="width">Den förväntade bredden på cellområdet i punkter.</param>
/// <param name="height">Den förväntade höjden på cellområdet i punkter.</param>
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

Denna förhandsgranskningshjälp renderar det omskalade området med [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Den begränsar [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) till det området, tar bort marginaler, sidhuvuden och sidfötter, och returnerar en PNG-ström placerad i början.

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

## **Conclusion**

{{% alert color="info" title="Note" %}}

Det finns två tillvägagångssätt för att lösa problemet med worksheets storleksändring. Välj det tillvägagångssätt som bäst passar dina krav och ditt användningsscenario. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för storleken på OLE-objektramen i denna lösning.

{{% /alert %}}

## **Vanliga frågor**

**Varför förändras storleken på ett inbäddat Excel‑ark när det aktiveras för första gången i PowerPoint?**

Detta händer eftersom Excel försöker behålla det ursprungliga fönsterstorleken vid aktivering, medan OLE-objektramen i PowerPoint har sina egna mått. PowerPoint och Excel förhandlar om storleken för att bibehålla bildförhållandet, vilket kan orsaka storleksändringen.

**Är det möjligt att helt förhindra detta storleksändringsproblem?**

Ja. Genom att skala OLE-ramen så att den passar Excel‑cellområdets storlek eller skala cellområdet för att passa önskad OLE‑ramstorlek kan du förhindra oönskad storleksändring.

**Vilken skalningsmetod bör jag använda, OLE‑ramskalning eller cellområdesskalning?**

Välj **OLE‑ramskalning** om du vill behålla de ursprungliga Excel‑rad- och kolumnstorlekarna. Välj **cellområdesskalning** om du vill ha en fast storlek på OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon gräns för OLE‑ramens storlek när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektramen i vilken storlek som helst så länge du ställer in skalan på rätt sätt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta ett ögonblicksbilder av det aktuella Excel‑cellområdet och använda den som OLE‑ramens platshållarbilder kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Skapa ett Excel‑diagram och bädda in det i en presentation som ett OLE‑objekt](/slides/sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Uppdatera OLE‑objekt automatiskt med ett MS PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)