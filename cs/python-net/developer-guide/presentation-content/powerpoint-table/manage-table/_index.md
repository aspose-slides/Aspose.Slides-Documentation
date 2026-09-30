---
title: Správa tabulek v prezentacích pomocí Pythonu
linktitle: Spravovat tabulku
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
description: "Vytvářejte a upravujte tabulky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Python přes .NET. Objevte jednoduché ukázky kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulky v PowerPointu organizují informace do řádků a sloupců, což usnadňuje čtení a porovnávání hodnot.

Aspose.Slides poskytuje třídy [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) a [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) a další typy, které vám umožní vytvářet, aktualizovat a spravovat tabulky v prezentacích.

## **Vytvoření tabulky od nuly**

Vytvořte tabulku zadáním její pozice, šířek sloupců a výšek řádků. Po přidání do snímku můžete formátovat okraje buněk, slučovat buňky a vkládat text.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte seznam šířek sloupců v bodech.
4. Definujte seznam výšek řádků v bodech.
5. Přidejte objekt [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) na snímek pomocí metody [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Projděte každou [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) a aplikujte formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky v první řadě tabulky.
8. Přistupte ke sloučené buňce přes její vlastnost [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Nastavte text ve sloučené buňce.
10. Uložte upravenou prezentaci.

Níže uvedený příklad vytvoří tabulku se třemi sloupci a pěti řádky na pozici (100, 50) bodů. Aplikuje červené okraje o šířce 5 bodů, sloučí první dvě buňky v první řadě a uloží výsledek jako `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce jsou indexy buněk nulové a používají pořadí (sloupec, řádek). První buňka má index (0, 0). V Pythonu přistupujete k buňce pomocí `table.rows[row_index][column_index]`; v tomto výrazu je nejprve index řádku.

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento příklad vytvoří 4 × 4 tabulku uvedenou výše, se šířkami sloupců a výškami řádků 70 bodů a červenými okraji buněk o šířce 5 bodů. Souřadnice ilustrují indexy buněk; příklad nechá buňky prázdné a uloží tabulku jako `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k existující tabulce**

Tabulky jsou uloženy ve sbírce tvarů snímku. Procházejte tvary, abyste našli tabulku, a poté použijte třídu [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) k načtení nebo aktualizaci jejích buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující tabulku podle jeho indexu.
3. Procházejte objekty [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) a zastavte se, když najdete tabulku. Pokud snímek obsahuje několik tabulek, použijte [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) k identifikaci té požadované.
4. Aktualizujte text v cílové buňce.
5. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `UpdateExistingTable.pptx` a najde první tabulku na prvním snímku. Nastaví buňku ve sloupci 0, řádek 1 na `New` a uloží výsledek jako `table1_out.pptx`. Vstup musí obsahovat alespoň jeden snímek a první tabulka na tomto snímku musí mít alespoň jeden sloupec a dva řádky.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Pro změnu velikosti řádku v existující tabulce a pochopení, proč může jeho skutečná výška převýšit požadované minimum, viz [Control Row Height](/slides/cs/python-net/manage-rows-and-columns/#control-row-height).

## **Nalezení buňky, která vlastní textový rámec**

Když obecný kód pro zpracování textu získá [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) z tabulky, použijte vlastnost [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) k získání vlastnické [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Pro textový rámec buňky tabulky je [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) nastaven a [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) je `None`, přestože samotná tabulka je tvar.

Souřadnice buňky jsou dostupné prostřednictvím pouze pro čtení vlastností [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) a [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) je také jen pro čtení: poskytuje navigaci k vlastníkovi, ale nemění vlastnictví. Vždy zkontrolujte, zda vrácená buňka není `None`, před jejím použitím.

Pro kompletní příklad, který identifikuje vlastníky buňky tabulky a tvaru, včetně tvarů spojených se SmartArt uzly, viz [Search and Replace Text](/slides/cs/python-net/search-and-replace-text/).

## **Zarovnání textu v tabulce**

Můžete řídit vertikální ukotvení a směr textu jednotlivých buněk tabulky. Příklad v této sekci vycentruje text v první buňce a otočí jej o 270 stupňů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) na snímek.
4. Získejte objekt [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) z tabulky.
5. Získejte první [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) a nastavte jeho text a barvu.
6. Nastavte buňce [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) a [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/).
7. Uložte upravenou prezentaci.

Tento příklad vytvoří 4 × 4 tabulku s šířkami sloupců 120 bodů a výškami řádků 100 bodů. Formátuje text v buňce (0, 0), přidá hodnoty do zbývajících buněk v první řadě a uloží výsledek jako `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení formátování textu na úrovni tabulky**

Použijte [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) k aplikaci formátování textu na všechny buňky v tabulce. Jeho přetížení přijímají formátování úseku, odstavce a textového rámce, takže můžete nastavit tyto vlastnosti bez procházení jednotlivých buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte objekt [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ze snímku.
4. Nastavte [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) pro text.
5. Nastavte [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) a [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Nastavte [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `table.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jeho prvním tvarem. Nastaví velikost písma na 25 bodů, zarovná odstavce vpravo s pravým okrajem 20 bodů a nastaví text vertikální. Formátovaná prezentace je uložena jako `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání vlastností stylu tabulky**

Použijte [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) k přečtení nebo přiřazení předdefinovaného stylu tabulky. Tento příklad použije [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) na jednu tabulku, vypíše název předvoleb a přiřadí stejný styl druhé tabulce. Obě tabulky jsou uloženy v `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzamknutí poměru stran tabulky**

Poměr stran tabulky je poměr její šířky k výšce. Použijte [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) k uzamčení tohoto poměru pro tabulku.

Níže uvedený příklad otevře `pres.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jeho prvním tvarem. Vytiskne aktuální stav uzamčení, povolí uzamčení poměru stran, vytiskne aktualizovaný stav (`True`) a uloží výsledek jako `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka poskytuje vlastnost [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), a odstavce mají [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Použití obou zajišťuje správné RTL pořadí a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesunu nebo změně velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/python-net/applying-protection-to-presentation/), abyste zakázali přesun, změnu velikosti, výběr apod. Tyto zámky se vztahují i na tabulky.

**Je podporováno vložení obrázku uvnitř buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztáhnout nebo dlaždice).