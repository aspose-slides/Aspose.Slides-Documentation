---
title: PowerPoint-presentaties converteren naar HTML in Python
linktitle: PowerPoint naar HTML
type: docs
weight: 30
url: /nl/python-net/convert-powerpoint-to-html/
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
- Aspose.Slides
description: "PowerPoint-presentaties converteren naar HTML in Python. Gebruik Aspose.Slides om PPT- en PPTX-bestanden, geselecteerde dia's, notities, lettertypen, afbeeldingen, SVG en media te exporteren."
---
## **Overzicht**

Aspose.Slides voor Python via .NET kan PowerPoint‑presentaties opslaan als HTML zonder Microsoft PowerPoint. De basisconversie bestaat uit één [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) laden en een `save`‑aanroep met [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/). Gebruik [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/) wanneer u de geëxporteerde lay‑out, lettertypen, afbeeldingen, aantekeningen, opmerkingen, SVG‑output of gekoppelde bronnen wilt beheersen.

Deze gids richt zich op praktische HTML‑exportscenario’s:

- Exporteer een volledige presentatie of geselecteerde dia's.
- Genereer vaste lay‑out, responsieve of op SVG gebaseerde HTML.
- Neem spreker‑aantekeningen en opmerkingen op.
- Beheer de beeldkwaliteit en bijgesneden beeldgegevens.
- Integreer lettertypen of sla lettertype‑bestanden afzonderlijk op.
- Kies hoe externe bronnen en mediabestanden worden geschreven en geraadpleegd.

Standaard genereert HTML‑export een zelf‑bevatend HTML‑document waarin de meeste bronnen zijn ingebed. Dit is handig voor het delen van één bestand, maar kan de outputgrootte vergroten. Voor publicatie op het web kunt u overwegen externe bronnen te gebruiken, de afbeelding‑DPI te verlagen, en alleen lettertypen in te sluiten die niet betrouwbaar beschikbaar zijn in de doelsituatie.

## **Een presentatie naar HTML converteren**

Om een presentatie te exporteren naar HTML, laad deze met [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en sla deze op met [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Dit voorbeeld schrijft één HTML‑bestand. De `with`‑statement maakt het presentatiewobject vrij en sluit bestands‑handles en renderingsbronnen na de export.

## **HtmlOptions gebruiken**

[HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/) is de belangrijkste configuratieklasse voor HTML‑export. Veelvoorkomende instellingen omvatten:

- `slides_layout_options`: voegt aantekeningen, opmerkingen, hand‑outs of andere lay‑out‑informatie toe.
- `html_formatter`: wijzigt de HTML‑documentstructuur of delegeert formatteren aan een controller.
- `slide_image_format`: wijzigt hoe dia's worden weergegeven, bijvoorbeeld als SVG.
- `pictures_compression`: regelt de afbeelding‑DPI en de outputgrootte.
- `delete_pictures_cropped_areas`: behoudt of verwijdert bijgesneden beeldgegevens.
- `svg_responsive_layout`: laat geëxporteerde SVG‑inhoud zich aanpassen aan de container.
- `show_hidden_slides`: neemt verborgen dia's op wanneer vereist.

De volgende secties tonen de meest voorkomende opties afzonderlijk, zodat u alleen die kunt combineren die uw workflow vereist.

## **Geselecteerde dia's naar HTML converteren**

De `save`‑overload die diacijfers accepteert, gebruikt 1‑gebaseerde dia‑posities. De onderstaande lus slaat elke dia op in een afzonderlijk HTML‑bestand.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Gebruik dit patroon wanneer een website of applicatie één HTML‑pagina per dia nodig heeft. Als elke dia dezelfde lay‑out moet hebben, maak dan één [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/)‑instantie aan en geef deze door aan elke `save`‑aanroep.

## **Responsieve HTML maken**

[ResponsiveHtmlController](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/responsivehtmlcontroller/) biedt responsieve HTML‑output via [HtmlFormatter](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmlformatter/). Gebruik dit wanneer de geëxporteerde pagina beter moet aanpassen aan de breedte van de browser.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Voor een op SVG gebaseerde responsieve lay‑out, stel `svg_responsive_layout` in op [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/). Dit is nuttig wanneer de dia‑inhoud wordt geëxporteerd als schaalbare SVG‑markup.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Sprekersaantekeningen en opmerkingen opnemen**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notescommentslayoutingoptions/) via `html_options.slides_layout_options` om sprekersaantekeningen of opmerkingen op te nemen. Aantekeningen en opmerkingen zijn standaard verborgen tenzij u hun posities kiest.

Stel dat de bronpresentatie sprekersaantekeningen bevat:

![Dia met sprekersaantekeningen in PowerPoint](slide_with_notes.png)

De volgende code exporteert de dia‑inhoud met sprekersaantekeningen onder de dia.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

De geëxporteerde HTML bevat het notitiegebied:

![HTML‑output met de dia en sprekersaantekeningen](HTML_with_notes.png)

Om opmerkingen te exporteren, stel `comments_position` in, bijvoorbeeld op `CommentsPositions.RIGHT` of `CommentsPositions.BOTTOM`. Als u alleen opmerkingen nodig heeft, laat `notes_position` weg. Als u zowel aantekeningen als opmerkingen nodig heeft, stel beide eigenschappen in.

## **Beeldkwaliteit en bijgesneden gebieden beheren**

HTML‑export kan dia‑afbeeldingen comprimeren om de outputgrootte te verkleinen. Stel `pictures_compression` in op een waarde uit [PicturesCompression](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/picturescompression/) wanneer u een hogere beeldkwaliteit nodig heeft.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Standaard kunnen bijgesneden delen van afbeeldingen uit de geëxporteerde output worden verwijderd. Houd bijgesneden gegevens alleen bij wanneer gebruikers die verborgen afbeeldingdelen moeten kunnen herstellen of inspecteren. Het behouden ervan kan de HTML‑grootte vergroten.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **CSS toevoegen**

Voor eenvoudige opmaak, geef een CSS‑tekenreeks door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmlformatter/). Dit wijzigt het omringende HTML‑document terwijl Aspose.Slides de dia‑inhoud blijft renderen.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Voor een aangepaste documentheader, een gekoppeld CSS‑bestand, of aangepaste markup rond dia's en vormen, gebruik een aangepaste formatteringscontroller en geef deze door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmlformatter/) met `create_custom_formatter`.

