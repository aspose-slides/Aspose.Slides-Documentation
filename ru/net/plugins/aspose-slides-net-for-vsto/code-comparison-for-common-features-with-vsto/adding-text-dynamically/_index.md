---
title: Динамическое добавление текста
type: docs
weight: 40
url: /ru/net/adding-text-dynamically/
---

Оба метода следуют следующим шагам:

- Создайте презентацию.
- Добавьте пустой слайд.
- Добавьте текстовое поле.
- Установите некоторый текст.
- Запишите презентацию.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Создайте презентацию

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Получите макет пустого слайда

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Добавьте пустой слайд

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Добавьте текст

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Установите текст

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Текст добавлен динамически";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Запишите результат на диск

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Создайте презентацию

	Presentation pres = new Presentation();

	//Пустой слайд добавляется по умолчанию, когда вы создаете

	//презентацию из конструктора по умолчанию

	//Поэтому нам не нужно добавлять никакой пустой слайд

	Slide sld = pres.GetSlideByPosition(1);

	//Получите индекс шрифта для Arial

	//Он всегда равен 0, если вы создаете презентацию из

	//конструктора по умолчанию

	int arialFontIndex = 0;

	//Добавьте текстовое поле

	//Для этого мы сначала добавим прямоугольник

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Скрыть его линию

	shp.LineFormat.ShowLines = false;

	//Затем добавьте текстовый фрейм внутри него

	TextFrame tf = shp.AddTextFrame("");

	//Установите текст

	tf.Text = "Текст добавлен динамически";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Запишите результат на диск

	pres.Write("outAspose.ppt");

}

``` 
## **Скачать пример кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772947)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip)