---
title: Spravujte buňky tabulky v prezentacích pomocí Pythonu
linktitle: Spravovat buňky
type: docs
weight: 30
url: /cs/python-net/manage-cells/
keywords:
- buňka tabulky
- sloučit buňky
- odstranit okraj
- rozdělit buňku
- obrázek v buňce
- barva pozadí
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Jednoduše spravujte buňky tabulky v PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET. Ovládněte rychlý přístup, úpravy a stylování buněk pro plynulou automatizaci snímků."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky v prezentacích PowerPoint a upravovat je. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit ohraničení buněk, pracovat s číslováním buněk po sloučení nebo rozdělení, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buněk pomocí vlastností buněk a uložit upravenou prezentaci jako soubor PPTX.

## **Identifikace sloučených buněk tabulky**

Tabulky často obsahují sloučené buňky pro záhlaví nebo pro seskupení souvisejících dat. V této části uvidíte, jak zjistit, zda konkrétní buňka patří do sloučené oblasti, a jak odkazovat na hlavní (levý horní) buňku, abyste mohli číst nebo formátovat celý blok konzistentně.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte tabulku z prvního snímku.
1. Procházejte řádky a sloupce tabulky a vyhledejte sloučené buňky.
1. Vytiskněte zprávu, když jsou nalezeny sloučené buňky.

Následující Python kód identifikuje sloučené buňky tabulky v prezentaci:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Předpokládáme, že první tvar na prvním snímku je tabulka.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Odstranění ohraničení buněk tabulky**

Někdy ohraničení tabulky ruší obsah nebo vytváří vizuální nepořádek. Tato část ukazuje, jak odstranit ohraničení ze vybraných buněk – nebo konkrétních stran buňky – aby byl dosažen čistší vzhled a lepší soulad s návrhem snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte snímek podle jeho indexu.
1. Definujte pole šířek sloupců.
1. Definujte pole výšek řádků.
1. Přidejte tabulku na snímek pomocí metody [add_table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_table/).
1. Procházejte každou buňku a vymažte horní, dolní, levé a pravé ohraničení.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Python kód ukazuje, jak odstranit ohraničení z buněk tabulky:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Definujte sloupce se šířkami a řádky s výškami.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Přidejte tvar tabulky na snímek.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Vymažte výplň ohraničení u každé buňky.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Uložte soubor PPTX na disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Číslování ve sloučených buňkách**

Pokud sloučíte dva páry buněk – například (1, 1) × (2, 1) a (1, 2) × (2, 2) – výsledná tabulka si zachová stejné číslování buněk jako tabulka bez sloučení. Následující Python kód demonstruje toto chování:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Definujte sloupce se šířkami a řádky s výškami.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Přidejte tvar tabulky na snímek.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Sloučte buňky (1,1) a (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Sloučte buňky (1, 2) a (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Vytiskněte indexy buněk.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Uložte soubor PPTX na disk.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Výstup:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Číslování v rozdělených buňkách**

V předchozím příkladu, když byly buňky tabulky sloučeny, číslování v ostatních buňkách se nezměnilo. Tentokrát vytvoříme běžnou tabulku (bez sloučených buněk) a poté rozdělíme buňku (1, 1), abychom získali speciální tabulku. Věnujte pozornost číslování této tabulky – může vypadat neobvykle. Jedná se však o způsob, jakým Microsoft PowerPoint čísluje buňky tabulky, a Aspose.Slides se chová stejně.

Následující Python kód demonstruje toto chování:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Přidejte tvar tabulky na snímek.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Rozdělte buňku (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Vytiskněte indexy buněk.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Uložte soubor PPTX na disk.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Výstup:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Změna barvy pozadí buňky tabulky**

Následující Python příklad ukazuje, jak změnit barvu pozadí buňky tabulky:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Vytvořte novou tabulku.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Nastavte barvu pozadí buňky.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Vložení obrázků do buněk tabulky**

Tato část ukazuje, jak vložit obrázek do buňky tabulky v Aspose.Slides. Pokrývá aplikaci výplně obrázkem na cílovou buňku a konfiguraci možností zobrazení, například roztahování nebo dlaždicování.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Definujte pole šířek sloupců.
1. Definujte pole výšek řádků.
1. Přidejte tabulku na snímek pomocí metody [add_table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_table/).
1. Načtěte obrázek ze souboru.
1. Přidejte obrázek do kolekce obrázků prezentace a získejte objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/).
1. Nastavte buňce tabulky vlastnost [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) na `PICTURE`.
1. Aplikujte obrázek na buňku tabulky a vyberte režim výplně (např. `STRETCH`).
1. Uložte prezentaci jako soubor PPTX.

Následující Python kód ukazuje, jak umístit obrázek do buňky tabulky při vytváření tabulky:

```python
import aspose.slides as slides

# Vytvořte objekt Presentation.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Přidejte tvar tabulky na snímek.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Načtěte obrázek a přidejte jej do prezentace pro získání objektu PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Aplikujte obrázek na první buňku tabulky.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Uložte prezentaci na disk.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu nastavit různé tloušťky čar a styly pro různé strany jedné buňky?**

Ano. Ohraničení [top](https://reference.aspose.com/slides/cs/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/cs/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/cs/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/cs/python-net/aspose.slides/cellformat/border_right/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit. Toto logicky plyne z řízení ohraničení po stranách buňky, jak je demonstrováno v článku.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillmode/) (stretch/tile). Při roztahování se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají. Článek zmiňuje režimy zobrazení obrázku v buňce.

**Mohu přiřadit hypertextový odkaz k veškerému obsahu buňky?**

[Hyperlinks](/slides/cs/python-net/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/objektu. V praxi přiřadíte odkaz buď k části, nebo ke všemu textu v buňce.

**Mohu nastavit různá písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) (úseky) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.