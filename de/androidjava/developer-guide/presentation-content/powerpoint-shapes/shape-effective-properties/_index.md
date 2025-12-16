---
title: Effektive Shape-Eigenschaften aus Präsentationen auf Android abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/androidjava/shape-effective-properties/
keywords:
- Shape-Eigenschaften
- Kameraeigenschaften
- Lichtanlage
- Stufenform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Android via Java effektive Shape-Eigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---

In diesem Thema werden wir **effektive** und **lokale** Eigenschaften besprechen. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Abschnitt‑Eigenschaften auf der Folie des Abschnitts;
1. In der Textstil‑Vorlage der Form auf Layout‑ oder Master‑Folie (falls die Textfeld‑Form des Abschnitts einen hat);
1. In den globalen Texteinstellungen der Präsentation;

werden diese Werte **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn jedoch eine Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte erhalten, indem Sie die Methode **getEffective()** des lokalen Formats verwenden.

Dieses Beispielcode zeigt, wie Sie effektive Werte erhalten:
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


## **Effektive Eigenschaften einer Kamera**

Aspose.Slides für Android über Java ermöglicht Entwicklern, effektive Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde die [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz der [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, die ein [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) darstellt.

Dieses Beispielcode zeigt, wie Sie effektive Eigenschaften für die Kamera abrufen:
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


## **Effektive Eigenschaften einer Lichtanlage**

Aspose.Slides für Android über Java ermöglicht Entwicklern, effektive Eigenschaften einer Lichtanlage abzurufen. Zu diesem Zweck wurde die [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Eigenschaften einer Lichtanlage enthält. Eine Instanz der [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, die ein [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) darstellt.

Dieses Beispielcode zeigt, wie Sie effektive Eigenschaften der Lichtanlage abrufen:
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


## **Effektive Eigenschaften einer Stufenform**

Aspose.Slides für Android über Java ermöglicht Entwicklern, effektive Eigenschaften einer Stufenform abzurufen. Zu diesem Zweck wurde die [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Eigenschaften der Formenrelief‑Fläche enthält. Eine Instanz der [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData)) Schnittstelle verwendet, die ein [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) darstellt.

Dieses Beispielcode zeigt, wie Sie effektive Eigenschaften für die Stufenform abrufen:
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


## **Effektive Eigenschaften eines Textfelds**

Mit Aspose.Slides für Android über Java können Sie effektive Eigenschaften eines Textfelds abrufen. Zu diesem Zweck wurde die [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Sie enthält effektive Eigenschaften der Textfeldformatierung. 

Dieses Beispielcode zeigt, wie Sie effektive Eigenschaften der Textfeldformatierung abrufen:
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


## **Effektive Eigenschaften eines Textstils**

Mit Aspose.Slides für Android über Java können Sie effektive Eigenschaften eines Textstils abrufen. Zu diesem Zweck wurde die [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Sie enthält effektive Textstileigenschaften.

Dieses Beispielcode zeigt, wie Sie effektive Eigenschaften des Textstils abrufen:
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


## **Den effektiven Schriftgradwert ermitteln**

Mit Aspose.Slides für Android über Java können Sie effektive Eigenschaften der Schriftgröße ermitteln. Hier stellen wir einen Code bereit, der zeigt, wie sich der effektive Schriftgradwert eines Abschnitts ändert, nachdem lokale Schriftgradwerte auf verschiedenen Präsentationsstrukturebenen gesetzt wurden:
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


## **Effektives Füllformat für eine Tabelle ermitteln**

Mit Aspose.Slides für Android über Java können Sie effektive Füllformatierung für verschiedene Tabellenteile ermitteln. Zu diesem Zweck wurde die [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) Schnittstelle in Aspose.Slides hinzugefügt. Sie enthält effektive Füllformatierungseigenschaften. Bitte beachten Sie: Zellenformatierung hat stets Vorrang vor Zeilenformatierung; Zeilenformatierung hat Vorrang vor Spaltenformatierung; und Spaltenformatierung hat Vorrang vor der gesamten Tabelle.
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

**Wie kann ich feststellen, dass ich ein „Snapshot“ und kein „Live‑Objekt“ habe, und wann sollte ich effektive Eigenschaften erneut lesen?**

EffectiveData‑Objekte sind unveränderliche Schnappschüsse der berechneten Werte zum Zeitpunkt des Aufrufs. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, holen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern der Layout‑/Master‑Folie auf bereits abgefragte effektive Eigenschaften aus?**

Ja, jedoch nur, nachdem Sie sie erneut gelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst — fordern Sie es nach einer Layout‑ oder Master‑Änderung erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Änderungen erfolgen in den lokalen Formatierungsobjekten (Form/Text/3D usw.), und anschließend holen Sie die effektiven Werte erneut ab.

**Was passiert, wenn an der Form‑Ebene, im Layout/Master und in den globalen Einstellungen kein Wert gesetzt ist?**

Der effektive Wert wird durch den Standardmechanismus (PowerPoint/Aspose.Slides‑Standardwerte) bestimmt. Dieser ermittelte Wert wird Teil des EffectiveData‑Schnappschusses.

**Kann ich anhand eines effektiven Schriftwertes erkennen, welche Ebene die Größe oder den Schriftschnitt bereitgestellt hat?**

Nicht unmittelbar. EffectiveData liefert den endgültigen Wert. Um die Quelle zu finden, prüfen Sie die lokalen Werte auf Abschnitt/Absatz/Textfeld‑Ebene sowie die Textstile im Layout/Master/Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich final war (keine höhere Vererbung nötig). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerendert“ Ergebnis nach vollständiger Vererbung benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie Formatierungen auf einer bestimmten Ebene ändern möchten, bearbeiten Sie die lokalen Eigenschaften und lesen Sie bei Bedarf erneut EffectiveData, um das Ergebnis zu prüfen.