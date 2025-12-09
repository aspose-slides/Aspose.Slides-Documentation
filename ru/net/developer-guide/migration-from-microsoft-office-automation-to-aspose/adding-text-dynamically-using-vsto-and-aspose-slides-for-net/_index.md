---
title: Добавление текста динамически с использованием VSTO и Aspose.Slides для .NET
linktitle: Добавление текста динамически
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

Общая задача, которую разработчики часто решают, — это динамическое добавление текста в слайды. В этой статье показаны примеры кода для динамического добавления текста с использованием [VSTO](/slides/ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) и [Aspose.Slides for .NET](/slides/ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Добавление текста динамически**
Both methods follow these steps:

1. Создать презентацию.
1. Добавить пустой слайд.
1. Добавить текстовое поле.
1. Установить некоторый текст.
1. Сохранить презентацию.
## **Пример кода VSTO**
The code snippets below results in a presentation with a plain slide and a string of text on it.

**Презентация, созданная в VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
 //Примечание: PowerPoint — это пространство имён, которое было определено выше следующим образом
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
The code snippets below use Aspose.Slides to create a presentation with a plain slide and a string of text on it.

**Презентация, созданная с помощью Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
 //Создать презентацию
 Presentation pres = new Presentation();

 //Пустой слайд добавляется по умолчанию при создании
 //презентации через конструктор по умолчанию
 //Следовательно, добавлять пустой слайд не требуется
 ISlide sld = pres.Slides[1];

 //Добавить текстовое поле
 //Для этого сначала добавим прямоугольник
 IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

 //Скрыть его линию
 shp.LineFormat.Style = LineStyle.NotDefined;

 //Затем добавить текстовый фрейм внутри него
 ITextFrame tf = ((IAutoShape)shp).TextFrame;

 //Установить текст
 tf.Text = "Text added dynamically";
 IPortion port = tf.Paragraphs[0].Portions[0];

 port.PortionFormat.FontBold = NullableBool.True;
 port.PortionFormat.FontHeight = 32;

 //Записать результат на диск
 pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
