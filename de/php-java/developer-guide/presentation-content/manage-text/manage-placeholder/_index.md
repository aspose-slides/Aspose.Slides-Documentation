---
title: Platzhalter verwalten
type: docs
weight: 10
url: /de/php-java/manage-placeholder/
description: Ändern Sie den Text in einem Platzhalter in PowerPoint-Folien mithilfe von PHP. Setzen Sie den Aufforderungstext in einem Platzhalter in PowerPoint-Folien mithilfe von PHP.
---

## **Text im Platzhalter ändern**
Mit [Aspose.Slides für PHP über Java](/slides/de/php-java/) können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es Ihnen, Änderungen am Text in einem Platzhalter vorzunehmen.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Sie können eine solche Präsentation in der Standardanwendung Microsoft PowerPoint erstellen.

So verwenden Sie Aspose.Slides, um den Text im Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich einen Folienverweis über dessen Index.
3. Durchlaufen Sie die Formen, um den Platzhalter zu finden.
4. Typkonvertieren Sie die Platzhalterform in eine [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) und ändern Sie den Text mithilfe des [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), der mit der [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) verknüpft ist.
5. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt, wie Sie den Text in einem Platzhalter ändern:

```php
  # Instanziiert eine Presentation-Klasse
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Durchläuft die Formen, um den Platzhalter zu finden
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Ändert den Text in jedem Platzhalter
        $shp->getTextFrame()->setText("Dies ist Platzhalter");
      }
    }
    # Speichert die Präsentation auf der Festplatte
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aufforderungstext im Platzhalter festlegen**
Standard- und vorgefertigte Layouts enthalten Platzhalteraufforderungstexte wie ***Klicken Sie, um einen Titel hinzuzufügen*** oder ***Klicken Sie, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Aufforderungstexte in Platzhalterlayouts einfügen.

Dieser PHP-Code zeigt Ihnen, wie Sie den Aufforderungstext in einem Platzhalter festlegen:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Durchläuft die Folie
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint zeigt "Klicken Sie, um einen Titel hinzuzufügen"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Titel hinzufügen";
        } else // Fügt Untertitel hinzu
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Untertitel hinzufügen";
        }
        $shape->getTextFrame()->setText($text);
        echo("Platzhalter mit Text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Transparenz des Platzhalterbildes festlegen**

Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbilds in einem Textplatzhalter festzulegen. Indem Sie die Transparenz des Bildes in einem solchen Rahmen anpassen, können Sie den Text oder das Bild hervorheben (je nach Farben des Textes und des Bildes).

Dieser PHP-Code zeigt Ihnen, wie Sie die Transparenz für einen Bildhintergrund (innerhalb einer Form) festlegen:

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Aktueller Transparenzwert: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);

```