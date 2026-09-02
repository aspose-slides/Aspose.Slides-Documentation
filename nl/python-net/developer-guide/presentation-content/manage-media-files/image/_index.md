---
title: Optimaliseer Beeldbeheer in PowerPoint met Python
linktitle: Beheer Afbeeldingen
type: docs
weight: 10
url: /nl/python-net/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van internet
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor Python via .NET, optimaliseer de prestaties en automatiseer je workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en interessanter. In Microsoft PowerPoint kun je afbeeldingen invoegen vanaf een bestand, internet of andere bronnen op dia's. Op dezelfde manier kun je met Aspose.Slides afbeeldingen op dia's toevoegen op verschillende manieren.

{{% alert title="Tip" color="primary" %}}
Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die je snel presentaties van afbeeldingen laten maken.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Als je een afbeelding wilt toevoegen als een frame‑object—met name als je van plan bent standaard opmaakopties zoals schalen of effecten toe te passen—zie [Afbeeldingsframes toevoegen aan presentaties met Python](https://docs.aspose.com/slides/nl/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Opmerking" color="warning" %}}
Je kunt beeld‑ en presentatietoegangsbewerkingen gebruiken om afbeeldingen tussen formaten te converteren. Zie deze pagina’s: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-png/); converteer [PNG naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-svg/); en converteer [SVG naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides ondersteunt werken met afbeeldingen in gangbare formaten zoals JPEG, PNG, BMP, GIF en anderen.

## **Afbeeldingen lokaal aan dia's toevoegen**

Je kunt één of meerdere afbeeldingen van je computer aan een dia in een presentatie toevoegen. Het volgende Python‑voorbeeld laat zien hoe je een afbeelding aan een dia toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen vanaf het web aan dia's toevoegen**

Als de afbeelding die je aan een dia wilt toevoegen niet op je computer beschikbaar is, kun je deze rechtstreeks vanaf het web invoegen.

Het volgende Python‑voorbeeld laat zien hoe je een afbeelding van een URL aan een dia toevoegt:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Download de ruwe afbeeldingsbytes.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen aan slide‑masters toevoegen**

Een slide‑master is de bovenste slide die informatie—thema, lay-out, enzovoort—opslaat en beheert voor alle onderliggende slides. Wanneer je een afbeelding aan een slide‑master toevoegt, verschijnt die afbeelding op elke slide die die master gebruikt.

Het volgende Python‑voorbeeld laat zien hoe je een afbeelding aan een slide‑master toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen als slide‑achtergronden toevoegen**

Je kunt een afbeelding gebruiken als achtergrond voor één of meerdere slides. Voor details, zie *[Afbeeldingen instellen als achtergronden voor slides](/slides/nl/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG toevoegen aan presentaties**

SVG‑inhoud kan aan een presentatie worden toegevoegd met de klasse [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/). De resulterende SVG‑afbeelding kan vervolgens aan de afbeeldingscollectie van de presentatie worden toegevoegd en worden gebruikt om een afbeeldingsframe te maken.

Het volgende Python‑voorbeeld importeert een zelfstandige SVG‑string. Alle afbeeldingen, stijlen en andere bronnen die door deze SVG worden gebruikt, zijn direct in de SVG‑inhoud ingebed.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG converteren naar een set vormen**

Aspose.Slides converteert SVG‑s naar een set vormen op een manier die vergelijkbaar is met de SVG‑verwerking in PowerPoint.

![PowerPoint‑pop‑upmenu](img_01_01.png)

Deze functionaliteit wordt geleverd door een overload van de methode [add_group_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_group_shape/) in de klasse [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/) die een [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/) als eerste argument neemt. 

De voorbeeldcode hieronder laat zien hoe je een SVG‑bestand naar een set vormen converteert.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lees de inhoud van het SVG‑bestand.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Maak een SvgImage‑object aan.
        svg_image = slides.SvgImage(svg_content)

        # Haal de grootte van de dia op.
        slide_size = presentation.slide_size.size

        # Converteer de SVG‑afbeelding naar een groep vormen en schaal deze naar de dia‑grootte.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Sla de presentatie op in PPTX‑formaat.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen als EMF aan slides toevoegen**

Aspose.Slides voor Python laat je Enhanced Metafile (EMF)‑afbeeldingen in presentaties invoegen.

Het volgende Python‑voorbeeld demonstreert dit:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen in de afbeeldingscollectie vervangen**

Aspose.Slides stelt je in staat afbeeldingen die zijn opgeslagen in de afbeeldingscollectie van een presentatie, inclusief die gebruikt door slide‑vormen, te vervangen. Deze sectie beschrijft verschillende benaderingen om afbeeldingen in de collectie bij te werken. De API biedt eenvoudige methoden om een afbeelding te vervangen door ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/)‑instantie, of een andere afbeelding die al bestaat in de collectie.

Volg deze stappen:

1. Laad de presentatie die de afbeeldingen bevat met de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
3. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.
4. Of laad de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/)‑object en vervang de doelafbeelding door dat object.
5. Of vervang de doelafbeelding door een afbeelding die al bestaat in de afbeeldingscollectie van de presentatie.
6. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation("sample.pptx") as presentation:

    # De eerste manier.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # De tweede manier.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # De derde manier.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Sla de presentatie op in een bestand.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Met Aspose’s gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter kun je tekst eenvoudig animeren en GIF’s van tekst maken.
{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na invoegen?**

Ja. De bronpixels blijven behouden, maar het uiteindelijke uiterlijk hangt af van hoe de [picture](/slides/nl/python-net/picture-frame/) wordt geschaald op de dia en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo tegelijk op tientallen dia's te vervangen?**

Plaats het logo op de master‑slide of een lay-out en vervang het in de afbeeldingscollectie van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden geconverteerd naar bewerkbare vormen?**

Ja. Je kunt een SVG converteren naar een groep vormen, waarna individuele delen bewerkbaar worden met standaard vormeigenschappen.

**Hoe kan ik een afbeelding tegelijk als achtergrond voor meerdere dia's instellen?**

[Wijs de afbeelding toe als achtergrond](/slides/nl/python-net/presentation-background/) op de master‑slide of de relevante lay-out—alle dia's die die master/lay-out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat een presentatie te groot wordt door veel afbeeldingen?**

Herbruik één afbeeldingsresource in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en houd herhaalde grafieken waar mogelijk op de master.