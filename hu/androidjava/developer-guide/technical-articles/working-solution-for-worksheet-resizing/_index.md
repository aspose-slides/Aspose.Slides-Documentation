---
title: Működő megoldás a munkalap átméretezésére
type: docs
weight: 20
url: /hu/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezés
- Excel
- munkalap
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Az Excel munkalap OLE átméretezésének javítása a prezentációkban: két módszer az objektumkeretek konzisztens megtartására – a keret vagy a lap skálázása – a PPT és PPTX formátumok között."
---
{{% alert color="info" title="Megjegyzés" %}}

Az Aspose összetevőkkel PowerPoint prezentációba beágyazott OLE objektumként megjelenő Excel munkalapok első aktiválásuk után váratlanul átméreteződhetnek. Ez a viselkedés megjegyezhető vizuális különbséget eredményez az OLE objektum aktiválás előtti és utáni állapota között. Ez a cikk ismerteti a problémát, és két megoldást mutat be.

{{% /alert %}}

## **Háttér**

Az [OLE kezelése](/slides/hu/androidjava/manage-ole/) című cikkben bemutattuk, hogyan lehet OLE keretet hozzáadni egy PowerPoint prezentációhoz az Aspose.Slides for Android Java használatával. Az [objektum előnézeti probléma](/slides/hu/androidjava/object-preview-issue-when-adding-oleobjectframe/) megoldásához a kiválasztott munkalap területének képét rendeltük az OLE objektumkerethez. A kimeneti prezentációban, ha duplán kattintunk a munkalap képet megjelenítő OLE objektumkeretre, aktiválódik az Excel munkafüzet. A végfelhasználók tetszőleges módosításokat végezhetnek a tényleges Excel munkafüzeten, majd a diához visszatérhetnek az aktivált Excel munkafüzeten kívülre kattintva. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diához. Az átméretezési arány a OLE objektumkeret és a beágyazott Excel munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megőrizni eredeti méretét. Ezzel szemben az OLE objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat részeként megőrizze a helyes arányokat. Az átméretezés a Excel ablakmérete és az OLE objektumkeret mérete‑pozíciója közti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás van az átméretezési hatás elkerülésére.

- Skálázza az OLE keretet a PowerPoint prezentációban, hogy megegyezzen a kiválasztott sorok és oszlopok teljes magasságával és szélességével.
- Tartsa állandó méretűnek az OLE keretet, és skálázza a kiválasztott sorokat és oszlopokat, hogy beleférjenek.

### **OLE keret méretének skálázása**

Ez a megközelítés az OLE keret méretét úgy állítja be, hogy az megegyezzen a beágyazott Excel munkalap kiválasztott sorainak és oszlopainak teljes magasságával és szélességével.

A példa betölti egy meglévő Excel munkafüzetet, és kiválasztja az első 10 sort és 13 oszlopot az első munkalapján nulla‑alapú indexekkel. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiálja a megjelenített tartományt. Az előnézet 96 DPI‑n kerül renderelésre, és pixeldimenzióit 72 pont per hüvelyk alapján átszámítja pontokra. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) beágyazza a módosított munkafüzetet egy olyan keretbe, amelynek méretei ezek. Az előnézetet a [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) segítségével rendeli hozzá, hogy a mentett prezentációban a "EMBEDDED OLE OBJECT" helyőrző helyett ez a kép jelenjen meg.

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

// Állítsa be a megjelenített méretet, amikor a munkafájl OLE objektumként van használva a PowerPointban.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Szerezze meg az OLE kép szélességét és magasságát pontban.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Szükség van a módosított munkafájl használatára.
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

Az előnézetsegéd a [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) segítségével a kiválasztott tartományra állítja be a nyomtatási területet, és eltávolítja a margókat, fejléceket és lábléceket. A [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) engedélyezésével a [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) a tartományt PNG‑képként rendereli. A segédprogram egy új bemeneti streamet ad vissza, amely a PNG‑képet a kezdeténél tartja a prezentációban való felhasználáshoz.

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

