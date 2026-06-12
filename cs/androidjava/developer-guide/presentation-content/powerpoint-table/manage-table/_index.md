---
title: Spravovat tabulky prezentací na Androidu
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint slajdech pomocí Aspose.Slides pro Android. Objevte jednoduché příklady kódu v Javě, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak zobrazit a představit informace. Informace v síti buněk (uspořádaných do řádků a sloupců) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Table) , rozhraní [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITable) , třídu [Cell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cell/) , rozhraní [ICell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icell/) a další typy, které umožňují vytvářet, aktualizovat a spravovat tabulky ve všech typech prezentací.

## **Vytvoření tabulky od nuly**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Definujte pole `columnWidth`.
4. Definujte pole `rowHeight`.
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITable) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Procházejte každý [ICell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icell/) , abyste použili formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky prvního řádku tabulky. 
8. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) buňky [ICell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icell/) .
9. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) .
10. Uložte upravenou prezentaci.

Tento kód v Javě vám ukazuje, jak vytvořit tabulku v prezentaci:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Definuje sloupce se šířkami a řádky s výškami
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Přidá tvar tabulky na snímek
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Nastaví formát ohraničení pro každou buňku
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Sloučí buňky 1 a 2 v řádku 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Přidá text do sloučené buňky
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Uloží prezentaci na disk
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce je číslování buněk jednoduché a nulové. První buňka v tabulce má index 0,0 (sloupec 0, řádek 0). 

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento kód v Javě vám ukazuje, jak specifikovat číslování buněk v tabulce:

```java
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Definuje sloupce se šířkami a řádky s výškami
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Přidá tvar tabulky na snímek
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Nastaví formát ohraničení pro každou buňku
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Uloží prezentaci na disk
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek obsahující tabulku pomocí jeho indexu. 
3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITable) a nastavte ho na null.
4. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) , dokud nenaleznete tabulku.

   Pokud se domníváte, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše zkontrolovat všechny jeho tvary. Když je tvar identifikován jako tabulka, můžete jej přetypovat na objekt [Table](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Table) . Pokud však snímek obsahuje několik tabulek, je lepší hledat požadovanou tabulku pomocí jejího [setAlternativeText(String value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).
5. Použijte objekt [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITable) , abyste pracovali s tabulkou. V níže uvedeném příkladu jsme přidali nový řádek do tabulky.
6. Uložte upravenou prezentaci.

Tento kód v Javě vám ukazuje, jak přistupovat k existující tabulce a pracovat s ní:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializuje nulovou TableEx
    ITable tbl = null;

    // Prochází tvary a nastaví referenci na nalezenou tabulku
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Nastaví text pro první sloupec druhého řádku
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Uloží upravenou prezentaci na disk
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarovnání textu v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITable) na snímek.
4. Získejte objekt [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) z tabulky.
5. Získejte [IParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/) z [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) .
6. Zarovnejte text vertikálně.
7. Uložte upravenou prezentaci.

Tento kód v Javě vám ukazuje, jak zarovnat text v tabulce:

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Získá první snímek 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definuje sloupce se šířkami a řádky s výškami
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Přidá tvar tabulky na snímek
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Přistupuje k textovému rámci
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Vytvoří objekt Paragraph pro textový rámec
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Vytvoří objekt Portion pro odstavec
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Zarovnává text vertikálně
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Uloží prezentaci na disk
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte objekt [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITable) ze snímku.
4. Nastavte [setFontHeight(float value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) pro text.
5. Nastavte [setAlignment(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Nastavte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Uložte upravenou prezentaci. 

Tento kód v Javě vám ukazuje, jak použít preferované možnosti formátování na text v tabulce:

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Předpokládejme, že první tvar na prvním snímku je tabulka
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Nastaví výšku písma buněk tabulky
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Nastaví zarovnání textu buněk tabulky a pravý okraj v jednom volání
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Nastaví vertikální typ textu buněk tabulky
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Získání vlastností stylu tabulky**

Aspose.Slides vám umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo kdekoliv jinde. Tento kód v Javě vám ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // změnit výchozí předvolbu stylu tématu
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uzamknutí poměru stran tabulky**

Poměr stran geometrického tvaru je poměr jeho rozměrů v různých dimenzích. Aspose.Slides poskytuje vlastnost [**setAspectRatioLocked**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) , která umožňuje uzamknout nastavení poměru stran pro tabulky i další tvary.

Tento kód v Javě vám ukazuje, jak uzamknout poměr stran pro tabulku:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invertovat

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Mohu povolit čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [setRightToLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) , a odstavce mají [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Použití obou zajišťuje správné RTL pořadí a vykreslování v buňkách.

**Jak mohu zabránit uživatelům v přesunu nebo změně velikosti tabulky v konečném souboru?**

Použijte zámky tvarů k zakázání přesunu, změny velikosti, výběru atd. Tyto zámky se vztahují i na tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždice).