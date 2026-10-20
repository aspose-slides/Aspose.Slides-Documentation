---
title: Konversi PPT dan PPTX ke PDF dalam Python via Java [Fitur Lanjutan Termasuk]
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
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari dalam Python via Java menggunakan Aspose.Slides, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam Python via Java menawarkan beberapa kelebihan, termasuk kompatibilitas antar perangkat dan preservasi tata letak serta format presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen hasil.

## **Konversi PowerPoint ke PDF**

Dengan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi sebuah presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) mengekspos metode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk Python via Java menyisipkan informasi API dan nomor versi ke dalam dokumen output. Misalnya, saat mengonversi sebuah presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.
{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiperteks
* Header dan footer
* Bullet
* Tabel

## **Konversi PowerPoint ke PDF**

Konversi standar menggunakan pengaturan ekspor PDF default. Gunakan opsi khusus ketika Anda perlu mengontrol kualitas gambar, konten halaman, atau kepatuhan PDF.

Contoh berikut memuat sebuah presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

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
Aspose menyediakan [**konverter PowerPoint ke PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratis secara online yang memperlihatkan proses konversi presentasi ke PDF. Anda dapat melakukan pengujian dengan konverter ini untuk implementasi langsung dari prosedur yang dijelaskan di sini.
{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—untuk memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus dijalankan.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas pilihan untuk gambar raster, menentukan bagaimana metafile harus diproses, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lainnya.

Contoh berikut mengekspor sebuah presentasi ke PDF 1.5 dengan kualitas JPEG diatur ke 90, resolusi gambar diatur ke 300 DPI, metafile disimpan sebagai PNG, dan kompresi teks Flate.

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

### **Pemilihan Kompresi Gambar Secara Otomatis**

Ketika sebuah presentasi berisi banyak foto atau tangkapan layar, mengurangi ukuran PDF yang diekspor dapat memudahkan pengiriman email atau pengunduhan. Panggil [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) dengan `True` untuk secara otomatis memilih algoritma kompresi yang paling sesuai untuk setiap gambar selama ekspor PDF.

Contoh berikut memuat presentasi yang ada, mengaktifkan pemilihan kompresi gambar otomatis, dan menyimpannya sebagai dokumen PDF. Semua pengaturan ekspor PDF lainnya tetap pada nilai default.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Opsi ini memilih algoritma kompresi untuk setiap gambar. Menurunkan nilai yang diberikan ke [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) mengurangi kualitas gambar JPEG, sementara menurunkan nilai yang diberikan ke [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) memungkinkan gambar diturunkan ke resolusi yang lebih rendah, yang dapat mengurangi detail. Mengaktifkan pemilihan kompresi otomatis tidak secara otomatis menurunkan salah satu pengaturan ini.

Memilih algoritma kompresi gambar memerlukan waktu pemrosesan dan memori tambahan. Pengurangan ukuran tergantung pada gambar dalam presentasi dan pengaturan ekspor; pengurangan yang tetap tidak dijamin untuk setiap presentasi.

### **Pertahankan File OLE Tersemat sebagai Lampiran PDF**

Jika sebuah presentasi berisi workbook Excel tersemat, Anda mungkin ingin penerima PDF dapat mengakses data workbook tersebut serta melihat slide. Panggil [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) dengan `True` untuk mempertahankan file OLE tersemat sebagai lampiran dalam PDF yang dihasilkan.

Nilai default adalah `False`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file tersematnya tidak disertakan sebagai lampiran. Mengatur opsi ke `True` menambahkan data file. Pratinjau tetap menjadi representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file tersemat secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat presentasi yang sudah berisi workbook Excel tersemat dan mengekspornya ke PDF dengan workbook terlampir.

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

1. Buka PDF yang diekspor dalam penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Attachments** pada penampil dan temukan workbook yang tersemat.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil mengizinkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Note" %}}
Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file tersemat, PDF/A-2 hanya mengizinkan lampiran PDF/A, dan PDF/A-3 mengizinkan tipe file lain, termasuk workbook Excel. Ini adalah persyaratan standar, bukan pembatasan khusus pada Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak mendemonstrasikan ekspor PDF/A.
{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) dari kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

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

Contoh berikut mengekspor sebuah presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses memperbolehkan pencetakan, termasuk pencetakan berkualitas tinggi.

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

Aspose.Slides menyediakan metode [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) dalam kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) yang memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Contoh berikut mengekspor sebuah presentasi ke PDF dan mencetak peringatan substitusi font ke konsol. Peringatan dicetak hanya ketika sebuah font yang tidak tersedia disubstitusi selama ekspor. Gunakan proxy JPype untuk menerima callback peringatan dari API Java. Konversi string deskripsi Java ke string Python sebelum memeriksa awalan:

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

### **Menangani Font Tanpa Gaya Tebal Khusus**

Suatu presentasi dapat menerapkan pemformatan tebal pada teks meskipun fontnya tidak memiliki gaya tebal khusus. Teks masih dapat tampil tebal melalui bold sintetis, yang secara artifisial menebalkan glif regular. Ketika teks tersebut terlihat terlalu berat atau berbeda dari tampilan yang diinginkan dalam PDF, coba panggil [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) dengan `True`. Opsi ini merender teks yang terpengaruh sebagai bitmap selama ekspor PDF dan dapat meningkatkan penampilannya untuk font tertentu. Nilai defaultnya adalah `False`.

Presentasi contoh berisi dua kotak teks: satu dengan teks biasa dan satu lagi dengan pemformatan tebal yang diterapkan pada font yang sama, yang tidak memiliki gaya tebal khusus. Contoh berikut memuat presentasi, mengaktifkan rasterisasi gaya font yang tidak didukung, dan mengekspornya ke PDF:

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

Pratinjau berikut menunjukkan output dengan opsi dinonaktifkan dan output dengan opsi diaktifkan. Dalam contoh ini, teks tebal memiliki goresan lebih berat ketika opsi dinonaktifkan. Dengan opsi diaktifkan, goresannya lebih ringan; teks biasa tidak berubah. Bandingkan hasil sebelum memilih pengaturan untuk presentasi Anda.

| Opsi dinonaktifkan (`False`, default) | Opsi diaktifkan (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dalam contoh ini, mengaktifkan opsi mengubah hanya teks tebal menjadi bitmap: teks tersebut tidak dapat dipilih, disalin, atau dicari sebagai teks tanpa OCR, dan tepinya terlihat lebih lembut pada zoom 800%. Teks biasa tetap dapat dicari. Dengan opsi dinonaktifkan, kedua string tetap berupa teks.

Opsi ini merasterisasi teks yang diformat tebal ketika fontnya tidak memiliki gaya tebal khusus. [Font substitution](/slides/id/python-java/font-substitution/) justru memilih font lain ketika font asli tidak tersedia.

## **Konversi Slide Terpilih dari PowerPoint ke PDF**

Nomor slide yang diberikan ke [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) bersifat bermula dari 1. Contoh ini mengekspor slide 1 dan 3 ketika keduanya ada:

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

Contoh ini mengekspor slide pertama pada halaman berukuran 612 x 792 poin (US Letter). Ia mengkloning slide ke dalam presentasi baru dengan ukuran yang ditentukan dan menskalakan konten slide agar pas.

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

    # Hapus slide kosong yang dibuat bersama presentasi baru.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Konversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Contoh berikut mengekspor sebuah presentasi ke PDF, menempatkan catatan pembicara masing-masing slide di bawah slide. Gunakan presentasi yang berisi catatan pembicara untuk melihat hasilnya.

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

Untuk menyiapkan PDF yang dapat diakses, konsultasikan [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Gunakan [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) untuk memilih standar output: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode ini mendemonstrasikan proses konversi PowerPoint ke PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

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

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafis kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar tunggal. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk keseluruhan gambar.

## **FAQ**

**Apakah saya dapat mengonversi beberapa file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch beberapa file PPT atau PPTX ke PDF. Anda dapat mengiterasi file Anda dan menerapkan proses konversi secara programatis.

**Apakah memungkinkan melindungi PDF yang dikonversi dengan kata sandi?**

Ya. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) untuk mengatur kata sandi dan menentukan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Panggil [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) dengan `True` dalam kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) dan [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) dalam kelas [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi [berbagai standar](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), termasuk PDF/A1a, PDF/A1b, dan PDF/UA, untuk aksesibilitas atau pengarsipan. Pilih standar yang sesuai dan tinjau output sesuai kebutuhan Anda.

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk Python via Java](/slides/id/python-java/)
- [Referensi API Aspose.Slides untuk Python via Java](https://reference.aspose.com/slides/python-java/)
- [Konverter Online Gratis Aspose](https://products.aspose.app/slides/conversion)