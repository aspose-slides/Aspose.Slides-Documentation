---
title: Verwalten von Präsentationsnotizen in PHP
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
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für PHP über Java an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---
## **Übersicht**

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese Funktion vor, einschließlich wie Notizen entfernt und wie ein Stil auf Notizfolien in einer Präsentation angewendet wird. Aspose.Slides ermöglicht das Entfernen von Notizen von beliebigen Folien und das Anwenden von Formatierungen auf vorhandene Notizen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen von einer bestimmten Folie in einer Präsentation entfernen.
- Notizen von allen Folien in einer Präsentation entfernen.

Um die Abmessungen der Notizseite zu lesen oder zu ändern, die Ausrichtung zu wechseln und das Exportverhalten zu prüfen, siehe [Notes Page Size](/slides/de/php-java/notes-size/).

## **Notizen von einer Folie entfernen**
Notizen von einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

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
Notizen von allen Folien in einer Präsentation können wie im folgenden Beispiel entfernt werden:

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

## **Ein Notizstil hinzufügen**
Die [getNotesStyle](https://reference.aspose.com/slides/de/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) Methode der [MasterNotesSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/MasterNotesSlide) Klasse bietet Zugriff auf den Textstil der Notizen. Die Implementierung wird im folgenden Beispiel demonstriert.

```php
  # Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlide-Textstil abrufen
      $notesStyle = $notesMaster->getNotesStyle();
      # Symbol‑Aufzählungszeichen für die Absätze der ersten Ebene festlegen
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

**Welches API-Entität stellt den Zugriff auf die Notizen einer bestimmten Folie bereit?**

Notizen werden über den Notizmanager der Folie abgerufen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/de/php-java/aspose.slides/notesslidemanager/getnotesslide/), die das Notizobjekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint-Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek richtet sich an ein breites Spektrum von Microsoft PowerPoint‑Formaten (97‑neuere) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.