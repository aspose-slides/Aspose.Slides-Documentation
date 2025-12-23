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
- Text von Folie abrufen
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
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java. Folgen Sie unserer einfachen Schritt‑für‑Schritt‑Anleitung, um Zeit zu sparen."
---

{{% alert color="primary" %}} 
Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Dazu muss der Text aus allen Formen auf allen Folien einer Präsentation extrahiert werden. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX‑Präsentationen mit Aspose.Slides extrahiert. 
{{% /alert %}} 
## **Text aus Folien extrahieren**
Aspose.Slides for PHP via Java stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) bereit. Diese Klasse stellt eine Reihe von überladenen statischen Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie bereit. Um den Text aus einer Folie in einer PPTX‑Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) , die von der Klasse [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) bereitgestellt wird. Diese Methode akzeptiert das Slide‑Objekt als Parameter.  
Bei der Ausführung durchsucht die Slide‑Methode den gesamten Text der als Parameter übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)-Objekten zurück. Das bedeutet, dass alle mit dem Text verbundenen Formatierungen verfügbar sind. Der folgende Codeausschnitt extrahiert den gesamten Text der ersten Folie der Präsentation:
```php
  # Instanziieren der Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Erhalten Sie ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Durchlaufen Sie das Array von TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Durchlaufen Sie die Absätze im aktuellen ITextFrame
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Durchlaufen Sie die Portions im aktuellen IParagraph
          foreach($para->getPortions() as $port) {
            # Anzeige des Textes im aktuellen Teil
            echo($port->getText());
            # Anzeige der Schriftgröße des Textes
            echo($port->getPortionFormat()->getFontHeight());
            # Anzeige des Schriftartnamens des Textes
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
Um den Text aus der gesamten Präsentation zu durchsuchen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) , die von der Klasse SlideUtil bereitgestellt wird. Sie übernimmt zwei Parameter:

1. Zunächst ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged)-Objekt, das die Präsentation repräsentiert, aus der der Text extrahiert wird.
2. Zweitens ein Boolescher Wert, der festlegt, ob die Master‑Folien beim Durchsuchen des Textes aus der Präsentation einbezogen werden sollen.  
Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)-Objekten zurück, einschließlich aller Textformatierungsinformationen. Der nachstehende Code scannt den Text und die Formatierungsinformationen einer Präsentation, einschließlich der Master‑Folien.
```php
  # Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Erhalten Sie ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Durchlaufen Sie das Array von TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Durchlaufen Sie die Absätze im aktuellen ITextFrame
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Durchlaufen Sie die Portions im aktuellen IParagraph
        foreach($para->getPortions() as $port) {
          # Anzeige des Textes im aktuellen Teil
          echo($port->getText());
          # Anzeige der Schriftgröße des Textes
          echo($port->getPortionFormat()->getFontHeight());
          # Anzeige des Schriftartnamens des Textes
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
Die neue statische Methode getPresentationText wurde zur Klasse Presentation hinzugefügt. Für diese Methode gibt es drei Überladungen:
```php

``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText) class which implements the [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) interface.

The new API can be used like this:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```


## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen bei der Textextraktion?**

Aspose.Slides ist für hohe Leistung optimiert und verarbeitet selbst [große Präsentationen](/slides/de/php-java/open-presentation/) effizient, wodurch es sich für Echtzeit‑ oder Batch‑Verarbeitungsszenarien eignet.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja, Aspose.Slides unterstützt das Extrahieren von Text aus Tabellen, Diagrammen und anderen komplexen Folienelementen vollständig, sodass Sie sämtlichen Textinhalt leicht zugreifen und analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsentationen zu extrahieren?**

Sie können Text mit der kostenlosen Testversion von Aspose.Slides extrahieren, allerdings hat diese bestimmte Einschränkungen, z. B. die Verarbeitung nur einer begrenzten Anzahl von Folien. Für uneingeschränkte Nutzung und zur Verarbeitung größerer Präsentationen wird der Erwerb einer Voll‑Lizenz empfohlen.