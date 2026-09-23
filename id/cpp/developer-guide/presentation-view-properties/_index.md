---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi dalam C++
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/cpp/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- snap pembagi vertikal
- tampilan tunggal
- status bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk C++ untuk menyesuaikan format slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bagian bawah. Properti yang terkait dengan posisi berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga saat dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) telah ditambahkan untuk memberikan akses ke properti tampilan normal presentasi.  

[INormalViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/inormalviewrestoredproperties/) antarmuka dan turunannya, serta enum [SplitterBarStateType](https://reference.aspose.com/slides/id/cpp/aspose.slides/splitterbarstatetype/) telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Properti **ShowOutlineIcons** menentukan apakah aplikasi harus menampilkan ikon jika menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Properti **SnapVerticalSplitter** menentukan apakah pembagi vertikal harus menempel ke keadaan diminimalkan ketika wilayah samping cukup kecil.

Properti **PreferSingleView** menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih untuk menampilkan salah satu wilayah konten di seluruh jendela.

Properti **VerticalBarState** dan **HorizontalBarState** menentukan keadaan yang harus ditunjukkan oleh bar pembagi horizontal atau vertikal. Bar pembagi horizontal memisahkan slide dari wilayah konten di bawah slide, bar pembagi vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** dan **SplitterBarStateType.Restored**.

Properti **RestoredLeft** dan **RestoredTop** menentukan ukuran wilayah slide atas atau samping tampilan normal, ketika nilai **SplitterBarStateType.Restored** diterapkan untuk **VerticalBarState** dan **HorizontalBarState** secara berurutan.

## **Tentang Memulihkan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika anak dari RestoredTop, tinggi ketika anak dari RestoredLeft) pada tampilan normal, ketika wilayah memiliki ukuran pemulihan variabel (tidak diminimalkan maupun dimaksimalkan).

Properti **DimensionSize** menentukan ukuran wilayah slide (lebar ketika anak dari RestoredTop, tinggi ketika anak dari RestoredLeft).

Properti **AutoAdjust** menentukan apakah ukuran wilayah konten samping harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh di bawah ini menunjukkan cara mengakses properti **ViewProperties.NormalViewProperties** untuk sebuah presentasi.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Pulihkan properti tampilan presentasi
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Mengatur Nilai Zoom Default**

Aspose.Slides untuk C++ kini mendukung pengaturan nilai zoom default untuk presentasi sehingga saat presentasi dibuka, zoom sudah ditetapkan. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) sebuah presentasi. Properti Tampilan Slide serta [get_NotesViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_notesviewproperties/) dapat diatur secara programatis. Pada topik ini, kita akan melihat dengan contoh cara mengatur Properti Tampilan Presentasi di Aspose.Slides.

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/)  
2. Atur [Properties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) Tampilan Presentasi  
3. Tulis presentasi sebagai file PPTX  

Pada contoh di bawah ini, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Menetapkan properti tampilan presentasi
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Nilai zoom dalam persentase untuk tampilan slide
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Nilai zoom dalam persentase untuk tampilan catatan 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Mengatur Jarak Grid**

Gunakan [Presentation::get_ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_viewproperties/) untuk mengakses pengaturan tampilan seluruh presentasi. Metode [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/get_gridspacing/) dan [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/set_gridspacing/) membaca atau mengubah interval grid pengeditan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk setiap slide. Jarak grid ditentukan dalam point, dimana 72 point sama dengan satu inci. Gunakan nilai positif, seperti yang diperlukan oleh dokumentasi API.

Contoh berikut membuka `demo.pptx` yang ada, mencetak jarak grid saat ini, mengatur interval seperempat inci, dan menyimpan hasilnya.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Grid berbeda dari [drawing guides](/slides/id/cpp/drawing-guides/). Jarak grid mengontrol interval reguler, sementara drawing guides adalah garis penyelarasan horizontal atau vertikal yang diposisikan secara individual. Menambahkan, memindahkan, atau menghapus drawing guides tidak mengubah jarak grid.

Baik grid maupun drawing guides merupakan bantuan pengeditan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak grid tidak menjamin editor akan menampilkan grid: visibilitasnya juga tergantung pada preferensi penampil atau editor.

## **Menampilkan atau Menyembunyikan Komentar Saat Membuka Presentasi**

Gunakan [Presentation::get_ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_viewproperties/) untuk mengakses pengaturan tampilan seluruh presentasi. Gunakan [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/get_showcomments/) dan [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/set_showcomments/) untuk menyimpan preferensi apakah komentar harus ditampilkan ketika presentasi dibuka di PowerPoint atau editor kompatibel lainnya.

Pengaturan ini hanya mengontrol preferensi tampilan yang disimpan. Ini tidak menambah, menghapus, menyunting, atau menyelesaikan komentar. Menyembunyikan komentar mempertahankan isi, penulis, posisi, balasan, dan statusnya. Lihat [Presentation Comments](/slides/id/cpp/presentation-comments/) untuk operasi yang mengubah komentar itu sendiri.

Contoh berikut memerlukan `comments.pptx` yang ada dan berisi komentar. Ia mencetak pengaturan visibilitas saat ini, meminta komentar disembunyikan, dan menyimpan PPTX baru tanpa menghapus komentar apa pun. Ia juga menggunakan [IViewProperties::set_LastView](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/set_lastview/) dengan [ViewType::SlideView](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewtype/) untuk mengonfigurasi tampilan pengeditan awal bersama visibilitas komentar.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Pengaturan ini tidak menentukan apakah komentar termasuk dalam ekspor PDF, HTML, gambar, catatan, atau handout. Konfigurasikan opsi spesifik ekspor yang relevan secara terpisah.

## **FAQ**

**Mengapa grid tidak terlihat setelah saya membuka kembali presentasi?**  
File menyimpan jarak grid, tetapi editor mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada editor.

**Apakah menghapus drawing guides mengubah jarak grid?**  
Tidak. Drawing guides dan jarak grid adalah pengaturan yang independen. Menghapus guides tidak mengubah interval grid yang disimpan.

**Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian berbeda dari presentasi?**  
Pengaturan [view](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_viewproperties/) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya menentukan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?**  
Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru terbuka dengan cara yang sama?**  
Ya. Karena [view properties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_viewproperties/) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.