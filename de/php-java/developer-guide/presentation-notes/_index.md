---
title: Präsentationsnotizen in PHP verwalten
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/php-java/presentation-notes/
keywords:
- Notizen
- Notizfolie
- Notizen hinzufügen
- Notizen entfernen
- Notizstil
- Master-Notizen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für PHP via Java an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---

{{% alert color="primary" %}} 

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese neue Funktion zum Entfernen von Notizen sowie zum Hinzufügen von Notizstil‑Folien zu einer beliebigen Präsentation vor. 

{{% /alert %}} 

Aspose.Slides für PHP via Java bietet die Möglichkeit, Notizen einer beliebigen Folie zu entfernen und Stil zu bestehenden Notizen hinzuzufügen. Entwickler können Notizen auf folgende Weise entfernen:

* Notizen einer bestimmten Folie einer Präsentation entfernen.
* Notizen aller Folien einer Präsentation entfernen

## **Notizen von einer Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:
```php
  # Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Entfernen der Notizen der ersten Folie
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Speichern der Präsentation auf dem Datenträger
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Notizen aus einer Präsentation entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:
```php
  # Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Entfernen der Notizen aller Folien
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Speichern der Präsentation auf dem Datenträger
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Notizstil hinzufügen**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) Methode wurde zur Klasse [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im folgenden Beispiel demonstriert.
```php
  # Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlide-Textstil abrufen
      $notesStyle = $notesMaster->getNotesStyle();
      # Symbol-Aufzählungszeichen für Absätze der ersten Ebene festlegen
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Welche API-Entität bietet Zugriff auf die Notizen einer bestimmten Folie?**

Notizen werden über den Notiz‑Manager der Folie abgerufen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/), die das Notizobjekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede bei der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek unterstützt ein breites Spektrum von Microsoft‑PowerPoint‑Formaten (97‑neuer) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.