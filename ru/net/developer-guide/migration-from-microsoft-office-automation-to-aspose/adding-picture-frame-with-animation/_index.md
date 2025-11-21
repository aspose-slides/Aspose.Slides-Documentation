---
title: Добавление картинных рамок с анимацией с использованием VSTO и Aspose.Slides для .NET
linktitle: Картинные рамки с анимацией
type: docs
weight: 60
url: /ru/net/adding-picture-frame-with-animation/
keywords:
- рамка изображения
- добавить изображение
- добавить изображение
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
description: "Перейдите от автоматизации Microsoft Office к Aspose.Slides для .NET и анимируйте картинные рамки в слайдах PowerPoint (PPT, PPTX) с чистым кодом C#."
---

{{% alert color="primary" %}} 

Картиночные рамки применяются к фигурам или изображениям в Microsoft PowerPoint, чтобы обрамлять изображения в презентации. Эта статья показывает, как программно создать картинную рамку и применить к ней анимацию, сначала с помощью [VSTO 2008](/slides/ru/net/adding-picture-frame-with-animation/), а затем с помощью [Aspose.Slides for .NET](/slides/ru/net/adding-picture-frame-with-animation/). Сначала мы покажем, как применить рамку и анимацию, используя VSTO 2008. Затем продемонстрируем те же шаги с использованием Aspose.Slides for .NET.

{{% /alert %}} 
## **Добавление картинных рамок с анимацией**
Ниже приведённые образцы кода создают презентацию со слайдом, добавляют изображение с картинной рамкой и применяют к нему анимацию.
### **Пример VSTO 2008**
Используя VSTO 2008, выполните следующие шаги:

1. Создайте презентацию.
1. Добавьте пустой слайд.
1. Добавьте элемент формы изображения на слайд.
1. Примените анимацию к изображению.
1. Сохраните презентацию на диск.

**Выходная презентация, созданная с помощью VSTO** 

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

1. Создайте презентацию.
1. Получите доступ к первому слайду.
1. Добавьте изображение в коллекцию изображений.
1. Добавьте элемент формы изображения на слайд.
1. Примените анимацию к изображению.
1. Сохраните презентацию на диск.

**Выходная презентация, созданная с помощью Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)
```c#
// Создать пустую презентацию
using (Presentation pres = new Presentation())
{
    // Получить первый слайд
    ISlide slide = pres.Slides[0];

    // Добавить изображение в коллекцию изображений презентации
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Добавить рамку изображения, высота и ширина которой совпадают с высотой и шириной изображения
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Получить основную последовательность анимации слайда
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Добавить эффект анимации «Вылет из левого» к рамке изображения
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохранить презентацию
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```
