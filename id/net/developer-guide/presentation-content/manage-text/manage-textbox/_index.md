---
title: Kelola Kotak Teks dalam Presentasi di .NET
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/net/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- menambahkan teks
- memperbarui teks
- membuat kotak teks
- memeriksa kotak teks
- menambahkan kolom teks
- menambahkan tautan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat, identifikasi, format, dan perbarui kotak teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET."
---
## **Pendahuluan**

Di Aspose.Slides untuk .NET, teks slide disimpan dalam bingkai teks yang menjadi milik bentuk. Antarmuka [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) mewakili bentuk yang paling umum memuat teks dan mengekspos teksnya melalui properti [IAutoShape.TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Setiap auto shape mengimplementasikan [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/), tetapi tidak semua shape adalah auto shape atau mendukung bingkai teks. Saat memproses presentasi yang ada, periksa bahwa sebuah shape mengimplementasikan `IAutoShape` sebelum mengakses teksnya.
{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks, tambahkan sebuah auto shape ke slide, tambahkan teks ke bingkai teksnya, dan simpan presentasi. Contoh berikut membuat kotak teks berbentuk persegi panjang:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Koordinat dan dimensi yang diberikan ke [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addautoshape/) diukur dalam poin. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/addtextframe/) menginisialisasi bingkai teks dengan teks yang diberikan.

## **Periksa Bentuk Kotak Teks**

Gunakan properti [AutoShape.IsTextBox](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/istextbox/) untuk menentukan apakah sebuah auto shape diperlakukan sebagai kotak teks. Ini berguna ketika sebuah presentasi berisi baik auto shape yang memuat teks maupun yang hanya grafis.

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

Sebuah auto shape yang baru ditambahkan tidak dianggap sebagai kotak teks sampai ia berisi teks yang tidak kosong. Anda dapat memberikan teks tersebut melalui [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/addtextframe/) atau [ITextFrame.Text](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/text/). Menambahkan atau menetapkan string kosong membuat `IsTextBox` tetap `false`:

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

## **Temukan Bentuk yang Memiliki Bingkai Teks**

Kode pemrosesan teks generik mungkin menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) tanpa mengetahui objek presentasi mana yang memilikinya. Gunakan properti read-only [ITextFrame.ParentShape](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentshape/) untuk menavigasi kembali ke [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) pemiliknya.

Untuk bingkai teks yang dimiliki oleh auto shape atau bentuk lain yang memuat teks, `ParentShape` berisi pemiliknya dan [ITextFrame.ParentCell](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentcell/) bernilai `null`. Periksa nilai yang dikembalikan sebelum mengaksesnya. Untuk mengidentifikasi pemilik shape dan sel tabel, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/net/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Properti [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/columncount/) membagi bingkai teks menjadi kolom, sementara [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/columnspacing/) mengatur jarak antar kolom dalam poin. Kedua pengaturan tersebut merupakan bagian dari [ITextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/) dan dapat diubah melalui bingkai teks pada kotak teks yang ada. Teks mengalir kembali di antara kolom dalam shape yang sama; tidak berlanjut ke shape lain.

Contoh berikut membuat kotak teks tiga kolom dengan 10 poin antar kolom, menyimpan presentasi, dan membaca kembali pengaturan yang disimpan dari file output:

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

## **Ekstrak Teks dari Kolom Individu**

Gunakan [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/splittextbycolumns/) untuk mengambil teks yang diberikan ke setiap kolom visual dalam bingkai teks yang ada. Metode ini mengembalikan satu string untuk setiap kolom, dalam urutan baca berbasis kolom. Bingkai teks satu kolom menghasilkan sebuah array dengan satu elemen, dan kolom kosong diwakili oleh string kosong. String-string tersebut hanya berisi teks polos; format tingkat bagian tidak dipertahankan.

Ini berguna ketika Anda perlu:
- Mengekstrak teks sambil mempertahankan urutan baca berbasis kolom.
- Mengindeks atau membandingkan konten slide multi-kolom.
- Mengekspor setiap kolom ke file terpisah, bidang basis data, atau tujuan lainnya.
- Memeriksa bagaimana teks didistribusikan kembali setelah mengubah [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/columnspacing/), font, atau ukuran bingkai teks.

Metode ini melaporkan teks yang didistribusikan dalam [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) saat ini; tidak secara otomatis mengalirkan teks antara shape atau kotak teks terpisah. Distribusi kolom dapat bergantung pada font yang tersedia dan pengaturan tata letak teks lainnya, jadi pastikan font yang diperlukan tersedia ketika hasil yang konsisten penting.

Contoh berikut memuat sebuah presentasi, menemukan auto shape multi-kolom pertama dengan bingkai teks, membaca jumlah kolom yang dikonfigurasikan, dan menulis teks dari setiap kolom ke file terpisah. Shape yang tidak menyediakan bingkai teks akan dilewati.

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

## **Perbarui Teks**

Untuk memperbarui teks di seluruh presentasi, iterasi melalui slide dan shape, pilih auto shape, dan kemudian edit bagian teksnya. Bekerja pada level bagian memungkinkan Anda mengubah teks dan format karakter.

Contoh berikut mengganti setiap kemunculan `years` dengan `months` dalam teks auto-shape dan membuat setiap bagian yang terpengaruh menjadi tebal:

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

Traversing ini memperbarui teks hanya dalam auto shape. Teks yang disimpan dalam tabel, diagram, SmartArt, atau shape yang dikelompokkan memerlukan traversing koleksi objek tersebut.

## **Tambahkan Kotak Teks dengan Tautan**

Sebuah tautan dapat ditetapkan ke bagian teks tertentu, sehingga hanya teks tersebut berfungsi sebagai tautan yang dapat diklik. Gunakan [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) untuk mengaitkan bagian tersebut dengan URL eksternal.

Contoh berikut membuat teks terhubung dan menyimpannya ke sebuah presentasi:

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

**Apa perbedaan antara kotak teks dan placeholder teks pada slide master atau layout?**

Sebuah [placeholder](/slides/id/net/manage-placeholder/) dapat mewarisi posisi dan pemformatannya dari sebuah [master slide](https://reference.aspose.com/slides/id/net/aspose.slides/masterslide/) atau [layout slide](https://reference.aspose.com/slides/id/net/aspose.slides/layoutslide/). Kotak teks biasa adalah shape independen pada slide tempat ia dibuat dan tidak memperoleh perilaku placeholder ketika tata letak berubah.

**Bagaimana saya dapat mengganti teks tanpa mengubah teks dalam diagram, tabel, atau SmartArt?**

Batasi traversal hanya pada shape yang mengimplementasikan [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/), seperti yang ditunjukkan dalam contoh Perbarui Teks. Diagram, tabel, dan SmartArt menyimpan teks dalam model objek mereka masing-masing, jadi tidak akan diubah oleh loop tersebut.