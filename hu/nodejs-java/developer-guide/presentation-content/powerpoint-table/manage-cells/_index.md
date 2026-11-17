---
title: Táblázatcellák kezelése prezentációkban JavaScript használatával
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/nodejs-java/manage-cells/
keywords:
- táblázatcella
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint táblázatcellák kezelése JavaScript-ben: egyesített cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for Node.js segítségével Java-n keresztül."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi a táblázatcellák elérését és módosítását a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatók a egyesített táblázatcellák, hogyan távolíthatók el a cellaszegélyek, hogyan dolgozhatunk a cellák számozásával az egyesítés vagy felosztás után, hogyan változtatható meg egy cella háttérszíne, és hogyan adhatunk képet egy táblázatcella belsejébe. A példák azt mutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezzünk be egy táblázatot egy diára, hogyan frissítsük a cella formázását a cella tulajdonságokon keresztül, és hogyan menthetjük a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulláral kezdődő indexeket használ a táblázatcellák eléréséhez a `(oszlop, sor)` sorrendben.

## **Egyesített táblázatcella azonosítása**

Az példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblázatként éri el. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) használatával azonosítja az egyesített területek celláit. Minden egyezéshez kiírja a cella koordinátáit `row;column` sorrendben, a [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), a [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), valamint a terület kezdő koordinátáit, a [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) és a [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Táblázatcella szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) objektumot, és adjon hozzá egy táblázatot az első diájához a [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) segítségével. Az oszlopszélességek, sormagasságok és a táblázat pozíciója pontokban van megadva. A példa az összes négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) beállítással állítja, így láthatatlanok.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Átlós cellaszegélyek hozzáadása**

Használja a [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) függvényt, hogy vonalat rajzoljon a bal felső saroktól a jobb alsóig, és a [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) függvényt, hogy vonalat a bal alsó saroktól a jobb felsőig. Egy átló jelölhet sarokfejlécet; mindkét átló X‑et alkothat, jelezve, hogy a cella nem alkalmazható.

Az egyes átlók egy [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) objektum. Ennek a [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) metódusában használja a [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) függvényt a [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) kiválasztásához, és színt válasszon a [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) segítségével. A vonal vastagságát pontokban állítsa be a [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) metódussal.

A példa három cellát hoz létre egy sorban: egy piros lefelé mutató átlót, egy kék felfelé mutató átlót, valamint mindkét átlót. A felső, alsó, bal és jobb cellaszegélyek változatlanok maradnak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az átló egy formázási tulajdonság, nem cellafelosztás. Minden cella egyetlen szövegkeretet tart meg, amely a [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/) segítségével érhető el; az átló mindkét oldalán lévő területeket nem lehet különállóan szerkeszteni.

![Három táblázatcella, amelyek egy piros átlót mutatnak a bal felsőtől a jobb aljáig, egy kék átlót a bal aljától a jobb felsőig, és mindkét átló X-et alkot.](diagonal-cell-borders.png)

*Balról jobbra: lefelé mutató átló (piros, 3 pt), felfelé mutató átló (kék, 5 pt), és mindkét átló.*

## **Táblázatcellák egyesítése**

Használja a [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) metódust, hogy egy téglalap alakú táblázatcella-tartományt egyetlen cellává egyesítsen. Adja meg a tartomány bal felső és jobb alsó sarkának celláit. Az utolsó argumentum szabályozza, hogy az egyesítés magában foglalhat‑e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést a tartományon belül tartja.

A példa egy 4x4‑es táblázatot hoz létre 70‑pont széles oszlopokkal és sorokkal, majd egyesíti a négy középső cellát a `(1, 1)`‑től `(2, 2)`‑ig tartó tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, míg a táblázat alaprendszere továbbra is négy oszlopból és négy sorból áll. Az egyesített cella tartalmához vagy formázásához a bal felső pozícióját használja: ebben a példában `table.get_Item(1, 1)`. Az egyesített tartományban lévő többi pozíció a táblázatrács része marad, ezért a tartományon kívüli cellák indexei nem változnak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Táblázatcellák felosztása**

A korábbi példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella felosztása új rácsoszlopot hozhat létre, és megváltoztathatja a jobboldali cellák oszlopindexeit. Az Aspose.Slides a PowerPoint táblázatrács modelljét követi.

Ez a példa egy 4x4‑es táblázatot hoz létre 70‑pont széles oszlopokkal és sorokkal, és a [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) metódust hívja a `(1, 1)` cellán. A cella 70‑pont szélességének felét használja két egyenlő szélességű cella létrehozásához.

