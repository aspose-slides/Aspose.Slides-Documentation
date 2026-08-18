---
title: Verwalten von Präsentationskopf- und -fußzeilen mit Python
linktitle: Kopf- und Fußzeile
type: docs
weight: 140
url: /de/python-net/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile festlegen
- Fußzeile festlegen
- Handout
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fußzeilen-, Datum-Uhrzeit-, Folien-Nummern- und Kopfzeilen-Platzhalter auf Folien, Notizseiten und Handouts mit Aspose.Slides für Python über .NET verwalten."
---
## **Übersicht**

PowerPoint verwendet je nach Folientyp unterschiedliche Kopf‑ und Fußzeilen‑Platzhalter. Aspose.Slides für Python über .NET ermöglicht es Ihnen, den Text und die Sichtbarkeit dieser Platzhalter über Klassen des Kopf‑/Fußzeilen‑Managers zu steuern.

Die verfügbaren Platzhalter hängen vom Geltungsbereich ab:

| Umfang | Kopfzeile | Fußzeile | Datum/Uhrzeit | Folien-/Seitenzahl |
|---|---|---|---|---|
| Normale Folie | Nein | Ja | Ja | Ja |
| Notizen‑Master | Ja | Ja | Ja | Ja |
| Notizen‑Folie | Ja | Ja | Ja | Ja |
| Handout‑Master | Ja | Ja | Ja | Ja |

Eine normale Präsentationsfolie hat keinen Kopfzeilen‑Platzhalter. Kopfzeilen sind auf Notizseiten und Handouts verfügbar. Für normale Folien verwenden Sie stattdessen die Fußzeilen‑, Datum‑/Uhrzeit‑ und Folien‑Nummern‑Platzhalter.

Der Geltungsbereich einer Änderung hängt vom verwendeten Manager ab. Die [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/slideheaderfootermanager/)‑Klasse steuert eine normale Folie. Die [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/notesslideheaderfootermanager/)‑Klasse steuert eine Notizen‑Folie. Master‑ und Layout‑Manager können Einstellungen zudem an abhängige Folien weitergeben, während die [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterhandoutslideheaderfootermanager/)‑Klasse den Handout‑Master kontrolliert.

## **Fußzeile, Datum/Uhrzeit und Folienzahlen auf normalen Folien festlegen**

Für normale Folien besteht der grundlegende Ablauf darin, den Kopf‑/Fußzeilen‑Manager jeder Folie aufzurufen, den Fußzeilen‑ und Datum/Uhrzeit‑Text zu setzen, die benötigten Platzhalter zu aktivieren und die Präsentation zu speichern. Folienzahlen werden von der Präsentation erzeugt, daher müssen Sie nur deren Sichtbarkeit steuern.

Verwenden Sie [`set_footer_text`](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) und [`set_date_time_text`](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/), um Text zu setzen, und [`set_footer_visibility`](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), sowie [`set_slide_number_visibility`](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/), um die entsprechenden Platzhalter anzuzeigen.

Das folgende End‑to‑End‑Beispiel wendet dieselbe Fußzeile, denselben Datum/Uhrzeit‑Text und dieselbe Folien‑Nummern‑Sichtbarkeit auf alle normalen Folien an:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie nur eine einzelne Folie aktualisieren müssen, greifen Sie direkt über die [`slides`](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slides/de/)‑Sammlung auf diese Folie zu, anstatt die gesamte Sammlung zu durchlaufen.

## **Kopf‑ und Fußzeilen im Notizen‑Master festlegen**

Der Notizen‑Master definiert ein gemeinsames Layout und das Verhalten der Platzhalter für Notizseiten. Verwenden Sie die [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/)‑Klasse, wenn Sie ausschließlich den Notizen‑Master ändern möchten.

Das folgende Beispiel setzt Kopfzeile, Fußzeile und Datum/Uhrzeit‑Text im Notizen‑Master und macht alle unterstützten Platzhalter auf diesem Master sichtbar:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Eine Präsentation kann keinen Notizen‑Master enthalten; prüfen Sie daher den zurückgegebenen Wert auf `None`, bevor Sie Änderungen vornehmen.

## **Notizen‑Master‑Einstellungen auf untergeordnete Notizen‑Folien anwenden**

Ein Notizen‑Master kann Kopf‑ und Fußzeileneinstellungen sowohl für sich selbst als auch für alle abhängigen Notizen‑Folien übernehmen. Verwenden Sie die dedizierten Propagations‑Methoden der [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/), wenn dieselben Einstellungen über die gesamte Notizen‑Hierarchie hinweg gelten sollen.

