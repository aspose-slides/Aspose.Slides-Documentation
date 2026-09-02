---
title: Menggabungkan Presentasi Secara Efisien di C++
linktitle: Gabungkan Presentasi
type: docs
weight: 40
url: /id/cpp/merge-presentation/
keywords:
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- kombinasikan PowerPoint
- kombinasikan presentasi
- kombinasikan slide
- kombinasikan PPT
- kombinasikan PPTX
- kombinasikan ODP
- C++
- Aspose.Slides
description: "Pelajari cara menggabungkan presentasi PowerPoint dan OpenDocument di C++ dengan menyalin slide, mengontrol master dan layout, mengubah ukuran konten slide, mempertahankan bagian, serta menangani file yang dilindungi atau besar."
---
## **Gambaran Umum**

Aspose.Slides for C++ menggabungkan presentasi dengan menyalin slide dari satu [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) ke yang lain. Operasi utama adalah [ISlideCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/), yang dapat mempertahankan format slide sumber atau melampirkan slide yang disalin ke master atau layout di presentasi tujuan.

Artikel ini mencakup alur kerja penggabungan yang paling umum:

- menggabungkan semua slide sambil mempertahankan format sumbernya;
- menggabungkan slide terpilih;
- menerapkan master dari presentasi tujuan;
- menerapkan layout spesifik dari presentasi tujuan;
- menormalkan ukuran slide yang berbeda sebelum menggabungkan;
- menambahkan slide yang disalin ke sebuah bagian;
- menggabungkan beberapa presentasi dalam satu alur kerja end-to-end;
- menangani master, sumber daya, catatan, komentar, media, font, kata sandi, file besar, dan masalah multithreading.

## **Bagaimana Penyalinan Slide Mempengaruhi Master dan Layout**

Sebuah slide mewarisi banyak penampilannya dari layout dan master. Karena itu, overload penyalinan yang Anda pilih menentukan bagaimana slide yang digabungkan diintegrasikan ke dalam presentasi tujuan.

Gunakan [ISlideCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) dengan salah satu cara berikut:

- `AddClone(sourceSlide)` — mempertahankan layout dan format slide sumber. Bila diperlukan, master sumber dapat disalin secara otomatis ke dalam presentasi tujuan. Aspose.Slides melacak master yang disalin secara otomatis sehingga slide yang berulang yang menggunakan master sumber yang sama tidak menyebabkan master tersebut disalin berulang kali.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — melampirkan slide yang disalin ke [IMasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/) tujuan tertentu. Aspose.Slides mencari layout yang cocok di bawah master tersebut berdasarkan tipe atau nama layout.
- `AddClone(sourceSlide, destinationLayout)` — melampirkan slide yang disalin langsung ke [ILayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/) tujuan tertentu.

Master atau layout yang diberikan ke overload `AddClone` harus berasal dari **presentasi tujuan**, bukan dari presentasi sumber.

## **Menggabungkan Seluruh Presentasi dan Mempertahankan Format Sumber**

Penggabungan paling sederhana menyalin setiap slide dari presentasi sumber ke presentasi tujuan. Ini merupakan pilihan yang tepat ketika slide yang diimpor harus mempertahankan tema, master, dan hubungan layout aslinya.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

Presentasi yang dihasilkan mungkin berisi beberapa master ketika sumber dan tujuan menggunakan desain yang berbeda. Hal ini diharapkan ketika format sumber sengaja dipertahankan.

## **Menggabungkan Slide Terpilih**

Anda tidak harus menyalin setiap slide. Contoh berikut mengimpor hanya indeks slide terpilih dari presentasi sumber.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Validasi indeks slide sebelum menyalin ketika mereka berasal dari input pengguna atau konfigurasi eksternal.

## **Menggabungkan Slide Menggunakan Master Tujuan**

