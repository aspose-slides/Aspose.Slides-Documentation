---
title: Beheer presentatievormen in Python
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/python-net/shape-manipulations/
keywords:
- PowerPoint‑vorm
- presentatie‑vorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop‑vorm‑ID opvragen
- alternatieve tekst van vorm
- aanpassingspunt van vorm
- preset‑vormaanpassing
- vormgeometrie
- vorm‑lay‑outopmaak
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, herordenen, exporteren, uitlijnen en spiegelen met Aspose.Slides for Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET stelt de vormen op een dia voor als een geordende [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/). De collectie is zowel de plaats waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de meest achterste vorm, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en preset‑aanpassingspunten kunt wijzigen, en toont vervolgens hoe je vormen kunt klonen, verwijderen, verbergen en herordenen. De laatste secties behandelen lay‑niveau opmaak, SVG‑export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Vormen identificeren en vinden**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of herordenen van een vorm kan de index wijzigen. Kies een identifier volgens de manier waarop de presentatie wordt gemaakt en onderhouden:

- [Shape.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/name/) is nuttig voor door ontwikkelaars beheerde sjablonen en is gemakkelijk te inspecteren in het Selectiepainel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamconventie op als code ervan afhankelijk is.
- [Shape.alternative_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/alternative_text/) is handig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilzwijgend als databasesleutel.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/office_interop_shape_id/) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de shape‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer je integreert met PowerPoint of wanneer je een eenduidige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw gecreëerde vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde property [Shape.unique_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/unique_id/) heeft een presentatie‑scope, maar is bedoeld voor add‑ins en kan worden herhaald. Het mag niet worden behandeld als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de koppeling in applicatiedata en controleer dat de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op `name` met een exacte vergelijking en rapporteert de interop‑ID die op diavoorraad geldt. Wanneer de sjabloon de verwachte vorm niet bevat, rapporteert de code dat resultaat in plaats van door te gaan met het verkeerde object.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Wanneer een bewerking specifiek is voor een type vorm, controleer dan het type voordat je typespecifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst alleen bij als het genoemde object een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) is.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Preset‑vormaanpassingen identificeren en wijzigen**

