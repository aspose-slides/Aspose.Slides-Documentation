---
title: Dukungan untuk Perpustakaan yang Dapat Dihentikan
type: docs
weight: 120
url: /id/java/support-for-interruptable-library/
keywords:
- perpustakaan yang dapat dihentikan
- token interupsi
- token pembatalan
- tugas yang berjalan lama
- tugas interupsi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Buat tugas yang berjalan lama dapat dibatalkan dengan Aspose.Slides untuk Java. Hentikan rendering dan konversi untuk PowerPoint dan OpenDocument secara aman, dengan contoh."
---
## **Gambaran Umum**

Aspose.Slides menyediakan mekanisme pemrosesan yang dapat dihentikan untuk tugas presentasi yang memakan waktu lama, seperti deserialisasi, serialisasi, dan rendering. Mekanisme ini didasarkan pada kelas `InterruptionToken` dan `InterruptionTokenSource`.

Sebuah `InterruptionToken` dapat diberikan kepada `LoadOptions` dan diteruskan ke konstruktor `Presentation`. Ketika `InterruptionTokenSource.interrupt()` dipanggil, tugas yang memakan waktu lama yang terkait akan dihentikan.

## **Perpustakaan yang Dapat Dihentikan**

Pada [Aspose.Slides 18.4](https://releases.aspose.com/slides/id/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), kami memperkenalkan kelas [InterruptionToken](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontokensource/). Kelas-kelas ini memungkinkan Anda menghentikan tugas yang memakan waktu lama seperti deserialisasi, serialisasi, dan rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontokensource/) adalah sumber token yang diteruskan ke [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/id/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Ketika [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/id/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) diatur dan instance [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/) diteruskan ke konstruktor [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/), memanggil [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontokensource/#interrupt--) menghentikan setiap tugas yang memakan waktu lama yang terkait dengan [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) tersebut.

Potongan kode berikut menunjukkan cara menghentikan tugas yang sedang berjalan:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // jalankan aksi di thread terpisah
Thread.sleep(10000);     // batas waktu
tokenSource.interrupt(); // hentikan konversi
```

## **FAQ**

**Apa tujuan dari perpustakaan interrupt Aspose.Slides?**

Ini menyediakan mekanisme untuk menghentikan operasi yang memakan waktu lama—seperti memuat, menyimpan, atau merender presentasi—sebelum selesai. Hal ini berguna ketika waktu pemrosesan harus dibatasi atau tugas tidak lagi diperlukan.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` diteruskan ke API Aspose.Slides dan diperiksa selama operasi yang memakan waktu lama.
- `InterruptionTokenSource` digunakan dalam kode Anda untuk membuat token dan memicu penghentian dengan memanggil `Interrupt()`.

**Tugas apa yang dapat dihentikan?**

Setiap tugas Aspose.Slides yang menerima [InterruptionToken](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontoken/)—seperti memuat presentasi dengan `Presentation(path, loadOptions)` atau menyimpan dengan `Presentation.save(...)`—dapat dihentikan.

**Apakah penghentian terjadi secara langsung?**

Tidak. Penghentian bersifat kooperatif: operasi secara berkala memeriksa token dan berhenti segera setelah mendeteksi bahwa [Interrupt()](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontokensource/#interrupt--) telah dipanggil.

**Apa yang terjadi jika saya memanggil [Interrupt()](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontokensource/#interrupt--) setelah tugas sudah selesai?**

Tidak ada—pemanggilan tersebut tidak berpengaruh jika tugas yang bersangkutan sudah selesai.

**Apakah saya dapat menggunakan kembali [InterruptionTokenSource](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontokensource/) yang sama untuk beberapa tugas?**

Ya—tetapi setelah Anda memanggil [Interrupt()](https://reference.aspose.com/slides/id/java/com.aspose.slides/interruptiontokensource/#interrupt--) pada sumber tersebut, semua tugas yang menggunakan tokennya akan dihentikan. Gunakan sumber token terpisah untuk mengelola tugas secara independen.