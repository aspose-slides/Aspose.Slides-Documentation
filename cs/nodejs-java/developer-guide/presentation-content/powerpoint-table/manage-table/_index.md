---
title: Správa tabulek v prezentaci v JavaScriptu
linktitle: Správa tabulky
type: docs
weight: 10
url: /cs/nodejs-java/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnat text
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint snímcích pomocí JavaScriptu a Aspose.Slides pro Node.js. Objevte jednoduché příklady kódu pro zjednodušení vašich pracovních postupů s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak zobrazit a představit informace. Informace v mřížce buněk (uspořádaných v řádcích a sloupcích) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) , třídu [Cell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/) a další typy, které vám umožňují vytvářet, aktualizovat a spravovat tabulky ve všech druzích prezentací.

## **Vytvoření tabulky od nuly**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Definujte pole `columnWidth`.
4. Definujte pole `rowHeight`.
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) .
6. Projděte každou [Cell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/) a aplikujte formátování na horní, dolní, pravý a levý okraj.
7. Sloučte čtyři buňky v levém horním rohu tabulky (první dva sloupce prvních dvou řádků) do jedné buňky. 
8. Získejte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) buňky [Cell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/) .
9. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) .
10. Uložte upravenou prezentaci.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciace třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Přidá tvar tabulky na snímek
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Nastaví formát ohraničení pro každou buňku
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Sloučí blok 2x2 v levém horním rohu buněk do jedné buňky
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Přidá nějaký text do sloučené buňky
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Uloží prezentaci na disk
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce je číslování buněk jednoduché a začíná od nuly. První buňka v tabulce má index 0,0 (sloupec 0, řádek 0). 

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento JavaScriptový kód ukazuje, jak určit číslování buněk v tabulce:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciace třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Přidá tvar tabulky na snímek
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Nastaví formát ohraničení pro každou buňku
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
    // Uloží prezentaci na disk
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek obsahující tabulku pomocí jeho indexu. 
3. Vytvořte objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) a nastavte jej na null.
4. Procházejte všechny objekty [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) , dokud nenajdete tabulku.

   Pokud předpokládáte, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše zkontrolovat všechny tvary, které obsahuje. Když je tvar identifikován jako tabulka, můžete jej přetypovat na objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) . Pokud však snímek obsahuje několik tabulek, je lepší hledat požadovanou tabulku pomocí jejího [setAlternativeText(String value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) .
5. Použijte objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) , abyste pracovali s tabulkou. V následujícím příkladu nastavíme text buňky v tabulce.
6. Uložte upravenou prezentaci.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciace třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Inicializuje null TableEx
    var tbl = null;
    // Prochází tvary a nastaví odkaz na nalezenou tabulku
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Nastaví text pro první sloupec druhého řádku
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Uloží upravenou prezentaci na disk
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Najít buňku, která vlastní TextFrame**

Když obecný kód pro zpracování textu získá [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) z tabulky, použijte metodu [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentCell--) k získání vlastnící [Cell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/). Pro textové rámečky v buňkách tabulky [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentCell--) vrací vlastníka a [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentShape--) vrací `null`, i když samotná tabulka je tvar.

Souřadnice buňky jsou dostupné prostřednictvím jen pro čtení metod [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) a [Cell.getFirstRowIndex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) . [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentCell--) také poskytuje navigaci jen pro čtení: vrací vlastníka, ale nemění vlastnictví. Vždy před použitím zkontrolujte, zda vrácená buňka není `null` .

Pro kompletní příklad, který identifikuje vlastníky buněk tabulky a tvarů, včetně tvarů spojených se SmartArt uzly, viz [Search and Replace Text](/slides/cs/nodejs-java/search-and-replace-text/) .

## **Zarovnání textu v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) na snímek.
4. Získejte objekt [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) z tabulky.
5. Získejte [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) .
6. Zarovnejte text vertikálně.
7. Uložte upravenou prezentaci.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var slide = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Přidá tvar tabulky na snímek
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Přistupuje k textovému rámci
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Vytvoří objekt Paragraph pro textový rámec
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Vytvoří objekt Portion pro odstavec
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Zarovnává text vertikálně
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Uloží prezentaci na disk
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) ze snímku.
4. Nastavte [setFontHeight(float value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pro text.
5. Nastavte [setAlignment(int value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Nastavte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Uložte upravenou prezentaci. 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Předpokládejme, že první tvar na prvním snímku je tabulka
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Nastaví výšku písma buněk tabulky
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Nastaví zarovnání textu buněk tabulky a pravý okraj v jednom volání
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Nastaví vertikální typ textu buněk tabulky
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení předdefinovaného stylu tabulky**

Aspose.Slides poskytuje vestavěné styly tabulek PowerPointu jako výčet [TableStylePreset](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tablestylepreset/) , takže můžete použít stejný vzhled na libovolnou tabulku. Tento JavaScriptový kód ukazuje, jak nahradit výchozí styl tabulky předdefinovaným stylem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// změnit výchozí předdefinovaný styl
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Uzamčení poměru stran tabulky**

Poměr stran geometrického tvaru je poměr jeho rozměrů v různých dimenzích. Aspose.Slides poskytuje vlastnost [**setAspectRatioLocked**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) , která umožňuje uzamknout nastavení poměru stran pro tabulky a další tvary.

Tento JavaScriptový kód ukazuje, jak uzamknout poměr stran pro tabulku:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [setRightToLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/table/setrighttoleft/) , a odstavce mají [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) . Použitím obou zajistíte správné pořadí RTL a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesouvání nebo změně velikosti tabulky v konečném souboru?**

Použijte zamykání tvarů k zakázání přesouvání, změny velikosti, výběru atd. Tyto zámky platí i pro tabulky.

**Je podporováno vkládání obrázku do buňky jako pozadí?**

Ano. Pro buňku můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/) , obrázek pak pokryje oblast buňky podle zvoleného režimu (roztáhnout nebo dlaždice).