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
- Texttabulator
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Formatieren und stilisieren Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java. Passen Sie Schriftarten, Farben, Ausrichtungen und mehr an."
---

## **Text hervorheben**
Methode [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlighttext/) wurde zur Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) hinzugefügt.

Sie ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe anhand eines Textbeispiels, ähnlich dem Tool „Textmarkerfarbe“ in PowerPoint 2019.

Das nachstehende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// Hervorheben aller Wörter 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// Hervorheben aller separaten Vorkommen von 'the'

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

Aspose bietet einen einfachen, [kostenlosen Online‑PowerPoint‑Bearbeitungsdienst](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Text mit regulärem Ausdruck hervorheben**

Methode [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlightregex/) wurde zur Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) hinzugefügt.

Sie ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe anhand eines regulären Ausdrucks, ähnlich dem Tool „Textmarkerfarbe“ in PowerPoint 2019.

Das nachstehende Code‑Snippet zeigt, wie diese Funktion verwendet wird:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// Hervorheben aller Wörter mit 10 Symbolen oder länger

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Hintergrundfarbe des Textes festlegen**

Aspose.Slides ermöglicht das Festlegen Ihrer bevorzugten Hintergrundfarbe für Text.

Dieser PHP‑Code zeigt, wie die Hintergrundfarbe für gesamten Text gesetzt wird:
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


Dieser PHP‑Code zeigt, wie die Hintergrundfarbe nur für einen Teil des Textes gesetzt wird:
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

