---
title: Mengonversi Presentasi PowerPoint ke XML dengan Python
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/python-net/convert-powerpoint-to-xml/
keywords:
- konversi PowerPoint ke XML
- konversi presentasi ke XML
- PPT ke XML
- PPTX ke XML
- ODP ke XML
- Presentasi XML PowerPoint
- SaveFormat.XML
- simpan presentasi sebagai XML
- ekspor presentasi ke XML
- stream XML
- Python
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint dan OpenDocument menjadi file atau stream XML PowerPoint di Python dengan Aspose.Slides."
---
## **Ikhtisar**

Aspose.Slides for Python via .NET dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda memerlukan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam pengujian otomatis, atau mengintegrasikan dengan alur kerja yang menggunakan XML alih-alih paket presentasi.

Gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) dengan nilai `XML` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/). Anda dapat menulis hasilnya langsung ke file atau ke stream.

{{% alert color="info" title="Catatan" %}}

`SaveFormat.XML` membuat PowerPoint XML Presentation. Ini tidak mengekstrak bagian individual Office Open XML yang disimpan di dalam paket PPTX. Jika Anda memerlukan bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau file XML slide individual, periksa paket PPTX itu sendiri.

{{% /alert %}}

## **Mengonversi Presentasi ke File XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) , lalu berikan jalur output serta `SaveFormat.XML` ke [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/). Sumber dapat berupa format presentasi apa pun yang didukung untuk dimuat, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX menjadi file XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Menulis Output XML ke Stream**

Gunakan overload stream dari [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) ketika XML harus tetap berada di memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke stream [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) dan mengembalikannya (rewind) untuk pembacaan selanjutnya:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Kirim xml_stream ke komponen berikutnya dalam alur kerja.
```

## **Bandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai dengan cara hasil akan digunakan:

| Format | Output | Penggunaan umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Presentasi PowerPoint XML | Memeriksa struktur, memecahkan masalah, membandingkan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | File presentasi biner lama | Kompatibilitas dengan alur kerja PowerPoint lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi beberapa bagian | Pengeditan PowerPoint reguler dan pertukaran presentasi |
| PDF atau TIFF | Halaman berlayout tetap atau gambar multi‑halaman | Melihat, mencetak, dan mengarsipkan |
| PNG, JPEG, atau SVG | Representasi render dari slide individu | Thumbnail, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi berorientasi web | Menampilkan di browser dan penerbitan web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, XML merepresentasikan data presentasi bukan merender slide sebagai halaman atau aset visual. Tabel [supported file formats](/slides/id/python-net/supported-file-formats/) mencantumkan PowerPoint XML Presentation sebagai format hanya untuk penyimpanan, jadi jangan gunakan bila alur kerja harus memuat file yang diekspor kembali ke Aspose.Slides untuk penyuntingan lanjutan.

## **FAQ**

**Apakah `SaveFormat.XML` sama dengan menyimpan file PPTX?**

Tidak. PPTX adalah paket yang berisi beberapa bagian Office Open XML, sedangkan `SaveFormat.XML` membuat file PowerPoint XML Presentation.

**Apakah saya dapat menyimpan output XML tanpa membuat file di disk?**

Ya. Kirim stream yang dapat ditulis ke [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/). Misalnya, gunakan stream [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali file XML yang diekspor?**

Tidak. PowerPoint XML Presentation saat ini hanya didukung untuk penyimpanan, bukan untuk pemuatan. Gunakan PPTX atau format presentasi lain yang didukung ketika diperlukan penyuntingan bolak‑balik.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individu.