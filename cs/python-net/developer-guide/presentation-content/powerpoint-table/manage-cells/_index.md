---
title: Správa buněk tabulky v prezentacích pomocí Pythonu
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
- prezentace
- Python
- Aspose.Slides
description: "Spravujte buňky tabulky PowerPoint v Pythonu: identifikujte sloučené buňky, odstraňujte okraje, rozdělujte buňky a nastavujte barvy pozadí a obrázky pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky v prezentacích PowerPoint a upravovat je. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit ohraničení buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky prostřednictvím vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové (zero‑based) indexy. Souřadnice v tomto článku jsou zapisovány jako `(column, row)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na prvním snímku jako k tabulce. Předpokládá, že snímek a tvar existují a že tvar je tabulka. Poté prochází všechny řádky a sloupce a používá [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) k identifikaci buněk ve sloučených oblastech. Pro každou shodu vypíše souřadnice buňky v pořadí `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/) a počáteční souřadnice oblasti, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) a [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Odstranění ohraničení buněk tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a přidejte tabulku na první snímek pomocí [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři ohraničení buňky na [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), čímž je učiní neviditelnými.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Sloučení buněk tabulky**

Použijte [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) ke sloučení obdélníkového rozsahu buněk tabulky do jedné buňky. Určete buňky v levém horním a pravém dolním rohu rozsahu. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `False` zachová sloučení uvnitř tohoto rozsahu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a následně sloučí čtyři centrální buňky od `(1, 1)` po `(2, 2)`. Výsledná buňka zabírá dva sloupce a dva řádky, zatímco základní mřížka tabulky si zachovává čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její pozici v levém horním rohu: `table.rows[1][1]` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nemění.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Rozdělení buněk tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec v mřížce a změnit indexy sloupců buněk napravo. Aspose.Slides se řídí modelem mřížky tabulky PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) na buňku `(1, 1)`. Polovina šířky buňky 70 bodů je předána k vytvoření dvou buňek stejné šířky.

Po tomto rozdělení jsou dvě poloviny přístupné jako `table.rows[1][1]` a `table.rows[1][2]`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se posunou na sloupce 3 a 4. Indexy řádků zůstávají nezměněny. Použijte tyto aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Rozdělení sloučených buněk podle rozsahu řádku nebo sloupce**

Pro připravení sloučených šablonových buněk na naplnění dat použijte [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) k rozdělení podél existující řádkové hranice nebo [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) k rozdělení podél sloupcové hranice.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučenému regionu:

- Rozdělení řádku: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Rozdělení sloupce: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Příklad předpokládá, že prezentace má tabulku jako první tvar na prvním snímku, přičemž buňky `(1, 2)` a `(1, 3)` jsou sloučeny vertikálně. Od dolní pozice používá [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) a [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) k určení počátku a kontroluje oba rozsahy. `split_by_row_span` s indexem 1 pak oddělí řádky 2 a 3 pro názvy produktů. Pro vodorovné sloučení dvou sloupců použijte `split_by_col_span` s indexem 1.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Získat výsledné buňky z tabulky po rozdělení.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Mřížka tabulky a okolní indexy buněk zůstávají nezměněny. Získejte výsledné buňky podle jejich souřadnic; zde mají oba rozsahy 1 a [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) vypisuje `False`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučené.

Původní text a jeho formátování zůstává v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, ohraničení a okraje. Po rozdělení buňky naplňte a nastavte libovolné požadované formátování textu explicitně.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ se zachovaným formátováním šablonové buňky. Viz [Reference API buněk](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) pro podrobnosti.

## **Změna barvy pozadí buňky tabulky**

Tento příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Nastaví [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na pevnou (solid) a [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) na červenou pro buňku `(2, 3)`, tj. ve třetím sloupci a čtvrtém řádku.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání obrázku do buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) a přidá jej do kolekce obrázků prezentace pomocí [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Poté přiřadí obrázek k výplni obrázkem buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) roztažením vyplní buňku, což může změnit poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je automaticky uvolněn po ukončení bloku `with`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu nastavit různé tloušťky a styly čar pro různé strany jedné buňky?**

Ano. Ohranění [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) mají samostatné vlastnosti, takže tloušťka a styl každé strany mohou být odlišné.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Při natahování se obrázek přizpůsobí nové buňce, při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz ke všemu obsahu buňky?**

[Hypertextové odkazy](/slides/cs/python-net/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz buď k části, nebo k celému textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (úseky) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.