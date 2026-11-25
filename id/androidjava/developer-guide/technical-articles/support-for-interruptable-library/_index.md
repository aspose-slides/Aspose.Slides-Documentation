---
title: Menginterupsi Operasi Presentasi yang Berjalan Lama di Android
linktitle: Interupsi Operasi Presentasi
type: docs
weight: 120
url: /id/androidjava/support-for-interruptable-library/
keywords:
- operasi yang dapat diinterupsi
- token interupsi
- token pembatalan
- tugas yang berjalan lama
- tugas interupsi
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membatalkan operasi presentasi yang berjalan lama di Aspose.Slides untuk Android via Java dan mengembalikan hasil parsial saat mengekspor slide dalam loop."
---
## **Ikhtisar**

Aspose.Slides for Android via Java dapat menghentikan operasi yang berjalan lama seperti memuat, menyimpan, dan merender presentasi. Aplikasi Anda dapat menggunakan token interupsi yang sama untuk menghentikan loop sebelum memproses slide berikutnya.

## **Menginterupsi Operasi Presentasi**

Buat sebuah [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), dapatkan tokennya dengan [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), dan berikan token tersebut ke [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Berikan opsi pemuatan ke [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Untuk meminta pembatalan, panggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) pada sumber. Operasi yang dapat diinterupsi berhenti ketika ia mendeteksi permintaan.

Contoh ini mengonversi `sample.pptx` menjadi `sample.ppt` pada thread latar belakang. Thread pemanggil menunggu hingga 10 detik untuk penyelesaian konversi. Jika konversi masih berjalan, ia meminta pembatalan dan menunggu pekerja selesai.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Panggil dari thread latar belakang dan berikan context.getFilesDir(), yang berisi sample.pptx.
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```
## **Menghubungkan Batas Waktu Java ke Aspose.Slides**

Untuk menetapkan batas waktu pada operasi presentasi, gunakan [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) untuk memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) ketika batas waktu berakhir. Contoh memungkinkan 20 detik untuk memuat `sample.pptx` dan mengekspornya ke `sample.pdf`. Jika ekspor selesai lebih cepat, aplikasi membatalkan permintaan yang dijadwalkan.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Panggil dari thread latar belakang dan berikan context.getFilesDir(), yang berisi sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```
## **Berhenti Sebelum Memproses Slide Berikutnya**

Gunakan [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) yang sama untuk presentasi dan loop yang mengekspor slidennya. Periksa [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) sebelum setiap ekspor. Jika pemanggil dapat menggunakan hasil parsial, kembalikan nomor slide untuk ekspor yang selesai dengan sukses.

Gunakan presentasi bernama `sample.pptx` dengan setidaknya dua slide. Overload [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) yang menerima array nomor slide menghitung dari 1. Contoh menyimpan setiap slide ke PDF terpisah dan meminta pembatalan segera setelah mencatat ekspor pertama yang berhasil.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // Panggil dari thread latar belakang dan berikan context.getFilesDir(), yang berisi sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```
Contoh menulis `slide-1.pdf` dan mencetak `Starting slide 1` diikuti oleh `Completed: [1]`. Loop mendeteksi permintaan sebelum memulai slide 2. Jika pembatalan datang saat penyimpanan, loop keluar sebelum mencatat slide tersebut selesai.

Jika pemanggil perlu menangani pembatalan, ganti pemeriksaan dan `break` di bagian atas loop dengan `token.throwIfInterruptionRequested()`. Hapus `try`/`catch` di sekitar penyimpanan sehingga pembatalan selama ekspor juga sampai ke pemanggil. Dengan input yang sama, contoh hanya mencetak `Starting slide 1` dan menulis `slide-1.pdf`. Pada awal iterasi kedua, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) melempar `com.aspose.slides.exceptions.OperationCanceledException` sebelum ekspor berikutnya dimulai. Metode tidak mengembalikan daftar.

## **Tanya Jawab**

**Kapan saya harus meminta pembatalan?**

Minta pembatalan ketika operasi melebihi batas waktu Anda atau ketika aplikasi Anda tidak lagi membutuhkan hasilnya.

**Apa perbedaan antara [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) dan [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Sumber memungkinkan aplikasi Anda meminta pembatalan. Token memungkinkan Aspose.Slides dan aplikasi Anda memeriksa permintaan tersebut.

**Apakah saya dapat membatalkan operasi dari timer Java?**

Ya. Jadwalkan pemanggilan [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) pada sumber yang terkait dengan presentasi.

**Operasi mana yang dapat saya interupsi?**

Anda dapat menginterupsi pemuatan, penyimpanan, dan perenderan. Berikan token ke [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) melalui [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Presentasi kemudian dapat mendeteksi pembatalan selama operasi selanjutnya seperti menyimpan ke PDF.

**Apakah operasi berhenti segera?**

Pembatalan bersifat kooperatif. Operasi memeriksa token secara berkala dan berhenti ketika mendeteksi permintaan.

**Apa yang terjadi jika saya memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) setelah operasi selesai?**

Operasi yang selesai tetap menyimpan hasilnya.

**Apakah beberapa operasi dapat berbagi [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Ya. Memanggil [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) meminta pembatalan untuk setiap operasi yang menggunakan token dari sumber tersebut. Gunakan sumber terpisah untuk setiap operasi yang ingin Anda batalkan secara independen.