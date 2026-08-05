---
title: Konversi PPT & PPTX ke PDF di Python | Opsi Lanjutan
linktitle: PowerPoint ke PDF
type: docs
weight: 40
url: /id/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- konversi PowerPoint
- presentasi
- PowerPoint ke PDF
- PPT ke PDF
- PPTX ke PDF
- simpan PowerPoint sebagai PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides untuk Python
description: "Panduan langkah demi langkah untuk mengonversi PPT, PPTX, dan ODP menjadi PDF berkualitas tinggi dan sesuai WCAG di Python dengan Aspose.Slides—termasuk perlindungan kata sandi, pemilihan slide, dan kontrol kualitas gambar."
showReadingTime: true
---
## **Ringkasan**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP) ke format PDF dalam Python menawarkan beberapa keunggulan, termasuk memastikan kompatibilitas lintas perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, memanfaatkan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF dalam Python, Anda cukup memberikan nama file sebagai argumen pada kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/) lalu menyimpan presentasi sebagai PDF menggunakan metode [Save](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/#methods). Kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/) menyediakan metode  [Save](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/#methods) yang biasanya dipakai untuk mengonversi presentasi ke PDF.

{{% alert title="CATATAN" color="warning" %}} 

Aspose.Slides for Python langsung menulis informasi API dan Nomor Versi pada dokumen output. Misalnya, ketika mengonversi presentasi ke PDF, Aspose.Slides for Python mengisi bidang Application dengan nilai '*Aspose.Slides*' dan bidang PDF Producer dengan nilai dalam format '*Aspose.Slides v XX.XX*'. **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides for Python untuk mengubah atau menghapus informasi ini dari dokumen output.

{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dalam sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan isi PDF yang dihasilkan sangat mirip dengan presentasi aslinya. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiper
* Header dan footer
* Bullet
* Tabel

## **Mengonversi PowerPoint ke PDF**

Operasi standar konversi PowerPoint ke PDF dijalankan dengan opsi default. Dalam kasus ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF menggunakan pengaturan optimal pada tingkat kualitas maksimum. Kode Python berikut menunjukkan cara mengonversi PowerPoint ke PDF:

_Step: Konversi PowerPoint ke PDF di Python_

Contoh kode berikut menjelaskan konversi tersebut menggunakan Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Langkah: Mengonversi PowerPoint ke PDF menggunakan Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Langkah: Mengonversi PPT ke PDF menggunakan Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Langkah: Mengonversi PPTX ke PDF menggunakan Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Langkah: Mengonversi ODP ke PDF menggunakan Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Langkah: Mengonversi PPS ke PDF menggunakan Python via .NET</a></strong>

_Langkah Kode:_

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan beri file PowerPoint.
  * Ekstensi _.ppt_ untuk memuat file **PPT** ke dalam kelas _Presentation_.
  * Ekstensi _.pptx_ untuk memuat file **PPTX** ke dalam kelas _Presentation_.
  * Ekstensi _.odp_ untuk memuat file **ODP** ke dalam kelas _Presentation_.
  * Ekstensi _.pps_ untuk memuat file **PPS** ke dalam kelas _Presentation_.
- Simpan _Presentation_ ke format **PDF** dengan memanggil metode **Save** dan menggunakan enumerasi **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Menyimpan presentasi sebagai PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="primary" %}} 

