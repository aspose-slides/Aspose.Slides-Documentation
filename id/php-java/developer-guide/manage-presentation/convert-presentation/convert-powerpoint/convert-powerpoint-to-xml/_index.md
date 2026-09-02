---
title: Konversi Presentasi PowerPoint ke XML dalam PHP
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/php-java/convert-powerpoint-to-xml/
keywords:
- konversi PowerPoint ke XML
- konversi presentasi ke XML
- PPT ke XML
- PPTX ke XML
- ODP ke XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- simpan presentasi sebagai XML
- ekspor presentasi ke XML
- stream XML
- PHP
- Aspose.Slides
description: "Konversi presentasi PowerPoint dan OpenDocument menjadi file atau stream XML PowerPoint dalam PHP dengan Aspose.Slides for PHP via Java."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda membutuhkan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam pengujian otomatis, atau mengintegrasikan dengan alur kerja yang menggunakan XML alih‑alih paket presentasi.

Gunakan metode [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dengan nilai `Xml` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/). Anda dapat menulis hasilnya langsung ke file atau ke stream.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` membuat PowerPoint XML Presentation. Ia tidak mengekstrak bagian‑bagian Office Open XML individual yang disimpan di dalam paket PPTX. Jika Anda membutuhkan bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau file XML slide individual, periksa paket PPTX itu sendiri.
{{% /alert %}}

## **Mengonversi Presentasi ke File XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), lalu berikan jalur output dan `SaveFormat::Xml` ke [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Sumber dapat berupa format presentasi apa pun yang didukung untuk pemuatan, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX ke file XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Menulis Output XML ke Stream**

Gunakan overload stream dari [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) ketika XML harus tetap berada dalam memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) dan memperoleh XML yang dihasilkan sebagai array byte:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Kirim $xmlBytes ke komponen berikutnya dalam alur kerja.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` menyimpan semua data yang dihasilkan dalam memori, sehingga tidak diperlukan reset posisi sebelum memanggil `toByteArray`.

## **Membandingkan XML dengan Format Presentasi dan Ekspor**

Pilihan format output tergantung pada cara hasil akan digunakan:

| Format | Output | Penggunaan Umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Memeriksa struktur, memecahkan masalah, membandingkan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | File presentasi biner warisan | Kompatibilitas dengan alur kerja PowerPoint lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi banyak bagian | Pengeditan PowerPoint biasa dan pertukaran presentasi |
| PDF atau TIFF | Halaman tata letak tetap atau gambar multi‑halaman | Melihat, mencetak, dan mengarsipkan |
| PNG, JPEG, atau SVG | Representasi ter‑render dari satu slide individual | Thumbnail, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi berorientasi web | Penampilan di browser dan publikasi web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, XML mewakili data presentasi bukan merender slide sebagai halaman atau aset visual. Tabel [supported file formats](/slides/id/php-java/supported-file-formats/) mencantumkan PowerPoint XML Presentation sebagai format hanya untuk penyimpanan, sehingga jangan gunakan bila alur kerja harus memuat kembali file yang diekspor ke Aspose.Slides untuk penyuntingan lanjutan.

## **FAQ**

**Apakah `SaveFormat::Xml` sama dengan menyimpan file PPTX?**

Tidak. PPTX adalah paket yang berisi banyak bagian Office Open XML, sedangkan `SaveFormat::Xml` membuat file PowerPoint XML Presentation.

**Apakah saya dapat menyimpan output XML tanpa membuat file di disk?**

Ya. Berikan stream yang dapat ditulis ke [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Misalnya, gunakan [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali file XML yang diekspor?**

Tidak. PowerPoint XML Presentation saat ini hanya didukung untuk penyimpanan, bukan untuk pemuatan. Gunakan PPTX atau format presentasi lain yang didukung ketika diperlukan penyuntingan berulang.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi yang terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individual.