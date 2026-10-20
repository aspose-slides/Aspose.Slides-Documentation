---
title: Mengonversi PPT & PPTX ke PDF di Python | Opsi Lanjutan
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
description: "Panduan langkah-demi-langkah untuk mengonversi PPT, PPTX, dan ODP ke PDF berkualitas tinggi yang sesuai dengan WCAG di Python dengan Aspose.Slides—termasuk perlindungan kata sandi, pemilihan slide, dan kontrol kualitas gambar."
showReadingTime: true
---
## **Ikhtisar**

Mengkonversi presentasi PowerPoint (PPT, PPTX, ODP) ke format PDF dalam Python menawarkan beberapa keuntungan, termasuk memastikan kompatibilitas di berbagai perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, memanfaatkan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Dengan menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF dalam Python, Anda cukup memberikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan kemudian menyimpan presentasi sebagai PDF menggunakan metode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) menyediakan metode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python menyisipkan informasi API dan nomor versinya ke dalam dokumen keluaran. Misalnya, ketika mengonversi presentasi ke PDF, Aspose.Slides for Python mengisi bidang Application dengan nilai '*Aspose.Slides*' dan bidang PDF Producer dengan nilai dalam format '*Aspose.Slides v XX.XX*'. **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides for Python untuk mengubah atau menghapus informasi ini dari dokumen keluaran.
{{% /alert %}}

Aspose.Slides memungkinkan Anda untuk mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dalam sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan isi PDF yang dihasilkan sangat cocok dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiper
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

