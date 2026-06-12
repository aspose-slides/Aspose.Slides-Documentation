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
- format isi
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk .NET menghitung dan menerapkan properti bentuk efektif untuk rendering PowerPoint yang akurat."
---
## **Gambaran Umum**

Topik ini menjelaskan perbedaan antara properti **lokal** dan **efektif**. Nilai lokal adalah nilai yang ditetapkan secara langsung pada tingkat pemformatan tertentu, seperti:

1. Properti bagian pada slide.
1. Gaya teks bentuk prototipe pada tata letak atau slide master, ketika bentuk bingkai teks bagian memiliki satu.
1. Pengaturan teks global dalam presentasi.

Nilai lokal dapat didefinisikan atau diabaikan pada tingkat mana pun. Ketika Aspose.Slides membutuhkan pemformatan akhir "as rendered", ia menyelesaikan rantai pewarisan dan mengembalikan nilai **efektif**. Anda dapat memperolehnya dengan memanggil metode `GetEffective` pada objek format lokal.

Contoh berikut menunjukkan cara mendapatkan nilai efektif. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) dengan bingkai teks dan setidaknya satu bagian.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Data pemformatan efektif mewakili pemformatan yang dihitung saat ini setelah pewarisan diterapkan. Pada implementasi saat ini, beberapa objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformateffectivedata/), dapat disimpan dalam cache secara internal. Memanggil `GetEffective` kembali setelah mengubah format induk atau yang diwarisi dapat menyegarkan data yang di-cache, dan objek yang sebelumnya diperoleh mungkin tidak lagi merepresentasikan keadaan sebelumnya. Jika Anda perlu mempertahankan nilai efektif untuk penggunaan kemudian, salin properti yang diperlukan, seperti tinggi font, warna isi, gaya font, atau perataan, ke dalam objek data Anda sendiri.
{{% /alert %}}

## **Dapatkan Properti Efektif Kamera**

Aspose.Slides memungkinkan Anda untuk mendapatkan properti efektif kamera. Antarmuka [ICameraEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/icameraeffectivedata/) merepresentasikan objek yang tidak dapat diubah yang berisi properti kamera efektif. Sebuah instance [ICameraEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/icameraeffectivedata/) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk kamera. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Dapatkan Properti Efektif Light Rig**

Aspose.Slides memungkinkan Anda untuk mendapatkan properti efektif light rig. Antarmuka [ILightRigEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ilightrigeffectivedata/) merepresentasikan objek yang tidak dapat diubah yang berisi properti light rig efektif. Sebuah instance [ILightRigEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ilightrigeffectivedata/) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk light rig. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Dapatkan Properti Efektif Bentuk Bevel**

Aspose.Slides memungkinkan Anda untuk mendapatkan properti efektif bentuk bevel. Antarmuka [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ishapebeveleffectivedata/) merepresentasikan objek yang tidak dapat diubah yang berisi properti relief permukaan efektif untuk sebuah bentuk. Sebuah instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ishapebeveleffectivedata/) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk bevel atas sebuah bentuk. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Dapatkan Properti Efektif Bingkai Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti efektif bingkai teks. Antarmuka [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformateffectivedata/) berisi properti pemformatan bingkai teks efektif.

Contoh kode berikut menunjukkan cara mendapatkan properti pemformatan bingkai teks efektif. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) dengan bingkai teks.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Dapatkan Properti Efektif Gaya Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti efektif gaya teks. Antarmuka [ITextStyleEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/itextstyleeffectivedata/) berisi properti gaya teks efektif.

Contoh kode berikut menunjukkan cara mendapatkan properti gaya teks efektif. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) dengan bingkai teks.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Dapatkan Nilai Tinggi Font Efektif**

Dengan Aspose.Slides, Anda dapat mendapatkan tinggi font efektif. Kode berikut menunjukkan bagaimana tinggi font efektif sebuah bagian berubah setelah nilai tinggi font lokal ditetapkan pada berbagai tingkat struktur presentasi.

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Dapatkan Format Isi Efektif untuk Tabel**

