---
title: Hoch- und Tiefschrift
type: docs
weight: 80
url: /de/php-java/superscript-and-subscript/
---

## **Hoch- und Tiefschrifttext verwalten**
Sie können Hoch- und Tiefschrifttext in jeden Absatz einfügen. Um Hoch- oder Tiefschrifttext im Textfeld von Aspose.Slides hinzuzufügen, muss die Methode [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) der Klasse [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat) verwendet werden.

Diese Eigenschaft gibt den Hoch- oder Tiefschrifttext zurück oder setzt ihn (Wert von -100 % (Tiefschrift) bis 100 % (Hochschrift). Zum Beispiel:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) hinzu.
- Greifen Sie auf das mit der [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) verbundene [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) zu.
- Löschen Sie vorhandene Absätze.
- Erstellen Sie ein neues Absatzobjekt zum Halten von Hochschrifttext und fügen Sie es zur [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) des [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) hinzu.
- Erstellen Sie ein neues Portion-Objekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und 100, um Hochschrift hinzuzufügen. (0 bedeutet keine Hochschrift).
- Setzen Sie einen Text für die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) und fügen Sie ihn dann der Portionensammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt zum Halten von Tiefschrifttext und fügen Sie es zur IParagraphs-Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portion-Objekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und -100, um Tiefschrift hinzuzufügen. (0 bedeutet keine Tiefschrift).
- Setzen Sie einen Text für die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) und fügen Sie ihn dann der Portionensammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist wie folgt.

```php
  # Instanziieren Sie eine Presentation-Klasse, die ein PPTX darstellt
  $pres = new Presentation();
  try {
    # Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Textfeld erstellen
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Absatz für Hochschrifttext erstellen
    $superPar = new Paragraph();
    # Portion mit normalem Text erstellen
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Portion mit Hochschrifttext erstellen
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Absatz für Tiefschrifttext erstellen
    $paragraph2 = new Paragraph();
    # Portion mit normalem Text erstellen
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Portion mit Tiefschrifttext erstellen
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Absätze zum Textfeld hinzufügen
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```