---
title: Verwalten von Präsentations-Kopf- und Fußzeilen in PHP
linktitle: Kopf- und Fußzeile
type: docs
weight: 140
url: /de/php-java/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilen-Text
- Fußzeile
- Fußzeilen-Text
- Kopfzeile festlegen
- Fußzeile festlegen
- Handout
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Platzhalter für Fußzeile, Datum/Uhrzeit, Folien-Nummer und Kopfzeile auf Folien, Notizseiten und Handouts mit Aspose.Slides für PHP über Java verwalten."
---
## **Übersicht**

PowerPoint verwendet je nach Folientyp unterschiedliche Platzhalter für Kopf‑ und Fußzeile. Aspose.Slides für PHP über Java ermöglicht es Ihnen, den Text und die Sichtbarkeit dieser Platzhalter über Klassen für Kopf‑/Fußzeilen‑Manager zu steuern.

Die verfügbaren Platzhalter hängen vom Umfang ab:

| Umfang | Kopfzeile | Fußzeile | Datum/Uhrzeit | Folien‑/Seitenzahl |
|---|---|---|---|---|
| Reguläre Folie | Nein | Ja | Ja | Ja |
| Notizen‑Master | Ja | Ja | Ja | Ja |
| Notizfolie | Ja | Ja | Ja | Ja |
| Handout‑Master | Ja | Ja | Ja | Ja |

Eine reguläre Präsentationsfolie hat keinen Kopfzeilen‑Platzhalter. Kopfzeilen sind auf Notizseiten und Handouts verfügbar. Für reguläre Folien verwenden Sie stattdessen die Platzhalter für Fußzeile, Datum/Uhrzeit und Folien‑/Seitenzahl.

Der Umfang einer Änderung hängt vom verwendeten Manager ab. Die [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideheaderfootermanager/)‑Klasse steuert eine reguläre Folie. Die [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/notesslideheaderfootermanager/)‑Klasse steuert eine Notizfolie. Master‑ und Layout‑Manager können Einstellungen auch an abhängige Folien weitergeben, während die [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterhandoutslideheaderfootermanager/)‑Klasse den Handout‑Master steuert.

## **Fußzeile, Datum/Uhrzeit und Folienzahlen auf regulären Folien festlegen**

Für reguläre Folien besteht der grundlegende Ablauf darin, den Kopf‑/Fußzeilen‑Manager jeder Folie aufzurufen, den Fußzeilen‑ und Datum/Uhrzeit‑Text zu setzen, die erforderlichen Platzhalter zu aktivieren und die Präsentation zu speichern. Folienzahlen werden von der Präsentation generiert, sodass Sie nur deren Sichtbarkeit steuern müssen.

Verwenden Sie [`setFooterText`](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) und [`setDateTimeText`](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/), um Text zu setzen, und [`setFooterVisibility`](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) sowie [`setSlideNumberVisibility`](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/), um die entsprechenden Platzhalter anzuzeigen.

Das folgende End‑zu‑Ende‑Beispiel wendet dieselbe Fußzeile, denselben Datum/Uhrzeit‑Text und dieselbe Folien‑/Seitenzahl‑Sichtbarkeit auf alle regulären Folien an:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wenn Sie nur eine Folie aktualisieren müssen, greifen Sie direkt über die [`getSlides`](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getslides/)‑Methode auf diese Folie zu, anstatt die gesamte Sammlung zu durchlaufen.

## **Kopf‑ und Fußzeilen im Notizen‑Master festlegen**

Der Notizen‑Master definiert ein gemeinsames Format und das Verhalten von Platzhaltern für Notizseiten. Verwenden Sie die [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/)‑Klasse, wenn Sie ausschließlich den Notizen‑Master selbst ändern möchten.

Das folgende Beispiel setzt Kopf‑, Fußzeilen‑ und Datum/Uhrzeit‑Text im Notizen‑Master und macht alle unterstützten Platzhalter in diesem Master sichtbar:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die [`getMasterNotesSlide`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/)‑Methode gibt `null` zurück, wenn die Präsentation keinen Notizen‑Master enthält.

## **Notizen‑Master‑Einstellungen auf untergeordnete Notizfolien anwenden**

Ein Notizen‑Master kann Kopf‑ und Fußzeileneinstellungen sowohl auf sich selbst als auch auf alle abhängigen Notizfolien anwenden. Verwenden Sie die dedizierten Propagations‑Methoden der [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/), wenn dieselben Einstellungen über die gesamte Notiz‑Hierarchie hinweg gelten sollen.

