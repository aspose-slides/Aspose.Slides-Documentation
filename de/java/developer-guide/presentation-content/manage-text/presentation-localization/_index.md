---
title: Präsentationslokalisierung
type: docs
weight: 100
url: /java/presentation-localization/
---

## **Sprache für Präsentation und Text von Formen ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Holen Sie die Referenz zu einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- [Sprache-ID festlegen](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) für den Text.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird im Folgenden in einem Beispiel demonstriert.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text zur Anwendung der Rechtschreibprüfungssprache");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```