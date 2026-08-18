---
title: Verwalten von Präsentations‑Kopf‑ und Fußzeilen in JavaScript
linktitle: Kopf‑ und Fußzeile
type: docs
weight: 140
url: /de/nodejs-java/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile festlegen
- Fußzeile festlegen
- Handzettel
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fußzeilen-, Datum‑Zeit‑, Folienzahl‑ und Kopfzeilen‑Platzhalter auf Folien, Notizseiten und Handouts mit Aspose.Slides für Node.js über Java verwalten."
---
## **Übersicht**

PowerPoint verwendet je nach Folientyp unterschiedliche Kopf- und Fußzeilen-Platzhalter. Aspose.Slides für Node.js über Java ermöglicht es Ihnen, den Text und die Sichtbarkeit dieser Platzhalter über Klassen zur Verwaltung von Kopf- und Fußzeilen zu steuern.

Die verfügbaren Platzhalter hängen vom Geltungsbereich ab:

| Umfang | Kopfzeile | Fußzeile | Datum/Zeit | Folien-/Seitenzahl |
|---|---|---|---|---|
| Reguläre Folie | Nein | Ja | Ja | Ja |
| Notizmaster | Ja | Ja | Ja | Ja |
| Notizfolie | Ja | Ja | Ja | Ja |
| Handout-Master | Ja | Ja | Ja | Ja |

Eine reguläre Präsentationsfolie hat keinen Kopfzeilen-Platzhalter. Kopfzeilen sind auf Notizseiten und Handouts verfügbar. Für reguläre Folien verwenden Sie stattdessen die Fußzeilen-, Datum/Zeit- und Folienzahl-Platzhalter.

Der Geltungsbereich einer Änderung hängt vom verwendeten Manager ab. Die Klasse [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideheaderfootermanager/) steuert eine reguläre Folie. Die Klasse [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notesslideheaderfootermanager/) steuert eine Notizfolie. Master‑ und Layout‑Manager können Einstellungen auch an abhängige Folien weitergeben, während die Klasse [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) den Handout‑Master steuert.

## **Fußzeilen, Datum/Zeit und Folienzahlen auf regulären Folien festlegen**

Für reguläre Folien besteht der grundlegende Ablauf darin, den Kopf- und Fußzeilen-Manager jeder Folie aufzurufen, den Fußzeilen- und Datum/Zeit-Text festzulegen, die erforderlichen Platzhalter zu aktivieren und die Präsentation zu speichern. Folienzahlen werden von der Präsentation erzeugt, sodass Sie nur deren Sichtbarkeit steuern müssen.

Verwenden Sie [`setFooterText`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) und [`setDateTimeText`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText), um den Text festzulegen, und verwenden Sie [`setFooterVisibility`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) und [`setSlideNumberVisibility`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility), um die entsprechenden Platzhalter anzuzeigen.

Das folgende End-to-End-Beispiel wendet dieselbe Fußzeile, Datum/Zeit-Text und Folienzahl-Sichtbarkeit auf alle regulären Folien an:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie nur eine Folie aktualisieren müssen, greifen Sie über die Methode [`getSlides`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslides/) direkt auf diese Folie zu, anstatt die gesamte Sammlung zu durchlaufen.

## **Kopf- und Fußzeilen im Notiz-Master festlegen**

Der Notiz-Master definiert ein gemeinsames Format und das Platzhalter-Verhalten für Notizseiten. Verwenden Sie die Klasse [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/), wenn Sie nur den Notiz-Master selbst ändern möchten.

Das folgende Beispiel legt Kopf-, Fußzeilen- und Datum/Zeit-Text im Notiz-Master fest und macht alle unterstützten Platzhalter auf diesem Master sichtbar:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Methode [`getMasterNotesSlide`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) liefert `null`, wenn die Präsentation keinen Notiz-Master enthält.

## **Notiz-Master-Einstellungen auf untergeordnete Notiz-Folien anwenden**

Ein Notiz-Master kann Kopf- und Fußzeileneinstellungen sowohl auf sich selbst als auch auf alle abhängigen Notiz-Folien anwenden. Verwenden Sie die speziellen Propagations-Methoden der Klasse [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/), wenn dieselben Einstellungen über die gesamte Notiz-Hierarchie hinweg gelten sollen.

