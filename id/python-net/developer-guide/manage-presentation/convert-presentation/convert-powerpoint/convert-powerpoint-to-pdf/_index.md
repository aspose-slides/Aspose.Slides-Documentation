---
title: Konversi PPT & PPTX ke PDF dalam Python | Opsi Lanjutan
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
- lampiran
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Panduan langkah demi langkah untuk mengonversi PPT, PPTX, dan ODP ke PDF berkualitas tinggi yang sesuai WCAG dalam Python dengan Aspose.Slides—termasuk perlindungan kata sandi, pemilihan slide, dan kontrol kualitas gambar."
showReadingTime: true
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP) ke format PDF menggunakan Python menawarkan beberapa keuntungan, termasuk memastikan kompatibilitas di berbagai perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen keluaran.

## **Konversi PowerPoint ke PDF**

Menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi sebuah presentasi ke PDF dalam Python, Anda cukup memberikan nama file sebagai argumen ke kelas [Presentasi](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan kemudian menyimpan presentasi sebagai PDF menggunakan metode [simpan](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Kelas [Presentasi](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) menyediakan metode [simpan](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Catatan" %}}

Aspose.Slides untuk Python menyisipkan informasi API dan nomor versinya ke dalam dokumen keluaran. Misalnya, ketika mengonversi sebuah presentasi ke PDF, Aspose.Slides untuk Python mengisi bidang Aplikasi dengan nilai '*Aspose.Slides*' dan bidang PDF Producer dengan nilai dalam format '*Aspose.Slides v XX.XX*'. **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk Python mengubah atau menghapus informasi ini dari dokumen keluaran.

{{% /alert %}}

Aspose.Slides memungkinkan Anda untuk mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dalam presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan isi PDF yang dihasilkan sangat cocok dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam proses konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan
* Header dan footer
* Poin
* Tabel

## **Konversi PowerPoint ke PDF**

Proses konversi standar PowerPoint-ke-PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Contoh berikut memuat sebuah presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Catatan" %}}

Aspose menyediakan [**Pengonversi PowerPoint ke PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) daring gratis yang mendemonstrasikan proses konversi presentasi ke PDF. Untuk implementasi langsung dari prosedur yang dijelaskan di sini, Anda dapat melakukan percobaan dengan konverter tersebut.

{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi kustom—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF (hasil proses konversi), mengunci PDF dengan kata sandi, atau bahkan menentukan bagaimana proses konversi harus berlangsung.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat mengatur pengaturan kualitas raster gambar yang diinginkan, menentukan cara menangani metafile, mengatur level kompresi untuk teks, mengatur DPI untuk gambar, dll.

Contoh berikut mengekspor sebuah presentasi ke PDF 1.5 dengan kualitas JPEG 90, resolusi gambar 300 DPI, metafile disimpan sebagai PNG, dan kompresi teks Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Pertahankan File OLE yang Disematkan sebagai Lampiran PDF**

Jika sebuah presentasi berisi workbook Excel yang disematkan, Anda mungkin ingin penerima PDF dapat mengakses data workbook tersebut serta melihat slide. Atur [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) ke `True` untuk mempertahankan file OLE yang disematkan sebagai lampiran dalam PDF yang dihasilkan.

Nilai default adalah `False`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file yang disematkan tidak termasuk sebagai lampiran. Mengatur opsi ke `True` menambahkan data file tersebut. Pratinjau tetap menjadi representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file yang disematkan secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat sebuah presentasi yang sudah berisi workbook Excel yang disematkan dan mengekspornya ke PDF dengan workbook terlampir.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Untuk memeriksa hasilnya:

1. Buka PDF yang diekspor di penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Attachments** penampil dan temukan workbook yang disematkan.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil mengizinkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Catatan" %}}

Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file yang disematkan, PDF/A-2 hanya mengizinkan lampiran PDF/A, dan PDF/A-3 mengizinkan tipe file lain, termasuk workbook Excel. Ini adalah persyaratan standar, bukan pembatasan khusus Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak mendemonstrasikan ekspor PDF/A.

{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan opsi kustom—properti [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—untuk menginstruksikan Aspose.Slides menyertakan slide tersembunyi tersebut sebagai halaman dalam PDF yang dihasilkan.

Contoh berikut mengekspor sebuah presentasi ke PDF, termasuk semua slide tersembunyi.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Contoh berikut mengekspor sebuah presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses memungkinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Konversi Slide Tertentu dalam PowerPoint ke PDF**

Contoh berikut mengekspor slide 1 dan 3 dari sebuah presentasi ke PDF. Nomor slide dalam array ini menggunakan indeks berbasis satu, dan presentasi masukan harus memiliki setidaknya tiga slide.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh berikut menyalin slide pertama dari sebuah presentasi ke dalam presentasi baru dengan ukuran slide 612 × 792 poin (8,5 × 11 inci). Itu menskalakan konten slide agar pas dan mengekspor satu slide tersebut ke PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Hapus slide kosong yang dibuat secara otomatis pada presentasi baru.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Konversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Contoh berikut mengekspor sebuah presentasi ke PDF, menempatkan catatan pembicara setiap slide di bawah slide. Gunakan presentasi yang memiliki catatan pembicara untuk melihat hasilnya.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Aksesibilitas dan Standar Kepatuhan untuk PDF**

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

{{% alert color="info" title="Catatan" %}}

Dukungan Aspose.Slides untuk operasi konversi PDF memungkinkan Anda mengonversi PDF ke format file paling populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, bagan, dan rumus sebagai satu gambar tunggal. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan mungkin ditandai sebagai artefak; teks alternatif hanya disediakan untuk keseluruhan gambar.

## **Tanya Jawab**

**Apakah Aspose.Slides untuk Python dapat menghapus informasi aplikasi dari PDF?**

Tidak, Aspose.Slides untuk Python secara otomatis menyertakan informasi API dan nomor versi dalam PDF keluaran. Informasi ini tidak dapat dimodifikasi atau dihapus.

**Bagaimana cara menyertakan hanya slide tertentu dalam konversi PDF?**

Anda dapat menentukan indeks slide yang ingin dikonversi dengan memberikan array posisi slide ke metode [simpan](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Apakah dimungkinkan melindungi PDF dengan kata sandi selama konversi?**

Ya, Anda dapat menetapkan kata sandi dan mendefinisikan izin akses menggunakan kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sebelum menyimpan presentasi sebagai PDF.

**Apakah Aspose.Slides mendukung konversi PDF ke format lain?**

Ya, Aspose.Slides mendukung konversi PDF ke format seperti HTML, format gambar (JPG, PNG), SVG, TIFF, dan XML.

**Bagaimana saya dapat memastikan PDF saya mematuhi standar aksesibilitas?**

Atur properti [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ke standar seperti `PDF_A1A`, `PDF_A1B`, atau `PDF_UA` untuk memastikan kepatuhan terhadap pedoman aksesibilitas.

**Apakah saya dapat menyertakan slide tersembunyi dalam output PDF?**

Ya, dengan mengatur properti [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ke `True`, slide tersembunyi akan disertakan dalam PDF.

**Bagaimana cara menyesuaikan kualitas dan resolusi gambar selama konversi?**

Gunakan properti [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) dan [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) untuk mengontrol kualitas dan resolusi gambar pada PDF yang dihasilkan.

**Apakah Aspose.Slides menangani substitusi font secara otomatis?**

Aspose.Slides mendeteksi substitusi font selama konversi, dan Anda dapat menanganinya menggunakan properti `warning_callback` dalam `SaveOptions` (saat ini terbatas).

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk Python via .NET](/slides/id/python-net/)
- [Referensi API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Konverter Online Gratis Aspose](https://products.aspose.app/slides/conversion)