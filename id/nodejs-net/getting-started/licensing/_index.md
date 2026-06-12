---
title: Lisensi
description: "Aspose.Slides untuk Node.js via .NET menyediakan berbagai rencana pembelian atau menawarkan Free Trial dan Lisensi Sementara 30 hari untuk evaluasi menggunakan kebijakan Lisensi dan Langganan."
type: docs
weight: 80
url: /id/nodejs-net/licensing/
---
Kadang‑kadang, untuk hasil evaluasi yang terbaik, pendekatan langsung mungkin diperlukan. Karena itu, Aspose.Slides menyediakan berbagai rencana pembelian serta menawarkan Free Trial dan 30‑day Temporary License untuk evaluasi.

{{% alert color="primary" %}}
Perhatikan bahwa ada sejumlah kebijakan dan praktik umum yang membimbing Anda tentang cara mengevaluasi, melisensikan dengan tepat, dan membeli produk kami. Anda dapat menemukan mereka di bagian ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluate Aspose.Slides**
Anda dapat dengan mudah mengunduh Aspose.Slides untuk evaluasi. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi akan menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

## **Evaluation Version Limitation**
Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsionalitas penuh produk, namun menambahkan watermark evaluasi di bagian atas dokumen saat dibuka dan disimpan. Anda juga dibatasi satu slide ketika mengekstrak teks dari slide presentasi.

{{% alert color="primary" %}} 
Jika Anda ingin menguji Aspose.Slides tanpa batasan versi evaluasi, Anda dapat meminta **30 Day Temporary License**. Silakan lihat [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}} 

## **About the License**
Anda dapat dengan mudah mengunduh versi evaluasi Aspose.Slides untuk Node.js via .NET dari [halaman unduhan](https://releases.aspose.com/slides/id/nodejs-net/). Versi evaluasi memberikan **kemampuan yang sama persis** dengan versi berlisensi Aspose.Slides. Lebih jauh, versi evaluasi akan menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode untuk menerapkan lisensi.

Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. File ini ditandatangani secara digital, jadi jangan memodifikasi file tersebut. Bahkan penambahan baris kosong secara tidak sengaja pada isi file akan membuatnya tidak valid.

Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda harus mengatur lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu mengatur lisensi satu kali per aplikasi atau proses.

## Purchased License

Setelah pembelian, Anda perlu menerapkan file atau aliran lisensi. 

{{% alert color="primary" %}}
Anda perlu mengatur lisensi:
* hanya sekali per domain aplikasi
* sebelum menggunakan kelas Aspose.Slides lainnya
{{% /alert %}}

{{% alert color="primary" %}}
Anda dapat menemukan informasi harga pada halaman [“Pricing Information”](https://purchase.aspose.com/pricing/slides/id/family).
{{% /alert %}}

### **Setting a License in Aspose.Slides for Node.js via .NET**

Lisensi dapat diterapkan dari lokasi berikut:

* Jalur eksplisit
* Stream
* Sebagai Metered License – mekanisme lisensi baru

{{% alert color="primary" %}}
Gunakan metode **setLicense** untuk melisensikan sebuah komponen.

Meskipun pemanggilan berulang pada **setLicense** tidak merusak, hal ini membuang sumber daya (prosesor).
{{% /alert %}}

{{% alert color="warning" %}}
Lisensi baru dapat mengaktifkan Aspose.Slides hanya pada versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

#### **Applying a License Using a File**

Cuplikan kode ini digunakan untuk mengatur file lisensi:

**Node.js**

```javascript
// Import modul Aspose.Slides untuk manipulasi file PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Fungsi ini menyiapkan pustaka Aspose.Slides dengan lisensi
function setupAsposeSlidesLicense() {
	
    // Inisialisasi kelas License dari modul Aspose.Slides
    var license = new asposeSlides.License();
    
    // Terapkan lisensi dari file
    // Ganti "your_license_file.lic" dengan jalur ke file lisensi Anda yang sebenarnya
    license.setLicense("your_license_file.lic");
}

// Jalankan fungsi untuk menyiapkan lisensi Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
Saat memanggil metode setLicense, nama lisensi harus sama dengan nama file lisensi Anda. Misalnya, Anda dapat mengubah nama file lisensi menjadi "Aspose.Slides.lic.xml". Kemudian, dalam kode Anda, Anda harus memberikan nama lisensi baru (Aspose.Slides.lic.xml) ke metode setLicense.
{{% /alert %}}