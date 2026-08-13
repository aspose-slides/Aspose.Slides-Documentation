---
title: Működő megoldás a munkalap átméretezésére
type: docs
weight: 20
url: /hu/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezése
- Excel
- munkalap
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek konzisztens megtartására – a keret vagy a lap skálázása – a PPT és PPTX formátumokban."
---
{{% alert color="info" %}}
Megfigyeltük, hogy az Aspose komponenseken keresztül PowerPoint‑prezentációba beágyazott OLE‑objektumként megjelenő Excel‑munkalapok az első aktiválás után meghatározatlan méretarányra vannak átméretezve. Ez a viselkedés észrevehető vizuális különbséget okoz a prezentációban az OLE‑objektum aktiválás előtti és utáni állapota között. Részletesen kivizsgáltuk a problémát, és megoldást nyújtottunk, amely ebben a cikkben olvasható.
{{% /alert %}}

## **Háttér**

Az [Manage OLE](/slides/hu/androidjava/manage-ole/) cikkben bemutattuk, hogyan adhatunk hozzá egy OLE‑keretet egy PowerPoint‑prezentációhoz az Aspose.Slides for Android via Java segítségével. Az [object preview issue](/slides/hu/androidjava/object-preview-issue-when-adding-oleobjectframe/) megoldásaként a kiválasztott munkalap területének képét rendeltük az OLE‑objektum kerethez. A kimeneti prezentációban, ha duplán kattintunk az OLE‑objektum keretre, amely a munkalap képet mutatja, aktiválódik az Excel‑könyv. A végfelhasználók a tényleges Excel‑könyvben tetszőleges módosítást végezhetnek, majd az aktivált Excel‑könyvön kívülre kattintva visszatérnek a diára. Az OLE‑objektum keret mérete megváltozik, amikor a felhasználó visszatér a diára. Az átméretezési tényező a keret és a beágyazott Excel‑könyv méretétől függ.

## **Átméretezés oka**

Mivel az Excel‑könyvnek saját ablakkészlete van, az első aktiváláskor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE‑objektum keretnek saját mérete van. A Microsoft szerint, amikor az Excel‑könyv aktiválva van, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat részeként a megfelelő arányokat fenntartsák. Az átméretezés az Excel‑ablak mérete és az OLE‑objektum keret mérete‑pozíciója közötti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik a méretezési hatás elkerülésére.

- Méretezze az OLE‑keretet a PowerPoint‑prezentációban, hogy megegyezzen a kívánt sor- és oszlopszám magasságával és szélességével az OLE‑keretben.
- Tartsa állandó méretben az OLE‑keretet, és méretezze át a résztvevő sorok és oszlopok méretét, hogy illeszkedjenek a kiválasztott OLE‑keret méretéhez.

### **OLE‑keret méretének méretezése**

Ebben a megközelítésben megtanuljuk, hogyan állítható be a beágyazott Excel‑könyv OLE‑keretének mérete úgy, hogy az egyezzen az Excel‑munkalapban részt vevő sorok és oszlopok összesített méretével.

Tegyük fel, hogy van egy sablon Excel‑lapunk, amelyet OLE‑keretként szeretnénk hozzáadni a prezentációhoz. Ebben az esetben az OLE‑objektum keret méretét először a könyvben részt vevő sorok magasságának és oszlopok szélességének összegzéséből számítjuk ki. Ezután beállítjuk az OLE‑keret méretét erre a kiszámított értékre. Az OLE‑kerethez a PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében egy képet is rögzítünk a könyvben kívánt sor- és oszloptartományokról, és azt állítjuk be OLE‑keret képként.

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

// Állítsa be a megjelenített méretet, amikor a munkafüzet-fájlt OLE objektumként használják a PowerPointban.
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

### **Cellatartomány méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan skálázhatók a részt vevő sorok magasságai és oszlopok szélessége, hogy egy egyéni OLE‑keret méretéhez illeszkedjenek.

Tegyük fel, hogy van egy sablon Excel‑lapunk, amelyet OLE‑keretként szeretnénk a prezentációhoz adni. Ebben az esetben beállítjuk az OLE‑keret méretét, és skálázzuk a sorok és oszlopok méretét, amelyek részt vesznek az OLE‑keret területében. Ezután a könyvet egy streambe mentjük, hogy alkalmazzuk a változtatásokat, és bájt‑tömbbé konvertáljuk az OLE‑kerethez való hozzáadás céljából. Az OLE‑kerethez a PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében egy képet is rögzítünk a könyvben kívánt sor- és oszloptartományokról, és azt állítjuk be OLE‑keret képként.

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

// Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják a PowerPointban.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skálázza a cellatartományt, hogy illeszkedjen a keret méretéhez.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// A módosított munkafüzetet kell használnunk.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Hozza létre az OLE objektum keretet.
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

## **Összegzés**

{{% alert color="info" %}} 
Két megközelítés létezik a munkalap átméretezési problémájának megoldására. A megfelelő megközelítés kiválasztása a konkrét követelményektől és felhasználási esettől függ. Mindkét módszer egyformán működik, függetlenül attól, hogy a prezentációk sablonból vagy a semmiből készülnek. Továbbá ennek a megoldásnak nincs korláta az OLE‑objektum keret méretére. 
{{% /alert %}}

## **GYIK**

### Miért változik méretben egy beágyazott Excel‑munkalap az első PowerPoint‑aktiváláskor?
Ez azért történik, mert az Excel az aktiváláskor megpróbálja megtartani az eredeti ablakméretet, míg a PowerPoint‑ban az OLE‑objektum keretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányt, ami az átméretezést eredményezheti.

### Lehetséges-e teljesen megakadályozni ezt az átméretezési problémát?
Igen. Az OLE‑keret az Excel cellatartomány méretéhez igazításával vagy a cellatartomány kívánt OLE‑keret méretéhez való skálázásával megakadályozhatók a nem kívánt átméretezések.

### Melyik skálázási módszert válasszam, OLE‑keret skálázást vagy cellatartomány skálázást?
Válassza az **OLE‑keret skálázást**, ha az eredeti Excel‑sor‑ és oszlopsméreteket kívánja megtartani. Válassza a **cellatartomány skálázást**, ha a prezentációban egy rögzített OLE‑keret méretet szeretne.

### Működnek-e ezek a megoldások, ha a prezentációm egy sablonon alapul?
Igen. Mindkét megoldás működik sablonból vagy a semmiből készült prezentációk esetén egyaránt.

### Van-e korlátozás az OLE‑keret méretére e módszerekkel?
Nem. Az OLE‑objektum keretet bármilyen méretűre állíthatja, ha megfelelően beállítja a skálát.

### Van mód elkerülni a „EMBEDDED OLE OBJECT” helyőrző szöveget a PowerPointban?
Igen. A célzott Excel‑cellatartományról készített pillanatkép OLE‑keret helyőrzőképként való beállításával egy egyéni előnézeti képet jeleníthet meg a alapértelmezett helyőrző helyett.