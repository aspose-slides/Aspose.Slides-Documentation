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
description: "Spravujte řádky a sloupce tabulky v PowerPointu s Aspose.Slides pro Python via .NET a urychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aspose.Slides for Python via .NET vám umožňuje spravovat strukturu tabulky a její formátování v prezentacích PowerPoint pomocí třídy [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) . Můžete označit řádek jako záhlaví, klonovat nebo odstraňovat řádky a sloupce a použít formátování textu na celý řádek nebo sloupec.

Tento článek popisuje tyto operace pomocí příkladů v Pythonu. Také ukazuje, jak získat přednastavený styl tabulky, abyste jej mohli znovu použít. Indexy řádků a sloupců tabulky jsou založeny na nule.

## **Ovládání výšky řádku**

Použijte [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) k nastavení minimální výšky řádku v bodech. Jedná se o dolní hranici, nikoli pevnou výšku. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) vrací skutečnou výšku a je jen pro čtení. Přístup k řádku získáte přes [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

Příklad načte [row-height-input.pptx](row-height-input.pptx), který má tabulku jako první tvar na první snímku. První řádek začíná na 70 bodech. Buňky používají text Arial 18 bodů, zalamování a horní a dolní okraje 6 bodů; delší text ve druhém sloupci se zalamuje do více řádků. Příklad zvýší minimum na 100 bodů, poté ho sníží na 20 bodů, vytiskne skutečnou výšku po každé změně a uloží oba výsledky.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

S dodanou prezentací zvýšení minima přidá prostor řádku. Snížení odebere tento přebytečný prostor, ale skutečná výška zůstane větší než 20 bodů, protože text a okraje buněk vyžadují více místa. Pouhé snížení minima nemůže řádek vtlačit pod prostor požadovaný jeho obsahem.

Několik faktorů ovlivňuje skutečnou výšku:

- **Text a velikost písma:** delší text, explicitní zalomení řádků nebo větší písmo může vyžadovat více vertikálního prostoru.
- **Zalamování a šířka sloupce:** při zapnutém zalamování může užší [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) vytvořit více řádků. Širší sloupec může vertikální prostor snížit.
- **Okraje buňky:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) a [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) přidávají vertikální prostor. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) a [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) snižují šířku dostupnou pro text a mohou způsobit další zalamování.

Pro tuto tabulku bez sloučených buněk určuje buňka, která potřebuje nejvíce vertikálního prostoru, spodní limit celého řádku řízený obsahem. Aby byl řádek kratší, může být potřeba zkrátit text, zmenšit velikost písma nebo okraje, nebo rozšířit sloupec.

Obrázky níže ukazují stejnou tabulku ve stejném měřítku. V tomto běhu byly skutečné výšky 70, 100 a 55,2 bodu: poslední řádek zůstal vyšší než jeho minimum 20 bodů. Přesná měření textu se mohou lišit podle písem dostupných ve vašem prostředí. Stáhněte si uložené výsledky: [zvýšené minimum](row-height-increased.pptx) a [snížené minimum](row-height-decreased.pptx).

| Původní: minimum 70 pt, skutečná 70 pt | Zvýšené: minimum 100 pt, skutečná 100 pt | Snížené: minimum 20 pt, skutečná 55.2 pt |
| --- | --- | --- |
| ![Původní tabulka s prvním řádkem o výšce 70 bodů.](row-height-before.png) | ![Tabulka po zvýšení minimální výšky prvního řádku na 100 bodů.](row-height-increased.png) | ![Tabulka po snížení minimální výšky prvního řádku na 20 bodů; zalomený text udržuje řádek vyšší než minimum.](row-height-decreased.png) |

## **Nastavit první řádek jako záhlaví**

Použijte vlastnost [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) k označení prvního řádku pro formátování záhlaví. Jeho vzhled závisí na stylu tabulky použitém na tabulku.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Získejte první snímek.
3. Získejte tabulku uloženou jako první tvar na snímku.
4. Povolit formátování záhlaví pro její první řádek.
5. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první tvar na první snímku. Povolením formátování záhlaví pro první řádek uloží soubor `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonovat řádek nebo sloupec tabulky**

Klonovat řádky nebo sloupce pro opětovné použití jejich obsahu a formátování. Kopii můžete připojit na konec tabulky nebo vložit na konkrétní pozici.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku metodou [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
5. Klonujte požadované řádky.
6. Klonujte požadované sloupce.
7. Uložte upravenou prezentaci.

Příklad vyžaduje `Test.pptx` s alespoň jedním snímkem. Vytvoří tabulku se třemi sloupci a pěti řádky, rozměry jsou zadány v bodech. Připojí kopie prvního řádku a sloupce, poté vloží kopie druhého řádku a sloupce na index 3 (čtvrtá pozice). Výsledná tabulka má sedm řádků a pět sloupců. Argument `False` zakazuje klonování do sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit řádek nebo sloupec z tabulky**

Odstranit řádky nebo sloupce, které již v tabulce nejsou potřeba. Odstranění položky posune indexy řádků nebo sloupců, které po ní následují.

1. Vytvořte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku metodou [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
5. Odstraňte druhý řádek a druhý sloupec.
6. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 3 × 3 a odstraní řádek a sloupec na indexu 1, takže zůstane tabulka 2 × 2 v souboru `TestTable_out.pptx`. Rozměry jsou v bodech. Argument `False` zakazuje odstranění sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

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

Použít formátování textu na celý řádek, aby buňky měly jednotný vzhled. Můžete nastavit vlastnosti písma, formátování odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Získejte tabulku na první snímku.
3. Nastavte [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) pro první řádek.
4. Nastavte [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) a [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) pro první řádek.
5. Nastavte [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) pro druhý řádek.
6. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první tvar na první snímku a alespoň dvěma řádky. Použije text 25 bodů, zarovnání vpravo a pravý okraj odstavce 20 bodů na první řádek, poté nastaví vertikální text ve druhém řádku.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

Použít formátování textu na celý sloupec, aby buňky měly jednotný vzhled. Můžete nastavit vlastnosti písma, formátování odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Získejte tabulku na první snímku.
3. Nastavte [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) pro první sloupec.
4. Nastavte [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) a [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) pro první sloupec.
5. Nastavte [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) pro druhý sloupec.
6. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první tvar na první snímku a alespoň dvěma sloupci. Použije text 25 bodů, zarovnání vpravo a pravý okraj odstavce 20 bodů na první sloupec, poté nastaví vertikální text ve druhém sloupci.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Získat vlastnosti stylu tabulky**

Použijte vlastnost [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) k získání přednastaveného stylu aplikovaného na tabulku a jeho opětovnému použití na jiné tabulce. Identifikuje preset namísto jednotlivých přepisů formátování buněk.

Příklad vytvoří tabulku, použije [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) a načte preset zpět. Vytiskne `True`, když načtený preset odpovídá použitému, a uloží tabulku v `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu použít motivy/styly PowerPoint na již vytvořenou tabulku?**

Ano. Tabulka dědí motiv snímku/podkladu/mistra a můžete stále přepsat výplně, okraje a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Seřaďte svá data v paměti nejprve a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít proužkované (pruhované) sloupce a současně si ponechat vlastní barvy v konkrétních buňkách?**

Ano. Zapněte proužkované sloupce a poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.