---
title: Získání efektivních vlastností tvaru z prezentací v Pythonu pomocí Javy
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/python-java/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- light rig
- tvar s zkosením
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak pomocí Aspose.Slides pro Python přes Javu rozlišit místní, zděděné a efektivní formátování tvarů v prezentacích PowerPoint."
---
## **Pochopte místní, zděděné a efektivní vlastnosti**

Formátování v PowerPointu může pocházet z několika míst. Hodnota uložená přímo na objektu je jeho **místní hodnota**. Pokud tato hodnota není nastavena, PowerPoint hledá ve zdrojích formátování nadřazených objektů, jako je výchozí nastavení odstavce, textový styl, rozložení nebo hlavní snímek, motiv nebo výchozí nastavení na úrovni prezentace. Tyto hodnoty jsou **zděděné hodnoty**. Hodnota, která zůstane po vyřešení celé hierarchie, je **efektivní hodnota** – hodnota používaná k vykreslení objektu.

Například část textu nemusí definovat vlastní výšku písma. Její místní [getFontHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#getFontHeight) hodnota je pak `float("nan")`, což znamená „není zde nastavena“. Část může zdědit výšku ze svého odstavce, výchozího textového stylu prezentace nebo jiného relevantního zdroje. Volání [getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#getEffective) na formát části vrací konečnou vyřešenou výšku.

Používejte dva typy formátovacích dat pro různé účely:

- Načtěte nebo změňte místní formátovací objekt, například [PortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/), pokud potřebujete řídit, kde je hodnota definována.
- Načtěte efektivní datový objekt, například `PortionFormatEffectiveData`, pokud potřebujete konečný vykreslený výsledek. Efektivní data jsou pouze pro čtení.

## **Porovnejte místní, zděděné a efektivní hodnoty**

Následující úplný příklad vytvoří tvar a aplikuje výšky písma na úrovni prezentace, odstavce a části. Každý krok vypíše hodnoty definované na těchto úrovních a výslednou efektivní hodnotu pro stejnou část textu. Také ukazuje, proč je třeba po změnách formátování znovu načíst efektivní data.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Načíst efektivní data po předchozích změnách.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Definujte zděděné hodnoty na dvou různých úrovních.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Místní hodnota v části přepisuje obě zděděné hodnoty.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Změna zděděné hodnoty nepřepíše existující místní hodnotu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Vymažte místní hodnotu. Část nyní opět zdědí hodnotu z odstavce.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Vymažte hodnotu odstavce. Výchozí nastavení prezentace nyní poskytuje výsledek.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Priorita v tomto příkladu je místní formátování části, poté formátování odstavce a nakonec výchozí nastavení prezentace. Ostatní objekty mohou mít různé řetězce dědičnosti, ale princip je stejný: konkrétnější explicitní hodnota vítězí a [getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#getEffective) vrací konečný výsledek.

## **Získání efektivních textových vlastností**

Formátování textu je rozděleno mezi několik objektů:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#getEffective) řeší vlastnosti textového rámce, jako jsou okraje, ukotvení, automatické přizpůsobení a svislý směr textu.
- [TextStyle.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textstyle/#getEffective) řeší formátování odstavců pro každou úroveň textového stylu.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#getEffective) řeší vlastnosti odstavce, jako jsou zarovnání, odsazení a odrážky.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#getEffective) řeší vlastnosti znaků, jako jsou výška písma, typ písma, barva, tučný a kurzíva.

Pro následující příklad musí soubor `text-formatting.pptx` obsahovat alespoň jeden snímek a jednu [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) s neprázdným textovým rámcem. AutoShape může být umístěna na libovolném místě ve sbírce tvarů; kód hledá vhodný objekt a před použitím jej ověří.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Získání efektivních 3D vlastností**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getEffective) vrací jeden objekt `ThreeDFormatEffectiveData`, který seskupuje všechna vyřešená 3D nastavení. Jeho metody `getCamera`, `getLightRig`, `getBevelTop` a `getBevelBottom` odhalují odpovídající efektivní data. Čtení těchto souvisejících nastavení najednou usnadňuje pochopení konečného 3D vzhledu tvaru.

Pro tento příklad musí soubor `shape-3d.pptx` obsahovat alespoň jeden tvar na prvním snímku. Pokud chcete, aby výstup obsahoval jiné hodnoty než výchozí, aplikujte na tento tvar 3D kameru, osvětlení nebo nastavení kvůlení.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Získání efektivního formátování tabulky**

Formátování tabulky může pocházet ze stylu tabulky i z formátů aplikovaných na celou tabulku, sloupec, řádek nebo jednotlivou buňku. V případě konfliktů mezi explicitně definovanými výplněmi je priorita následující: buňka, řádek, sloupec a pak celá tabulka. Efektivní formát buňky je konečný formát používaný k vykreslení této buňky.

Pro tento příklad musí soubor `table-formatting.pptx` obsahovat alespoň jednu tabulku na prvním snímku. Tabulka musí mít alespoň jeden řádek a jeden sloupec. Kód hledá [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) místo toho, aby předpokládal, že `getShapes().get_Item(0)` je tabulka.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Pokud potřebujete barvu místo pouze typu výplně, nejprve zkontrolujte efektivní `getFillType` a potom si přečtěte metodu, která se na tento typ vztahuje – například `getSolidFillColor` pro plnou výplň.

## **Znovu načíst efektivní data po změnách**

Efektivní data popisují hierarchii formátování v okamžiku, kdy jsou vyřešena. Po změně čehokoliv, co může v hierarchii participovat, zavolejte [getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#getEffective) znovu, včetně:

- místního formátování objektu;
- výchozích nastavení odstavce nebo textového rámce;
- stylu tabulky, tabulky, sloupce, řádku nebo formátu buňky;
- formátování rozložení nebo hlavního snímku;
- dat motivu nebo výchozích nastavení na úrovni prezentace;
- rozložení nebo hlavního snímku přiřazeného ke snímku.

Neukládejte objekt efektivních dat jako trvalý snímek. Aspose.Slides může interně kešovat některá efektivní data a pozdější volání [getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#getEffective) může tato data obnovit. Pokud potřebujete porovnat hodnoty před a po změně, zkopírujte potřebné skalární hodnoty – například výšku písma, barvu, zarovnání nebo šířku kvůlení – do vlastních proměnných před provedením změny.

Pro změnu hodnoty aktualizujte příslušný místní formátovací objekt a poté zavolejte [getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#getEffective) k ověření výsledku. Objektů efektivních dat jsou samy o sobě pouze pro čtení.

## **Často kladené otázky**

**Jak mohu zjistit, která úroveň poskytla efektivní hodnotu?**

Efektivní data obsahují konečnou hodnotu, nikoli její zdroj. Prohlédněte si příslušné místní objekty od nejspecifičtější úrovně směrem ven. Pro text to může zahrnovat část, odstavec, textový rámec, rozložení, hlavní snímek, motiv a výchozí nastavení prezentace. Nedefinované hodnoty jako `float("nan")` nebo `None` naznačují, že hledání pokračuje na další úroveň.

**Co se stane, když žádná úroveň nenastaví vlastnost?**

Aspose.Slides vyřeší odpovídající výchozí hodnotu PowerPointu nebo knihovny. Tato vyřešená hodnota se objeví v efektivních datech, i když žádný místní objekt ji explicitně nedefinuje.

**Proč se efektivní hodnota někdy rovná místní hodnotě?**

Místní hodnota zvítězila v výpočtu dědičnosti. To je očekávané, když je vlastnost explicitně nastavena na objektu a žádné konkrétnější pravidlo ji nepřepíše.

**Kdy bych měl použít místní data místo efektivních dat?**

Používejte místní data k prohlédnutí nebo úpravě konkrétní úrovně formátování. Používejte efektivní data, když potřebujete konečný vzhled po aplikaci dědičnosti, pravidel motivu a relevantních stylů. [Kompletní příklad porovnání](#compare-local-inherited-and-effective-values) ukazuje obojí ve stejném pracovním postupu.