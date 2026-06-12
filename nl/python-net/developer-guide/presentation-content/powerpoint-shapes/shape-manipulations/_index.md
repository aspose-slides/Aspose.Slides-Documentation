---
title: Vormen beheren in presentaties met Python
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
- volgorde van vorm wijzigen
- interop vorm‑ID ophalen
- alternatieve tekst van vorm
- lay‑outformaten van vorm
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe je vormen kunt maken, bewerken en optimaliseren in Aspose.Slides voor Python via .NET en hoogwaardige PowerPoint- en OpenDocument‑presentaties kunt leveren."
---
## **Overzicht**

Deze gids introduceert vormmanipulatie in Aspose.Slides voor Python via .NET. Leer praktische patronen voor het vinden van vormen (incl. op Alternatieve Tekst), dupliceren, verwijderen of verbergen, herschikken, uitlijnen en spiegelen, het lezen van ID's en lay-out‑gedreven opmaak, en het exporteren van individuele vormen naar SVG met behulp van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) API's.

## **Vormen vinden op dia's**

PowerPoint identificeert vormen alleen via interne ID's. Ken een unieke Alt‑tekst toe aan de doelvorm in PowerPoint, open vervolgens de presentatie met Aspose.Slides voor Python, doorloop de vormen van de dia en selecteer degene waarvan de Alt‑tekst overeenkomt. De `find_shape`‑methode implementeert deze aanpak en retourneert de passende vorm.

```py
import aspose.slides as slides

# Vindt een vorm op een dia via zijn alternatieve tekst.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Zoek de vorm met Alt Text "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Vormen klonen**

Om vormen van een bron‑dia naar een nieuwe dia te klonen in Aspose.Slides, volg deze stappen:

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan op basis van het bronbestand.
1. Haal de bron‑dia op via de index en verkrijg de collectie Shapes.
1. Verkrijg een lege lay-out van de master‑dia.
1. Voeg een lege dia toe met die lay-out en haal de Shapes op.
1. Clone de vormen naar de doel‑dia.
1. Sla de presentatie op als PPTX.

De volgende code‑voorbeeld kloont vormen van de ene dia naar de andere.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Sla de presentatie op op schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vormen verwijderen**

Aspose.Slides laat je elke vorm van een dia verwijderen. Bijvoorbeeld, om een vorm van de eerste dia te verwijderen via zijn Alternatieve Tekst, volg deze stappen:

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie en laad het bestand.
1. Open de eerste dia uit de collectie Slides.
1. Zoek de vorm op basis van de Alternatieve Tekst‑waarde.
1. Verwijder de vorm uit de Shapes‑collectie van de dia.
1. Sla de presentatie op op schijf in PPTX‑formaat.

```py
import aspose.slides as slides

# Vindt een vorm op een dia via zijn alternatieve tekst.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Zoek de vorm met Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Verwijder de vorm.
    slide.shapes.remove(shape)
    # Sla de presentatie op op schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vormen verbergen**

Aspose.Slides laat je elke vorm op een dia verbergen. Bijvoorbeeld, om een vorm op de eerste dia te verbergen via zijn Alternatieve Tekst, volg deze stappen:

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie en laad het bestand.
1. Open de eerste dia uit de collectie Slides.
1. Zoek de vorm op basis van de Alternatieve Tekst‑waarde.
1. Verberg de vorm.
1. Sla de presentatie op op schijf in PPTX‑formaat.

