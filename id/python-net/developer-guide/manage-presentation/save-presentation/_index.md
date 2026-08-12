---
title: Menyimpan Presentasi di Python
linktitle: Menyimpan Presentasi
type: docs
weight: 80
url: /id/python-net/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke stream
- tipe tampilan pradefinisi
- Format Strict Office Open XML
- mode Zip64
- memperbarui thumbnail
- proses penyimpanan
- Python
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di Python menggunakan Aspose.Slides—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Buka Presentasi di Python](/slides/id/python-net/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) berisi konten presentasi. Baik Anda membuat presentasi dari nol maupun memodifikasi yang sudah ada, Anda harus menyimpannya setelah selesai. Dengan Aspose.Slides untuk Python, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan presentasi.

## **Menyimpan Presentasi ke File**

Simpan sebuah presentasi ke file dengan memanggil metode `save` pada kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides untuk Python.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    
    # Lakukan beberapa pekerjaan di sini...

    # Simpan presentasi ke file.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Menyimpan Presentasi ke Stream**

Anda dapat menyimpan sebuah presentasi ke stream dengan memberikan output stream ke metode `save` pada kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Sebuah presentasi dapat ditulis ke banyak jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Simpan presentasi ke stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Menyimpan Presentasi dengan Tipe Tampilan Pradefinisi**

Aspose.Slides untuk Python memungkinkan Anda menetapkan tampilan awal yang digunakan PowerPoint saat presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/). Atur properti `last_view` ke nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Menyimpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan sebuah presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/) dan atur properti conformance saat menyimpan. Jika Anda menetapkan `Conformance.ISO_29500_2008_STRICT`, file output akan disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat sebuah presentasi dan menyimpannya dalam format Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    # Simpan presentasi dalam format Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Menyimpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang membatasi ukuran tidak terkompresi tiap file hingga 4 GB (2^32 byte), ukuran terkompresi tiap file, dan total ukuran arsip, serta membatasi jumlah file menjadi 65 535 (2^16‑1). Ekstensi format ZIP64 mengangkat batasan ini menjadi 2^64.

Properti [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Properti ini menyediakan mode berikut:

- `IF_NECESSARY` menggunakan ekstensi format ZIP64 hanya bila presentasi melebihi batas di atas. Ini adalah mode default.
- `NEVER` tidak pernah menggunakan ekstensi format ZIP64.
- `ALWAYS` selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan sebuah presentasi sebagai file PPTX dengan ekstensi format ZIP64 diaktifkan:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="CATATAN" color="warning" %}}

Saat Anda menyimpan dengan `Zip64Mode.NEVER`, sebuah [PptxException](https://reference.aspose.com/slides/id/python-net/aspose.slides/pptxexception/) akan dilempar jika presentasi tidak dapat disimpan dalam format ZIP32.

{{% /alert %}}

## **Menyimpan Presentasi dalam Format Office Open XML dengan Level Kompresi**

Saat bekerja dengan presentasi besar, Anda dapat menyesuaikan level kompresi untuk menyeimbangkan ukuran file dan waktu pemrosesan. Bergantung pada kebutuhan, Anda mungkin lebih memilih proses yang lebih cepat atau file output yang lebih kecil.

Aspose.Slides menyediakan properti [PptxOptions.compression_level](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/compression_level/) yang memungkinkan Anda menentukan level kompresi yang digunakan saat menyimpan presentasi dalam format Office Open XML.

Level kompresi yang tersedia:

- [**NONE**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Tidak ada kompresi. File disimpan apa adanya.
- [**LEVEL1**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Kompresi tercepat dengan rasio kompresi terendah.
- [**LEVEL2**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Kompresi lebih cepat dengan rasio sedikit lebih baik daripada **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Memberikan kompresi lebih baik daripada **LEVEL2** dengan dampak sedang pada waktu pemrosesan.
- [**LEVEL4**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Memberikan kompresi lebih baik daripada **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Meningkatkan kompresi dibanding **LEVEL4** dengan tambahan waktu pemrosesan.
- [**LEVEL6**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Kompresi standar yang memberikan keseimbangan baik antara kecepatan pemrosesan dan ukuran file. Ini adalah *level kompresi default*.
- [**LEVEL7**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Memberikan kompresi lebih baik daripada **LEVEL6** dengan pemrosesan lebih lambat.
- [**LEVEL8**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Memberikan kompresi lebih baik daripada **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/compressionlevel/): Kompresi maksimum. Menghasilkan ukuran file paling kecil dengan waktu pemrosesan terpanjang.

Contoh berikut menunjukkan cara menyimpan presentasi sebagai file PPTX *tanpa kompresi*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Contoh ini menunjukkan cara menyimpan presentasi sebagai file PPTX dengan *kompresi maksimum*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Menyimpan Presentasi tanpa Memperbarui Thumbnail**

Properti [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) mengontrol pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika diatur ke `True`, thumbnail diperbarui selama proses penyimpanan. Ini adalah default.
- Jika diatur ke `False`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dibuat.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa memperbarui thumbnail.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}

Opsi ini membantu mengurangi waktu yang diperlukan untuk menyimpan presentasi dalam format PPTX.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

Aspose telah mengembangkan aplikasi [PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API-nya sendiri. Aplikasi ini memungkinkan Anda memisahkan sebuah presentasi menjadi beberapa file dengan menyimpan slide yang dipilih sebagai file PPTX atau PPT baru.

{{% /alert %}}

## **FAQ**

**Apakah "penyimpanan cepat" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Setiap penyimpanan membuat file target penuh; "penyimpanan cepat" inkremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) tidak bersifat thread‑safe; simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang tertaut secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/python-net/manage-hyperlinks/) dipertahankan. File yang tertaut secara eksternal (misalnya video dengan jalur relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. Properti dokumen standar [/slides/id/python-net/presentation-properties/] didukung dan akan dituliskan ke file saat disimpan.