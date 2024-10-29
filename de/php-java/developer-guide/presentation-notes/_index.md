---
title: Präsentationsnotizen
type: docs
weight: 110
url: /de/php-java/presentation-notes/
keywords: "PowerPoint Referentennotizen"
description: "Präsentationsnotizen, Referentennotizen"
---


{{% alert color="primary" %}} 

Aspose.Slides unterstützt das Entfernen von Notizenfolien aus einer Präsentation. In diesem Thema werden wir diese neue Funktion zum Entfernen von Notizen sowie das Hinzufügen von Stilfolien für Notizen aus beliebigen Präsentationen vorstellen.

{{% /alert %}} 

Aspose.Slides für PHP über Java bietet die Möglichkeit, die Notizen einer Folie zu entfernen sowie bestehenden Notizen Stil zu verleihen. Entwickler können Notizen auf folgende Weise entfernen:

* Notizen einer bestimmten Folie einer Präsentation entfernen.
* Notizen aller Folien einer Präsentation entfernen.


## **Notizen von einer Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

```php
  # Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Entfernen der Notizen der ersten Folie
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Speichern der Präsentation auf der Festplatte
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Notizen von der Präsentation entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:

```php
  # Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Entfernen der Notizen aller Folien
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()); $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Speichern der Präsentation auf der Festplatte
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **NotesStyle hinzufügen**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) Methode wurde zur [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) Schnittstelle und zur [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) Klasse hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztexts an. Die Umsetzung wird im folgenden Beispiel demonstriert.

```php
  # Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Stil für den Text der MasterNotesSlide abrufen
      $notesStyle = $notesMaster->getNotesStyle();
      # Symbolpunkte für die Absätze der ersten Ebene setzen
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