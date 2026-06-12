---
title: Správa řádků a sloupců v tabulkách PowerPoint pomocí Pythonu
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/python-net/manage-rows-and-columns/
keywords:
- řádek tabulky
- sloupec tabulky
- první řádek
- záhlaví tabulky
- klonovat řádek
- klonovat sloupec
- kopírovat řádek
- kopírovat sloupec
- odstranit řádek
- odstranit sloupec
- formátování textu řádku
- formátování textu sloupce
- styl tabulky
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravujte řádky a sloupce tabulky v PowerPoint a OpenDocument pomocí Aspose.Slides pro Python na platformě .NET a zrychlete úpravy prezentací a aktualizaci dat."
---
## **Přehled**

Tento článek ukazuje, jak spravovat řádky a sloupce tabulky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python. Naučíte se, jak přidávat, vkládat, klonovat a mazat řádky nebo sloupce, označit první řádek jako záhlaví, upravovat velikost a rozložení a aplikovat formátování textu a stylu na úrovni řádku nebo sloupce. Každý úkol je předveden pomocí kompaktních, samostatných ukázkových kódu založených na rozhraní [Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/) API, takže můžete rychle najít tabulku na snímku a přetvořit její strukturu tak, aby odpovídala vašemu návrhu.

## **Nastavit první řádek jako záhlaví**

Označte první řádek tabulky jako záhlaví, aby byly jasně odlišeny názvy sloupců od dat. V Aspose.Slides pro Python stačí povolit možnost *First Row* tabulky, aby se použilo formátování záhlaví definované vybraným stylem tabulky.

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci.
1. Získejte snímek podle jeho indexu.
1. Projděte všechny objekty [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) a najděte požadovanou tabulku.
1. Nastavte první řádek tabulky jako záhlaví.

Tento Python kód ukazuje, jak nastavit první řádek tabulky jako záhlaví:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Projděte tvary a získejte odkaz na tabulku.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Nastavte první řádek tabulky jako její záhlaví.
    table.first_row = True
    
    # Uložte prezentaci na disk.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonovat řádek nebo sloupec tabulky**

Zkopírujte libovolný řádek nebo sloupec tabulky a vložte kopii na požadovanou pozici v tabulce. Duplikát zachová obsah buněk, formátování i velikosti, takže můžete rozšířit rozvržení rychle a konzistentně.

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci.
1. Získejte snímek podle jeho indexu.
1. Definujte pole šířek sloupců.
1. Definujte pole výšek řádků.
1. Přidejte [Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/) na snímek pomocí `add_table(x, y, column_widths, row_heights)`.
1. Klonujte řádek tabulky.
1. Klonujte sloupec tabulky.
1. Uložte upravenou prezentaci.

Tento Python kód ukazuje, jak klonovat řádek a sloupec tabulky PowerPoint:

```python
 import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Definujte šířky sloupců a výšky řádků.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Přidejte tabulku na snímek.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Přidejte text do řádku 1, sloupec 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Přidejte text do řádku 2, sloupec 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Klonujte řádek 1 na konci tabulky.
    table.rows.add_clone(table.rows[0], False)

    # Přidejte text do řádku 1, sloupec 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Přidejte text do řádku 2, sloupec 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Klonujte řádek 2 jako 4. řádek tabulky.
    table.rows.insert_clone(3,table.rows[1], False)

    # Klonujte první sloupec na konci.
    table.columns.add_clone(table.columns[0], False)

    # Klonujte druhý sloupec na indexu 3 (4. pozice).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Uložte prezentaci na disk.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit řádek nebo sloupec z tabulky**

Zjednodušte tabulku odstraněním libovolného řádku nebo sloupce podle indexu pomocí Aspose.Slides pro Python — rozvržení se automaticky přizpůsobí a zachová formátování zbývajících buněk. To je užitečné pro zjednodušení datových mřížek nebo smazání zástupných prvků bez nutnosti přestavovat tabulku.

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci.
1. Získejte snímek podle jeho indexu.
1. Definujte pole šířek sloupců.
1. Definujte pole výšek řádků.
1. Přidejte ITable na snímek pomocí `add_table(x, y, column_widths, row_heights)`.
1. Odstraňte řádek tabulky.
1. Odstraňte sloupec tabulky.
1. Uložte upravenou prezentaci.

Následující Python kód ukazuje, jak odstranit řádek a sloupec z tabulky:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit formátování textu na úrovni řádku tabulky**

Aplikujte konzistentní stylování textu na celý řádek tabulky v jednom kroku. S Aspose.Slides pro Python můžete najednou nastavit rodinu písma, velikost, tučnost, barvu a zarovnání pro všechny buňky v řádku, aby byly nadpisy nebo datové pásy jednotné.

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci.
1. Získejte snímek podle jeho indexu.
1. Získejte příslušný objekt [Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/) na snímku.
1. Nastavte výšku písma pro buňky prvního řádku.
1. Nastavte zarovnání a pravý okraj pro buňky prvního řádku.
1. Nastavte svislý typ textu pro buňky druhého řádku.
1. Uložte upravenou prezentaci.

Tento Python kód demonstruje operaci.

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Nastavte výšku písma pro buňky prvního řádku.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Nastavte zarovnání textu a pravý okraj buněk prvního řádku.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Nastavte svislý typ textu buněk druhého řádku.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Uložte prezentaci na disk.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

Aplikujte konzistentní stylování textu na celý sloupec tabulky najednou. S Aspose.Slides pro Python můžete nastavit rodinu písma, velikost, tučnost, barvu a zarovnání pro všechny buňky ve sloupci a vytvořit tak jednotné svislé pásy pro nadpisy nebo data.

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci.
1. Získejte snímek podle jeho indexu.
1. Získejte příslušný objekt [Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/) na snímku.
1. Nastavte výšku písma pro buňky prvního sloupce.
1. Nastavte zarovnání a pravý okraj pro buňky prvního sloupce.
1. Nastavte svislý typ textu pro buňky druhého sloupce.
1. Uložte upravenou prezentaci.

Následující Python kód demonstruje operaci:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Nastavte výšku písma buněk prvního sloupce.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Nastavte zarovnání textu a pravý okraj buněk prvního sloupce.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Nastavte svislý typ textu buněk druhého sloupce.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Uložte prezentaci na disk.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Získat vlastnosti stylu tabulky**

Aspose.Slides umožňuje získat vlastnosti stylu tabulky, abyste je mohli znovu použít pro jinou tabulku nebo jinde. Následující Python kód ukazuje, jak získat vlastnosti stylu z přednastaveného stylu tabulky:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu na již vytvořenou tabulku aplikovat motivy/styly PowerPoint?**

Ano. Tabulka dědí motiv snímku/rozvržení/mistra a přesto můžete přepsat výplně, okraje a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Nejprve seřaďte data v paměti a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít proužkované (pruhované) sloupce a přitom zachovat vlastní barvy v konkrétních buňkách?**

Ano. Zapněte proužkované sloupce a poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.