Az osztás után a két felét a `table.get_Item(1, 1)` és a `table.get_Item(2, 1)` hivatkozza. A táblázat rácsa most öt oszlopot tartalmaz: az eredetileg a 2‑ és 3‑as oszlopokban lévő cellák a 3‑as és 4‑es oszlopokra kerülnek. A sorindexek változatlanok maradnak. Az osztás után a cellák elérésekor ezeket a frissített oszlopindexeket használja.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![Egy össze nem egyesített 70‑pontos cella két 35‑pontos cellára oszlik, egy ötödik rácsoszlopot hozzáadva, és a jobbra lévő indexeket eltolva.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*The width split affects cell (1, 1), using zero-based (column, row) indices. Other rows keep a cell spanning both new column positions.*
<!-- visual-explanation:manage-cells:end -->

### **Egyesített cellák felosztása sor‑ vagy oszlopkiterjedés szerint**

A egyesített sabloncellák adatkitöltésre való előkészítéséhez használja a [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) metódust egy meglévő sorhatár mentén való felosztáshoz, vagy a [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) metódust oszlophatár mentén való felosztáshoz.

Az `index` argumentum a felső rész sorait vagy a bal rész oszlopait számolja a felosztásnál; a egyesített régióhoz viszonyítva:

- Sor felosztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Oszlop felosztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

A példa egy olyan prezentációt feltételez, amelynek első diáján az első alakzat egy táblázat, a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. Az alsó pozíciótól kiindulva a [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) és a [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) segítségével megtalálja a kiindulási pontot, és ellenőrzi mindkét kiterjedést. A `splitByRowSpan(1)` ezután szétválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Vízszintes két‑oszlopos egyesítéshez használja a `splitByColSpan(1)`‑et helyette.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Szerezze be a felosztás után a táblázatból származó cellákat.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

A táblázat rácsa és a környező cella indexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján hívja meg; itt mindkettő 1‑es kiterjedéssel rendelkezik, és a [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) `false`‑t eredményez. Nagyobb régiók egy felosztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és formázása a felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. Töltse fel a cellákat felosztás után, és állítsa be a szükséges szövegformázást kifejezetten.

A mentett prezentáció külön "Product A" és "Product B" cellákat tartalmaz, a sablon cellaformázása megtartva. A részletekért lásd a [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) oldalt.

### **Cella felosztása egy adott magasságban**

A [splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) a felső rész magasságát pontokban veszi. A [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) a felső részben lévő meglévő rácssorok számát veszi. Egy 40‑pontos cella középre helyezéséhez a jobb oszlopban, vonja le a 40-et a cella tényleges magasságából, és osztja el a maradék helyet egyenlően felül és alul.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az első felosztás egy rácssort ad hozzá, és az alsó 90 pontot a `(1, 1)` cellában hagyja. A második felosztás ezt a cellát egy 40‑pontos középső cellára és egy 50‑pontos alsó cellára bontja. A jobb oszlop most három cellát tartalmaz, magasságok 50, 40 és 50 pont fentről lefelé. A bal cella három sort fed le, és megtartja az eredeti 140‑pontos magasságot.

![A bal cella lefedi a teljes táblázatmagasságot, három cella mellett, a középső cella „Middle” felirattal.](split-by-height.png)

## **A táblázatcella háttérszínének módosítása**

Ez a példa 150‑pontos oszlopokkal és 50‑pontos sorokkal rendelkező táblázatot hoz létre. A [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) segítségével válassza a szilárd kitöltést, és a [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) által visszaadott színt állítsa pirosra a `(2, 3)` cellában, a harmadik oszlopban és negyedik sorban.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kép hozzáadása egy táblázatcellába**

Tegye az bemeneti képet a munkakönyvtárba, mielőtt futtatja ezt a példát. A képet a [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) segítségével tölti be, majd a prezentáció képgyűjteményéhez adja a [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) használatával. Ezután a képet a `(0, 0)` cella, a táblázat első cellájának képkitöltéséhez rendeli.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) a képet a cellához nyújtja, ami megváltoztathatja az arányát. Az oszlopszélességek és sormagasságok pontokban vannak megadva. A betöltött képet egy `finally` blokkban szabadítja fel, miután a prezentációba került.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Beállíthatok különböző vonalvastagságokat és stílusokat egy cella egyes oldalaira?**

Igen. A [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) szegélyek különálló tulajdonságokkal rendelkeznek, így az egyes oldalak vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a kép beállítása után megváltoztatom az oszlop/sor méretét a cella háttérként?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) függvénye. Nyújtás esetén a kép a új cellához igazodik; csempézés esetén a csempéket újraszámítják.

**Hozzáadhatok hiperhivatkozást a cella teljes tartalmához?**

[Hyperlinks](/slides/hu/nodejs-java/manage-hyperlinks/) a cella szövegkeretén belüli szöveg (rész) szintjén vagy az egész táblázat/forma szintjén állítható be. Gyakorlati megoldásként a hivatkozást egy részhez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok különböző betűtípusokat egy cellán belül?**

Igen. A cella szövegkerete [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (futamok) támogat, amelyek független formázással rendelkeznek – betűcsalád, stílus, méret és szín.