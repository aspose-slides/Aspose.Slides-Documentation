---
title: Lisensi
type: docs
weight: 80
url: /id/php-java/licensing/
keywords:
- lisensi
- lisensi sementara
- menetapkan lisensi
- gunakan lisensi
- validasi lisensi
- file lisensi
- versi evaluasi
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk PHP via Java. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Pendahuluan**

Kadang-kadang, untuk hasil evaluasi terbaik, pendekatan langsung mungkin diperlukan. Untuk alasan ini, Aspose.Slides menyediakan berbagai rencana pembelian dan juga menawarkan Uji Coba Gratis serta Lisensi Sementara selama 30 hari untuk evaluasi.

{{% alert color="primary" %}}
Perhatikan bahwa ada sejumlah kebijakan dan praktik umum yang memandu Anda tentang cara mengevaluasi, melisensikan dengan tepat, dan membeli produk kami. Anda dapat menemukannya di bagian [Kebijakan Pembelian dan FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluasi Aspose.Slides**
Anda dapat dengan mudah mengunduh Aspose.Slides untuk evaluasi. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi secara otomatis menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

## **Batasan Versi Evaluasi**
Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan semua fungsi produk, tetapi menyisipkan watermark evaluasi di bagian atas dokumen saat dibuka dan disimpan. Anda juga dibatasi hanya satu slide ketika mengekstrak teks dari slide presentasi.

{{% alert color="primary" %}} 
Jika Anda ingin menguji Aspose.Slides tanpa batasan versi evaluasi, Anda dapat meminta **Lisensi Sementara 30 Hari**. Silakan lihat [Cara mendapatkan Lisensi Sementara?](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}} 

## **Tentang Lisensi**
Anda dapat dengan mudah mengunduh versi evaluasi Aspose.Slides untuk PHP via Java dari [halaman unduhan](https://packagist.org/packages/aspose/slides). Versi evaluasi memberikan **kemampuan yang sama persis** dengan versi berlisensi Aspose.Slides. Selanjutnya, versi evaluasi secara otomatis menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode untuk menerapkan lisensi.

Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. File tersebut ditandatangani secara digital, jadi jangan memodifikasi file. Bahkan penambahan baris baru secara tidak sengaja pada isi file akan membuatnya tidak valid.

Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda harus menetapkan lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menetapkan lisensi sekali per aplikasi atau proses.

{{% alert color="primary" %}} 
Anda mungkin ingin melihat [Lisensi Berdasarkan Meter](https://docs.aspose.com/slides/id/php-java/metered-licensing/).
{{% /alert %}} 

## **Lisensi yang Dibeli**

Setelah pembelian, Anda perlu menerapkan file atau aliran lisensi. 

{{% alert color="primary" %}}
Anda harus menetapkan lisensi:
* hanya sekali per domain aplikasi
* sebelum menggunakan kelas Aspose.Slides lainnya
{{% /alert %}}

{{% alert color="primary" %}}
Anda dapat menemukan informasi harga pada halaman [Informasi Harga](https://purchase.aspose.com/pricing/slides/id/family).
{{% /alert %}}

### **Menetapkan Lisensi di Aspose.Slides untuk PHP via Java**

Lisensi dapat diterapkan dari lokasi berikut:

* Jalur eksplisit
* Aliran
* Sebagai Lisensi Berdasarkan Meter – mekanisme lisensi baru

{{% alert color="primary" %}}
Gunakan metode **setLicense** untuk melisensikan sebuah komponen.

Meskipun beberapa pemanggilan **setLicense** tidak berbahaya, hal itu membuang sumber daya (prosesor).
{{% /alert %}}

{{% alert color="warning" %}}
Lisensi baru hanya dapat mengaktifkan Aspose.Slides pada versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

#### **Terapkan Lisensi Menggunakan File**

Potongan kode ini digunakan untuk menetapkan file lisensi:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Saat memanggil metode setLicense, nama lisensi harus sama dengan nama file lisensi Anda. Misalnya, Anda dapat mengubah nama file lisensi menjadi "Aspose.Slides.lic.xml". Kemudian, dalam kode Anda, harus meneruskan nama lisensi baru (Aspose.Slides.lic.xml) ke metode setLicense.

#### **Terapkan Lisensi dari Aliran**

Potongan kode ini digunakan untuk menerapkan lisensi dari aliran:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **FAQ**

**Apakah saya dapat menerapkan lisensi di lingkungan yang sepenuhnya offline (tanpa akses internet)?**

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak memerlukan koneksi internet.

**Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?**

Tidak. Lisensi bersifat seumur hidup: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan dapat menggunakan rilis terbaru tanpa memperbarui langganan.