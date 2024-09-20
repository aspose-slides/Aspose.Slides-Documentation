---
title: Форматирование текста
type: docs
weight: 110
url: /net/format-text/
---

Обе методы VSTO и Aspose.Slides выполняют следующие шаги:

- Открыть исходную презентацию.
- Доступ к первому слайду.
- Доступ к третьему текстовому полю.
- Изменить форматирование текста в третьем текстовом поле.
- Сохранить презентацию на диск.
## **VSTO**
``` csharp

 //Открыть презентацию

Presentation pres = new Presentation("source.ppt");

//Добавить шрифт Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Доступ к первому слайду

Slide slide = pres.GetSlideByPosition(1);

//Доступ ко третьей фигуре

Shape shp = slide.Shapes[2];

//Изменить шрифт текста на Verdana и высоту на 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Загустить текст

port.FontBold = true;

//Курсивить текст

port.FontItalic = true;

//Изменить цвет текста

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Изменить цвет фона фигуры

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Записать вывод на диск

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Открыть презентацию

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Доступ к первому слайду

PowerPoint.Slide slide = pres.Slides[1];

//Доступ к третьей фигуре

PowerPoint.Shape shp = slide.Shapes[3];

//Изменить шрифт текста на Verdana и высоту на 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Загустить текст

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Курсивить текст

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Изменить цвет текста

txtRange.Font.Color.RGB = 0x00CC3333;

//Изменить цвет фона фигуры

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Изменить положение по горизонтали

shp.Left -= 70;

//Записать вывод на диск

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Скачать образец кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772953)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip)