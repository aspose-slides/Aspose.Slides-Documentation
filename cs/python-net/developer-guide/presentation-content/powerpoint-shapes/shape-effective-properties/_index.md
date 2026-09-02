---
title: Získání efektivních vlastností tvaru z prezentací v Pythonu
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/python-net/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelné zařízení
- tvar s zkosením
- textový rámec
- styl textu
- výška písma
- formát výplně
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se používat Aspose.Slides pro Python prostřednictvím .NET k rozlišení místního, zděděného a efektivního formátování tvarů v PowerPoint prezentacích."
---
## **Pochopte místní, zděděné a efektivní vlastnosti**

Formátování PowerPointu může pocházet z několika míst. Hodnota uložená přímo na objektu je jeho **místní hodnota**. Pokud tato hodnota není nastavena, PowerPoint se podívá na nadřazené zdroje formátování, jako je výchozí nastavení odstavce, textový styl, rozvržení nebo hlavní snímek, motiv nebo výchozí nastavení na úrovni prezentace. Tyto hodnoty jsou **zděděné hodnoty**. Hodnota, která zůstane po vyřešení celé hierarchie, je **efektivní hodnota**, která se používá k vykreslení objektu.

Například textová část nemusí definovat vlastní výšku písma. Její místní [font_height](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ibaseportionformat/font_height/) je pak `float("nan")`, což znamená „není zde nastaveno“. Část může zdědit výšku ze svého odstavce, výchozího textového stylu prezentace nebo jiného příslušného zdroje. Volání [get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iportionformat/get_effective/) na formát části vrátí finální vypočtenou výšku.

Použijte oba typy formátovacích dat pro různé účely:

- Přečtěte nebo změňte místní formátovací objekt, například [IPortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iportionformat/), pokud potřebujete ovládat, kde je hodnota definována.
- Přečtěte objekt efektivních dat, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iportionformateffectivedata/), pokud potřebujete finální vykreslený výsledek. Efektivní data jsou pouze pro čtení.

## **Porovnejte místní, zděděné a efektivní hodnoty**

Následující kompletní příklad vytvoří tvar a použije výšky písma na úrovních prezentace, odstavce a části. Každý krok vypíše hodnoty definované na těchto úrovních a výslednou efektivní hodnotu pro stejnou textovou část. Také ukazuje, proč je nutné po změnách formátování znovu načíst efektivní data.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Načtěte efektivní data po předchozích změnách.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Definujte zděděné hodnoty na dvou různých úrovních.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Místní hodnota v části přepíše obě zděděné hodnoty.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Změna zděděné hodnoty nepřepíše existující místní hodnotu.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Vymažte místní hodnotu. Část nyní opět dědí od odstavce.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Vymažte hodnotu odstavce. Výchozí nastavení prezentace nyní poskytuje výsledek.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Priorita v tomto příkladu je místní formátování části, poté formátování odstavce a nakonec výchozí nastavení prezentace. Ostatní objekty mohou mít jiné řetězce dědičnosti, ale princip je stejný: specifikovanější explicitní hodnota vyhrává a [get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iportionformat/get_effective/) vrací finální výsledek.

## **Získejte efektivní textové vlastnosti**

Formátování textu je rozděleno do několika objektů:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/itextframeformat/get_effective/) řeší vlastnosti textového rámečku, jako jsou okraje, ukotvení, automatické přizpůsobení a svislý směr textu.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/itextstyle/get_effective/) řeší formátování odstavců pro každou úroveň textového stylu.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iparagraphformat/get_effective/) řeší vlastnosti odstavce, jako jsou zarovnání, odsazení a odrážky.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iportionformat/get_effective/) řeší vlastnosti znaků, jako jsou výška písma, typ písma, barva, tučné a kurzíva.

Pro další příklad musí `text-formatting.pptx` obsahovat alespoň jeden snímek a jednu [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) s neprázdným textovým rámcem. AutoShape může být na libovolné pozici ve sbírce tvarů; kód hledá odpovídající objekt a před použitím jej ověří.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Získejte efektivní 3D vlastnosti**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformat/get_effective/) vrací jeden objekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformateffectivedata/) který seskupuje všechna vyřešená 3D nastavení. Jeho vlastnosti [camera](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) a [bevel_bottom](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) zobrazují odpovídající efektivní data. Čtení těchto souvisejících nastavení společně usnadňuje pochopení finálního 3D vzhledu tvaru.

