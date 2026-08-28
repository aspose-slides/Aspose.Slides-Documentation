---
title: Kelola Paragraf Teks PowerPoint di .NET
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- tambahkan teks
- tambahkan paragraf
- kelola teks
- kelola paragraf
- kelola bullet
- indentasi paragraf
- indentasi menggantung
- bullet paragraf
- daftar bernomor
- daftar bullet
- properti paragraf
- impor HTML
- teks ke HTML
- paragraf ke HTML
- paragraf ke gambar
- teks ke gambar
- ekspor paragraf
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat dan memformat paragraf, portion, bullet, daftar bernomor, indentasi, konten HTML, dan gambar paragraf dengan Aspose.Slides untuk .NET."
---
## **Ikhtisar**

Aspose.Slides for .NET merepresentasikan teks sebagai hierarki bingkai teks, paragraf, dan portion:

* [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) mewakili wadah teks dalam sebuah shape dan menyediakan akses ke koleksi paragrafnya.
* [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/) mewakili satu paragraf dalam sebuah text frame dan menyediakan akses ke portion serta pemformatan tingkat paragraf.
* [IPortion](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/) mewakili satu run teks dalam paragraf. Setiap portion dapat memiliki teks dan pemformatan tingkat karakter masing‑masing.

Dengan demikian, sebuah paragraf dapat berisi teks dengan font, warna, ukuran, dan pemformatan lain yang berbeda dengan menggunakan beberapa portion.

## **Buat dan Format Paragraf**

### **Buat Paragraf dengan Beberapa Portion**

Langkah‑langkah berikut membuat sebuah text frame dengan tiga paragraf, masing‑masing berisi tiga portion:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) shape tersebut.
5. Gunakan paragraf default dan tambahkan dua objek [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/) lagi ke text frame.
6. Tambahkan cukup objek [IPortion](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/) untuk setiap paragraf agar berisi tiga portion. Paragraf default sudah berisi satu portion kosong.
7. Atur teks masing‑masing portion.
8. Terapkan pemformatan tingkat karakter melalui [IPortion.PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/portionformat/).
9. Simpan presentasi yang telah dimodifikasi.

Contoh C# berikut mengimplementasikan langkah‑langkah tersebut:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Buat Daftar Bullet dan Penomoran**

### **Buat Daftar Bullet atau Penomoran**

Bullet dan penomoran memudahkan pemindaian item terkait. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [IBulletFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/).

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide yang dipilih.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) shape tersebut.
5. Hapus paragraf default dari text frame.
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/) untuk bullet simbol.
7. Atur [IBulletFormat.Type](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/type/) ke [BulletType.Symbol](https://reference.aspose.com/slides/id/net/aspose.slides/bullettype/) dan tentukan karakter bullet.
8. Atur teks paragraf, indent, warna bullet, dan tinggi bullet.
9. Tambahkan paragraf ke text frame.
10. Buat paragraf kedua dan atur [IBulletFormat.Type](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/type/) ke [BulletType.Numbered](https://reference.aspose.com/slides/id/net/aspose.slides/bullettype/).
11. Konfigurasikan gaya bullet bernomor dan tambahkan paragraf ke text frame.
12. Simpan presentasi.

Contoh C# berikut membuat bullet simbol dan bullet bernomor:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Gunakan Bullet Gambar**

Bullet gambar memungkinkan Anda menggunakan gambar kustom alih‑alih simbol atau angka.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) dan akses [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/)‑nya.
4. Hapus paragraf default dari text frame.
5. Muat gambar bullet dan tambahkan ke koleksi gambar presentasi sebagai [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/).
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/) dan atur teksnya.
7. Atur [IBulletFormat.Type](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/type/) ke [BulletType.Picture](https://reference.aspose.com/slides/id/net/aspose.slides/bullettype/).
8. Tetapkan gambar melalui [IBulletFormat.Picture](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/picture/) dan atur tinggi bullet.
9. Tambahkan paragraf ke text frame.
10. Simpan presentasi yang telah dimodifikasi.

Contoh C# berikut membuat bullet gambar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Buat Daftar Multilevel**

Atur [IParagraphFormat.Depth](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/depth/) untuk menempatkan paragraf pada level daftar yang berbeda. Level teratas memiliki depth `0`.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) serta hapus paragraf default dari text frame‑nya.
3. Buat empat paragraf dan konfigurasikan simbol bullet masing‑masing.
4. Atur nilai [IParagraphFormat.Depth](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/depth/) menjadi `0`, `1`, `2`, dan `3`.
5. Tambahkan paragraf ke text frame dan simpan presentasi.

