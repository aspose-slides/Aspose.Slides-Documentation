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

Aspose.Slides lehetővé teszi a PowerPoint‑prezentációk táblázatcelláinak elérését és módosítását. Ez a cikk bemutatja, hogyan azonosíthatók az egyesített táblázatcellák, hogyan távolíthatók el a cella szegélyek, hogyan dolgozhat a cellaszámozással egyesítés vagy felosztás után, hogyan változtatható meg egy cella háttérszíne, és hogyan adhatunk képet egy táblázatcella belsejébe. A példák megmutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezhetünk be egy táblázatot egy diáról, hogyan frissíthetjük a cella formázását a cella tulajdonságain keresztül, és hogyan menthetjük a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulla‑alapú indexeket használ a táblázatcellák eléréséhez a `(oszlop, sor)` sorrendben.

## **Az egyesített táblázatcella azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblázatként kezeli. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Azt követően végigiterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) metódust használja az egyesített területek celláinak azonosításához. Minden egyezésnél kiírja a cella koordinátáit `sor;oszlop` sorrendben, valamint a [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/) értékeket, és a terület kezdő koordinátáit: [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) és [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

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

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) objektumot, és adjon egy táblázatot az első diájához a [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) metódussal. Az oszlopszélességeket, sormagasságokat és a táblázat pozícióját pontokban adja meg. A példa minden négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) értékre állítja, így láthatatlanná válik.

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

## **Táblázatcellák egyesítése**

A [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) metódust használja egy téglalap alakú táblázatcellák tartomány egy cellává kombinálásához. Adja meg a tartomány bal‑felső és jobb‑alsó sarkában lévő cellákat. Az utolsó argumentum szabályozza, hogy az egyesítés tartalmazhat‑e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést a tartományon belül tartja.

A példa egy 4‑x‑4‑es táblázatot hoz létre 70‑pontos oszlopszélességekkel és sormagasságokkal, majd egyesíti a négy középső cellát a `(1, 1)`‑től `(2, 2)`‑ig terjedő tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, míg a táblázat alatti rács négy oszlopot és négy sort tartalmaz továbbra is. Az egyesített cella tartalmának vagy formázásának eléréséhez használja a bal‑felső pozícióját: ebben a példában `table.get_Item(1, 1)`. A többi pozíció a egyesített tartományban a táblázatrács része marad, ezért a tartományon kívüli cellák indexei nem változnak.

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

Az előző példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella felosztása új rácsoszlopot vezethet be, és megváltoztathatja a jobb oldali cellák oszlopszámait. Az Aspose.Slides a PowerPoint táblázatrács modelljét követi.

Ez a példa egy 4‑x‑4‑es táblázatot hoz létre 70‑pontos oszlopszélességekkel és sormagasságokkal, majd a `(1, 1)` cellán meghívja a [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) metódust. A cella 70‑pontos szélességének felét adja át, így két egyenlő szélességű cella jön létre.

A felosztás után a két felét a `table.get_Item(1, 1)` és `table.get_Item(2, 1)` hivatkozza. A táblázatrács most már öt oszlopot tartalmaz: az eredetileg a 2‑es és 3‑as oszlopban lévő cellák a 3‑as és 4‑es oszlopba kerülnek. A sorindexek változatlanok maradnak. A felosztás után a cellák elérésénél ezeket a frissített oszlopszámokat használja.

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

### **Egyesített cellák felosztása sor- vagy oszlopszélesség szerint**

A betöltött sabloncellák adatkitöltésre való előkészítéséhez használja a [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) metódust egy meglévő sorhatár mentén való felosztáshoz, vagy a [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) metódust egy oszlophatár mentén való felosztáshoz.

Az `index` argumentum a felosztás felső részében lévő sorok vagy a bal oldali részében lévő oszlopok számát jelöli; a megadott érték a egyesített területhez képest relatív:

- Sor felosztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Oszlop felosztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

A példa azt feltételezi, hogy a prezentáció első diáján az első alakzat táblázat, amelyben a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. Az alsó pozíciótól kiindulva a [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) és [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) segítségével határozza meg a kiinduló pontot, és ellenőrzi mindkét kiterjedést. A `splitByRowSpan(1)` ezután szétválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Egy vízszintes, kétoszlopos egyesítés esetén használja helyette a `splitByColSpan(1)` metódust.

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

        // A felosztás után a táblázatból származó cellák lekérése.
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

A táblázatrács és a környező cellák indexei változatlanok maradnak. A kapott cellákat a koordinátáik alapján kérdezheti le; itt mindkettő 1‑es kiterjedéssel rendelkezik, és a [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) `false` értéket ad. Nagyobb területek egy felosztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és annak formázása a felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, mint például a kitöltés, a szegélyek és a margók. Töltse fel a cellákat a felosztás után, és állítsa be a szükséges szövegformázást kifejezetten.

A mentett prezentáció külön „Product A” és „Product B” cellákat tartalmaz, megőrizve a sablon cellaformázását. A részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) oldalt.

## **A táblázatcella háttérszínének módosítása**

Ez a példa egy 150‑pontos oszlopszélességű és 50‑pontos sormagasságú táblázatot hoz létre. A [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) segítségével szilárd kitöltést választ, és a [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) által visszaadott színt pirosra állítja a `(2, 3)` cellában, amely a harmadik oszlopban és a negyedik sorban található.

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

## **Kép hozzáadása táblázatcella belsejébe**

Tegye az bemeneti képet a munkakönyvtárba a példa futtatása előtt. A képet a [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) segítségével tölti be, és a [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) metódussal adja hozzá a prezentáció képgyűjteményéhez. Ezután a képet a `(0, 0)` cella (a táblázat első cellája) képkitöltéséhez rendeli.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) az egész cellát kitölti a képpel, ami megváltoztathatja a képarányt. Az oszlopszélességek és sormagasságok pontokban vannak megadva. A betöltött képet egy `finally` blokkban szabadítja fel, miután hozzáadta a prezentációhoz.

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

## **GYIK**

**Beállíthatok különböző vonalvastagságot és stílust a cella egyes oldalaira?**

Igen. A [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) szegélyeknek különálló tulajdonságai vannak, így minden oldal vastagsága és stílusa eltérő lehet.

**Mi történik a képpel, ha a oszlop-/sorméretet megváltoztatom miután képet állítottam be a cella háttérként?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) beállítástól függ. Nyújtás esetén a kép alkalmazkodik az új cellához; csempézés esetén a csempéket újraszámítják.

**Hozzá tudok-e rendelni hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/nodejs-java/manage-hyperlinks/) beállítható a cella szövegtábláján belül a szöveg (rész) szintjén vagy az egész táblázat/alakzat szintjén. Gyakorlatban a hivatkozást egy részlethez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok többféle betűtípust egyetlen cellában?**

Igen. A cella szövegtáblája támogatja a [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (futások) önálló formázását — betűcsalád, stílus, méret és szín.