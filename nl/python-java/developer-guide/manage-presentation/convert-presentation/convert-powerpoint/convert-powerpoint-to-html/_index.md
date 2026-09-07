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
description: "Converteer PowerPoint-presentaties naar HTML in Python via Java. Gebruik Aspose.Slides om PPT- en PPTX-bestanden, geselecteerde dia’s, notities, lettertypen, afbeeldingen, SVG en media te exporteren."
---
## **Overzicht**

Aspose.Slides for Python via Java kan PowerPoint‑presentaties opslaan als HTML zonder Microsoft PowerPoint. De basisconversie bestaat uit één [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑laden en een [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑aanroep met [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/). Gebruik [HtmlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/) wanneer u de geëxporteerde lay-out, lettertypen, afbeeldingen, notities, opmerkingen, SVG‑output of gekoppelde bronnen wilt beheersen.

Deze gids richt zich op praktische HTML‑exportscenario’s:

- Exporteer een volledige presentatie of geselecteerde dia’s.
- Genereer vaste lay‑out, responsieve of SVG‑gebaseerde HTML.
- Neem sprekaantekeningen en opmerkingen op.
- Beheer de beeldkwaliteit en bijgesneden afbeeldingsgegevens.
- Voeg lettertypen in of sla lettertypebestanden apart op.
- Kies hoe externe bronnen en mediabestanden worden weggeschreven en gerefereerd.

Standaard produceert HTML‑export een zelfstandige HTML‑document waarbij de meeste bronnen zijn ingesloten. Dit is handig om één bestand te delen, maar kan de bestandsgrootte vergroten. Voor publicatie op het web, overweeg externe bronnen, een lagere DPI voor afbeeldingen en alleen het insluiten van lettertypen die niet betrouwbaar beschikbaar zijn in de doelomgeving.

## **Converteer een presentatie naar HTML**

Om een presentatie naar HTML te exporteren, laadt u deze met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) en slaat u deze op met [SaveFormat.Html](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Html).

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

Elk voorbeeld laadt `presentation.pptx` uit de huidige werkmap. Installeer Aspose.Slides for Python via Java en een compatibele Java‑runtime voordat u het script uitvoert. De JVM wordt éénmaal per Python‑proces gestart.

Dit voorbeeld schrijft één HTML‑bestand. Het presentatietobject wordt in het `finally`‑blok vrijgegeven, waardoor bestands‑handles en renderresources na de export worden vrijgelaten.

## **Configureer HTML‑export**

[HtmlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/) is de belangrijkste configuratieklasse voor HTML‑export. Veelgebruikte instellingen omvatten:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): voegt notities, opmerkingen, hand-outs of andere lay‑outinformatie toe.
- [setHtmlFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setHtmlFormatter): wijzigt de HTML‑documentstructuur of delegeert formatteren naar een controller.
- [setSlideImageFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSlideImageFormat): wijzigt hoe dia’s worden weergegeven, bijvoorbeeld als SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setPicturesCompression): beheert DPI van afbeeldingen en output‑grootte.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): behoudt of verwijdert bijgesneden afbeeldingsdata.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): laat geëxporteerde SVG‑content zich aanpassen aan de container.
- [setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): neemt verborgen dia’s op wanneer dat vereist is.

De volgende secties tonen de meest voorkomende opties afzonderlijk, zodat u alleen de opties kunt combineren die uw workflow nodig heeft.

## **Converteer geselecteerde dia’s naar HTML**

