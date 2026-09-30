---
title: Správa řádků a sloupců v tabulkách PowerPoint pomocí JavaScriptu
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/nodejs-java/manage-rows-and-columns/
keywords:
- řádek tabulky
- sloupec tabulky
- první řádek
- záhlaví tabulky
- klonovat řádek
- klonovat sloupec
- kopírovat řádek
- kopírovat sloupec
- odstranit řádek
- odst

r

it

sloupec
- formátování textu řádku
- formátování textu sloupce
- styl tabulky
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java a zrychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aspose.Slides for Node.js via Java vám umožňuje spravovat strukturu tabulky a formátování v prezentacích PowerPoint pomocí třídy [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Můžete označit řádek jako záhlaví, klonovat nebo odstraňovat řádky a sloupce a aplikovat formátování textu na celý řádek nebo sloupec.

Tento článek vysvětluje tyto operace pomocí příkladů v JavaScriptu. Také ukazuje, jak získat přednastavený styl tabulky, abyste jej mohli znovu použít. Indexy řádků a sloupců tabulky jsou nulové.

## **Ovládání výšky řádku**

Použijte [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) k nastavení minimální výšky řádku v bodech. Jedná se o spodní mez, nikoli pevnou výšku. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) vrací skutečnou výšku. Přístup k řádku získáte pomocí [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

Příklad načte [row-height-input.pptx](row-height-input.pptx), který má tabulku jako první tvar na první snímku. Jeho první řádek začíná ve výšce 70 bodů. Buňky používají text Arial 18 bodů, zalamování a horní a dolní okraje 6 bodů; delší text ve druhém sloupci se zalamuje do více řádků. Příklad zvýší minimum na 100 bodů, poté ho sníží na 20 bodů, po každé změně vypíše skutečnou výšku a uloží oba výsledky.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

U poskytnuté prezentace zvyšování minima přidává řádku prostor. Snížení odstraňuje tento nadbytečný prostor, ale skutečná výška zůstává větší než 20 bodů, protože text a okraje buněk potřebují více místa. Pouhé snížení minima nemůže řádek přinutit podmínku prostoru vyžadovaného jeho obsahem.

Několik faktorů ovlivňuje skutečnou výšku:

- **Text a velikost písma:** delší text, explicitní zalomení řádků nebo větší písmo může vyžadovat více svislého prostoru.
- **Zalamování a šířka sloupce:** při povoleném zalamování může zmenšení šířky sloupce pomocí [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) vytvořit více řádků. Širší sloupec může snížit vertikální požadovaný prostor.
- **Okraje buněk:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) a [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) přidávají svislý prostor. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) a [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) zmenšují šířku dostupnou pro text a mohou způsobit další zalamování.

Pro tuto tabulku bez sloučených buněk určuje buňka, která potřebuje nejvíce svislého prostoru, obsahově řízený spodní limit pro celý řádek. Aby byl řádek kratší, možná budete muset také zkrátit text, snížit velikost písma nebo okraje, nebo rozšířit sloupec.

Obrázky níže ukazují stejnou tabulku ve stejném měřítku. Ve výsledcích byly skutečné výšky 70, 100 a 55,2 bodu: poslední řádek zůstával vyšší než jeho minimum 20 bodů. Přesná měření textu se mohou lišit podle dostupných písem ve vašem prostředí. Stáhněte si uložené výsledky: [increased minimum](row-height-increased.pptx) a [decreased minimum](row-height-decreased.pptx).

| Originál: minimum 70 pt, skutečná 70 pt | Zvýšeno: minimum 100 pt, skutečná 100 pt | Sníženo: minimum 20 pt, skutečná 55.2 pt |
| --- | --- | --- |
| ![Původní tabulka s prvním řádkem 70 bodů.](row-height-before.png) | ![Tabulka po zvýšení minima prvního řádku na 100 bodů.](row-height-increased.png) | ![Tabulka po snížení minima prvního řádku na 20 bodů; zalomený text udržuje řádek vyšší než minimum.](row-height-decreased.png) |

