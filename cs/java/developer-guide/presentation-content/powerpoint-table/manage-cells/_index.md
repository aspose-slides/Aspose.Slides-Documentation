---
title: Správa buněk tabulky v prezentacích pomocí Java
linktitle: Správa buněk
type: docs
weight: 30
url: /cs/java/manage-cells/
keywords:
- buňka tabulky
- sloučit buňky
- odstranit ohraničení
- rozdělit buňku
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše spravujte buňky tabulky v PowerPointu pomocí Aspose.Slides pro Java. Ovládněte rychlý přístup, úpravy a stylování buněk pro plynulou automatizaci snímků."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky v prezentacích PowerPoint a měnit je. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit ohraničení buněk, pracovat s číslováním buněk po sloučení nebo rozdělení, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky pomocí vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

## **Identifikace sloučené buňky tabulky**
1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte tabulku z první snímky. 
3. Procházejte řádky a sloupce tabulky a hledejte sloučené buňky.
4. Vypište zprávu, když jsou nalezeny sloučené buňky.

Tento Java kód ukazuje, jak identifikovat sloučené buňky tabulky v prezentaci:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // předpokládá se, že Slide#0.Shape#0 je tabulka
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranění ohraničení buněk tabulky**
1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku do snímku pomocí metody [addTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Procházejte každou buňku a vymažte horní, spodní, pravé i levé ohraničení.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak odstranit ohraničení z buněk tabulky:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistoupí k prvnímu snímku
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Definuje sloupce se šířkami a řádky s výškami
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Přidá tvar tabulky na snímek
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Nastaví formát ohraničení pro každou buňku
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Zapíše PPTX na disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Číslování ve sloučených buňkách**
Pokud sloučíme 2 páry buněk (1, 1) × (2, 1) a (1, 2) × (2, 2), výsledná tabulka bude číslovaná. Tento Java kód demonstruje postup:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
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

    // Sloučí buňky (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Sloučí buňky (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Poté sloučíme buňky dále sloučením (1, 1) a (1, 2). Výsledkem je tabulka obsahující velkou sloučenou buňku uprostřed:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
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

    // Sloučí buňky (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Sloučí buňky (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Sloučí buňky (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Zapíše soubor PPTX na disk
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Číslování v rozdělené buňce**
V předchozích příkladech, když byly buňky tabulky sloučeny, číslování nebo číselný systém v ostatních buňkách se nezměnil.

Tentokrát vezmeme běžnou tabulku (tabulku bez sloučených buněk) a pokusíme se rozdělit buňku (1,1), abychom získali zvláštní tabulku. Věnujte pozornost číslování této tabulky, které se může zdát podivné. To však tak Microsoft PowerPoint čísluje buňky tabulky a Aspose.Slides dělá totéž.

Tento Java kód demonstruje popsaný postup:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
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

    // Sloučí buňky (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Sloučí buňky (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Rozdělí buňku (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // Zapíše soubor PPTX na disk
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změna barvy pozadí buňky tabulky**

Tento Java kód ukazuje, jak změnit barvu pozadí buňky tabulky:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // vytvoří novou tabulku
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // nastaví barvu pozadí buňky 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Přidání obrázku do buňky tabulky**

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku do snímku pomocí metody [AddTable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Vytvořte objekt `Images` pro uložení souboru obrázku.
7. Přidejte obrázek `IImage` do objektu `IPPImage`.
8. Nastavte `FillFormat` buňky tabulky na `Picture`.
9. Přidejte obrázek do první buňky tabulky.
10. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak umístit obrázek do buňky tabulky při vytváření tabulky:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide islide = pres.getSlides().get_Item(0);

    // Definuje sloupce se šířkami a řádky s výškami
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Přidá tvar tabulky na snímek
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Vytvoří objekt IPPImage pomocí souboru obrázku
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Přidá obrázek do první buňky tabulky
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Uloží soubor PPTX na disk
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu nastavit různou tloušťku a styl čar pro různé strany jedné buňky?**

Ano. Ohraničení [horní](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellformat/#getBorderTop--)/[spodní](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellformat/#getBorderBottom--)/[levé](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellformat/#getBorderLeft--)/[pravé](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellformat/#getBorderRight--) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit. Toto logicky vyplývá z řízení ohraničení na jednotlivých stranách buňky, jak je ukázáno v článku.

**Co se stane s obrázkem, pokud změním velikost sloupce/řádku po nastavení obrázku jako pozadí buňky?**

Chování závisí na [režimu výplně](https://reference.aspose.com/slides/cs/java/com.aspose.slides/picturefillmode/) (roztažení/ozdrojování). Při roztažení se obrázek přizpůsobí nové buňce; při ozdrojování se dlaždice přepočítají. Článek zmiňuje režimy zobrazování obrázku v buňce.

**Mohu přiřadit hypertextový odkaz ke všemu obsahu buňky?**

[Hyperlinky](/slides/cs/java/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/objektu. V praxi přiřadíte odkaz buď k části textu, nebo ke všemu textu v buňce.

**Mohu nastavit různá písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [části](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/) (běhy) s nezávislým formátováním — rodina písma, styl, velikost a barva.