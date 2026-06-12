---
title: Správa tabulek prezentací v Javě
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/java/manage-table/
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
- Java
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v prezentacích PowerPoint pomocí Aspose.Slides pro Javu. Objevte jednoduché ukázky kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je účinný způsob, jak zobrazit a představit informace. Informace v mřížce buněk (uspořádaných v řadách a sloupcích) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Table) , rozhraní [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) , třídu [Cell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cell/) , rozhraní [ICell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icell/) a další typy, které vám umožní vytvářet, aktualizovat a spravovat tabulky ve všech typech prezentací. 

## **Vytvoření tabulky od nuly**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Definujte pole `columnWidth`.
4. Definujte pole `rowHeight`.
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Projděte každou [ICell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icell/) a aplikujte formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky první řady tabulky. 
8. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) buňky [ICell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icell/) .
9. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) .
10. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak vytvořit tabulku v prezentaci:

```java
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Přidává tvar tabulky na snímek
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Nastavuje formát ohraničení pro každou buňku
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

    // Přidává text do sloučené buňky
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Ukládá prezentaci na disk
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce je číslování buněk jednoduché a začíná od nuly. První buňka v tabulce má index 0,0 (sloupec 0, řada 0). 

Například buňky v tabulce se 4 sloupci a 4 řadami jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento Java kód vám ukazuje, jak určit číslování buněk v tabulce:

```java
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Přidává tvar tabulky na snímek
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Nastavuje formát okraje pro každou buňku
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

    // Ukládá prezentaci na disk
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek obsahující tabulku pomocí jeho indexu. 
3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) a nastavte jej na null.
4. Projděte všechny objekty [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) , dokud nenajdete tabulku.

   Pokud máte podezření, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše prověřit všechny tvary, které obsahuje. Když je tvar identifikován jako tabulka, můžete jej přetypovat na objekt [Table](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Table) . Pokud však snímek obsahuje několik tabulek, je vhodnější hledat požadovanou tabulku pomocí jejího [setAlternativeText(String value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) .
5. Použijte objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) , abyste pracovali s tabulkou. V níže uvedeném příkladu jsme přidali nový řádek do tabulky.
6. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak získat přístup a pracovat s existující tabulkou:

```java
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializuje null TableEx
    ITable tbl = null;

    // Prochází tvary a nastavuje odkaz na nalezenou tabulku
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Nastavuje text pro první sloupec druhého řádku
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Ukládá upravenou prezentaci na disk
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarovnání textu v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) na snímek. 
4. Získejte přístup k objektu [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) z tabulky. 
5. Získejte [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) z [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) .
6. Zarovnejte text vertikálně.
7. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak zarovnat text v tabulce:

```java
// Vytváří instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definuje sloupce se šířkami a řádky s výškami
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Přidává tvar tabulky na snímek
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Přistupuje k textovému rámečku
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Vytváří objekt Paragraph pro textový rámeček
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Vytváří objekt Portion pro odstavec
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Zarovnává text vertikálně
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Ukládá prezentaci na disk
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte objekt [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable) ze snímku.
4. Nastavte [setFontHeight(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pro text. 
5. Nastavte [setAlignment(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Nastavte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Uložte upravenou prezentaci. 

Tento Java kód vám ukazuje, jak použít preferované možnosti formátování na text v tabulce:

```java
// Vytváří instanci třídy Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Předpokládejme, že první tvar na prvním snímku je tabulka
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Nastavuje výšku fontu buněk tabulky
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Nastavuje zarovnání textu buněk tabulky a pravý okraj v jednom volání
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Nastavuje vertikální typ textu buněk tabulky
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Získání vlastností stylu tabulky**

Aspose.Slides vám umožňuje načíst vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo kdekoliv jinde. Tento Java kód vám ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky:

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

## **Uzamčení poměru stran tabulky**

Poměr stran geometrického tvaru je poměr jeho rozměrů v různých směrech. Aspose.Slides poskytuje vlastnost [**setAspectRatioLocked**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) , která vám umožní uzamknout nastavení poměru stran pro tabulky a další tvary. 

Tento Java kód vám ukazuje, jak uzamknout poměr stran tabulky:

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

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku i text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [setRightToLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/table/#setRightToLeft-boolean-) , a odstavce mají [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Použití obou zajišťuje správný RTL pořadí a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesunu nebo změně velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/java/applying-protection-to-presentation/) k zakázání přesunu, změny velikosti, výběru atd. Tyto zámky platí i pro tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/java/com.aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztažení nebo dláždění).