---
title: Buat Presentasi di PHP
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/php-java/create-presentation/
keywords:
- buat presentasi
- presentasi baru
- buat PPT
- PPT baru
- buat PPTX
- PPTX baru
- buat ODP
- ODP baru
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Buat presentasi dengan Aspose.Slides untuk PHP via Java — hasilkan file PPT, PPTX, dan ODP serta simpan secara programatik untuk hasil yang dapat diandalkan."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan kotak teks ke slide pertama, dan menyimpan hasilnya sebagai file. Artikel ini juga menunjukkan cara membuat dan menyimpan presentasi kosong, serta cara membuka presentasi yang ada dalam format yang didukung dan menyimpannya dalam format lain. FAQ singkat di akhir mencakup pertanyaan umum tentang format, templat, ukuran slide, satuan, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

Sebelum memulai, instal Aspose.Slides untuk PHP via Java dengan Composer dan jalankan PHP/Java Bridge di Apache Tomcat. Lihat [Instalasi](/slides/id/php-java/installation/) untuk pengaturan lengkap. Contoh di bawah mengasumsikan Tomcat berjalan pada `localhost:8080` dan folder `vendor` Composer berada di samping skrip.

## **Membuat Presentasi PowerPoint**

Untuk membuat presentasi dan menaruh kotak teks di slide pertama, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation]. Presentasi baru sudah berisi satu slide kosong.
1. Dapatkan slide tersebut dari koleksi yang dikembalikan oleh [Presentation::getSlides] berdasarkan indeksnya, 0.
1. Tambahkan sebuah persegi panjang dengan metode [ShapeCollection::addAutoShape] dan atur teksnya dengan [TextFrame::setText].
1. Simpan presentasi sebagai file PPTX dengan metode [Presentation::save].

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/id/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dua baris `require_once` memuat klien PHP/Java Bridge dari Tomcat dan kelas Aspose.Slides dari paket Composer. Sudut kiri‑atas persegi panjang berada 50 point dari tepi kiri dan 50 point dari tepi atas slide, dan persegi panjang memiliki lebar 400 point serta tinggi 100 point. File yang disimpan berisi satu slide dengan persegi panjang tersebut dan teksnya. Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi pada setiap slide yang disimpannya; lihat [Lisensi](/slides/id/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides membaca dan menulis file di dalam Tomcat, bukan di proses PHP Anda, sehingga jalur relatif seperti `"hello.pptx"` diselesaikan terhadap folder kerja Tomcat. Contoh pada halaman ini membangun jalur absolut dengan `__DIR__`, sehingga file dibaca dari dan disimpan di samping skrip.
{{% /alert %}}

## **Membuat dan Menyimpan Presentasi**

Untuk membuat presentasi kosong dan menyimpannya, buat sebuah instance dari kelas [Presentation] dan simpan dalam format apa pun dari enumerasi [SaveFormat]. Hasilnya adalah presentasi dengan satu slide kosong.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/id/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Membuka dan Menyimpan Presentasi**

Untuk mengonversi presentasi dari satu format ke format lain, buka dengan memberikan jalurnya ke konstruktor [Presentation], lalu simpan dalam format tujuan. Aspose.Slides mendeteksi format input, seperti PPT, PPTX, atau ODP, dari file itu sendiri.

Contoh di bawah mengasumsikan ada presentasi OpenDocument bernama *Sample.odp* di samping skrip dan menyimpannya sebagai PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/id/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tanya Jawab**

### Format apa yang dapat saya simpan untuk presentasi baru?

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/php-java/save-presentation/), dan mengekspor ke [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/php-java/convert-powerpoint-to-xps/), [HTML](/slides/id/php-java/convert-powerpoint-to-html/), [SVG](/slides/id/php-java/render-a-slide-as-an-svg-image/), serta [gambar](/slides/id/php-java/convert-powerpoint-to-png/), di antara lainnya.

### Bisakah saya memulai dari templat (POTX/POTM) dan menyimpan sebagai PPTX standar?

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan serupa [didukung](/slides/id/php-java/supported-file-formats/).

### Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?

Atur [ukuran slide](/slides/id/php-java/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih cara konten harus diskalakan.

### Dalam satuan apa ukuran dan koordinat diukur?

Dalam point: 1 inci sama dengan 72 unit.

### Bagaimana cara menangani presentasi sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?

Gunakan [strategi manajemen BLOB](/slides/id/php-java/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan lebih pilih alur kerja berbasis file dibandingkan aliran yang hanya berada di memori.

### Bisakah saya membuat/menyimpan presentasi secara paralel?

Anda tidak dapat mengoperasikan instance [Presentation] yang sama dari [multiple threads](/slides/id/php-java/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

### Bagaimana cara menghapus watermark percobaan dan batasan?

[Terapkan lisensi](/slides/id/php-java/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan penyiapan lisensi harus disinkronkan jika ada beberapa thread yang terlibat.

### Bisakah saya menandatangani secara digital PPTX yang saya buat?

Ya. [Tanda tangan digital](/slides/id/php-java/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

### Apakah macro (VBA) didukung dalam presentasi yang dibuat?

Ya. Anda dapat [membuat/mengedit proyek VBA](/slides/id/php-java/presentation-via-vba/) dan menyimpan file yang mendukung macro seperti PPTM/PPSM.