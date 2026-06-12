---
title: Geavanceerde Tekstextractie uit Presentaties in Python
linktitle: Tekst extraheren
type: docs
weight: 90
url: /nl/python-net/extract-text-from-presentation/
keywords:
  - tekst extraheren
  - tekst extraheren uit dia
  - tekst extraheren uit presentatie
  - tekst extraheren uit PowerPoint
  - tekst extraheren uit OpenDocument
  - tekst extraheren uit PPT
  - tekst extraheren uit PPTX
  - tekst extraheren uit ODP
  - tekst ophalen
  - tekst ophalen uit dia
  - tekst ophalen uit presentatie
  - tekst ophalen uit PowerPoint
  - tekst ophalen uit OpenDocument
  - tekst ophalen uit PPT
  - tekst ophalen uit PPTX
  - tekst ophalen uit ODP
  - PowerPoint
  - OpenDocument
  - presentatie
  - Python
  - Aspose.Slides
description: "Extraheer snel tekst uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET. Volg onze eenvoudige, stapsgewijze gids om tijd te besparen."
---
## **Overzicht**

Tekst extraheren uit presentaties is een veelvoorkomende maar essentiële taak voor ontwikkelaars die met dia‑inhoud werken. Of je nu werkt met Microsoft PowerPoint‑bestanden in PPT‑ of PPTX‑formaat, of met OpenDocument‑presentaties (ODP), toegang krijgen tot en het ophalen van tekstgegevens kan cruciaal zijn voor analyse, automatisering, indexering of content‑migratie.

Dit artikel biedt een volledige gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatieformaten, waaronder PPT, PPTX en ODP, met behulp van Aspose.Slides for Python via .NET. Je leert hoe je systematisch door presentatie‑elementen kunt itereren om de tekstinhoud die je nodig hebt nauwkeurig op te halen.

## **Tekst extraheren uit een dia**

Aspose.Slides for Python via .NET levert de [aspose.slides.util](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/) namespace, die de [SlideUtil](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/)‑klasse bevat. Deze klasse biedt verschillende overladen statische methoden om alle tekst uit een presentatie of dia te extraheren. Om tekst uit een dia in een presentatie te halen, gebruik je de [get_all_text_boxes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/get_all_text_boxes/)‑methode. Deze methode accepteert een object van het type [BaseSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/) als parameter. Bij uitvoering scant de methode de volledige dia op tekst en retourneert een array van objecten van het type [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/), waarbij eventuele tekstopmaak behouden blijft.

De volgende codefragment extrahert alle tekst van de eerste dia van de presentatie:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Tekst extraheren uit een presentatie**

Om tekst van de volledige presentatie te scannen, gebruik je de [get_all_text_frames](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/get_all_text_frames/)‑statische methode die de [SlideUtil](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/)‑klasse biedt. Deze methode accepteert twee parameters:

1. Ten eerste een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object dat een PowerPoint‑ of OpenDocument‑presentatie representeert waaruit tekst wordt geëxtraheerd.  
1. Ten tweede een `Boolean`‑waarde die aangeeft of de master‑dia’s moeten worden meegenomen bij het scannen van tekst in de presentatie.

De methode retourneert een array van objecten van het type [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/), inclusief informatie over tekstopmaak. De onderstaande code scant de tekst en opmaakdetails uit een presentatie, inclusief de master‑dia’s.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Gecategoriseerde en snelle tekstextractie**

De [PresentationFactory](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/)‑klasse biedt ook methoden om alle tekst uit presentaties te extraheren:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

Het [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textextractionarrangingmode/)‑enum‑argument geeft de modus aan voor het organiseren van het resultaat van de tekstextractie en kan de volgende waarden krijgen:
- `UNARRANGED` – De ruwe tekst zonder rekening te houden met de positie op de dia.  
- `ARRANGED` – De tekst wordt gerangschikt in dezelfde volgorde als op de dia.

De `UNARRANGED`‑modus kan worden gebruikt wanneer snelheid cruciaal is; hij is sneller dan de `ARRANGED`‑modus.

[PresentationText](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is gehaald. De eigenschap `slides_text` retourneert een array van dia‑tekstobjecten. Elk object vertegenwoordigt de tekst op de corresponderende dia en heeft de volgende eigenschappen:

- `text` – De tekst binnen de vormen van de dia.  
- `master_text` – De tekst binnen de vormen van de master‑dia die bij deze dia hoort.  
- `layout_text` – De tekst binnen de vormen van de layout‑dia die bij deze dia hoort.  
- `notes_text` – De tekst binnen de vormen van de notities‑dia die bij deze dia hoort.  
- `comments_text` – De tekst in de opmerkingen die bij deze dia horen.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **FAQ**

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens tekstextractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [large presentations](/slides/nl/python-net/open-presentation/) verwerken, waardoor het geschikt is voor realtime‑ of bulk‑verwerking scenario’s.

**Kan Aspose.Slides tekst uit tabellen en diagrammen binnen presentaties extraheren?**

Ja. Aspose.Slides kan tekst uit veel dia‑elementen extraheren, waaronder tabellen en diagramgerelateerde objecten, zodat je tekstuele inhoud in gangbare presentatiestructuren kunt benaderen en analyseren.

**Heb ik een speciale Aspose.Slides‑licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel deze [certain limitations](/slides/nl/python-net/licensing/) heeft, zoals het verwerken van slechts een beperkt aantal dia’s. Voor onbeperkt gebruik en om grotere presentaties aan te kunnen, wordt aangeraden een volledige licentie aan te schaffen.