---
title: Lisensi
description: "Terapkan file lisensi ke Aspose.Slides untuk Node.js via .NET, lihat apa batasan versi evaluasi, dan dapatkan lisensi sementara gratis selama 30 hari untuk pengujian."
type: docs
weight: 80
url: /id/nodejs-net/licensing/
---
## **Gambaran Umum**

Aspose.Slides untuk Node.js via .NET adalah satu paket npm untuk evaluasi maupun produksi. Tanpa lisensi, paket ini berjalan dalam mode evaluasi. Setelah Anda membeli lisensi, atau mendapatkan lisensi sementara gratis selama 30 hari, Anda menerapkannya dengan beberapa baris kode, dan batasan evaluasi tidak lagi berlaku.

{{% alert color="info" title="Note" %}}

Kebijakan umum tentang cara mengevaluasi, melisensikan, dan membeli produk Aspose dikumpulkan dalam [Kebijakan Pembelian dan FAQ](https://purchase.aspose.com/policies). Harga terdaftar pada [Informasi Harga](https://purchase.aspose.com/pricing/slides/family) halaman.

{{% /alert %}}

## **Batasan Versi Evaluasi**

Versi evaluasi menyediakan semua fungsionalitas produk, dengan dua batasan:

- **Watermark.** Setiap slide dari setiap presentasi yang Anda simpan mendapatkan watermark evaluasi: sebuah kotak teks terkunci di tengah slide yang menampilkan "Evaluation only." Watermark yang sama juga diterapkan pada ekspor PDF, XPS, dan HTML serta pada gambar slide.
- **Truncated text.** Teks yang kode Anda baca kembali dari bingkai teks, paragraf, atau bagian dipotong menjadi lima karakter pertama, diikuti dengan pemberitahuan "... text has been truncated due to evaluation version limitation." Ekspor Markdown dan HTML5 dipotong dengan cara yang sama. Teks yang kode Anda tulis disimpan secara lengkap.

[Evaluasi Aspose.Slides](/slides/id/nodejs-net/evaluate-aspose-slides/) menjelaskan kedua batasan secara detail dan menyertakan skrip yang menampilkannya.

{{% alert color="success" title="Tip" %}}

Untuk menguji Aspose.Slides tanpa batasan evaluasi, minta lisensi sementara gratis **30-day temporary license**. Lihat [Cara Mendapatkan Lisensi Sementara?](https://purchase.aspose.com/temporary-license) untuk detail.

{{% /alert %}}

## **Tentang Lisensi**

Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, dan tanggal kedaluwarsa berlangganan. File ini ditandatangani secara digital, jadi jangan mengubahnya: bahkan satu baris kosong tambahan yang ditambahkan secara tidak sengaja akan membuatnya tidak valid.

## **Menerapkan Lisensi**

Terapkan lisensi dengan metode `setLicense` pada kelas `License`. Panggil sekali per proses, sebelum Anda membuat objek `Presentation` apa pun. Memanggilnya lagi tidak menyebabkan masalah, tetapi akan mengulangi pekerjaan yang sudah dilakukan.

Skrip berikut menerapkan lisensi dari file bernama `Aspose.Slides.lic`. Ganti nama tersebut dengan nama atau jalur lengkap file lisensi Anda; file dapat memiliki nama apa saja.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Nama file atau jalur relatif akan diselesaikan berdasarkan folder saat ini, yaitu folder tempat Anda menjalankan `node`. Simpan file lisensi di folder proyek Anda dan jalankan skrip dari sana, atau berikan jalur lengkap.

Jika file tidak dapat ditemukan, atau bukan lisensi yang sah, `setLicense` akan melemparkan error, dan Aspose.Slides tetap berada dalam mode evaluasi. Skrip menangkapi error tersebut dan mencetak pesannya. Untuk file yang hilang, pesan dimulai dengan `License "Aspose.Slides.lic" doesn't exist or access is restricted.` dan mencantumkan setiap lokasi yang dicari.

Dalam paket ini, lisensi hanya diterapkan dari file. `License` tidak menerima stream, dan paket tidak mengekspos lisensi berbasis meteran. Untuk kelas yang dibungkus paket ini, lihat [Lisensi](https://reference.aspose.com/slides/net/aspose.slides/license/) dalam referensi API Aspose.Slides untuk .NET.