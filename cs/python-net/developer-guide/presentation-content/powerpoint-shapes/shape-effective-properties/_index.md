---
title: Získání efektivních vlastností tvaru z prezentací v Pythonu
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/python-net/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelný systém
- zkosený tvar
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Python prostřednictvím .NET vypočítává a aplikuje efektivní vlastnosti tvaru pro přesné vykreslení v PowerPointu."
---
## **Přehled**

Toto téma vysvětluje rozdíl mezi **lokálními** a **efektivními** vlastnostmi. Lokální hodnoty jsou hodnoty, které jsou nastaveny přímo na konkrétní úrovni formátování, například:

1. Vlastnosti úseku na snímku.  
1. Textové styly prototypového tvaru na rozvržení nebo hlavním snímku, pokud má tvar textového rámečku úseku.  
1. Globální nastavení textu v prezentaci.

Lokální hodnoty mohou být definovány nebo vynechány na jakékoli úrovni. Když Aspose.Slides potřebuje konečné formátování „jako vykreslené“, rozřeší řetězec dědičnosti a vrátí **efektivní** hodnoty. Můžete je získat voláním metody `get_effective` na objektu lokálního formátu.

Následující příklad ukazuje, jak získat efektivní hodnoty. Předpokládá se, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) s textovým rámečkem a alespoň jedním úsekem.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Efektivní formátovací data představují aktuální vypočtené formátování po aplikaci dědičnosti. V současné implementaci mohou být některé objekty efektivních dat, jako například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iportionformateffectivedata/), uloženy v interní cache. Opětovné volání `get_effective` po změně nadřazeného nebo zděděného formátování může cache obnovit a dříve získaný objekt již nemusí představovat předchozí stav. Pokud potřebujete zachovat efektivní hodnoty pro pozdější opětovné použití, zkopírujte požadované vlastnosti, jako je výška písma, barva výplně, styl písma nebo zarovnání, do svého vlastního datového objektu.
{{% /alert %}}

## **Získání efektivních vlastností kamery**

Aspose.Slides vám umožňuje získat efektivní vlastnosti kamery. Typ [ICameraEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/icameraeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti kamery. Instance [ICameraEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/icameraeffectivedata/) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformateffectivedata/), který poskytuje efektivní hodnoty pro [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti kamery. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Získání efektivních vlastností světelného systému**

Aspose.Slides vám umožňuje získat efektivní vlastnosti světelného systému. Typ [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ilightrigeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti světelného systému. Instance [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ilightrigeffectivedata/) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformateffectivedata/), který poskytuje efektivní hodnoty pro [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti světelného systému. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Získání efektivních vlastností zkosení tvaru**

Aspose.Slides vám umožňuje získat efektivní vlastnosti zkosení tvaru. Typ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishapebeveleffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti reliéfu plochy pro tvar. Instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishapebeveleffectivedata/) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ithreedformateffectivedata/), který poskytuje efektivní hodnoty pro [ThreeDFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/threedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti pro horní zkosení tvaru. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Získání efektivních vlastností textového rámce**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového rámce. Typ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/itextframeformateffectivedata/) obsahuje vlastnosti formátování textového rámce.

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti formátování textového rámce. Předpokládá se, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) s textovým rámcem.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Získání efektivních vlastností textového stylu**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového stylu. Typ [ITextStyleEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/itextstyleeffectivedata/) obsahuje efektivní vlastnosti textového stylu.

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti textového stylu. Předpokládá se, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) s textovým rámcem.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Získání efektivní výšky písma**

Pomocí Aspose.Slides můžete získat efektivní výšku písma. Následující kód ukazuje, jak se efektivní výška písma úseku mění po nastavení lokálních hodnot výšky písma na různých úrovních struktury prezentace.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání efektivního formátu výplně tabulky**

Pomocí Aspose.Slides můžete získat efektivní formátování výplně pro různé části tabulky. Typ [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ifillformateffectivedata/) obsahuje vlastnosti efektivního formátování výplně. Formátování buňky má vyšší prioritu než formátování řádku, formátování řádku má vyšší prioritu než formátování sloupce a formátování sloupce má vyšší prioritu než formátování celé tabulky.

V důsledku toho se k vykreslení buňky tabulky používají vlastnosti [ICellFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/icellformateffectivedata/). Následující ukázka kódu ukazuje, jak získat efektivní formátování výplně pro různé části tabulky. Předpokládá se, že první tvar na prvním snímku je [Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **Často kladené otázky**

**Vrací `get_effective` snímek?**

Ne vždy. Efektivní data představují vypočtené formátování po aplikaci dědičnosti, ale některé objekty efektivních dat mohou být uloženy v interní cache. Následující volání `get_effective` může formátování přepočítat a obnovit cache, takže dříve získaný objekt by neměl být považován za trvalý snímek.

**Kdy bych měl znovu načíst efektivní vlastnosti?**

Opětovně zavolejte `get_effective` po změně lokálního formátování, nadřazených stylů, formátování rozvržení, formátování hlavního snímku nebo výchozích nastavení na úrovni prezentace. Další volání přehodnotí hierarchii formátování a vrátí aktuální efektivní výsledek.

**Mění nebo odstranění rozvržení/hlavního snímku efektivní vlastnosti, které už byly získány?**

Ano, ale změna se projeví při dalším volání `get_effective`. Pokud se změní nebo odstraní nadřazený zdroj formátování, dříve získaná efektivní data mohou být zastaralá. Po opětovném volání `get_effective` Aspose.Slides přehodnotí strom formátování a výsledná písma, barvy, velikosti nebo jiné hodnoty se mohou změnit.

**Mohu měnit hodnoty přes objekty efektivních dat?**

Ne. Objektům efektivních dat jsou exposovány vypočtené hodnoty. Proveďte změny v lokálních objektech formátování a poté znovu získáte efektivní hodnoty.

**Co se stane, pokud vlastnost není nastavena na úrovni tvaru, ani v rozvržení/hlavním snímku, ani v globálních nastaveních?**

Efektivní hodnota je určena výchozím mechanismem, který zahrnuje výchozí nastavení PowerPointu i Aspose.Slides. Tato rozpoznaná hodnota se stane součástí aktuálních efektivních dat.

**Z efektivní hodnoty písma, mohu zjistit, která úroveň poskytla velikost nebo řez písma?**

Ne přímo. Efektivní data vrací finální hodnotu. Pro zjištění zdroje zkontrolujte lokální hodnoty na úrovni úseku, odstavce, textového rámce a textových stylů na úrovních rozvržení, hlavního snímku a prezentace, abyste viděli, kde se objeví první explicitní definice.

**Proč efektivní hodnoty někdy vypadají identicky jako lokální?**

Protože lokální hodnota se ukázala být konečná (nedošlo k potřebě vyšší úrovně dědičnosti). V takových případech se efektivní hodnota shoduje s lokální.

**Kdy mám používat efektivní vlastnosti a kdy pracovat jen s lokálními?**

Používejte efektivní data, když potřebujete výsledek „jako vykreslený“ po aplikaci veškeré dědičnosti, například pro sladění barev, odsazení nebo velikostí. Pokud potřebujete tyto hodnoty zachovat bez ohledu na pozdější změny formátování, zkopírujte požadované vlastnosti do svého vlastního objektu. Pokud potřebujete měnit formátování na konkrétní úrovni, upravte lokální vlastnosti a pak, pokud je potřeba, znovu načtěte efektivní data pro ověření výsledku.