---
title: Добавление рамок изображений с анимацией с использованием VSTO и Aspose.Slides for .NET
linktitle: Рамки изображений с анимацией
type: docs
weight: 60
url: /ru/net/adding-picture-frame-with-animation/
keywords:
- рамка изображения
- добавить изображение
- добавить картинку
- изображение с анимацией
- картинка с анимацией
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Перейдите с автоматизации Microsoft Office на Aspose.Slides for .NET и анимируйте рамки изображений в слайдах PowerPoint (PPT, PPTX) с чистым кодом C#."
---

{{% alert color="primary" %}} 
Рамки изображений применяются к формам или изображениям в Microsoft PowerPoint, чтобы обрамлять изображения в презентации. В этой статье показано, как программно создать рамку изображения и применить к ней анимацию, сначала с помощью [VSTO 2008](/slides/ru/net/adding-picture-frame-with-animation/) и затем с помощью [Aspose.Slides for .NET](/slides/ru/net/adding-picture-frame-with-animation/). Сначала мы покажем, как применить рамку и анимацию с помощью VSTO 2008. Затем мы покажем, как выполнить те же шаги с помощью Aspose.Slides for .NET.
{{% /alert %}} 
## **Добавление рамок изображений с анимацией**
Ниже приведённые примеры кода создают презентацию со слайдом, добавляют изображение с рамкой и применяют к нему анимацию.
### **Пример VSTO 2008**
Используя VSTO 2008, выполните следующие шаги:

1. Создать презентацию.
1. Добавить пустой слайд.
1. Добавить форму изображения на слайд.
1. Применить анимацию к изображению.
1. Сохранить презентацию на диск.

**Презентация‑результат, созданная с помощью VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)
```c#
//Создание пустой презентации
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Добавление пустого слайда
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Добавление рамки изображения
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Применение анимации к рамке изображения
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Сохранение презентации
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Пример Aspose.Slides for .NET**
Используя Aspose.Slides for .NET, выполните следующие шаги:

1. Создать презентацию.
1. Получить доступ к первому слайду.
1. Добавить изображение в коллекцию изображений.
1. Добавить форму изображения на слайд.
1. Применить анимацию к изображению.
1. Сохранить презентацию на диск.

**Презентация‑результат, созданная с помощью Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)
```c#
 // Создать пустую презентацию
 using (Presentation pres = new Presentation())
 {
     // Получить доступ к первому слайду
     ISlide slide = pres.Slides[0];
 
     // Добавить изображение в коллекцию изображений презентации
     IImage image = Images.FromFile("aspose.jpg");
     IPPImage ppImage = pres.Images.AddImage(image);
     image.Dispose();
 
     // Добавить рамку изображения, высота и ширина которой совпадают с высотой и шириной изображения
     IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);
 
     // Получить основную последовательность анимации слайда
     ISequence sequence = pres.Slides[0].Timeline.MainSequence;
 
     // Добавить эффект анимации «Полёт слева» к рамке изображения
     IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);
 
     // Сохранить презентацию
     pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
 }
```