## **Nastavit první řádek jako záhlaví**

Použijte metodu [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) , abyste označili první řádek pro formátování záhlaví. Jeho vzhled závisí na stylu tabulky aplikovaném na tabulku.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Získejte tabulku uloženou jako první tvar na snímku.
4. Povolte formátování záhlaví pro její první řádek.
5. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první tvar na první snímku. Povólí formátování záhlaví pro první řádek a uloží `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Klonovat řádek nebo sloupec tabulky**

Klonujte řádky nebo sloupce, abyste znovu použili jejich obsah a formátování. Můžete připojit kopii na konec tabulky nebo ji vložit na konkrétní pozici.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Klonujte požadované řádky.
6. Klonujte požadované sloupce.
7. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `Test.pptx` s alespoň jedním snímkem. Vytvoří tabulku se třemi sloupci a pěti řádky, přičemž rozměry jsou zadány v bodech. Přidá kopie prvního řádku a sloupce, poté vloží kopie druhého řádku a sloupce na index 3 (čtvrtá pozice). Výsledná tabulka má sedm řádků a pět sloupců. Argument `false` zakazuje klonování do sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odstranit řádek nebo sloupec z tabulky**

Odstraňte řádky nebo sloupce, které již v tabulce nejsou potřeba. Odstranění položky posune indexy řádků nebo sloupců, které ji následují.

1. Vytvořte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Odstraňte druhý řádek a druhý sloupec.
6. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 3 × 3 a odstraní řádek a sloupec na indexu 1, což zanechá tabulku 2 × 2 v souboru `TestTable_out.pptx`. Rozměry jsou v bodech. Argument `false` zakazuje odstraňování sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit formátování textu na úrovni řádku tabulky**

Aplikujte formátování textu na celý řádek, aby buňky zůstaly jednotné. Můžete nastavit vlastnosti písma, formátování odstavce a směr textu bez formátování každé buňky zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte tabulku na prvním snímku.
3. Použijte [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pro první řádek.
4. Použijte [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) a [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) pro první řádek.
5. Použijte [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) pro druhý řádek.
6. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první tvar na první snímku a alespoň dvěma řádky. Aplikuje text o velikosti 25 bodů, zarovnání vpravo a pravý okraj odstavce 20 bodů na první řádek, poté nastaví vertikální text ve druhém řádku.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

Aplikujte formátování textu na celý sloupec, aby buňky zůstaly jednotné. Můžete nastavit vlastnosti písma, formátování odstavce a směr textu bez formátování každé buňky zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Získejte tabulku na prvním snímku.
3. Použijte [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pro první sloupec.
4. Použijte [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) a [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) pro první sloupec.
5. Použijte [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) pro druhý sloupec.
6. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první tvar na první snímku a alespoň dvěma sloupci. Aplikuje text o velikosti 25 bodů, zarovnání vpravo a pravý okraj odstavce 20 bodů na první sloupec, poté nastaví vertikální text ve druhém sloupci.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Získat vlastnosti stylu tabulky**

Použijte metodu [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) k získání přednastaveného stylu aplikovaného na tabulku a jeho opětovnému použití na jiné tabulce. Identifikuje přednastavení místo jednotlivých přepsání formátování buněk.

Příklad vytvoří tabulku, použije [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1), a načte zpět přednastavení. Vypíše celočíselnou hodnotu odpovídající `DarkStyle1` a uloží tabulku do souboru `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu aplikovat motivy/styly PowerPointu na již vytvořenou tabulku?**

Ano. Tabulka dědí motiv snímku/podkladu/mistra a přesto můžete přepsat výplně, okraje a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Nejprve setřiďte data v paměti a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít pruhované sloupce a zároveň mít vlastní barvy v konkrétních buňkách?**

Ano. Zapněte pruhované sloupce a poté přepište konkrétní buňky místním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.