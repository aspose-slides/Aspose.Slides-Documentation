---
title: Kelola Daftar Berpoin dan Bernomor dalam Presentasi di .NET
linktitle: Kelola Daftar
type: docs
weight: 70
url: /id/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- poin
- daftar berpoin
- daftar bernomor
- poin simbol
- poin gambar
- poin khusus
- daftar bertingkat
- buat poin
- tambahkan poin
- tambahkan daftar
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat dan memformat daftar berpoin, poin gambar, daftar bertingkat, dan daftar bernomor dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET."
---
## **Ikhtisar**

Aspose.Slides untuk .NET memungkinkan Anda membuat dan memformat daftar berpoin dan bernomor dalam presentasi PowerPoint dan OpenDocument. Item daftar adalah paragraf yang pengaturan poinnya dikontrol melalui format paragrafnya.

Gunakan properti [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/paragraphformat/) untuk mengakses pengaturan daftar tingkat paragraf. Titik masuk utama adalah [IParagraphFormat.Bullet](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/bullet/), yang mengembalikan objek [IBulletFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/). Dengan objek ini, Anda dapat mengatur jenis poin, simbol, gambar, warna, ukuran, gaya penomoran, dan nomor awal.

Artikel ini menunjukkan cara:

- membuat daftar berpoin dengan simbol khusus
- membuat poin gambar
- membuat daftar bertingkat dengan mengatur kedalaman paragraf
- membuat daftar bernomor
- memeriksa dan mengubah pemformatan daftar dalam presentasi yang ada

## **Buat Daftar Berpoin**

Untuk membuat daftar berpoin, tambahkan objek [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/) ke sebuah [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) dan atur [IBulletFormat.Type](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/type/) ke [BulletType.Symbol](https://reference.aspose.com/slides/id/net/aspose.slides/bullettype/). Anda kemudian dapat mengatur [IBulletFormat.Char](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/color/), dan [IBulletFormat.Height](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/height/) untuk mengontrol tampilan poin.

Kode C# berikut menunjukkan cara membuat daftar berpoin dalam sebuah slide:

```csharp
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

![Simbol poin](symbol_bullets.png)

## **Buat Daftar Bernomor**

Gunakan daftar bernomor ketika urutan item penting. Atur [IBulletFormat.Type](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/type/) ke [BulletType.Numbered](https://reference.aspose.com/slides/id/net/aspose.slides/bullettype/). Anda juga dapat memilih format penomoran dengan [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/numberedbulletstyle/) atau mengatur [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/numberedbulletstartwith/) bila daftar harus dimulai dari nilai selain 1.

Kode C# berikut menunjukkan cara membuat daftar bernomor dalam sebuah slide:

```csharp
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

![Poin bernomor](numbered_bullets.png)

## **Buat Poin Gambar**

Aspose.Slides memungkinkan Anda mengganti simbol poin standar dengan gambar. Poin gambar paling cocok untuk gambar sederhana yang tetap terbaca pada ukuran kecil, seperti ikon atau file PNG transparan kecil.

{{% alert color="primary" %}}
Idealnya, bila Anda berencana mengganti simbol poin standar dengan gambar, pilih grafis sederhana dengan latar belakang transparan. Gambar semacam itu bekerja baik sebagai simbol poin khusus.

Ingat bahwa gambar akan diperkecil menjadi sangat kecil. Karena itu, kami sangat menyarankan memilih gambar yang tetap jelas dan efektif secara visual ketika digunakan sebagai poin dalam daftar.
{{% /alert %}}

Untuk membuat poin gambar, tambahkan gambar ke [Presentation.Images](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/images/) dan tetapkan objek gambar yang dikembalikan ke [IBulletFormat.Picture](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/picture/). Atur [IBulletFormat.Type](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/type/) ke [BulletType.Picture](https://reference.aspose.com/slides/id/net/aspose.slides/bullettype/) sebelum menugaskan gambar.

Misalkan kita memiliki "image.png":

![Gambar untuk poin](picture_for_bullets.png)

Kode C# berikut menunjukkan cara membuat poin gambar dalam sebuah slide:

```csharp
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

![Poin gambar](picture_bullets.png)

## **Buat Daftar Bertingkat**

Gunakan [IParagraphFormat.Depth](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/depth/) untuk menempatkan item daftar pada tingkat yang berbeda. Tingkat 0 adalah tingkat teratas, tingkat 1 berada di dalamnya, dan seterusnya.

Kode C# berikut menunjukkan cara membuat daftar berpoin bertingkat:

```csharp
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

![Daftar bertingkat](multilevel_list.png)

## **Ubah Daftar yang Ada**

Untuk mengubah pemformatan daftar dalam presentasi yang ada, akses paragraf target dan perbarui pengaturan [IParagraphFormat.Bullet](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/bullet/)‑nya. Properti yang sama yang digunakan untuk membuat daftar dapat dipakai untuk memeriksa atau memodifikasi daftar yang dimuat dari file PPT, PPTX, atau ODP.

Kode C# berikut mengubah paragraf pertama dalam sebuah bingkai teks untuk menggunakan gaya daftar bernomor:

```csharp
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

## **FAQ**

**Apakah daftar berpoin dan bernomor dapat diekspor ke PDF atau gambar?**

Ya. Aspose.Slides mempertahankan pemformatan daftar ketika format target mendukung tata letak teks dan fitur poin yang bersangkutan.

**Apakah saya dapat mengedit daftar dalam presentasi yang ada?**

Ya. Muat presentasi, akses paragraf target, periksa atau perbarui pengaturan [IParagraphFormat.Bullet](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/bullet/), dan simpan presentasi.

**Apakah daftar dapat berisi teks non-Latin?**

Ya. Teks item daftar dapat berisi karakter Unicode, sehingga Anda dapat membuat daftar dalam presentasi multibahasa. Pastikan font yang digunakan dalam presentasi mendukung karakter yang Anda butuhkan.