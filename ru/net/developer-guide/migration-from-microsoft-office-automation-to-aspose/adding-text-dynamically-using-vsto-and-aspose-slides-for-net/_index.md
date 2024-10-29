---
title: Динамическое добавление текста с использованием VSTO и Aspose.Slides для .NET
type: docs
weight: 20
url: /ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
---

{{% alert color="primary" %}} 

Общей задачей, которую разработчики должны решить, является динамическое добавление текста на слайды. В этой статье представлены примеры кода для динамического добавления текста с использованием [VSTO](/slides/ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) и [Aspose.Slides для .NET](/slides/ru/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Динамическое добавление текста**
Обе методики следуют следующим шагам:

1. Создать презентацию.
1. Добавить пустой слайд.
1. Добавить текстовое поле.
1. Установить некоторый текст.
1. Записать презентацию.
## **Пример кода VSTO**
Ниже приведены кодовые фрагменты, которые создают презентацию с обычным слайдом и строкой текста на нем.

**Презентация, созданная в VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Примечание: PowerPoint - это пространство имен, определенное выше следующим образом
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
txtRange.Text = "Текст добавлен динамически";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Записать вывод на диск
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Пример Aspose.Slides для .NET**
Ниже приведены кодовые фрагменты, которые используют Aspose.Slides для создания презентации с обычным слайдом и строкой текста на нем.

**Презентация, созданная с использованием Aspose.Slides для .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Создать презентацию
Presentation pres = new Presentation();

//Пустой слайд добавляется по умолчанию, когда вы создаете
//презентацию из конструктора по умолчанию
//Поэтому нам не нужно добавлять ни один пустой слайд
ISlide sld = pres.Slides[1];

//Добавить текстовое поле
//Для этого сначала добавим прямоугольник
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Скрыть его рамку
shp.LineFormat.Style = LineStyle.NotDefined;

//Затем добавим текстовое поле внутри него
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Установить текст
tf.Text = "Текст добавлен динамически";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Записать вывод на диск
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```