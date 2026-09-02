---
title: Verwalten von Präsentations‑Kopf‑ und Fußzeilen auf Android
linktitle: Kopf‑ und Fußzeile
type: docs
weight: 140
url: /de/androidjava/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilent

- Fußzeile
- Fußzeilentext
- Kopfzeile festlegen
- Fußzeile festlegen
- Handout
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fußzeilen-, Datum‑Uhrzeit‑, Folien‑Nummer‑ und Kopfzeilen‑Platzhalter auf Folien, Notizseiten und Handouts mit Aspose.Slides für Android via Java verwalten."
---
## **Übersicht**

PowerPoint verwendet je nach Folientyp unterschiedliche Platzhalter für Kopf‑ und Fußzeilen. Aspose.Slides für Android via Java ermöglicht die Steuerung von Text und Sichtbarkeit dieser Platzhalter über Manager‑Schnittstellen für Kopf‑ und Fußzeilen.

Die verfügbaren Platzhalter hängen vom Geltungsbereich ab:

| Bereich | Kopfzeile | Fußzeile | Datum/Uhrzeit | Folien-/Seitennummer |
|---|---|---|---|---|
| Reguläre Folie | Nein | Ja | Ja | Ja |
| Notiz‑Master | Ja | Ja | Ja | Ja |
| Notiz‑Folie | Ja | Ja | Ja | Ja |
| Handout‑Master | Ja | Ja | Ja | Ja |

Eine reguläre Präsentationsfolie hat keinen Kopfzeilen‑Platzhalter. Kopfzeilen sind auf Notizseiten und Handouts verfügbar. Für reguläre Folien verwenden Sie stattdessen die Fußzeilen‑, Datum/Uhrzeit‑ und Folien‑Nummer‑Platzhalter.

Der Geltungsbereich einer Änderung hängt vom verwendeten Manager ab. Das [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideheaderfootermanager/)‑Interface steuert eine reguläre Folie. Das [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/inotesslideheaderfootermanager/)‑Interface steuert eine Notizfolie. Master‑ und Layout‑Manager können Einstellungen außerdem an abhängige Folien weitergeben, während das [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/)‑Interface den Handout‑Master steuert.

## **Fußzeile, Datum/Uhrzeit und Foliennummern auf regulären Folien festlegen**

Für reguläre Folien besteht der grundlegende Ablauf darin, den Kopf‑/Fußzeilen‑Manager jeder Folie aufzurufen, den Fußzeilen‑ und Datum/Uhrzeit‑Text zu setzen, die erforderlichen Platzhalter zu aktivieren und die Präsentation zu speichern. Foliennummern werden von der Präsentation generiert, sodass nur deren Sichtbarkeit zu steuern ist.

Verwenden Sie [`setFooterText`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) und [`setDateTimeText`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-), um Text zu setzen, sowie [`setFooterVisibility`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-) und [`setSlideNumberVisibility`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-), um die entsprechenden Platzhalter anzuzeigen.

Das folgende End‑to‑End‑Beispiel wendet dieselbe Fußzeile, denselben Datum/Uhrzeit‑Text und dieselbe Folien‑Nummer‑Sichtbarkeit auf alle regulären Folien an:

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

Möchten Sie nur eine Folie aktualisieren, rufen Sie die Folie direkt über die [`getSlides`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSlides--)‑Methode auf, anstatt die gesamte Sammlung zu durchlaufen.

## **Kopf‑ und Fußzeilen im Notiz‑Master festlegen**

Der Notiz‑Master definiert einheitliche Formatierung und Platzhalterverhalten für Notizseiten. Verwenden Sie das [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/)‑Interface, wenn Sie ausschließlich den Notiz‑Master selbst ändern möchten.

Das folgende Beispiel setzt Kopf‑, Fußzeilen‑ und Datum/Uhrzeit‑Text im Notiz‑Master und macht alle unterstützten Platzhalter auf diesem Master sichtbar:

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

Die Methode [`getMasterNotesSlide`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) gibt `null` zurück, wenn die Präsentation keinen Notiz‑Master enthält.

## **Einstellungen des Notiz‑Masters auf untergeordnete Notizfolien anwenden**

Ein Notiz‑Master kann Kopf‑ und Fußzeileneinstellungen sowohl auf sich selbst als auch auf alle abhängigen Notizfolien anwenden. Nutzen Sie die dafür vorgesehenen Propagations‑Methoden des [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/), wenn dieselben Einstellungen über die gesamte Notiz‑Hierarchie hinweg gelten sollen.

