---
title: Fungerande lösning för arbetsbladsstorleksändring
type: docs
weight: 20
url: /sv/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildskalning
- Excel
- arbetsblad
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Åtgärda OLE‑storleksändring av Excel‑arbetsblad i presentationer: två sätt att hålla objekt‑ramar konsekventa—skala ramen eller bladet—över PPT‑ och PPTX‑formaten."
---
{{% alert color="info" %}}

Det har observerats att Excel‑arbetsblad som bäddas in som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändrar storlek till en okänd skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan före‑ och efter‑aktiveringslägena för OLE‑objektet. Vi har undersökt problemet i detalj och tillhandahåller en lösning i denna artikel.

{{% /alert %}}

## **Bakgrund**

I artikeln [Hantera OLE](/slides/sv/java/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides for Java. För att åtgärda [objekt‑förhandsgranskningsproblemet](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det markerade arbetsbladsområdet till OLE‑ramen. I den resulterande presentationen, när du dubbelklickar på OLE‑ramen som visar arbetsbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑ramen ändras när användaren återvänder till bilden. Storleksändringen varierar beroende på OLE‑ramens storlek och den inbäddade Excel‑arbetsbokens storlek.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑ramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller rätt proportioner som en del av inbäddningsprocessen. Storleksändringen beror på skillnaderna mellan Excel‑fönstrets storlek och OLE‑ramens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjden och bredden för önskat antal rader och kolumner i OLE‑ramen.
- Behåll OLE‑ramens storlek konstant och skala storleken på de medverkande raderna och kolumnerna så att de får plats i den valda OLE‑ramens storlek.

### **Skala OLE‑ramens storlek**

I detta tillvägagångssätt lär vi oss hur man ställer in OLE‑ramens storlek för det inbäddade Excel‑arbetsboken så att den matchar den kumulativa storleken för de medverkande raderna och kolumnerna i Excel‑arbetsbladet.

Anta att vi har ett mall‑Excel‑blad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas först OLE‑objektets storlek baserat på de kumulativa radhöjderna och kolumnbredderna för de medverkande raderna och kolumnerna i arbetsboken. Därefter ställer vi in OLE‑ramens storlek till detta beräknade värde. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint, fångar vi också en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använder den som OLE‑ramens bild.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ange den visade storleken när arbetsboksfilen används som OLE-objekt i PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Hämta bredden och höjden på OLE-bilden i punkter.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Vi måste använda den modifierade arbetsboken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till OLE-bilden i presentationens resurser.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Skapa OLE-objektsramen.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

### **Skala cellområdets storlek**

I detta tillvägagångssätt lär vi oss hur man skalar höjden på de medverkande raderna och bredden på de medverkande kolumnerna så att de matchar en anpassad OLE‑ramstorlek.

Anta att vi har ett mall‑Excel‑blad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario ställer vi in OLE‑ramens storlek och skalar storleken på de rader och kolumner som deltar i OLE‑ramens område. Därefter sparar vi arbetsboken till en ström för att tillämpa ändringarna och konverterar den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint, får vi också en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och sätter den som OLE‑ramens bild.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

// Skala cellområdet så att det passar ramens storlek.
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

// Skapa OLE-objektsramen.
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
 * @param width     Den förväntade bredden på cellområdet i punkter.
 * @param height    Den förväntade höjden på cellområdet i punkter.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" %}} 

Det finns två tillvägagångssätt för att lösa problem med storleksändring av arbetsbladet. Valet av lämpligt tillvägagångssätt beror på de specifika kraven och användningsfallet. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från början. Dessutom finns det ingen begränsning för OLE‑objektets ramstorlek i denna lösning.

{{% /alert %}}

## **FAQ**

### Varför förändras storleken på ett inbäddat Excel‑arbetsblad vid första aktiveringen i PowerPoint?

Det beror på att Excel försöker behålla det ursprungliga fönsterets storlek när det aktiveras, medan OLE‑objektets ram i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bibehålla bildförhållandet, vilket kan orsaka en storleksändring.

### Är det möjligt att helt undvika detta storleksändringsproblem?

Ja. Genom att skala OLE‑ramen så att den passar Excel‑cellområdets storlek eller genom att skala cellområdet så att det passar den önskade OLE‑ramens storlek kan oönskad storleksändring förhindras.

### Vilken skalningsmetod bör jag använda, OLE‑ram‑skalning eller cellområde‑skalning?

Välj **OLE‑ram‑skalning** om du vill behålla de ursprungliga Excel‑rad- och kolumnstorlekarna. Välj **cellområde‑skalning** om du vill ha en fast storlek för OLE‑ramen i din presentation.

### Kommer dessa lösningar att fungera om min presentation är baserad på en mall?

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från början.

### Finns det någon begränsning för storleken på OLE‑ramen när man använder dessa metoder?

Nej. Du kan göra OLE‑objektets ram så stor du vill så länge du ställer in skalan korrekt.

### Finns det ett sätt att undvika texten "EMBEDDED OLE OBJECT" i PowerPoint?

Ja. Genom att ta en bild av mål‑Excel‑cellområdet och använda den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standard‑platshållaren.

## **Relaterade artiklar**

[Skapa ett Excel‑diagram och bädda in det i en presentation som ett OLE‑objekt](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Uppdatera OLE‑objekt automatiskt med ett MS PowerPoint‑tillägg](/slides/sv/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)