---
title: Kelola Placeholder Presentasi di .NET
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/net/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder diagram
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Placeholder adalah bentuk yang memesan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, isi, gambar, diagram, dan placeholder konten serbaguna. Tidak seperti bentuk biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides mengekspos informasi placeholder melalui properti [IShape.Placeholder](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/placeholder/). Properti ini mengembalikan objek [IPlaceholder](https://reference.aspose.com/slides/id/net/aspose.slides/iplaceholder/) atau `null` untuk bentuk normal. Gunakan [IPlaceholder.Type](https://reference.aspose.com/slides/id/net/aspose.slides/iplaceholder/type/) untuk menentukan apa yang dimaksudkan placeholder tersebut.

Antarmuka bentuk tetap penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten yang kosong biasanya direpresentasikan oleh sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).
- Placeholder gambar yang terisi dapat direpresentasikan oleh sebuah [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/).
- Placeholder diagram yang terisi dapat direpresentasikan oleh sebuah [IChart](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [IPlaceholder.Type](https://reference.aspose.com/slides/id/net/aspose.slides/iplaceholder/type/) maupun antarmuka bentuk runtime alih‑alih mengasumsikan bahwa setiap placeholder adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type] menjelaskan peran placeholder; tidak menjamin tipe runtime bentuk. Selalu gunakan pemeriksaan tipe sebelum mengakses anggota khusus teks, gambar, diagram, tabel, atau media.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder pada tingkat master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau lebih slide normal dan dapat mewarisi dari master.
3. Slide normal berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/getbaseplaceholder/) untuk naik satu tingkat dalam hierarki ini. Placeholder slide biasanya mengembalikan placeholder tata letaknya; placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `null` ketika bentuk tidak memiliki placeholder dasar.

Contoh berikut mencantumkan placeholder pada slide pertama dan melaporkan placeholder dasarnya:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Mengedit sebuah placeholder pada slide normal membuat atau mengubah penimpaan lokal untuk slide tersebut. Mengedit tata letak atau master yang terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan itu. Sebuah bentuk biasa lokal tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Ubah Teks dalam Placeholder**

Placeholder judul, judul‑tengah, subjudul, isi, dan teks biasanya mendukung teks. Periksa keberadaan [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) sebelum menggunakan properti [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/textframe/)‑nya.

Contoh berikut memperbarui placeholder judul pertama pada slide pertama dan menyimpan hasilnya:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Pola ini menghindari casting placeholder gambar, diagram, tabel, atau media ke [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/). Pola ini juga mengidentifikasi placeholder berdasarkan tujuan alih‑alih mengandalkan indeks bentuk yang rapuh.

## **Setel Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi waktu‑desain yang ditampilkan di placeholder kosong, seperti *Click to add title*. Tetapkan teks prompt khusus pada placeholder tata letak daripada mencoba menjangkaunya melalui koleksi bentuk slide normal. Akses tata letak melalui [ISlide.LayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/layoutslide/) dan iterasi melalui [ILayoutSlide.Shapes](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/shapes/).

Contoh berikut mengubah prompt judul dan subjudul pada tata letak yang digunakan oleh slide pertama:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Teks prompt bukan konten slide normal. Itu dimaksudkan untuk placeholder kosong dalam aplikasi penyunting seperti PowerPoint. Setelah pengguna atau program menyediakan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang ada pada slide yang menggunakan tata letak tersebut.

## **Perbarui Placeholder Gambar**

Ada dua kasus yang harus ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh sebuah [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/), ganti gambar melalui [IPictureFillFormat.Picture](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/picture/) dan [ISlidesPicture.Image](https://reference.aspose.com/slides/id/net/aspose.slides/islidespicture/image/).
- Jika masih merupakan placeholder kosong, tambahkan sebuah picture frame pada koordinat placeholder dengan [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addpictureframe/) dan hapus placeholder kosong.

Contoh berikut mendukung kedua kasus dan menyimpan presentasi:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Penggantian yang dibuat untuk placeholder kosong adalah picture frame lokal, bukan placeholder baru, karena [IShape.Placeholder](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/placeholder/) bersifat read‑only. Itu mempertahankan posisi yang dipesan namun tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder penting, siapkan dan isi placeholder di PowerPoint terlebih dahulu, lalu perbarui [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Manage Picture Frames](/slides/id/net/picture-frame/). Operasi tersebut berlaku pada picture frame atau picture fill, bukan pada metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang terisi dapat direpresentasikan oleh sebuah [IChart](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/). Contoh berikut menemukan diagram semacam itu dengan memeriksa tipe placeholder serta antarmuka runtime, mengubah judulnya, dan menyimpan berkas:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Placeholder konten umum biasanya memiliki [PlaceholderType.Object](https://reference.aspose.com/slides/id/net/aspose.slides/placeholdertype/). Di PowerPoint ia berfungsi sebagai peluncur untuk beberapa jenis konten, termasuk diagram, tabel, diagram alur, gambar, dan media. Setelah terisi, periksa antarmuka bentuk aktual untuk mengetahui apa yang dikandungnya. Tata letak khusus juga dapat mengekspos [PlaceholderType.Chart](https://reference.aspose.com/slides/id/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/id/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/id/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/id/net/aspose.slides/placeholdertype/), atau [PlaceholderType.Diagram](https://reference.aspose.com/slides/id/net/aspose.slides/placeholdertype/).

Aspose.Slides tidak mengubah placeholder [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) yang kosong menjadi [IChart](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/) hanya dengan mengubah [IPlaceholder.Type](https://reference.aspose.com/slides/id/net/aspose.slides/iplaceholder/type/); tipe tersebut bersifat read‑only. Untuk mengisi diagram atau area konten kosong secara programatik, tambahkan objek yang diperlukan pada koordinat placeholder lalu hapus placeholder kosong. Contoh berikut melakukannya untuk sebuah diagram:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan artikel manajemen diagram khusus [chart management articles](/slides/id/net/powerpoint-charts/) ketika Anda perlu mengganti kategori, seri, atau data workbook‑nya.

## **Contoh Lengkap: Perbarui Teks atau Konten Gambar**

Contoh end‑to‑end berikut membuka templat, mencari slide pertama untuk placeholder judul atau gambar, memeriksa tipe placeholder dan bentuk, memperbarui konten yang sesuai, dan menyimpan output. Contoh ini sengaja menghindari asumsi indeks bentuk atau casting semua placeholder ke antarmuka yang sama.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apa itu placeholder dasar?**

Placeholder dasar adalah bentuk yang bersesuaian pada tata letak atau master dari mana placeholder lain mewarisi. Gunakan [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/getbaseplaceholder/) untuk mengambilnya. Sebuah bentuk lokal biasa mengembalikan `null` karena tidak termasuk dalam hierarki placeholder.

**Bisakah saya mengubah semua judul slide dengan mengedit placeholder tata letak?**

Anda dapat mengubah pemformatan atau teks prompt yang diwarisi melalui tata letak, tetapi konten judul yang sudah ada disimpan pada slide normal. Untuk mengganti teks judul aktual di seluruh presentasi, iterasi slide dan perbarui setiap placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor slide, header, dan footer?**

Gunakan manajer header dan footer pada tingkat slide, tata letak, master, catatan, atau handout yang sesuai. Lihat [Manage Presentation Header and Footer](/slides/id/net/presentation-header-and-footer/) untuk contoh lengkap.