---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di C++
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/cpp/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten garis besar
- ikon garis besar
- penjepit pemisah vertikal
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
description: "Temukan properti tampilan Aspose.Slides untuk C++ untuk menyesuaikan format slide PPT, PPTX, dan ODP — sesuaikan tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti yang berkaitan dengan penempatan berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga saat dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) telah ditambahkan untuk menyediakan akses ke properti tampilan normal dari presentasi.  

Antarmuka [INormalViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/inormalviewrestoredproperties/) dan turunannya, serta enum [SplitterBarStateType](https://reference.aspose.com/slides/id/cpp/aspose.slides/splitterbarstatetype/) telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Properti **ShowOutlineIcons** menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Properti **SnapVerticalSplitter** menentukan apakah pemisah vertikal harus menempel ke keadaan diminimalkan ketika wilayah samping cukup kecil.

Properti **PreferSingleView** menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh‑jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih untuk menampilkan salah satu wilayah konten di seluruh jendela.

Properti **VerticalBarState** dan **HorizontalBarState** menentukan keadaan bar pemisah horizontal atau vertikal yang harus ditampilkan. Bar pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, bar pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** dan **SplitterBarStateType.Restored**.

Properti **RestoredLeft** dan **RestoredTop** menentukan ukuran wilayah slide atas atau samping tampilan normal, ketika nilai **SplitterBarStateType.Restored** diterapkan untuk **VerticalBarState** dan **HorizontalBarState** masing‑masing.

## **Tentang Memulihkan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi anak dari RestoredTop, tinggi ketika menjadi anak dari RestoredLeft) tampilan normal, ketika wilayah tersebut memiliki ukuran dipulihkan yang variabel (tidak diminimalkan maupun dimaksimalkan).  

Properti **DimensionSize** menentukan ukuran wilayah slide (lebar ketika menjadi anak dari RestoredTop, tinggi ketika menjadi anak dari RestoredLeft).  

Properti **AutoAdjust** menentukan apakah ukuran wilayah konten samping harus menyesuaikan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.  

Contoh di bawah ini menunjukkan cara mengakses properti **ViewProperties.NormalViewProperties** untuk sebuah presentasi.

``` cpp
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

## **Atur Nilai Zoom Default**

Aspose.Slides untuk C++ kini mendukung pengaturan nilai zoom default untuk presentasi sehingga saat presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) dari sebuah presentasi. Properti Tampilan Slide serta [get_NotesViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_notesviewproperties/) dapat diatur secara programatis. Pada topik ini, kita akan melihat dengan contoh cara mengatur View Properties dari Presentation di Aspose.Slides.

Untuk mengatur properti tampilan, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/)
1. Atur View [Properties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) dari Presentation
1. Tulis presentasi sebagai file PPTX

Dalam contoh di bawah ini, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Mengatur properti tampilan presentasi
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Nilai zoom dalam persen untuk tampilan slide
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Nilai zoom dalam persen untuk tampilan catatan 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Atur Jarak Grid**

Gunakan [Presentation::get_ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_viewproperties/) untuk mengakses pengaturan tampilan pada tingkat presentasi. Metode [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/get_gridspacing/) dan [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/set_gridspacing/) membaca atau mengubah interval grid penyuntingan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk satu slide saja. Jarak grid ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif sesuai dokumentasi API.

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

Grid berbeda dari [drawing guides](/slides/id/cpp/drawing-guides/). Jarak grid mengontrol interval reguler, sementara drawing guide adalah garis penempatan horizontal atau vertikal yang diposisikan secara individual. Menambah, memindahkan, atau menghapus drawing guide tidak mengubah jarak grid.

Baik grid maupun drawing guide adalah bantuan penyuntingan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak grid tidak menjamin editor akan menampilkan grid: visibilitasnya juga bergantung pada preferensi penampil atau editor.

## **FAQ**

**Mengapa grid tidak terlihat setelah saya membuka kembali presentasi?**  
File menyimpan jarak grid, tetapi editor yang mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada editor yang Anda gunakan.

**Apakah menghapus drawing guide mengubah jarak grid?**  
Tidak. Drawing guide dan jarak grid adalah pengaturan yang independen. Menghapus guide tidak mengubah interval grid yang disimpan.

**Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian yang berbeda dari sebuah presentasi?**  
Pengaturan tampilan didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya mendefinisikan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?**  
Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri hanya berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru terbuka dengan cara yang sama?**  
Ya. Karena [view properties](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_viewproperties/) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.