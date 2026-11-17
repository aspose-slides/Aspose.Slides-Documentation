---
title: Spravovat buňky tabulky v prezentacích pomocí JavaScriptu
linktitle: Spravovat buňky
type: docs
weight: 30
url: /cs/nodejs-java/manage-cells/
keywords:
- buňka tabulky
- sloučit buňky
- odstranit okraj
- rozdělit buňku
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravovat buňky tabulky PowerPoint v JavaScriptu: identifikovat sloučené buňky, odstranit okraje, rozdělit buňky a nastavit barvy pozadí a obrázky pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky a upravovat je v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení, změnit barvu pozadí buňky a přidat obrázek uvnitř buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buněk prostřednictvím vlastností buněk a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové indexy pro přístup k buňkám tabulky v pořadí `(sloupec, řádek)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevírá existující prezentaci a přistupuje k prvnímu tvaru na první snímku jako k tabulce. Předpokládá, že snímek a tvar existují a že tvar je tabulka. Poté prochází všechny řádky a sloupce a pomocí [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) identifikuje buňky ve sloučených oblastech. Pro každou shodu vypisuje souřadnice buňky v pořadí `řádek;sloupec`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/) a počáteční souřadnice oblasti, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) a [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Odstranění okrajů buněk tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) a přidejte tabulku na první snímek pomocí [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři okraje buňky na [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), čímž je učiní neviditelnými.

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

## **Přidání úhlopříčných okrajů buněk**

Použijte [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) k vykreslení čáry od levého horního rohu k pravému dolnímu a [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) k vykreslení čáry od levého dolního rohu k pravému hornímu. Úhlopříčka může označovat záhlaví rohu; obě úhlopříčky mohou vytvořit X, aby označily buňku jako neaplikovatelnou.

Každá úhlopříčka je [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/). V jeho [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) použijte [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) k výběru [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) a zvolte barvu pomocí [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/). Šířku čáry nastavte v bodech pomocí [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/).

Příklad vytvoří tři buňky v jednom řádku: červenou úhlopříčku dolů, modrou úhlopříčku nahoru a obě úhlopříčky. Zachová neporušené horní, dolní, levé a pravé okraje buňky.

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

Úhlopříčka je formátovací vlastnost, nikoli rozdělení buňky. Každá buňka si zachovává jediný textový rámec, přístupný přes [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/); oblasti na obou stranách úhlopříčky nelze upravovat nezávisle.

Uložená tabulka, vykreslená v Microsoft PowerPoint:

![Tři buňky tabulky zobrazující červenou úhlopříčku z levého horního rohu do pravého dolního, modrou úhlopříčku z levého dolního rohu do pravého horního a obě úhlopříčky tvořící X.](diagonal-cell-borders.png)

*Zleva doprava: úhlopříčka dolů (červená, 3 pt), úhlopříčka nahoru (modrá, 5 pt) a obě úhlopříčky.*

## **Sloučení buněk tabulky**

Použijte [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) k sloučení obdélníkové oblasti buněk tabulky do jedné buňky. Zadejte buňky v levém horním a pravém dolním rohu oblasti. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadanou oblast; `false` udržuje sloučení v rámci této oblasti.

Příklad vytvoří tabulku 4 × 4 s 70‑bodovými sloupci a řádky, poté sloučí čtyři centrální buňky od `(1, 1)` po `(2, 2)`. Výsledná buňka zabírá dva sloupce a dva řádky, zatímco podkladová mřížka tabulky si zachová čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její levou horní pozici: `table.get_Item(1, 1)` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nemění.

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

## **Rozdělení buněk tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec mřížky a změnit indexy sloupců buněk vpravo. Aspose.Slides následuje model mřížky tabulky v PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 s 70‑bodovými sloupci a řádky a zavolá [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) na buňce `(1, 1)`. Polovina šířky buňky 70 bodů je předána k vytvoření dvou buněk se stejnou šířkou.

Po tomto rozdělení jsou obě poloviny přístupné jako `table.get_Item(1, 1)` a `table.get_Item(2, 1)`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se posunou na sloupce 3 a 4. Indexy řádků zůstávají nezměněny. Používejte aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

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
[![Nelze sloučená buňka 70 bodů se rozdělí na dvě buňky po 35 bodů, což přidá pátý sloupec mřížky a posune indexy napravo.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Rozdělení šířky se týká buňky (1, 1) při nulových (sloupec, řádek) indexech. Ostatní řádky zachovávají buňku, která zasahuje oba nové sloupcové pozice.* 
<!-- visual-explanation:manage-cells:end -->

### **Rozdělení sloučených buněk podle rozsahu řádku nebo sloupce**

Pro přípravu sloučených šablonových buněk k naplnění daty použijte [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) k rozdělení podél existující řádkové hranice nebo [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) k rozdělení podél sloupcové hranice.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučenému regionu:

- Rozdělení řádku: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Rozdělení sloupce: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Příklad očekává, že prezentace má tabulku jako první tvar na prvním snímku, přičemž buňky `(1, 2)` a `(1, 3)` jsou sloučeny vertikálně. Od dolní pozice používá [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) a [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) k nalezení počátku a kontroluje oba rozsahy. `splitByRowSpan(1)` potom odděluje řádky 2 a 3 pro názvy produktů. Pro vodorovné sloučení dvou sloupců použijte místo toho `splitByColSpan(1)`.

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

        // Získat výsledné buňky z tabulky po rozdělení.
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

Mřížka tabulky a okolní indexy buněk zůstávají nezměněny. Získané buňky můžete načíst podle jejich souřadnic; zde obě mají rozsah 1 a [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) vrací `false`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučené.

Původní text a jeho formátování zůstává v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, okraje a okraje. Naplňte buňky po rozdělení a nastavte jakékoli požadované formátování textu výslovně.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ s zachovaným formátováním šablonové buňky. Viz [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) pro podrobnosti.

### **Rozdělení buňky na konkrétní výšku**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) přijímá výšku horní části v bodech. [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) přijímá počet existujících řádkových mřížek v horní části. Pro vycentrování buňky 40 bodů v pravém sloupci odečtěte 40 od skutečné výšky buňky a zbývající prostor rovnoměrně rozdělte nad a pod ní.

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

První rozdělení přidá řádek mřížky a zanechá spodních 90 bodů v buňce `(1, 1)`. Druhé rozdělení rozdělí tuto buňku na střední buňku 40 bodů a spodní buňku 50 bodů. Pravý sloupec nyní obsahuje tři buňky s výškami 50, 40 a 50 bodů odshora dolů. Levá buňka zasahuje všechny tři řádky a zachovává původní výšku 140 bodů.

![Levá buňka zasahuje celou výšku tabulky vedle tří buněk, přičemž prostřední buňka je uprostřed.](split-by-height.png)

## **Změna barvy pozadí buňky tabulky**

Tento příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Použije [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) k výběru plné výplně a nastaví barvu vrácenou metodou [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) na červenou pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku.

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

## **Přidání obrázku do buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) a přidá jej do kolekce obrázků prezentace pomocí [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Poté přiřadí obrázek jako výplň obrázku buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) roztaže obrázek tak, aby vyplnil buňku, což může změnit jeho poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je uvolněn v bloku `finally` po jeho přidání do prezentace.

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

## **Často kladené otázky**

**Mohu nastavit různé tloušťky a styly čar pro různé strany jedné buňky?**

Ano. Okraje [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/), [bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/), [left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/) a [right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) mají samostatné vlastnosti, takže se tloušťka a styl každé strany mohou lišit.

**Co se stane s obrázkem, pokud změním velikost sloupce/řádku po nastavení obrázku jako pozadí buňky?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Při roztažení se obrázek přizpůsobí nové buňce, při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz ke všemu obsahu buňky?**

[Hyperlinks](/slides/cs/nodejs-java/manage-hyperlinks/) jsou nastaveny na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz buď k části, nebo ke všemu textu v buňce.

**Mohu nastavit různé fonty v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (úseky) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.