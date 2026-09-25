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
- penyesuaian bentuk bawaan
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

Aspose.Slides for .NET merepresentasikan bentuk pada slide sebagai [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/) yang terurut. Koleksi tersebut merupakan tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukannya: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal dan memodifikasi titik penyesuaian bentuk bawaan, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan menyusun ulang bentuk. Bagian akhir mencakup pemformatan tingkat tata letak, ekspor SVG, perataan, dan pengaturan pembalikan. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi berguna saat memproses file yang sudah dikenal, tetapi bukan pengenal yang stabil. Penambahan, penghapusan, atau penyusunan ulang bentuk dapat mengubah indeksnya. Pilih pengenal berdasarkan cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/name/) berguna untuk templat yang dikontrol pengembang dan mudah diperiksa di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan jika kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/alternativetext/) berguna ketika deskripsi aksesibilitas atau tag yang disediakan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalkan atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam memanfaatkan teks aksesibilitas yang bermakna sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/officeinteropshapeid/) adalah pengenal baca‑saja yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ini saat mengintegrasikan dengan PowerPoint atau ketika Anda memerlukan referensi tak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat ulang merupakan bentuk yang berbeda dan menerima IDnya sendiri.

Properti terkait [UniqueId](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/uniqueid/) memiliki ruang lingkup presentasi, tetapi ditujukan untuk add‑in dan dapat dipertukarkan kembali. Ini tidak boleh diperlakukan sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Untuk contoh praktis membaca dan memperbarui teks alternatif judul serta deskripsi, lihat [Manage Alternative Text Titles and Descriptions](/slides/id/net/presentation-accessibility/). Gunakan teks alternatif untuk menjelaskan makna visual kepada pembaca, dan pisahkan dari nama bentuk yang digunakan kode untuk menemukan bentuk.

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

Ketika operasi spesifik untuk tipe bentuk, periksa antarmuka sebelum menggunakan anggota tipe‑spesifik. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).

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

## **Identifikasi dan Modifikasi Penyesuaian Bentuk Bawaan**

Bentuk geometri bawaan dapat mengekspos titik penyesuaian yang mengontrol fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses mereka melalui koleksi baca‑saja [IGeometryShape.Adjustments](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/adjustments/). Koleksi itu disediakan oleh bentuk, tetapi setiap [IAdjustValue](https://reference.aspose.com/slides/id/net/aspose.slides/iadjustvalue/) berisi nilai yang dapat diubah.

Jangan bergantung hanya pada indeks koleksi tetap. Iterasi melalui penyesuaian dan periksa properti baca‑saja [Type](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/type/), yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/net/aspose.slides/shapeadjustmenttype/)‑nya menggambarkan apa yang dikontrol oleh penyesuaian tersebut. Properti baca‑saja [Name](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/name/) memberikan informasi identifikasi tambahan dan sangat berguna ketika sebuah preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan properti nilai yang sesuai dengan makna penyesuaian:

