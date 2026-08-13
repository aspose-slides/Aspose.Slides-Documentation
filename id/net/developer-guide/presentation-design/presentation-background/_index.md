---
title: Kelola Latar Belakang Presentasi di .NET
linktitle: Latar Belakang Slide
type: docs
weight: 20
url: /id/net/presentation-background/
keywords:
- latar belakang presentasi
- latar belakang slide
- warna solid
- warna gradien
- latar belakang gambar
- transparansi latar belakang
- properti latar belakang
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengatur latar belakang dinamis dalam file PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET, dengan tip kode untuk meningkatkan presentasi Anda."
---
## **Pendahuluan**

Warna solid, gradien, dan gambar biasanya digunakan untuk latar belakang slide. Anda dapat mengatur latar belakang untuk **slide normal** (satu slide) atau **slide master** (berlaku untuk beberapa slide sekaligus).

![PowerPoint background](powerpoint-background.png)

## **Atur Latar Belakang Warna Solid untuk Slide Normal**

Aspose.Slides memungkinkan Anda menetapkan warna solid sebagai latar belakang untuk slide tertentu dalam sebuah presentasi—bahkan jika presentasi menggunakan slide master. Perubahan hanya berlaku pada slide yang dipilih.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Atur [BackgroundType](https://reference.aspose.com/slides/id/net/aspose.slides/backgroundtype/) slide menjadi `OwnBackground`.
3. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) latar belakang slide menjadi `Solid`.
4. Gunakan properti [SolidFillColor](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/solidfillcolor/) pada [FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah diubah.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Atur warna latar belakang slide menjadi biru.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Simpan presentasi ke disk.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Atur Latar Belakang Warna Solid untuk Slide Master**

Aspose.Slides memungkinkan Anda menetapkan warna solid sebagai latar belakang untuk slide master dalam sebuah presentasi. Slide master berfungsi sebagai templat yang mengontrol pemformatan untuk semua slide, sehingga ketika Anda memilih warna solid untuk latar belakang slide master, itu berlaku untuk setiap slide.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Atur [BackgroundType](https://reference.aspose.com/slides/id/net/aspose.slides/backgroundtype/) slide master (melalui `masters`) menjadi `OwnBackground`.
3. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) latar belakang slide master menjadi `Solid`.
4. Gunakan [SolidFillColor](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/solidfillcolor/) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah diubah.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Atur warna latar belakang slide Master menjadi Hijau Hutan.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Simpan presentasi ke disk.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Atur Latar Belakang Gradien untuk Slide**

Gradien adalah efek grafis yang dibuat oleh perubahan warna secara bertahap. Ketika digunakan sebagai latar belakang slide, gradien dapat membuat presentasi terlihat lebih artistik dan profesional. Aspose.Slides memungkinkan Anda menetapkan warna gradien sebagai latar belakang untuk slide.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Atur [BackgroundType](https://reference.aspose.com/slides/id/net/aspose.slides/backgroundtype/) slide menjadi `OwnBackground`.
3. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) latar belakang slide menjadi `Gradient`.
4. Gunakan properti [GradientFormat](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/gradientformat/) pada [FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/) untuk mengonfigurasi pengaturan gradien yang Anda inginkan.
5. Simpan presentasi yang telah diubah.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Terapkan efek gradien pada latar belakang.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Simpan presentasi ke disk.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Atur Gambar sebagai Latar Belakang Slide**

Selain isian solid dan gradien, Aspose.Slides memungkinkan Anda menggunakan gambar sebagai latar belakang slide.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Atur [BackgroundType](https://reference.aspose.com/slides/id/net/aspose.slides/backgroundtype/) slide menjadi `OwnBackground`.
3. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) latar belakang slide menjadi `Picture`.
4. Muat gambar yang ingin Anda gunakan sebagai latar belakang slide.
5. Tambahkan gambar ke koleksi gambar presentasi.
6. Gunakan properti [PictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/picturefillformat/) pada [FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/) untuk menetapkan gambar sebagai latar belakang.
7. Simpan presentasi yang telah diubah.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Atur properti gambar latar belakang.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Muat gambar.
    IImage image = Images.FromFile("Tulips.jpg");
    // Tambahkan gambar ke koleksi gambar presentasi.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Simpan presentasi ke disk.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Atur gambar yang digunakan untuk isian latar belakang.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Atur mode isian gambar menjadi Tile dan sesuaikan properti ubin.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Baca selengkapnya: [**Tile Picture As Texture**](/slides/id/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ubah Transparansi Gambar Latar Belakang**

Anda mungkin ingin menyesuaikan transparansi gambar latar belakang slide agar konten slide lebih menonjol. Kode C# berikut menunjukkan cara mengubah transparansi gambar latar belakang slide:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Misalnya.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan koleksi operasi transformasi gambar.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Temukan efek transparansi persentase tetap yang ada.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Atur nilai transparansi baru.
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Dapatkan Nilai Latar Belakang Slide**

Aspose.Slides menyediakan antarmuka [IBackgroundEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ibackgroundeffectivedata/) untuk mengambil nilai latar belakang efektif sebuah slide. Antarmuka ini menampilkan [FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibackgroundeffectivedata/fillformat/) dan [EffectFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibackgroundeffectivedata/effectformat/) yang efektif.

Dengan menggunakan properti `background` kelas [BaseSlide](https://reference.aspose.com/slides/id/net/aspose.slides/baseslide/), Anda dapat memperoleh latar belakang efektif untuk sebuah slide.

Contoh C# berikut menunjukkan cara mendapatkan nilai latar belakang efektif sebuah slide:

```cs
using Aspose.Slides;

// Buat instance kelas Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Ambil latar belakang efektif, dengan memperhitungkan master, layout, dan tema.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

### Apakah saya dapat mengatur ulang latar belakang khusus dan mengembalikan latar belakang tema/lay out?

Ya. Hapus isian khusus slide, dan latar belakang akan kembali diwarisi dari slide [layout](/slides/id/net/slide-layout/)/[master](/slides/id/net/slide-master/) yang bersangkutan (mis., [theme background](/slides/id/net/presentation-theme/)).

### Apa yang terjadi pada latar belakang jika saya mengubah tema presentasi nanti?

Jika sebuah slide memiliki isian sendiri, isian tersebut tidak akan berubah. Jika latar belakang diwarisi dari [layout](/slides/id/net/slide-layout/)/[master](/slides/id/net/slide-master/), maka latar belakang akan diperbarui agar sesuai dengan [tema baru](/slides/id/net/presentation-theme/).