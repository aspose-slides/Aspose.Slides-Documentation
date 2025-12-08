---
title: "Folienlayouts in Python anwenden oder ändern"
linktitle: "Folienlayout"
type: docs
weight: 60
url: /de/python-net/slide-layout/
keywords:
- "Folienlayout"
- "Inhaltslayout"
- "Platzhalter"
- "Präsentationsdesign"
- "Foliendesign"
- "unbenutztes Layout"
- "Fußzeilen Sichtbarkeit"
- "Titelfolie"
- "Titel und Inhalt"
- "Abschnittsüberschrift"
- "Zwei Inhalte"
- "Vergleich"
- "Nur Titel"
- "Leeres Layout"
- "Inhalt mit Beschriftung"
- "Bild mit Beschriftung"
- "Titel und vertikaler Text"
- "Vertikaler Titel und Text"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie Folienlayouts in Aspose.Slides für Python via .NET verwalten und anpassen. Erkunden Sie Layout‑Typen, die Steuerung von Platzhaltern, die Sichtbarkeit von Fußzeilen und die Manipulation von Layouts anhand von Code‑Beispielen in Python."
---

## **Übersicht**

Ein Folienlayout definiert die Anordnung von Platzhalterboxen und die Formatierung für den Inhalt einer Folie. Es steuert, welche Platzhalter verfügbar sind und wo sie angezeigt werden. Folienlayouts helfen Ihnen, Präsentationen schnell und konsistent zu gestalten – egal, ob Sie etwas Einfaches oder Komplexeres erstellen. Zu den häufigsten Folienlayouts in PowerPoint gehören:

**Titel‑Folienlayout** – Enthält zwei Textplatzhalter: einen für den Titel und einen für den Untertitel.

**Titel‑und‑Inhalt‑Layout** – Enthält oben einen kleineren Titel‑Platzhalter und darunter einen größeren für den Hauptinhalt (wie Text, Aufzählungspunkte, Diagramme, Bilder und mehr).

**Leeres Layout** – Enthält keine Platzhalter, sodass Sie die Folie von Grund auf selbst gestalten können.

Folienlayouts sind Teil eines Folienmasters, der die Layout‑Stile für die gesamte Präsentation definiert. Sie können Layout‑Folien über den Folienmaster anhand ihres Typs, Namens oder ihrer eindeutigen ID abrufen und ändern. Alternativ können Sie ein bestimmtes Layout‑Folie direkt in der Präsentation bearbeiten.

Um mit Folienlayouts in Aspose.Slides für Python zu arbeiten, können Sie verwenden:

