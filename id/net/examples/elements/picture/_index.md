---
title: Gambar
type: docs
weight: 50
url: /id/net/examples/elements/picture/
keywords:
- gambar
- bingkai gambar
- tambahkan gambar
- akses gambar
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bekerja dengan gambar di Aspose.Slides untuk .NET: menyisipkan, memotong, mengompresi, mewarnai ulang, dan mengekspor gambar dengan contoh C# untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyisipkan dan mengakses gambar dari gambar dalam memori menggunakan **Aspose.Slides for .NET**. Contoh-contoh di bawah membuat gambar dalam memori, menempatkannya pada slide, dan kemudian mengambilnya.

## **Tambah Gambar**

Kode ini menghasilkan bitmap kecil, mengubahnya menjadi aliran, dan menyisipkannya sebagai bingkai gambar pada slide pertama.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Buat gambar sederhana dalam memori.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Ubah bitmap menjadi MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Tambahkan gambar ke presentasi.
    var image = presentation.Images.AddImage(imageStream);

    // Sisipkan bingkai gambar yang menampilkan gambar pada slide pertama.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Akses Gambar**

Contoh ini memastikan sebuah slide berisi bingkai gambar dan kemudian mengakses yang pertama ditemukan.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Pastikan ada setidaknya satu bingkai gambar untuk diproses.
    using var bitmap = new Bitmap(40, 40);

    // Ubah bitmap menjadi MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Tambahkan gambar ke presentasi.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Akses bingkai gambar pertama pada slide.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```