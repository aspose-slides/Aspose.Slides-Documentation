---
title: Mengelola Kotak Teks dalam Presentasi di .NET
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/net/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- menambah teks
- memperbarui teks
- membuat kotak teks
- memeriksa kotak teks
- menambah kolom teks
- menambah tautan hiper
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat, identifikasi, format, dan perbarui kotak teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET."
---
## **Pendahuluan**

Di Aspose.Slides untuk .NET, teks slide disimpan dalam bingkai teks yang menjadi milik bentuk. Antarmuka [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) mewakili bentuk yang paling umum memuat teks dan mengekspos teksnya melalui properti [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Catatan" %}}

Setiap auto shape mengimplementasikan [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), tetapi tidak setiap shape adalah auto shape atau mendukung bingkai teks. Saat memproses presentasi yang ada, periksa bahwa sebuah shape mengimplementasikan `IAutoShape` sebelum mengakses teksnya.

{{% /alert %}}

## **Membuat Kotak Teks pada Slide**

Untuk membuat kotak teks, tambahkan auto shape ke slide, tambahkan teks ke bingkai teksnya, dan simpan presentasi. Contoh berikut membuat kotak teks berbentuk persegi panjang:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Koordinat dan dimensi yang diberikan ke [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) diukur dalam poin. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) menginisialisasi bingkai teks dengan teks yang diberikan.

## **Memeriksa Bentuk Kotak Teks**

Gunakan properti [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) untuk menentukan apakah sebuah auto shape diperlakukan sebagai kotak teks. Ini berguna ketika sebuah presentasi berisi baik auto shape yang memuat teks maupun yang hanya grafis.

![Kotak teks dan sebuah bentuk](istextbox.png)

