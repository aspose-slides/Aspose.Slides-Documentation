---
title: Menyimpan Presentasi di Python
linktitle: Menyimpan Presentasi
type: docs
weight: 80
url: /id/python-net/save-presentation/
keywords:
- menyimpan PowerPoint
- menyimpan OpenDocument
- menyimpan presentasi
- menyimpan slide
- menyimpan PPT
- menyimpan PPTX
- menyimpan ODP
- presentasi ke file
- presentasi ke stream
- tipe tampilan yang telah ditentukan
- Format Strict Office Open XML
- mode Zip64
- menyegarkan thumbnail
- proses penyimpanan
- Python
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di Python menggunakan Aspose.Slides—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Ikhtisar**

[Open a Presentation in Python](/slides/id/python-net/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk membuka presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) berisi konten presentasi. Baik Anda membuat presentasi dari nol maupun memodifikasi yang sudah ada, Anda perlu menyimpannya setelah selesai. Dengan Aspose.Slides for Python, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan presentasi.

## **Simpan Presentasi ke File**

Simpan presentasi ke file dengan memanggil metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides for Python.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    
    # Lakukan beberapa pekerjaan di sini...

    # Simpan presentasi ke file.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Simpan Presentasi ke Stream**

Anda dapat menyimpan presentasi ke stream dengan memberi stream output ke metode `save` kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). Presentasi dapat ditulis ke berbagai jenis stream. Pada contoh di bawah, kami membuat presentasi baru, menambahkan teks ke sebuah shape, dan menyimpannya ke stream.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Simpan presentasi ke stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Simpan Presentasi dengan Tipe Tampilan yang Sudah Ditentukan**

Aspose.Slides for Python memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint saat presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/). Atur properti `last_view` ke nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Simpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/) dan atur properti conformance saat menyimpan. Jika Anda mengatur `Conformance.ISO_29500_2008_STRICT`, file output disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat presentasi dan menyimpannya dalam format Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    # Simpan presentasi dalam format Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

File Office Open XML adalah arsip ZIP yang memberlakukan batas 4 GB (2^32 byte) untuk ukuran tidak terkompresi suatu file, ukuran terkompresi suatu file, dan total ukuran arsip, serta membatasi arsip hingga 65 535 (2^16‑1) file. Ekstensi format ZIP64 menaikkan batas ini menjadi 2^64.

Properti [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Properti ini menyediakan mode berikut:

- `IF_NECESSARY` menggunakan ekstensi format ZIP64 hanya bila presentasi melampaui batas di atas. Ini adalah mode default.
- `NEVER` tidak pernah menggunakan ekstensi format ZIP64.
- `ALWAYS` selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan presentasi sebagai PPTX dengan ekstensi format ZIP64 diaktifkan:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="CATATAN" color="warning" %}}
Saat Anda menyimpan dengan `Zip64Mode.NEVER`, sebuah [PptxException](https://reference.aspose.com/slides/id/python-net/aspose.slides/pptxexception/) dilempar jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Simpan Presentasi tanpa Memperbarui Thumbnail**

Properti [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) mengontrol pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika diatur ke `True`, thumbnail diperbarui selama proses penyimpanan. Ini adalah nilai default.
- Jika diatur ke `False`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dibuat.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa memperbarui thumbnailnya.

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
Aspose telah mengembangkan sebuah [free PowerPoint Splitter app](https://products.aspose.app/slides/id/splitter) menggunakan API mereka sendiri. Aplikasi ini memungkinkan Anda memisahkan sebuah presentasi menjadi beberapa file dengan menyimpan slide yang dipilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Penyimpanan selalu membuat file target lengkap setiap kali; “fast save” inkremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) [tidak thread‑safe](/slides/id/python-net/multithreading/); simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlinks](/slides/id/python-net/manage-hyperlinks/) tetap dipertahankan. File yang ditautkan secara eksternal (misalnya video melalui jalur relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Author, Title, Company, Date)?**

Ya. Properti dokumen standar [/slides/id/python-net/presentation-properties/] didukung dan akan ditulis ke file saat disimpan.