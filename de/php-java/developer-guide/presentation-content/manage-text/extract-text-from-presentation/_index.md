---
title: Text aus Präsentation extrahieren
type: docs
weight: 90
url: /php-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Es ist nicht ungewöhnlich, dass Entwickler den Text aus einer Präsentation extrahieren müssen. Um dies zu tun, müssen Sie den Text aus allen Formen auf allen Folien einer Präsentation extrahieren. Dieser Artikel erklärt, wie man Text aus Microsoft PowerPoint PPTX-Präsentationen mithilfe von Aspose.Slides extrahiert.

{{% /alert %}} 
## **Text aus Folie extrahieren**
Aspose.Slides für PHP über Java bietet die [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) Klasse. Diese Klasse bietet eine Reihe von überladenen statischen Methoden zum Extrahieren des gesamten Texts aus einer Präsentation oder Folie. Um den Text von einer Folie in einer PPTX-Präsentation zu extrahieren, verwenden Sie die überladene statische Methode [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) der [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) Klasse. Diese Methode akzeptiert das Slide-Objekt als Parameter. Bei der Ausführung scannt die Slide-Methode den gesamten Text von der übergebenen Folie und gibt ein Array von [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) Objekten zurück. Dies bedeutet, dass jede Textformatierung, die mit dem Text verbunden ist, verfügbar ist. Der folgende Code extrahiert den gesamten Text auf der ersten Folie der Präsentation:

```php
  # Instantiere die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Erhalte ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Durchlaufe das Array von TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Durchlaufe die Absätze im aktuellen ITextFrame
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Durchlaufe die Abschnitte im aktuellen IParagraph
          foreach($para->getPortions() as $port) {
            # Zeige den Text im aktuellen Abschnitt an
            echo($port->getText());
            # Zeige die Schriftgröße des Textes an
            echo($port->getPortionFormat()->getFontHeight());
            # Zeige den Schriftartnamen des Textes an
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

## **Text aus Präsentation extrahieren**
Um den Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) der SlideUtil-Klasse. Sie akzeptiert zwei Parameter:

1. Zuerst ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) Objekt, das die Präsentation repräsentiert, aus der der Text extrahiert wird.
1. Zweitens einen booleschen Wert, der bestimmt, ob die Masterfolie bei der Texterfassung aus der Präsentation einbezogen werden soll.
   Die Methode gibt ein Array von [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) Objekten zurück, die mit Informationen zur Textformatierung ausgestattet sind. Der folgende Code scannt den Text und die Formatierungsinformationen aus einer Präsentation, einschließlich der Masterfolien.

```php
  # Instantiere die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Erhalte ein Array von ITextFrame-Objekten aus allen Folien in der PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Durchlaufe das Array von TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Durchlaufe die Absätze im aktuellen ITextFrame
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Durchlaufe die Abschnitte im aktuellen IParagraph
        foreach($para->getPortions() as $port) {
          # Zeige den Text im aktuellen Abschnitt an
          echo($port->getText());
          # Zeige die Schriftgröße des Textes an
          echo($port->getPortionFormat()->getFontHeight());
          # Zeige den Schriftartnamen des Textes an
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
Die neue statische Methode getPresentationText wurde zur Presentation-Klasse hinzugefügt. Es gibt drei Überladungen für diese Methode:

```php

``` 

Das [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) Enum-Argument gibt den Modus an, um das Ergebnis der Textergebnisse zu organisieren und kann auf folgende Werte gesetzt werden:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - Der rohe Text ohne Berücksichtigung der Position auf der Folie
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - Der Text ist in der gleichen Reihenfolge wie auf der Folie positioniert

Der **Unarranged**-Modus kann verwendet werden, wenn Geschwindigkeit kritisch ist, da er schneller ist als der Arranged-Modus.

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) repräsentiert den rohen Text, der aus der Präsentation extrahiert wurde. Es enthält die Methode [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) die ein Array von [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. Das [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) Objekt hat die folgenden Methoden:

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - Der Text auf den Formen der Folie
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - Der Text auf den Formen der Masterseite für diese Folie
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - Der Text auf den Formen der Layoutseite für diese Folie
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - Der Text auf den Formen der Notizenseite für diese Folie

Es gibt auch eine [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText) Klasse, die das [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) Interface implementiert.

Die neue API kann wie folgt verwendet werden:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```