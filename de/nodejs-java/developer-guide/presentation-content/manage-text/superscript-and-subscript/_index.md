---
title: Hoch- und Tiefgestellt
type: docs
weight: 80
url: /de/nodejs-java/superscript-and-subscript/
---

## **Verwalten von hoch- und tiefgestelltem Text**

Sie können hoch- und tiefgestellten Text in jedem Absatzabschnitt hinzufügen. Um hoch- oder tiefgestellten Text in einem Aspose.Slides‑Textrahmen hinzuzufügen, muss die Methode [**setEscapement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) der Klasse [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat) verwendet werden.

Diese Eigenschaft gibt den hoch- oder tiefgestellten Text zurück oder legt ihn fest (Wert von -100 % (tiefgestellt) bis 100 % (hochgestellt)). Beispiel:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Erhalten Sie die Referenz einer Folie über deren Index.
- Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) des Typs [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) hinzu.
- Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) zu, das mit dem [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) verknüpft ist.
- Löschen Sie vorhandene Paragraphs
- Erstellen Sie ein neues Absatzobjekt zum Halten von hochgestelltem Text und fügen Sie es der [Paragraphs collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getParagraphs--) des [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) hinzu.
- Erstellen Sie ein neues Portion‑Objekt
- Setzen Sie die Escapement‑Eigenschaft für die Portion zwischen 0 und 100, um hochgestellten Text hinzuzufügen. (0 bedeutet kein Hochstellen)
- Legen Sie etwas Text für [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) fest und fügen Sie ihn dann der Portion‑Sammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt zum Halten von tiefgestelltem Text und fügen Sie es der IParagraphs‑Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portion‑Objekt
- Setzen Sie die Escapement‑Eigenschaft für die Portion zwischen 0 und -100, um tiefgestellten Text hinzuzufügen. (0 bedeutet kein Tiefstellen)
- Legen Sie etwas Text für [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) fest und fügen Sie ihn dann der Portion‑Sammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten dargestellt.
```javascript
// Instanziieren Sie eine Presentation-Klasse, die eine PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // Textfeld erstellen
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Absatz für hochgestellten Text erstellen
    var superPar = new aspose.slides.Paragraph();
    // Portion mit normalem Text erstellen
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Portion mit hochgestelltem Text erstellen
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Absatz für tiefgestellten Text erstellen
    var paragraph2 = new aspose.slides.Paragraph();
    // Portion mit normalem Text erstellen
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Portion mit tiefgestelltem Text erstellen
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Absätze zum Textfeld hinzufügen
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wird hoch- und tiefgestellter Text beim Exportieren in PDF oder andere Formate beibehalten?**

Ja, Aspose.Slides behält die hoch- und tiefgestellte Formatierung beim Exportieren von Präsentationen nach PDF, PPT/PPTX, Bildern und anderen unterstützten Formaten korrekt bei. Die spezialisierte Formatierung bleibt in allen Ausgabedateien erhalten.

**Kann hoch- und tiefgestellter Text mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb einer einzigen Portion. Sie können Fett, Kursiv, Unterstreichen aktivieren und gleichzeitig hoch- oder tiefgestellten Text anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) konfigurieren.

**Funktionieren hoch- und tiefgestellte Formatierungen für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen und Diagrammelementen. Bei der Arbeit mit SmartArt müssen Sie auf die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/)) und deren Textcontainer zugreifen und dann die [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/)‑Eigenschaften in ähnlicher Weise konfigurieren.