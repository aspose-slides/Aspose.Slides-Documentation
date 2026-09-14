---
title: Verwalten von Präsentationskopf‑ und -fußzeilen in Python über Java
linktitle: Kopf‑ und Fußzeile
type: docs
weight: 140
url: /de/python-java/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile setzen
- Fußzeile setzen
- Handzettel
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fußzeilen‑, Datum‑Uhrzeit‑, Folien‑Nummern‑ und Kopfzeilen‑Platzhalter auf Folien, Notizseiten und Handzetteln mit Aspose.Slides für Python über Java verwalten."
---
## **Übersicht**

PowerPoint verwendet je nach Folientyp unterschiedliche Platzhalter für Kopf‑ und Fußzeilen. Aspose.Slides für Python über Java ermöglicht die Steuerung von Text und Sichtbarkeit dieser Platzhalter über Kopf‑/Fußzeilen‑Manager‑Klassen.

Die verfügbaren Platzhalter hängen vom Geltungsbereich ab:

| Geltungsbereich | Kopfzeile | Fußzeile | Datum/Uhrzeit | Folien-/Seitennummer |
|---|---|---|---|---|
| Normale Folie | Nein | Ja | Ja | Ja |
| Notizen‑Master | Ja | Ja | Ja | Ja |
| Notizen‑Folie | Ja | Ja | Ja | Ja |
| Handzettel‑Master | Ja | Ja | Ja | Ja |

Eine reguläre Präsentationsfolie hat keinen Kopfzeilen‑Platzhalter. Kopfzeilen sind auf Notizseiten und Handzetteln verfügbar. Für reguläre Folien verwenden Sie stattdessen die Platzhalter Fußzeile, Datum/Uhrzeit und Folien‑Nummer.

Der Geltungsbereich einer Änderung hängt vom verwendeten Manager ab. Die [SlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideheaderfootermanager/)‑Klasse steuert eine einzelne reguläre Folie. Die [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/notesslideheaderfootermanager/)‑Klasse steuert eine einzelne Notizenfolie. Master‑ und Layout‑Manager können Einstellungen außerdem an abhängige Folien weitergeben, während die [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterhandoutslideheaderfootermanager/)‑Klasse den Handzettel‑Master steuert.

## **Fußzeile, Datum/Uhrzeit und Folien‑Nummern auf regulären Folien festlegen**

Für reguläre Folien besteht der grundlegende Ablauf darin, den Kopf‑/Fußzeilen‑Manager jeder Folie zu öffnen, den Fußzeilen‑ und Datum/Uhrzeit‑Text zu setzen, die benötigten Platzhalter zu aktivieren und die Präsentation zu speichern. Folien‑Nummern werden von der Präsentation erzeugt, sodass nur deren Sichtbarkeit zu steuern ist.

Verwenden Sie [setFooterText](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) und [setDateTimeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText), um Text zu setzen, und [setFooterVisibility](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) sowie [setSlideNumberVisibility](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility), um die entsprechenden Platzhalter anzuzeigen.

Das folgende End‑to‑End‑Beispiel wendet dieselbe Fußzeile, denselben Datum/Uhrzeit‑Text und dieselbe Folien‑Nummern‑Sichtbarkeit auf alle regulären Folien an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wenn Sie nur eine Folie aktualisieren müssen, greifen Sie direkt über die [getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides)‑Methode auf diese Folie zu, anstatt die gesamte Sammlung zu durchlaufen.

## **Kopf‑ und Fußzeilen auf dem Notizen‑Master festlegen**

Der Notizen‑Master definiert einheitliche Formatierung und Platzhalter‑Verhalten für Notizseiten. Verwenden Sie die [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/)‑Klasse, wenn Sie nur den Notizen‑Master selbst ändern möchten.

Das folgende Beispiel setzt Kopfzeile, Fußzeile und Datum/Uhrzeit‑Text auf dem Notizen‑Master und macht alle unterstützten Platzhalter auf diesem Master sichtbar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Methode `getMasterNotesSlide` gibt `None` zurück, wenn die Präsentation keinen Notizen‑Master enthält.

## **Notizen‑Master‑Einstellungen auf untergeordnete Notizen‑Folien anwenden**

Ein Notizen‑Master kann Kopf‑ und Fußzeilen‑Einstellungen auf sich selbst und auf alle abhängigen Notizen‑Folien anwenden. Verwenden Sie die dedizierten Propagations‑Methoden der [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/), wenn dieselben Einstellungen über die gesamte Notizen‑Hierarchie hinweg gelten sollen.

