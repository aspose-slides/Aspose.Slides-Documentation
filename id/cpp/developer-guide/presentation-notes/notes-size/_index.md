---
title: Ubah Ukuran dan Orientasi Halaman Catatan dalam C++
linktitle: Ukuran Halaman Catatan
type: docs
weight: 10
url: /id/cpp/notes-size/
keywords:
- ukuran halaman catatan
- orientasi catatan
- catatan lanskap
- catatan potret
- ukuran handout
- PowerPoint
- presentasi
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Baca dan ubah dimensi halaman catatan di Aspose.Slides untuk C++, ubah orientasi, verifikasi ukuran yang disimpan, serta ekspor catatan atau handout ke PDF dan gambar."
---
## **Gambaran Umum**

Gunakan [Presentation::get_NotesSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_notessize/) untuk mengakses pengaturan halaman catatan presentasi. Metode ini mengembalikan objek [INotesSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/inotessize/) yang mana metode [set_Size](https://reference.aspose.com/slides/id/cpp/aspose.slides/inotessize/set_size/) mengatur dimensi. Meskipun objek pengaturan catatan tidak dapat diganti, Anda dapat mengubah ukurannya.

Lebar dan tinggi ditentukan dalam **point**, dengan 72 point per inci. Misalnya, 900 × 600 point adalah 12,5 × 8⅓ inci. Pengaturan ini berlaku untuk keseluruhan presentasi, bukan untuk catatan slide individu.

| Pengaturan | Tujuan |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_notessize/) | Mengontrol dimensi halaman catatan dan dimensi halaman yang digunakan untuk ekspor handout. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slidesize/) | Mengontrol dimensi slide presentasi reguler melalui [ISlideSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/). |

Mengubah salah satu pengaturan tidak secara otomatis mengubah yang lain. Mengubah orientasi halaman catatan juga tidak memutar slide reguler. Lihat [Slide Size](/slides/id/cpp/slide-size/) untuk mengubah ukuran slide reguler.

Contoh di bawah ini menggunakan file `sample.pptx` yang sudah ada. Untuk contoh ekspor, gunakan presentasi dengan setidaknya satu slide yang berisi catatan pembicara. Setiap contoh dapat dijalankan secara terpisah.

## **Baca Ukuran dan Orientasi Halaman Catatan**

Baca lebar dan tinggi serta bandingkan untuk menentukan orientasi: halaman yang lebih lebar adalah lanskap, yang lebih tinggi adalah potret, dan dimensi yang sama menggambarkan halaman berbentuk persegi. Contoh ini mencetak dimensi aktual dalam point, tanpa mengasumsikan ukuran kertas standar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Beralih ke Lanskap Tanpa Mengubah Ukuran Kertas**

Untuk mengubah hanya orientasi, tukar lebar dan tinggi yang ada. Ini mempertahankan panjang kedua sisi, termasuk ukuran kertas khusus. Kondisi di bawah ini mencegah halaman yang sudah lanskap diubah kembali menjadi potret dan membiarkan halaman persegi tetap tidak berubah.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Untuk orientasi potret, gunakan penugasan yang sama ketika `size.get_Width() > size.get_Height()`. Jangan mengganti dimensi A4 atau Letter kecuali Anda juga ingin mengubah ukuran kertas.

## **Atur dan Verifikasi Ukuran Halaman Catatan Kustom**

Tetapkan kedua dimensi sekaligus, kemudian gunakan [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) untuk menyimpan presentasi. Contoh ini menetapkan halaman lanskap 900 × 600 point, menyimpannya sebagai PPTX, dan membuka kembali file yang disimpan untuk memeriksa nilai yang dipertahankan. Perbandingan mengizinkan toleransi 0,01 point untuk nilai floating‑point; ini bukan jaminan presisi untuk setiap format file.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Hasil yang diharapkan adalah `900 x 600 points` dan `Size preserved: True`. Memeriksa presentasi yang baru dibuka memverifikasi file yang disimpan, bukan hanya pengaturan dalam memori.

## **Ekspor Catatan dan Handout**

Dimensi halaman mendefinisikan area yang tersedia untuk tata letak catatan atau handout. Mereka tidak mengaktifkan tata letak tersebut secara otomatis: konfigurasikan opsi ekspor juga. Ekspor slide reguler tetap menggunakan dimensi slide.

### **Ekspor Catatan ke PDF dan PNG**

