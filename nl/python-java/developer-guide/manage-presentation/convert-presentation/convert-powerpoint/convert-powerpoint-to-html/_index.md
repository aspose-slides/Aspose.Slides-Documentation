---
title: PowerPoint-presentaties converteren naar HTML in Python via Java
linktitle: PowerPoint naar HTML
type: docs
weight: 30
url: /nl/python-java/convert-powerpoint-to-html/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar HTML
- presentatie naar HTML
- dia naar HTML
- PPT naar HTML
- PPTX naar HTML
- PowerPoint opslaan als HTML
- presentatie opslaan als HTML
- dia opslaan als HTML
- PPT opslaan als HTML
- PPTX opslaan als HTML
- PPT exporteren naar HTML
- PPTX exporteren naar HTML
- Python
- Java
- Aspose.Slides
description: "PowerPoint-presentaties converteren naar HTML in Python via Java. Gebruik Aspose.Slides om PPT- en PPTX-bestanden, geselecteerde dia's, notities, lettertypen, afbeeldingen, SVG en media te exporteren."
---
## **Overzicht**

Aspose.Slides voor Python via Java kan PowerPoint‑presentaties opslaan als HTML zonder Microsoft PowerPoint. De basisconversie bestaat uit een enkele [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑load en een [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑aanroep met [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/). Gebruik [HtmlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/) wanneer je de geëxporteerde lay-out, lettertypen, afbeeldingen, notities, opmerkingen, SVG‑output of gekoppelde bronnen moet beheersen.

Deze handleiding richt zich op praktische HTML‑exportscenario’s:

- Exporteer een volledige presentatie of geselecteerde dia's.  
- Genereer HTML met vaste lay‑out, responsief of op SVG gebaseerd.  
- Neem presentatornotities en opmerkingen op.  
- Beheer de beeldkwaliteit en bijgesneden afbeeldingsdata.  
- Integreer lettertypen of sla lettertypebestanden apart op.  
- Kies hoe externe bronnen en mediabestanden worden weggeschreven en waarnaar wordt verwezen.

Standaard produceert HTML‑export een zelf‑containende HTML‑document waarbij de meeste bronnen zijn ingebed. Dit is handig om één bestand te delen, maar kan de bestandsgrootte vergroten. Voor publicatie op het web kun je externe bronnen overwegen, een lagere DPI voor afbeeldingen gebruiken en alleen lettertypen insluiten die niet betrouwbaar beschikbaar zijn in de doelomgeving.

## **Converteer een presentatie naar HTML**

Om een presentatie naar HTML te exporteren, laad je deze met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) en sla je deze op met [SaveFormat.Html](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Elk voorbeeld laadt `presentation.pptx` vanuit de huidige werkmap. Installeer Aspose.Slides voor Python via Java en een compatibele Java‑runtime voordat je het script uitvoert. De JVM wordt één keer per Python‑proces gestart.

Dit voorbeeld schrijft één HTML‑bestand. Het presentatie‑object wordt in het `finally`‑blok vrijgegeven, waardoor bestands‑handles en rendering‑bronnen na de export worden vrijgemaakt.

## **Configureer HTML‑export**

[HtmlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/) is de belangrijkste configuratie‑klasse voor HTML‑export. Veelgebruikte instellingen omvatten:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): voegt notities, opmerkingen, hand-outs of andere lay‑outinformatie toe.  
- [setHtmlFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setHtmlFormatter): verandert de HTML‑documentstructuur of delegeert opmaak naar een controller.  
- [setSlideImageFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSlideImageFormat): bepaalt hoe dia's worden weergegeven, bijvoorbeeld als SVG.  
- [setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setPicturesCompression): beheert de DPI van afbeeldingen en de grootte van de output.  
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): houdt bijgesneden afbeeldingsdata al dan niet bij.  
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): laat geëxporteerde SVG‑inhoud zich aanpassen aan de container.  
- [setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): neemt verborgen dia's op wanneer dat nodig is.

De volgende secties tonen de meest voorkomende opties afzonderlijk, zodat je alleen die kunt combineren die jouw workflow vereist.

## **Converteer geselecteerde dia's naar HTML**

