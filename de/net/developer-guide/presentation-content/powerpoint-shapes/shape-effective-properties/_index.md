---
title: Effektive Eigenschaften von Formen
type: docs
weight: 50
url: /net/shape-effective-properties/
keywords: "Formeigenschaften, Kamer Eigenschaften, Licht Rig, Fasenform, Textfeld, Textstil, Schriftgrößewert, Füllformat für Tabelle, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Erhalten Sie effektive Eigenschaften von Formen in PowerPoint-Präsentationen in C# oder .NET"
---

In diesem Thema werden wir **effektive** und **lokale** Eigenschaften diskutieren. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Portionseigenschaften auf der Folie der Portion.
1. Im Prototypformtextstil auf dem Layout oder der Masterfolie (wenn das Textfeldform der Portion eines hat).
1. In den globalen Texteinstellungen der Präsentation.

dann werden diese Werte als **lokale** Werte bezeichnet. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Aber letztendlich, wenn es darum geht, dass die Anwendung wissen muss, wie die Portion aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte abrufen, indem Sie die Methode **getEffective()** des lokalen Formats verwenden.

Das folgende Beispiel zeigt, wie man effektive Werte erhält.

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
Aspose.Slides für .NET ermöglicht Entwicklern, effektive Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde die Klasse **CameraEffectiveData** in Aspose.Slides hinzugefügt. Die KameraEffectiveData-Klasse stellt ein unveränderliches Objekt dar, das die effektiven Kameraeigenschaften enthält. Eine Instanz der Klasse **CameraEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein effektives Wertepaar für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Kamera erhält.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effektive Kameraeigenschaften =");
	Console.WriteLine("Typ: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Sichtfeld: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```


## **Effektive Eigenschaften des Licht Rigs abrufen**
Aspose.Slides für .NET ermöglicht Entwicklern, effektive Eigenschaften des Licht Rigs abzurufen. Zu diesem Zweck wurde die Klasse **LightRigEffectiveData** in Aspose.Slides hinzugefügt. Die LightRigEffectiveData-Klasse stellt ein unveränderliches Objekt dar, das die effektiven Eigenschaften des Licht Rigs enthält. Eine Instanz der Klasse **LightRigEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein effektives Wertepaar für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für das Licht Rig erhält.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effektive Eigenschaften des Licht Rigs =");
	Console.WriteLine("Typ: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Richtung: " + threeDEffectiveData.LightRig.Direction);
}
```


## **Effektive Eigenschaften der Fasenform abrufen**
Aspose.Slides für .NET ermöglicht Entwicklern, effektive Eigenschaften der Fasenform abzurufen. Zu diesem Zweck wurde die Klasse **ShapeBevelEffectiveData** in Aspose.Slides hinzugefügt. Die ShapeBevelEffectiveData-Klasse stellt ein unveränderliches Objekt dar, das die effektiven Relief-Eigenschaften der Form enthält. Eine Instanz der Klasse **ShapeBevelEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein effektives Wertepaar für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Fasenform erhält.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effektive Relief-Eigenschaften der oberen Fläche der Form =");
	Console.WriteLine("Typ: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Breite: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Höhe: " + threeDEffectiveData.BevelTop.Height);
}
```



## **Effektive Eigenschaften des Textfelds abrufen**
Mit Aspose.Slides für .NET können Sie effektive Eigenschaften des Textfelds abrufen. Zu diesem Zweck wurde die Klasse **TextFrameFormatEffectiveData** in Aspose.Slides hinzugefügt, die effektive Formatierungseigenschaften des Textfelds enthält.

Das folgende Codebeispiel zeigt, wie man effektive Formatierungseigenschaften des Textfelds erhält.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Anker-Typ: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Automatische Anpassungsart: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Text vertikaler Typ: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Ränder");
	Console.WriteLine("   Links: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Oben: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Rechts: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Unten: " + effectiveTextFrameFormat.MarginBottom);
}
```



## **Effektive Eigenschaften des Textstils abrufen**
Mit Aspose.Slides für .NET können Sie effektive Eigenschaften des Textstils abrufen. Zu diesem Zweck wurde die Klasse **TextStyleEffectiveData** in Aspose.Slides hinzugefügt, die effektive Eigenschaften des Textstils enthält.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften des Textstils erhält.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Effektive Absatzformatierung für Stil-Ebene #" + i + " =");

        Console.WriteLine("Tiefe: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Einzug: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Ausrichtung: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Schriftausrichtung: " + effectiveStyleLevel.FontAlignment);
    }
}

```


## **Effektiven Schriftgrößewert abrufen**
Mit Aspose.Slides für .NET können Sie effektive Eigenschaften der Schriftgröße abrufen. Hier ist der Code, der zeigt, wie sich der effektive Schriftgrößewert der Portion ändert, nachdem lokale Schriftgrößewerte auf verschiedenen Präsentationsstruktur-Ebenen festgelegt wurden.

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Beispieltext mit erster Portion");
    IPortion portion1 = new Portion(" und zweiter Portion.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Effektive Schriftgröße direkt nach der Erstellung:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Effektive Schriftgröße nach Festlegung der standardmäßigen Schriftgröße der gesamten Präsentation:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Effektive Schriftgröße nach Festlegung der standardmäßigen Schriftgröße des Absatzes:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Effektive Schriftgröße nach Festlegung der Schriftgröße von Portion #0:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Effektive Schriftgröße nach Festlegung der Schriftgröße von Portion #1:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **Effektives Füllformat für Tabellen abrufen**
Mit Aspose.Slides für .NET können Sie effektive Füllformatierungen für unterschiedliche logische Teile der Tabelle abrufen. Zu diesem Zweck wurde das Interface **IFillFormatEffectiveData** in Aspose.Slides hinzugefügt, das effektive Füllformatierungseigenschaften enthält. Bitte beachten Sie, dass die Zellformatierung immer eine höhere Priorität hat als die Zeilenformatierung, eine Zeile eine höhere Priorität hat als eine Spalte und eine Spalte eine höhere Priorität hat als die gesamte Tabelle.

Die Eigenschaften **CellFormatEffectiveData** werden immer verwendet, um die Tabelle zu zeichnen. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierungen für verschiedene logische Teile der Tabelle erhält.

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