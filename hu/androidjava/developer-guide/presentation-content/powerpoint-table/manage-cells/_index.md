---
title: Táblázatcellák kezelése Androidos prezentációkban
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/androidjava/manage-cells/
keywords:
- táblázatcella
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "PowerPoint táblázatcellák kezelése Androidon: egyesített cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása Aspose.Slides for Android segítségével Java nyelven."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációk táblázatcelláit elérje és módosítsa. Ez a cikk bemutatja, hogyan azonosíthatja az egyesített táblázatcellákat, távolíthatja el a cellaszegélyeket, dolgozhat a cellák számozásával az egyesítés vagy felosztás után, módosíthatja egy cella háttérszínét, és hogyan adhat hozzá képet egy táblázatcellán belül. A példák bemutatják, hogyan hozhat létre vagy nyithat meg egy prezentációt, szerezhet be egy táblázatot egy diából, frissítheti a cella formázását a cella tulajdonságain keresztül, és mentheti a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulla‑bázisú indexeket használ a táblázatcellák eléréséhez `(oszlop, sor)` sorrendben.

## **Egyesített táblázatcellák azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblázatként érinti. Feltételezi, hogy a dia és az alakzat létezik, valamint hogy az alakzat táblázat. Ezután végigiterál minden soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) használatával azonosítja az egyesített régiók celláit. Minden egyezésnél kiírja a cella koordinátáit `row;column` sorrendben, valamint a [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), és a régió kiindulási koordinátáit: [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) és [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Táblázatcellaszegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) és adjon egy táblázatot az első diájához a [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) segítségével. Az oszlopszélességeket, sormagasságokat és a táblázat pozícióját pontokban adjuk meg. A példa minden négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) értékre állítja, így láthatatlanná téve őket.

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

## **Átlós cellaszegélyek hozzáadása**

Használja a [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) hogy egy vonalat rajzoljon a bal felső saroktól a jobb alsóig, és a [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) hogy egy vonalat a bal alsó saroktól a jobb felsőig. Egy átló megjelölhet egy sarkfejlécet; mindkét átló X‑et alkothat, hogy a cellát nem alkalmazandóként jelölje.

Minden átló egy [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). A [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--)‑ben használja a [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-)‑t, hogy a [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)‑t válassza, és színt válasszon a [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--)‑lal. Állítsa be a vonal vastagságát pontokban a [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-)-el.

A példa egy sorban három cellát hoz létre: egy piros lefelé mutató átlót, egy kék felfelé mutató átlót, és mindkét átlót. A felső, alsó, bal és jobb cellaszegélyeket változatlanul hagyja.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Az átló egy formázási tulajdonság, nem cella felosztás. Minden cella egyetlen szövegkeretet tartalmaz, amely a [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--)‑en keresztül érhető el; az átló mindkét oldalán lévő területeket nem lehet önállóan szerkeszteni.

A mentett táblázat, a Microsoft PowerPoint‑ben megjelenítve:
![Három táblázatcellát mutat, egy piros átlót a bal felső saroktól a jobb alsóig, egy kék átlót a bal alsó saroktól a jobb felsőig, és mindkét átló X‑et alkot.](diagonal-cell-borders.png)

*Balról jobbra: lefelé mutató átló (piros, 3 pt), felfelé mutató átló (kék, 5 pt), és mindkét átló.*

## **Táblázatcellák egyesítése**

Használja a [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-)‑t, hogy egy téglalap alakú táblázatcellák tartományt egy cellává egyesítse. Adja meg a tartomány bal‑felső és jobb‑alsó sarkában lévő cellákat. Az utolsó argumentum szabályozza, hogy az egyesítés magában foglalhat‑e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést a tartományon belül tartja.

A példa egy 4×4‑es táblázatot hoz létre 70‑pontos oszlopokkal és sorokkal, majd egyesíti a négy központi cellát a `(1, 1)`‑től `(2, 2)`‑ig terjedő tartományban. Az eredményül kapott cella két oszlopot és két sort foglal el, miközben a táblázat alaprácsa négy oszlopot és négy sort megtart. Az egyesített cella tartalmához vagy formázásához használja a bal‑felső pozícióját: `table.get_Item(1, 1)` ebben a példában. A többi pozíció az egyesített tartományban része marad a táblázat rácsnak, ezért a tartományon kívüli cellák indexei nem változnak.

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

Az előző példában a cellák egyesítése megőrzi a táblázat rácsát. Egy cella felosztása új rács oszlopot hozhat létre, és megváltoztathatja a jobb oldali cellák oszlopindexeit. Az Aspose.Slides a PowerPoint táblázatrács modelljét követi.

Ez a példa egy 4×4‑es táblázatot hoz létre 70‑pontos oszlopokkal és sorokkal, és a `[splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-)`‑t hívja a `(1, 1)` cellán. A cella 70‑pontos szélességének felét használja fel két egyenlő szélességű cella létrehozásához.

