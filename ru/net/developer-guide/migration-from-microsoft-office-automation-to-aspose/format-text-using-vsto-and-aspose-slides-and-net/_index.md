---
title: Форматирование текста с помощью VSTO и Aspose.Slides для .NET
linktitle: Форматировать текст
type: docs
weight: 30
url: /ru/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- форматировать текст
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Перейдите от автоматизации Microsoft Office к Aspose.Slides для .NET и форматируйте текст в презентациях PowerPoint (PPT, PPTX) с точным контролем."
---
{{% alert color="info" %}} 
Иногда необходимо программно форматировать текст на слайдах. В этой статье показано, как прочитать пример презентации с некоторым текстом на первом слайде, используя либо [VSTO](/slides/ru/net/format-text-using-vsto-and-aspose-slides-and-net/) и [Aspose.Slides for .NET](/slides/ru/net/format-text-using-vsto-and-aspose-slides-and-net/). Код форматирует текст в третьем текстовом поле на слайде, чтобы он выглядел как текст в последнем текстовом поле.
{{% /alert %}} 
## **Форматирование текста**
Both the VSTO and Aspose.Slides methods take the following steps:

1. Open the source presentation.
1. Access the first slide.
1. Access the third text box.
1. Change the formatting of the text in the third text box.
1. Save the presentation to disk.

Скриншоты ниже показывают пример слайда до и после выполнения кода VSTO и Aspose.Slides for .NET.

**Входная презентация** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Пример кода VSTO**
Код ниже показывает, как переоформить текст на слайде с использованием VSTO.

**Текст, переоформленный с помощью VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Примечание: PowerPoint — это пространство имён, которое было определено выше таким образом
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Open the presentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Access the first slide
PowerPoint.Slide slide = pres.Slides[1];

//Access the third shape
PowerPoint.Shape shp = slide.Shapes[3];

//Change its text's font to Verdana and height to 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Bolden it
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Italicize it
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Change text color
txtRange.Font.Color.RGB = 0x00CC3333;

//Change shape background color
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposition it horizontally
shp.Left -= 70;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Пример Aspose.Slides for .NET**
Чтобы отформатировать текст с помощью Aspose.Slides, добавьте шрифт перед форматированием текста.

**Выходная презентация, созданная с помощью Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //Открыть презентацию
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

//Bolden it
port.PortionFormat.FontBold = NullableBool.True;

//Italicize it
port.PortionFormat.FontItalic = NullableBool.True;

//Change text color
//Set font color
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Change shape background color
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Write the output to disk
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```