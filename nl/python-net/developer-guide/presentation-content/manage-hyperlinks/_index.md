---
title: Beheer presentatiehyperlinks in Python
linktitle: Beheer hyperlinks
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
- texthyperlink
- diahyperlink
- vormhyperlink
- afbeeldinghyperlink
- videohyperlink
- wijzigbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Voeg hyperlinks toe, formatteer, werk ze bij en verwijder ze in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET, met Python‑voorbeelden."
---
## **Introductie**

Een hyperlink verbindt presentatietekst met een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks doorgaans twee doelen:

* Open een website vanuit tekst, een vorm of een mediaraam.
* Navigeer naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for Python via .NET stelt je in staat deze links toe te voegen, hun weergave en geluid te regelen, hun eigenschappen bij te werken en ze te verwijderen. De onderstaande voorbeelden laten zien hoe je met hyperlinks werkt op individuele elementen en hoe je hyperlinks benadert op presentatie-, dia- of tekstvakniveau.

{{% alert color="info" title="Note" %}}
U kunt presentaties ook bewerken met de [gratis online Aspose PowerPoint-editor](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **URL-hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediaraam. Het element waaraan u de hyperlink toewijst bepaalt het klikbare gebied: een tekstdelen koppelt de geselecteerde tekst, terwijl een vorm of frame het dia‑object koppelt.

Voor presentaties met relatieve hyperlinks, zie [Hyperlinkbasis beheren](/slides/nl/python-net/presentation-properties/#manage-the-hyperlink-base) om de document‑niveau basis te lezen, wijzigen of wissen.

### **URL-hyperlinks aan tekst toevoegen**

Om tekst aan een website te koppelen, wijs een [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) toe aan de [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) eigenschap van het tekstdelen, zoals hieronder getoond. Alleen dat tekstgedeelte wordt klikbaar.

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

### **URL-hyperlinks aan vormen en mediaraamwerken toevoegen**

Ken een URL toe aan de [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) eigenschap van het rechthoek, zodat het gehele gebied klikbaar wordt. De [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) geeft lezers een hint over de bestemming wanneer ze over het rechthoekje zweven. Dezelfde eigenschappen gelden voor afbeelding-, audio- en videoraamwerken.

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

U kunt de kleur van gekoppelde tekst wijzigen, een geluid afspelen of stoppen wanneer een lezer een link activeert, en de tooltip instellen die verschijnt bij het zweven.

### **Kleur**

De [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) eigenschap van [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) bepaalt of een hyperlink de hyperlinkkleur van de presentatie of de opmaak van het tekstdelen gebruikt. Om een aangepaste tekstkleur toe te passen, selecteer [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) en stel de opvulkleur van het gedeelte in. Deze functie is geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

In dit voorbeeld zorgt het instellen van [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) op de eerste link ervoor dat de tekst rood wordt weergegeven. De tweede link behoudt de hyperlinkkleur van de presentatie.

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

Een hyperlink kan een geluid afspelen wanneer het geactiveerd wordt of een al afspelend geluid stoppen. Gebruik de volgende eigenschappen om dit gedrag te configureren:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Geluid aan hyperlink toevoegen**

De knop op de eerste dia gebruikt [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) om audio uit een WAV‑bestand af te spelen wanneer de lezer klikt om door te gaan. Op de tweede dia gebruikt een aparte knop [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) om de weergave te stoppen en de lezer op die dia te houden.

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

#### **Geluid van hyperlink extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest de hyperlink‑audio van de eerste vorm in het geheugen via [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) en [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

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

### **Tooltip- en interactiesettings**

U kunt de volgende [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) eigenschappen bijwerken nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) stelt de tekst in die een kijker kan weergeven als hint voor de link.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) specificeert het doelraam binnen een ouder‑HTML‑frameset, indien van toepassing.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) bepaalt of het activeren van de link de bestemming aan de lijst van bekeken hyperlinks toevoegt.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) bepaalt of de hyperlink wordt gemarkeerd wanneer erop wordt geklikt.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) om hyperlink‑containers te verzamelen, inclusief tekstgedeellinks, voordat u ze wijzigt. Het volgende voorbeeld verwijdert beide activeringstypen van de eerste dia. Om slechts één type te verwijderen, roep alleen [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) of [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) aan; het verwijderen van een klikactie verwijdert niet de bijbehorende muis‑over‑actie.

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