Tetapkan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/) ke [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) untuk menyertakan catatan dalam PDF. Contoh ini juga merender slide pertama dengan catatan ke PNG menggunakan [Slide::GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/getimage/) dan [RenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/renderingoptions/).

Mode [BottomTruncated](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notespositions/) menjaga catatan pada satu halaman; catatan yang tidak muat dapat terpotong. PDF menggunakan halaman 900 × 600 point. Pada skala gambar 1 × 1 yang digunakan di bawah, PNG berukuran 900 × 600 piksel. Point mendeskripsikan geometri halaman; piksel mendeskripsikan output raster, yang dimensinya juga bergantung pada skala rendering.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Untuk ekspor PDF dengan catatan panjang, [BottomFull](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notespositions/) memungkinkan halaman tambahan sesuai kebutuhan. Jangan gunakan mode itu dengan pemanggilan gambar satu slide di atas, yang tidak mendukungnya. Setelah mengubah ukuran, periksa output untuk catatan terpotong dan penempatan objek notes‑master yang ada; mengubah dimensi halaman saja tidak menjamin semua konten akan muat. Lihat [Convert PowerPoint to PDF with Notes](/slides/id/cpp/convert-powerpoint-to-pdf-with-notes/) untuk informasi lebih lanjut tentang ekspor catatan.

### **Ekspor Handout ke PDF**

Gunakan [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/handoutlayoutingoptions/) untuk menampilkan beberapa thumbnail slide pada satu halaman. Contoh berikut menetapkan halaman 900 × 600 point dan menggunakan [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/handouttype/) untuk menyusun hingga empat slide per halaman. Preset horizontal mengontrol urutan slide; orientasi halaman diambil dari lebar dan tingginya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Mengubah ukuran halaman mengubah area yang tersedia untuk grid handout tanpa mengubah dimensi slide sumber. Untuk gambar handout, gunakan [Presentation::GetImages](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/getimages/) dengan tata letak handout, bukan metode gambar slide individu. Di Aspose.Slides, rendering handout tingkat presentasi menggunakan dimensi halaman catatan, sementara pemanggilan gambar slide individu tidak menghasilkan halaman handout. Lihat [Handout Mode](/slides/id/cpp/convert-powerpoint-in-handout-mode/) untuk opsi tata letak.

## **Ukuran Halaman di Viewer, Ekspor, dan Pencetakan**

Jaga agar ukuran presentasi yang disimpan, ukuran halaman yang diekspor, dan ukuran kertas yang dicetak tetap terpisah:

- **Viewer presentasi:** Viewer dapat menampilkan atau mencetak catatan menggunakan aturan tata letak sendiri. Jika aplikasi lain menyimpan file, buka kembali dan periksa dimensinya lagi; konversi format aplikasi tersebut mungkin menormalkannya.
- **Format ekspor:** Contoh PDF catatan dan handout di atas menggunakan dimensi halaman yang telah dikonfigurasi. Gambar raster menggunakan dimensi piksel integer dan skala rendering, sehingga nilai point pecahan dapat dibulatkan dalam output gambar. Mengekspor slide reguler tidak menerapkan ukuran halaman catatan.
- **Driver printer:** Pemilihan kertas, rotasi otomatis, dan pengaturan sesuaikan‑dengan‑halaman dapat mengubah output fisik tanpa mengubah dimensi yang tersimpan di presentasi atau PDF. Untuk ukuran kertas tertentu, cocokkan pengaturan printer dan periksa pratinjau cetak.

## **FAQ**

**Apakah saya dapat mengatur ukuran catatan hanya untuk satu slide?**

Ukuran halaman catatan adalah pengaturan tingkat presentasi. Slide individual dapat memiliki konten catatan yang berbeda, tetapi properti ini tidak menyediakan ukuran halaman terpisah untuk tiap slide.

**Mengapa mengubah orientasi catatan tidak mengubah slide saya?**

Halaman catatan dan slide reguler memiliki dimensi yang independen. Gunakan pengaturan ukuran slide reguler ketika Anda ingin mengubah ukuran slide itu sendiri.

**Mengapa hasil yang saya simpan atau cetak memiliki ukuran berbeda?**

Pertama, buka kembali presentasi yang disimpan dan bandingkan dimensi catatannya. Jika berubah, periksa apakah menyimpan atau mengonversi file di aplikasi lain mengubah pengaturan halaman. Jika tidak, periksa tata letak ekspor, skala gambar, pengaturan viewer, dan pemilihan kertas printer.