Preset‑geometrievormen kunnen aanpassingspunten blootstellen die eigenschappen regelen zoals hoekgrootte, pijlpuntverhoudingen of booghoeken. Benader ze via de alleen‑lees collectie [GeometryShape.adjustments](https://reference.aspose.com/slides/nl/python-net/aspose.slides/geometryshape/adjustments/). De collectie zelf wordt door de vorm geleverd, maar elke [AdjustValue](https://reference.aspose.com/slides/nl/python-net/aspose.slides/adjustvalue/) bevat een waarde die kan worden veranderd.

Vertrouw niet uitsluitend op een vaste collectie‑index. Doorloop de aanpassingen en inspecteer de alleen‑lees property [AdjustValue.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/adjustvalue/type/), waarvan de waarde van [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapeadjustmenttype/) aangeeft wat de aanpassing regelt. De alleen‑lees property [AdjustValue.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/adjustvalue/name/) levert extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardepoging die bij de betekenis van de aanpassing past:

| Aanpassingstype | Doel | Te wijzigen waarde |
|---|---|---|
| `CORNER_SIZE` | Grootte van afgeronde hoeken | [raw_value](https://reference.aspose.com/slides/nl/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Dikte van een pijlstaart | `raw_value` |
| `ARROWHEAD_LENGTH` | Lengte van een pijlpunt | `raw_value` |
| `ARROWHEAD_WIDTH` | Breedte van een pijlpunt | `raw_value` |
| `START_ANGLE` | Starthoek van een taart- of boogvorm | [angle_value](https://reference.aspose.com/slides/nl/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Eindhoek van een taart- of boogvorm | `angle_value` |

`type` en `name` kunnen niet worden toegekend. `raw_value` is een lees‑schrijf geheel getal in de native geometrie‑eenheden van de preset, terwijl `angle_value` een lees‑schrijf hoek in graden is. Het aantal, de volgorde, betekenis en geldige bereik van de aanpassingen hangen af van de preset‑property [GeometryShape.shape_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/geometryshape/shape_type/). Een waarde die voor de ene preset geldig is, kan ongeldig of anders werkend zijn voor een andere.

Wanneer `type` `ShapeAdjustmentType.CUSTOM` is, herkent de API geen standaard semantische betekenis. Inspecteer `name`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en het bereik bekend zijn. Zelfs voor herkende types, controleer of hetzelfde type meer dan één keer voorkomt voordat je een waarde selecteert. Het artikel [Connector](/slides/nl/python-net/connector/) toont deze situatie met connector‑buig‑aanpassingen.

Het volgende volledige voorbeeld maakt standaard‑ en gewijzigde versies van drie preset‑vormen. Het doorloopt elke aanpassing, rapporteert `name` en `type`, wijzigt grootte‑gerelateerde waarden via `raw_value`, wijzigt hoeken via `angle_value`, en slaat het resultaat op. De linkerkolom behoudt de standaardgeometrie; de rechterkolom toont de aangepaste afgeronde rechthoek, vier‑weg‑pijl en taart.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Voeg kopteksten toe voor de standaard- en aangepaste vormkolommen.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Het controleren van het semantische type vóór het wijzigen van een waarde maakt de code expliciet over zijn bedoeling en voorkomt dat men veronderstelt dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **De Shape‑Collectie wijzigen**

De methoden add, clone, remove en reorder werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, gebruik dan geen indexen die vóór die bewerking zijn vastgelegd.

### **Een vorm klonen**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_clone/) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/insert_clone/) maakt eveneens een kopie maar plaatst die op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een bestemmingsdia, kloont een gelabelde rechthoek naar de voorkant en voegt een tweede kloon toe aan de achterkant. Wijzigingen aan een van beide klonen beïnvloeden de bronvorm niet.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Hulpbronnen die door complexe vormen worden gebruikt, worden beheerd door de presentatie, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Vormen verwijderen**

[ShapeCollection.remove](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Bij het verwijderen van meerdere overeenkomsten tijdens een geïndexeerde iteratie, loop van het einde naar voren zodat elke resterende index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een aangewezen naam. Het leest `slide.shapes[index]`, niet een vaste collectie‑item, en cast de vorm niet onnodig.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Na verwijdering veranderen het aantal vormen en de indexen van latere vormen. Verwijzingen naar onveranderde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectors, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer wijzigen dan alleen het uiterlijk van de dia.

### **Een vorm verbergen**

Het instellen van [Shape.hidden](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/hidden/) op `True` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, zodat verbergen geschikt is voor optionele elementen die later kunnen worden hersteld.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en zichtbaar worden gemaakt door een gebruiker of door code, en blijft deel uitmaken van het presentatie‑bestand.

### **De Z‑order wijzigen**

Overlap‑vormen worden getekend in de volgorde van de collectie. [ShapeCollection.reorder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `len(slide.shapes) - 1` is de voorkant.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

De rechthoek wordt eerst gemaakt en zit aanvankelijk achter de ellips. Het verplaatsen naar de laatste index plaatst hem vooraan. Voltooi de z‑order na het toevoegen of klonen van alle gerelateerde vormen, want die bewerkingen voegen nieuwe collectie‑items toe of voegen ze in en kunnen de gewenste stapel veranderen.

## **Vormen op layout‑dia's inspecteren**

Normale dia's, layout‑dia's en master‑dia's hebben aparte vormcollecties. Een vorm in een layout‑collectie is niet hetzelfde object als een vergelijkbaar gepositioneerde vorm op een normale dia. Inspecteer layout‑vormen wanneer je de opmaak die door een layout wordt geleverd wilt begrijpen of wijzigen.

Het volgende voorbeeld leest van elke layout‑vorm de [Shape.fill_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/fill_format/) en [Shape.line_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/line_format/) zonder aan te nemen dat elke vorm een `AutoShape` is.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Het bewerken van een layout kan meerdere dia's die het gebruiken beïnvloeden. Bepaal voordat je een layout‑vorm wijzigt of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die layout gebruikt.

## **Een vorm exporteren naar SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/write_as_svg/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat de vorm, maar niet de volledige slide‑achtergrond of naburige vormen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van hulpmiddelen zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Vormen uitlijnen**

De overloads van [SlideUtil.align_shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/align_shapes/) lijnen ofwel alle vormen of geselecteerde collectie‑indexen uit. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapesalignmenttype/) specificeert de rand, middellijn of distributiemodus. Stel `align_to_slide` in op `True` om de slide‑randen te gebruiken; stel het in op `False` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijn drie vormen op de bovenrand van de dia uit. Hun huidige indexen worden onmiddellijk vóór uitlijning opgezocht.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Uitlijning wijzigt posities, niet de z‑order. Relatieve uitlijning vereist normaal gezien minstens twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de tussenruimte te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Een vorm spiegelen**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegel‑instellingen en rotatie op. De waarden `flip_h` en `flip_v` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/python-net/aspose.slides/nullablebool/): `TRUE` activeert de spiegel, `FALSE` deactiveert deze, en `NOT_DEFINED` behoudt de ongedefinieerde of standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt elke andere frame‑waarde en vervangt alleen de twee spiegel‑instellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Shape.frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/frame/) het volledige frame vervangt.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

De opgeslagen vorm wordt horizontaal en verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vormidentifier?**

Alleen voor kortstondige verwerking wanneer de collectie niet verandert voordat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `name`‑ of `alternative_text`‑conventie voor gemaakte sjablonen, of `office_interop_shape_id` voor slide‑gescopeerde interop‑werkzaamheden.

**Verbergt verbergen een vorm uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Ze kan worden gevonden, herordend, bewerkt of weer zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`add_clone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik `insert_clone` om de initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na validatie van de exacte preset en collectie‑lay‑out. Geef de voorkeur aan itereren door `GeometryShape.adjustments` en controleer `AdjustValue.type`; gebruik `AdjustValue.name` als aanvullende informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.