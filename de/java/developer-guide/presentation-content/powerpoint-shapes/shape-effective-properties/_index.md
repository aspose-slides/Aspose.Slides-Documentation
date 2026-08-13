---
title: Abrufen von effektiven Shape-Eigenschaften aus Präsentationen in Java
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/java/shape-effective-properties/
keywords:
- Shape-Eigenschaften
- Kameraeigenschaften
- Lichtsystem
- Abgeschrägtes Shape
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Java effektive Shape-Eigenschaften berechnet und anwendet, um eine präzise PowerPoint‑Darstellung zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, zum Beispiel:

1. Abschnitts‑Eigenschaften auf einer Folie.  
1. Textstile des Prototyp‑Shape auf einem Layout‑ oder Master‑Slide, wenn das Textfeld‑Shape des Abschnitts eines hat.  
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerendert“‑Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `getEffective` auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte erhält. Es wird angenommen, dass das erste Shape auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textfeld und mindestens einem Abschnitt ist.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Effektive Formatierungsdaten repräsentieren die aktuell berechnete Formatierung nach Anwendung der Vererbung. In der aktuellen Implementierung können einige effektive Datenobjekte, wie z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPortionFormatEffectiveData), intern gecached werden. Ein erneuter Aufruf von `getEffective` nach Änderung des übergeordneten oder geerbten Formats kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für eine spätere Wiederverwendung behalten müssen, kopieren Sie die erforderlichen Eigenschaften, wie Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICameraEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICameraEffectiveData) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Kamera abruft. Es wird angenommen, dass das erste Shape auf der ersten Folie über 3D‑Formatierung verfügt.

```java
import com.aspose.slides.*;

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

## **Effektive Eigenschaften eines Lichtsystems abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften eines Lichtsystems. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ILightRigEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Lichtsystem‑Eigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ILightRigEffectiveData) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für das Lichtsystem abruft. Es wird angenommen, dass das erste Shape auf der ersten Folie über 3D‑Formatierung verfügt.

```java
import com.aspose.slides.*;

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

## **Effektive Eigenschaften einer Shape‑Abschrägung abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Shape‑Abschrägung. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeBevelEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Flächen‑Relief‑Eigenschaften für ein Shape enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeBevelEffectiveData) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormatEffectiveData) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/IThreeDFormat) liefert.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die obere Abschrägung eines Shapes abruft. Es wird angenommen, dass das erste Shape auf der ersten Folie über 3D‑Formatierung verfügt.

```java
import com.aspose.slides.*;

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

## **Effektive Eigenschaften eines Textfelds abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften eines Textfelds. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextFrameFormatEffectiveData) enthält effektive Textfeld‑Formatierungseigenschaften.

Das folgende Codebeispiel zeigt, wie man effektive Textfeld‑Formatierungseigenschaften abruft. Es wird angenommen, dass das erste Shape auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textfeld ist.

```java
import com.aspose.slides.*;

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

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften eines Textstils. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITextStyleEffectiveData) enthält effektive Textstileigenschaften.

Das folgende Codebeispiel zeigt, wie man effektive Textstileigenschaften abruft. Es wird angenommen, dass das erste Shape auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape) mit einem Textfeld ist.

```java
import com.aspose.slides.*;

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

## **Den effektiven Schriftgrößenwert ermitteln**

Aspose.Slides ermöglicht das Ermitteln der effektiven Schriftgröße. Der folgende Code demonstriert, wie sich die effektive Schriftgröße eines Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Präsentations‑Strukturebenen gesetzt wurden.

```java
import com.aspose.slides.*;

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

## **Effektives Füllformat einer Tabelle ermitteln**

Aspose.Slides ermöglicht das Abrufen effektiver Füllformatierung für unterschiedliche Tabellenteile. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IFillFormatEffectiveData) enthält effektive Füllformatierungs‑Eigenschaften. Zellformatierungen haben höhere Priorität als Zeilenformatierungen, Zeilenformatierungen höher als Spaltenformatierungen und Spaltenformatierungen höher als die Formatierung der gesamten Tabelle.

Als Ergebnis werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICellFormatEffectiveData) verwendet, um die Tabellenzelle zu zeichnen. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile abruft. Es wird angenommen, dass das erste Shape auf der ersten Folie ein [ITable](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITable) ist.

```java
import com.aspose.slides.*;

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

### Gibt `getEffective` einen Schnappschuss zurück?

Nicht immer. Effektive Daten stellen die berechnete Formatierung nach Anwendung der Vererbung dar, aber einige effektive Datenobjekte können intern gecached werden. Ein nachfolgender Aufruf von `getEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss angesehen werden sollte.

### Wann sollte ich effektive Eigenschaften erneut auslesen?

Rufen Sie `getEffective` erneut auf, nachdem Sie lokale Formatierungen, übergeordnete Stile, Layout‑Formatierungen, Master‑Formatierungen oder Präsentations‑Standardwerte geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und liefert das aktuelle effektive Ergebnis.

### Führt das Ändern oder Entfernen eines Layout‑/Master‑Slides zu Änderungen an bereits abgerufenen effektiven Eigenschaften?

Ja, die Änderung wird beim nächsten Aufruf von `getEffective` wirksam. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

### Kann ich Werte über effektive Datenobjekte ändern?

Nein. Effektive Datenobjekte geben nur berechnete Werte zurück. Änderungen müssen an den lokalen Formatierungsobjekten vorgenommen werden, danach die effektiven Werte erneut abgerufen werden.

### Was passiert, wenn eine Eigenschaft weder auf Shape‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?

Der effektive Wert wird durch den Standardmechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

### Kann ich anhand eines effektiven Schriftwertes erkennen, welche Ebene die Größe oder den Schriftschnitt bereitgestellt hat?

Nicht direkt. Effektive Daten geben den endgültigen Wert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Abschnitts‑, Absatz‑, Textfeld‑ und Textstil‑Ebenen im Layout, Master und Präsentations‑Level, um zu sehen, wo die erste explizite Definition vorkommt.

### Warum sehen effektive Werte manchmal identisch mit den lokalen aus?

Weil der lokale Wert letztlich der endgültige ist (keine höhere Vererbung erforderlich war). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

### Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?

Verwenden Sie effektive Daten, wenn Sie das „wie gerendert“-Ergebnis nach vollständiger Anwendung der Vererbung benötigen, z. B. zum Angleichen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen bewahren müssen, kopieren Sie die erforderlichen Eigenschaften in Ihr eigenes Objekt. Wenn Sie die Formatierung auf einer bestimmten Ebene ändern wollen, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu überprüfen.