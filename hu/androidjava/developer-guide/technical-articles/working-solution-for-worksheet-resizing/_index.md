---
title: Működő megoldás a munkalap átméretezéshez
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
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek egységességének biztosítására – a keret vagy a munkalap skálázásával – a PPT és PPTX formátumokban."
---
{{% alert color="primary" %}}
Megfigyeltük, hogy az Aspose komponenseken keresztül PowerPoint‑prezentációba beágyazott OLE objektumként szereplő Excel‑munkalapok az első aktiválás után ismeretlen méretarányra vannak átméretezve. Ez a viselkedés észrevehető vizuális különbséget eredményez a prezentációban az OLE objektum aktiválás előtti és utáni állapota között. Részletesen kivizsgáltuk ezt a problémát, és megoldást nyújtunk, amely ebben a cikkben található.
{{% /alert %}}

## **Háttér**

Az [OLE kezelése](/slides/hu/androidjava/manage-ole/) című cikkben bemutattuk, hogyan lehet OLE keretet hozzáadni PowerPoint‑prezentációhoz az Aspose.Slides for Android for Java használatával. Az [objektum előnézeti probléma](/slides/hu/androidjava/object-preview-issue-when-adding-oleobjectframe/) megoldásához a kiválasztott munkalap területének képét rendeltük az OLE objektumkerethez. A kimeneti prezentációban, ha duplán kattint a munkalap képet megjelenítő OLE objektumkeretre, az Excel‑munkafüzet aktiválódik. A végfelhasználók tetszőleges módosításokat végezhetnek a tényleges Excel‑munkafüzeten, majd a slide‑ra visszatérhetnek a aktivált Excel‑munkafüzeten kívül kattintva. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a slide‑ra. Az átméretezési arány az OLE objektumkeret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Átméretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Ezzel szemben az OLE objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy biztosítsák a megfelelő arányok megőrzését az beágyazási folyamat részeként. Az átméretezés a Excel‑ablak mérete és az OLE objektumkeret mérete és pozíciója közötti eltérések alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési hatás elkerülésére.

- Mérje skálázza az OLE keret méretét a PowerPoint‑prezentációban, hogy megfeleljen a kívánt sor‑ és oszlopszám magasságának és szélességének az OLE keretben.
- Tartsa állandóan az OLE keret méretét, és skálázza a résztvevő sorok és oszlopok méretét, hogy illeszkedjen a kiválasztott OLE keret méretéhez.

### **OLE keret méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan állítható be a beágyazott Excel‑munkafüzet OLE keret mérete, hogy megegyezzen a résztvevő sorok és oszlopok összegzett méretével az Excel‑munkalapon.

Tegyük fel, hogy van egy sablon Excel‑állományunk, és azt OLE keretként szeretnénk hozzáadni a prezentációhoz. Ebben a forgatókönyvben az OLE objektumkeret méretét először a munkafüzetben résztvevő sorok magasságának és oszlopok szélességének összegzett értéke alapján számítjuk ki. Ezután ezt a kiszámított értéket állítjuk be az OLE keret méretének. A PowerPointban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben kívánt sor‑ és oszloptartományok képét is elkészítjük, és azt állítjuk be OLE keret képként.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják PowerPointban.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Szerezze meg az OLE kép szélességét és magasságát pontban.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// A módosított munkafüzetet kell használnunk.
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

### **Cella tartomány méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan skálázhatók a résztvevő sorok magasságai és a résztvevő oszlopok szélessége egy egyedi OLE keret méretéhez igazodva.

Tegyük fel, hogy van egy sablon Excel‑állományunk, és azt OLE keretként szeretnénk hozzáadni a prezentációhoz. Ebben a forgatókönyvben beállítjuk az OLE keret méretét, és skálázzuk a OLE keret területébe tartozó sorok és oszlopok méretét. Ezután a munkafüzetet áramlamba mentjük a változtatások alkalmazásához, és bájt tömbbé konvertáljuk, hogy hozzáadhassuk az OLE kerethez. A PowerPointban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben kívánt sor‑ és oszloptartományok képét is elkészítjük, és azt állítjuk be OLE keret képként.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják PowerPointban.
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
 * @param width     A cellatartomány várt szélessége pontokban.
 * @param height    A cellatartomány várt magassága pontokban.
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

## **Következtetés**

{{% alert color="primary" %}} 
Két megközelítés létezik a munkalap átméretezési probléma megoldására. A megfelelő megközelítés kiválasztása a konkrét követelményektől és felhasználási esettől függ. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy a prezentációt sablonból vagy az elejétől hozzák létre. Ezenkívül nincs korlátozás az OLE objektumkeret méretére ebben a megoldásban.
{{% /alert %}}

## **GYIK**

**Miért változik a beágyazott Excel‑munkalap mérete, amikor először aktiválják PowerPointban?**

Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretet aktiváláskor, míg a PowerPointban az OLE objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet az arányok megőrzése érdekében, ami az átméretezést okozhat.

**Lehet‑e teljesen elkerülni ezt az átméretezési problémát?**

Igen. Az OLE keret skálázásával az Excel cellatartomány méretéhez, vagy a cellatartomány skálázásával a kívánt OLE keret méretéhez megakadályozható a nem kívánt átméretezés.

**Melyik skálázási módszert használjam, OLE keret skálázást vagy cellatartomány skálázást?**

Válassza az **OLE keret skálázást**, ha az eredeti Excel sor‑ és oszlopszélességeket szeretné megőrizni. Válassza a **cellatartomány skálázást**, ha a prezentációban fix OLE keret méretet szeretne.

**Működnek ezek a megoldások, ha a prezentációm sablon alapján készült?**

Igen. Mindkét megoldás működik sablonból vagy az elejétől készült prezentációk esetén.

**Van korlátja az OLE keret méretének ezen módszerek használatakor?**

Nem. Az OLE objektumkeretet tetszőleges méretűre állíthatja, amíg a skálát megfelelően beállítja.

**Van mód a PowerPointban megjelenő „EMBEDDED OLE OBJECT” helyettesítő szöveg elkerülésére?**

Igen. A cél Excel cellatartomány pillanatfelvételével, és azt OLE keret helyettesítő képének beállításával egyedi előnézeti képet jeleníthet meg az alapértelmezett helyettesítő szöveg helyett.