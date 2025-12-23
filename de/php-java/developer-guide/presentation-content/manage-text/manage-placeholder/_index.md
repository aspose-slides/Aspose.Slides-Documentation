---
title: Verwalten von Präsentationsplatzhaltern in PHP
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/php-java/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Hinweistext
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Mühelose Verwaltung von Platzhaltern in Aspose.Slides für PHP via Java: Text ersetzen, Hinweise anpassen & Bildtransparenz festlegen in PowerPoint und OpenDocument."
---

## **Text in einem Platzhalter ändern**
Mit [Aspose.Slides for PHP via Java](/slides/de/php-java/) können Sie Platzhalter auf Folien in Präsentationen finden und bearbeiten. Aspose.Slides ermöglicht es Ihnen, Änderungen am Text in einem Platzhalter vorzunehmen.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Eine solche Präsentation können Sie in der Standard‑Microsoft‑PowerPoint‑Anwendung erstellen.

So verwenden Sie Aspose.Slides, um den Text im Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Durchlaufen Sie die Shapes, um den Platzhalter zu finden.
4. Casten Sie die Platzhalter‑Shape zu einer [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)-Klasse und ändern Sie den Text mithilfe des [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)-Objekts, das mit der [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)-Klasse verknüpft ist.
5. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie man den Text in einem Platzhalter ändert:
```php
  # Instanziiert eine Presentation-Klasse
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Durchläuft die Shapes, um den Platzhalter zu finden
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Ändert den Text in jedem Platzhalter
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Speichert die Präsentation auf die Festplatte
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Prompt‑Text in einem Platzhalter festlegen**
Standard‑ und vordefinierte Layouts enthalten Platzhalter‑Prompt‑Texte wie ***Klicken Sie, um einen Titel hinzuzufügen*** oder ***Klicken Sie, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Prompt‑Texte in Platzhalter‑Layouts einfügen.

Dieser PHP‑Code zeigt, wie man den Prompt‑Text in einem Platzhalter festlegt:
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
          $text = "Add Title";
        } else // Fügt Untertitel hinzu
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Transparenz eines Platzhalter‑Bildes festlegen**
Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbildes in einem Text‑Platzhalter einzustellen. Durch Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (abhängig von den Farben von Text und Bild).

Dieser PHP‑Code zeigt, wie man die Transparenz für einen Bild‑Hintergrund (innerhalb einer Shape) festlegt:
```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Was ist ein Basis‑Platzhalter und wie unterscheidet er sich von einer lokalen Shape auf einer Folie?**

Ein Basis‑Platzhalter ist die ursprüngliche Shape in einem Layout oder Master, von der die Shape der Folie erbt – Typ, Position und einige Formatierungen stammen daraus. Eine lokale Shape ist unabhängig; gibt es keinen Basis‑Platzhalter, findet keine Vererbung statt.

**Wie kann ich alle Titel oder Beschriftungen in einer Präsentation aktualisieren, ohne jede Folie zu durchlaufen?**

Bearbeiten Sie den entsprechenden Platzhalter im Layout oder im Master. Folien, die auf diesen Layouts/diesem Master basieren, übernehmen die Änderung automatisch.

**Wie steuere ich die Standard‑Header/Footer‑Platzhalter – Datum & Uhrzeit, Foliennummer und Footer‑Text?**

Verwenden Sie die HeaderFooter‑Verwalter im jeweiligen Geltungsbereich (normale Folien, Layouts, Master, Notizen/Handzettel), um diese Platzhalter ein- oder auszuschalten und deren Inhalt festzulegen.