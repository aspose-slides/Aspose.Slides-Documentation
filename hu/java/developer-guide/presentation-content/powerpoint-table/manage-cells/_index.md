---
title: "Táblázatcellák kezelése prezentációkban Java használatával"
linktitle: "Cellák kezelése"
type: docs
weight: 30
url: /hu/java/manage-cells/
keywords:
- "táblázatcella"
- "cellák egyesítése"
- "szegély eltávolítása"
- "cella szétválasztása"
- "kép a cellában"
- "háttérszín"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "PowerPoint táblázatcellák kezelése Java-ban: egyesített cellák azonosítása, szegélyek eltávolítása, cellák szétválasztása, valamint háttérszínek és képek beállítása az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy hozzáférjünk és módosítsuk a táblázatcellákat PowerPoint bemutatókban. Ez a cikk bemutatja, hogyan azonosíthatók az egyesített táblázatcellák, hogyan távolíthatók el a cellahatárok, hogyan kezelhetők a cellaszámok az egyesítés vagy szétválasztás után, hogyan változtatható meg egy cella háttérszíne, és hogyan adhatunk képet egy táblázatcellába. A példák bemutatják, hogyan hozhatunk létre vagy nyithatunk meg egy bemutatót, hogyan szerezhetünk be egy táblázatot egy diáról, hogyan frissíthetjük a cellaformázást a cellatulajdonságok segítségével, és hogyan menthetjük a módosított bemutatót PPTX fájlként.

Az Aspose.Slides nulla‑alapú indexeket használ a táblázatcellák eléréséhez a `(oszlop, sor)` sorrendben.

## **Egyesített táblázatcella azonosítása**

A példa megnyit egy meglévő bemutatót, és az első dián az első alakzatot táblázatként érinti. Feltételezi, hogy a dia és az alakzat létezik, valamint hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) segítségével azonosítja az egyesített területek celláit. Minden találat esetén kiírja a cella koordinátáit `sor;oszlop` sorrendben, a [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), a [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--) és a terület kezdő koordinátáit, a [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) és a [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) segítségével.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Táblázatcella-szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) objektumot, és adjon egy táblázatot az első diájához a [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) segítségével. Az oszlopszélességek, sormagasságok és a táblázat pozíciója pontban van megadva. A példa az összes négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) értékre állítja, így láthatatlanokká válik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Táblázatcellák egyesítése**

A [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) segítségével egy téglalap alakú táblázatcella-halmazt egyetlen cellává egyesítheti. Adja meg a tartomány bal‑felső és jobb‑alsó sarkában lévő cellákat. Az utolsó argumentum határozza meg, hogy az egyesítés tartalmazhat-e a megadott tartományon kívüli cellákat; a `false` érték a tartományon belül tartja az egyesítést.

A példa egy 4×4-es táblázatot hoz létre 70‑pontos oszlopokkal és sorokkal, majd egyesíti a négy középső cellát a `(1, 1)`‑től `(2, 2)`‑ig tartó tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, míg a táblázat alaprácsa négy oszlopot és négy sort megtart. Az egyesített cella tartalmához vagy formázásához a bal‑felső pozíciót használja: `table.get_Item(1, 1)` ebben a példában. A többi pozíció a egyesített tartományban a táblázatrács része marad, ezért a tartományon kívüli cellák indexei nem változnak.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Táblázatcellák szétválasztása**

Az előző példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella szétválasztása új oszlopot hozhat létre a rácsban, és megváltoztathatja a jobb oldali cellák oszlopt indexeit. Az Aspose.Slides a PowerPoint táblázat‑rács modelljét követi.

Ez a példa egy 4×4-es táblázatot hoz létre 70‑pontos oszlopokkal és sorokkal, és a `(1, 1)` cellán meghívja a [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) metódust. A cella 70‑pontos szélességének felét adja át két egyenlő szélességű cella létrehozásához.

