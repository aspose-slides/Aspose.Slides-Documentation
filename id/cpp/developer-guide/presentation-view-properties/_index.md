---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di C++
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/cpp/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten kerangka
- ikon kerangka
- snap pembagi vertikal
- tampilan tunggal
- status bilah
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk C++ untuk mengonfigurasi tata letak tampilan normal, zoom slide dan catatan, jarak grid, serta visibilitas komentar dalam presentasi PowerPoint."
---
## **Pendahuluan**

Dalam tampilan normal PowerPoint, slide muncul di antara panel samping untuk thumbnail atau kerangka dan panel catatan di bawah. Aspose.Slides untuk C++ menampilkan preferensi penyuntingan yang disimpan melalui [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Ini mencakup tata letak panel, tingkat zoom, jarak grid, dan visibilitas komentar.

## **Tentang INormalViewProperties**

Gunakan [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) untuk mengakses antarmuka [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) mengontrol apakah ikon muncul di samping judul slide dalam kerangka. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) memungkinkan panel samping menempel pada keadaan diperkecil ketika pengguna mempersempitnya. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) menunjukkan preferensi untuk menampilkan satu panel dalam jendela penuh.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) mengontrol pemisah antara panel samping dan slide. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) mengontrol pemisah di atas panel catatan. Kedua metode menerima nilai [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) berupa `Minimized`, `Maximized`, atau `Restored`.

## **Tentang Memulihkan INormalViewProperties**

Saat pemisah dipulihkan, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) memberikan ukuran yang disimpan untuk panel samping dan [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) memberikan ukuran yang disimpan untuk area slide atas. Kedua properti mengekspose [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Metode [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) menerima persentase dari 0 hingga 100, dan [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) mengontrol apakah editor menyesuaikan ukuran ketika jendela diubah ukurannya.

Contoh ini memperbarui presentasi yang sudah ada. Ia memulihkan pemisah horizontal, mengatur ukuran area slide atas yang diberikan oleh [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) menjadi 80 % dengan penyesuaian otomatis diaktifkan, dan memaksimalkan pemisah vertikal. Ia juga mengaktifkan ikon kerangka dengan [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) untuk tampilan kerangka.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Atur Nilai Zoom Default**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) dan [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) menyimpan pengaturan zoom terpisah untuk editor. Pengaturan ini tidak memengaruhi dimensi slide, pemutaran slide-show, atau resolusi ekspor gambar.

Contoh ini membuka presentasi yang sudah ada dan mengaktifkan penskalaan otomatis dengan [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) agar slide menyesuaikan ukuran jendela penyuntingan. Untuk halaman catatan, ia menonaktifkan penskalaan otomatis dan menggunakan [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) untuk menetapkan zoom tetap 80 %.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Atur Jarak Grid**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) menetapkan jarak antara garis grid penyuntingan di seluruh presentasi. Nilai yang diterima berupa angka positif dalam poin, dengan 72 poin per inci. Contoh ini menampilkan jarak saat ini dalam presentasi yang ada dan menyimpan grid seperempat inci dengan mengatur interval menjadi 18 poin.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Grid berulang pada interval tetap. [Drawing guides](/slides/id/cpp/drawing-guides/) menandai posisi horizontal atau vertikal secara individu. Kedua elemen ini adalah bantuan penyuntingan dan hanya muncul di editor yang menampilkannya. Slide show serta ekspor ke PDF, gambar, atau SVG tidak menyertakannya.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) menyimpan preferensi yang digunakan editor kompatibel saat membuka presentasi. Untuk presentasi yang sudah ada dengan komentar, contoh ini menampilkan pengaturan saat ini dan menyimpan salinan dengan komentar tersembunyi. Ia juga memanggil [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) dengan [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) agar salinan terbuka dalam tampilan slide.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Menyembunyikan komentar mempertahankan teks, penulis, posisi, balasan, dan statusnya. Untuk mengubah komentar itu sendiri, lihat [Presentation Comments](/slides/id/cpp/presentation-comments/). Pengaturan ekspor mengontrol apakah komentar muncul dalam PDF, HTML, gambar, catatan, atau handout.

## **FAQ**

**Mengapa grid disembunyikan saat saya membuka kembali presentasi?**

Presentasi menyimpan interval grid. Untuk melihat grid, aktifkan visibilitas grid di editor.

**Apakah menghapus panduan gambar mengubah jarak grid?**

Tidak. Menambahkan, memindahkan, atau menghapus panduan tidak mengubah interval grid.

**Bisakah bagian berbeda dari sebuah presentasi memiliki pengaturan tampilan yang berbeda?**

Tidak. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) berlaku untuk seluruh presentasi.

**Bisakah saya menyimpan pengaturan tampilan yang berbeda untuk pengguna yang berbeda?**

File menyimpan satu set properti tampilan untuk semua orang. Editor juga dapat menerapkan preferensi lokal pengguna.

**Bisakah saya menyimpan pengaturan tampilan dalam templat?**

Ya. Presentasi yang dibuat dari templat mewarisi pengaturan tampilan yang disimpan.