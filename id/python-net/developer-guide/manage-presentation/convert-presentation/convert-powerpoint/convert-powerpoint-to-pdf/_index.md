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
- lampiran
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Panduan langkah demi langkah untuk mengonversi PPT, PPTX, dan ODP menjadi PDF berkualitas tinggi yang mematuhi WCAG di Python dengan Aspose.Slides—menyertakan perlindungan kata sandi, pemilihan slide, dan kontrol kualitas gambar."
showReadingTime: true
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP) ke format PDF di Python menawarkan beberapa keuntungan, termasuk memastikan kompatibilitas di berbagai perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Dengan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF di Python, Anda cukup memberikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan kemudian menyimpan presentasi sebagai PDF menggunakan metode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) menyediakan metode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Catatan" %}}

Aspose.Slides for Python menyisipkan informasi API dan nomor versinya ke dalam dokumen output. Misalnya, ketika mengonversi presentasi ke PDF, Aspose.Slides for Python mengisi bidang Application dengan nilai '*Aspose.Slides*' dan bidang PDF Producer dengan nilai dalam format '*Aspose.Slides v XX.XX*'. **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides for Python untuk mengubah atau menghapus informasi ini dari dokumen output.

{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dalam presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan isi PDF yang dihasilkan sangat mirip dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiper
* Header dan footer
* Bullet
* Tabel

## **Konversi PowerPoint ke PDF**

Proses standar konversi PowerPoint ke PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF menggunakan pengaturan optimal pada tingkat kualitas maksimum.

Contoh berikut memuat presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Catatan" %}}

Aspose menyediakan [**konverter PowerPoint ke PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) secara daring gratis yang menunjukkan proses konversi presentasi ke PDF. Untuk implementasi langsung prosedur yang dijelaskan di sini, Anda dapat melakukan percobaan dengan konverter tersebut.

{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi kustom—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF (hasil proses konversi), mengunci PDF dengan kata sandi, atau bahkan menentukan cara proses konversi berjalan.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat mengatur pengaturan kualitas yang diinginkan untuk gambar raster, menentukan cara penanganan metafile, menetapkan tingkat kompresi untuk teks, mengatur DPI untuk gambar, dll.

Contoh berikut mengekspor presentasi ke PDF 1.5 dengan kualitas JPEG 90, resolusi gambar 300 DPI, metafile disimpan sebagai PNG, dan kompresi teks Flate.

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

### **Mempertahankan File OLE Tertanam sebagai Lampiran PDF**

Jika presentasi berisi workbook Excel tertanam, Anda mungkin ingin penerima PDF dapat mengakses data workbook tersebut serta melihat slide. Atur [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) ke `True` untuk mempertahankan file OLE tertanam sebagai lampiran dalam PDF yang dihasilkan.

Nilai default adalah `False`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file tertanam tidak disertakan sebagai lampiran. Mengatur opsi ke `True` juga menyertakan data file. Pratinjau tetap menjadi representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file tertanam secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat presentasi yang sudah berisi workbook Excel tertanam dan mengekspornya ke PDF dengan workbook terlampir.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Untuk memeriksa hasilnya:

1. Buka PDF yang diekspor dalam penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Attachments** penampil dan temukan workbook yang tertanam.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil mengizinkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Catatan" %}}

Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file tertanam, PDF/A-2 hanya mengizinkan lampiran PDF/A, dan PDF/A-3 mengizinkan tipe file lain, termasuk workbook Excel. Ini adalah persyaratan standar, bukan pembatasan khusus Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak menunjukkan ekspor PDF/A.

{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika presentasi berisi slide tersembunyi, Anda dapat menggunakan opsi kustom—properti [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—untuk menginstruksikan Aspose.Slides menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Contoh berikut mengekspor presentasi ke PDF, termasuk semua slide tersembunyi.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Contoh berikut mengekspor presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses mengizinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Menangani Font Tanpa Gaya Tebal Khusus**

Sebuah presentasi dapat menerapkan pemformatan tebal pada teks meskipun fontnya tidak memiliki gaya tebal khusus. Teks tetap dapat terlihat tebal melalui penebalan sintetis, yang secara artifisial menebalkan glif reguler. Ketika teks tersebut tampak terlalu berat atau berbeda dari tampilan yang diharapkan dalam PDF, coba atur [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) ke `True`. Opsi ini merender teks yang bersangkutan sebagai bitmap selama ekspor PDF dan dapat meningkatkan tampilan untuk font tertentu. Nilai defaultnya adalah `False`.

Presentasi contoh berisi dua kotak teks: satu dengan teks reguler dan satu dengan pemformatan tebal pada font yang sama, yang tidak memiliki gaya tebal khusus. Contoh berikut memuat presentasi, mengaktifkan rasterisasi gaya font yang tidak didukung, dan mengekspornya ke PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Pratinjau berikut menampilkan output nonaktif dan output aktif. Pada contoh ini, teks tebal memiliki goresan lebih berat ketika opsi dinonaktifkan. Dengan opsi diaktifkan, goresannya lebih ringan; teks reguler tidak berubah. Bandingkan hasilnya sebelum memilih pengaturan untuk presentasi Anda.

| Opsi dinonaktifkan (`False`, default) | Opsi diaktifkan (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Pada contoh ini, mengaktifkan opsi mengubah hanya teks tebal menjadi bitmap: tidak dapat dipilih, disalin, atau dicari sebagai teks tanpa OCR, dan tepiannya terlihat lebih lembut pada zoom 800 %. Teks reguler tetap dapat dicari. Dengan opsi dinonaktifkan, kedua string tetap teks.

Opsi ini merasterisasi teks yang diformat tebal ketika fontnya tidak memiliki gaya tebal khusus. [Substitusi font](/slides/id/python-net/font-substitution/) justru memilih font lain ketika font asli tidak tersedia.

## **Konversi Slide Terpilih dalam PowerPoint ke PDF**

Contoh berikut mengekspor slide 1 dan 3 dari presentasi ke PDF. Nomor slide dalam array ini dimulai dari 1, dan presentasi input harus berisi setidaknya tiga slide.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh berikut menyalin slide pertama dari presentasi ke presentasi baru dengan ukuran slide 612 × 792 poin (8,5 × 11 inci). Ia menyesuaikan konten slide agar muat dan mengekspor slide tunggal ke PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Hapus slide kosong yang dibuat bersama presentasi baru.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Konversi PowerPoint ke PDF dalam Tampilan Catatan Slide**

Contoh berikut mengekspor presentasi ke PDF, menempatkan catatan pembicara setiap slide di bawah slide. Gunakan presentasi yang berisi catatan pembicara untuk melihat hasilnya.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Aksesibilitas dan Standar Kepatuhan PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode Python ini menunjukkan operasi konversi PowerPoint ke PDF di mana beberapa PDF berdasarkan standar kepatuhan yang berbeda dihasilkan:

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

Dukungan Aspose.Slides untuk operasi konversi PDF memungkinkan Anda mengonversi PDF ke format file paling populer. Anda dapat melakukan [PDF ke HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) konversi. Operasi konversi PDF ke format khusus lainnya—[PDF ke SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan formula sebagai satu gambar tunggal. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah Aspose.Slides for Python dapat menghapus informasi aplikasi dari PDF?**

Tidak, Aspose.Slides for Python secara otomatis menyertakan informasi API dan nomor versi dalam PDF output. Informasi ini tidak dapat diubah atau dihapus.

**Bagaimana cara menyertakan hanya slide tertentu dalam konversi PDF?**

Anda dapat menentukan indeks slide yang ingin dikonversi dengan memberikan array posisi slide ke metode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Apakah memungkinkan melindungi PDF dengan kata sandi selama konversi?**

Ya, Anda dapat menetapkan kata sandi dan menentukan izin akses menggunakan kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sebelum menyimpan presentasi sebagai PDF.

**Apakah Aspose.Slides mendukung konversi PDF ke format lain?**

Ya, Aspose.Slides mendukung konversi PDF ke format seperti HTML, format gambar (JPG, PNG), SVG, TIFF, dan XML.

**Bagaimana saya dapat memastikan PDF saya mematuhi standar aksesibilitas?**

Atur properti [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ke standar seperti `PDF_A1A`, `PDF_A1B`, atau `PDF_UA` untuk memastikan kepatuhan terhadap pedoman aksesibilitas.

**Dapatkah saya menyertakan slide tersembunyi dalam output PDF?**

Ya, dengan mengatur properti [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ke `True`, slide tersembunyi akan disertakan dalam PDF.

**Bagaimana cara menyesuaikan kualitas dan resolusi gambar selama konversi?**

Gunakan properti [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) dan [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) untuk mengontrol kualitas dan resolusi gambar dalam PDF yang dihasilkan.

**Apakah Aspose.Slides menangani substitusi font secara otomatis?**

Aspose.Slides mendeteksi substitusi font selama konversi, dan Anda dapat menanganinya menggunakan properti `warning_callback` dalam `SaveOptions` (saat ini terbatas).

## **Sumber Daya Tambahan**

- [Aspose.Slides for Python via .NET Documentation](/slides/id/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)