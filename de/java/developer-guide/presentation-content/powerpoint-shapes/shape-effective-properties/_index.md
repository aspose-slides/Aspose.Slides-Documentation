---
title: Effektive Eigenschaften von Formen
type: docs
weight: 50
url: /java/shape-effective-properties/
---

In diesem Thema werden wir **effektive** und **lokale** Eigenschaften besprechen. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Formatierungen für Absätze auf der Folie des Portions;
1. Im Typographie-Stil von Prototypformen auf Layout- oder Master-Folien (wenn das Textfeld der Portionsform eines hat);
1. In den globalen Texteinstellungen der Präsentation;

sind diese Werte als **lokale** Werte bekannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn jedoch eine Anwendung wissen muss, wie die Portion aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte erhalten, indem Sie die **getEffective()**-Methode aus dem lokalen Format verwenden.

Dieser Beispielcode zeigt Ihnen, wie Sie effektive Werte erhalten:

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

## **Effektive Eigenschaften der Kamera abrufen**
Aspose.Slides für Java ermöglicht Entwicklern, die effektiven Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde das [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) Interface zu Aspose.Slides hinzugefügt. Das [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) Interface stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz des [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) Interfaces wird als Teil des [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) Interfaces verwendet, welches ein [effektives Werte](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt Ihnen, wie Sie effektive Eigenschaften für die Kamera abrufen:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effektive Kameraeigenschaften =");
    System.out.println("Typ: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Sichtfeld: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Effektive Eigenschaften des Licht-Rigs abrufen**
Aspose.Slides für Java ermöglicht Entwicklern, die effektiven Eigenschaften von Licht-Rigs abzurufen. Zu diesem Zweck wurde das [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) Interface zu Aspose.Slides hinzugefügt. Das [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) Interface stellt ein unveränderliches Objekt dar, das effektive Eigenschaften des Licht-Rigs enthält. Eine Instanz des [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) Interfaces wird als Teil des [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) Interfaces verwendet, welches ein [effektives Werte](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt Ihnen, wie Sie effektive Eigenschaften des Licht-Rigs abrufen:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effektive Licht-Rig Eigenschaften =");
    System.out.println("Typ: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Richtung: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Effektive Eigenschaften der Fasenform abrufen**
Aspose.Slides für Java ermöglicht Entwicklern, die effektiven Eigenschaften der Fasenform abzurufen. Zu diesem Zweck wurde das [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) Interface zu Aspose.Slides hinzugefügt. Das [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) Interface stellt ein unveränderliches Objekt dar, das die effektiven Oberflächenrelief-Eigenschaften der Form enthält. Eine Instanz des [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) Interfaces wird als Teil des [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)) Interfaces verwendet, welches ein [effektives Werte](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt Ihnen, wie Sie effektive Eigenschaften für die Fasenform abrufen:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effektive Oberflächenrelief-Eigenschaften der Form =");
    System.out.println("Typ: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Breite: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Höhe: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Effektive Eigenschaften eines Textfeldes abrufen**
Mit Aspose.Slides für Java können Sie die effektiven Eigenschaften eines Textfeldes abrufen. Zu diesem Zweck wurde das [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) Interface zu Aspose.Slides hinzugefügt. Es enthält die effektiven Formatierungseigenschaften des Textfeldes.

Dieser Beispielcode zeigt Ihnen, wie Sie effektive Formatierungseigenschaften des Textfeldes abrufen:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Ankertyp: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Automatische Anpassungsart: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Textvertikaler Typ: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Ränder");
    System.out.println("   Links: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Oben: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Rechts: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Unten: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Effektive Eigenschaften eines Textstils abrufen**
Mit Aspose.Slides für Java können Sie die effektiven Eigenschaften eines Textstils abrufen. Zu diesem Zweck wurde das [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) Interface zu Aspose.Slides hinzugefügt. Es enthält die effektiven Eigenschaften des Textstils.

Dieser Beispielcode zeigt Ihnen, wie Sie effektive Eigenschaften des Textstils abrufen:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effektive Absatzformatierung für Stil-Ebene #" + i + " =");

        System.out.println("Tiefe: " + effectiveStyleLevel.getDepth());
        System.out.println("Einzug: " + effectiveStyleLevel.getIndent());
        System.out.println("Ausrichtung: " + effectiveStyleLevel.getAlignment());
        System.out.println("Schriftausrichtung: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Effektiven Schriftgrad-Wert abrufen**
Mit Aspose.Slides für Java können Sie die effektiven Eigenschaften des Schriftgrads abrufen. Hier stellen wir einen Code bereit, der zeigt, wie sich der effektive Schriftgradwert der Portion ändert, nachdem lokale Schriftgradwerte auf verschiedenen Präsentationsstrukturebenen festgelegt wurden:

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Beispieltext mit erster Portion");
    IPortion portion1 = new Portion(" und zweiter Portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effektive Schriftgradhöhe sofort nach Erstellung:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effektive Schriftgradhöhe nach Festlegung der gesamten Präsentation als Standardschriftgradhöhe:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effektive Schriftgradhöhe nach Festlegung der Absatz-Standard-Schriftgradhöhe:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effektive Schriftgradhöhe nach Festlegung der Schriftgradhöhe von Portion #0:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effektive Schriftgradhöhe nach Festlegung der Schriftgradhöhe von Portion #1:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Effektive Füllformatierung für Tabellen abrufen**
Mit Aspose.Slides für Java können Sie die effektive Füllformatierung für verschiedene logische Teile von Tabellen abrufen. Zu diesem Zweck wurde das [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) Interface in Aspose.Slides hinzugefügt. Es enthält effektive Füllformatierungseigenschaften. Bitte beachten Sie dies: Die Zellformatierung hat immer Priorität gegenüber der Zeilenformatierung; Zeilen haben Priorität gegenüber den Spalten; und Spalten haben Priorität gegenüber der gesamten Tabelle.

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