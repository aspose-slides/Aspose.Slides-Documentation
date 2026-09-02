---
title: Mengonversi Presentasi PowerPoint ke XML dalam JavaScript
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/nodejs-java/convert-powerpoint-to-xml/
keywords:
- mengonversi PowerPoint ke XML
- mengonversi presentasi ke XML
- PPT ke XML
- PPTX ke XML
- ODP ke XML
- Presentasi XML PowerPoint
- SaveFormat.Xml
- simpan presentasi sebagai XML
- ekspor presentasi ke XML
- stream XML
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi presentasi PowerPoint dan OpenDocument ke berkas atau stream XML PowerPoint dalam JavaScript dengan Aspose.Slides untuk Node.js via Java."
---
## **Ikhtisar**

Aspose.Slides untuk Node.js via Java dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda membutuhkan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam pengujian otomatis, atau mengintegrasikan dengan alur kerja yang mengonsumsi XML alih‑alih paket presentasi.

Gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) dengan nilai `Xml` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/). Anda dapat menulis hasilnya langsung ke file atau ke stream.

{{% alert color="info" title="Catatan" %}}

`SaveFormat.Xml` membuat PowerPoint XML Presentation. Ia tidak mengekstrak bagian‑bagian Office Open XML individu yang disimpan di dalam paket PPTX. Jika Anda memerlukan bagian‑bagian paket PPTX secara tepat, seperti `ppt/presentation.xml` atau file XML slide terpisah, periksa paket PPTX itu sendiri.

{{% /alert %}}

## **Mengonversi Presentasi ke Berkas XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/), lalu berikan jalur output dan `SaveFormat.Xml` ke [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save). Sumber dapat berupa format presentasi apa pun yang didukung untuk dimuat, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX ke berkas XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Menulis Output XML ke Stream**

Gunakan overload stream dari [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) ketika XML harus tetap berada di memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke `ByteArrayOutputStream` Java dan menyalin data yang dihasilkan ke `Buffer` Node.js:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Lewati xmlBuffer ke komponen berikutnya dalam alur kerja.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Membandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai dengan cara hasil akan digunakan:

| Format | Output | Penggunaan umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Memeriksa struktur, pemecahan masalah, perbandingan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | Berkas presentasi biner lama | Kompatibilitas dengan alur kerja PowerPoint versi lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi banyak bagian | Pengeditan PowerPoint biasa dan pertukaran presentasi |
| PDF atau TIFF | Halaman berlayout tetap atau gambar multi‑halaman | Penampilan, pencetakan, dan pengarsipan |
| PNG, JPEG, atau SVG | Representasi render satu slide | Thumbnail, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi berorientasi web | Penampilan di browser dan penerbitan web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, XML merepresentasikan data presentasi bukan render slide sebagai halaman atau aset visual. Tabel [format berkas yang didukung](/slides/id/nodejs-java/supported-file-formats/) mencantumkan PowerPoint XML Presentation sebagai format hanya‑simpan, jadi jangan menggunakannya ketika alur kerja harus memuat berkas yang diekspor kembali ke Aspose.Slides untuk penyuntingan lanjutan.

## **FAQ**

**Apakah `SaveFormat.Xml` sama dengan menyimpan berkas PPTX?**

Tidak. PPTX adalah paket yang berisi banyak bagian Office Open XML, sedangkan `SaveFormat.Xml` membuat berkas PowerPoint XML Presentation.

**Bisakah saya menyimpan output XML tanpa membuat berkas di disk?**

Ya. Berikan stream yang dapat ditulisi ke [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save). Misalnya, gunakan `ByteArrayOutputStream` Java dan salin datanya ke `Buffer` Node.js untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali berkas XML yang diekspor?**

Tidak. PowerPoint XML Presentation saat ini hanya didukung untuk penyimpanan, bukan untuk pemuatan. Gunakan PPTX atau format presentasi lain yang didukung ketika diperlukan penyuntingan bolak‑balik.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi yang terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individual.