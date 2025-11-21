---
title: Autofit-Einstellungen verwalten
type: docs
weight: 30
url: /de/nodejs-java/manage-autofit-settings/
keywords: "Textfeld, Autofit, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Legen Sie die Autofit-Einstellungen für Textfelder in PowerPoint in JavaScript fest"
---

Standardmäßig verwendet Microsoft PowerPoint, wenn Sie ein Textfeld hinzufügen, die Einstellung **Resize shape to fix text** für das Textfeld – es passt die Größe des Textfelds automatisch an, damit der Text immer hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – erhöht die Höhe – um mehr Text aufnehmen zu können. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, reduziert PowerPoint das Textfeld automatisch – verringert die Höhe – um überflüssigen Platz zu entfernen. 

In PowerPoint sind dies die 4 wichtigen Parameter oder Optionen, die das Autofit‑Verhalten für ein Textfeld steuern: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java bietet ähnliche Optionen – einige Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) – die es Ihnen ermöglichen, das Autofit‑Verhalten für Textfelder in Präsentationen zu steuern.

## **Resize Shape to Fit Text**

Wenn Sie möchten, dass der Text in einem Feld immer in dieses Feld passt, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Resize shape to fix text** verwenden. Um diese Einstellung festzulegen, rufen Sie die Methode [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) der Klasse [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) mit dem Wert `Shape` auf.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser JavaScript‑Code zeigt, wie Sie festlegen, dass ein Text immer in sein Feld in einer PowerPoint‑Präsentation passt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Wenn der Text länger oder größer wird, wird das Textfeld automatisch vergrößert (Höhe erhöht), sodass der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil. 

## **Do Not Autofit**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Abmessungen beibehält, unabhängig von Änderungen des enthaltenen Textes, müssen Sie die Option **Do not Autofit** verwenden. Um diese Einstellung festzulegen, rufen Sie die Methode [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) der Klasse [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) mit dem Wert `None` auf.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser JavaScript‑Code zeigt, wie Sie festlegen, dass ein Textfeld immer seine Abmessungen in einer PowerPoint‑Präsentation beibehält:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Wird der Text zu lang für sein Feld, fließt er heraus. 

## **Shrink Text on Overflow**

Wenn ein Text zu lang für sein Feld wird, können Sie mit der Option **Shrink text on overflow** festlegen, dass Größe und Abstand des Textes reduziert werden, um in das Feld zu passen. Um diese Einstellung festzulegen, rufen Sie die Methode [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) der Klasse [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) mit dem Wert `Normal` auf.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser JavaScript‑Code zeigt, wie Sie festlegen, dass ein Text bei Überlauf verkleinert wird in einer PowerPoint‑Präsentation:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}

Wenn die Option **Shrink text on overflow** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 

{{% /alert %}}

## **Wrap Text**

Wenn Sie möchten, dass der Text in einer Form umbrochen wird, sobald er die Breite der Form überschreitet, verwenden Sie den Parameter **Wrap text in shape**. Um diese Einstellung festzulegen, rufen Sie die Methode [setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) der Klasse [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) mit dem Wert `true` auf.

Dieser JavaScript‑Code zeigt, wie Sie die Einstellung Wrap Text in einer PowerPoint‑Präsentation verwenden:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

Rufen Sie die Methode `setWrapText` mit dem Wert `False` für eine Form auf, wird der Text, wenn er länger als die Formbreite wird, über die Formgrenzen hinaus in einer einzigen Zeile erweitert. 

{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textfelds das AutoFit?**

Ja. Padding (interne Ränder) verringert den nutzbaren Textbereich, sodass AutoFit früher greift – die Schrift wird früher verkleinert oder die Form früher angepasst. Prüfen und passen Sie die Ränder an, bevor Sie AutoFit optimieren.

**Wie interagiert AutoFit mit manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt die Schriftgröße und den Abstand rund um diese an. Das Entfernen unnötiger Umbrüche reduziert oft, wie stark AutoFit den Text verkleinern muss.

**Wirkt sich das Ändern der Design‑Schriftart oder das Auslösen einer Schriftart‑Ersetzung auf das AutoFit‑Ergebnis aus?**

Ja. Das Ersetzen durch eine Schriftart mit anderen Glyph‑Metriken ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und Zeilenumbrüche verändern kann. Nach jeder Schriftart‑Änderung oder -Ersetzung prüfen Sie die Folien erneut.