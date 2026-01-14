---
title: "Textfelder in Präsentationen mit PHP verwalten"
linktitle: "Textfeld verwalten"
type: docs
weight: 20
url: /de/php-java/manage-textbox/
keywords:
  - "Textfeld"
  - "Textrahmen"
  - "Text hinzufügen"
  - "Text aktualisieren"
  - "Textfeld erstellen"
  - "Textfeld prüfen"
  - "Textspalte hinzufügen"
  - "Hyperlink hinzufügen"
  - "PowerPoint"
  - "Präsentation"
  - "PHP"
  - "Aspose.Slides"
description: "Aspose.Slides für PHP ermöglicht das einfache Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert die Automatisierung Ihrer Präsentationen."
---

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann etwas Text in das Textfeld einfügen. Aspose.Slides für PHP via Java stellt die [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑Klasse bereit, die es Ihnen ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}

Aspose.Slides stellt außerdem die [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑Klasse bereit, mit der Sie Formen zu Folien hinzufügen können. Allerdings können nicht alle über die `Shape`‑Klasse hinzugefügten Formen Text enthalten. Formen, die über die [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑Klasse hinzugefügt werden, können jedoch Text enthalten.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Daher sollten Sie, wenn Sie einer Form Text hinzufügen möchten, prüfen und bestätigen, dass sie über die `AutoShape`‑Klasse erzeugt wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) arbeiten, das eine Eigenschaft von `AutoShape` ist. Siehe den Abschnitt [Update Text](/slides/de/php-java/manage-textbox/#update-text) auf dieser Seite.

{{% /alert %}}

## **Ein Textfeld auf einer Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die erste Folie der neu erstellten Präsentation.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑Objekt mit dem Formtyp [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) an einer angegebenen Position auf der Folie hinzu und erhalten Sie den Verweis auf das neu hinzugefügte `AutoShape`‑Objekt.  
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das einen Text enthält. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*  
5. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt.

Dieser PHP‑Code – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie Text zu einer Folie hinzufügen:
```php
  # Instanziert Präsentation
  $pres = new Presentation();
  try {
    # Holt die erste Folie der Präsentation
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape mit Typ Rectangle hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Fügt dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame(" ");
    # Greift auf das TextFrame zu
    $txtFrame = $ashp->getTextFrame();
    # Erstellt das Paragraph-Objekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellt ein Portion-Objekt für den Paragraph
    $portion = $para->getPortions()->get_Item(0);
    # Setzt Text
    $portion->setText("Aspose TextBox");
    # Speichert die Präsentation auf die Festplatte
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Überprüfen, ob es sich um ein Textfeld handelt**

Aspose.Slides bietet die [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/istextbox/)‑Methode der [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑Klasse, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Text box and shape](istextbox.png)

Dieser PHP‑Code zeigt, wie Sie prüfen, ob eine Form als Textfeld erstellt wurde:
```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```


Beachten Sie, dass die Methode `isTextBox` einer über die `addAutoShape`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)‑Klasse hinzugefügten AutoShape `false` zurückgibt. Nachdem Sie jedoch Text über die `addTextFrame`‑Methode oder die `setText`‑Methode hinzugefügt haben, liefert die Eigenschaft `isTextBox` `true`.
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() gibt false zurück
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() gibt true zurück

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() gibt false zurück
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() gibt true zurück

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() gibt false zurück
$shape3->addTextFrame("");
// shape3->isTextBox() gibt false zurück

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() gibt false zurück
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() gibt false zurück
```


## **Spalten zu einem Textfeld hinzufügen**

Aspose.Slides stellt die Methoden [setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/) und [setColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumnspacing/) der [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/)‑Klasse bereit, mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten in einem Textfeld festlegen und den Abstand zwischen den Spalten in Punktwerten bestimmen.

Dieser Code demonstriert die beschriebene Operation:
```php
  $pres = new Presentation();
  try {
    # Holt die erste Folie der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape mit dem Typ Rectangle hinzu
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Fügt dem Rechteck ein TextFrame hinzu
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Holt das Textformat des TextFrames
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Legt die Anzahl der Spalten im TextFrame fest
    $format->setColumnCount(3);
    # Legt den Abstand zwischen den Spalten fest
    $format->setColumnSpacing(10);
    # Speichert die Präsentation
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Spalten zu einem Textfeld hinzufügen**
Aspose.Slides für PHP via Java stellt die Methode [setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/) der [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/)‑Klasse bereit, mit der Sie Spalten in Textfeldern hinzufügen können. Über diese Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textfeld festlegen.

Dieser PHP‑Code zeigt, wie Sie einer Textfläche eine Spalte hinzufügen:
```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Text aktualisieren**

Aspose.Slides ermöglicht es Ihnen, den Text in einem Textfeld oder alle Texte in einer Präsentation zu ändern oder zu aktualisieren.

Dieser PHP‑Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:
```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Überprüft, ob die Form das Textframe unterstützt (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Durchläuft die Absätze im Textframe
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Durchläuft jede Portion im Absatz
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Ändert den Text

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Ändert die Formatierung

            }
          }
        }
      }
    }
    # Speichert die geänderte Präsentation
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ein Textfeld mit Hyperlink hinzufügen**

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, wird der Link geöffnet.

Um ein Textfeld mit einem Link hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie sich einen Verweis auf die erste Folie der neu erstellten Präsentation.  
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` = `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie den Verweis auf das neu hinzugefügte AutoShape‑Objekt.  
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält.  
5. Instanziieren Sie die `HyperlinkManager`‑Klasse.  
6. Weisen Sie über die Methode [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) einen Hyperlink dem gewünschten Teil des `TextFrame` zu.  
7. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt.

Dieser PHP‑Code – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:
```php
  # Instanziiert eine Presentation-Klasse, die eine PPTX darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein AutoShape-Objekt mit dem Typ Rectangle hinzu
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Castet die Form zu AutoShape
    $pptxAutoShape = $shape;
    # Greift auf die ITextFrame-Eigenschaft der AutoShape zu
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Fügt dem Rahmen Text hinzu
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Setzt den Hyperlink für den Portionstext
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Speichert die PPTX-Präsentation
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter beim Arbeiten mit Master‑Folien?**

Ein [placeholder](/slides/de/php-java/manage-placeholder/) erbt Stil/Position vom [master] (https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) und kann in [layouts] (https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) überschrieben werden, während ein normales Textfeld ein eigenständiges Objekt auf einer bestimmten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen Massen‑Text‑Austausch in der gesamten Präsentation durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie die Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([charts] (https://reference.aspose.com/slides/php-java/aspose.slides/chart/), [tables] (https://reference.aspose.com/slides/php-java/aspose.slides/table/), [SmartArt] (https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.