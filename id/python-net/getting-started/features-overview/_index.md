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
- pencetakan
- pemformatan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via .NET: sebuah API kuat untuk membuat, mengedit, mengotomatiskan, dan mengonversi presentasi PowerPoint serta OpenDocument secara efisien."
---
## **Platform yang Didukung**
Platform Aspose.Slides untuk Python via .NET dapat digunakan pada Windows x64 atau x86 dan berbagai distribusi Linux dengan Python 3.5 atau yang lebih baru terpasang. Ada persyaratan tambahan untuk platform Linux target:
- Perpustakaan runtime GCC-6 (atau yang lebih baru)
- Dependensi .NET Core Runtime. Menginstal .NET Core Runtime itu sendiri TIDAK diperlukan
- Untuk Python 3.5-3.7: Build Python dengan `pymalloc` diperlukan. Opsi build Python `--with-pymalloc` diaktifkan secara default. Biasanya, build Python dengan `pymalloc` ditandai dengan akhiran `m` pada nama file.
- `libpython` perpustakaan Python bersama. Opsi build Python `--enable-shared` dinonaktifkan secara default, beberapa distribusi Python tidak menyertakan perpustakaan `libpython` bersama. Untuk beberapa platform Linux, perpustakaan `libpython` bersama dapat diinstal menggunakan manajer paket, misalnya: `sudo apt-get install libpython3.7`. Masalah umum adalah perpustakaan `libpython` diinstal di lokasi berbeda dari lokasi standar sistem untuk perpustaan bersama. Masalah ini dapat diperbaiki dengan menggunakan opsi build Python untuk mengatur jalur perpustakaan alternatif saat mengkompilasi Python, atau diperbaiki dengan membuat tautan simbolik ke file perpustakaan `libpython` di lokasi standar sistem untuk perpustakaan bersama. Biasanya, nama file perpustakaan `libpython` bersama adalah `libpythonX.Ym.so.1.0` untuk Python 3.5-3.7, atau `libpythonX.Y.so.1.0` untuk Python 3.8 atau yang lebih baru (contoh: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Jika Anda memerlukan dukungan untuk lebih banyak platform, cari produk “kembar” Aspose.Slides untuk .NET atau Aspose.Slides untuk Java.

## **Format File dan Konversi**
Aspose.Slides untuk Python via .NET mendukung sebagian besar format dokumen PowerPoint. Ini juga memungkinkan Anda mengekspor mereka ke format populer yang banyak digunakan dan dipertukarkan oleh organisasi. Lihat detail berikut:

|**Fitur**|**Deskripsi**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/id/python-net/ppt-vs-pptx/)|Aspose.Slides untuk Python via .NET menyediakan pemrosesan tercepat untuk format dokumen presentasi ini.|
|[PPT to PPTX conversion](/slides/id/python-net/convert-ppt-to-pptx/)|Aspose.Slides untuk Python via .NET mendukung konversi PPT ke PPTX.|
|[Portable Document Format (PDF)](/slides/id/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Anda dapat mengekspor semua format file yang didukung ke dokumen Adobe Portable Document Format (PDF) dengan satu metode.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/id/python-net/convert-powerpoint-to-xps/)|Anda dapat mengekspor semua format file yang didukung ke dokumen XML Parser Specification (XPS) dengan satu metode.|
|[Tagged Image File Format (TIFF)](/slides/id/python-net/convert-powerpoint-to-tiff/)|Anda dapat mengekspor semua format file presentasi yang didukung ke Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/id/python-net/convert-powerpoint-to-html/)|Aspose.Slides untuk Python via .NET mendukung konversi PresentationEx ke format HTML.|

## **Rendering dan Pencetakan**
Aspose.Slides untuk Python via .NET mendukung rendering fidelity tinggi dari slide dalam dokumen presentasi ke berbagai format grafis. Lihat detail berikut:

|**Fitur**|**Deskripsi**|
| :- | :- |
|.NET Supported Image Formats|Dengan Aspose.Slides untuk Python via .NET, Anda dapat merender slide presentasi dan gambar pada slide ke semua format grafis yang didukung .NET seperti TIFF, PNG, BMP, JPEG, GIF, dan metafile.|
|SVG Format|Aspose.Slides untuk Python via .NET juga menyediakan metode bawaan yang memungkinkan Anda mengekspor slide presentasi ke format Scalable Vector Graphics (SVG).|
|Presentation Printing|Versi terbaru Aspose.Slides untuk Python via .NET menyediakan metode cetak bawaan dengan berbagai opsi.|

