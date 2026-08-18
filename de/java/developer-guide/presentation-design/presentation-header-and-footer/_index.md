---
title: Verwalten von Präsentationskopf- und -fußzeilen in Java
linktitle: Kopf‑ und Fußzeile
type: docs
weight: 140
url: /de/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fußzeilen-, Datum‑Uhrzeit-, Folienzahl‑ und Kopfzeilen‑Platzhalter auf Folien, Notizenseiten und Handzetteln mit Aspose.Slides für Java verwalten."
---
## **Übersicht**

PowerPoint verwendet je nach Seitentyp unterschiedliche Kopf‑ und Fußzeilen‑Platzhalter. Aspose.Slides for Java ermöglicht die Steuerung von Text und Sichtbarkeit dieser Platzhalter über Kopf‑/Fußzeilen‑Manager‑Schnittstellen.

Die verfügbaren Platzhalter hängen vom Geltungsbereich ab:

| Geltungsbereich | Kopfzeile | Fußzeile | Datum/Uhrzeit | Folien‑/Seitenzahl |
|---|---|---|---|---|
| Reguläre Folie | Nein | Ja | Ja | Ja |
| Notizen‑Master | Ja | Ja | Ja | Ja |
| Notizen‑Folie | Ja | Ja | Ja | Ja |
| Handzettel‑Master | Ja | Ja | Ja | Ja |

Eine reguläre Präsentationsfolie hat keinen Kopfzeilen‑Platzhalter. Kopfzeilen sind auf Notizenseiten und Handzetteln verfügbar. Für reguläre Folien verwenden Sie stattdessen die Fußzeilen‑, Datum/Uhrzeit‑ und Folien‑Nummer‑Platzhalter.

Der Geltungsbereich einer Änderung hängt vom verwendeten Manager ab. Die [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideheaderfootermanager/)‑Schnittstelle steuert eine reguläre Folie. Die [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/java/com.aspose.slides/inotesslideheaderfootermanager/)‑Schnittstelle steuert eine Notizfolie. Master‑ und Layout‑Manager können Einstellungen auch an abhängige Folien weitergeben, während die [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/)‑Schnittstelle den Handzettel‑Master steuert.

## **Fußzeile, Datum/Uhrzeit und Folienzahlen auf regulären Folien festlegen**

Für reguläre Folien besteht der grundlegende Arbeitsablauf darin, den Kopf‑/Fußzeilen‑Manager jeder Folie aufzurufen, den Fußzeilen‑ und Datum/Uhrzeit‑Text festzulegen, die benötigten Platzhalter zu aktivieren und die Präsentation zu speichern. Folienzahlen werden von der Präsentation generiert, sodass Sie nur deren Sichtbarkeit steuern müssen.

Verwenden Sie [`setFooterText`](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) und [`setDateTimeText`](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-), um den Text festzulegen, und [`setFooterVisibility`](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), sowie [`setSlideNumberVisibility`](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-), um die entsprechenden Platzhalter anzuzeigen.

Das folgende End‑to‑End‑Beispiel wendet dieselbe Fußzeile, Datum/Uhrzeit‑Text und Folienzahl‑Sichtbarkeit auf alle regulären Folien an:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie nur eine Folie aktualisieren müssen, greifen Sie direkt über die [`getSlides`](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlides--)‑Methode auf diese Folie zu, anstatt die gesamte Sammlung zu durchlaufen.

## **Kopf‑ und Fußzeilen auf dem Notizen‑Master festlegen**

Der Notizen‑Master definiert ein gemeinsames Format und das Platzhalterverhalten für Notizenseiten. Verwenden Sie die [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/)‑Schnittstelle, wenn Sie nur den Notizen‑Master selbst ändern möchten.

Das folgende Beispiel legt Kopfzeile, Fußzeile und Datum/Uhrzeit‑Text im Notizen‑Master fest und macht alle unterstützten Platzhalter auf diesem Master sichtbar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die [`getMasterNotesSlide`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--)‑Methode liefert `null`, wenn die Präsentation keinen Notizen‑Master enthält.

## **Notizen‑Master‑Einstellungen auf untergeordnete Notizfolien anwenden**

Ein Notizen‑Master kann Kopf‑ und Fußzeileneinstellungen sowohl auf sich selbst als auch auf alle abhängigen Notizfolien anwenden. Verwenden Sie die dedizierten Propagationsmethoden der [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/), wenn dieselben Einstellungen über die Notizen‑Hierarchie hinweg gelten sollen.

