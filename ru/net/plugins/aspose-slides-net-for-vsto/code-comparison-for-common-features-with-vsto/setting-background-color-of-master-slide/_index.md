---
title: Установка цвета фона для главного слайда
type: docs
weight: 140
url: /ru/net/setting-background-color-of-master-slide/
---

## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Установка цвета фона для главного слайда.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //Создаем класс Presentation, который представляет файл презентации

using (PresentationEx pres = new PresentationEx())

{

	//Устанавливаем цвет фона главного слайда на лесной зеленый

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//Записываем презентацию на диск

	pres.Save("Установка цвета фона для главного слайда.pptx", SaveFormat.Pptx);

``` 
## **Скачать образец кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/787342)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Setting%20Background%20color%20of%20Master%20Slide%20\(Asose.Slides\).zip)