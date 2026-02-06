---
title: Abschnitt
type: docs
weight: 90
url: /de/python-net/examples/elements/section/
keywords:
- Abschnitt
- Folienabschnitt
- Abschnitt hinzufügen
- Abschnitt abrufen
- Abschnitt entfernen
- Abschnitt umbenennen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte in Python mit Aspose.Slides: Erstellen, umbenennen, einfach neu anordnen, Folien zwischen Abschnitten verschieben und die Sichtbarkeit für PPT, PPTX und ODP steuern."
---
Beispiele für die Verwaltung von Präsentationsabschnitten – hinzufügen, darauf zugreifen, entfernen und umbenennen, programmatisch mithilfe von **Aspose.Slides for Python via .NET**.

## **Abschnitt hinzufügen**

Erstellen Sie einen Abschnitt, der an einer bestimmten Folie beginnt.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Einen neuen Abschnitt hinzufügen und die Folie angeben, die den Anfang des Abschnitts markiert.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Abschnitt abrufen**

Rufen Sie einen Abschnitt aus einer Präsentation ab.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Zugriff auf einen Abschnitt nach Index.
        section = presentation.sections[0]
```

## **Abschnitt entfernen**

Löschen Sie einen zuvor hinzugefügten Abschnitt.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Abschnitt entfernen.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Abschnitt umbenennen**

Ändern Sie den Namen eines bestehenden Abschnitts.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Abschnitt umbenennen.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```