---
title: Schriftarten verwalten - PowerPoint Java API
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /de/php-java/manage-fonts/
description: Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Dieser Artikel zeigt, wie man die Schriftarteigenschaften von Textabsätzen auf Folien mit der PowerPoint Java API konfiguriert.
---

## **Schriftartbezogene Eigenschaften verwalten**
{{% alert color="primary" %}} 

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, entweder um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensstilen zu entsprechen. Die Textformatierung hilft Benutzern, das Aussehen und die Atmosphäre des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für PHP über Java verwendet, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um die Schriftarteigenschaften eines Absatzes mit Aspose.Slides für PHP über Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Erhalten Sie einen Verweis auf die Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Placeholder) Formen in der Folie zu und typwandeln Sie sie in [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Holen Sie sich den [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph) aus dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame), der von [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) zur Verfügung gestellt wird.
1. Rechtfertigen Sie den Absatz.
1. Greifen Sie auf den Text [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) eines [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph) zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FontData) und setzen Sie die **Schriftart** des Text [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Setzen Sie die Schriftfarbe mit dem [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FillFormat), das vom [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) Objekt bereitgestellt wird.
1. Speichern Sie die modifizierte Präsentation in einer PPTX-Datei.

Die Implementierung der obigen Schritte ist unten angegeben. Sie nimmt eine ungeschmückte Präsentation und formatiert die Schriftarten auf einer der Folien. Die nachfolgenden Screenshots zeigen die Eingabedatei und wie die Code-Snippets sie ändern. Der Code ändert die Schriftart, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Der gleiche Text mit aktualisierter Formatierung**|

```php
  # Erstellen Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Zugriff auf eine Folie anhand ihrer Position
    $slide = $pres->getSlides()->get_Item(0);
    # Zugriff auf den ersten und zweiten Placeholder in der Folie und typwandeln als AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Zugriff auf den ersten Paragraph
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Den Absatz rechtfertigen
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Zugriff auf den ersten Anteil
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Neue Schriftarten definieren
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Neue Schriftarten dem Anteil zuweisen
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Schriftart auf fett setzen
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Schriftart auf kursiv setzen
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Schriftfarbe setzen
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # PPTX auf die Festplatte speichern
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Textschriftarteigenschaften festlegen**
{{% alert color="primary" %}} 

Wie in **Verwalten schriftartbezogener Eigenschaften** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides für PHP über Java verwendet, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene andere Eigenschaften der Schriftfamilienkategorie zu definieren.

{{% /alert %}} 

Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Erhalten Sie den Verweis auf eine Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) des Typs **Rechteck** hinzu.
1. Entfernen Sie den Füllstil, der mit der [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) verbunden ist.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) der [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) zu.
1. Fügen Sie etwas Text zum [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) hinzu.
1. Greifen Sie auf das [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) Objekt zu, das mit dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) verbunden ist.
1. Definieren Sie die zu verwendende Schriftart für das [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Setzen Sie andere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mithilfe der relevanten Eigenschaften, die vom [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) Objekt bereitgestellt werden.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist unten angegeben.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides für PHP über Java festgelegten Schriftarteigenschaften**|

```php
  # Erstellen Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Erhalten Sie die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Rechtecktyp hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Entfernen Sie jeglichen Füllstil, der mit der AutoShape verbunden ist
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Greifen Sie auf das TextFrame der AutoShape zu
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Greifen Sie auf den Anteil zu, der mit dem TextFrame verbunden ist
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Setzen Sie die Schriftart für den Anteil
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Setzen Sie die Fettschrift-Eigenschaft der Schriftart
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Setzen Sie die Kursiveigenschaft der Schriftart
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Setzen Sie die Unterstreichungseigenschaft der Schriftart
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Setzen Sie die Höhe der Schriftart
    $port->getPortionFormat()->setFontHeight(25);
    # Setzen Sie die Farbe der Schriftart
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Speichern Sie die Präsentation auf der Festplatte
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```