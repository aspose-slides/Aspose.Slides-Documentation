---
title: "Táblázatok kezelése prezentációkban JavaScript-ben"
linktitle: "Táblázat kezelése"
type: docs
weight: 10
url: /hu/nodejs-java/manage-table/
keywords:
- "tábla hozzáadása"
- "tábla létrehozása"
- "tábla elérése"
- "oldalarány"
- "szöveg igazítása"
- "szövegformázás"
- "tábla stílus"
- "PowerPoint"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákon JavaScript és Aspose.Slides for Node.js segítségével. Fedezze fel az egyszerű kódpéldákat, hogy hatékonyabbá tegye a táblázatkezelést."
---
## **Bevezetés**

A PowerPoint táblázatai sorba és oszlopba rendezik az információkat, megkönnyítve az értékek olvasását és összehasonlítását.

Az Aspose.Slides biztosítja a [Táblázat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) osztályt, a [Cella](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) osztályt és egyéb típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését a bemutatókban.

## **Táblázat létrehozása nulláról**

Hozzon létre egy táblázatot a pozíciójának, az oszlopszélességeknek és a sormagasságoknak a megadásával. Miután hozzáadta egy diára, formázhatja a cellahatárokat, egyesítheti a cellákat, és szöveget illeszthet be.