Voor onvoorwaardelijke verwijdering verwijdert [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) beide activeringstypen in de geselecteerde scope in één oproep. Voor selectieve opschoning en dekking van masters, lay‑outs en notities, zie [Rapport, opschonen en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Hyperlinks wissen vóór het vervangen van SmartArt‑tekst**

Wanneer u een alinea in een bestaande SmartArt‑knoop vervangt, kan het wissen van de tekstgedeelten een oude hyperlink in stand houden. Haal de alinea op via [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/). Voordat u de gedeelten wist, roep [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) aan via [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) op het tekstvak van de knoopvorm die de alinea weergeeft. Dit verwijdert elke hyperlink in dat frame, inclusief links in andere alinea's.

In `SmartArtHyperlink.pptx` is de derde vorm op de eerste dia een SmartArt‑grafiek. Het voorbeeld vervangt de eerste alinea van de vierde knoop. In deze presentatie toont de eerste vorm van de knoop die alinea.

Nadat beide gedeelten zijn toegevoegd, leest het voorbeeld hun effectieve opmaak met [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). De effectieve [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) eigenschap retourneert de nieuwe hyperlink voor het eerste gedeelte en `None` voor het tweede.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **Een volledige hyperlink‑inventaris opbouwen**

Voordat u een presentatie distribueert, maakt u een inventaris op van de interactieve acties en web‑links. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) retourneert [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) objecten, niet een platte lijst van URL‑strings. Inspecteer zowel [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) als [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties bevatten, dus een volledig rapport heeft tot twee rijen per container nodig.

Alleen hyperlinks op vormniveau scannen kan links die aan tekstgedeelten zijn gekoppeld missen. Vraag in plaats daarvan de juiste scope op, en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie-, dia- en tekstvak‑scopes opvragen**

De [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) klasse is beschikbaar via [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) en [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Elke scope ondersteunt dezelfde queries:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) retourneert containers met een klikactie.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) retourneert containers met een muis‑over‑actie.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) retourneert containers met een van beide of beide acties.

Dit voorbeeld kent klik‑ en muis‑over‑acties toe aan een vorm en de tekst daarvan, en een macro‑actie aan een aparte knop. Het vergelijkt de containers die door [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) worden geretourneerd met de aantallen per activeringstype. Een tekstvak‑query telt alleen links in de tekst. De eigen acties van de omvattende vorm verschijnen in de dia‑ en presentatie‑queries.

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

Voor dit voorbeeld rapporteren presentatie‑ en dia‑queries elk drie klik‑containers, twee muis‑over‑containers en drie containers met een van beide acties. De tekstvak‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) om een actie te interpreteren voordat u de bestemming interpreteert. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) omvatten meer dan webnavigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `HYPERLINK` | Externe hyperlink; inspecteer de URL en het schema. |
| `JUMP_SPECIFIC_SLIDE` | Interne navigatie naar een specifieke dia. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Ingebouwde diavoorstellingsnavigatie, opgelost in de diavoorstellingscontext. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Beëindig de huidige show of start een aangepaste show. |
| `START_MACRO` | Voer een macro uit. |
| `START_PROGRAM` | Start een programma. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Open een bestand of een andere presentatie; beoordeel afzonderlijk van web‑URLs. |
| `START_STOP_MEDIA` | Start of stop mediaplayback. |
| `NO_ACTION`, `UNKNOWN` | Geen navigatie‑actie, of een niet‑herkende actie die beoordeling vereist. |

