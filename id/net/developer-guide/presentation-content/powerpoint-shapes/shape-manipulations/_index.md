---
title: Kelola Bentuk Presentasi di .NET
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/net/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- temukan bentuk
- gandakan bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk interop
- teks alternatif bentuk
- titik penyesuaian bentuk
- penyesuaian bentuk preset
- geometri bentuk
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
description: "Pelajari cara mengidentifikasi, menyesuaikan, menggandakan, menghapus, menyembunyikan, menyusun ulang, mengekspor, meratakan, dan membalik bentuk presentasi dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides for .NET merepresentasikan bentuk pada slide sebagai koleksi terurut [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/). Koleksi ini sekaligus tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukan mereka: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal dan memodifikasi titik penyesuaian bentuk yang telah ditentukan, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan menyusun ulang bentuk. Bagian akhir mencakup pemformatan pada tingkat layout, ekspor SVG, perataan, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Mengidentifikasi dan Menemukan Bentuk**

Indeks koleksi memang praktis saat memproses file yang sudah diketahui, tetapi bukan pengidentifikasi yang stabil. Penambahan, penghapusan, atau penyusunan ulang sebuah bentuk dapat mengubah indeksnya. Pilih pengidentifikasi menurut cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/name/) berguna untuk templat yang dikendalikan developer dan mudah diperiksa di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan jika kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/alternativetext/) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalkan atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan menyalahgunakan teks aksesibilitas yang bermakna sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/officeinteropshapeid/) adalah pengidentifikasi read‑only yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh PowerPoint interop. Gunakan ketika berintegrasi dengan PowerPoint atau ketika membutuhkan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat ulang adalah bentuk yang berbeda dan menerima IDnya masing‑masing.

Properti terkait [UniqueId](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/uniqueid/) memiliki ruang lingkup presentasi, tetapi ditujukan untuk add‑in dan dapat dipindahtangankan. Jangan anggap sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan `Name` dengan perbandingan ordinal dan melaporkan interop ID pada level slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

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

Ketika sebuah operasi spesifik pada tipe bentuk, periksa antarmuka sebelum menggunakan anggota spesifik tipe. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama merupakan [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).

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

## **Mengidentifikasi dan Memodifikasi Penyesuaian Bentuk yang Telah Ditentukan**