| Tipe penyesuaian | Tujuan | Nilai yang diubah |
|---|---|---|
| `CornerSize` | Ukuran sudut bulat | [RawValue](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Ketebalan ekor panah | `RawValue` |
| `ArrowheadLength` | Panjang kepala panah | `RawValue` |
| `ArrowheadWidth` | Lebar kepala panah | `RawValue` |
| `StartAngle` | Sudut awal pai atau busur | [AngleValue](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Sudut akhir pai atau busur | `AngleValue` |

`Type` dan `Name` tidak dapat ditugaskan. `RawValue` adalah integer baca‑tulis dalam satuan geometri native preset, sementara `AngleValue` adalah sudut baca‑tulis dalam derajat. Jumlah, urutan, makna, dan rentang nilai yang sah bergantung pada [ShapeType](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/shapetype/) preset. Nilai yang sah untuk satu preset mungkin tidak sah atau menghasilkan efek berbeda pada preset lain.

Ketika `Type` adalah `ShapeAdjustmentType.Custom`, API tidak mengenali makna semantik standar. Periksa `Name`, tipe preset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali makna dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenal, periksa apakah tipe yang sama muncul lebih dari sekali sebelum memilih nilai. Artikel [Connector](/slides/id/net/connector/) menunjukkan situasi ini dengan penyesuaian lengkung penghubung.

Contoh lengkap berikut membuat versi default dan dimodifikasi dari tiga bentuk preset. Ia mengiterasi setiap penyesuaian, melaporkan `Name` dan `Type`‑nya, mengubah nilai terkait ukuran melalui `RawValue`, mengubah sudut melalui `AngleValue`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menampilkan persegi panjang bulat yang disesuaikan, panah empat arah, dan pai.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Menambahkan header untuk kolom bentuk default dan kolom bentuk yang disesuaikan.
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

Memeriksa tipe semantik sebelum mengubah nilai membuat kode eksplisit tentang maksudnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki makna yang sama pada berbagai bentuk preset.

## **Modifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan susun ulang beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Bentuk**

[AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addclone/) membuat salinan independen dan menambahkannya ke koleksi target. [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks urutan‑z yang ditentukan. Overload yang menerima koordinat memindahkan gandaan tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat meresize juga.

Contoh membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan gandaan kedua ke belakang. Perubahan pada salah satu gandaan tidak memodifikasi bentuk sumber.

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

Penggandaan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengenal logis baru pada gandaan bila nilai‑nilai tersebut harus unik. Sumber daya yang digunakan oleh bentuk kompleks ditangani oleh presentasi, tetapi gandaan tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[Remove](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, iterasi dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca `slide.Shapes[i]`, bukan item koleksi tetap, dan tidak melakukan casting bentuk secara tidak perlu.

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

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga penghubung, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari penampilan slide.

### **Sembunyikan Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/hidden/) ke `true` menjaga bentuk tetap berada di koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia untuk kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

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

Menyembunyikan bukan berarti menghapus atau mengamankan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari berkas presentasi.

### **Ubah Urutan Z**

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

Persegi panjang dibuat dulu dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan‑z setelah menambah atau menggandakan semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang dimaksud.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang berposisi serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/fillformat/) dan [LineFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/lineformat/) bentuk tata letak tanpa mengasumsikan bahwa setiap bentuk adalah `AutoShape`.

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

Menyunting tata letak dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau berisi penimpaan lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

[WriteAsSvg](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/writeassvg/) menulis konten terrender satu bentuk ke aliran. Hasilnya berisi bentuk tersebut, bukan latar belakang seluruh slide atau bentuk tetangga.

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

Jaga presentasi tetap terbuka saat merender. Output tergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide alih‑alih bentuk individual. Pemanggil memiliki aliran dan harus menutupnya.

## **Ratakan Bentuk**

Overload [SlideUtil.AlignShapes](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/alignshapes/) meratakan semua bentuk atau indeks koleksi terpilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/net/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Setel `alignToSlide` ke `true` untuk menggunakan tepi slide; setel ke `false` untuk meratakan bentuk terpilih relatif satu sama lain.

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

Perataan mengubah posisi, bukan urutan‑z. Perataan relatif biasanya membutuhkan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal membutuhkan cukup bentuk untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/net/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `FlipH` dan `FlipV`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/net/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tidak ditentukan/default.

Presentasi input di bawah berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan setiap nilai frame lainnya dan mengganti hanya dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/frame/) baru menggantikan seluruh frame.

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

Bentuk yang disimpan terbalik secara horizontal dan vertikal sementara posisi, ukuran, dan rotasinya tetap.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengenal bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `Name` atau `AlternativeText` yang tervalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari urutan‑z?**

Tidak. Bentuk tersembunyi tetap berada di koleksi pada indeks yang sama. Ia dapat ditemukan, disusun ulang, diedit, atau ditampilkan kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`AddClone` menambahkan gandaan ke akhir koleksi, yang merupakan depan urutan‑z. Gunakan `InsertClone` untuk memilih indeks awal atau `Reorder` setelah semua bentuk ditambahkan.

**Dapatkah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian bentuk preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik iterasi melalui `IGeometryShape.Adjustments` dan periksa `IAdjustValue.Type`; gunakan `IAdjustValue.Name` sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari sekali.