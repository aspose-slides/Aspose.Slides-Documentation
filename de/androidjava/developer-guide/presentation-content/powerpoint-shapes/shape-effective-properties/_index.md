---
title: Ermitteln von effektiven Formeigenschaften aus Präsentationen auf Android
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/androidjava/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtanlage
- Abgeschrägte Form
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Android über Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, zum Beispiel:

1. Portionseigenschaften auf einer Folie.
1. Prototyp‑Form‑Textstile in einem Layout‑ oder Master‑Folien, wenn die Textfeld‑Form der Portion einen hat.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerenderte“ Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `getEffective()` auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) mit einem Textfeld und mindestens einer Portion ist.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effektive Formatierungsdaten stellen die aktuelle berechnete Formatierung dar, nachdem die Vererbung angewendet wurde. In der aktuellen Implementierung können einige effektive Datenobjekte, wie z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformateffectivedata/), intern zwischengespeichert werden. Ein erneuter Aufruf von `getEffective()` nach einer Änderung der übergeordneten oder vererbten Formatierung kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt den früheren Zustand möglicherweise nicht mehr dar. Wenn Sie effektive Werte für eine spätere Wiederverwendung erhalten möchten, kopieren Sie die erforderlichen Eigenschaften wie Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icameraeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der Kamera erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung hat.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften einer Lichtanlage abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Lichtanlage. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilightrigeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Lichtanlageneigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der Lichtanlage erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung hat.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften einer Formabschrägung abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formabschrägung. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapebeveleffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Eigenschaften für die Abschrägung einer Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der oberen Abschrägung einer Form erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung hat.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften eines Textfelds abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds abrufen. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformateffectivedata/) enthält effektive Formatierungseigenschaften für Textfelder.

Das folgende Codebeispiel zeigt, wie man effektive Formatierungseigenschaften eines Textfelds erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) mit einem Textfeld ist.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften eines Textstils abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils abrufen. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextstyleeffectivedata/) enthält effektive Eigenschaften des Textstils.

Das folgende Codebeispiel zeigt, wie man effektive Textstileigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) mit einem Textfeld ist.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Effektiven Schriftgrößenwert abrufen**

Mit Aspose.Slides können Sie die effektive Schriftgröße erhalten. Der folgende Code zeigt, wie sich die effektive Schriftgröße einer Portion ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Effektives Füllformat für eine Tabelle erhalten**

Mit Aspose.Slides können Sie effektive Füllformatierung für verschiedene Tabellenteile erhalten. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformateffectivedata/) enthält effektive Füllformatierungseigenschaften. Zellformatierung hat höhere Priorität als Reihenformatierung, Reihenformatierung hat höhere Priorität als Spaltenformatierung und Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Folglich werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icellformateffectivedata/) verwendet, um die Tabellenzelle zu zeichnen. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile erhält. Es wird angenommen, dass die erste Form auf der ersten Folie eine [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itable/) ist.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Gibt `getEffective()` einen Schnappschuss zurück?**

Nicht immer. Effektive Daten stellen die berechnete Formatierung dar, nachdem die Vererbung angewendet wurde, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `getEffective()` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss angesehen werden sollte.

**Wann sollte ich effektive Eigenschaften erneut auslesen?**

Rufen Sie `getEffective()` erneut auf, nachdem Sie die lokale Formatierung, übergeordnete Stile, Layout‑Formatierung, Master‑Formatierung oder Präsentations‑Standardwerte geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und gibt das aktuelle effektive Ergebnis zurück.

**Wirkt sich das Ändern oder Entfernen einer Layout‑/Master‑Folien auf bereits abgerufene effektive Eigenschaften aus?**

Ja, aber die Änderung wird erst beim nächsten Aufruf von `getEffective()` wirksam. Wird eine übergeordnete Formatierungsquelle geändert oder entfernt, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective()` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte zurück. Änderungen sollten in den lokalen Formatierungsobjekten vorgenommen werden, und anschließend die effektiven Werte erneut abgerufen werden.

**Was passiert, wenn eine Eigenschaft weder auf der Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?**

Der effektive Wert wird durch den Standard‑Mechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe oder Schriftart bereitgestellt hat?**

Nicht direkt. Effektive Daten geben nur den endgültigen Wert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Ebene der Portion, des Absatzes, des Textfelds und der Textstile im Layout, Master und der Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich der endgültige war (keine höhere Ebene musste vererbt werden). In solchen Fällen entspricht der effektive Wert dem lokalen.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen, z. B. zum Angleichen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen erhalten möchten, kopieren Sie die erforderlichen Eigenschaften in ein eigenes Objekt. Möchten Sie die Formatierung auf einer bestimmten Ebene ändern, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut aus, um das Ergebnis zu prüfen.