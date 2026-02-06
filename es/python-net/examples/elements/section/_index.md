---
title: Sección
type: docs
weight: 90
url: /es/python-net/examples/elements/section/
keywords:
- sección
- sección de diapositiva
- añadir sección
- acceder a la sección
- eliminar sección
- renombrar sección
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Administre las secciones de diapositivas en Python con Aspose.Slides: cree, renombre y reordene fácilmente, mueva diapositivas entre secciones y controle la visibilidad para PPT, PPTX y ODP."
---
Ejemplos de gestión de secciones de presentación: agregar, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for Python via .NET**.

## **Agregar una sección**

Cree una sección que comience en una diapositiva específica.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Añade una nueva sección y especifica la diapositiva que marca el inicio de la sección.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a una sección**

Obtenga una sección de una presentación.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Accede a una sección por índice.
        section = presentation.sections[0]
```

## **Eliminar una sección**

Elimine una sección añadida previamente.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Elimina la sección.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Renombrar una sección**

Cambie el nombre de una sección existente.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Renombra la sección.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```