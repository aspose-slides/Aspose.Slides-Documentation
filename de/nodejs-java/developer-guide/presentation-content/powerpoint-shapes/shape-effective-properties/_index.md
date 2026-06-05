---
title: "Formeffektive Eigenschaften aus Präsentationen in JavaScript abrufen"
linktitle: "Effektive Eigenschaften"
type: docs
weight: 50
url: /de/nodejs-java/shape-effective-properties/
keywords:
- "Formeigenschaften"
- "Kameraeigenschaften"
- "Beleuchtungsanlage"
- "Formabschrägung"
- "Textfeld"
- "Textstil"
- "Schriftgröße"
- "Füllformat"
- "PowerPoint"
- "Präsentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Entdecken Sie, wie Aspose.Slides für Node.js via Java Formeigenschaften effektiv berechnet und anwendet, um eine präzise PowerPoint‑Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, zum Beispiel:

1. Portionseigenschaften auf einer Folie.
1. Textstile von Prototyp‑Formen in einem Layout‑ oder Master‑Folie, wenn die Form des Textfelds der Portion einen hat.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder ausgelassen werden. Wenn Aspose.Slides die endgültige „wie gerendert“ Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `getEffective` am lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie Sie effektive Werte abrufen können. Es wird angenommen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) mit einem Textfeld und mindestens einer Portion ist.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effektive Formatierungsdaten stellen die aktuell berechnete Formatierung dar, nachdem die Vererbung angewendet wurde. In der aktuellen Implementierung können einige effektive Datenobjekte intern zwischengespeichert werden. Ein erneuter Aufruf von `getEffective` nach Ändern von übergeordneten oder vererbten Formatierungen kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für eine spätere Wiederverwendung aufbewahren müssen, kopieren Sie die benötigten Eigenschaften, wie Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das effektive Kamera‑Datenobjekt enthält unveränderliche Kameraeigenschaften und wird über die für [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) zurückgegebenen effektiven Werte bereitgestellt.

Das folgende Codebeispiel zeigt, wie Sie effektive Eigenschaften für die Kamera erhalten. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften einer Beleuchtungsanlage**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Beleuchtungsanlage. Das effektive Beleuchtungsanlagen‑Datenobjekt enthält unveränderliche Eigenschaften der Beleuchtungsanlage und wird über die für [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) zurückgegebenen effektiven Werte bereitgestellt.

Das folgende Codebeispiel zeigt, wie Sie effektive Eigenschaften für die Beleuchtungsanlage erhalten. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften einer Abschrägung einer Form**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formabschrägung. Das effektive Datenobjekt für Formabschrägungen enthält unveränderliche Flächenrelief‑Eigenschaften einer Form und wird über die für [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) zurückgegebenen effektiven Werte bereitgestellt.

Das folgende Codebeispiel zeigt, wie Sie effektive Eigenschaften für die obere Abschrägung einer Form erhalten. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften eines Textframes**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textframes erhalten. Das zurückgegebene effektive Datenobjekt enthält Formatierungseigenschaften des Textframes.

Das folgende Codebeispiel zeigt, wie Sie effektive Formatierungseigenschaften eines Textframes abrufen. Es wird angenommen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) mit einem Textframe ist.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften eines Textstils**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils erhalten. Das zurückgegebene effektive Datenobjekt enthält Eigenschaften des Textstils.

Das folgende Codebeispiel zeigt, wie Sie effektive Eigenschaften eines Textstils erhalten. Es wird angenommen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) mit einem Textframe ist.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Den effektiven Schriftgrößenwert erhalten**

Mit Aspose.Slides können Sie die effektive Schriftgröße erhalten. Der folgende Code zeigt, wie sich die effektive Schriftgröße einer Portion ändert, wenn lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt werden.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Effektives Füllformat für eine Tabelle abrufen**

Mit Aspose.Slides können Sie das effektive Füllformat für verschiedene Tabellenteile erhalten. Das zurückgegebene effektive Datenobjekt enthält Eigenschaften des Füllformats. Zellenformatierung hat höhere Priorität als Zeilenformatierung, Zeilenformatierung hat höhere Priorität als Spaltenformatierung und Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Folglich werden die effektiven Zellenformatierungseigenschaften zum Zeichnen der Tabellenzelle verwendet. Das folgende Codebeispiel zeigt, wie Sie das effektive Füllformat für verschiedene Tabellenteile erhalten. Es wird angenommen, dass die erste Form auf der ersten Folie eine [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/table/) ist.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Gibt `getEffective` einen Schnappschuss zurück?**

Nicht immer. Effektive Daten stellen die berechnete Formatierung dar, nachdem die Vererbung angewendet wurde, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `getEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss betrachtet werden sollte.

**Wann sollte ich effektive Eigenschaften erneut auslesen?**

Rufen Sie `getEffective` erneut auf, nachdem Sie die lokale Formatierung, übergeordnete Stile, Layout‑Formatierung, Master‑Formatierung oder die Standardwerte der Präsentation geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und gibt das aktuelle effektive Ergebnis zurück.

**Wirkt sich das Ändern oder Entfernen einer Layout‑/Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?**

Ja, aber die Änderung wird erst beim nächsten Aufruf von `getEffective` wirksam. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte wieder. Änderungen sollten in den lokalen Formatierungsobjekten vorgenommen werden, anschließend können die effektiven Werte erneut abgerufen werden.

**Was passiert, wenn eine Eigenschaft weder auf Formebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?**

Der effektive Wert wird durch den Standardmechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

**Kann ich anhand eines effektiven Schriftwertes feststellen, welche Ebene die Größe oder den Schriftschnitt bereitgestellt hat?**

Nicht direkt. Effektive Daten geben nur den endgültigen Wert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte bei der Portion, dem Absatz, dem Textframe und den Textstilen im Layout, Master und auf Präsentationsebene, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch mit den lokalen aus?**

Weil der lokale Wert letztlich endgültig war (keine höhere Vererbung nötig war). In solchen Fällen entspricht der effektive Wert dem lokalen.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen, etwa um Farben, Einzüge oder Größen abzustimmen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen bewahren möchten, kopieren Sie die erforderlichen Eigenschaften in ein eigenes Objekt. Möchten Sie die Formatierung auf einer bestimmten Ebene ändern, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu prüfen.