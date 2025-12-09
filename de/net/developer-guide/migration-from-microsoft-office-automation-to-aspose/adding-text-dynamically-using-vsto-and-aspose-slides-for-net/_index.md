---
title: Text dynamisch hinzufügen mit VSTO und Aspose.Slides für .NET
linktitle: Text dynamisch hinzufügen
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
description: "Sehen Sie, wie Sie von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und dynamischen Text zu PowerPoint (PPT, PPTX)-Präsentationen in C# hinzufügen."
---

{{% alert color="primary" %}} 

Eine häufige Aufgabe, die Entwickler erledigen müssen, ist das Hinzufügen von Text zu Folien dynamisch. Dieser Artikel zeigt Codebeispiele für das dynamische Hinzufügen von Text mithilfe von [VSTO](/slides/de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) und [Aspose.Slides for .NET](/slides/de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Text dynamisch hinzufügen**
Beide Methoden folgen diesen Schritten:

1. Eine Präsentation erstellen.
1. Eine leere Folie hinzufügen.
1. Ein Textfeld hinzufügen.
1. Text festlegen.
1. Die Präsentation speichern.
## **VSTO-Codebeispiel**
Die unten stehenden Code‑Snippets erzeugen eine Präsentation mit einer einfachen Folie und einem Textstring darauf.

**Die Präsentation, wie in VSTO erstellt** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//Hinweis: PowerPoint ist ein Namespace, der oben wie folgt definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Eine Präsentation erstellen
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




## **Aspose.Slides für .NET Beispiel**
Die unten stehenden Code‑Snippets verwenden Aspose.Slides, um eine Präsentation mit einer einfachen Folie und einem Textstring darauf zu erstellen.

**Die Präsentation, wie mit Aspose.Slides für .NET erstellt** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//Eine Präsentation erstellen
Presentation pres = new Presentation();

//Leere Folie wird standardmäßig hinzugefügt, wenn Sie
//eine Präsentation über den Standardkonstruktor erstellen
//Daher müssen wir keine leere Folie hinzufügen
ISlide sld = pres.Slides[1];

//Ein Textfeld hinzufügen
//Um es hinzuzufügen, fügen wir zuerst ein Rechteck hinzu
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Linie ausblenden
shp.LineFormat.Style = LineStyle.NotDefined;

//Dann fügen wir ein Textfeld darin hinzu
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Text festlegen
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Ausgabe auf die Festplatte schreiben
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
