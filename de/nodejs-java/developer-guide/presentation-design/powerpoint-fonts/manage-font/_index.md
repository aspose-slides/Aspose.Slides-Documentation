---
title: Schriftarten in Präsentationen mit JavaScript verwalten
linktitle: Schriftarten verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-fonts/
keywords:
- Schriftarten verwalten
- Schriftarteigenschaften
- Absatz
- Textformatierung
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Steuern Sie Schriftarten mit Aspose.Slides für Node.js über Java: Betten Sie Schriftarten ein, ersetzen Sie sie und laden Sie benutzerdefinierte Schriftarten, um PPT-, PPTX- und ODP-Präsentationen klar und konsistent zu halten."
---

## **Verwalten von Schriftbezogenen Eigenschaften**
{{% alert color="primary" %}} 

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung hilft Benutzern, das Aussehen und das Gefühl des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für Node.js über Java verwendet, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren.

{{% /alert %}} 

Um Schriftarteigenschaften eines Absatzes mithilfe von Aspose.Slides für Node.js über Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Placeholder)‑Formen in der Folie zu und wandeln Sie sie in [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) um.
1. Holen Sie das [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph) aus dem von [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) bereitgestellten [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame).
1. Richten Sie den Absatz aus.
1. Greifen Sie auf den Text [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) eines [Paragraph] zu.
1. Definieren Sie die Schriftart mit [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FontData) und setzen Sie die **Font** des Textes [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) entsprechend.
   1. Setzen Sie die Schriftart auf Fett.
   1. Setzen Sie die Schriftart auf Kursiv.
1. Setzen Sie die Schriftfarbe mit dem von dem [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion)‑Objekt bereitgestellten [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FillFormat).
1. Speichern Sie die modifizierte Präsentation in einer PPTX-Datei.

Die Implementierung der obigen Schritte ist unten dargestellt. Sie nimmt eine nicht formatierte Präsentation und formatiert die Schriftarten auf einer der Folien. Die nachfolgenden Screenshots zeigen die Eingabedatei und wie die Code‑Snippets sie ändern. Der Code ändert die Schriftart, die Farbe und den Schriftstil.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Abbildung: Der Text in der Eingabedatei**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Abbildung: Der gleiche Text mit aktualisierter Formatierung**|
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Zugriff auf eine Folie über ihre Position
    var slide = pres.getSlides().get_Item(0);
    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Zugriff auf den ersten Absatz
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Absatz ausrichten (Blocksatz)
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Zugriff auf den ersten Teil
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Neue Schriftarten definieren
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Neue Schriftarten dem Teil zuweisen
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Schriftart auf Fett setzen
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Schriftart auf Kursiv setzen
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Schriftfarbe festlegen
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // PPTX auf Festplatte speichern
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Text-Schriftarten-Eigenschaften festlegen**
{{% alert color="primary" %}} 

Wie in **Verwalten von Schriftbezogenen Eigenschaften** erwähnt, wird ein [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides für Node.js über Java verwendet, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene weitere Eigenschaften der Schriftfamilie festzulegen.

{{% /alert %}} 

Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) vom Typ **Rectangle** hinzu.
1. Entfernen Sie den mit dem [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) verbundenen Füllstil.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) des [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) zu.
1. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) etwas Text hinzu.
1. Greifen Sie auf das mit dem [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) verbundene [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion)-Objekt zu.
1. Definieren Sie die für das [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) zu verwendende Schriftart.
1. Setzen Sie andere Schriftarteigenschaften wie Fett, Kursiv, Unterstreichen, Farbe und Höhe mithilfe der entsprechenden Eigenschaften, die das [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion)-Objekt bereitstellt.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist unten dargestellt.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Abbildung: Text mit einigen von Aspose.Slides für Node.js über Java festgelegten Schriftarteigenschaften**|
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // AutoShape vom Typ Rechteck hinzufügen
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Jeglichen mit dem AutoShape verbundenen Füllstil entfernen
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Auf das mit dem AutoShape verbundene TextFrame zugreifen
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Auf den mit dem TextFrame verbundenen Portion zugreifen
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Schriftart für den Portion festlegen
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Fett-Eigenschaft der Schriftart festlegen
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Kursiv-Eigenschaft der Schriftart festlegen
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Unterstreichungs-Eigenschaft der Schriftart festlegen
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Höhe der Schriftart festlegen
    port.getPortionFormat().setFontHeight(25);
    // Farbe der Schriftart festlegen
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Präsentation auf Festplatte speichern
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
