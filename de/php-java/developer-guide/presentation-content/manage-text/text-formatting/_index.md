---
title: Textformatierung
type: docs
weight: 50
url: /php-java/text-formatting/
---

## **Text hervorheben**
Die Methode [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) wurde zum Interface [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) hinzugefügt.

Es ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe anhand eines Textbeispiels, ähnlich dem Werkzeug Textmarkierungsfarbe in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie Sie diese Funktion verwenden können:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// hebt alle Wörter 'wichtig' hervor

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// hebt alle separaten Vorkommen von 'the' hervor

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

## **Text hervorheben mittels regulärer Ausdrücke**

Die Methode [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) wurde zum Interface [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) und zur Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) hinzugefügt.

Es ermöglicht das Hervorheben eines Textteils mit Hintergrundfarbe mithilfe von Regex, ähnlich dem Werkzeug Textmarkierungsfarbe in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie Sie diese Funktion verwenden können:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// hebt alle Wörter mit 10 oder mehr Zeichen hervor

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Text-Hintergrundfarbe festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Farbe für den Hintergrund eines Texts festzulegen.

Dieser PHP-Code zeigt Ihnen, wie Sie die Hintergrundfarbe für einen gesamten Text festlegen:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Schwarz");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Rot ");
    $portion3 = new Portion("Schwarz");
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

Dieser PHP-Code zeigt Ihnen, wie Sie die Hintergrundfarbe nur für einen Teil eines Texts festlegen:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Schwarz");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Rot ");
    $portion3 = new Portion("Schwarz");
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
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Rot"))->findFirst();
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

Die Textformatierung ist eines der Schlüsselelemente bei der Erstellung jeglicher Art von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für PHP über Java das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema werden wir sehen, wie wir die Ausrichtung der Textabsätze in einer Folie steuern können. Bitte folgen Sie den folgenden Schritten, um Textabsätze mit Aspose.Slides für PHP über Java auszurichten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Erlangen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und typwandeln Sie sie als [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. Holen Sie sich den Absatz (der ausgerichtet werden muss) aus dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) der von [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) bereitgestellt wird.
5. Richten Sie den Absatz aus. Ein Absatz kann rechts, links, zentriert oder im Blocksatz ausgerichtet werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```php
  # Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typwandeln als AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Ändern Sie den Text in beiden Platzhaltern
    $tf1->setText("Zentrierte Ausrichtung von Aspose");
    $tf2->setText("Zentrierte Ausrichtung von Aspose");
    # Holen Sie sich den ersten Absatz der Platzhalter
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Richten Sie den Textabsatz zentriert aus
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Schreiben Sie die Präsentation als PPTX-Datei
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Transparenz für Text festlegen**
Dieser Artikel demonstriert, wie Sie die Transparenzeigenschaft für eine Textform mit Aspose.Slides für PHP über Java festlegen können. Um die Transparenz für Text festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - Transparenz ist: " . $shadowColor->getAlpha() / 255.0 * 100);
    # setze die Transparenz auf null Prozent
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zeichenabstand für Text festlegen**

Aspose.Slides ermöglicht es Ihnen, den Abstand zwischen Buchstaben in einer Textbox festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen erweitern oder reduzieren.

Dieser PHP-Code zeigt Ihnen, wie Sie den Abstand für eine Textzeile erweitern und den Abstand für eine andere Zeile reduzieren können:

```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// erweitern

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// reduzieren

  $presentation->save("out.pptx", SaveFormat::Pptx);
```

## **Schriftarteigenschaften von Absätzen verwalten**

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, entweder um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensstilen zu entsprechen. Die Textformatierung hilft Benutzern, das Aussehen und Gefühl des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Sie Aspose.Slides für PHP über Java verwenden, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren. Um die Schriftarteigenschaften eines Absatzes mithilfe von Aspose.Slides für PHP über Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erlangen Sie eine Referenz zu einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die Platzhalterformen in der Folie zu und typwandeln Sie sie in [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Holen Sie sich den [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) aus dem [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) der von [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) bereitgestellt wird.
1. Rechtsfertigen Sie den Absatz.
1. Greifen Sie auf die Textportion eines Absatzes zu.
1. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart der Textportion entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   2. Setzen Sie die Schriftart auf kursiv.
1. Legen Sie die Schriftfarbe mithilfe der [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) fest, die von dem [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion) Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben. Sie nimmt eine schmucklose Präsentation und formatiert die Schriftarten auf einer der Folien.

```php
  # Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Zugriff auf eine Folie anhand ihrer Folienposition
    $slide = $pres->getSlides()->get_Item(0);
    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typwandeln als AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Zugriff auf den ersten Absatz
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Zugriff auf die erste Portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definieren Sie neue Schriftarten
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Weisen Sie den Portionen neue Schriftarten zu
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Setzen Sie die Schriftart auf fett
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Setzen Sie die Schriftart auf kursiv
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Setzen Sie die Schriftfarbe
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
Eine Portion wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie Sie Aspose.Slides für PHP über Java verwenden, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene andere Eigenschaften der Schriftfamilienkategorie festzulegen. Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Texts festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Erlangen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) der Art [Rechteck](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) zur Folie hinzu.
4. Entfernen Sie den Füllstil, der mit der [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) verbunden ist.
5. Greifen Sie auf das TextFrame der AutoShape zu.
6. Fügen Sie etwas Text zum TextFrame hinzu.
7. Greifen Sie auf das mit dem [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) verbundene Portion-Objekt zu.
8. Definieren Sie die Schriftart, die für die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion) verwendet werden soll.
9. Legen Sie andere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mithilfe der entsprechenden Eigenschaften, die vom Portion-Objekt bereitgestellt werden, fest.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```php
  # Instanziieren Sie die Präsentation
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Entfernen Sie den Füllstil, der mit der AutoShape verbunden ist
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame, das mit der AutoShape verbunden ist
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Zugriff auf die Portion, die mit dem TextFrame verbunden ist
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Setzen Sie die Schriftart für die Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Setzen Sie die fett-Eigenschaft der Schriftart
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Setzen Sie die kursiv-Eigenschaft der Schriftart
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Setzen Sie die unterstrichen-Eigenschaft der Schriftart
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Setzen Sie die Höhe der Schriftart
    $port->getPortionFormat()->setFontHeight(25);
    # Setzen Sie die Farbe der Schriftart
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Schreiben Sie die PPTX auf die Festplatte
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Schriftgröße für Text festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Schriftgröße für vorhandenen Text in einem Absatz und andere Texte, die möglicherweise später zu dem Absatz hinzugefügt werden, auszuwählen.

Dieser PHP-Code zeigt Ihnen, wie Sie die Schriftgröße für Texte in einem Absatz festlegen:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Holt die erste Form, zum Beispiel.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Holt den ersten Absatz, zum Beispiel.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Setzt die Standard-Schriftgröße auf 20 pt für alle Textportionen im Absatz.
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

## **Textdrehung festlegen**

Aspose.Slides für PHP über Java ermöglicht Entwicklern, den Text zu drehen. Der Text kann so eingestellt werden, dass er [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal), [Vertikal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical), [Vertikal270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertikal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical), [OstasienVertikal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolischVertikal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) oder [WordArtVertikalRechtsNachLinks](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) erscheint. Um den Text eines TextFrames zu drehen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Drehen Sie den Text](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Speichern Sie die Datei auf der Festplatte.

```php
  # Erstellen Sie eine Instanz der Präsentationsklasse
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Fügen Sie dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Erstellen Sie das Absatzobjekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellen Sie das Portionobjekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.");
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

