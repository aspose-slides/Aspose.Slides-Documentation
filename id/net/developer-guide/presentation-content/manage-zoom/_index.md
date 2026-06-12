---
title: Kelola Zoom Presentasi di .NET
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/net/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom slide
- zoom bagian
- zoom ringkasan
- tambahkan zoom
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk .NET — lompat antar bagian, tambahkan gambar mini dan transisi pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Zoom di PowerPoint memungkinkan Anda melompat ke dan dari slide, bagian, serta bagian‑bagian tertentu dari sebuah presentasi. Saat Anda sedang mempresentasikan, kemampuan menavigasi dengan cepat antar konten ini bisa sangat berguna. 

![overview_image](overview.png)

* Untuk merangkum seluruh presentasi dalam satu slide, gunakan [Summary Zoom](#Summary-Zoom).
* Untuk menampilkan hanya slide‑slide terpilih, gunakan [Slide Zoom](#Slide-Zoom).
* Untuk menampilkan hanya satu bagian, gunakan [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Slide zoom dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi secara bebas antar slide dalam urutan apa pun tanpa menginterupsi alur presentasi. Slide zoom cocok untuk presentasi singkat tanpa banyak bagian, tetapi Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Slide zoom membantu Anda menelusuri banyak potongan informasi seolah‑olah berada pada satu kanvas tunggal. 

![overview_image](slidezoomsel.png)

Untuk objek slide zoom, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/id/net/aspose.slides/zoomimagetype), antarmuka [IZoomFrame](https://reference.aspose.com/slides/id/net/aspose.slides/izoomframe), dan beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection).

### **Membuat Zoom Frame**

Anda dapat menambahkan zoom frame pada slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru yang akan Anda tautkan ke zoom frame. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara membuat zoom frame pada slide:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //Membuat latar belakang untuk slide kedua
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //Membuat kotak teks untuk slide kedua
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //Membuat latar belakang untuk slide ketiga
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //Membuat kotak teks untuk slide ketiga
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Menambahkan objek ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Membuat Zoom Frame dengan Gambar Kustom**
Dengan Aspose.Slides untuk .NET, Anda dapat membuat zoom frame dengan gambar pratinjau slide yang berbeda sebagai berikut: 
1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru yang akan Anda tautkan ke zoom frame. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide tersebut.
4.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang akan digunakan untuk mengisi frame.
5.	Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara membuat zoom frame dengan gambar yang berbeda:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Membuat latar belakang untuk slide kedua
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Membuat kotak teks untuk slide ketiga
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Membuat gambar baru untuk objek zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Menambahkan objek ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Memformat Zoom Frame**
Pada bagian sebelumnya, kami menunjukkan cara membuat zoom frame sederhana. Untuk membuat zoom frame yang lebih rumit, Anda harus mengubah pemformatan frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada zoom frame. 

Anda dapat mengontrol pemformatan zoom frame pada slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru yang akan ditautkan ke zoom frame. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang akan digunakan untuk mengisi frame.
6.	Tetapkan gambar kustom untuk objek zoom frame pertama.
7.	Ubah format garis untuk objek zoom frame kedua.
8.	Hapus latar belakang dari gambar objek zoom frame kedua.
5.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara mengubah pemformatan zoom frame pada slide: 

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Membuat latar belakang untuk slide kedua
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Membuat kotak teks untuk slide kedua
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Membuat latar belakang untuk slide ketiga
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Membuat kotak teks untuk slide ketiga
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Menambahkan objek ZoomFrame objects
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Membuat gambar baru untuk objek zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Menetapkan gambar kustom untuk objek zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Menetapkan format zoom frame untuk objek zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Pengaturan untuk tidak menampilkan latar belakang pada objek zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Section Zoom**

Section zoom adalah tautan ke sebuah bagian dalam presentasi Anda. Anda dapat menggunakan section zoom untuk kembali ke bagian yang ingin Anda tekankan. Atau Anda dapat menggunakannya untuk menyoroti bagaimana bagian‑bagian tertentu dalam presentasi Anda saling terhubung. 

![overview_image](seczoomsel.png)

Untuk objek section zoom, Aspose.Slides menyediakan antarmuka [ISectionZoomFrame](https://reference.aspose.com/slides/id/net/aspose.slides/isectionzoomframe) dan beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection).

### **Membuat Section Zoom Frame**

Anda dapat menambahkan section zoom frame ke slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru. 
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan ke zoom frame. 
5.	Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara membuat zoom frame pada slide:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan Section baru ke presentasi
    pres.Sections.AddSection("Section 1", slide);

    // Menambahkan objek SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Membuat Section Zoom Frame dengan Gambar Kustom**

Dengan Aspose.Slides untuk .NET, Anda dapat membuat section zoom frame dengan gambar pratinjau slide yang berbeda sebagai berikut: 

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan ke zoom frame. 
5.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang akan digunakan untuk mengisi frame.
5.	Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara membuat zoom frame dengan gambar yang berbeda:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan Section baru ke presentasi
    pres.Sections.AddSection("Section 1", slide);

    // Membuat gambar baru untuk objek zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Menambahkan objek SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Memformat Section Zoom Frame**

Untuk membuat section zoom frame yang lebih rumit, Anda harus mengubah pemformatan frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada section zoom frame. 

Anda dapat mengontrol pemformatan section zoom frame pada slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan ke zoom frame. 
5.	Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Ubah ukuran dan posisi untuk objek section zoom yang dibuat.
7.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang akan digunakan untuk mengisi frame.
8.	Tetapkan gambar kustom untuk objek section zoom frame yang dibuat.
9.	Tetapkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
10.	Hapus latar belakang dari gambar objek section zoom frame.
11.	Ubah format garis untuk objek zoom frame kedua.
12.	Ubah durasi transisi.
13.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara mengubah pemformatan section zoom frame:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan Section baru ke presentasi
    pres.Sections.AddSection("Section 1", slide);

    // Menambahkan objek SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Pemformatan untuk SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Summary Zoom**

Summary zoom seperti halaman landing di mana semua bagian presentasi Anda ditampilkan sekaligus. Saat Anda mempresentasikan, Anda dapat menggunakan zoom untuk berpindah dari satu tempat ke tempat lain dalam presentasi secara bebas. Anda dapat berkreasi, melompati bagian, atau mengunjungi kembali potongan slide tanpa menginterupsi alur presentasi.

![overview_image](sumzoomsel.png)

Untuk objek summary zoom, Aspose.Slides menyediakan antarmuka [ISummaryZoomFrame](https://reference.aspose.com/slides/id/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/id/net/aspose.slides/isummaryzoomsection), dan [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/net/aspose.slides/isummaryzoomsectioncollection) serta beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection).

### **Membuat Summary Zoom**

Anda dapat menambahkan summary zoom frame ke slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan summary zoom frame ke slide pertama.
4.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara membuat summary zoom frame pada slide:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    pres.Sections.AddSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    pres.Sections.AddSection("Section 2", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    pres.Sections.AddSection("Section 3", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    pres.Sections.AddSection("Section 4", slide);

    // Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Menambahkan dan Menghapus Section pada Summary Zoom**

Semua bagian dalam summary zoom frame direpresentasikan oleh objek [ISummaryZoomFrameSection](https://reference.aspose.com/slides/id/net/aspose.slides/isummaryzoomsection), yang disimpan dalam objek [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/net/aspose.slides/isummaryzoomsectioncollection). Anda dapat menambah atau menghapus objek section summary zoom melalui antarmuka [ISummaryZoomSectionCollection] dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan summary zoom frame ke slide pertama.
4.	Tambahkan slide dan bagian baru ke presentasi.
5.	Tambahkan bagian yang dibuat ke summary zoom frame.
6.	Hapus bagian pertama dari summary zoom frame.
7.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara menambah dan menghapus bagian dalam summary zoom frame:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    pres.Sections.AddSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    pres.Sections.AddSection("Section 2", slide);

    // Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Menambahkan slide baru ke presentasi
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Menambahkan section ke Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Menghapus section dari Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Memformat Section pada Summary Zoom**

Untuk membuat objek summary zoom section yang lebih rumit, Anda harus mengubah pemformatan frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada objek summary zoom section. 

Anda dapat mengontrol pemformatan objek summary zoom section dalam summary zoom frame dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan summary zoom frame ke slide pertama.
4.	Dapatkan objek summary zoom section untuk objek pertama dari `ISummaryZoomSectionCollection`.
7.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage) dengan menambahkan gambar ke koleksi images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang akan digunakan untuk mengisi frame.
8.	Tetapkan gambar kustom untuk objek section zoom yang dibuat.
9.	Tetapkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
11.	Ubah format garis untuk objek zoom frame kedua.
12.	Ubah durasi transisi.
13.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut menunjukkan cara mengubah pemformatan untuk objek summary zoom section:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    pres.Sections.AddSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Menambahkan section baru ke presentasi
    pres.Sections.AddSection("Section 2", slide);

    // Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Mendapatkan objek SummaryZoomSection pertama
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Pemformatan untuk objek SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Menyimpan presentasi
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat mengontrol pengembalian ke slide “parent” setelah menampilkan target?**

Ya. [Zoom frame](https://reference.aspose.com/slides/id/net/aspose.slides/zoomframe/) atau [section](https://reference.aspose.com/slides/id/net/aspose.slides/sectionzoomframe/) memiliki perilaku `ReturnToParent` yang, bila diaktifkan, mengirim penonton kembali ke slide asal setelah mereka mengunjungi konten target.

**Apakah saya dapat menyesuaikan “kecepatan” atau durasi transisi Zoom?**

Ya. Zoom mendukung penetapan `TransitionDuration` sehingga Anda dapat mengontrol berapa lama animasi lompatan berlangsung.

**Apakah ada batasan jumlah objek Zoom yang dapat dimiliki sebuah presentasi?**

Tidak ada batasan keras yang didokumentasikan dalam API. Batas praktis bergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak zoom frame, tetapi pertimbangkan ukuran file dan waktu render.