---
title: Konversi PPT dan PPTX ke PDF di Python via Java [Fitur Lanjutan Disertakan]
linktitle: PowerPoint ke PDF
type: docs
weight: 40
url: /id/python-java/convert-powerpoint-to-pdf/
keywords:
- konversi PowerPoint
- konversi presentasi
- PowerPoint ke PDF
- presentasi ke PDF
- PPT ke PDF
- konversi PPT ke PDF
- PPTX ke PDF
- konversi PPTX ke PDF
- simpan PowerPoint sebagai PDF
- simpan PPT sebagai PDF
- simpan PPTX sebagai PDF
- ekspor PPT ke PDF
- ekspor PPTX ke PDF
- lampiran
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari di Python via Java menggunakan Aspose.Slides, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam Python melalui Java menawarkan beberapa keuntungan, termasuk kompatibilitas lintas perangkat dan pelestarian tata letak serta format presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi file PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Dengan menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) menyediakan metode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java menyisipkan informasi API dan nomor versinya ke dalam dokumen output. Sebagai contoh, ketika mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.
{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi aslinya. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan
* Header dan footer
* Bullet
* Tabel

## **Konversi PowerPoint ke PDF**

Konversi standar menggunakan pengaturan ekspor PDF default. Gunakan opsi khusus ketika Anda perlu mengontrol kualitas gambar, konten halaman, atau kepatuhan PDF.

Instal [Aspose.Slides for Python via Java](/slides/id/python-java/installation/) dan runtime Java yang kompatibel sebelum menjalankan contoh. Setiap contoh membaca `presentation.pptx` dari direktori kerja saat ini; ganti dengan file PPT, PPTX, atau ODP Anda. Mulai JVM sekali per proses Python.

Contoh berikut memuat presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose menawarkan [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratis secara daring yang mendemonstrasikan proses konversi presentasi ke PDF. Anda dapat menjalankan pengujian dengan konverter ini untuk implementasi langsung prosedur yang dijelaskan di sini.
{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus berjalan.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan menggunakan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas yang diinginkan untuk gambar raster, menentukan cara penanganan metafile, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lainnya.

Contoh berikut mengekspor presentasi ke PDF 1.5 dengan kualitas JPEG diatur ke 90, resolusi gambar diatur ke 300 DPI, metafile disimpan sebagai PNG, dan kompresi teks Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Pertahankan File OLE Tersemat sebagai Lampiran PDF**

Jika sebuah presentasi berisi buku kerja Excel tersemat, Anda mungkin ingin penerima PDF dapat mengakses data buku kerja tersebut serta melihat slide. Panggil [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) dengan `True` untuk mempertahankan file OLE tersemat sebagai lampiran dalam PDF yang dihasilkan.

Nilai default adalah `False`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file tersemat tidak disertakan sebagai lampiran. Mengatur opsi menjadi `True` juga menyertakan data file. Pratinjau tetap menjadi representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file tersemat secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat presentasi yang sudah berisi buku kerja Excel tersemat dan mengekspornya ke PDF dengan buku kerja terlampir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Untuk memeriksa hasilnya:

1. Buka PDF yang diekspor pada penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Attachments** penampil dan temukan buku kerja yang tersemat.
3. Simpan lampiran dan bukalah di Excel untuk memeriksa datanya, atau buka langsung jika penampil mengizinkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Note" %}}
Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file tersemat, PDF/A-2 hanya mengizinkan lampiran PDF/A, dan PDF/A-3 mengizinkan tipe file lain, termasuk buku kerja Excel. Ini adalah persyaratan standar, bukan pembatasan khusus Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak mendemonstrasikan ekspor PDF/A.
{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) dari kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Contoh berikut mengekspor presentasi ke PDF, termasuk semua slide tersembunyi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Contoh berikut mengekspor presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses memungkinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Deteksi Substitusi Font**

Aspose.Slides menyediakan metode [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) pada kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) yang memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Contoh berikut mengekspor presentasi ke PDF dan mencetak peringatan substitusi font ke konsol. Peringatan dicetak hanya ketika font yang tidak tersedia digantikan selama ekspor. Gunakan proxy JPype untuk menerima panggilan balik peringatan dari API Java. Konversi string deskripsi Java ke string Python sebelum memeriksa prefiksnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Font Substitution](/slides/id/python-java/font-substitution/).
{{% /alert %}}

### **Tangani Font Tanpa Gaya Tebal Khusus**

Sebuah presentasi dapat menerapkan pemformatan tebal pada teks meskipun fontnya tidak memiliki gaya tebal khusus. Teks masih dapat muncul tebal melalui bold sintetis, yang menebalkan glyph reguler secara artifisial. Ketika teks tersebut terlihat terlalu berat atau berbeda dari tampilan yang diinginkan dalam PDF, coba panggil [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) dengan `True`. Opsi ini merender teks yang terpengaruh sebagai bitmap selama ekspor PDF dan dapat memperbaiki penampilannya untuk font tertentu. Nilai defaultnya adalah `False`.

Presentasi contoh berisi dua kotak teks: satu dengan teks biasa dan satu dengan pemformatan tebal yang diterapkan pada font yang sama, yang tidak memiliki gaya tebal khusus. Contoh berikut memuat presentasi, mengaktifkan rasterisasi gaya font yang tidak didukung, dan mengekspornya ke PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Pratinjau berikut menunjukkan output dengan opsi dinonaktifkan dan diaktifkan. Dalam contoh ini, teks tebal memiliki goresan yang lebih tebal saat opsi dinonaktifkan. Dengan opsi diaktifkan, goresannya lebih ringan; teks biasa tidak berubah. Bandingkan hasilnya sebelum memilih pengaturan untuk presentasi Anda.

| Opsi dinonaktifkan (`False`, default) | Opsi diaktifkan (`True`) |
|---|---|
| ![PDF dengan rasterisasi gaya font tidak didukung dinonaktifkan](unsupported-bold-disabled.png) | ![PDF dengan rasterisasi gaya font tidak didukung diaktifkan](unsupported-bold-enabled.png) |

Dalam contoh ini, mengaktifkan opsi mengubah hanya teks tebal menjadi bitmap: teks tidak dapat dipilih, disalin, atau dicari sebagai teks tanpa OCR, dan tepinya tampak lebih halus pada zoom 800%. Teks biasa tetap dapat dicari. Dengan opsi dinonaktifkan, kedua string tetap berupa teks.

Opsi ini meraster teks yang diformat sebagai tebal ketika fontnya tidak memiliki gaya tebal khusus. [Font substitution](/slides/id/python-java/font-substitution/) justru memilih font lain ketika font asli tidak tersedia.

## **Konversi Slide Terpilih dari PowerPoint ke PDF**

Nomor slide yang diberikan ke [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) bersifat 1-based. Contoh ini mengekspor slide 1 dan 3 bila keduanya ada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh ini mengekspor slide pertama pada halaman berukuran 612 x 792 poin (US Letter). Ia menyalin slide ke presentasi baru dengan ukuran yang ditentukan dan menskalakan konten slide agar pas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Hapus slide kosong yang dibuat saat presentasi baru dibuat.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Konversi PowerPoint ke PDF dalam Tampilan Catatan Slide**

Contoh berikut mengekspor presentasi ke PDF, menempatkan catatan pembicara masing‑masing slide di bawah slide. Gunakan presentasi yang berisi catatan pembicara untuk melihat hasilnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

Ketika menyiapkan PDF yang dapat diakses, konsultasikan [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Gunakan [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) untuk memilih standar output: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode ini menunjukkan proses konversi PowerPoint ke PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan mungkin ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah saya dapat mengonversi banyak file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat melakukan iterasi melalui file Anda dan menerapkan proses konversi secara programatis.

**Apakah memungkinkan melindungi PDF yang dikonversi dengan kata sandi?**

Ya. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) untuk menetapkan kata sandi dan mendefinisikan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Panggil [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) dengan `True` pada kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) dan [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) pada kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi [berbagai standar](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), termasuk PDF/A1a, PDF/A1b, dan PDF/UA, untuk aksesibilitas atau pengarsipan. Pilih standar yang sesuai dan tinjau outputnya terhadap kebutuhan Anda.

## **Sumber Daya Tambahan**

- [Aspose.Slides for Python via Java Documentation](/slides/id/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)