## **Fitur Konten**
Aspose.Slides untuk Python via .NET memungkinkan Anda mengakses, memodifikasi, atau membuat hampir semua item atau konten dokumen presentasi. Lihat detail berikut:

|**Fitur**|**Deskripsi**|
| :- | :- |
|Master Slides|Master Slides menentukan tata letak slide normal. Aspose.Slides untuk Python via .NET memungkinkan Anda mengakses dan memodifikasi Master Slides dari dokumen presentasi.|
|Normal Slides|Dengan Aspose.Slides untuk Python via .NET, Anda dapat membuat slide baru dengan berbagai tipe; Anda juga dapat mengakses dan memodifikasi slide yang sudah ada dalam presentasi.|
|Cloning / Copying Slides|Ada metode bawaan yang disediakan oleh Aspose.Slides untuk Python via .NET yang memungkinkan Anda mengkloning atau menyalin slide yang ada dalam presentasi. Anda juga dapat menggunakan slide yang disalin dan dikloning dari satu presentasi ke yang lain. Karena slide mewarisi tata letaknya dari master slide, metode kloning bawaan secara otomatis menyalin master saat mengkloning.|
|Managing Slides sections|Metode untuk mengorganisir slide dalam berbagai bagian di dalam sebuah presentasi.|
|Place Holders and Text Holders|Anda dapat mengakses placeholder dan text holder dalam sebuah slide. Lebih lagi, Anda dapat membuat slide dengan text holder dari awal menggunakan metode yang tepat.|
|Header and Footers|Aspose.Slides untuk Python via .NET memfasilitasi penanganan header/footer dalam slide.|
|Notes in Slides|Dengan Aspose.Slides untuk Python via .NET, Anda dapat mengakses dan memodifikasi catatan yang terkait dengan sebuah slide serta menambahkan catatan baru.|
|Finding a Shape|Anda juga dapat menemukan shape tertentu dari sebuah slide menggunakan teks alternatif yang terkait dengan shape tersebut.|
|Backgrounds|Aspose.Slides untuk Python via .NET memungkinkan Anda bekerja dengan latar belakang yang terkait dengan master atau slide normal dalam sebuah presentasi.|
|Text Boxes|Kotak teks dapat dibuat dari awal. Anda dapat mengakses kotak teks yang sudah ada. Anda juga dapat memodifikasi teksnya tanpa kehilangan format teks asli.|
|Rectangle Shapes|Anda dapat membuat atau memodifikasi shape persegi panjang dengan Aspose.Slides untuk Python via .NET.|
|Poly Line Shapes|Anda dapat membuat atau memodifikasi shape poly line dengan Aspose.Slides untuk Python via .NET.|
|Ellipse Shapes|Anda dapat membuat atau memodifikasi shape elips dengan Aspose.Slides untuk Python via .NET.|
|Group Shapes|Aspose.Slides untuk Python via .NET mendukung group shapes.|
|Auto Shapes|Aspose.Slides untuk Python via .NET mendukung auto shapes.|
|SmartArt|Aspose.Slides untuk Python via .NET menyediakan dukungan untuk shape SmartArt di MS PowerPoint.|
|Charts|Aspose.Slides untuk Python via .NET menyediakan dukungan untuk MSO Charts di PowerPoint.|
|Shapes Serialization|Aspose.Slides untuk Python via .NET mendukung sejumlah besar shape. Ketika Aspose.Slides untuk Python via .NET tidak memiliki dukungan untuk suatu shape, Anda dapat menggunakan metode serialisasi melalui mana Anda dapat menseralisasi shape tersebut dari slide yang ada. Dengan cara ini, Anda dapat menggunakan shape tersebut lebih lanjut sesuai kebutuhan Anda.|
|Picture Frames|Anda dapat mengelola gambar dalam picture frames dengan Aspose.Slides untuk Python via .NET.|
|Audio Frames|Anda dapat menautkan atau menyematkan file audio dalam audio frames pada slide dengan Aspose.Slides untuk Python via .NET.|
|Video Frames|Anda dapat menangani file video dalam video frames. Aspose.Slides untuk Python via .NET juga menyediakan dukungan untuk video yang ditautkan dan disematkan.|
|OLE Frame|Anda dapat mengelola OLE Objects dalam OLE frames dengan Aspose.Slides untuk Python via .NET.|
|Tables|Aspose.Slides untuk Python via .NET mendukung tabel dalam slide.|
|ActiveX Controls|Dukungan untuk kontrol ActiveX.|
|VBA Macros|Dukungan untuk mengelola VBA macros di dalam presentasi.|
|Text Frame|Anda dapat mengakses teks pada shape apa pun melalui text frame yang terkait dengan shape tersebut.|
|Text Scanning|Anda dapat memindai teks dalam presentasi pada tingkat presentasi atau slide melalui metode pemindaian bawaan.|
|Animations|Anda dapat menerapkan animasi pada shape.|
|Slide Shows|Aspose.Slides untuk Python via .NET mendukung slide show dan transisi slide.|

