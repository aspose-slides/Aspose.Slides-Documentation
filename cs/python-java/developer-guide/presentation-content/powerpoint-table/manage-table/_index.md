---
title: Spravujte tabulky prezentací v Pythonu
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/python-java/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnání textu
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v snímcích PowerPointu s Aspose.Slides pro Python přes Java. Objevte jednoduché ukázky kódu pro zefektivnění vašich pracovních postupů s tabulkami."
---
## **Úvod**

Tabulky v PowerPointu organizují informace do řádků a sloupců, což usnadňuje čtení a porovnávání hodnot.

Aspose.Slides poskytuje třídy [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) a [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) a další typy, které umožňují vytvářet, aktualizovat a spravovat tabulky v prezentacích.

## **Vytvoření tabulky od nuly**

Vytvořte tabulku zadáním její pozice, šířek sloupců a výšek řádků. Po přidání do snímku můžete formátovat okraje buněk, slučovat buňky a vkládat text.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte seznam šířek sloupců v bodech.
4. Definujte seznam výšek řádků v bodech.
5. Přidejte objekt [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) do snímku pomocí metody [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Procházejte každou [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) a aplikujte formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky v první řadě tabulky.
8. Získejte přístup k sloučené buňce přes její metodu [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Nastavte text ve sloučené buňce.
10. Uložte upravenou prezentaci.

Níže uvedený příklad vytvoří tabulku se třemi sloupci a pěti řádky na souřadnicích (100, 50) bodů. Aplikuje červené okraje šířky 5 bodů, sloučí první dvě buňky v první řadě a uloží výsledek jako `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce jsou indexy buněk založeny na nule a používají pořadí (sloupec, řádek). První buňka má index (0, 0).

Například buňky v tabulce se 4 sloupci a 4 řádky jsou očíslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento příklad vytvoří výše ilustrovanou 4 × 4 tabulku se šířkami sloupců a výškami řádků 70 bodů a červenými okraji buněk šířky 5 bodů. Souřadnice ilustrují indexy buněk; příklad nechá buňky prázdné a uloží tabulku jako `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup k existující tabulce**

Tabulky jsou uloženy ve sbírce tvarů snímku. Procházejte tvary, abyste našli tabulku, a potom použijte třídu [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) k načtení nebo aktualizaci jejích buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující tabulku podle jeho indexu.
3. Procházejte objekty [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) a zastavte se, když je nalezena tabulka. Pokud snímek obsahuje několik tabulek, použijte [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) k identifikaci té, kterou potřebujete.
4. Aktualizujte text v cílové buňce.
5. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `UpdateExistingTable.pptx` a najde první tabulku na prvním snímku. Nastaví buňku ve sloupci 0, řádku 1 na `New` a uloží výsledek jako `table1_out.pptx`. Vstup musí obsahovat alespoň jeden snímek a první tabulka na tomto snímku musí mít alespoň jeden sloupec a dva řádky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Chcete‑li změnit výšku řádku v existující tabulce a pochopit, proč může skutečná výška překročit požadovaný minimální limit, viz [Ovládání výšky řádku](/slides/cs/python-java/manage-rows-and-columns/#control-row-height).

## **Najít buňku, která vlastní textový rámec**

Když obecný kód pro zpracování textu získá [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) z tabulky, použijte metodu [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) k získání vlastnící [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/). Pro textový rámec v buňce tabulky [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) vrací vlastníka a [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) vrací `None`, i když samotná tabulka je tvar.

Souřadnice buňky jsou dostupné prostřednictvím jen pro čtení metod [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) a [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) také poskytuje jen pro čtení navigaci: vrací vlastníka, ale nemění vlastnictví. Vždy před použitím zkontrolujte, zda vrácená buňka není `None`.

Kompletní příklad, který identifikuje vlastníky buňky tabulky a tvaru, včetně tvarů spojených s uzly SmartArt, najdete v [Vyhledávání a nahrazování textu](/slides/cs/python-java/search-and-replace-text/).

## **Zarovnání textu v tabulce**

Můžete řídit vertikální ukotvení a směr textu jednotlivých buněk tabulky. Příklad v této sekci vycentruje text v první buňce a otočí jej o 270 stupňů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) do snímku.
4. Získejte přístup k objektu [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) z tabulky.
5. Získejte přístup k prvnímu [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) a nastavte jeho text a barvu.
6. Nastavte vertikální ukotvení buňky a směr textu pomocí [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) a [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 4 × 4 se šířkami sloupců 120 bodů a výškami řádků 100 bodů. Naformátuje text v buňce (0, 0), přidá hodnoty do zbývajících buněk v první řadě a uloží výsledek jako `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení formátování textu na úrovni tabulky**

Použijte [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat), abyste aplikovali formátování textu na všechny buňky v tabulce. Jeho přetížení přijímají formátování částí, odstavců a textového rámce, takže můžete nastavit tyto vlastnosti bez iterace přes jednotlivé buňky.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte přístup k objektu [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ze snímku.
4. Nastavte velikost písma pomocí [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) pro text.
5. Nastavte zarovnání odstavce a pravý okraj pomocí [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) a [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Nastavte směr textu pomocí [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `table.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Nastaví velikost písma na 25 bodů, zarovná odstavce vpravo s pravým okrajem 20 bodů a nastaví text vertikálně. Formátovaná prezentace je uložena jako `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Získání vlastností stylu tabulky**

Použijte [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset), abyste načetli předdefinovaný styl tabulky, a [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset), abyste jej přiřadili. Tento příklad aplikuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) na jednu tabulku, vytiskne hodnotu předvolby a přiřadí stejnou předvolbu druhé tabulce. Obě tabulky jsou uloženy v `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Uzamčení poměru stran tabulky**

Poměr stran tabulky je poměr její šířky k výšce. Použijte [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked), abyste tento poměr pro tabulku uzamkli.

Níže uvedený příklad otevře `pres.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Vytiskne aktuální stav zámku, povolí uzamčení poměru stran, vytiskne aktualizovaný stav (`True`) a uloží výsledek jako `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft), a odstavce mají [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Použití obou zajišťuje správné pořadí RTL a vykreslování uvnitř buněk.

**Jak mohu zabránit uživatelům v přesouvání nebo změně velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/python-java/applying-protection-to-presentation/), abyste zakázali přesouvání, změnu velikosti, výběr atd. Tyto zámky se vztahují i na tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Pro buňku můžete nastavit [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/); obrázek pak pokryje oblast buňky podle zvoleného režimu (roztáhnout nebo opakovat).