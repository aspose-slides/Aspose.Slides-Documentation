---
title: Mengonversi Slide Presentasi ke Gambar di .NET
linktitle: Slide ke Gambar
type: docs
weight: 41
url: /id/net/convert-slide/
keywords:
- konversi slide
- ekspor slide
- slide ke gambar
- simpan slide sebagai gambar
- slide ke EMF
- slide ke PNG
- slide ke JPEG
- slide ke bitmap
- slide ke TIFF
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Konversi slide dari presentasi PPT, PPTX, dan ODP ke format PNG, JPEG, GIF, TIFF, EMF, dan format gambar lainnya dalam C# dengan Aspose.Slides untuk .NET."
---
## **Pendahuluan**

Aspose.Slides for .NET dapat merender slide individu dari presentasi PowerPoint dan OpenDocument sebagai PNG, JPEG, GIF, TIFF, dan format gambar lainnya.

Untuk mengonversi slide menjadi gambar, ikuti langkah‑langs berikut:

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Pilih slide yang ingin Anda render.
3. Jika diperlukan, konfigurasikan rendering dengan kelas [RenderingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/renderingoptions/) atau [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/).
4. Panggil metode [GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/islide/getimage/). Metode ini mengembalikan objek [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/).
5. Panggil metode [IImage.Save](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/save/) dan tentukan format output dengan nilai [ImageFormat](https://reference.aspose.com/slides/id/net/aspose.slides/imageformat/).

## **Mengonversi Slide ke Gambar PNG**

Konversi paling sederhana menggunakan pengaturan rendering default. Objek [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) yang dihasilkan dapat diproses di memori atau disimpan ke file.

Contoh C# berikut merender slide pertama dan menyimpannya sebagai gambar PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Mengonversi Slide ke Gambar dengan Ukuran Kustom**

Gunakan overload [GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/islide/getimage/) yang menerima nilai [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) untuk merender slide dengan dimensi piksel yang tepat.

Contoh berikut membuat gambar JPEG 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Mengonversi Slide dengan Catatan dan Komentar ke Gambar**

Secara default, gambar slide tidak menyertakan catatan atau komentar. Tetapkan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/notescommentslayoutingoptions/) ke properti [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) untuk mengontrol di mana catatan dan komentar muncul.

