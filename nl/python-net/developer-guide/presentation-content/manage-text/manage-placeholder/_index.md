---
title: Beheer presentatiesplaatsvervullers in Python
linktitle: Beheer plaatsvervullers
type: docs
weight: 10
url: /nl/python-net/manage-placeholder/
keywords:
- plaatsvervuller
- tekstplaatsvervuller
- afbeeldingsplaatsvervuller
- diagramplaatsvervuller
- inhoudplaatsvervuller
- prompttekst
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u tekst-, afbeelding-, diagram- en inhoudsplaatsvervullers kunt inspecteren en bewerken en begrijp de erfenis van plaatsvervullers met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel, body, afbeelding, diagram en algemene inhouds‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een lay‑outdia of masterslide.

Aspose.Slides biedt placeholder‑informatie via de [Shape.placeholder]‑eigenschap. Deze eigenschap retourneert een [Placeholder]‑object of `None` voor een gewone vorm. Gebruik [Placeholder.type] om te bepalen wat de placeholder moet bevatten.

De vormklasse blijft van belang nadat u het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, diagram‑ of inhouds‑placeholder wordt meestal weergegeven door een [AutoShape].
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [PictureFrame].
- Een gevulde diagram‑placeholder kan worden weergegeven door een [Chart].
- Een inhouds‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [Placeholder.type] als de runtime‑vormklasse in plaats van aan te nemen dat elke placeholder een [AutoShape] is.

{{% alert color="warning" title="Warning" %}}
[Placeholder.type] beschrijft de rol van een placeholder; het garandeert niet de runtime‑klasse van de vorm. Gebruik altijd een type‑check voordat u toegang krijgt tot tekst-, afbeelding-, diagram-, tabel‑ of media‑specifieke leden.
{{% /alert %}}

## **Begrijp Placeholder‑Erfenis**

Placeholders vormen een hiërarchie:

1. Een master‑dia definieert herbruikbare stijlen en, in sommige gevallen, master‑level placeholders.
2. Een lay‑outdia definieert de indeling die wordt gebruikt door een of meer normale dia's en kan van de master erven.
3. Een normale dia bevat de placeholders voor die dia en kan van zijn lay‑out erven.

Roep [Shape.get_base_placeholder] aan om één niveau hoger in deze hiërarchie te gaan. Een dia‑placeholder retourneert normaal gesproken zijn lay‑outplaceholder; een lay‑outplaceholder kan zijn master‑placeholder retourneren. De methode retourneert `None` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft een lijst weer van placeholders op de eerste dia en meldt hun basis‑placeholders:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Een placeholder op een normale dia bewerken creëert of wijzigt een lokale override voor die dia. Het bewerken van de gerelateerde lay‑out of master kan alle dia's beïnvloeden die die instelling nog erven. Een gewone lokale vorm heeft geen basis‑placeholder en begint niet te erven alleen omdat hij dezelfde coördinaten beslaat.

## **Tekst Wijzigen in een Placeholder**

Titel‑, gecentreerde‑titel‑, ondertitel‑, body‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op een [AutoShape] voordat u de [text_frame]‑eigenschap gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste dia bij en slaat het resultaat op:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Dit patroon voorkomt dat afbeelding‑, diagram‑, tabel‑ of media‑placeholders worden behandeld als [AutoShape]‑objecten. Het identificeert ook de placeholder op basis van doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompttekst Instellen op een Lay‑out**

Prompttekst is de ontwerp‑tijd instructie die wordt weergegeven in een lege placeholder, zoals *Klik om titel toe te voegen*. Stel aangepaste prompttekst in op de lay‑outplaceholder in plaats van te proberen deze te bereiken via de vormcollectie van een normale dia. Benader de lay‑out via [Slide.layout_slide] en iteratie over [LayoutSlide.shapes].

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de lay‑out die door de eerste dia wordt gebruikt:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Prompttekst is geen normale dia‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsapplicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud levert, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op dia's die de lay‑out gebruiken.

