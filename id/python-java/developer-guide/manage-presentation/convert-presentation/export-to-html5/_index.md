---
title: "Konversi Presentasi ke HTML5 dengan Python via Java"
linktitle: "Presentasi ke HTML5"
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
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Python via Java. Pertahankan format, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides. Artikel ini mencakup ekspor HTML5 dasar tanpa ekstensi web tambahan, serta opsi untuk mengontrol animasi bentuk dan transisi slide. Artikel ini juga menunjukkan proses ekspor standar PowerPoint ke HTML, menjelaskan cara menghasilkan output HTML5 dalam mode tampilan slide, dan mendemonstrasikan cara menyertakan komentar dalam dokumen yang diekspor dengan mengonfigurasi tata letaknya.

Contoh-contoh memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Tempatkan `pres.pptx` (atau `sample.pptx` untuk contoh komentar) di direktori kerja saat ini. Setiap contoh memulai JVM hanya jika belum berjalan.

## **Ekspor PowerPoint ke HTML5**

Gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan [SaveFormat.Html5](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Html5) untuk mengekspor presentasi tanpa ekstensi web tambahan:

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

{{% alert color="info" title="Catatan" %}} 
Ekspor HTML5 menghasilkan konten HTML untuk dilihat di peramban. 
{{% /alert %}}

Gunakan [Html5Options](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/) untuk mengkonfigurasi ekspor. Panggil [setAnimateShapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/#setAnimateShapes) dan [setAnimateTransitions](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/#setAnimateTransitions) dengan `False` untuk menonaktifkan animasi bentuk dan transisi slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Ekspor PowerPoint ke HTML**

Gunakan [SaveFormat.Html](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Html) untuk ekspor HTML standar. Lihat [Convert PowerPoint to HTML](/slides/id/python-java/convert-powerpoint-to-html/) untuk opsi lainnya:

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

Dalam kasus ini, konten presentasi dirender melalui SVG dalam bentuk seperti ini:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Peringatan" color="warning" %}} 
Ekspor HTML standar merender konten slide melalui SVG dan tidak menyediakan opsi animasi bentuk HTML5 serta transisi slide. 
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

**Aspose.Slides** memungkinkan Anda mengonversi presentasi PowerPoint ke dokumen HTML5 di mana slide disajikan dalam mode tampilan slide. Dalam hal ini, ketika Anda membuka file HTML5 yang dihasilkan di peramban, Anda melihat presentasi dalam mode tampilan slide pada halaman web. 

Kode Python ini mendemonstrasikan proses ekspor PowerPoint ke Tampilan Slide HTML5:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Mengonversi Presentasi ke Dokumen HTML5 dengan Komentar**

Komentar di PowerPoint adalah alat yang memungkinkan pengguna meninggalkan catatan atau umpan balik pada slide presentasi. Mereka sangat berguna dalam proyek kolaboratif, di mana banyak orang dapat menambahkan saran atau catatan mereka pada elemen slide tertentu tanpa mengubah konten utama. Setiap komentar menampilkan nama penulis, memudahkan melacak siapa yang menambahkan catatan tersebut.

Misalkan kita memiliki presentasi PowerPoint berikut yang disimpan dalam file "sample.pptx".

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Ketika Anda mengonversi presentasi PowerPoint ke dokumen HTML5, Anda dapat dengan mudah menentukan apakah akan menyertakan komentar dari presentasi dalam dokumen output. Untuk melakukannya, berikan parameter tampilan untuk komentar ke metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) dari kelas [Html5Options](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/).

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/) dan [setCommentsPosition](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) dengan [CommentsPositions.Right](https://reference.aspose.com/slides/id/python-java/aspose.slides/commentspositions/#Right). Contoh kode berikut mengonversi presentasi ke dokumen HTML5 dengan komentar ditampilkan di sebelah kanan slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Dokumen "output.html" ditampilkan pada gambar di bawah.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/#setAnimateShapes) dan [transisi slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Apakah output komentar didukung, dan dimana dapat ditempatkan relatif terhadap slide?**

Ya, komentar dapat ditambahkan dalam HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript untuk alasan keamanan atau CSP?**

Ya, ada [pengaturan](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) yang memungkinkan Anda melewatkan hyperlink dengan panggilan JavaScript saat menyimpan. Ini menghapus hyperlink tersebut; namun tidak menjamin bahwa semua skrip HTML5 yang dihasilkan memenuhi Kebijakan Keamanan Konten (Content Security Policy) situs.