```py
# Vindt een vorm op een dia via zijn alternatieve tekst.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Zoek de vorm met Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Verberg de vorm.
    shape.hidden = True
    # Sla de presentatie op op schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **De volgorde van vormen wijzigen**

Aspose.Slides stelt ontwikkelaars in staat om de volgorde van vormen (z‑order) te wijzigen. Het herschikken bepaalt welke vorm vóór of achter een andere verschijnt. Bijvoorbeeld, om twee vormen op de eerste dia te herschikken, volg de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de eerste dia.
1. Voeg de eerste vorm toe (bijvoorbeeld een rechthoek).
1. Voeg de tweede vorm toe (bijvoorbeeld een driehoek).
1. Herschik de vormen door de tweede vorm naar de eerste positie in de collectie te verplaatsen.
1. Sla de presentatie op op schijf.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Voeg twee vormen toe aan de dia.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Verplaats de tweede vorm naar de eerste positie.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Interop Shape‑ID ophalen**

Aspose.Slides laat je de unieke identifier van een vorm binnen de scope van een dia verkrijgen, in tegenstelling tot de `unique_id`‑eigenschap die uniek is voor de hele presentatie. De `office_interop_shape_id`‑eigenschap is beschikbaar op de [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑klasse. De waarde correspondeert met de `Id` van het `Microsoft.Office.Interop.PowerPoint.Shape`‑object. Een voorbeeldcode‑fragment staat hieronder.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Haal de unieke identifier van de vorm binnen de dia op.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Alternatieve tekst voor vormen instellen**

Aspose.Slides stelt ontwikkelaars in staat om alternatieve tekst voor elke vorm in te stellen. Je kunt alternatieve tekst gebruiken om vormen in een presentatie te identificeren en te lokaliseren. De eigenschap kan zowel via Aspose.Slides als Microsoft PowerPoint worden gelezen en geschreven. Door vormen te markeren met deze eigenschap kun je ze later verwijderen, verbergen of herschikken op een dia.

Om de alternatieve tekst van een vorm in te stellen, volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de eerste dia.
1. Voeg een vorm toe aan de dia.
1. Stel de alternatieve tekst in.
1. Sla de presentatie op op schijf.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Voeg een vorm toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Stel de alternatieve tekst van de vorm in.
    shape.alternative_text = "User Defined"
    # Sla de presentatie op op schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Lay-outformaten voor vormen benaderen**

Aspose.Slides biedt een eenvoudige API om lay-outformaten voor vormen te benaderen. Deze sectie laat zien hoe je lay-outformaten kunt benaderen.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Vormen renderen als SVG**

Aspose.Slides ondersteunt het renderen van vormen als SVG. De `write_as_svg`‑methode (en zijn overloads) op de [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑klasse laat je de inhoud van een vorm opslaan als een SVG‑afbeelding. Het code‑fragment hieronder toont hoe je een vorm exporteert naar een SVG‑bestand.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Haal de eerste vorm op van de eerste dia.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Vorm uitlijnen**

Met de `align_shape`‑methode in de [SlidesUtil](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/)‑klasse kun je:

* Vormen uitlijnen ten opzichte van de marges van een dia (zie Voorbeeld 1).
* Vormen ten opzichte van elkaar uitlijnen (zie Voorbeeld 2).

De enumeratie [ShapesAlignmentType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapesalignmenttype/) definieert de beschikbare uitlijnopties.

**Voorbeeld 1**

Deze Python‑code toont hoe je de vormen met index 1, 2 en 4 uitlijnt op de bovenrand van de dia:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Voorbeeld 2**

Dit Python‑voorbeeld toont hoe je alle vormen in een collectie uitlijnt ten opzichte van de laagste vorm in die collectie:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Flip‑eigenschappen**

In Aspose.Slides biedt de [ShapeFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapeframe/)‑klasse controle over horizontale en verticale spiegeling van vormen via de `flip_h`‑ en `flip_v`‑eigenschappen. Beide eigenschappen zijn van het type [NullableBool](https://reference.aspose.com/slides/nl/python-net/aspose.slides/nullablebool/), waardoor `TRUE` een flip aangeeft, `FALSE` geen flip, of `NOT_DEFINED` om het standaardgedrag te gebruiken. Deze waarden zijn toegankelijk via het [Frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/frame/) van een vorm.

Om de flip‑instellingen te wijzigen, wordt een nieuw [ShapeFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapeframe/)‑object gecreëerd met de huidige positie en grootte van de vorm, de gewenste waarden voor `flip_h` en `flip_v`, en de rotatiehoek. Dit object wordt toegewezen aan het [Frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/frame/) van de vorm en na het opslaan van de presentatie worden de spiegeltransformaties toegepast op het uitvoerbestand.

Stel dat we een sample.pptx‑bestand hebben waarin de eerste dia één vorm bevat met standaard flip‑instellingen, zoals hieronder weergegeven.

![The shape to be flipped](shape_to_be_flipped.png)

Het volgende code‑voorbeeld haalt de huidige flip‑eigenschappen van de vorm op en spiegelt deze zowel horizontaal als verticaal.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Haal de horizontale spiegelingsproperty van de vorm op.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Haal de verticale spiegelingsproperty van de vorm op.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Spiegel horizontaal en verticaal.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kan ik vormen (union/intersect/subtract) op een dia combineren zoals in een desktop‑editor?**

Er is geen ingebouwde Boolean‑operatie‑API. Je kunt het benaderen door zelf de gewenste omtrek te construeren — bijvoorbeeld de resulterende geometrie berekenen (via [GeometryPath](https://reference.aspose.com/slides/nl/python-net/aspose.slides/geometrypath/)) en een nieuwe vorm met die contour aanmaken, eventueel de originelen verwijderen.

**Hoe kan ik de stapelvolgorde (z-order) regelen zodat een vorm altijd “bovenaan” blijft?**

Pas de invoeg‑/verplaatsvolgorde aan binnen de [shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/shapes/)‑collectie van de dia. Voor voorspelbare resultaten, finaliseer de z‑order nadat alle overige dia‑wijzigingen zijn uitgevoerd.

**Kan ik een vorm “vergrendelen” om te voorkomen dat gebruikers deze in PowerPoint bewerken?**

Ja. Stel [shape‑level protection flags](/slides/nl/python-net/applying-protection-to-presentation/) in (bijv. vergrendel selectie, verplaatsing, grootte‑aanpassing, tekst‑bewerking). Indien nodig, spiegel de restricties op de master‑ of lay‑out‑dia. Let op: dit is UI‑niveau bescherming, geen beveiligingsfunctie; voor sterkere bescherming combineer met bestands‑niveau restricties zoals [read‑only aanbevelingen of wachtwoorden](/slides/nl/python-net/password-protected-presentation/).