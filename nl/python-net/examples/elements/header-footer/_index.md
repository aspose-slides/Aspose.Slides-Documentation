---
title: KoptekstVoettekst
type: docs
weight: 220
url: /nl/python-net/examples/elements/header-footer/
keywords:
- koptekst voettekst
- voeg koptekst voettekst toe
- werk koptekst voettekst bij
- stel datum en tijd in
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer kopteksten en voetteksten in Python met Aspose.Slides: voeg datum/tijd toe of bewerk, dia‑nummers en voettekst, toon of verberg vullers in PPT, PPTX en ODP."
---
Toont hoe je voetteksten kunt toevoegen en datum‑ en tijdsvullers kunt bijwerken met **Aspose.Slides for Python via .NET**.

## **Voettekst toevoegen**

Voeg tekst toe aan het voettekstgebied van een dia en maak deze zichtbaar.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Datum en tijd bijwerken**

Wijzig de datum‑ en tijdsvuller op een dia.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```