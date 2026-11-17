---
title: Java-val táblázatcellák kezelése bemutatókban
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/java/manage-cells/
keywords:
- table cell
- merge cells
- remove border
- split cell
- image in cell
- background color
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Táblázatcellák kezelése PowerPoint-ban Java-val: összevont cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides for Java használatával."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a táblázatcellák elérését és módosítását PowerPoint bemutatókban. Ez a cikk bemutatja, hogyan lehet azonosítani az összevont táblázatcellákat, eltávolítani a cellaszegélyeket, a cellaszámozással dolgozni az egyesítés vagy felosztás után, megváltoztatni egy cella háttérszínét, és képet hozzáadni egy táblázatcellához. A példák azt mutatják be, hogyan hozhatunk létre vagy nyithatunk meg egy bemutatót, hogyan szerezhetünk be egy táblázatot egy diáról, hogyan frissíthetjük a cella formázását a cella tulajdonságain keresztül, és hogyan menthetjük el a módosított bemutatót PPTX fájlként.

Az Aspose.Slides nullaalapú indexeket használ a táblázatcellák eléréséhez `(oszlop, sor)` sorrendben.

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

## **Összevont táblázatcella azonosítása**

A példa megnyit egy létező bemutatót, és az első dián az első alakzatot táblázatként érinti. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Ezután végigiterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) segítségével azonosítja az összevont területek celláit. Minden egyezésnél kiírja a cella koordinátáit `row;column` sorrendben, a [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), a [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), valamint a terület kezdő koordinátáit, a [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) és a [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Táblázatcella szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) és adjon hozzá egy táblázatot az első diájához a [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) segítségével. Az oszlopszélességeket, sormagasságokat és a táblázat pozícióját pontokban adja meg. A példa az összes négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) értékre állítja, így láthatatlanná válik.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Átlós cellaszegélyek hozzáadása**

Használja a [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) függvényt a bal felső saroktól a jobb alsó sarokig tartó vonal megrajzolásához, és a [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) függvényt a bal alsó saroktól a jobb felső sarokig tartó vonalhoz. Egy átló jelölhet egy sarokfejlécet; mindkét átló X-et alkothat, hogy a cellát nem alkalmazandóként jelölje.

Minden átló egy [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/). A [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) használatával hívja meg a [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) metódust a [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) kiválasztásához, és válasszon színt a [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) segítségével. A vonal vastagságát pontokban a [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) metódussal állítsa be.

A példa egy sorban három cellát hoz létre: egy piros lefelé mutató átlót, egy kék felfelé mutató átlót, valamint mindkettőt. A felső, alsó, bal és jobb cellaszegélyek változatlanok maradnak.

A diagonal is a formatting property, not a cell split. Each cell retains a single text frame, accessed through [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--); the regions on either side of a diagonal cannot be edited independently.

The saved table, rendered in Microsoft PowerPoint:

![Három táblázatcella, ahol egy piros átló a bal felsőtől a jobb alsóig, egy kék átló a bal alulról a jobb felsőig, és mindkét átló X-et alkot.](diagonal-cell-borders.png)

*Balról jobbra: lefelé mutató átló (piros, 3 pt), felfelé mutató átló (kék, 5 pt), és mindkét átló.*

## **Táblázatcellák egyesítése**

Használja a [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) metódust egy téglalap alakú táblázatcellatartomány egy cellává egyesítéséhez. Adja meg a tartomány bal felső és jobb alsó sarkában lévő cellákat. Az utolsó argumentum szabályozza, hogy az egyesítés tartalmazhat-e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést a tartományon belül tartja.

A példa egy 4x4-es táblázatot hoz létre 70 pontos oszlopokkal és sorokkal, majd az `(1, 1)`‑től `(2, 2)`‑ig terjedő négy középső cellát egyesíti. Az így keletkező cella két oszlopot és két sort fed le, míg a táblázat alaprácsa továbbra is négy oszlopból és négy sorból áll. Az egyesített cella tartalmához vagy formázásához a bal felső pozíciót használja: `table.get_Item(1, 1)` ebben a példában. A többi pozíció a egyesített tartományban a táblázatrács része marad, így a tartományon kívüli cellák indexei nem változnak.

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

## **Táblázatcellák felosztása**

Az előző példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella felosztása új rácsoszlopot hozhat létre és módosíthatja a cellák jobb oldali oszlop indexeit. Az Aspose.Slides a PowerPoint táblázatrács modelljét követi.

Ez a példa egy 4x4-es táblázatot hoz létre 70 pontos oszlopokkal és sorokkal, és a `(1, 1)` cellára meghívja a [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) metódust. A cella 70 pontos szélességének felét használja két egyenlő szélességű cella létrehozásához.

A felosztás után a két felét a `table.get_Item(1, 1)` és a `table.get_Item(2, 1)` hivatkozza. A táblázatrács most öt oszlopot tartalmaz: az eredetileg a 2‑ és 3‑as oszlopban lévő cellák a 3‑as és 4‑es oszlopba kerülnek. A sorindexek változatlanok maradnak. A felosztás utáni celláknál használja ezeket a frissített oszlopindexeket.

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

