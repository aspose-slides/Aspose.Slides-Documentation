---
title: Динамическое добавление текста с использованием VSTO и Aspose.Slides для .NET
linktitle: Динамическое добавление текста
type: docs
weight: 20
url: /ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- добавить текст
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Посмотрите, как перейти от автоматизации Microsoft Office к Aspose.Slides для .NET и добавить динамический текст в презентации PowerPoint (PPT, PPTX) на C#."
---

{{% alert color="primary" %}} 

Обычная задача, которую разработчики часто решают, — добавление текста на слайды динамически. В этой статье показаны примеры кода для динамического добавления текста с использованием [VSTO](/slides/ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) и [Aspose.Slides for .NET](/slides/ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Динамическое добавление текста**
Оба метода следуют этим шагам:

1. Создать презентацию.
1. Добавить пустой слайд.
1. Добавить текстовое поле.
1. Установить некоторый текст.
1. Сохранить презентацию.
## **Пример кода VSTO**
Приведённые ниже фрагменты кода создают презентацию с простым слайдом и строкой текста на нём.

**Презентация, созданная в VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//Примечание: PowerPoint — это пространство имен, которое было определено выше так
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Создать презентацию
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


## **Пример Aspose.Slides for .NET**
Приведённые ниже фрагменты кода используют Aspose.Slides для создания презентации с простым слайдом и строкой текста на нём.

**Презентация, созданная с использованием Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//Создать презентацию
Presentation pres = new Presentation();

//Blank slide is added by default, when you create
//presentation from default constructor
//So, we don't need to add any blank slide
ISlide sld = pres.Slides[1];

//Add a textbox
//To add it, we will first add a rectangle
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Hide its line
shp.LineFormat.Style = LineStyle.NotDefined;

//Then add a textframe inside it
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Set a text
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Write the output to disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
