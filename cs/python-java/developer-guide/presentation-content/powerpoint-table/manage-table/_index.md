---
title: Správa tabulek prezentací v Pythonu
linktitle: Správa tabulky
type: docs
weight: 10
url: /cs/python-java/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnat text
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint snímcích pomocí Aspose.Slides pro Python přes Java. Objevte jednoduché příklady kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak zobrazit informace. Informace v mřížce buněk (uspořádaných v řadách a sloupcích) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) třídu [Cell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cell/) a další typy, které vám umožňují vytvářet, aktualizovat a spravovat tabulky ve všech druzích prezentací.

## **Vytvoření tabulky od začátku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte seznam šířek sloupců.
4. Definujte seznam výšek řádků.
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) do snímku pomocí metody [addTable](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addTable).
6. Procházejte každou [Cell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cell/), abyste aplikovali formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky první řady tabulky.
8. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) buňky [Cell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cell/).
9. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/).
10. Uložte upravenou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Vytvoří instanci třídy Presentation, která představuje soubor PPTX
presentation = Presentation()
try:

    # Přistupuje k prvnímu snímku
    slide = presentation.getSlides().get_Item(0)

    # Definuje sloupce se šířkami a řádky s výškami
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Přidá tvar tabulky do snímku
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Nastaví formát okraje pro každou buňku
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Sloučí buňky 1 a 2 v řadě 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Přidá nějaký text do sloučené buňky
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Uloží prezentaci na disk
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce je číslování buněk jednoduché a začíná od nuly. První buňka v tabulce má index 0,0 (sloupec 0, řada 0).

Například buňky v tabulce se 4 sloupci a 4 řadami jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento Python kód vám ukazuje, jak vytvořit tabulku s běžným číslováním buněk:

```python
import jpame
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Vytvoří instanci třídy Presentation, která představuje soubor PPTX
presentation = Presentation()
try:

    # Přistupuje k prvnímu snímku
    slide = presentation.getSlides().get_Item(0)

    # Definuje sloupce se šířkami a řádky s výškami
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Přidá tvar tabulky do snímku
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Nastaví formát okraje pro každou buňku
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

    # Uloží prezentaci na disk
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující tabulku podle jeho indexu.
3. Inicializujte proměnnou pro objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/), a nastavte ji na `None`.
4. Procházejte všechny objekty [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/) dokud nenajdete tabulku.

   Pokud máte podezření, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše zkontrolovat všechny tvary, které obsahuje. Když je tvar identifikován jako tabulka, můžete jej použít jako objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/). Pokud však snímek obsahuje několik tabulek, je lepší hledat požadovanou tabulku pomocí jejího [getAlternativeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getAlternativeText).

5. Použijte objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) abyste s tabulkou pracovali. V níže uvedeném příkladu aktualizujeme text v první sloupci druhé řady.
6. Uložte upravenou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Vytvoří instanci třídy Presentation, která představuje soubor PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Přistupuje k prvnímu snímku
    slide = presentation.getSlides().get_Item(0)

    # Inicializuje referenci na tabulku.
    table = None

    # Prochází tvary a nastaví referenci na nalezenou tabulku
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Nastaví text pro první sloupec druhé řady
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Uloží upravenou prezentaci na disk
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nalezení buňky, která vlastní TextFrame**

Když obecný kód pro zpracování textu získá [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) z tabulky, použijte metodu [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParentCell), abyste získali vlastnící [Cell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cell/). Pro textový rámec v buňce tabulky metoda [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParentCell) vrací vlastníka a [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParentShape) vrací `None`, i když tabulka samotná je tvar.

Souřadnice buňky jsou dostupné přes pouze pro čtení metody [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cell/#getFirstColumnIndex) a [Cell.getFirstRowIndex](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#getParentCell) také poskytuje pouze pro čtení navigaci: vrací vlastníka, ale nemění vlastnictví. Vždy před použitím zkontrolujte, zda vrácená buňka není `None`.

Pro kompletní příklad, který identifikuje vlastníky buňky tabulky a tvarů, včetně tvarů spjatých s uzly SmartArt, viz [Search and Replace Text](/slides/cs/python-java/search-and-replace-text/).

## **Zarovnání textu v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) do snímku.
4. Získejte objekt [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) z tabulky.
5. Přistupte k [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) objektu [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/).
6. Zarovnejte text svisle.
7. Uložte upravenou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Vytvoří instanci třídy Presentation
presentation = Presentation()
try:

    # Získá první snímek
    slide = presentation.getSlides().get_Item(0)

    # Definuje sloupce s šířkami a řádky s výškami
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Přidá tvar tabulky do snímku
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Přistupuje k textovému rámci
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Přistupuje k prvnímu odstavci v textovém rámci.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Přistupuje k první části v odstavci.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Zarovnává text vertikálně
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Uloží prezentaci na disk
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přistupte k objektu [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) ze snímku.
4. Nastavte výšku písma textu pomocí [setFontHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Nastavte zarovnání a pravý okraj pomocí [setAlignment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setAlignment) a [setMarginRight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Nastavte vertikální typ textu pomocí [setTextVerticalType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Uložte upravenou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Vytvoří instanci třídy Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Předpokládejme, že první tvar na prvním snímku je tabulka
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Nastaví výšku písma buněk tabulky
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Nastaví zarovnání textu buněk tabulky a pravý okraj v jednom volání
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Nastaví vertikální typ textu buněk tabulky
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Získání vlastností stylu tabulky**

Aspose.Slides vám umožňuje načíst vlastnosti stylu tabulky, abyste je mohli použít u jiné tabulky nebo jinde. Tento Python kód vám ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # změní výchozí přednastavený styl motivu

    # Získá přednastavený styl tabulky
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Použije získaný přednastavený styl na jinou tabulku
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Uzamčení poměru stran tabulky**

Poměr stran geometrického tvaru je poměr jeho rozměrů v různých dimenzích. Aspose.Slides poskytuje metodu [setAspectRatioLocked](https://reference.aspose.com/slides/cs/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked), která umožňuje uzamknout nastavení poměru stran pro tabulky a jiné tvary.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # invertovat
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku i text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [setRightToLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/#setRightToLeft), a odstavce mají [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setRightToLeft). Použití obou zajišťuje správné RTL pořadí a vykreslování uvnitř buněk.

**Jak mohu zabránit uživatelům v přesouvání nebo změně velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/python-java/applying-protection-to-presentation/), abyste zakázali přesouvání, změnu velikosti, výběr apod. Tyto zámky platí také pro tabulky.

**Je podporováno vkládání obrázku do buňky jako pozadí?**

Ano. Pro buňku můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/), obrázek pak pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždice).