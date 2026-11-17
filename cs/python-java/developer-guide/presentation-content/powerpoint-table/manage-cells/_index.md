---
title: Spravovat buňky tabulky v prezentacích pomocí Pythonu
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
description: "Spravovat buňky tabulky PowerPoint v Pythonu: identifikovat sloučené buňky, odstranit okraje, rozdělit buňky a nastavit barvy pozadí a obrázky pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky a upravovat je v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek uvnitř buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky prostřednictvím vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové indexy pro přístup k buňkám tabulky v pořadí `(column, row)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na první snímku jako k tabulce. Předpokládá, že snímek i tvar existují a že tvar je tabulka. Poté prochází všechny řádky a sloupce a používá [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) k identifikaci buněk ve sloučených oblastech. Pro každou shodu vypíše souřadnice buňky v pořadí `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) a počáteční souřadnice oblasti, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) a [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **Odstranění okrajů buňky tabulky**

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

## **Přidání úhlopříčných okrajů buňky**

Použijte [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) pro nakreslení čáry z levého horního rohu do pravého dolního a [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) pro nakreslení čáry z levého dolního rohu do pravého horního. Úhlopříčka může označovat záhlaví sloupce. Obě úhlopříčky mohou vytvořit X, které označuje buňku jako neaplikovatelnou.

Každá úhlopříčka je [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). V jejím [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) použijte [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) k výběru [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) a zvolte barvu pomocí [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Šířku čáry v bodech nastavte pomocí [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

Příklad vytvoří tři buňky v jednom řádku: červenou úhlopříčku směrem dolů, modrou úhlopříčku směrem nahoru a obě úhlopříčky. Horní, spodní, levý a pravý okraj buněk zůstane nezměněn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Úhlopříčka je vlastnost formátování, nikoli rozdělení buňky. Každá buňka si ponechává jediný textový rámec, přístupný přes [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). Oblasti na obou stranách úhlopříčky nelze upravovat nezávisle.

Uložená tabulka, vykreslená v Microsoft PowerPoint:

![Tři buňky tabulky zobrazující červenou úhlopříčku z levého horního rohu do pravého dolního, modrou úhlopříčku z levého dolního rohu do pravého horního a obě úhlopříčky tvořící X.](diagonal-cell-borders.png)

*Zleva doprava: úhlopříčka dolů (červená, 3 pt), úhlopříčka nahoru (modrá, 5 pt) a obě úhlopříčky.*

## **Sloučení buněk tabulky**

Použijte [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) k sloučení obdélníkové oblasti buněk tabulky do jedné buňky. Uveďte buňky v levém horním a pravém dolním rohu oblasti. Poslední argument určuje, zda může sloučení zahrnovat buňky mimo zadanou oblast; `False` udržuje sloučení uvnitř této oblasti.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů, poté sloučí čtyři centrální buňky od `(1, 1)` po `(2, 2)`. Výsledná buňka zasahuje dva sloupce a dva řádky, zatímco podkladová mřížka tabulky si zachovává čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její levý horní pozici: `table.get_Item(1, 1)` v tomto příkladu. Ostatní pozice ve sloučené oblasti zůstávají součástí mřížky, takže indexy buněk mimo oblast se nemění.

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

## **Rozdělení buněk tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec mřížky a změnit indexy sloupců buněk vpravo od ní. Aspose.Slides se řídí modelem mřížky tabulky v PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) na buňce `(1, 1)`. Polovina šířky buňky 70 bodů je předána k vytvoření dvou buněk stejné šířky.

Po tomto rozdělení jsou obě poloviny přístupny jako `table.get_Item(1, 1)` a `table.get_Item(2, 1)`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se přesunou na sloupce 3 a 4. Indexy řádků zůstávají nezměněny. Používejte tyto aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

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

<!-- visual-explanation:manage-cells:start -->
[![Nesloučená buňka o šířce 70 bodů se rozdělí na dvě buňky o šířce 35 bodů, přičemž se přidá pátý sloupec mřížky a posunou se indexy napravo.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Rozdělení šířky ovlivňuje buňku (1, 1) s nulovými (sloupec, řádek) indexy. Ostatní řádky si ponechají buňku zasahující oba nové sloupce.*
<!-- visual-explanation:manage-cells:end -->

### **Rozdělení sloučených buněk podle řádku nebo sloupce**

Pro přípravu sloučených šablonových buněk k naplnění daty použijte [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) k rozdělení podél existující hranice řádku nebo [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) k rozdělení podél hranice sloupce.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučené oblasti:

- Rozdělení řádku: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Rozdělení sloupce: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Příklad předpokládá, že prezentace obsahuje tabulku jako první tvar na prvním snímku, s buňkami `(1, 2)` a `(1, 3)` sloučenými vertikálně. Začínající od dolní pozice používá [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) a [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) k určení počátku a kontroluje oba rozsahy. `splitByRowSpan(1)` pak oddělí řádky 2 a 3 pro názvy produktů. Pro horizontální sloučení dvou sloupců použijte místo toho `splitByColSpan(1)`.

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

        # Získat výsledné buňky z tabulky po rozdělení.
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

Mřížka tabulky a okolní indexy buněk zůstávají nezměněny. Získáte výsledné buňky podle jejich souřadnic; zde mají oba rozsahy 1 a [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) vrací `False`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučené.

Původní text a jeho formátování zůstává v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, okraje a okraje. Po rozdělení buňky naplňte textem a případně explicitně nastavte požadované formátování textu.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ se zachovaným formátováním buňky šablony. Viz [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) pro podrobnosti.

### **Rozdělení buňky podle konkrétní výšky**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) přijímá výšku horní části v bodech. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) přijímá počet existujících řádků mřížky v horní části. Pro vycentrování buňky o výšce 40 bodů ve pravém sloupci odečtěte 40 od skutečné výšky buňky a zbytek rovnoměrně rozdělte nad a pod ní.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

První rozdělení přidá řádek mřížky a zanechá spodních 90 bodů v buňce `(1, 1)`. Druhé rozdělení rozdělí tuto buňku na střední buňku o výšce 40 bodů a spodní buňku o výšce 50 bodů. Pravý sloupec má nyní tři buňky s výškami 50, 40 a 50 bodů shora dolů. Levá buňka zasahuje všechny tři řádky a zachovává původní výšku 140 bodů.

![Levá buňka zasahuje celou výšku tabulky vedle tří buněk, přičemž střední buňka je uprostřed.](split-by-height.png)

## **Změna barvy pozadí buňky tabulky**

Tento příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Použije [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) k výběru pevné výplně a nastaví barvu vrácenou metodou [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) na červenou pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku.

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

## **Přidání obrázku uvnitř buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) a přidá jej do kolekce obrázků prezentace pomocí [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Pak přiřadí obrázek k výplni obrázkem buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) roztahuje obrázek tak, aby vyplnil buňku, což může změnit její poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je uvolněn v bloku `finally` po jeho přidání do prezentace.

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

Ano. Okraje [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změním velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Při strečování se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz k celému obsahu buňky?**

[Hyperlinks](/slides/cs/python-java/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi odkaz přiřadíte buď k části, nebo ke všemu textu v buňce.

**Mohu nastavit různé písmo v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (běhy) s nezávislým formátováním — rodinu písma, styl, velikost a barvu.