## **Lettertypen insluiten**

Als de doelomgeving mogelijk niet over de presentatie‑lettertypen beschikt, sluit dan lettertypen in de HTML in met [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Insluiten verbetert de visuele getrouwheid maar vergroot de outputgrootte.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Sluit een lettertype uit alleen wanneer u zeker weet dat de doel‑browsers of -systemen het al leveren. Voor merklettype of minder gangbare lettertypen is insluiten meestal veiliger.

## **Lettertypebestanden koppelen in plaats van insluiten**

Om de HTML‑bestandsgrootte te verkleinen, kunt u lettertype‑gegevens naar afzonderlijke WOFF‑bestanden schrijven en `@font-face`‑regels aan de HTML toevoegen. Dit vereist een controller die aanpast hoe lettertype‑gegevens tijdens export worden geschreven. In Python via .NET implementeert u die controller in een kleine .NET‑helper‑assembly, laadt u deze in Python, en geeft u het helper‑object door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmlformatter/) met `create_custom_formatter`.

Wanneer u lettertypen externaliseert, kies dan bewust twee paden:

- De uitvoermap op het bestandssysteem waar gegenereerde WOFF‑bestanden worden weggeschreven.
- Het URL‑pad dat in het HTML‑document zal verschijnen en dat de browser zal gebruiken om die lettertype‑bestanden te laden.

Houd het HTML‑bestand en de gegenereerde lettertype‑bestanden samen totdat de implementatie‑paden definitief zijn. Als de bestanden naar een andere locatie worden ingezet, zorg dan dat het URL‑voorvoegsel overeenkomt met het geïmplementeerde URL‑pad.

## **Bronnen extern opslaan**

Zelf‑bevatende HTML is gemakkelijk te verplaatsen, maar ingebedde Base64‑bronnen kunnen het bestand groot maken. Als uw applicatie externe afbeelding‑, lettertype‑, audio‑ of videobestanden nodig heeft, gebruik een aangepaste link/ embed‑controller en geef deze door aan de [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/)‑constructor.

Wanneer u bronnen externaliseert, kies dan bewust twee paden:

- Het uitvoerpad op het bestandssysteem, waar uw applicatie gegenereerde afbeeldingen, lettertypen, audio of video schrijft.
- Het URL‑pad, dat de browser vanuit het HTML‑document gebruikt om die bestanden te laden.

Voor een volledige bespreking van afbeelding‑koppelingen, zie [Presentaties exporteren naar HTML met extern gekoppelde afbeeldingen](/slides/nl/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Mediabestanden exporteren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/videoplayerhtmlcontroller/) exporteert video‑ en audio‑bestanden en schrijft HTML die ze in een browser kan afspelen. De constructor accepteert:

- `path`: de map waar gegenereerde mediabestanden worden weggeschreven.
- `file_name`: de te genereren HTML‑bestandsnaam.
- `base_uri`: het absolute URI‑voorvoegsel dat in de HTML‑koppelingen naar mediabestanden wordt gebruikt.

