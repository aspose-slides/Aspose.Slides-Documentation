---
title: Munkalap átméretezés megoldása
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
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek konzisztens megtartására – skálázza a keretet vagy a munkalapot – a PPT és PPTX formátumokban."
---
{{% alert color="info" title="Note" %}}

Az Aspose komponensekkel PowerPoint‑prezentációba beágyazott OLE‑objektumként megjelenő Excel‑munkalapok az első aktiválásuk után váratlanul átméreteződhetnek. Ez a viselkedés észrevehető vizuális különbséget okoz az OLE‑objektum aktiválás előtti és utáni állapota között. Ez a cikk ismerteti a problémát, és két megoldást mutat be.

{{% /alert %}}

## **Háttér**

A [OLE kezelése](/slides/hu/java/manage-ole/) című cikkben bemutattuk, hogyan lehet OLE‑keretet hozzáadni egy PowerPoint‑prezentációhoz az Aspose.Slides for Java használatával. A [objektum előnézeti probléma](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/) kezelésére a kiválasztott munkalap‑rész képét rendeltük az OLE‑objektumkerethez. A kimeneti prezentációban, ha duplán kattint a munkalap‑képet megjelenítő OLE‑objektumkeretre, az Excel‑munkafüzet aktiválódik. A végfelhasználó a tényleges Excel‑munkafüzetben a kívánt módosításokat elvégezheti, majd a diára visszatérhet a aktivált Excel‑munkafüzeten kívülre kattintva. Az OLE‑objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára. Az átméretezés mértéke az OLE‑objektumkeret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiválásakor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE‑objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat részeként a megfelelő arányokat megőrizze. Az átméretezés az Excel‑ablak mérete és az OLE‑objektumkeret mérete és pozíciója közötti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési hatás elkerülésére.

- Átméretezni az OLE‑keretet a PowerPoint‑prezentációban, hogy megegyezzen a kiválasztott sorok és oszlopok teljes magasságával és szélességével.
- Az OLE‑keret méretét állandóan tartani, és a kiválasztott sorok és oszlopok méretét úgy skálázni, hogy beleférjenek.

### **OLE keret méretének skálázása**

Ez a megközelítés az OLE‑keret méretét úgy állítja be, hogy megegyezzen a beágyazott Excel‑munkalapban kiválasztott sorok és oszlopok teljes magasságával és szélességével.

A példa egy meglévő Excel‑munkafüzetet tölt be, és a nullától indexelt első 10 sort és 13 oszlopot választja ki az első munkalapon. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiálja a megjelenített tartományt. Az előnézet 96 DPI‑n renderelődik, pixelméreteit pedig 72 pont per hüvelyk alapján pontokra konvertálja. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) a módosított munkafüzetet beágyazza egy keretbe ezekkel a méretekkel. Az előnézetet a [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) segítségével rendeli hozzá, hogy a mentett prezentációban a "EMBEDDED OLE OBJECT" helyőrzőt lecserélje.

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

// Állítsa be a megjelenített méretet, amikor a munkafüzetfájl OLE objektumként van használva a PowerPointban.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Szerezze meg az OLE kép szélességét és magasságát pontban.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Használnunk kell a módosított munkafüzetet.
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

Az előnézeti segédfüggvény a [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-)‑t állítja a kiválasztott tartományra, és eltávolítja a margókat, fejléceket és lábléceket. A [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) engedélyezése esetén a [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) a tartományt PNG‑képként rendereli. A segédfüggvény egy új bemeneti streamet ad vissza a PNG‑képpel, amely a kezdeténél van pozícionálva a prezentációban való használathoz.

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

Ez a megközelítés a kiválasztott sorok magasságát és a kiválasztott oszlopok szélességét úgy skálázza, hogy egy egyéni OLE‑keret méretéhez illeszkedjen.

A példa egy meglévő Excel‑munkafüzetet tölt be, és a nullától indexelt első 10 sort és 13 oszlopot választja ki az első munkalapon. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiálja a megjelenített tartományt, a lenti segédfüggvény pedig ezt a tartományt 400 pont széles és 100 pont magas keretbe illeszti. A módosított munkafüzetet áramlásba mentve a [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) a megadott méretben ágyazza be. Az előnézet, amely 96 DPI‑n renderelődik, a [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) segítségével kerül hozzárendelésre, így a mentett prezentáció a kiválasztott cellákat jeleníti meg az alapértelmezett helyőrző helyett.

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

// Állítsa be a megjelenített méretet, amikor a munkafüzetfájl OLE objektumként van használva a PowerPointban.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skálázza a cellatartományt, hogy illeszkedjen a keret méretéhez.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Használnunk kell a módosított munkafüzetet.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
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

A skálázó segédfüggvény külön szélesség‑ és magasságrátát számít a kiválasztott tartományra, megőrizve az oszlopok relatív szélességét és a sorok relatív magasságát. A kiszámított dimenziókat pontból hüvelykre konvertálja, mielőtt a [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) és a [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) hívásokkal beállítaná. A kiválasztott tartománynak nem nullás szélességgel és magassággal kell rendelkeznie.

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

Ez a előnézeti segédfüggvény a [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) használatával rendereli a méretezett tartományt. A [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) csak erre a tartományra korlátozza, eltávolítja a margókat, fejléceket és lábléceket, majd egy PNG‑streamet ad vissza, amely a kezdeténél van pozícionálva.

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

## **Következtetés**
{{% alert color="info" title="Note" %}}

Két megközelítés létezik a munkalap‑átméretezési probléma megoldására. Válassza ki azt, amelyik a legjobban illeszkedik az igényeihez és felhasználási esetéhez. Mindkét módszer ugyanúgy működik, legyen szó sablonból vagy a semmiből létrehozott prezentációról. Emellett ebben a megoldásban nincs korlátozás az OLE‑objektumkeret méretére vonatkozóan.

{{% /alert %}}

## **GYIK**

**Miért változik méret szerint egy beágyazott Excel‑munkalap, amikor először aktiválják a PowerPointban?**  
Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretét aktiváláskor, míg a PowerPoint‑ban az OLE‑objektumkeretnek saját méretei vannak. A két alkalmazás egyezteti a méreteket a megfelelő képarány megtartása érdekében, ami átméretezést eredményezhet.

**Lehetséges-e teljesen megelőzni ezt a méretezési problémát?**  
Igen. Az OLE‑keret skálázásával a Excel‑cellatartomány méretéhez, vagy a cellatartomány skálázásával a kívánt OLE‑keret méretéhez elkerülhető a nemkívánatos átméretezés.

**Melyik skálázási módszert válasszam, OLE‑keret skálázás vagy cellatartomány skálázás?**  
Válassza az **OLE‑keret skálázását**, ha az eredeti Excel‑sor- és oszlopszélességeket szeretné megtartani. Válassza a **cellatartomány skálázását**, ha fix méretű OLE‑keretet kíván a prezentációban.

**Működnek ezek a megoldások, ha a prezentáció sablonon alapul?**  
Igen. Mindkét megoldás működik sablonból vagy a semmiből létrehozott prezentációk esetén.

**Van-e limit az OLE‑keret méretére vonatkozóan ezekkel a módszerekkel?**  
Nem. Az OLE‑objektumkeret bármilyen méretű lehet, amíg a skálázást megfelelően beállítja.

**Létezik-e mód a "EMBEDDED OLE OBJECT" helyőrző szöveg elkerülésére a PowerPointban?**  
Igen. A cél Excel‑cellatartomány pillanatfelvételét beállítva OLE‑keret helyőrzőképként, egy egyedi előnézeti képet jeleníthet meg az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel‑diagram létrehozása és beágyazása a prezentációba OLE‑objektumként](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objektumok automatikus frissítése MS PowerPoint‑kiegészítővel](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)