Ez a megközelítés a kiválasztott sorok magasságát és oszlopok szélességét skálázza, hogy egy egyéni OLE keretmérettel egyezzen.

A példa betölti egy meglévő Excel munkafüzetet, és kiválasztja az első 10 sort és 13 oszlopot az első munkalapján nulla‑alapú indexekkel. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiálja a megjelenített tartományt, és az alábbi segédprogram ezt a tartományt egy 400 pont széles és 100 pont magas keretre méretezi. A módosított munkafüzet streambe mentése után a [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) a megadott mérettel ágyazza be. A 96 DPI‑n renderelt előnézet a [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) segítségével kerül hozzárendelésre, így a mentett prezentáció a kiválasztott cellákat mutatja az alapértelmezett helyőrző helyett.

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

// Állítsa be a megjelenített méretet, amikor a munkafájl OLE objektumként van használva a PowerPointban.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skálázza a cellatartományt, hogy illeszkedjen a keret méretéhez.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Szükség van a módosított munkafájl használatára.
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

A skálázó segédprogram külön szélességi és magassági arányokat számol ki a kiválasztott tartományra, megőrizve az oszlopok relatív szélességét és a sorok relatív magasságát. A kiszámított méreteket pontból hüvelykre konvertálja, mielőtt a [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) és a [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) metódusokkal alkalmazná. A kiválasztott tartománynak nem lehet nulla szélességű vagy magasságú.

```java
/**
 * @param width     A cellatartomány várt szélessége pontban.
 * @param height    A cellatartomány várt magassága pontban.
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

Ez a előnézetsegéd a [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) segítségével rendereli az átméretezett tartományt. A [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) csak erre a tartományra korlátozza a nyomtatási területet, eltávolítja a margókat, fejléceket és lábléceket, majd egy PNG‑streamet ad vissza, amely a kezdeténél áll.

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

{{% alert color="info" title="Megjegyzés" %}}

Két megközelítés létezik a munkalap átméretezési probléma megoldására. Válassza ki a legmegfelelőbbet az igényei és felhasználási eset szerint. Mindkét módszer egyformán működik, akár sablonból, akár üresen hoz létre prezentációt. Emellett nincs korlátozás az OLE objektumkeret méretére ebben a megoldásban.

{{% /alert %}}

## **GYIK**

**Miért változik méretben egy beágyazott Excel munkalap, amikor először aktiválják a PowerPointban?**

Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretét aktiváláskor, míg a PowerPointban az OLE objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányokat, ami átméretezést eredményezhet.

**Lehet-e teljesen megakadályozni ezt az átméretezési problémát?**

Igen. Az OLE keret skálázásával a Excel cellatartomány méretéhez, vagy a cellatartomány skálázásával a kívánt OLE keretmérethez megakadályozható a nem kívánt átméretezés.

**Melyik skálázási módszert válasszam, OLE keret skálázás vagy cellatartomány skálázás?**

Válassza az **OLE keret skálázását**, ha meg akarja tartani az eredeti Excel sor‑ és oszlopszélességeket. Válassza a **cellatartomány skálázását**, ha fix méretű OLE keretet szeretne a prezentációjában.

**Működnek-e ezek a megoldások, ha a prezentáció sablonon alapul?**

Igen. Mindkét megoldás működik sablonból és üresen létrehozott prezentációk esetén egyaránt.

**Van-e korlátozás az OLE keret méretére e módszerekkel?**

Nincs. Az OLE objektumkeretet bármilyen méretűre beállíthatja, amíg a skálázást megfelelően elvégzi.

**Létezik-e mód a "EMBEDDED OLE OBJECT" helyőrző szöveg elkerülésére a PowerPointban?**

Igen. A cél Excel cellatartományról készített pillanatképet beállíthatja az OLE keret helyőrzőképéül, így egy egyedi előnézeti képet jeleníthet meg az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel diagram létrehozása és OLE objektumként beágyazása prezentációba](/slides/hu/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE objektumok automatikus frissítése MS PowerPoint kiegészítővel](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)