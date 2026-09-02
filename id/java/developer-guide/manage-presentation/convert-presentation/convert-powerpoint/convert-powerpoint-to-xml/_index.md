---
title: Mengonversi Presentasi PowerPoint ke XML dalam Java
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/java/convert-powerpoint-to-xml/
keywords:
- mengonversi PowerPoint ke XML
- mengonversi presentasi ke XML
- PPT ke XML
- PPTX ke XML
- ODP ke XML
- Presentasi XML PowerPoint
- SaveFormat.Xml
- menyimpan presentasi sebagai XML
- mengekspor presentasi ke XML
- stream XML
- Java
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint dan OpenDocument ke file atau stream XML PowerPoint dalam Java dengan Aspose.Slides untuk Java."
---
## **Gambaran Umum**

Aspose.Slides for Java dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda memerlukan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam pengujian otomatis, atau mengintegrasikan dengan alur kerja yang mengonsumsi XML alih‑alih paket presentasi.

Gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-) dengan nilai `Xml` dari kelas [SaveFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/). Anda dapat menulis hasilnya langsung ke file atau ke stream.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` membuat PowerPoint XML Presentation. Ini tidak mengekstrak bagian‑bagian Office Open XML individual yang disimpan di dalam paket PPTX. Jika Anda memerlukan bagian‑bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau file XML slide individual, periksa paket PPTX itu sendiri.
{{% /alert %}}

## **Konversi Presentasi ke File XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/), lalu berikan jalur output dan `SaveFormat.Xml` ke [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Sumber dapat berupa format presentasi apa pun yang didukung untuk pemuatan, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX ke file XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Menulis Output XML ke Stream**

Gunakan overload stream dari [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) ketika XML harus tetap berada di memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) dan memperoleh XML yang dihasilkan sebagai array byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Kirim xmlData ke komponen berikutnya dalam alur kerja.
} finally {
    presentation.dispose();
}
```

## **Bandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai dengan cara hasil akan digunakan:

| Format | Output | Penggunaan Umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Presentasi PowerPoint XML | Memeriksa struktur, memecahkan masalah, membandingkan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | File presentasi biner legacy | Kompatibilitas dengan alur kerja PowerPoint yang lebih lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi banyak bagian | Penyuntingan PowerPoint reguler dan pertukaran presentasi |
| PDF atau TIFF | Halaman berlayout tetap atau gambar multi‑halaman | Penayangan, pencetakan, dan pengarsipan |
| PNG, JPEG, atau SVG | Representasi render dari satu slide | Thumbnail, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi berorientasi web | Penayangan di browser dan penerbitan web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berorientasi data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, XML merepresentasikan data presentasi bukan render slide sebagai halaman atau aset visual. Tabel [format file yang didukung](/slides/id/java/supported-file-formats/) mencantumkan PowerPoint XML Presentation sebagai format hanya‑simpan, jadi jangan gunakan ketika alur kerja harus memuat kembali file yang diekspor ke Aspose.Slides untuk penyuntingan lanjutan.

## **FAQ**

**Apakah `SaveFormat.Xml` sama dengan menyimpan file PPTX?**

Tidak. PPTX adalah paket yang berisi banyak bagian Office Open XML, sedangkan `SaveFormat.Xml` menghasilkan file PowerPoint XML Presentation.

**Apakah saya dapat menyimpan output XML tanpa membuat file di disk?**

Ya. Berikan stream yang dapat ditulis ke [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Misalnya, gunakan [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali file XML yang diekspor?**

Tidak. PowerPoint XML Presentation saat ini hanya didukung untuk penyimpanan, bukan pemuatan. Gunakan PPTX atau format presentasi lain yang didukung ketika diperlukan penyuntingan bolak‑balik.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi yang terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individual.