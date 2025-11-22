---
title: "Effektive Formeigenschaften"
type: docs
weight: 50
url: /de/net/shape-effective-properties/
keywords: "Formeigenschaften, Kameraeigenschaften, Light Rig, Fasenform, Textfeld, Textstil, Schrifthöhenwert, Füllformat für Tabelle, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Ermitteln Sie effektive Formeigenschaften in PowerPoint-Präsentationen in C# oder .NET"
---

In diesem Thema besprechen wir **effective** und **local** Eigenschaften. Wenn wir Werte direkt auf diesen Ebenen setzen

1. In Absatz‑Eigenschaften auf der Folie des Absatzes.
1. Im Textstil der Prototypform auf Layout‑ oder Masterfolie (wenn die Textfeldform des Absatzes einen hat).
1. In den globalen Texteinstellungen der Präsentation.

dann werden diese Werte **local** Werte genannt. Auf jeder Ebene können **local** Werte definiert oder weggelassen werden. Aber schließlich, wenn die Anwendung wissen muss, wie der Absatz aussehen soll, verwendet sie **effective** Werte. Sie können **effective** Werte erhalten, indem Sie die **getEffective()**‑Methode des lokalen Formats verwenden.

Das folgende Beispiel zeigt, wie man **effective** Werte erhält.
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




## **Effektive Eigenschaften der Kamera**
Aspose.Slides für .NET ermöglicht Entwicklern, effektive Eigenschaften der Kamera zu erhalten. Zu diesem Zweck wurde die **CameraEffectiveData**‑Klasse in Aspose.Slides hinzugefügt. Die CameraEffectiveData‑Klasse stellt ein unveränderliches Objekt dar, das effektive Kamera‑Eigenschaften enthält. Eine Instanz der **CameraEffectiveData**‑Klasse wird als Teil der **ThreeDFormatEffectiveData**‑Klasse verwendet, die ein Paar effektiver Werte für die ThreeDFormat‑Klasse darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Kamera erhält.
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



## **Effektive Eigenschaften des Light Rig**
Aspose.Slides für .NET ermöglicht Entwicklern, effektive Eigenschaften des Light Rig zu erhalten. Zu diesem Zweck wurde die **LightRigEffectiveData**‑Klasse in Aspose.Slides hinzugefügt. Die LightRigEffectiveData‑Klasse stellt ein unveränderliches Objekt dar, das effektive Light‑Rig‑Eigenschaften enthält. Eine Instanz der **LightRigEffectiveData**‑Klasse wird als Teil der **ThreeDFormatEffectiveData**‑Klasse verwendet, die ein Paar effektiver Werte für die ThreeDFormat‑Klasse darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für das Light Rig erhält.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```



## **Effektive Eigenschaften des Bevel Shape**
Aspose.Slides für .NET ermöglicht Entwicklern, effektive Eigenschaften des Bevel Shape zu erhalten. Zu diesem Zweck wurde die **ShapeBevelEffectiveData**‑Klasse in Aspose.Slides hinzugefügt. Die ShapeBevelEffectiveData‑Klasse stellt ein unveränderliches Objekt dar, das effektive Relief‑Eigenschaften der Form enthält. Eine Instanz der **ShapeBevelEffectiveData**‑Klasse wird als Teil der **ThreeDFormatEffectiveData**‑Klasse verwendet, die ein Paar effektiver Werte für die ThreeDFormat‑Klasse darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für das Bevel Shape erhält.
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




## **Effektive Eigenschaften des Text Frame**
Mit Aspose.Slides für .NET können Sie effektive Eigenschaften des Text Frame erhalten. Zu diesem Zweck wurde die **TextFrameFormatEffectiveData**‑Klasse in Aspose.Slides hinzugefügt, die effektive Formatierungseigenschaften des Text Frames enthält.

Das folgende Codebeispiel zeigt, wie man effektive Formatierungseigenschaften des Text Frames erhält.
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




## **Effektive Eigenschaften des Text Style**
Mit Aspose.Slides für .NET können Sie effektive Eigenschaften des Text Style erhalten. Zu diesem Zweck wurde die **TextStyleEffectiveData**‑Klasse in Aspose.Slides hinzugefügt, die effektive Eigenschaften des Text Styles enthält.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften des Text Styles erhält.
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



## **Effektiver Schrifthöhenwert**
Mit Aspose.Slides für .NET können Sie effektive Eigenschaften der Schrifthöhe erhalten. Hier ist der Code, der zeigt, wie sich der effektive Schrifthöhenwert eines Abschnitts ändert, nachdem auf verschiedenen Ebenen der Präsentationsstruktur lokale Schrifthöhenwerte gesetzt wurden.
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



## **Effektives Füllformat für Tabelle**
Mit Aspose.Slides für .NET können Sie effektive Füllformatierung für verschiedene logische Teile einer Tabelle erhalten. Zu diesem Zweck wurde das **IFillFormatEffectiveData**‑Interface in Aspose.Slides hinzugefügt, das effektive Füllformatierungseigenschaften enthält. Bitte beachten Sie, dass die Zellenformatierung stets höhere Priorität hat als die Zeilenformatierung, eine Zeile hat höhere Priorität als eine Spalte und eine Spalte höher als die gesamte Tabelle.

Schließlich werden immer die **CellFormatEffectiveData**‑Eigenschaften verwendet, um die Tabelle zu zeichnen. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierung für verschiedene logische Tabellenteile erhält.
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

**Wie kann ich erkennen, ob ich einen "snapshot" statt eines "live-object" erhalten habe, und wann sollte ich effektive Eigenschaften erneut lesen?**

EffectiveData‑Objekte sind unveränderliche Snapshots der zum Zeitpunkt des Aufrufs berechneten Werte. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern der Layout-/Master-Folien auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut gelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Nehmen Sie Änderungen an den lokalen Formatierungsobjekten (Form/Text/3D usw.) vor und holen Sie anschließend die effektiven Werte erneut.

**Was passiert, wenn eine Eigenschaft weder auf Formenebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?**

Der effektive Wert wird durch den Standard‑Mechanismus (PowerPoint/Aspose.Slides‑Standardwerte) bestimmt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe oder Schriftart bereitgestellt hat?**

Nicht direkt. EffectiveData liefert den endgültigen Wert. Um die Quelle zu finden, prüfen Sie die lokalen Werte im Abschnitt/Absatz/Textfeld und die Textstile im Layout/Master/der Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich final ist (keine Vererbung von höheren Ebenen notwendig war). In solchen Fällen entspricht der effektive Wert dem lokalen.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerendert“ Ergebnis nach Anwendung aller Vererbungen benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie die Formatierung auf einer bestimmten Ebene ändern müssen, passen Sie die lokalen Eigenschaften an und lesen Sie gegebenenfalls EffectiveData erneut ein, um das Ergebnis zu überprüfen.