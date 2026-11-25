---
title: Interupsi Operasi Presentasi yang Memakan Waktu Lama di PHP
linktitle: Interupsi Operasi Presentasi
type: docs
weight: 120
url: /id/php-java/support-for-interruptable-library/
keywords:
- token interupsi
- pembatalan
- batas waktu konversi
- ekspor slide
- PowerPoint
- PHP
- Aspose.Slides
description: "Pelajari cara membatalkan konversi presentasi dengan timer dan mengembalikan slide yang diekspor sebelum pembatalan menggunakan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java dapat menghentikan operasi yang berjalan lama seperti memuat, menyimpan, dan merender presentasi. Dalam sebuah loop yang mengekspor satu slide pada satu waktu, token yang sama memungkinkan aplikasi Anda berhenti sebelum slide berikutnya dan mengembalikan daftar ekspor yang selesai.

Kedua contoh PHP mengasumsikan bahwa bootstrap Anda memanggil `define("JAVA_PREFER_VALUES", 1);` sebelum memuat `Java.inc` dari bridge, kemudian memuat `aspose.slides.php`. Pengaturan ini memungkinkan PHP menangkap pengecualian Java selama pemanggilan. Contoh-contoh tersebut memeriksa penyebab pengecualian yang dibungkus sehingga kesalahan konversi lainnya sampai ke pemanggil.

## **Interupsi Operasi Presentasi**

Buat sebuah [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), dapatkan tokennya dengan [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), dan lewatkan ke [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Berikan opsi-opsi ini saat membuat [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Memanggil [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) meminta pembatalan. Operasi yang sedang berjalan berhenti ketika mendeteksi permintaan tersebut.

### **Atur Batas Waktu Konversi**

Sementara PHP menunggu pemuatan atau penyimpanan sinkron melalui PHP/Java Bridge, timer Java dapat meminta pembatalan pada thread terpisah. Simpan helper berikut sebagai `ConversionTimeout.java`, kompilasi dengan JAR Aspose.Slides pada classpath, dan jadikan kelas yang dikompilasi tersedia untuk bridge dengan nama paketnya, `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Dengan bridge dan pembungkus Aspose.Slides PHP yang sudah dimuat, jalankan contoh berikut dengan `sample.pptx` di direktori kerja proses Java, atau gunakan path absolut yang dapat diakses oleh proses tersebut. Batas waktu 20 detik mencakup pemuatan dan ekspor PDF. Jika konversi selesai lebih awal, PHP membatalkan timer. Untuk mengonversi ke format PowerPoint lama dengan batas 10 detik, gunakan `sample.ppt`, `SaveFormat::Ppt`, dan `10000` milidetik.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Berhenti Sebelum Memproses Slide Berikutnya**

Periksa [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) sebelum setiap ekspor. Overload [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) untuk slide terpilih menerima nomor slide mulai dari 1. Lewatkan array satu elemen untuk menulis PDF terpisah untuk setiap slide.

Gunakan `sample.pptx` dengan setidaknya dua slide. Untuk mendemonstrasikan pembatalan di antara ekspor, contoh ini memintanya segera setelah merekam slide pertama.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

Contoh menulis `slide-1.pdf` dan mencetak `Completed: [1]`. Iterasi kedua melihat permintaan sebelum memulai ekspor lain. Jika pembatalan terjadi selama penyimpanan, daftar hanya berisi ekspor yang sudah dikonfirmasi sebelumnya. Penyimpanan yang terganggu dapat meninggalkan file tidak lengkap di disk.

Untuk menyebarkan pembatalan ke pemanggil, ganti pemeriksaan di awal loop dengan `$token->throwIfInterruptionRequested();` dan hapus `try`/`catch` internal, tetap pertahankan penyimpanan dan pemeriksaan yang mengikutinya. Dengan input yang sama, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) menghasilkan pengecualian sebelum slide 2 dan pemanggil tidak menerima daftar apa pun.

## **FAQ**

**Kapan saya harus meminta pembatalan?**

Minta pembatalan ketika batas waktu berakhir atau pemanggil tidak lagi memerlukan hasilnya. Permintaan yang dibuat setelah operasi selesai tidak mengubah hasilnya.

**Bagaimana sumber dan token berbeda?**

Sumber memungkinkan aplikasi meminta pembatalan. Token memungkinkan Aspose.Slides dan kode aplikasi mengamati permintaan tersebut.

**Dapatkah beberapa operasi berbagi sumber yang sama?**

Ya. Permintaan tersebut berlaku untuk semua operasi yang menggunakan token dari sumber itu. Buat sumber terpisah untuk operasi yang memerlukan pembatalan independen.