Contoh berikut memeriksa setiap auto shape dalam sebuah presentasi:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Sebuah auto shape yang baru ditambahkan tidak dianggap sebagai kotak teks sampai berisi teks yang tidak kosong. Anda dapat menyediakan teks tersebut melalui [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) atau [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Menambahkan atau menetapkan string kosong membuat `IsTextBox` tetap `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Dua pemanggilan pertama mencetak `True`; dua pemanggilan terakhir mencetak `False`.

## **Menemukan Bentuk yang Memiliki Bingkai Teks**

Kode pemrosesan teks generik dapat menerima sebuah [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) tanpa mengetahui objek presentasi mana yang menampungnya. Gunakan properti read‑only [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) untuk menavigasi kembali ke [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pemiliknya.

Untuk bingkai teks yang dimiliki oleh sebuah auto shape atau bentuk lain yang memuat teks, `ParentShape` berisi pemiliknya dan [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) bernilai `null`. Periksa nilai yang dikembalikan sebelum mengaksesnya. Untuk mengidentifikasi pemilik shape maupun sel tabel, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/net/search-and-replace-text/).

## **Mendapatkan Kotak Teks Bentuk**

Mulai dari Aspose.Slides untuk .NET 26.11, [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) mengembalikan area teks yang ditentukan oleh geometri bentuk induk. Koordinat dan dimensi berada dalam poin, relatif terhadap sudut kiri‑atas bentuk tersebut. Misalnya, elips memiliki kotak teks yang lebih kecil daripada batas luarnya.

Kotak ini mendeskripsikan bentuk, bukan karakter yang dirender. Mengubah teks atau margin bingkai teks tidak mengubahnya menjadi ukuran teks yang ditempati. Gunakan [paragraph bounds](/slides/id/net/paragraph-bounds/) atau [portion bounds](/slides/id/net/portion-bounds/) untuk pengukuran teks yang dirender.

Setelah [installing Aspose.Slides for .NET](/slides/id/net/installation/) 26.11 atau yang lebih baru, jalankan contoh ini untuk menggambar kotak teks geometri dengan warna merah. Bentuk‑bentuk tidak diputar dan tidak dikelompokkan, sehingga menambahkan posisi X/Y mereka cukup untuk menempatkan overlay pada slide.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

Untuk bentuk 200 × 100 poin di atas, kotak mengembalikan `(0, 0, 200, 100)`; elips mengembalikan kira‑kira `(29.289, 14.645, 141.421, 70.711)`. Metode ini juga membaca kotak teks yang dideklarasikan pada geometri khusus. Ia tidak menerapkan rotasi ruang slide atau transformasi grup; perhitungkan hal‑hal tersebut secara terpisah saat memposisikan overlay. Bingkai teks tanpa bentuk geometri, seperti bingkai teks sel tabel, dapat melempar `InvalidOperationException`.

## **Menambahkan Kolom ke Kotak Teks**

Properti [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) membagi bingkai teks menjadi beberapa kolom, sementara [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) menetapkan jarak antar kolom dalam poin. Kedua pengaturan termasuk dalam [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) dan dapat diubah melalui bingkai teks kotak teks yang ada. Teks akan mengalir kembali antar kolom dalam bentuk yang sama; tidak berlanjut ke bentuk lain.

Contoh berikut membuat kotak teks tiga kolom dengan jarak 10 poin antar kolom, menyimpan presentasi, dan membaca kembali pengaturan yang disimpan dari file keluaran:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Mengekstrak Teks dari Kolom Individual**

Gunakan [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) untuk mengambil teks yang ditetapkan ke setiap kolom visual dalam sebuah bingkai teks yang ada. Metode ini mengembalikan satu string untuk tiap kolom, dalam urutan baca berbasis kolom. Bingkai teks satu kolom menghasilkan array dengan satu elemen, dan kolom kosong direpresentasikan dengan string kosong. String yang dihasilkan hanya berisi teks polos; format pada tingkat bagian tidak dipertahankan.

Ini berguna ketika Anda perlu:

- Mengekstrak teks sambil mempertahankan urutan baca berbasis kolom.
- Mengindeks atau membandingkan konten slide multi‑kolom.
- Mengekspor tiap kolom ke file terpisah, field basis data, atau tujuan lainnya.
- Memeriksa bagaimana teks didistribusikan ulang setelah mengubah [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), jenis huruf, atau ukuran bingkai teks.

Metode ini melaporkan teks yang didistribusikan dalam [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) saat ini; ia tidak secara otomatis mengalirkan teks antar bentuk atau kotak teks yang terpisah. Distribusi kolom dapat dipengaruhi oleh ketersediaan huruf dan pengaturan tata letak teks lainnya, jadi pastikan huruf yang diperlukan tersedia ketika hasil yang konsisten penting.

Contoh berikut memuat sebuah presentasi, menemukan auto shape multi‑kolom pertama dengan bingkai teks, membaca jumlah kolom yang dikonfigurasi, dan menulis teks dari setiap kolom ke file terpisah. Bentuk yang tidak menyediakan bingkai teks akan dilewati.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Memperbarui Teks**

Untuk memperbarui teks di seluruh presentasi, iterasikan slide dan shape, pilih auto shape, lalu edit bagian‑bagian teksnya. Bekerja pada tingkat bagian memungkinkan Anda mengubah baik teks maupun format karakter.

Contoh berikut menggantikan setiap kemunculan `years` dengan `months` dalam teks auto‑shape dan membuat setiap bagian yang terpengaruh menjadi tebal:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Ini hanya memperbarui teks pada auto shape. Teks yang tersimpan dalam tabel, diagram, SmartArt, atau shape yang dikelompokkan memerlukan iterasi koleksi objek masing‑masing.

## **Menambahkan Kotak Teks dengan Tautan Hiper**

Tautan hiper dapat diberikan pada bagian teks tertentu, sehingga hanya teks itu yang berfungsi sebagai tautan yang dapat diklik. Gunakan [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) untuk mengaitkan bagian tersebut dengan URL eksternal.

Contoh berikut membuat teks bertautan dan menyimpannya ke sebuah presentasi:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks pada slide master atau tata letak?**

Sebuah [placeholder](/slides/id/net/manage-placeholder/) dapat mewarisi posisi dan formatnya dari sebuah [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) atau [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). Kotak teks biasa adalah shape independen pada slide tempat ia dibuat dan tidak memperoleh perilaku placeholder ketika tata letak berubah.

**Bagaimana saya dapat mengganti teks tanpa mengubah teks di diagram, tabel, atau SmartArt?**

Batasi penelusuran hanya pada shape yang mengimplementasikan [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), seperti yang ditunjukkan dalam contoh Memperbarui Teks. Diagram, tabel, dan SmartArt menyimpan teks dalam model objek mereka sendiri, sehingga tidak dimodifikasi oleh loop tersebut.