Beispielsweise aktualisieren [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) und [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) die Kopfzeile des Notizen‑Masters und aller untergeordneten Kopfzeilen. Entsprechende Methoden stehen für Fußzeilen, Datum/Uhrzeit und Folien‑Nummern zur Verfügung.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die oben verwendeten Propagations‑Methoden sind [setFooterAndChildFootersText](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) und [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Kopf‑ und Fußzeilen auf einer einzelnen Notizen‑Folie festlegen**

Eine Notizen‑Folie gehört zu einer bestimmten regulären Folie. Verwenden Sie deren [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/notesslideheaderfootermanager/), wenn Sie nur diese Notizseite anpassen möchten.

Die [addNotesSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/notesslidemanager/#addNotesSlide)‑Methode gibt die Notizen‑Folie für die aktuelle Folie zurück und erstellt sie, falls sie noch nicht existiert. Das folgende Beispiel konfiguriert die Notizseite, die mit der ersten Präsentationsfolie verknüpft ist:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wenn Sie zunächst Einstellungen vom Notizen‑Master propagieren und danach eine einzelne Notizen‑Folie ändern, ermöglichen die späteren Folien‑spezifischen Einstellungen eine unabhängige Anpassung dieser Notizseite.

## **Kopf‑ und Fußzeilen auf dem Handzettel‑Master festlegen**

Handzettel‑Seiten verwenden den Handzettel‑Master für ihre Kopf‑, Fußzeilen‑, Datum/Uhrzeit‑ und Seiten‑Nummer‑Platzhalter. Im Gegensatz zu Notizseiten werden Handzettel‑Einstellungen über den Handzettel‑Master verwaltet, nicht über einzelne Handzettel‑Folien.

Verwenden Sie die Methode `getMasterHandoutSlide`, um auf den Handzettel‑Master zuzugreifen. Falls er nicht vorhanden ist, rufen Sie `setDefaultMasterHandoutSlide` auf, um den Standard‑Handzettel‑Master zu erstellen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Geltungsbereich und Vererbung verstehen**

Wählen Sie den Kopf‑/Fußzeilen‑Manager, der dem Geltungsbereich entspricht, den Sie ändern möchten:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideheaderfootermanager/) ändert Fußzeile, Datum/Uhrzeit und Folien‑Nummer‑Einstellungen für eine reguläre Folie.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslideheaderfootermanager/) steuert eine Layout‑Folie und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslideheaderfootermanager/) steuert einen regulären Folien‑Master und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslideheaderfootermanager/) steuert den Notizen‑Master und kann Einstellungen an alle abhängigen Notizen‑Folien weitergeben.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/notesslideheaderfootermanager/) ändert eine Notizen‑Folie und unterstützt zusätzlich einen Kopfzeilen‑Platzhalter zu Fußzeile, Datum/Uhrzeit und Folien‑Nummer.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) ändert den Handzettel‑Master und unterstützt alle vier Platzhaltertypen.

Verwenden Sie die Propagation von einem Master oder Layout, wenn dieselbe Einstellung über die gesamte Hierarchie gelten soll. Verwenden Sie einen einzelnen Folien‑ oder Notizen‑Folie‑Manager, wenn Sie eine lokale Einstellung für eine Seite benötigen.

## **FAQ**

**Kann ich einer regulären Folie eine Kopfzeile hinzufügen?**

Nein. PowerPoint definiert keinen Kopfzeilen‑Platzhalter für reguläre Folien. Auf regulären Folien verwenden Sie die Platzhalter Fußzeile, Datum/Uhrzeit und Folien‑Nummer. Kopfzeilen­Platzhalter stehen auf Notizseiten und Handzetteln zur Verfügung.

**Was tun, wenn ein Fußzeilen‑, Datum/Uhrzeit‑ oder Folien‑Nummer‑Platzhalter nicht sichtbar ist?**

Verwenden Sie den entsprechenden Kopf‑/Fußzeilen‑Manager, um dessen Sichtbarkeit zu prüfen und bei Bedarf zu aktivieren. Beispielsweise gibt [isFooterVisible](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) an, ob ein Fußzeilen‑Platzhalter vorhanden ist, und [setFooterVisibility](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) ändert dessen Sichtbarkeit.

**Wie beginne ich die Folien‑Nummerierung mit einem anderen Wert als 1?**

Rufen Sie die Methode [setFirstSlideNumber](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#setFirstSlideNumber) der Präsentation auf. Die Folien‑Nummern‑Platzhalter verwenden dann die aktualisierte Nummerierungssequenz.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren in PDF, Bilder oder HTML?**

Sichtbare Kopf‑ und Fußzeilen‑Elemente werden zusammen mit dem übrigen Präsentationsinhalt im Ausgabeformat gerendert. Ihr Erscheinungsbild hängt vom zu exportierenden Seitentyp und den entsprechenden Platzhalter‑Sichtbarkeitseinstellungen ab.