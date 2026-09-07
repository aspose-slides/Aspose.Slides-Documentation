---
title: Mengonversi Presentasi PowerPoint ke XML dalam Python via Java
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/python-java/convert-powerpoint-to-xml/
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
- Python
- Java
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint dan OpenDocument ke file atau stream XML PowerPoint dalam Python via Java dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda memerlukan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam tes otomatis, atau mengintegrasikan dengan alur kerja yang mengonsumsi XML alih‑alih paket presentasi.

Gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan nilai [Xml](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Xml) dari kelas [SaveFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) . Anda dapat menulis hasilnya langsung ke file atau ke stream.

{{% alert color="info" title="Note" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Xml) membuat PowerPoint XML Presentation. Ia tidak mengekstrak bagian‑bagian Office Open XML yang disimpan di dalam paket PPTX. Jika Anda memerlukan bagian‑bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau file XML slide individual, periksa paket PPTX itu sendiri.

{{% /alert %}}

## **Mengonversi Presentasi ke File XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) , lalu berikan jalur output dan [SaveFormat.Xml](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Xml) ke [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) . Sumber dapat berupa format presentasi apa pun yang didukung untuk pemuatan, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX ke file XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Menulis Output XML ke Stream**

Gunakan overload stream dari [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) ketika XML harus tetap berada di memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) dan memperoleh XML yang dihasilkan sebagai objek bytes Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Kirim xml_data ke komponen berikutnya dalam alur kerja.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Bandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai cara hasil akan digunakan:

| Format | Output | Penggunaan umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | A PowerPoint XML Presentation | Memeriksa struktur, memecahkan masalah, membandingkan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | A legacy binary presentation file | Kompatibilitas dengan alur kerja PowerPoint yang lebih lama |
| PPTX (`.pptx`) | An Office Open XML package containing multiple parts | Pengeditan PowerPoint biasa dan pertukaran presentasi |
| PDF or TIFF | Fixed‑layout pages or a multi‑page image | Melihat, mencetak, dan mengarsipkan |
| PNG, JPEG, or SVG | A rendered representation of an individual slide | Thumbnail, pratinjau, dan aset gambar |
| HTML or HTML5 | Web‑oriented presentation output | Penampilan di browser dan penerbitan web |

Tidak seperti PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Tidak seperti PDF, TIFF, HTML, dan format gambar slide, XML merepresentasikan data presentasi bukan merender slide sebagai halaman atau aset visual. Tabel [supported file formats](/slides/id/python-java/supported-file-formats/) mencantumkan PowerPoint XML Presentation sebagai format hanya‑simpan, jadi jangan gunakan ketika alur kerja harus memuat kembali file yang diekspor ke Aspose.Slides untuk penyuntingan lanjutan.

## **FAQ**

**Apakah ekspor XML sama dengan menyimpan file PPTX?**

Tidak. PPTX adalah paket yang berisi banyak bagian Office Open XML, sedangkan [SaveFormat.Xml](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Xml) membuat file PowerPoint XML Presentation.

**Bisakah saya menyimpan output XML tanpa membuat file di disk?**

Ya. Berikan stream output Java yang dapat ditulis ke [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) . Misalnya, gunakan [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali file XML yang diekspor?**

Tidak. PowerPoint XML Presentation saat ini hanya didukung untuk penyimpanan, tidak untuk pemuatan. Gunakan PPTX atau format presentasi lain yang didukung ketika diperlukan pengeditan bolak‑balik.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi yang terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individual.