Als het HTML‑bestand `html-output/presentation.html` is en mediabestanden worden opgeslagen in `html-output/media`, moet `path` verwijzen naar de mediamap op schijf, terwijl `base_uri` moet verwijzen naar dezelfde map vanuit het perspectief van de browser. Voor lokale preview kunt u een `file:///`‑URI uit de mediamap samenstellen. Voor een uitgerolde applicatie gebruikt u de absolute URL van de gepubliceerde mediamap.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Gebruik uitgaande mappen die uniek zijn per exporttaak, vooral in server‑applicaties. Gedeelde output‑paden kunnen ervoor zorgen dat bestanden van verschillende conversies elkaar overschrijven.

## **Prestaties en bronnenbeheer**

HTML‑conversie is een renderingsoperatie, dus verwerkingstijd en geheugengebruik hangen af van het aantal dia's, de resolutie van afbeeldingen, lettertypen, effecten, diagrammen en ingesloten media. Hogere `pictures_compression`‑DPI‑waarden, ingesloten lettertypen, SVG‑output en het behouden van bijgesneden afbeeldingdelen kunnen de getrouwheid verbeteren maar verhogen doorgaans de outputgrootte.

Voor batch‑conversie:

- Maak elke [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie snel vrij.
- Gebruik afzonderlijke uitvoermappen voor afzonderlijke taken.
- Vermijd het insluiten van gangbare lettertypen tenzij de getrouwheid het vereist.
- Verlaag de afbeelding‑DPI wanneer de HTML voor preview of miniaturen is.
- Houd de bronpresentatie, gegenereerde HTML en externe bronnen samen totdat de implementatie‑paden definitief zijn.

## **FAQ**

**Worden hyperlinks behouden in de HTML‑output?**

Ja. Hyperlinks in de presentatie worden geëxporteerd naar HTML en blijven klikbaar wanneer de doel‑URL geldig is.

**Kan ik presentaties parallel naar HTML converteren?**

Ja, maar deel geen enkele [Presentation]‑instantie over threads. Verwerk verschillende bestanden met afzonderlijke presentatie‑instanties, aparte streams en aparte uitvoermappen. Zie de [multithreading guidance](/slides/nl/python-net/multithreading/) voor details.

**Is een Presentation‑object thread‑safe?**

Nee. Een enkele [Presentation]‑instantie moet op één thread worden geladen, gewijzigd, opgeslagen en vrijgemaakt. Voor parallel werk, maak een onafhankelijke instantie per thread of proces.

**Waarom is het gegenereerde HTML‑bestand groot?**

De standaardexport kan bronnen direct in de HTML insluiten. Ingesloten lettertypen, afbeeldingen met hoge DPI, media, SVG‑inhoud en behouden bijgesneden afbeeldingdelen vergroten de grootte ook. Gebruik externe bronnen, sluit gangbare lettertypen uit van insluiten, en verlaag `pictures_compression` wanneer een kleinere output belangrijker is dan maximale getrouwheid.

**Waarom wordt een PowerPoint‑lettergrootte van 24 pt weergegeven als 17.999819 pt in HTML?**

Dit kan gebeuren omdat PowerPoint en HTML verschillende DPI‑modellen gebruiken. PowerPoint slaat tekstgroottes op in typografische punten gebaseerd op 72 DPI, terwijl HTML‑lay‑out gebaseerd is op CSS‑pixels in een 96‑DPI‑model. Wanneer Aspose.Slides een presentatie exporteert naar HTML, wordt de lettergrootte tussen deze systemen vertaald, en kan de conversie kleine afrondingsverschillen introduceren.

Deze waarden duiden niet op een echte visuele verandering van de lettergrootte. Het zijn alleen een wiskundig neveneffect van het omzetten van tekstmetingen tussen PowerPoint en HTML.

**Hoe moet ik base_uri kiezen voor media‑export?**

Kies `base_uri` vanuit het perspectief van de browser en geef deze door als een absolute URI. Voor lokale preview kunt u deze afleiden van de uitvoermap met `Path(media_directory).as_uri() + "/"`. Voor implementatie gebruikt u de absolute URL van de gepubliceerde mediamap. Het bestandssysteem‑`path` en de browser‑`base_uri` hoeven niet dezelfde tekenreeks te zijn, maar ze moeten dezelfde bronlocatie beschrijven.

**Kan ik verborgen dia's opnemen?**

Ja. Stel `show_hidden_slides = True` in op [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/) wanneer verborgen dia's geëxporteerd moeten worden.