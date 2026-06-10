---
title: Működő megoldás a munkalap átméretezéséhez
type: docs
weight: 20
url: /hu/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezése
- Excel
- munkalap
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek egységességének megtartására—a keret vagy a lap méretezésével—mind a PPT, mind a PPTX formátumokban."
---
{{% alert color="primary" %}}
Azt tapasztaltuk, hogy az Aspose komponensek által PowerPoint‑prezentációba beágyazott OLE‑objektumként megjelenő Excel‑munkalapok az első aktiválás után ismeretlen méretarányra kerülnek átméretezésre. Ez a viselkedés a OLE‑objektum aktiválás előtti és utáni állapota között nyilvánvaló vizuális különbséget eredményez a prezentációban. Részletesen kivizsgáltuk a problémát, és megoldást nyújtottunk, amelyet ebben a cikkben ismertetünk.
{{% /alert %}}

## **Háttér**

Az [Manage OLE](/slides/hu/java/manage-ole/) cikkben bemutattuk, hogyan adhatunk OLE‑keretet egy PowerPoint‑prezentációhoz az Aspose.Slides for Java használatával. A [object preview issue](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/) megoldásaként egy képet rendeltünk a kiválasztott munkalap területéről az OLE‑objektum kerethez. A kimeneti prezentációban, ha duplán kattintunk a munkalap képét mutató OLE‑objektum keretre, az Excel‑munkafüzet aktiválódik. A felhasználó a tényleges Excel‑munkafüzetben a kívánt módosításokat elvégezheti, majd a aktivált Excel‑munkafüzeten kívülre kattintva visszatér a diára. A felhasználó visszatérésekor az OLE‑objektum keret mérete megváltozik. Az átméretezés mértéke az OLE‑objektum keret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzettel saját ablakmérete van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Ezzel szemben az OLE‑objektum keretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat részeként helyes arányokat biztosítsanak. Az átméretezés az Excel‑ablak mérete és az OLE‑objektum keret mérete és pozíciója közti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési effektus elkerülésére.

- Méretezze az OLE‑keretet a PowerPoint‑prezentációban úgy, hogy a kívánt sor- és oszlopszám magasságával és szélességével megegyezzen.
- Tartsa állandóan az OLE‑keret méretét, és méretezze a részt vevő sorok és oszlopok méretét úgy, hogy illeszkedjenek a kiválasztott OLE‑keret méretébe.

### **Az OLE‑keret méretezése**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be az beágyazott Excel‑könyv OLE‑keretének méretét úgy, hogy megegyezzen a munkalapban részt vevő sorok és oszlopok összegzett méretével.

Tegyük fel, hogy van egy sablon Excel‑lapunk, és azt OLE‑keretként szeretnénk hozzáadni a prezentációhoz. Ebben az esetben az OLE‑objektum keret méretét először a könyvben részt vevő sorok magasságának és oszlopok szélességének összegzése alapján számítjuk ki. Ezután a OLE‑keret méretét erre a kiszámított értékre állítjuk. Az PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében egy képet is készítünk a könyvben kívánt sor- és oszloptartományokról, és azt állítjuk be OLE‑keret képként.

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

// Szerezze meg az OLE-kép szélességét és magasságát pontban.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// A módosított munkafüzetet kell használnunk.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adja hozzá az OLE-képet a prezentáció erőforrásaihoz.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Hozza létre az OLE-objektumkeretet.
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

### **A cellatartomány méretének méretezése**

Ebben a megközelítésben megtanuljuk, hogyan méretezzük a részt vevő sorok magasságát és oszlopok szélességét úgy, hogy egy egyedi OLE‑keretméretnek feleljenek meg.

Tegyük fel, hogy van egy sablon Excel‑lapunk, és azt OLE‑keretként szeretnénk hozzáadni a prezentációhoz. Ebben az esetben beállítjuk az OLE‑keret méretét, és méretezzük a keret területébe tartozó sorok és oszlopok méretét. Ezután a könyvet egy stream‑be mentjük a módosítások alkalmazásához, majd byte‑tömbbé konvertáljuk, hogy az OLE‑kerethez hozzáfűzhessük. Az PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében egy képet is készítünk a könyvben kívánt sor- és oszloptartományokról, és azt állítjuk be OLE‑keret képként.

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

// Méretezzük a cellatartományt, hogy illeszkedjen a keret méretéhez.
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

{{% alert color="primary" %}} 
Két megközelítés létezik a munkalap átméretezési problémájának megoldására. A megfelelő megközelítés kiválasztása a konkrét követelményektől és felhasználási esettől függ. Mindkét módszer egyformán működik, függetlenül attól, hogy a prezentáció sablonból vagy az elejétől készül. Továbbá ebben a megoldásban nincs korlátozva az OLE‑objektum keret mérete. 
{{% /alert %}}

## **GYIK**

**Miért változik méretben egy beágyazott Excel‑munkalap, amikor először aktiválják PowerPointban?**  
Ez azért történik, mert az Excel az aktiváláskor megpróbálja megtartani az eredeti ablakméretét, míg a PowerPointban az OLE‑objektum keretnek saját méretei vannak. A PowerPoint és az Excel egyezteti a méretet a helyes képarány fenntartása érdekében, ami az átméretezést eredményezheti.

**Lehetséges-e teljes mértékben megakadályozni ezt az átméretezési problémát?**  
Igen. Az OLE‑keret méretezésével úgy, hogy illeszkedjen az Excel‑cellatartomány méretéhez, vagy a cellatartomány méretezésével úgy, hogy illeszkedjen a kívánt OLE‑keret méretéhez, elkerülhető a nem kívánt átméretezés.

**Melyik méretezési módszert kellene használnom, az OLE‑keret méretezését vagy a cellatartomány méretezését?**  
Válassza az **OLE‑keret méretezést**, ha az eredeti Excel‑sor- és oszlopszemélyiségeket szeretné megtartani. Válassza a **cellatartomány méretezést**, ha a prezentációban egy rögzített méretű OLE‑keretet szeretne.

**Működnek ezek a megoldások, ha a prezentáció sablonon alapul?**  
Igen. Mindkét megoldás működik sablonból vagy az elejétől létrehozott prezentációk esetén.

**Van korláta az OLE‑keret méretének ezeknél a módszereknél?**  
Nem. Az OLE‑objektum keretet tetszőleges méretűre állíthatja, ameddig a skálát megfelelően beállítja.

**Van mód arra, hogy elkerülje a PowerPointban megjelenő „EMBEDDED OLE OBJECT” helykitöltő szöveget?**  
Igen. A célzott Excel‑cellatartományról készített képernyőképet beállítva OLE‑keret helykitöltő képeként, egy egyéni előnézeti képet jeleníthet meg az alapértelmezett helykitöltő helyett.

## **Kapcsolódó cikkek**

[Excel-diagram létrehozása és OLE‑objektumként a prezentációba ágyazása](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objektumok automatikus frissítése MS PowerPoint‑kiegészítővel](/slides/hu/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)