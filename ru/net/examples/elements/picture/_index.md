---
title: Изображение
type: docs
weight: 50
url: /ru/net/examples/elements/picture/
keywords:
- пример изображения
- рамка изображения
- добавить изображение
- доступ к изображению
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с изображениями в C# с помощью Aspose.Slides: вставляйте, заменяйте, обрезайте, сжимайте, регулируйте прозрачность и эффекты, заполняйте фигуры и экспортируйте в PPT, PPTX и ODP."
---

Показывает, как вставлять и получать доступ к изображениям из изображений в памяти, используя **Aspose.Slides for .NET**. Приведённые ниже примеры создают изображение в памяти, помещают его на слайд и затем извлекают его.

## **Добавить изображение**

Этот код создает небольшой bitmap, преобразует его в поток и вставляет в качестве рамки изображения на первый слайд.
```csharp
public static void Add_Picture()
{
    using var pres = new Presentation();

    // Создать простое изображение в памяти
    using var bmp = new Bitmap(width: 100, height: 100);
    using (var g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.LightGreen);
    }

    // Преобразовать Bitmap в MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Добавить изображение в презентацию
    var ppImage = pres.Images.AddImage(imageStream);

    // Вставить рамку изображения, показывающую картинку на первом слайде
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bmp.Width, height: bmp.Height, ppImage);

    pres.Save(@"c:\_tmp\xxx.pptx", SaveFormat.Pptx);
}
```


## **Получить доступ к изображению**

Этот пример гарантирует, что слайд содержит рамку изображения, и затем получает доступ к первой найденной.
```csharp
public static void Access_Picture()
{
    using var pres = new Presentation();

    // Убедитесь, что существует хотя бы один кадр изображения для работы
    using var bmp = new Bitmap(40, 40);

    // Преобразовать Bitmap в MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Добавить изображение в презентацию
    var ppImage = pres.Images.AddImage(imageStream);
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, ppImage);

    // Доступ к первому кадру изображения на слайде
    var pictureFrame = pres.Slides[0].Shapes.OfType<PictureFrame>().First();
}
```
