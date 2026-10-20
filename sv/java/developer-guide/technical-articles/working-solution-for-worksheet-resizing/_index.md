---
title: Lösning för kalkylbladsstorleksändring
type: docs
weight: 20
url: /sv/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildstorleksändring
- Excel
- kalkylblad
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Fixa OLE‑storleksändring av Excel‑kalkylblad i presentationer: två sätt att hålla objektramar konsekventa—skala ramen eller bladet—över PPT‑ och PPTX‑formaten."
---
{{% alert color="info" title="Note" %}}

Excel-kalkylblad som är inbäddade som OLE-objekt i en PowerPoint-presentation med Aspose-komponenter kan ändra storlek oväntat efter sin första aktivering. Detta beteende skapar en märkbar visuell skillnad mellan OLE-objektet före och efter aktivering. Denna artikel förklarar problemet och beskriver två sätt att lösa det.

{{% /alert %}}

## **Bakgrund**

I artikeln [Hantera OLE](/slides/sv/java/manage-ole/) förklarade vi hur man lägger till en OLE-ram i en PowerPoint-presentation med Aspose.Slides för Java. För att åtgärda [problem med förhandsgranskning av objekt](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda kalkylbladsområdet till OLE-ramen. I den sparade presentationen, när du dubbelklickar på OLE-ramen som visar kalkylbladsbilden, aktiveras Excel-arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel-arbetsboken. Storleken på OLE-ramen kommer att ändras när användaren återvänder till bilden. Storleksändringsfaktorn varierar beroende på storleken på OLE-ramen och den inbäddade Excel-arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel-arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE-objektets ram sin egen storlek. Enligt Microsoft förhandlar Excel och PowerPoint storleken när Excel-arbetsboken aktiveras för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel-fönstrets storlek och OLE-ramens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE-ramen i PowerPoint-presentationen så att den matchar den totala höjden och bredden på de valda raderna och kolumnerna.
- Behåll OLE-ramens storlek konstant och skala de valda raderna och kolumnerna så att de får plats i den.

### **Skala OLE‑ramens storlek**

Detta tillvägagångssätt sätter OLE-ramens storlek så att den matchar den totala höjden och bredden på de valda raderna och kolumnerna i det inbäddade Excel-kalkylbladet.

Exemplet laddar en befintlig Excel-arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första kalkylblad med nollbaserade index. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definierar det visade området. Förhandsgranskningen renderas med 96 DPI och dess pixeldimensioner konverteras till punkter med 72 punkter per tum. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) bäddar in den modifierade arbetsboken i en ram med dessa mått. Förhandsgranskningen tilldelas via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) för att ersätta platshållaren "EMBEDDED OLE OBJECT" i den sparade presentationen.

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

// Ange den visade storleken när arbetsboksfilen används som ett OLE-objekt i PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Hämta bredd och höjd på OLE-bilden i punkter.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Vi måste använda den modifierade arbetsboken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Lägg till OLE-bilden till presentationens resurser.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Skapa OLE-objektets ram.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Förhandsgranskningshjälpen ställer in [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) till det valda området och tar bort marginaler, sidhuvuden och sidfötter. Med [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) aktiverat renderar [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) området som en PNG-bild. Hjälpen returnerar en ny inmatningsström som innehåller PNG-bilden, placerad i början för användning i presentationen.

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

Detta tillvägagångssätt skalar höjderna på de valda raderna och breddarna på de valda kolumnerna så att de matchar en anpassad OLE-ramstorlek.

Exemplet laddar en befintlig Excel-arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första kalkylblad med nollbaserade index. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definierar det visade området, och hjälpen nedan skalar det området för att passa en ram som är 400 punkter bred och 100 punkter hög. Efter att den modifierade arbetsboken har sparats till en ström bäddar [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) in den med den angivna storleken. En förhandsgranskning renderad med 96 DPI tilldelas via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), så den sparade presentationen visar de valda cellerna istället för standardplatshållaren.

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

// Ange den visade storleken när arbetsboksfilen används som ett OLE-objekt i PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala cellområdet för att passa ramens storlek.
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

// Skapa OLE-objektets ram.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Skalningshjälpen beräknar separata bredd- och höjdförhållanden för det valda området, och bevarar de relativa bredden på dess kolumner samt den relativa höjden på dess rader. Den konverterar de beräknade dimensionerna från punkter till tum innan de tillämpas med [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) och [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Det valda området måste ha en icke‑noll bredd och höjd.

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

Denna förhandsgranskningshjälp renderar det omformade området med [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Den begränsar [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) till det området, tar bort marginaler, sidhuvuden och sidfötter och returnerar en PNG-ström placerad i början.

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

{{% alert color="info" title="Note" %}}

Det finns två tillvägagångssätt för att åtgärda problemet med kalkylbladets storleksändring. Välj det tillvägagångssätt som bäst passar dina krav och ditt användningsfall. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för storleken på OLE-objektets ram i denna lösning.

{{% /alert %}}

## **Vanliga frågor**

**Varför ändrar ett inbäddat Excel-kalkylblad storlek när det aktiveras för första gången i PowerPoint?**

Detta sker eftersom Excel försöker behålla det ursprungliga fönsterstorleken vid aktivering, medan OLE-objektets ram i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bevara bildförhållandet, vilket kan leda till storleksändring.

**Är det möjligt att helt förhindra detta storleksändringsproblem?**

Ja. Genom att skala OLE-ramen så att den passar Excel‑cellområdets storlek eller genom att skala cellområdet för att passa önskad OLE‑ramstorlek kan du förhindra oönskad storleksändring.

**Vilken skalningsmetod bör jag använda, OLE‑ramskalning eller cellområdesskalning?**

Välj **OLE‑ramskalning** om du vill behålla de ursprungliga Excel‑rad‑ och kolumnstorlekarna. Välj **cellområdesskalning** om du vill ha en fast storlek på OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer skapade från mallar och från grunden.

**Finns det någon gräns för OLE‑ramens storlek när dessa metoder används?**

Nej. Du kan göra OLE‑objektets ram hur stor du vill så länge du anger skalan på lämpligt sätt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta en ögonblicksbild av det önskade Excel‑cellområdet och använda den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Skapa ett Excel-diagram och bädda in det i en presentation som ett OLE-objekt](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Uppdatera OLE-objekt automatiskt med ett MS PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)