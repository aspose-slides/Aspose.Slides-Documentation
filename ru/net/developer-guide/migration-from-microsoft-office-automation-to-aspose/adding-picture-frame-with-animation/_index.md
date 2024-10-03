---
title: Добавление рамки для изображения с анимацией
type: docs
weight: 60
url: /ru/net/adding-picture-frame-with-animation/
---

{{% alert color="primary" %}} 

Рамки для изображений применяются к фигурам или изображениям в Microsoft PowerPoint для оформления изображений в презентации. Эта статья показывает, как создать рамку для изображения и применить к ней анимацию программным образом, сначала используя [VSTO 2008](/slides/ru/net/adding-picture-frame-with-animation/), а затем [Aspose.Slides для .NET](/slides/ru/net/adding-picture-frame-with-animation/). Сначала мы покажем, как применить рамку и анимацию, используя VSTO 2008. Затем мы покажем, как выполнить те же действия с помощью Aspose.Slides для .NET.

{{% /alert %}} 
## **Добавление рамок для изображений с анимацией**
Приведенные ниже примеры кода создают презентацию со слайдом, добавляют изображение с рамкой для изображения и применяют к нему анимацию.
### **Пример VSTO 2008**
Используя VSTO 2008, выполните следующие шаги:

1. Создайте презентацию.
1. Добавьте пустой слайд.
1. Добавьте фигуру изображения на слайд.
1. Примените анимацию к изображению.
1. Сохраните презентацию на диск.

**Выходная презентация, созданная с помощью VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Создание пустой презентации
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Добавление пустого слайда
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Добавление рамки для изображения
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Применение анимации к рамке для изображения
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Сохранение презентации
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Пример Aspose.Slides для .NET**
Используя Aspose.Slides для .NET, выполните следующие шаги:

1. Создайте презентацию.
1. Получите доступ к первому слайду.
1. Добавьте изображение в коллекцию изображений.
1. Добавьте фигуру изображения на слайд.
1. Примените анимацию к изображению.
1. Сохраните презентацию на диск.

**Выходная презентация, созданная с помощью Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
//Создание пустой презентации
Presentation pres = new Presentation();

//Получение первого слайда
ISlide slide = pres.Slides[0];

//Добавление объекта изображения в коллекцию изображений презентации
System.Drawing.Image pic = (System.Drawing.Image)new Bitmap("C:\\Data\\aspose.jpg");

IPPImage imgx = pres.Images.AddImage(pic);

//Добавление рамки для изображения с высотой и шириной, эквивалентной изображению
IPictureFrame PicFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

//Применение анимации к рамке для изображения
//PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Сохранение презентации
pres.Save("c:\\data\\AsposeAnim.ppt", SaveFormat.Ppt);
```