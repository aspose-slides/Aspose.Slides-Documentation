---
title: Schriften in Präsentationen mit JavaScript verwalten
linktitle: Schriften verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-fonts/
keywords:
- Schriften verwalten
- Schrifteigenschaften
- Absatz
- Textformatierung
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Steuern Sie Schriften mit Aspose.Slides für Node.js via Java: Betten Sie benutzerdefinierte Schriften ein, ersetzen Sie sie und laden Sie sie, um PPT-, PPTX- und ODP-Präsentationen klar und konsistent zu halten."
---

## **Schriftbezogene Eigenschaften verwalten**
{{% alert color="primary" %}} 

Präsentationen enthalten in der Regel sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung hilft den Benutzern, das Aussehen und das Gefühl des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Aspose.Slides für Node.js via Java verwendet wird, um die Schriftarteigenschaften von Absätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um die Schriftarteigenschaften eines Absatzes mit Aspose.Slides für Node.js via Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)-Klasse.
1. Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/)-Formen in der Folie zu und casten Sie sie zu [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Erhalten Sie das [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)-Objekt aus dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), das von [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) bereitgestellt wird.
1. Justieren Sie den Absatz.
1. Greifen Sie auf das Text-[Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)-Objekt eines [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)-Elements zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) und setzen Sie die **Font** der Text-[Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Setzen Sie die Schriftfarbe mit dem über das [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)-Objekt bereitgestellten [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/).
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte finden Sie unten. Sie nimmt eine unveränderte Präsentation und formatiert die Schriften auf einer der Folien. Die nachfolgenden Screenshots zeigen die Eingabedatei und wie die Code‑Snippets diese ändern. Der Code ändert die Schriftart, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Der gleiche Text mit aktualisierter Formatierung**|
```javascript
// Erstelle ein Presentation-Objekt, das eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Greift auf eine Folie über ihre Position zu
    var slide = pres.getSlides().get_Item(0);
    // Greift auf den ersten und zweiten Platzhalter in der Folie zu und castet ihn zu AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Greift auf den ersten Absatz zu
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Absatz im Blocksatz ausrichten
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Greift auf die erste Portion zu
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Definiere neue Schriftarten
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Ordnet neue Schriftarten der Portion zu
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Setzt die Schriftart auf Fett
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Setzt die Schriftart auf Kursiv
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Setzt die Schriftfarbe
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Textschriftart‑Eigenschaften festlegen**
{{% alert color="primary" %}} 

Wie im Abschnitt **Schriftbezogene Eigenschaften verwalten** beschrieben, wird ein [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie Aspose.Slides für Node.js via Java verwendet wird, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie weitere Eigenschaften der Schriftfamilie festzulegen.

{{% /alert %}} 

Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)-Klasse.
1. Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)-Objekt vom Typ **Rectangle** hinzu.
1. Entfernen Sie den Füllstil, der dem [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) zugeordnet ist.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) etwas Text hinzu.
1. Greifen Sie auf das [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)-Objekt zu, das dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) zugeordnet ist.
1. Definieren Sie die für das [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)-Objekt zu verwendende Schriftart.
1. Setzen Sie weitere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe über die entsprechenden Eigenschaften des [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)-Objekts.
1. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte finden Sie unten.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides für Node.js via Java gesetzten Schriftarteigenschaften**|
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // Ein AutoShape vom Typ Rectangle hinzufügen
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Entfernen Sie jeglichen Fill-Style, der dem AutoShape zugeordnet ist
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Greifen Sie auf das TextFrame zu, das dem AutoShape zugeordnet ist
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Greifen Sie auf die Portion zu, die dem TextFrame zugeordnet ist
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Setzen Sie die Schriftart für die Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Setzen Sie die Bold‑Eigenschaft der Schrift
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Setzen Sie die Italic‑Eigenschaft der Schrift
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Setzen Sie die Unterstreichungs‑Eigenschaft der Schrift
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Setzen Sie die Höhe der Schrift
    port.getPortionFormat().setFontHeight(25);
    // Setzen Sie die Farbe der Schrift
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Speichern Sie die Präsentation auf dem Datenträger
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
