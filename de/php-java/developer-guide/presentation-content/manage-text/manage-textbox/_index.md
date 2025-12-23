---
title: "Textfelder in Präsentationen mit PHP verwalten"
linktitle: "Textfeld verwalten"
type: docs
weight: 20
url: /de/php-java/manage-textbox/
keywords:
  - Textfeld
  - Textrahmen
  - Text hinzufügen
  - Text aktualisieren
  - Textfeld erstellen
  - Textfeld prüfen
  - Textspalte hinzufügen
  - Hyperlink hinzufügen
  - PowerPoint
  - Präsentation
  - PHP
  - Aspose.Slides
description: "Aspose.Slides für PHP ermöglicht das einfache Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert damit die Automatisierung Ihrer Präsentationen."
---

Texte auf Folien befinden sich in der Regel in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann etwas Text in das Textfeld einfügen. Aspose.Slides für PHP via Java stellt die [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) Schnittstelle bereit, die es Ihnen ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}
Aspose.Slides stellt außerdem die [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) Schnittstelle bereit, die das Hinzufügen von Formen zu Folien ermöglicht. Allerdings können nicht alle über die `IShape` Schnittstelle hinzugefügten Formen Text enthalten. Formen, die über die [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) Schnittstelle hinzugefügt werden, können jedoch Text enthalten.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Daher sollten Sie, wenn Sie mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über die `IAutoShape` Schnittstelle gecastet wurde. Erst dann können Sie mit [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Ein Textfeld auf einer Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.  
2. Erhalten Sie eine Referenz für die erste Folie in der neu erstellten Präsentation.  
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) Objekt mit [ShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setShapeType-int-) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape` Objekt.  
4. Fügen Sie dem `IAutoShape` Objekt die `TextFrame` Eigenschaft hinzu, die einen Text enthalten wird. Im nachstehenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*  
5. Schreiben Sie schließlich die PPTX-Datei über das `Presentation` Objekt.  

Dieser PHP-Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:
```php
  # Instanziert eine Präsentation
  $pres = new Presentation();
  try {
    # Holt die erste Folie in der Präsentation
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape mit Typ Rectangle hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Fügt dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame(" ");
    # Greift auf das TextFrame zu
    $txtFrame = $ashp->getTextFrame();
    # Erstellt das Paragraph-Objekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellt ein Portion-Objekt für den Absatz
    $portion = $para->getPortions()->get_Item(0);
    # Setzt den Text
    $portion->setText("Aspose TextBox");
    # Speichert die Präsentation auf die Festplatte
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Prüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) Methode der [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) Klasse zur Verfügung, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Text box and shape](istextbox.png)

Dieser PHP-Code zeigt Ihnen, wie Sie prüfen können, ob eine Form als Textfeld erstellt wurde:
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


Beachten Sie, dass wenn Sie einfach ein Autoshape mit der `addAutoShape` Methode der [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) Klasse hinzufügen, die `isTextBox` Methode des Autoshapes `false` zurückgibt. Nachdem Sie jedoch Text zum Autoshape mit der `addTextFrame` Methode oder der `setText` Methode hinzugefügt haben, gibt die `isTextBox` Eigenschaft `true` zurück.
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

Aspose.Slides stellt die Eigenschaften [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) und [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (aus der [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) Schnittstelle und der [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) Klasse) zur Verfügung, die es ermöglichen, Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten in einem Textfeld angeben und den Abstand in Punkten zwischen den Spalten festlegen.

Dieser Code demonstriert die beschriebene Operation:
```php
  $pres = new Presentation();
  try {
    # Holt die erste Folie in der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape mit Typ Rectangle hinzu
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Fügt dem Rechteck ein TextFrame hinzu
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Holt das Textformat des TextFrames
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Gibt die Anzahl der Spalten im TextFrame an
    $format->setColumnCount(3);
    # Gibt den Abstand zwischen den Spalten an
    $format->setColumnSpacing(10);
    # Speichert die Präsentation
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Spalten zu einem Textrahmen hinzufügen**

Aspose.Slides für PHP via Java stellt die [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) Eigenschaft (aus der [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) Schnittstelle) bereit, die das Hinzufügen von Spalten in Textrahmen ermöglicht. Mit dieser Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textrahmen festlegen.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textrahmens hinzufügen:
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

Aspose.Slides ermöglicht es Ihnen, den Text in einem Textfeld oder alle Texte in einer Präsentation zu ändern bzw. zu aktualisieren. 

Dieser PHP-Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:
```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Prüft, ob die Form ein Textframe unterstützt (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Durchläuft Absätze im Textframe
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

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, wird der Benutzer zum Öffnen des Links geleitet. 

Um ein Textfeld mit einem Link hinzuzufügen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.  
2. Erhalten Sie eine Referenz für die erste Folie in der neu erstellten Präsentation.  
3. Fügen Sie ein `AutoShape` Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie eine Referenz des neu hinzugefügten AutoShape Objekts.  
4. Fügen Sie dem `AutoShape` Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält.  
5. Instanziieren Sie die `IHyperlinkManager` Klasse.  
6. Weisen Sie das `IHyperlinkManager` Objekt der [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) Eigenschaft zu, die mit dem gewünschten Teil des `TextFrame` verknüpft ist.  
7. Schreiben Sie schließlich die PPTX-Datei über das `Presentation` Objekt.  

Dieser PHP-Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie einem Folie ein Textfeld mit Hyperlink hinzufügen:
```php
  # Instanziert eine Presentation‑Klasse, die ein PPTX darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie in der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein AutoShape‑Objekt mit dem Typ Rectangle hinzu
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Castet die Form zu AutoShape
    $pptxAutoShape = $shape;
    # Greift auf die ITextFrame‑Eigenschaft der AutoShape zu
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Fügt dem Rahmen Text hinzu
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Setzt den Hyperlink für den Portionstext
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Speichert die PPTX‑Präsentation
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter bei der Arbeit mit Masterfolien?**

Ein [placeholder](/slides/de/php-java/manage-placeholder/) erbt Stil/Position vom [master](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) und kann auf [layouts](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn Sie die Layouts wechseln.

**Wie kann ich einen massenhaften Textaustausch in der gesamten Präsentation durchführen, ohne Texte in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie Ihre Iteration auf Auto-Shapes, die Textrahmen besitzen, und schließen Sie eingebettete Objekte ([charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.