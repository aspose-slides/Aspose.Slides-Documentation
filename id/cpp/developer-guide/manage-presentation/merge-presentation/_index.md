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
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- C++
- Aspose.Slides
description: "Pelajari cara menggabungkan presentasi PowerPoint dan OpenDocument di C++ dengan menyalin slide, mengontrol master dan layout, mengubah ukuran konten slide, mempertahankan section, serta menangani file yang dilindungi atau berukuran besar."
---
## **Gambaran Umum**

Aspose.Slides for C++ menggabungkan presentasi dengan menyalin slide dari satu [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) ke yang lain. Operasi utama adalah [ISlideCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/), yang dapat mempertahankan format slide sumber atau menempelkan slide yang disalin ke master atau layout di presentasi tujuan.

Artikel ini membahas alur kerja penggabungan yang paling umum:

- menggabungkan semua slide sambil mempertahankan format sumbernya;
- menggabungkan slide yang dipilih;
- menerapkan master dari presentasi tujuan;
- menerapkan layout tertentu dari presentasi tujuan;
- menormalkan ukuran slide yang berbeda sebelum menggabungkan;
- menambahkan slide yang disalin ke sebuah section;
- menggabungkan beberapa presentasi dalam satu alur kerja end‑to‑end;
- menangani master, sumber daya, catatan, komentar, media, font, kata sandi, file besar, dan masalah multithreading.

## **Bagaimana Penyalinan Slide Mempengaruhi Master dan Layout**

Sebuah slide mewarisi sebagian besar tampilannya dari layout dan master. Karena itu, overload penyalinan yang Anda pilih menentukan bagaimana slide yang digabungkan diintegrasikan ke dalam presentasi tujuan.

Gunakan [ISlideCollection::AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) dengan salah satu cara berikut:

- `AddClone(sourceSlide)` — mempertahankan layout dan format slide sumber. Jika diperlukan, master sumber dapat disalin secara otomatis ke presentasi tujuan. Aspose.Slides melacak master yang disalin secara otomatis sehingga slide berulang yang menggunakan master sumber yang sama tidak menyebabkan master tersebut disalin berulang‑ulang.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — menempelkan slide yang disalin ke [IMasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/) tujuan tertentu. Aspose.Slides mencari layout yang cocok di bawah master tersebut berdasarkan tipe atau nama layout.
- `AddClone(sourceSlide, destinationLayout)` — menempelkan slide yang disalin langsung ke [ILayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/) tujuan tertentu.

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

Presentasi hasil dapat berisi beberapa master ketika sumber dan tujuan menggunakan desain yang berbeda. Hal ini diharapkan ketika format sumber sengaja dipertahankan.

## **Menggabungkan Slide yang Dipilih**

Anda tidak harus menyalin semua slide. Contoh berikut mengimpor hanya indeks slide tertentu dari presentasi sumber.

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

Validasi indeks slide sebelum menyalin ketika indeks tersebut berasal dari masukan pengguna atau konfigurasi eksternal.

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

Aspose.Slides memilih layout yang cocok di bawah master yang ditentukan dengan mencocokkan tipe atau nama layout sumber. Jika tidak ada layout yang cocok dan `allowCloneMissingLayout` bernilai `true`, layout sumber akan disalin sehingga slide dapat ditambahkan. Jika bernilai `false`, akan dilemparkan [PptxEditException](https://reference.aspose.com/slides/id/cpp/aspose.slides/details_pptxeditexception/).

Gunakan `false` ketika Anda menginginkan penggabungan gagal alih‑alih menambahkan layout tambahan ke master tujuan.

## **Menggabungkan Slide Menggunakan Layout Tujuan Tertentu**

Gunakan overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) ketika Anda sudah mengetahui layout tujuan mana yang harus digunakan oleh slide yang diimpor.

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

Menerapkan layout tujuan mengubah hubungan layout yang diwarisi; tidak mengubah desain konten slide sumber. Jika layout sumber dan tujuan memiliki struktur placeholder yang berbeda, periksa hasilnya untuk memastikan bahwa format yang diwarisi dan perilaku placeholder sudah sesuai.

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda**

Presentasi dengan dimensi slide yang berbeda dapat digabungkan, tetapi menyalin slide ke presentasi dengan ukuran slide lain tidak secara otomatis meredesain kontennya untuk kanvas yang baru. Oleh karena itu bentuk dapat tampak bergeser, terskala tidak terduga, atau berada di luar area slide yang terlihat.

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

Mengubah ukuran mengubah objek presentasi sumber di memori. Jika Anda memerlukan presentasi sumber asli tetap tidak berubah untuk operasi lain, buka instansi terpisah untuk proses penggabungan.

## **Menggabungkan Slide ke Section Presentasi**

Loop penyalinan slide dasar tidak membuat kembali hierarki section dari presentasi sumber. Jika section penting dalam output, buat atau pilih section di presentasi tujuan dan salin slide ke dalamnya secara eksplisit dengan [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/).

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

