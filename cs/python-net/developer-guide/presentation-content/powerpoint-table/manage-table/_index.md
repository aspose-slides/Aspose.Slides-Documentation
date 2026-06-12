---
title: Správa tabulek prezentace pomocí Pythonu
linktitle: Správa tabulky
type: docs
weight: 10
url: /cs/python-net/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnat text
- formátování textu
- styl tabulky
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Python přes .NET. Objevte jednoduché příklady kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak prezentovat informace. Informace uspořádané v mřížce buněk (řádky a sloupce) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table], třídu [Cell] a další související typy, které vám pomohou vytvářet, aktualizovat a spravovat tabulky v libovolné prezentaci.

## **Vytvoření tabulek od nuly**

Tato sekce ukazuje, jak vytvořit tabulku od nuly v Aspose.Slides přidáním tvaru tabulky na snímek, definováním řádků a sloupců a nastavením přesných velikostí. Také uvidíte, jak naplnit buňky textem, upravit zarovnání a okraje a přizpůsobit vzhled tabulky.

1. Vytvořte instanci třídy [Presentation].
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte pole šířek sloupců.
4. Definujte pole výšek řádků.
5. Přidejte [Table] na snímek.
6. Iterujte přes každou [Cell] a upravte její horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky v prvním řádku tabulky.
8. Získejte [TextFrame] buňky [Cell].
9. Přidejte text do [TextFrame].
10. Uložte upravenou prezentaci.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    # Přístup k prvnímu snímku.
    slide = presentation.slides[0]

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Přidejte tvar tabulky na snímek.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Nastavte formát okraje pro každou buňku.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Sloučte buňky od (řádek 0, sloupec 0) do (řádek 1, sloupec 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Přidejte text do sloučené buňky.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Uložte prezentaci na disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Číslování ve standardních tabulkách**

Ve standardní tabulce je číslování buněk jednoduché a začíná od nuly. První buňka v tabulce má index (0, 0) (sloupec 0, řádek 0).

Například v tabulce se 4 sloupci a 4 řádky jsou buňky očíslovány následovně:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Následující příklad v Pythonu ukazuje, jak odkazovat na buňky pomocí tohoto číslování od nuly:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Přístup k existující tabulce**

Tato sekce vysvětluje, jak najít a pracovat s existující tabulkou v prezentaci pomocí Aspose.Slides. Naučíte se, jak najít tabulku na snímku, přistupovat k jejím řádkům, sloupcům a buňkám a aktualizovat obsah nebo formátování.

1. Vytvořte instanci třídy [Presentation].
2. Získejte odkaz na snímek, který obsahuje tabulku, podle jeho indexu.
3. Iterujte přes všechny objekty [Shape], dokud nenajdete tabulku.
4. Použijte objekt [Table] pro práci s tabulkou.
5. Uložte upravenou prezentaci.

{{% alert color="info" %}}
Pokud snímek obsahuje několik tabulek, je lepší vyhledat požadovanou tabulku podle její vlastnosti `alternative_text`.
{{% /alert %}}

Následující příklad v Pythonu ukazuje, jak přistupovat k existující tabulce a pracovat s ní:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvořte instanci třídy Presentation pro načtení souboru PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    table = None

    # Iterujte přes tvary a odkazujte na první nalezenou tabulku.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Nastavte text první buňky v prvním řádku.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Uložte upravenou prezentaci na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zarovnání textu v tabulkách**

Tato sekce ukazuje, jak řídit zarovnání textu uvnitř buněk tabulky pomocí Aspose.Slides. Naučíte se nastavit vodorovné i svislé zarovnání buněk, aby byl váš obsah přehledný a konzistentní.

1. Vytvořte instanci třídy [Presentation].
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [Table] na snímek.
4. Získejte objekt [Cell] z tabulky.
5. Zarovnejte text vertikálně.
6. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak zarovnat text v tabulce:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Přidejte tvar tabulky na snímek.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Centrovat text a nastavit svislou orientaci.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Uložte prezentaci na disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení formátování textu na úrovni tabulky**

Tato sekce ukazuje, jak aplikovat formátování textu na úrovni tabulky v Aspose.Slides, aby každá buňka zdědila jednotný styl. Naučíte se globálně nastavit velikost písma, zarovnání a okraje.

1. Vytvořte instanci třídy [Presentation].
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [Table] na snímek.
4. Nastavte velikost písma (výšku písma) pro text.
5. Nastavte zarovnání odstavce a okraje.
6. Nastavte vertikální orientaci textu.
7. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak aplikovat preferované možnosti formátování na text v tabulce:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvoří instanci třídy Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Nastavte velikost písma pro všechny buňky tabulky.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Nastavte text zarovnaný vpravo a pravý okraj pro všechny buňky tabulky.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Nastavte svislou orientaci textu pro všechny buňky tabulky.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Použití vestavěných stylů tabulek**

Aspose.Slides vám umožňuje formátovat tabulky pomocí předdefinovaných stylů přímo v kódu. Příklad demonstruje vytvoření tabulky, aplikaci vestavěného stylu a uložení výsledku — efektivní způsob, jak zajistit konzistentní, profesionální formátování.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzamčení poměru stran tabulek**

Poměr stran tvaru je poměr jeho rozměrů. Aspose.Slides poskytuje vlastnost `aspect_ratio_locked`, která umožňuje uzamknout poměr stran pro tabulky i jiné tvary.

Následující příklad v Pythonu ukazuje, jak uzamknout poměr stran pro tabulku:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku i text v jejích buňkách?**

Ano. Tabulka poskytuje vlastnost [right_to_left] a odstavce mají [ParagraphFormat.right_to_left]. Použitím obojího se zajistí správné RTL pořadí a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesunu nebo změně velikosti tabulky v konečném souboru?**

Použijte [uzamčení tvaru](/slides/cs/python-net/applying-protection-to-presentation/) k zakázání přesunu, změny velikosti, výběru apod. Tato uzamčení platí i pro tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Můžete nastavit [vyplnění obrázkem] pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztáhnout nebo dlaždice).