Aspose menyediakan [**konverter PowerPoint ke PDF**](https://products.aspose.app/slides/id/conversion/ppt-to-pdf) daring gratis yang mendemonstrasikan proses konversi presentasi ke PDF. Untuk melihat implementasi nyata prosedur yang dijelaskan di sini, Anda dapat menguji konverter tersebut.

{{% /alert %}}

## **Mengonversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di bawah kelas [PdfOptions](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF (hasil proses konversi), melindungi PDF dengan kata sandi, atau bahkan menentukan cara proses konversi berjalan.

### **Mengonversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat mengatur kualitas raster gambar yang diinginkan, menentukan cara penanganan metafile, menetapkan tingkat kompresi untuk teks, mengatur DPI untuk gambar, dll.

Contoh kode di bawah ini menunjukkan operasi di mana presentasi PowerPoint dikonversi ke PDF dengan beberapa opsi kustom:

```python
import aspose.slides as slides

# Membuat instance kelas PdfOptions
pdf_options = slides.export.PdfOptions()

# Mengatur kualitas gambar JPG
pdf_options.jpeg_quality = 90

# Mengatur DPI untuk gambar
pdf_options.sufficient_resolution = 300

# Mengatur perilaku metafile
pdf_options.save_metafiles_as_png = True

# Mengatur tingkat kompresi teks untuk konten tekstual
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Menentukan mode kepatuhan PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Membuat instance kelas Presentation yang mewakili dokumen PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Menyimpan presentasi sebagai dokumen PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Mengonversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika presentasi berisi slide tersembunyi, Anda dapat menggunakan opsi kustom—properti `show_hidden_slides` dari kelas [PdfOptions](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides.export/pdfoptions/)—untuk menginstruksikan Aspose.Slides menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Kode Python berikut menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan slide tersembunyi disertakan:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Membuat instance kelas PdfOptions
pdfOptions = slides.export.PdfOptions()

# Menambahkan slide tersembunyi
pdfOptions.show_hidden_slides = True

# Menyimpan presentasi sebagai PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Mengonversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Kode Python berikut menunjukkan cara mengonversi PowerPoint ke PDF yang dilindungi kata sandi (menggunakan parameter perlindungan dari kelas [PdfOptions](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Membuat instance objek Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Membuat instance kelas PdfOptions
pdfOptions = slides.export.PdfOptions()

# Mengatur kata sandi PDF dan izin akses
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Menyimpan presentasi sebagai PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Mengonversi Slide Tertentu dalam PowerPoint ke PDF**

Kode Python berikut menunjukkan cara mengonversi slide tertentu dalam sebuah presentasi PowerPoint ke PDF:

```python
import aspose.slides as slides

# Membuat instance objek Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Mengatur array posisi slide
slides_array = [ 1, 3 ]

# Menyimpan presentasi sebagai PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Mengonversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Kode Python berikut menunjukkan cara mengonversi PowerPoint ketika ukuran slidennya ditentukan ke PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Membuat presentasi baru dengan ukuran slide yang disesuaikan.
    with slides.Presentation() as resized_presentation:

        # Mengatur ukuran slide kustom.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Mengkloning slide pertama dari presentasi asli.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Menyimpan presentasi yang diubah ukuran ke PDF dengan catatan.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Mengonversi PowerPoint ke PDF dalam Tampilan Catatan Slide**

Kode Python berikut menunjukkan cara mengonversi PowerPoint ke PDF catatan:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Menyimpan presentasi ke catatan PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Aksesibilitas dan Standar Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode Python berikut mendemonstrasikan operasi konversi PowerPoint ke PDF di mana beberapa PDF berdasarkan standar kepatuhan yang berbeda dihasilkan:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Catatan" color="warning" %}} 

Dukungan Aspose.Slides untuk operasi konversi PDF meluas hingga memungkinkan Anda mengonversi PDF ke format file paling populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar tunggal. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah Aspose.Slides for Python dapat menghapus informasi aplikasi dari PDF?**

Tidak, Aspose.Slides for Python secara otomatis menyertakan informasi API dan nomor versi dalam PDF output. Informasi ini tidak dapat diubah atau dihapus.

**Bagaimana cara menyertakan hanya slide tertentu dalam konversi PDF?**

Anda dapat menentukan indeks slide yang ingin dikonversi dengan mengirimkan array posisi slide ke metode `save`.

**Apakah memungkinkan melindungi PDF dengan kata sandi saat konversi?**

Ya, Anda dapat mengatur kata sandi dan mendefinisikan izin akses menggunakan kelas `PdfOptions` sebelum menyimpan presentasi sebagai PDF.

**Apakah Aspose.Slides mendukung konversi PDF ke format lain?**

Ya, Aspose.Slides mendukung konversi PDF ke format seperti HTML, format gambar (JPG, PNG), SVG, TIFF, dan XML.

**Bagaimana cara memastikan PDF saya mematuhi standar aksesibilitas?**

Atur properti `compliance` pada `PdfOptions` ke standar seperti `PDF_A1A`, `PDF_A1B`, atau `PDF_UA` untuk memastikan kepatuhan terhadap pedoman aksesibilitas.

**Bisakah saya menyertakan slide tersembunyi dalam output PDF?**

Ya, dengan mengatur properti `show_hidden_slides` pada `PdfOptions` menjadi `True`, slide tersembunyi akan disertakan dalam PDF.

**Bagaimana cara menyesuaikan kualitas dan resolusi gambar selama konversi?**

Gunakan properti `jpeg_quality` dan `sufficient_resolution` pada `PdfOptions` untuk mengontrol kualitas dan resolusi gambar dalam PDF yang dihasilkan.

**Apakah Aspose.Slides menangani substitusi font secara otomatis?**

Aspose.Slides mendeteksi substitusi font selama konversi, dan Anda dapat menanganinya menggunakan properti `warning_callback` pada `SaveOptions` (saat ini terbatas).

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk .NET](https://docs.aspose.com/slides/id/python-net/)
- [Referensi API Aspose.Slides](https://reference.aspose.com/slides/id/python-net/)
- [Konverter Online Gratis Aspose](https://products.aspose.app/slides/id/conversion)