Beispielsweise aktualisieren [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) und [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) die Kopfzeile des Notizen‑Masters und aller untergeordneten Kopfzeilen. Entsprechende Methoden gibt es für Fußzeilen, Datum/Uhrzeit und Folienzahlen.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Die oben verwendeten Propagations‑Methoden sind [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), und [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Kopf‑ und Fußzeilen auf einer einzelnen Notizen‑Folie festlegen**

Eine Notizen‑Folie gehört zu einer bestimmten normalen Folie. Verwenden Sie deren [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/notesslideheaderfootermanager/)‑Klasse, wenn Sie nur diese Notizenseite anpassen möchten.

Die Methode [`add_notes_slide`](https://reference.aspose.com/slides/de/python-net/aspose.slides/notesslidemanager/add_notes_slide/) liefert die Notizen‑Folie für die aktuelle Folie und erzeugt sie, falls sie noch nicht existiert. Das folgende Beispiel konfiguriert die Notizenseite, die mit der ersten Präsentationsfolie verknüpft ist:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie zuerst Einstellungen vom Notizen‑Master propagieren und anschließend eine einzelne Notizen‑Folie ändern, ermöglichen die nachträglichen Folien‑spezifischen Einstellungen eine unabhängige Anpassung dieser Notizenseite.

## **Kopf‑ und Fußzeilen auf dem Handout‑Master festlegen**

Handout‑Seiten verwenden den Handout‑Master für ihre Kopf‑, Fußzeilen‑, Datum/Uhrzeit‑ und Seitenzahlen‑Platzhalter. Im Gegensatz zu Notizenseiten werden Handout‑Einstellungen über den Handout‑Master und nicht über einzelne Handout‑Folien verwaltet.

Verwenden Sie die Eigenschaft [`master_handout_slide`](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/), um auf den Handout‑Master zuzugreifen. Falls er nicht vorhanden ist, rufen Sie [`set_default_master_handout_slide`](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) auf, um den Standard‑Handout‑Master zu erstellen.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Umfang und Vererbung verstehen**

Wählen Sie den Kopf‑/Fußzeilen‑Manager, der dem gewünschten Umfang entspricht:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/slideheaderfootermanager/) ändert Fußzeile, Datum/Uhrzeit und Folien‑Nummer‑Einstellungen für eine normale Folie.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslideheaderfootermanager/) steuert eine Layout‑Folie und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslideheaderfootermanager/) steuert einen regulären Folien‑Master und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslideheaderfootermanager/) steuert den Notizen‑Master und kann Einstellungen an alle abhängigen Notizen‑Folien weitergeben.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/notesslideheaderfootermanager/) ändert eine Notizen‑Folie und unterstützt neben Fußzeile, Datum/Uhrzeit und Folienzahl auch einen Kopfzeilen‑Platzhalter.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) ändert den Handout‑Master und unterstützt alle vier Platzhalter‑Typen.

Verwenden Sie die Propagation von einem Master‑ oder Layout‑Manager, wenn dieselbe Einstellung für die gesamte Hierarchie gelten soll. Nutzen Sie einen einzelnen Folien‑ oder Notizen‑Slide‑Manager, wenn Sie eine lokale Einstellung für eine Seite benötigen.

## **FAQ**

**Kann ich einer normalen Folie eine Kopfzeile hinzufügen?**

Nein. PowerPoint definiert keinen Kopfzeilen‑Platzhalter für normale Folien. Verwenden Sie auf normalen Folien die Fußzeilen‑, Datum/Uhrzeit‑ und Folien‑Nummern‑Platzhalter. Kopfzeilen‑Platzhalter stehen nur auf Notizseiten und Handouts zur Verfügung.

**Was tun, wenn ein Fußzeilen‑, Datum/Uhrzeit‑ oder Folien‑Nummern‑Platzhalter nicht sichtbar ist?**

Verwenden Sie den entsprechenden Kopf‑/Fußzeilen‑Manager, um die Sichtbarkeit zu prüfen und bei Bedarf zu aktivieren. Beispielsweise gibt [`is_footer_visible`](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) an, ob ein Fußzeilen‑Platzhalter vorhanden ist, und [`set_footer_visibility`](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) ändert dessen Sichtbarkeit.

**Wie starte ich die Foliennummerierung mit einem anderen Wert als 1?**

Setzen Sie die Eigenschaft [`first_slide_number`](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/first_slide_number/) der Präsentation. Die Folien‑Nummern‑Platzhalter verwenden dann die aktualisierte Nummerierungssequenz.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren in PDF, Bilder oder HTML?**

Sichtbare Kopf‑ und Fußzeilen‑Elemente werden zusammen mit dem restlichen Präsentationsinhalt im Ausgabeformat gerendert. Das Aussehen hängt vom zu exportierenden Folientyp und den jeweiligen Sichtbarkeitseinstellungen der Platzhalter ab.