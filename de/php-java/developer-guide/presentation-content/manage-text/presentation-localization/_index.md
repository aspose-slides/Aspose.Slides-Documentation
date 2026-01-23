---
title: Präsentationslokalisierung in PHP automatisieren
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/php-java/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Sprach-ID
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument-Folien mit Aspose.Slides für PHP über Java, anhand praktischer Codebeispiele und Tipps für eine schnellere globale Einführung."
---

## **Sprache für eine Präsentation ändern und Text formatieren**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vom Typ [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- [Set Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) für den Text festlegen.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird im folgenden Beispiel demonstriert.
```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Löst die Sprach‑ID eine automatische Textübersetzung aus?**

Nein. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, übersetzt aber nicht den Textinhalt und ändert ihn nicht. Es handelt sich um Metadaten, die PowerPoint für die Prüfung versteht.

**Beeinflusst die Sprach‑ID die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides ist die [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) für die Prüfung vorgesehen. Die Qualität der Silbentrennung und der Zeilenumbruch hängen hauptsächlich von der Verfügbarkeit [proper fonts](/slides/de/php-java/powerpoint-fonts/) sowie von Layout‑/Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Stellen Sie sicher, dass die erforderlichen Schriften verfügbar sind, konfigurieren Sie [font substitution rules](/slides/de/php-java/font-substitution/) und/oder betten Sie Schriften [embed fonts](/slides/de/php-java/embedded-font/) in die Präsentation ein, um ein korrektes Rendering zu gewährleisten.

**Kann ich innerhalb eines einzelnen Absatzes verschiedene Sprachen festlegen?**

Ja. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) wird auf Textebene angewendet, sodass ein einzelner Absatz mehrere Sprachen mit jeweils eigenen Prüf­einstellungen kombinieren kann.