Zum Beispiel aktualisieren [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) und [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) die Notizen‑Master‑Kopfzeile und alle untergeordneten Kopfzeilen. Entsprechende Methoden stehen für Fußzeilen, Datum/Uhrzeit und Folienzahlen zur Verfügung.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die oben verwendeten Propagationsmethoden sind [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), und [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Kopf‑ und Fußzeilen auf einer einzelnen Notizfolie festlegen**

Eine Notizfolie gehört zu einer bestimmten regulären Folie. Verwenden Sie deren [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/java/com.aspose.slides/inotesslideheaderfootermanager/)‑Schnittstelle, wenn Sie nur diese Notizseite anpassen möchten.

Die [`addNotesSlide`](https://reference.aspose.com/slides/de/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--)‑Methode gibt die Notizfolie für die aktuelle Folie zurück und erstellt eine, falls noch keine vorhanden ist. Das folgende Beispiel konfiguriert die Notizseite, die mit der ersten Präsentationsfolie verknüpft ist:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie zunächst Einstellungen vom Notizen‑Master propagieren und danach eine einzelne Notizfolie ändern, ermöglichen die späteren Folien‑spezifischen Einstellungen, diese Notizseite unabhängig zu bearbeiten.

## **Kopf‑ und Fußzeilen auf dem Handzettel‑Master festlegen**

Handzettelseiten verwenden den Handzettel‑Master für ihre Kopf‑, Fußzeilen‑, Datum/Uhrzeit‑ und Seitenzahlen‑Platzhalter. Im Gegensatz zu Notizenseiten werden Handzettel‑Einstellungen über den Handzettel‑Master und nicht über einzelne Handzettelfolien verwaltet.

Verwenden Sie die [`getMasterHandoutSlide`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--)‑Methode, um auf den Handzettel‑Master zuzugreifen. Falls dieser nicht vorhanden ist, rufen Sie [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) auf, um den Standard‑Handzettel‑Master zu erstellen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geltungsbereich und Vererbung verstehen**

Wählen Sie den Kopf‑/Fußzeilen‑Manager, der dem Geltungsbereich entspricht, den Sie ändern möchten:

- `ISlideHeaderFooterManager` ändert Fußzeilen‑, Datum/Uhrzeit‑ und Folienzahl‑Einstellungen für eine reguläre Folie.
- `ILayoutSlideHeaderFooterManager` steuert eine Layout‑Folie und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- `IMasterSlideHeaderFooterManager` steuert einen regulären Folien‑Master und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- `IMasterNotesSlideHeaderFooterManager` steuert den Notizen‑Master und kann Einstellungen an alle abhängigen Notizfolien weitergeben.
- `INotesSlideHeaderFooterManager` ändert eine Notizfolie und unterstützt einen Kopfzeilen‑Platzhalter zusätzlich zu Fußzeile, Datum/Uhrzeit und Folienzahl.
- `IMasterHandoutSlideHeaderFooterManager` ändert den Handzettel‑Master und unterstützt alle vier Platzhaltertypen.

Verwenden Sie die Propagation von einem Master oder Layout, wenn dieselbe Einstellung in der gesamten Hierarchie gelten soll. Verwenden Sie einen einzelnen Folien‑ oder Notizfolien‑Manager, wenn Sie eine lokale Einstellung für eine Seite benötigen.

## **FAQ**

**Kann ich einer regulären Folie eine Kopfzeile hinzufügen?**

Nein. PowerPoint definiert keinen Kopfzeilen‑Platzhalter für reguläre Folien. Verwenden Sie auf regulären Folien die Fußzeilen‑, Datum/Uhrzeit‑ und Folienzahl‑Platzhalter. Kopfzeilen‑Platzhalter stehen auf Notizenseiten und Handzetteln zur Verfügung.

**Was ist, wenn ein Fußzeilen-, Datum/Uhrzeit- oder Folienzahl‑Platzhalter nicht sichtbar ist?**

Verwenden Sie den entsprechenden Kopf-/Fußzeilen‑Manager, um dessen Sichtbarkeit zu prüfen und bei Bedarf zu aktivieren. Zum Beispiel gibt [`isFooterVisible`](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) an, ob ein Fußzeilen‑Platzhalter vorhanden ist, und [`setFooterVisibility`](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) ändert dessen Sichtbarkeit.

**Wie starte ich die Foliennummerierung mit einem Wert ungleich 1?**

Rufen Sie die [`setFirstSlideNumber`](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-)‑Methode der Präsentation auf. Die Folienzahl‑Platzhalter verwenden dann die aktualisierte Nummerierungssequenz.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren nach PDF, Bildern oder HTML?**

Sichtbare Kopf‑ und Fußzeilenelemente werden zusammen mit dem restlichen Präsentationsinhalt im Ausgabeformat gerendert. Ihr Erscheinungsbild hängt vom zu exportierenden Seitentyp und den jeweiligen Sichtbarkeitseinstellungen der Platzhalter ab.