---
title: Beheer presentatie-placeholders in Python
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/python-java/manage-placeholder/
keywords:
- placeholder
- tekst-placeholder
- afbeelding-placeholder
- diagram-placeholder
- inhoud-placeholder
- prompt-tekst
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u tekst-, afbeelding-, diagram- en inhoud-placeholders kunt inspecteren en bewerken en begrijp de placeholder-erfenis met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel-, tekst-, afbeelding-, diagram- en algemene content‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een layout‑slide of master‑slide.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder)‑methode. De methode retourneert een [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/)‑object of `None` voor een normale vorm. Gebruik [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) om te bepalen wat de placeholder moet bevatten.

Het type vorm blijft belangrijk nadat u het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, diagram‑ of content‑placeholder wordt doorgaans weergegeven door een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Een gevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Een content‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) als het runtime‑vormtype in plaats van aan te nemen dat elke placeholder een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) is.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat u toegang krijgt tot tekst-, afbeelding-, diagram-, tabel‑ of mediaspecifieke leden.
{{% /alert %}}

## **Begrijp placeholder‑erfenis**

Placeholders vormen een hiërarchie:

1. Een master‑slide definieert herbruikbare stijlen en, in sommige gevallen, master‑niveau placeholders.
2. Een layout‑slide definieert de indeling die wordt gebruikt door één of meer normale slides en kan erven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan erven van de layout.

Roep [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) aan om één niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder retourneert normaal zijn layout‑placeholder; een layout‑placeholder kan zijn master‑placeholder retourneren. De methode levert `None` op wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft een lijst weer van placeholders op de eerste slide en rapporteert hun basis‑placeholders:
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

Het bewerken van een placeholder op een normale slide creëert of wijzigt een lokale override voor die slide. Het bewerken van de bijbehorende layout of master kan alle slides beïnvloeden die die instelling nog erven. Een lokale gewone vorm heeft geen basis‑placeholder en begint niet met erven alleen omdat het dezelfde coördinaten bezet.

## **Verwijder placeholder‑status**

Wanneer u een sjabloon aanpast, gebruikt u [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) om een bestaand object als een gewone vorm te behouden. Zijn [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder)‑methode retourneert `None`, maar de vorm blijft in de collectie van de slide aanwezig. In tegenstelling tot [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) verwijdert dat de vorm uit die collectie.

Het volgende voorbeeld vereist een `template.pptx` met minstens één slide en een niet‑lege tekst‑placeholder op de eerste slide. Gebruik een placeholder met opmaak die is geërfd van de layout of master om het effect van het verwijderen van die relatie te zien. Het voorbeeld controleert dat dezelfde vorm behouden blijft, roept de methode opnieuw aan op de nu gewone vorm, en slaat het resultaat op.

{{% alert color="warning" title="Warning" %}}
Het verwijderen van placeholder‑status behoudt niet automatisch de geërfde weergave‑instellingen. Het onderstaande voorbeeld laat die instellingen bewust onveranderd, waardoor de uitvoer er anders uit kan zien. Een vorm waarvan positie en grootte volledig geërfd zijn, kan na de oproep nul‑coördinaten en afmetingen hebben en onzichtbaar worden, hoewel hij in de collectie blijft.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Het aanroepen van de methode op een gewone vorm heeft geen effect.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Voor een overeenkomende placeholder geven alle drie de controles `True` weer. De tekst blijft behouden, maar geërfde positie, grootte, rotatie, lettertype, alineauslijning, marges van het tekstframe, verticale verankering, vul‑ en lijninstellingen kunnen wijzigen wanneer de placeholder‑relatie wordt verwijderd. Bijvoorbeeld kan geërfde titelopmaak terugvallen op gewone tekstopmaak. Zie [Slide Layout](/slides/nl/python-java/slide-layout/) voor meer over layouts.

