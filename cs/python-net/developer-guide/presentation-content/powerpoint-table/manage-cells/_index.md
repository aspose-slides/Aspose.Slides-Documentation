---
title: Správa buněk tabulky v prezentacích pomocí Pythonu
linktitle: Správa buněk
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
description: "Spravujte buňky tabulky PowerPoint v Pythonu: identifikujte sloučené buňky, odstraňujte okraje, rozdělte buňky a nastavujte barvy pozadí a obrázky pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Aspose.Slides umožňuje přístup k buňkám tabulek a jejich úpravu v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek uvnitř buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buněk prostřednictvím vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové indexy. Souřadnice v tomto článku jsou zapisovány jako `(column, row)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na prvním snímku jako k tabulce. Předpokládá se, že snímek a tvar existují a že tvar je tabulka. Poté iteruje přes všechny řádky a sloupce a používá [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) k identifikaci buněk ve sloučených oblastech. Pro každou shodu vytiskne souřadnice buňky v pořadí `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/) a výchozí souřadnice oblasti, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) a [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

## **Odstranění okrajů buňky tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a přidejte tabulku na první snímek pomocí [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři okraje buňky na [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), čímž je učiní neviditelnými.

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

## **Přidání úhlových okrajů buňky**

Použijte [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) pro nakreslení čáry z levého horního rohu do pravého dolního a [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) pro nakreslení čáry z levého dolního rohu do pravého horního. Diagonála může označovat záhlaví rohu; obě diagonály mohou vytvořit X, aby buňka byla označena jako neaplikovatelná.

Každá diagonála je [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). V jejím [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) nastavte [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) a zvolte [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Šířku čáry nastavte v bodech pomocí [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/).

Příklad vytvoří tři buňky v jednom řádku: červenou diagonálu směrem dolů, modrou diagonálu směrem nahoru a obě diagonály. Horní, dolní, levý a pravý okraj buněk zůstane nezměněn.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Diagonála je vlastnost formátování, nikoli rozdělení buňky. Každá buňka zachovává jediný [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); oblasti na obou stranách diagonály nelze upravovat nezávisle.

Uložená tabulka, vykreslená v Microsoft PowerPoint:

![Tři buňky tabulky zobrazující červenou diagonálu z levého horního rohu do pravého dolního, modrou diagonálu z levého dolního rohu do pravého horního a obě diagonály tvořící X.](diagonal-cell-borders.png)

*Zleva doprava: diagonála dolů (červená, 3 pt), diagonála nahoru (modrá, 5 pt) a obě diagonály.*

## **Sloučení buněk tabulky**

Použijte [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) pro spojení obdélníkového rozsahu buněk tabulky do jedné buňky. Zadejte buňky v levém horním a pravém dolním rohu rozsahu. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `False` ponechá sloučení uvnitř tohoto rozsahu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a poté sloučí čtyři střední buňky od `(1, 1)` po `(2, 2)`. Výsledná buňka zabírá dva sloupce a dva řádky, zatímco podkladová mřížka tabulky si zachovává čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její pozici v levém horním rohu: `table.rows[1][1]` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nemění.

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

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec v mřížce a změnit indexy sloupců buněk napravo. Aspose.Slides se řídí modelem mřížky tabulek PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) na buňce `(1, 1)`. Polovina šířky buňky 70 bodů je předána pro vytvoření dvou buněk stejných šířek.

Po tomto rozdělení jsou dvě poloviny přístupné jako `table.rows[1][1]` a `table.rows[1][2]`. Mřížka tabulky nyní obsahuje pět sloupců: buňky původně ve sloupcích 2 a 3 se posunou na sloupce 3 a 4. Indexy řádků zůstávají nezměněny. Použijte aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

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

<!-- visual-explanation:manage-cells:start -->
[![Nesloučená buňka o šířce 70 bodů se rozdělí na dvě buňky po 35 bodů, přidáním pátého sloupce a posunutím indexů napravo.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Rozdělení šířky postihuje buňku (1, 1) s nulovými (sloupec, řádek) indexy. Ostatní řádky si ponechají buňku prostupující oba nové sloupce.*
<!-- visual-explanation:manage-cells:end -->

### **Rozdělení sloučených buněk podle řádku nebo sloupce**

Pro přípravu sloučených šablonových buněk na naplnění dat použijte [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) pro rozdělení podél existující řádkové hranice nebo [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) pro rozdělení podél sloupcové hranice.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučenému regionu:

- Rozdělení řádku: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Rozdělení sloupce: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Příklad předpokládá, že prezentace má tabulku jako první tvar na prvním snímku, přičemž buňky `(1, 2)` a `(1, 3)` jsou sloučeny vertikálně. Vychozením z dolní pozice používá [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) a [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) k určení počátku a kontroluje oba rozsahy. `split_by_row_span` s indexem 1 pak oddělí řádky 2 a 3 pro názvy produktů. Pro horizontální sloučení dvou sloupců použijte místo toho `split_by_col_span` s indexem 1.

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

        # Získejte výsledné buňky z tabulky po rozdělení.
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

Mřížka tabulky a okolní indexy buněk zůstávají beze změny. Získáte výsledné buňky podle jejich souřadnic; zde mají obě rozsahy hodnotu 1 a [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) vrací `False`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučené.

Původní text a jeho formátování zůstává v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, okraje a okraje. Po rozdělení buňky naplňte textem a případně explicitně nastavte požadované formátování textu.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ s zachovaným formátováním šablony buňky. Viz [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) pro podrobnosti.

### **Rozdělení buňky na konkrétní výšku**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) přijímá výšku horní části v bodech. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) přijímá počet existujících řádků mřížky v horní části. Pro vertikální centrování 40‑bodové buňky ve pravém sloupci odečtěte 40 od skutečné výšky buňky a zbytek rovnoměrně rozdělte nad a pod ní.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

První rozdělení přidá řádek do mřížky, přičemž spodních 90 bodů zůstane v `table.rows[1][1]`. Druhé rozdělení tuto buňku rozdělí na střední buňku o výšce 40 bodů a spodní buňku o výšce 50 bodů. Tři buňky v pravém sloupci mají nyní výšky 50, 40 a 50 bodů shora dolů. Levá buňka prostupuje všechny tři řádky při původní výšce 140 bodů.

![Levá buňka prostupuje celou výšku tabulky vedle tří buněk se středem uprostřed.](split-by-height.png)

## **Změna barvy pozadí buňky tabulky**

Tento příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku, nastaví [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na solid a [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) na červenou.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání obrázku uvnitř buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) a přidá jej do kolekce obrázků prezentace pomocí [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Poté přiřadí obrázek k výplni obrázkem buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) roztahuje obrázek tak, aby vyplnil buňku, což může změnit poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek se automaticky uvolní, když skončí blok `with`.

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

Ano. Okraje [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/),[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/),[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/),[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) mají samostatné vlastnosti, takže tloušťka a styl každé strany mohou být odlišné.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Při roztažení se obrázek přizpůsobí nové buňce, při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz na celý obsah buňky?**

[Hyperlinks](/slides/cs/python-net/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz buď k části, nebo ke všemu textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (běhy) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.