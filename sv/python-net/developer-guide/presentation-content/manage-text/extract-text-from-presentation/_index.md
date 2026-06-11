---
title: Avancerad textutvinning från presentationer i Python
linktitle: Extrahera text
type: docs
weight: 90
url: /sv/python-net/extract-text-from-presentation/
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
- Aspose.Slides
description: "Extrahera snabbt text från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Följ vår enkla, steg‑för‑steg‑guide för att spara tid."
---
## **Översikt**

Att extrahera text från presentationer är en vanlig men ändå viktig uppgift för utvecklare som arbetar med bildspel. Oavsett om du hanterar Microsoft PowerPoint‑filer i PPT‑ eller PPTX‑format, eller OpenDocument‑presentationer (ODP), kan åtkomst till och hämtning av textdata vara kritisk för analys, automatisering, indexering eller innehållsmigrering.

Denna artikel ger en omfattande guide för hur du effektivt extraherar text från olika presentationsformat, inklusive PPT, PPTX och ODP, med Aspose.Slides för Python via .NET. Du kommer att lära dig hur du systematiskt itererar genom presentationselement för att exakt hämta den textinnehåll du behöver.

## **Extrahera text från en bild**

Aspose.Slides för Python via .NET tillhandahåller namnområdet [aspose.slides.util](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/) som innehåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/). Denna klass exponerar flera överlagrade statiska metoder för att extrahera all text från en presentation eller bild. För att extrahera text från en bild i en presentation använder du metoden [get_all_text_boxes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Denna metod accepterar ett objekt av typen [BaseSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/) som parameter. När den körs skannar metoden hela bilden efter text och returnerar en array av objekt av typen [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/), med bibehållen textformatering.

Följande kodsnutt extraherar all text från den första bilden i presentationen:

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

## **Extrahera text från en presentation**

För att skanna text från hela presentationen använder du den statiska metoden [get_all_text_frames](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/get_all_text_frames/) som exponeras av klassen [SlideUtil](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/). Den tar emot två parametrar:

1. Först ett [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objekt som representerar en PowerPoint‑ eller OpenDocument‑presentation som text ska extraheras från.
1. För det andra ett `Boolean`‑värde som anger om masterbilderna ska inkluderas när text skannas från presentationen.

Metoden returnerar en array av objekt av typen [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/), inklusive information om textformatering. Koden nedan skannar texten och formateringsdetaljerna från en presentation, inklusive masterbilderna.

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

## **Kategoriserad och snabb textutvinning**

Klassen [PresentationFactory](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/) tillhandahåller också metoder för att extrahera all text från presentationer:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textextractionarrangingmode/) enum‑argumentet anger läget för att organisera resultatet av textutvinningen och kan sättas till följande värden:
- `UNARRANGED` – Råtext utan hänsyn till dess position på bilden.
- `ARRANGED` – Texten är arrangerad i samma ordning som på bilden.

`UNARRANGED`‑läget kan användas när hastighet är kritisk; det är snabbare än `ARRANGED`‑läget.

[PresentationText](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationtext/) representerar den råa texten som extraherats från presentationen. Dess `slides_text`‑egenskap returnerar en array av bildtext‑objekt. Varje objekt representerar texten på den motsvarande bilden och har följande egenskaper:

- `text` – Texten i bildens former.
- `master_text` – Texten i master‑bildens former som är associerade med denna bild.
- `layout_text` – Texten i layout‑bildens former som är associerade med denna bild.
- `notes_text` – Texten i noterings‑bildens former som är associerade med denna bild.
- `comments_text` – Texten i kommentarer som är associerade med denna bild.

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

## **Vanliga frågor**

**Hur snabbt bearbetar Aspose.Slides stora presentationer vid textutvinning?**

Aspose.Slides är optimerat för hög prestanda och kan bearbeta även [stora presentationer](/slides/sv/python-net/open-presentation/), vilket gör det lämpligt för realtids‑ eller massbearbetningsscenario.

**Kan Aspose.Slides extrahera text från tabeller och diagram i presentationer?**

Ja. Aspose.Slides kan extrahera text från många bildelement, inklusive tabeller och diagramrelaterade objekt, så du kan komma åt och analysera textinnehåll i vanliga presentationsstrukturer.

**Behöver jag en speciell Aspose.Slides‑licens för att extrahera text från presentationer?**

Du kan extrahera text med den kostnadsfria provversionen av Aspose.Slides, men den har [vissa begränsningar](/slides/sv/python-net/licensing/), såsom att bara bearbeta ett begränsat antal bilder. För obegränsad användning och för att hantera större presentationer rekommenderas att köpa en full licens.