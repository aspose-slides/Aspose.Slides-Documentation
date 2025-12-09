---
title: Dynamisches Hinzufügen von Text mit VSTO und Aspose.Slides für .NET
linktitle: Dynamisches Hinzufügen von Text
type: docs
weight: 20
url: /de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- Text hinzufügen
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie von Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und dynamischen Text zu PowerPoint (PPT, PPTX)-Präsentationen in C# hinzufügen."
---

{{% alert color="primary" %}} 

Eine häufige Aufgabe, die Entwickler erledigen müssen, ist das dynamische Hinzufügen von Text zu Folien. Dieser Artikel zeigt Code‑Beispiele zum dynamischen Hinzufügen von Text mit [VSTO](/slides/de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) und [Aspose.Slides for .NET](/slides/de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Dynamisches Hinzufügen von Text**
Beide Methoden folgen diesen Schritten:

1. Eine Präsentation erstellen.
1. Eine leere Folie hinzufügen.
1. Ein Textfeld hinzufügen.
1. Text festlegen.
1. Die Präsentation schreiben.
## **VSTO‑Code‑Beispiel**
Die nachstehenden Code‑Snippets erzeugen eine Präsentation mit einer einfachen Folie und einem Textstring darauf.

**Die in VSTO erstellte Präsentation** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//Hinweis: PowerPoint ist ein Namespace, das oben wie folgt definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Erstelle eine Präsentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Hole das leere Folienlayout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Füge eine leere Folie hinzu
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Füge Text hinzu
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Setze den Text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Schreibe die Ausgabe auf die Festplatte
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




## **Aspose.Slides für .NET‑Beispiel**
Die nachstehenden Code‑Snippets verwenden Aspose.Slides, um eine Präsentation mit einer einfachen Folie und einem Textstring darauf zu erstellen.

**Die mit Aspose.Slides für .NET erstellte Präsentation** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//Präsentation erstellen
Presentation pres = new Presentation();

//Leere Folie wird standardmäßig hinzugefügt, wenn Sie erstellen
//die Präsentation über den Standardkonstruktor
//Daher müssen wir keine leere Folie hinzufügen
ISlide sld = pres.Slides[1];

//Textfeld hinzufügen
//Um es hinzuzufügen, fügen wir zuerst ein Rechteck hinzu
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Hide its line
shp.LineFormat.Style = LineStyle.NotDefined;

//Then add a textframe inside it
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Set a text
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Write the output to disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
