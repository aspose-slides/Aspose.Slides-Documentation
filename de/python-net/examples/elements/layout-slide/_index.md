---
title: Layout-Folie
type: docs
weight: 20
url: /de/python-net/examples/elements/layout-slide/
keywords:
- Layout-Folie
- Layout-Folie hinzufügen
- Layout-Folie zugreifen
- Layout-Folie entfernen
- unbenutzte Layout-Folie
- Layout-Folie klonen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwenden Sie Python, um Layout-Folien mit Aspose.Slides zu verwalten: erstellen, anwenden, klonen, umbenennen und Platzhalter sowie Designs in Präsentationen für PPT, PPTX und ODP anpassen."
---
Dieser Artikel zeigt, wie man mit **Layout-Folien** in Aspose.Slides für Python über .NET arbeitet. Eine Layout-Folie definiert das Design und die Formatierung, die von normalen Folien übernommen werden. Sie können Layout-Folien hinzufügen, darauf zugreifen, klonen und entfernen sowie ungenutzte Folien bereinigen, um die Größe der Präsentation zu reduzieren.

## **Layout-Folie hinzufügen**

Sie können eine benutzerdefinierte Layout-Folie erstellen, um wiederverwendbare Formatierungen zu definieren.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Erstelle eine Layout-Folie mit dem angegebenen Typ und Namen.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Layout-Folien dienen als Vorlagen für einzelne Folien. Sie können gemeinsame Elemente einmal definieren und sie in vielen Folien wiederverwenden.

> 💡 **Tip 2:** Wenn Sie Formen oder Text zu einer Layout-Folie hinzufügen, zeigen alle darauf basierenden Folien diesen gemeinsamen Inhalt automatisch an.  
> Der Screenshot unten zeigt zwei Folien, die jeweils ein Textfeld von derselben Layout-Folie erben.

![Folien erben Layout-Inhalt](layout-slide-result.png)


## **Auf eine Layout-Folie zugreifen**

Layout-Folien können über den Index oder den Layout-Typ (z. B. `Blank`, `Title`, `SectionHeader` usw.) zugegriffen werden.

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Zugriff nach Index.
        first_layout_slide = presentation.layout_slides[0]

        # Zugriff nach Layouttyp.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Layout-Folie entfernen**

Sie können eine bestimmte Layout-Folie entfernen, wenn sie nicht mehr benötigt wird.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Holen Sie eine Layout-Folie nach Typ und entfernen Sie sie.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Unbenutzte Layout-Folien entfernen**

Um die Größe der Präsentation zu reduzieren, können Sie Layout-Folien entfernen, die von keinen normalen Folien verwendet werden.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Entfernt automatisch alle Layout-Folien, die von keiner Folie referenziert werden.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Layout-Folie klonen**

Sie können eine Layout-Folie mit der Methode `AddClone` duplizieren.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Holen Sie eine vorhandene Layout-Folie nach Typ.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Klonen Sie die Layout-Folie an das Ende der Layout-Folien-Sammlung.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Zusammenfassung:** Layout-Folien sind leistungsstarke Werkzeuge zur Verwaltung einheitlicher Formatierung über Folien hinweg. Aspose.Slides bietet vollständige Kontrolle über das Erstellen, Verwalten und Optimieren von Layout-Folien.