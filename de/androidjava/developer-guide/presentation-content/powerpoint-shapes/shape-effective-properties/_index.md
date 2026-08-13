---
title: Effektive Formeigenschaften aus Präsentationen auf Android abrufen
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
- Schriftgrad
- Füllformat
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Android über Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Wiedergabe zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, zum Beispiel:

1. Portionseigenschaften auf einer Folie.  
1. Textstile von Prototypformen auf einem Layout‑ oder Master‑Folie, wenn die Textfeldform der Portion einen hat.  
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerendert“‑Formatierung benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die Methode `getEffective()` auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie effektive Werte abgerufen werden. Es wird angenommen, dass die erste Form auf der ersten Folie ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) mit einem Textfeld und mindestens einer Portion ist.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Effektive Formatierungsdaten stellen die aktuell berechnete Formatierung nach Anwendung der Vererbung dar. In der aktuellen Implementierung können einige effektive Datenobjekte, wie zum Beispiel [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformateffectivedata/), intern zwischengespeichert werden. Ein erneuter Aufruf von `getEffective()` nach einer Änderung der übergeordneten oder geerbten Formatierung kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt kann den früheren Zustand nicht mehr repräsentieren. Wenn Sie effektive Werte für eine spätere Wiederverwendung erhalten möchten, kopieren Sie die erforderlichen Eigenschaften, etwa Schriftgrad, Füllfarbe, Schriftstil oder Ausrichtung, in Ihr eigenes Datenobjekt.
{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Kameraeigenschaften. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icameraeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz von [ICameraEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icameraeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) liefert.

```java
import com.aspose.slides.*;

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

Aspose.Slides ermöglicht das Abrufen effektiver Lichtanlagen‑Eigenschaften. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilightrigeffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Lichtanlagen‑Eigenschaften enthält. Eine Instanz von [ILightRigEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilightrigeffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) liefert.

```java
import com.aspose.slides.*;

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

## **Effektive Eigenschaften einer Abschrägung einer Form abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formabschrägung. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapebeveleffectivedata/) stellt ein unveränderliches Objekt dar, das effektive Flächenrelief‑Eigenschaften für eine Form enthält. Eine Instanz von [IShapeBevelEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapebeveleffectivedata/) wird über [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformateffectivedata/) bereitgestellt, das effektive Werte für [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) liefert.

```java
import com.aspose.slides.*;

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

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds abrufen. Das Interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformateffectivedata/) enthält effektive Textfeld‑Formatierungseigenschaften.

```java
import com.aspose.slides.*;

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

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils abrufen. Das Interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextstyleeffectivedata/) enthält effektive Textstileigenschaften.

```java
import com.aspose.slides.*;

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

## **Den effektiven Schriftgradwert abrufen**

Mit Aspose.Slides können Sie den effektiven Schriftgrad ermitteln. Der folgende Code demonstriert, wie sich der effektive Schriftgrad einer Portion ändert, nachdem lokale Schriftgrad‑Werte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden.

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

## **Effektives Füllformat für eine Tabelle abrufen**

Mit Aspose.Slides können Sie effektive Füllformatierungen für verschiedene Tabellenteile erhalten. Das Interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformateffectivedata/) enthält effektive Füllformatierungs‑Eigenschaften. Zellformatierungen haben höhere Priorität als Zeilenformatierungen, Zeilenformatierungen haben höhere Priorität als Spaltenformatierungen und Spaltenformatierungen haben höhere Priorität als die Formatierung der gesamten Tabelle.

Daher werden die Eigenschaften von [ICellFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icellformateffectivedata/) verwendet, um die Tabellenzelle zu zeichnen. Das folgende Beispiel zeigt, wie effektive Füllformatierungen für verschiedene Tabellenteile abgerufen werden. Es wird angenommen, dass die erste Form auf der ersten Folie eine [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itable/) ist.

```java
import com.aspose.slides.*;

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

### Gibt `getEffective()` einen Schnappschuss zurück?

Nicht immer. Effektive Daten repräsentieren die berechnete Formatierung nach Anwendung der Vererbung, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachträglicher Aufruf von `getEffective()` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss betrachtet werden sollte.

### Wann sollte ich effektive Eigenschaften erneut einlesen?

Rufen Sie `getEffective()` erneut auf, nachdem Sie lokale Formatierungen, übergeordnete Stile, Layout‑Formatierungen, Master‑Formatierungen oder Präsentations‑Standardwerte geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und gibt das aktuelle Ergebnis zurück.

### Wirkt sich das Ändern oder Entfernen einer Layout‑/Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?

Ja, die Änderung wird beim nächsten Aufruf von `getEffective()` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective()` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

### Kann ich Werte über effektive Datenobjekte ändern?

Nein. Effektive Datenobjekte geben nur berechnete Werte wieder. Änderungen sollten an den lokalen Formatierungsobjekten vorgenommen werden, anschließend können die effektiven Werte erneut abgerufen werden.

### Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?

Der effektive Wert wird durch den Standard‑Mechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser ermittelte Wert wird Teil der aktuellen effektiven Daten.

### Kann ich aus einem effektiven Schriftwert ersehen, welche Ebene die Größe oder Schriftart bereitgestellt hat?

Nicht direkt. Effektive Daten geben nur den endgültigen Wert zurück. Um die Quelle zu finden, prüfen Sie die lokalen Werte auf Portion‑, Absatz‑, Textfeld‑ und Textstil‑Ebene im Layout, Master und in der Präsentation, um festzustellen, wo die erste explizite Definition vorkommt.

### Warum sehen effektive Werte manchmal identisch zu den lokalen aus?

Weil der lokale Wert letztlich final war (keine höhere Vererbung nötig war). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

### Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?

Verwenden Sie effektive Daten, wenn Sie das „wie gerendert“‑Ergebnis nach vollständiger Vererbung benötigen, z. B. zum Angleichen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen bewahren wollen, kopieren Sie die erforderlichen Eigenschaften in Ihr eigenes Objekt. Wenn Sie Formatierungen auf einer bestimmten Ebene ändern möchten, passen Sie lokale Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu überprüfen.