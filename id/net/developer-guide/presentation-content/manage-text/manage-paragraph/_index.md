---
title: Kelola Paragraf Teks PowerPoint di .NET
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/net/manage-paragraph/
keywords:
- tambahkan teks
- tambahkan paragraf
- kelola teks
- kelola paragraf
- kelola bullet
- indent paragraf
- indent gantung
- bullet paragraf
- daftar bernomor
- daftar berbullet
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
description: "Kuasai pemformatan paragraf dengan Aspose.Slides untuk .NET—optimalkan perataan, spasi, dan gaya dalam presentasi PPT, PPTX, dan ODP di C#."
---
## **Pendahuluan**

Aspose.Slides menyediakan semua antarmuka dan kelas yang Anda perlukan untuk bekerja dengan teks, paragraf, dan bagian PowerPoint dalam C#.

* Aspose.Slides menyediakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) yang memungkinkan Anda menambahkan objek yang merepresentasikan sebuah paragraf. Sebuah objek `ITextFame` dapat memiliki satu atau beberapa paragraf (setiap paragraf dibuat melalui carriage return).
* Aspose.Slides menyediakan antarmuka [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/) yang memungkinkan Anda menambahkan objek yang merepresentasikan bagian. Sebuah objek `IParagraph` dapat memiliki satu atau beberapa bagian (koleksi objek iPortions).
* Aspose.Slides menyediakan antarmuka [IPortion](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/) yang memungkinkan Anda menambahkan objek yang merepresentasikan teks dan properti formatnya. 

Sebuah objek `IParagraph` dapat menangani teks dengan properti format yang berbeda melalui objek `IPortion` yang mendasarinya.

## **Menambahkan Beberapa Paragraf yang Memuat Beberapa Bagian**

Langkah-langkah berikut menunjukkan cara menambahkan sebuah bingkai teks yang berisi 3 paragraf dan setiap paragraf berisi 3 bagian:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah Rectangle [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Dapatkan ITextFrame yang terkait dengan [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).
5. Buat dua objek [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/) dan tambahkan ke koleksi `IParagraphs` dari [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).
6. Buat tiga objek [IPortion](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/) untuk setiap `IParagraph` baru (dua objek Portion untuk Paragraph default) dan tambahkan setiap objek `IPortion` ke koleksi IPortion masing‑masing `IParagraph`.
7. Tetapkan beberapa teks untuk setiap bagian.
8. Terapkan fitur format pilihan Anda ke setiap bagian menggunakan properti format yang disediakan oleh objek `IPortion`.
9. Simpan presentasi yang telah dimodifikasi.

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
using (Presentation pres = new Presentation())
{
    // Mengakses slide pertama
    ISlide slide = pres.Slides[0];

    // Menambahkan IAutoShape Rectangle
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Mengakses TextFrame AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Membuat Paragraph dan Portion dengan format teks yang berbeda
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Menyimpan presentasi yang telah dimodifikasi
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **Mengelola Bullet Paragraf**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf ber‑bullet selalu lebih mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) autoshape. 
5. Hapus paragraf default di `TextFrame`.
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/).
8. Tetapkan `Type` bullet untuk paragraf menjadi `Symbol` dan tetapkan karakter bullet.
9. Tetapkan `Text` paragraf.
10. Tetapkan `Indent` paragraf untuk bullet.
11. Tetapkan warna untuk bullet.
12. Tetapkan tinggi bullet.
13. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
14. Tambahkan paragraf kedua dan ulangi proses pada langkah 7 sampai 13.
15. Simpan presentasi.

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
using (Presentation pres = new Presentation())
{

    // Mengakses slide pertama
    ISlide slide = pres.Slides[0];


    // Menambahkan dan mengakses Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Mengakses frame teks autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Menghapus paragraf default
    txtFrm.Paragraphs.RemoveAt(0);

    // Membuat paragraf
    Paragraph para = new Paragraph();

    // Mengatur gaya bullet paragraf dan simbol
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Mengatur teks paragraf
    para.Text = "Welcome to Aspose.Slides";

    // Mengatur indent bullet
    para.ParagraphFormat.Indent = 25;

    // Mengatur warna bullet
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // mengatur IsBulletHardColor ke true untuk menggunakan warna bullet sendiri

    // Mengatur Tinggi Bullet
    para.ParagraphFormat.Bullet.Height = 100;

    // Menambahkan Paragraf ke frame teks
    txtFrm.Paragraphs.Add(para);

    // Membuat paragraf kedua
    Paragraph para2 = new Paragraph();

    // Mengatur jenis dan gaya bullet paragraf
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Menambahkan teks paragraf
    para2.Text = "This is numbered bullet";

    // Mengatur indent bullet
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // mengatur IsBulletHardColor ke true untuk menggunakan warna bullet sendiri

    // Mengatur Tinggi Bullet
    para2.ParagraphFormat.Bullet.Height = 100;

    // Menambahkan Paragraf ke frame teks
    txtFrm.Paragraphs.Add(para2);


    // Menyimpan presentasi yang telah dimodifikasi
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Mengelola Bullet Gambar**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf gambar mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) autoshape.
5. Hapus paragraf default di `TextFrame`.
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/).
7. Muat gambar dalam [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/).
8. Tetapkan tipe bullet ke [Picture](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) dan tetapkan gambar.
9. Tetapkan `Text` paragraf.
10. Tetapkan `Indent` paragraf untuk bullet.
11. Tetapkan warna untuk bullet.
12. Tetapkan tinggi bullet.
13. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
14. Tambahkan paragraf kedua dan ulangi proses berdasarkan langkah sebelumnya.
15. Simpan presentasi yang telah dimodifikasi.

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation presentation = new Presentation();

