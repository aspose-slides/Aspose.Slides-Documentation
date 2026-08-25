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
- gambar tertanam
- gambar tertaut
- ekstrak gambar
- gambar raster
- gambar SVG
- potong gambar
- hapus area yang dipotong
- kompres gambar
- StretchOffset
- format bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres bingkai gambar dalam presentasi dengan Aspose.Slides untuk .NET."
---
## **Ikhtisar**

Bingkai gambar adalah bentuk slide yang menampilkan sebuah gambar. Di Aspose.Slides, sumber gambar dan bentuk yang menampilkannya adalah objek terpisah: sebuah [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) memiliki sumber daya gambar yang tertanam melalui koleksi [Images](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/images/)-nya, sementara sebuah [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) mengontrol posisi gambar, ukuran, format garis, rotasi, pemotongan, efek gambar, dan pengaturan tingkat bingkai lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari satu kali. Tambahkan gambar ke presentasi satu kali, simpan [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) yang dikembalikan, dan gunakan sumber gambar tersebut saat membuat bingkai gambar.

Bingkai gambar dapat berisi gambar raster seperti PNG atau JPEG dan gambar vektor SVG. Mereka juga dapat merujuk ke gambar terhubung alih‑alih menyimpan byte gambar dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran file, ekstraksi, dan perilaku ekspor, jadi sebaiknya tentukan bagaimana gambar harus disimpan sebelum menerapkan pemformatan atau optimasi.

## **Menambahkan dan Memformat Gambar yang Tertanam**

Untuk gambar yang tertanam, tambahkan data gambar ke presentasi dan buat bingkai gambar dengan [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addpictureframe/). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap berdiri sendiri ketika dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat bingkai dengan dimensi asli gambar, dan menerapkan format garis serta rotasi:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Bingkai gambar mengontrol geometri yang ditampilkan; mengubah ukuran bingkai tidak mengubah dimensi piksel asli yang disimpan dalam sumber daya gambar yang tertanam. Perbedaan ini menjadi penting ketika memotong atau mengompresi gambar di kemudian hari.

## **Menggunakan Skala Relatif**

[IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) menyediakan skala lebar dan tinggi relatif untuk bingkai. Nilai `1.0` sesuai dengan 100 % ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu mempertahankan hubungan dengan ukuran gambar sumber alih‑alih menghitung dimensi akhir secara manual.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Skala relatif mengubah pengaturan skala bingkai; ia tidak melakukan resampling atau kompresi pada gambar yang tertanam.

## **Gambar yang Tertanam dan Tertaut**

Gambar yang tertanam menyimpan data gambar di dalam presentasi dan oleh karena itu merupakan pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar yang tertaut menyimpan lokasi eksternal melalui jalur tautan [ISlidesPicture](https://reference.aspose.com/slides/id/net/aspose.slides/islidespicture/) alih‑alih menanam data gambar dengan cara yang sama.

Gambar yang tertaut dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi mereka memperkenalkan ketergantungan eksternal. File yang ditautkan harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, gambar yang tertaut mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim lewat email, diarsipkan, atau dirender di lingkungan terisolasi, gambar yang tertanam biasanya lebih dapat diandalkan.

### **Menambahkan Gambar yang Tertaut**

Contoh berikut membuat bingkai gambar dan menunjukkannya ke file gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video merupakan alur kerja media terpisah dan sengaja tidak digabungkan dalam contoh ini.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Gunakan tautan ketika manajemen file eksternal memang disengaja. Jangan gunakan hanya sebagai pengganti kompresi: PPTX kecil dengan ketergantungan gambar yang rusak biasanya kurang berguna dibandingkan presentasi yang lebih besar dan berdiri sendiri.

## **Mengekstrak Gambar dari Bingkai Gambar**

Sebelum mengekstrak gambar dari presentasi yang ada, periksa bahwa sebuah bentuk memang merupakan [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) dan bahwa ia berisi gambar yang tertanam. Bingkai gambar yang tertaut mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Mengekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) secara langsung dan tidak memerlukan pembungkus sistem‑gambar lama. Contoh berikut menemukan gambar raster tertanam pertama pada sebuah slide dan menyimpannya sebagai PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Menyimpan melalui [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) mengonversi gambar yang diekstrak ke format output yang diminta. Jika Anda memerlukan byte terkode yang disimpan dalam presentasi alih‑alih file raster yang telah dikonversi, gunakan data biner sumber gambar tersebut.

### **Mengekstrak Gambar SVG**