De [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑overload die dia‑nummers accepteert, gebruikt 1‑gebaseerde posities. De onderstaande lus slaat elke dia op in een apart HTML‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Gebruik dit patroon wanneer een website of applicatie één HTML‑pagina per dia nodig heeft. Als elke dia dezelfde lay‑out moet hebben, maak dan één [HtmlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/)‑instantie aan en geef deze door aan elke [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑aanroep.

## **Maak responsieve HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/nl/python-java/aspose.slides/responsivehtmlcontroller/) levert responsieve HTML‑output via [HtmlFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmlformatter/). Gebruik dit wanneer de geëxporteerde pagina beter moet aanpassen aan de breedte van de browser.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Voor een op SVG gebaseerde responsieve lay‑out roep je [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) aan met `True`. Dit is nuttig wanneer de inhoud van de dia wordt geëxporteerd als schaalbare SVG‑markup.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Neem presentatornotities en opmerkingen op**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/) via [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) om presentatornotities of opmerkingen op te nemen. Notities en opmerkingen zijn standaard verborgen tenzij je hun posities opgeeft.

Stel dat de bronpresentatie presentatornotities bevat:

![Slide met presentatornotities in PowerPoint](slide_with_notes.png)

De volgende code exporteert de dia‑inhoud met presentatornotities onder de dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

De geëxporteerde HTML bevat het notitie‑gebied:

![HTML‑output met de dia en presentatornotities](HTML_with_notes.png)

Om opmerkingen te exporteren, roep je [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) aan, bijvoorbeeld met [CommentsPositions.Right](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentspositions/#Right) of [CommentsPositions.Bottom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentspositions/#Bottom). Als je alleen opmerkingen nodig hebt, laat je [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) weg. Als je zowel notities als opmerkingen wilt, roep je beide methoden aan.

## **Beheer beeldkwaliteit en bijgesneden gebieden**

HTML‑export kan dia‑afbeeldingen comprimeren om de output‑grootte te verkleinen. Geef een waarde door aan [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setPicturesCompression) uit [PicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturescompression/) wanneer je hogere beeldkwaliteit nodig hebt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Standaard kunnen bijgesneden delen van afbeeldingen uit de geëxporteerde output worden verwijderd. Houd bijgesneden data alleen wanneer gebruikers deze verborgen afbeeldingsdelen moeten kunnen herstellen of inspecteren. Het behouden hiervan kan de HTML‑grootte vergroten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Voeg CSS toe**

Voor eenvoudige styling kun je een CSS‑string doorgeven aan [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Hiermee wijzig je het omringende HTML‑document terwijl Aspose.Slides de dia‑inhoud blijft renderen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Voor een aangepaste document‑header, een gekoppeld CSS‑bestand of aangepaste markup rond dia’s en vormen, gebruik je een aangepaste opmaak‑controller via een JPype‑interface‑proxy en geef je deze door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmlformatter/) met [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Integreer lettertypen**

Als de doelomgeving de lettertypen van de presentatie mogelijk niet geïnstalleerd heeft, kun je lettertypen in de HTML insluiten met [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/python-java/aspose.slides/embedallfontshtmlcontroller/). Insluiten verbetert de visuele getrouwheid maar vergroot de bestandsgrootte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Sluit alleen lettertypen uit wanneer je zeker bent dat de doel‑browsers of -systemen deze al leveren. Voor merk‑lettertypen of minder gangbare lettertypen is insluiten doorgaans veiliger.

## **Sla bronnen extern op**

Zelf‑containende HTML is gemakkelijk te verplaatsen, maar ingebedde Base64‑bronnen kunnen het bestand groot maken. Als je applicatie externe afbeeldingsbestanden nodig heeft, implementeer dan een resource‑linking‑controller via een JPype‑interface‑proxy en geef deze door aan de [HtmlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/)‑constructor.

Wanneer je bronnen externaliseert, kies je twee paden bewust:

- Het besturingssysteem‑outputpad, waar je applicatie gegenereerde afbeeldingen, lettertypen, audio‑ of videobestanden wegschrijft.  
- Het URL‑pad, dat de browser gebruikt vanuit het HTML‑document om die bestanden te laden.

## **Exporteer mediabestanden**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoplayerhtmlcontroller/) exporteert video‑ en audiobestanden en schrijft HTML die ze in een browser kan afspelen. De constructor neemt:

- `path`: de map waarin gegenereerde mediabestanden worden weggeschreven.  
- `fileName`: de naam van het te genereren HTML‑bestand.  
- `baseUri`: het absolute URI‑voorvoegsel dat in de HTML‑links naar mediabestanden wordt gebruikt.

Het volgende voorbeeld exporteert media die al in `presentation.pptx` zijn ingebed. Het gegenereerde HTML‑document verwijst naar mediabestanden uitsluitend via bestandsnaam, relatief ten opzichte van het HTML‑document, dus `path` moet de map zijn die ook het HTML‑bestand ontvangt. `baseUri` moet een absolute URI zijn: voor lokaal voorvertonen bouw je een `file:///`‑URI vanuit de output‑map; voor een gedeployde applicatie gebruik je de absolute URL van de gepubliceerde map.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Gebruik output‑mappen die uniek zijn per export‑taak, vooral in server‑applicaties. Gedeelde output‑paden kunnen ertoe leiden dat bestanden van verschillende conversies elkaar overschrijven.

## **Prestaties en resource‑beheer**

HTML‑conversie is een render‑operatie, dus verwerkingstijd en geheugenverbruik hangen af van het aantal dia’s, de resolutie van afbeeldingen, lettertypen, effecten, grafieken en ingebedde media. Hogere DPI‑waarden die aan [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setPicturesCompression) worden doorgegeven, ingesloten lettertypen, SVG‑output en behouden bijgesneden afbeeldingsgebieden kunnen de getrouwheid verbeteren maar vergroten doorgaans de output‑grootte.

Voor batch‑conversie:

- Maak elke [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie direct vrij.  
- Gebruik aparte uitvoermappen voor afzonderlijke taken.  
- Vermijd het insluiten van algemene lettertypen tenzij de nauwkeurigheid dit vereist.  
- Verlaag de DPI van afbeeldingen wanneer de HTML alleen voor een voorbeeld of thumbnails wordt gebruikt.  
- Bewaar de bronpresentatie, gegenereerde HTML en externe bronnen samen totdat de definitieve deploy‑paden bekend zijn.

## **FAQ**

**Worden hyperlinks behouden in de HTML-uitvoer?**  
Ja. Hyperlinks in de presentatie worden geëxporteerd naar HTML en blijven klikbaar wanneer de doel‑URL geldig is.

**Kan ik presentaties parallel naar HTML converteren?**  
Ja, maar deel geen enkele [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie tussen threads. Verwerk verschillende bestanden met gescheiden presentatie‑instanties, streams en uitvoermappen. Zie de [multithreading guidance](/slides/nl/python-java/multithreading/) voor details.

**Is een presentatie‑object thread‑safe?**  
Nee. Een enkel [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object moet worden geladen, bewerkt, opgeslagen en vrijgegeven op één thread. Voor parallel werk maak je per thread of proces een onafhankelijke instantie aan.

**Waarom is het gegenereerde HTML‑bestand groot?**  
De standaardexport kan bronnen direct in de HTML insluiten. Ingesloten lettertypen, afbeeldingen met hoge DPI, media, SVG‑inhoud en behouden bijgesneden afbeeldingsgebieden vergroten de grootte. Gebruik externe bronnen, sluit algemene lettertypen uit en geef een lagere DPI‑waarde door aan [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setPicturesCompression) wanneer een kleinere output belangrijker is dan maximale getrouwheid.

**Waarom kunnen font‑size‑waarden in HTML afwijken van de PowerPoint‑waarden?**  
De geëxporteerde pagina kan SVG‑coördinatensystemen en schalings‑transformaties gebruiken. Een ruwe CSS‑ of SVG‑font‑size‑waarde op zich beschrijft niet de uiteindelijke weergavegrootte. Vergelijk de gerenderde dia op het beoogde zoom‑niveau en controleer de beschikbaarheid van het lettertype wanneer de tekst er anders uitziet.

**Hoe kies ik baseUri voor mediabestandsexport?**  
Kies `baseUri` vanuit het perspectief van de browser en geef het op als een absolute URI. Voor lokaal voorvertonen kun je het afleiden van de output‑map met `output_directory.as_uri() + "/"`. Voor deployment gebruik je de absolute URL van de gepubliceerde map. Het bestandssysteem‑`path` en het browser‑`baseUri` hoeven niet dezelfde tekenreeks te zijn, maar moeten dezelfde locatie beschrijven, en die locatie moet de map zijn die het gegenereerde HTML‑bestand bevat omdat mediakoppelingen relatief ten opzichte daarvan worden geschreven.

**Kan ik verborgen dia's opnemen?**  
Ja. Roep [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) aan met `True` wanneer verborgen dia's moeten worden geëxporteerd.