Beispielsweise aktualisieren [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) und [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) den Notiz‑Master‑Kopfzeilentext und alle untergeordneten Kopfzeilen. Entsprechende Methoden existieren für Fußzeilen, Datum/Uhrzeit und Foliennummern.

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

Die oben verwendeten Propagations‑Methoden sind [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-) und [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Kopf‑ und Fußzeilen einer einzelnen Notizfolie festlegen**

Eine Notizfolie gehört zu einer bestimmten regulären Folie. Verwenden Sie deren [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/inotesslideheaderfootermanager/)‑Interface, wenn Sie ausschließlich diese Notizseite anpassen möchten.

Die Methode [`addNotesSlide`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) gibt die Notizfolie zur aktuellen Folie zurück und erstellt sie, falls noch keine existiert. Das folgende Beispiel konfiguriert die Notizseite, die der ersten Präsentationsfolie zugeordnet ist:

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

Wenn Sie zuerst Einstellungen vom Notiz‑Master propagieren und anschließend eine einzelne Notizfolie ändern, ermöglichen die nachträglichen Folien‑spezifischen Einstellungen eine unabhängige Anpassung dieser Notizseite.

## **Kopf‑ und Fußzeilen im Handout‑Master festlegen**

Handout‑Seiten benutzen den Handout‑Master für ihre Kopf‑, Fußzeilen‑, Datum/Uhrzeit‑ und Seiten‑Nummer‑Platzhalter. Anders als bei Notizseiten werden Handout‑Einstellungen über den Handout‑Master verwaltet, nicht über einzelne Handout‑Folien.

Verwenden Sie die Methode [`getMasterHandoutSlide`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--), um auf den Handout‑Master zuzugreifen. Ist er nicht vorhanden, rufen Sie [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) auf, um den Standard‑Handout‑Master zu erstellen.

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

## **Bereich und Vererbung verstehen**

Wählen Sie den Kopf‑/Fußzeilen‑Manager, der dem zu ändernden Bereich entspricht:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideheaderfootermanager/) ändert Fußzeile, Datum/Uhrzeit und Folien‑Nummer‑Einstellungen für eine reguläre Folie.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) steuert eine Layout‑Folie und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) steuert einen regulären Folien‑Master und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) steuert den Notiz‑Master und kann Einstellungen an alle abhängigen Notizfolien propagieren.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) ändert eine Notizfolie und unterstützt zusätzlich zu Fußzeile, Datum/Uhrzeit und Folien‑Nummer einen Kopfzeilen‑Platzhalter.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) ändert den Handout‑Master und unterstützt alle vier Platzhaltertypen.

Verwenden Sie die Propagation von einem Master‑ oder Layout‑Manager, wenn dieselbe Einstellung über die gesamte Hierarchie gelten soll. Nutzen Sie einen einzelnen Folien‑ oder Notiz‑Slide‑Manager, wenn Sie eine lokale Einstellung für eine Seite benötigen.

## **FAQ**

**Kann ich einer regulären Folie eine Kopfzeile hinzufügen?**

Nein. PowerPoint definiert keinen Kopfzeilen‑Platzhalter für reguläre Folien. Auf regulären Folien verwenden Sie die Fußzeilen‑, Datum/Uhrzeit‑ und Folien‑Nummer‑Platzhalter. Kopfzeilen‑Platzhalter stehen auf Notiz‑ und Handout‑Seiten zur Verfügung.

**Was ist, wenn ein Fußzeilen‑, Datum/Uhrzeit‑ oder Folien‑Nummer‑Platzhalter nicht sichtbar ist?**

Verwenden Sie den entsprechenden Kopf‑/Fußzeilen‑Manager, um dessen Sichtbarkeit zu prüfen und bei Bedarf zu aktivieren. Beispielsweise gibt [`isFooterVisible`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) an, ob ein Fußzeilen‑Platzhalter vorhanden ist, und [`setFooterVisibility`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) ändert dessen Sichtbarkeit.

**Wie beginne ich die Foliennummerierung mit einem anderen Wert als 1?**

Rufen Sie die Methode [`setFirstSlideNumber`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) der Präsentation auf. Die Folien‑Nummer‑Platzhalter verwenden dann die aktualisierte Nummerierungssequenz.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren in PDF, Bilder oder HTML?**

Sichtbare Kopf‑ und Fußzeilenelemente werden zusammen mit dem restlichen Präsentationsinhalt im Ausgabeformat gerendert. Ihr Aussehen hängt vom exportierten Seitentyp und den entsprechenden Platzhalter‑Sichtbarkeitseinstellungen ab.