---
title: Fungerande lösning för ändring av kalkylbladsstorlek
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
description: "Fixa OLE‑storleksändring av Excel‑kalkylblad i presentationer: två sätt att hålla objektramarna konsekventa—skala ramen eller bladet—över PPT‑ och PPTX‑format."
---
{{% alert color="info" %}}

Det har observerats att Excel‑kalkylblad som är inbäddade som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändras till en oidentifierad skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan före‑ och efteraktiveringslägena för OLE‑objektet. Vi har undersökt problemet i detalj och tillhandahållit en lösning, som behandlas i den här artikeln.

{{% /alert %}}

## **Bakgrund**

I artikeln [Manage OLE](/slides/sv/androidjava/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för Android via Java. För att åtgärda [objektförhandsvisningsproblem](/slides/sv/androidjava/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda kalkylbladsområdet till OLE‑objektramen. I den färdiga presentationen, när du dubbelklickar på OLE‑objektramen som visar kalkylbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objektramen kommer att ändras när användaren återvänder till bilden. Omfånget av storleksändringen varierar beroende på OLE‑objektrammans storlek och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid den första aktiveringen. Å andra sidan har OLE‑objektramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller rätt proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑objektrammens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjden och bredden för önskat antal rader och kolumner i OLE‑ramen.
- Behåll OLE‑ramens storlek konstant och skala storleken på de medverkande raderna och kolumnerna så att de passar inom den valda OLE‑ramens storlek.

### **Skala OLE‑ramens storlek**

I detta tillvägagångssätt kommer vi att lära oss hur man ställer in OLE‑ramens storlek för den inbäddade Excel‑arbetsboken så att den matchar den kumulativa storleken på de medverkande raderna och kolumnerna i Excel‑kalkylbladet.

Anta att vi har ett mall‑Excel‑ark och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas storleken på OLE‑objektrammen först baserat på den kumulativa radhöjden och kolumnbredden för de medverkande raderna och kolumnerna i arbetsboken. Därefter ställer vi in OLE‑ramens storlek till detta beräknade värde. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ange den visade storleken när arbetsboksfilen används som OLE‑objekt i PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

### **Skala cellområdessstorlek**

I detta tillvägagångssätt kommer vi att lära oss hur man skalar höjden på de medverkande raderna och bredden på de medverkande kolumnerna så att de matchar en anpassad OLE‑ramstorlek.

Anta att vi har ett mall‑Excel‑ark och vill lägga till det i en presentation som en OLE‑ram. I detta scenario kommer vi att ställa in OLE‑ramens storlek och skala storleken på de rader och kolumner som deltar i OLE‑ramens område. Vi kommer sedan att spara arbetsboken till en ström för att tillämpa ändringarna och konvertera den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

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

// Ange den visade storleken när arbetsboksfilen används som OLE‑objekt i PowerPoint.
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

Det finns två tillvägagångssätt för att lösa problemet med storleksändring av kalkylbladet. Valet av lämpligt tillvägagångssätt beror på de specifika kraven och användningsfallet. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för storleken på OLE‑objektrammen i denna lösning.

{{% /alert %}}

## **Vanliga frågor**

### Varför ändrar ett inbäddat Excel‑kalkylblad storlek när det först aktiveras i PowerPoint?

Detta händer eftersom Excel försöker behålla den ursprungliga fönsterstorleken vid aktivering, medan OLE‑objektrammen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bibehålla bildförhållandet, vilket kan orsaka storleksändringen.

### Är det möjligt att helt förhindra detta problem med storleksändring?

Ja. Genom att skala OLE‑ramen så att den passar Excel‑cellområdets storlek eller genom att skala cellområdet så att det passar önskad OLE‑ramstorlek kan du förhindra oönskad storleksändring.

### Vilken skalningsmetod bör jag använda, OLE‑ramsskalning eller cellområdesskalning?

Välj **OLE‑ramsskalning** om du vill behålla de ursprungliga Excel‑radernas och -kolumnernas storlekar. Välj **cellområdesskalning** om du vill ha en fast storlek för OLE‑ramen i din presentation.

### Kommer dessa lösningar att fungera om min presentation är baserad på en mall?

Ja. Båda lösningarna fungerar för presentationer skapade från mallar och från grunden.

### Finns det någon gräns för OLE‑ramens storlek när man använder dessa metoder?

Nej. Du kan göra OLE‑objektrammen i vilken storlek som helst så länge du sätter skalningen på rätt sätt.

### Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?

Ja. Genom att ta en ögonblicksbild av mål‑Excel‑cellområdet och sätta den som OLE‑ramens platshållarbild kan du visa en egen förhandsgranskningsbild i stället för standard‑platshållaren.