Contoh C# berikut membuat daftar bullet empat level:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Mulai Item Daftar Nomor dengan Nilai Kustom**

Gunakan [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/numberedbulletstartwith/) untuk mengatur nomor awal yang ditampilkan pada paragraf bernomor.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
2. Hapus paragraf default dari text frame shape.
3. Buat tiga paragraf bernomor.
4. Atur [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/numberedbulletstartwith/) menjadi `2`, `3`, dan `7` untuk paragraf masing‑masing.
5. Tambahkan paragraf ke text frame dan simpan presentasi.

Contoh C# berikut menetapkan nomor awal kustom untuk setiap paragraf:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Kontrol Tata Letak Paragraf dan Properti Akhir**

### **Set Indent Baris Pertama**

Gunakan properti [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) untuk mengontrol indent baris pertama sebuah paragraf. Properti ini hanya memindahkan baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris‑baris berikutnya tetap sejajar dengan badan paragraf.

Gunakan [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginleft/) bila Anda perlu memindahkan seluruh paragraf. Gunakan [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) bila Anda hanya perlu memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) yang berbeda untuk mendemonstrasikan bagaimana indent baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) shape dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf ke text frame.
7. Simpan presentasi yang telah dimodifikasi.

Contoh kode berikut menunjukkan cara mengatur indent paragraf:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Indent baris pertama dari paragraf](first_line_indent.png)

### **Set Indent Menggantung**

Indent menggantung adalah tata letak paragraf dimana baris pertama mulai lebih ke kiri dibanding baris‑baris berikutnya. Di Aspose.Slides, Anda menciptakan efek ini dengan properti [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/). Atur `Indent` ke nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap badan paragraf.

Secara praktis, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginleft/) menentukan posisi kiri badan paragraf, dan [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indent menggantung, atur nilai `MarginLeft` positif dan nilai `Indent` negatif.

Pemformatan ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain dimana baris‑baris terbungkus harus sejajar di bawah badan paragraf, bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) persegi panjang ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) shape dan hapus paragraf default.
5. Buat paragraf dan atur nilai [MarginLeft](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginleft/) positif untuk masing‑masing paragraf.
6. Atur nilai [Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) negatif untuk menciptakan efek indent menggantung.
7. Tambahkan paragraf ke text frame.
8. Simpan presentasi yang telah dimodifikasi.

Contoh kode berikut menunjukkan cara mengatur indent menggantung untuk sebuah paragraf:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Indent menggantung dari paragraf](hanging_indent.png)

### **Set Properti Run Akhir Paragraf**

Properti [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/endparagraphportionformat/) mengontrol pemformatan tanda akhir paragraf. Contoh berikut menetapkan ukuran font dan font Latin pada tanda akhir paragraf kedua:

1. Muat sebuah [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) serta bersihkan paragraf defaultnya.
3. Buat dua paragraf dan tambahkan portion teks ke masing‑masing.
4. Buat sebuah [PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/portionformat/) untuk tanda akhir paragraf kedua.
5. Atur [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/fontheight/) dan [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/latinfont/).
6. Tetapkan format ke [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/endparagraphportionformat/) dan simpan presentasi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Impor dan Ekspor Konten Paragraf**

### **Impor Teks HTML ke Paragraf**

