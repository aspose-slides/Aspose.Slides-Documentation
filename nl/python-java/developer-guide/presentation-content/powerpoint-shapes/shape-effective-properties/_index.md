---
title: Effectieve vormeigenschappen ophalen uit presentaties in Python via Java
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/python-java/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtrig
- afgeschuinde vorm
- tekstkader
- tekststijl
- letterhoogte
- vulformaat
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u Aspose.Slides voor Python via Java kunt gebruiken om lokale, geërfde en effectieve vormopmaak in PowerPoint‑presentaties te onderscheiden."
---
## **Begrijp lokale, geërfde en effectieve eigenschappen**

PowerPoint-opmaak kan uit verschillende bronnen komen. De waarde die rechtstreeks op een object is opgeslagen, is de **lokale waarde**. Als die waarde niet is ingesteld, kijkt PowerPoint naar opmaakbronnen van bovenliggende objecten, zoals een standaardparagraaf, een tekststijl, een lay-out‑ of meesterslide, een thema of standaardinstellingen op presentatieniveau. Die waarden zijn **geërfde waarden**. De waarde die overblijft nadat de volledige hiërarchie is afgehandeld, is de **effectieve waarde** — de waarde die wordt gebruikt om het object weer te geven.

Bijvoorbeeld, een tekstgedeelte kan zijn eigen letterhoogte niet definiëren. De lokale [getFontHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#getFontHeight)‑waarde is dan `float("nan")`, wat betekent “hier niet ingesteld”. Het gedeelte kan een hoogte erven van de paragraaf, de standaard‑tekststijl van de presentatie, of een andere toepasselijke bron. Het aanroepen van [getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#getEffective) op het gedeelte‑formaat geeft de uiteindelijk opgeloste hoogte terug.

Gebruik de twee soorten opmaakgegevens voor verschillende doeleinden:

- Lees of wijzig een lokaal opmaakobject, zoals [PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/), wanneer je moet bepalen waar een waarde gedefinieerd is.
- Lees een effectief gegevensobject, zoals `PortionFormatEffectiveData`, wanneer je het uiteindelijke, gerenderde resultaat nodig hebt. Effectieve gegevens zijn alleen‑lezen.

## **Vergelijk lokale, geërfde en effectieve waarden**

Het volgende volledige voorbeeld maakt een vorm aan en past letterhoogtes toe op presentatieniveau, paragraafniveau en gedeelteniveau. Elke stap print de op die niveaus gedefinieerde waarden en de resulterende effectieve waarde voor hetzelfde tekstgedeelte. Het laat ook zien waarom effectieve gegevens opnieuw moeten worden gelezen na formatwijzigingen.

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

    # Lees effectieve gegevens na de voorgaande wijzigingen.
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

    # Definieer geërfde waarden op twee verschillende niveaus.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Een lokale waarde op het gedeelte overschrijft beide geërfde waarden.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Het wijzigen van een geërfde waarde overschrijft een bestaande lokale waarde niet.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Wis de lokale waarde. Het gedeelte erft nu opnieuw van de paragraaf.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Wis de paragraafwaarde. De standaard van de presentatie levert nu het resultaat.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De prioriteit in dit voorbeeld is eerst lokale opmaak van het gedeelte, daarna paragraaf‑opmaak, daarna de presentatie‑standaard. Andere objecten kunnen verschillende overervingsketens hebben, maar het principe is hetzelfde: een meer specifieke expliciete waarde wint, en [getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#getEffective) geeft het eindresultaat terug.

## **Effectieve teksteigenschappen ophalen**

Tekstopmaak is verdeeld over verschillende objecten:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#getEffective) lost eigenschappen van het tekstframe op, zoals marges, verankering, autofit en verticale tekstrichting.
- [TextStyle.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textstyle/#getEffective) lost paragraafopmaak op voor elk niveau van de tekststijl.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#getEffective) lost paragraafeigenschappen op, zoals uitlijning, inspringen en opsommingstekens.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#getEffective) lost teken‑eigenschappen op, zoals letterhoogte, lettertype, kleur, vet en cursief.

Voor het volgende voorbeeld moet `text-formatting.pptx` minstens één slide en één [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) met een niet‑leeg tekstframe bevatten. De AutoShape kan zich op elke positie in de vormcollectie bevinden; de code zoekt naar een geschikt object en valideert het vóór gebruik.

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

## **Effectieve 3D‑eigenschappen ophalen**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getEffective) retourneert één `ThreeDFormatEffectiveData`‑object dat alle opgeloste 3D‑instellingen groepeert. De methoden `getCamera`, `getLightRig`, `getBevelTop` en `getBevelBottom` geven de corresponderende effectieve gegevens terug. Deze gerelateerde instellingen samen lezen maakt het makkelijker om het uiteindelijke 3D‑uiterlijk van een vorm te begrijpen.

Voor dit voorbeeld moet `shape-3d.pptx` minstens één vorm op de eerste slide bevatten. Pas 3D‑camera‑, verlichtings‑ of afschuining‑instellingen toe op die vorm als je wilt dat de uitvoer waarden bevat die afwijken van de standaardinstellingen.

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

## **Effectieve tabelopmaak ophalen**

Tabelopmaak kan afkomstig zijn van de tabelstijl en van opmaak die op de hele tabel, een kolom, een rij of een afzonderlijke cel wordt toegepast. Bij conflicten tussen expliciet gedefinieerde vullingen heeft de volgorde prioriteit: cel, rij, kolom, en daarna de volledige tabel. De effectieve opmaak van een cel is de uiteindelijke opmaak die wordt gebruikt om die cel te tekenen.

Voor dit voorbeeld moet `table-formatting.pptx` minstens één tabel op de eerste slide bevatten. De tabel moet minstens één rij en één kolom hebben. De code zoekt naar een [Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) in plaats van ervan uit te gaan dat `getShapes().get_Item(0)` een tabel is.

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

Als je de kleur nodig hebt in plaats van alleen het vultype, controleer dan eerst de effectieve `getFillType`, en lees daarna de methode die bij dat type hoort — bijvoorbeeld `getSolidFillColor` voor een effen vulling.

## **Effectieve gegevens opnieuw lezen na wijzigingen**

Effectieve gegevens beschrijven de opmaakhiërarchie op het moment dat deze wordt opgelost. Roep [getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#getEffective) opnieuw aan nadat je iets hebt gewijzigd dat aan die hiërarchie kan deelnemen, inclusief:

- de lokale opmaak van het object;
- standaardinstellingen voor paragrafen of tekstframes;
- een tabelstijl, tabel, kolom, rij of celopmaak;
- lay‑out‑ of meesterslide‑opmaak;
- themagegevens of standaardinstellingen op presentatieniveau;
- de lay‑out of master die aan een slide is toegewezen.

Bewaar geen effectief gegevensobject als een permanente snapshot. Aspose.Slides kan sommige effectieve gegevens intern cachen, en een latere [getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#getEffective)‑aanroep kan die gegevens vernieuwen. Als je waarden vóór en na een wijziging moet vergelijken, kopieer dan de scalare waarden die je nodig hebt — zoals een letterhoogte, kleur, uitlijning of afschuiningbreedte—naar eigen variabelen voordat je de wijziging doorvoert.

Om een waarde te wijzigen, werk je het juiste lokale opmaakobject bij en roep je daarna [getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#getEffective) aan om het resultaat te verifiëren. Effectieve gegevensobjecten zelf zijn alleen‑lezen.

## **FAQ**

**Hoe kan ik bepalen welk niveau een effectieve waarde leverde?**

Effectieve gegevens bevatten de uiteindelijke waarde, niet de bron. Inspecteer de toepasselijke lokale objecten, beginnend bij het meest specifieke niveau en werk naar buiten toe. Voor tekst kan dit het gedeelte, de paragraaf, het tekstframe, de lay‑out, de master, het thema en de presentatiestandaarden omvatten. Niet‑gedefinieerde waarden zoals `float("nan")` of `None` geven aan dat de zoektocht naar een hoger niveau doorgaat.

**Wat gebeurt er als geen enkel niveau een eigenschap definieert?**

Aspose.Slides lost de juiste PowerPoint‑ of bibliotheekstandaard op. Die opgeloste waarde verschijnt in de effectieve gegevens, zelfs al wordt hij niet expliciet door een lokaal object gedefinieerd.

**Waarom komt een effectieve waarde soms overeen met de lokale waarde?**

De lokale waarde heeft de overervingsberekening gewonnen. Dit is te verwachten wanneer de eigenschap expliciet op het object is ingesteld en er geen specifiekere regel is die deze overschrijft.

**Wanneer moet ik lokale gegevens gebruiken in plaats van effectieve gegevens?**

Gebruik lokale gegevens om een specifiek opmaakniveau te inspecteren of te bewerken. Gebruik effectieve gegevens wanneer je de uiteindelijke weergave nodig hebt na overerving, themaregels en toepasselijke stijlen. Het [volledige vergelijkingsexemplaar](#compare-local-inherited-and-effective-values) toont beide in dezelfde workflow.