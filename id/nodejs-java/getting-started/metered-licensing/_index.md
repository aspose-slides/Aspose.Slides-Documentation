---
title: Lisensi Metered
type: docs
weight: 100
url: /id/nodejs-java/metered-licensing/
keywords:
- lisensi
- lisensi metered
- kunci lisensi
- kunci publik
- kunci privat
- kuantitas konsumsi
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides untuk Node.js via Java dengan lisensi metered memungkinkan Anda memproses file PowerPoint dan OpenDocument secara fleksibel, hanya membayar apa yang Anda gunakan."
---
## **Pendahuluan**

Licensing berbasis meter adalah mekanisme lisensi yang dapat digunakan bersama metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, Anda memilih licensing berbasis meter.

## **Terapkan Kunci Metered**

Saat Anda membeli lisensi berbasis meter, Anda mendapatkan kunci (bukan file lisensi). Kunci metered ini dapat diterapkan menggunakan kelas [Metered](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/metered/) yang disediakan Aspose untuk operasi metering. Untuk detail lebih lanjut, lihat [FAQ Lisensi Metered](https://purchase.aspose.com/faqs/licensing/metered).

1. Buat instance dari kelas [Metered](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/metered/).

2. Berikan kunci publik dan privat Anda ke metode [setMeteredKey](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/metered/#setMeteredKey).

3. Lakukan beberapa pemrosesan (menjalankan tugas).

4. Panggil metode [getConsumptionQuantity](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) dari kelas `Metered`.

Anda harus melihat jumlah/kuantitas permintaan API yang telah Anda konsumsi sejauh ini.

Kode contoh ini menunjukkan cara menggunakan licensing berbasis meter:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat instance dari kelas Metered
var metered = new aspose.slides.Metered();

// Menyampaikan kunci publik dan privat ke objek Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Mendapatkan nilai kuantitas konsumsi sebelum pemanggilan API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Lakukan sesuatu dengan API Aspose.Slides di sini
// ...

// Mendapatkan nilai kuantitas konsumsi setelah pemanggilan API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
Untuk menggunakan licensing berbasis meter, Anda memerlukan koneksi internet yang stabil karena mekanisme lisensi menggunakan internet untuk terus berinteraksi dengan layanan kami dan melakukan perhitungan.
{{% /alert %}} 

## **FAQ**

**Apakah saya dapat menggunakan lisensi berbasis meter bersama dengan lisensi reguler (perpetual atau sementara) dalam aplikasi yang sama?**

Ya. Metered adalah mekanisme lisensi tambahan yang dapat digunakan bersamaan dengan [metode lisensi](/slides/id/nodejs-java/licensing/). Anda memilih mekanisme mana yang akan diterapkan saat aplikasi dimulai.

**Apa yang sebenarnya dihitung sebagai konsumsi pada lisensi berbasis meter: operasi atau file?**

Penggunaan API yang dihitung, yaitu jumlah permintaan atau operasi. Anda dapat memperoleh konsumsi saat ini melalui [metode pelacakan konsumsi](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/metered/).

**Apakah metered cocok untuk lingkungan microservices dan serverless di mana instance sering direstart?**

Ya. Karena perhitungan dilakukan pada level panggilan API, skenario dengan cold start yang sering kompatibel, asalkan ada akses jaringan yang stabil untuk perhitungan metered.

**Apakah fungsionalitas library berbeda saat menggunakan lisensi berbasis meter dibandingkan dengan lisensi perpetual?**

Tidak. Ini hanya mengenai mekanisme lisensi dan penagihan; kemampuan produk tetap sama.

**Bagaimana metered terkait dengan versi percobaan dan lisensi sementara?**

Versi percobaan memiliki batasan dan watermark, [lisensi sementara](https://purchase.aspose.com/temporary-license/) menghapus batasan selama 30 hari, dan metered menghapus batasan serta mengenakan biaya berdasarkan penggunaan aktual.

**Bisakah saya mengontrol anggaran dengan secara otomatis bereaksi saat ambang konsumsi terlampaui?**

Ya. Praktik umum adalah membaca konsumsi saat ini secara berkala melalui [metode pelacakan](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/metered/) dan menerapkan batasan atau peringatan Anda sendiri pada tingkat aplikasi atau pemantauan.