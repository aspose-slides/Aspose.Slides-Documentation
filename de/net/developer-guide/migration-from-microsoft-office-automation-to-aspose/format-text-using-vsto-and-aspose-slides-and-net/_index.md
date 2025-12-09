---
title: Text formatieren mit VSTO und Aspose.Slides für .NET
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
description: "Migrieren Sie von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET und formatieren Sie Text in PowerPoint (PPT, PPTX)-Präsentationen mit präziser Kontrolle."
---

{{% alert color="primary" %}} 

Manchmal müssen Sie den Text in Folien programmgesteuert formatieren. Dieser Artikel zeigt, wie man eine Beispielpräsentation mit etwas Text auf der ersten Folie entweder mit [VSTO](/slides/de/net/format-text-using-vsto-and-aspose-slides-and-net/) und [Aspose.Slides for .NET](/slides/de/net/format-text-using-vsto-and-aspose-slides-and-net/) liest. Der Code formatiert den Text im dritten Textfeld auf der Folie, sodass er wie der Text im letzten Textfeld aussieht.

{{% /alert %}} 
## **Text formatieren**
Sowohl die VSTO- als auch die Aspose.Slides-Methoden führen die folgenden Schritte aus:

1. Öffnen Sie die Quellpräsentation.
1. Greifen Sie auf die erste Folie zu.
1. Greifen Sie auf das dritte Textfeld zu.
1. Ändern Sie die Formatierung des Textes im dritten Textfeld.
1. Speichern Sie die Präsentation auf dem Datenträger.

Die Screenshots unten zeigen die Beispiel‑Folie vor und nach der Ausführung des VSTO‑ und Aspose.Slides‑für‑.NET‑Codes.

**Die Eingabepäsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO-Codebeispiel**
Der folgende Code zeigt, wie man Text auf einer Folie mit VSTO neu formatiert.

**Der mit VSTO neu formatierte Text** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//Hinweis: PowerPoint ist ein Namespace, der oben wie folgt definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Öffne die Präsentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Greife auf die erste Folie zu
PowerPoint.Slide slide = pres.Slides[1];

//Greife auf das dritte Shape zu
PowerPoint.Shape shp = slide.Shapes[3];

//Ändere die Schriftart des Textes zu Verdana und die Höhe auf 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Mache es fett
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Stelle es kursiv
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ändere die Textfarbe
txtRange.Font.Color.RGB = 0x00CC3333;

//Ändere die Hintergrundfarbe des Shapes
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Positioniere es horizontal neu
shp.Left -= 70;

//Schreibe die Ausgabe auf die Festplatte
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```





### **Aspose.Slides für .NET‑Beispiel**
Um Text mit Aspose.Slides zu formatieren, fügen Sie die Schriftart vor dem Formatieren des Textes hinzu.

**Die mit Aspose.Slides erstellte Ausgabepäsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //Öffne die Präsentation
Presentation pres = new Presentation("c:\\source.ppt");

//Greife auf die erste Folie zu
ISlide slide = pres.Slides[0];

//Greife auf das dritte Shape zu
IShape shp = slide.Shapes[2];

//Ändere die Schriftart des Textes zu Verdana und die Höhe auf 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Fett formatieren
port.PortionFormat.FontBold = NullableBool.True;

//Kursiv formatieren
port.PortionFormat.FontItalic = NullableBool.True;

//Textfarbe ändern
//Schriftfarbe festlegen
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Shape-Hintergrundfarbe ändern
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Ausgabe auf die Festplatte schreiben
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
