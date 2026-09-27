---
title: Lisensi
type: docs
weight: 80
url: /id/php-java/licensing/
keywords:
- lisensi
- lisensi sementara
- atur lisensi
- gunakan lisensi
- validasi lisensi
- file lisensi
- versi evaluasi
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Menerapkan, mengelola, dan memecahkan masalah lisensi di Aspose.Slides untuk PHP via Java. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Pendahuluan**

Kadang-kadang, untuk hasil evaluasi terbaik, pendekatan langsung mungkin diperlukan. Untuk alasan ini, Aspose.Slides menyediakan berbagai paket pembelian dan juga menawarkan Uji Coba Gratis serta Lisensi Sementara 30 hari untuk evaluasi.

{{% alert color="info" title="Note" %}}
Perlu dicatat bahwa ada sejumlah kebijakan dan praktik umum yang membimbing Anda tentang cara mengevaluasi, melisensikan dengan benar, dan membeli produk kami. Anda dapat menemukan mereka di bagian ["Kebijakan Pembelian dan FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluasi Aspose.Slides**
Anda dapat dengan mudah mengunduh Aspose.Slides untuk evaluasi. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi akan menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi. 

## **Batasan Versi Evaluasi**
Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsi penuh produk, dengan dua batasan:

* Menambahkan kotak teks watermark evaluasi di tengah setiap slide dari setiap presentasi yang disimpannya.
* Teks yang dibaca kode Anda dari presentasi dipotong sampai beberapa karakter pertama, diikuti dengan pemberitahuan tentang batasan evaluasi. Teks yang ditulis kode Anda disimpan secara lengkap.

{{% alert color="info" title="Note" %}}
Jika Anda ingin menguji Aspose.Slides tanpa batasan versi evaluasi, Anda dapat meminta **Lisensi Sementara 30 Hari**. Silakan lihat [Cara mendapatkan Lisensi Sementara?](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}} 

## **Tentang Lisensi**
Anda dapat dengan mudah mengunduh versi evaluasi Aspose.Slides untuk PHP via Java dari [halaman unduhan](https://packagist.org/packages/aspose/slides). Versi evaluasi memberikan **kemampuan yang sama persis** dengan versi berlisensi Aspose.Slides. Lebih lanjut, versi evaluasi akan menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode untuk menerapkan lisensi.

Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang memiliki lisensi, tanggal kedaluwarsa langganan, dan sebagainya. File ini ditandatangani secara digital, jadi jangan memodifikasi file tersebut. Bahkan penambahan baris kosong secara tidak sengaja pada isi file akan membuatnya tidak valid.

Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menyetel lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menyetel lisensi satu kali per aplikasi atau proses.

{{% alert color="info" title="Note" %}}
Anda mungkin ingin melihat [Metered Licensing](/slides/id/php-java/metered-licensing/).
{{% /alert %}} 

## **Lisensi yang Dibeli**

Setelah pembelian, Anda perlu menerapkan file atau stream lisensi. 

{{% alert color="info" title="Note" %}}
Anda perlu menyetel lisensi:
* hanya sekali per domain aplikasi
* sebelum menggunakan kelas Aspose.Slides lainnya
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Anda dapat menemukan informasi harga pada halaman [“Informasi Harga”](https://purchase.aspose.com/pricing/slides/id/family).
{{% /alert %}}

### **Menyetel Lisensi di Aspose.Slides untuk PHP via Java**

Lisensi dapat diterapkan dari lokasi berikut:

* Jalur eksplisit
* Stream
* Sebagai Metered License – mekanisme lisensi baru

{{% alert color="info" title="Note" %}}
Gunakan metode **setLicense** untuk melisensikan sebuah komponen.

Meskipun memanggil **setLicense** berkali‑kali tidak berbahaya, hal itu membuang sumber daya (prosesor).
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Lisensi baru hanya dapat mengaktifkan Aspose.Slides dengan versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

#### **Menerapkan Lisensi Menggunakan File**

Potongan kode ini digunakan untuk menyetel file lisensi:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/id/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

Contoh ini mengharapkan file lisensi berada di samping skrip dan menggunakan jalur absolutnya: Aspose.Slides berjalan di dalam Tomcat, sehingga tidak memecahkan jalur relatif terhadap folder skrip Anda. Saat memanggil metode setLicense, nama lisensi harus sama dengan nama file lisensi Anda. Misalnya, Anda dapat mengubah nama file lisensi menjadi "Aspose.Slides.lic.xml". Kemudian, dalam kode Anda, Anda harus melewatkan nama lisensi baru (Aspose.Slides.lic.xml) ke metode setLicense.

#### **Menerapkan Lisensi dari Stream**

Potongan kode ini digunakan untuk menerapkan lisensi dari stream:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/id/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### Bisakah saya menerapkan lisensi di lingkungan offline sepenuhnya (tanpa akses internet)?
Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

### Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?
Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan dapat menggunakan rilis yang lebih baru tanpa memperbarui.