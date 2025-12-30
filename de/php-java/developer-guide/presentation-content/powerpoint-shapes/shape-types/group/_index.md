---
title: Gruppenpräsentationsformen in PHP
linktitle: Formgruppe
type: docs
weight: 40
url: /de/php-java/group/
keywords:
- Gruppenform
- Formgruppe
- Gruppe hinzufügen
- Alternativtext
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java gruppieren und gruppierung aufheben - schnelle, schrittweise Anleitung mit kostenlosem Code."
---

## **Eine Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu erstellen. Aspose.Slides für PHP via Java unterstützt das Hinzufügen oder den Zugriff auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu füllen, oder auf irgendeine Eigenschaft der Gruppenform zuzugreifen. So fügen Sie einer Folie mit Aspose.Slides für PHP via Java eine Gruppenform hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie der hinzugefügten Gruppenform Formen hinzu.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Das nachstehende Beispiel fügt einer Folie eine Gruppenform hinzu.
```php
  # Instanziieren der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Erste Folie holen
    $sld = $pres->getSlides()->get_Item(0);
    # Zugriff auf die Formensammlung der Folien
    $slideShapes = $sld->getShapes();
    # Hinzufügen einer Gruppenform zur Folie
    $groupShape = $slideShapes->addGroupShape();
    # Hinzufügen von Formen zur hinzugefügten Gruppenform
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Hinzufügen des Gruppenformrahmens
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Schreiben der PPTX-Datei auf die Festplatte
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zugriff auf die AltText‑Eigenschaft**
Dieses Thema zeigt einfache Schritte, inklusive Code‑Beispielen, zum Hinzufügen einer Gruppenform und zum Zugriff auf die AltText‑Eigenschaft von Gruppenformen auf Folien. So greifen Sie mit Aspose.Slides für PHP via Java auf AltText einer Gruppenform in einer Folie zu:

1. Instanzieren Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse, die die PPTX‑Datei repräsentiert.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Greifen Sie auf die Formen‑Sammlung der Folien zu.
1. Greifen Sie auf die Gruppenform zu.
1. Greifen Sie auf die [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--)‑Eigenschaft zu.

Das nachstehende Beispiel greift auf den alternativen Text einer Gruppenform zu.
```php
  # Instanzieren der Presentation-Klasse, die die PPTX-Datei repräsentiert
  $pres = new Presentation("AltText.pptx");
  try {
    # Erste Folie holen
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Zugriff auf die Formensammlung der Folien
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Zugriff auf die Gruppenform.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Zugriff auf die AltText-Eigenschaft
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wird verschachteltes Gruppieren (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) verfügt über eine [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/)‑Methode, die direkt die Unterstützung der Hierarchie anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)‑Methode [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/), um ihre Position im Anzeige‑Stack zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrabschnitt der Gruppe wird über [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/) bereitgestellt, wodurch Sie Vorgänge an dem Objekt einschränken können.