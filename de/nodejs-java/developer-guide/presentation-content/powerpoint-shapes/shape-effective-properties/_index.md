---
title: Effektive Formeigenschaften aus Präsentationen in JavaScript abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/nodejs-java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtvorrichtung
- Bevel-Form
- Textfeld
- Textstil
- Schriftgrad
- Füllformat
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Node.js über Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint‑Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene gesetzt werden, zum Beispiel:

1. Portionseigenschaften auf einer Folie.
1. Textformatvorlagen von Prototypformen auf einem Layout‑ oder Master‑Folie, wenn die Textfeld‑Form der Portion eine solche hat.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerenderte“ Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `getEffective` auf dem lokalen Format‑Objekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) mit einem Textfeld und mindestens einer Portion ist.

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
Effektive Formatierungsdaten stellen die aktuell berechnete Formatierung dar, nachdem die Vererbung angewendet wurde. In der aktuellen Implementierung können einige effektive Datenobjekte intern zwischengespeichert werden. Ein erneuter Aufruf von `getEffective` nach dem Ändern von übergeordneten oder geerbten Formatierungen kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für eine spätere Wiederverwendung bewahren müssen, kopieren Sie die erforderlichen Eigenschaften, wie Schriftgrad, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das effektive Kamera‑Datenobjekt enthält unveränderliche Kameraeigenschaften und wird über die effektiven Werte bereitgestellt, die für [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) zurückgegeben werden.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Kamera erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften einer Lichtvorrichtung abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Lichtvorrichtung. Das effektive Lichtvorrichtungs‑Datenobjekt enthält unveränderliche Eigenschaften der Lichtvorrichtung und wird über die effektiven Werte bereitgestellt, die für [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) zurückgegeben werden.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Lichtvorrichtung erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften einer Bevel‑Form abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Bevel‑Form. Das effektive Bevel‑Form‑Datenobjekt enthält unveränderliche Relief‑Eigenschaften einer Form und wird über die effektiven Werte bereitgestellt, die für [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) zurückgegeben werden.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die obere Abschrägung einer Form erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften eines Textfelds abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds erhalten. Das zurückgegebene effektive Datenobjekt enthält Eigenschaften der Textfeld‑Formatierung.

Das folgende Codebeispiel zeigt, wie man effektive Textfeld‑Formatierungseigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) mit einem Textfeld ist.

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

## **Effektive Eigenschaften eines Textstils abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils erhalten. Das zurückgegebene effektive Datenobjekt enthält Eigenschaften des Textstils.

Das folgende Codebeispiel zeigt, wie man effektive Textstileigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) mit einem Textfeld ist.

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

## **Den effektiven Schriftgradwert abrufen**

Mit Aspose.Slides können Sie den effektiven Schriftgrad erhalten. Der folgende Code demonstriert, wie sich der effektive Schriftgrad einer Portion ändert, nachdem lokale Schriftgradwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden.

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

Mit Aspose.Slides können Sie effektive Füllformatierung für verschiedene Tabellenteile erhalten. Das zurückgegebene effektive Datenobjekt enthält Eigenschaften der Füllformatierung. Zellformatierung hat höhere Priorität als Zeilenformatierung, Zeilenformatierung hat höhere Priorität als Spaltenformatierung, und Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Daher werden die effektiven Zellformatierungseigenschaften zum Zeichnen der Tabellenzelle verwendet. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/table/) ist.

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

Nicht immer. Effektive Daten repräsentieren die berechnete Formatierung nach Anwendung der Vererbung, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `getEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss betrachtet werden sollte.

**Wann sollte ich effektive Eigenschaften erneut abfragen?**

Rufen Sie `getEffective` erneut auf, nachdem Sie lokale Formatierungen, übergeordnete Stile, Layout‑Formatierungen, Master‑Formatierungen oder präsentationsweite Vorgaben geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und liefert das aktuelle effektive Ergebnis.

**Wirkt sich das Ändern oder Entfernen einer Layout‑/Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?**

Ja, die Änderung wird beim nächsten Aufruf von `getEffective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte wieder. Änderungen sollten in den lokalen Formatierungsobjekten vorgenommen werden, und dann sollten die effektiven Werte erneut abgerufen werden.

**Was passiert, wenn eine Eigenschaft weder auf Formebene, noch im Layout/Master und nicht in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standard‑Mechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides beinhaltet. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe oder Schriftart bereitgestellt hat?**

Nicht direkt. Effektive Daten liefern nur den endgültigen Wert. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Portion, Absatz, Textfeld und Textstilen im Layout, Master und auf Präsentationsebene, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich endgültig war (keine höhere Vererbung erforderlich war). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Anwendung der Vererbung benötigen, etwa zum Angleichen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen bewahren wollen, kopieren Sie die benötigten Eigenschaften in Ihr eigenes Objekt. Wenn Sie Formatierungen auf einer bestimmten Ebene ändern möchten, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu überprüfen.