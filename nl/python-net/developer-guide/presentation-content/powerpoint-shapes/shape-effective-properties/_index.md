---
title: Haal effectieve vormeigenschappen op uit presentaties in Python
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/python-net/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtopstelling
- afgeschuinde vorm
- tekstframe
- tekststijl
- letterhoogte
- vulopmaak
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u Aspose.Slides voor Python via .NET kunt gebruiken om lokale, geërfde en effectieve vormopmaak in PowerPoint-presentaties te onderscheiden."
---
## **Begrijp lokale, geërfde en effectieve eigenschappen**

PowerPoint-opmaak kan uit verschillende bronnen komen. De waarde die rechtstreeks op een object wordt opgeslagen, is de **lokale waarde**. Als die waarde niet is ingesteld, kijkt PowerPoint naar bovenliggende opmaakbronnen, zoals een alinea‑standaard, een tekst‑style, een indeling‑ of masterslide, een thema of de standaardinstellingen van de presentatie. Deze waarden zijn **geërfde waarden**. De waarde die overblijft nadat de volledige hiërarchie is verwerkt, is de **effectieve waarde**, die wordt gebruikt om het object weer te geven.

Bijvoorbeeld, een tekstgedeelte definieert mogelijk niet zijn eigen letterhoogte. De lokale [font_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ibaseportionformat/font_height/) is dan `float("nan")`, wat betekent “hier niet ingesteld”. Het gedeelte kan een hoogte erven van de alinea, de standaard‑tekst‑style van de presentatie, of een andere toepasselijke bron. Het aanroepen van [get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iportionformat/get_effective/) op het opmaakobject van het gedeelte retourneert de uiteindelijk berekende hoogte.

Gebruik de twee soorten opmaakgegevens voor verschillende doeleinden:

- Lees of wijzig een lokaal opmaakobject, zoals [IPortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iportionformat/), wanneer u moet bepalen waar een waarde wordt gedefinieerd.
- Lees een effectief gegevensobject, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iportionformateffectivedata/), wanneer u het uiteindelijke, gerenderde resultaat nodig hebt. Effectieve gegevens zijn alleen‑lezen.

## **Vergelijk lokale, geërfde en effectieve waarden**

Het volgende volledige voorbeeld maakt een vorm aan en past letterhoogtes toe op presentatieniveau, alinea‑niveau en gedeelte‑niveau. Elke stap drukt de waarden af die op die niveaus zijn gedefinieerd en de resulterende effectieve waarde voor hetzelfde tekstgedeelte. Het laat ook zien waarom effectieve gegevens opnieuw moeten worden gelezen na opmaakwijzigingen.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Lees effectieve gegevens na de voorgaande wijzigingen.
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

    # Definieer geërfde waarden op twee verschillende niveaus.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Een lokale waarde op het gedeelte overschrijft beide geërfde waarden.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Het wijzigen van een geërfde waarde overschrijft geen bestaande lokale waarde.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Wis de lokale waarde. Het gedeelte erft nu weer van de alinea.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Wis de alinea‑waarde. De standaard van de presentatie levert nu het resultaat.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

De prioriteit in dit voorbeeld is eerst de lokale opmaak van het gedeelte, daarna de alinea‑opmaak, en vervolgens de standaard van de presentatie. Andere objecten kunnen verschillende ervaringsketens hebben, maar het principe is hetzelfde: een specifiekere expliciete waarde heeft voorrang, en [get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iportionformat/get_effective/) retourneert het eindresultaat.

## **Haal effectieve tekst‑eigenschappen op**

Tekstopmaak is verdeeld over verschillende objecten:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/itextframeformat/get_effective/) lost tekst‑frame‑eigenschappen op zoals marges, verankering, autofit en verticale tekstrichting.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/itextstyle/get_effective/) lost alinea‑opmaak op voor elk tekst‑style‑niveau.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iparagraphformat/get_effective/) lost alinea‑eigenschappen op, zoals uitlijning, inspringing en opsommingstekens.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iportionformat/get_effective/) lost teken‑eigenschappen op, zoals letterhoogte, lettertype, kleur, vet en cursief.

Voor het volgende voorbeeld moet `text-formatting.pptx` ten minste één dia en één [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) bevatten met een niet‑lege tekstframe. De AutoShape kan zich op elke positie in de vormverzameling bevinden; de code zoekt naar een geschikt object en valideert het voordat het wordt gebruikt.

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