## **Fitur Pemformatan**
Dengan Aspose.Slides untuk Python via .NET, Anda dapat memformat teks dan shape pada slide dalam presentasi. Lihat detail berikut:

|**Fitur**|**Deskripsi**|
| :- | :- |
|Text Formatting|<p>Dalam Aspose.Slides untuk Python via .NET, Anda dapat mengelola teks melalui text frame yang terkait dengan shape. Oleh karena itu, Anda dapat memformat teks menggunakan paragraf dan bagian yang terkait dengan text frame. Elemen teks ini dapat diformat melalui Aspose.Slides untuk Python via .NET.</p><p>- Jenis Font</p><p>- Ukuran Font</p><p>- Warna Font</p><p>- Nada Font</p><p>- Penjajaran Paragraf</p><p>- Penomoran Paragraf</p><p>- Orientasi Paragraf</p>|
|Shape Formatting|<p>Dalam Aspose.Slides untuk Python via .NET, elemen dasar sebuah slide adalah shape. Anda dapat memformat elemen shape ini dengan Aspose.Slides untuk Python via .NET:</p><p>- Posisi</p><p>- Ukuran</p><p>- Garis</p><p>- Isi (termasuk Pola, Gradasi, Solid)</p><p>- Teks</p><p>- Gambar</p>|

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint di server/PC agar perpustakaan berfungsi?**

Tidak. PowerPoint tidak diperlukan; Aspose.Slides adalah mesin mandiri untuk membuat, mengedit, mengkonversi, dan merender presentasi.

**Bagaimana cara kerja multithreading? Apakah pemrosesan dapat diparalelkan?**

Aman untuk memproses dokumen yang berbeda dalam thread yang berbeda; objek [presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang sama tidak boleh digunakan oleh [multiple threads](/slides/id/python-net/multithreading/) secara bersamaan.

**Apakah kata sandi file dan enkripsi didukung?**

Ya. [Anda dapat](/slides/id/python-net/password-protected-presentation/) membuka presentasi yang terenkripsi, mengatur atau menghapus kata sandi buka dan tulis, serta memeriksa status perlindungan.

**Apakah saya perlu memperhatikan paket font di kontainer Linux?**

Ya. Disarankan untuk menginstal paket font umum dan/atau secara eksplisit [menentukan direktori font](/slides/id/python-net/custom-font/) dalam aplikasi Anda untuk menghindari substitusi yang tidak terduga.

**Apakah ada keterbatasan dalam versi evaluasi?**

Dalam [mode evaluasi](/slides/id/python-net/licensing/), watermark ditambahkan pada output dan beberapa batasan diterapkan; [lisensi sementara 30 hari](https://purchase.aspose.com/temporary-license/) tersedia untuk pengujian semua fitur.

**Apakah mengimpor format eksternal ke dalam presentasi (PDF/HTML → PPTX) didukung?**

Ya. Anda dapat menambahkan [halaman PDF dan konten HTML](/slides/id/python-net/import-presentation/) ke presentasi, mengubahnya menjadi slide.