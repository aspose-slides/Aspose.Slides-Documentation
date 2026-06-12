---
title: Spravovat řádky a sloupce v tabulkách PowerPoint pomocí Javy
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/java/manage-rows-and-columns/
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
- Java
- Aspose.Slides
description: "Spravujte řádky a sloupce tabulek v PowerPointu pomocí Aspose.Slides pro Javu a zrychlete úpravy prezentace a aktualizace dat."
---
## **Úvod**

Aby bylo možné spravovat řádky a sloupce tabulky v prezentaci PowerPoint, poskytuje Aspose.Slides třídu [Table](https://reference.aspose.com/slides/cs/java/com.aspose.slides/table/) , rozhraní [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) a mnoho dalších typů. 

## **Nastavit první řádek jako záhlaví**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte prezentaci. 
2. Získejte referenci snímku podle jeho indexu. 
3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) a přiřaďte mu hodnotu null. 
4. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) a najděte požadovanou tabulku. 
5. Nastavte první řádek tabulky jako záhlaví. 

Tento Java kód ukazuje, jak nastavit první řádek tabulky jako záhlaví:

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializuje nulový TableEx
    ITable tbl = null;

    // Prochází tvary a nastaví referenci na tabulku
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Nastaví první řádek tabulky jako záhlaví
            tbl.setFirstRow(true);
        }
    }
    
    // Uloží prezentaci na disk
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Klonovat řádek nebo sloupec tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte prezentaci, 
2. Získejte referenci snímku podle jeho indexu. 
3. Definujte pole `columnWidth`. 
4. Definujte pole `rowHeight`. 
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Zklonujte řádek tabulky. 
7. Zklonujte sloupec tabulky. 
8. Uložte upravenou prezentaci. 

Tento Java kód ukazuje, jak klonovat řádek nebo sloupec tabulky v PowerPointu:

```java
 // Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Přidá tvar tabulky na snímek
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Přidá text do buňky řádku 1 sloupce 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Přidá text do buňky řádku 1 sloupce 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Zklonuje řádek 1 na konci tabulky
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Přidá text do buňky řádku 2 sloupce 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Přidá text do buňky řádku 2 sloupce 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Zklonuje řádek 2 jako čtvrtý řádek tabulky
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Zklonuje první sloupec na konci
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Zklonuje druhý sloupec na indexu čtvrtého sloupce
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Uloží prezentaci na disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranit řádek nebo sloupec z tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte prezentaci, 
2. Získejte referenci snímku podle jeho indexu. 
3. Definujte pole `columnWidth`. 
4. Definujte pole `rowHeight`. 
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Odeberte řádek tabulky. 
7. Odeberte sloupec tabulky. 
8. Uložte upravenou prezentaci. 

Tento Java kód ukazuje, jak odstranit řádek nebo sloupec z tabulky:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit formátování textu na úrovni řádku tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte prezentaci, 
2. Získejte referenci snímku podle jeho indexu. 
3. Získejte odpovídající objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) ze snímku. 
4. Nastavte buňkám v prvním řádku [setFontHeight(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Nastavte buňkám v prvním řádku [setAlignment(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Nastavte buňkám ve druhém řádku [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Uložte upravenou prezentaci. 

Tento Java kód demonstruje operaci.

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Předpokládejme, že první tvar na prvním snímku je tabulka
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Nastaví výšku písma buněk v prvním řádku
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Nastaví zarovnání textu a pravý okraj buněk v prvním řádku
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Nastaví vertikální typ textu buněk ve druhém řádku
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Uloží prezentaci na disk
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte prezentaci, 
2. Získejte referenci snímku podle jeho indexu. 
3. Získejte odpovídající objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) ze snímku. 
4. Nastavte buňkám v prvním sloupci [setFontHeight(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Nastavte buňkám v prvním sloupci [setAlignment(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Nastavte buňkám ve druhém sloupci [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Uložte upravenou prezentaci. 

Tento Java kód demonstruje operaci: 

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Předpokládejme, že první tvar na prvním snímku je tabulka
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Nastaví výšku písma buněk v prvním sloupci
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Nastaví zarovnání textu a pravý okraj buněk v prvním sloupci jedním voláním
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Nastaví vertikální typ textu buněk ve druhém sloupci
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Získat vlastnosti stylu tabulky**

Aspose.Slides umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo jinde. Tento Java kód ukazuje, jak získat vlastnosti stylu z přednastaveného stylu tabulky:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // změnit výchozí přednastavený styl motivu
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu na již vytvořenou tabulku použít motivy/styly PowerPointu?**

Ano. Tabulka dědí motiv snímku/podkladu/mistra a můžete nad tím motivem stále přepsat výplně, okraje a barvy textu.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Nejprve seřaďte data v paměti a poté znovu naplňte řádky tabulky v tom pořadí.

**Mohu mít pruhované (striped) sloupce a zároveň zachovat vlastní barvy v konkrétních buňkách?**

Ano. Zapněte pruhované sloupce a poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.