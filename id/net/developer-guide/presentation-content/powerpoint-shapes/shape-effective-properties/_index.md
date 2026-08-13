---
title: Dapatkan Properti Efektif Bentuk dari Presentasi di .NET
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/net/shape-effective-properties/
keywords:
- properti bentuk
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isian
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menggunakan Aspose.Slides untuk .NET guna membedakan pemformatan bentuk lokal, yang diwariskan, dan yang efektif dalam presentasi PowerPoint."
---
## **Memahami Properti Lokal, Warisan, dan Efektif**

Pemformatan PowerPoint dapat berasal dari beberapa tempat. Nilai yang disimpan langsung pada sebuah objek adalah **nilai lokal**. Jika nilai tersebut tidak diatur, PowerPoint akan melihat sumber pemformatan induk, seperti default paragraf, gaya teks, tata letak atau slide master, tema, atau default tingkat presentasi. Nilai-nilai tersebut adalah **nilai yang diwariskan**. Nilai yang tersisa setelah seluruh hierarki diselesaikan adalah **nilai efektif** — nilai yang digunakan untuk merender objek.

Misalnya, sebuah bagian teks mungkin tidak menentukan tinggi fontnya sendiri. Nilai lokal [FontHeight](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/fontheight/) menjadi `float.NaN`, yang berarti "tidak diatur di sini." Bagian tersebut dapat mewarisi tinggi dari paragrafnya, gaya teks default presentasi, atau sumber lain yang berlaku. Memanggil [GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/geteffective/) pada format bagian mengembalikan tinggi yang telah diselesaikan.

Gunakan dua jenis data pemformatan untuk tujuan yang berbeda:

- Baca atau ubah objek format lokal, seperti [IPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/), ketika Anda perlu mengontrol di mana nilai didefinisikan.
- Baca objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformateffectivedata/), ketika Anda memerlukan hasil akhir yang dirender. Data efektif bersifat hanya-baca.

## **Bandingkan Nilai Lokal, Warisan, dan Efektif**

Contoh lengkap berikut membuat sebuah bentuk dan menerapkan tinggi font pada tingkat presentasi, paragraf, dan bagian. Setiap langkah mencetak nilai yang didefinisikan pada tingkat tersebut dan nilai efektif yang dihasilkan untuk bagian teks yang sama. Ini juga menunjukkan mengapa data efektif harus dibaca kembali setelah perubahan pemformatan.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Tentukan nilai yang diwariskan pada dua tingkat yang berbeda.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Nilai lokal pada bagian menggantikan kedua nilai yang diwariskan.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Mengubah nilai yang diwariskan tidak menggantikan nilai lokal yang ada.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Bersihkan nilai lokal. Bagian kini kembali mewarisi dari paragraf.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Bersihkan nilai paragraf. Default presentasi kini menyediakan hasilnya.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Baca data efektif setelah perubahan sebelumnya.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Prioritas dalam contoh ini adalah pemformatan lokal bagian, kemudian pemformatan paragraf, kemudian default presentasi. Objek lain dapat memiliki rantai pewarisan yang berbeda, tetapi prinsipnya sama: nilai eksplisit yang lebih spesifik menang, dan [GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/geteffective/) mengembalikan hasil akhir.

## **Dapatkan Properti Teks Efektif**

Pemformatan teks dibagi menjadi beberapa objek:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/geteffective/) menyelesaikan properti bingkai teks seperti margin, penambatan, autofit, dan arah teks vertikal.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/id/net/aspose.slides/itextstyle/geteffective/) menyelesaikan pemformatan paragraf untuk setiap tingkat gaya teks.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/geteffective/) menyelesaikan properti paragraf seperti perataan, indentasi, dan bullet.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/geteffective/) menyelesaikan properti karakter seperti tinggi font, jenis huruf, warna, tebal, dan miring.

Untuk contoh berikut, `text-formatting.pptx` harus berisi setidaknya satu slide dan satu [AutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) dengan bingkai teks yang tidak kosong. AutoShape dapat muncul pada posisi apa pun dalam koleksi bentuk; kode mencari objek yang cocok dan memvalidasinya sebelum digunakan.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Dapatkan Properti 3D Efektif**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/geteffective/) mengembalikan satu objek [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformateffectivedata/) yang mengelompokkan semua pengaturan 3D yang telah diselesaikan. Properti [Camera](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformateffectivedata/beveltop/), dan [BevelBottom](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) menampilkan data efektif yang bersesuaian. Membaca pengaturan terkait ini secara bersamaan memudahkan pemahaman tampilan 3D akhir dari sebuah bentuk.

