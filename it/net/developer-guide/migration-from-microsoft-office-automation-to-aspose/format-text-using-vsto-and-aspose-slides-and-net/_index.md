---
title: Formattare il testo usando VSTO e Aspose.Slides per .NET
linktitle: Formattare il testo
type: docs
weight: 30
url: /it/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- formattare il testo
- migrazione
- VSTO
- automazione Office
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Migra dall'automazione di Microsoft Office ad Aspose.Slides per .NET e formatta il testo nelle presentazioni PowerPoint (PPT, PPTX) con controllo preciso."
---
{{% alert color="info" %}} 

A volte, è necessario formattare il testo nelle diapositive in modo programmatico. Questo articolo mostra come leggere una presentazione di esempio con del testo sulla prima diapositiva utilizzando sia [VSTO](/slides/it/net/format-text-using-vsto-and-aspose-slides-and-net/) che [Aspose.Slides for .NET](/slides/it/net/format-text-using-vsto-and-aspose-slides-and-net/). Il codice formatta il testo nella terza casella di testo sulla diapositiva in modo che assomigli al testo nell'ultima casella di testo.

{{% /alert %}} 
## **Formattare il testo**
Sia i metodi VSTO sia quelli Aspose.Slides seguono i seguenti passaggi:

1. Aprire la presentazione di origine.
1. Accedere alla prima diapositiva.
1. Accedere alla terza casella di testo.
1. Modificare la formattazione del testo nella terza casella di testo.
1. Salvare la presentazione su disco.

Gli screenshot seguenti mostrano la diapositiva di esempio prima e dopo l'esecuzione del codice VSTO e Aspose.Slides per .NET.

**La presentazione di input** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Esempio di codice VSTO**
Il codice seguente mostra come riformattare il testo su una diapositiva usando VSTO.

**Il testo riformattato con VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Nota: PowerPoint è uno spazio dei nomi che è stato definito sopra in questo modo
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Apri la presentazione
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Accedi alla prima diapositiva
PowerPoint.Slide slide = pres.Slides[1];

//Accedi alla terza forma
PowerPoint.Shape shp = slide.Shapes[3];

//Cambia il font del suo testo in Verdana e l'altezza a 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Rendilo in grassetto
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Rendilo in corsivo
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Cambia il colore del testo
txtRange.Font.Color.RGB = 0x00CC3333;

//Cambia il colore di sfondo della forma
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Riposizionalo orizzontalmente
shp.Left -= 70;

//Scrivi l'output su disco
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Esempio Aspose.Slides per .NET**
Per formattare il testo con Aspose.Slides, aggiungere il carattere prima di formattare il testo.

**La presentazione di output creata con Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //Apri la presentazione
Presentation pres = new Presentation("source.ppt");

//Access the first slide
ISlide slide = pres.Slides[0];

//Access the third shape
IShape shp = slide.Shapes[2];

//Change its text's font to Verdana and height to 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Rendila in grassetto
port.PortionFormat.FontBold = NullableBool.True;

//Rendila in corsivo
port.PortionFormat.FontItalic = NullableBool.True;

//Cambia il colore del testo
//Imposta il colore del font
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Cambia il colore di sfondo della forma
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Scrivi l'output su disco
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```