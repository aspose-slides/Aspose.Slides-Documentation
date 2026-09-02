---
title: Mengonversi PPT & PPTX ke PDF dalam Python | Opsi Lanjutan
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
  - Aspose.Slides for Python
description: "Panduan langkah demi langkah untuk mengonversi PPT, PPTX, dan ODP ke PDF berkualitas tinggi dan sesuai WCAG dalam Python dengan Aspose.Slides—termasuk perlindungan kata sandi, pemilihan slide, dan kontrol kualitas gambar."
showReadingTime: true
---
## **Overview**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP) ke format PDF dalam Python menawarkan beberapa keuntungan, termasuk memastikan kompatibilitas di berbagai perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Installation**

```bash
pip install aspose.slides
```

Paket ini menyertakan runtime yang dibutuhkan, sehingga Microsoft PowerPoint tidak perlu diinstal pada mesin yang melakukan konversi.

## **PowerPoint to PDF Conversions**

Dengan menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF dalam Python, Anda cukup memberikan nama file sebagai argumen pada kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/) dan kemudian menyimpan presentasi sebagai PDF menggunakan metode [Save](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/#methods). Kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/) menampilkan metode [Save](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/#methods) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides untuk Python secara langsung menulis informasi API dan Nomor Versi ke dalam dokumen output. Misalnya, ketika mengonversi presentasi ke PDF, Aspose.Slides untuk Python mengisi bidang Application dengan nilai '*Aspose.Slides*' dan bidang PDF Producer dengan nilai dalam bentuk '*Aspose.Slides v XX.XX*'. **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk Python mengubah atau menghapus informasi ini dari dokumen output.
{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dalam presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan isi PDF yang dihasilkan sangat cocok dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiper
* Header dan footer
* Bullet
* Tabel

## **Convert PowerPoint to PDF**

Operasi standar konversi PowerPoint ke PDF dijalankan menggunakan opsi default. Dalam kasus ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF dengan menggunakan pengaturan optimal pada tingkat kualitas maksimum. Kode Python ini menunjukkan cara mengonversi PowerPoint ke PDF:

_Steps: PowerPoint to PDF Conversions in Python_

The following sample code explains these conversions using Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Langkah: Mengonversi PowerPoint ke PDF menggunakan Python via .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Langkah: Mengonversi PPT ke PDF menggunakan Python via .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Langkah: Mengonversi PPTX ke PDF menggunakan Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Langkah: Mengonversi ODP ke PDF menggunakan Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Langkah: Mengonversi PPS ke PDF menggunakan Python via .NET</strong></a>

_Code Steps:_

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan berikan file PowerPoint kepadanya.
  * Ekstensi _.ppt_ untuk memuat file **PPT** di dalam kelas _Presentation_.
  * Ekstensi _.pptx_ untuk memuat file **PPTX** di dalam kelas _Presentation_.
  * Ekstensi _.odp_ untuk memuat file **ODP** di dalam kelas _Presentation_.
  * Ekstensi _.pps_ untuk memuat file **PPS** di dalam kelas _Presentation_.
- Simpan _Presentation_ ke format **PDF** dengan memanggil metode **Save** dan menggunakan enumerasi **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Menyimpan presentasi sebagai PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 
Aspose menyediakan [**Konverter PowerPoint ke PDF**](https://products.aspose.app/slides/id/conversion/ppt-to-pdf) gratis secara daring yang memperlihatkan proses konversi presentasi ke PDF. Untuk implementasi langsung dari prosedur yang dijelaskan di sini, Anda dapat menguji dengan konverter tersebut.
{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides menyediakan opsi khusus—properti di bawah kelas [PdfOptions](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF (hasil proses konversi), mengunci PDF dengan kata sandi, atau bahkan menentukan bagaimana proses konversi seharusnya berjalan.

### **Convert PowerPoint to PDF with Custom Options**

Menggunakan opsi konversi khusus, Anda dapat menetapkan pengaturan kualitas gambar raster yang diinginkan, menentukan cara menangani metafile, mengatur tingkat kompresi untuk teks, mengatur DPI untuk gambar, dll.

Contoh kode di bawah menunjukkan operasi di mana sebuah presentasi PowerPoint dikonversi ke PDF dengan beberapa opsi khusus:

```python
import aspose.slides as slides

# Membuat instance kelas PdfOptions
pdf_options = slides.export.PdfOptions()

# Menetapkan kualitas untuk gambar JPG
pdf_options.jpeg_quality = 90

# Menetapkan DPI untuk gambar
pdf_options.sufficient_resolution = 300

# Menetapkan perilaku untuk metafile
pdf_options.save_metafiles_as_png = True

# Menetapkan tingkat kompresi teks untuk konten tekstual
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Menetapkan mode kepatuhan PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Membuat instance kelas Presentation yang mewakili dokumen PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Menyimpan presentasi sebagai dokumen PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convert PowerPoint to PDF with Hidden Slides**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan opsi khusus—properti `show_hidden_slides` dari kelas [PdfOptions](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides.export/pdfoptions/)—untuk menginstruksikan Aspose.Slides menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Kode Python ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan slide tersembunyi disertakan:

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

### **Convert PowerPoint to Password Protected PDF**

Kode Python ini menunjukkan cara mengonversi PowerPoint ke PDF yang dilindungi kata sandi (menggunakan parameter perlindungan dari kelas [PdfOptions](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Membuat instance objek Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Membuat instance kelas PdfOptions
pdfOptions = slides.export.PdfOptions()

# Menetapkan kata sandi PDF dan izin akses
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Menyimpan presentasi sebagai PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Convert Selected Slides in PowerPoint to PDF**

Kode Python ini menunjukkan cara mengonversi slide tertentu dalam presentasi PowerPoint ke PDF:

```python
import aspose.slides as slides

# Membuat instance objek Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Menetapkan array posisi slide
slides_array = [ 1, 3 ]

# Menyimpan presentasi sebagai PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Convert PowerPoint to PDF with Custom Slide Size**

Kode Python ini menunjukkan cara mengonversi PowerPoint ketika ukuran slidennya ditentukan ke PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Membuat presentasi baru dengan ukuran slide yang disesuaikan.
    with slides.Presentation() as resized_presentation:

        # Menetapkan ukuran slide khusus.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Mengkloning slide pertama dari presentasi asli dan menghapus slide kosong default.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Menyimpan presentasi yang telah diubah ukurannya ke PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Convert PowerPoint to PDF in Notes Slide View**

Kode Python ini menunjukkan cara mengonversi PowerPoint ke PDF catatan:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# Mengonfigurasi opsi PDF dengan tata letak catatan
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Menyimpan presentasi ke PDF dengan catatan
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode Python ini mendemonstrasikan operasi konversi PowerPoint ke PDF di mana beberapa PDF berdasarkan standar kepatuhan yang berbeda dihasilkan:

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

{{% alert title="Note" color="warning" %}} 
Dukungan Aspose.Slides untuk operasi konversi PDF meluas hingga memungkinkan Anda mengonversi PDF ke format file paling populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/id/python-net/conversion/pdf-to-xml/)—juga didukung.
{{% /alert %}}

> **Note:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, bagan, dan rumus sebagai satu gambar tunggal. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

### Can Aspose.Slides for Python remove the application information from the PDF?

Tidak, Aspose.Slides untuk Python secara otomatis menyertakan informasi API dan nomor versi dalam PDF output. Informasi ini tidak dapat dimodifikasi atau dihapus.

### How do I include only specific slides in the PDF conversion?

Anda dapat menentukan indeks slide yang ingin dikonversi dengan melewatkan array posisi slide ke metode `save`.

### Is it possible to password-protect the PDF during conversion?

Ya, Anda dapat menetapkan kata sandi dan mendefinisikan izin akses menggunakan kelas `PdfOptions` sebelum menyimpan presentasi sebagai PDF.

### Does Aspose.Slides support converting PDF to other formats?

Ya, Aspose.Slides mendukung konversi PDF ke format seperti HTML, format gambar (JPG, PNG), SVG, TIFF, dan XML.

### How can I ensure my PDF complies with accessibility standards?

Setel properti `compliance` dalam `PdfOptions` ke standar seperti `PDF_A1A`, `PDF_A1B`, atau `PDF_UA` untuk memastikan kepatuhan terhadap pedoman aksesibilitas.

### Can I include hidden slides in the PDF output?

Ya, dengan mengatur properti `show_hidden_slides` dalam `PdfOptions` menjadi `True`, slide tersembunyi akan disertakan dalam PDF.

### How do I adjust image quality and resolution during conversion?

Gunakan properti `jpeg_quality` dan `sufficient_resolution` dalam `PdfOptions` untuk mengontrol kualitas gambar dan resolusi dalam PDF yang dihasilkan.

### Does Aspose.Slides handle font substitutions automatically?

Aspose.Slides mendeteksi substitusi font selama konversi, dan Anda dapat menanganinya menggunakan properti `warning_callback` dalam `SaveOptions` (saat ini terbatas).

## **Additional Resources**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/id/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/id/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/id/conversion)