Zum Beispiel aktualisieren [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) und [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) die Kopfzeile des Notiz-Masters und alle untergeordneten Kopfzeilen. Entsprechende Methoden stehen für Fußzeilen, Datum/Zeit und Folienzahlen zur Verfügung.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die oben verwendeten Propagations-Methoden sind [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) und [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Kopf- und Fußzeilen auf einer einzelnen Notiz-Folie festlegen**

Eine Notizfolie gehört zu einer bestimmten regulären Folie. Verwenden Sie deren Klasse [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notesslideheaderfootermanager/), wenn Sie nur diese Notizseite anpassen möchten.

Die Methode [`addNotesSlide`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) gibt die Notizfolie für die aktuelle Folie zurück und erstellt sie, falls sie noch nicht existiert. Das folgende Beispiel konfiguriert die Notizseite, die mit der ersten Präsentationsfolie verknüpft ist:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie zunächst Einstellungen vom Notiz-Master propagieren und anschließend eine einzelne Notizfolie ändern, ermöglichen Ihnen die späteren Folien-spezifischen Einstellungen, diese Notizseite unabhängig zu bearbeiten.

## **Kopf- und Fußzeilen im Handout-Master festlegen**

Handout-Seiten verwenden den Handout-Master für ihre Kopf-, Fußzeilen-, Datum/Zeit- und Seitenzahl-Platzhalter. Im Gegensatz zu Notizseiten werden Handout-Einstellungen über den Handout-Master und nicht über einzelne Handout-Folien verwaltet.

Verwenden Sie [`getMasterHandoutSlide`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide), um auf den Handout-Master zuzugreifen. Falls er nicht vorhanden ist, rufen Sie [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) auf, um den Standard-Handout-Master zu erstellen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geltungsbereich und Vererbung verstehen**

Wählen Sie den Kopf-/Fußzeilen-Manager, der dem gewünschten Geltungsbereich entspricht:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideheaderfootermanager/) ändert Fußzeilen-, Datum/Zeit- und Folienzahl-Einstellungen für eine reguläre Folie.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) steuert eine Layout-Folie und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslideheaderfootermanager/) steuert einen regulären Folien-Master und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) steuert den Notiz-Master und kann Einstellungen an alle abhängigen Notiz-Folien weitergeben.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notesslideheaderfootermanager/) ändert eine Notizfolie und unterstützt zusätzlich zu Fußzeile, Datum/Zeit und Folienzahl einen Kopfzeilen-Platzhalter.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) ändert den Handout-Master und unterstützt alle vier Platzhaltertypen.

Verwenden Sie die Propagation von einem Master- oder Layout-Manager, wenn dieselbe Einstellung in der gesamten Hierarchie gelten soll. Nutzen Sie einen einzelnen Folien- oder Notiz-Folien-Manager, wenn Sie eine lokale Einstellung für eine Seite benötigen.

## **FAQ**

**Kann ich einer regulären Folie eine Kopfzeile hinzufügen?**

Nein. PowerPoint definiert keinen Kopfzeilen-Platzhalter für reguläre Folien. Auf regulären Folien verwenden Sie die Fußzeilen-, Datum/Zeit- und Folienzahl-Platzhalter. Kopfzeilen-Platzhalter sind auf Notizseiten und Handouts verfügbar.

**Was ist, wenn ein Fußzeilen-, Datum/Zeit- oder Folienzahl-Platzhalter nicht sichtbar ist?**

Verwenden Sie den entsprechenden Kopf-/Fußzeilen-Manager, um dessen Sichtbarkeit zu prüfen und bei Bedarf zu aktivieren. Zum Beispiel gibt [`isFooterVisible`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) an, ob ein Fußzeilen-Platzhalter vorhanden ist, und [`setFooterVisibility`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) ändert dessen Sichtbarkeit.

**Wie beginne ich die Foliennummerierung mit einem anderen Wert als 1?**

Rufen Sie die Methode [`setFirstSlideNumber`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) der Präsentation auf. Die Folienzahl-Platzhalter verwenden dann die aktualisierte Nummerierungssequenz.

**Was passiert mit Kopf- und Fußzeilen beim Exportieren in PDF, Bilder oder HTML?**

Sichtbare Kopf- und Fußzeilen-Elemente werden zusammen mit dem restlichen Präsentationsinhalt im Ausgabeformat gerendert. Ihr Erscheinungsbild hängt vom zu exportierenden Seitentyp und den entsprechenden Platzhalter-Sichtbarkeitseinstellungen ab.