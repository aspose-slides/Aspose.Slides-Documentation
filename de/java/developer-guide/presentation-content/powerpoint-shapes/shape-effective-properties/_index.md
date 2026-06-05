---
title: Abrufen von effektiven Formeigenschaften aus Präsentationen in Java
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtrigg
- Schrägkantform
- Textfeld
- Textstil
- Schriftgrad
- Füllformat
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint‑Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, zum Beispiel:

1. Abschnittseigenschaften auf einer Folie.  
2. Textstile von Prototypformen in einem Layout oder einer Master‑Folie, wenn die Textfeldform des Abschnitts einen hat.  
3. Globale Texteinstellungen in einer Präsentation.  

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerenderte“ Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `getEffective` auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textfeld und mindestens einem Abschnitt ist.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effektive Formatierungsdaten repräsentieren die aktuell berechnete Formatierung nach Anwendung der Vererbung. In der aktuellen Implementierung können einige effektive Datenobjekte, wie z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPortionFormatEffectiveData), intern zwischengespeichert werden. Ein erneuter Aufruf von `getEffective` nach einer Änderung der übergeordneten oder vererbten Formatierung kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den vorherigen Zustand dar. Wenn Sie effektive Werte für eine spätere Wiederverwendung behalten müssen, kopieren Sie die erforderlichen Eigenschaften, wie Schriftgrad, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICameraEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine [ICameraEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICameraEffectiveData)-Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Kamera erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D-Formatierung besitzt.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften eines Lichtrigs**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften eines Lichtrigs. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ILightRigEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Lichtrig‑Eigenschaften enthält. Eine [ILightRigEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ILightRigEffectiveData)-Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für das Lichtrig erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D-Formatierung besitzt.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften einer Bevel‑Form**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formbevel. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeBevelEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Flächenrelief‑Eigenschaften einer Form enthält. Eine [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeBevelEffectiveData)-Instanz wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Ober‑Bevel einer Form erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D-Formatierung besitzt.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften eines Textfelds**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds abrufen. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextFrameFormatEffectiveData) enthält effektive Formatierungseigenschaften für Textfelder.

Das folgende Codebeispiel zeigt, wie man effektive Textfeldformatierungseigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textfeld ist.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Effektive Eigenschaften eines Textstils**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils abrufen. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextStyleEffectiveData) enthält effektive Textstileigenschaften.

Das folgende Codebeispiel zeigt, wie man effektive Textstileigenschaften erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textfeld ist.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Den effektiven Schriftgradwert erhalten**

Mit Aspose.Slides können Sie den effektiven Schriftgrad erhalten. Der folgende Code zeigt, wie sich der effektive Schriftgrad eines Abschnitts ändert, nachdem lokale Schriftgradwerte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden.

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

## **Den effektiven Füllformat für eine Tabelle erhalten**

Mit Aspose.Slides können Sie effektive Füllformatierungen für verschiedene Tabellenteile abrufen. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IFillFormatEffectiveData) enthält effektive Füllformatierungseigenschaften. Die Zellenformatierung hat höhere Priorität als die Zeilenformatierung, die Zeilenformatierung hat höhere Priorität als die Spaltenformatierung, und die Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Daher werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICellFormatEffectiveData) verwendet, um die Tabellzelle zu zeichnen. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile erhält. Es wird angenommen, dass die erste Form auf der ersten Folie ein [ITable](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITable) ist.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Gibt `getEffective` einen Schnappschuss zurück?**

Nicht immer. Effektive Daten stellen die berechnete Formatierung nach Anwendung der Vererbung dar, jedoch können einige effektive Datenobjekte intern zwischengespeichert werden. Ein nachfolgender Aufruf von `getEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss betrachtet werden sollte.

**Wann sollte ich effektive Eigenschaften erneut auslesen?**

Rufen Sie `getEffective` erneut auf, nachdem Sie die lokale Formatierung, übergeordnete Stile, Layout‑Formatierung, Master‑Formatierung oder die Standardwerte der Präsentation geändert haben. Der nächste Aufruf wertet die Formatierungshierarchie neu aus und gibt das aktuelle effektive Ergebnis zurück.

**Wirkt sich das Ändern oder Entfernen einer Layout‑/Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch wird die Änderung beim nächsten Aufruf von `getEffective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte aus. Änderungen müssen an den lokalen Formatierungsobjekten vorgenommen werden, und anschließend können die effektiven Werte erneut abgerufen werden.

**Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?**

Der effektive Wert wird durch den Standardmechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides beinhaltet. Dieser ermittelte Wert wird Teil der aktuellen effektiven Daten.

**Kann ich anhand eines effektiven Schriftwertes feststellen, welche Ebene die Größe oder Schriftart bereitgestellt hat?**

Nicht direkt. Effektive Daten geben nur den Endwert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte im Abschnitt, Absatz, Textfeld und den Textstilen auf Layout‑, Master‑ und Präsentationsebene, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich final war (keine höherstufige Vererbung erforderlich war). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen, etwa um Farben, Einzüge oder Größen abzustimmen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen bewahren möchten, kopieren Sie die erforderlichen Eigenschaften in ein eigenes Objekt. Wenn Sie die Formatierung auf einer bestimmten Ebene ändern wollen, passen Sie die lokalen Eigenschaften an und lesen Sie anschließend bei Bedarf die effektiven Daten erneut, um das Ergebnis zu prüfen.