// Mengakses slide pertama
ISlide slide = presentation.Slides[0];

// Membuat instance gambar untuk bullet
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Menambahkan dan mengakses Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Mengakses textframe autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Menghapus paragraf default
textFrame.Paragraphs.RemoveAt(0);

// Membuat paragraf baru
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Mengatur gaya bullet paragraf dan gambar
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Mengatur Tinggi Bullet
paragraph.ParagraphFormat.Bullet.Height = 100;

// Menambahkan paragraf ke text frame
textFrame.Paragraphs.Add(paragraph);

// Menulis presentasi sebagai file PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Menulis presentasi sebagai file PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Mengelola Bullet Multilevel**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Bullet multilevel mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class.
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) di slide baru.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) autoshape.
5. Hapus paragraf default di `TextFrame`.
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/) dan set kedalaman ke 0.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan set kedalaman ke 1.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan set kedalaman ke 2.
9. Buat instance paragraf keempat melalui kelas `Paragraph` dan set kedalaman ke 3.
10. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
11. Simpan presentasi yang telah dimodifikasi.

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
using (Presentation pres = new Presentation())
{

    // Mengakses slide pertama
    ISlide slide = pres.Slides[0];
    
    // Menambahkan dan mengakses Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Mengakses frame teks dari autoshape yang dibuat
    ITextFrame text = aShp.AddTextFrame("");
    
    // Menghapus paragraf default
    text.Paragraphs.Clear();

    // Menambahkan paragraf pertama
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Mengatur level bullet
    para1.ParagraphFormat.Depth = 0;

    // Menambahkan paragraf kedua
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Mengatur level bullet
    para2.ParagraphFormat.Depth = 1;

    // Menambahkan paragraf ketiga
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Mengatur level bullet
    para3.ParagraphFormat.Depth = 2;

    // Menambahkan paragraf keempat
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Mengatur level bullet
    para4.ParagraphFormat.Depth = 3;

    // Menambahkan paragraf ke koleksi
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Menulis presentasi sebagai file PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Mengelola Paragraf dengan Daftar Bernomor Kustom**

Antarmuka [IBulletFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/) menyediakan properti [NumberedBulletStartWith](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/numberedbulletstartwith) dan lainnya yang memungkinkan Anda mengelola paragraf dengan penomoran atau format kustom.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class.
2. Akses slide yang berisi paragraf.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) autoshape.
5. Hapus paragraf default di `TextFrame`.
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/) dan set [NumberedBulletStartWith](https://reference.aspose.com/slides/id/net/aspose.slides/ibulletformat/numberedbulletstartwith) ke 2.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan set `NumberedBulletStartWith` ke 3.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan set `NumberedBulletStartWith` ke 7.
9. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
10. Simpan presentasi yang telah dimodifikasi.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Mengakses frame teks dari autoshape yang dibuat
	ITextFrame textFrame = shape.TextFrame;

	// Menghapus paragraf default yang ada
	textFrame.Paragraphs.RemoveAt(0);

	// Daftar pertama
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Mengatur Indent Baris Pertama untuk Paragraf**

Gunakan properti [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) untuk mengontrol indent baris pertama sebuah paragraf. Properti ini hanya memindahkan baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sedangkan baris lainnya tetap rata dengan tubuh paragraf.

Gunakan [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginleft/) ketika Anda perlu memindahkan seluruh paragraf. Gunakan [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) ketika Anda hanya perlu memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai `Indent` yang berbeda untuk mendemonstrasikan bagaimana indent baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat beberapa paragraf dan set nilai [Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf ke bingkai teks.
7. Simpan presentasi yang telah dimodifikasi.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

![Indent baris pertama dari paragraf](first_line_indent.png)

## **Mengatur Indent Gantung untuk Paragraf**

Indent gantung adalah tata letak paragraf di mana baris pertama dimulai di sebelah kiri baris-baris berikutnya. Di Aspose.Slides, Anda menciptakan efek ini dengan properti [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/). Set `Indent` ke nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap tubuh paragraf.

Secara praktik, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginleft/) menentukan posisi kiri tubuh paragraf, dan [IParagraphFormat.Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indent gantung, set nilai `MarginLeft` positif dan nilai `Indent` negatif.

Formatting ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris yang dibungkus harus rata di bawah tubuh paragraf bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat paragraf dan set nilai [MarginLeft](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginleft/) positif untuk masing‑masing paragraf.
6. Set nilai [Indent](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/indent/) negatif untuk menciptakan efek indent gantung.
7. Tambahkan paragraf ke bingkai teks.
8. Simpan presentasi yang telah dimodifikasi.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

![Indent gantung dari paragraf](hanging_indent.png)

## **Mengelola Properti Jalur Akhir Paragraf**

1. Buat sebuah instance dari [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) class.
1. Dapatkan referensi untuk slide yang berisi paragraf melalui posisinya.
1. Tambahkan sebuah rectangle [autoshape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) ke slide.
1. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) dengan dua paragraf ke Rectangle.
1. Set `FontHeight` dan tipe Font untuk paragraf.
1. Set properti End untuk paragraf.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Mengimpor Teks HTML ke dalam Paragraf**

Aspose.Slides menyediakan dukungan tingkat lanjut untuk mengimpor teks HTML ke dalam paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) ke slide.
4. Tambahkan dan akses `autoshape` [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/).
5. Hapus paragraf default di `ITextFrame`.
6. Baca file HTML sumber dalam sebuah TextReader.
7. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/).
8. Tambahkan konten file HTML yang dibaca oleh TextReader ke [ParagraphCollection](https://reference.aspose.com/slides/id/net/aspose.slides/paragraphcollection/) TextFrame.
9. Simpan presentasi yang telah dimodifikasi.

```c#
// Membuat instance presentasi kosong
using (Presentation pres = new Presentation())
{
    // Mengakses slide pertama bawaan presentasi
    ISlide slide = pres.Slides[0];

    // Menambahkan AutoShape untuk menampung konten HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Menambahkan text frame ke shape
    ashape.AddTextFrame("");

    // Menghapus semua paragraf di text frame yang ditambahkan
    ashape.TextFrame.Paragraphs.Clear();

    // Memuat file HTML menggunakan stream reader
    TextReader tr = new StreamReader("file.html");

    // Menambahkan teks dari stream reader HTML ke text frame
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Menyimpan presentasi
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Mengekspor Teks Paragraf ke HTML**

Aspose.Slides menyediakan dukungan tingkat lanjut untuk mengekspor teks (yang terdapat dalam paragraf) ke HTML.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi yang diinginkan.
2. Akses referensi slide yang relevan melalui indeksnya.
3. Akses shape yang berisi teks yang akan diekspor ke HTML.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) shape.
5. Buat instance `StreamWriter` dan tambahkan file HTML baru.
6. Berikan indeks awal ke StreamWriter dan ekspor paragraf pilihan Anda.

```c#
// Memuat file presentasi
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Mengakses slide pertama bawaan presentasi
    ISlide slide = pres.Slides[0];

    // Mengakses indeks yang diperlukan
    int index = 0;

    // Mengakses shape yang ditambahkan
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Menulis data paragraf ke HTML dengan menentukan indeks awal paragraf dan jumlah paragraf yang akan disalin
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Menyimpan Paragraf sebagai Gambar**

Di bagian ini, kami akan mengeksplorasi dua contoh yang menunjukkan cara menyimpan paragraf teks, yang direpresentasikan oleh antarmuka [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/), sebagai gambar. Kedua contoh mencakup memperoleh gambar shape yang berisi paragraf menggunakan metode `GetImage` dari antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/), menghitung batas paragraf di dalam shape, dan mengekspornya sebagai gambar bitmap. Pendekatan ini memungkinkan Anda mengekstrak bagian spesifik teks dari presentasi PowerPoint dan menyimpannya sebagai gambar terpisah, yang dapat berguna untuk penggunaan lebih lanjut dalam berbagai skenario.

