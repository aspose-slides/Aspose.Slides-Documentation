---
title: Добавление рамки для изображения с анимацией в VSTO и Aspose.Слайды
type: docs
weight: 20
url: /net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---

Приведенные ниже образцы кода создают презентацию со слайдом, добавляют изображение с рамкой для изображения и применяют анимацию к нему.
## **VSTO**
Используя VSTO, выполните следующие шаги:

1. Создайте презентацию.
1. Добавьте пустой слайд.
1. Добавьте форму изображения на слайд.
1. Примените анимацию к изображению.
1. Запишите презентацию на диск.

``` csharp
 //Создание пустой презентации

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Добавить пустой слайд

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Добавить рамку для изображения

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Применение анимации к рамке для изображения

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Сохранение презентации

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **Aspose.Slides**
Используя Aspose.Slides для .NET, выполните следующие шаги:

1. Создайте презентацию.
1. Получите доступ к первому слайду.
1. Добавьте изображение в коллекцию изображений.
1. Добавьте форму изображения на слайд.
1. Примените анимацию к изображению.
1. Запишите презентацию на диск.

``` csharp
 //Создание пустой презентации

Presentation pres = new Presentation();

//Получение первого слайда

Slide slide = pres.GetSlideByPosition(1);

//Добавление объекта изображения в коллекцию изображений презентации

Picture pic = new Picture(pres, "pic.jpeg");

//После добавления объекта изображения, изображению присваивается уникальный идентификатор

int picId = pres.Pictures.Add(pic);

//Добавление рамки для изображения

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Применение анимации к рамке для изображения

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Сохранение презентации

pres.Write("AsposeAnim.ppt");
``` 
## **Скачать образец кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772946)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip)