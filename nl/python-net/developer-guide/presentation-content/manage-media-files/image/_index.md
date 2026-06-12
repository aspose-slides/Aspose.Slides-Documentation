---
title: Optimaliseer afbeeldingbeheer in PowerPoint met Python
linktitle: Afbeeldingen beheren
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
- presentatie
- Python
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor Python via .NET, optimaliseer de prestaties en automatiseer je workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en interessanter. In Microsoft PowerPoint kun je afbeeldingen vanuit een bestand, internet of andere bronnen op dia's invoegen. Op dezelfde manier kun je met Aspose.Slides afbeeldingen aan dia's toevoegen op verschillende manieren.

{{% alert  title="Tip" color="primary" %}}

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die je snel presentaties uit afbeeldingen laten maken.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

Wil je een afbeelding als frame‑object toevoegen—bijvoorbeeld wanneer je standaard opmaakopties zoals schalen of effecten wilt gebruiken—zie dan [Afbeeldingsframes toevoegen aan presentaties met Python](https://docs.aspose.com/slides/nl/python-net/picture-frame/).

{{% /alert %}}

{{% alert title="Opmerking" color="warning" %}}

Je kunt afbeelding‑ en presentatie‑I/O‑bewerkingen gebruiken om afbeeldingen tussen formaten te converteren. Zie deze pagina’s: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-png/); converteer [PNG naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-svg/); en converteer [SVG naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides ondersteunt het werken met afbeeldingen in gangbare formaten zoals JPEG, PNG, BMP, GIF en anderen.

## **Afbeeldingen die lokaal zijn opgeslagen aan dia's toevoegen**

Je kunt één of meer afbeeldingen van je computer aan een dia in een presentatie toevoegen. Het volgende Python‑voorbeeld laat zien hoe je een afbeelding aan een dia toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen van het internet aan dia's toevoegen**

Als de afbeelding die je aan een dia wilt toevoegen niet op je computer beschikbaar is, kun je deze direct van het internet invoegen.

Het volgende Python‑voorbeeld laat zien hoe je een afbeelding vanaf een URL aan een dia toevoegt:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen aan dia‑masters toevoegen**

Een dia‑master is de bovenste dia die informatie—thema, lay‑out, enzovoort—voor alle onderliggende dia's opslaat en beheert. Wanneer je een afbeelding aan een dia‑master toevoegt, verschijnt die afbeelding op elke dia die die master gebruikt.

Het volgende Python‑voorbeeld laat zien hoe je een afbeelding aan een dia‑master toevoegt:

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

## **Een afbeelding als dia‑achtergrond instellen**

Je wilt misschien een afbeelding als achtergrond voor een specifieke dia of meerdere dia’s gebruiken. Voor details, zie [Een afbeelding als achtergrond voor een dia instellen](https://docs.aspose.com/slides/nl/python-net/presentation-background/#set-image-as-background-for-slide).

## **SVG aan presentaties toevoegen**

Je kunt elke afbeelding in een presentatie invoegen met de [add_picture_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_picture_frame/)‑methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/)‑klasse.

Om een afbeeldingsobject van een SVG te maken, volg je deze stappen:

1. Maak een [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/) en voeg deze toe aan de afbeeldingscollectie van de presentatie.  
2. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object van de [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/).  
3. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/)‑object met behulp van de [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/).

Het volgende Python‑voorbeeld laat zien hoe je een SVG‑afbeelding aan een presentatie toevoegt met deze stappen:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lees de inhoud van een SVG‑bestand.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Maak een SvgImage‑object aan.
        svg_image = slides.SvgImage(svg_content)

        # Maak een PPImage‑object aan.
        pp_image = presentation.images.add_image(svg_image)

        # Maak een nieuw PictureFrame‑object aan.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Sla de presentatie op in PPTX‑formaat.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG converteren naar een reeks vormen**

Aspose.Slides zet SVG‑bestanden om in een reeks vormen, op een manier die vergelijkbaar is met de SVG‑verwerking in PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Deze functionaliteit wordt geleverd door een overload van de [add_group_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_group_shape/)‑methode in de [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/)‑klasse die een [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/) als eerste argument accepteert.  

De voorbeeldcode hieronder laat zien hoe je een SVG‑bestand converteert naar een reeks vormen.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lees de inhoud van het SVG‑bestand.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Maak een SvgImage‑object aan.
        svg_image = slides.SvgImage(svg_content)

        # Haal de dia‑grootte op.
        slide_size = presentation.slide_size.size

        # Converteer de SVG‑afbeelding naar een groep vormen en schaal deze naar de dia‑grootte.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Sla de presentatie op in PPTX‑formaat.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen als EMF in dia's toevoegen**

Aspose.Slides voor Python laat je Enhanced Metafile (EMF)‑afbeeldingen in presentaties invoegen.

Het volgende Python‑voorbeeld demonstreert dit:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen in de afbeeldingscollectie vervangen**

Aspose.Slides maakt het mogelijk om afbeeldingen die in de afbeeldingscollectie van een presentatie zijn opgeslagen te vervangen, inclusief die welke door dia‑vormen worden gebruikt. Deze sectie beschrijft diverse methoden om afbeeldingen in de collectie bij te werken. De API biedt eenvoudige methoden om een afbeelding te vervangen door ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/)‑instantie, of een andere afbeelding die al in de collectie aanwezig is.

Volg deze stappen:

1. Laad de presentatie die de afbeeldingen bevat via de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.  
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.  
3. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.  
4. Of laad de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/)‑object en vervang de doelafbeelding hiermee.  
5. Of vervang de doelafbeelding door een afbeelding die al in de afbeeldingscollectie van de presentatie bestaat.  
6. Sla de aangepaste presentatie op als een PPTX‑bestand.

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Maak een instantie van de Presentation‑klasse die een presentatiedossier vertegenwoordigt.
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

    # Sla de presentatie op naar een bestand.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

Met de gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter van Aspose kun je eenvoudig tekst animeren en GIF‑bestanden van tekst maken.

{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na het invoegen?**

Ja. De bron‑pixels worden bewaard, maar het uiteindelijke uiterlijk hangt af van hoe het [picture](/slides/nl/python-net/picture-frame/) op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia’s tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingscollectie van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgezet in bewerkbare vormen?**

Ja. Je kunt een SVG omzetten naar een groep vormen; vervolgens kunnen individuele onderdelen bewerkt worden met de gebruikelijke vorm‑eigenschappen.

**Hoe kan ik één afbeelding als achtergrond voor meerdere dia’s tegelijk instellen?**

[Stel de afbeelding in als achtergrond](/slides/nl/python-net/presentation-background/) op de master‑dia of de betreffende lay‑out—alle dia’s die die master/lay‑out gebruiken, krijgen de achtergrond overgenomen.

**Hoe voorkom ik dat de presentatie “opschroeft” door veel afbeeldingen?**

Herbruik één afbeelding‑resource in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en houd herhaalde grafieken bij voorkeur op de master.