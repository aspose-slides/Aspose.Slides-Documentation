---
title: Aggiungere testo in modo dinamico usando VSTO e Aspose.Slides per .NET
linktitle: Aggiungere testo in modo dinamico
type: docs
weight: 20
url: /it/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- aggiungere testo
- migrazione
- VSTO
- automazione Office
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come migrare dall'automazione Microsoft Office a Aspose.Slides per .NET e aggiungere testo dinamico alle presentazioni PowerPoint (PPT, PPTX) in C#."
---
{{% alert color="primary" %}} 
Un'attività comune che gli sviluppatori devono svolgere è aggiungere testo alle diapositive in modo dinamico. Questo articolo mostra esempi di codice per aggiungere testo dinamicamente utilizzando [VSTO](/slides/it/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) e [Aspose.Slides for .NET](/slides/it/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).
{{% /alert %}} 
## **Aggiungere testo dinamicamente**
Entrambi i metodi seguono questi passaggi:

1. Creare una presentazione.
1. Aggiungere una diapositiva vuota.
1. Aggiungere una casella di testo.
1. Impostare del testo.
1. Scrivere la presentazione.
## **Esempio di codice VSTO**
I frammenti di codice qui sotto producono una presentazione con una diapositiva semplice e una stringa di testo.

**La presentazione creata in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Nota: PowerPoint è uno spazio dei nomi che è stato definito sopra in questo modo
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Crea una presentazione
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Aggiungi una diapositiva vuota
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Aggiungi un testo
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Imposta un testo
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Scrivi l'output su disco
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```

## **Esempio di Aspose.Slides per .NET**
I frammenti di codice qui sotto usano Aspose.Slides per creare una presentazione con una diapositiva semplice e una stringa di testo.

**La presentazione creata utilizzando Aspose.Slides per .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Crea una presentazione
Presentation pres = new Presentation();

//La diapositiva vuota viene aggiunta per impostazione predefinita, quando crei
//una presentazione dal costruttore predefinito
//Quindi, non è necessario aggiungere alcuna diapositiva vuota
ISlide sld = pres.Slides[1];

//Aggiungi una casella di testo
//Per aggiungerla, prima aggiungeremo un rettangolo
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Nascondi la sua linea
shp.LineFormat.Style = LineStyle.NotDefined;

//Quindi aggiungi un frame di testo al suo interno
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Imposta un testo
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Scrivi l'output su disco
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```