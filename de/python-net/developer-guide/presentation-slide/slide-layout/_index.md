---
title: Folienlayouts in Python anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/python-net/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliendesign
- unbenutztes Layout
- Fußzeilen‑Sichtbarkeit
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
description: "Folienlayouts in Aspose.Slides für Python über .NET anwenden, erstellen und ändern, Platzhalter hinzufügen, unbenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und die Formatierung von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Durch das Anwenden eines Layouts erhalten Folien eine konsistente Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die am häufigsten verwendeten Layouts umfassen:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titelplatzhalter und einen allgemein nutzbaren Inhaltsplatzhalter.
- **Leer**: Enthält keine Inhaltsplatzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layoutvererbung**

Eine Präsentation hat drei miteinander verbundene Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/) definiert das Thema, die gemeinsame Formatierung, Hintergründe und gemeinsame Objekte.
1. Eine [Layoutfolie](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
1. Eine [normale Folie](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine normale Folie erbt Thema und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer normalen Folie festgelegter Wert überschreibt den vererbten Wert auf dieser Ebene. Wenn eine normale Folie erstellt wird, werden ihre Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur normalen Folie gehört.

Fügen Sie einem Layout die erforderlichen Platzhalter hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechenden Platzhalterformen zu bereits existierenden normalen Folien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern der vererbten Formatierung oder der vorhandenen Platzhaltergeometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Vor dem Bearbeiten eines bereits verwendeten Layouts sollten Sie seine abhängigen Folien prüfen und die resultierende Präsentation überprüfen.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie seine abhängigen Folien zuerst einem anderen Layout zu oder entfernen Sie nur nicht verwendete Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Slide Master](/slides/de/python-net/slide-master/).

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den standardmäßigen PowerPoint‑Layoutdefinitionen folgt. Layoutnamen können vom Benutzer bearbeitet und lokalisiert werden, sodass eine namensbasierte Auswahl weniger zuverlässig ist, es sei denn, Sie steuern die Quellvorlage.

Das folgende Beispiel sucht in dem ersten Master nach **Titel und Inhalt**. Wenn dieses Layout nicht verfügbar ist, greift es bewusst auf **Leer** zurück. Die zweite Null‑Prüfung ist erforderlich, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird anschließend über die Eigenschaft [Slide.layout_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/layout_slide/) auf die erste normale Folie angewendet.

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

Das Ändern des Layouts einer Folie entfernt nicht die direkt zur Folie hinzugefügten normalen Formen. Platzhalterpositionen, vererbte Formatierung und die Übereinstimmung zwischen bestehenden Platzhaltern und dem neuen Layout können sich jedoch ändern, sodass Sie die Ausgabe prüfen sollten, wenn Sie zwischen wesentlich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind getrennte Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die Methode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterlayoutslidecollection/add/) auf der Layoutsammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine normale Folie basierend darauf. Layoutnamen müssen innerhalb der Sammlung eindeutig sein.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Fügen Sie ein Layout nur hinzu, wenn die Vorlage wirklich eine weitere wiederverwendbare Struktur benötigt. Falls bereits ein geeignetes Layout existiert, wählen Sie es aus und verwenden Sie es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die Eigenschaft [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/placeholder_manager/) stellt einen [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout bereit.

| PowerPoint‑Platzhalter | `LayoutPlaceholderManager`‑Methode |
| ---------------------- | ----------------------------------- |
| ![Inhalt](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Inhalt (vertikal)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (vertikal)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Bild](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Diagramm](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabelle](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online‑Bild](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout existiert, fügt ihm vier Platzhalter hinzu und erstellt anschließend eine normale Folie, die das modifizierte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die normale Folie erstellt wird, damit Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie generieren kann.

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
Das Ändern der vererbten Formatierung oder der Geometrie bestehender Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht nachträglich in bereits vorhandene normale Folien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Entfernen nicht verwendeter Layoutfolien**

Verwenden Sie die Methode [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), um Layouts zu entfernen, auf die keine normale Folie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Um ein bestimmtes Layout zu entfernen, verwenden Sie zunächst seine Eigenschaft [has_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/has_depending_slides/) oder die Methode [get_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/get_depending_slides/). Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [LayoutSlide.remove](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/remove/) aufrufen. Der Versuch, ein noch verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout hat eigene Platzhalter für Fußzeile, Folienzahl und Datum‑Uhrzeit. Verwenden Sie die Eigenschaft [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/header_footer_manager/), um diese Platzhalter für ein Layout zu steuern. Dies ist nützlich, wenn beispielsweise Inhalts‑Layouts Fußzeilen anzeigen sollen, Titelfolien jedoch nicht.

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

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und seinen untergeordneten Layouts**

Um über eine Master‑Hierarchie hinweg einheitliche Fußzeileneinstellungen anzuwenden, verwenden Sie die Eigenschaft [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslide/header_footer_manager/). Die Propagationsmethoden von [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Normalfolien; sie zielen nicht nur auf eine einzelne normale Folie.

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

## **FAQ**

**Was ist der Unterschied zwischen einer Masterfolie und einer Layoutfolie?**

Eine Masterfolie definiert das Thema und die gemeinsame Formatierung der Präsentation. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Normale Folien verwenden diese Layouts und speichern folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie mit der Methode [add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/globallayoutslidecollection/add_clone/) eine Kopie zur Ziel‑Sammlung hinzu. Beim Kopieren zwischen Präsentationen sollten Sie außerdem Schriftarten, Themen, Bilder und weitere vom Quell‑Layout genutzte Ressourcen prüfen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien übernehmen die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschreiben. Die Platzhaltergeometrie und die vererbte Gestaltung können dadurch auf vielen Folien gleichzeitig geändert werden. Verwenden Sie [get_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/get_depending_slides/), um die betroffenen Folien vor der Bearbeitung des Layouts zu ermitteln.

**Was passiert, wenn ich ein noch verwendetes Layout entferne?**

Aspose.Slides löst eine [PptxEditException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxeditexception/) aus. Ordnen Sie zunächst die abhängigen Folien neu zu oder verwenden Sie [remove_unused_layout_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), um nur nicht referenzierte Layouts zu entfernen.