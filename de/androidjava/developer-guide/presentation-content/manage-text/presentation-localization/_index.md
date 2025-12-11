---
title: Automatisiere die Lokalisierung von Präsentationen unter Android
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/androidjava/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Sprach-ID
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument-Folien in Java mit Aspose.Slides für Android, indem Sie praktische Codebeispiele und Tipps für eine schnellere globale Einführung nutzen."
---

## **Sprache für eine Präsentation und Formen-Text ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
- Rufen Sie die Referenz einer Folie über ihren Index ab.
- Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- [Setting Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) für den Text festlegen.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte wird im Folgenden anhand eines Beispiels gezeigt.
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

**Löst die Language‑ID eine automatische Textübersetzung aus?**

Nein. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, aber sie übersetzt den Text nicht und ändert ihn nicht. Es handelt sich um Metadaten, die PowerPoint für die Korrektur versteht.

**Beeinflusst die Language‑ID die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides dient die [language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) der Korrektur. Die Qualität der Silbentrennung und der Zeilenumbruch hängen hauptsächlich von der Verfügbarkeit geeigneter [proper fonts](/slides/de/androidjava/powerpoint-fonts/) und den Layout‑/Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Stellen Sie sicher, dass die erforderlichen Schriften verfügbar sind, konfigurieren Sie die [font substitution rules](/slides/de/androidjava/font-substitution/), und/oder betten Sie [embed fonts](/slides/de/androidjava/embedded-font/) in die Präsentation ein.

**Kann ich verschiedene Sprachen innerhalb eines einzelnen Absatzes festlegen?**

Ja. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Korrektureinstellungen enthalten kann.