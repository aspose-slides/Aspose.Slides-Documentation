---
title: Mengelola Daftar Berpoin dan Bernomor dalam Presentasi di .NET
linktitle: Kelola Daftar
type: docs
weight: 70
url: /id/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- bullet
- daftar berpoin
- daftar bernomor
- bullet simbol
- bullet gambar
- bullet khusus
- daftar berjenjang
- buat bullet
- tambahkan bullet
- tambahkan daftar
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat dan memformat daftar berpoin, bullet gambar, daftar berjenjang, dan daftar bernomor dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides for .NET memungkinkan Anda membuat dan memformat daftar berpoin dan bernomor dalam presentasi PowerPoint dan OpenDocument. Item daftar adalah paragraf yang pengaturan bullet‑nya dikendalikan melalui format paragrafnya.

Gunakan properti [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) untuk mengakses pengaturan daftar pada tingkat paragraf. Titik masuk utama adalah [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), yang mengembalikan objek [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/). Dengan objek ini, Anda dapat mengatur jenis bullet, simbol, gambar, warna, ukuran, gaya penomoran, dan nomor awal.

Artikel ini menunjukkan cara:

- membuat daftar berpoin dengan simbol khusus
- membuat bullet gambar
- membuat daftar berjenjang dengan mengatur kedalaman paragraf
- membuat daftar bernomor
- memeriksa dan mengubah pemformatan daftar dalam presentasi yang ada
- membaca penanda daftar aktual dan angka bersamaan dengan teks paragraf

## **Buat Daftar Berpoin**

Untuk membuat daftar berpoin, tambahkan objek [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) ke dalam [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) dan setel [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) ke [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Anda kemudian dapat mengatur [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/), dan [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) untuk mengontrol tampilan bullet.

Berikut ini contoh kode C# yang menunjukkan cara membuat daftar berpoin dalam sebuah slide:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Hasil:

![Bullet simbol](symbol_bullets.png)

## **Buat Daftar Bernomor**

Gunakan daftar bernomor ketika urutan item penting. Setel [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) ke [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Anda juga dapat memilih format penomoran dengan [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) atau mengatur [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) ketika daftar harus dimulai dengan nilai selain 1.

Berikut ini contoh kode C# yang menunjukkan cara membuat daftar bernomor dalam sebuah slide:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Hasil:

![Bullet bernomor](numbered_bullets.png)

## **Buat Bullet Gambar**

Aspose.Slides memungkinkan Anda mengganti simbol bullet biasa dengan gambar. Bullet gambar paling cocok dengan gambar sederhana yang tetap terbaca pada ukuran kecil, seperti ikon atau file PNG transparan kecil.

{{% alert color="info" title="Note" %}}
Idealnya, bila Anda berencana mengganti simbol bullet biasa dengan gambar, sebaiknya pilih grafik sederhana dengan latar belakang transparan. Gambar seperti itu cocok sebagai simbol bullet khusus.
{{% /alert %}}

Untuk membuat bullet gambar, tambahkan gambar ke [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) dan tetapkan objek gambar yang dikembalikan ke [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). Setel [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) ke [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) sebelum menetapkan gambar.

Misalkan kita memiliki "image.png":

![Gambar untuk bullet](picture_for_bullets.png)

Berikut ini contoh kode C# yang menunjukkan cara membuat bullet gambar dalam sebuah slide:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Hasil:

![Bullet gambar](picture_bullets.png)

## **Buat Daftar Berjenjang**

Gunakan [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) untuk menempatkan item daftar pada level yang berbeda. Level 0 adalah level teratas, level 1 berada di dalamnya, dan seterusnya.

Berikut ini contoh kode C# yang menunjukkan cara membuat daftar berpoin berjenjang:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Hasil:

![Daftar berjenjang](multilevel_list.png)

## **Ubah Daftar yang Ada**

Untuk mengubah pemformatan daftar dalam presentasi yang ada, akses paragraf target dan perbarui pengaturan [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/). Properti yang sama yang digunakan untuk membuat daftar dapat digunakan untuk memeriksa atau memodifikasi daftar yang dimuat dari file PPT, PPTX, atau ODP.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Baca Nilai Bullet Aktual**

Saat mengekstrak konten presentasi, pertahankan penanda daftar bersamaan dengan teks paragraf. Panggil [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) dan akses [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) untuk memperoleh format bullet efektif. Periksa [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) sebelum membaca [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/).

Untuk daftar bernomor, bedakan tiga nilai berikut:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) menentukan format, misalnya angka Arab diikuti titik atau huruf kecil diikuti titik.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) menentukan nomor awal untuk sekumpulan paragraf bernomor.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) mengembalikan penanda yang diformat untuk paragraf tertentu. Misalnya, item kedua dalam daftar yang dimulai dari 5 mengembalikan `6.`.

Pertahankan [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) pada setiap paragraf untuk menyimpan level penurunanannya. Penanda aktual tidak mengkodekan seluruh hierarki: item berjenjang dapat mengembalikan `c.` bukan label gabungan seperti `6.c.`.

Contoh mandiri berikut membuat daftar, menyimpannya ke dalam presentasi, dan memuat ulang presentasi untuk melaporkan teks, kedalaman, jenis bullet, dan nilai aktual setiap paragraf. Penanda gambar biru kecil dibuat dari SVG inline.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Buat penanda gambar tanpa file gambar eksternal.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

Daftar sumber ditampilkan di bawah.

![Daftar dimulai dari 5, item huruf berjenjang dan angka Romawi, penanda simbol, paragraf tanpa bullet, dan penanda gambar biru](actual_bullet_values.png)

Laporan sesuai dengan penanda yang ditampilkan di PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Untuk [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/), [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) mengembalikan `null`, bukan string kosong. Tangani tipe ini secara terpisah: tipe pertama tidak memiliki penanda, sedangkan tipe kedua memerlukan ekstraksi gambar bullet secara terpisah. Bullet gambar tidak dapat direproduksi hanya dengan mengekstrak penanda teks.

## **FAQ**

**Apakah daftar berpoin dan bernomor dapat diekspor ke PDF atau gambar?**

Ya. Aspose.Slides mempertahankan pemformatan daftar ketika format target mendukung tata letak teks dan fitur bullet yang bersesuaian.

**Apakah saya dapat mengedit daftar dalam presentasi yang ada?**

Ya. Muat presentasi, akses paragraf target, periksa atau perbarui pengaturan [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), dan simpan presentasi.

**Apakah daftar dapat berisi teks non-Latin?**

Ya. Teks item daftar dapat berisi karakter Unicode, sehingga Anda dapat membuat daftar dalam presentasi multibahasa. Pastikan font yang digunakan dalam presentasi mendukung karakter yang Anda perlukan.