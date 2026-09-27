---
title: Lisensi
type: docs
weight: 80
url: /id/nodejs-java/licensing/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk Node.js. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Pendahuluan**

Kadang-kadang, untuk hasil evaluasi terbaik, pendekatan langsung mungkin diperlukan. Karena itu, Aspose.Slides menyediakan berbagai rencana pembelian dan juga menawarkan Uji Coba Gratis serta Lisensi Sementara 30 hari untuk evaluasi.

{{% alert color="info" title="Note" %}}
Perhatikan bahwa ada sejumlah kebijakan dan praktik umum yang memandu Anda tentang cara mengevaluasi, melisensikan dengan tepat, dan membeli produk kami. Anda dapat menemukannya di bagian [Kebijakan Pembelian dan FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluasi Aspose.Slides**
Anda dapat dengan mudah mengunduh Aspose.Slides untuk evaluasi. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi cukup menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

## **Batasan Versi Evaluasi**
Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsionalitas produk penuh, dengan dua batasan:

* Ini menambahkan kotak teks watermark evaluasi ke setiap slide dari setiap presentasi yang disimpannya.
* Teks yang lebih panjang dari lima karakter yang dibaca kode Anda dari sebuah presentasi dipotong menjadi lima karakter pertama, diikuti oleh `... text has been truncated due to evaluation version limitation.` Teks dengan lima karakter atau kurang dikembalikan tanpa perubahan, dan teks yang ditulis kode Anda disimpan secara lengkap.

{{% alert color="info" title="Note" %}}
Jika Anda ingin menguji Aspose.Slides tanpa batasan versi evaluasi, Anda dapat meminta **Lisensi Sementara 30 Hari**. Silakan merujuk ke [Cara Mendapatkan Lisensi Sementara?](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}}

## **Tentang Lisensi**
Anda dapat dengan mudah mengunduh versi evaluasi Aspose.Slides untuk Node.js via Java dari [halaman unduhan](https://releases.aspose.com/slides/id/nodejs-java/). Versi evaluasi memiliki fitur yang sama dengan versi berlisensi, dengan batasan yang dijelaskan di atas. Lebih lanjut, versi evaluasi cukup menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode untuk menerapkan lisensi.

Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. File ini ditandatangani secara digital, jadi jangan memodifikasi file. Bahkan penambahan baris baru yang tidak disengaja ke isi file akan membuatnya tidak valid.

Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menetapkan lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menetapkan lisensi satu kali per aplikasi atau proses.

{{% alert color="info" title="Note" %}}
Anda mungkin ingin melihat [Metered Licensing](/slides/id/nodejs-java/metered-licensing/).
{{% /alert %}}

## **Lisensi yang Dibeli**
Setelah pembelian, Anda perlu menerapkan file lisensi atau aliran.

{{% alert color="info" title="Note" %}}
Anda perlu menetapkan lisensi:
* hanya satu kali per proses
* sebelum menggunakan kelas Aspose.Slides lainnya
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Anda dapat menemukan informasi harga di halaman [“Pricing Information”](https://purchase.aspose.com/pricing/slides/id/family).
{{% /alert %}}

### **Menetapkan Lisensi di Aspose.Slides untuk Node.js via Java**
Lisensi dapat diterapkan dari lokasi berikut:

* Jalur eksplisit
* Aliran
* Sebagai Lisensi Metered – mekanisme lisensi baru

{{% alert color="info" title="Note" %}}
Gunakan metode **setLicense** untuk melisensikan sebuah komponen.

Meskipun panggilan berulang ke **setLicense** tidak berbahaya, mereka membuang sumber daya (prosesor).
{{% /alert %}}

#### **Menerapkan Lisensi Menggunakan File**
Potongan kode ini digunakan untuk menetapkan file lisensi:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides berjalan di mesin virtual Java yang membuat Node.js tetap berjalan, sehingga akhiri proses secara eksplisit.
process.exit(0);
```

Saat memanggil metode setLicense, nama lisensi harus sama dengan nama file lisensi Anda. Misalnya, Anda dapat mengubah nama file lisensi menjadi "Aspose.Slides.lic.xml". Kemudian, dalam kode Anda, Anda harus memberikan nama lisensi baru (Aspose.Slides.lic.xml) ke metode setLicense. Jika file tidak ada atau tidak berisi lisensi yang valid, [setLicense](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/license/setlicense/) melemparkan pengecualian, yang mengakhiri skrip dengan error.

#### **Menerapkan Lisensi dari Aliran**
Untuk menerapkan lisensi dari aliran, berikan objek [License](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/license/) dan aliran dapat dibaca ke metode statis [setLicenseFromStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/license/setlicense/). Aliran dibaca secara asinkron, dan callback menerima error jika aliran tidak berisi lisensi yang valid:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides berjalan di mesin virtual Java yang membuat Node.js tetap berjalan, sehingga akhiri proses secara eksplisit.
    process.exit(0);
});
```

Lisensi diterapkan ketika seluruh aliran telah dibaca, tepat sebelum callback dijalankan, sehingga mulailah pekerjaan Aspose.Slides lain dari callback.

Kedua contoh memanggil `process.exit(0)` ketika selesai, karena mesin virtual Java yang menjalankan Aspose.Slides membuat Node.js tetap berjalan. Dalam sebuah aplikasi, lanjutkan dengan kode Aspose.Slides Anda alih-alih mengakhiri proses.

## **FAQ**

### **Bisakah saya menerapkan lisensi di lingkungan yang sepenuhnya offline (tanpa akses internet)?**
Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

### **Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?**
Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal akhir langganan Anda; Anda hanya tidak akan dapat menggunakan rilis terbaru tanpa memperbarui.