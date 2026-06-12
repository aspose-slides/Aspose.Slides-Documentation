---
title: Správa buněk tabulky v prezentacích pomocí JavaScriptu
linktitle: Správa buněk
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
description: "Spravujte buňky tabulky v PowerPointu pomocí Aspose.Slides pro Node.js. Ovládněte rychlý přístup, úpravy a styling buněk pro bezproblémovou automatizaci snímků."
---
## **Přehled**

Aspose.Slides umožňuje přistupovat k buňkám tabulky v PowerPoint prezentacích a upravovat je. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky prostřednictvím vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

## **Identifikace sloučené buňky tabulky**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte tabulku z prvního snímku. 
3. Procházejte řádky a sloupce tabulky a najděte sloučené buňky.
4. Vytiskněte zprávu, když jsou nalezeny sloučené buňky.

Tento JavaScriptový kód ukazuje, jak identifikovat sloučené buňky tabulky v prezentaci:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0); // předpokládáme, že Slide#0.Shape#0 je tabulka
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranění okrajů buněk tabulky**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Procházejte každou buňku a vymažte horní, dolní, pravý a levý okraj.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak odstranit okraje z buněk tabulky:

```javascript
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Přidá tvar tabulky na snímek
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Nastaví formát okraje pro každou buňku
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Zapíše PPTX na disk
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Číslování ve sloučených buňkách**
Pokud sloučíme 2 páry buněk (1, 1) x (2, 1) a (1, 2) x (2, 2), výsledná tabulka bude očíslovaná. Tento JavaScriptový kód demonstruje proces:

```javascript
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Přidá tvar tabulky na snímek
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Nastavuje formát okraje pro každou buňku
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Sloučí buňky (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Sloučí buňky (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Poté buňky dále sloučíme sloučením (1, 1) a (1, 2). Výsledkem je tabulka obsahující velkou sloučenou buňku uprostřed:

```javascript
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Přidá tvar tabulky na snímek
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Nastavuje formát okraje pro každou buňku
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Sloučí buňky (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Sloučí buňky (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Sloučí buňky (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Zapíše soubor PPTX na disk
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Číslování v rozdělené buňce**
V předchozích příkladech, když byly buňky tabulky sloučeny, číslování v ostatních buňkách se nezměnilo.

Tento krátký příklad vezme běžnou tabulku (tabulku bez sloučených buněk) a následně rozdělí buňku (1,1), aby vznikla zvláštní tabulka. Všimněte si číslování této tabulky, které může působit podivně. Jedná se však o způsob, jakým Microsoft PowerPoint čísluje buňky tabulky, a Aspose.Slides dělá to samé.

Tento JavaScriptový kód demonstruje popsaný proces:

```javascript
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Přidá tvar tabulky na snímek
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Nastavuje formát okraje pro každou buňku
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Sloučí buňky (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Sloučí buňky (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Rozdělí buňku (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Zapíše soubor PPTX na disk
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Změna barvy pozadí buňky tabulky**

Tento JavaScriptový kód ukazuje, jak změnit barvu pozadí buňky tabulky:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // vytvoří novou tabulku
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // nastaví barvu pozadí buňky
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Přidání obrázku do buňky tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Vytvořte objekt `Images` pro uložení souboru obrázku.
7. Přidejte obrázek `IImage` do objektu `PPImage`.
8. Nastavte `FillFormat` buňky tabulky na `Picture`.
9. Přidejte obrázek do první buňky tabulky.
10. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vložit obrázek do buňky tabulky při vytváření tabulky:

```javascript
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var islide = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Přidá tvar tabulky na snímek
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Vytvoří objekt PPImage pomocí souboru obrázku
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Přidá obrázek do první buňky tabulky
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Uloží soubor PPTX na disk
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Mohu nastavit různé tloušťky a styly čar pro různé strany jedné buňky?**

Ano. Okraje [horní](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellformat/getbordertop/), [dolní](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellformat/getborderbottom/), [levý](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellformat/getborderleft/) a [pravý](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellformat/getborderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit. Toto logicky vyplývá z řízení okrajů po jednotlivých stranách buňky, jak je ukázáno v článku.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [režimu výplně](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillmode/) (roztažení/dlaždice). Při roztažení se obrázek přizpůsobí nové buňce; při dláždění se dlaždice přepočítají. Článek zmiňuje režimy zobrazení obrázku v buňce.

**Mohu přiřadit hypertextový odkaz k veškerému obsahu buňky?**

[Hyperlinks](/slides/cs/nodejs-java/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/objektu. V praxi odkaz přiřadíte buď k části textu, nebo k celému textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) (běhy) s nezávislým formátováním – rodina písma, styl, velikost a barva.