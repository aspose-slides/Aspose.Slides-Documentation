---
title: Shape Effektive Eigenschaften
type: docs
weight: 50
url: /de/nodejs-java/shape-effective-properties/
---

In diesem Thema besprechen wir **effektive** und **lokale** Eigenschaften. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Abschnittseigenschaften auf der Folie des Abschnitts;
1. In Prototyp‑Form‑Textstil auf Layout‑ oder Masterfolie (wenn das Textfeld des Abschnitts einen hat);
1. In den globalen Texteinstellungen der Präsentation;

werden diese Werte **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Aber wenn eine Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte erhalten, indem Sie die **getEffective()**‑Methode des lokalen Formats verwenden.

Dieser Beispielcode zeigt, wie Sie effektive Werte erhalten:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    var effectiveTextFrameFormat = localTextFrameFormat.getEffective();
    var localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    var effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effektive Eigenschaften der Kamera abrufen**
Aspose.Slides for Node.js via Java ermöglicht Entwicklern, effektive Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde die Klasse [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) zu Aspose.Slides hinzugefügt. Die Klasse [CameraEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz der [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData)‑Klasse wird als Teil der [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData)‑Klasse verwendet, die ein [effektiver Werte](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--)‑Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) darstellt.

Dieser Beispielcode zeigt, wie Sie effektive Eigenschaften für die Kamera erhalten:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective camera properties =");
    console.log("Type: " + threeDEffectiveData.getCamera().getCameraType());
    console.log("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    console.log("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effektive Eigenschaften des Light Rig abrufen**
Aspose.Slides for Node.js via Java ermöglicht Entwicklern, effektive Eigenschaften des Light Rig abzurufen. Zu diesem Zweck wurde die Klasse [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) zu Aspose.Slides hinzugefügt. Die [LightRigEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData)‑Klasse stellt ein unveränderliches Objekt dar, das effektive Light‑Rig‑Eigenschaften enthält. Eine Instanz der [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData)‑Klasse wird als Teil der [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData)‑Klasse verwendet, die ein [effektiver Werte](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--)‑Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) darstellt.

Dieser Beispielcode zeigt, wie Sie effektive Eigenschaften des Light Rig erhalten:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective light rig properties =");
    console.log("Type: " + threeDEffectiveData.getLightRig().getLightType());
    console.log("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effektive Eigenschaften der Bevel Shape abrufen**
Aspose.Slides for Node.js via Java ermöglicht Entwicklern, effektive Eigenschaften der Bevel Shape abzurufen. Zu diesem Zweck wurde die [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData)‑Klasse zu Aspose.Slides hinzugefügt. Die [ShapeBevelEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData)‑Klasse stellt ein unveränderliches Objekt dar, das effektive Relief‑Eigenschaften der Shape‑Fläche enthält. Eine Instanz der [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData)‑Klasse wird als Teil der [**ThreeDFormatEffectiveData**]([**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData))‑Klasse verwendet, die ein [effektiver Werte](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--)‑Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) darstellt.

Dieser Beispielcode zeigt, wie Sie effektive Eigenschaften für die Bevel Shape erhalten:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    console.log("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    console.log("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effektive Eigenschaften eines Textfelds abrufen**
Mit Aspose.Slides for Node.js via Java können Sie effektive Eigenschaften eines Textfelds abrufen. Zu diesem Zweck wurde die Klasse [**TextFrameFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormatEffectiveData) zu Aspose.Slides hinzugefügt. Sie enthält effektive Formatierungseigenschaften für Textfelder.

Dieser Beispielcode zeigt, wie Sie effektive Textfeld‑Formatierungseigenschaften erhalten:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();
    console.log("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    console.log("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    console.log("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    console.log("Margins");
    console.log("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    console.log("   Top: " + effectiveTextFrameFormat.getMarginTop());
    console.log("   Right: " + effectiveTextFrameFormat.getMarginRight());
    console.log("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effektive Eigenschaften eines Textstils abrufen**
Mit Aspose.Slides for Node.js via Java können Sie effektive Eigenschaften eines Textstils abrufen. Zu diesem Zweck wurde die [**TextStyleEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextStyleEffectiveData)‑Klasse zu Aspose.Slides hinzugefügt. Sie enthält effektive Textstileigenschaften.

Dieser Beispielcode zeigt, wie Sie effektive Textstileigenschaften erhalten:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    for (var i = 0; i <= 8; i++) {
        var effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        console.log(("= Effective paragraph formatting for style level #" + i) + " =");
        console.log("Depth: " + effectiveStyleLevel.getDepth());
        console.log("Indent: " + effectiveStyleLevel.getIndent());
        console.log("Alignment: " + effectiveStyleLevel.getAlignment());
        console.log("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effektiven Schriftgrößenwert abrufen**
Mit Aspose.Slides for Node.js via Java können Sie effektive Eigenschaften der Schriftgröße abrufen. Hier stellen wir einen Code bereit, der zeigt, wie sich der effektive Schriftgrößenwert eines Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();
    var portion0 = new aspose.slides.Portion("Sample text with first portion");
    var portion1 = new aspose.slides.Portion(" and second portion.");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    console.log("Effective font height after setting entire presentation default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.save("SetLocalFontHeightValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effektives Füllformat für Tabellen abrufen**
Mit Aspose.Slides for Node.js via Java können Sie effektive Füllformatierung für verschiedene logische Teile einer Tabelle abrufen. Zu diesem Zweck wurde die [**CellFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellFormatEffectiveData)‑Klasse in Aspose.Slides hinzugefügt. Sie enthält effektive Füllformatierungseigenschaften. Bitte beachten Sie: Zellformatierung hat immer Vorrang vor Zeilenformatierung; Zeilenformatierung hat Vorrang vor Spaltenformatierung; und Spaltenformatierung hat Vorrang vor der gesamten Tabelle.
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var tableFormatEffective = tbl.getTableFormat().getEffective();
    var rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    var columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    var cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();
    var tableFillFormatEffective = tableFormatEffective.getFillFormat();
    var rowFillFormatEffective = rowFormatEffective.getFillFormat();
    var columnFillFormatEffective = columnFormatEffective.getFillFormat();
    var cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wie kann ich erkennen, dass ich einen „Snapshot“ und kein „Live‑Objekt“ habe, und wann sollte ich effektive Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Schnappschüsse der zum Zeitpunkt des Aufrufs berechneten Werte. Wenn Sie lokale oder vererbte Einstellungen der Shape ändern, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern der Layout‑/Master‑Folien auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut ausgelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht automatisch – fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Änderungen nehmen Sie in den lokalen Formatierungsobjekten (Shape/Text/3D usw.) vor und holen dann bei Bedarf die effektiven Werte erneut.

**Was passiert, wenn eine Eigenschaft weder auf Shape‑Ebene, noch im Layout/Master und nicht in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standard‑Mechanismus (PowerPoint/Aspose.Slides‑Standardeinstellungen) bestimmt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich aus einem effektiven Schriftwert ableiten, auf welcher Ebene Größe oder Schriftart festgelegt wurde?**

Nicht direkt. EffectiveData liefert nur den endgültigen Wert. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Abschnitt/Absatz/Textfeld‑Ebene sowie die Textstile im Layout/Master/Präsentation, um die erste explizite Definition zu finden.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich final war (keine höhere Vererbung nötig). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Vererbung benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie Formatierungen auf einer bestimmten Ebene ändern wollen, bearbeiten Sie die lokalen Eigenschaften und lesen Sie bei Bedarf EffectiveData erneut, um das Ergebnis zu prüfen.