Pro tento příklad musí `shape-3d.pptx` obsahovat alespoň jeden tvar na svém prvním snímku. Aplikujte na tento tvar 3D kameru, osvětlení nebo nastavení zkosení, pokud chcete, aby výstup obsahoval jiné hodnoty než výchozí.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Získejte efektivní formátování tabulky**

Formátování tabulky může pocházet ze stylu tabulky a z formátů aplikovaných na celou tabulku, sloupec, řádek nebo jednotlivou buňku. V případě konfliktů mezi explicitně definovanými výplněmi je priorita: buňka, řádek, sloupec a pak celá tabulka. Efektivní formát buňky je konečný formát použitý k vykreslení této buňky.

Pro tento příklad musí `table-formatting.pptx` obsahovat alespoň jednu tabulku na svém prvním snímku. Tabulka musí mít alespoň jeden řádek a jeden sloupec. Kód hledá [Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/) místo toho, aby předpokládal, že `shapes[0]` je tabulka.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Pokud potřebujete barvu spíše než jen typ výplně, nejprve zkontrolujte efektivní [fill_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ifillformateffectivedata/fill_type/), a poté přečtěte vlastnost, která se vztahuje k tomuto typu, například [solid_fill_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) pro plnou výplň.

## **Znovu načtěte efektivní data po změnách**

Efektivní data popisují hierarchii formátování v okamžiku, kdy jsou vyřešena. Po změně čehokoli, co může v hierarchii participovat, zavolejte `get_effective` znovu, včetně:

- místního formátování objektu;
- výchozích nastavení odstavce nebo textového rámce;
- stylu tabulky, tabulky, sloupce, řádku nebo formátu buňky;
- formátování rozvržení nebo hlavního snímku;
- dat motivu nebo výchozích nastavení na úrovni prezentace;
- rozložení nebo hlavního snímku přiřazeného ke konkrétnímu snímku.

Nepochovávejte objekt efektivních dat jako trvalý snímek. Aspose.Slides může interně kešit některá efektivní data a pozdější volání `get_effective` může tato data obnovit. Pokud potřebujete porovnat hodnoty před a po změně, zkopírujte skalární hodnoty, které potřebujete, například výšku písma, barvu, zarovnání nebo šířku zkosení, do vlastních proměnných před provedením změny.

Pro změnu hodnoty aktualizujte příslušný místní formátovací objekt a poté zavolejte `get_effective` k ověření výsledku. Objektů efektivních dat jsou samy o sobě pouze pro čtení.

## **Často kladené otázky**

**Jak mohu zjistit, která úroveň poskytla efektivní hodnotu?**

Efektivní data obsahují finální hodnotu, ne její zdroj. Prohlédněte si příslušné místní objekty od nejspecifičtější úrovně směrem ven. Pro text to může zahrnovat část, odstavec, textový rámec, rozvržení, hlavní snímek, motiv a výchozí nastavení prezentace. Nedefinované hodnoty jako `float("nan")` nebo `None` naznačují, že hledání pokračuje na další úroveň.

**Co se stane, když žádná úroveň nedefinuje vlastnost?**

Aspose.Slides vyřeší příslušný výchozí parametr PowerPointu nebo knihovny. Tato vyřešená hodnota se objeví v efektivních datech, i když žádný místní objekt ji explicitně nedefinuje.

**Proč se efektivní hodnota někdy rovná místní hodnotě?**

Místní hodnota vyhrála výpočet dědičnosti. To je očekávané, když je vlastnost explicitně nastavena na objektu a žádné specifičtější pravidlo ji nepřepíše.

**Kdy bych měl použít místní data místo efektivních dat?**

Použijte místní data k inspekci nebo úpravě konkrétní úrovně formátování. Použijte efektivní data, když potřebujete finální vzhled po aplikaci dědičnosti, pravidel motivu a příslušných stylů. [Kompletní příklad porovnání](#compare-local-inherited-and-effective-values) ukazuje oba přístupy ve stejném pracovním postupu.