Untuk gambar SVG, [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) menyediakan objek [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/). Ini memungkinkan Anda mengambil data SVG secara langsung alih‑alih merasterkan gambar terlebih dahulu.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Menyimpan konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG secara otomatis merender konten vektor tersebut menjadi piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh dianggap sebagai salinan byte‑per‑byte dari SVG yang tertanam; gunakan data [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) yang tertanam bila sumber vektor asli diperlukan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam bingkai. Nilai pemotongan pada [IPictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan tidak langsung menghapus piksel tersembunyi dari gambar yang tertanam; ia hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan bingkai gambar secara aman dan menerapkan nilai pemotongan:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Karena data gambar tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran file lebih penting daripada kemampuan untuk membatalkan, wilayah yang dipotong dapat dihapus secara fisik seperti yang dijelaskan pada bagian berikutnya.

## **Menghapus Data Gambar yang Dipotong**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) menghapus data gambar di luar persegi potong saat ini dan mengembalikan sumber gambar yang dihasilkan. Ini dapat mengurangi ukuran file, tetapi merupakan optimasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Metode ini dapat menambahkan sumber gambar baru ke presentasi. Jika gambar asli juga digunakan oleh bingkai gambar lain, bingkai‑bingkai tersebut tetap memerlukan sumber yang ada, sehingga penghapusan wilayah yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Mengompresi Gambar Raster**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/compressimage/) mengurangi resolusi gambar raster relatif terhadap ukuran gambar saat ditampilkan. Ia juga dapat menghapus wilayah yang dipotong dalam operasi yang sama. Metode mengembalikan `true` ketika gambar diubah ukurannya atau dipotong dan `false` ketika tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/net/aspose.slides.export/picturescompression/) yang telah ditentukan sebelumnya ketika resolusi target standar sudah cukup:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Nilai DPI positif khusus dapat diberikan alih‑alih nilai enum ketika target khusus diperlukan.

Kompresi dimaksudkan untuk gambar raster. Konten SVG dan metafile tidak berkurang oleh alur kerja kompresi raster ini. Ingat juga bahwa resolusi lebih rendah dan wilayah yang dipotong yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimasi. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar sebenarnya akan dilihat atau diekspor, bukan dengan menerapkan DPI terendah secara global.

## **Mengelola Efek Transformasi Gambar**

Untuk alur kerja lengkap yang mencakup kecerahan, kontras, transformasi warna, blur, efek alfa, rantai berurutan, inspeksi, penghapusan, dan verifikasi putar‑balik, lihat [Image Transform Effects](/slides/id/net/image-transform-effects/).

## **Mengunci Geometri Bingkai Gambar**

Pengaturan [IPictureFrameLock](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk sebuah bingkai gambar. Misalnya, kunci rasio‑aspek menjaga proporsi bentuk saat ukuran diubah.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Kunci ini berlaku pada bentuk bingkai gambar. Ia tidak memaksa gambar sumber untuk di‑resample atau diubah secara permanen menjadi rasio‑aspek yang sama.

## **Menyesuaikan Nilai StretchOffset**

Ketika mode isian gambar adalah stretch, nilai stretch‑offset pada [IPictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/) menentukan persegi isian relatif terhadap kotak pembatas bingkai gambar. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dari pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi di mana isian gambar yang terlihat diregangkan.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Gunakan stretch offset untuk penempatan isian. Gunakan properti pemotongan ketika tujuan Anda menyembunyikan tepi gambar sumber.

## **Penyimpanan, Ukuran File, dan Pertimbangan Ekspor**

Pertukaran utama lebih mudah dikelola ketika penyimpanan gambar dan pemformatan bingkai gambar diperlakukan secara terpisah:

- **Gambar tertanam** membuat presentasi berdiri sendiri dan paling dapat diandalkan untuk berbagi serta rendering sisi‑server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar tertaut** dapat membuat paket lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia di jalur atau lokasi yang disimpan.
- **Pemotongan** pada awalnya tidak destruktif. Piksel tersembunyi tetap tertanam hingga wilayah yang dipotong dihapus secara eksplisit atau dihapus selama kompresi.
- **Kompresi** dapat mengurangi ukuran file secara signifikan untuk gambar raster yang terlalu besar, tetapi mengorbankan resolusi sumber. Kompresi sebaiknya diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **Gambar SVG** sebaiknya tetap sebagai SVG ketika preservasi vektor penting. Ekstrak SVG yang tertanam secara langsung ketika Anda membutuhkan sumber vektor itu sendiri. Ekspor slide raster selalu mengonversi slide yang dirender menjadi piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) yang ada bila memungkinkan alih‑alih memuat berulang kali file yang sama ke dalam alur kerja presentasi.

Untuk presentasi besar, optimasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya ketika penyuntingan di kemudian tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan menjadi bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara bingkai gambar dan sumber gambar?**

[IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) mewakili sumber gambar yang terkait dengan presentasi. [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta pemformatan tingkat bingkai seperti ukuran, rotasi, nilai pemotongan, efek, dan kunci.

**Haruskah saya menanamkan atau menautkan gambar?**

Tanamkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang disengaja dan lokasi eksternal dapat dipertahankan secara andal.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak secara langsung. Pengaturan pemotongan standar menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di bawahnya. Gunakan [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) atau kompresi gambar dengan penghapusan wilayah yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Bisakah saya mengembalikan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat mengurangi resolusi raster yang disimpan, dan penghapusan wilayah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi bila pengeditan beresolusi tinggi di kemudian hari mungkin diperlukan.

**Bagaimana seharusnya gambar SVG ditangani?**

Pertahankan konten SVG sebagai SVG ketika keakuratan vektor penting. [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) yang tertanam dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana cara menghindari cast tidak aman saat membaca slide yang ada?**

Periksa tipe bentuk sebelum menggunakan anggota khusus bingkai gambar. Pencocokan pola dengan [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) atau memfilter koleksi bentuk berdasarkan antarmuka tersebut menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi bingkai gambar.