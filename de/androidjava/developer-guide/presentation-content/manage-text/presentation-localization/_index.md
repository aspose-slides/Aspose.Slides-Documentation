---
title: Präsentationslokalisierung
type: docs
weight: 100
url: /androidjava/presentation-localization/
---

## **Sprache für Präsentation und Text der Form ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie der Folie eine [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) vom Typ [Rechteck](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- [Sprache ID festlegen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) für den Text.
- Schreiben Sie die Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte wird unten in einem Beispiel demonstriert.

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