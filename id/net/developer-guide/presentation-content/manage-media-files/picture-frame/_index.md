---
title: Kelola Bingkai Gambar dalam Presentasi di .NET
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/net/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- tambahkan gambar
- buat gambar
- ekstrak gambar
- gambar raster
- gambar vektor
- pangkas gambar
- area yang dipangkas
- Properti StretchOff
- pemformatan bingkai gambar
- properti bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- transparansi gambar
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tambahkan bingkai gambar ke presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET. Permudah alur kerja Anda dan tingkatkan desain slide."
---
## **Pendahuluan**

Bingkai gambar adalah bentuk yang berisi sebuah gambar—mirip dengan gambar dalam sebuah bingkai. 

Anda dapat menambahkan gambar ke slide melalui bingkai gambar. Dengan cara ini, Anda dapat memformat gambar dengan memformat bingkai gambar.

{{% alert  title="Tip" color="primary" %}} 

Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 

{{% /alert %}} 

## **Buat Bingkai Gambar**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation). 
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/net/aspose.slides/iimagecollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk. 
4. Tentukan lebar dan tinggi gambar. 
5. Buat [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe) berdasarkan lebar dan tinggi gambar melalui metode `AddPictureFrame` yang disediakan oleh objek shape yang terkait dengan slide yang direferensikan. 
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide. 
7. Tulis presentasi yang telah dimodifikasi sebagai file PPTX. 

