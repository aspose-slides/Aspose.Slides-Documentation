---
title: Správa buněk tabulky v prezentacích pomocí Pythonu
linktitle: Spravovat buňky
type: docs
weight: 30
url: /cs/python-java/manage-cells/
keywords:
- buňka tabulky
- sloučit buňky
- odstranit okraj
- rozdělit buňku
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravujte buňky tabulky PowerPoint v Pythonu: identifikujte sloučené buňky, odstraňujte okraje, rozdělte buňky a nastavte barvy pozadí a obrázky pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky a upravovat je v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek uvnitř buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky pomocí vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové indexování pro přístup k buňkám tabulky v pořadí `(sloupec, řádek)`.

## **Identifikovat sloučenou buňku tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na první snímku jako k tabulce. Předpokládá, že snímek a tvar existují a že tvar je tabulka. Pak iteruje přes všechny řádky a sloupce a používá [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) k identifikaci buněk ve sloučených oblastech. Pro každou shodu vytiskne souřadnice buňky v pořadí `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) a počáteční souřadnice oblasti, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) a [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Odstranit okraje buněk tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a přidejte tabulku na první snímek pomocí [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři okraje buňky na [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), čímž je učiní neviditelnými.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sloučit buňky tabulky**

Použijte [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) ke sloučení obdélníkového rozsahu buněk tabulky do jedné buňky. Zadejte buňky v levém horním a pravém dolním rohu rozsahu. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `False` udržuje sloučení v tomto rozsahu.

Příklad vytvoří tabulku 4 × 4 s 70‑bodovými sloupci a řádky, pak sloučí čtyři střední buňky od `(1, 1)` po `(2, 2)`. Výsledná buňka zasahuje přes dva sloupce a dva řádky, zatímco podkladová mřížka tabulky si zachovává čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její levý horní pozici: `table.get_Item(1, 1)` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nemění.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rozdělit buňky tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec mřížky a změnit indexy sloupců buněk napravo od ní. Aspose.Slides se řídí modelem mřížky tabulky PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 s 70‑bodovými sloupci a řádky a zavolá [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) na buňce `(1, 1)`. Polovina 70‑bodové šířky buňky je použita k vytvoření dvou buněk stejné šířky.

Po tomto rozdělení jsou dvě poloviny přístupné jako `table.get_Item(1, 1)` a `table.get_Item(2, 1)`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se přesunou do sloupců 3 a 4, respektive. Indexy řádků zůstávají beze změny. Používejte tyto aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Rozdělit sloučené buňky podle řádkového nebo sloupcového rozpětí**

Pro přípravu sloučených buněk šablony k naplnění daty použijte [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) pro rozdělení podél existující řádkové hranice nebo [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) pro rozdělení podél sloupcové hranice.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučenému regionu:

- Rozdělení řádku: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Rozdělení sloupce: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Příklad předpokládá, že prezentace má tabulku jako první tvar na prvním snímku, kde jsou buňky `(1, 2)` a `(1, 3)` sloučeny svisle. Začíná od dolní pozice, používá [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) a [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) k určení počátku a kontroluje oba rozpětí. `splitByRowSpan(1)` pak odděluje řádky 2 a 3 pro názvy produktů. Pro vodorovné sloučení dvou sloupců použijte místo toho `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

            # Získejte výsledné buňky z tabulky po rozdělení.
            upper_cell = table.get_Item(first_column_index, first_row_index)
            lower_cell = table.get_Item(first_column_index, first_row_index + 1)
            print(f"Upper cell merged: {upper_cell.isMergedCell()}")
            print(f"Lower cell merged: {lower_cell.isMergedCell()}")

            upper_cell.getTextFrame().setText("Product A")
            lower_cell.getTextFrame().setText("Product B")

            presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Mřížka tabulky a okolní indexy buněk zůstávají nezměněny. Získejte výsledné buňky podle jejich souřadnic; zde obě mají rozsah 1 a [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) vypíše `False`. Větší oblasti mohou po jednom rozdělení zůstávat částečně sloučené.

Původní text a jeho formátování zůstávají v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, okraje a okraje. Naplňte buňky po rozdělení a nastavte případné požadované formátování textu explicitně.

Uložená prezentace obsahuje samostatné buňky "Product A" a "Product B" s ponechaným formátováním buněk šablony. Viz [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) pro podrobnosti.

## **Změnit barvu pozadí buňky tabulky**

Tento příklad vytvoří tabulku se 150‑bodovými sloupci a 50‑bodovými řádky. Používá [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) k výběru plné výplně a nastavuje barvu vrácenou metodou [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) na červenou pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přidat obrázek do buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) a přidá jej do kolekce obrázků prezentace pomocí [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Poté přiřadí obrázek k výplni obrázku buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) roztáhne obrázek tak, aby vyplnil buňku, což může změnit její poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je uvolněn v bloku `finally` po jeho přidání do prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu nastavit různé tloušťky čar a styly pro různé strany jedné buňky?**

Ano. Okraje [horní](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[spodní](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[levý](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[pravý](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změním velikost sloupce/řádku?**

Chování závisí na [režim výplně](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/). Při roztahování se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz k veškerému obsahu buňky?**

[Hyperlinky](/slides/cs/python-java/manage-hyperlinks/) jsou nastavovány na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz k části nebo k celému textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [části](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (běhy) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.