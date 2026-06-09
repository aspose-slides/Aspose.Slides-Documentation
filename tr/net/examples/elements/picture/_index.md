---
title: Resim
type: docs
weight: 50
url: /tr/net/examples/elements/picture/
keywords:
- resim
- resim çerçevesi
- resim ekle
- resme erişim
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde resimlerle çalışın: ekleyin, kırpın, sıkıştırın, yeniden renklendirin ve PPT, PPTX ve ODP sunumları için C# örnekleriyle görüntüleri dışa aktarın."
---
Bu makale, **Aspose.Slides for .NET** kullanarak bellek içi görüntülerden resim ekleme ve erişme yöntemlerini gösterir. Aşağıdaki örnekler bir resmi bellek içinde oluşturur, bir slayta yerleştirir ve ardından geri alır.

## **Resim Ekle**

Bu kod küçük bir bitmap oluşturur, bunu bir akışa dönüştürür ve ilk slayta bir resim çerçevesi olarak ekler.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Basit bir bellek içi görüntü oluşturur.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Bitmap'i MemoryStream'e dönüştürür.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Görüntüyü sunuma ekler.
    var image = presentation.Images.AddImage(imageStream);

    // İlk slaytta görüntüyü gösteren bir resim çerçevesi ekler.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Resme Erişim**

Bu örnek, bir slaytın bir resim çerçevesi içerdiğini garanti eder ve ardından bulunan ilk çerçeveye erişir.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // En az bir resim çerçevesinin mevcut olduğundan emin olun.
    using var bitmap = new Bitmap(40, 40);

    // Bitmap'i MemoryStream'e dönüştürür.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Görüntüyü sunuma ekler.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Slayttaki ilk resim çerçevesine erişir.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```