{{% alert color="info" title="Note" %}}
Aspose menyediakan [**Pengonversi PowerPoint ke PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) online gratis yang menunjukkan proses konversi presentasi ke PDF. Untuk implementasi langsung dari prosedur yang dijelaskan di sini, Anda dapat melakukan percobaan dengan konverter tersebut.
{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF (hasil proses konversi), mengunci PDF dengan kata sandi, atau bahkan menentukan bagaimana proses konversi harus berjalan.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan menggunakan opsi konversi kustom, Anda dapat mengatur pengaturan kualitas yang diinginkan untuk gambar raster, menentukan cara penanganan metafile, mengatur tingkat kompresi untuk teks, mengatur DPI untuk gambar, dll.

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

### **Pilih Kompresi Gambar Secara Otomatis**

Ketika sebuah presentasi berisi banyak foto atau tangkapan layar, mengurangi ukuran PDF yang diekspor dapat mempermudah pengiriman email atau pengunduhan. Atur [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) ke `True` untuk secara otomatis memilih algoritma kompresi yang paling sesuai untuk setiap gambar selama ekspor PDF.

Contoh berikut memuat presentasi yang ada, mengaktifkan pemilihan kompresi gambar otomatis, dan menyimpannya sebagai dokumen PDF. Semua pengaturan ekspor PDF lainnya tetap pada nilai default mereka.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Opsi ini memilih algoritma kompresi untuk setiap gambar. Menurunkan [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) justru mengurangi kualitas gambar JPEG, sedangkan menurunkan [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) memungkinkan gambar diturunkan sampelnya ke resolusi lebih rendah, yang dapat mengurangi detail. Mengaktifkan pemilihan kompresi otomatis tidak secara otomatis menurunkan kedua pengaturan ini.

Memilih algoritma kompresi gambar memerlukan waktu pemrosesan dan memori tambahan. Pengurangan ukuran tergantung pada gambar dalam presentasi dan pengaturan ekspor; pengurangan tetap tidak dijamin untuk setiap presentasi.

### **Pertahankan File OLE Tertanam sebagai Lampiran PDF**

Jika sebuah presentasi berisi workbook Excel yang tertanam, Anda mungkin ingin penerima PDF mengakses data workbook tersebut serta melihat slide. Atur [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) ke `True` untuk mempertahankan file OLE yang tertanam sebagai lampiran dalam PDF yang dihasilkan.

Nilai default adalah `False`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file yang tertanam tidak disertakan sebagai lampiran. Mengatur opsi ke `True` secara tambahan menyertakan data file. Pratinjau tetap menjadi representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file tertanam secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Untuk memeriksa hasilnya:

1. Buka PDF yang diekspor dalam penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Lampiran** penampil dan temukan workbook yang tertanam.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil memperbolehkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Note" %}}
Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file tertanam, PDF/A-2 hanya mengizinkan lampiran PDF/A, dan PDF/A-3 mengizinkan tipe file lain, termasuk workbook Excel. Ini merupakan persyaratan standar, bukan pembatasan khusus Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak menunjukkan ekspor PDF/A.
{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan opsi kustom—properti [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—untuk menginstruksikan Aspose.Slides menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Contoh berikut mengekspor presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses memungkinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Tangani Font Tanpa Gaya Bold Khusus**

Sebuah presentasi dapat menerapkan pemformatan tebal pada teks meskipun fontnya tidak memiliki gaya tebal khusus. Teks masih dapat tampak tebal melalui bold sintetis, yang menebalkan glyph reguler secara artifisial. Ketika teks tersebut terlihat terlalu berat atau berbeda dari tampilan yang diinginkan dalam PDF, coba atur [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) ke `True`. Opsi ini merender teks yang terpengaruh sebagai bitmap selama ekspor PDF dan dapat memperbaiki tampilannya untuk font tertentu. Nilai defaultnya adalah `False`.

Contoh presentasi berisi dua kotak teks: satu dengan teks biasa dan satu dengan pemformatan tebal yang diterapkan pada font yang sama, yang tidak memiliki gaya tebal khusus. Contoh berikut memuat presentasi, mengaktifkan rasterisasi gaya font yang tidak didukung, dan mengekspornya ke PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Pratinjau berikut memperlihatkan output yang dinonaktifkan dan yang diaktifkan. Pada contoh ini, teks tebal memiliki goresan lebih berat ketika opsi dinonaktifkan. Dengan opsi diaktifkan, goresannya lebih ringan; teks biasa tidak berubah. Bandingkan hasilnya sebelum memilih pengaturan untuk presentasi Anda.

| Opsi dinonaktifkan (`False`, default) | Opsi diaktifkan (`True`) |
|---|---|
| ![PDF dengan rasterisasi gaya font yang tidak didukung dinonaktifkan](unsupported-bold-disabled.png) | ![PDF dengan rasterisasi gaya font yang tidak didukung diaktifkan](unsupported-bold-enabled.png) |

Pada contoh ini, mengaktifkan opsi mengubah hanya teks tebal menjadi bitmap: teks tersebut tidak dapat dipilih, disalin, atau dicari sebagai teks tanpa OCR, dan tepinya tampak lebih lembut pada zoom 800 %. Teks biasa tetap dapat dicari. Dengan opsi dinonaktifkan, kedua string tetap berupa teks.

Opsi ini meraster teks yang diformat tebal ketika fontnya tidak memiliki gaya tebal khusus. [Substitusi font](/slides/id/python-net/font-substitution/) justru memilih font lain ketika font asli tidak tersedia.

## **Konversi Slide Pilihan di PowerPoint ke PDF**

Contoh berikut mengekspor slide 1 dan 3 dari sebuah presentasi ke PDF. Nomor slide dalam array ini berbasis satu, dan presentasi masukan harus berisi setidaknya tiga slide.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh berikut menyalin slide pertama dari sebuah presentasi ke presentasi baru dengan ukuran slide 612 × 792 poin (8,5 × 11 inci). Ia menskala konten slide agar pas dan mengekspor slide tunggal ke PDF.

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

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

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

{{% alert color="info" title="Note" %}}
Dukungan Aspose.Slides untuk operasi konversi PDF memungkinkan Anda mengonversi PDF ke format file yang paling populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) . Konversi operasi PDF lainnya ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—juga didukung.
{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafis kompleks seperti SmartArt, diagram, dan formula sebagai satu gambar. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan mungkin ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah Aspose.Slides for Python dapat menghapus informasi aplikasi dari PDF?**

Tidak, Aspose.Slides for Python secara otomatis menyertakan informasi API dan nomor versi dalam PDF output. Informasi ini tidak dapat dimodifikasi atau dihapus.

**Bagaimana cara menyertakan hanya slide tertentu dalam konversi PDF?**

Anda dapat menentukan indeks slide yang ingin dikonversi dengan memasukkan array posisi slide ke metode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Apakah memungkinkan melindungi PDF dengan kata sandi selama konversi?**

Ya, Anda dapat mengatur kata sandi dan mendefinisikan izin akses menggunakan kelas [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sebelum menyimpan presentasi sebagai PDF.

**Apakah Aspose.Slides mendukung mengonversi PDF ke format lain?**

Ya, Aspose.Slides mendukung mengonversi PDF ke format seperti HTML, format gambar (JPG, PNG), SVG, TIFF, dan XML.

**Bagaimana saya dapat memastikan PDF saya mematuhi standar aksesibilitas?**

Atur properti [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ke standar seperti `PDF_A1A`, `PDF_A1B`, atau `PDF_UA` untuk memastikan kepatuhan terhadap pedoman aksesibilitas.

**Apakah saya dapat menyertakan slide tersembunyi dalam output PDF?**

Ya, dengan mengatur properti [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ke `True`, slide tersembunyi akan disertakan dalam PDF.

**Bagaimana cara menyesuaikan kualitas dan resolusi gambar selama konversi?**

Gunakan properti [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) dan [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) dalam [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) untuk mengontrol kualitas dan resolusi gambar dalam PDF yang dihasilkan.

**Apakah Aspose.Slides menangani substitusi font secara otomatis?**

Aspose.Slides mendeteksi substitusi font selama konversi, dan Anda dapat menanganinya menggunakan properti `warning_callback` dalam `SaveOptions` (saat ini terbatas).

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk Python via .NET](/slides/id/python-net/)
- [Referensi API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Konverter Online Gratis Aspose](https://products.aspose.app/slides/conversion)