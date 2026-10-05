---
title: Konversi Presentasi ke HTML5 dalam Java
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Java. Pertahankan pemformatan, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides untuk Java. Artikel ini mencakup ekspor dasar, kontrol animasi bentuk dan transisi slide, serta tata letak komentar. Artikel ini juga membandingkan keluaran HTML5 dengan keluaran berbasis SVG dari ekspor HTML standar.

## **Ekspor PowerPoint ke HTML5**

Contoh berikut memuat presentasi dari direktori kerja dan menyimpannya dalam format HTML5. Contoh ini menggunakan pengaturan ekspor default; contoh berikutnya menunjukkan cara mengontrol pemutaran animasi secara eksplisit. Ganti path input dengan path ke presentasi Anda.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Catatan" %}}
Selain dokumen HTML, ekspor menulis file CSS dan JavaScript pendukung untuk styling slide, animasi, efek, dan navigasi. Simpan file-file ini bersama dokumen HTML saat memindahkan atau menerbitkan output. Halaman yang dihasilkan juga memuat jQuery dan Anime.js dari CDN publik; tanpa keduanya, navigasi slide dan animasi tidak akan berjalan.
{{% /alert %}}

Untuk mengekspor tanpa memutar animasi bentuk atau transisi slide, berikan `false` ke [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) dan [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) di [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Pengaturan ini independen, sehingga Anda dapat mengaktifkan satu sementara menonaktifkan yang lain. Contoh ini mengekspor presentasi dengan kedua jenis animasi dinonaktifkan pada halaman yang dihasilkan.

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

Ekspor HTML standar menggunakan pendekatan rendering yang berbeda: konten slide direpresentasikan sebagai SVG di dalam halaman HTML. Contoh berikut mengonversi presentasi ke dokumen HTML menggunakan pendekatan rendering ini.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
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

{{% alert title="Peringatan" color="warning" %}}
Ekspor berbasis SVG tidak mengekspos bentuk PowerPoint sebagai elemen HTML individu. Gunakan ekspor HTML5 ketika Anda memerlukan opsi animasi bentuk dan transisi slide yang ditunjukkan dalam artikel ini.
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

Ekspor HTML5 menghasilkan halaman untuk melihat dan menavigasi slide presentasi di peramban. Contoh ini mengaktifkan baik [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) maupun [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) sehingga tampilan slide yang diekspor dapat memutar efek dari presentasi sumber.

Gunakan presentasi yang sudah berisi animasi bentuk dan transisi slide untuk melihat efek pengaturan ini. Mengaktifkannya tidak menambahkan efek baru pada slide yang tidak memilikinya. Setelah ekspor, buka dokumen HTML5 yang dihasilkan di peramban dengan file pendukung tersedia.

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

## **Konversi Presentasi ke Dokumen HTML5 dengan Komentar**

Anda dapat menyertakan komentar slide yang sudah ada dalam output HTML5 sehingga pembaca dapat melihat umpan balik di samping konten slide. Contoh pada bagian ini mengasumsikan presentasi sumber berisi komentar, seperti yang diilustrasikan di bawah. Contoh ini mengekspor komentar tersebut; tidak membuat komentar baru.

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Berikan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) ke metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) dari [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Gunakan [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) untuk memilih `Right` dari enumerasi [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) agar komentar ditempatkan di sebelah kanan setiap slide.

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

Gambar di bawah ini menunjukkan dokumen HTML5 yang diekspor dengan komentar yang ditampilkan di samping slide.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **Kecualikan Tautan JavaScript Selama Ekspor**

Misalkan `hyperlinks.pptx` berisi teks tertaut dengan target `javascript:alert('Hello')` dan tautan biasa `https://example.com/`. Untuk mengecualikan tautan JavaScript selama ekspor, berikan `true` ke [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Nilai default adalah `false`, sehingga tautan ini tidak disaring kecuali Anda mengaktifkan opsi tersebut.

Contoh berikut memuat presentasi dari direktori kerja dan mengekspornya menggunakan [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

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

File yang diekspor menghilangkan tautan JavaScript sementara mempertahankan teksnya serta tautan HTTPS biasa. Presentasi sumber tidak berubah.

Opsi ini menyaring tautan JavaScript; tidak menghapus semua skrip atau konten aktif lainnya, serta tidak menjamin kepatuhan CSP. Misalnya, output HTML5 masih menyertakan skrip untuk navigasi slide dan animasi.

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, ekspor HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) dan [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Apakah komentar didukung, dan di mana dapat ditempatkan relatif terhadap slide?**

Ya, komentar yang ada dapat disertakan dalam output HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript untuk alasan keamanan atau CSP?**

Ya, pengaturan [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) memungkinkan Anda melewatkan tautan dengan panggilan JavaScript saat menyimpan. Nilai default adalah `false`. Lihat [Kecualikan Tautan JavaScript Selama Ekspor](/slides/id/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) untuk contoh ekspor HTML5 dan ruang lingkup filter. Pengaturan ini tidak menghapus JavaScript yang digunakan oleh penampil HTML5 untuk navigasi dan animasi.