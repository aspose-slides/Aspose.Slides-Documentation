---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit PHP
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/php-java/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte Daten in Aspose.Slides für PHP via Java hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Elemente mit der Endung .pptx — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur der in Präsentationen enthaltenen Daten.  

Ein *Slide* ist eines der Elemente in Präsentationen; ein *Slide‑Part* enthält den Inhalt einer einzelnen Folie. Ein Slide‑Part darf explizite Beziehungen zu vielen Parts — z. B. zu benutzerdefinierten Tags — haben, die nach ISO/IEC 29500 definiert sind.  

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Nutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)) existieren.

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel‑Wert‑Paar‑Werte. 
{{% /alert %}} 

## **Abrufen von Tag‑Werten**

In Folien entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt, wie Sie den Wert eines Tags mit Aspose.Slides für PHP via Java für [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) abrufen:
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


## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft — `MyTag`  
- dem Wert der benutzerdefinierten Eigenschaft — `My Tag Value`

Wenn Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren möchten, können Sie von Tags profitieren. Zum Beispiel können Sie, um alle Präsentationen aus nordamerikanischen Ländern zusammenzufassen, ein „North American“-Tag erstellen und die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen.  

Dieser Beispielcode zeigt, wie Sie mit Aspose.Slides für PHP via Java ein Tag zu einer [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) hinzufügen:
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


Oder für ein einzelnes [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape):
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie die [Remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/)‑Operation auf der [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu entfernen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) auf der [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/); sie liefert ein Array aller Tag‑Namen.