Om de gewenste weergave te behouden, moet u vóór de oproep de berekende positie, grootte en rotatie vastleggen en de benodigde effectieve opmaakwaarden naar afzonderlijke variabelen kopiëren. Haal die waarden op via [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) en [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Vertrouw niet alleen op de effectieve‑formaatobjecten, want hun tekst‑opmaakwaarden kunnen veranderen nadat de relatie is verwijderd. Pas de vastgelegde waarden expliciet toe op de gewone vorm daarna, inclusief lettertypefamilie, -grootte, -stijl, -kleur, alineainstellingen, tekstframe‑instellingen, vulling en lijn die in uw sjabloon worden gebruikt.

Geërfde vormgeometrie moet mogelijk ook expliciet worden toegewezen via [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Voor een rechthoekige tekst‑placeholder betekent dit het toewijzen van [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); alleen de vulling en lijn herstellen, herstelt mogelijk niet de zichtbare rechthoek. Sjablonen met extra effecten of complexere opmaak vereisen ook die instellingen.

## **Tekst wijzigen in een placeholder**

Titel‑, gecentreerde‑titel‑, ondertitel‑, tekst‑ en content‑placeholders ondersteunen doorgaans tekst. Controleer op een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) voordat u zijn [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame)‑methode gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste slide bij en slaat het resultaat op:
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

Dit patroon voorkomt dat afbeelding‑, diagram‑, tabel‑ of media‑placeholders worden behandeld als [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Het identificeert de placeholder ook op basis van het doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompt‑tekst instellen op een layout**

Prompt‑tekst is de ontwerpinstructie die wordt weergegeven in een lege placeholder, bijvoorbeeld *Klik om titel toe te voegen*. Stel aangepaste prompt‑tekst in op de layout‑placeholder in plaats van te proberen deze via de shape‑collectie van een normale slide te bereiken. Toegang tot de layout verkrijgt u via [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) en u iterereert over de collectie die wordt geretourneerd door [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de layout die door de eerste slide wordt gebruikt:
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

Prompt‑tekst is geen gewone slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsapplicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud levert, wordt de prompt niet meer getoond. Het wijzigen van een prompt vervangt bovendien niet de bestaande tekst op slides die de layout gebruiken.

## **Een afbeelding‑placeholder bijwerken**

Er zijn twee gevallen om af te handelen:

- Als de afbeelding‑placeholder al is gevuld en wordt weergegeven door een [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), vervang dan de afbeelding via [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) en [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Als het nog een lege placeholder is, voeg dan een picture‑frame toe op de coördinaten van de placeholder met [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) en verwijder de lege placeholder.

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

De vervanging die wordt gemaakt voor een lege placeholder is een lokaal picture‑frame, geen nieuwe placeholder, omdat [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) geen setter biedt. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, maak en vul de placeholder eerst in PowerPoint, en werk vervolgens het resulterende [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) bij met Aspose.Slides.

Voor afbeeldings‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/python-java/picture-frame/). Die bewerkingen behoren tot het picture‑frame of picture‑fill, niet tot de placeholder‑metadata.

## **Werken met diagram‑ en content‑placeholders**

Een gevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Dit voorbeeld vindt zo’n diagram via zowel placeholder‑type als runtime‑type, wijzigt de titel en slaat het bestand op:
```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

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

Een algemene content‑placeholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). In PowerPoint fungeert deze als lanceer‑van verschillende content‑types, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat deze is gevuld, inspecteert u het daadwerkelijke vorm‑type om te achterhalen wat deze bevat. Gespecialiseerde layouts kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) of [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram) blootleggen.

Aspose.Slides converteert een lege [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)‑placeholder niet naar een [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) alleen door [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) te wijzigen; het type kan via de API niet worden veranderd. Om een leeg diagram‑ of content‑gebied programmatisch te vullen, voegt u het benodigde object toe op de coördinaten van de placeholder en verwijdert u vervolgens de lege placeholder. Het volgende voorbeeld doet dat voor een diagram:
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

Het toegevoegde diagram is een gewone lokale chart. Het bezet het gebied van de placeholder maar erft niet van de layout‑placeholder. Gebruik de speciale [chart management articles](/slides/nl/python-java/powerpoint-charts/) wanneer u de categorieën, reeksen of werkboek‑data moet vervangen.

## **Volledig voorbeeld: tekst‑ of afbeeldingsinhoud bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt in de eerste slide naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑types, werkt de juiste inhoud bij, en slaat de uitvoer op. Het voorbeeld vermijdt bewust het aannemen van een vorm‑index of het behandelen van elke placeholder als hetzelfde type.
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

## **FAQ**

**Wat is een basis‑placeholder?**

Een basis‑placeholder is de overeenkomende vorm op de layout of master waarvan een andere placeholder erft. Gebruik [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) om deze op te halen. Een gewone lokale vorm retourneert `None` omdat deze niet deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle titels van slides wijzigen door een layout‑placeholder te bewerken?**

U kunt geërfde opmaak of prompt‑tekst wijzigen via een layout, maar bestaande titelinhoud wordt opgeslagen op de normale slides. Om de daadwerkelijke titeltekst in een hele presentatie te vervangen, iterereert u over de slides en werkt u elke titel‑placeholder bij.

**Hoe beheer ik datum-, slide‑nummer-, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op de juiste slide‑, layout‑, master‑, notitie‑ of handout‑scope. Zie [Manage Presentation Header and Footer](/slides/nl/python-java/presentation-header-and-footer/) voor volledige voorbeelden.