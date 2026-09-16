---
title: Beheer presentatiehyperlinks in Python via Java
linktitle: Beheer hyperlinks
type: docs
weight: 20
url: /nl/python-java/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- teksthyperlink
- diahyperlink
- vormhyperlink
- afbeeldinghyperlink
- videohyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Voeg hyperlinks toe, formatteer, werk bij en verwijder hyperlinks in PowerPoint en OpenDocument presentaties met Aspose.Slides voor Python via Java, met Python voorbeelden."
---
## **Introductie**

Een hyperlink koppelt presentatiewaarde aan een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks doorgaans twee doelen:

* Een website openen vanuit tekst, een vorm of een mediaframe.
* Naar een andere dia navigeren, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for Python via Java laat u deze koppelingen toevoegen, hun uiterlijk en geluid regelen, hun eigenschappen bijwerken en ze verwijderen. De voorbeelden hieronder laten zien hoe u met hyperlinks werkt op afzonderlijke elementen en hoe u hyperlinks benadert op presentatieniveau, diavlak of tekstframe‑niveau.

{{% alert color="info" title="Opmerking" %}}

U kunt presentaties ook bewerken met de [gratis online Aspose PowerPoint‑editor](https://products.aspose.app/slides/nl/editor).

{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediaframe. Het element waaraan u de hyperlink toewijst bepaalt het klikbare gebied: een tekstdeel koppelt de geselecteerde tekst, terwijl een vorm of frame het dia‑object koppelt.

### **URL‑hyperlinks toevoegen aan tekst**

Om tekst aan een website te koppelen, geeft u een [Hyperlink](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/) door aan de [setHyperlinkClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#setHyperlinkClick)‑methode van het tekstdeel, zoals hieronder weergegeven. Alleen dat tekstdeel wordt klikbaar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **URL‑hyperlinks toevoegen aan vormen en mediaframes**

Om een vorm of frame klikbaar te maken, roept u de [setHyperlinkClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setHyperlinkClick)‑methode aan. De hyperlink behoort tot het object zelf in plaats van tot een tekstdeel erin.

Dezelfde aanpak geldt voor afbeelding‑, audio‑ en videoframes: wijs de hyperlink toe aan het frame en roep [setTooltip](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setTooltip) aan indien nodig.

Het volgende voorbeeld maakt een rechthoek klikbaar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Interne hyperlinks laten lezers van een inhoudsopgave naar een specifieke dia springen. Het volgende voorbeeld gebruikt [setInternalHyperlinkClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) om de tekst “Page 2” op de eerste dia te koppelen aan de tweede dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hyperlinks opmaken**

### **Kleur**

De [setColorSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setColorSource)‑methode van [Hyperlink](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/) bepaalt of een hyperlink de hyperlink‑kleur van de presentatie of de opmaak van het tekstdeel gebruikt. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkcolorsource/) en stelt u de vulkleur van het deel in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekshyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstvulling, terwijl de tweede de standaard hyperlink‑kleur behoudt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Geluid**

Een hyperlink kan een geluid afspelen bij activering of een al afspelend geluid stoppen. Gebruik de volgende methoden om dit gedrag te configureren:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setSound) specificeert het audio dat aan de hyperlink is gekoppeld.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Een hyperlinkgeluid toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Het klikken op de knop speelt het geluid af en navigeert naar de volgende dia. Een tweede vorm op die dia stopt het vorige geluid bij klikken, zonder een navigatie‑actie uit te voeren.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Een hyperlinkgeluid extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest het audio‑bestand van de eerste vorm‑hyperlink in het geheugen via [getSound](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#getSound) en [getBinaryData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Tooltip‑ en interactie‑instellingen**

U kunt de volgende [Hyperlink](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/)‑methoden aanroepen nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [setTooltip](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setTooltip) stelt de tekst in die een kijker als hint voor de link kan weergeven.
- [setTargetFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setTargetFrame) specificeert het doelframe binnen een bovenliggend HTML‑frameset, indien van toepassing.
- [setHistory](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setHistory) bepaalt of het activeren van de link de bestemming toevoegt aan de lijst van bekeken hyperlinks.
- [setHighlightClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#setHighlightClick) bepaalt of de hyperlink wordt gemarkeerd bij klikken.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [getAnyHyperlinks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) om hyperlink‑containers, inclusief tekstdeel‑links, te verzamelen vóór wijziging. Het volgende voorbeeld verwijdert beide activeringssoorten van de eerste dia. Om slechts één type te verwijderen, roep alleen [removeHyperlinkClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) of [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) aan; het verwijderen van een klik‑actie verwijdert de muis‑over‑tegenhanger niet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Voor onvoorwaardelijke verwijdering verwijdert [removeAllHyperlinks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) beide activeringssoorten in de geselecteerde scope in één oproep. Voor selectieve opschoning en dekking van masters, layouts en notities, zie [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlinkinventaris opstellen**

Voordat u een presentatie distribueert, inventariseert u de interactieve acties evenals de web‑koppelingen. [getAnyHyperlinks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) retourneert hyperlink‑containers, zoals [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/)‑ en [PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/)‑objecten, niet een platte lijst van URL‑strings. Inspecteer zowel [getHyperlinkClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getHyperlinkClick) als [getHyperlinkMouseOver](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getHyperlinkMouseOver) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties exposeren, dus een volledig rapport kan tot twee rijen per container nodig hebben.

Het scannen van alleen hyperlinks op vormniveau kan links missen die aan tekstdelen zijn gekoppeld. Vraag in plaats daarvan de juiste scope op en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie-, dia- en tekstframe‑scope opvragen**

De [HyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/)‑klasse is beschikbaar via [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getHyperlinkQueries) en [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getHyperlinkQueries). Elke scope ondersteunt dezelfde queries:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) geeft containers met een klik‑actie.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) geeft containers met een muis‑over‑actie.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) geeft containers met één of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` met een externe klik‑link, een bestands‑muisknop‑link, interne dia‑navigatie, een tekst‑muisknop‑link en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie queries werken op elke scope; de tellingen geven containers weer, niet het totale aantal acties. De tekstframe‑scope sluit de eigen links van de omvattende vorm uit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Voor dit voorbeeld rapporteren presentatie‑ en dia‑queries elk drie klik‑containers, twee muis‑over‑containers en drie containers met één van beide acties. De tekstframe‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [Hyperlink.getActionType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#getActionType) om een actie te interpreteren voordat u de bestemming interpreteert. De waardes van [HyperlinkActionType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkactiontype/) omvatten meer dan alleen web‑navigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; controleer de URL en het schema. |
| `JumpSpecificSlide` | Interne navigatie naar een bepaalde dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstelling‑navigatie, opgelost in de diavoorstelling‑context. |
| `JumpEndShow`, `StartCustomSlideShow` | Huidige show beëindigen of een aangepaste show starten. |
| `StartMacro` | Een macro uitvoeren. |
| `StartProgram` | Een programma starten. |
| `OpenFile`, `OpenPresentation` | Een bestand of een andere presentatie openen; apart beoordelen van web‑URL’s. |
| `StartStopMedia` | Media‑afspeelmoraal starten of stoppen. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die beoordeling vereist. |

Lees externe bestemmingen via [getExternalUrl](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#getExternalUrl) en specifieke interne bestemmingen via [getTargetSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#getTargetSlide). Interne acties en ingebouwde commando’s kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar de waarde van [getExternalUrlOriginal](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) wanneer die verschilt van de genormaliseerde URL, en neem de tooltip van [getTooltip](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlink/#getTooltip) op wanneer beschikbaar.

### **Hyperlinks rapporteren, saneren en verifiëren**

Het volgende Python‑voorbeeld leest een bestaande presentatie (gebruik het bestand dat hierboven is aangemaakt), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent het opnieuw om beide activeringssoorten opnieuw te controleren. Het verzamelt containers vóór wijziging en gebruikt referentie‑gelijkheid om te voorkomen dat dezelfde container tweemaal wordt verwerkt. Presentatie‑queries omvatten gewone dia’s; voor een pakketinventaris vraagt het expliciet ook masters, layouts, notities en de notitie‑ en handout‑masters op wanneer aanwezig.

Het rapport registreert een één‑gebaseerde dia‑index en [getSlideId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getSlideId) waar beschikbaar. [getSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getSlide) levert de eigenaar‑dia voor ondersteunde containers. Masters, layouts en notities hebben geen gewone dia‑index en worden geïdentificeerd door hun scope. Vorm‑containers en tekst‑deel‑opmaak‑containers worden apart gelabeld; andere containertypen behouden hun runtime‑typenaam. Elke container krijgt een rapport‑lokale ID zodat de twee acties kunnen worden gecorreleerd. Het rapport slaat actietypen op als de gehele constante waarden gedefinieerd door de Java‑enumeratie.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het wijst macro’s, programma’s, bestand‑acties, andere diavoorstelling‑acties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleidsbeslissingen, geen veiligheidsoordeel van Aspose.Slides. Alleen HTTPS garandeert geen vertrouwen: voeg host‑allowlists en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor correctie ondersteunt de [getHyperlinkManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getHyperlinkManager) van de container [setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) en [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muis‑over‑acties worden onafhankelijk verwijderd. Stel `replace_external_clicks` in op `False` om alle beleids­schendingen te verwijderen. Kies een door de toepassing beheerde vervangingspagina vóór uitrol.

De export‑vlag van het rapport hanteert een conservatief PDF‑review‑beleid: markeer muis‑over‑acties en alles anders dan een externe link of een specifieke dia‑sprong als mogelijk niet‑ondersteund. Het is een review‑hint, geen capaciteits‑test of garantie dat niet‑gemarkeerde links de export overleven. Ondersteunde [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/)‑ en [HTML](/slides/nl/python-java/convert-powerpoint-to-html/)‑exports kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster‑[images](/slides/nl/python-java/convert-powerpoint-to-png/) en [video](/slides/nl/python-java/convert-powerpoint-to-video/) kunnen interactieve hyperlinks niet behouden; markeer elke actie bij audit voor die outputs.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestands‑muisknop‑link en de macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie blijven. De verificatie toont nul verboden acties. Een invoer met een verboden externe klik‑URL laat ook de vervangings­tak zien. Een container met een toegestane klik en een verboden muis‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [removeAllHyperlinks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), dat beide activeringssoorten overal in de geselecteerde scope verwijdert ongeacht beleid. Verificatie controleert hier alleen hyperlink‑acties; het verwijdert geen ingesloten VBA‑projecten, OLE‑objecten of andere actieve inhoud, en het valideert geen geëxporteerd PDF‑ of HTML‑bestand.

## **FAQ**

**Hoe kan ik naar een sectie of de eerste dia ervan linken?**

Secties in PowerPoint groeperen dia’s, maar een interne hyperlink richt zich op een individuele dia. Om naar een sectie te navigeren, linkt u naar de eerste dia van die sectie.

**Kan ik een hyperlink aan elementen van de master‑dia koppelen zodat deze op alle dia’s werkt?**

Ja. Elementen van de master‑dia en lay‑out ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia’s die de betreffende master of lay‑out gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de export‑overwegingen in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).