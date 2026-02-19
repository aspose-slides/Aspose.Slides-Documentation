---
title: Изображение
type: docs
weight: 50
url: /ru/net/examples/elements/picture/
keywords:
- изображение
- рамка изображения
- добавить изображение
- доступ к изображению
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с изображениями в Aspose.Slides for .NET: вставка, обрезка, сжатие, изменение цвета и экспорт изображений с примерами на C# для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как вставлять и получать доступ к изображениям из изображений, находящихся в памяти, с использованием **Aspose.Slides for .NET**. Приведённые ниже примеры создают изображение в памяти, помещают его на слайд и затем извлекают его.

## **Добавить изображение**

Этот код генерирует небольшое растровое изображение, преобразует его в поток и вставляет его как рамку изображения на первом слайде.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Создайте простое изображение в памяти.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Преобразуйте bitmap в MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Добавьте изображение в презентацию.
    var image = presentation.Images.AddImage(imageStream);

    // Вставьте рамку изображения, отображающую изображение, на первом слайде.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Получить изображение**

Этот пример гарантирует, что слайд содержит рамку изображения, и затем получает доступ к первой найденной.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Убедитесь, что существует хотя бы одна рамка изображения для работы.
    using var bitmap = new Bitmap(40, 40);

    // Преобразуйте bitmap в MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Добавьте изображение в презентацию.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Получите доступ к первой рамке изображения на слайде.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```