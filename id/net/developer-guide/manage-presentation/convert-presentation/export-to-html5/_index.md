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
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk .NET. Pertahankan pemformatan, animasi, dan interaktivitas."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides untuk .NET. Artikel ini mencakup ekspor dasar, kontrol animasi bentuk dan transisi slide, serta tata letak komentar. Artikel ini juga membandingkan output HTML5 dengan output berbasis SVG dari ekspor HTML standar.

## **Ekspor PowerPoint ke HTML5**

Contoh berikut memuat presentasi dari direktori kerja dan menyimpannya dalam format HTML5. Contoh ini menggunakan pengaturan ekspor default; contoh berikutnya menunjukkan cara mengendalikan pemutaran animasi secara eksplisit. Ganti jalur masukan dengan jalur ke presentasi Anda.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Catatan" %}}
Selain dokumen HTML, ekspor menulis file CSS dan JavaScript pendukung untuk gaya slide, animasi, efek, dan navigasi. Simpan file-file ini bersama dokumen HTML saat memindahkan atau memublikasikan output. Halaman yang dihasilkan juga memuat jQuery dan Anime.js dari CDN publik; tanpa mereka, navigasi slide dan animasi tidak akan berjalan.
{{% /alert %}}

Untuk mengekspor tanpa memutar animasi bentuk atau transisi slide, atur [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) dan [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) ke `false` dalam [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Pengaturan ini bersifat independen, sehingga Anda dapat mengaktifkan satu sementara menonaktifkan yang lain. Contoh ini mengekspor presentasi dengan kedua jenis animasi dinonaktifkan pada halaman yang dihasilkan.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Ekspor PowerPoint ke HTML**

Ekspor HTML standar menggunakan pendekatan rendering yang berbeda: konten slide direpresentasikan sebagai SVG di dalam halaman HTML. Contoh berikut mengonversi presentasi menjadi dokumen HTML menggunakan pendekatan rendering ini.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Markup sederhana di bawah ini menggambarkan struktur halaman yang dihasilkan. Elemen SVG berisi konten slide yang dirender; teks placeholder mewakili konten tersebut dan bukan output ekspor yang sesungguhnya.

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
Ekspor berbasis SVG tidak menampilkan bentuk PowerPoint sebagai elemen HTML terpisah. Gunakan ekspor HTML5 ketika Anda membutuhkan opsi animasi bentuk dan transisi slide yang dijelaskan dalam artikel ini.
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

Ekspor HTML5 menghasilkan halaman untuk melihat dan menavigasi slide presentasi di peramban. Contoh ini mengaktifkan baik [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) maupun [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) sehingga tampilan slide yang diekspor dapat memutar efek dari presentasi sumber.

Gunakan presentasi yang sudah berisi animasi bentuk dan transisi slide untuk melihat efek dari pengaturan ini. Mengaktifkannya tidak menambahkan efek baru pada slide yang tidak memilikinya. Setelah ekspor, buka dokumen HTML5 yang dihasilkan di peramban dengan file pendukungnya tersedia.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Konversi Presentasi ke Dokumen HTML5 dengan Komentar**

Anda dapat menyertakan komentar slide yang ada dalam output HTML5 sehingga pembaca dapat melihat umpan balik bersamaan dengan konten slide. Contoh dalam bagian ini mengharapkan presentasi sumber berisi komentar, seperti yang diilustrasikan di bawah. Contoh ini mengekspor komentar tersebut; tidak membuat komentar baru.

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Tetapkan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) ke properti [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) dari [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Atur [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) ke `Right` dari enumerasi [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) untuk menempatkan komentar di sebelah kanan setiap slide.

Contoh berikut mengekspor presentasi ke HTML5 dengan tata letak komentar ini. Presentasi tanpa komentar tidak akan memiliki teks komentar untuk ditampilkan.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Gambar di bawah ini menunjukkan dokumen HTML5 yang diekspor dengan komentar ditampilkan di samping slide.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **Kecualikan Tautan JavaScript Saat Ekspor**

Misalkan `hyperlinks.pptx` berisi teks yang ditautkan dengan target `javascript:alert('Hello')` dan tautan biasa `https://example.com/`. Untuk mengecualikan tautan JavaScript saat ekspor, atur [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) ke `true`. Nilai default adalah `false`, sehingga tautan ini tidak difilter kecuali Anda mengaktifkan opsi tersebut.

Contoh berikut memuat presentasi dari direktori kerja dan mengekspornya menggunakan [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

File yang diekspor menghilangkan tautan JavaScript sambil mempertahankan teksnya dan tautan HTTPS biasa. Presentasi sumber tidak berubah.

Opsi ini memfilter tautan JavaScript; tidak menghapus semua skrip atau konten aktif lainnya, juga tidak menjamin kepatuhan CSP. Misalnya, output HTML5 masih menyertakan skrip untuk navigasi slide dan animasi.

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, ekspor HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) dan [transisi slide](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Apakah komentar didukung, dan di mana dapat ditempatkan relatif terhadap slide?**

Ya, komentar yang ada dapat disertakan dalam output HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript demi keamanan atau alasan CSP?**

Ya, pengaturan [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) memungkinkan Anda melewatkan tautan hypertext dengan pemanggilan JavaScript saat menyimpan. Nilai default adalah `false`. Lihat [Kecualikan Tautan JavaScript Saat Ekspor](/slides/id/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) untuk contoh sederhana ekspor HTML, HTML5, dan PDF serta ruang lingkup filter tersebut. Pengaturan ini tidak menghapus JavaScript yang digunakan oleh penampil HTML5 untuk navigasi dan animasi.