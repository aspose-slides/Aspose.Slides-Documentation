---
title: Beheer presentatieplaceholders in Python
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/python-java/manage-placeholder/
keywords:
- placeholder
- tekstplaceholder
- afbeeldingsplaceholder
- diagramplaceholder
- inhoudsplaceholder
- prompttekst
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u tekst-, afbeelding-, diagram- en inhoudsplaceholders kunt inspecteren en bewerken en begrijp placeholder‑erfenis met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel, inhoud, afbeelding, diagram en algemene inhoud‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een lay‑outdia of masterschijf.

Aspose.Slides biedt placeholder‑informatie via de [Shape.getPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getPlaceholder)‑methode. De methode geeft een [Placeholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholder/)‑object terug of `None` voor een normale vorm. Gebruik [Placeholder.getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholder/#getType) om te bepalen wat de placeholder moet bevatten.

Het vormtype blijft relevant nadat je het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, diagram‑ of inhoud‑placeholder wordt meestal vertegenwoordigd door een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/).
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [PictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pictureframe/).
- Een gevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/).
- Een inhoud‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [Placeholder.getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholder/#getType) als het runtime‑vormtype in plaats van aan te nemen dat elke placeholder een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) is.

{{% alert color="warning" title="Waarschuwing" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholder/#getType) beschrijft de rol van een placeholder; het garandeert niet het runtime‑vormtype van de vorm. Gebruik altijd een type‑check voordat je tekst-, afbeelding-, diagram-, tabel‑ of media‑specifieke leden benadert.
{{% /alert %}}

## **Begrijp placeholder‑erfenis**

Placeholders vormen een hiërarchie:

1. Een masterschijf definieert herbruikbare stijlen en, in sommige gevallen, master‑level placeholders.
2. Een lay‑outdia definieert de indeling die door één of meer normale dia's wordt gebruikt en kan erven van de master.
3. Een normale dia bevat de placeholders voor die dia en kan erven van de lay‑out.

Roep [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getBasePlaceholder) aan om een niveau hoger in deze hiërarchie te gaan. Een dia‑placeholder geeft normaal gesproken zijn lay‑out‑placeholder terug; een lay‑out‑placeholder kan zijn master‑placeholder teruggeven. De methode retourneert `None` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft een lijst van placeholders op de eerste dia en meldt hun basis‑placeholders:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Een placeholder bewerken op een normale dia maakt een lokale override aan of wijzigt deze voor die dia. Het bewerken van de gerelateerde lay‑out of master kan alle dia's beïnvloeden die die instelling nog erven. Een gewone lokale vorm heeft geen basis‑placeholder en begint niet te erven alleen omdat hij dezelfde coördinaten inneemt.

## **Tekst wijzigen in een placeholder**

Titel‑, gecentreerde‑titel‑, ondertitel‑, body‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) voordat je de [getTextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/#getTextFrame)‑methode gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste dia bij en slaat het resultaat op:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dit patroon voorkomt het behandelen van afbeelding‑, diagram‑, tabel‑ of media‑placeholders als een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/). Het identificeert bovendien de placeholder op basis van doel in plaats van te vertrouwen op een kwetsbare vorm‑index.

## **Prompt‑tekst instellen op een lay‑out**

Prompt‑tekst is de ontwerptijd‑instructie die wordt weergegeven in een lege placeholder, bijvoorbeeld *Klik om titel toe te voegen*. Stel aangepaste prompt‑tekst in op de lay‑out‑placeholder in plaats van te proberen deze via de vormcollectie van een normale dia te bereiken. Toegang tot de lay‑out krijg je via [Slide.getLayoutSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getLayoutSlide) en je iterate over de collectie die wordt geretourneerd door [BaseSlide.getShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getShapes).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de lay‑out die door de eerste dia wordt gebruikt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prompt‑tekst is geen gewone dia‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsapplicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt bovendien niet de bestaande tekst op dia's die de lay‑out gebruiken.

## **Een afbeelding‑placeholder bijwerken**

Er zijn twee gevallen om af te handelen:

- Als de afbeelding‑placeholder al is gevuld en wordt weergegeven door een [PictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pictureframe/), vervang dan de afbeelding via [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/#getPicture) en [Picture.setImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picture/#setImage).
- Als het nog een lege placeholder is, voeg dan een picture‑frame toe op de coördinaten van de placeholder met [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addPictureFrame) en verwijder de lege placeholder.

Het volgende voorbeeld ondersteunt beide gevallen en slaat de presentatie op:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De vervanging die voor een lege placeholder wordt aangemaakt, is een lokaal picture‑frame, geen nieuwe placeholder, omdat [Shape.getPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getPlaceholder) geen setter biedt. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul de placeholder eerst in PowerPoint, en werk daarna het resulterende [PictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pictureframe/) bij met Aspose.Slides.

Voor beeldtransparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/python-java/picture-frame/). Die bewerkingen behoren tot het picture‑frame of picture‑fill, niet tot placeholder‑metadata.

## **Werken met diagram‑ en inhoud‑placeholders**

Een gevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/). Dit voorbeeld vindt zo’n diagram via zowel placeholder‑type als runtime‑type, wijzigt de titel en slaat het bestand op:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Een algemene inhoud‑placeholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholdertype/#Object). In PowerPoint fungeert hij als starter voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat hij is gevuld, inspecteer je het daadwerkelijke vormtype om te leren wat hij bevat. Gespecialiseerde lay‑outs kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholdertype/#Media) of [PlaceholderType.Diagram](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholdertype/#Diagram) blootleggen.

Aspose.Slides zet een lege [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) placeholder niet om in een [Chart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/) door alleen [Placeholder.getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholder/#getType) te wijzigen; het type kan via de API niet worden veranderd. Om een leeg diagram of inhoudsgebied programmatically te vullen, voeg je het benodigde object toe op de coördinaten van de placeholder en verwijder je daarna de lege placeholder. Het volgende voorbeeld doet dit voor een diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het toegevoegde diagram is een gewone lokale diagram. Het neemt het gebied van de placeholder in beslag maar erft niet van de lay‑out‑placeholder. Gebruik de dedicated [chart management articles](/slides/nl/python-java/powerpoint-charts/) wanneer je de categorieën, series of werkmapgegevens moet vervangen.

## **Volledig voorbeeld: tekst‑ of afbeeldinginhoud bijwerken**

Het volgende end‑to‑end‑voorbeeld opent een sjabloon, zoekt op de eerste dia naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vormtypes, werkt de juiste inhoud bij en slaat de uitvoer op. Het voorbeeld vermijdt bewust aannames over vorm‑indexen of het behandelen van elke placeholder als hetzelfde type.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Wat is een basis‑placeholder?**

Een basis‑placeholder is de bijbehorende vorm op de lay‑out of master waarvan een andere placeholder erft. Gebruik [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getBasePlaceholder) om deze op te halen. Een gewone lokale vorm retourneert `None` omdat hij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle diatitel wijzigen door een lay‑out‑placeholder te bewerken?**

Je kunt geërfde opmaak of prompt‑tekst wijzigen via een lay‑out, maar bestaande titelinhoud wordt opgeslagen op de normale dia's. Om de daadwerkelijke titeltekst door een hele presentatie heen te vervangen, iterate je over de dia's en werk je elke titel‑placeholder bij.

**Hoe beheer ik datum‑, dia‑nummer‑, header‑ en voettekst‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste niveau: dia, lay‑out, master, notities of handout. Zie [Manage Presentation Header and Footer](/slides/nl/python-java/presentation-header-and-footer/) voor volledige voorbeelden.