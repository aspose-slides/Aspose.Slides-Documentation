---
title: Mengonversi Presentasi ke HTML5 dengan Python
linktitle: Ekspor ke HTML5
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
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- konversi slide
- ekspor HTML5
- ekspor presentasi
- ekspor slide
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Python melalui .NET. Pertahankan pemformatan, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides. Artikel ini mencakup ekspor HTML5 dasar tanpa ekstensi web atau ketergantungan tambahan, serta opsi untuk mengontrol animasi bentuk dan transisi slide. Artikel ini juga menunjukkan proses ekspor standar PowerPoint ke HTML, menjelaskan cara menghasilkan output HTML5 dalam mode tampilan slide, dan mendemonstrasikan cara menyertakan komentar dalam dokumen yang diekspor dengan mengonfigurasi tata letaknya.

## **Ekspor PowerPoint ke HTML5**

Kode python ini menunjukkan cara mengekspor presentasi ke HTML5 tanpa ekstensi web dan ketergantungan:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
Dalam kasus ini, Anda mendapatkan HTML bersih. 
{{% /alert %}}

Anda dapat menentukan pengaturan untuk animasi bentuk dan transisi slide dengan cara ini:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Ekspor PowerPoint ke HTML**

Kode python ini mendemonstrasikan proses standar PowerPoint ke HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
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

{{% alert title="Note" color="warning" %}} 
Saat Anda menggunakan metode ini untuk mengekspor PowerPoint ke HTML, karena rendering SVG, Anda tidak dapat menerapkan gaya atau menganimasikan elemen tertentu. 
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

**Aspose.Slides** memungkinkan Anda mengonversi presentasi PowerPoint ke dokumen HTML5 dimana slide disajikan dalam mode tampilan slide. Dalam hal ini, ketika Anda membuka file HTML5 hasil di peramban, Anda melihat presentasi dalam mode tampilan slide di halaman web. 

Kode Python ini mendemonstrasikan proses ekspor PowerPoint ke Tampilan Slide HTML5:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Ekspor presentasi yang berisi transisi slide, animasi, dan animasi bentuk ke HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Simpan presentasi
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Mengonversi Presentasi ke Dokumen HTML5 dengan Komentar**

Komentar dalam PowerPoint adalah alat yang memungkinkan pengguna meninggalkan catatan atau umpan balik pada slide presentasi. Mereka sangat berguna dalam proyek kolaboratif, di mana beberapa orang dapat menambahkan saran atau catatan mereka pada elemen slide tertentu tanpa mengubah konten utama. Setiap komentar menampilkan nama penulis, sehingga mudah melacak siapa yang memberi catatan.

Misalkan kita memiliki presentasi PowerPoint berikut yang disimpan dalam file "sample.pptx".

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Saat Anda mengonversi presentasi PowerPoint ke dokumen HTML5, Anda dapat dengan mudah menentukan apakah akan menyertakan komentar dari presentasi dalam dokumen output. Untuk melakukannya, Anda perlu menentukan parameter tampilan untuk komentar dalam properti `notes_comments_layouting` dari kelas [Html5Options](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/).

Contoh kode berikut mengonversi presentasi ke dokumen HTML5 dengan komentar ditampilkan di sebelah kanan slide.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Dokumen "output.html" ditampilkan pada gambar di bawah.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/animate_shapes/) dan [transisi slide](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/animate_transitions/).

**Apakah output komentar didukung, dan di mana mereka dapat ditempatkan relatif terhadap slide?**

Ya, komentar dapat ditambahkan dalam HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/notes_comments_layouting/) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript untuk alasan keamanan atau CSP?**

Ya, ada [pengaturan](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/skip_java_script_links/) yang memungkinkan Anda melewatkan hyperlink dengan panggilan JavaScript saat menyimpan. Ini membantu mematuhi kebijakan keamanan yang ketat.