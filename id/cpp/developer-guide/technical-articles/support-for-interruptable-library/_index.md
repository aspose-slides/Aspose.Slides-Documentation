---
title: Dukungan untuk Perpustakaan yang Dapat Diinterupsi
type: docs
weight: 150
url: /id/cpp/support-for-interruptable-library/
keywords:
- perpustakaan yang dapat diinterupsi
- token interupsi
- token pembatalan
- tugas yang berjalan lama
- tugas interupsi
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Buat tugas yang berjalan lama dapat dibatalkan dengan Aspose.Slides untuk C++. Interupsi rendering dan konversi untuk PowerPoint dan OpenDocument secara aman, dengan contoh."
---
## **Gambaran Umum**

Aspose.Slides menyediakan mekanisme pemrosesan yang dapat diinterupsi untuk tugas presentasi yang berjalan lama, seperti deserialisasi, serialisasi, dan rendering. Mekanisme ini didasarkan pada kelas `InterruptionToken` dan `InterruptionTokenSource`.

`InterruptionToken` dapat ditetapkan ke `LoadOptions` dan diteruskan ke konstruktor `Presentation`. Ketika `InterruptionTokenSource::Interrupt()` dipanggil, tugas yang berjalan lama terkait akan diinterupsi.

## **Perpustakaan yang Dapat Diinterupsi**

Pada [Aspose.Slides 18.4](https://releases.aspose.com/slides/id/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), kami memperkenalkan kelas [InterruptionToken](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontokensource/). Kedua kelas ini memungkinkan Anda menginterupsi tugas yang berjalan lama seperti deserialisasi, serialisasi, dan rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontokensource/) adalah sumber token yang diteruskan ke [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Ketika [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_interruptiontoken/) diatur dan instance [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/) diteruskan ke konstruktor [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/), pemanggilan [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontokensource/interrupt/) akan menginterupsi tugas yang berjalan lama yang terkait dengan [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) tersebut.

Potongan kode berikut memperlihatkan cara menginterupsi tugas yang sedang berjalan:

```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // jalankan aksi di thread terpisah
    Threading::Thread::Sleep(10000);       // batas waktu
    tokenSource->Interrupt();              // hentikan konversi
}
```

## **FAQ**

**Apa tujuan perpustakaan interrupt Aspose.Slides?**

Ia menyediakan mekanisme untuk menginterupsi operasi yang memakan waktu lama—seperti memuat, menyimpan, atau merender presentasi—sebelum selesai. Hal ini berguna ketika waktu pemrosesan harus dibatasi atau tugas tersebut tidak lagi diperlukan.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` diteruskan ke API Aspose.Slides dan diperiksa selama operasi yang memakan waktu lama.
- `InterruptionTokenSource` digunakan dalam kode Anda untuk membuat token dan memicu interupsi dengan memanggil `Interrupt()`.

**Tugas apa yang dapat diinterupsi?**

Setiap tugas Aspose.Slides yang menerima [InterruptionToken](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontoken/)—seperti memuat presentasi dengan `Presentation(path, loadOptions)` atau menyimpan dengan `Presentation::Save(...)`—dapat diinterupsi.

**Apakah interupsi terjadi secara langsung?**

Tidak. Interupsi bersifat kooperatif: operasi secara berkala memeriksa token dan berhenti segera setelah mendeteksi bahwa [Interrupt()](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontokensource/interrupt/) telah dipanggil.

**Apa yang terjadi jika saya memanggil [Interrupt()](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontokensource/interrupt/) setelah tugas selesai?**

Tidak ada apa‑apa—pemanggilan tersebut tidak berpengaruh jika tugas yang bersangkutan sudah selesai.

**Bisakah saya menggunakan kembali [InterruptionTokenSource](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontokensource/) yang sama untuk beberapa tugas?**

Ya—tetapi setelah Anda memanggil [Interrupt()](https://reference.aspose.com/slides/id/cpp/aspose.slides/interruptiontokensource/interrupt/) pada sumber tersebut, semua tugas yang menggunakan tokennya akan diinterupsi. Gunakan sumber token terpisah untuk mengelola tugas secara independen.