Textformatierung ist ein Schlüsselelement beim Erstellen von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für PHP via Java das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema sehen wir, wie die Ausrichtung von Textabsätzen in einer Folie gesteuert werden kann. Bitte folgen Sie den untenstehenden Schritten, um Textabsätze mit Aspose.Slides für PHP via Java auszurichten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie über deren Index.
3. Greifen Sie auf die Platzhalter‑Shapes der Folie zu und casten Sie sie zu einem [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
4. erhalten Sie den Absatz (der ausgerichtet werden soll) aus dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
5. Richten Sie den Absatz aus. Ein Absatz kann rechts, links, zentriert oder blockbasiert ausgerichtet werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.
```php
  # Instanziiere ein Presentation-Objekt, das eine PPTX-Datei darstellt
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Ändere den Text in beiden Platzhaltern
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # Abrufen des ersten Absatzes der Platzhalter
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Zentriere den Textabsatz
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
Dieser Artikel zeigt, wie die Transparenzeigenschaft für beliebige Text‑Shapes mit Aspose.Slides für PHP via Java festgelegt wird. Um die Transparenz für Text festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.
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

Aspose.Slides ermöglicht das Festlegen des Abstands zwischen Zeichen in einem Textfeld. Auf diese Weise können Sie die optische Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen vergrößern oder verkleinern.

Der folgende PHP‑Code zeigt, wie der Abstand für eine Zeile Text vergrößert und für eine andere Zeile verkleinert wird:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// erweitern

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// verdichten

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **Schrifteigenschaften eines Absatzes verwalten**

Präsentationen enthalten meist Text und Bilder. Der Text kann auf verschiedene Weise formatiert werden, sei es zum Hervorheben bestimmter Abschnitte und Wörter oder zur Einhaltung von Unternehmensrichtlinien. Die Textformatierung hilft Benutzern, das Aussehen des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Aspose.Slides für PHP via Java verwendet wird, um die Schrifteigenschaften von Absätzen auf Folien zu konfigurieren. So verwalten Sie die Schrifteigenschaften eines Absatzes mit Aspose.Slides für PHP via Java:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Holen Sie die Referenz einer Folie über deren Index.
1. Greifen Sie auf die Platzhalter‑Shapes der Folie zu und casten Sie sie zu einem [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Erhalten Sie das [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) aus dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Blockbasieren (Justify) Sie den Absatz.
1. Greifen Sie auf den Text‑Portion eines Absatzes zu.
1. Definieren Sie die Schrift mit FontData und setzen Sie die Schrift des Text‑Portion entsprechend.
   1. Setzen Sie die Schrift auf fett.
   1. Setzen Sie die Schrift auf kursiv.
1. Setzen Sie die Schriftfarbe über die [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) des [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)‑Objekts.
1. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben. Sie nimmt eine unformatierte Präsentation und formatiert die Schriftarten auf einer der Folien.
```php
  # Instanziiere ein Presentation-Objekt, das eine PPTX-Datei darstellt
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Zugriff auf die Folie über ihre Position
    $slide = $pres->getSlides()->get_Item(0);
    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Zugriff auf den ersten Absatz
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Zugriff auf den ersten Portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definiere neue Schriftarten
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Weisen Sie den Portionen neue Schriftarten zu
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Schrift auf Fett setzen
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Schrift auf Kursiv setzen
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Schriftfarbe setzen
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Schreiben Sie die PPTX auf die Festplatte
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Schriftfamilie des Textes verwalten**
Ein Portion wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie Aspose.Slides für PHP via Java ein Textfeld mit Text erstellt und dann eine bestimmte Schrift sowie weitere Eigenschaften der Schriftfamilie definiert. So erstellen Sie ein Textfeld und setzen Schriftarteigenschaften des Textes darin:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vom Typ [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) hinzu.
4. Entfernen Sie den Füllstil, der dem [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) zugeordnet ist.
5. Greifen Sie auf das TextFrame des AutoShape zu.
6. Fügen Sie dem TextFrame Text hinzu.
7. Greifen Sie auf das Portion‑Objekt des [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) zu.
8. Definieren Sie die Schrift, die für die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) verwendet werden soll.
9. Setzen Sie weitere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Größe über die entsprechenden Eigenschaften des Portion‑Objekts.
10. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.
```php
  # Instanziiere ein Presentation-Objekt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape des Typs Rechteck hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Entferne den Füllstil, der mit der AutoShape verknüpft ist
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Greife auf das TextFrame der AutoShape zu
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Greife auf die Portion des TextFrames zu
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Setze die Schriftart für die Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Setze die Schrift auf fett
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Setze die Schrift auf kursiv
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Setze die Unterstreichung der Schrift
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Setze die Höhe der Schrift
    $port->getPortionFormat()->setFontHeight(25);
    # Setze die Farbe der Schrift
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Speichere die PPTX-Datei auf die Festplatte
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Schriftgröße für Text festlegen**

Aspose.Slides ermöglicht das Festlegen Ihrer bevorzugten Schriftgröße für vorhandenen Text in einem Absatz sowie für später hinzuzufügenden Text.

Dieser PHP‑Code zeigt, wie die Schriftgröße für Texte innerhalb eines Absatzes gesetzt wird:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # Ermittelt das erste Shape, zum Beispiel.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Ermittelt den ersten Absatz, zum Beispiel.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Setzt die Standardschriftgröße auf 20 pt für alle Textportionen im Absatz.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Setzt die Schriftgröße auf 20 pt für aktuelle Textportionen im Absatz.
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


## **Textrotation festlegen**

Aspose.Slides für PHP via Java ermöglicht das Drehen von Text. Text kann als [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#MongolianVertical) oder [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVerticalRightToLeft) festzulegen. Um den Text eines beliebigen TextFrames zu drehen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) zu.
5. [Drehen Sie den Text](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
6. Speichern Sie die Datei auf dem Datenträger.
```php
  # Instanziiere ein Presentation-Objekt
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape vom Typ Rechteck hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Füge dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Greife auf das TextFrame zu
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Erstelle das Paragraph-Objekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstelle das Portion-Objekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Speichere die Präsentation
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Benutzerdefinierten Rotationswinkel für ein TextFrame festlegen**
Aspose.Slides für PHP via Java unterstützt jetzt das Festlegen eines benutzerdefinierten Rotationswinkels für TextFrames. In diesem Thema zeigen wir anhand eines Beispiels, wie die Eigenschaft RotationAngle in Aspose.Slides gesetzt wird. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/) und [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/getrotationangle/) wurden zur Klasse [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) hinzugefügt und ermöglichen das Festlegen eines benutzerdefinierten Rotationswinkels für TextFrames. Um den RotationAngle zu setzen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Fügen Sie der Folie ein Diagramm hinzu.
3. [Setzen Sie einen Rotationswinkel](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/).
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird die Eigenschaft RotationAngle gesetzt.
```php
  # Instanziiere ein Presentation-Objekt
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape vom Typ Rechteck hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Füge dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Greife auf das TextFrame zu
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Erstelle das Paragraph-Objekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstelle das Portion-Objekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Text rotation example.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Speichere die Präsentation
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zeilenabstand eines Absatzes**
Aspose.Slides stellt Eigenschaften unter [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) bereit – `SpaceAfter`, `SpaceBefore` und `SpaceWithin` – mit denen der Zeilenabstand für einen Absatz verwaltet werden kann. Die drei Eigenschaften werden wie folgt verwendet:

* Um den Zeilenabstand eines Absatzes in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand eines Absatzes in Punkten anzugeben, verwenden Sie einen negativen Wert.

Beispiel: Sie können einen Zeilenabstand von 16 pt für einen Absatz festlegen, indem Sie die Eigenschaft `SpaceBefore` auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die ein AutoShape mit Text enthält.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Absatz zu.
5. Setzen Sie die Absatz‑Eigenschaften.
6. Speichern Sie die Präsentation.

Dieser PHP‑Code zeigt, wie der Zeilenabstand für einen Absatz festgelegt wird:
```php
  # Erstelle eine Instanz der Klasse Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Erhalte die Referenz einer Folie anhand ihres Index
    $sld = $pres->getSlides()->get_Item(0);
    # Greife auf das TextFrame zu
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Greife auf den Absatz zu
    $para = $tf1->getParagraphs()->get_Item(0);
    # Setze Eigenschaften des Absatzes
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # Speichere die Präsentation
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **AutofitType‑Eigenschaft für ein TextFrame festlegen**
In diesem Thema untersuchen wir die verschiedenen Formatierungseigenschaften von TextFrames. Dieser Artikel behandelt das Setzen der AutofitType‑Eigenschaft von TextFrames, die Ankerposition des Textes und das Drehen des Textes in einer Präsentation. Aspose.Slides für PHP via Java ermöglicht das Setzen der AutofitType‑Eigenschaft eines beliebigen TextFrames. AutofitType kann auf [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) oder [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape) gesetzt werden. Wenn auf [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) gesetzt, bleibt die Form unverändert, während der Text angepasst wird, ohne die Form zu verändern. Wird AutofitType auf [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape) gesetzt, wird die Form so modifiziert, dass nur der erforderliche Text darin enthalten ist. So setzen Sie die AutofitType‑Eigenschaft eines TextFrames, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) zu.
5. [Setzen Sie den Autofit‑Typ](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setautofittype/) des TextFrames.
6. Speichern Sie die Datei auf dem Datenträger.
```php
  # Erstelle eine Instanz der Klasse Presentation
  $pres = new Presentation();
  try {
    # Greife auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape vom Typ Rectangle hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Füge dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Greife auf das TextFrame zu
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Erstelle das Paragraph-Objekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstelle das Portion-Objekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Speichere die Präsentation
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ankerposition eines TextFrames festlegen**
Aspose.Slides für PHP via Java ermöglicht das Setzen des Ankers eines beliebigen TextFrames. TextAnchorType gibt an, wo der Text in der Form platziert wird. AnchorType kann auf [Top](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Top), [Center](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Center), [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Justified) oder [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Distributed) gesetzt werden. So setzen Sie den Anker eines beliebigen TextFrames, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie ein beliebiges Shape hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) zu.
5. [Setzen Sie den Textanker‑Typ](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setanchoringtype/) des TextFrames.
6. Speichern Sie die Datei auf dem Datenträger.
```php
  # Erstelle eine Instanz der Klasse Presentation
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape vom Typ Rectangle hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Füge dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Greife auf das TextFrame zu
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Erstelle das Paragraph-Objekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstelle das Portion-Objekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Speichere die Präsentation
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Tabs und EffectiveTabs in einer Präsentation**
Alle Texttabulatoren werden in Pixel angegeben.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Abbildung: 2 explizite Tabs und 2 Standard‑Tabs**|
- Die Eigenschaft EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.
- Die Sammlung EffectiveTabs enthält alle Tabs (aus der Tabs‑Sammlung und Standard‑Tabs).
- EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) gibt den Abstand zwischen Standard‑Tabs (3 und 4 in unserem Beispiel) an.
- EffectiveTabs.GetTabByIndex(index) mit index = 0 liefert den ersten expliziten Tab (Position = 731), index = 1 den zweiten Tab (Position = 1241). Bei index = 2 wird der erste Standard‑Tab (Position = 1470) zurückgegeben usw.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um die nächste Tabulation nach einem Text zu ermitteln. Beispiel: Text „Hello World!“. Um diesen Text zu rendern, muss die Startposition für „world!“ bekannt sein. Zuerst berechnen Sie die Länge von „Hello“ in Pixel und rufen GetTabAfterPosition mit diesem Wert auf. Sie erhalten die nächste Tab‑Position zum Zeichnen von „world!“.

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt das Anwenden des **All Caps**‑Schrifteffekts, dass Text auf der Folie in Großbuchstaben angezeigt wird, obwohl er ursprünglich klein geschrieben wurde. Beim Abrufen eines solchen Textabschnitts mit Aspose.Slides liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um dies zu handhaben, prüfen Sie [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) – wenn er `All` anzeigt, konvertieren Sie die zurückgegebene Zeichenfolge in Großbuchstaben, damit Ihre Ausgabe mit dem, was Benutzer auf der Folie sehen, übereinstimmt.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei sample2.pptx.

![The All Caps effect](all_caps_effect.png)

 Der nachstehende Code‑Beispiel zeigt, wie der Text mit dem **All Caps**‑Effekt extrahiert wird:
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


Ausgabe:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie die Klasse [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Sie können über alle Zellen der Tabelle iterieren und den Text in jeder Zelle ändern, indem Sie deren `TextFrame`‑ und `ParagraphFormat`‑Eigenschaften verwenden.

**Wie kann man Farbverläufe auf Text in einer PowerPoint‑Folien anwenden?**

Um Farbverläufe auf Text anzuwenden, benutzen Sie die Methode `getFillFormat` in [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). Setzen Sie `FillFormat` auf `Gradient`, wobei Sie die Start‑ und Endfarben des Farbverlaufs sowie weitere Eigenschaften wie Richtung und Transparenz definieren, um den Verlaufs‑Effekt auf dem Text zu erzeugen.