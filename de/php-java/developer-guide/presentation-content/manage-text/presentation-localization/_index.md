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
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument-Folien mit Aspose.Slides für PHP über Java, mithilfe praktischer Codebeispiele und Tipps für eine schnellere globale Einführung."
---

## **Sprache für eine Präsentation und Formtext ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Holen Sie die Referenz einer Folie mittels ihres Index.
- Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie dem TextFrame Text hinzu.
- [Sprach‑ID festlegen](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) für den Text.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der genannten Schritte wird im folgenden Beispiel gezeigt.
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

**Wird durch die Sprach‑ID eine automatische Textübersetzung ausgelöst?**

Nein. Die [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) in Aspose.Slides speichert die Sprache für die Rechtschreib‑ und Grammatikprüfung, übersetzt jedoch nicht den Textinhalt. Es handelt sich um Metadaten, die PowerPoint für die Korrektur versteht.

**Beeinflusst die Sprach‑ID die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides dient die [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) der Korrektur. Die Qualität der Silbentrennung und des Zeilenumbruchs hängt hauptsächlich von der Verfügbarkeit geeigneter [proper fonts](/slides/de/php-java/powerpoint-fonts/) und den Layout‑/Zeilenumbruch‑Einstellungen des Schriftsystems ab. Stellen Sie sicher, dass die erforderlichen Schriften verfügbar sind, konfigurieren Sie [font substitution rules](/slides/de/php-java/font-substitution/), und/oder betten Sie [embed fonts](/slides/de/php-java/embedded-font/) in die Präsentation ein.

**Kann ich innerhalb eines einzelnen Absatzes verschiedene Sprachen festlegen?**

Ja. Die [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Korrektureinstellungen mischen kann.