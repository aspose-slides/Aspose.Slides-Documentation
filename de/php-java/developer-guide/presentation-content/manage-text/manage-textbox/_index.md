---
title: Textfelder in Präsentationen mit PHP verwalten
linktitle: Textfeld verwalten
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
description: "Aspose.Slides für PHP erleichtert das Erstellen, Bearbeiten und Duplizieren von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert Ihre Präsentationsautomatisierung."
---
## **Einleitung**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann etwas Text in das Textfeld einfügen. Aspose.Slides für PHP via Java stellt die [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) Klasse bereit, die es Ihnen ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}
Aspose.Slides stellt außerdem die [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) Klasse zur Verfügung, die es ermöglicht, Formen zu Folien hinzuzufügen. Allerdings können nicht alle über die `Shape`‑Klasse hinzugefügten Formen Text enthalten. Formen, die über die [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) Klasse hinzugefügt werden, können jedoch Text enthalten.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Daher sollten Sie, wenn Sie mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, prüfen und bestätigen, dass sie über die `AutoShape`‑Klasse vergeben wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) arbeiten, das eine Eigenschaft von `AutoShape` ist. Siehe den Abschnitt [Update Text](/slides/de/php-java/manage-textbox/#update-text) auf dieser Seite.
{{% /alert %}}

## **Ein Textfeld auf einer Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz auf die erste Folie der neu erstellten Präsentation.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) Objekt mit dem Formtyp [Rectangle](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapetype/#Rectangle) an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz auf das neu hinzugefügte `AutoShape`‑Objekt.  
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das Text enthalten soll. Im nachfolgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*  
5. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt.  

Dieser PHP‑Code – eine Umsetzung der obigen Schritte – zeigt, wie Sie Text zu einer Folie hinzufügen:

```php
  # Instanziert die Präsentation
  $pres = new Presentation();
  try {
    # Erhält die erste Folie der Präsentation
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape mit dem Typ Rechteck hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Fügt dem Rechteck ein TextFrame hinzu
    $ashp->addTextFrame(" ");
    # Greift auf das TextFrame zu
    $txtFrame = $ashp->getTextFrame();
    # Erstellt das Paragraph-Objekt für das TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellt ein Portion-Objekt für das Paragraph
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

## **Überprüfung einer Textfeld‑Form**

Aspose.Slides stellt die Methode [isTextBox](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/istextbox/) der [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) Klasse bereit, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Textfeld und Form](istextbox.png)

Dieser PHP‑Code zeigt, wie Sie prüfen können, ob eine Form als Textfeld erstellt wurde:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Beachten Sie, dass wenn Sie einfach eine AutoShape mit der `addAutoShape`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/) Klasse hinzufügen, die `isTextBox`‑Methode der AutoShape `false` zurückgibt. Nachdem Sie jedoch Text zur AutoShape mit der `addTextFrame`‑Methode oder der `setText`‑Methode hinzugefügt haben, gibt die `isTextBox`‑Eigenschaft `true` zurück.

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

## **Finden der Form, die einen Textrahmen besitzt**

In generischem Textverarbeitungscode können Sie ein [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) erhalten, ohne bereits zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die Methode [TextFrame::getParentShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentShape), um zum übergeordneten [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) zurückzukehren.

Für einen Textrahmen, der zu einer [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) oder einer anderen textenthaltenden Form gehört, liefert [TextFrame::getParentShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentShape) den Eigentümer und [TextFrame::getParentCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentCell) liefert `null`. Beide Methoden bieten eine nur‑lesbare Navigation, sodass ihr Aufruf das Eigentum nicht ändert. Überprüfen Sie immer den zurückgegebenen Wert mit `java_is_null`, bevor Sie auf die Form zugreifen.

Für ein vollständiges Beispiel, das Form‑ und Tabellenzellen‑Eigentümer identifiziert, einschließlich Formen, die mit SmartArt‑Knoten verknüpft sind, siehe [Search and Replace Text](/slides/de/php-java/search-and-replace-text/).

## **Spalten zu einem Textfeld hinzufügen**

Aspose.Slides stellt die Methoden [setColumnCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/setcolumncount/) und [setColumnSpacing](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/setcolumnspacing/) der [TextFrameFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/) Klasse zur Verfügung, die es Ihnen ermöglichen, Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten in einem Textfeld angeben und den Abstand in Punkten zwischen den Spalten festlegen.

Dieser Code demonstriert den beschriebenen Vorgang:

```php
  $pres = new Presentation();
  try {
    # Erhält die erste Folie der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape mit dem Typ Rechteck hinzu
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Fügt dem Rechteck ein TextFrame hinzu
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Erhält das Textformat des TextFrames
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

Aspose.Slides für PHP via Java bietet die Methode [setColumnCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/setcolumncount/) der [TextFrameFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/) Klasse, die es ermöglicht, Spalten in Textrahmen hinzuzufügen. Über diese Eigenschaft können Sie die gewünschte Anzahl von Spalten in einem Textrahmen festlegen.

Dieser PHP‑Code zeigt, wie Sie innerhalb eines Textrahmens eine Spalte hinzufügen:

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

Aspose.Slides ermöglicht es Ihnen, den in einem Textfeld enthaltenen Text oder alle Texte einer Präsentation zu ändern bzw. zu aktualisieren.

Dieser PHP‑Code demonstriert einen Vorgang, bei dem alle Texte in einer Präsentation aktualisiert bzw. geändert werden:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Prüft, ob die Form Textrahmen unterstützt (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Durchläuft die Absätze im Textrahmen
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Durchläuft jeden Abschnitt im Absatz
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

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, wird der Nutzer zum Öffnen des Links weitergeleitet.

Um ein Textfeld mit einem Link hinzuzufügen, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie sich eine Referenz auf die erste Folie der neu erstellten Präsentation.  
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz auf das neu hinzugefügte AutoShape‑Objekt.  
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält.  
5. Instanziieren Sie die `HyperlinkManager`‑Klasse.  
6. Ordnen Sie mit der Methode [setExternalHyperlinkClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) einen Hyperlink dem gewünschten Teil des `TextFrame` zu.  
7. Schreiben Sie schließlich die PPTX‑Datei über das `Presentation`‑Objekt.  

Dieser PHP‑Code – eine Umsetzung der obigen Schritte – zeigt, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:

```php
  # Instanziert eine Presentation-Klasse, die ein PPTX darstellt
  $pres = new Presentation();
  try {
    # Erhält die erste Folie der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein AutoShape-Objekt mit dem Typ Rechteck hinzu
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Castet die Form zu AutoShape
    $pptxAutoShape = $shape;
    # Greift auf die ITextFrame-Eigenschaft der AutoShape zu
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Fügt dem Rahmen etwas Text hinzu
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Setzt den Hyperlink für den Textabschnitt
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

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter bei der Arbeit mit Master‑Folien?**

Ein [placeholder](/slides/de/php-java/manage-placeholder/) erbt Stil/Position vom [master](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) und kann auf [layouts](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer bestimmten Folie ist und sich nicht ändert, wenn Sie das Layout wechseln.

**Wie kann ich einen massiven Textaustausch in der gesamten Präsentation durchführen, ohne Texte in Diagrammen, Tabellen und SmartArt zu berühren?**

Begrenzen Sie Ihre Schleife auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([charts](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/de/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.