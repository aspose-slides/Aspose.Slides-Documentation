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
description: "Sehen Sie, wie Sie von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und dynamischen Text zu PowerPoint-Präsentationen (PPT, PPTX) in C# hinzufügen."
---
{{% alert color="info" %}} 
Eine häufige Aufgabe, die Entwickler erledigen müssen, ist das dynamische Hinzufügen von Text zu Folien. Dieser Artikel zeigt Codebeispiele für das dynamische Hinzufügen von Text mithilfe von [VSTO](/slides/de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) und [Aspose.Slides for .NET](/slides/de/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).
{{% /alert %}} 
## **Dynamisches Hinzufügen von Text**
Both methods follow these steps:

1. Eine Präsentation erstellen.
1. Eine leere Folie hinzufügen.
1. Ein Textfeld hinzufügen.
1. Text festlegen.
1. Die Präsentation speichern.
## **VSTO-Codebeispiel**
Die nachstehenden Code Snippets erzeugen eine Präsentation mit einer einfachen Folie und einem Text darauf.

**Die Präsentation, wie sie in VSTO erstellt wurde** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Hinweis: PowerPoint ist ein Namespace, der oben wie folgt definiert wurde
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

//Setze Text
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

## **Aspose.Slides for .NET Beispiel**
Die nachstehenden Code Snippets verwenden Aspose.Slides, um eine Präsentation mit einer einfachen Folie und einem Text darauf zu erstellen.

**Die Präsentation, wie sie mit Aspose.Slides for .NET erstellt wurde** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Erstelle eine Präsentation
Presentation pres = new Presentation();

//Leere Folie wird standardmäßig hinzugefügt, wenn Sie erstellen
//eine Präsentation mit dem Standardkonstruktor
//Daher müssen wir keine leere Folie hinzufügen
ISlide sld = pres.Slides[1];

//Füge ein Textfeld hinzu
//Um es hinzuzufügen, fügen wir zuerst ein Rechteck hinzu
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Verstecke die Linie
shp.LineFormat.Style = LineStyle.NotDefined;

//Dann fügen wir einen Textrahmen darin ein
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Setze Text
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Schreibe die Ausgabe auf die Festplatte
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```