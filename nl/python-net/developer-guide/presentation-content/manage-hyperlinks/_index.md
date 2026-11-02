---
title: Beheer presentatie‑hyperlinks in Python
linktitle: Beheer Hyperlinks
type: docs
weight: 20
url: /nl/python-net/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- tekst‑hyperlink
- dia‑hyperlink
- vorm‑hyperlink
- afbeelding‑hyperlink
- video‑hyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "URL's, hyperlinks toevoegen, opmaken, bijwerken en verwijderen in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET, met Python‑voorbeelden."
---
## **Introductie**

Een hyperlink verbindt presentatiewaarde met een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks meestal twee doelen:

* Een website openen vanuit tekst, een vorm of een mediakader.
* Navigeren naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for Python via .NET stelt u in staat deze koppelingen toe te voegen, hun uiterlijk en geluid te regelen, hun eigenschappen bij te werken en ze te verwijderen. De voorbeelden hieronder laten zien hoe u met hyperlinks werkt op individuele elementen en hoe u hyperlinks benadert op presentatieniveau, dia‑niveau of tekst‑kaderniveau.

{{% alert color="info" title="Note" %}}
U kunt presentaties ook bewerken met de [gratis online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediakader. Het element waaraan u de hyperlink toewijst bepaalt het klikbare gebied: een tekstdelen linkt de geselecteerde tekst, terwijl een vorm of kader het dia‑object linkt.

Voor presentaties met relatieve hyperlinks, zie [Beheer de basis‑hyperlink](/slides/nl/python-net/presentation-properties/#manage-the-hyperlink-base) om de document‑niveau basis te lezen, wijzigen of wissen.

### **URL‑hyperlinks aan tekst toevoegen**

Om tekst aan een website te koppelen, kent u een [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) toe aan de eigenschap [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) van het tekstdeel, zoals hieronder weergegeven. Alleen dat tekstdeel wordt klikbaar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **URL‑hyperlinks aan vormen en mediakaders toevoegen**

Om een vorm of kader klikbaar te maken, stelt u de eigenschap [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) in. De hyperlink behoort tot het object zelf en niet tot een tekstdeel binnen het object.

Dezelfde aanpak geldt voor afbeelding‑, audio‑ en video‑kaders: wijs de hyperlink toe aan het kader en stel desgewenst de [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) van de koppeling in.

Het volgende voorbeeld maakt een rechthoek klikbaar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Interne hyperlinks laten lezers springen van een inhoudsopgave naar een specifieke dia. Het volgende voorbeeld gebruikt [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) om de tekst “Page 2” op de eerste dia te koppelen aan de tweede dia.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks opmaken**

### **Kleur**

De eigenschap [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) van [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) bepaalt of een hyperlink de hyperlinkkleur van de presentatie of de opmaak van het tekstdeel gebruikt. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) en stelt u de opvulkleur van het tekstdeel in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekst‑hyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstopvulling, terwijl de tweede de standaard hyperlinkkleur behoudt.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Geluid**

Een hyperlink kan een geluid afspelen wanneer deze wordt geactiveerd of een al afspelend geluid stoppen. Gebruik de volgende eigenschappen om dit gedrag te configureren:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Een hyperlinkgeluid toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Door op de knop te klikken wordt het geluid afgespeeld en wordt naar de volgende dia genavigeerd. Een tweede vorm op die dia stopt het vorige geluid bij een klik, zonder een navigatie‑actie uit te voeren.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Een hyperlinkgeluid extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest het audio‑bestand van de hyperlink van de eerste vorm in het geheugen via [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) en [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Tooltip‑ en interactie‑instellingen**

U kunt de volgende [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) eigenschappen bijwerken nadat u een hyperlink aan tekst of een vorm heeft toegewezen:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) stelt de tekst in die een kijker als hint voor de koppeling kan weergeven.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) specificeert het doel‑kader binnen een bovenliggend HTML‑frameset, indien van toepassing.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) bepaalt of het activeren van de koppeling de bestemming toevoegt aan de lijst van bekeken hyperlinks.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) bepaalt of de hyperlink wordt gemarkeerd bij een klik.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) om hyperlink‑containers te verzamelen, inclusief links van tekstdelen, voordat u ze wijzigt. Het volgende voorbeeld verwijdert beide activeringstypen van de eerste dia. Om slechts één type te verwijderen, roep alleen [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) of [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) aan; het verwijderen van een klik‑actie verwijdert niet de bijbehorende muis‑over‑actie.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Voor onvoorwaardelijke verwijdering verwijdert [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) beide activeringstypen in het gekozen bereik in één oproep. Voor selectieve opschoning en dekking van masters, lay-outs en notities, zie [Rapport, saneren en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlink‑inventaris bouwen**

Voordat u een presentatie verspreidt, maakt u een inventaris op van de interactieve acties en de web‑koppelingen. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) retourneert [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) objecten, niet een platte lijst van URL‑strings. Inspecteer zowel [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) als [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) van elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties bevatten, dus een volledig rapport heeft tot twee rijen per container nodig.

Alleen hyperkoppelingen op vormniveau scannen kan links die aan tekstdelen gekoppeld zijn missen. Vraag in plaats daarvan de juiste scope op, en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie-, dia‑ en tekst‑kaderscopes opvragen**

