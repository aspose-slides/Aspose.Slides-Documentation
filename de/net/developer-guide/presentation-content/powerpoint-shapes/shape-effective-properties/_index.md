---
title: Formeffektive Eigenschaften aus Präsentationen in .NET abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/net/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtanlage
- Fasenform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides for .NET effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---

In diesem Thema behandeln wir **effektive** und **lokale** Eigenschaften. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In den Eigenschaften eines Abschnitts auf dessen Folie.
1. Im Textstil der Prototyp‑Form im Layout oder Master‑Folien (falls die Textfeld‑Form des Abschnitts einen hat).
1. In den globalen Texteinstellungen der Präsentation.

dann werden diese Werte **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn die Anwendung jedoch wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können **effektive** Werte erhalten, indem Sie die Methode **getEffective()** aus dem lokalen Format verwenden.

Das folgende Beispiel zeigt, wie man **effektive** Werte abruft.
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




## **Effektive Eigenschaften der Kamera abrufen**
Aspose.Slides für .NET ermöglicht Entwicklern, **effektive** Eigenschaften der Kamera zu erhalten. Zu diesem Zweck wurde die Klasse **CameraEffectiveData** zu Aspose.Slides hinzugefügt. Die Klasse CameraEffectiveData repräsentiert ein unveränderliches Objekt, das **effektive** Kameraeigenschaften enthält. Eine Instanz der Klasse **CameraEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar aus **effektiven** Werten für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man **effektive** Eigenschaften für die Kamera abruft.
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



## **Effektive Eigenschaften der Lichtanlage abrufen**
Aspose.Slides für .NET ermöglicht Entwicklern, **effektive** Eigenschaften der Lichtanlage zu erhalten. Zu diesem Zweck wurde die Klasse **LightRigEffectiveData** zu Aspose.Slides hinzugefügt. Die Klasse LightRigEffectiveData repräsentiert ein unveränderliches Objekt, das **effektive** Eigenschaften der Lichtanlage enthält. Eine Instanz der Klasse **LightRigEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar aus **effektiven** Werten für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man **effektive** Eigenschaften für die Lichtanlage abruft.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```



## **Effektive Eigenschaften der Fasenform abrufen**
Aspose.Slides für .NET ermöglicht Entwicklern, **effektive** Eigenschaften der Fasenform zu erhalten. Zu diesem Zweck wurde die Klasse **ShapeBevelEffectiveData** zu Aspose.Slides hinzugefügt. Die Klasse ShapeBevelEffectiveData repräsentiert ein unveränderliches Objekt, das **effektive** Eigenschaften der Formoberflächenrelief‑Attribute enthält. Eine Instanz der Klasse **ShapeBevelEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar aus **effektiven** Werten für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man **effektive** Eigenschaften für die Fasenform abruft.
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




## **Effektive Eigenschaften des Textfelds abrufen**
Mit Aspose.Slides für .NET können Sie **effektive** Eigenschaften des Textfelds erhalten. Zu diesem Zweck wurde die Klasse **TextFrameFormatEffectiveData** zu Aspose.Slides hinzugefügt, die **effektive** Formatierungseigenschaften des Textfelds enthält.

Das folgende Codebeispiel zeigt, wie man **effektive** Formatierungseigenschaften des Textfelds abruft.
{{49854a88-4327-40f7-b937-0b5209eda4e4}>



## **Effektive Eigenschaften des Textstils abrufen**
Mit Aspose.Slides für .NET können Sie **effektive** Eigenschaften des Textstils erhalten. Zu diesem Zweck wurde die Klasse **TextStyleEffectiveData** zu Aspose.Slides hinzugefügt, die **effektive** Textstileigenschaften enthält.

Das folgende Codebeispiel zeigt, wie man **effektive** Textstileigenschaften abruft.
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



## **Effektiven Schriftgrößenwert abrufen**
Mit Aspose.Slides für .NET können Sie **effektive** Eigenschaften der Schriftgröße erhalten. Hier wird demonstriert, wie sich der **effektive** Schriftgrößenwert eines Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden.
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



## **Effektives Füllformat für Tabellen abrufen**
Mit Aspose.Slides für .NET können Sie **effektive** Füllformatierungen für verschiedene logische Tabellenteile erhalten. Zu diesem Zweck wurde das Interface **IFillFormatEffectiveData** zu Aspose.Slides hinzugefügt, das **effektive** Füllformatierungseigenschaften enthält. Bitte beachten Sie, dass die Zellformatierung immer höhere Priorität hat als die Zeilenformatierung, eine Zeile höhere Priorität als eine Spalte und eine Spalte höhere als die gesamte Tabelle.

Letztlich werden immer die **CellFormatEffectiveData**‑Eigenschaften zum Zeichnen der Tabelle verwendet. Das folgende Codebeispiel zeigt, wie man **effektive** Füllformatierung für verschiedene logische Tabellenteile abruft.
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

**Wie kann ich erkennen, dass ich einen „Snapshot“ und kein „Live‑Objekt“ erhalten habe, und wann sollte ich **effektive** Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Snapshots der zum Aufrufzeitpunkt berechneten Werte. Wenn Sie lokale oder vererbte Einstellungen der Form ändern, rufen Sie die **effektiven** Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern des Layouts/der Master‑Folien auf bereits abgerufene **effektive** Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut ausgelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Layout‑ oder Master‑Änderung erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Änderungen erfolgen in den lokalen Formatierungsobjekten (Form/Text/3D usw.), und anschließend können Sie die **effektiven** Werte erneut abfragen.

**Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?**

Der **effektive** Wert wird durch den Standard‑Mechanismus (PowerPoint/Aspose.Slides‑Standardwerte) bestimmt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich aus einem **effektiven** Schriftwert erkennen, welche Ebene die Größe oder den Schriftschnitt bereitgestellt hat?**

Nicht direkt. EffectiveData liefert nur den finalen Wert. Um die Quelle zu finden, prüfen Sie die lokalen Werte auf Abschnitt/Absatz/Textfeld‑Ebene sowie die Textstile im Layout/Master/Präsentation, um die erste explizite Definition zu ermitteln.

**Warum sehen **effektive** Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich endgültig wurde (keine höhere Vererbung notwendig war). In solchen Fällen stimmt der **effektive** Wert mit dem lokalen überein.

**Wann sollte ich **effektive** Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen (z. B. zum Ausrichten von Farben, Einzügen oder Größen). Wenn Sie die Formatierung auf einer bestimmten Ebene ändern wollen, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die **effektiven** Daten erneut, um das Ergebnis zu überprüfen.