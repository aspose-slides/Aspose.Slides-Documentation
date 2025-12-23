---
title: PowerPoint-Text in PHP formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/php-java/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeld-Anker
- Texttabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Formatieren und stylen Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java. Passen Sie Schriftarten, Farben, Ausrichtungen und mehr an."
---

## **Text hervorheben**
Method [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) has been added to [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) interface and [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) class.

It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// Hervorheben aller Wörter 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// Hervorheben aller einzelnen 'the'-Vorkommen

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
Aspose bietet einen einfachen, [kostenlosen Online-PowerPoint-Bearbeitungsservice](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Text mit regulärem Ausdruck hervorheben**
Method [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) has been added to [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) interface and [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) class.

It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// Alle Wörter mit 10 Zeichen oder länger hervorheben

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Hintergrundfarbe des Textes festlegen**
Aspose.Slides allows you to specify your preferred color for the background of a text.

This PHP code shows you how to set the background color for an entire text:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->spliterator(), false)->map(( p) -> $p->getPortions())->forEach(( c) -> $c->forEach(( ic) -> $ic->getPortionFormat()->getHighlightColor()->setColor($Color.BLUE)));
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


This PHP code shows you how to set the background color for only a portion of a text:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Red"))->findFirst();
    if ($redPortion->isPresent()) {
      $redPortion->get()->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->RED);
    }
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Textabsätze ausrichten**
Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for PHP via Java supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for PHP via Java:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Obtain the reference of a slide by using its Index.
3. Access the Placeholder shapes present in the slide and typecast them as a [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. Get the Paragraph (that needs to be aligned) from the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) exposed by [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
6. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.
```php
  # Instanziieren eines Presentation-Objekts, das eine PPTX-Datei darstellt
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Ändern des Textes in beiden Platzhaltern
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # Abrufen des ersten Absatzes der Platzhalter
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Ausrichten des Textabsatzes zur Mitte
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Schreiben der Präsentation als PPTX-Datei
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Transparenz für Text festlegen**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides for PHP via Java. In order to set the transparency to text. Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get the reference of a slide.
3. Set shadow color
4. Write the presentation as a PPTX file.

The implementation of the above steps is given below.
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # Transparenz auf null Prozent setzen
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zeichenabstand für Text festlegen**
Aspose.Slides allows you to set the space between letters in a textbox. This way, you get to adjust the visual density of a line or block of text by expanding or condensing the spacing between characters.

This PHP code shows you how to expand the spacing for one line of text and condense the spacing for another line:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// ausdehnen

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// verdichten

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **Schrifteigenschaften eines Absatzes verwalten**
Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for PHP via Java to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for PHP via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the Placeholder shapes in the slide and typecast them to [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Get the [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) from the [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) exposed by [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Justify the paragraph.
1. Access a Paragraph's text Portion.
1. Define the font using FontData and set the Font of the text Portion accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) exposed by the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion) object.
1. Write the modified presentation to a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.
```php
  # Instanziieren eines Presentation-Objekts, das eine PPTX-Datei darstellt
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Zugriff auf eine Folie mittels ihrer Position
    $slide = $pres->getSlides()->get_Item(0);
    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Zugriff auf den ersten Absatz
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Zugriff auf den ersten Teil
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Neue Schriftarten definieren
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Neue Schriftarten dem Teil zuweisen
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Schriftart auf Fett setzen
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Schriftart auf Kursiv setzen
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Schriftfarbe festlegen
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # PPTX auf die Festplatte schreiben
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Schriftfamilie des Textes verwalten**
A portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for PHP via Java to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Obtain the reference of a slide by using its index.
3. Add an [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) of the type [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) to the slide.
4. Remove the fill style associated with the [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Access the AutoShape's TextFrame.
6. Add some text to the TextFrame.
7. Access the Portion object associated with the [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. Define the font to be used for the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the Portion object.
10. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.
```php
  # Präsentation instanziieren
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # AutoShape vom Typ Rechteck hinzufügen
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Alle Füllstile, die mit dem AutoShape verknüpft sind, entfernen
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Auf das TextFrame des AutoShape zugreifen
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Auf den Portion des TextFrames zugreifen
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Schriftart für den Portion festlegen
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Fett-Eigenschaft der Schrift festlegen
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Kursiv-Eigenschaft der Schrift festlegen
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Unterstreichungs-Eigenschaft der Schrift festlegen
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Höhe der Schrift festlegen
    $port->getPortionFormat()->setFontHeight(25);
    # Farbe der Schrift festlegen
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTX auf die Festplatte schreiben
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Schriftgröße für Text festlegen**
Aspose.Slides allows you to choose your preferred font size for existing text in a paragraph and other texts that may be added to the paragraph later.

This PHP code shows you how to set the font size for texts contained in a paragraph:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # Holt das erste Shape, zum Beispiel.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Holt den ersten Absatz, zum Beispiel.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Setzt die Standard-Schriftgröße auf 20 pt für alle Textabschnitte im Absatz.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Setzt die Schriftgröße auf 20 pt für die aktuellen Textabschnitte im Absatz.
      foreach($paragraph->getPortions() as $portion) {
        $portion->getPortionFormat()->setFontHeight(20);
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Text-Drehung festlegen**
Aspose.Slides for PHP via Java allows developers to rotate the text. Text could be set to appear as [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) or [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). To rotate the text of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Access the first slide.
3. Add any Shape to the slide.
4. Access the [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Save file to disk.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Die erste Folie holen
    $slide = $pres->getSlides()->get_Item(0);
    # Ein AutoShape vom Typ Rechteck hinzufügen
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # TextFrame zum Rechteck hinzufügen
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Paragraph-Objekt für das TextFrame erstellen
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Portion-Objekt für den Paragraphen erstellen
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Präsentation speichern
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Benutzerdefinierten Rotationswinkel für ein Textfeld festlegen**
Aspose.Slides for PHP via Java now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new methods [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) and [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) have been added to [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) and [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle, Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Add a chart on slide.
3. [Set RotationAngle property](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Die erste Folie holen
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape vom Typ Rechteck hinzufügen
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # TextFrame zum Rechteck hinzufügen
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Paragraph-Objekt für das TextFrame erstellen
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Portion-Objekt für den Paragraphen erstellen
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Text rotation example.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Präsentation speichern
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zeilenabstand eines Absatzes**
Aspose.Slides provides properties under [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` and `SpaceWithin`—that allow you to manage the line spacing for a paragraph. The three properties are used this way:

* To specify the line spacing for a paragraph in percentage, use a positive value. 
* To specify the line spacing for a paragraph in points, use a negative value.

For example, you can apply a 16pt line spacing for a paragraph by setting the `SpaceBefore` property to -16.

This is how you specify the line spacing for a specific paragraph:

1. Load a presentation containing an AutoShape with some text in it.
2. Get a slide's reference through its index.
3. Access the TextFrame.
4. Access the Paragraph.
5. Set the Paragraph properties.
6. Save the presentation.

This PHP code shows you how to specify the line spacing for a paragraph:
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation("Fonts.pptx");
  try {
    # Referenz einer Folie über ihren Index erhalten
    $sld = $pres->getSlides()->get_Item(0);
    # Auf das TextFrame zugreifen
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Auf den Absatz zugreifen
    $para = $tf1->getParagraphs()->get_Item(0);
    # Eigenschaften des Absatzes festlegen
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # Präsentation speichern
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **AutofitType‑Eigenschaft für ein Textfeld festlegen**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for PHP via Java allows developers to set AutofitType property of any text frame. AutofitType could be set to [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) or [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). If set to [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape), then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) of the TextFrame.
6. Save file to disk.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape vom Typ Rechteck hinzufügen
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # TextFrame zum Rechteck hinzufügen
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Paragraph-Objekt für das TextFrame erstellen
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Portion-Objekt für den Paragraphen erstellen
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Präsentation speichern
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Anker eines Textfelds festlegen**
Aspose.Slides for PHP via Java allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. AnchorType could be set to [Top](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) or [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). To set Anchor of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) of the TextFrame.
6. Save file to disk.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Die erste Folie holen
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape vom Typ Rechteck hinzufügen
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # TextFrame zum Rechteck hinzufügen
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Paragraph-Objekt für das TextFrame erstellen
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Portion-Objekt für den Paragraphen erstellen
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Präsentation speichern
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Tabs und EffectiveTabs in einer Präsentation**
All text tabulations are given in pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs).
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Hello World!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".

## **Text mit All‑Caps‑Effekt extrahieren**
In PowerPoint, applying the **All Caps** font effect makes text appear in uppercase on the slide even when it was originally typed in lowercase. When you retrieve such a text portion with Aspose.Slides, the library returns the text exactly as it was entered. To handle this, check [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/)—if it indicates `All`, simply convert the returned string to uppercase so that your output matches what users see on the slide.

Let’s say we have the following text box on the first slide of the sample2.pptx file.

![The All Caps effect](all_caps_effect.png)

 The code example below shows how to extract the text with the **All Caps** effect aplyied:
```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $textPortion = $paragraph->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = $textPortion->getText()->toUpperCase();
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```


Output:
```text
Ursprünglicher Text: Hello, Aspose!
All-Caps-Effekt: HELLO, ASPOSE!
```


## **FAQ**

**How to modify text in a table on a slide?**

To modify text in a table on a slide, you need to use the [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) class. You can iterate through all the cells in the table and change the text in each cell by accessing its `TextFrame` and `ParagraphFormat` properties within each cell.

**How to apply gradient color to text in a PowerPoint slide?**

To apply gradient color to text, use the `getFillFormat` method in [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). Set the `FilFormat` to `Gradient`, where you can define the gradient's start and end colors, along with other properties such as direction and transparency to create the gradient effect on the text.