Slide yang disalin ditambahkan ke section tujuan yang ditentukan. Untuk mempertahankan beberapa section sumber, enumerasi [Presentation::get_Sections](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_sections/), ambil slide saat ini dari setiap section sumber dengan [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/id/cpp/aspose.slides/isection/getslideslistofsection/), buat kembali section di tujuan, dan salin setiap slide yang dikembalikan ke section tujuan yang bersesuaian. Lihat [Manage Slide Sections](/slides/id/cpp/slide-section/) untuk contoh lengkap enumerasi section, termasuk section kosong dan perubahan struktural.

## **Menggabungkan Beberapa Presentasi dengan Aman**

Contoh end‑to‑end berikut menggunakan presentasi pertama sebagai tujuan, menormalkan ukuran slide setiap sumber tambahan, hanya membuka setiap sumber selama proses penyalinan, dan menyimpan file akhir satu kali.

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

Ini merupakan titik awal yang berguna untuk mempertahankan format sumber slide yang diimpor. Jika output Anda harus menggunakan satu tema tujuan, ganti pemanggilan sederhana `AddClone(slide)` dengan overload master‑tujuan atau layout‑tujuan yang telah dijelaskan sebelumnya.

## **Pertimbangan Praktis**

### **Master, Layout, dan Kualitas Format**

Penyalinan slide default dapat secara otomatis membawa master sumber yang dibutuhkan ke dalam presentasi tujuan. Aspose.Slides menyimpan registri internal untuk master yang disalin secara otomatis agar tidak menyalin master yang sama berulang‑ulang. Master yang disalin secara manual tidak tercatat di registri tersebut, jadi hindari menyalin master sebelumnya kecuali Anda memerlukan kontrol eksplisit atas struktur master.

Jangan mengasumsikan bahwa dua master atau layout dengan nama yang sama secara visual identik. Jika template perusahaan harus mengontrol tampilan akhir, pilih master atau layout tujuan secara eksplisit dan verifikasi hasil setelah penggabungan.

### **Catatan dan Komentar**

Catatan pembicara dan komentar slide terkait dengan konten slide dan disalin ketika slide disalin. Aspose.Slides juga menyediakan API khusus untuk [presentation notes](/slides/id/cpp/presentation-notes/) dan [presentation comments](/slides/id/cpp/presentation-comments/).

Jika format halaman catatan penting, periksa presentasi yang digabung karena master catatan berada pada tingkat presentasi dan dapat berbeda antara file sumber. Untuk alur kerja review, verifikasi juga penulis komentar dan komentar berulir setelah menggabungkan file dari penulis atau template yang berbeda.

### **Gambar, Audio, Video, Objek OLE, dan Tautan Eksternal**

Slide dapat merujuk pada sumber daya tingkat presentasi seperti gambar, audio tertanam, video tertanam, dan data OLE. Salin slide secara keseluruhan bukan hanya bentuk yang terlihat sehingga Aspose.Slides dapat mempertahankan hubungan slide dengan sumber dayanya.

Sumber daya tertaut dan tertanam harus diperlakukan berbeda. Audio, video, objek OLE, atau hyperlink yang ditautkan tetap bergantung pada target eksternal; menyalin slide tidak mengubah tautan eksternal menjadi konten tertanam. Uji jalur dan URL sumber daya tertaut di lingkungan tempat presentasi yang digabungkan akan dibuka.

Aspose.Slides secara eksplisit melacak master yang disalin otomatis, namun hal ini tidak boleh dianggap sebagai jaminan umum bahwa sumber daya biner yang identik dari presentasi sumber yang tidak terkait akan selalu didedupikasi. Jika ukuran file output penting, inspeksi paket yang digabung dan ukur hasilnya alih‑alih mengandalkan deduplikasi implisit.

### **Font Tertanam dan Ketersediaan Font**

Font dikelola pada tingkat presentasi. Jika tipografi harus konsisten di semua mesin, jangan mengasumsikan bahwa menyalin slide saja menjamin semua font yang diperlukan tersedia di lingkungan tujuan. Anda dapat memeriksa font tertanam dengan [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getembeddedfonts/) dan mengelola penanaman secara eksplisit sebagaimana dijelaskan dalam [Embed Fonts in Presentations](/slides/id/cpp/embedded-font/).

Juga pastikan Anda memiliki izin untuk menanamkan font yang digunakan oleh file sumber. Lisensi font dapat membatasi penanaman.

### **Presentasi yang Dilindungi Kata Sandi**

