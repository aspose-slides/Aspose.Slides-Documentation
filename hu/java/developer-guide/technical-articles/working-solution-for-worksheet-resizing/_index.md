---
title: Működő megoldás a munkalap méretezéséhez
type: docs
weight: 20
url: /hu/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezés
- Excel
- munkalap
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Javítja az Excel munkalap OLE méretezését a prezentációkban: két mód a objektumkeretek következetes megtartására – skálázzuk a keretet vagy a munkalapot – a PPT és PPTX formátumokban."
---
{{% alert color="info" %}}

Megfigyeltük, hogy az Excel munkalapok, amelyeket OLE objektumként ágyazunk be egy PowerPoint‑prezentációba az Aspose komponensek segítségével, az első aktiválás után ismeretlen méretarányra méreteződnek. Ez a viselkedés észrevehető vizuális különbséget okoz a prezentációban az OLE objektum elő- és utóaktiválási állapota között. Részletesen vizsgáltuk a problémát, és megoldást nyújtottunk, amelyet ebben a cikkben ismertetünk.

{{% /alert %}}

## **Háttér**

Az [Manage OLE](/slides/hu/java/manage-ole/) cikkben bemutattuk, hogyan adhatunk OLE keretet egy PowerPoint‑prezentációhoz az Aspose.Slides for Java segítségével. A [object preview issue](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/) megoldásaként egy képet rendeltünk a kijelölt munkalap területéről az OLE objektumkerethez. A kimeneti prezentációban, ha duplán kattintasz az OLE objektumkeretre, amely a munkalap képet jeleníti, az Excel munkafüzet aktiválódik. A végfelhasználó módosíthatja az Excel‑munkafüzetet, majd a aktivált Excel‑ablakon kívülre kattintva visszatérhet a diára. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára. A méretezési tényező a OLE objektumkeret és a beágyazott Excel‑munkafüzet méretétől függ.

## **A méretezés oka**

Mivel az Excel‑munkafüzet saját ablakmérettel rendelkezik, az első aktiváláskor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat során a helyes arányokat biztosítsák. A méretezés az Excel‑ablak és az OLE objektumkeret méretének és pozíciójának eltérései alapján történik.

## **Működő megoldás**

Két lehetséges megoldás van a méretezési hatás elkerülésére.

- Méretezze az OLE keretet a PowerPoint‑prezentációban úgy, hogy az megfeleljen a kívánt sor- és oszlopszám magasságának és szélességének.
- Tartsa állandó méretűnek az OLE keretet, és skálázza a résztvevő sorok és oszlopok méretét úgy, hogy illeszkedjenek a kiválasztott OLE keret méretéhez.

### **OLE keret méretezése**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel‑munkafüzet OLE keretméretét úgy, hogy az egyezzen az Excel‑munkalap résztvevő sorainak és oszlopainak összesített méretével.

Tegyük fel, hogy van egy sablon Excel‑lapunk, és OLE keretként szeretnénk hozzáadni egy prezentációhoz. Ebben az esetben az OLE objektumkeret méretét először a munkafüzet résztvevő sorainak magasságai és oszlopainak szélességei alapján számítjuk ki. Ezután a kiszámított értéknek megfelelően állítjuk be az OLE keret méretét. Az OLE kerethez a PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében egy képet is rögzítünk a munkafüzet kívánt sor‑ és oszloptartományairól, és azt állítjuk be OLE keret képként.

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

// Állítsa be a megjelenített méretet, amikor a munkafájl OLE objektumként kerül felhasználásra a PowerPointban.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Szerezze meg az OLE kép szélességét és magasságát pontban.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// A módosított munkafájlt kell használnunk.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Hozza létre az OLE objektumkeretet.
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

### **Cellatartomány méretezése**

Ebben a megközelítésben megtanuljuk, hogyan skálázzuk a résztvevő sorok magasságát és oszlopok szélességét úgy, hogy egy egyéni OLE keretméretnek megfelelőek legyenek.

Tegyük fel, hogy van egy sablon Excel‑lapunk, és OLE keretként szeretnénk hozzáadni egy prezentációhoz. Ebben az esetben beállítjuk az OLE keret méretét, majd skálázzuk a tartományba eső sorok és oszlopok méretét. Ezután a munkafüzetet stream‑be mentjük a módosítások alkalmazásához, majd byte‑tömbbé konvertáljuk, hogy hozzáadhassuk az OLE kerethez. Az OLE kerethez a PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében egy képet is rögzítünk a munkafüzet kívánt sor‑ és oszloptartományairól, és azt állítjuk be OLE keret képként.

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

// Állítsa be a megjelenített méretet, amikor a munkafájl OLE objektumként kerül felhasználásra a PowerPointban.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skálázza a cellatartományt, hogy illeszkedjen a keret méretéhez.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// A módosított munkafájlt kell használnunk.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Hozza létre az OLE objektumkeretet.
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
 * @param width     A cellatartomány várható szélessége pontban.
 * @param height    A cellatartomány várható magassága pontban.
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

## **Összefoglalás**

{{% alert color="info" %}} 

Két megközelítés létezik a munkalap méretezési problémájának megoldására. A megfelelő megközelítés kiválasztása a konkrét követelményektől és felhasználási esettől függ. Mindkét módszer ugyanúgy működik, legyen szó sablonból vagy az elejétől felépített prezentációról. Emellett ebben a megoldásban nincs limit az OLE objektumkeret méretére.

{{% /alert %}}

## **GYIK**

### Miért változik méret szerint egy beágyazott Excel‑munkalap első aktiválásakor a PowerPoint‑ban?

Az Excel megpróbálja megtartani az eredeti ablakméretét aktiváláskor, míg a PowerPoint‑ban az OLE objektumkeret saját méretekkel rendelkezik. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányt, ami a méretezést okozza.

### Lehet-e teljesen elkerülni ezt a méretezési problémát?

Igen. Az OLE keret méretezésével az Excel‑cellatartomány méretéhez vagy a cellatartomány méretezésével az kívánt OLE keretmérethez, megakadályozható a nem kívánt méretezés.

### Melyik méretezési módszert válasszam, az OLE keret méretezését vagy a cellatartomány méretezését?

Válaszd az **OLE keret méretezését**, ha az eredeti Excel‑sor‑ és oszlops méreteket szeretnéd megtartani. Válaszd a **cellatartomány méretezését**, ha fix méretű OLE keretet kívánsz a prezentációban.

### Működnek ezek a megoldások, ha a prezentáció egy sablonon alapul?

Igen. Mindkét megoldás működik sablonból és az elejétől felépített prezentációk esetén is.

### Van korlátozás az OLE keret méretére vonatkozóan ezen módszerek használatakor?

Nem. Az OLE objektumkeretet bármilyen méretűre beállíthatod, amíg megfelelően skálázod.

### Van mód elkerülni a „EMBEDDED OLE OBJECT” helyőrző szöveget a PowerPoint‑ban?

Igen. Az Excel‑cellatartomány pillanatfelvételét beállítva OLE keret helyőrzőképének, saját előnézeti képet jeleníthetsz meg az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/hu/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)