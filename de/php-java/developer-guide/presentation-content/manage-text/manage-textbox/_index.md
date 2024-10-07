---
title: TextBox verwalten
type: docs
weight: 20
url: /php-java/manage-textbox/
description: Erstellen Sie ein Textfeld auf PowerPoint-Folien mit PHP. Fügen Sie eine Spalte in das Textfeld oder den Textrahmen in PowerPoint-Folien mit PHP ein. Fügen Sie ein Textfeld mit Hyperlink in PowerPoint-Folien mit PHP hinzu.
---


Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Um also Text auf eine Folie hinzuzufügen, müssen Sie ein Textfeld hinzufügen und dann etwas Text in das Textfeld eingeben. Aspose.Slides für PHP über Java bietet die [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) Schnittstelle, die es Ihnen ermöglicht, eine Form hinzuzufügen, die Text enthält.

{{% alert title="Info" color="info" %}}

Aspose.Slides bietet auch die [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) Schnittstelle, die es Ihnen ermöglicht, Formen zu Folien hinzuzufügen. Es können jedoch nicht alle Formen, die über die `IShape` Schnittstelle hinzugefügt werden, Text halten. Gleichzeitig können Formen, die über die [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) Schnittstelle hinzugefügt werden, Text enthalten.

{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie also mit einer Form arbeiten, der Sie Text hinzufügen möchten, sollten Sie überprüfen und bestätigen, dass sie über die `IAutoShape` Schnittstelle erstellt wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Text aktualisieren](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) auf dieser Seite.

{{% /alert %}}

## **Textfeld auf Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Erhalten Sie eine Referenz auf die erste Folie der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) Objekt hinzu, wobei [ShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setShapeType-int-) auf `Rectangle` an einer bestimmten Position auf der Folie gesetzt ist, und erhalten Sie die Referenz des neu hinzugefügten `IAutoShape` Objekts.
4. Fügen Sie der `IAutoShape`  ein `TextFrame` hinzu, das einen Text enthält. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Speichern Sie schließlich die PPTX-Datei durch das `Presentation` Objekt. 

Dieser PHP-Code – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:

```php
  # Erstellt eine Präsentation
  $pres = new Presentation();
  try {
    # Holt die erste Folie in der Präsentation
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape mit Typ Rectangle hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Fügt TextFrame zum Rechteck hinzu
    $ashp->addTextFrame(" ");
    # Greift auf das Textfeld zu
    $txtFrame = $ashp->getTextFrame();
    # Erstellt das Paragraph-Objekt für das Textfeld
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellt ein Portion-Objekt für das Paragraph
    $portion = $para->getPortions()->get_Item(0);
    # Setzt den Text
    $portion->setText("Aspose TextBox");
    # Speichert die Präsentation auf der Festplatte
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Überprüfen Sie das Textfeld-Form**

Aspose.Slides bietet die [isTextBox()](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) Eigenschaft (von der [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) Klasse), um die Formen zu prüfen und Textfelder zu finden.

![Textfeld und Form](istextbox.png)

Dieser PHP-Code zeigt Ihnen, wie Sie überprüfen, ob eine Form als Textfeld erstellt wurde:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index){
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape")))
        $autoShape = $shape;
        echo(java_is_true($autoShape->isTextBox()) ? "Form ist ein Textfeld" : "Form ist kein Textfeld");
    }
}

  $pres = new Presentation("pres.pptx");
  try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($pres, $forEachShapeCallback);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Spalte im Textfeld hinzufügen**

Aspose.Slides bietet die [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) und [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) Eigenschaften (von der [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) Schnittstelle und [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) Klasse), die es Ihnen ermöglichen, Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten in einem Textfeld angeben und den Abstand in Punkten zwischen den Spalten festlegen.

Dieser Code demonstriert die beschriebene Operation:

```php
  $pres = new Presentation();
  try {
    # Holt die erste Folie in der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape mit Typ Rectangle hinzu
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Fügt TextFrame zum Rechteck hinzu
    $aShape->addTextFrame("Alle diese Spalten sind darauf beschränkt, innerhalb eines einzigen Textcontainers zu bleiben – " . "Sie können Text hinzufügen oder löschen, und der neue oder verbleibende Text passt sich automatisch " . "an, um innerhalb des Containers zu fließen. Sie können keinen Text von einem Container " . "in einen anderen fließen lassen – wir haben Ihnen gesagt, dass die Spaltenoptionen für Text in PowerPoint begrenzt sind!");
    # Holt das Textformat von TextFrame
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


## **Spalte im Textrahmen hinzufügen**
Aspose.Slides für PHP über Java bietet die [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) Eigenschaft (von der [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) Schnittstelle), die es Ihnen ermöglicht, Spalten in Textrahmen hinzuzufügen. Über diese Eigenschaft können Sie Ihre bevorzugte Anzahl von Spalten in einem Textrahmen angeben.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textrahmens hinzufügen:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("Alle diese Spalten sind gezwungen, innerhalb eines einzigen Textcontainers zu bleiben – " . "Sie können Text hinzufügen oder löschen – und der neue oder verbleibende Text passt sich " . "automatisch an, um innerhalb des Containers zu bleiben. Sie können keinen Text von einem Container " . "in einen anderen fließen lassen, da die Spaltenoptionen für Text in PowerPoint begrenzt sind!");
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

Aspose.Slides ermöglicht es Ihnen, den Text, der in einem Textfeld enthalten ist, oder alle Texte in einer Präsentation zu ändern oder zu aktualisieren. 

Dieser PHP-Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert oder geändert werden:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Überprüft, ob die Form ein Textfeld (IAutoShape) unterstützt.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Iteriert durch die Absätze im Textfeld
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Iteriert durch jede Portion im Absatz
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Ändert den Text

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Ändert das Format

            }
          }
        }
      }
    }
    # Speichert die modifizierte Präsentation
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Textfeld mit Hyperlink hinzufügen** 

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, werden die Benutzer dazu aufgefordert, den Link zu öffnen. 

Um ein Textfeld mit einem Link hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der `Presentation` Klasse. 
2. Erhalten Sie eine Referenz auf die erste Folie der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape` Objekt mit `ShapeType` auf `Rectangle` an einer bestimmten Position auf der Folie hinzu und erhalten Sie eine Referenz des neu hinzugefügten AutoShape Objekts.
4. Fügen Sie dem `AutoShape` ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die `IHyperlinkManager` Klasse. 
6. Weisen Sie das `IHyperlinkManager` Objekt der [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) Eigenschaft zu, die mit der bevorzugten Portion des `TextFrame` verbunden ist.
7. Speichern Sie schließlich die PPTX-Datei durch das `Presentation` Objekt. 

Dieser PHP-Code – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie ein Textfeld mit einem Hyperlink zu einer Folie hinzufügen:

```php
  # Erstellt eine Präsentationsklasse, die ein PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Holt die erste Folie in der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein AutoShape-Objekt mit Typ Rectangle hinzu
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Wandelt die Form in ein AutoShape um
    $pptxAutoShape = $shape;
    # Greift auf die ITextFrame-Eigenschaft zu, die mit dem AutoShape verbunden ist
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Fügt etwas Text zum Rahmen hinzu
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