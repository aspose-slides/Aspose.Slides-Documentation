---
title: Lisensi
type: docs
weight: 80
url: /id/nodejs-java/licensing/
keywords:
- lisensi
- lisensi sementara
- mengatur lisensi
- menggunakan lisensi
- memvalidasi lisensi
- file lisensi
- versi evaluasi
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk Node.js. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Introduction**

Kadangkala, untuk hasil evaluasi terbaik, pendekatan langsung mungkin diperlukan. Untuk alasan ini, Aspose.Slides menyediakan berbagai paket pembelian serta menawarkan Uji Coba Gratis dan Lisensi Sementara 30 hari untuk evaluasi.

{{% alert color="primary" %}}
Perhatikan bahwa ada sejumlah kebijakan dan praktik umum yang memandu Anda cara mengevaluasi, melisensikan dengan tepat, dan membeli produk kami. Anda dapat menemukan mereka di ["Kebijakan Pembelian dan FAQ"](https://purchase.aspose.com/policies) bagian.
{{% /alert %}}

## **Evaluasi Aspose.Slides**
Anda dapat dengan mudah mengunduh Aspose.Slides untuk evaluasi. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi akan menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi. 

## **Batasan Versi Evaluasi**
Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan semua fungsionalitas produk, tetapi menambahkan watermark evaluasi di bagian atas dokumen saat dibuka dan disimpan. Anda juga dibatasi hanya satu slide saat mengekstrak teks dari slide presentasi.

{{% alert color="primary" %}} 
Jika Anda ingin menguji Aspose.Slides tanpa batasan versi evaluasi, Anda dapat meminta **Lisensi Sementara 30 Hari**. Silakan lihat [Cara mendapatkan Lisensi Sementara?](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}} 

## **Tentang Lisensi**
Anda dapat dengan mudah mengunduh versi evaluasi Aspose.Slides untuk Node.js via Java dari [halaman unduh](https://releases.aspose.com/slides/id/nodejs-java/). Versi evaluasi memberikan **kemampuan yang sama persis** dengan versi berlisensi Aspose.Slides. Lebih lanjut, versi evaluasi akan menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode untuk menerapkan lisensi.

Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. File ini ditandatangani secara digital, jadi jangan mengubah file. Bahkan penambahan baris baru yang tidak sengaja ke isi file akan membuatnya tidak valid.

Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menyetel lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menyetel lisensi satu kali per aplikasi atau proses.

{{% alert color="primary" %}} 
Anda mungkin ingin melihat [Metered Licensing](https://docs.aspose.com/slides/id/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Lisensi yang Dibeli**

Setelah pembelian, Anda perlu menerapkan file atau aliran lisensi. 

{{% alert color="primary" %}}
Anda perlu menyetel lisensi:
* hanya sekali per domain aplikasi
* sebelum menggunakan kelas Aspose.Slides lainnya
{{% /alert %}}

{{% alert color="primary" %}}
Anda dapat menemukan informasi harga di [“Informasi Harga”](https://purchase.aspose.com/pricing/slides/id/family) halaman.
{{% /alert %}}

### **Menyetel Lisensi di Aspose.Slides untuk Node.js via Java**

Lisensi dapat diterapkan dari lokasi berikut:

* Jalur eksplisit
* Aliran
* Sebagai Metered License – mekanisme lisensi baru

{{% alert color="primary" %}}
Gunakan metode **setLicense** untuk melisensi sebuah komponen.

Meskipun beberapa pemanggilan **setLicense** tidak merusak, itu membuang sumber daya (processor).
{{% /alert %}}

{{% alert color="warning" %}}
Lisensi baru hanya dapat mengaktifkan Aspose.Slides pada versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

#### **Menerapkan Lisensi Menggunakan File**

Potongan kode ini digunakan untuk menyetel file lisensi:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Saat memanggil metode setLicense, nama lisensi harus sama dengan nama file lisensi Anda. Misalnya, Anda dapat mengubah nama file lisensi menjadi "Aspose.Slides.lic.xml". Kemudian, dalam kode Anda, Anda harus memberikan nama lisensi baru (Aspose.Slides.lic.xml) ke metode setLicense.

#### **Menerapkan Lisensi dari Aliran**

Potongan kode ini digunakan untuk menerapkan lisensi dari aliran:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **FAQ**

**Apakah saya dapat menerapkan lisensi dalam lingkungan offline sepenuhnya (tanpa akses internet)?**

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak memerlukan koneksi internet.

**Apa yang terjadi setelah langganan satu tahun berakhir? Apakah pustaka akan berhenti berfungsi?**

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan dapat menggunakan rilis yang lebih baru tanpa memperbarui.