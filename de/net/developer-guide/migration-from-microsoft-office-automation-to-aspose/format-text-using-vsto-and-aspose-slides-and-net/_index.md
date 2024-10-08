---
title: Text formatieren mit VSTO und Aspose.Slides und .NET
type: docs
weight: 30
url: /de/net/format-text-using-vsto-and-aspose-slides-and-net/
---

{{% alert color="primary" %}} 

Manchmal müssen Sie den Text auf Folien programmatisch formatieren. Dieser Artikel zeigt, wie Sie eine Beispielpräsentation mit etwas Text auf der ersten Folie lesen, entweder mit [VSTO](/slides/de/net/format-text-using-vsto-and-aspose-slides-and-net/) oder [Aspose.Slides für .NET](/slides/de/net/format-text-using-vsto-and-aspose-slides-and-net/). Der Code formatiert den Text im dritten Textfeld auf der Folie so, dass er wie der Text im letzten Textfeld aussieht.

{{% /alert %}} 
## **Textformatierung**
Sowohl die VSTO- als auch die Aspose.Slides-Methoden führen die folgenden Schritte aus:

1. Öffnen Sie die Quellpräsentation.
1. Greifen Sie auf die erste Folie zu.
1. Greifen Sie auf das dritte Textfeld zu.
1. Ändern Sie die Formatierung des Textes im dritten Textfeld.
1. Speichern Sie die Präsentation auf der Festplatte.

Die Screenshots unten zeigen die Beispiel-Folie vor und nach der Ausführung des VSTO- und Aspose.Slides für .NET-Codes.

**Die Eingabepräsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO Codebeispiel**
Der folgende Code zeigt, wie Sie den Text auf einer Folie mit VSTO neu formatieren.

**Der mit VSTO neu formatierte Text** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Hinweis: PowerPoint ist ein Namespace, der oben so definiert wurde
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Öffnen Sie die Präsentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Zugriff auf die erste Folie
PowerPoint.Slide slide = pres.Slides[1];

//Zugriff auf die dritte Form
PowerPoint.Shape shp = slide.Shapes[3];

//Ändern Sie die Schriftart des Textes in Verdana und die Höhe auf 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Fett formatieren
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Kursiv formatieren
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Textfarbe ändern
txtRange.Font.Color.RGB = 0x00CC3333;

//Hintergrundfarbe der Form ändern
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Horizontale Neupositionierung
shp.Left -= 70;

//Schreiben Sie die Ausgabe auf die Festplatte
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides für .NET Beispiel**
Um Text mit Aspose.Slides zu formatieren, fügen Sie die Schriftart vor der Formatierung des Textes hinzu.

**Die Ausgabepräsentation, die mit Aspose.Slides erstellt wurde** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //Öffnen Sie die Präsentation
Presentation pres = new Presentation("c:\\source.ppt");

//Zugriff auf die erste Folie
ISlide slide = pres.Slides[0];

//Zugriff auf die dritte Form
IShape shp = slide.Shapes[2];

//Ändern Sie die Schriftart des Textes in Verdana und die Höhe auf 32
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
//Festlegen der Schriftfarbe
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Hintergrundfarbe der Form ändern
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Schreiben Sie die Ausgabe auf die Festplatte
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```