<!-- visual-explanation:manage-cells:start -->
[![Egy nem egyesített 70 pontos cella felosztva két 35 pontos cellává, ötödik rácsoszlop hozzáadva és a jobboldali indexek eltolásával.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)
* *A szélesség felosztása a (1, 1) cellát érinti, nullaalapú (oszlop, sor) indexekkel. A többi sor egy cellát tart meg, amely mindkét új oszloppozíciót lefedi.* 
<!-- visual-explanation:manage-cells:end -->

### **Egyesített cellák felosztása sor- vagy oszlopszélesség szerint**

Az egyesített sabloncellák adatkitöltésre való előkészítéséhez használja a [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) metódust egy meglévő sorhatáron történő felosztáshoz, vagy a [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) metódust egy oszlophatáron történő felosztáshoz.

`index` argument a felosztás felső részében lévő sorokat vagy a bal részében lévő oszlopokat számolja; a megadott érték az egyesített régióhoz képest relatív.

- Sor felosztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)
- Oszlop felosztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)

A példa azt feltételezi, hogy a bemutató első diáján az első alakzat egy táblázat, amelyben a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. A jobb alsó pozíciótól indulva a [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) és a [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) segítségével lokálja a kiindulási pontot, és ellenőrzi mindkét átfedést. A `splitByRowSpan(1)` ezután szétválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Vízszintes kétoszlopos egyesítéshez használja helyette a `splitByColSpan(1)`-et.

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

        // A felosztás után a táblázatból lekérdezzük az eredményül kapott cellákat.
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

A táblázatrács és a környező cellaindexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján kérdezheti le; itt mindkettő 1‑es átfedéssel rendelkezik, és a [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) `false`‑t ad vissza. Nagyobb régiók egy felosztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és formázása a felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. A felosztás után töltse fel a cellákat, és szükség esetén állítsa be a szöveg formázását explicit módon.

A mentett bemutató külön "Product A" és "Product B" cellákat tartalmaz, a sablon cellaformázása megmarad. A részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) oldalt.

### **Cellá felosztása adott magasságban**

A [splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) a felső rész magasságát pontokban veszi. A [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) a felső részben lévő meglévő rácssorok számát veszi. Egy 40 pontos cella középre helyezéséhez a jobb oszlopban vonja le a 40-et a cella tényleges magasságából, és az így megmaradt teret egyenlően ossza el felül és alul.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };
    
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az első felosztás egy rácssort ad hozzá, a `(1, 1)` cellában 90 pontot hagyva alul. A második felosztás a cellát egy 40 pontos középső cellára és egy 50 pontos alsó cellára osztja. A jobb oszlop most három cellát tartalmaz, magasságuk felülről lefelé 50, 40 és 50 pont. A bal cella mindhárom sort lefedi, és megtartja az eredeti 140 pontos magasságát.

![A bal cella az egész táblázat magasságát lefedi, mellette három cella található, amelyek középen a „Middle” cella van.](split-by-height.png)

## **A táblázatcella háttérszínének megváltoztatása**

Ez a példa 150 pontos oszlopokkal és 50 pontos sorokkal hoz létre egy táblázatot. A [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) segítségével szilárd kitöltést választ, és a [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) által visszaadott színt pirosra állítja a `(2, 3)` cellában, amely a harmadik oszlopban és a negyedik sorban található.

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

## **Kép hozzáadása a táblázatcellához**

Helyezze az bemeneti képet a munkakönyvtárba, mielőtt futtatná ezt a példát. A képet a [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) segítségével tölti be, és a bemutató képgyűjteményéhez a [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) segítségével adja hozzá. Ezután hozzárendeli a képet a `(0, 0)` cella képtöltéséhez, amely a táblázat első cellája.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) a képet a cellára nyújtja, ami megváltoztathatja a képarányt. Az oszlopszélességek és sormagasságok pontokban vannak megadva. A betöltött képet a `finally` blokkban szabadítják fel, miután hozzáadták a bemutatóhoz.

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

**Beállíthatok különböző vonalvastagságokat és stílusokat egy cella különböző oldalain?**

Igen. A [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) szegélyeknek külön-külön vannak tulajdonságaik, így minden oldal vastagsága és stílusa eltérő lehet.

**Mi történik a képpel, ha az oszlop/sor méretét megváltoztatom miután a képet a cella háttérként beállítottam?**

A viselkedés a [kitöltési mód](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile) függvénye. Nyújtás esetén a kép a új cellához igazodik, csempézés esetén a csempéket újraszámítják.

**Hozzárendelhetek hiperhivatkozást a cella teljes tartalmához?**

[Hiperhivatkozások](/slides/hu/java/manage-hyperlinks/) a cella szövegtábláján belül a szöveg (rész) szintjén vagy a teljes táblázat/alkalmazás szintjén van beállítva. Gyakorlatban a hivatkozást egy részre vagy a cella teljes szövegére rendeli.

**Beállíthatok különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegtáblája támogatja a [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (futásokat) független formázással — betűcsalád, stílus, méret és szín.