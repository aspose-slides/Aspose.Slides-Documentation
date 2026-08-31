---
title: Ikhtisar Fitur
type: docs
weight: 20
url: /id/python-net/features-overview/
keywords:
- fitur
- platform yang didukung
- format file
- konversi
- rendering
- pemformatan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Temukan Aspose.Slides for Python via .NET: API kuat untuk membuat, mengedit, mengotomatiskan, dan mengonversi presentasi PowerPoint serta OpenDocument dengan efisien."
---
## **Platform yang Didukung**
Platform Aspose.Slides for Python via .NET dapat digunakan di Windows x64 atau x86 serta berbagai distribusi Linux dengan Python 3.5 atau yang lebih baru terpasang. Ada persyaratan tambahan untuk platform Linux target:

- Perpustakaan runtime GCC-6 (atau lebih baru)
- Ketergantungan .NET Core Runtime. Menginstal .NET Core Runtime itu sendiri TIDAK diperlukan
- Untuk Python 3.5-3.7: Build Python dengan `pymalloc` diperlukan. Opsi build Python `--with-pymalloc` diaktifkan secara default. Biasanya, build `pymalloc` Python ditandai dengan akhiran `m` pada nama file.
- Perpustakaan Python bersama `libpython`. Opsi build Python `--enable-shared` dinonaktifkan secara default, beberapa distribusi Python tidak menyertakan perpustakaan bersama `libpython`. Untuk beberapa platform Linux, perpustakaan `libpython` dapat dipasang menggunakan manajer paket, misalnya: `sudo apt-get install libpython3.7`. Masalah umum adalah perpustakaan `libpython` diinstal di lokasi yang berbeda dari lokasi standar sistem untuk perpustakaan bersama. Masalah ini dapat diperbaiki dengan menggunakan opsi build Python untuk mengatur jalur perpustakaan alternatif saat mengompilasi Python, atau dengan membuat tautan simbolik ke file perpustakaan `libpython` di lokasi standar sistem untuk perpustakaan bersama. Biasanya, nama file perpustakaan bersama `libpython` adalah `libpythonX.Ym.so.1.0` untuk Python 3.5-3.7, atau `libpythonX.Y.so.1.0` untuk Python 3.8 atau yang lebih baru (contoh: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Jika Anda membutuhkan dukungan untuk lebih banyak platform, carilah produk “saudara kembar” Aspose.Slides for .NET atau Aspose.Slides for Java.

## **Format File dan Konversi**
Aspose.Slides for Python via .NET mendukung sebagian besar format dokumen PowerPoint. Ini juga memungkinkan Anda mengekspornya ke format populer yang banyak digunakan dan dipertukarkan oleh organisasi. Lihat detail berikut:

|**Fitur**|**Deskripsi**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/id/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET menyediakan pemrosesan tercepat untuk format dokumen presentasi ini.|
|[PPT to PPTX conversion](/slides/id/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET mendukung konversi PPT ke PPTX.|
|[Portable Document Format (PDF)](/slides/id/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Anda dapat mengekspor semua format file yang didukung ke dokumen Adobe Portable Document Format (PDF) dengan satu metode.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/id/python-net/convert-powerpoint-to-xps/)|Anda dapat mengekspor semua format file yang didukung ke dokumen XML Parser Specification (XPS) dengan satu metode.|
|[Tagged Image File Format (TIFF)](/slides/id/python-net/convert-powerpoint-to-tiff/)|Anda dapat mengekspor semua format file presentasi yang didukung ke Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/id/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET mendukung konversi PresentationEx ke format HTML.|

## **Rendering Presentasi**
Aspose.Slides for Python via .NET mendukung rendering dengan fidelitas tinggi dari slide dalam dokumen presentasi ke berbagai format grafis. Lihat detail berikut:

|**Fitur**|**Deskripsi**|
| :- | :- |
|Format Gambar yang Didukung .NET|Dengan Aspose.Slides for Python via .NET, Anda dapat merender slide presentasi dan gambar pada slide ke semua format grafis yang didukung .NET seperti TIFF, PNG, BMP, JPEG, GIF, dan metafile.|
|Format SVG|Aspose.Slides for Python via .NET juga menyediakan metode bawaan yang memungkinkan Anda mengekspor slide presentasi ke format Scalable Vector Graphics (SVG).|

## **Fitur Konten**
Aspose.Slides for Python via .NET memungkinkan Anda mengakses, memodifikasi, atau membuat hampir semua item atau konten dokumen presentasi. Lihat detail berikut:

|**Fitur**|**Deskripsi**|
| :- | :- |
|Slide Master|Slide Master menentukan tata letak slide normal. Aspose.Slides for Python via .NET memungkinkan Anda mengakses dan memodifikasi Slide Master dari dokumen presentasi|
|Slide Normal|Dengan Aspose.Slides for Python via .NET, Anda dapat membuat slide baru dengan berbagai tipe; Anda juga dapat mengakses dan memodifikasi slide yang ada dalam presentasi|
|Menggandakan / Menyalin Slide|Ada metode bawaan yang disediakan oleh Aspose.Slides for Python via .NET yang memungkinkan Anda menggandakan atau menyalin slide yang ada dalam sebuah presentasi. Anda juga dapat menggunakan slide yang disalin atau digandakan dari satu presentasi ke presentasi lain. Karena sebuah slide mewarisi tata letaknya dari slide master, metode penggandaan bawaan secara otomatis menyalin master saat menggandakan|
|Mengelola Bagian Slide|Metode untuk mengatur slide dalam berbagai bagian di dalam sebuah presentasi|
|Placeholder dan Placeholder Teks|Anda dapat mengakses placeholder dan placeholder teks dalam sebuah slide. Selain itu, Anda dapat membuat slide dengan placeholder teks dari awal menggunakan metode yang sesuai|
|Header dan Footer|Aspose.Slides for Python via .NET mempermudah penanganan header/footer di slide|
|Catatan pada Slide|Dengan Aspose.Slides for Python via .NET, Anda dapat mengakses dan memodifikasi catatan yang terkait dengan slide serta menambahkan catatan baru|
|Mencari Bentuk|Anda juga dapat menemukan bentuk tertentu dari sebuah slide menggunakan teks alternatif yang terkait dengan bentuk tersebut|
|Latar Belakang|Aspose.Slides for Python via .NET memungkinkan Anda bekerja dengan latar belakang yang terkait dengan slide master atau slide normal dalam sebuah presentasi|
|Kotak Teks|Kotak teks dapat dibuat dari awal. Anda dapat mengakses kotak teks yang ada. Anda juga dapat memodifikasi teksnya tanpa kehilangan format teks asli|
|Bentuk Persegi Panjang|Anda dapat membuat atau memodifikasi bentuk persegi panjang dengan Aspose.Slides for Python via .NET|
|Bentuk Garis Poly|Anda dapat membuat atau memodifikasi bentuk garis poly dengan Aspose.Slides for Python via .NET|
|Bentuk Elips|Anda dapat membuat atau memodifikasi bentuk elips dengan Aspose.Slides for Python via .NET|
|Bentuk Grup|Aspose.Slides for Python via .NET mendukung bentuk grup|
|Auto Shapes|Aspose.Slides for Python via .NET mendukung auto shapes|
|SmartArt|Aspose.Slides for Python via .NET menyediakan dukungan untuk bentuk SmartArt di MS PowerPoint|
|Charts|Aspose.Slides for Python via .NET menyediakan dukungan untuk MSO Charts di PowerPoint|
|Serialisasi Bentuk| Aspose.Slides for Python via .NET mendukung banyak bentuk. Ketika Aspose.Slides for Python via .NET tidak mendukung suatu bentuk, Anda dapat menggunakan metode serialisasi untuk men-serialisasi bentuk tersebut dari slide yang ada. Dengan cara ini, Anda dapat menggunakan bentuk tersebut lebih lanjut sesuai kebutuhan Anda |
|Frame Gambar|Anda dapat mengelola gambar dalam frame gambar dengan Aspose.Slides for Python via .NET|
|Frame Audio|Anda dapat menautkan atau menyematkan file audio dalam frame audio pada slide dengan Aspose.Slides for Python via .NET|
|Frame Video|Anda dapat menangani file video dalam frame video. Aspose.Slides for Python via .NET juga menyediakan dukungan untuk video yang ditautkan dan disematkan|
|Frame OLE|Anda dapat mengelola OLE Objects dalam frame OLE dengan Aspose.Slides for Python via .NET|
|Tables|Aspose.Slides for Python via .NET mendukung tabel di slide|
|Kontrol ActiveX|Mendukung kontrol ActiveX|
|Makro VBA|Mendukung pengelolaan makro VBA di dalam presentasi|
|Frame Teks|Anda dapat mengakses teks pada bentuk apa pun melalui frame teks yang terkait dengan bentuk tersebut|
|Pemindaian Teks|Anda dapat memindai teks dalam sebuah presentasi pada tingkat presentasi atau slide melalui metode pemindaian bawaan|
|Animasi|Anda dapat menerapkan animasi pada bentuk|
|Slide Shows|Aspose.Slides for Python via .NET mendukung pertunjukan slide dan transisi slide|

## **Fitur Pemformatan**
Dengan Aspose.Slides for Python via .NET, Anda dapat memformat teks dan bentuk pada slide dalam presentasi. Lihat detail berikut:

|**Fitur**|**Deskripsi**|
| :- | :- |
|Pemformatan Teks|<p>Di Aspose.Slides for Python via .NET, Anda dapat mengelola teks melalui frame teks yang terkait dengan bentuk. Oleh karena itu, Anda dapat memformat teks menggunakan paragraf dan bagian yang terkait dengan frame teks. Elemen teks ini dapat diformat melalui Aspose.Slides for Python via .NET.</p><p>- Jenis Font</p><p>- Ukuran Font</p><p>- Warna Font</p><p>- Nuansa Font</p><p>- Penjajaran Paragraf</p><p>- Penomoran Paragraf</p><p>- Orientasi Paragraf</p>|
|Pemformatan Bentuk|<p>Di Aspose.Slides for Python via .NET, elemen dasar slide adalah sebuah bentuk. Anda dapat memformat elemen bentuk ini dengan Aspose.Slides for Python via .NET:</p><p>- Posisi</p><p>- Ukuran</p><p>- Garis</p><p>- Isi (termasuk Pola, Gradasi, Solid)</p><p>- Teks</p><p>- Gambar</p>|

## **FAQ**

### Apakah saya perlu menginstal Microsoft PowerPoint di server/PC agar pustaka dapat berfungsi?
Tidak. PowerPoint tidak diperlukan; Aspose.Slides adalah mesin mandiri untuk membuat, mengedit, mengonversi, dan merender presentasi.

### Bagaimana cara kerja multithreading? Apakah pemrosesan dapat diparalelkan?
Aman untuk memproses dokumen yang berbeda di thread yang berbeda; objek [presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang sama tidak boleh digunakan oleh [multiple threads](/slides/id/python-net/multithreading/) secara bersamaan.

### Apakah kata sandi file dan enkripsi didukung?
Ya. [Anda dapat](/slides/id/python-net/password-protected-presentation/) membuka presentasi yang dienkripsi, mengatur atau menghapus kata sandi buka dan tulis, serta memeriksa status perlindungan.

### Apakah saya perlu memperhatikan paket font di kontainer Linux?
Ya. Disarankan untuk menginstal paket font umum dan/atau secara eksplisit [specify font directories](/slides/id/python-net/custom-font/) dalam aplikasi Anda untuk menghindari substitusi yang tidak diharapkan.

### Apakah ada batasan dalam versi evaluasi?
Dalam [evaluation mode](/slides/id/python-net/licensing/), sebuah watermark ditambahkan pada output dan beberapa batasan berlaku; sebuah [30-day temporary license](https://purchase.aspose.com/temporary-license/) tersedia untuk pengujian fitur lengkap.

### Apakah mengimpor format eksternal ke dalam presentasi (PDF/HTML → PPTX) didukung?
Ya. Anda dapat menambahkan [PDF pages and HTML content](/slides/id/python-net/import-presentation/) ke presentasi, mengubahnya menjadi slide.