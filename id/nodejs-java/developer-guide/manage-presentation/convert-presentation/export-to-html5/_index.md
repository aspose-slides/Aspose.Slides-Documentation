---
title: Konversi Presentasi ke HTML5 dengan JavaScript
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Node.js. Pertahankan format, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides untuk Node.js via Java. Artikel ini mencakup ekspor dasar, kontrol animasi bentuk dan transisi slide, serta tata letak komentar. Artikel ini juga membandingkan output HTML5 dengan output berbasis SVG dari ekspor HTML standar.

## **Ekspor PowerPoint ke HTML5**

Contoh berikut memuat presentasi dari direktori kerja dan menyimpannya dalam format HTML5. Contoh ini menggunakan pengaturan ekspor default; contoh berikutnya menunjukkan cara mengontrol pemutaran animasi secara eksplisit. Ganti jalur input dengan jalur ke presentasi Anda.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Selain dokumen HTML, ekspor menulis file CSS dan JavaScript pendukung untuk gaya slide, animasi, efek, dan navigasi. Simpan file‑file ini bersama dokumen HTML saat memindahkan atau menerbitkan output. Halaman yang dihasilkan juga memuat jQuery dan Anime.js dari CDN publik; tanpa mereka, navigasi slide dan animasi tidak akan berjalan.
{{% /alert %}}

Untuk mengekspor tanpa memutar animasi bentuk atau transisi slide, berikan `false` ke [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) dan [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) dalam [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Pengaturan ini bersifat independen, sehingga Anda dapat mengaktifkan satu sementara menonaktifkan yang lain. Contoh ini mengekspor presentasi dengan kedua jenis animasi dinonaktifkan dalam halaman yang dihasilkan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Ekspor PowerPoint ke HTML**

Ekspor HTML standar menggunakan pendekatan rendering yang berbeda: konten slide direpresentasikan sebagai SVG di dalam halaman HTML. Contoh berikut mengonversi presentasi ke dokumen HTML menggunakan pendekatan rendering ini.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Markup sederhana di bawah ini menggambarkan struktur halaman yang dihasilkan. Elemen SVG berisi konten slide yang dirender; teks placeholder mewakili konten tersebut dan bukan output ekspor literal.

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
Ekspor berbasis SVG tidak menampilkan bentuk PowerPoint sebagai elemen HTML terpisah. Gunakan ekspor HTML5 ketika Anda memerlukan opsi animasi bentuk dan transisi slide yang ditunjukkan dalam artikel ini.
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

Ekspor HTML5 menghasilkan halaman untuk melihat dan menavigasi slide presentasi di peramban. Contoh ini mengaktifkan kedua [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) dan [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) sehingga tampilan slide yang diekspor dapat memutar efek dari presentasi sumber.

Gunakan presentasi yang sudah berisi animasi bentuk dan transisi slide untuk melihat efek pengaturan ini. Mengaktifkannya tidak menambah efek baru pada slide yang tidak memiliki efek. Setelah ekspor, buka dokumen HTML5 yang dihasilkan di peramban dengan file pendukungnya tersedia.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Mengonversi Presentasi ke Dokumen HTML5 dengan Komentar**

Anda dapat menyertakan komentar slide yang ada dalam output HTML5 sehingga pembaca dapat melihat umpan balik bersamaan dengan konten slide. Contoh pada bagian ini mengharapkan presentasi sumber berisi komentar, seperti yang diilustrasikan di bawah. Contoh ini mengekspor komentar tersebut; tidak membuat yang baru.

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Berikan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ke metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) dari [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Gunakan [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) untuk memilih `Right` dari enumerasi [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) guna menempatkan komentar di sebelah kanan setiap slide.

Contoh berikut mengekspor presentasi ke HTML5 dengan tata letak komentar ini. Presentasi tanpa komentar tidak akan memiliki teks komentar untuk ditampilkan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Gambar di bawah ini menunjukkan dokumen HTML5 yang diekspor dengan komentar ditampilkan di samping slide.

![Komentar dalam dokumen HTML5 hasil output](two_comments_html5.png)

## **Mengeluarkan Hyperlink JavaScript Selama Ekspor**

Misalkan `hyperlinks.pptx` berisi teks berlink dengan target `javascript:alert('Hello')` dan link biasa `https://example.com/`. Untuk mengeluarkan hyperlink JavaScript selama ekspor, berikan `true` ke [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Defaultnya adalah `false`, sehingga link tersebut tidak difilter kecuali Anda mengaktifkan opsi.

Contoh berikut memuat presentasi dari direktori kerja dan mengekspornya menggunakan [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

File yang diekspor menghilangkan hyperlink JavaScript sambil mempertahankan teksnya dan link HTTPS biasa. Presentasi sumber tidak berubah.

Opsi ini menyaring hyperlink JavaScript; tidak menghapus semua skrip atau konten aktif lainnya, dan tidak menjamin kepatuhan CSP. Misalnya, output HTML5 masih menyertakan skrip untuk navigasi slide dan animasi.

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, ekspor HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) dan [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Apakah komentar didukung, dan di mana dapat ditempatkan relatif terhadap slide?**

Ya, komentar yang ada dapat disertakan dalam output HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) untuk catatan dan komentar.

**Apakah saya dapat melewatkan link yang memanggil JavaScript untuk alasan keamanan atau CSP?**

Ya, pengaturan [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) memungkinkan Anda melewatkan hyperlink dengan pemanggilan JavaScript saat menyimpan. Defaultnya adalah `false`. Lihat [Keluarkan Hyperlink JavaScript Selama Ekspor](/slides/id/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) untuk contoh ekspor HTML5 dan cakupan penyaringannya. Pengaturan ini tidak menghapus JavaScript yang digunakan oleh penampil HTML5 untuk navigasi dan animasi.