## **Benutzerdefinierten Drehwinkel für TextFrame festlegen**
Aspose.Slides für PHP über Java unterstützt jetzt die Festlegung des benutzerdefinierten Drehwinkels für das TextFrame. In diesem Thema werden wir mit einem Beispiel sehen, wie Sie die Property RotationAngle in Aspose.Slides festlegen. Die neuen Methoden [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) und [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) wurden zu den Interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) und [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) hinzugefügt, um den benutzerdefinierten Drehwinkel für das TextFrame festzulegen. Um den RotationAngle festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Fügen Sie ein Diagramm auf die Folie hinzu.
3. [Setzen Sie die RotationAngle-Property](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel setzen wir die RotationAngle-Property.

```php
  # Erstellen Sie eine Instanz der Präsentationsklasse
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Fügen Sie dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Erstellen Sie das Absatzobjekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellen Sie das Portionobjekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Beispiel für Textdrehung.");
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

## **Zeilenabstand des Absatzes**
Aspose.Slides bietet Eigenschaften unter [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` und `SpaceWithin`—die es Ihnen ermöglichen, den Zeilenabstand für einen Absatz zu verwalten. Die drei Eigenschaften werden wie folgt verwendet:

* Um den Zeilenabstand für einen Absatz in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Absatz in Punkten anzugeben, verwenden Sie einen negativen Wert.

Zum Beispiel können Sie einen 16pt-Zeilenabstand für einen Absatz festlegen, indem Sie die `SpaceBefore`-Eigenschaft auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die eine AutoShape mit einem Text enthält.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Absatz zu.
5. Legen Sie die Eigenschaften des Absatzes fest.
6. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie den Zeilenabstand für einen Absatz angeben:

```php
  # Erstellen Sie eine Instanz der Präsentationsklasse
  $pres = new Presentation("Fonts.pptx");
  try {
    # Erlangen Sie eine Folienreferenz über ihren Index
    $sld = $pres->getSlides()->get_Item(0);
    # Zugriff auf das TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Zugriff auf den Absatz
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

## **Die AutofitType-Eigenschaft für TextFrame festlegen**
In diesem Thema werden wir die verschiedenen Formatierungs Eigenschaften des Textframes erkunden. Dieser Artikel behandelt, wie Sie die AutofitType-Eigenschaft des Textframes, den Anker des Texts und die Drehung des Texts in der Präsentation festlegen. Aspose.Slides für PHP über Java ermöglicht Entwicklern, die AutofitType-Eigenschaft eines beliebigen Textframes festzulegen. AutofitType kann auf [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) oder [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape) gesetzt werden. Wenn auf [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) gesetzt, bleibt die Form gleich, während der Text ohne Änderung der Form angepasst wird, während, wenn AutofitType auf [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape) gesetzt ist, die Form so modifiziert wird, dass nur der erforderliche Text enthalten ist. Um die AutofitType-Eigenschaft eines Textframes festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Setzen Sie die AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```php
  # Erstellen Sie eine Instanz der Präsentationsklasse
  $pres = new Presentation();
  try {
    # Greifen Sie auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Fügen Sie dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Erstellen Sie das Absatzobjekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellen Sie das Portionobjekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.");
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

## **Anker des TextFrame festlegen**
Aspose.Slides für PHP über Java ermöglicht Entwicklern, den Anker eines beliebigen TextFrames festzulegen. TextAnchorType gibt an, wo der Text in der Form platziert ist. Der AnchorType kann auf [Oben](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top), [Zentrum](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center), [Unten](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) oder [Verteilt](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed) gesetzt werden. Um den Anker eines beliebigen TextFrames festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Setzen Sie den TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```php
  # Erstellen Sie eine Instanz der Präsentationsklasse
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Fügen Sie dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Zugriff auf das TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Erstellen Sie das Absatzobjekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellen Sie das Portionobjekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.");
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

## **Tabs und EffectiveTabs in der Präsentation**
Alle Texttabulatoren werden in Pixeln angegeben.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Abbildung: 2 explizite Tabs und 2 Standard-Tabs**|
- Die Eigenschaft EffectiveTabs.ExplicitTabCount (2 in unserem Fall) entspricht der Tabs.Count.
- Die EffeffectiveTabs-Sammlung umfasst alle Tabs (aus der Tabs-Sammlung und Standard-Tabs).
- Die Eigenschaft EffectiveTabs.ExplicitTabCount (2 in unserem Fall) entspricht der Tabs.Count.
- Die Eigenschaft EffectiveTabs.DefaultTabSize (294) zeigt den Abstand zwischen den Standard-Tabs (3 und 4 in unserem Beispiel).
- EffectiveTabs.GetTabByIndex(index) mit index = 0 gibt den ersten expliziten Tab (Position = 731) zurück, index = 1 - den zweiten Tab (Position = 1241). Wenn Sie versuchen, den nächsten Tab mit index = 2 zu erhalten, gibt es den ersten Standard-Tab (Position = 1470) zurück usw.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um die nächste Tabulatorposition nach einem bestimmten Text zu erhalten. Zum Beispiel haben Sie den Text: "Hallo Welt!". Um diesen Text zu rendern, sollten Sie wissen, wo Sie mit "Welt!" beginnen. Zunächst sollten Sie die Länge von "Hallo" in Pixeln berechnen und mit diesem Wert GetTabAfterPosition aufrufen. Sie erhalten die nächste Tabulatorposition, um "Welt!" zu zeichnen.