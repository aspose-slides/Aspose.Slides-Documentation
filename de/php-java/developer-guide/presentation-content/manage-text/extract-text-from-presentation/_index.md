---
title: Erweiterte Textextraktion aus Präsentationen in PHP
linktitle: Text extrahieren
type: docs
weight: 90
url: /de/php-java/extract-text-from-presentation/
keywords:
- Text extrahieren
- Text aus Folie extrahieren
- Text aus Präsentation extrahieren
- Text aus PowerPoint extrahieren
- Text aus OpenDocument extrahieren
- Text aus PPT extrahieren
- Text aus PPTX extrahieren
- Text aus ODP extrahieren
- Text abrufen
- Text aus Folie abrufen
- Text aus Präsentation abrufen
- Text aus PowerPoint abrufen
- Text aus OpenDocument abrufen
- Text aus PPT abrufen
- Text aus PPTX abrufen
- Text aus ODP abrufen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java. Folgen Sie unserer einfachen Schritt-für-Schritt-Anleitung, um Zeit zu sparen."
---

{{% alert color="primary" %}} 

Es kommt häufig vor, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie Sie Text aus Microsoft PowerPoint PPTX‑Präsentationen mithilfe von Aspose.Slides extrahieren. 

{{% /alert %}} 
## **Text aus Folien extrahieren**
Aspose.Slides for PHP via Java stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/) bereit. Diese Klasse bietet mehrere überladene statische Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie. Um den Text aus einer Folie in einer PPTX‑Präsentation zu extrahieren,
verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextboxes/) der Klasse [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/). Diese Methode akzeptiert das Slide‑Objekt als Parameter.
Bei der Ausführung scannt die Slide‑Methode den gesamten Text der übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)‑Objekten zurück. Das bedeutet, dass jede Textformatierung, die dem Text zugeordnet ist, verfügbar ist. Der folgende Code extrahiert den gesamten Text der ersten Folie der Präsentation:
```php
  # Instantiieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Ein Array von ITextFrame-Objekten aus allen Folien im PPTX erhalten
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Durchlaufen des Arrays von TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Durchlaufen der Absätze im aktuellen ITextFrame
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Durchlaufen der Abschnitte im aktuellen IParagraph
          foreach($para->getPortions() as $port) {
            # Text im aktuellen Abschnitt anzeigen
            echo($port->getText());
            # Schriftgröße des Textes anzeigen
            echo($port->getPortionFormat()->getFontHeight());
            # Schriftname des Textes anzeigen
            if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
              echo($port->getPortionFormat()->getLatinFont()->getFontName());
            }
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **Text aus Präsentationen extrahieren**
Um den Text der gesamten Präsentation zu scannen, verwenden Sie die
[getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextframes/)‑statische Methode der SlideUtil‑Klasse. Sie erwartet zwei Parameter:

1. Zunächst ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Objekt, das die Präsentation repräsentiert, aus der der Text extrahiert werden soll.
1. Zweitens ein boolescher Wert, der bestimmt, ob die Master‑Folien in den Scan einbezogen werden sollen.
   Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)‑Objekten zurück, einschließlich aller Textformatierungsinformationen. Der nachstehende Code scannt den Text und die Formatierungsinformationen einer Präsentation, einschließlich der Master‑Folien.
```php
  # Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Ein Array von ITextFrame-Objekten aus allen Folien im PPTX erhalten
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Durchlaufen des Arrays von TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Durchlaufen der Absätze im aktuellen ITextFrame
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Durchlaufen der Abschnitte im aktuellen IParagraph
        foreach($para->getPortions() as $port) {
          # Text im aktuellen Abschnitt anzeigen
          echo($port->getText());
          # Schriftgröße des Textes anzeigen
          echo($port->getPortionFormat()->getFontHeight());
          # Schriftname des Textes anzeigen
          if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
            echo($port->getPortionFormat()->getLatinFont()->getFontName());
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **Kategorisierte und schnelle Textextraktion**
Die neue statische Methode getPresentationText wurde der Klasse Presentation hinzugefügt. Es gibt drei Überladungen für diese Methode:
```php

```


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet effizient selbst [große Präsentationen](/slides/de/php-java/open-presentation/), sodass es für Echtzeit‑ oder Batch‑Verarbeitungsszenarien geeignet ist.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen vollständig, sodass Sie gesamten Textinhalt leicht zugreifen und analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, wobei jedoch bestimmte Einschränkungen gelten, z. B. die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Kauf einer Volllizenz empfohlen.