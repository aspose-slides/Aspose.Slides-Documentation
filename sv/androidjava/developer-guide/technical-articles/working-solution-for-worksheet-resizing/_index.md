---
title: Fungerande lösning för kalkylbladsstorleksändring
type: docs
weight: 20
url: /sv/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildskalning
- Excel
- kalkylblad
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Fixa OLE-förstoringen av Excel‑kalkylblad i presentationer: två sätt att hålla objektramar konsekventa—skala ramen eller bladet—i både PPT- och PPTX-format."
---
{{% alert color="primary" %}}

Det har observerats att Excel‑kalkylblad som är inbäddade som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändras till en okänd skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan före‑ och efteraktiveringsstaten för OLE‑objektet. Vi har undersökt problemet i detalj och tillhandahållit en lösning, som behandlas i den här artikeln.

{{% /alert %}}

## **Bakgrund**

I artikeln [Manage OLE](/slides/sv/androidjava/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för Android via Java. För att åtgärda [object preview issue](/slides/sv/androidjava/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda kalkylbladsområdet till OLE‑objektramen. I den resulterande presentationen, när du dubbelklickar på OLE‑objektramen som visar kalkylbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till sliden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objektramen kommer att ändras när användaren återgår till sliden. Förstoringsfaktorn varierar beroende på storleken på OLE‑objektramen och den inbäddade Excel‑arbetsboken.

## **Orsak till Förstoringen**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑objektramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Förstoringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑objektramen storlek och position.

## **Fungerande Lösning**

Det finns två möjliga lösningar för att undvika förstorningseffekten.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjden och bredden för önskat antal rader och kolumner i OLE‑ramen.
- Behåll OLE‑ramens storlek konstant och skala storleken på de deltagande raderna och kolumnerna så att de får plats i den valda OLE‑ramens storlek.

### **Skala OLE‑ramens storlek**

I detta tillvägagångssätt kommer vi att lära oss hur man ställer in OLE‑ramens storlek för den inbäddade Excel‑arbetsboken så att den matchar den sammanlagda storleken på de deltagande raderna och kolumnerna i Excel‑kalkylbladet.

Anta att vi har ett Excel‑mallblad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas först storleken på OLE‑objektramen baserat på den sammanlagda radhöjden och kolumnbredden för de deltagande raderna och kolumnerna i arbetsboken. Därefter sätter vi OLE‑ramens storlek till detta beräknade värde. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint kommer vi även att ta en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ange den visade storleken när arbetsbokfilen används som OLE-objekt i PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
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

I detta tillvägagångssätt kommer vi att lära oss hur man skalar höjden på de deltagande raderna och bredden på de deltagande kolumnerna så att de matchar en anpassad OLE‑ramstorlek.

Anta att vi har ett Excel‑mallblad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario sätter vi storleken på OLE‑ramen och skalar storleken på de rader och kolumner som deltar i OLE‑ramområdet. Därefter sparar vi arbetsboken till en ström för att tillämpa ändringarna och konverterar den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint kommer vi även att ta en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ange den visade storleken när arbetsboksfilen används som OLE-objekt i PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala cellintervallet för att passa ramstorleken.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Vi måste använda den modifierade arbetsboken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till OLE-bilden i presentationens resurser.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Skapa OLE-objektramen.
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

Det finns två tillvägagångssätt för att åtgärda problemet med att kalkylbladet ändrar storlek. Valet av lämpligt tillvägagångssätt beror på de specifika kraven och användningsfallet. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen begränsning för storleken på OLE‑objektramen i denna lösning.

{{% /alert %}}

## **FAQ**

**Varför ändrar ett inbäddat Excel‑kalkylblad storlek vid första aktiveringen i PowerPoint?**

Detta sker eftersom Excel försöker behålla det ursprungliga fönsterstorleken vid aktivering, medan OLE‑objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bibehålla bildförhållandet, vilket kan leda till förändringen.

**Är det möjligt att helt förhindra detta förstoringsproblem?**

Ja. Genom att skala OLE‑ramen så att den matchar Excel‑cellintervallens storlek eller skala cellintervallet så att det passar den önskade OLE‑ramens storlek, kan du förhindra oönskad förändring.

**Vilken skalningsmetod bör jag använda, OLE‑ramens skalning eller cellintervallens skalning?**

Välj **OLE frame scaling** om du vill behålla de ursprungliga Excel‑rad- och kolumnstorlekarna. Välj **cell range scaling** om du vill ha en fast storlek på OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon begränsning för OLE‑ramens storlek när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektramen i vilken storlek som helst så länge du anger skalan korrekt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta en bild av det önskade Excel‑cellintervallet och använda den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.