Bentuk geometri preset dapat mengekspos titik penyesuaian yang mengontrol fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses mereka melalui koleksi read‑only [IGeometryShape.Adjustments](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/adjustments/). Koleksi itu sendiri disediakan oleh bentuk, tetapi setiap [IAdjustValue](https://reference.aspose.com/slides/id/net/aspose.slides/iadjustvalue/) berisi nilai yang dapat diubah.

Jangan bergantung hanya pada indeks koleksi yang tetap. Lakukan iterasi melalui penyesuaian dan periksa properti read‑only [Type](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/type/), yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/net/aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikendalikan penyesuaian. Properti read‑only [Name](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/name/) memberikan informasi identifikasi tambahan dan sangat berguna ketika sebuah preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan properti nilai yang sesuai dengan makna penyesuaian:

| Tipe Penyesuaian | Tujuan | Nilai yang Diubah |
|---|---|---|
| `CornerSize` | Ukuran sudut melengkung | [RawValue](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Ketebalan ekor panah | `RawValue` |
| `ArrowheadLength` | Panjang kepala panah | `RawValue` |
| `ArrowheadWidth` | Lebar kepala panah | `RawValue` |
| `StartAngle` | Sudut awal pai atau busur | [AngleValue](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Sudut akhir pai atau busur | `AngleValue` |

`Type` dan `Name` tidak dapat ditetapkan. `RawValue` adalah integer read/write dalam satuan geometri native preset, sedangkan `AngleValue` adalah sudut read/write dalam derajat. Jumlah, urutan, makna, dan rentang nilai yang valid tergantung pada preset [ShapeType](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/shapetype/). Nilai yang valid untuk satu preset mungkin tidak valid atau memiliki efek berbeda untuk preset lain.

Ketika `Type` adalah `ShapeAdjustmentType.Custom`, API tidak mengenali makna semantik standar. Periksa `Name`, tipe preset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali makna dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari satu kali sebelum memilih nilai. Artikel [Connector](/slides/id/net/connector/) memperlihatkan situasi ini dengan penyesuaian tikungan connector.

Contoh lengkap berikut membuat versi default dan versi yang dimodifikasi dari tiga bentuk preset. Ia mengiterasi setiap penyesuaian, melaporkan `Name` dan `Type`‑nya, mengubah nilai terkait ukuran melalui `RawValue`, mengubah sudut melalui `AngleValue`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menampilkan persegi panjang bulat, panah empat arah, dan pai yang telah disesuaikan.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Menambahkan header untuk kolom bentuk default dan yang disesuaikan.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Memeriksa tipe semantik sebelum mengubah nilai membuat kode eksplisit mengenai maksudnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki arti yang sama pada bentuk preset yang berbeda.

## **Memodifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan susun ulang beroperasi pada koleksi secara langsung. Jika sebuah operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Menggandakan Bentuk**

[AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addclone/) membuat salinan independen dan menambahkannya ke koleksi target. [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan salinan tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat meresize juga.

Contoh membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan salinan kedua di belakang. Perubahan pada salah satu salinan tidak memodifikasi bentuk sumber.

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

Penggandaan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengidentifikasi logis baru pada salinan bila nilai‑nilai tersebut harus unik. Sumber daya yang digunakan oleh bentuk kompleks ditangani oleh presentasi, tetapi salinan tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Menghapus Bentuk**

[Remove](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, telusuri dari akhir agar setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca `slide.Shapes[i]`, bukan item koleksi tetap, dan tidak melakukan cast pada bentuk secara tidak perlu.

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

Setelah penghapusan, jumlah bentuk dan indeks bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga connector, animasi, dan fitur presentasi lain yang mungkin merujuk ke objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Menyembunyikan Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/hidden/) menjadi `true` menjaga bentuk tetap berada dalam koleksi tetapi mencegahnya muncul dalam tampilan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

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

Menyembunyikan bukan penghapusan atau keamanan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari file presentasi.

### **Mengubah Z‑Order**

Bentuk yang saling tumpang tindih digambar sesuai urutan koleksi. [Reorder](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/reorder/) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `Count - 1` adalah depan.

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

Persegi panjang dibuat terlebih dahulu dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan z‑order setelah menambah atau menggandakan semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah susunan yang dimaksud.

## **Memeriksa Bentuk pada Slide Layout**

Slide normal, slide layout, dan slide master memiliki koleksi bentuk terpisah. Bentuk dalam koleksi layout bukan objek yang sama dengan bentuk yang diposisikan serupa pada slide normal. Periksa bentuk layout ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh layout.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/fillformat/) dan [LineFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/lineformat/) pada bentuk layout tanpa mengasumsikan bahwa setiap bentuk adalah `AutoShape`.

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

Mengedit layout dapat memengaruhi beberapa slide yang menggunakannya. Sebelum mengubah bentuk layout, tentukan apakah slide normal mewarisi objek tersebut atau memiliki penimpaan lokal, dan uji setiap slide yang memakai layout itu.

## **Mengekspor Bentuk ke SVG**

[WriteAsSvg](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/writeassvg/) menulis konten yang dirender dari satu bentuk ke aliran. Hasilnya berisi bentuk tersebut, bukan latar belakang seluruh slide atau bentuk tetangga.

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

Biarkan presentasi tetap terbuka saat merender. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide alih‑alih bentuk individu. Pemanggil memiliki aliran dan harus membuangnya.

## **Meratakan Bentuk**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/alignshapes/) memiliki overload yang meratakan semua bentuk atau indeks koleksi yang dipilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/net/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `alignToSlide` ke `true` untuk menggunakan tepi slide; atur ke `false` untuk meratakan bentuk yang dipilih relatif satu sama lain.

Contoh ini meratakan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan dikonversi ke indeksnya saat ini tepat sebelum perataan.

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

Perataan mengubah posisi, bukan z‑order. Perataan relatif biasanya memerlukan setidaknya dua bentuk, sedangkan distribusi horizontal atau vertikal membutuhkan cukup bentuk untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Membalik Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/net/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertical, serta rotasi. Nilai `FlipH` dan `FlipV`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/net/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi input di bawah ini berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan setiap nilai frame lainnya dan hanya mengganti dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/frame/) baru menggantikan seluruh frame.

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

Bentuk yang disimpan dipantulkan secara horizontal dan vertikal sambil mempertahankan posisi, ukuran, dan rotasinya.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengidentifikasi bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Pilih konvensi `Name` atau `AlternativeText` yang tervalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop pada tingkat slide.

**Apakah menyembunyikan bentuk menghapusnya dari z‑order?**

Tidak. Bentuk yang disembunyikan tetap berada dalam koleksi pada indeks yang sama. Ia dapat ditemukan, disusun ulang, diedit, atau ditampilkan kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`AddClone` menambahkan salinan ke akhir koleksi, yang merupakan depan z‑order. Gunakan `InsertClone` untuk memilih indeks awal atau `Reorder` setelah semua bentuk ditambahkan.

**Bisakah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian bentuk preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik iterasi melalui `IGeometryShape.Adjustments` dan periksa `IAdjustValue.Type`; gunakan `IAdjustValue.Name` sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari satu kali.