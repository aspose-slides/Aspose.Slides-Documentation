---
title: Beheer presentatie‑placeholders in Python
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/python-net/manage-placeholder/
keywords:
- placeholder
- tekst‑placeholder
- afbeeldings‑placeholder
- diagram‑placeholder
- inhouds‑placeholder
- prompt‑tekst
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe je tekst‑, afbeelding‑, diagram‑ en inhouds‑placeholders kunt inspecteren en bewerken en begrijp placeholder‑erfelijkheid met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatie‑sjabloon. Veelvoorkomende voorbeelden zijn titel, hoofdtekst, afbeelding, diagram en algemene inhouds‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een lay‑out‑slide of master‑slide.

Aspose.Slides stelt placeholder‑informatie beschikbaar via de [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) eigenschap. Deze eigenschap retourneert een [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) object of `None` voor een normale vorm. Gebruik [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) om te bepalen wat de placeholder moet bevatten.

De vormklasse blijft relevant nadat je het placeholder‑type kent:

- Een lege tekst‑, afbeelding-, diagram‑ of inhouds‑placeholder wordt doorgaans weergegeven door een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- Een ingevulde afbeelding‑placeholder kan worden weergegeven door een [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- Een ingevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- Een inhouds‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) als de runtime‑vormklasse in plaats van aan te nemen dat elke placeholder een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) is.

