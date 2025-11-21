---
title: Добавление текста динамически с помощью VSTO и Aspose.Slides для .NET
linktitle: Динамическое добавление текста
type: docs
weight: 20
url: /ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- добавление текста
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как перейти от автоматизации Microsoft Office к Aspose.Slides для .NET и добавить динамический текст в презентации PowerPoint (PPT, PPTX) на C#."
---

{{% alert color="primary" %}} 

Одна из типичных задач, которую разработчикам необходимо выполнять, — добавление текста на слайды динамически. В этой статье показаны примеры кода для динамического добавления текста с использованием [VSTO](/slides/ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) и [Aspose.Slides for .NET](/slides/ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Динамическое добавление текста**
Оба метода выполняют следующие шаги:

1. Создать презентацию.
1. Добавить пустой слайд.
1. Добавить текстовое поле.
1. Установить текст.
1. Сохранить презентацию.
## **Пример кода VSTO**
Приведённые ниже фрагменты кода создают презентацию с простым слайдом и строкой текста на нём.

**Презентация, созданная в VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//Примечание: PowerPoint — это пространство имён, которое было определено выше следующим образом
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Создать презентацию
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Получить макет пустого слайда
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Добавить пустой слайд
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Добавить текст
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Установить текст
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Записать выходной файл на диск
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

//Пустой слайд добавляется по умолчанию, когда вы создаёте
//презентацию с использованием конструктора по умолчанию
//Поэтому нам не нужно добавлять пустой слайд
ISlide sld = pres.Slides[1];

//Добавить текстовое поле
//Чтобы добавить его, мы сначала добавим прямоугольник
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Скрыть его линию
shp.LineFormat.Style = LineStyle.NotDefined;

//Затем добавить внутри него текстовый фрейм
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Установить текст
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Записать выходной файл на диск
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
