---
title: Mengonversi PowerPoint ke PDF di Node.js via .NET
linktitle: PowerPoint ke PDF
type: docs
weight: 30
url: /id/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint ke PDF
- mengonversi PowerPoint ke PDF
- PPTX ke PDF
- PPT ke PDF
- ODP ke PDF
- menyimpan presentasi sebagai PDF
- PDF/A
- PdfOptions
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengonversi presentasi PPTX, PPT, dan ODP ke PDF dalam JavaScript dengan Aspose.Slides untuk Node.js via .NET, serta menghasilkan berkas PDF/A arsip dengan PdfOptions."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via .NET mengonversi presentasi PowerPoint dan OpenDocument ke PDF tanpa Microsoft PowerPoint. Setiap slide yang terlihat menjadi satu halaman PDF dengan ukuran yang sama dengan slide, dan teks tetap dapat dipilih serta dapat dicari. Artikel ini menunjukkan konversi default dan konversi ke PDF/A dengan [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

Contoh‑contoh mengharapkan sebuah presentasi bernama `sample.pptx` di folder proyek yang Anda siapkan di [Installation](/slides/id/nodejs-net/installation/). Presentasi PowerPoint apa saja dapat digunakan. Simpan tiap contoh sebagai file `.js` di folder proyek dan jalankan dari folder tersebut dengan `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET tidak memiliki referensi API tersendiri. Ia mencerminkan API Aspose.Slides for .NET dengan nama camelCase, sehingga tautan API dalam artikel ini mengarah ke kelas dan anggota yang cocok di [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Mengonversi Presentasi ke PDF**

Untuk mengonversi presentasi ke PDF, ikuti langkah‑langkah berikut:

1. Buka presentasi dengan memberikan jalurnya ke konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Kode yang sama berfungsi untuk file PPTX, PPT, dan ODP.  
2. Panggil metode [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) dengan jalur output dan `SaveFormat.Pdf`.  
3. Panggil `dispose` dalam blok `finally` untuk melepaskan sumber daya .NET yang mendasari presentasi.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Skrip menulis `sample.pdf` ke folder proyek. Konversi menggunakan pengaturan default: setiap slide yang tidak disembunyikan menjadi satu halaman, mengikuti urutan slide. Tanpa lisensi, setiap halaman juga menampilkan watermark evaluasi; lihat [Licensing](/slides/id/nodejs-net/licensing/).

## **Mengonversi Presentasi ke PDF/A**

Untuk mengendalikan output, berikan objek [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sebagai argumen ketiga `save`. Contoh berikut mengatur properti [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) menjadi `PdfCompliance.PdfA2b`, yang menghasilkan berkas PDF/A-2b. PDF/A adalah standar ISO untuk pengarsipan jangka panjang: di antara aturan lainnya, standar ini mewajibkan setiap font yang digunakan dokumen disematkan dalam berkas.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Skrip menulis `sample-pdfa.pdf` dengan halaman yang sama seperti konversi default. Untuk memastikan sebuah berkas memenuhi standar, periksa dengan validator PDF/A seperti [veraPDF](https://verapdf.org/). Nilai [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) lainnya memilih standar lain, seperti `PdfA1b`, `PdfA2a`, atau `PdfUa` untuk aksesibilitas.

## **FAQ**

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Slide tersembunyi dilewati secara default. Atur properti [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) dari `PdfOptions` menjadi `true` dan berikan opsi tersebut ke `save`.

**Apakah saya dapat melindungi PDF dengan kata sandi?**

Ya. Atur properti [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) dari `PdfOptions` sebelum memanggil `save`. Pembaca PDF kemudian akan meminta kata sandi tersebut sebelum membuka berkas.

**Apakah saya dapat mengonversi hanya sebagian slide?**

Ya. Berikan array posisi slide sebagai argumen keempat `save`. Posisi dimulai dari 1, dan argumen ketiga dapat `null` jika tidak memerlukan opsi: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` menulis PDF dengan slide pertama dan ketiga.

**Mengapa teks terlihat berbeda saat saya mengonversi di Linux?**

Aspose.Slides hanya dapat menggunakan font yang terpasang pada mesin yang menjalankan konversi. Ketika sebuah presentasi menggunakan font yang tidak ada, seperti Calibri pada server Linux tipikal, Aspose.Slides akan menggunakan font yang terpasang sebagai pengganti, yang dapat mengubah tampilan teks dan pemenggalan baris. Pasang font yang digunakan presentasi Anda untuk memperoleh hasil yang sama seperti di Windows.

**Apakah saya dapat memperoleh PDF sebagai Buffer alih-alih berkas?**

Ya. `presentation.saveToBuffer(SaveFormat.Pdf)` mengembalikan PDF sebagai `Buffer` Node.js, yang praktis ketika Anda mengirim hasilnya dalam respons HTTP. Metode ini juga menerima `PdfOptions` sebagai argumen keduanya.