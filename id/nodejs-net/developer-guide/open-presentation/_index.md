---
title: Membuka Presentasi di Node.js via .NET
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/nodejs-net/open-presentation/
keywords:
- membuka presentasi
- membuka PowerPoint
- membuka PPTX
- membuka PPT
- membuka ODP
- memuat presentasi
- presentasi dari buffer
- jumlah slide
- mengonversi presentasi
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buka presentasi PPTX, PPT, dan ODP dalam JavaScript dengan Aspose.Slides untuk Node.js via .NET: muat dari jalur file atau Buffer, baca jumlah slide, dan simpan dalam format lain."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via .NET membuka presentasi PowerPoint dan OpenDocument, seperti file PPTX, PPT, dan ODP, dari jalur file atau dari `Buffer` Node.js. Artikel ini menunjukkan kedua cara, membaca jumlah slide, dan menyimpan presentasi yang dibuka dalam format lain.

Contoh-contoh mengharapkan sebuah presentasi bernama `sample.pptx` di folder proyek yang Anda siapkan di [Installation](/slides/id/nodejs-net/installation/). Presentasi PowerPoint apa pun dapat digunakan. Simpan setiap contoh sebagai file `.js` di folder proyek dan jalankan dari folder tersebut dengan `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET tidak memiliki referensi API sendiri. Ia mencerminkan API Aspose.Slides untuk .NET dengan nama camelCase, sehingga tautan API dalam artikel ini mengarah ke kelas dan anggota yang cocok di [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Buka Presentasi dari File**

Untuk membuka sebuah presentasi, berikan jalurnya ke konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Aspose.Slides mendeteksi format dari isi file bukan dari ekstensi, sehingga kode yang sama dapat membuka file PPTX, PPT, dan ODP. Jalur relatif diselesaikan terhadap direktori kerja saat ini, yang merupakan folder proyek ketika Anda menjalankan skrip dari sana.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Skrip mencetak jumlah slide dalam `sample.pptx`, misalnya `Slide count: 9`. Properti `count` dari koleksi [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) termasuk slide tersembunyi. Panggil `dispose` dalam blok `finally`, seperti yang ditunjukkan, sehingga sumber daya .NET di balik presentasi dibebaskan bahkan jika kode Anda gagal.

## **Buka Presentasi dari Buffer**

Ketika sebuah presentasi berasal dari database, unggahan HTTP, atau sumber lain yang memberikan Anda byte bukan jalur file, berikan `Buffer` Node.js sebagai argumen konstruktor kedua dan `null` sebagai argumen pertama. Contoh berikut membaca `sample.pptx` ke dalam buffer untuk meniru sumber tersebut:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Skrip mencetak jumlah slide yang sama seperti contoh sebelumnya. Argumen kedua harus berupa `Buffer`. Untuk tipe lain, seperti `Uint8Array`, konstruktor tidak melaporkan kesalahan; ia membuat presentasi baru dengan satu slide kosong sebagai gantinya. Konversi tipe biner lain terlebih dahulu dengan `Buffer.from`.

## **Simpan Presentasi dalam Format Lain**

Untuk mengonversi sebuah presentasi ke format presentasi lain, buka dan simpan dengan nilai [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) yang berbeda. Contoh berikut mencetak format yang dideteksi Aspose.Slides, yang dikembalikan oleh properti [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/), dan menyimpan presentasi sebagai presentasi OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Skrip mencetak `Source format: Pptx` dan menulis `sample.odp`, yang berisi slide yang sama. `sourceFormat` mengembalikan `Ppt`, `Pptx`, atau `Odp`. Untuk menyimpan sebagai PDF atau sebagai gambar, lihat [Convert PowerPoint to PDF](/slides/id/nodejs-net/convert-powerpoint-to-pdf/) dan [Convert Slides to Images](/slides/id/nodejs-net/convert-slide/).

## **FAQ**

**Bagaimana cara membuka presentasi yang dilindungi kata sandi?**

Buat objek [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) , set properti [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) , dan berikan objek tersebut sebagai argumen konstruktor ketiga: `new Presentation("protected.pptx", null, loadOptions)`. Tanpa kata sandi yang benar, konstruktor akan melempar error.

**Mengapa konstruktor melempar `Error` dengan pesan kosong?**

Ketika konstruktor `Presentation` gagal di .NET, misalnya karena file tidak ada, bukan presentasi, atau memerlukan kata sandi yang berbeda, JavaScript menerima `Error` dengan pesan kosong. Sebelum membuka file, periksa apakah file tersebut ada relatif terhadap direktori kerja, misalnya dengan `fs.existsSync`.

**Format apa saja yang dapat saya buka?**

Format presentasi PowerPoint dan OpenDocument, termasuk PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP, dan FODP.