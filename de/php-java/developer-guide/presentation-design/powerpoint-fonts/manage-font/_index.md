---
title: Schriftarten in Präsentationen mit PHP verwalten
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /de/php-java/manage-fonts/
keywords:
- Schriftarten verwalten
- Schrifteigenschaften
- Absatz
- Textformatierung
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Steuern Sie Schriftarten in PHP mit Aspose.Slides: Einbetten, Ersetzen und Laden benutzerdefinierter Schriftarten, um PPT-, PPTX- und ODP-Präsentationen klar, markenkonform und konsistent zu halten."
---

## **Schriftbezogene Eigenschaften verwalten**
{{% alert color="primary" %}} 

Präsentationen enthalten meist sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung ermöglicht es Benutzern, das Aussehen und das Gefühl des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Aspose.Slides für PHP via Java verwendet wird, um die Schrifteigenschaften von Absätzen auf Folien zu konfigurieren.

{{% /alert %}} 

So verwalten Sie die Schrifteigenschaften eines Absatzes mit Aspose.Slides für PHP via Java:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/)-Formen in der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Holen Sie das [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) aus dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), das von [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) bereitgestellt wird.
1. Richten Sie den Absatz aus.
1. Greifen Sie auf das Text-[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)-Objekt eines [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) und setzen Sie die **Font** der Text[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Setzen Sie die Schriftfarbe mit dem über das [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)-Objekt bereitgestellten [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte finden Sie unten. Sie nimmt eine einfache Präsentation und formatiert die Schriften auf einer der Folien. Die nachfolgenden Screenshots zeigen die Eingabedatei und wie die Code‑Snippets sie verändern. Der Code ändert die Schriftart, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Der gleiche Text mit aktualisierter Formatierung**|
```php
  # Instanziiere ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Zugriff auf eine Folie anhand ihrer Position
    $slide = $pres->getSlides()->get_Item(0);
    # Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Zugriff auf den ersten Absatz
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Ausrichtung des Absatzes auf Blocksatz
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Zugriff auf den ersten Teil
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definiere neue Schriftarten
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Weist neue Schriftarten der Portion zu
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
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Speichere die PPTX-Datei auf dem Datenträger
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Text-Schrifteigenschaften festlegen**
{{% alert color="primary" %}} 

Wie im Abschnitt **Schriftbezogene Eigenschaften verwalten** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie Aspose.Slides für PHP via Java verwendet wird, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene weitere Eigenschaften der Schriftfamilie festzulegen.

{{% /alert %}} 

So erstellen Sie ein Textfeld und setzen die Schrifteigenschaften des darin enthaltenen Textes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.
1. Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)-Objekt des Typs **Rectangle** hinzu.
1. Entfernen Sie den Füllstil, der mit dem [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) verbunden ist.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) etwas Text hinzu.
1. Greifen Sie auf das [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)-Objekt zu, das mit dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) verknüpft ist.
1. Definieren Sie die Schriftart, die für das [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) verwendet werden soll.
1. Setzen Sie weitere Schrifteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe über die entsprechenden Eigenschaften des [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)-Objekts.
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte finden Sie unten.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides für PHP via Java gesetzten Schrifteigenschaften**|
```php
  # Instanziiere ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape vom Typ Rectangle hinzu
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Entferne jeglichen Füllstil, der mit der AutoShape verbunden ist
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Greife auf das TextFrame zu, das mit der AutoShape verknüpft ist
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Greife auf die Portion zu, die mit dem TextFrame verknüpft ist
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Setze die Schriftart für die Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Setze die Fettdruck-Eigenschaft der Schrift
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Setze die Kursiv-Eigenschaft der Schrift
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Setze die Unterstreichungs-Eigenschaft der Schrift
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Setze die Höhe der Schrift
    $port->getPortionFormat()->setFontHeight(25);
    # Setze die Farbe der Schrift
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Speichere die Präsentation auf dem Datenträger
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
