---
title: Sectie
type: docs
weight: 90
url: /nl/python-net/examples/elements/section/
keywords:
- sectie
- dia sectie
- sectie toevoegen
- sectie benaderen
- sectie verwijderen
- sectie hernoemen
- code voorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer dia secties in Python met Aspose.Slides: maak, hernoem, herschik eenvoudig, verplaats dia's tussen secties en beheer de zichtbaarheid voor PPT, PPTX en ODP."
---
Voorbeelden voor het beheren van presentatiesecties—voeg toe, benader, verwijder en hernoem ze programmatisch met **Aspose.Slides for Python via .NET**.

## **Sectie toevoegen**

Maak een sectie aan die begint bij een specifieke dia.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Voeg een nieuwe sectie toe en geef de dia op die het begin van de sectie aangeeft.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Sectie benaderen**

Haalt een sectie op uit een presentatie.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Toegang tot een sectie via index.
        section = presentation.sections[0]
```

## **Sectie verwijderen**

Verwijder een eerder toegevoegde sectie.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Verwijder de sectie.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sectie hernoemen**

Wijzig de naam van een bestaande sectie.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Hernoem de sectie.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```