Untuk contoh ini, `shape-3d.pptx` harus berisi setidaknya satu bentuk pada slide pertama. Terapkan pengaturan kamera 3D, pencahayaan, atau bevel pada bentuk tersebut jika Anda menginginkan output berisi nilai selain default.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Dapatkan Pemformatan Tabel Efektif**

Pemformatan tabel dapat berasal dari gaya tabel serta dari format yang diterapkan pada seluruh tabel, sebuah kolom, baris, atau sel individual. Untuk konflik di antara isian yang didefinisikan secara eksplisit, prioritasnya adalah sel, baris, kolom, dan kemudian seluruh tabel. Format efektif sebuah sel adalah format akhir yang digunakan untuk menggambar sel tersebut.

Untuk contoh ini, `table-formatting.pptx` harus berisi setidaknya satu tabel pada slide pertama. Tabel tersebut harus memiliki setidaknya satu baris dan satu kolom. Kode mencari sebuah [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) alih-alih mengasumsikan bahwa `Shapes[0]` adalah tabel.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Jika Anda memerlukan warna bukan hanya jenis isian, pertama periksa [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformateffectivedata/filltype/) yang efektif, lalu baca properti yang berlaku untuk jenis tersebut — misalnya, [SolidFillColor](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) untuk isian solid.

## **Baca Ulang Data Efektif Setelah Perubahan**

Data efektif menggambarkan hierarki pemformatan pada saat diselesaikan. Panggil `GetEffective` lagi setelah mengubah apa pun yang dapat berpartisipasi dalam hierarki tersebut, termasuk:

- pemformatan lokal objek;
- default paragraf atau bingkai teks;
- gaya tabel, tabel, kolom, baris, atau format sel;
- pemformatan tata letak atau slide master;
- data tema atau default tingkat presentasi;
- tata letak atau master yang ditetapkan pada slide.

Jangan menyimpan objek data efektif sebagai snapshot permanen. Aspose.Slides dapat menyimpan beberapa data efektif di cache secara internal, dan panggilan `GetEffective` berikutnya dapat menyegarkan data tersebut. Jika Anda perlu membandingkan nilai sebelum dan sesudah perubahan, salin nilai skalar yang Anda perlukan — seperti tinggi font, warna, perataan, atau lebar bevel — ke variabel Anda sendiri sebelum melakukan perubahan.

Untuk mengubah nilai, perbarui objek format lokal yang sesuai dan kemudian panggil `GetEffective` untuk memverifikasi hasilnya. Objek data efektif itu sendiri bersifat hanya-baca.

## **FAQ**

**Bagaimana saya dapat mengetahui level mana yang memberikan nilai efektif?**

Data efektif berisi nilai akhir, bukan sumbernya. Periksa objek lokal yang berlaku mulai dari level paling spesifik ke luar. Untuk teks, ini dapat mencakup bagian, paragraf, bingkai teks, tata letak, master, tema, dan default presentasi. Nilai yang tidak terdefinisi seperti `float.NaN` atau `null` menunjukkan bahwa pencarian berlanjut ke level lain.

**Apa yang terjadi ketika tidak ada level yang mendefinisikan properti?**

Aspose.Slides menyelesaikan default PowerPoint atau pustaka yang sesuai. Nilai yang diselesaikan tersebut muncul dalam data efektif meskipun tidak ada objek lokal yang mendefinisikannya secara eksplisit.

**Mengapa nilai efektif kadang sama dengan nilai lokal?**

Nilai lokal memenangkan perhitungan pewarisan. Ini diharapkan ketika properti secara eksplisit diatur pada objek dan tidak ada aturan yang lebih spesifik yang menggantikannya.

**Kapan saya harus menggunakan data lokal dibandingkan data efektif?**

Gunakan data lokal untuk memeriksa atau mengedit tingkat pemformatan tertentu. Gunakan data efektif ketika Anda memerlukan tampilan akhir setelah pewarisan, aturan tema, dan gaya yang berlaku diselesaikan. [Contoh perbandingan lengkap](#compare-local-inherited-and-effective-values) memperlihatkan keduanya dalam alur kerja yang sama.