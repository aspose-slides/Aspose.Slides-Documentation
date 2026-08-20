---
title: Kelola Bentuk Presentasi dalam .NET
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/net/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- cari bentuk
- klon bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk interop
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- rata bentuk
- balikkan bentuk
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, mengklon, menghapus, menyembunyikan, mengubah urutan, mengekspor, meratakan, dan membalik bentuk presentasi dengan Aspose.Slides untuk .NET."
---
## **Ringkasan**

Aspose.Slides for .NET merepresentasikan bentuk‑bentuk pada slide sebagai urutan [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/). Koleksi tersebut sekaligus tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukan mereka: indeks `0` adalah bentuk paling belakang, sedangkan indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model itu. Pertama dijelaskan cara mengidentifikasi bentuk secara andal, kemudian ditunjukkan cara menyalin, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir membahas pemformatan tingkat tata letak, ekspor SVG, perataan, dan pengaturan flip. Setiap contoh berdiri sendiri, sehingga Anda dapat menggunakan hanya operasi yang diperlukan alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi memang praktis saat memproses file yang sudah diketahui, tetapi bukan pengenal yang stabil. Penambahan, penghapusan, atau perubahan urutan bentuk dapat mengubah indeksnya. Pilih pengenal menurut cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/name/) berguna untuk templat yang dikendalikan pengembang dan mudah dilihat di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan bila kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/alternativetext/) berguna bila deskripsi aksesibilitas atau tag yang disediakan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan gunakan teks aksesibilitas yang bermakna secara diam‑diam sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/officeinteropshapeid/) adalah pengenal baca‑saja yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan bila berintegrasi dengan PowerPoint atau bila Anda memerlukan referensi yang tidak ambigu selama masa hidup bentuk. Bentuk yang disalin atau dibuat kembali adalah bentuk yang berbeda dan menerima ID nya masing‑masing.

Properti [UniqueId](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/uniqueid/) yang terkait memiliki cakupan presentasi, tetapi ditujukan untuk add‑in dan dapat dipetakan ulang. Jangan perlakukan sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan `Name` dengan perbandingan ordinal dan melaporkan ID interop berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Ketika operasi bersifat khusus pada tipe bentuk, periksa antarmuka sebelum menggunakan anggota spesifik tipe. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Modifikasi Koleksi Bentuk**

Metode tambahkan, klon, hapus, dan ubah urutan beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan bentuk, jangan lagi mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Klon Bentuk**

[AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addclone/) membuat salinan independen dan menambahkannya ke koleksi target. [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukuran; overload dengan lebar dan tinggi dapat mengubah ukuran juga.

Contoh membuat slide tujuan, mengklon persegi panjang berlabel ke depan, dan menyisipkan klon kedua ke belakang. Perubahan pada salah satu klon tidak memodifikasi bentuk sumber.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Klon menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengenal logis baru pada klon bila nilai tersebut harus unik. Sumber daya yang dipakai oleh bentuk kompleks ditangani oleh presentasi, namun klon tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[Remove](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berbasis indeks, lakukan penelusuran dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca `slide.Shapes[i]`, bukan item koleksi tetap, dan tidak melakukan casting bentuk yang tidak perlu.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk selanjutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga konektor, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Sembunyikan Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/hidden/) ke `true` mempertahankan bentuk dalam koleksi tetapi mencegahnya muncul dalam tampilan slide biasa. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Menyembunyikan bukan berarti menghapus atau mengamankan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari file presentasi.

### **Ubah Urutan Z**

Bentuk yang tumpang tindih digambar sesuai urutan koleksi. [Reorder](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/reorder/) memindahkan bentuk yang ada ke indeks target tanpa menyalinnya. Indeks `0` adalah belakang; `Count - 1` adalah depan.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Persegi panjang dibuat dulu dan pada awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan z setelah menambahkan atau mengklon semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diinginkan.

## **Inspeksi Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang berposisi serupa pada slide normal. Periksa bentuk tata letak saat Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/fillformat/) dan [LineFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/lineformat/) pada bentuk tata letak tanpa mengasumsikan semua bentuk merupakan `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Mengedit tata letak dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau memiliki penimpaan lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

[WriteAsSvg](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/writeassvg/) menulis konten yang dirender dari satu bentuk ke aliran. Hasilnya berisi bentuk saja, bukan latar belakang slide seluruhnya atau bentuk‑bentuk tetangga.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Biarkan presentasi tetap terbuka saat melakukan render. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan keseluruhan komposisi, ekspor slide daripada bentuk individual. Pemanggil memiliki aliran dan harus membuangnya.

## **Ratakan Bentuk**

Overload [SlideUtil.AlignShapes](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/alignshapes/) meratakan semua bentuk atau indeks koleksi yang dipilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/net/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Setel `alignToSlide` ke `true` untuk menggunakan tepi slide; setel ke `false` untuk meratakan bentuk yang dipilih relatif satu sama lain.

Contoh ini meratakan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan diubah menjadi indeks terkini tepat sebelum perataan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Perataan mengubah posisi, bukan urutan z. Perataan relatif biasanya membutuhkan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung ulang indeks bila Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/net/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `FlipH` dan `FlipV`‑nya memakai [NullableBool](https://reference.aspose.com/slides/id/net/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi input di bawah berisi satu bentuk yang belum dibalik.

![Bentuk sebelum dibalik](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan mengganti hanya dua pengaturan flip. Hal ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/frame/) baru menggantikan seluruh frame.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

Bentuk yang disimpan kini dicerminkan secara horizontal dan vertikal sementara posisi, ukuran, dan rotasinya tetap.

![Bentuk setelah dibalik](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengenal bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik pakai konvensi `Name` atau `AlternativeText` yang tervalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk kerja interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari urutan z?**

Tidak. Bentuk tersembunyi tetap berada di koleksi pada indeks yang sama. Ia dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang diklon muncul di depan bentuk lain?**

`AddClone` menambahkan klon ke akhir koleksi, yang merupakan depan urutan z. Gunakan `InsertClone` untuk memilih indeks awal atau `Reorder` setelah semua bentuk ditambahkan.