Gunakan [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/id/net/aspose.slides/paragraphcollection/addfromhtml/) untuk mengonversi markup HTML menjadi paragraf dan portion dalam sebuah text frame.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses sebuah slide dan tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).
3. Akses [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) shape dan bersihkan paragraf defaultnya.
4. Baca file HTML sumber.
5. Kirim string HTML ke [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/id/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Simpan presentasi yang telah dimodifikasi.

Contoh C# berikut mengimpor HTML ke dalam sebuah text frame:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Ekspor Teks Paragraf ke HTML**

Gunakan [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/id/net/aspose.slides/paragraphcollection/exporttohtml/) untuk mengekspor rentang paragraf yang dipilih sebagai HTML.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi yang diinginkan.
2. Akses slide dan temukan [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) yang berisi teks.
3. Akses [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) shape.
4. Panggil [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/id/net/aspose.slides/paragraphcollection/exporttohtml/) dengan indeks paragraf awal dan jumlah paragraf yang akan diekspor.
5. Tulis string HTML yang dikembalikan ke sebuah file.

Contoh C# berikut mengekspor semua paragraf dari shape teks pertama:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Render Paragraf sebagai Gambar**

[IParagraph.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/getimage/) merender sebuah paragraf individu secara langsung dan mengembalikan sebuah [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/). Simpan hasilnya ke file atau stream dengan [IImage.Save](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/save/). Anda tidak perlu merender shape yang berisi atau memotong bitmap secara manual.

[IParagraph.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/getimage/) dapat mengembalikan `null` bila paragraf tidak ditemukan dalam koleksi induknya, tidak memiliki batas rendering yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpan dan buang gambar yang dikembalikan setelah selesai digunakan.

#### **Render Paragraf pada Skala Default**

Misalkan kita memiliki file presentasi bernama sample.pptx dengan satu slide, di mana shape pertama adalah sebuah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

Contoh berikut merender paragraf kedua dalam shape teks biasa pada skala default dan menyimpan gambar yang dikembalikan dalam format PNG. Pernyataan `using` memastikan gambar dibuang dengan tepat.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Hasilnya:

![Gambar paragraf](paragraph_to_image_output.png)

#### **Render Paragraf dalam Sel Tabel dengan Skalasi**

Gunakan overload [IParagraph.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/getimage/) yang menerima parameter `float scaleX` dan `float scaleY` untuk mengatur faktor skala horizontal dan vertikal. Contoh berikut membuat sebuah tabel, merender paragraf di sel pertamanya dengan lebar dan tinggi dua kali skala default, dan menyimpan hasilnya sebagai gambar PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Faktor skala `1` mempertahankan ukuran piksel default pada sumbu tersebut. Misalnya, `2` untuk kedua faktor menghasilkan gambar yang lebar dan tingginya kira‑kira dua kali dimensi default, sehingga menghasilkan empat kali lebih banyak piksel. Faktor yang lebih besar umumnya menghasilkan teks yang lebih tajam untuk zoom atau output beresolusi tinggi, tetapi juga meningkatkan penggunaan memori dan ukuran file. Faktor di bawah `1` menghasilkan gambar lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara independen.

Merender seluruh shape dengan [IShape.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/getimage/) tetap berguna ketika output harus menyertakan isi, border, atau konteks visual lain dari shape. Untuk gambar hanya paragraf, gunakan [IParagraph.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Apakah saya dapat sepenuhnya menonaktifkan pembungkusan baris di dalam frame teks?**

Ya. Atur [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/wraptext/) untuk menonaktifkan pembungkusan sehingga baris tidak terputus di tepi text frame.

**Bagaimana cara saya mendapatkan batas tepat pada slide untuk paragraf tertentu?**

Gunakan [IParagraph.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/getrect/) untuk mengambil persegi pembatas paragraf. [IPortion.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/getrect/) memberikan batas sebuah portion individu.

**Di mana pengaturan perataan paragraf (kiri, kanan, tengah, atau justify) dikontrol?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/alignment/) adalah pengaturan tingkat paragraf dan berlaku untuk seluruh paragraf terlepas dari pemformatan portion individual.

**Apakah saya dapat mengatur bahasa proofing untuk bagian dari sebuah paragraf?**

Ya. Atur [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/languageid/) untuk portion individual, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.