- Eigenschaften wie [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) und [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) unter der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
- Typen wie [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) und [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Um mehr über die Arbeit mit Folienmastern zu erfahren, lesen Sie den Artikel [Manage PowerPoint Slide Masters in Python](/slides/de/python-net/slide-master/).
{{% /alert %}}

## **Folienlayouts zu Präsentationen hinzufügen**

Um das Aussehen und die Struktur Ihrer Folien anzupassen, müssen Sie möglicherweise neue Layout‑Folien zu einer Präsentation hinzufügen. Aspose.Slides für Python ermöglicht es Ihnen, zu prüfen, ob ein bestimmtes Layout bereits existiert, bei Bedarf ein neues hinzuzufügen und es zum Einfügen von Folien basierend auf diesem Layout zu verwenden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie auf die [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/) zu.
1. Prüfen Sie, ob die gewünschte Layout‑Folie bereits in der Sammlung vorhanden ist. Falls nicht, fügen Sie das benötigte Layout hinzu.
1. Fügen Sie eine leere Folie basierend auf dem neuen Layout hinzu.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie ein Folienlayout zu einer PowerPoint‑Präsentation hinzugefügt wird:
```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    # Durchlaufen Sie die Layout-Folientypen, um eine Layout-Folie auszuwählen.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Eine Situation, in der die Präsentation nicht alle Layout-Typen enthält.
        # Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layout-Typen.
        # Allerdings können Layout-Folien mit benutzerdefinierten Typen erkennbare Namen haben,
        # wie "Titel", "Titel und Inhalt" usw., die für die Auswahl von Layout-Folien verwendet werden können.
        # Sie können sich auch auf eine Menge von Platzhalter-Formtypen verlassen.
        # Zum Beispiel sollte eine Titelfolie nur den Titel-Platzhaltertyp besitzen, usw.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Fügen Sie eine leere Folie mit der hinzugefügten Layout-Folie ein.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Unbenutzte Layout‑Folien entfernen**

Aspose.Slides stellt die Methode [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) der Klasse [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) bereit, um nicht benötigte Layout‑Folien zu löschen.

Der folgende Python‑Code zeigt, wie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernt wird:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Platzhalter zu Folienlayouts hinzufügen**

Aspose.Slides bietet die Eigenschaft [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/placeholder_manager/), mit der Sie neue Platzhalter zu einer Layout‑Folie hinzufügen können.

Dieser Manager enthält Methoden für die folgenden Platzhaltertypen:

| PowerPoint‑Platzhalter | [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) Methode |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Der folgende Python‑Code demonstriert, wie neue Platzhalterformen zur Blank‑Layout‑Folie hinzugefügt werden:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Holen Sie die leere Layout-Folie.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Holen Sie den Platzhalter-Manager der Layout-Folie.
    placeholder_manager = layout.placeholder_manager

    # Fügen Sie verschiedene Platzhalter zur leeren Layout-Folie hinzu.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Fügen Sie eine neue Folie mit dem leeren Layout hinzu.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The placeholders on the layout slide](add_placeholders.png)

## **Fußzeilen‑Sichtbarkeit für ein Layout‑Folie festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text je nach Layout angezeigt oder ausgeblendet werden. Aspose.Slides für Python erlaubt es Ihnen, die Sichtbarkeit dieser Fußzeilen‑Platzhalter zu steuern. Das ist nützlich, wenn bestimmte Layouts Fußzeileninformationen zeigen sollen, während andere schlicht bleiben.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Holen Sie sich einen Layout‑Folie‑Verweis über dessen Index.
1. Setzen Sie den Fußzeilen‑Platzhalter der Folie auf sichtbar.
1. Setzen Sie den Foliennummer‑Platzhalter auf sichtbar.
1. Setzen Sie den Datum‑Zeit‑Platzhalter auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie die Sichtbarkeit einer Folienfußzeile festgelegt wird:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```


## **Kind‑Fußzeilen‑Sichtbarkeit für eine Folie festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text auf der Ebene des Folienmasters gesteuert werden, um Konsistenz über alle Layout‑Folien hinweg zu gewährleisten. Aspose.Slides für Python ermöglicht es Ihnen, die Sichtbarkeit und den Inhalt dieser Fußzeilen‑Platzhalter auf dem Master‑Folie festzulegen und diese Einstellungen an alle untergeordneten Layout‑Folien weiterzugeben. So bleibt die Fußzeileninformation in der gesamten Präsentation einheitlich.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Holen Sie sich einen Verweis auf die Master‑Folie über deren Index.
1. Setzen Sie die Fußzeilen‑Platzhalter des Masters und aller Kind‑Folien auf sichtbar.
1. Setzen Sie die Foliennummer‑Platzhalter des Masters und aller Kind‑Folien auf sichtbar.
1. Setzen Sie die Datum‑Zeit‑Platzhalter des Masters und aller Kind‑Folien auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert diesen Vorgang:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Was ist der Unterschied zwischen einer Master‑Folie und einer Layout‑Folie?**

Eine Master‑Folie definiert das Gesamtdesign und die Standardformatierung, während Layout‑Folien spezifische Anordnungen von Platzhaltern für verschiedene Inhaltsarten festlegen.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja, Sie können eine Layout‑Folie aus der [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/)‑Sammlung einer Präsentation klonen und mit der Methode `add_clone` in eine andere einfügen.

**Was passiert, wenn ich eine Layout‑Folie lösche, die noch von einer Folie verwendet wird?**

Versuchen Sie, eine Layout‑Folie zu löschen, die noch von mindestens einer Folie referenziert wird, wirft Aspose.Slides eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/). Verwenden Sie stattdessen [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), um nur nicht genutzte Layout‑Folien sicher zu entfernen.