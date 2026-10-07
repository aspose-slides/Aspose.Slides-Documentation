---
title: Správa buněk tabulky v prezentacích na Androidu
linktitle: Správa buněk
type: docs
weight: 30
url: /cs/androidjava/manage-cells/
keywords:
- buňka tabulky
- sloučení buněk
- odstranění okraje
- rozdělení buňky
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Správa buněk tabulky PowerPoint na Androidu: identifikace sloučených buněk, odstraňování okrajů, rozdělování buněk a nastavení barev pozadí a obrázků pomocí Aspose.Slides pro Android v Javě."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky v prezentacích PowerPoint a upravovat je. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení, změnit barvu pozadí buňky a přidat obrázek uvnitř buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky prostřednictvím vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá indexy založené na nule pro přístup k buňkám tabulky v pořadí `(sloupec, řádek)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevře existující prezentaci a získá první tvar na prvním snímku jako tabulku. Předpokládá, že snímek a tvar existují a že tvar je tabulka. Poté prochází všechny řádky a sloupce a používá [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) k identifikaci buněk ve sloučených oblastech. Pro každou shodu vytiskne souřadnice buňky v pořadí `řádek;sloupec`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), a počáteční souřadnice oblasti, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) a [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Odstranění okrajů buněk tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a přidejte tabulku na první snímek pomocí [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři okraje buňky na [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), čímž je učiní neviditelnými.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sloučení buněk tabulky**

Použijte [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) k sloučení obdélníkového rozsahu buněk tabulky do jedné buňky. Zadejte buňky v levém horním a pravém dolním rohu rozsahu. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `false` udržuje sloučení uvnitř tohoto rozsahu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a poté sloučí čtyři střední buňky z `(1, 1)` až `(2, 2)`. Výsledná buňka přesahuje dva sloupce a dva řádky, zatímco podkladová mřížka tabulky si zachová čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její pozici v levém horním rohu: `table.get_Item(1, 1)` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nemění.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rozdělení buněk tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec mřížky a změnit indexy sloupců buněk napravo. Aspose.Slides se řídí modelem mřížky tabulky PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) na buňce `(1, 1)`. Polovina šířky buňky 70 bodů je předána k vytvoření dvou buněk stejné šířky.

Po tomto rozdělení jsou dvě poloviny přístupné jako `table.get_Item(1, 1)` a `table.get_Item(2, 1)`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se přesunou na sloupce 3 a 4. Indexy řádků zůstávají nezměněny. Používejte aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Rozdělení sloučených buněk podle rozsahu řádku nebo sloupce**

Pro přípravu sloučených šablonových buněk na naplnění daty použijte [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) k rozdělení podél existující hranice řádku nebo [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) k rozdělení podél hranice sloupce.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučenému regionu:

- Rozdělení řádku: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Rozdělení sloupce: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Příklad očekává, že prezentace bude mít tabulku jako první tvar na prvním snímku, přičemž buňky `(1, 2)` a `(1, 3)` jsou sloučeny vertikálně. Začíná od dolní pozice a používá [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) a [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) k určení počátku a kontroluje oba rozsahy. `splitByRowSpan(1)` poté oddělí řádky 2 a 3 pro názvy produktů. Pro vodorovné sloučení dvou sloupců použijte místo toho `splitByColSpan(1)`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Získejte výsledné buňky z tabulky po rozdělení.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Mřížka tabulky a sousední indexy buněk zůstávají nezměněny. Získané buňky vyhledávejte podle jejich souřadnic; zde mají obě rozsah 1 a [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) vrací `false`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučeny.

Původní text a jeho formátování zůstává v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako výplň, okraje a okraje. Po rozdělení buňky naplňte a nastavené formátování textu aplikujte explicitně.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ s zachovaným formátováním šablonové buňky. Další podrobnosti najdete v [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/).

## **Změna barvy pozadí buňky tabulky**

Tento příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Použije [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) k výběru plné výplně a nastaví barvu vrácenou metodou [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) na červenou pro buňku `(2, 3)`, tedy třetí sloupec a čtvrtý řádek.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání obrázku uvnitř buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) a přidá jej do kolekce obrázků prezentace pomocí [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Poté přiřadí obrázek k výplni obrázku buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) roztahuje obrázek tak, aby vyplnil buňku, což může změnit poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je uvolněn v bloku `finally` po jeho přidání do prezentace.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu nastavit různé tloušťky a styly čar pro různé strany jedné buňky?**

Ano. Okraje [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změním velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Při roztažení se obrázek přizpůsobí nové buňce; při dláždění se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz k veškerému obsahu buňky?**

[Hyperlinks](/slides/cs/androidjava/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz buď k části, nebo ke veškerému textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (úseky) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.