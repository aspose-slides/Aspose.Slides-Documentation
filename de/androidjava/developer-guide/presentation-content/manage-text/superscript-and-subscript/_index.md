---
title: Hoch- und Tiefgestellt
type: docs
weight: 80
url: /androidjava/superscript-and-subscript/
---

## **Hochgestellten und tiefgestellten Text verwalten**
Sie können hochgestellten und tiefgestellten Text in jeden Absatz einfügen. Um hochgestellten oder tiefgestellten Text im Aspose.Slides-Textformat hinzuzufügen, muss man die [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) Methode der [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat) Klasse verwenden.

Diese Eigenschaft gibt den hochgestellten oder tiefgestellten Text zurück oder setzt ihn (Wert von -100% (tiefgestellt) bis 100% (hochgestellt). Zum Beispiel:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) des Typs [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) zur Folie hinzu.
- Greifen Sie auf den [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) zu, der mit der [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) verbunden ist.
- Löschen Sie die vorhandenen Absätze.
- Erstellen Sie ein neues Absatzobjekt zum Halten hochgestellten Textes und fügen Sie es der [IParagraphs-Sammlung](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) des [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) hinzu.
- Erstellen Sie ein neues Portion-Objekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und 100, um hochgestellten Text hinzuzufügen. (0 bedeutet kein hochgestellter Text)
- Setzen Sie etwas Text für [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) und fügen Sie es dann der Portion-Sammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt zum Halten des tiefgestellten Textes und fügen Sie es der IParagraphs-Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portion-Objekt.
- Setzen Sie die Escapement-Eigenschaft für die Portion zwischen 0 und -100, um tiefgestellten Text hinzuzufügen. (0 bedeutet kein tiefgestellter Text)
- Setzen Sie etwas Text für [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) und fügen Sie es dann der Portion-Sammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist unten angegeben.

```java
// Instanz einer Presentation-Klasse erstellen, die ein PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);

    // Textfeld erstellen
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Absatz für hochgestellten Text erstellen
    IParagraph superPar = new Paragraph();

    // Portion mit normalem Text erstellen
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Portion mit hochgestelltem Text erstellen
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Absatz für tiefgestellten Text erstellen
    IParagraph paragraph2 = new Paragraph();

    // Portion mit normalem Text erstellen
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Portion mit tiefgestelltem Text erstellen
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Absätze zum Textfeld hinzufügen
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```