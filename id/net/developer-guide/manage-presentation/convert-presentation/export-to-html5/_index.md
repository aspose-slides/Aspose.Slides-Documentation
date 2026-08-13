---
title: Konversi Presentasi ke HTML5 di .NET
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk .NET. Pertahankan format, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides. Artikel ini mencakup ekspor HTML5 dasar, serta opsi untuk mengontrol animasi bentuk dan transisi slide. Artikel ini juga menunjukkan proses ekspor standar PowerPoint-ke-HTML, menjelaskan cara menghasilkan output HTML5 dalam mode tampilan slide, dan mendemonstrasikan cara menyertakan komentar dalam dokumen yang diekspor dengan mengonfigurasi tata letaknya.

## **Ekspor PowerPoint ke HTML5**

Kode C# ini menunjukkan cara mengekspor presentasi ke HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
Selain dokumen HTML, proses ekspor menulis file pendukung yang direferensikannya: `pres.css`, `master.css`, `animation.js`, `effects.js`, dan `navigation.js`. Halaman yang dihasilkan juga memuat jQuery dan Anime.js dari CDN publik; tanpa file tersebut, navigasi slide dan animasi tidak akan berjalan. 
{{% /alert %}}

Anda dapat menentukan pengaturan untuk animasi bentuk dan transisi slide dengan cara berikut:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Ekspor PowerPoint ke HTML**

Kode C# ini mendemonstrasikan proses standar PowerPoint ke HTML:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
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
Saat Anda menggunakan metode ini untuk mengekspor PowerPoint ke HTML, karena rendering SVG, Anda tidak dapat menerapkan gaya atau memberi animasi pada elemen tertentu. 
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

**Aspose.Slides** memungkinkan Anda mengonversi presentasi PowerPoint menjadi dokumen HTML5 di mana slide ditampilkan dalam mode tampilan slide. Dalam hal ini, ketika Anda membuka file HTML5 yang dihasilkan di peramban, Anda akan melihat presentasi dalam mode tampilan slide pada halaman web. 

Kode C# ini mendemonstrasikan proses ekspor PowerPoint ke Tampilan Slide HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Konversi Presentasi ke Dokumen HTML5 dengan Komentar**

Komentar di PowerPoint adalah alat yang memungkinkan pengguna meninggalkan catatan atau umpan balik pada slide presentasi. Komentar sangat berguna dalam proyek kolaboratif, di mana beberapa orang dapat menambahkan saran atau catatan mereka pada elemen slide tertentu tanpa mengubah konten utama. Setiap komentar menampilkan nama penulis, sehingga mudah melacak siapa yang memberikan catatan.

Misalkan kita memiliki presentasi PowerPoint berikut yang disimpan dalam file "sample.pptx".

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Saat Anda mengonversi presentasi PowerPoint ke dokumen HTML5, Anda dapat dengan mudah menentukan apakah akan menyertakan komentar dari presentasi dalam dokumen output. Untuk melakukannya, Anda perlu menentukan parameter tampilan untuk komentar pada properti `NotesCommentsLayouting` dari kelas [Html5Options](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/).

Contoh kode berikut mengonversi presentasi menjadi dokumen HTML5 dengan komentar yang ditampilkan di sebelah kanan slide.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Dokumen "output.html" ditampilkan pada gambar di bawah.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **FAQ**

### Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?

Ya, HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/animateshapes/) dan [transisi slide](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/animatetransitions/).

### Apakah output komentar didukung, dan dimana dapat ditempatkan relatif terhadap slide?

Ya, komentar dapat ditambahkan dalam HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/id/net/aspose.slides.export/html5options/notescommentslayouting/) untuk catatan dan komentar.

### Apakah saya dapat melewatkan tautan yang memanggil JavaScript untuk alasan keamanan atau CSP?

Ya, ada [pengaturan](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) yang memungkinkan Anda melewatkan hyperlink dengan panggilan JavaScript saat menyimpan. Ini membantu mematuhi kebijakan keamanan yang ketat.