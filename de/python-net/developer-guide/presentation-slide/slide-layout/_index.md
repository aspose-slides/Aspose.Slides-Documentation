---
title: Slide-Layouts in Python anwenden oder ändern
linktitle: Slide-Layout
type: docs
weight: 60
url: /de/python-net/slide-layout/
keywords:
- Slide-Layout
- Inhalts-Layout
- Platzhalter
- Präsentationsdesign
- Foliengestaltung
- Unbenutztes Layout
- Fußzeilensichtbarkeit
- Titelfolie
- Titel und Inhalt
- Abschnittsüberschrift
- Zwei Inhalte
- Vergleich
- Nur Titel
- Leeres Layout
- Inhalt mit Beschriftung
- Bild mit Beschriftung
- Titel und vertikaler Text
- Vertikaler Titel und Text
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Slide-Layouts in Aspose.Slides für Python via .NET anwenden, erstellen und ändern, Platzhalter hinzufügen, unbenutzte Layouts entfernen und die Fußzeilensichtbarkeit steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und die Formatierung von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, ermöglicht jedoch, dass jede Folie ihren eigenen Inhalt enthält.

Die am häufigsten verwendeten Layouts umfassen:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemeinen Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhalts‑Platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layoutvererbung**

Eine Präsentation hat drei verwandte Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/) definiert das Design, die gemeinsame Formatierung, Hintergründe und gemeinsame Objekte.
2. Eine [Layoutfolie](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
3. Eine [Normalfolie](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine Normalfolie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer Normalfolie festgelegter Wert überschreibt den geerbten Wert auf dieser Ebene. Wenn eine Normalfolie erstellt wird, werden ihre Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur Normalfolie gehört.

Fügen Sie erforderliche Platzhalter zu einem Layout hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout erzeugt nicht automatisch die entsprechende Platzhalterform in bereits vorhandenen Normalfolien.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern der vererbten Formatierung oder der vorhandenen Platzhaltergeometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Vor dem Bearbeiten eines bereits genutzten Layouts sollten Sie dessen abhängige Folien prüfen und die resultierende Präsentation überprüfen.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie seine abhängigen Folien zuerst einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Folienmaster](/slides/de/python-net/slide-master/).

Um geerbte Logos oder dekorative Master‑Formen auf einer Folie oder über ein gemeinsam genutztes Layout auszublenden, siehe [Steuerung der Sichtbarkeit von Master‑Grafiken](/slides/de/python-net/slide-master/). Das Beispiel vergleicht zwei Folien, die denselben Master verwenden.

## **Auswählen und Anwenden eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den standardmäßigen PowerPoint‑Layout‑Definitionen folgt. Layout‑Namen können vom Benutzer bearbeitet und lokalisiert werden, daher ist eine Auswahl anhand des Namens weniger zuverlässig, es sei denn, Sie kontrollieren die Ausgangsvorlage.

Das folgende Beispiel sucht auf dem ersten Master nach **Titel und Inhalt**. Wenn dieses Layout nicht verfügbar ist, fällt es bewusst auf **Leer** zurück. Die zweite Null‑Prüfung ist erforderlich, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die Eigenschaft [Slide.layout_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/layout_slide/) auf die erste Normalfolie angewendet.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Das Ändern des Layouts einer Folie entfernt nicht die regulären Formen, die direkt zur Folie hinzugefügt wurden. Allerdings können Platzhalterpositionen, vererbte Formatierung und die Zuordnung zwischen bestehenden Platzhaltern und dem neuen Layout geändert werden, sodass Sie die Ausgabe prüfen sollten, wenn Sie zwischen deutlich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind separate Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die Methode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterlayoutslidecollection/add/) auf der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine Normalfolie, die darauf basiert. Layout‑Namen müssen innerhalb der Sammlung eindeutig sein.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert bereits ein geeignetes Layout, wählen Sie es aus und verwenden Sie es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die Eigenschaft [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/placeholder_manager/) stellt einen [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout bereit.

| PowerPoint-Platzhalter | `LayoutPlaceholderManager` Methode |
| ---------------------- | ----------------------------------- |
| ![Inhalt](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Inhalt (Vertikal)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertikal)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Bild](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Diagramm](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabelle](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Medium](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online‑Bild](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout vorhanden ist, fügt ihm vier Platzhalter hinzu und erstellt anschließend eine Normalfolie, die das modifizierte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die Normalfolie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie erzeugen kann.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Platzhalter auf der Layoutfolie](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Das Ändern der vererbten Formatierung oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bestehende Normalfolien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Entfernen ungenutzter Layoutfolien**

Verwenden Sie die Methode [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), um Layouts zu entfernen, auf die keine Normalfolie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Um ein bestimmtes Layout zu entfernen, verwenden Sie zunächst seine Eigenschaft [has_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/has_depending_slides/) oder die Methode [get_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/get_depending_slides/). Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [LayoutSlide.remove](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/remove/) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilensichtbarkeit auf einer Layoutfolie**

Ein Layout verfügt über eigene Fußzeilen-, Foliennummer‑ und Datum‑Uhrzeit‑Platzhalter. Verwenden Sie die Eigenschaft [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/header_footer_manager/), um diese Platzhalter für ein Layout zu steuern. Dies ist nützlich, wenn beispielsweise Inhalts‑Layouts Fußzeilen anzeigen sollen, Titel‑Layouts jedoch nicht.

Das folgende Beispiel wählt ein Layout sicher aus und macht dessen Fußzeilenelemente sichtbar:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Steuerung der Fußzeilensichtbarkeit auf einem Master und dessen Kind‑Layouts**

Um konsistente Fußzeileneinstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die Eigenschaft [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/header_footer_manager/). Die Propagationsmethoden von [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Normalfolien; sie richten sich nicht nur an eine einzelne Normalfolie.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Häufig gestellte Fragen**

**Was ist der Unterschied zwischen einer Masterfolie und einer Layoutfolie?**

Eine Masterfolie definiert das Design der Präsentation und die gemeinsam genutzte Formatierung. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Normalfolien verwenden diese Layouts und speichern den folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie mit der Methode [add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/globallayoutslidecollection/add_clone/) eine Kopie zur Ziel‑Sammlung hinzu. Beim Kopieren zwischen Präsentationen sollten Sie außerdem Schriften, Designs, Bilder und andere vom Quell‑Layout verwendete Ressourcen überprüfen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien erben die Layout‑Änderungen, sofern sie die betroffene Formatierung oder Objekte nicht lokal überschreiben. Daher können die Platzhaltergeometrie und die geerbte Gestaltung gleichzeitig auf vielen Folien geändert werden. Verwenden Sie [get_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/get_depending_slides/), um vor dem Bearbeiten des Layouts die betroffenen Folien zu ermitteln.

**Was passiert, wenn ich ein noch verwendetes Layout entferne?**

Aspose.Slides löst eine [PptxEditException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxeditexception/) aus. Ordnen Sie zuerst die abhängigen Folien neu zu oder verwenden Sie [remove_unused_layout_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), um nur nicht referenzierte Layouts zu entfernen.