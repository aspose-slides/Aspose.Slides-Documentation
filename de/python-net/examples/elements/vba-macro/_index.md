---
title: VbaMacro
type: docs
weight: 150
url: /de/python-net/examples/elements/vba-macro/
keywords:
- VBA-Makro
- VBA-Makro hinzufügen
- Zugriff auf VBA-Makro
- VBA-Makro entfernen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Arbeiten Sie mit VBA-Makros in Python unter Verwendung von Aspose.Slides: Projekte und Module hinzufügen oder bearbeiten, Makros signieren oder entfernen und Präsentationen in PPT, PPTX und ODP speichern."
---
Veranschaulicht, wie man VBA-Makros mit **Aspose.Slides for Python via .NET** hinzufügt, darauf zugreift und sie entfernt.

## **VBA-Makro hinzufügen**

Erstellen Sie eine Präsentation mit einem VBA-Projekt und einem einfachen Makromodul.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # VBA-Projekt initialisieren.
        presentation.vba_project = slides.vba.VbaProject()

        # Leeres Modul mit dem Namen "Module" hinzufügen.
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Zugriff auf ein VBA-Makro**

Rufen Sie das erste Modul aus dem VBA-Projekt ab.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **VBA-Makro entfernen**

Löschen Sie ein Modul aus dem VBA-Projekt.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Angenommen, die Präsentation enthält ein VBA-Projekt und mindestens ein Modul.
        module = presentation.vba_project.modules[0]

        # Entfernt das Modul aus dem Projekt.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```