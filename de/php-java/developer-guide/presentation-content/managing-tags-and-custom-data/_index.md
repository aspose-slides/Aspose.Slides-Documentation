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
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint-Präsentationen arbeitet. Er gibt einen kurzen Überblick darüber, wie Daten in PPTX-Dateien gespeichert werden, weist darauf hin, dass präsentationsspezifische Daten als Tags und benutzerdefinierte XML-Teile existieren können, und beschreibt Tags als Schlüssel-Wert-String-Paare.

Er zeigt außerdem, wie Tag-Werte gelesen und Tags zu einer Präsentation, einer einzelnen Folie oder einer Form hinzugefügt werden können. Zusätzlich behandelt der Artikel gängige Tag-Verwaltungsaufgaben wie das Löschen aller Tags, das Entfernen eines Tags nach Namen und das Abrufen der Liste von Tag-Namen.

## **Speicherung von Daten in Präsentationsdateien**

PPTX-Dateien - Elemente mit der Endung .pptx - werden im PresentationML-Format gespeichert, das Teil der Office Open XML-Spezifikation ist. Das Office Open XML-Format definiert die Struktur für in Präsentationen enthaltene Daten.

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folienteil* den Inhalt einer einzelnen Folie. Ein Folienteil darf explizite Beziehungen zu vielen Teilen haben - beispielsweise benutzerdefinierte Tags - die durch ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([TagCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/)) und CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpartcollection/)) existieren.

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel-Wert-String-Paare. 
{{% /alert %}} 

## **Werte von Tags abrufen**

In Slides entspricht ein Tag den Methoden [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getKeywords) und [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#setKeywords). Dieses Beispielcode zeigt, wie man den Wert eines Tags mit Aspose.Slides für PHP via Java für die [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation) abruft:

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

- der Name einer benutzerdefinierten Eigenschaft - `MyTag`
- der Wert der benutzerdefinierten Eigenschaft - `My Tag Value`

Wenn Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie von der Verwendung von Tags profitieren. Beispielsweise können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, einen Nordamerika-Tag erstellen und dann die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen.

Dieses Beispielcode zeigt, wie man einem [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation) mit Aspose.Slides für PHP via Java einen Tag hinzufügt:

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

Tags können auch für [Slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/) festgelegt werden:

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

Oder für ein einzelnes [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $pres->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Einschränkungen**

Tags, die über die benutzerdefinierte Daten-Tag-Sammlung mit `getCustomData()->getTags()` hinzugefügt werden, werden ausschließlich in der PowerPoint-Datei gespeichert. Sie werden **nicht** in die PDF-Tag-Struktur übertragen, wenn die Präsentation in PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Workaround**: Sie können einen benutzerdefinierten Bezeichner im **Alt-Text** des Objekts speichern (z.B. `$shape->setAlternativeText("MyId")`). Nach dem Exportieren nach PDF kann der Alt-Text in der PDF-Tag-Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel-Wert-Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag nach seinem Namen, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie die [remove(name)](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/remove/)‑Operation auf der [tag collection](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/), um das Tag nach seinem Schlüssel zu löschen.

**Wie kann ich die vollständige Liste der Tag-Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/getnamesoftags/) auf der [tag collection](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/); sie gibt ein Array aller Tag-Namen zurück.