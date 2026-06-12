---
title: Spravujte řádky a sloupce v tabulkách PowerPoint pomocí JavaScriptu
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
- odstranit sloupec
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

Aby vám umožnil spravovat řádky a sloupce tabulky v prezentaci PowerPoint, Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/table/) a další typy.

## **Nastavit první řádek jako hlavičku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a načtěte prezentaci.  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Vytvořte objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) a nastavte jej na null.  
4. Projděte všechny objekty [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) a najděte odpovídající tabulku.  
5. Nastavte první řádek tabulky jako její hlavičku.  

Tento JavaScriptový kód vám ukazuje, jak nastavit první řádek tabulky jako její hlavičku:

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Získá první snímek
    var sld = pres.getSlides().get_Item(0);
    // Inicializuje null TableEx
    var tbl = null;
    // Prochází tvary a nastaví odkaz na tabulku
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Nastaví první řádek tabulky jako její záhlaví
            tbl.setFirstRow(true);
        }
    }
    // Uloží prezentaci na disk
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Klonovat řádek nebo sloupec tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a načtěte prezentaci,  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Definujte pole `columnWidth`.  
4. Definujte pole `rowHeight`.  
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Klonujte řádek tabulky.  
7. Klonujte sloupec tabulky.  
8. Uložte upravenou prezentaci.  

Tento JavaScriptový kód vám ukazuje, jak klonovat řádek nebo sloupec tabulky PowerPoint:

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Získá první snímek
    var sld = pres.getSlides().get_Item(0);
    // Definuje sloupce s šířkami a řádky s výškami
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Přidá tvar tabulky na snímek
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Přidá text do buňky řádku 1, buňky 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Přidá text do buňky řádku 1, buňky 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Klonuje řádek 1 na konci tabulky
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Přidá text do buňky řádku 2, buňky 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Přidá text do buňky řádku 2, buňky 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Klonuje řádek 2 jako 4. řádek tabulky
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Klonuje první sloupec na konci
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Klonuje druhý sloupec na pozici čtvrtého sloupce
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Uloží prezentaci na disk
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranit řádek nebo sloupec z tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a načtěte prezentaci,  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Definujte pole `columnWidth`.  
4. Definujte pole `rowHeight`.  
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Odstraňte řádek tabulky.  
7. Odstraňte sloupec tabulky.  
8. Uložte upravenou prezentaci.  

Tento JavaScriptový kód vám ukazuje, jak odstranit řádek nebo sloupec z tabulky:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavit formátování textu na úrovni řádku tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a načtěte prezentaci,  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Získejte příslušný objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) ze snímku.  
4. Nastavte buňkám v prvním řádku [setFontHeight(float value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Nastavte buňkám v prvním řádku [setAlignment(int value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Nastavte buňkám ve druhém řádku [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Uložte upravenou prezentaci.  

Tento JavaScriptový kód demonstruje operaci.

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Předpokládejme, že první tvar na prvním snímku je tabulka
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Nastaví výšku písma buněk v prvním řádku
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Nastaví zarovnání textu a pravý okraj buněk v prvním řádku
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Nastaví typ svislého textu buněk ve druhém řádku
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Uloží prezentaci na disk
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a načtěte prezentaci,  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Získejte příslušný objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Table) ze snímku.  
4. Nastavte buňkám v prvním sloupci [setFontHeight(float value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Nastavte buňkám v prvním sloupci [setAlignment(int value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Nastavte buňkám ve druhém sloupci [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Uložte upravenou prezentaci.  

Tento JavaScriptový kód demonstruje operaci:

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Předpokládejme, že první tvar na prvním snímku je tabulka
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Nastaví výšku písma buněk v prvním sloupci
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Nastaví zarovnání textu a pravý okraj buněk v prvním sloupci v jednom volání
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Nastaví typ svislého textu buněk ve druhém sloupci
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Získat vlastnosti stylu tabulky**

Aspose.Slides vám umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo kdekoli jinde. Tento JavaScriptový kód vám ukazuje, jak získat vlastnosti stylu z přednastaveného stylu tabulky:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// změní výchozí předdefinovaný styl tématu
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu použít motivy/styly PowerPoint na již vytvořenou tabulku?**

Ano. Tabulka dědí motiv snímku/podkladu/masteru a můžete stále přepsat výplně, okraje a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Nejprve seřaďte data v paměti a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít pruhované (proužkované) sloupce a zároveň zachovat vlastní barvy u konkrétních buněk?**

Ano. Zapněte pruhované sloupce, poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.