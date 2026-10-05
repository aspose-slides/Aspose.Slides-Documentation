---
title: Mengonversi Presentasi ke HTML5 dengan Python
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/python-net/export-to-html5/
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
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Python melalui .NET. Pertahankan pemformatan, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides untuk Python melalui .NET. Artikel ini mencakup ekspor dasar, kontrol animasi bentuk dan transisi slide, serta tata letak komentar. Artikel ini juga membandingkan output HTML5 dengan output berbasis SVG dari ekspor HTML standar.

## **Ekspor PowerPoint ke HTML5**

Contoh berikut memuat presentasi dari direktori kerja dan menyimpannya dalam format HTML5. Contoh ini menggunakan pengaturan ekspor default; contoh berikutnya menunjukkan cara mengontrol pemutaran animasi secara eksplisit. Ganti jalur input dengan jalur ke presentasi Anda.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}

Selain dokumen HTML, ekspor menulis file CSS dan JavaScript pendukung untuk styling slide, animasi, efek, dan navigasi. Simpan file‑file ini bersama dokumen HTML saat memindahkan atau memublikasikan output. Halaman yang dihasilkan juga memuat jQuery dan Anime.js dari CDN publik; tanpa mereka, navigasi slide dan animasi tidak berjalan.

{{% /alert %}}

Untuk mengekspor tanpa memutar animasi bentuk atau transisi slide, setel [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) dan [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) menjadi `False` pada [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Pengaturan ini bersifat independen, sehingga Anda dapat mengaktifkan salah satunya sambil menonaktifkan yang lain. Contoh ini mengekspor presentasi dengan kedua jenis animasi dinonaktifkan pada halaman yang dihasilkan.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Ekspor PowerPoint ke HTML**

Ekspor HTML standar menggunakan pendekatan rendering yang berbeda: konten slide direpresentasikan sebagai SVG di dalam halaman HTML. Contoh berikut mengonversi presentasi ke dokumen HTML menggunakan pendekatan rendering ini.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Markup sederhana di bawah menggambarkan struktur halaman yang dihasilkan. Elemen SVG berisi konten slide yang dirender; teks placeholder mewakili konten tersebut dan bukan output ekspor literal.

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

Ekspor berbasis SVG tidak mengekspos bentuk PowerPoint sebagai elemen HTML individual. Gunakan ekspor HTML5 ketika Anda memerlukan opsi animasi bentuk dan transisi slide yang ditunjukkan dalam artikel ini.

{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

Ekspor HTML5 menghasilkan halaman untuk melihat dan menavigasi slide presentasi di peramban. Contoh ini mengaktifkan baik [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) maupun [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) sehingga tampilan slide yang diekspor dapat memutar efek dari presentasi sumber.

Gunakan presentasi yang sudah berisi animasi bentuk dan transisi slide untuk melihat efek pengaturan ini. Mengaktifkannya tidak menambahkan efek baru ke slide yang tidak memilikinya. Setelah ekspor, buka dokumen HTML5 yang dihasilkan di peramban dengan file pendukung tersedia.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Konversi Presentasi ke Dokumen HTML5 dengan Komentar**

Anda dapat menyertakan komentar slide yang ada dalam output HTML5 sehingga pembaca dapat melihat umpan balik di samping konten slide. Contoh pada bagian ini mengasumsikan presentasi sumber berisi komentar, seperti yang diilustrasikan di bawah. Contoh ini mengekspor komentar tersebut; tidak membuat komentar baru.

![Two comments on the presentation slide](two_comments_pptx.png)

Tetapkan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) ke properti [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) pada [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Setel [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) menjadi `RIGHT` dari enumerasi [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) untuk menempatkan komentar di sebelah kanan setiap slide.

Contoh berikut mengekspor presentasi ke HTML5 dengan tata letak komentar ini. Presentasi tanpa komentar tidak akan memiliki teks komentar untuk ditampilkan.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

Gambar di bawah menunjukkan dokumen HTML5 yang diekspor dengan komentar ditampilkan di samping slide.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Kecualikan Tautan JavaScript Selama Ekspor**

Misalkan `hyperlinks.pptx` berisi teks yang ditautkan dengan target `javascript:alert('Hello')` dan tautan biasa `https://example.com/`. Untuk mengecualikan tautan JavaScript selama ekspor, setel [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) menjadi `True`. Nilai default adalah `False`, sehingga tautan‑tautan ini tidak disaring kecuali Anda mengaktifkan opsi tersebut.

Contoh berikut memuat presentasi dari direktori kerja dan mengekspornya menggunakan [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Berkas yang diekspor menghilangkan tautan JavaScript sambil mempertahankan teksnya dan tautan HTTPS biasa. Presentasi sumber tidak berubah.

Opsi ini menyaring tautan JavaScript; tidak menghapus semua skrip atau konten aktif lainnya, serta tidak menjamin kepatuhan CSP. Misalnya, output HTML5 masih menyertakan skrip untuk navigasi slide dan animasi.

## **FAQ**

**Bisakah saya mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, ekspor HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) dan [transisi slide](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Apakah komentar didukung, dan di mana dapat ditempatkan relatif terhadap slide?**

Ya, komentar yang ada dapat disertakan dalam output HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) untuk catatan dan komentar.

**Bisakah saya melewatkan tautan yang memanggil JavaScript demi keamanan atau alasan CSP?**

Ya, pengaturan [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) memungkinkan Anda melewatkan tautan dengan pemanggilan JavaScript saat menyimpan. Nilai default adalah `False`. Lihat [Exclude JavaScript Hyperlinks During Export](/slides/id/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) untuk contoh ekspor HTML5 dan ruang lingkup filter. Pengaturan ini tidak menghapus JavaScript yang digunakan oleh penampil HTML5 untuk navigasi dan animasi.