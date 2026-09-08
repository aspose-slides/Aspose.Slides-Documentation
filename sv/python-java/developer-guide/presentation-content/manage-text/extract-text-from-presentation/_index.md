---
title: Avancerad textutvinning från presentationer i Python via Java
linktitle: Extrahera text
type: docs
weight: 90
url: /sv/python-java/extract-text-from-presentation/
keywords:
- extrahera text
- extrahera text från bild
- extrahera text från presentation
- extrahera text från PowerPoint
- extrahera text från OpenDocument
- extrahera text från PPT
- extrahera text från PPTX
- extrahera text från ODP
- hämta text
- hämta text från bild
- hämta text från presentation
- hämta text från PowerPoint
- hämta text från OpenDocument
- hämta text från PPT
- hämta text från PPTX
- hämta text från ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Extrahera snabbt text från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java. Följ vår enkla steg-för-steg guide för att spara tid."
---
## **Översikt**

Att extrahera text från presentationer är en vanlig men ändå viktig uppgift för utvecklare som arbetar med bildinnehåll. Oavsett om du hanterar Microsoft PowerPoint-filer i PPT- eller PPTX-format, eller OpenDocument-presentationer (ODP), kan åtkomst till och hämtning av textdata vara avgörande för analys, automatisering, indexering eller innehållsmigrering.

Denna artikel ger en omfattande guide om hur man på ett effektivt sätt extraherar text från olika presentationsformat, inklusive PPT, PPTX och ODP, med Aspose.Slides for Python via Java. Du kommer att lära dig hur du systematiskt itererar genom presentationens element för att exakt hämta den textinnehåll du behöver.

## **Extrahera text från en bild**

Aspose.Slides for Python via Java tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideutil/). Denna klass exponerar flera överlagrade statiska metoder för att extrahera all text från en presentation eller bild. För att extrahera text från en bild i en presentation, använd metoden [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideutil/#getAllTextBoxes). Denna metod tar emot ett objekt av typen [BaseSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/) som parameter. När den körs skannar metoden hela bilden efter text och returnerar en matris av objekt av typen [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/), som bevarar all textformatering.

Följande kodsnutt extraherar all text från den första bilden i presentationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Extrahera text från en presentation**

För att skanna text från hela presentationen, använd den statiska metoden [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideutil/#getAllTextFrames) som exponeras av klassen [SlideUtil](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideutil/). Den tar emot två parametrar:

1. Först ett [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) -objekt som representerar en PowerPoint- eller OpenDocument-presentation som texten ska extraheras från.
1. Sedan ett `bool`-värde som indikerar om masterslides ska inkluderas när text skannas från presentationen.

Metoden returnerar en matris av objekt av typen [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/), inklusive information om textformatering. Koden nedan skannar text och formateringsdetaljer från en presentation, inklusive masterslides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Kategoriserad och snabb textutvinning**

Klassen [PresentationFactory](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/) tillhandahåller också metoder för att extrahera all text från presentationer:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Extrahera texten från en fil.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Extrahera texten från en ström.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Extrahera texten från en ström med läsalternativ.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

Argumentet [TextExtractionArrangingMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textextractionarrangingmode/) i enumet anger läget för organisering av resultatet av textutvinning och kan sättas till följande värden:

- [Unarranged](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - Den råa texten utan hänsyn till dess position på bilden.
- [Arranged](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - Texten är ordnad i samma ordning som på bilden.

Det oordnade läget kan användas när hastighet är kritisk; det är snabbare än det ordnade läget.

[PresentationText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationtext/) representerar den råa texten som extraherats från presentationen. Dess [getSlidesText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationtext/#getSlidesText) metod returnerar en matris av objekt av typen `SlideText`. Varje objekt representerar texten på den motsvarande bilden. Objektet av typen `SlideText` har följande metoder:

- `getText` - Texten inom bildens former.
- `getMasterText` - Texten inom masterslidens former som är associerade med denna bild.
- `getLayoutText` - Texten inom layoutbildens former som är associerade med denna bild.
- `getNotesText` - Texten inom noteringsbildens former som är associerade med denna bild.
- `getCommentsText` - Texten inom kommentarer som är associerade med denna bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **FAQ**

**Hur snabbt bearbetar Aspose.Slides stora presentationer under textutvinning?**

Aspose.Slides är optimerat för hög prestanda och kan bearbeta även [stora presentationer](/slides/sv/python-java/open-presentation/), vilket gör det lämpligt för realtid- eller massbearbetningsscenarier.

**Kan Aspose.Slides extrahera text från tabeller och diagram i presentationer?**

Ja. Aspose.Slides kan extrahera text från många bildelement, inklusive tabeller och diagramrelaterade objekt, så att du kan komma åt och analysera textinnehåll i vanliga presentationsstrukturer.

**Behöver jag en speciell Aspose.Slides-licens för att extrahera text från presentationer?**

Du kan extrahera text med den kostnadsfria provversionen av Aspose.Slides, även om den har [vissa begränsningar](/slides/sv/python-java/licensing/), såsom att endast bearbeta ett begränsat antal bilder. För obegränsad användning och för att hantera större presentationer rekommenderas att köpa en full licens.