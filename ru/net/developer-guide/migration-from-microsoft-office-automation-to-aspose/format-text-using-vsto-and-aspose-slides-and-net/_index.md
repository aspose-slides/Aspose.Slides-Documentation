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
description: "Перейдите с автоматизации Microsoft Office на Aspose.Slides для .NET и отформатируйте текст в презентациях PowerPoint (PPT, PPTX) с точным контролем."
---

{{% alert color="primary" %}} 

Иногда необходимо программно форматировать текст на слайдах. В этой статье показано, как открыть пример презентации с некоторым текстом на первом слайде, используя либо [VSTO](/slides/ru/net/format-text-using-vsto-and-aspose-slides-and-net/) либо [Aspose.Slides for .NET](/slides/ru/net/format-text-using-vsto-and-aspose-slides-and-net/). Код форматирует текст в третьем текстовом поле на слайде, делая его похожим на текст в последнем текстовом поле.

{{% /alert %}} 
## **Форматирование текста**
Методы VSTO и Aspose.Slides выполняют следующие шаги:

1. Откройте исходную презентацию.
1. Получите доступ к первому слайду.
1. Получите доступ к третьему текстовому полю.
1. Измените форматирование текста в третьем текстовом поле.
1. Сохраните презентацию на диск.

Скриншоты ниже показывают пример слайда до и после выполнения кода VSTO и Aspose.Slides for .NET.

**Исходная презентация** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **Пример кода VSTO**
Код ниже демонстрирует, как переоформить текст на слайде с помощью VSTO.

**Текст, переоформленный с помощью VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//Примечание: PowerPoint — это пространство имён, которое было определено выше следующим образом
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
 //Открыть презентацию
Presentation pres = new Presentation("c:\\source.ppt");

//Получить первый слайд
ISlide slide = pres.Slides[0];

//Получить третий объект
IShape shp = slide.Shapes[2];

//Изменить шрифт текста на Verdana и высоту на 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Сделать полужирным
port.PortionFormat.FontBold = NullableBool.True;

//Сделать курсивом
port.PortionFormat.FontItalic = NullableBool.True;

//Изменить цвет текста
//Установить цвет шрифта
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Изменить цвет фона формы
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Записать результат на диск
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
