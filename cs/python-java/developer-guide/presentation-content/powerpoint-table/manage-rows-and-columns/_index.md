---
title: Správa řádků a sloupců v tabulkách PowerPoint pomocí Pythonu
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/python-java/manage-rows-and-columns/
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
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí Aspose.Slides pro Python přes Java a zrychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aspose.Slides for Python via Java vám umožňuje spravovat strukturu tabulky a formátování v prezentacích PowerPoint pomocí třídy [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Můžete označit řádek jako záhlaví, klonovat nebo odstraňovat řádky a sloupce a použít formátování textu na celý řádek nebo sloupec.

Tento článek vysvětluje tyto operace pomocí příkladů v Pythonu. Také ukazuje, jak získat přednastavený styl tabulky, abyste jej mohli znovu použít. Indexy řádků a sloupců tabulky jsou založeny na nule.

## **Řízení výšky řádku**

Použijte [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) k nastavení minimální výšky řádku v bodech. Jedná se o spodní mez, nikoli pevnou výšku. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) vrací skutečnou výšku. Přístup k řádku získáte přes [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

Příklad načte soubor [row-height-input.pptx](row-height-input.pptx), který má tabulku jako první objekt na první snímku. Jeho první řádek začíná ve výšce 70 bodů. Buňky používají text Arial o velikosti 18 bodů, zalamování a 6‑bodové horní a spodní okraje; delší text ve druhém sloupci se zalamuje do několika řádků. Příklad zvýší minimum na 100 bodů, poté jej sníží na 20 bodů, vytiskne skutečnou výšku po každé změně a uloží oba výsledky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

U poskytnuté prezentace přidání minima přidá řádku prostor. Snížení minima odstraní tento přebytečný prostor, ale skutečná výška zůstane větší než 20 bodů, protože text a okraje buněk vyžadují více místa. Pouze snížení minima nemůže řádek vynutit pod prostor potřebný pro jeho obsah.

Několik faktorů ovlivňuje skutečnou výšku:

- **Text a velikost písma:** delší text, explicitní zalomení řádků nebo větší písmo mohou vyžadovat více svislého prostoru.
- **Zalamování a šířka sloupce:** při zapnutém zalamování může snížení šířky sloupce pomocí [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) vytvořit více řádků. Širší sloupec může svislý prostor snížit.
- **Okraje buněk:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) a [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) přidávají svislý prostor. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) a [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) zmenšují šířku dostupnou pro text a mohou způsobit další zalamování.

Pro tuto tabulku bez sloučených buněk určuje buňka, která potřebuje nejvíce svislého prostoru, spodní limit obsahu pro celý řádek. Pokud chcete řádek zkrátit, možná bude nutné zkrátit text, zmenšit velikost písma nebo okraje, nebo rozšířit sloupec.

Obrázky níže zobrazují stejnou tabulku ve stejném měřítku. Ve výsledcích byly skutečné výšky 70, 100 a 55,2 bodu: poslední řádek zůstal vyšší než jeho minimum 20 bodů. Přesné měření textu se může lišit podle fontů dostupných ve vašem prostředí. Stáhněte si uložené výsledky: [increased minimum](row-height-increased.pptx) a [decreased minimum](row-height-decreased.pptx).

| Originál: minimum 70 pt, skutečná výška 70 pt | Zvětšeno: minimum 100 pt, skutečná výška 100 pt | Zmenšeno: minimum 20 pt, skutečná výška 55,2 pt |
| --- | --- | --- |
| ![Původní tabulka s prvním řádkem o výšce 70 bodů.](row-height-before.png) | ![Tabulka po zvýšení minimální výšky prvního řádku na 100 bodů.](row-height-increased.png) | ![Tabulka po snížení minimální výšky prvního řádku na 20 bodů; zalomený text udržuje řádek vyšší než minimum.](row-height-decreased.png) |

## **Nastavení první řádky jako záhlaví**

Použijte metodu [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) k označení prvního řádku pro formátování záhlaví. Jeho vzhled závisí na stylu tabulky použitém na tabulce.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Získejte tabulku uloženou jako první objekt na snímku.
4. Povolte formátování záhlaví pro její první řádek.
5. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první objekt na první snímek. Zapíná formátování záhlaví pro první řádek a ukládá `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonování řádku nebo sloupce tabulky**

Klonujte řádky nebo sloupce, abyste znovu použili jejich obsah a formátování. Kopii můžete připojit na konec tabulky nebo ji vložit na konkrétní pozici.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Klonujte požadované řádky.
6. Klonujte požadované sloupce.
7. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `Test.pptx` s alespoň jedním snímkem. Vytvoří tabulku se třemi sloupci a pěti řádky, přičemž rozměry jsou zadány v bodech. Přidá kopie prvního řádku a sloupce, poté vloží kopie druhého řádku a sloupce na index 3 (čtvrtá pozice). Výsledná tabulka má sedm řádků a pět sloupců. Argument `False` zakazuje klonování do sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odstranění řádku nebo sloupce z tabulky**

Odstraňte řádky nebo sloupce, které už v tabulce nejsou potřeba. Odebrání položky posune indexy řádků nebo sloupců, které za ní následují.

1. Vytvořte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Odstraňte druhý řádek a druhý sloupec.
6. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku tři × tři a odstraní řádek a sloupec na indexu 1, čímž vznikne tabulka dva × dvě v souboru `TestTable_out.pptx`. Rozměry jsou v bodech. Argument `False` zakazuje odstranění sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení formátování textu na úrovni řádku tabulky**

Použijte formátování textu na celý řádek, aby buňky zůstaly konzistentní. Můžete nastavit vlastnosti písma, formát odstavce a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte tabulku na prvním snímku.
3. Použijte [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) pro první řádek.
4. Použijte [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) a [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) pro první řádek.
5. Použijte [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) pro druhý řádek.
6. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první objekt na první snímek a alespoň dvěma řádky. Použije 25‑bodový text, zarovnání vpravo a 20‑bodový pravý okraj odstavce na první řádek, poté nastaví vertikální text ve druhém řádku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení formátování textu na úrovni sloupce tabulky**

Použijte formátování textu na celý sloupec, aby buňky zůstaly konzistentní. Můžete nastavit vlastnosti písma, formát odstavce a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte tabulku na prvním snímku.
3. Použijte [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) pro první sloupec.
4. Použijte [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) a [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) pro první sloupec.
5. Použijte [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) pro druhý sloupec.
6. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první objekt na první snímek a alespoň dvěma sloupci. Použije 25‑bodový text, zarovnání vpravo a 20‑bodový pravý okraj odstavce na první sloupec, poté nastaví vertikální text ve druhém sloupci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Získání vlastností stylu tabulky**

Použijte metodu [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) k získání přednastaveného stylu aplikovaného na tabulku a jeho opětovnému použití na jiné tabulce. Tím se identifikuje předvolba místo individuálních přepisů formátování buněk.

Příklad vytvoří tabulku, použije [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) a přečte zpět předvolbu. Vytiskne celočíselnou hodnotu odpovídající `DarkStyle1` a uloží tabulku v souboru `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu použít motivy/styly PowerPointu na již vytvořenou tabulku?**

Ano. Tabulka dědí motiv snímku/podkladu/mistra a přesto můžete přepsat výplně, okraje a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Seřaďte data v paměti nejprve a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít pruhované (striped) sloupce a zároveň zachovat vlastní barvy u konkrétních buněk?**

Ano. Zapněte pruhované sloupce a poté přepište konkrétní buňky místním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.