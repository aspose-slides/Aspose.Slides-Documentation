---
title: Automatisierung der Präsentationslokalisierung in Java
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/java/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Sprach-ID
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument-Folien in Java mit Aspose.Slides, und nutzen Sie praktische Code-Beispiele sowie Tipps für eine schnellere globale Einführung."
---

## **Sprache für Präsentation und Formtext ändern**
- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- [Language-ID festlegen](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) für den Text.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte wird im folgenden Beispiel gezeigt.
```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Löst die Language ID die automatische Textübersetzung aus?**

Nein. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, übersetzt jedoch den Text nicht und ändert ihn nicht. Es handelt sich um Metadaten, die PowerPoint für die Korrektur versteht.

**Beeinflusst die Language ID die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides dient die [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) der Rechtschreibprüfung. Die Qualität der Silbentrennung und der Zeilenumbruch hängen hauptsächlich von der Verfügbarkeit von [richtigen Schriften](/slides/de/java/powerpoint-fonts/) sowie von Layout‑/Zeilenumbruch‑Einstellungen des Schriftsystems ab. Stellen Sie sicher, dass die erforderlichen Schriften verfügbar sind, konfigurieren Sie [Schriftart‑Ersetzungsregeln](/slides/de/java/font-substitution/) und/oder betten Sie [Schriften ein](/slides/de/java/embedded-font/) in die Präsentation ein.

**Kann ich verschiedene Sprachen innerhalb eines einzelnen Absatzes festlegen?**

Ja. Die [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) wird auf Textebenen‑Portionen angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Korrektureinstellungen mischen kann.