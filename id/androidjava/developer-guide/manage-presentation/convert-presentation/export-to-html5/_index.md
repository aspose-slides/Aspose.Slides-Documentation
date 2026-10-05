---
title: Konversi Presentasi ke HTML5 di Android
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Android melalui Java. Jaga format, animasi, dan interaktivitas."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides untuk Android melalui Java. Artikel ini mencakup ekspor dasar, kontrol animasi bentuk dan transisi slide, serta tata letak komentar. Artikel ini juga membandingkan output HTML5 dengan output berbasis SVG dari ekspor HTML standar.

## **Ekspor PowerPoint ke HTML5**

Contoh berikut memuat presentasi dari direktori kerja dan menyimpannya dalam format HTML5. Contoh ini menggunakan pengaturan ekspor default; contoh berikutnya menunjukkan cara mengendalikan pemutaran animasi secara eksplisit. Ganti jalur input dengan jalur ke presentasi Anda.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Selain dokumen HTML, proses ekspor menulis file CSS dan JavaScript pendukung untuk gaya slide, animasi, efek, dan navigasi. Simpan file-file ini bersama dokumen HTML saat memindahkan atau memublikasikan output. Halaman yang dihasilkan juga memuat jQuery dan Anime.js dari CDN publik; tanpa mereka, navigasi slide dan animasi tidak berjalan.
{{% /alert %}}

Untuk mengekspor tanpa memutar animasi bentuk atau transisi slide, berikan `false` ke [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) dan [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) di [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Pengaturan ini independen, sehingga Anda dapat mengaktifkan satu sementara menonaktifkan yang lain. Contoh ini mengekspor presentasi dengan kedua jenis animasi dinonaktifkan di halaman yang dihasilkan.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Ekspor PowerPoint ke HTML**

Ekspor HTML standar menggunakan pendekatan rendering berbeda: konten slide direpresentasikan sebagai SVG dalam halaman HTML. Contoh berikut mengonversi sebuah presentasi menjadi dokumen HTML menggunakan pendekatan rendering ini.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Markup sederhana di bawah ini menggambarkan struktur halaman yang dihasilkan. Elemen SVG berisi konten slide yang dirender; teks placeholder mewakili konten tersebut dan bukan output ekspor secara harfiah.

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
Ekspor berbasis SVG tidak mengekspos bentuk PowerPoint sebagai elemen HTML terpisah. Gunakan ekspor HTML5 ketika Anda memerlukan opsi animasi bentuk dan transisi slide yang ditunjukkan dalam artikel ini.
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

Ekspor HTML5 menghasilkan halaman untuk melihat dan menavigasi slide presentasi di peramban. Contoh ini mengaktifkan baik [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) maupun [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) sehingga tampilan slide yang diekspor dapat memutar efek dari presentasi sumber. Gunakan presentasi yang sudah berisi animasi bentuk dan transisi slide untuk melihat efek pengaturan ini. Mengaktifkannya tidak menambahkan efek baru pada slide yang tidak memilikinya. Setelah ekspor, buka dokumen HTML5 yang dihasilkan di peramban dengan file pendukungnya tersedia.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Mengonversi Presentasi ke Dokumen HTML5 dengan Komentar**

Anda dapat menyertakan komentar slide yang ada dalam output HTML5 sehingga pembaca dapat melihat umpan balik bersamaan dengan konten slide. Contoh pada bagian ini mengharapkan presentasi sumber berisi komentar, seperti yang diilustrasikan di bawah. Contoh ini mengekspor komentar tersebut; tidak membuat yang baru.

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Berikan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) ke metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) milik [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Gunakan [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) untuk memilih `Right` dari enumerasi [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) guna menempatkan komentar di sebelah kanan setiap slide.

Contoh berikut mengekspor presentasi ke HTML5 dengan tata letak komentar ini. Presentasi tanpa komentar tidak akan memiliki teks komentar untuk ditampilkan.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Komentar dalam dokumen HTML5 yang dihasilkan](two_comments_html5.png)

## **Kecualikan Hyperlink JavaScript Saat Mengekspor**

Misalkan `hyperlinks.pptx` berisi teks tertaut dengan target `javascript:alert('Hello')` dan tautan biasa `https://example.com/`. Untuk mengecualikan hyperlink JavaScript saat mengekspor, berikan `true` ke [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Nilai default adalah `false`, sehingga tautan ini tidak disaring kecuali Anda mengaktifkan opsi tersebut.

Contoh berikut memuat presentasi dari direktori kerja dan mengekspornya menggunakan [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

File yang diekspor menghilangkan hyperlink JavaScript sambil mempertahankan teksnya dan tautan HTTPS biasa. Presentasi sumber tidak berubah.

Opsi ini menyaring hyperlink JavaScript; tidak menghapus semua skrip atau konten aktif lainnya, serta tidak menjamin kepatuhan CSP. Misalnya, output HTML5 tetap menyertakan skrip untuk navigasi slide dan animasi.

## **FAQ**

**Bisakah saya mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, ekspor HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) dan [transisi slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Apakah komentar didukung, dan di mana dapat ditempatkan relatif terhadap slide?**

Ya, komentar yang ada dapat disertakan dalam output HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) untuk catatan dan komentar.

**Bisakah saya melewatkan tautan yang memanggil JavaScript karena alasan keamanan atau CSP?**

Ya, pengaturan [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) memungkinkan Anda melewatkan hyperlink dengan pemanggilan JavaScript saat menyimpan. Nilai default adalah `false`. Lihat [Kecualikan Hyperlink JavaScript Saat Mengekspor](/slides/id/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) untuk contoh ekspor HTML5 dan ruang lingkup filter. Pengaturan ini tidak menghapus JavaScript yang digunakan oleh penampil HTML5 untuk navigasi dan animasi.