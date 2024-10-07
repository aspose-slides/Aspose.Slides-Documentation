---
title: Effektive Eigenschaften von Formen
type: docs
weight: 50
url: /androidjava/shape-effective-properties/
---

In diesem Thema werden wir **effektive** und **lokale** Eigenschaften besprechen. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Abschnittseigenschaften auf der Folie des Abschnitts;
1. Im Textstil der Prototypform auf dem Layout oder Master-Folie (wenn die Textfeldform des Abschnitts einen hat);
1. In den globalen Texteinstellungen der Präsentation;

diese Werte werden als **lokale** Werte bezeichnet. Auf jeder Ebene könnten **lokale** Werte definiert oder weggelassen werden. Aber wenn eine Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte durch die Verwendung der **getEffective()**-Methode aus dem lokalen Format erhalten.

Dieser Beispielcode zeigt, wie man effektive Werte erhält:

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

## **Erhalten von effektiven Eigenschaften der Kamera**
Aspose.Slides für Android über Java ermöglicht Entwicklern, effektive Eigenschaften der Kamera zu erhalten. Zu diesem Zweck wurde das [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz der [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, welche ein [effektive Werte](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt Ihnen, wie man effektive Eigenschaften für die Kamera erhält:

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

## **Erhalten von effektiven Eigenschaften des Licht-Rigs**
Aspose.Slides für Android über Java ermöglicht Entwicklern, effektive Eigenschaften des Licht-Rigs zu erhalten. Zu diesem Zweck wurde die [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Licht-Rig-Eigenschaften enthält. Eine Instanz der [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, welche ein [effektive Werte](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt Ihnen, wie man effektive Eigenschaften des Licht-Rigs erhält:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effektive Licht-Rig-Eigenschaften =");
    System.out.println("Typ: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Richtung: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Erhalten von effektiven Eigenschaften der abgeschrägten Form**
Aspose.Slides für Android über Java ermöglicht Entwicklern, effektive Eigenschaften der abgeschrägten Form zu erhalten. Zu diesem Zweck wurde die [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Relief-Eigenschaften der Form enthält. Eine Instanz der [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, welche ein [effektive Werte](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt Ihnen, wie man effektive Eigenschaften für die abgeschrägte Form erhält:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effektive Relief-Eigenschaften der oberen Fläche der Form =");
    System.out.println("Typ: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Breite: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Höhe: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Erhalten von effektiven Eigenschaften eines Textfeldes**
Mit Aspose.Slides für Android über Java können Sie effektive Eigenschaften eines Textfeldes erhalten. Zu diesem Zweck wurde die [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Sie enthält effektive Formatierungseigenschaften für Textfelder.

Dieser Beispielcode zeigt Ihnen, wie man effektive Formatierungseigenschaften für Textfelder erhält:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anker-Typ: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("AutoFit-Typ: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertikaler Typ: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Ränder");
    System.out.println("   Links: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Oben: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Rechts: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Unten: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Erhalten von effektiven Eigenschaften eines Textstils**
Mit Aspose.Slides für Android über Java können Sie effektive Eigenschaften des Textstils erhalten. Zu diesem Zweck wurde die [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Sie enthält effektive Eigenschaften des Textstils.

Dieser Beispielcode zeigt Ihnen, wie man effektive Eigenschaften des Textstils erhält:

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
        System.out.println("Schrift-Ausrichtung: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Erhalten des effektiven Schriftgröße-Wertes**
Mit Aspose.Slides für Android über Java können Sie effektive Eigenschaften der Schriftgröße erhalten. Hier bieten wir einen Code, der zeigt, wie der effektive Schriftgrößenwert des Abschnitts sich ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden:

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

    System.out.println("Effektive Schriftgröße just nach der Erstellung:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effektive Schriftgröße nach Festlegung der Standard-Schriftgröße für die gesamte Präsentation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effektive Schriftgröße nach Festlegung der Standard-Schriftgröße für den Absatz:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effektive Schriftgröße nach Festlegung der Schriftgröße von Portion #0:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effektive Schriftgröße nach Festlegung der Schriftgröße von Portion #1:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Erhalten der effektiven Füllformatierung für Tabellen**
Mit Aspose.Slides für Android über Java können Sie effektive Füllformatierungen für verschiedene Teile der Tabellenlogik erhalten. Zu diesem Zweck wurde die [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) Schnittstelle in Aspose.Slides hinzugefügt. Sie enthält effektive Füllformatierungseigenschaften. Bitte beachten Sie dies: Die Zellformatierung hat immer Vorrang vor der Zeilenformatierung; die Zeile hat Vorrang vor der Spaltenformatierung; und die Spalte hat Vorrang vor der gesamten Tabelle.

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