Gunakan overload [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) ketika slide yang diimpor harus mengikuti master yang sudah ada di presentasi tujuan.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides memilih layout yang sesuai di bawah master yang ditentukan dengan mencocokkan tipe atau nama layout sumber. Jika tidak ada layout yang cocok dan `allowCloneMissingLayout` bernilai `true`, layout sumber disalin sehingga slide dapat ditambahkan. Jika `false`, sebuah [PptxEditException](https://reference.aspose.com/slides/id/cpp/aspose.slides/details_pptxeditexception/) akan dilempar.

Gunakan `false` ketika Anda ingin penggabungan gagal alih-alih menambahkan layout tambahan ke master tujuan.

## **Menggabungkan Slide Menggunakan Layout Tujuan Spesifik**

Gunakan overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) ketika Anda tahu persis layout tujuan mana yang harus digunakan oleh slide yang diimpor.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Menerapkan layout tujuan mengubah hubungan layout yang diwarisi; tidak mengubah desain konten slide sumber. Jika layout sumber dan tujuan memiliki struktur placeholder yang berbeda, periksa hasilnya untuk memastikan bahwa format dan perilaku placeholder yang diwarisi sudah tepat.

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda**

Presentasi dengan dimensi slide yang berbeda dapat digabungkan, tetapi menyalin slide ke presentasi dengan ukuran slide lain tidak otomatis mendesain ulang kontennya untuk kanvas baru. Bentuk dapat terlihat bergeser, terukur tidak terduga, atau berada di luar area slide yang terlihat.

Pendekatan praktis adalah mengubah ukuran presentasi sumber sebelum menyalin. Metode [SlideSize::SetSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesize/setsize/) dapat menskalakan konten yang ada sambil mengubah dimensi slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesizescaletype/) menskalakan konten agar sesuai dengan ukuran yang diminta.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Mengubah ukuran mengubah objek presentasi sumber di memori. Jika Anda membutuhkan presentasi sumber asli tetap tidak berubah untuk operasi lain, buka instansi terpisah untuk penggabungan.

## **Menggabungkan Slide ke dalam Bagian Presentasi**

