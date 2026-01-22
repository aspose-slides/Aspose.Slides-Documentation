---
title: Abrufen von Shape-Effekteigenschaften aus Präsentationen in JavaScript
linktitle: Effekteigenschaften
type: docs
weight: 50
url: /de/nodejs-java/shape-effective-properties/
keywords:
- Shape-Eigenschaften
- Kameraeigenschaften
- Lichtanlage
- Schräge Form
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Node.js via Java effektive Shape-Eigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---

In diesem Thema werden wir **effektive** und **lokale** Eigenschaften besprechen. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Abschnittseigenschaften auf der Folie des Abschnitts;
1. Im Textstil der Prototyp-Form auf Layout‑ oder Master‑Folie (falls die Textfeld‑Form des Abschnitts einen hat);
1. In den globalen Texteinstellungen der Präsentation;

diese Werte werden **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn jedoch eine Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte erhalten, indem Sie die **getEffective()**‑Methode des lokalen Formats verwenden.

Dieses Beispielcode zeigt, wie man effektive Werte erhält:
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


## **Erhalten von effektiven Eigenschaften der Kamera**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern, effektive Eigenschaften der Kamera zu erhalten. Zu diesem Zweck wurde die Klasse **CameraEffectiveData** zu Aspose.Slides hinzugefügt. Die Klasse **CameraEffectiveData** stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz der Klasse **CameraEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--)‑Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) darstellt.

Dieses Beispielcode‑Beispiel zeigt, wie man effektive Eigenschaften für die Kamera erhält:
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


## **Erhalten von effektiven Eigenschaften der Lichtanlage**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern, effektive Eigenschaften der Lichtanlage zu erhalten. Zu diesem Zweck wurde die Klasse **LightRigEffectiveData** zu Aspose.Slides hinzugefügt. Die Klasse **LightRigEffectiveData** stellt ein unveränderliches Objekt dar, das effektive Eigenschaften der Lichtanlage enthält. Eine Instanz der Klasse **LightRigEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--)‑Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) darstellt.

Dieses Beispielcode‑Beispiel zeigt, wie man effektive Eigenschaften der Lichtanlage erhält:
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


## **Erhalten von effektiven Eigenschaften der Schräge Form**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern, effektive Eigenschaften der Schräge Form zu erhalten. Zu diesem Zweck wurde die Klasse **ShapeBevelEffectiveData** zu Aspose.Slides hinzugefügt. Die Klasse **ShapeBevelEffectiveData** stellt ein unveränderliches Objekt dar, das effektive Reliefeigenschaften der Form enthält. Eine Instanz der Klasse **ShapeBevelEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--)‑Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) darstellt.

Dieses Beispielcode‑Beispiel zeigt, wie man effektive Eigenschaften für die Schräge Form erhält:
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


## **Erhalten von effektiven Eigenschaften eines Textfelds**
Mit Aspose.Slides für Node.js via Java können Sie effektive Eigenschaften eines Textfelds erhalten. Zu diesem Zweck wurde die Klasse **TextFrameFormatEffectiveData** zu Aspose.Slides hinzugefügt. Sie enthält effektive Formatierungseigenschaften des Textfelds.

Dieses Beispielcode zeigt, wie man effektive Formatierungseigenschaften des Textfelds erhält:
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


## **Erhalten von effektiven Eigenschaften eines Textstils**
Mit Aspose.Slides für Node.js via Java können Sie effektive Eigenschaften eines Textstils erhalten. Zu diesem Zweck wurde die Klasse **TextStyleEffectiveData** zu Aspose.Slides hinzugefügt. Sie enthält effektive Textstileigenschaften.

Dieses Beispielcode‑Beispiel zeigt, wie man effektive Textstileigenschaften erhält:
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


## **Erhalten des effektiven Schriftgrößenwerts**
Mit Aspose.Slides für Node.js via Java können Sie effektive Eigenschaften der Schriftgröße erhalten. Hier stellen wir einen Code bereit, der zeigt, wie sich der effektive Schriftgrößenwert eines Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden:
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


## **Erhalten eines effektiven Füllformats für Tabellen**
Mit Aspose.Slides für Node.js via Java können Sie das effektive Füllformat für verschiedene logische Teile einer Tabelle erhalten. Zu diesem Zweck wurde die Klasse **CellFormatEffectiveData** zu Aspose.Slides hinzugefügt. Sie enthält effektive Füllformat-Eigenschaften. Bitte beachten Sie: Zellformat hat immer Vorrang vor Zeilenformat; Zeilenformat hat Vorrang vor Spaltenformat; und Spaltenformat hat Vorrang vor dem Gesamttableau.
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

**Wie kann ich feststellen, dass ich einen „Snapshot“ und kein „Live‑Objekt“ erhalten habe, und wann sollte ich effektive Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Schnappschüsse der berechneten Werte zum Zeitpunkt des Aufrufs. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern der Layout‑/Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut ausgelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Nehmen Sie Änderungen in den lokalen Formatierungsobjekten (Form/Text/3D usw.) vor und holen Sie anschließend die effektiven Werte erneut.

**Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout‑/Master‑Folie oder in den globalen Einstellungen festgelegt ist?**

Der effektive Wert wird durch den Standardmechanismus (PowerPoint‑/Aspose.Slides‑Standardeinstellungen) bestimmt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich aus einem effektiven Schriftwert ableiten, welche Ebene die Größe oder den Schriftschnitt bereitgestellt hat?**

Nicht unmittelbar. EffectiveData liefert den finalen Wert. Um die Quelle zu finden, prüfen Sie die lokalen Werte im Abschnitt/Absatz/Textfeld und die Textstile im Layout/Master/Präsentation, um festzustellen, wo die erste explizite Definition erscheint.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich endgültig war (keine höhere Vererbung erforderlich). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen (z. B. zum Ausrichten von Farben, Einzügen oder Größen). Wenn Sie die Formatierung auf einer bestimmten Ebene ändern möchten, modifizieren Sie lokale Eigenschaften und lesen Sie bei Bedarf EffectiveData erneut, um das Ergebnis zu prüfen.