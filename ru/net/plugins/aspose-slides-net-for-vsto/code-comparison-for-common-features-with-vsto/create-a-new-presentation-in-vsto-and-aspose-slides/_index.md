---
title: Создание новой презентации в VSTO и Aspose.Slides
type: docs
weight: 80
url: /ru/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---

Ниже приведены два примера кода, которые иллюстрируют, как VSTO и Aspose.Slides для .NET могут быть использованы для достижения одной и той же цели.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Получить макет титульного слайда

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Добавить титульный слайд.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Установить текст заголовка

slide.Shapes.Title.TextFrame.TextRange.Text = "Заголовок слайда";

//Установить текст подзаголовка

slide.Shapes[2].TextFrame.TextRange.Text = "Подзаголовок слайда";

//Сохранить результат на диск

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Создать презентацию

	Presentation pres = new Presentation();

	//Добавить титульный слайд

	Slide slide = pres.AddTitleSlide();

	//Установить текст заголовка

	((TextHolder)slide.Placeholders[0]).Text = "Заголовок слайда";

	//Установить текст подзаголовка

	((TextHolder)slide.Placeholders[1]).Text = "Подзаголовок слайда";

	//Сохранить результат на диск

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Скачать образец кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772949)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip)