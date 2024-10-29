---
title: Präsentationskopf und -fußzeile
type: docs
weight: 140
url: /de/php-java/presentation-header-and-footer/
keywords: "PowerPoint Kopf- und Fußzeile"
description: "PowerPoint Kopf- und Fußzeile"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/php-java/) bietet Unterstützung für die Arbeit mit Texten von Kopf- und Fußzeilen, die tatsächlich auf der Folienmaster-Ebene verwaltet werden.

{{% /alert %}} 

[Aspose.Slides für PHP über Java](/slides/de/php-java/) bietet die Funktion zur Verwaltung von Kopf- und Fußzeilen innerhalb von Präsentationsfolien. Diese werden tatsächlich auf der Präsentationsmaster-Ebene verwaltet.

## **Kopf- und Fußzeile in der Präsentation verwalten**
Notizen einer bestimmten Folie können entfernt werden, wie im folgenden Beispiel gezeigt:

```php
  # Präsentation laden
  $pres = new Presentation("headerTest.pptx");
  try {
    # Fußzeile einstellen
    $pres->getHeaderFooterManager()->setAllFootersText("Mein Fußzeilentext");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Kopfzeile abrufen und aktualisieren
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

## **Kopf- und Fußzeile in Handouts und Notizfolien verwalten**
Aspose.Slides für PHP über Java unterstützt Kopf- und Fußzeilen in Handouts und Notizfolien. Bitte befolgen Sie die folgenden Schritte:

- Laden Sie eine [Präsentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), die ein Video enthält.
- Ändern Sie die Einstellungen für Kopf- und Fußzeilen für den Notizenmaster und alle Notizfolien.
- Stellen Sie sicher, dass die Master-Notizfolie und alle untergeordneten Fußzeilenplatzhalter sichtbar sind.
- Stellen Sie sicher, dass die Master-Notizfolie und alle untergeordneten Datums- und Uhrzeitplatzhalter sichtbar sind.
- Ändern Sie die Einstellungen für Kopf- und Fußzeilen nur für die erste Notizfolie.
- Stellen Sie den Platzhalter für die Kopfzeile der Notizfolie sichtbar.
- Setzen Sie den Text für den Platzhalter der Kopfzeile der Notizfolie.
- Setzen Sie den Text für den Platzhalter Datum-Uhrzeit der Notizfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Codebeispiel im folgenden Beispiel.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Ändern Sie die Kopf- und Fußzeileneinstellungen für den Notizenmaster und alle Notizfolien
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// machen Sie die Master-Notizfolie und alle untergeordneten Fußzeilenplatzhalter sichtbar

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// machen Sie die Master-Notizfolie und alle untergeordneten Kopfzeilenplatzhalter sichtbar

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// machen Sie die Master-Notizfolie und alle untergeordneten Foliennummernplatzhalter sichtbar

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// machen Sie die Master-Notizfolie und alle untergeordneten Datums- und Uhrzeitplatzhalter sichtbar

      $headerFooterManager->setHeaderAndChildHeadersText("Kopfzeilentext");// setzen Sie den Text für die Master-Notizfolie und alle untergeordneten Kopfzeilenplatzhalter

      $headerFooterManager->setFooterAndChildFootersText("Fußzeilentext");// setzen Sie den Text für die Master-Notizfolie und alle untergeordneten Fußzeilenplatzhalter

      $headerFooterManager->setDateTimeAndChildDateTimesText("Datum- und Uhrzeittext");// setzen Sie den Text für die Master-Notizfolie und alle untergeordneten Datums- und Uhrzeitplatzhalter

    }
    # Ändern Sie die Kopf- und Fußzeileneinstellungen nur für die erste Notizfolie
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// machen Sie diesen Platzhalter für die Kopfzeile der Notizfolie sichtbar

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// machen Sie diesen Platzhalter für die Fußzeile der Notizfolie sichtbar

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// machen Sie diesen Platzhalter für die Foliennummer der Notizfolie sichtbar

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// machen Sie diesen Platzhalter für Datum und Uhrzeit der Notizfolie sichtbar

      $headerFooterManager->setHeaderText("Neuer Kopfzeilentext");// setzen Sie den Text für den Platzhalter Kopfzeile der Notizfolie

      $headerFooterManager->setFooterText("Neuer Fußzeilentext");// setzen Sie den Text für den Platzhalter Fußzeile der Notizfolie

      $headerFooterManager->setDateTimeText("Neuer Datum- und Uhrzeittext");// setzen Sie den Text für den Platzhalter Datum-Uhrzeit der Notizfolie

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```