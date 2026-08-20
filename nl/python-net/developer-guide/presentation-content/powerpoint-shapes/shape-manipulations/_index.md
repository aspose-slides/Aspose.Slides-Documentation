---
title: Beheer Presentatievormen in Python
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/python-net/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- vorm-lay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET stelt de vormen op een dia voor als een geordende [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/). De collectie is zowel de plaats waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de meest achterste vorm, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren, daarna wordt getoond hoe je vormen kloont, verwijdert, verbergt en de volgorde wijzigt. De laatste secties behandelen opmaak op lay-outniveau, SVG-export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Identificeren en Vinden van Vormen**

Collectie‑indexes zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Shape.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/name/) is nuttig voor door ontwikkelaars beheerde sjablonen en is eenvoudig te inspecteren in het selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie op als code ervan afhankelijk is.
- [Shape.alternative_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/alternative_text/) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik geen betekenisvolle toegankelijkheidstekst stilletjes als databasetoets.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/office_interop_shape_id/) is een alleen‑lezen‑identifier die uniek is binnen een dia en overeenkomt met de vorm‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer je integreert met PowerPoint of wanneer je gedurende de levensduur van een vorm een ondubbelzinnige referentie nodig hebt. Een gekloonde of opnieuw gemaakte vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde eigenschap [Shape.unique_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/unique_id/) heeft alleen een presentatiescope, maar is bedoeld voor add‑ins en kan opnieuw worden toegewezen. Deze moet niet worden behandeld als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de mapping in applicatie‑data en controleer dat de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op `name` met een exacte vergelijking en meldt de interop‑ID op dia‑niveau. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een bepaald vormtype, controleer dan het type voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij **alleen** als het benoemde object een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) is.

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

## **De Shape-collectie wijzigen**

De methoden voor toevoegen, klonen, verwijderen en herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, blijf dan niet vertrouwen op eerder vastgelegde indexes.

### **Een vorm klonen**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_clone/) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/insert_clone/) maakt eveneens een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een bestemmingsdia, kloont een gelabelde rechthoek naar de voorkant en voegt een tweede kloon toe aan de achterkant. Wijzigingen aan één van de klonen wijzigen de bronvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief de naam en alternatieve tekst. Wijs nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Bronnen die door complexe vormen worden gebruikt, worden door de presentatie afgehandeld, maar een kloon blijft een nieuw collectie‑item met een nieuwe vormidentiteit.

### **Vormen verwijderen**

[ShapeCollection.remove](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/remove/) verwijdert een specifiek vormobject uit de collectie. Wanneer je meerdere overeenkomsten verwijdert tijdens een iteratie op index, loop dan van het einde zodat elk overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een opgegeven naam. Het leest `slide.shapes[index]`, niet een vaste collectie‑item, en cast de vorm niet onnodig.

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

Na het verwijderen wijzigen het aantal vormen en de indexen van latere vormen. Verwijzingen naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectors, animaties en andere presentatie‑features die kunnen verwijzen naar het verwijderde object; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden gevonden en ongedekt door een gebruiker of door code, en blijft deel van het presentatie‑bestand.

### **De Z‑volgorde wijzigen**

Overlappende vormen worden getekend in de volgorde van de collectie. [ShapeCollection.reorder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `len(slide.shapes) - 1` is de voorkant.

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

De rechthoek wordt eerst gemaakt en zit aanvankelijk achter de ellips. Het verplaatsen naar de laatste index zet hem naar voren. Voltooi de z‑volgorde pas nadat je alle gerelateerde vormen hebt toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe en kunnen de beoogde stapel wijzigen.

## **Vormen op lay-outdia's inspecteren**

Normale dia’s, lay-outdia’s en masters hebben afzonderlijke vormcollecties. Een vorm in een lay-outcollectie is niet hetzelfde object als een evenredig gepositioneerde vorm op een normale dia. Inspecteer lay‑out‑vormen wanneer je de opmaak die door een lay‑out wordt geleverd wilt begrijpen of wijzigen.

Het volgende voorbeeld leest voor elke lay‑outvorm de [Shape.fill_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/fill_format/) en [Shape.line_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/line_format/) zonder aan te nemen dat elke vorm een `AutoShape` is.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Het bewerken van een lay‑out kan meerdere dia’s die het gebruiken beïnvloeden. Voordat je een lay‑outvorm wijzigt, bepaal of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Een vorm exporteren naar SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/write_as_svg/) schrijft de gerenderde inhoud van één vorm naar een stroom. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of naburige vormen.

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

Houd de presentatie geopend tijdens het renderen. De output hangt af van de opmaak van de vorm en van bronnen zoals lettertypen en afbeeldingen. Als je de hele compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stroom en moet deze sluiten.

## **Vormen uitlijnen**

De [SlideUtil.align_shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/align_shapes/) overloads lijnen ofwel alle vormen of geselecteerde collectie‑indexes uit. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapesalignmenttype/) specificeert de rand, de middenlijn of de distributiemodus. Zet `align_to_slide` op `True` om de dia‑randen te gebruiken; zet het op `False` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit op de bovenrand van de dia. Hun huidige indexen worden direct vóór de uitlijning bepaald.

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

Uitlijning wijzigt posities, niet de z‑volgorde. Relatieve uitlijning vereist normaal minstens twee vormen, terwijl horizontale of verticale distributie genoeg vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Een vorm spiegelen**

De [ShapeFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides.shapeframe/)‑klasse slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De waarden `flip_h` en `flip_v` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/python-net/aspose.slides/nullablebool/): `TRUE` zet de spiegel aan, `FALSE` zet hem uit, en `NOT_DEFINED` behoudt de ongespecificeerde of standaard status.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm vóór het draaien](shape_to_be_flipped.png)

Het voorbeeld behoudt elke andere frame‑waarde en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuwe [Shape.frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/frame/) het volledige frame vervangt.

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

De opgeslagen vorm wordt zowel horizontaal als verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![De vorm na het draaien](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identifier?**

Alleen voor kortdurende verwerking wanneer de collectie niet zal veranderen voordat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `name`‑ of `alternative_text`‑conventie voor gemaakte sjablonen, of `office_interop_shape_id` voor interop‑werk op dia‑niveau.

**Verwijdert het verbergen van een vorm haar uit de z‑volgorde?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Ze kan worden gevonden, herschikt, bewerkt of weer zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`add_clone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑volgorde is. Gebruik `insert_clone` om een initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.