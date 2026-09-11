---
title: Správa buněk tabulky v prezentacích pomocí Pythonu
linktitle: Správa buněk
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
description: "Jednoduše spravujte buňky tabulky v PowerPointu pomocí Aspose.Slides pro Python přes Java. Ovládněte rychlý přístup, úpravy a stylování buněk pro plynulou automatizaci snímků."
---
## **Přehled**

Aspose.Slides vám umožňuje přístup k buňkám tabulek a jejich úpravu v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po jejich sloučení nebo rozdělení, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky pomocí vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

## **Identifikace sloučené buňky tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
2. Získejte tabulku z prvního snímku.
3. Iterujte řádky a sloupce tabulky a vyhledejte sloučené buňky.
4. Vytiskněte zprávu, když jsou nalezeny sloučené buňky.

Tento kód v Pythonu ukazuje, jak v prezentaci identifikovat sloučené buňky tabulky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Předpokládejme, že první tvar na první snímku je tabulka.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Odstranění okrajů buněk tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte seznam šířek sloupců.
4. Definujte seznam výšek řádků.
5. Přidejte tabulku na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addTable) .
6. Iterujte přes každou buňku a odstraňte horní, spodní, pravý a levý okraj.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód v Pythonu ukazuje, jak odstranit okraje z buněk tabulky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpython.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Přístup k prvnímu snímku.
    slide = presentation.getSlides().get_Item(0)

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Přidejte tabulku na snímek.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Nastavte formát okrajů pro každou buňku.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Číslování ve sloučených buňkách**

Pokud sloučíme dva páry buněk, (1, 1) a (2, 1) a (1, 2) a (2, 2), výsledná tabulka zachová číslování buněk. Tento kód v Pythonu demonstruje proces:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přístup k prvnímu snímku.
    slide = presentation.getSlides().get_Item(0)

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Přidejte tabulku na snímek.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Nastavte formát okrajů pro každou buňku.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Sloučit buňky (1, 1) a (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Sloučit buňky (1, 2) a (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poté dále sloučíme buňky tím, že spojíme (1, 1) a (1, 2). Výsledkem je tabulka s velkou sloučenou buňkou uprostřed:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přístup k prvnímu snímku.
    slide = presentation.getSlides().get_Item(0)

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Přidejte tabulku na snímek.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Nastavte formát okrajů pro každou buňku.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Sloučit buňky (1, 1) a (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Sloučit buňky (1, 2) a (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Sloučit buňky (1, 1) a (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Číslování v rozdělené buňce**

V předchozích příkladech sloučení buněk tabulky nezměnilo číslování ostatních buněk.

Tentokrát vezmeme běžnou tabulku (tabulku bez sloučených buněk) a pokusíme se rozdělit buňku (1, 1), abychom získali zvláštní tabulku. Možná si všimnete, že číslování této tabulky může působit podivně. Nicméně tak Microsoft PowerPoint čísluje buňky tabulky a Aspose.Slides dělá totéž.

Tento kód v Pythonu demonstruje popsaný proces:

```python
import jpype
import asposeslides

if not jpame.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přístup k prvnímu snímku.
    slide = presentation.getSlides().get_Item(0)

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Přidejte tabulku na snímek.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Nastavte formát okrajů pro každou buňku.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Rozdělit buňku (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Změna barvy pozadí buňky tabulky**

Tento kód v Pythonu ukazuje, jak změnit barvu pozadí buňky tabulky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Přístup k prvnímu snímku.
    slide = presentation.getSlides().get_Item(0)

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Přidejte tabulku na snímek.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Nastavte barvu pozadí buňky.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přidání obrázku do buňky tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte seznam šířek sloupců.
4. Definujte seznam výšek řádků.
5. Přidejte tabulku na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addTable) .
6. Načtěte soubor obrázku pomocí [Images.fromFile](https://reference.aspose.com/slides/cs/python-java/aspose.slides/images/#fromFile) .
7. Přidejte obrázek do prezentace a vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) .
8. Nastavte typu výplně buňky tabulky [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/) na [FillType.Picture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/#Picture) .
9. Přidejte obrázek do první buňky tabulky.
10. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód v Pythonu ukazuje, jak umístit obrázek do buňky tabulky při jejím vytváření:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Přístup k prvnímu snímku.
    slide = presentation.getSlides().get_Item(0)

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Přidejte tabulku na snímek.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Vytvořte obrázek prezentace ze souboru obrázku.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Přidejte obrázek do první buňky tabulky.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu nastavit různé tloušťky čar a styly pro různé strany jedné buňky?**

Ano. Okraje [horní](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellformat/#getBorderTop)/[spodní](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellformat/#getBorderBottom)/[levý](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellformat/#getBorderLeft)/[pravý](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellformat/#getBorderRight) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit. To logicky vyplývá z řízení okrajů podle stran buňky, jak je ukázáno v článku.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [režimu výplně](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillmode/) (roztažení/duplikace). Při roztažení se obrázek přizpůsobí nové buňce; při duplikaci se dlaždice přepočítají. Článek zmiňuje režimy zobrazení obrázku v buňce.

**Mohu přiřadit hypertextový odkaz ke veškerému obsahu buňky?**

Hyperlinky jsou nastaveny na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz buď k části, nebo ke všem textům v buňce.

**Mohu nastavit různé fonty v jedné buňce?**

Ano. Textový rámec buňky podporuje [části](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) (běhy) s nezávislým formátováním – rodinu písma, styl, velikost i barvu.