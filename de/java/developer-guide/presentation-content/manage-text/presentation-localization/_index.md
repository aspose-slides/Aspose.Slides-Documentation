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
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument-Folien in Java mit Aspose.Slides, mithilfe praktischer Code-Beispiele und Tipps für eine schnellere globale Einführung."
---

## **Sprache für eine Präsentation und Shape‑Text ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- [Sprache ID festlegen](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) für den Text.
- Schreiben Sie die Präsentation als PPTX‑Datei.

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

**Löst die Sprach‑ID eine automatische Textübersetzung aus?**

Nein. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in Aspose.Slides speichert die Sprache für die Rechtschreib‑ und Grammatikprüfung, übersetzt den Text jedoch nicht und ändert ihn nicht. Es handelt sich um Metadaten, die PowerPoint für die Korrektur versteht.

**Beeinflusst die Sprach‑ID die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides dient die [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) der Korrektur. Die Qualität der Silbentrennung und der Zeilenumbruch hängen hauptsächlich von der Verfügbarkeit [proper fonts](/slides/de/java/powerpoint-fonts/) sowie von Layout‑ und Zeilenumbruch‑Einstellungen für das jeweilige Schriftsystem ab. Stellen Sie sicher, dass die erforderlichen Schriftarten verfügbar sind, konfigurieren Sie [font substitution rules](/slides/de/java/font-substitution/), und/oder betten Sie [embed fonts](/slides/de/java/embedded-font/) in die Präsentation ein, um ein korrektes Rendering zu gewährleisten.

**Kann ich in einem einzigen Absatz verschiedene Sprachen festlegen?**

Ja. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) wird auf Portionsebene angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Korrektureinstellungen mischen kann.