De [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑overload die diapositioneringen accepteert, gebruikt 1‑gebaseerde dia‑indices. De onderstaande lus slaat elke dia op in een apart HTML‑bestand.

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

[ResponsiveHtmlController](https://reference.aspose.com/slides/nl/python-java/aspose.slides/responsivehtmlcontroller/) levert responsieve HTML‑output via [HtmlFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmlformatter/). Gebruik deze wanneer de geëxporteerde pagina beter moet aanpassen aan de breedte van de browser.

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

Voor een SVG‑gebaseerde responsieve lay‑out, roep [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) aan met `True`. Dit is nuttig wanneer de dia‑inhoud wordt geëxporteerd als schaalbare SVG‑markup.

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

## **Neem sprekaantekeningen en opmerkingen op**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/) via [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) om sprekaantekeningen of opmerkingen op te nemen. Notities en opmerkingen zijn standaard verborgen tenzij u hun posities specificeert.

Stel dat de bronpresentatie sprekaantekeningen bevat:

![Dia met sprekaantekeningen in PowerPoint](slide_with_notes.png)

De volgende code exporteert de dia‑inhoud met sprekaantekeningen onder de dia.

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

De geëxporteerde HTML bevat het notitiegebied:

![HTML‑output met de dia en sprekaantekeningen](HTML_with_notes.png)

Om opmerkingen te exporteren, roep [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) aan, bijvoorbeeld met [CommentsPositions.Right](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentspositions/#Right) of [CommentsPositions.Bottom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentspositions/#Bottom). Als u alleen opmerkingen nodig hebt, laat dan [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) weg. Als u zowel notities als opmerkingen wilt, roep dan beide methoden aan.

## **Beheer beeldkwaliteit en bijgesneden gebieden**

HTML‑export kan dia‑afbeeldingen comprimeren om de output‑grootte te verkleinen. Geef een waarde door aan [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setPicturesCompression) vanuit [PicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturescompression/) wanneer u een hogere beeldkwaliteit nodig heeft.

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

Standaard kunnen bijgesneden gebieden van afbeeldingen worden verwijderd uit de geëxporteerde output. Houd bijgesneden data alleen wanneer gebruikers deze verborgen afbeeldingsdelen moeten kunnen herstellen of inspecteren. Het behouden hiervan kan de HTML‑grootte vergroten.

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

Voor eenvoudige styling, geef een CSS‑string door aan [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Dit wijzigt het omringende HTML‑document terwijl Aspose.Slides de dia‑inhoud blijft renderen.

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

Voor een aangepast document‑header, een gekoppeld CSS‑bestand, of aangepaste markup rond dia’s en vormen, gebruik een aangepaste formatteringscontroller via een JPype‑interface‑proxy en geef deze door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmlformatter/) met [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Lettertypen insluiten**

Wanneer de doelomgeving de presentatiellettertypen mogelijk niet geïnstalleerd heeft, sluit dan lettertypen in in de HTML met [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/python-java/aspose.slides/embedallfontshtmlcontroller/). Insluiten verbetert de visuele getrouwheid maar vergroot de bestandsgrootte.

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

Sluit lettertypen alleen uit wanneer u er zeker van bent dat de doelsystemen of browsers deze al beschikbaar hebben. Voor huismerk‑lettertypen of minder gangbare lettertypen is insluiten doorgaans veiliger.

## **Sla bronnen extern op**

Zelfstandige HTML is eenvoudig te verplaatsen, maar ingesloten Base64‑bronnen kunnen het bestand groot maken. Als uw applicatie externe afbeeldingsbestanden nodig heeft, implementeer dan een resource‑linking‑controller via een JPype‑interface‑proxy en geef deze door aan de [HtmlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/)‑constructor.

Wanneer u bronnen externaliseert, kies dan twee paden bewust:

- Het bestandssysteem‑outputpad, waar uw applicatie gegenereerde afbeeldingen, lettertypen, audio‑ of videobestanden schrijft.
- Het URL‑pad, dat de browser gebruikt vanuit het HTML‑document om die bestanden te laden.

## **Exporteer mediabestanden**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoplayerhtmlcontroller/) exporteert video‑ en audiobestanden en schrijft HTML die ze in een browser kan afspelen. De constructor accepteert:

- `path`: de map waarin gegenereerde mediabestanden worden geschreven.
- `fileName`: de naam van het HTML‑bestand dat wordt gegenereerd.
- `baseUri`: het absolute URI‑voorvoegsel dat in de HTML‑links naar mediabestanden wordt gebruikt.

Het volgende voorbeeld exporteert media die al zijn ingebed in `presentation.pptx`. Het gegenereerde HTML‑document verwijst naar mediabestanden uitsluitend via bestandsnaam, relatief ten opzichte van het HTML‑document, dus `path` moet de map zijn die tevens het HTML‑bestand ontvangt. `baseUri` moet een absoluut URI zijn: voor lokale preview een `file:///`‑URI construeren vanuit de output‑map; voor een gedeployde applicatie de absolute URL van de gepubliceerde map gebruiken.

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

HTML‑conversie is een renderingsoperatie, dus verwerkingstijd en geheugenverbruik hangen af van het aantal dia’s, beeldresolutie, lettertypen, effecten, grafieken en ingesloten media. Hogere DPI‑waarden die worden doorgegeven aan [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setPicturesCompression), ingesloten lettertypen, SVG‑output en bewaarde bijgesneden afbeeldingsgebieden kunnen de getrouwheid verbeteren maar vergroten doorgaans de bestandsgrootte.

Voor batch‑conversie:

- Maak elke [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie snel vrij.
- Gebruik afzonderlijke output‑mappen voor afzonderlijke taken.
- Vermijd het insluiten van veelgebruikte lettertypen tenzij de getrouwheid dit vereist.
- Verminder de DPI van afbeeldingen wanneer de HTML wordt gebruikt voor preview of thumbnails.
- Houd de bronpresentatie, het gegenereerde HTML‑document en externe bronnen bij elkaar tot de uiteindelijke implementatie‑paden definitief zijn.

## **FAQ**

**Worden hyperlinks behouden in de HTML‑output?**

Ja. Hyperlinks in de presentatie worden geëxporteerd naar HTML en blijven klikbaar wanneer de doellink geldig is.

**Kan ik presentaties parallel naar HTML converteren?**

Ja, maar deel geen [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie tussen threads. Verwerk verschillende bestanden met afzonderlijke presentatie‑instances, afzonderlijke streams en afzonderlijke output‑mappen. Zie de [multithreading‑richtlijnen](/slides/nl/python-java/multithreading/) voor details.

**Is een presentatie‑object thread‑safe?**

Nee. Een enkele [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie moet worden geladen, aangepast, opgeslagen en vrijgegeven op één thread. Voor parallel werk, maak een onafhankelijke instantie per thread of proces.

**Waarom is het gegenereerde HTML‑bestand zo groot?**

De standaardexport kan bronnen direct in de HTML insluiten. Ingesloten lettertypen, hoge‑DPI‑afbeeldingen, media, SVG‑content en bewaarde bijgesneden afbeeldingsgebieden verhogen eveneens de grootte. Gebruik externe bronnen, sluit veelvoorkomende lettertypen uit en geef een lagere DPI‑waarde door aan [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setPicturesCompression) wanneer een kleinere output belangrijker is dan maximale getrouwheid.

**Waarom kunnen font‑size‑waarden in HTML afwijken van de PowerPoint‑waarden?**

De geëxporteerde pagina kan SVG‑coördinatensystemen en schaal‑transformaties gebruiken. Een ruwe CSS‑ of SVG‑font‑size‑waarde alleen beschrijft niet de uiteindelijke weergavegrootte. Vergelijk de gerenderde dia op het beoogde zoom‑niveau en controleer de beschikbaarheid van het lettertype als de tekst er anders uitziet.

**Hoe moet ik baseUri kiezen voor mediabestand‑export?**

Kies `baseUri` vanuit het perspectief van de browser en geef deze door als een absoluut URI. Voor lokale preview kunt u deze afleiden van de output‑map met `output_directory.as_uri() + "/"`. Voor implementatie gebruik u de absolute URL van de gepubliceerde map. Het bestandssysteem‑`path` en de browser‑`baseUri` hoeven niet dezelfde tekenreeks te zijn, maar ze moeten naar dezelfde locatie verwijzen, en die locatie moet de map zijn die het gegenereerde HTML‑bestand bevat omdat mediakoppelingen relatief daartoe worden geschreven.

**Kan ik verborgen dia’s opnemen?**

Ja. Roep [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) aan met `True` wanneer verborgen dia’s moeten worden geëxporteerd.