## **Haal effectieve 3D‑eigenschappen op**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformat/get_effective/) retourneert één [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformateffectivedata/) object dat alle berekende 3D‑instellingen groepeert. De eigenschappen [camera](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/), en [bevel_bottom](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) geven de overeenkomstige effectieve gegevens weer. Het samen lezen van deze verwante instellingen maakt het makkelijker te begrijpen hoe de uiteindelijke 3D‑weergave van een vorm eruitziet.

Voor dit voorbeeld moet `shape-3d.pptx` op de eerste dia ten minste één vorm bevatten. Pas een 3D‑camera, belichting of afschuining toe op die vorm als u wilt dat de uitvoer andere waarden dan de standaardinstellingen bevat.

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

## **Haal effectieve tabel‑opmaak op**

Tabel‑opmaak kan afkomstig zijn van de tabelstyle en van opmaak die op de volledige tabel, een kolom, een rij of een individuele cel wordt toegepast. Bij conflicten tussen expliciet gedefinieerde vullingen is de prioriteit cel, rij, kolom en daarna de volledige tabel. De effectieve opmaak van een cel is de uiteindelijke opmaak die wordt gebruikt om die cel te tekenen.

Voor dit voorbeeld moet `table-formatting.pptx` op de eerste dia ten minste één tabel bevatten. De tabel moet minstens één rij en één kolom hebben. De code zoekt naar een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) in plaats van ervan uit te gaan dat `shapes[0]` een tabel is.

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

Als u de kleur nodig hebt in plaats van alleen het vul‑type, controleer dan eerst de effectieve [fill_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ifillformateffectivedata/fill_type/), en lees vervolgens de eigenschap die van toepassing is op dat type, bijvoorbeeld [solid_fill_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) voor een effen vulkleur.

## **Lees effectieve gegevens opnieuw na wijzigingen**

Effectieve gegevens beschrijven de opmaakhiërarchie op het moment dat deze wordt berekend. Roep `get_effective` opnieuw aan nadat u iets hebt gewijzigd dat deel kan uitmaken van die hiërarchie, inclusief:

- de lokale opmaak van het object;
- standaardinstellingen van alinea of tekst‑frame;
- een tabel‑style, tabel, kolom, rij of cel‑opmaak;
- indeling‑ of masterslide‑opmaak;
- themagegevens of standaardinstellingen van de presentatie;
- de indeling of master die aan een dia is toegewezen.

Bewaar een effectief gegevensobject niet als een permanent momentopname. Aspose.Slides kan sommige effectieve gegevens intern cachen, en een latere `get_effective`‑aanroep kan die gegevens vernieuwen. Als u waarden vóór en na een wijziging moet vergelijken, kopieer dan de scalare waarden die u nodig hebt, zoals een letterhoogte, kleur, uitlijning of afschuiningsbreedte, naar uw eigen variabelen voordat u de wijziging doorvoert.

Om een waarde te wijzigen, werkt u het juiste lokale opmaakobject bij en roept u vervolgens `get_effective` aan om het resultaat te verifiëren. Effectieve gegevensobjecten zelf zijn alleen‑lezen.

## **FAQ**

**Hoe kan ik zien welk niveau een effectieve waarde heeft geleverd?**

Effectieve gegevens bevatten de uiteindelijke waarde, niet de bron ervan. Inspecteer de toepasselijke lokale objecten van het meest specifieke niveau naar buiten toe. Voor tekst kan dit het gedeelte, de alinea, het tekst‑frame, de indeling, de master, het thema en de standaardinstellingen van de presentatie omvatten. Niet‑gedefinieerde waarden zoals `float("nan")` of `None` geven aan dat de zoektocht doorgaat naar een ander niveau.

**Wat gebeurt er als geen enkel niveau een eigenschap definieert?**

Aspose.Slides lost de juiste PowerPoint‑ of bibliotheek‑standaard op. Die berekende waarde verschijnt in de effectieve gegevens, ook al definieert geen lokaal object deze expliciet.

**Waarom komt een effectieve waarde soms overeen met de lokale waarde?**

De lokale waarde heeft de erfenisberekening gewonnen. Dit is te verwachten wanneer de eigenschap expliciet op het object is ingesteld en geen specifiekere regel deze overschrijft.

**Wanneer moet ik lokale gegevens gebruiken in plaats van effectieve gegevens?**

Gebruik lokale gegevens om een specifiek opmaakniveau te inspecteren of te bewerken. Gebruik effectieve gegevens wanneer u de uiteindelijke weergave nodig heeft na erfenis, themaregels en toepasselijke stijlen. Het [complete vergelijking voorbeeld](#compare-local-inherited-and-effective-values) laat beide zien in dezelfde workflow.