Kode C# berikut menunjukkan cara membuat bingkai gambar:

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
using (Presentation pres = new Presentation())
{
    // Mengambil slide pertama
    ISlide slide = pres.Slides[0];

    // Memuat gambar dan menambahkannya ke koleksi gambar presentasi
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Menambahkan bingkai gambar dengan tinggi dan lebar yang sama
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Menerapkan beberapa pemformatan pada bingkai gambar
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Menulis presentasi ke file PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Bingkai gambar memungkinkan Anda dengan cepat membuat slide presentasi berdasarkan gambar. Ketika Anda menggabungkan bingkai gambar dengan opsi penyimpanan Aspose.Slides, Anda dapat memanipulasi operasi input/output untuk mengonversi gambar dari satu format ke format lain. Anda mungkin ingin melihat halaman ini: konversi [gambar ke JPG](https://products.aspose.com/slides/id/net/conversion/image-to-jpg/); konversi [JPG ke gambar](https://products.aspose.com/slides/id/net/conversion/jpg-to-image/); konversi [JPG ke PNG](https://products.aspose.com/slides/id/net/conversion/jpg-to-png/), konversi [PNG ke JPG](https://products.aspose.com/slides/id/net/conversion/png-to-jpg/); konversi [PNG ke SVG](https://products.aspose.com/slides/id/net/conversion/png-to-svg/), konversi [SVG ke PNG](https://products.aspose.com/slides/id/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Buat Bingkai Gambar dengan Skala Relatif**

Dengan mengubah skala relatif gambar, Anda dapat membuat bingkai gambar yang lebih kompleks. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation). 
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan gambar ke koleksi gambar presentasi. 
4. Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/net/aspose.slides/iimagecollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk. 
5. Tentukan lebar dan tinggi relatif gambar dalam bingkai gambar. 
6. Tulis presentasi yang telah dimodifikasi sebagai file PPTX. 

Kode C# berikut menunjukkan cara membuat bingkai gambar dengan skala relatif:

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
using (Presentation presentation = new Presentation())
{
    // Memuat gambar dan menambahkannya ke koleksi gambar presentasi
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Menambahkan bingkai gambar ke slide
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Mengatur lebar dan tinggi skala relatif
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Menyimpan presentasi
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Ekstrak Gambar Raster dari Bingkai Gambar**

Anda dapat mengekstrak gambar raster dari objek [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe) dan menyimpannya dalam format PNG, JPG, dan format lainnya. Contoh kode di bawah ini memperlihatkan cara mengekstrak gambar dari dokumen “sample.pptx” dan menyimpannya dalam format PNG.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Ekstrak Gambar SVG dari Bingkai Gambar**

Ketika sebuah presentasi berisi grafik SVG yang ditempatkan di dalam bentuk [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/), Aspose.Slides untuk .NET memungkinkan Anda mengambil gambar vektor asli dengan fidelitas penuh. Dengan menelusuri koleksi bentuk slide, Anda dapat mengidentifikasi setiap [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/), memeriksa apakah [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) yang mendasarinya berisi konten SVG, dan kemudian menyimpan gambar tersebut ke disk atau stream dalam format SVG aslinya.

Contoh kode berikut memperlihatkan cara mengekstrak gambar SVG dari bingkai gambar:

```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Dapatkan Transparansi Gambar**

Aspose.Slides memungkinkan Anda mendapatkan efek transparansi yang diterapkan pada gambar. Kode C# berikut mendemonstrasikan operasi tersebut:

```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

{{% alert color="primary" %}} 
Semua efek yang diterapkan pada gambar dapat ditemukan di [Aspose.Slides.Effects](https://reference.aspose.com/slides/id/net/aspose.slides.effects/). 
{{% /alert %}}

## **Pemformatan Bingkai Gambar**

Aspose.Slides menyediakan banyak opsi pemformatan yang dapat diterapkan pada bingkai gambar. Dengan opsi-opsi tersebut, Anda dapat mengubah bingkai gambar agar sesuai dengan kebutuhan spesifik.

1. Buat instance dari kelas [Presentation](http://www.aspose.com/api/net/slides/id/aspose.slides/) . 
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/net/aspose.slides/iimagecollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk. 
4. Tentukan lebar dan tinggi gambar. 
5. Buat `PictureFrame` berdasarkan lebar dan tinggi gambar melalui metode [AddPictureFrame](http://www.aspose.com/api/net/slides/id/aspose.slides/ishapecollection/methods/addpictureframe) yang disediakan oleh objek [IShapes](http://www.aspose.com/api/net/slides/id/aspose.slides/ishapecollection) yang terkait dengan slide yang direferensikan. 
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide. 
7. Atur warna garis bingkai gambar. 
8. Atur lebar garis bingkai gambar. 
9. Putar bingkai gambar dengan memberi nilai positif atau negatif. 
   * Nilai positif memutar gambar searah jarum jam. 
   * Nilai negatif memutar gambar berlawanan arah jarum jam. 
10. Tambahkan bingkai gambar (yang berisi gambar) ke slide. 
11. Tulis presentasi yang telah dimodifikasi sebagai file PPTX. 

Kode C# berikut mendemonstrasikan proses pemformatan bingkai gambar:

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
using (Presentation presentation = new Presentation())
{
    // Mengambil slide pertama
    ISlide slide = presentation.Slides[0];

    // Memuat gambar dan menambahkannya ke koleksi gambar presentasi
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Menambahkan bingkai gambar dengan tinggi dan lebar gambar yang setara
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Menerapkan beberapa pemformatan pada bingkai gambar
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Menulis presentasi ke file PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose baru-baru ini mengembangkan [Collage Maker gratis](https://products.aspose.app/slides/id/collage). Jika Anda perlu menggabungkan gambar JPG/JPEG atau PNG, atau membuat grid dari foto, Anda dapat menggunakan layanan ini. 

{{% /alert %}}

## **Tambahkan Gambar sebagai Tautan**

Untuk menghindari ukuran presentasi yang besar, Anda dapat menambahkan gambar (atau video) melalui tautan alih-alih menyematkan file secara langsung ke dalam presentasi. Kode C# berikut menunjukkan cara menambahkan gambar dan video ke placeholder:

```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Pangkas Gambar**

Kode C# berikut menunjukkan cara memangkas gambar yang ada pada slide:

```c#
using (Presentation presentation = new Presentation())
{
    // Membuat objek gambar baru
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Menambahkan PictureFrame ke Slide
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Memotong gambar (nilai persentase)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Menyimpan hasil
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Hapus Area yang Dipangkas dari Bingkai**

Jika Anda ingin menghapus area yang dipangkas dari gambar yang berada dalam bingkai, Anda dapat menggunakan metode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Metode ini mengembalikan gambar yang dipangkas atau gambar asli jika pemangkasan tidak diperlukan.

Kode C# berikut mendemonstrasikan operasi tersebut:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Mengambil PictureFrame dari slide pertama
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Menghapus area yang dipangkas dari gambar PictureFrame dan mengembalikan gambar yang dipangkas
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Menyimpan hasil
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Metode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) menambahkan gambar yang dipangkas ke koleksi gambar presentasi. Jika gambar hanya digunakan dalam [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/) yang diproses, pengaturan ini dapat mengurangi ukuran presentasi. Jika tidak, jumlah gambar dalam presentasi yang dihasilkan akan meningkat.

Metode ini mengonversi file metafile WMF/EMF ke gambar PNG raster pada operasi pemangkasan. 

{{% /alert %}}

## **Kompres Gambar**

Anda dapat mengompres gambar dalam presentasi menggunakan metode [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/compressimage/). Metode ini mengompres gambar dengan mengurangi ukurannya berdasarkan ukuran bentuk dan resolusi yang ditentukan, dengan opsi untuk menghapus area yang dipangkas. 

Ini menyesuaikan ukuran dan resolusi gambar serupa dengan fitur **Picture Format → Compress Pictures → Resolution** di PowerPoint.

Contoh C# berikut menunjukkan cara mengompres gambar dalam presentasi dengan menentukan resolusi target dan secara opsional menghapus area yang dipangkas:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Kompres gambar dengan resolusi target 150 DPI (resolusi Web) dan hapus area yang dipangkas.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Periksa hasil kompresi.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Atau menggunakan nilai DPI kustom secara langsung:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Kompres gambar ke 150 DPI (resolusi web), menghapus area yang dipangkas.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Metode ini mengonversi gambar ke resolusi lebih rendah berdasarkan ukuran bentuk dan DPI yang diberikan. Area yang dipangkas juga dapat dihapus untuk mengoptimalkan ukuran file. Jika gambar adalah metafile (WMF/EMF) atau SVG, kompresi tidak akan diterapkan. Selain itu, kualitas JPEG dipertahankan atau sedikit berkurang tergantung pada resolusi, serupa dengan cara PowerPoint menangani JPEG beresolusi tinggi. 

{{% /alert %}}

## **Kunci Rasio Aspek**

Jika Anda ingin bentuk yang berisi gambar mempertahankan rasio aspeknya bahkan setelah Anda mengubah dimensi gambar, Anda dapat menggunakan properti [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframelock/aspectratiolocked/) untuk mengatur pengaturan *Lock Aspect Ratio*. 

Kode C# berikut menunjukkan cara mengunci rasio aspek bentuk:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Mengatur bentuk agar mempertahankan rasio aspek saat mengubah ukuran
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Pengaturan *Lock Aspect Ratio* ini hanya mempertahankan rasio aspek bentuk dan bukan gambar yang dikandungnya. 

{{% /alert %}}

## **Gunakan Properti StretchOff**

Dengan menggunakan properti [StretchOffsetLeft](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat/properties/stretchoffsetright) dan [StretchOffsetBottom](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat), Anda dapat menentukan persegi panjang isi. 

Ketika peregangan ditentukan untuk sebuah gambar, persegi panjang sumber diskalakan untuk menyesuaikan persegi panjang isi yang ditentukan. Setiap tepi persegi panjang isi didefinisikan oleh offset persentase dari tepi yang bersesuaian pada kotak batas bentuk. Persentase positif menentukan inset sementara persentase negatif menentukan outset. 

1. Buat instance dari [Presentation](http://www.aspose.com/api/net/slides/id/aspose.slides/) . 
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan rectangle `AutoShape`. 
4. Buat gambar. 
5. Atur tipe isian bentuk. 
6. Atur mode isian gambar bentuk. 
7. Tambahkan gambar yang akan mengisi bentuk. 
8. Tentukan offset gambar dari tepi yang bersesuaian pada kotak batas bentuk 
9. Tulis presentasi yang telah dimodifikasi sebagai file PPTX. 

Kode C# berikut mendemonstrasikan proses di mana properti StretchOff digunakan:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Mengatur gambar diregangkan dari setiap sisi dalam badan shape
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Bagaimana cara mengetahui format gambar apa yang didukung untuk PictureFrame?**

Aspose.Slides mendukung baik gambar raster (PNG, JPEG, BMP, GIF, dll.) maupun gambar vektor (misalnya SVG) melalui objek gambar yang ditetapkan ke [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/). Daftar format yang didukung umumnya tumpang tindih dengan kemampuan mesin konversi slide dan gambar.

**Bagaimana dampak menambahkan puluhan gambar berukuran besar terhadap ukuran dan kinerja PPTX?**

Menyematkan gambar besar meningkatkan ukuran file dan penggunaan memori; menautkan gambar membantu menjaga ukuran presentasi tetap kecil tetapi memerlukan file eksternal tetap dapat diakses. Aspose.Slides menyediakan kemampuan menambahkan gambar lewat tautan untuk mengurangi ukuran file.

**Bagaimana cara mengunci objek gambar agar tidak sengaja dipindahkan/diubah ukuran?**

Gunakan [shape locks](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/pictureframelock/) untuk sebuah [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/) (misalnya, nonaktifkan pemindahan atau pengubahan ukuran). Mekanisme penguncian dijelaskan untuk bentuk dalam artikel [proteksi terpisah](/slides/id/net/applying-protection-to-presentation/) dan didukung untuk berbagai jenis bentuk, termasuk [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/).

**Apakah fidelitas vektor SVG terjaga saat mengekspor presentasi ke PDF/gambar?**

Aspose.Slides memungkinkan mengekstrak SVG dari [PictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/pictureframe/) sebagai vektor asli. Saat [mengekspor ke PDF](/slides/id/net/convert-powerpoint-to-pdf/) atau [format raster](/slides/id/net/convert-powerpoint-to-png/), hasilnya mungkin diraster tergantung pada pengaturan ekspor; fakta bahwa SVG asli disimpan sebagai vektor dikonfirmasi oleh perilaku ekstraksi.