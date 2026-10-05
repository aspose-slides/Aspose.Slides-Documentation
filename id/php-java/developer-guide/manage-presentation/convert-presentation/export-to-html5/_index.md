---
title: Konversi Presentasi ke HTML5 dengan PHP
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk PHP via Java. Pertahankan pemformatan, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides untuk PHP via Java. Artikel ini mencakup ekspor dasar, kontrol animasi bentuk dan transisi slide, serta tata letak komentar. Artikel ini juga membandingkan output HTML5 dengan output berbasis SVG dari ekspor HTML standar.

## **Ekspor PowerPoint ke HTML5**

Contoh berikut memuat presentasi dari direktori kerja dan menyimpannya dalam format HTML5. Contoh ini menggunakan pengaturan ekspor default; contoh berikutnya menunjukkan cara mengontrol pemutaran animasi secara eksplisit. Ganti jalur masukan dengan jalur ke presentasi Anda.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Catatan" %}}

Selain dokumen HTML, proses ekspor menulis file CSS dan JavaScript pendukung untuk penataan slide, animasi, efek, dan navigasi. Simpan file‑file ini bersama dokumen HTML saat memindahkan atau memublikasikan output. Halaman yang dihasilkan juga memuat jQuery dan Anime.js dari CDN publik; tanpa keduanya, navigasi slide dan animasi tidak akan berjalan.

{{% /alert %}}

Untuk mengekspor tanpa memutar animasi bentuk atau transisi slide, berikan `false` ke [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) dan [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) dalam [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Pengaturan ini bersifat independen, sehingga Anda dapat mengaktifkan satu sementara menonaktifkan yang lain. Contoh ini mengekspor presentasi dengan kedua jenis animasi dinonaktifkan dalam halaman yang dihasilkan.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Ekspor PowerPoint ke HTML**

Ekspor HTML standar menggunakan pendekatan perenderan yang berbeda: konten slide direpresentasikan sebagai SVG di dalam halaman HTML. Contoh berikut mengonversi presentasi ke dokumen HTML menggunakan pendekatan perenderan ini.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
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

{{% alert title="Peringatan" color="warning" %}}

Ekspor berbasis SVG tidak mengekspor bentuk PowerPoint sebagai elemen HTML terpisah. Gunakan ekspor HTML5 ketika Anda memerlukan opsi animasi bentuk dan transisi slide yang ditunjukkan dalam artikel ini.

{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

Ekspor HTML5 menghasilkan halaman untuk melihat dan menavigasi slide presentasi di peramban. Contoh ini mengaktifkan baik [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) maupun [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) sehingga tampilan slide yang diekspor dapat memutar efek dari presentasi sumber.

Gunakan presentasi yang sudah berisi animasi bentuk dan transisi slide untuk melihat efek pengaturan ini. Mengaktifkannya tidak menambahkan efek baru pada slide yang tidak memilikinya. Setelah diekspor, buka dokumen HTML5 yang dihasilkan di peramban dengan file pendukung yang tersedia.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Mengonversi Presentasi ke Dokumen HTML5 dengan Komentar**

Anda dapat menyertakan komentar slide yang ada dalam output HTML5 sehingga pembaca dapat melihat umpan balik di samping konten slide. Contoh pada bagian ini mengasumsikan presentasi sumber berisi komentar, seperti yang digambarkan di bawah. Contoh ini mengekspor komentar tersebut; tidak membuat komentar baru.

![Two comments on the presentation slide](two_comments_pptx.png)

Berikan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) ke metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) dari [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Gunakan [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) untuk memilih `Right` dari enumerasi [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) guna menempatkan komentar di sebelah kanan setiap slide.

Contoh berikut mengekspor presentasi ke HTML5 dengan tata letak komentar ini. Presentasi tanpa komentar tidak akan menampilkan teks komentar.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Gambar di bawah ini menunjukkan dokumen HTML5 yang diekspor dengan komentar ditampilkan di samping slide.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Mengecualikan Tautan JavaScript Saat Mengekspor**

Misalkan `hyperlinks.pptx` berisi teks bertautan dengan target `javascript:alert('Hello')` dan sebuah tautan biasa `https://example.com/`. Untuk mengecualikan tautan JavaScript saat mengekspor, berikan `true` ke [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Nilai default adalah `false`, sehingga tautan‑tautan ini tidak disaring kecuali Anda mengaktifkan opsi tersebut.

Contoh berikut memuat presentasi dari direktori kerja dan mengekspornya menggunakan [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

File yang diekspor menghilangkan tautan JavaScript sementara mempertahankan teksnya serta tautan HTTPS biasa. Presentasi sumber tidak berubah.

Opsi ini menyaring tautan JavaScript; ia tidak menghapus semua skrip atau konten aktif lainnya, serta tidak menjamin kepatuhan CSP. Misalnya, output HTML5 tetap menyertakan skrip untuk navigasi slide dan animasi.

## **Tanya Jawab**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, ekspor HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) dan [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**Apakah komentar didukung, dan di mana mereka dapat ditempatkan relatif terhadap slide?**

Ya, komentar yang ada dapat disertakan dalam output HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript untuk alasan keamanan atau CSP?**

Ya, pengaturan [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) memungkinkan Anda melewatkan tautan yang berisi panggilan JavaScript saat menyimpan. Nilai defaultnya adalah `false`. Lihat [Exclude JavaScript Hyperlinks During Export](/slides/id/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) untuk contoh ekspor HTML5 dan ruang lingkup penyaringan. Pengaturan ini tidak menghapus JavaScript yang digunakan oleh penampil HTML5 untuk navigasi dan animasi.