A szétválasztás után a két rész a `table.get_Item(1, 1)` és a `table.get_Item(2, 1)` segítségével érhető el. A táblázat rácsa most öt oszlopot tartalmaz: az eredetileg a 2‑ és 3‑as oszlopokban lévő cellák a 3‑as és 4‑es oszlopokba kerülnek, sorrendben. A sorindexek változatlanok maradnak. A szétválasztás után a cellák elérésekor ezeket a frissített oszlopindexeket használja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Egyesített cellák szétválasztása sor- vagy oszlopszélesség szerint**

Az egyesített sabloncellák adatfeltöltésre történő előkészítéséhez használja a [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) metódust egy meglévő sorhatár mentén történő szétválasztáshoz, vagy a [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) metódust egy oszlophatár mentén történő szétválasztáshoz.

Az `index` argumentum a szétválasztás felső részében lévő sorok vagy a bal oldali részében lévő oszlopok számát adja meg; a megadott érték az egyesített területhez viszonyítva értendő:

- Sor szétválasztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Oszlop szétválasztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

A példa azt feltételezi, hogy a bemutató első diáján az első alakzat egy táblázat, ahol a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. A alsó pozícióból kiindulva a [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) és a [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) segítségével meghatározza a kiindulási pontot, és ellenőrzi mindkét kiterjedést. A `splitByRowSpan(1)` ezután szétválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Vízszintes két‑oszlopos egyesítés esetén használja a `splitByColSpan(1)`‑et helyette.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // A szétválasztás után a táblázatból lekérhető eredő cellák.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

A táblázat rácsa és a környező cella indexek változatlanok maradnak. A keletkezett cellákat a koordinátáik alapján kérdezheti le; itt mindkettő 1‑es kiterjedésű, és a [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) `false` értéket ad. Nagyobb területek egy szétválasztás után is maradhatnak részben egyesítve.

Az eredeti szöveg és formázása a felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. A szétválasztás után töltse fel a cellákat, és állítsa be a szükséges szövegformázást kifejezetten.

A mentett bemutató külön "Product A" és "Product B" cellákat tartalmaz, a sablon cellaformázása megmarad. A részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) oldalt.

## **A táblázatcella háttérszínének módosítása**

Ez a példa egy táblázatot hoz létre 150‑pontos oszloppal és 50‑pontos sorral. A [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) segítségével egy szilárd kitöltést választ, és a [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) által visszaadott színt pirosra állítja a `(2, 3)` cellában, amely a harmadik oszlop és a negyedik sor.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kép hozzáadása egy táblázatcellához**

Az példát futtatás előtt helyezze el a bemeneti képet a munkakönyvtárban. A képet a [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) tölt be, és a [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) segítségével hozzáadja a bemutató képgyűjteményéhez. Ezután a képet a `(0, 0)` cella (az első cella a táblázatban) képkitöltéséhez rendeli.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) a képet kinyújtja, hogy betöltse a cellát, ami megváltoztathatja a képarányt. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött képet a `finally` blokkban szabadítja fel, miután hozzá lett adva a bemutatóhoz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Beállíthatok különböző vonalvastagságot és stílust az egy cella különböző oldalain?**

Igen. A [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a képet cella háttérként beállítva megváltoztatom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile) beállítástól függ. Nyújtás esetén a kép az új cellához igazodik, csempézés esetén a csempéket újraszámolják.

**Rendelhetek hiperhivatkozást a cella teljes tartalmához?**

[Hyperlinks](/slides/hu/java/manage-hyperlinks/) a cella szövegrétegén (rész) szinten vagy a teljes táblázat/alakzat szintjén állítható be. Gyakorlatban a hivatkozást vagy egy részhez, vagy a cella teljes szövegéhez rendeli.

**Beállíthatok különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegrétege a [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (szegmensek) használatát támogatja, amelyeknek önálló formázása lehet – betűcsalád, stílus, méret és szín.