Contoh berikut menempatkan catatan yang dipotong di bawah slide dan komentar di sebelah kanannya:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Untuk konversi slide ke gambar, jangan atur properti [NotesPosition](https://reference.aspose.com/slides/id/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) ke [BottomFull](https://reference.aspose.com/slides/id/net/aspose.slides.export/notespositions/). Catatan dapat berisi lebih banyak teks daripada ukuran gambar tetap dapat menampung. Gunakan [BottomTruncated](https://reference.aspose.com/slides/id/net/aspose.slides.export/notespositions/) sebagai gantinya.
{{% /alert %}}

## **Mengonversi Slide ke Gambar Menggunakan Opsi TIFF**

Kelas [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/) memungkinkan Anda mengontrol ukuran, resolusi, dan properti lainnya dari gambar TIFF yang dirender.

Contoh berikut merender slide pertama sebagai gambar TIFF 2160 × 2880 dengan 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Mengonversi Semua Slide ke Gambar**

Iterasikan koleksi slide untuk mengonversi seluruh presentasi menjadi serangkaian gambar. Slide tersembunyi termasuk kecuali Anda secara eksplisit melewatinya.

Contoh berikut merender setiap slide sebagai gambar JPEG dengan faktor skala horizontal dan vertikal sebesar 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Membuat Output Metafile Ditingkatkan**

Enhanced Metafile (EMF) berguna ketika grafik berbasis vektor harus dipertukarkan dengan Microsoft Office atau aplikasi Windows lain yang mendukung metafile Windows. Tidak seperti gambar berbasis piksel, EMF dapat mempertahankan operasi gambar vektor yang dapat diskalakan tanpa kehilangan ketajaman yang sama. Namun, EMF terutama merupakan format kompatibilitas untuk aplikasi dengan dukungan metafile Windows, bukan format pertukaran universal. Selain itu, konten slide yang kompleks, seperti gambar bitmap dan beberapa efek, dapat disimpan sebagai elemen raster di dalam kontainer metafile vektor.

### **Ekspor Slide ke EMF**

Metode [ISlide.WriteAsEmf](https://reference.aspose.com/slides/id/net/aspose.slides/islide/writeasemf/) menulis [ISlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/) ke aliran target dalam format EMF. Contoh berikut memuat presentasi, memilih slide pertama, dan menulisnya ke aliran file EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Pemanggil memiliki aliran yang diteruskan ke [ISlide.WriteAsEmf](https://reference.aspose.com/slides/id/net/aspose.slides/islide/writeasemf/) dan harus menutup atau membuangnya. Aspose.Slides menulis pada posisi saat ini dari aliran dan membiarkan aliran tetap terbuka.

### **Mengonversi Gambar SVG ke EMF dan Menambahkannya ke Presentasi**

Gunakan [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/writeasemf/) untuk mengonversi konten SVG ke EMF. Byte yang dihasilkan dapat ditambahkan ke presentasi melalui [IImageCollection.AddImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimagecollection/addimage/) dan ditempatkan pada slide dengan [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addpictureframe/).

Contoh berikut membuat [SvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/svgimage/) dari markup SVG, mengonversinya ke EMF dalam memori, menyisipkan metafile pada slide pertama, dan menyimpan presentasi:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/writeasemf/) tidak mengambil kepemilikan aliran tujuan. Setelah menulis, posisi aliran berada di akhir data yang dihasilkan. Reset `Position` ke awal sebelum meneruskan aliran yang dapat dicari ke pembaca, seperti yang ditunjukkan di atas. Pertahankan aliran terbuka sampai konsumen selesai membacanya, dan buang setelahnya. Alternatifnya, panggil `ToArray` dan berikan array byte yang dikembalikan ke [IImageCollection.AddImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimagecollection/addimage/); `ToArray` mengembalikan buffer lengkap terlepas dari posisi aliran saat ini.

Generasi EMF tersedia pada sistem operasi yang didukung oleh build Aspose.Slides untuk .NET yang dipilih, tetapi rendering dapat berbeda antar platform ketika font atau ketergantungan grafik native tidak tersedia. Instal font yang digunakan oleh konten sumber atau konfigurasikan substitusi yang sesuai, ikuti [platform requirements](/slides/id/net/system-requirements/) untuk paket Aspose.Slides Anda, dan validasi hasilnya di aplikasi tujuan yang mengkonsumsi EMF. Aplikasi Linux dan macOS sering memiliki dukungan terbatas atau tidak konsisten untuk menampilkan dan mengedit metafile Windows.

## **Rendering Emoji Berwarna**

{{% alert title="Note" color="info" %}}
Untuk merender emoji berwarna dengan benar saat mengonversi slide presentasi ke gambar, font emoji yang digunakan dalam presentasi harus diinstal dan tersedia pada sistem yang melakukan konversi. Misalnya, jika presentasi menggunakan **Segoe UI Emoji** dan font ini tidak tersedia, emoji dapat muncul dalam monokrom pada gambar output.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung rendering slide dengan animasi?**

Tidak. Metode [GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/islide/getimage/) merender gambar statis slide dan tidak mengekspor animasi.

**Apakah slide tersembunyi dapat diekspor sebagai gambar?**

Ya. Slide tersembunyi dapat dirender seperti slide biasa. Termasuk mereka dalam loop pemrosesan, seperti contoh di atas.

**Apakah bayangan dan efek lain dipertahankan dalam gambar slide?**

Ya. Aspose.Slides merender bayangan, transparansi, dan efek grafis lain yang didukung dalam gambar slide.