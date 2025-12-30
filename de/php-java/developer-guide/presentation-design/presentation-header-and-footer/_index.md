---
title: Verwalten von Präsentationskopf- und Fußzeilen in PHP
linktitle: Kopfzeile und Fußzeile
type: docs
weight: 140
url: /de/php-java/presentation-header-and-footer/
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
- PHP
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für PHP via Java, um Kopf- und Fußzeilen in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen und anzupassen, sodass sie professionell aussehen."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/php-java/) bietet Unterstützung zum Arbeiten mit Kopf- und Fußzeilentexten von Folien, die tatsächlich auf Ebene der Folienmaster gepflegt werden.

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/de/php-java/) bietet die Möglichkeit, Kopf- und Fußzeilen in Präsentationsfolien zu verwalten. Diese werden tatsächlich auf Ebene des Präsentationsmasters verwaltet.

## **Kopf- und Fußzeilen in einer Präsentation verwalten**
Anmerkungen einer bestimmten Folie können wie im nachstehenden Beispiel entfernt werden:
```php
  # Präsentation laden
  $pres = new Presentation("headerTest.pptx");
  try {
    # Footer festlegen
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Header zugreifen und aktualisieren
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Präsentation speichern
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Kopf- und Fußzeilen in Handout- und Notizfolien verwalten**
Aspose.Slides for PHP via Java unterstützt Kopf- und Fußzeilen in Handout- und Notizfolien. Bitte folgen Sie den untenstehenden Schritten:

- Laden Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) mit einem Video.
- Ändern Sie die Header- und Footer-Einstellungen für den Notizmaster und alle Notizfolien.
- Setzen Sie die Master-Notizfolie und alle untergeordneten Footer-Platzhalter sichtbar.
- Setzen Sie die Master-Notizfolie und alle untergeordneten Datums- und Zeit-Platzhalter sichtbar.
- Ändern Sie die Header- und Footer-Einstellungen nur für die erste Notizfolie.
- Setzen Sie den Header-Platzhalter der Notizfolie sichtbar.
- Setzen Sie den Text im Header-Platzhalter der Notizfolie.
- Setzen Sie den Text im Datums-Zeit-Platzhalter der Notizfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Code‑Snippet im untenstehenden Beispiel bereitgestellt.
```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Header- und Footer-Einstellungen für den Notizmaster und alle Notizfolien ändern
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// macht die Master-Notizfolie und alle untergeordneten Footer-Platzhalter sichtbar

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// macht die Master-Notizfolie und alle untergeordneten Header-Platzhalter sichtbar

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// macht die Master-Notizfolie und alle untergeordneten SlideNumber-Platzhalter sichtbar

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// macht die Master-Notizfolie und alle untergeordneten Datum‑und‑Zeit-Platzhalter sichtbar

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// setzt Text für die Master-Notizfolie und alle untergeordneten Header-Platzhalter

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// setzt Text für die Master-Notizfolie und alle untergeordneten Footer-Platzhalter

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// setzt Text für die Master-Notizfolie und alle untergeordneten Datum‑und‑Zeit-Platzhalter

    }
    # Header- und Footer-Einstellungen nur für die erste Notizfolie ändern
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// macht diesen Notizfolie-Header-Platzhalter sichtbar

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// macht diesen Notizfolie-Footer-Platzhalter sichtbar

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// macht diesen Notizfolie‑SlideNumber-Platzhalter sichtbar

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// macht diesen Notizfolie‑Date‑time-Platzhalter sichtbar

      $headerFooterManager->setHeaderText("New header text");// setzt Text für den Notizfolie-Header-Platzhalter

      $headerFooterManager->setFooterText("New footer text");// setzt Text für den Notizfolie-Footer-Platzhalter

      $headerFooterManager->setDateTimeText("New date and time text");// setzt Text für den Notizfolie‑Date‑time-Platzhalter

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich einen „Header“ zu normalen Folien hinzufügen?**

In PowerPoint gibt es „Header“ nur für Notizen und Handouts; auf regulären Folien sind die unterstützten Elemente Fußzeile, Datum/Uhrzeit und Foliennummer. In Aspose.Slides gilt dieselbe Einschränkung: Header nur für Notes/Handout und auf Folien – Footer/DateTime/SlideNumber.

**Was ist, wenn das Layout keinen Footer‑Bereich enthält – kann ich dessen Sichtbarkeit aktivieren?**

Ja. Prüfen Sie die Sichtbarkeit über den Header/Footer-Manager und aktivieren Sie sie bei Bedarf. Diese API-Indikatoren und Methoden sind für Fälle gedacht, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummerierung mit einem anderen Wert als 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Zum Beispiel können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Headern/Footern beim Exportieren nach PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem übrigen Inhalt.