Sumber yang dilindungi kata sandi harus dibuka berhasil sebelum slidennya dapat disalin. Berikan kata sandi melalui [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Membuka sumber yang terenkripsi tidak secara otomatis menerapkan perlindungan yang sama pada presentasi tujuan. Atur perlindungan output secara terpisah bila diperlukan.

### **Presentasi Besar dan Penggunaan Memori**

Presentasi besar yang berisi gambar resolusi tinggi, audio, video, atau objek biner besar lainnya dapat mengonsumsi memori signifikan. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) menyediakan kontrol untuk penanganan BLOB dan penggunaan file sementara. Lihat [Manage Presentation BLOBs](/slides/id/cpp/manage-blob/) untuk strategi file besar.

Untuk file besar, sebaiknya muat dari jalur file bila memungkinkan, buang setiap presentasi sumber segera setelah selesai digabung, dan hindari menyimpan hasil menengah berulang kali kecuali alur kerja memerlukan checkpoint.

### **Keamanan Thread**

Jangan memuat, mengubah, menyimpan, atau menyalin instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang sama secara bersamaan dari beberapa thread. Jaga setiap instance presentasi tetap terisolasi untuk satu operasi penggabungan. Jika Anda memparalelkan pekerjaan independen, gunakan instance presentasi yang terpisah dan ikuti panduan [Aspose.Slides multithreading](/slides/id/cpp/multithreading/).

## **FAQ**

**Bagaimana cara mempertahankan desain asli setiap presentasi sumber?**

Gunakan [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) tanpa menyediakan master atau layout tujuan. Aspose.Slides dapat secara otomatis menyalin master sumber ketika diperlukan oleh slide yang diimpor.

**Bagaimana cara membuat slide yang diimpor menggunakan tema tujuan?**

Gunakan overload yang menerima master tujuan. Berikan master dari presentasi tujuan, bukan dari sumber. Aspose.Slides akan mencoba memetakan setiap slide sumber ke layout yang sesuai di bawah master tersebut.

**Kapan saya harus menggunakan layout tujuan spesifik alih‑alih master tujuan?**

Gunakan layout spesifik ketika setiap slide yang diimpor harus menggunakan satu layout yang sudah diketahui. Gunakan master ketika Anda menginginkan Aspose.Slides memilih di antara layout master tersebut berdasarkan tipe atau nama layout sumber.

**Apakah presentasi dengan ukuran slide berbeda dapat digabungkan?**

Ya, tetapi konten slide tidak secara otomatis dirancang ulang untuk dimensi tujuan. Ubah ukuran presentasi sumber terlebih dahulu ketika Anda memerlukan penempatan yang dapat diprediksi, misalnya dengan [SlideSize::SetSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesize/setsize/) dan [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesizescaletype/).

**Apakah saya dapat menggabungkan file PPT, PPTX, dan ODP menjadi satu file?**

Ya. Muat setiap presentasi sumber, salin slide yang diperlukan ke satu tujuan, dan simpan tujuan dalam format output yang didukung. Karena format presentasi tidak mendukung set fitur yang persis sama, verifikasi konten kompleks setelah penggabungan lintas format. Lihat [Supported File Formats](/slides/id/cpp/supported-file-formats/).

**Apakah section sumber dipertahankan secara otomatis?**

Tidak oleh loop dasar yang hanya menyalin slide. Buat kembali section yang diperlukan di tujuan dan gunakan overload section dari [AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) ketika struktur section harus dipertahankan.

**Apakah catatan pembicara dan komentar dipertahankan?**

Mereka disalin bersama slide yang disalin. Untuk alur kerja yang bergantung pada gaya master catatan, penulis komentar, atau data review berulir, verifikasi hasil penggabungan karena skenario tersebut melibatkan struktur tingkat presentasi serta konten tingkat slide.

**Apa yang terjadi pada audio, video, objek OLE, dan tautan?**

Konten tertanam dibawa sebagai bagian dari hubungan sumber daya slide yang disalin. Tautan eksternal tetap eksternal, sehingga file atau URL target masih harus tersedia setelah penggabungan.

**Apakah font tertanam dari setiap sumber dijamin tersedia di presentasi yang digabung?**

Jangan mengandalkan penyalinan slide saja untuk penyebaran font. Periksa font tertanam pada tujuan dan kelola penanaman font atau ketersediaan font eksternal secara eksplisit ketika tipografi penting.

**Bagaimana cara menggabungkan file yang dilindungi kata sandi?**

Buka dengan [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/) yang benar, lalu salin slidennya seperti biasa. Perlindungan output dikonfigurasi secara terpisah.

**Bagaimana cara menangani presentasi yang sangat besar?**

Gunakan manajemen BLOB ketika objek biner besar mendominasi penggunaan memori, pilih pemuatan dari jalur file untuk file sangat besar, buang presentasi sumber sesegera mungkin, dan simpan hasil akhir hanya saat diperlukan.

**Apakah saya dapat menggabungkan slide dari beberapa thread?**

Jangan gunakan satu instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) secara bersamaan dari beberapa thread. Jaga setiap operasi penggabungan terisolasi pada instance presentasi masing‑masing.