Misalkan kita memiliki file presentasi bernama sample.pptx dengan satu slide, di mana shape pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

**Contoh 1**

Dalam contoh ini, kami memperoleh paragraf kedua sebagai gambar. Untuk melakukannya, kami mengekstrak gambar shape dari slide pertama presentasi, kemudian menghitung batas paragraf kedua dalam bingkai teks shape. Paragraf kemudian digambar ulang pada gambar bitmap baru, yang disimpan dalam format PNG. Metode ini sangat berguna ketika Anda perlu menyimpan paragraf tertentu sebagai gambar terpisah sambil mempertahankan dimensi dan format teks secara tepat.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Hasil:

![Gambar paragraf](paragraph_to_image_output.png)

**Contoh 2**

Dalam contoh ini, kami memperluas pendekatan sebelumnya dengan menambahkan faktor skala pada gambar paragraf. Shape diekstrak dari presentasi dan disimpan sebagai gambar dengan faktor skala `2`. Ini memungkinkan keluaran resolusi lebih tinggi saat mengekspor paragraf. Batas paragraf kemudian dihitung dengan mempertimbangkan skala. Skala dapat sangat berguna ketika diperlukan gambar yang lebih detail, misalnya untuk keperluan materi cetak berkualitas tinggi.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**Apakah saya dapat menonaktifkan pembungkus baris sepenuhnya di dalam sebuah bingkai teks?**

Ya. Gunakan pengaturan pembungkus bingkai teks ([WrapText](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/wraptext/)) untuk mematikan pembungkus sehingga baris tidak akan terpotong di tepi bingkai.

**Bagaimana saya dapat memperoleh batas tepat pada slide untuk paragraf tertentu?**

Anda dapat mengambil rectangle pembatas paragraf (bahkan untuk satu bagian) untuk mengetahui posisi dan ukuran tepatnya pada slide.

**Di mana pengaturan perataan paragraf (kiri/kanan/tengah/justify) dikontrol?**

[Alignment](https://reference.aspose.com/slides/id/net/aspose.slides/paragraphformat/alignment/) adalah pengaturan tingkat paragraf di [ParagraphFormat](https://reference.aspose.com/slides/id/net/aspose.slides/paragraphformat/); ia berlaku pada seluruh paragraf terlepas dari format bagian individual.

**Apakah saya dapat mengatur bahasa pemeriksaan ejaan hanya untuk bagian paragraf (misalnya, satu kata)?**

Ya. Bahasa diatur pada tingkat bagian ([PortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/languageid/)), sehingga beberapa bahasa dapat hidup berdampingan dalam satu paragraf.