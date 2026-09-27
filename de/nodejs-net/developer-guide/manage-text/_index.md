---
title: Verwalten von Präsentationstext in Node.js via .NET
linktitle: Text verwalten
type: docs
weight: 50
url: /de/nodejs-net/manage-text/
keywords:
- Text
- Textfeld
- Text hinzufügen
- Text ändern
- Text formatieren
- Schriftgröße
- Fetter Text
- Textrahmen
- Absatz
- Abschnitt
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Fügen Sie einer Folie ein Textfeld hinzu und ändern Sie anschließend dessen Text, Schriftgröße und Fettdruck in JavaScript mit Aspose.Slides für Node.js via .NET."
---
## **Übersicht**

Im Aspose.Slides gehört der Text auf einer Folie zu einer Form. Eine Autoform, z. B. ein Rechteck, verfügt über ein Textfeld; das Textfeld enthält Absätze, und jeder Absatz enthält Abschnitte, die Textabschnitte mit derselben Formatierung sind. Sie ändern den Text über das Textfeld und die Schriftart über das Format eines Abschnitts.

Dieser Artikel fügt einer Folie ein Textfeld hinzu und speichert die Präsentation. Anschließend öffnet er die gespeicherte Datei und ändert den Text, die Schriftgröße und den Fettdruck des Textfelds.

Die Beispiele benötigen ein Projekt, das wie in [Installation](/slides/de/nodejs-net/installation/) beschrieben eingerichtet ist. Speichern Sie jedes Beispiel als `.js`‑Datei im Projektordner und führen Sie es aus diesem Ordner mit `node` aus.

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides für Node.js via .NET hat keine eigene API‑Referenz. Sie spiegelt die Aspose.Slides‑API für .NET mit camelCase‑Namen wider, sodass die API‑Links in diesem Artikel zu den entsprechenden Klassen und Mitgliedern in der [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) führen.
{{% /alert %}}

## **Textfeld hinzufügen**

Um ein Textfeld hinzuzufügen, fügen Sie einer Folie mit der Methode [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) eine Autoform hinzu und geben ihr mit der Methode [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/) Text. Das folgende Beispiel fügt ein Rechteck zur ersten Folie einer neuen Präsentation hinzu und speichert die Präsentation als `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Die Position (x, y) und die Größe (Breite, Höhe) sind in Punkten.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

Die Folie in `text-box.pptx` enthält ein Rechteck, 500 Punkte breit und 80 Punkte hoch, mit dem Text „Quarterly report“ in der Standardschriftart und -größe. Das nächste Beispiel ändert dieses Textfeld.

## **Text und dessen Formatierung ändern**

Das folgende Beispiel öffnet `text-box.pptx`, das im vorherigen Beispiel erstellt wurde, und holt die erste Form auf der ersten Folie. Formen wie Bilder und Tabellen besitzen kein Textfeld, daher prüft das Beispiel, ob die Form eine [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) ist, bevor es das [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) der Form verwendet. Anschließend führt es Folgendes aus:

1. Es ersetzt den Text über die Eigenschaft [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) des Textfelds. Danach enthält das Textfeld einen Absatz mit einem Abschnitt.  
2. Es holt diesen Abschnitt aus den Sammlungen [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) und [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) und liest dessen [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/).  
3. Es setzt [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/), die Schriftgröße in Punkten, und [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/), das einen [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)‑Wert annimmt.

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

In `text-box-updated.pptx` zeigt das Textfeld „Quarterly report: third quarter“ in fettem 32‑Punkte‑Schrifttyp. Da der neue Text ein einzelner Abschnitt ist, gelten die beiden Formatierungseigenschaften auf den gesamten Text. Ohne Lizenz fügt jeder Speichervorgang ein Evaluationswasserzeichen hinzu. Da `text-box.pptx` bereits im Evaluationsmodus gespeichert wurde, enthält `text-box-updated.pptx` zwei; siehe [Evaluate Aspose.Slides](/slides/de/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Warum nimmt `fontBold` einen `NullableBool`‑Wert anstelle von `true` oder `false`?**

Ein Abschnitt kann eine Eigenschaft undefiniert lassen und sie vom Absatz, der Form oder dem Folienlayout bzw. -master erben. `NullableBool.NotDefined` bedeutet „erben“, während `NullableBool.True` und `NullableBool.False` den geerbten Wert überschreiben. Das Zuweisen von `true` oder `false` löst einen Fehler aus. Aus demselben Grund gibt `fontHeight` `NaN` zurück, wenn der Abschnitt seine Schriftgröße erbt.

**Wie ändere ich die Textfarbe?**

Setzen Sie die Füllung des Abschnittsformats: Weisen Sie `FillType.Solid` `portionFormat.fillFormat.fillType` zu und anschließend eine Farbe wie `"#FF0000"` `portionFormat.fillFormat.solidFillColor.color`. Fügen Sie `FillType` zu den Namen hinzu, die Sie aus dem Paket importieren.

**Wie formatiere ich nur einen Teil des Textes?**

Die Formatierung gehört zu Abschnitten, daher sollten Sie diesen Textteil in einen eigenen Abschnitt einfügen. Erstellen Sie den Abschnitt mit `Portion.CreatePortionFromText`, hängen Sie ihn mit der `add`‑Methode der `portions`‑Sammlung eines Absatzes an und setzen Sie anschließend das `portionFormat` des neuen Abschnitts. Fügen Sie `Portion` zu den Namen hinzu, die Sie aus dem Paket importieren.

**Warum gibt das Lesen von Text "... text has been truncated due to evaluation version limitation" zurück?**

Ohne Lizenz gibt Aspose.Slides nur die ersten fünf Zeichen eines längeren Textes zurück, den Sie lesen, z. B. `textFrame.text`, gefolgt von diesem Hinweis. Der von Ihnen geschriebene Text wird vollständig gespeichert. Wenden Sie eine Lizenz an, wie in [Licensing](/slides/de/nodejs-net/licensing/) beschrieben, um den vollständigen Text zu lesen.