---
title: Mengelola Zoom Presentasi di C++
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/cpp/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom slide
- zoom bagian
- zoom ringkasan
- tambah zoom
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk C++ — melompat antar bagian, menambahkan thumbnail dan transisi pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Zoom di PowerPoint memungkinkan Anda melompat ke dan dari slide, bagian, serta bagian‑bagian tertentu dalam sebuah presentasi. Saat Anda sedang mempresentasikan, kemampuan menavigasi dengan cepat antar konten ini bisa sangat berguna. 

![overview_image](Overview.png)

* Untuk merangkum seluruh presentasi pada satu slide, gunakan [Summary Zoom](#Summary-Zoom).
* Untuk menampilkan slide yang dipilih saja, gunakan [Slide Zoom](#Slide-Zoom).
* Untuk menampilkan satu bagian saja, gunakan [Section Zoom](#Section-Zoom).

## **Zoom Slide**
Zoom slide dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi secara bebas antar slide dalam urutan apa pun tanpa mengganggu alur presentasi. Zoom slide sangat cocok untuk presentasi singkat tanpa banyak bagian, namun Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Zoom slide membantu Anda menggali banyak potongan informasi sambil tetap terasa seperti berada pada satu kanvas. 

![overview_image](slidezoomsel.png)

Untuk objek zoom slide, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/id/cpp/aspose.slides/zoomimagetype/), antarmuka [IZoomFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/izoomframe/), dan beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/).

### **Membuat Frame Zoom**

Anda dapat menambahkan frame zoom pada slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru yang akan Anda tautkan ke frame zoom. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan frame zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara membuat frame zoom pada slide:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Menambahkan slide baru ke presentasi
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Membuat latar belakang untuk slide kedua
SetSlideBackground(slide2, Color::get_Cyan());

// Membuat kotak teks untuk slide kedua
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Membuat latar belakang untuk slide ketiga
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Membuat kotak teks untuk slide ketiga
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Menambahkan objek ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Membuat Frame Zoom dengan Gambar Kustom**
Dengan Aspose.Slides untuk C++, Anda dapat membuat frame zoom dengan gambar pratinjau slide yang berbeda dengan cara berikut: 
1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru yang akan Anda tautkan ke frame zoom. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide.
4.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang akan digunakan untuk mengisi frame.
5.	Tambahkan frame zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara membuat frame zoom dengan gambar yang berbeda:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Menambahkan slide baru ke presentasi
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Membuat latar belakang untuk slide kedua
SetSlideBackground(slide, Color::get_Cyan());

// Membuat kotak teks untuk slide ketiga
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Membuat gambar baru untuk objek zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Menambahkan objek ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Format Frame Zoom**
Pada bagian sebelumnya, kami menunjukkan cara membuat frame zoom sederhana. Untuk membuat frame zoom yang lebih rumit, Anda harus mengubah format frame sederhana. Ada beberapa pilihan format yang dapat Anda terapkan pada frame zoom. 

Anda dapat mengontrol format frame zoom pada slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru yang akan Anda tautkan ke frame zoom. 
3.	Tambahkan beberapa teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan frame zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang akan digunakan untuk mengisi frame.
6.	Tetapkan gambar kustom untuk objek frame zoom pertama.
7.	Ubah format garis untuk objek frame zoom kedua.
8.	Hapus latar belakang dari gambar pada objek frame zoom kedua.
5.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara mengubah format frame zoom pada slide: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Menambahkan slide baru ke presentasi
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Membuat latar belakang untuk slide kedua
SetSlideBackground(slide2, Color::get_Cyan());

// Membuat kotak teks untuk slide kedua
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Membuat latar belakang untuk slide ketiga
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Membuat kotak teks untuk slide ketiga
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Menambahkan objek ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Membuat gambar baru untuk objek zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Menetapkan gambar kustom untuk objek zoomFrame1
zoomFrame1->set_Image(image);

// Menetapkan format frame zoom untuk objek zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Pengaturan untuk tidak menampilkan latar belakang pada objek zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom Bagian**

Zoom bagian adalah tautan ke sebuah bagian dalam presentasi Anda. Anda dapat menggunakan zoom bagian untuk kembali ke bagian‑bagian yang ingin Anda tekankan. Atau Anda dapat menggunakannya untuk menyoroti bagaimana bagian‑bagian tertentu dalam presentasi Anda terhubung. 

![overview_image](seczoomsel.png)

Untuk objek zoom bagian, Aspose.Slides menyediakan antarmuka [ISectionZoomFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectionzoomframe/) dan beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/).

### **Membuat Frame Zoom Bagian**

Anda dapat menambahkan frame zoom bagian ke slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru. 
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan ke frame zoom. 
5.	Tambahkan frame zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara membuat frame zoom pada slide:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Menambahkan slide baru ke presentasi
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Menambahkan Section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 1", slide);

// Menambahkan objek SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Membuat Frame Zoom Bagian dengan Gambar Kustom**

Menggunakan Aspose.Slides untuk C++, Anda dapat membuat frame zoom bagian dengan gambar pratinjau slide yang berbeda dengan cara berikut: 

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan ke frame zoom. 
5.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang akan digunakan untuk mengisi frame.
5.	Tambahkan frame zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara membuat frame zoom dengan gambar yang berbeda:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Menambahkan slide baru ke presentasi
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Menambahkan Section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 1", slide);

// Membuat gambar baru untuk objek zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Menambahkan objek SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Format Frame Zoom Bagian**

