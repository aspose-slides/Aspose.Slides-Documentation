---
title: Operasi Presentasi Low-Code dalam C++
linktitle: API Low-Code
type: docs
weight: 50
url: /id/cpp/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- menggabungkan presentasi
- iterasi slide
- iterasi shape
- iterasi teks
- mengumpulkan shape
- kompres presentasi
- hapus master slide yang tidak terpakai
- hapus layout slide yang tidak terpakai
- kompres font yang disematkan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides dalam C++ untuk mengonversi dan menggabungkan presentasi, mengiterasi konten, mengumpulkan shape, dan mengurangi ukuran presentasi."
---
## **Gambaran Umum**

Namespace [Aspose::Slides::LowCode](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/) menyediakan kelas pembantu statis untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan ke dalam metode terfokus, sehingga Anda dapat mengonversi atau menggabungkan file, memproses elemen presentasi, mengumpulkan shape, dan menghapus konten yang tidak terpakai dengan kode yang lebih sedikit.

Pembantu low‑code paling berguna ketika operasi diterapkan pada seluruh file atau presentasi dan alur kerja default memenuhi kebutuhan Anda. Gunakan model objek lengkap [Aspose.Slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/) ketika Anda memerlukan kontrol yang lebih halus atas slide, master, layout, shape, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Pembantu | Gunakan untuk |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/convert/) | Mengonversi presentasi ke format lain dengan panggilan file‑ke‑file langsung. |
| [Merger](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/merger/) | Menggabungkan file presentasi lengkap dengan format yang sama. |
| [ForEach](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/) | Menjalankan aksi untuk setiap slide, shape, paragraf, atau potongan teks. |
| [Collect](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/collect/) | Mengambil shape dari seluruh presentasi untuk diproses atau dianalisis berulang kali. |
| [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/) | Menghapus master dan layout yang tidak terpakai serta mengurangi data font yang disematkan. |

## **Mengonversi Presentasi**

Gunakan [Convert::AutoByExtension](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/convert/autobyextension/) ketika ekstensi file output cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari jalur output, dan menulis hasilnya.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Kelas [Convert](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/convert/) juga menyediakan metode khusus untuk output PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek lengkap ketika Anda perlu memeriksa atau memodifikasi presentasi sebelum ekspor atau mengonfigurasi opsi ekspor yang tidak disediakan oleh pembantu yang dipilih. Lihat [Convert Presentation](/cpp/convert-presentation/) untuk alur kerja dan opsi spesifik format.

## **Menggabungkan Presentasi**

Gunakan [Merger::Process](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/merger/process/) untuk menggabungkan file presentasi lengkap dengan satu panggilan. Presentasi masukan harus memiliki format file yang sama.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Pembantu ini cocok ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan mereka secara individual. Gunakan model objek lengkap ketika Anda perlu menggabungkan slide tertentu, menerapkan master atau layout tujuan, mempertahankan bagian secara eksplisit, atau menyelaraskan ukuran slide yang berbeda. Lihat [Merge Presentations](/cpp/merge-presentation/) untuk skenario tersebut.

## **Iterasi Elemen Presentasi**

Kelas [ForEach](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/) memanggil callback untuk setiap tipe elemen presentasi yang diminta. Ini menghindari loop koleksi bertingkat dan memudahkan inspeksi atau perubahan format pada seluruh presentasi.

Contoh berikut menggunakan [ForEach::Slide](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/paragraph/), dan [ForEach::Portion](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/portion/) untuk memeriksa elemen yang bersangkutan:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Secara default, traversal shape dan teks pada seluruh presentasi mencakup slide normal, master, dan layout. Overload dengan parameter `includeNotes` juga dapat memproses slide catatan. Gunakan loop koleksi langsung ketika urutan traversal, penghentian awal, penyaringan sebelum pemanggilan callback, atau kontrol detail orang‑tua‑anak penting.

## **Mengumpulkan Shapes**

Gunakan [Collect::Shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/collect/shapes/) ketika Anda memerlukan koleksi semua shape dalam presentasi daripada callback untuk tiap shape. Ini berguna ketika kumpulan yang sama akan disaring, dihitung, atau diproses lebih dari satu kali.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Gunakan [ForEach::Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/shape/) sebagai gantinya ketika setiap shape dapat ditangani segera dan Anda tidak perlu menyimpan hasil yang dikumpulkan.

## **Mengompresi Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font yang disematkan:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) menghapus slide layout yang tidak dirujuk oleh slide normal mana pun.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) menghapus slide master yang tidak lagi digunakan.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) menghapus karakter yang tidak terpakai dari font yang disematkan.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Hapus layout yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak dirujuk setelah pembersihan layout juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin memerlukan master, layout, atau data font yang disematkan secara lengkap nanti. Untuk detail lebih lanjut, lihat [Slide Master](/cpp/slide-master/) dan [Embedded Font](/cpp/embedded-font/).

## **Tanya Jawab**

**Kapan saya harus menggunakan API low‑code alih‑alih model objek lengkap?**

Gunakan pembantu low‑code ketika operasi standar diterapkan pada file atau presentasi lengkap dan tidak memerlukan kontrol detail atas elemen individual. Gunakan model objek lengkap ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan layout, memeriksa keadaan menengah, atau mengonfigurasi perilaku yang tidak disediakan pembantu.

**Apakah Merger dapat menggabungkan presentasi dengan format file yang berbeda?**

Tidak. [Merger::Process](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/merger/process/) mengharuskan presentasi masukan memiliki format yang sama. Konversi file masukan ke format bersama terlebih dahulu, misalnya dengan [Convert::AutoByExtension](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/convert/autobyextension/), lalu gabungkan file yang telah dikonversi.

**Apakah ForEach memproses slide master, layout, dan catatan?**

[ForEach::Slide](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/slide/) mengiterasi slide presentasi normal. [ForEach::Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/paragraph/), dan [ForEach::Portion](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/portion/) pada seluruh presentasi mencakup slide normal, master, dan layout secara default. Gunakan overload mereka dengan `includeNotes` disetel ke `true` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach::Shape dan Collect::Shapes?**

Gunakan [ForEach::Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/shape/) untuk memproses tiap shape secara langsung melalui callback. Gunakan [Collect::Shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/collect/shapes/) ketika Anda memerlukan hasil yang dapat dipertahankan, disaring, dihitung, atau dilintasi beberapa kali.

**Apakah Compress selalu membuat file presentasi lebih kecil?**

Tidak selalu. Hasilnya tergantung pada apakah presentasi berisi layout yang tidak terpakai, master yang tidak terpakai, atau font yang disematkan dengan karakter yang tidak terpakai. Jika tidak ada hal tersebut, operasi [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/) yang bersangkutan mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dibuat oleh ForEach atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/foreach/) atau menjalankan [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/), panggil [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) untuk menulis hasilnya.

## **Artikel Terkait**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)