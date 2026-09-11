---
title: Správa řádků a sloupců v tabulkách PowerPointu pomocí Pythonu
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/python-java/manage-rows-and-columns/
keywords:
- řádek tabulky
- sloupec tabulky
- první řádek
- hlavička tabulky
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
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí Aspose.Slides pro Python přes Java a urychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aby vám umožnil spravovat řádky a sloupce tabulky v prezentaci PowerPoint, Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) a mnoho dalších typů.

## **Nastavit první řádek jako hlavičku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci.  
2. Získejte referenci na snímek podle jeho indexu.  
3. Vytvořte referenci na [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) a přiřaďte jí hodnotu `None`.  
4. Projděte všechny objekty [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/) a najděte příslušnou tabulku.  
5. Nastavte první řádek tabulky jako její hlavičku.

Tento Python kód ukazuje, jak nastavit první řádek tabulky jako hlavičku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonovat řádek nebo sloupec tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci.  
2. Získejte referenci na snímek podle jeho indexu.  
3. Definujte seznam šířek sloupců.  
4. Definujte seznam výšek řádků.  
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) do snímku pomocí metody [addTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addTable).  
6. Zklonujte řádek tabulky.  
7. Zklonujte sloupec tabulky.  
8. Uložte upravenou prezentaci.

Tento Python kód ukazuje, jak klonovat řádek nebo sloupec tabulky v PowerPointu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
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

## **Odstranit řádek nebo sloupec z tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).  
2. Získejte referenci na snímek podle jeho indexu.  
3. Definujte seznam šířek sloupců.  
4. Definujte seznam výšek řádků.  
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) do snímku pomocí metody [addTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addTable).  
6. Odstraňte řádek tabulky.  
7. Odstraňte sloupec tabulky.  
8. Uložte upravenou prezentaci.

Tento Python kód ukazuje, jak odstranit řádek nebo sloupec z tabulky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavit formátování textu na úrovni řádku tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci.  
2. Získejte referenci na snímek podle jeho indexu.  
3. Získejte příslušný objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) ze snímku.  
4. Nastavte výšku písma buněk v prvním řádku pomocí [setFontHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Nastavte zarovnání textu a pravý okraj buněk v prvním řádku pomocí [setAlignment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setAlignment) a [setMarginRight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Nastavte vertikální typ textu buněk ve druhém řádku pomocí [setTextVerticalType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Uložte upravenou prezentaci.

Tento Python kód demonstruje operaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci.  
2. Získejte referenci na snímek podle jeho indexu.  
3. Získejte příslušný objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) ze snímku.  
4. Nastavte výšku písma buněk v prvním sloupci pomocí [setFontHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Nastavte zarovnání textu a pravý okraj buněk v prvním sloupci pomocí [setAlignment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setAlignment) a [setMarginRight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Nastavte vertikální typ textu buněk ve druhém sloupci pomocí [setTextVerticalType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Uložte upravenou prezentaci.

Tento Python kód demonstruje operaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Získat vlastnosti stylu tabulky**

Aspose.Slides vám umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo kdekoliv jinde. Tento Python kód ukazuje, jak získat vlastnosti stylu z přednastaveného stylu tabulky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu na již vytvořenou tabulku použít motivy/styly PowerPointu?**

Ano. Tabulka dědí motiv snímku/pouzdra/mistra a přesto můžete přepisovat výplně, okraje a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky v Aspose.Slides nemají vestavěné řazení ani filtry. Nejprve seřaďte data v paměti a poté naplňte řádky tabulky v tomto pořadí.

**Mohu mít pruhované sloupce a zároveň zachovat vlastní barvy v konkrétních buňkách?**

Ano. Zapněte pruhované sloupce a poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.