## **Een Afbeeldings‑Placeholder Bijwerken**

Er zijn twee gevallen om af te handelen:

- Als de afbeelding‑placeholder al is gevuld en wordt weergegeven door een [PictureFrame], vervang de afbeelding via [PictureFillFormat.picture] en [Picture.image].
- Als het nog een lege placeholder is, voeg een picture‑frame toe op de coördinaten van de placeholder met [ShapeCollection.add_picture_frame] en verwijder de lege placeholder.

Het volgende voorbeeld ondersteunt beide gevallen en slaat de presentatie op:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

De vervanging die voor een lege placeholder wordt gemaakt, is een lokaal picture‑frame, geen nieuwe placeholder, omdat [Shape.placeholder] alleen‑lees is. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul de placeholder eerst in PowerPoint, en werk vervolgens het resulterende [PictureFrame] bij met Aspose.Slides.

Voor afbeeldings‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/python-net/picture-frame/). Die bewerkingen behoren tot het picture‑frame of picture‑fill, niet tot placeholder‑metadata.

## **Werken met Diagram‑ en Inhouds‑Placeholders**

Een gevulde diagram‑placeholder kan worden weergegeven door een [Chart]. Dit voorbeeld vindt zo’n diagram door zowel placeholder‑type als runtime‑klasse, wijzigt de titel en slaat het bestand op:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Een algemene inhouds‑placeholder heeft meestal [PlaceholderType.OBJECT]. In PowerPoint fungeert deze als een lanceerder voor verschillende inhoudstypen, inclusief diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat deze is gevuld, inspecteer de feitelijke vormklasse om te zien wat erin zit. Gespecialiseerde lay‑outs kunnen ook [PlaceholderType.CHART], [PlaceholderType.TABLE], [PlaceholderType.PICTURE], [PlaceholderType.MEDIA] of [PlaceholderType.DIAGRAM] blootleggen.

Aspose.Slides zet een lege [AutoShape]‑placeholder niet om in een [Chart] alleen door [Placeholder.type] te wijzigen; het type is alleen‑lees. Om programmatically een lege diagram‑ of inhouds‑zone te vullen, voeg het benodigde object toe op de coördinaten van de placeholder en verwijder vervolgens de lege placeholder. Het volgende voorbeeld doet dat voor een diagram:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Het toegevoegde diagram is een gewoon lokaal diagram. Het bezet het gebied van de placeholder maar erft niet van de lay‑outplaceholder. Gebruik de speciale [chart management articles](/slides/nl/python-net/powerpoint-charts/) wanneer u de categorieën, series of werkboek‑data moet vervangen.

## **Volledig Voorbeeld: Tekst of Afbeeldingsinhoud Bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt op de eerste dia naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vormtypen, werkt de juiste inhoud bij en slaat de output op. Het voorbeeld vermijdt opzettelijk het aannemen van een vorm‑index of het behandelen van elke placeholder als dezelfde vormklasse.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wat is een basis‑placeholder?**

Een basis‑placeholder is de overeenkomstige vorm op de lay‑out of master waarvan een andere placeholder erft. Gebruik [Shape.get_base_placeholder] om deze op te halen. Een gewone lokale vorm geeft `None` terug omdat ze geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle diatitels wijzigen door een lay‑outplaceholder te bewerken?**

U kunt geërfde opmaak of prompttekst wijzigen via een lay‑out, maar bestaande titelinhoud is opgeslagen op de normale dia's. Om de daadwerkelijke titeltekst in een hele presentatie te vervangen, iterereert u over de dia's en werkt u elke titel‑placeholder bij.

**Hoe beheer ik datum-, dia‑nummer-, header‑ en footer‑placeholders?**

Gebruik de header‑ en footermanagers op het juiste niveau: dia, lay‑out, master, notities of handout. Zie [Manage Presentation Header and Footer](/slides/nl/python-net/presentation-header-and-footer/) voor volledige voorbeelden.