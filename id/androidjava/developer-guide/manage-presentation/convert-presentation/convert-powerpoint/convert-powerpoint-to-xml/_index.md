---
title: Mengonversi Presentasi PowerPoint ke XML di Android
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/androidjava/convert-powerpoint-to-xml/
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
- Android
- Java
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint dan OpenDocument ke file atau stream XML PowerPoint di Android dengan Aspose.Slides."
---
## **Ikhtisar**

Aspose.Slides untuk Android via Java dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda membutuhkan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam pengujian otomatis, atau mengintegrasikan dengan alur kerja yang mengkonsumsi XML alih‑alih paket presentasi.

Gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) dengan [SaveFormat.Xml](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/#Xml). Anda dapat menulis hasilnya langsung ke file atau ke stream.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` membuat PowerPoint XML Presentation. Itu tidak mengekstrak bagian Office Open XML individu yang disimpan di dalam paket PPTX. Jika Anda memerlukan bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau file XML slide individu, periksa paket PPTX itu sendiri.

{{% /alert %}}

## **Mengonversi Presentasi ke File XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) , lalu berikan jalur output dan [SaveFormat.Xml](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/#Xml) ke [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Sumber dapat berupa format presentasi apa pun yang didukung untuk dimuat, seperti PPT, PPTX, atau ODP.

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

Gunakan overload stream dari [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) ketika XML harus tetap berada di memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) dan memperoleh XML yang dihasilkan sebagai array byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Kirim xmlData ke komponen berikutnya dalam alur kerja.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Bandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai dengan cara hasil akan digunakan:

| Format | Output | Penggunaan umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Memeriksa struktur, memecahkan masalah, membandingkan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | File presentasi biner warisan | Kompatibilitas dengan alur kerja PowerPoint lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi beberapa bagian | Pengeditan PowerPoint reguler dan pertukaran presentasi |
| PDF atau TIFF | Halaman tata letak tetap atau gambar multi‑halaman | Melihat, mencetak, dan mengarsipkan |
| PNG, JPEG, atau SVG | Representasi yang di‑render dari slide individu | Thumbnail, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi berorientasi web | Penayangan di browser dan penerbitan web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, XML mewakili data presentasi bukan merender slide sebagai halaman atau aset visual. Tabel [supported file formats](/slides/id/androidjava/supported-file-formats/) mencantumkan PowerPoint XML Presentation sebagai format hanya‑simpan, sehingga jangan gunakan ketika alur kerja harus memuat kembali file yang diekspor ke Aspose.Slides untuk pengeditan lanjutan.

## **FAQ**

**Apakah `SaveFormat.Xml` sama dengan menyimpan file PPTX?**

Tidak. PPTX adalah paket yang berisi beberapa bagian Office Open XML, sedangkan `SaveFormat.Xml` membuat file PowerPoint XML Presentation.

**Bisakah saya menyimpan output XML tanpa membuat file di disk?**

Ya. Berikan stream yang dapat ditulisi ke [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Misalnya, gunakan [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali file XML yang diekspor?**

Tidak. PowerPoint XML Presentation saat ini hanya didukung untuk penyimpanan, bukan untuk pemuatan. Gunakan PPTX atau format presentasi lain yang didukung ketika diperlukan pengeditan bolak‑balik.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi yang terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individu.