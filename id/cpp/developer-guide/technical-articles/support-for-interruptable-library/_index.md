---
title: Menginterupsi Operasi Presentasi yang Memakan Waktu Lama di C++
linktitle: Interupsi Operasi Presentasi
type: docs
weight: 150
url: /id/cpp/support-for-interruptable-library/
keywords:
- operasi yang dapat diinterupsi
- token interupsi
- token pembatalan
- tugas yang berjalan lama
- interupsi tugas
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara membatalkan operasi presentasi yang memakan waktu lama di Aspose.Slides untuk C++ dan mengembalikan hasil parsial saat mengekspor slide dalam loop."
---
## **Ringkasan**

Aspose.Slides for C++ dapat menghentikan operasi yang memakan waktu lama seperti memuat, menyimpan, dan merender presentasi. Aplikasi Anda dapat menggunakan token interupsi yang sama untuk menghentikan loop sebelum memproses slide berikutnya.

## **Menginterupsi Operasi Presentasi**

Buat sebuah [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), ambil tokennya dengan [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), berikan token tersebut ke [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), dan berikan opsi pemuatan ke [konstruktor Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Untuk meminta pembatalan, panggil [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) pada sumbernya. Operasi yang dapat diinterupsi berhenti ketika melihat permintaan tersebut.

Contoh ini memulai konversi `sample.pptx` ke `sample.ppt` dalam tugas latar belakang dan meminta pembatalan jika tugas masih berjalan setelah 10 detik. Jika konversi selesai lebih cepat, output sudah lengkap.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Menghubungkan Pembatalan Aplikasi ke Aspose.Slides**

Jika aplikasi Anda menggunakan [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), gunakan [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) untuk meneruskan permintaan pembatalan ke [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). Contoh mengekspor `sample.pptx` ke `sample.pdf` dalam tugas latar belakang. Jika ekspor masih berjalan setelah 20 detik, aplikasi memanggil [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), yang memanggil kembali yang terdaftar.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Berhenti Sebelum Memproses Slide Berikutnya**

Gunakan [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) yang sama untuk presentasi dan loop yang mengekspor slide‑slidenya. Periksa [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) sebelum memulai setiap ekspor. Jika pemanggil dapat menggunakan hasil parsial, kembalikan nomor slide untuk ekspor yang berhasil selesai.

Gunakan presentasi bernama `sample.pptx` dengan setidaknya dua slide. Contoh meminta pembatalan segera setelah mencatat ekspor pertama yang berhasil.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

Contoh menulis `slide-1.pdf` dan mencetak `Starting slide 1` diikuti oleh `Completed: [1]`. Loop melihat permintaan sebelum memulai slide 2. Jika pembatalan malah menginterupsi [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) selama ekspor, blok `catch` menghentikan loop sebelum kode mencatat slide saat ini selesai.

Jika pemanggil perlu menangani pembatalan, ganti pemeriksaan `if` dan `break` di bagian atas loop dengan panggilan ke [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) pada token. Hapus `try`/`catch` di sekitar ekspor sehingga pembatalan selama penyimpanan juga sampai ke pemanggil. Dengan input yang sama, contoh hanya mencetak `Starting slide 1` dan menulis `slide-1.pdf`. Pada awal iterasi kedua, pemanggil menerima [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) sebelum ekspor dimulai. Pemanggil tidak menerima daftar slide yang telah selesai.

## **FAQ**

**Kapan sebaiknya saya meminta pembatalan?**

Minta pembatalan ketika sebuah operasi melebihi batas waktu Anda atau ketika aplikasi Anda tidak lagi membutuhkan hasilnya.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Sumber memungkinkan aplikasi Anda meminta pembatalan. Token memungkinkan Aspose.Slides dan aplikasi Anda memeriksa permintaan tersebut.

**Bisakah saya menggunakan [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) dengan Aspose.Slides?**

Ya. Ketika token aplikasi Anda memberi sinyal pembatalan, panggil [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) pada sumber yang terkait dengan presentasi.

**Operasi apa saja yang dapat saya interupsi?**

Anda dapat menginterupsi pemuatan, penyimpanan, dan perenderan. Berikan token ke [konstruktor Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) melalui [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). Presentasi kemudian dapat mendeteksi pembatalan selama operasi selanjutnya seperti [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Apakah operasi berhenti serta‑merta?**

Pembatalan bersifat kooperatif. Sebuah operasi memeriksa token secara berkala dan berhenti ketika melihat permintaan.

**Apa yang terjadi jika saya memanggil [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) setelah operasi selesai?**

Operasi yang selesai tetap mempertahankan hasilnya.

**Bisakah beberapa operasi berbagi satu [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Ya. Memanggil [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) meminta pembatalan untuk setiap operasi yang menggunakan token dari sumber tersebut. Gunakan sumber terpisah untuk setiap operasi yang ingin Anda batalkan secara independen.