Lees externe bestemmingen uit [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) en specifieke interne bestemmingen uit [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Interne acties en ingebouwde commando's kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) wanneer deze verschilt van de genormaliseerde URL, en voeg de [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) toe wanneer beschikbaar.

### **Rapport, opschonen en verifiëren van hyperlinks**

Dit voorbeeld opent de presentatie uit het voorgaande voorbeeld en schrijft één JSON‑record per actie. Het gebruikt [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) om containers op gewone dia's, masters, lay‑outs en notities te verzamelen, inclusief de notitie‑ en handout‑masters wanneer aanwezig. Het vraagt elke scope één keer op om dubbele verwerking te voorkomen, past het hieronder beschreven beleid toe, en opent de opgeslagen presentatie opnieuw om zowel klik‑ als muis‑over‑acties te controleren.

Het rapport registreert een één‑gebaseerde dia‑index en [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) waar beschikbaar. De verzamelaar behoudt de eigenaar‑dia en scope naast elke geretourneerde container. Masters, lay‑outs en notities hebben geen gewone dia‑index en worden geïdentificeerd aan de hand van hun scope. Vormcontainers en tekst‑gedeeltes‑opmaakcontainers worden apart gelabeld; andere containertypen behouden hun runtime‑type‑naam. Elke container krijgt een rapport‑lokale ID zodat zijn twee acties kunnen worden gecorreleerd.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het wijst macro’s, programma’s, bestandsacties, andere diavoorstellingsacties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleidsbeslissingen, geen veiligheidsbeoordeling van Aspose.Slides. Alleen HTTPS garandeert geen vertrouwen: voeg host‑allowlists en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor correctie ondersteunt de [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) van de container [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) en [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Hier worden verboden externe kliklinks vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muis‑over‑acties worden onafhankelijk verwijderd. Stel `replace_external_clicks` in op `False` om alle beleids‑schendingen te verwijderen. Kies een door de toepassing beheerde vervangingspagina vóór implementatie.

De export‑vlag van het rapport hanteert een conservatief PDF‑reviewbeleid: markeer muis‑over‑acties en alles anders dan een externe link of een specifieke dia‑sprong als potentieel niet‑ondersteund. Het is een aanwijzing voor review, geen capaciteitstest of garantie dat niet‑gemarkeerde links de export overleven. Ondersteunde [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/python-net/convert-powerpoint-to-html/) exports kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster‑[images](/slides/nl/python-net/convert-powerpoint-to-png/) en [video](/slides/nl/python-net/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie bij het auditen voor die uitvoerformaten.

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
    # Vraag elke dia-scope één keer op, en bewaar de eigenaar bij elke container.
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

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De muis‑over‑link van het bestand en de macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL test ook de vervangings‑tak. Een container met een toegestane klik en een verboden muis‑over behoudt zijn klikactie.

Deze selectieve opschoning verschilt van [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), die beide activeringstypen in de geselecteerde scope verwijdert, ongeacht het beleid. Verificatie hier controleert alleen hyperlink‑acties; het verwijdert geen ingesloten VBA‑projecten, OLE‑objecten of andere actieve content, en het valideert geen geëxporteerd PDF‑ of HTML‑bestand.

## **FAQ**

**Hoe kan ik linken naar een sectie of de eerste dia ervan?**

Secties in PowerPoint groeperen dia's, maar een interne hyperlink richt zich op een individuele dia. Om navigatie naar een sectie te maken, link je naar de eerste dia in die sectie.

**Kan ik een hyperlink aan masterdia‑elementen koppelen zodat deze op alle dia's werkt?**

Ja. Masterdia‑ en lay‑outelementen ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia's die de betreffende master of lay‑out gebruiken.

**Worden hyperlinks behouden bij het exporteren naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de export­overwegingen in [Rapport, opschonen en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).