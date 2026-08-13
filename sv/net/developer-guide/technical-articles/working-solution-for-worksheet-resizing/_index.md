---
title: Fungerande lösning för storleksändring av kalkylblad
type: docs
weight: 40
url: /sv/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildskalning
- Excel
- kalkylblad
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Åtgärda OLE‑storleksändring av Excel‑kalkylblad i presentationer: två sätt att hålla objektramar konsekventa—skala ramen eller bladet—över PPT‑ och PPTX‑format."
---
{{% alert color="info" %}} 
Det har observerats att Excel-kalkylblad som är inbäddade som OLE-objekt i en PowerPoint-presentation via Aspose-komponenter ändras till en okänd skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan före- och efteraktiveringsstatusen för OLE-objektet. Vi har undersökt problemet i detalj och tillhandahåller en lösning som behandlas i den här artikeln.
{{% /alert %}} 

## **Bakgrund**

I artikeln [Manage OLE](/slides/sv/net/manage-ole/) förklarade vi hur man lägger till en OLE-ram i en PowerPoint-presentation med Aspose.Slides för .NET. För att åtgärda [object preview issue](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda kalkylbladsområdet till OLE-objektramen. I den genererade presentationen, när du dubbelklickar på OLE-objektramen som visar kalkylbladsbilden, aktiveras Excel-arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel-arbetsboken och sedan återvända till bilden genom att klicka utanför den aktiverade Excel-arbetsboken. Storleken på OLE-objektramen kommer att förändras när användaren återgår till bilden. Ändringsfaktorn varierar beroende på storleken på OLE-objektramen och den inbäddade Excel-arbetsboken. 

## **Orsak till storleksändring**

Eftersom Excel-arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE-objektramen sin egen storlek. Enligt Microsoft, när Excel-arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel-fönstrets storlek och OLE-objektrammens storlek och position. 

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE-ramens storlek i PowerPoint-presentationen så att den matchar höjden och bredden för önskat antal rader och kolumner i OLE-ramen.
- Håll OLE-ramens storlek konstant och skala storleken på de medverkande raderna och kolumnerna så att de passar inom den valda OLE-ramens storlek.

### **Skala OLE-ramens storlek**

I detta tillvägagångssätt kommer vi att lära oss hur man ställer in OLE-ramens storlek för den inbäddade Excel-arbetsboken så att den matchar den kumulativa storleken för de medverkande raderna och kolumnerna i Excel-kalkylbladet.

Anta att vi har ett mall-Excel-ark och vill lägga till det i en presentation som en OLE-ram. I detta scenario kommer storleken på OLE-objektramen först att beräknas baserat på den kumulativa radhöjden och kolumnbredden för de medverkande raderna och kolumnerna i arbetsboken. Därefter kommer vi att sätta OLE-ramens storlek till detta beräknade värde. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE-ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE-ramens bild.

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

// Ange den visade storleken när arbetsbokfilen används som ett OLE-objekt i PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Hämta bredden och höjden på OLE-bilden i punkter.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Vi måste använda den ändrade arbetsboken.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Lägg till OLE-bilden i presentationens resurser.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Skapa OLE-objektramen.
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

### **Skala cellområdets storlek**

I detta tillvägagångssätt kommer vi att lära oss hur man skalar höjderna på de medverkande raderna och bredden på de medverkande kolumnerna för att matcha en anpassad OLE-ramstorlek.

Anta att vi har ett mall-Excel-ark och vill lägga till det i en presentation som en OLE-ram. I detta scenario kommer vi att sätta OLE-ramens storlek och skala storleken på de rader och kolumner som deltar i OLE-ramens område. Vi kommer sedan att spara arbetsboken till en ström för att tillämpa ändringarna och konvertera den till en byte-array för att lägga till den i OLE-ramen. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE-ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE-ramens bild.

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

// Ange den visade storleken när arbetsbokfilen används som ett OLE-objekt i PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala cellområdet så att det passar ramstorleken.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Vi måste använda den ändrade arbetsboken.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Lägg till OLE-bilden i presentationens resurser.
var oleImage = presentation.Images.AddImage(imageStream);

// Skapa OLE-objektramen.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

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

## **Slutsats**

{{% alert color="info" %}}
Det finns två tillvägagångssätt för att åtgärda problemet med kalkylbladsstorleksändring. Valet av lämpligt tillvägagångssätt beror på specifika krav och användningsfall. Båda metoderna fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för OLE-objektrammens storlek i denna lösning.
{{% /alert %}}

## **FAQ**

### Varför ändras ett inbäddat Excel-kalkylblad i storlek när det aktiveras för första gången i PowerPoint?
Detta händer eftersom Excel försöker behålla det ursprungliga fönsterstorleken vid aktivering, medan OLE-objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan orsaka storleksändringen.

### Är det möjligt att helt förhindra detta storleksändringsproblem?
Ja. Genom att skala OLE-ramen så att den passar Excel-cellområdets storlek eller skala cellområdet så att det passar den önskade OLE-ramens storlek kan du förhindra oönskad storleksändring.

### Vilken skalningsmetod bör jag använda, OLE-ramskalning eller cellområdesskalning?
Välj **OLE frame scaling** om du vill behålla de ursprungliga Excel-rad- och kolumnstorlekarna. Välj **cell range scaling** om du vill ha en fast storlek på OLE-ramen i din presentation.

### Kommer dessa lösningar att fungera om min presentation är baserad på en mall?
Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

### Finns det någon begränsning för OLE-ramens storlek när man använder dessa metoder?
Nej. Du kan göra OLE-objektramen vilken storlek som helst så länge du ställer in skalan på rätt sätt.

### Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?
Ja. Genom att ta en skärmdump av det önskade Excel-cellområdet och sätta den som OLE-ramens platshållarbilde kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Skapa ett Excel-diagram och bädda in det i en presentation som ett OLE-objekt](/slides/sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Uppdatera OLE-objekt automatiskt med ett MS PowerPoint-tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)