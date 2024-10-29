---
title: Präsentation Lokalisierung
type: docs
weight: 100
url: /de/php-java/presentation-localization/
---

## **Sprache für Präsentations- und Formulartext ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz zu einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie einige Texte zum TextFrame hinzu.
- [Spracheinstellung](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) für den Text festlegen.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Umsetzung der obigen Schritte wird im Folgenden anhand eines Beispiels demonstriert.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text zur Anwendung der Rechtschreibsprache");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```