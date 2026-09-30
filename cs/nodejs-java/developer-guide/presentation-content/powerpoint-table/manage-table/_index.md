---
title: Správa tabulek v prezentacích v JavaScriptu
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/nodejs-java/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnání textu
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint snímcích pomocí JavaScriptu a Aspose.Slides pro Node.js. Objevte jednoduché ukázky kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulky v PowerPointu organizují informace do řádků a sloupců, což usnadňuje čtení a porovnávání hodnot.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , třídu [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) a další typy, které vám umožňují vytvářet, aktualizovat a spravovat tabulky v prezentacích.

## **Vytvoření tabulky od začátku**

Vytvořte tabulku zadáním její pozice, šířek sloupců a výšek řádků. Po přidání do snímku můžete formátovat okraje buněk, slučovat buňky a vkládat text.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte pole šířek sloupců v bodech.
4. Definujte pole výšek řádků v bodech.
5. Přidejte objekt [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) do snímku pomocí metody [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-).
6. Procházejte každou [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) a aplikujte formátování na horní, dolní, pravý a levý okraj.
7. Sloučte první dvě buňky v první řadě tabulky.
8. Získejte přístup ke sloučené buňce pomocí její metody [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--).
9. Nastavte text ve sloučené buňce.
10. Uložte upravenou prezentaci.

Níže uvedený příklad vytvoří tabulku se třemi sloupci a pěti řádky v bodových souřadnicích (100, 50). Aplikuje červené okraje o šířce 5 bodů, sloučí první dvě buňky v první řadě a uloží výsledek jako `table.pptx`.

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

## **Číslování ve standardní tabulce**

Ve standardní tabulce jsou indexy buněk nulové a používají pořadí (sloupec, řádek). První buňka má index (0, 0).

Například buňky v tabulce se 4 sloupci a 4 řádky jsou očíslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento příklad vytvoří tabulku 4 × 4 znázorněnou výše, se šířkami sloupců a výškami řádků 70 bodů a červenými okraji buněk o šířce 5 bodů. Souřadnice ilustrují indexy buněk; příklad ponechá buňky prázdné a uloží tabulku jako `StandardTables_out.pptx`.

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

## **Přístup k existující tabulce**

Tabulky jsou uloženy ve sbírce tvarů snímku. Procházejte tvary, abyste našli tabulku, a poté použijte třídu [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) k načtení nebo aktualizaci jejích buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující tabulku podle jeho indexu.
3. Procházejte objekty [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) a zastavte se, když je nalezena tabulka. Pokud snímek obsahuje několik tabulek, použijte [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) k identifikaci té, kterou potřebujete.
4. Aktualizujte text v cílové buňce.
5. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `UpdateExistingTable.pptx` a najde první tabulku na první snímku. Nastaví buňku ve sloupci 0, řádku 1 na `New` a uloží výsledek jako `table1_out.pptx`. Vstup musí obsahovat alespoň jeden snímek a první tabulka na tomto snímku musí mít alespoň jeden sloupec a dva řádky.

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

Pro změnu velikosti řádku v existující tabulce a pochopení, proč jeho skutečná výška může přesáhnout požadované minimum, viz [Ovládání výšky řádku](/slides/cs/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Najít buňku, která vlastní textový rámec**

Když obecný kód pro zpracování textu získá [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) z tabulky, použijte metodu [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) k získání vlastnické [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/). Pro textový rámec buňky tabulky [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) vrací vlastníka a [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) vrací `null`, i když samotná tabulka je tvar.

Souřadnice buňky jsou k dispozici prostřednictvím metod jen pro čtení [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) a [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) . [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) také poskytuje navigaci jen pro čtení: vrací vlastníka, ale nemění vlastnictví. Vždy před použitím zkontrolujte, zda vrácená buňka není `null`.

Pro úplný příklad identifikující vlastníky buněk tabulky i tvarů, včetně tvarů spojených se SmartArt uzly, viz [Vyhledávání a nahrazování textu](/slides/cs/nodejs-java/search-and-replace-text/).

## **Zarovnání textu v tabulce**

Můžete řídit vertikální ukotvení a směr textu jednotlivých buněk tabulky. Příklad v této sekci vycentruje text v první buňce a otočí jej o 270 stupňů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) do snímku.
4. Získejte objekt [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) z tabulky.
5. Získejte první [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) a nastavte jeho text a barvu.
6. Nastavte vertikální ukotvení buňky a směr textu pomocí [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) a [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 4 × 4 se šířkami sloupců 120 bodů a výškami řádků 100 bodů. Formátuje text v buňce (0, 0), přidá hodnoty do zbývajících buněk v první řadě a uloží výsledek jako `Vertical_Align_Text_out.pptx`.

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

## **Nastavení formátování textu na úrovni tabulky**

Použijte [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) k aplikaci formátování textu na všechny buňky v tabulce. Jeho přetížení přijímají formátování úsečků, odstavců a textových rámců, takže můžete nastavit tyto vlastnosti bez procházení jednotlivých buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte objekt [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) ze snímku.
4. Nastavte velikost písma pomocí [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pro text.
5. Nastavte zarovnání odstavce a pravý okraj pomocí [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) a [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Nastavte směr textu pomocí [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `table.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Nastaví velikost písma na 25 bodů, zarovná odstavce vpravo s pravým okrajem 20 bodů a nastaví text na vertikální. Formátovaná prezentace je uložena jako `result.pptx`.

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

## **Získání vlastností stylu tabulky**

Použijte [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) k načtení předdefinovaného stylu tabulky a [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) k jeho přiřazení. Tento příklad aplikuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) na jednu tabulku, vytiskne hodnotu předvolby a přiřadí stejnou předvolbu druhé tabulce. Obě tabulky jsou uloženy v `table-style.pptx`.

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

## **Uzamčení poměru stran tabulky**

Poměr stran tabulky je poměr její šířky k výšce. Pomocí [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) můžete tento poměr pro tabulku uzamknout.

Níže uvedený příklad otevře `pres.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Vytiskne aktuální stav uzamčení, povolí uzamčení poměru stran, vytiskne aktualizovaný stav (`true`) a uloží výsledek jako `pres-out.pptx`.

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

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka nabízí metodu [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-), a odstavce mají [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Použití obou zajišťuje správné RTL pořadí a vykreslování uvnitř buněk.

**Jak mohu zabránit uživatelům přesouvat nebo měnit velikost tabulky v konečném souboru?**

Použijte [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) k zakázání přesunu, změny velikosti, výběru atd. Tyto zámky se vztahují také na tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztáhnout nebo dlaždice).