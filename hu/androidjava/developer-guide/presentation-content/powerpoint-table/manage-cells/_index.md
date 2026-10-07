---
title: Táblacellák kezelése prezentációkban Androidon
linktitle: Cella kezelése
type: docs
weight: 30
url: /hu/androidjava/manage-cells/
keywords:
- táblacella
- cellák egyesítése
- szegély eltávolítása
- cella szétválasztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "PowerPoint táblacellák kezelése Androidon: egyesített cellák azonosítása, szegélyek eltávolítása, cellák szétválasztása, valamint háttérszínek és képek beállítása az Aspose.Slides for Android segítségével Java-ból."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi táblacellák elérését és módosítását PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatók az egyesített táblacellák, hogyan távolíthatók el a cellaszegélyek, hogyan kezelhető a cellaszámozás egyesítés vagy szétválasztás után, hogyan változtatható meg egy cella háttérszíne, valamint hogyan adhatunk képet egy táblacellához. A példák azt mutatják be, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezhetünk be egy táblát egy diáról, hogyan frissíthetjük a cella formázását a cella tulajdonságain keresztül, és hogyan menthetjük a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nulla‑alapú indexeket használ a táblacellák eléréséhez a `(oszlop, sor)` sorrendben.

## **Egyesített táblacella azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dia első alakzatát táblaként éri el. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat egy táblázat. Ezután végigiterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) segítségével azonosítja az egyesített területek celláit. Minden egyezésnél kiírja a cella koordinátáit `sor;oszlop` sorrendben, a [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), a [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--) értékeket, valamint a terület kezdő koordinátáit, a [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) és a [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) értékeket.

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

## **Táblacella szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) objektumot, és adjon egy táblázatot az első diához a [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódussal. Az oszlopszélességeket, sormagasságokat és a tábla pozícióját pontban adjuk meg. A példa az összes négy cellaszegélyt a [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) értékre állítja, így láthatatlanná válnak.

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

## **Táblacellák egyesítése**

A [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) metódussal egy téglalap alakú cellatartományt egyetlen cellává egyesíthetünk. Meg kell adni a tartomány bal‑felső és jobb‑alsó sarkának celláit. Az utolsó argumentum szabályozza, hogy az egyesítés tartalmazhat‑e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést a tartományon belül tartja.

A példa egy 4 × 4‑es táblát hoz létre 70 pontos oszlopokkal és sorokkal, majd a középső négy cellát egyesíti a `(1, 1)`‑től `(2, 2)`‑ig terjedő tartományban. Az így kapott cella két oszlopot és két sort fed le, míg a táblázat mögöttes rácsa továbbra is négy oszlopból és négy sorból áll. Az egyesített cella tartalmához vagy formázásához a bal‑felső pozíciót használjuk: `table.get_Item(1, 1)` ebben a példában. A tartományban maradt egyéb pozíciók továbbra is a táblarács részei, így a tartományon kívüli cellák indexei nem változnak.

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

## **Táblacellák szétválasztása**

Az előző példában az egyesített cellák a táblarácsot megőrzik. Egy cella szétválasztása új rács­oszlopot hozhat létre, és megváltoztathatja a jobbra lévő cellák oszlopszámait. Az Aspose.Slides a PowerPoint táblarács‑modelljét követi.

Ez a példa egy 4 × 4‑es táblát hoz létre 70 pontos oszlopokkal és sorokkal, majd a `(1, 1)` cellán meghívja a [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) metódust. A cella 70 pontos szélességének felét adja át, így két egyenlő szélességű cella jön létre.

A szétválasztás után a két felét a `table.get_Item(1, 1)` és a `table.get_Item(2, 1)` hívásokkal érhetjük el. A táblarács most már öt oszlopot tartalmaz: az eredetileg a 2‑ és 3‑as oszlopokban lévő cellák átkerülnek a 3‑as és 4‑es oszlopokba. A sorindexek változatlanok maradnak. A szétválasztás után a cellák eléréséhez ezekkel a frissített oszlopszámokkal kell dolgozni.

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

### **Egyesített cellák szétválasztása sor vagy oszlop szélesség szerint**

Az egyesített sabloncélák adatkitöltés előtt a [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) segítségével egy meglévő sorhatáron, vagy a [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) segítségével egy oszlophatáron választhatók szét.

Az `index` argumentum a felső rész sorait vagy a bal rész oszlopait számolja, a megadott érték a egyesített régióhoz viszonyítva:

- Sor szétválasztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Oszlop szétválasztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

A példa egy prezentációt feltételez, amelynek az első diáján az első alakzat egy táblázat, ahol a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesítve vannak. A alsó pozícióból kiindulva a [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) és a [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) segítségével meghatározza a kiindulási pontot, és ellenőrzi mindkét kiterjedést. A `splitByRowSpan(1)` ezután szétválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Egy vízszintes, kétoszlopos egyesítéshez használja helyette a `splitByColSpan(1)`‑et.

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

        // Szerezze meg a szétválasztás után a táblából a keletkező cellákat.
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

A táblarács és a környező cellaindexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján lehet lekérdezni; itt mindkettőnek 1‑es kiterjedése van, és a [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) `false`‑t ad vissza. Nagyobb régiók egy szétválasztás után is részben egyesítve maradhatnak.

Az eredeti szöveg és formázás a felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. A cellákat a szétválasztás után kell kitölteni, és a szükséges szövegelemek formázását explicit módon beállítani.

A mentett prezentáció külön „Product A” és „Product B” cellákat tartalmaz, a sablon cellaformázását megtartva. Tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) részleteket.

## **A táblacella háttérszínének módosítása**

Ez a példa 150 pontos oszlopokkal és 50 pontos sorokkal hoz létre egy táblát. A [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) segítségével szilárd kitöltést választ, majd a [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) által visszaadott színt pirosra állítja a `(2, 3)` cellára, amely a harmadik oszlopban és a negyedik sorban található.

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

## **Kép hozzáadása táblacellába**

Helyezze a bemeneti képet a munkakönyvtárba a példa futtatása előtt. A képet a [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) tölti be, és a [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) metódussal adja hozzá a prezentáció képgyűjteményéhez. Ezután a képet a `(0, 0)` cella képtöltésére (picture fill) rendeli, amely a tábla első cellája.

A [PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) a képet a cellához nyújtja, ami megváltoztathatja az arányait. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött képet a `finally` blokkban dobja el, miután hozzáadta a prezentációhoz.

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

**Beállíthatok különböző vonalvastagságot és stílust egyetlen cella különböző oldalain?**

Igen. A [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) szegélyeknek külön tulajdonságaik vannak, ezért minden oldal vastagsága és stílusa eltérhet.

**Mi történik a képpel, ha a oszlop/sor méretét megváltoztatom a kép háttérként történő beállítása után?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) függvénye. Nyújtás esetén a kép a új cellához igazodik; csempézés esetén a csempéket újraszámítják.

**Hozzáadhatok hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/androidjava/manage-hyperlinks/) szövegszegmens‑szinten (cell text frame‑ben) vagy a teljes táblázat/alakzat szintjén állítható be. Gyakorlatban a hivatkozást egy szegmenshez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (run) elemeket független formázással – betűtípus‑család, stílus, méret és szín.