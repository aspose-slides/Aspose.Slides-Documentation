---
title: Fungerande lösning för arbetsbladsstorleksändring
type: docs
weight: 40
url: /sv/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildskalning
- Excel
- arbetsblad
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lös problemet med OLE‑storleksändring av Excel‑arbetsblad i presentationer: två sätt att hålla objektramar konsistenta—skala ramen eller bladet—över PPT‑ och PPTX‑format."
---
{{% alert color="primary" %}} 

Det har observerats att Excel‑arbetsblad som bäddas in som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändras till en oidentifierad skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan OLE‑objektets tillstånd före och efter aktivering. Vi har undersökt problemet i detalj och tillhandahåller en lösning som beskrivs i den här artikeln.

{{% /alert %}} 

## **Bakgrund**

I artikeln [Hantera OLE](/slides/sv/net/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för .NET. För att åtgärda [objektförhandsgranskningsproblemet](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda arbetsbladsområdet till OLE‑objekt‑ramen. I den resulterande presentationen, när du dubbelklickar på OLE‑objekt‑ramen som visar arbetsbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objekt‑ramen ändras när användaren återvänder till bilden. Storleksändringsfaktorn varierar beroende på storleken på OLE‑objekt‑ramen och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid den första aktiveringen. Å andra sidan har OLE‑objekt‑ramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑objekt‑ramens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjden och bredden för önskat antal rader och kolumner i OLE‑ramen.
- Håll OLE‑ramens storlek konstant och skala storleken på de deltagande raderna och kolumnerna så att de passar inom den valda OLE‑ramens storlek.

### **Skala OLE‑ramens storlek**

I detta tillvägagångssätt lär vi oss hur man ställer in OLE‑ramens storlek för den inbäddade Excel‑arbetsboken så att den matchar den kumulativa storleken av de deltagande raderna och kolumnerna i Excel‑arbetsbladet.

Antag att vi har ett Excel‑mallblad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas storleken på OLE‑objekt‑ramen först baserat på de kumulativa radhöjderna och kolumnbredderna för de deltagande raderna och kolumnerna i arbetsboken. Därefter sätter vi OLE‑ramens storlek till detta beräknade värde. För att undvika det röda "EMBEDDED OLE OBJECT"-meddelandet för OLE‑ramen i PowerPoint kommer vi även att ta en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Ange den visade storleken när arbetsbokfilen används som ett OLE‑objekt i PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Hämta bredd och höjd på OLE‑bilden i punkter.
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

// Skapa OLE‑objekt‑ramen.
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

### **Skala cellområde‑storlek**

I detta tillvägagångssätt lär vi oss hur man skalar höjderna på de deltagande raderna och bredden på de deltagande kolumnerna för att matcha en anpassad OLE‑ramstorlek.

Antag att vi har ett Excel‑mallblad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario kommer vi att sätta OLE‑ramens storlek och skala storleken på de rader och kolumner som deltar i OLE‑ramens område. Vi sparar sedan arbetsboken till en ström för att tillämpa ändringarna och konverterar den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika det röda "EMBEDDED OLE OBJECT"-meddelandet för OLE‑ramen i PowerPoint kommer vi också att ta en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Ange den visade storleken när arbetsbokfilen används som ett OLE‑objekt i PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala cellområdet så att det passar ramens storlek.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Lägg till OLE‑bilden i presentationens resurser.
var oleImage = presentation.Images.AddImage(imageStream);

// Skapa OLE‑objekt‑ramen.
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

{{% alert color="primary" %}}

Det finns två tillvägagångssätt för att åtgärda problemet med arbetsbladsstorleksändring. Valet av lämpligt tillvägagångssätt beror på de specifika krav och användningsfall. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen begränsning för storleken på OLE‑objekt‑ramen i denna lösning.

{{% /alert %}}

## **Vanliga frågor**

**Varför ändrar ett inbäddat Excel‑arbetsblad storlek när det först aktiveras i PowerPoint?**  
Det händer eftersom Excel försöker behålla det ursprungliga fönsterstorleken vid aktivering, medan OLE‑objekt‑ramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till storleksändring.

**Är det möjligt att helt förhindra detta storleksändringsproblem?**  
Ja. Genom att skala OLE‑ramen så att den passar Excel‑cellområdets storlek eller skala cellområdet så att det passar den önskade OLE‑ramstorleken, kan oönskad storleksändring undvikas.

**Vilken skalningsmetod bör jag använda, OLE‑ramskalning eller cellområdesskalning?**  
Välj **OLE‑ramskalning** om du vill behålla de ursprungliga Excel‑rad‑ och kolumnstorlekarna. Välj **cellområdesskalning** om du vill ha en fast storlek för OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**  
Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon begränsning för OLE‑ramens storlek när man använder dessa metoder?**  
Nej. Du kan göra OLE‑objekt‑ramen vilken storlek som helst så länge du anger skalan korrekt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**  
Ja. Genom att ta en avbildning av det mål‑Excel‑cellområdet och använda den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standard‑platshållaren.

## **Relaterade artiklar**

[Skapa ett Excel‑diagram och bädda in det i en presentation som ett OLE‑objekt](/slides/sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Uppdatera OLE‑objekt automatiskt med ett MS PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)