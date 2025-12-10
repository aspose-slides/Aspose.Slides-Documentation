---
title: Erhalte effektive Formeigenschaften aus Präsentationen in .NET
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/net/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtanlage
- Fasenform
- Textrahmen
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für .NET effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---

In diesem Thema werden wir **effektive** und **lokale** Eigenschaften besprechen. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Teil‑Eigenschaften auf der Folie des Teils.  
1. Im Textstil der Prototypform auf Layout‑ oder Masterfolie (falls die Textrahmen‑Form des Teils einen hat).  
1. In den globalen Texteinstellungen der Präsentation.

dann werden diese Werte **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Schließlich, wenn die Anwendung wissen muss, wie der Teil aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte erhalten, indem Sie die **getEffective()**‑Methode des lokalen Formats verwenden.

Das folgende Beispiel zeigt, wie man effektive Werte abruft.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextFrameFormat localTextFrameFormat = shape.TextFrame.TextFrameFormat;
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

    IPortionFormat localPortionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.GetEffective();
}
```




## **Effektive Eigenschaften einer Kamera abrufen**
Aspose.Slides für .NET ermöglicht Entwicklern das Abrufen **effektiver** Eigenschaften der Kamera. Zu diesem Zweck wurde die Klasse **CameraEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse **CameraEffectiveData** stellt ein unveränderliches Objekt dar, das effektive Kamera‑Eigenschaften enthält. Eine Instanz der Klasse **CameraEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die Klasse **ThreeDFormat** darstellt.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften der Kamera abruft.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective camera properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```



## **Effektive Eigenschaften einer Lichtanlage abrufen**
Aspose.Slides für .NET ermöglicht Entwicklern das Abrufen **effektiver** Eigenschaften der Lichtanlage. Zu diesem Zweck wurde die Klasse **LightRigEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse **LightRigEffectiveData** stellt ein unveränderliches Objekt dar, das effektive Eigenschaften der Lichtanlage enthält. Eine Instanz der Klasse **LightRigEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die Klasse **ThreeDFormat** darstellt.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften der Lichtanlage abruft.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```



## **Effektive Eigenschaften einer Fasenform abrufen**
Aspose.Slides für .NET ermöglicht Entwicklern das Abrufen **effektiver** Eigenschaften einer Fasenform. Zu diesem Zweck wurde die Klasse **ShapeBevelEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse **ShapeBevelEffectiveData** stellt ein unveränderliches Objekt dar, das effektive Relief‑Eigenschaften der Form enthält. Eine Instanz der Klasse **ShapeBevelEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die Klasse **ThreeDFormat** darstellt.

Der folgende Code‑Beispiel zeigt, wie man effektive Eigenschaften der Fasenform abruft.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective shape's top face relief properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
}
```




## **Effektive Eigenschaften eines Textrahmens abrufen**
Mit Aspose.Slides für .NET können Sie **effektive** Eigenschaften eines Textrahmens abrufen. Zu diesem Zweck wurde die Klasse **TextFrameFormatEffectiveData** in Aspose.Slides hinzugefügt, die effektive Formatierungs‑Eigenschaften des Textrahmens enthält.

Der folgende Code‑Beispiel zeigt, wie man effektive Formatierungs‑Eigenschaften des Textrahmens abruft.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Margins");
	Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
}
```




## **Effektive Eigenschaften eines Textstils abrufen**
Mit Aspose.Slides für .NET können Sie **effektive** Eigenschaften eines Textstils abrufen. Zu diesem Zweck wurde die Klasse **TextStyleEffectiveData** in Aspose.Slides hinzugefügt, die **effektive** Textstil‑Eigenschaften enthält.

Der folgende Code‑Beispiel zeigt, wie man effektive Textstil‑Eigenschaften abruft.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Effective paragraph formatting for style level #" + i + " =");

        Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
    }
}
```



## **Den effektiven Wert der Schriftgröße ermitteln**
Mit Aspose.Slides für .NET können Sie **effektive** Eigenschaften der Schriftgröße ermitteln. Das folgende Beispiel demonstriert, wie sich der effektive Schriftgrößenwert eines Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden.
```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Effective font height just after creation:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Effective font height after setting entire presentation default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Effective font height after setting paragraph default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Effective font height after setting portion #0 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Effective font height after setting portion #1 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```



## **Effektives Füllformat für eine Tabelle ermitteln**
Mit Aspose.Slides für .NET können Sie **effektive** Füllformatierung für verschiedene logische Tabellen‑Teile ermitteln. Zu diesem Zweck wurde das Interface **IFillFormatEffectiveData** in Aspose.Slides hinzugefügt, das effektive Füllformat‑Eigenschaften enthält. Bitte beachten Sie, dass Zellformatierung immer höhere Priorität hat als Zeilenformatierung, eine Zeile höhere Priorität als eine Spalte und eine Spalte höhere Priorität als die gesamte Tabelle.

Somit werden letztlich immer **CellFormatEffectiveData**‑Eigenschaften zum Zeichnen der Tabelle verwendet. Der folgende Code‑Beispiel zeigt, wie man effektive Füllformatierung für verschiedene logische Tabellen‑Teile ermittelt.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	ITable tbl = pres.Slides[0].Shapes[0] as ITable;
	ITableFormatEffectiveData tableFormatEffective = tbl.TableFormat.GetEffective();
	IRowFormatEffectiveData rowFormatEffective = tbl.Rows[0].RowFormat.GetEffective();
	IColumnFormatEffectiveData columnFormatEffective = tbl.Columns[0].ColumnFormat.GetEffective();
	ICellFormatEffectiveData cellFormatEffective = tbl[0, 0].CellFormat.GetEffective();

	IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.FillFormat;
	IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.FillFormat;
	IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.FillFormat;
	IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.FillFormat;
}
```


## **FAQ**

**Wie kann ich erkennen, ob ich ein „Snapshot“ statt eines „Live‑Objekts“ habe, und wann sollte ich effektive Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Schnappschüsse der zu diesem Zeitpunkt berechneten Werte. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern der Layout‑/Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch nur, wenn Sie sie erneut auslesen. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Änderungen erfolgen in den lokalen Formatierungs‑Objekten (Form/Text/3D usw.), und anschließend werden die effektiven Werte erneut abgefragt.

**Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?**

Der effektive Wert wird durch den Standard‑Mechanismus (PowerPoint/Aspose.Slides‑Standardwerte) ermittelt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Schnappschusses.

**Kann ich anhand eines effektiven Schriftwertes erkennen, welche Ebene die Größe oder den Schriftsatz bereitgestellt hat?**

Nicht direkt. EffectiveData gibt den endgültigen Wert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Abschnitt/Absatz/Text‑Rahmen‑Ebene sowie die Textstile auf Layout‑/Master‑/Präsentations‑Ebene, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen Werten aus?**

Weil der lokale Wert letztlich endgültig wurde (es wurde keine höhere Vererbung benötigt). In solchen Fällen stimmt der effektive Wert mit dem lokalen Wert überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen (z. B. zum Ausrichten von Farben, Einzügen oder Größen). Wenn Sie die Formatierung auf einer bestimmten Ebene ändern möchten, bearbeiten Sie die lokalen Eigenschaften und lesen Sie bei Bedarf EffectiveData erneut, um das Ergebnis zu prüfen.