Loop penyalinan slide dasar tidak membuat kembali hierarki bagian presentasi sumber. Jika bagian penting dalam output, buat atau pilih bagian di presentasi tujuan dan salin slide ke dalamnya secara eksplisit dengan [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Slide yang disalin ditambahkan ke bagian tujuan yang ditentukan. Untuk mempertahankan beberapa bagian sumber, buat kembali bagian-bagian tersebut di tujuan dan petakan setiap slide sumber ke bagian tujuan yang sesuai.

## **Menggabungkan Beberapa Presentasi dengan Aman**

Contoh end-to-end berikut menggunakan presentasi pertama sebagai tujuan, menormalkan ukuran slide masing-masing sumber tambahan, menjaga setiap sumber terbuka hanya saat sedang disalin, dan menyimpan file akhir sekali saja.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Ini merupakan baseline yang berguna untuk mempertahankan format sumber slide yang diimpor. Jika output Anda harus menggunakan satu tema tujuan, gantikan pemanggilan sederhana `AddClone(slide)` dengan overload master atau layout tujuan yang sesuai yang ditunjukkan sebelumnya.

## **Pertimbangan Praktis**

### **Master, Layout, dan Kesetiaan Formatting**

Penyalinan slide default dapat secara otomatis membawa master sumber yang diperlukan ke dalam presentasi tujuan. Aspose.Slides menyimpan registry internal untuk master yang disalin secara otomatis guna menghindari penyalinan master yang sama berulang kali. Master yang disalin secara manual tidak dilacak oleh registry tersebut, jadi hindari menyalin master sebelumnya kecuali Anda memerlukan kontrol eksplisit atas struktur master.

Jangan mengasumsikan bahwa dua master atau layout dengan nama yang sama secara visual setara. Jika template perusahaan harus mengontrol tampilan akhir, pilih master atau layout tujuan secara eksplisit dan verifikasi hasil setelah penggabungan.

### **Catatan dan Komentar**

Catatan pembicara dan komentar slide terkait dengan konten slide dan disalin saat slide disalin. Aspose.Slides juga menyediakan API khusus untuk [presentation notes](https://docs.aspose.com/slides/id/cpp/presentation-notes/) dan [presentation comments](https://docs.aspose.com/slides/id/cpp/presentation-comments/).

Jika format halaman catatan penting, verifikasi presentasi yang digabungkan karena master catatan adalah objek level presentasi dan dapat berbeda antar file sumber. Untuk alur kerja review, verifikasi juga penulis komentar dan komentar berulir setelah menggabungkan file dari penulis atau template yang berbeda.

### **Gambar, Audio, Video, OLE Objects, dan Tautan Eksternal**

Slide dapat merujuk sumber daya level presentasi seperti gambar, audio tersemat, video tersemat, dan data OLE. Salin slide itu sendiri bukan hanya bentuk yang terlihat sehingga Aspose.Slides dapat mempertahankan hubungan slide ke sumber dayanya.

Sumber daya tersemat dan tertaut harus diperlakukan berbeda. Audio, video, objek OLE, atau hyperlink yang ditautkan tetap bergantung pada target eksternal; menyalin slide tidak mengubah tautan eksternal menjadi konten tersemat. Uji jalur dan URL sumber daya tertaut di lingkungan tempat presentasi yang digabungkan akan dibuka.

Aspose.Slides secara eksplisit melacak master yang disalin secara otomatis, tetapi ini tidak boleh dianggap sebagai jaminan umum bahwa sumber daya biner identik dari presentasi sumber yang tidak terkait akan selalu didedupikasi. Jika ukuran file output penting, inspeksi paket yang digabungkan dan ukur hasilnya alih-alih mengandalkan deduplikasi implisit.

### **Font Tersemat dan Ketersediaan Font**

Font dikelola pada level presentasi. Jika tipografi harus tetap konsisten antar mesin, jangan mengasumsikan bahwa menyalin slide saja menjamin setiap font yang diperlukan tersedia di lingkungan tujuan. Anda dapat memeriksa font tersemat dengan [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getembeddedfonts/) dan mengelola penyematan secara eksplisit seperti dijelaskan di [Embed Fonts in Presentations](https://docs.aspose.com/slides/id/cpp/embedded-font/).

Juga pastikan Anda diizinkan menyematkan font yang digunakan oleh file sumber. Lisensi font dapat membatasi penyematan.

### **Presentasi yang Dilindungi Kata Sandi**

Sumber yang dilindungi kata sandi harus dibuka berhasil sebelum slide-nya dapat disalin. Berikan kata sandi melalui [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Membuka sumber yang terenkripsi tidak secara otomatis menerapkan perlindungan yang sama pada presentasi tujuan. Konfigurasikan perlindungan output secara terpisah bila diperlukan.

### **Presentasi Besar dan Penggunaan Memori**

Presentasi besar yang berisi gambar resolusi tinggi, audio, video, atau objek biner besar lainnya dapat mengonsumsi memori yang signifikan. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) menyediakan kontrol untuk penanganan BLOB dan penggunaan file sementara. Lihat [Manage Presentation BLOBs](https://docs.aspose.com/slides/id/cpp/manage-blob/) untuk strategi file besar.

Untuk file besar, lebih baik memuat dari jalur file bila memungkinkan, buang masing-masing presentasi sumber segera setelah selesai digabungkan, dan hindari menyimpan hasil perantara secara berulang kecuali alur kerja memerlukan checkpoint.

### **Keamanan Thread**

Jangan memuat, memodifikasi, menyimpan, atau menyalin instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang sama secara bersamaan dari beberapa thread. Jaga setiap instance presentasi terbatas pada satu operasi penggabungan. Jika Anda memparallelkan pekerjaan independen, gunakan instance presentasi yang independen dan ikuti [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/id/cpp/multithreading/).

## **FAQ**

**Bagaimana cara mempertahankan desain asli setiap presentasi sumber?**

Gunakan [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) tanpa menyediakan master atau layout tujuan. Aspose.Slides dapat secara otomatis menyalin master sumber ketika diperlukan oleh slide yang diimpor.

**Bagaimana cara membuat slide yang diimpor menggunakan tema tujuan?**

Gunakan overload yang menerima master tujuan. Berikan master dari presentasi tujuan, bukan dari sumber. Aspose.Slides akan mencoba memetakan setiap slide sumber ke layout yang sesuai di bawah master tersebut.

**Kapan saya harus menggunakan layout tujuan spesifik alih-alih master tujuan?**

Gunakan layout spesifik ketika setiap slide yang diimpor harus menggunakan satu layout yang diketahui. Gunakan master ketika Anda ingin Aspose.Slides memilih di antara layout master tersebut berdasarkan tipe atau nama layout sumber.

**Apakah presentasi dengan ukuran slide berbeda dapat digabungkan?**

Ya, tetapi konten slide tidak otomatis didesain ulang untuk dimensi tujuan. Ubah ukuran presentasi sumber terlebih dahulu ketika Anda memerlukan penempatan yang dapat diprediksi, misalnya dengan [SlideSize::SetSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesize/setsize/) dan [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesizescaletype/).

**Bisakah saya menggabungkan file PPT, PPTX, dan ODP menjadi satu file?**

Ya. Muat setiap presentasi sumber, salin slide yang diperlukan ke satu tujuan, dan simpan tujuan dalam format output yang didukung. Karena format presentasi tidak mendukung set fitur yang persis sama, verifikasi konten kompleks setelah penggabungan lintas format. Lihat [Supported File Formats](https://docs.aspose.com/slides/id/cpp/supported-file-formats/).

**Apakah bagian sumber dipertahankan secara otomatis?**

Tidak oleh loop dasar yang hanya menyalin slide. Buat kembali bagian yang diperlukan di tujuan dan gunakan overload section dari [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) ketika struktur bagian harus dipertahankan.

**Apakah catatan pembicara dan komentar dipertahankan?**

Mereka disalin bersama slide yang disalin. Untuk alur kerja yang bergantung pada styling master catatan, penulis komentar, atau data review berulir, verifikasi hasil yang digabungkan karena skenario tersebut melibatkan struktur level presentasi serta konten level slide.

**Apa yang terjadi pada audio, video, objek OLE, dan hyperlink?**

Konten tersemat dibawa sebagai bagian dari hubungan sumber daya slide yang disalin. Tautan eksternal tetap eksternal, sehingga file target atau URL mereka harus tetap tersedia setelah penggabungan.

**Apakah font tersemat dari setiap sumber dijamin tersedia dalam presentasi yang digabungkan?**

Jangan mengandalkan penyalinan slide saja untuk penyebaran font. Periksa font tersemat pada tujuan dan kelola penyematan font atau ketersediaan font eksternal secara eksplisit ketika tipografi penting.

**Bagaimana cara menggabungkan file yang dilindungi kata sandi?**

Bukalah dengan [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/) yang benar, kemudian salin slide-nya secara normal. Perlindungan output dikonfigurasi secara terpisah.

**Bagaimana saya harus menangani presentasi yang sangat besar?**

Gunakan manajemen BLOB ketika objek biner besar mendominasi penggunaan memori, lebih suka memuat dari jalur file untuk file sangat besar, buang presentasi sumber segera, dan simpan hasil akhir hanya ketika diperlukan.

**Bisakah saya menyalin slide dari banyak thread?**

Jangan gunakan satu instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) secara bersamaan dari banyak thread. Jaga setiap operasi penggabungan terisolasi pada instance presentasinya masing‑masing.