---
title: Dynamické přidávání textu pomocí VSTO a Aspose.Slides pro .NET
linktitle: Dynamické přidávání textu
type: docs
weight: 20
url: /cs/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
  - přidat text
  - migrace
  - VSTO
  - automatizace Office
  - PowerPoint
  - prezentace
  - .NET
  - C#
  - Aspose.Slides
description: "Podívejte se, jak migrovat z automatizace Microsoft Office na Aspose.Slides pro .NET a přidat dynamický text do prezentací PowerPoint (PPT, PPTX) v C#."
---
{{% alert color="primary" %}} 

Běžnou úlohou, kterou vývojáři často potřebují splnit, je dynamické přidávání textu do snímků. Tento článek ukazuje příklady kódu pro dynamické přidávání textu pomocí [VSTO](/slides/cs/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) a [Aspose.Slides for .NET](/slides/cs/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Přidávání textu dynamicky**
Both methods follow these steps:

1. Vytvořte prezentaci.
1. Přidejte prázdný snímek.
1. Přidejte textové pole.
1. Nastavte nějaký text.
1. Uložte prezentaci.
## **Příklad kódu VSTO**
The code snippets below results in a presentation with a plain slide and a string of text on it.

**Prezentace vytvořená ve VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Poznámka: PowerPoint je jmenný prostor, který byl výše definován takto
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Vytvořte prezentaci
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



## **Příklad Aspose.Slides pro .NET**
The code snippets below use Aspose.Slides to create a presentation with a plain slide and a string of text on it.

**Prezentace vytvořená pomocí Aspose.Slides pro .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Vytvořte prezentaci
Presentation pres = new Presentation();

//Prázdný snímek je přidán ve výchozím nastavení, když vytvoříte
//prezentaci z výchozího konstruktoru
//Takže není potřeba přidávat žádný prázdný snímek
ISlide sld = pres.Slides[1];

//Přidejte textové pole
//Pro jeho přidání nejprve přidáme obdélník
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Skryjte jeho čáru
shp.LineFormat.Style = LineStyle.NotDefined;

//Pak přidejte textový rámec uvnitř něj
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Nastavte text
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Write the output to disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```