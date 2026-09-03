---
title: Kelola Transisi Slide dalam Presentasi Menggunakan C++
linktitle: Transisi Slide
type: docs
weight: 80
url: /id/cpp/slide-transition/
keywords:
- transisi slide
- menambahkan transisi slide
- menerapkan transisi slide
- transisi slide lanjutan
- transisi morph
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan pergerakan slide otomatis, dan sesuaikan Morph serta efek transisi lainnya dengan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Transisi slide mengontrol bagaimana slide muncul selama pertunjukan slide. Dengan Aspose.Slides for C++, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi pergerakan dengan klik mouse atau timer, dan menyesuaikan opsi khusus untuk sebuah efek. Artikel ini menggunakan contoh C++ untuk menerapkan transisi, menetapkan durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan akses pengaturan transisi slide melalui [get_SlideShowTransition](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Panggil [set_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_type/) dengan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitiontype/), kemudian simpan presentasi.

Contoh berikut menerapkan transisi Circle pada slide pertama dan transisi Comb pada slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Menambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Metode berikut mengontrol perilaku ini:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [set_AdvanceAfter](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_advanceafter/) mengaktifkan pergerakan otomatis.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) menentukan jeda sebelum pergerakan otomatis, dalam milidetik.

Aktifkan pergerakan dengan klik dan timer untuk membiarkan penonton melanjutkan dengan klik atau menunggu timer. Untuk hanya menggunakan timer, panggil [set_AdvanceOnClick](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) dengan `false`. Jeda mengontrol kapan pertunjukan slide berlanjut; tidak menentukan durasi efek transisi visual.

Contoh ini menetapkan efek berbeda pada tiga slide pertama dan mengaktifkan pergerakan otomatis setelah 3, 5, dan 7 detik, masing‑masing. Klik mouse juga dapat mempercepat slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Untuk memeriksa apakah pergerakan berbasis timer diaktifkan, panggil [get_AdvanceAfter](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Jeda yang disimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan pergerakan otomatis untuk slide dengan jeda lebih dari dua detik. Itu mengaktifkan klik mouse untuk slide tersebut dan menyimpan pengaturan yang diperbarui.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Mengontrol Waktu Transisi Secara Tepat**

Gunakan [set_Duration](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_duration/) untuk menentukan panjang tepat efek transisi dalam milidetik. Metode [get_SlideShowTransition](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) pada slide mengungkapkan pengaturan ini melalui [ISlideShowTransition](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/):

| Metode | Tujuan |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_duration/) | Menetapkan durasi efek transisi itu sendiri, dalam milidetik. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Menetapkan jeda sebelum slide maju secara otomatis, dalam milidetik. Panggil [set_AdvanceAfter](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_advanceafter/) dengan `true` untuk mengaktifkan timer ini. |
| [set_Speed](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_speed/) | Memilih kategori kecepatan yang telah ditentukan dari [TransitionSpeed](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium, atau Fast. Digunakan ketika durasi yang tepat tidak ditentukan. |

[set_Duration] mengontrol hanya efek transisi; tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan jeda pergerakan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang disetel, Aspose.Slides menentukan durasi efek dari tipe transisi dan nilai yang dikembalikan oleh [get_Speed](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Terapkan Durasi yang Sama pada Setiap Slide**

Untuk ritme yang konsisten, terapkan efek dan durasi tepat yang sama pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitiontype/), dan memberi setiap transisi durasi 750 milidetik. Secara terpisah mengaktifkan pergerakan otomatis setelah 5.000 milidetik dan menonaktifkan pergerakan dengan klik mouse, lalu menyimpan hasilnya sebagai PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Konfigurasikan pergerakan otomatis secara terpisah dari durasi efek.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Tetapkan Durasi Berbeda untuk Slide Individual**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengantar bagian. Contoh ini menetapkan 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Koordinasikan Transisi dengan Output Animasi**

Saat menyiapkan [animated GIF](/slides/id/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/cpp/export-to-html5/), atau [video](/slides/id/cpp/convert-powerpoint-to-video/), tetapkan durasi transisi yang tepat sebelum ekspor agar sesuai dengan kecepatan yang diinginkan. Misalnya, gunakan fade 600 milidetik antar adegan, dan sesuaikan jeda pergerakan masing‑masing slide secara terpisah untuk memberi waktu pada narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik bersesuaian dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi dalam pengaturan ekspor. Periksa efek dan opsi waktu yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Panggil [get_Duration](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/get_duration/) sebelum memodifikasi transisi untuk menentukan apakah nilai eksplisit disimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang disetel; nilai non‑negatif menunjukkan durasi yang disimpan dalam milidetik. Nilai yang tidak disetel bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan tipe transisi dan nilai yang dikembalikan oleh [get_Speed](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/get_speed/) untuk menentukan durasi tersebut. Menetapkan tipe transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dahulu.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Transisi Morph**

Transisi Morph menganimasikan perubahan antar objek pada slide berurutan. Untuk membuat efek Morph sederhana, gandakan sebuah slide, pindahkan atau ubah ukuran sebuah objek pada salinan, dan terapkan transisi Morph pada slide kedua. Ini memberikan objek yang bersesuaian untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, menggandakan slide, dan mengubah posisi serta ukuran persegi panjang pada salinan. Kemudian memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitiontype/) untuk slide kedua. Buka file yang disimpan di penampil presentasi yang mendukung Morph untuk melihat efeknya selama pertunjukan slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Jenis Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitionmorphtype/) mengontrol cara Morph mencocokkan dan menganimasikan konten:

- [ByObject](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitionmorphtype/) menganggap setiap bentuk sebagai satu objek keseluruhan.
- [ByWord](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitionmorphtype/) menganimasikan teks dengan mencocokkan kata‑kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitionmorphtype/) menganimasikan teks dengan mencocokkan karakter bila memungkinkan.

Panggil [set_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_type/) dengan Morph sebelum mengakses [get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/get_value/). Nilai tersebut kemudian menyediakan antarmuka [IMorphTransition](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/imorphtransition/), yang metode [set_MorphType](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) memilih mode pencocokan.

Contoh ini membuka presentasi yang dibuat pada bagian sebelumnya dan mengkonfigurasi slide kedua untuk menggunakan animasi Morph berbasis kata.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Mengatur Efek Transisi**

Beberapa transisi menampilkan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada tipe transisi yang dipilih. Tetapkan tipe terlebih dahulu, kemudian gunakan antarmuka yang tepat yang dikembalikan oleh [get_Value](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/get_value/).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia memanggil [set_FromBlack](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) dengan `true` melalui [IOptionalBlackTransition](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/ioptionalblacktransition/) sehingga transisi dimulai dari layar hitam.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Pilih [set_Duration](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_duration/) ketika Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [set_Speed](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_speed/) ketika kategori [TransitionSpeed](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitionspeed/) yang telah ditentukan—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang disetel. Pengaturan ini mengontrol efek transisi secara independen dari jeda pergerakan otomatis.

**Apakah saya dapat melampirkan audio pada transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat dengan [set_Sound](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_sound/), panggil [set_SoundMode](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_soundmode/) dengan StartSound dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitionsoundmode/), dan aktifkan pengulangan dengan [set_SoundLoop](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_soundloop/). Audio akan berulang hingga ada peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Loop melalui koleksi yang dikembalikan oleh metode [get_Slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slides/) pada presentasi dan panggil [set_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/set_type/) dengan nilai yang sama untuk setiap transisi slide. Atur opsi waktu dan efek dalam loop yang sama agar perilaku tetap konsisten di semua slide.

**Bagaimana saya dapat memeriksa transisi mana yang saat ini diatur pada slide?**

Panggil [get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/islideshowtransition/get_type/) pada transisi yang dikembalikan oleh metode [get_SlideShowTransition](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) slide. Itu mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/cpp/aspose.slides.slideshow/transitiontype/); None berarti tidak ada efek transisi yang diterapkan.