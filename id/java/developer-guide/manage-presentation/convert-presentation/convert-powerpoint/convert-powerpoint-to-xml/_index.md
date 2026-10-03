---
title: Konversi Presentasi PowerPoint ke XML di Java
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/java/convert-powerpoint-to-xml/
keywords:
- konversi PowerPoint ke XML
- konversi presentasi ke XML
- PPT ke XML
- PPTX ke XML
- ODP ke XML
- Presentasi XML PowerPoint
- SaveFormat.Xml
- simpan presentasi sebagai XML
- ekspor presentasi ke XML
- stream XML
- Java
- Aspose.Slides
description: "Konversi presentasi PowerPoint dan OpenDocument menjadi berkas atau stream XML PowerPoint di Java dengan Aspose.Slides for Java."
---
## **Ikhtisar**

Aspose.Slides for Java dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda memerlukan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam pengujian otomatis, atau mengintegrasikan dengan alur kerja yang menggunakan XML alih-alih paket presentasi.

Gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-) dengan nilai `Xml` dari kelas [SaveFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/). Anda dapat menulis hasilnya langsung ke berkas atau ke stream.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` membuat PowerPoint XML Presentation. Ini tidak mengekstrak bagian Office Open XML individu yang disimpan di dalam paket PPTX. Jika Anda memerlukan bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau berkas XML slide individu, periksa paket PPTX itu sendiri.
{{% /alert %}}

## **Mengonversi Presentasi ke Berkas XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan kemudian berikan jalur keluaran serta `SaveFormat.Xml` ke [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Sumber dapat berupa format presentasi apa pun yang didukung untuk dimuat, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX ke berkas XML:

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

Gunakan overload stream dari [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) ketika XML harus tetap dalam memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) dan memperoleh XML hasil sebagai array byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Berikan xmlData ke komponen berikutnya dalam alur kerja.
} finally {
    presentation.dispose();
}
```

## **Bandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai cara penggunaan hasil:

| Format | Output | Penggunaan umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Presentasi PowerPoint XML | Memeriksa struktur, memecahkan masalah, membandingkan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | Berkas presentasi biner lama | Kompatibilitas dengan alur kerja PowerPoint yang lebih lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi beberapa bagian | Penyuntingan PowerPoint reguler dan pertukaran presentasi |
| PDF atau TIFF | Halaman berlayout tetap atau gambar multi-halaman | Penampilan, pencetakan, dan pengarsipan |
| PNG, JPEG, atau SVG | Representasi hasil render dari slide individu | Gambar mini, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi berorientasi web | Penampilan di peramban dan publikasi web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, XML mewakili data presentasi bukan merender slide sebagai halaman atau aset visual. Tabel [supported file formats](/slides/id/java/supported-file-formats/) mencantumkan semua format yang dapat dimuat, diimpor, disimpan, atau dirender oleh Aspose.Slides.

## **FAQ**

**Apakah `SaveFormat.Xml` sama dengan menyimpan berkas PPTX?**

Tidak. PPTX adalah paket yang berisi beberapa bagian Office Open XML, sedangkan `SaveFormat.Xml` membuat berkas PowerPoint XML Presentation.

**Apakah saya dapat menyimpan output XML tanpa membuat berkas di disk?**

Ya. Berikan stream yang dapat ditulisi ke [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Misalnya, gunakan [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali berkas XML yang diekspor?**

Ya. Berikan berkas XML atau stream ke konstruktor [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSourceFormat--) kemudian mengembalikan `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) melaporkan `LoadFormat.Unknown` untuk format ini, jadi jangan gunakan untuk memutuskan apakah berkas XML dapat dibuka.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individu.