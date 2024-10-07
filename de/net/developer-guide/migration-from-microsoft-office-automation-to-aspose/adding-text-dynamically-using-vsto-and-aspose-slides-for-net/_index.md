---
title: Dynamisches Hinzufügen von Text mit VSTO und Aspose.Slides für .NET
type: docs
weight: 20
url: /net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
---

{{% alert color="primary" %}} 

Eine gängige Aufgabe, die Entwickler zu erledigen haben, besteht darin, Text dynamisch zu Folien hinzuzufügen. Dieser Artikel zeigt Codebeispiele zum dynamischen Hinzufügen von Text mit [VSTO](/slides/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) und [Aspose.Slides für .NET](/slides/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Dynamisches Hinzufügen von Text**
Beide Methoden folgen diesen Schritten:

1. Eine Präsentation erstellen.
1. Eine leere Folie hinzufügen.
1. Ein Textfeld hinzufügen.
1. Einige Texte festlegen.
1. Die Präsentation speichern.
## **VSTO-Codebeispiel**
Die folgenden Codeausschnitte ergeben eine Präsentation mit einer einfachen Folie und einem Textstring darauf.

**Die in VSTO erstellte Präsentation** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Hinweis: PowerPoint ist ein Namespace, der oben so definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Eine Präsentation erstellen
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Das Layout der leeren Folie erhalten
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Eine leere Folie hinzufügen
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Text hinzufügen
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Einen Text festlegen
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text dynamisch hinzugefügt";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Die Ausgabe auf die Festplatte schreiben
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Aspose.Slides für .NET-Beispiel**
Die folgenden Codeausschnitte verwenden Aspose.Slides, um eine Präsentation mit einer einfachen Folie und einem Textstring darauf zu erstellen.

**Die in Aspose.Slides für .NET erstellte Präsentation** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Eine Präsentation erstellen
Presentation pres = new Presentation();

//Eine leere Folie wird standardmäßig hinzugefügt, wenn Sie
//eine Präsentation aus dem Standardkonstruktor erstellen
//Deshalb müssen wir keine leere Folie hinzufügen
ISlide sld = pres.Slides[1];

//Ein Textfeld hinzufügen
//Um es hinzuzufügen, fügen wir zuerst ein Rechteck hinzu
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Seine Rahmenlinie ausblenden
shp.LineFormat.Style = LineStyle.NotDefined;

//Dann fügen wir einen Textrahmen darin hinzu
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Einen Text festlegen
tf.Text = "Text dynamisch hinzugefügt";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Die Ausgabe auf die Festplatte schreiben
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```