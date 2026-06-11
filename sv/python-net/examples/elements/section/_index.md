---
title: Sektion
type: docs
weight: 90
url: /sv/python-net/examples/elements/section/
keywords:
- sektion
- bildsektion
- lägg till sektion
- komma åt sektion
- ta bort sektion
- byta namn på sektion
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantering av bildsektioner i Python med Aspose.Slides: skapa, byta namn, omordna enkelt, flytta bilder mellan sektioner och kontrollera synlighet för PPT, PPTX och ODP."
---
Exempel på hantering av presentationssektioner—lägg till, komma åt, ta bort och byta namn på dem programmässigt med **Aspose.Slides for Python via .NET**.

## **Lägg till en sektion**

Skapa en sektion som börjar på en specifik bild.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Lägg till en ny sektion och ange bilden som markerar början på sektionen.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Kom åt en sektion**

Hämta en sektion från en presentation.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Åtkomst till en sektion efter index.
        section = presentation.sections[0]
```

## **Ta bort en sektion**

Radera en tidigare tillagd sektion.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Ta bort sektionen.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Byt namn på en sektion**

Ändra namnet på en befintlig sektion.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Byt namn på sektionen.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```