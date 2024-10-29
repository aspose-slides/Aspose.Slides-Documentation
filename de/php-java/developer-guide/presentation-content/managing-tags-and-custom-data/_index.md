---
title: Verwaltung von Tags und benutzerdefinierten Daten
type: docs
weight: 300
url: /de/php-java/managing-tags-and-custom-data

---

## Datenspeicherung in Präsentationsdateien

PPTX-Dateien – Objekte mit der .pptx-Erweiterung – werden im PresentationML-Format gespeichert, das Teil der Office Open XML-Spezifikation ist. Das Office Open XML-Format definiert die Struktur für Daten, die in Präsentationen enthalten sind.

Mit einem *Folie*, die eines der Elemente in Präsentationen ist, enthält ein *Folienpart* den Inhalt einer einzelnen Folie. Ein Folienpart darf explizite Beziehungen zu vielen Teilen haben – wie z. B. benutzerdefinierte Tags – wie sie durch ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)) existieren.

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Schlüssel-Wert-Paarwerte. 

{{% /alert %}} 

## Abfragen der Werte für Tags

In Folien entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt Ihnen, wie Sie den Wert eines Tags mit Aspose.Slides für PHP über Java für [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) abrufen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Tags zu Präsentationen hinzufügen

Aspose.Slides ermöglicht es Ihnen, Tags zu Präsentationen hinzuzufügen. Ein Tag besteht typischerweise aus zwei Elementen: 

- dem Namen einer benutzerdefinierten Eigenschaft - `MyTag` 
- dem Wert der benutzerdefinierten Eigenschaft - `My Tag Value`

Wenn Sie einige Präsentationen basierend auf einer bestimmten Regel oder Eigenschaft klassifizieren müssen, kann es vorteilhaft sein, Tags zu diesen Präsentationen hinzuzufügen. Wenn Sie beispielsweise alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, können Sie ein nordamerikanisches Tag erstellen und dann die relevanten Länder (die USA, Mexiko und Kanada) als Werte zuweisen.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) mit Aspose.Slides für PHP über Java hinzufügen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tags können auch für [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) gesetzt werden:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("Mein Text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```