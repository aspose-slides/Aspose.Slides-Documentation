---
title: SmartArt
type: docs
weight: 140
url: /id/net/examples/elements/smart-art/
keywords:
- SmartArt
- menambahkan SmartArt
- mengakses SmartArt
- menghapus SmartArt
- tata letak SmartArt
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bekerja dengan SmartArt di Aspose.Slides untuk .NET: buat, edit, konversi, dan gaya diagram dengan C# untuk presentasi PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara menambahkan grafik SmartArt, mengaksesnya, menghapusnya, dan mengubah tata letak menggunakan **Aspose.Slides for .NET**.

## **Add SmartArt**

Masukkan grafik SmartArt menggunakan salah satu tata letak bawaan.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Access SmartArt**

Dapatkan objek SmartArt pertama pada slide.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Remove SmartArt**

Hapus bentuk SmartArt dari slide.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Change SmartArt Layout**

Perbarui jenis tata letak grafik SmartArt yang ada.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```