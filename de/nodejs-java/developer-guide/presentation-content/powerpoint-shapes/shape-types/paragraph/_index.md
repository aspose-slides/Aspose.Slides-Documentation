---
title: Absatz
type: docs
weight: 60
url: /de/nodejs-java/paragraph/
---

## **Paragraph- und Portion-Koordinaten in TextFrame erhalten**
Mit Aspose.Slides für Node.js über Java können Entwickler jetzt die rechteckigen Koordinaten für Paragraph innerhalb der Paragraphensammlung eines TextFrames erhalten. Es ermöglicht auch, die [Koordinaten einer Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) innerhalb der Portionensammlung eines Paragraphen abzurufen. In diesem Thema zeigen wir anhand eines Beispiels, wie man die rechteckigen Koordinaten für einen Paragraphen zusammen mit der Position einer Portion innerhalb eines Paragraphen ermittelt.
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **Rechteckige Koordinaten eines Paragraphen erhalten**
Mit der Methode [**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) können Entwickler das Begrenzungsrechteck des Paragraphen abrufen.
```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Größe von Paragraph und Portion in einem Tabellenzellen-TextFrame erhalten**

Um die Größe und die Koordinaten der [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) oder des [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) in einem Tabellenzellen-TextFrame zu erhalten, können Sie die Methoden [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--) und [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) verwenden.

Dieser Beispielcode demonstriert die beschriebene Operation:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**In welchen Einheiten werden die Koordinaten für einen Paragraphen und Textportionen zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst Wortumbruch die Begrenzungen eines Paragraphen?**

Ja. Wenn das [wrapping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) im [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) aktiviert ist, bricht der Text um, um die Breite des Bereichs zu passen, wodurch sich die tatsächlichen Begrenzungen des Paragraphen ändern.

**Können Paragraphenkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Punkte in Pixel umrechnen mit: pixels = points × (DPI / 72). Das Ergebnis hängt vom gewählten DPI für das Rendern/Exportieren ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/nodejs-java/shape-effective-properties/); sie gibt die endgültigen zusammengefassten Werte für Einzüge, Abstand, Umbruch, RTL und mehr zurück.