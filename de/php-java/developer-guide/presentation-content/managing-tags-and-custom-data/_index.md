---
title: Tags und benutzerdefinierte Daten in Präsentationen mit PHP verwalten
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

PPTX-Dateien — Elemente mit der Erweiterung .pptx — werden im PresentationML-Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur für in Präsentationen enthaltene Daten. 

Ein *Folie* ist eines der Elemente in Präsentationen, ein *Folien‑Teil* enthält den Inhalt einer einzelnen Folie. Ein Folien‑Teil darf explizite Beziehungen zu vielen Teilen haben — wie benutzerdefinierten Tags — definiert durch ISO/IEC 29500. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([TagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/)) und CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/customxmlpartcollection/)) existieren.

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Schlüssel‑Wert‑Paar‑Zeichenketten. 

{{% /alert %}} 

## **Werte von Tags abrufen**

In Folien entspricht ein Tag den Methoden [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getKeywords) und [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setKeywords). Dieses Beispielcode zeigt, wie man den Wert eines Tags mit Aspose.Slides für PHP via Java für [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) erhält:
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

- der Name einer benutzerdefinierten Eigenschaft – `MyTag` 
- der Wert einer benutzerdefinierten Eigenschaft – `My Tag Value`

Wenn Sie einige Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, kann das Hinzufügen von Tags zu diesen Präsentationen von Nutzen sein. Zum Beispiel können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, einen Nordamerika‑Tag erstellen und dann die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen. 

Dieses Beispielcode zeigt, wie man einen Tag zu einer [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) mit Aspose.Slides für PHP via Java hinzufügt:
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


Tags können auch für [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) gesetzt werden:
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


Oder für ein einzelnes [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/):
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

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/)‑Operation auf der [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) auf der [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.