---
title: Effekte Formeigenschaften aus Präsentationen in Java abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Light Rig
- Fasenform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides for Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint‑Darstellung zu gewährleisten."
---

In diesem Thema werden wir **effektive** und **lokale** Eigenschaften besprechen. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In den Eigenschaften des Abschnitts auf der Folie des Abschnitts;
1. Im Textstil der Prototypform auf Layout‑ oder Master‑Folien (falls die Form des Textfelds des Abschnitts einen hat);
1. In den globalen Texteinstellungen der Präsentation;

diese Werte werden **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn jedoch eine Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können **effektive** Werte erhalten, indem Sie die Methode **getEffective()** aus dem lokalen Format verwenden.

Dieser Beispielcode zeigt, wie man **effektive** Werte erhält:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IPortionFormat localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Effektive Eigenschaften einer Kamera abrufen**
Aspose.Slides for Java ermöglicht Entwicklern, **effektive** Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde das Interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) zu Aspose.Slides hinzugefügt. Das Interface [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) stellt ein unveränderliches Objekt dar, das **effektive** Kameraeigenschaften enthält. Eine Instanz des [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) Interface wird als Teil des [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) Interface verwendet, das ein [effektive Werte](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) ist.

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Effektive Eigenschaften eines Light Rig abrufen**
Aspose.Slides for Java ermöglicht Entwicklern, **effektive** Eigenschaften eines Light Rig abzurufen. Zu diesem Zweck wurde das Interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) zu Aspose.Slides hinzugefügt. Das Interface [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) stellt ein unveränderliches Objekt dar, das **effektive** Light‑Rig‑Eigenschaften enthält. Eine Instanz des [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) Interface wird als Teil des [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) Interface verwendet, das ein [effektive Werte](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) ist.

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Effektive Eigenschaften einer Bevel-Form abrufen**
Aspose.Slides for Java ermöglicht Entwicklern, **effektive** Eigenschaften einer Bevel‑Form abzurufen. Zu diesem Zweck wurde das Interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) zu Aspose.Slides hinzugefügt. Das Interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) stellt ein unveränderliches Objekt dar, das **effektive** Gesichts‑Relief‑Eigenschaften der Form enthält. Eine Instanz des [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) Interface wird als Teil des [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) Interface verwendet, das ein [effektive Werte](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) ist.

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Effektive Eigenschaften eines Textfelds abrufen**
Mit Aspose.Slides for Java können Sie **effektive** Eigenschaften eines Textfelds abrufen. Zu diesem Zweck wurde das Interface [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) zu Aspose.Slides hinzugefügt. Es enthält **effektive** Formatierungseigenschaften des Textfelds.

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
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
    if (pres != null) pres.dispose();
}
```


## **Effektive Eigenschaften eines Textstils abrufen**
Mit Aspose.Slides for Java können Sie **effektive** Eigenschaften eines Textstils abrufen. Zu diesem Zweck wurde das Interface [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) zu Aspose.Slides hinzugefügt. Es enthält **effektive** Textstileigenschaften.

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effective paragraph formatting for style level #" + i + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Den effektiven Schriftgröße‑Wert erhalten**
Mit Aspose.Slides for Java können Sie **effektive** Eigenschaften der Schriftgröße erhalten. Hier stellen wir einen Code bereit, der zeigt, wie sich der **effektive** Schriftgrößenwert eines Abschnitts ändert, nachdem **lokale** Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden:

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effective font height just after creation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effective font height after setting entire presentation default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effective font height after setting paragraph default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effective font height after setting portion #0 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effective font height after setting portion #1 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Das effektive Füllformat für eine Tabelle erhalten**
Mit Aspose.Slides for Java können Sie **effektive** Füllformatierung für verschiedene logische Teile einer Tabelle erhalten. Zu diesem Zweck wurde das Interface [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) in Aspose.Slides hinzugefügt. Es enthält **effektive** Füllformatierungseigenschaften. Bitte beachten Sie: Zellformatierung hat immer Vorrang vor Zeilenformatierung; Zeilen haben Vorrang vor Spalten; und Spalten haben Vorrang vor der gesamten Tabelle.

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    ITable tbl = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITableFormatEffectiveData tableFormatEffective = tbl.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie kann ich erkennen, dass ich einen „Snapshot“ und kein „Live‑Objekt“ erhalten habe, und wann sollte ich effektive Eigenschaften erneut auslesen?**  
EffectiveData‑Objekte sind unveränderliche Snapshots der zum Zeitpunkt des Aufrufs berechneten Werte. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, holen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Beeinflusst das Ändern der Layout‑/Master‑Folien bereits abgerufene effektive Eigenschaften?**  
Ja, jedoch erst, nachdem Sie sie erneut ausgelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über EffectiveData ändern?**  
Nein. EffectiveData ist schreibgeschützt. Nehmen Sie Änderungen an den lokalen Formatierungsobjekten (Form/Text/3D usw.) vor und holen Sie anschließend die effektiven Werte erneut.

**Was passiert, wenn eine Eigenschaft weder auf Formebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?**  
Der effektive Wert wird durch den Standard‑Mechanismus (PowerPoint/Aspose.Slides‑Standards) bestimmt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich anhand eines effektiven Schriftwertes erkennen, welche Ebene Größe oder Schriftart bereitgestellt hat?**  
Nicht direkt. EffectiveData liefert den endgültigen Wert. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte im Abschnitt/Absatz/Textfeld und die Textstile im Layout/Master/der Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen aus?**  
Weil der lokale Wert letztlich final war (keine höhere Vererbung erforderlich war). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**  
Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie die Formatierung auf einer bestimmten Ebene ändern müssen, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf EffectiveData erneut, um das Ergebnis zu prüfen.