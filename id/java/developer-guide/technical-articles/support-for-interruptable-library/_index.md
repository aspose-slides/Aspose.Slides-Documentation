---
title: Interupsi Operasi Presentasi yang Memakan Waktu Lama di Java
linktitle: Interupsi Operasi Presentasi
type: docs
weight: 120
url: /id/java/support-for-interruptable-library/
keywords:
- operasi yang dapat diinterupsi
- token interupsi
- token pembatalan
- tugas yang memakan waktu lama
- interupsi tugas
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara membatalkan operasi presentasi yang memakan waktu lama di Aspose.Slides untuk Java dan mengembalikan hasil parsial saat mengekspor slide dalam loop."
---
## **Ikhtisar**

Aspose.Slides for Java dapat menghentikan operasi yang memakan waktu lama seperti memuat, menyimpan, dan merender presentasi. Aplikasi Anda dapat menggunakan token interupsi yang sama untuk menghentikan loop sebelum memproses slide berikutnya.

## **Interrupt a Presentation Operation**

Buat sebuah [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), dapatkan tokennya dengan [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), dan berikan token tersebut ke [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Berikan load options ke [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Untuk meminta pembatalan, panggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) pada sumber. Operasi yang dapat diinterupsi berhenti saat mendeteksi permintaan.

Contoh ini mengonversi `sample.pptx` menjadi `sample.ppt` pada thread latar belakang. Thread pemanggil menunggu hingga 10 detik untuk menyelesaikan konversi. Jika konversi masih berjalan, ia meminta pembatalan dan menunggu pekerja selesai.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Connect a Java Timeout to Aspose.Slides**

Untuk menetapkan batas waktu pada operasi presentasi, gunakan [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) untuk memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) ketika timeout berakhir. Contoh ini memberikan 20 detik untuk memuat `sample.pptx` dan mengekspornya ke `sample.pdf`. Jika ekspor selesai lebih cepat, aplikasi membatalkan permintaan yang dijadwalkan.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Stop Before Processing the Next Slide**

Gunakan [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) yang sama untuk presentasi dan loop yang mengekspor slide‑slide‑nya. Periksa [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) sebelum setiap ekspor. Jika pemanggil dapat menggunakan hasil parsial, kembalikan nomor slide untuk ekspor yang berhasil diselesaikan.

Gunakan sebuah presentasi bernama `sample.pptx` dengan setidaknya dua slide. Overload [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) yang menerima array nomor slide menghitung dari 1. Contoh ini menyimpan setiap slide ke PDF terpisah dan meminta pembatalan segera setelah mencatat ekspor pertama yang berhasil.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

Contoh ini menulis `slide-1.pdf` dan mencetak `Starting slide 1` diikuti oleh `Completed: [1]`. Loop mendeteksi permintaan sebelum memulai slide 2. Jika pembatalan tiba selama penyimpanan, loop keluar sebelum mencatat slide tersebut selesai.

Jika pemanggil perlu menangani pembatalan, gantikan pemeriksaan dan `break`‑nya di bagian atas loop dengan `token.throwIfInterruptionRequested()`. Hapus `try`/`catch` di sekitar penyimpanan sehingga pembatalan selama ekspor juga sampai ke pemanggil. Dengan input yang sama, contoh hanya mencetak `Starting slide 1` dan menulis `slide-1.pdf`. Pada awal iterasi kedua, [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) melempar `com.aspose.slides.exceptions.OperationCanceledException` sebelum ekspor berikutnya dimulai. Metode tersebut tidak mengembalikan daftar apa pun.

## **FAQ**

**Kapan saya harus meminta pembatalan?**

Minta pembatalan ketika suatu operasi melebihi batas waktu Anda atau ketika aplikasi Anda tidak lagi memerlukan hasilnya.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Sumber memungkinkan aplikasi Anda meminta pembatalan. Token memungkinkan Aspose.Slides dan aplikasi Anda memeriksa permintaan tersebut.

**Bisakah saya membatalkan operasi dari timer Java?**

Ya. Jadwalkan pemanggilan [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) pada sumber yang terkait dengan presentasi.

**Operasi apa yang dapat saya interupsi?**

Anda dapat menginterupsi pemuatan, penyimpanan, dan rendering. Berikan token ke [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) melalui [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Presentasi kemudian dapat mendeteksi pembatalan selama operasi selanjutnya seperti menyimpan ke PDF.

**Apakah operasi berhenti segera?**

Pembatalan bersifat kooperatif. Sebuah operasi memeriksa token secara berkala dan berhenti saat mendeteksi permintaan.

**Apa yang terjadi jika saya memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) setelah operasi selesai?**

Operasi yang selesai tetap mempertahankan hasilnya.

**Apakah beberapa operasi dapat berbagi [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Ya. Memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) meminta pembatalan untuk setiap operasi yang menggunakan token dari sumber tersebut. Gunakan sumber terpisah untuk setiap operasi yang ingin Anda batalkan secara independen.