Untuk membuat frame zoom bagian yang lebih rumit, Anda harus mengubah format frame sederhana. Ada beberapa pilihan format yang dapat Anda terapkan pada frame zoom bagian. 

Anda dapat mengontrol format frame zoom bagian pada slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan ke frame zoom. 
5.	Tambahkan frame zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Ubah ukuran dan posisi untuk objek zoom bagian yang dibuat.
7.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang akan digunakan untuk mengisi frame.
8.	Tetapkan gambar kustom untuk objek frame zoom bagian yang dibuat.
9.	Atur kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
10.	Hapus latar belakang dari gambar pada objek frame zoom bagian.
11.	Ubah format garis untuk objek frame zoom kedua.
12.	Ubah durasi transisi.
13.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara mengubah format frame zoom bagian:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Menambahkan slide baru ke presentasi
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Menambahkan Section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 1", slide);

// Menambahkan objek SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Pemformatan untuk SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Zoom Ringkasan**

Zoom ringkasan seperti halaman arahan di mana semua bagian presentasi Anda ditampilkan sekaligus. Saat Anda mempresentasikan, Anda dapat menggunakan zoom untuk berpindah dari satu bagian presentasi ke bagian lain dalam urutan apa pun yang Anda inginkan. Anda dapat berkreasi, melompat ke depan, atau kembali ke bagian‑bagian slide tanpa mengganggu alur presentasi.

![overview_image](sumzoomsel.png)

Untuk objek zoom ringkasan, Aspose.Slides menyediakan antarmuka [ISummaryZoomFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isummaryzoomsection/), dan [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isummaryzoomsectioncollection/) serta beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/).

### **Membuat Zoom Ringkasan**

Anda dapat menambahkan frame zoom ringkasan ke slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan frame zoom ringkasan ke slide pertama.
4.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara membuat frame zoom ringkasan pada slide:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Menambahkan slide baru ke presentasi
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Menambahkan section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 1", slide);

// Menambahkan slide baru ke presentasi
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Menambahkan section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 2", slide);

// Menambahkan slide baru ke presentasi
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Menambahkan section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 3", slide);

// Menambahkan slide baru ke presentasi
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Menambahkan section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 4", slide);

// Menambahkan objek SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Menambah dan Menghapus Seksi Zoom Ringkasan**

Semua bagian dalam frame zoom ringkasan direpresentasikan oleh objek [ISummaryZoomSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isummaryzoomsection/), yang disimpan dalam objek [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isummaryzoomsectioncollection/). Anda dapat menambah atau menghapus objek seksi zoom ringkasan melalui antarmuka [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isummaryzoomsectioncollection/) dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan frame zoom ringkasan ke slide pertama.
4.	Tambahkan slide dan bagian baru ke presentasi.
5.	Tambahkan bagian yang dibuat ke frame zoom ringkasan.
6.	Hapus bagian pertama dari frame zoom ringkasan.
7.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara menambah dan menghapus bagian dalam frame zoom ringkasan:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Menambahkan slide baru ke presentasi
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Menambahkan Section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 1", slide);

//Menambahkan slide baru ke presentasi
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Menambahkan Section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 2", slide);

// Menambahkan SummaryZoomFrame objek
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Menambahkan slide baru ke presentasi
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Menambahkan Section baru ke presentasi
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Menambahkan section ke Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Menghapus section dari Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Format Seksi Zoom Ringkasan**

Untuk membuat objek seksi zoom ringkasan yang lebih rumit, Anda harus mengubah format frame sederhana. Ada beberapa pilihan format yang dapat Anda terapkan pada objek seksi zoom ringkasan. 

Anda dapat mengontrol format objek seksi zoom ringkasan dalam frame zoom ringkasan dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan frame zoom ringkasan ke slide pertama.
4.	Dapatkan objek seksi zoom ringkasan pertama dari `ISummaryZoomSectionCollection`.
7.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) dengan menambahkan gambar ke koleksi images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang akan digunakan untuk mengisi frame.
8.	Tetapkan gambar kustom untuk objek frame zoom bagian yang dibuat.
9.	Atur kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
11.	Ubah format garis untuk objek frame zoom kedua.
12.	Ubah durasi transisi.
13.	Tulis presentasi yang telah dimodifikasi sebagai berkas PPTX.

Kode C++ berikut menunjukkan cara mengubah format objek seksi zoom ringkasan:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Menambahkan slide baru ke presentasi
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Menambahkan section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 1", slide);

//Menambahkan slide baru ke presentasi
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Menambahkan section baru ke presentasi
pres->get_Sections()->AddSection(u"Section 2", slide);

// Menambahkan objek SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Mendapatkan objek SummaryZoomSection pertama
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Pemformatan untuk objek SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Menyimpan presentasi
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat mengontrol kembali ke slide “parent” setelah menampilkan target?**

Ya. [Zoom frame](https://reference.aspose.com/slides/id/cpp/aspose.slides/zoomframe/) atau [section](https://reference.aspose.com/slides/id/cpp/aspose.slides/sectionzoomframe/) memiliki metode `set_ReturnToParent` yang mengirim penonton kembali ke slide asal setelah mereka mengunjungi konten target.

**Apakah saya dapat mengatur “kecepatan” atau durasi transisi Zoom?**

Ya. Zoom mendukung pengaturan durasi transisi sehingga Anda dapat mengontrol berapa lama animasi lompatan berlangsung.

**Apakah ada batasan berapa banyak objek Zoom yang dapat dimiliki sebuah presentasi?**

Tidak ada batas API keras yang didokumentasikan. Batas praktis bergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak frame Zoom, namun pertimbangkan ukuran berkas dan waktu rendering.