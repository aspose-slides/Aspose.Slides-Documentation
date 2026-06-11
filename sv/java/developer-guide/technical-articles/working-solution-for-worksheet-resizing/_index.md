---
title: Fungerande lösning för storleksändring av kalkylblad
type: docs
weight: 20
url: /sv/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildskalning
- Excel
- kalkylblad
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lös OLE-storleksändring av Excel-kalkylblad i presentationer: två sätt att hålla objektramar konsekventa - skala ramen eller bladet - över PPT- och PPTX-format."
---
{{% alert color="primary" %}}

Det har observerats att Excel‑kalkylblad som bäddas in som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter får en okänd skalning efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan OLE‑objektets tillstånd före och efter aktivering. Vi har undersökt problemet i detalj och presenterar en lösning i den här artikeln.

{{% /alert %}}

## **Bakgrund**

I artikeln [Manage OLE](/slides/sv/java/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides for Java. För att åtgärda [object preview issue](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det markerade kalkylbladsområdet till OLE‑ramen. I den resulterande presentationen, när du dubbelklickar på OLE‑ramen som visar kalkylbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑ramen ändras när användaren återvänder till bilden. Skalningsfaktorn varierar beroende på OLE‑ramens storlek och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑ramen sin egen storlek. Enligt Microsoft förhandlar Excel och PowerPoint när arbetsboken aktiveras om storleken för att säkerställa korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen beror på skillnaderna mellan Excel‑fönstrets storlek och OLE‑ramens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika effekt av storleksändring.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjd och bredd för önskat antal rader och kolumner i OLE‑ramen.
- Håll OLE‑ramens storlek konstant och skala storleken på de medverkande raderna och kolumnerna så att de får plats i den valda OLE‑ramstorleken.

### **Skala OLE‑ramens storlek**

I detta tillvägagångssätt lär vi oss hur man ställer in OLE‑ramens storlek för den inbäddade Excel‑arbetsboken så att den matchar den kumulativa storleken av de medverkande raderna och kolumnerna i Excel‑kalkylbladet.

Anta att vi har ett mall‑Excel‑blad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas först OLE‑objektets ramstorlek baserat på den kumulativa radhöjden och kolumnbredden för de medverkande raderna och kolumnerna i arbetsboken. Därefter sätter vi OLE‑ramens storlek till detta beräknade värde. För att undvika den röda texten "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint, fångar vi också en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använder den som OLE‑ramens bild.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ange den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Skala cellintervallens storlek**

I detta tillvägagångssätt lär vi oss hur man skalar höjden på de medverkande raderna och bredden på de medverkande kolumnerna så att de matchar en anpassad OLE‑ramstorlek.

Anta att vi har ett mall‑Excel‑blad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario ställer vi in OLE‑ramens storlek och skalar storleken på de rader och kolumner som deltar i OLE‑ramens område. Vi sparar sedan arbetsboken till en ström för att tillämpa förändringarna och konverterar den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika den röda texten "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint, fångar vi också en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använder den som OLE‑ramens bild.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ange den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala cellintervallet så att det passar ramens storlek.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Vi måste använda den ändrade arbetsboken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till OLE‑bilden i presentationens resurser.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Skapa OLE‑objektramen.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     Den förväntade bredden på cellintervallet i punkter.
 * @param height    Den förväntade höjden på cellintervallet i punkter.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Slutsats**

{{% alert color="primary" %}} 

Det finns två tillvägagångssätt för att lösa problemet med storleksändring av kalkylbladet. Valet av lämplig metod beror på de specifika kraven och användningsfallet. Båda metoderna fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen begränsning för OLE‑objektets ramstorlek i denna lösning.

{{% /alert %}}

## **FAQ**

**Varför ändras storleken på ett inbäddat Excel‑kalkylblad när det aktiveras första gången i PowerPoint?**

Det beror på att Excel försöker behålla det ursprungliga fönsterstorleken vid aktivering, medan OLE‑ramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till en storleksändring.

**Är det möjligt att helt undvika detta storleksändringsproblem?**

Ja. Genom att skala OLE‑ramen för att passa Excel‑cellintervallens storlek eller skala cellintervallet för att passa önskad OLE‑ramstorlek kan du förhindra oönskad skalning.

**Vilken skalningsmetod bör jag använda, OLE‑ramskalning eller cellintervallskalning?**

Välj **OLE‑ramskalning** om du vill behålla de ursprungliga rad- och kolumnstorlekarna i Excel. Välj **cellintervallskalning** om du vill ha en fast storlek på OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation bygger på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon gräns för OLE‑ramens storlek när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektets ram så stor du vill så länge du anger skalan korrekt.

**Finns det ett sätt att undvika platsinnehavaren "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta ett ögonblicksbild av mål‑Excel‑cellintervallet och använda den som OLE‑ramens platshållarbild kan du visa en egen förhandsgranskning i stället för standard‑platshållaren.

## **Relaterade artiklar**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/sv/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)