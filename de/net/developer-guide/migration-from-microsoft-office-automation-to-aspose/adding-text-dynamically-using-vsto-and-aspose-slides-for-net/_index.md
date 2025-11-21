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
description: "Erfahren Sie, wie Sie von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und dynamischen Text zu PowerPoint-Präsentationen (PPT, PPTX) in C# hinzufügen."
---

{{% alert color="primary" %}} 

Eine häufige Aufgabe, die Entwickler erledigen müssen, ist das dynamische Hinzufügen von Text zu Folien. Dieser Artikel zeigt Codebeispiele für das dynamische Hinzufügen von Text mithilfe von [VSTO](/slides/de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) und [Aspose.Slides for .NET](/slides/de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Adding Text Dynamically**
Beide Methoden folgen diesen Schritten:

1. Eine Präsentation erstellen.
1. Eine leere Folie hinzufügen.
1. Ein Textfeld hinzufügen.
1. Text festlegen.
1. Die Präsentation speichern.
## **VSTO Code Example**
Die nachfolgenden Code‑Snippets erzeugen eine Präsentation mit einer einfachen Folie und einem Text darauf.

**The presentation as created in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//Hinweis: PowerPoint ist ein Namespace, der oben wie folgt definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Präsentation erstellen
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Leeres Folienlayout abrufen
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Leere Folie hinzufügen
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Text hinzufügen
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Text festlegen
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Ausgabe auf Datenträger schreiben
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




## **Aspose.Slides for .NET Example**
Die nachfolgenden Code‑Snippets verwenden Aspose.Slides, um eine Präsentation mit einer einfachen Folie und einem Text darauf zu erstellen.

**The presentation as created using Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//Präsentation erstellen
Presentation pres = new Presentation();

//Leere Folie wird standardmäßig hinzugefügt, wenn Sie erstellen
//Präsentation über den Standardkonstruktor
//Daher müssen wir keine leere Folie hinzufügen
ISlide sld = pres.Slides[1];

//Textbox hinzufügen
//Um sie hinzuzufügen, fügen wir zunächst ein Rechteck hinzu
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Linie ausblenden
shp.LineFormat.Style = LineStyle.NotDefined;

//Dann ein Textfeld darin hinzufügen
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Text festlegen
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Ausgabe auf Datenträger schreiben
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
