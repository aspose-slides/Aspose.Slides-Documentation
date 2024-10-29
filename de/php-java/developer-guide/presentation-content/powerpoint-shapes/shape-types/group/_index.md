---
title: Gruppe
type: docs
weight: 40
url: /de/php-java/group/
---

## **Gruppe Form hinzufügen**
Aspose.Slides unterstützt das Arbeiten mit Gruppenschablonen auf Folien. Diese Funktion hilft Entwicklern, umfassendere Präsentationen zu erstellen. Aspose.Slides für PHP über Java unterstützt das Hinzufügen oder Zugreifen auf Gruppenschablonen. Es ist möglich, Formen zu einer hinzugefügten Gruppenschablone hinzuzufügen, um sie zu füllen, oder auf eine beliebige Eigenschaft der Gruppenschablone zuzugreifen. Um eine Gruppenschablone zu einer Folie unter Verwendung von Aspose.Slides für PHP über Java hinzuzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie eine Gruppenschablone hinzu.
1. Fügen Sie die Formen zur hinzugefügten Gruppenschablone hinzu.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppenschablone hinzu.

```php
  # Instanziieren Sie die Präsentationsklasse
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Zugriff auf die Formensammlung der Folien
    $slideShapes = $sld->getShapes();
    # Hinzufügen einer Gruppenschablone zur Folie
    $groupShape = $slideShapes->addGroupShape();
    # Hinzufügen von Formen innerhalb der hinzugefügten Gruppenschablone
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Hinzufügen eines Rahmens für die Gruppenschablone
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Schreiben Sie die PPTX-Datei auf die Festplatte
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zugriff auf die AltText-Eigenschaft**
Dieses Thema zeigt einfache Schritte, komplett mit Codebeispielen, zum Hinzufügen einer Gruppenschablone und zum Zugriff auf die AltText-Eigenschaft von Gruppenschablonen auf Folien. Um auf AltText einer Gruppenschablone in einer Folie unter Verwendung von Aspose.Slides für PHP über Java zuzugreifen:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse, die die PPTX-Datei darstellt.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Zugriff auf die Formensammlung der Folien.
1. Zugriff auf die Gruppenschablone.
1. Zugriff auf die [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) Eigenschaft.

Das folgende Beispiel greift auf den alternativen Text der Gruppenschablone zu.

```php
  # Instanziieren Sie die Präsentationsklasse, die die PPTX-Datei darstellt
  $pres = new Presentation("AltText.pptx");
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Zugriff auf die Formensammlung der Folien
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Zugriff auf die Gruppenschablone.
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