A felosztás után a két felet a `table.get_Item(1, 1)` és a `table.get_Item(2, 1)` hivatkozza. A táblázat rácsa most öt oszlopot tartalmaz: az eredetileg a 2‑ és 3‑as oszlopokban lévő cellák áthelyeződnek a 3‑as és 4‑es oszlopokba. A sorindexek változatlanok maradnak. Használja ezeket a frissített oszlopindexeket a cellák elérésekor a felosztás után.

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
[![Egy nem egyesített 70‑pontos cella két 35‑pontos cellára oszlik, ezzel egy ötödik rácsoszlopot hozzáadva és eltolva a jobb oldali indexeket.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*The width split affects cell (1, 1), using zero-based (column, row) indices. Other rows keep a cell spanning both new column positions.*
<!-- visual-explanation:manage-cells:end -->

### **Egyesített cellák felosztása sor‑ vagy oszlopszélesség alapján**

Az egyesített sabloncellák adatfeltöltésre való előkészítéséhez használja a [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-)‑t, hogy egy meglévő sorhatár mentén osztja fel, vagy a [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-)‑t, hogy egy oszlophatár mentén osztja fel.

Az `index` argumentum a felosztás felső részében lévő sorok vagy a bal részében lévő oszlopok számát jelöli; a megadott érték a egyesített régióhoz képest relatív:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

A példa azt feltételezi, hogy a prezentációban a első dián az első alakzat egy táblázat, amelyben a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. Az alsó pozícióból kiindulva a [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) és a [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) segítségével megtalálja az eredetet, és ellenőrzi mindkét átfedést. Ezután a `splitByRowSpan(1)` szétválasztja a 2‑es és 3‑as sorokat a termékneveknél. Vízszintes két oszlopos egyesítéshez használja a `splitByColSpan(1)`‑et helyette.

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

        // A felosztás után a táblázatban lévő eredményül kapott cellák lekérése.
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

A táblázat rácsa és a környező cella indexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján lehet lekérni; itt mindkettő átfedése 1, és a [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) `false`‑t ad vissza. Nagyobb régiók egy felosztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és annak formázása az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. Töltse fel a cellákat a felosztás után, és állítsa be a szükséges szövegformázást explicit módon.

A mentett prezentáció külön "Product A" és "Product B" cellákat tartalmaz, a sablon cellaformázása megmarad. A részletekért tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)‑t.

### **Cellát felosztása meghatározott magasságban**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) a felső rész magasságát veszi pontokban. [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) a létező rácssorok számát veszi a felső részben. Egy 40‑pontos cella középre helyezéséhez a jobb oszlopban, vonja le a 40‑et a cella tényleges magasságából, és ossza el a maradék helyet egyenlően felül és alul.

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

Az első felosztás egy rácssort ad hozzá, és a `(1, 1)` cellában 90 pontot hagy alul. A második felosztás ezt a cellát egy 40‑pontos középső cellára és egy 50‑pontos alsó cellára osztja. A jobb oszlop most három cellával rendelkezik, melyek magassága felülről lefelé 50, 40 és 50 pont. A bal cella három sort fed le, és megtartja az eredeti 140 pontos magasságát.

![A bal cella a teljes táblázat magasságát lefedi, három cella áll mellette, a középsőben a „Middle” felirat.](split-by-height.png)

## **A táblázatcellák háttérszínének módosítása**

Ez a példa egy 150‑pontos oszlopokkal és 50‑pontos sorokkal rendelkező táblázatot hoz létre. A [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) segítségével egy szilárd kitöltést választ, majd a [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) által visszaadott színt pirosra állítja a `(2, 3)` cellában, ami a harmadik oszlop és a negyedik sor.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Kép hozzáadása táblázatcellán belül**

A bemeneti képet helyezze a munkakönyvtárba a példa futtatása előtt. A képet a [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) segítségével tölti be, és a prezentáció képgyűjteményéhez adja a [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-)‑mel. Ezután a képet a `(0, 0)` cella képtöltéséhez rendeli, amely a táblázat első cellája.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) kinyújtja a képet, hogy kitöltse a cellát, ami megváltoztathatja a képarányt. Az oszlopszélességek és sormagasságok pontokban vannak megadva. A betöltött képet a `finally` blokkban szabadítják fel, miután hozzá lett adva a prezentációhoz.

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

**Beállíthatok különböző vonalvastagságot és stílust a cella egyes oldalaira?**

Igen. A [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) szegélyeknek különálló tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a cella háttérként beállított kép után megváltoztatom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) függvénye. Nyújtás esetén a kép az új cellához igazodik, csempézés esetén a csempéket újraszámítják.

**Hozzáadhatok hiperhivatkozást a cella teljes tartalmához?**

[Hyperlinks](/slides/hu/androidjava/manage-hyperlinks/) a cella szövegkeretén belüli szöveg (rész) szintjén vagy a teljes táblázat/forma szintjén állítható be. Gyakorlati szempontból a linket egy részhez vagy a cella összes szövegéhez rendeli.

**Beállíthatok különböző betűtípusokat egy cellán belül?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (futtatások) független formázásával — betűcsalád, stílus, méret és szín.