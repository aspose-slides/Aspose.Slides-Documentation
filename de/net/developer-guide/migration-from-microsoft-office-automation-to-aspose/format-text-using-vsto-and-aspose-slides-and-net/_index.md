---
title: Text mit VSTO und Aspose.Slides für .NET formatieren
linktitle: Text formatieren
type: docs
weight: 30
url: /de/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- Text formatieren
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Migrieren Sie von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET und formatieren Sie Text in PowerPoint‑Präsentationen (PPT, PPTX) mit präziser Steuerung."
---

{{% alert color="primary" %}} 

Manchmal müssen Sie den Text auf Folien programmgesteuert formatieren. Dieser Artikel zeigt, wie man eine Beispielpräsentation mit etwas Text auf der ersten Folie entweder mit [VSTO](/slides/de/net/format-text-using-vsto-and-aspose-slides-and-net/) und [Aspose.Slides for .NET](/slides/de/net/format-text-using-vsto-and-aspose-slides-and-net/) einliest. Der Code formatiert den Text im dritten Textfeld auf der Folie so, dass er dem Text im letzten Textfeld entspricht.

{{% /alert %}} 
## **Text formatieren**
Sowohl die VSTO- als auch die Aspose.Slides-Methoden führen die folgenden Schritte aus:

1. Öffnen Sie die Quellpräsentation.
1. Greifen Sie auf die erste Folie zu.
1. Greifen Sie auf das dritte Textfeld zu.
1. Ändern Sie die Formatierung des Textes im dritten Textfeld.
1. Speichern Sie die Präsentation auf dem Datenträger.

Die Screenshots unten zeigen die Beispielfolie vor und nach der Ausführung des VSTO- und Aspose.Slides for .NET-Codes.

**Die Eingabepräsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO-Codebeispiel**
Der folgende Code zeigt, wie man Text auf einer Folie mit VSTO neu formatiert.

**Der mit VSTO neu formatierte Text** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//Hinweis: PowerPoint ist ein Namensraum, der oben wie folgt definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
 //Öffnet die Präsentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Greift auf die erste Folie zu
PowerPoint.Slide slide = pres.Slides[1];

//Greift auf das dritte Shape zu
PowerPoint.Shape shp = slide.Shapes[3];

//Ändert die Schriftart des Textes zu Verdana und die Größe auf 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Fett formatieren
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Kursiv formatieren
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ändert die Textfarbe
txtRange.Font.Color.RGB = 0x00CC3333;

//Ändert die Hintergrundfarbe des Shapes
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Verschiebt es horizontal
shp.Left -= 70;

//Schreibt die Ausgabe auf die Festplatte
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```





### **Aspose.Slides for .NET-Beispiel**
Um Text mit Aspose.Slides zu formatieren, fügen Sie die Schriftart hinzu, bevor Sie den Text formatieren.

**Die mit Aspose.Slides erstellte Ausgabepäsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //Öffnet die Präsentation
Presentation pres = new Presentation("c:\\source.ppt");

//Greift auf die erste Folie zu
ISlide slide = pres.Slides[0];

//Greift auf das dritte Shape zu
IShape shp = slide.Shapes[2];

//Ändert die Schriftart des Textes zu Verdana und die Höhe auf 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Fett formatieren
port.PortionFormat.FontBold = NullableBool.True;

//Kursiv formatieren
port.PortionFormat.FontItalic = NullableBool.True;

//Ändert die Textfarbe
//Setzt die Schriftfarbe
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Ändert die Hintergrundfarbe des Shapes
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Schreibt die Ausgabe auf die Festplatte
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