De klasse [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) is beschikbaar via [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) en [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Elke scope ondersteunt dezelfde queries:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) retourneert containers met een klik‑actie.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) retourneert containers met een muis‑over‑actie.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) retourneert containers met één of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` met een externe klik‑link, een bestands‑mouse‑over‑link, interne dia‑navigatie, een tekst‑mouse‑over‑link en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie queries werken in elke scope; de aantallen beschrijven containers, geen actietotalen. De tekst‑kader‑scope sluit de eigen links van de omvattende vorm uit.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Voor dit voorbeeld melden de presentatie‑ en dia‑queries elk drie klik‑containers, twee muis‑over‑containers en drie containers met één van de acties. De tekst‑kader‑query meldt één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) om een actie te interpreteren voordat u de bestemming interpreteert. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) bestrijken meer dan web‑navigatie:

| Values | Meaning for an audit |
| --- | --- |
| `HYPERLINK` | Externe hyperlink; inspecteer de URL en het schema. |
| `JUMP_SPECIFIC_SLIDE` | Interne navigatie naar een specifieke dia. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Ingebouwde diavoorstelling‑navigatie, opgelost in de diavoorstelling‑context. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Beëindig de huidige show of start een aangepaste show. |
| `START_MACRO` | Voer een macro uit. |
| `START_PROGRAM` | Start een programma. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Open een bestand of een andere presentatie; beoordeel apart van web‑URL's. |
| `START_STOP_MEDIA` | Start of stop media‑afspeellijst. |
| `NO_ACTION`, `UNKNOWN` | Geen navigatie‑actie, of een niet‑herkende actie die beoordeling behoeft. |

Lees externe bestemmingen van [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) en specifieke interne bestemmingen van [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Interne acties en ingebouwde commando's kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) wanneer deze verschilt van de genormaliseerde URL, en neem de [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) op wanneer beschikbaar.

### **Rapport, saneren en verifiëren van hyperlinks**

Het volgende Python‑voorbeeld leest een bestaande presentatie (gebruik het hierboven gemaakte bestand), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent het opnieuw om beide activeringstypen opnieuw te controleren. Het verzamelt containers voordat deze worden gewijzigd en vraagt elke dia‑scope één keer op om dubbele verwerking te vermijden. Presentatie‑queries bestrijken gewone dia's; voor een pakkende inventaris vraagt het voorbeeld gewone dia's, masters, lay-outs, notities en de notitie‑ en handout‑masters op wanneer aanwezig.

Het rapport registreert een één‑gebaseerde dia‑index en [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) indien beschikbaar. De verzamelaar behoudt de eigende dia en scope naast elke geretourneerde container. Masters, lay-outs en notities hebben geen gewone dia‑index en worden geïdentificeerd op basis van hun scope. Vorm‑containers en tekst‑deel‑opmaak‑containers worden apart gelabeld; andere containertypen behouden hun runtime‑type‑naam. Elke container krijgt een rapport‑lokale ID zodat de twee acties met elkaar kunnen worden gecorreleerd.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL's en geldige interne dia‑doelen toe. Het wijst macro's, programma's, bestandsacties, andere diavoorstelling‑acties, onbekende acties en andere URL‑schema's af. Deze afwijzingen zijn beleidsbeslissingen, geen veiligheidsoordeel van Aspose.Slides. Alleen HTTPS biedt geen vertrouwen: voeg host‑toegestane lijsten en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL's worden gecontroleerd. Het voorbeeld controleert metadata zonder de koppelingen te volgen of acties uit te voeren.

Voor correctie ondersteunt de [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) van de container [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) en [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muis‑over‑acties worden onafhankelijk verwijderd. Stel `replace_external_clicks` in op `False` om alle beleids­schendingen te verwijderen. Kies een door de toepassing beheerde vervangingspagina vóór uitrol.

De export‑vlag van het rapport gebruikt een conservatief PDF‑review‑beleid: markeer muis‑over‑acties en alles behalve een externe link of een specifieke dia‑sprong als potentieel niet‑ondersteund. Het is een controle‑hint, geen capaciteits‑test of garantie dat niet‑gemarkeerde koppelingen de export overleven. Ondersteunde [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/)‑ en [HTML](/slides/nl/python-net/convert-powerpoint-to-html/)‑exports kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster‑[images](/slides/nl/python-net/convert-powerpoint-to-png/) en [video](/slides/nl/python-net/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie bij het auditten voor die uitvoer.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Vraag elke dia‑scope één keer op, bewaar de eigenaar bij elke container.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestands‑mouse‑over‑link en macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL doorloopt ook de vervangings‑tak. Een container met een toegestane klik en een verboden muis‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), die beide activeringstypen in het geselecteerde bereik verwijdert, ongeacht het beleid. Verificatie hier controleert alleen hyperlink‑acties; het verwijdert geen ingesloten VBA‑projecten, OLE‑objecten of andere actieve inhoud, en het valideert geen geëxporteerd PDF‑ of HTML‑bestand.

## **Veelgestelde vragen**

**Hoe kan ik een link naar een sectie of de eerste dia ervan maken?**

Secties in PowerPoint groeperen dia's, maar een interne hyperlink richt zich op een individuele dia. Om navigatie naar een sectie te creëren, linkt u naar de eerste dia in die sectie.

**Kan ik een hyperlink aan elementen van de master‑dia koppelen zodat deze op alle dia's werkt?**

Ja. Elementen van de master‑dia en lay‑out ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia's die de overeenkomstige master of lay‑out gebruiken.

**Worden hyperlinks behouden bij het exporteren naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de exportoverwegingen in [Rapport, saneren en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).