Beispielsweise aktualisieren [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) und [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) die Kopfzeile des Notizen‑Masters und aller untergeordneten Kopfzeilen. Entsprechende Methoden stehen für Fußzeilen, Datum/Uhrzeit und Folienzahlen zur Verfügung.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die oben verwendeten Propagations‑Methoden sind [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) sowie [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Kopf‑ und Fußzeilen auf einer einzelnen Notizfolie festlegen**

Eine Notizfolie gehört zu einer bestimmten regulären Folie. Verwenden Sie deren [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/notesslideheaderfootermanager/)‑Klasse, wenn Sie nur diese Notizseite individuell anpassen möchten.

Die [`addNotesSlide`](https://reference.aspose.com/slides/de/php-java/aspose.slides/notesslidemanager/addnotesslide/)‑Methode gibt die Notizfolie für die aktuelle Folie zurück und erstellt eine, falls sie noch nicht existiert. Das folgende Beispiel konfiguriert die Notizseite, die mit der ersten Präsentationsfolie verknüpft ist:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wenn Sie zuerst Einstellungen vom Notizen‑Master propagieren und anschließend eine einzelne Notizfolie ändern, ermöglichen die nachfolgenden Folien‑spezifischen Einstellungen, diese Notizseite unabhängig zu bearbeiten.

## **Kopf‑ und Fußzeilen im Handout‑Master festlegen**

Handout‑Seiten verwenden den Handout‑Master für ihre Kopf‑, Fußzeilen‑, Datum/Uhrzeit‑ und Seitenzahl‑Platzhalter. Im Gegensatz zu Notizseiten werden Handout‑Einstellungen über den Handout‑Master und nicht über einzelne Handout‑Folien verwaltet.

Verwenden Sie die [`getMasterHandoutSlide`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/)‑Methode, um auf den Handout‑Master zuzugreifen. Wenn er nicht vorhanden ist, rufen Sie [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) auf, um den Standard‑Handout‑Master zu erstellen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Umfang und Vererbung verstehen**

Wählen Sie den Kopf‑/Fußzeilen‑Manager, der dem Umfang entspricht, den Sie ändern möchten:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideheaderfootermanager/) ändert Fußzeilen‑, Datum/Uhrzeit‑ und Folien‑/Seitenzahl‑Einstellungen für eine reguläre Folie.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslideheaderfootermanager/) steuert eine Layout‑Folie und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslideheaderfootermanager/) steuert einen regulären Folien‑Master und kann unterstützte Einstellungen an abhängige Folien weitergeben.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masternotesslideheaderfootermanager/) steuert den Notizen‑Master und kann Einstellungen an alle abhängigen Notizfolien weitergeben.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/notesslideheaderfootermanager/) ändert eine Notizfolie und unterstützt neben Fußzeile und Datum/Uhrzeit auch einen Kopfzeilen‑Platzhalter.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) ändert den Handout‑Master und unterstützt alle vier Platzhalter‑Typen.

Verwenden Sie die Propagation von einem Master‑ oder Layout‑Manager, wenn dieselbe Einstellung im gesamten Hierarchie‑Baum gelten soll. Verwenden Sie einen einzelnen Folien‑ oder Notiz‑Slide‑Manager, wenn Sie eine lokale Einstellung für eine einzelne Seite benötigen.

## **FAQ**

**Kann ich einer regulären Folie eine Kopfzeile hinzufügen?**

Nein. PowerPoint definiert keinen Kopfzeilen‑Platzhalter für reguläre Folien. Verwenden Sie auf regulären Folien die Platzhalter für Fußzeile, Datum/Uhrzeit und Folien‑/Seitenzahl. Kopfzeilen‑Platzhalter stehen auf Notizseiten und Handouts zur Verfügung.

**Was ist, wenn ein Fußzeilen‑, Datum/Uhrzeit‑ oder Folien‑/Seitenzahl‑Platzhalter nicht sichtbar ist?**

Verwenden Sie den entsprechenden Kopf‑/Fußzeilen‑Manager, um die Sichtbarkeit zu prüfen und bei Bedarf zu aktivieren. Beispielsweise gibt [`isFooterVisible`](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) an, ob ein Fußzeilen‑Platzhalter vorhanden ist, und [`setFooterVisibility`](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) ändert dessen Sichtbarkeit.

**Wie beginne ich die Foliennummerierung mit einem anderen Wert als 1?**

Rufen Sie die Methode [`setFirstSlideNumber`](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/setfirstslidenumber/) der Präsentation auf. Die Folien‑/Seitenzahl‑Platzhalter verwenden dann die aktualisierte Nummerierungssequenz.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren in PDF, Bilder oder HTML?**

Sichtbare Kopf‑ und Fußzeilen‑Elemente werden zusammen mit dem restlichen Präsentationsinhalt im Ausgabeformat gerendert. Ihr Aussehen hängt vom zu exportierenden Seitentyp und den jeweiligen Platzhalter‑Sichtbarkeitseinstellungen ab.