1. Hozzon létre egy példányt a [Bemutató](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást a diára a indexe alapján.
3. Határozzon meg egy tömböt az oszlopszélességek pontra vonatkozó értékeivel.
4. Határozzon meg egy tömböt a sormagasságok pontra vonatkozó értékeivel.
5. Adjon egy [Táblázat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) objektumot a diára az [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) metódus segítségével.
6. Iteráljon minden [Cella](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) elemen, hogy formázást alkalmazzon a felső, alsó, jobb és bal határokra.
7. Egyesítse a táblázat első sorának első két celláját.
8. A hozzáférjen az egyesített cellához a [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) metódusán keresztül.
9. Állítsa be a szöveget az egyesített cellában.
10. Mentse el a módosított bemutatót.

Az alábbi példa három oszlopból és öt sorból álló táblázatot hoz létre (100, 50) pont koordinátán. Vörös, 5 pont széles határokat alkalmaz, egyesíti az első sor első két celláját, és a eredményt `table.pptx`‑ként menti.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Számozás egy szabványos táblázatban**

A szabványos táblázatban a cella indexek nullától kezdődnek, és a (oszlop, sor) sorrendet követik. Az első cella indexe (0, 0).

Az alábbiakban például egy 4 oszlopból és 4 sorból álló táblázat celláit így számozzuk:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a példa létrehozza a fent ábrázolt 4 × 4-es táblázatot, 70 pont oszlopszélességgel és sormagassággal, valamint 5 pont széles vörös cellahatárokkal. A koordináták a cella indexeket szemléltetik; a példa üresen hagyja a cellákat, és a táblázatot `StandardTables_out.pptx`‑ként menti.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Meglévő táblázat elérése**

A táblázatok egy dia alakzatgyűjteményében vannak tárolva. Iteráljon az alakzatokon, hogy megtalálja a táblázatot, majd használja a [Táblázat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) osztályt a cellák olvasásához vagy frissítéséhez.

1. Töltse be a bemutatót a [Bemutató](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztály segítségével.
2. Szerezzen hivatkozást arra a diára, amelyik a táblázatot tartalmazza, az indexe alapján.
3. Iteráljon a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) objektumokon, és álljon meg, ha táblázatot talál. Ha a dián több táblázat is van, használja a [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) metódust a szükséges azonosításához.
4. Frissítse a szöveget a célcellában.
5. Mentse el a módosított bemutatót.

Az alábbi példa megnyitja a `UpdateExistingTable.pptx` fájlt és megtalálja az első táblázatot az első dián. A 0. oszlop, 1. sor celláját `New` értékre állítja, és az eredményt `table1_out.pptx`‑ként menti. A bemenetnek legalább egy diát kell tartalmaznia, és az első táblázatnak azon a dián legalább egy oszlopa és két sora kell legyen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

A sor átméretezéséhez meglévő táblázatban, és hogy megértsük, miért haladhatja meg a tényleges magasság a kért minimumot, lásd [Sor magasságának szabályozása](/slides/hu/nodejs-java/manage-rows-and-columns/#control-row-height).

## **A szövegkeretet tartalmazó cella megtalálása**

Amikor általános szövegfeldolgozó kód egy [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) objektumot kap egy táblázatból, használja a [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) metódust, hogy lekérje a tulajdonos [Cella](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) objektumot. Egy táblázat‑cella szövegkeret esetén a [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) visszaadja a tulajdonost, míg a [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) `null`‑t ad, még akkor is, ha maga a táblázat alakzat.

A cellakoordináták a csak‑olvasható [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) és [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) metódusok segítségével érhetők el. A [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) szintén csak‑olvasható navigációt biztosít: visszaadja a tulajdonost, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze, hogy a visszakapott cella nem `null`, mielőtt használja.

Egy teljes példáért, amely azonosítja a táblacella és alakzat tulajdonosokat, beleértve a SmartArt‑csomópontokhoz társított alakzatokat, lásd [Szöveg keresése és cseréje](/slides/hu/nodejs-java/search-and-replace-text/).

## **Szöveg igazítása egy táblázatban**

Egyedi táblacellák függőleges rögzítését és szöve irányát szabályozhatja. Az ebben a szakaszban szereplő példa középre igazítja a szöveget az első cellában, majd 270 fokkal elforgatja.

1. Hozzon létre egy példányt a [Bemutató](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást a diára a indexe alapján.
3. Adjon egy [Táblázat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) objektumot a diához.
4. Szerezzen hozzáférést egy [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) objektumhoz a táblázatból.
5. Szerezze meg az első [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét és színét.
6. Állítsa be a cella függőleges rögzítését és a szöveg irányát a [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) és a [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) metódusokkal.
7. Mentse el a módosított bemutatót.

Ez a példa egy 4 × 4‑es táblázatot hoz létre 120 pont oszlopszélességgel és 100 pont sormagassággal. Formázza a szöveget a (0, 0) cellában, értékeket ad a maradék celláknak az első sorban, és a eredményt `Vertical_Align_Text_out.pptx`‑ként menti.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegformázás beállítása táblázatszinten**

Használja a [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) metódust, hogy szövegformázást alkalmazzon a táblázat minden cellájára. Az overloadok lehetővé teszik rész, bekezdés és szövegkeret formázásának átadását, így az egyes cellák iterálása nélkül is beállíthatók ezek a tulajdonságok.

1. Töltse be a bemutatót a [Bemutató](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztály segítségével.
2. Szerezzen hivatkozást a diára a indexe alapján.
3. Szerezzen egy [Táblázat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) objektumot a diáról.
4. Állítsa be a betűméretet a [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) metódussal a szöveghez.
5. Állítsa be a bekezdés igazítását és a jobb margót a [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) és a [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) metódusokkal.
6. Állítsa be a szöveg irányát a [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metódussal.
7. Mentse el a módosított bemutatót.

Az alábbi példa megnyitja a `table.pptx`‑et, amelynek legalább egy diája van, és azon a dián a első alakzat egy táblázat. A betűméretet 25 pontra állítja, a bekezdéseket jobbra igazítja 20 pont jobb margóval, és a szöveget függőlegesé teszi. A formázott bemutató `result.pptx`‑ként kerül mentésre.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A táblázat stílus tulajdonságainak lekérése**

Használja a [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) metódust a táblázat előre beállított stílusának lekéréséhez, és a [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) metódust a hozzárendeléshez. Ez a példa a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) előre beállítást alkalmaz egy táblázatra, kiírja az előre beállított értéket, majd ugyanezt az előre beállítást egy második táblázatra is alkalmazza. Mindkét táblázat `table-style.pptx`‑ben kerül mentésre.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A táblázat arányának rögzítése**

A táblázat aránya a szélesség és a magasság aránya. Használja a [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) metódust ennek az aránynak a rögzítéséhez.

Az alábbi példa megnyitja a `pres.pptx`‑et, amelynek legalább egy diája van, és azon a dián a első alakzat egy táblázat. Kiírja a jelenlegi zárási állapotot, engedélyezi az arány rögzítését, majd kiírja a frissített állapotot (`true`), és a eredményt `pres-out.pptx`‑ként menti.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bekapcsolhatom a jobbról balra (RTL) olvasási irányt egy egész táblázatra és annak celláiban lévő szövegre?**

Igen. A táblázat a [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) metódust biztosítja, a bekezdéseknek pedig a [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-) metódusuk van. Mindkettő együttes használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg a felhasználókat, hogy a táblázatot mozgassák vagy átméretezzék a végleges fájlban?**

Használja az [alakzatzárolások](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) lehetőségét a mozgatás, átméretezés, kijelölés stb. letiltására. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép beillesztése cellába háttérként?**

Igen. Beállíthat egy [kép kitöltést](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) egy cellához; a kép a cellaterületet lefedi a kiválasztott mód szerint (nyújtás vagy mozaik).