{{% alert color="warning" title="Waarschuwing" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) beschrijft de rol van een placeholder; het garandeert niet de runtime‑klasse van de vorm. Gebruik altijd een type‑check voordat je tekst, afbeelding, diagram, tabel of media‑specifieke leden benadert.
{{% /alert %}}

## **Begrijp de erfelijkheid van placeholders**

Placeholders vormen een hiërarchie:

1. Een master‑slide definieert herbruikbare stijlen en, in sommige gevallen, master‑niveau placeholders.
2. Een lay‑out‑slide definieert de indeling die wordt gebruikt door één of meer normale slides en kan erven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan erven van zijn lay‑out.

Roep [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) aan om één niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder geeft normaal zijn lay‑out‑placeholder terug; een lay‑out‑placeholder kan zijn master‑placeholder retourneren. De methode retourneert `None` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft de placeholders op de eerste slide weer en meldt hun basis‑placeholders:

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

Een placeholder op een normale slide bewerken creëert of wijzigt een lokale overschrijving voor die slide. Het bewerken van de gerelateerde lay‑out of master kan alle slides beïnvloeden die nog steeds die instelling erven. Een gewone lokale vorm heeft geen basis‑placeholder en begint niet te erven alleen omdat hij dezelfde coördinaten inneemt.

## **Placeholderstatus verwijderen**

Wanneer je een sjabloon aanpast, gebruik [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) om een bestaand object als een gewone vorm te behouden. Zijn [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) eigenschap wordt `None`, maar de vorm blijft in de collectie van de slide staan. In tegenstelling tot [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) verwijdert dit de vorm uit die collectie.

Het volgende voorbeeld vereist `template.pptx` met ten minste één slide en een niet‑lege tekst‑placeholder op de eerste slide. Gebruik een placeholder met opmaak die is geërfd van zijn lay‑out of master om het effect van het verwijderen van die relatie te zien. Het voorbeeld controleert dat dezelfde vorm behouden blijft, roept de methode opnieuw aan op de nu gewone vorm en slaat het resultaat op.

{{% alert color="warning" title="Waarschuwing" %}}
Het verwijderen van de placeholderstatus behoudt niet automatisch geërfde weergave‑instellingen. Het onderstaande voorbeeld laat die instellingen expres onveranderd, zodat de uitvoer er anders uit kan zien. Een vorm waarvan positie en grootte volledig geërfd zijn, kan na de oproep nul‑coördinaten en afmetingen hebben en onzichtbaar worden, hoewel hij in de collectie blijft.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Het aanroepen van de methode op een gewone vorm heeft geen effect.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Voor een overeenkomstige placeholder geven alle drie de controles `True` terug. De tekst blijft, maar geërfde positie, grootte, rotatie, lettertype, alinea‑uitlijning, tekst‑frame‑marges, verticale verankering, opvulling en lijneigenschappen kunnen wijzigen wanneer de placeholder‑relatie wordt verwijderd. Zo kan geërfde titelopmaak terugvallen op gewone tekstopmaak. Zie [Slide Layout](/slides/nl/python-net/slide-layout/) voor meer over lay‑outs.

Om de beoogde weergave te behouden, leg de berekende positie, grootte en rotatie vast vóór de oproep, en kopieer de benodigde effectieve opmaakwaarden naar afzonderlijke variabelen. Haal die waarden op via [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), en [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Vertrouw niet alleen op de effectieve‑format‑objecten, want hun tekst‑opmaak kan veranderen na het verwijderen van de relatie. Pas de vastgelegde waarden expliciet toe op de gewone vorm daarna, inclusief lettertype‑familie, grootte, stijl, kleur, alinea‑instellingen, tekst‑frame‑instellingen, opvulling en lijn die in je sjabloon worden gebruikt.

Geërfde vormgeometrie moet mogelijk ook expliciet worden toegewezen via [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). Voor een rechthoekige tekst‑placeholder betekent dit dat je [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) toewijst; alleen de opvulling en lijn herstellen, herstelt mogelijk niet de zichtbare rechthoek. Sjablonen met extra effecten of complexere opmaak vereisen die instellingen ook.

## **Tekst wijzigen in een placeholder**

Titel-, gecentreerde‑titel‑, ondertitel‑, hoofdtekst‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vóór gebruik van de [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) eigenschap.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste slide bij en slaat het resultaat op:

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

Dit patroon voorkomt dat afbeelding‑, diagram‑, tabel‑ of media‑placeholders worden behandeld als [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) objecten. Het identificeert bovendien de placeholder op basis van het doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompttekst instellen op een lay‑out**

Prompttekst is de ontwerpinstructie die wordt getoond in een lege placeholder, zoals *Klik om titel toe te voegen*. Stel aangepaste prompttekst in op de lay‑out‑placeholder in plaats van te proberen deze via de vorm‑collectie van een normale slide te bereiken. Benader de lay‑out via [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) en doorloop [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de lay‑out die door de eerste slide wordt gebruikt:

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

Prompttekst is geen normale slide‑inhoud. Ze is bedoeld voor lege placeholders in bewerkingsprogramma’s zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer getoond. Het wijzigen van een prompt vervangt bovendien niet de bestaande tekst op slides die de lay‑out gebruiken.

## **Afbeeldings‑placeholder bijwerken**

Er zijn twee gevallen om te behandelen:

- Als de afbeelding‑placeholder al is gevuld en wordt weergegeven door een [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), vervang je de afbeelding via [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) en [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Als het nog een lege placeholder is, voeg je een picture‑frame toe op de coördinaten van de placeholder met [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) en verwijder je de lege placeholder.

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

De vervanging die voor een lege placeholder wordt gemaakt, is een lokaal picture‑frame, geen nieuwe placeholder, omdat [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) alleen‑lezen is. Het behoudt de gereserveerde positie maar erft geen placeholder‑specifiek gedrag meer. Als het behouden van de placeholder‑relatie cruciaal is, bereid en vul dan eerst de placeholder in PowerPoint, en werk vervolgens het resulterende [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) bij met Aspose.Slides.

Voor afbeeldings‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/python-net/picture-frame/). Deze bewerkingen behoren tot het picture‑frame of picture‑fill, niet tot placeholder‑metadata.

## **Werken met diagram‑ en inhouds‑placeholders**

Een ingevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). Dit voorbeeld zoekt zo’n diagram via zowel placeholder‑type als runtime‑klasse, wijzigt de titel en slaat het bestand op:

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

Een algemene inhouds‑placeholder heeft meestal [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). In PowerPoint fungeert hij als een lanceerder voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat hij is gevuld, inspecteer je de daadwerkelijke vormklasse om te zien wat hij bevat. Gespecialiseerde lay‑outs kunnen ook [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), of [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) blootstellen.

Aspose.Slides zet een lege [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) placeholder niet om in een [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) door simpelweg [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) te wijzigen; het type is alleen‑lezen. Om programmatically een leeg diagram of inhoudsgebied te vullen, voeg je het vereiste object toe op de coördinaten van de placeholder en verwijder je vervolgens de lege placeholder. Het volgende voorbeeld doet dat voor een diagram:

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

Het toegevoegde diagram is een gewone lokale chart. Het beslaat het gebied van de placeholder maar erft niet van de lay‑out‑placeholder. Gebruik de toegewijde [chart management articles](/slides/nl/python-net/powerpoint-charts/) wanneer je de categorieën, series of workbook‑data moet vervangen.

## **Volledig voorbeeld: tekst‑ of afbeeldingsinhoud bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt in de eerste slide naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vormtypes, werkt de juiste inhoud bij en slaat de output op. Het voorbeeld vermijdt bewust het aannemen van een vorm‑index of het behandelen van elke placeholder als dezelfde vormklasse.

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

Een basis‑placeholder is de bijbehorende vorm op de lay‑out of master waarvan een andere placeholder erft. Gebruik [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) om deze op te halen. Een gewone lokale vorm geeft `None` terug omdat zij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle slide‑titels wijzigen door een lay‑out‑placeholder te bewerken?**

Je kunt geërfde opmaak of prompttekst wijzigen via een lay‑out, maar de bestaande titelinhoud staat opgeslagen op de normale slides. Om de feitelijke titeltekst in een hele presentatie te vervangen, doorloop je de slides en werk je elke titel‑placeholder bij.

**Hoe beheer ik datum‑, slide‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste niveau (slide, lay‑out, master, notities of handout). Zie [Manage Presentation Header and Footer](/slides/nl/python-net/presentation-header-and-footer/) voor volledige voorbeelden.