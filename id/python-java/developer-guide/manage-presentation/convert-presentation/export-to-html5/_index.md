---
title: Mengonversi Presentasi ke HTML5 di Python via Java
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/python-java/export-to-html5/
keywords:
- PowerPoint ke HTML5
- OpenDocument ke HTML5
- presentasi ke HTML5
- slide ke HTML5
- PPT ke HTML5
- PPTX ke HTML5
- ODP ke HTML5
- simpan PPT sebagai HTML5
- simpan PPTX sebagai HTML5
- simpan ODP sebagai HTML5
- ekspor PPT ke HTML5
- ekspor PPTX ke HTML5
- ekspor ODP ke HTML5
- Python
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Python via Java. Pertahankan pemformatan, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides untuk Python via Java. Artikel ini mencakup ekspor dasar, kontrol animasi bentuk dan transisi slide, serta tata letak komentar. Selain itu, artikel ini membandingkan output HTML5 dengan output berbasis SVG dari ekspor HTML standar.

Contoh-contoh memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Tempatkan presentasi masukan di direktori kerja saat ini. Setiap contoh memulai JVM hanya jika belum berjalan.

## **Ekspor PowerPoint ke HTML5**

Contoh berikut memuat presentasi dari direktori kerja dan menyimpannya dalam format HTML5. Contoh ini menggunakan pengaturan ekspor default; contoh berikutnya menunjukkan cara mengendalikan pemutaran animasi secara eksplisit. Ganti jalur masukan dengan jalur ke presentasi Anda.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Selain dokumen HTML, ekspor menulis file CSS dan JavaScript pendukung untuk styling slide, animasi, efek, dan navigasi. Simpan file-file ini bersama dokumen HTML saat memindahkan atau mempublikasikan output. Halaman yang dihasilkan juga memuat jQuery dan Anime.js dari CDN publik; tanpa mereka, navigasi slide dan animasi tidak berjalan.
{{% /alert %}}

Untuk mengekspor tanpa memutar animasi bentuk atau transisi slide, berikan `False` ke [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) dan [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) di [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Pengaturan ini independen, sehingga Anda dapat mengaktifkan satu sementara menonaktifkan yang lain. Contoh ini mengekspor presentasi dengan kedua jenis animasi dinonaktifkan pada halaman yang dihasilkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Ekspor PowerPoint ke HTML**

Ekspor HTML standar menggunakan pendekatan rendering yang berbeda: konten slide direpresentasikan sebagai SVG di dalam halaman HTML. Contoh berikut mengonversi presentasi menjadi dokumen HTML menggunakan pendekatan rendering ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Markup sederhana di bawah ini menggambarkan struktur halaman yang dihasilkan. Elemen SVG berisi konten slide yang dirender; teks placeholder mewakili konten tersebut dan bukan output ekspor sebenarnya.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Ekspor berbasis SVG tidak mengekspos bentuk PowerPoint sebagai elemen HTML terpisah. Gunakan ekspor HTML5 ketika Anda membutuhkan opsi animasi bentuk dan transisi slide yang ditunjukkan dalam artikel ini.
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

Ekspor HTML5 menghasilkan halaman untuk melihat dan menavigasi slide presentasi dalam peramban. Contoh ini mengaktifkan kedua [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) dan [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) sehingga tampilan slide yang diekspor dapat memutar efek dari presentasi sumber.

Gunakan presentasi yang sudah berisi animasi bentuk dan transisi slide untuk melihat efek dari pengaturan ini. Mengaktifkannya tidak menambah efek baru pada slide yang tidak memilikinya. Setelah ekspor, buka dokumen HTML5 yang dihasilkan di peramban dengan file pendukung yang tersedia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Konversi Presentasi ke Dokumen HTML5 dengan Komentar**

Anda dapat menyertakan komentar slide yang ada dalam output HTML5 sehingga pembaca dapat melihat umpan balik bersamaan dengan konten slide. Contoh dalam bagian ini mengharapkan presentasi sumber berisi komentar, seperti yang ditunjukkan di bawah. Itu mengekspor komentar tersebut; tidak membuat yang baru.

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Berikan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) ke metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) dari [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Gunakan [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) untuk memilih `Right` dari enumerasi [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) guna menempatkan komentar di sebelah kanan setiap slide.

Contoh berikut mengekspor presentasi ke HTML5 dengan tata letak komentar ini. Presentasi tanpa komentar tidak akan memiliki teks komentar untuk ditampilkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Gambar di bawah ini menunjukkan dokumen HTML5 yang diekspor dengan komentar ditampilkan di sebelah slide.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **Kecualikan Hyperlink JavaScript Saat Ekspor**

Misalkan `hyperlinks.pptx` berisi teks tertaut dengan target `javascript:alert('Hello')` dan tautan biasa `https://example.com/`. Untuk mengecualikan hyperlink JavaScript saat ekspor, berikan `True` ke [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Defaultnya adalah `False`, sehingga tautan ini tidak disaring kecuali Anda mengaktifkan opsi tersebut.

Contoh berikut memuat presentasi dari direktori kerja dan mengekspornya menggunakan [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

File yang diekspor menghilangkan hyperlink JavaScript sambil mempertahankan teksnya dan tautan HTTPS biasa. Presentasi sumber tidak berubah.

Opsi ini menyaring hyperlink JavaScript; tidak menghapus semua skrip atau konten aktif lainnya, serta tidak menjamin kepatuhan CSP. Misalnya, output HTML5 tetap menyertakan skrip untuk navigasi slide dan animasi.

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, ekspor HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) dan [transisi slide](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Apakah komentar didukung, dan di mana dapat ditempatkan relatif terhadap slide?**

Ya, komentar yang ada dapat disertakan dalam output HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript untuk alasan keamanan atau CSP?**

Ya, pengaturan [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) memungkinkan Anda melewatkan hyperlink dengan panggilan JavaScript saat menyimpan. Defaultnya adalah `False`. Lihat [Kecualikan Hyperlink JavaScript Selama Ekspor](/slides/id/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) untuk contoh ekspor HTML5 dan cakupan filter. Pengaturan ini tidak menghapus JavaScript yang digunakan oleh penampil HTML5 untuk navigasi dan animasi.