Dengan Aspose.Slides, Anda dapat mendapatkan pemformatan isi efektif untuk berbagai bagian tabel. Antarmuka [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformateffectivedata/) berisi properti pemformatan isi efektif. Pemformatan sel memiliki prioritas lebih tinggi daripada pemformatan baris, pemformatan baris memiliki prioritas lebih tinggi daripada pemformatan kolom, dan pemformatan kolom memiliki prioritas lebih tinggi daripada pemformatan seluruh tabel.

Akibatnya, properti [ICellFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/icellformateffectivedata/) digunakan untuk menggambar sel tabel. Contoh kode berikut menunjukkan cara mendapatkan pemformatan isi efektif untuk berbagai bagian tabel. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/).

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

**Apakah `GetEffective` mengembalikan snapshot?**

Tidak selalu. Data efektif mewakili pemformatan yang dihitung setelah pewarisan diterapkan, tetapi beberapa objek data efektif dapat disimpan dalam cache secara internal. Panggilan `GetEffective` berikutnya dapat menghitung ulang pemformatan dan menyegarkan data yang di-cache, sehingga objek yang sebelumnya diperoleh tidak boleh dianggap sebagai snapshot yang tahan lama.

**Kapan saya harus membaca properti efektif lagi?**

Panggil `GetEffective` lagi setelah mengubah pemformatan lokal, gaya induk, pemformatan tata letak, pemformatan master, atau nilai default pada tingkat presentasi. Panggilan berikutnya akan mengevaluasi kembali hierarki pemformatan dan mengembalikan hasil efektif saat ini.

**Apakah mengubah atau menghapus slide tata letak/master memengaruhi properti efektif yang sudah diambil?**

Ya, tetapi perubahan tersebut tercermin pada panggilan `GetEffective` berikutnya. Jika sumber pemformatan induk diubah atau dihapus, data efektif yang sebelumnya diperoleh mungkin sudah usang. Setelah `GetEffective` dipanggil lagi, Aspose.Slides akan mengevaluasi kembali pohon pemformatan dan font, warna, ukuran, atau nilai lainnya dapat berubah.

**Dapatkah saya memodifikasi nilai melalui objek data efektif?**

Tidak. Objek data efektif hanya menampilkan nilai yang telah dihitung. Lakukan perubahan pada objek pemformatan lokal, kemudian peroleh kembali nilai efektifnya.

**Apa yang terjadi jika sebuah properti tidak diatur pada tingkat bentuk, tata letak/master, atau pengaturan global?**

Nilai efektif ditentukan oleh mekanisme default, yang mencakup nilai default PowerPoint dan Aspose.Slides. Nilai yang terpecahkan tersebut menjadi bagian dari data efektif saat ini.

**Dari nilai font efektif, dapatkah saya mengetahui tingkat mana yang menyediakan ukuran atau jenis huruf?**

Tidak secara langsung. Data efektif mengembalikan nilai akhir. Untuk menemukan sumbernya, periksa nilai lokal pada bagian, paragraf, bingkai teks, dan gaya teks pada tata letak, master, serta tingkat presentasi untuk melihat di mana definisi eksplisit pertama muncul.

**Mengapa nilai efektif kadang terlihat identik dengan nilai lokal?**

Karena nilai lokal akhirnya menjadi nilai akhir (tidak ada pewarisan tingkat lebih tinggi yang diperlukan). Dalam kasus tersebut, nilai efektif cocok dengan nilai lokal.

**Kapan saya harus menggunakan properti efektif, dan kapan hanya menggunakan yang lokal?**

Gunakan data efektif ketika Anda memerlukan hasil "as rendered" setelah semua pewarisan diterapkan, misalnya untuk menyelaraskan warna, indentasi, atau ukuran. Jika Anda perlu mempertahankan nilai tersebut terlepas dari perubahan pemformatan selanjutnya, salin properti yang dibutuhkan ke dalam objek Anda sendiri. Jika Anda perlu mengubah pemformatan pada tingkat tertentu, ubah properti lokal dan kemudian, bila perlu, baca kembali data efektif untuk memverifikasi hasilnya.