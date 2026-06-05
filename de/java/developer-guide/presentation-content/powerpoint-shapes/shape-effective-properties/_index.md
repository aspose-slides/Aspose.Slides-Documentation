---
title: Abrufen effektiver Formeigenschaften aus Präsentationen in Java
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtanlage
- Kantenform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint‑Darstellung zu ermöglichen."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene gesetzt werden, z. B.:

1. Abschnittseigenschaften auf einer Folie.  
2. Textstile von Prototyp‑Formen auf einem Layout‑ oder Master‑Slide, wenn die Textframe‑Form des Abschnitts einen hat.  
3. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides das endgültige „wie gerenderte“ Format benötigt, löst es die Vererbungskette auf und liefert **effektive** Werte. Sie erhalten diese, indem Sie die Methode `getEffective` auf dem lokalen Format‑Objekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textframe und mindestens einem Abschnitt ist.

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
Effektive Formatierungsdaten repräsentieren die aktuell berechneten Formatierungen nach Anwendung der Vererbung. In der aktuellen Implementierung können einige effektive Datenobjekte, wie [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPortionFormatEffectiveData), intern zwischengespeichert werden. Ein erneuter Aufruf von `getEffective` nach Änderung von übergeordneten oder vererbten Einstellungen kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für eine spätere Wiederverwendung behalten müssen, kopieren Sie die benötigten Eigenschaften (z. B. Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung) in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICameraEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICameraEffectiveData) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften für die Kamera abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften einer Lichtanlage abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Lichtanlage. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ILightRigEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Lichtanlageneigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ILightRigEffectiveData) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften für die Lichtanlage abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften einer Formkante (Bevel) abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formkante. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeBevelEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Gesichts‑Relief‑Eigenschaften einer Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeBevelEffectiveData) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften für die obere Kante einer Form abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften eines Textrahmens abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textrahmens abrufen. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextFrameFormatEffectiveData) enthält effektive Textframe‑Formatierungseigenschaften.

Der folgende Code‑Beispiel zeigt, wie man effektive Textframe‑Formatierungseigenschaften abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textframe ist.

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

## **Effektive Eigenschaften eines Textstils abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils abrufen. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextStyleEffectiveData) enthält effektive Textstileigenschaften.

Der folgende Code‑Beispiel zeigt, wie man effektive Textstileigenschaften abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textframe ist.

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

## **Den effektiven Schriftgrößenwert abrufen**

Mit Aspose.Slides können Sie die effektive Schriftgröße erhalten. Der folgende Code demonstriert, wie sich die effektive Schriftgröße eines Abschnitts ändert, wenn lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt werden.

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

## **Effektives Füllformat für eine Tabelle abrufen**

Mit Aspose.Slides können Sie das effektive Füllformat für verschiedene Tabellenteile erhalten. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IFillFormatEffectiveData) enthält effektive Füllformatierungseigenschaften. Zellformatierungen haben höhere Priorität als Zeilenformatierungen, Zeilenformatierungen haben höhere Priorität als Spaltenformatierungen und Spaltenformatierungen haben höhere Priorität als die Formatierung der gesamten Tabelle.

Damit werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICellFormatEffectiveData) zum Zeichnen der Tabellenzelle verwendet. Der folgende Code‑Beispiel zeigt, wie man effektives Füllformat für verschiedene Tabellenteile abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [ITable](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITable) ist.

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

Nicht immer. Effektive Daten repräsentieren die berechnete Formatierung nach Anwendung der Vererbung, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `getEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss betrachtet werden sollte.

**Wann sollte ich effektive Eigenschaften erneut auslesen?**

Rufen Sie `getEffective` erneut auf, nachdem Sie lokale Formatierungen, übergeordnete Stile, Layout‑Formatierungen, Master‑Formatierungen oder Präsentations‑Standardeinstellungen geändert haben. Der nächste Aufruf wertet die Formatierungshierarchie neu aus und gibt das aktuelle effektive Ergebnis zurück.

**Wirkt sich das Ändern oder Entfernen eines Layout‑/Master‑Slides auf bereits abgerufene effektive Eigenschaften aus?**

Ja, die Änderung wird beim nächsten `getEffective`‑Aufruf berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungs‑Baum neu und die resultierenden Schriftarten, Farben, Größen oder andere Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben berechnete Werte zurück. Änderungen müssen an den lokalen Formatierungsobjekten vorgenommen und anschließend die effektiven Werte erneut abgerufen werden.

**Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standard‑Mechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe oder Schriftart bereitgestellt hat?**

Nicht direkt. Effektive Daten liefern den endgültigen Wert. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Abschnitts‑, Absatz‑, Textframe‑ und Textstil‑Ebene im Layout, Master und in der Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch mit den lokalen aus?**

Weil der lokale Wert letztlich endgültig war (keine höhere Ebene musste vererbt werden). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Anwendung der Vererbung benötigen, etwa zum Angleichen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unverändert behalten wollen, kopieren Sie die benötigten Eigenschaften in Ihr eigenes Objekt. Wenn Sie Formatierungen auf einer bestimmten Ebene ändern möchten, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu überprüfen.