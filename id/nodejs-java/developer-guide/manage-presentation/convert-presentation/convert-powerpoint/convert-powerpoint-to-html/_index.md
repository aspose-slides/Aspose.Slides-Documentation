---
title: Konversi Presentasi PowerPoint ke HTML di Node.js
linktitle: PowerPoint ke HTML
type: docs
weight: 30
url: /id/nodejs-java/convert-powerpoint-to-html/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke HTML
- presentasi ke HTML
- slide ke HTML
- PPT ke HTML
- PPTX ke HTML
- simpan PowerPoint sebagai HTML
- simpan presentasi sebagai HTML
- simpan slide sebagai HTML
- simpan PPT sebagai HTML
- simpan PPTX sebagai HTML
- ekspor PPT ke HTML
- ekspor PPTX ke HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke HTML di Node.js. Gunakan Aspose.Slides untuk Node.js via Java untuk mengekspor berkas PPT dan PPTX, slide terpilih, catatan, font, gambar, SVG, dan media."
---
## **Ikhtisar**

Aspose.Slides untuk Node.js via Java dapat menyimpan presentasi PowerPoint sebagai HTML tanpa Microsoft PowerPoint. Konversi dasar hanya memuat satu [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan memanggil `save` dengan [SaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/). Gunakan [HtmlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmloptions/) ketika Anda perlu mengontrol tata letak yang diekspor, font, gambar, catatan, komentar, output SVG, atau sumber daya yang ditautkan.

Panduan ini berfokus pada skenario ekspor HTML yang praktis:

- Ekspor seluruh presentasi atau slide yang dipilih.
- Hasilkan HTML dengan tata letak tetap, responsif, atau berbasis SVG.
- Sertakan catatan pembicara dan komentar.
- Kendalikan kualitas gambar dan data gambar yang dipotong.
- Sematkan font atau simpan berkas font secara terpisah.
- Pilih cara sumber daya eksternal dan berkas media ditulis dan direferensikan.

Secara default, ekspor HTML menghasilkan dokumen HTML yang berdiri sendiri dimana sebagian besar sumber daya disematkan. Ini memudahkan berbagi satu berkas, namun dapat meningkatkan ukuran keluaran. Untuk publikasi web, pertimbangkan sumber daya eksternal, DPI gambar yang lebih rendah, dan hanya menyematkan font yang tidak tersedia secara andal di lingkungan target.

## **Mengonversi Presentasi ke HTML**

Untuk mengekspor presentasi ke HTML, muat dengan [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan simpan dengan [SaveFormat.Html](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Contoh ini menulis satu berkas HTML. Objek presentasi dibuang di blok `finally`, yang melepaskan pegangan berkas dan sumber daya rendering setelah ekspor.

## **Gunakan HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmloptions/) adalah kelas konfigurasi utama untuk ekspor HTML. Pengaturan umum meliputi:

- `SlidesLayoutOptions`: menambahkan catatan, komentar, handout, atau informasi tata letak lainnya.
- `HtmlFormatter`: mengubah struktur dokumen HTML atau mendelegasikan pemformatan ke sebuah controller.
- `SlideImageFormat`: mengubah cara slide direpresentasikan, misalnya sebagai SVG.
- `PicturesCompression`: mengendalikan DPI gambar dan ukuran keluaran.
- `DeletePicturesCroppedAreas`: mempertahankan atau menghapus data gambar yang dipotong.
- `SvgResponsiveLayout`: membuat konten SVG yang diekspor menyesuaikan dengan kontainernya.
- `ShowHiddenSlides`: menyertakan slide tersembunyi bila diperlukan.

Bagian berikut menunjukkan opsi paling umum secara terpisah sehingga Anda dapat menggabungkan hanya yang dibutuhkan alur kerja Anda.

## **Mengonversi Slide Terpilih ke HTML**

Overload `Presentation.save` yang menerima nomor slide menggunakan posisi slide berbasis 1. Loop di bawah ini menyimpan setiap slide ke berkas HTML terpisah.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Gunakan pola ini ketika situs web atau aplikasi membutuhkan satu halaman HTML per slide. Jika setiap slide harus memiliki tata letak yang sama, buat satu instance [HtmlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmloptions/) dan berikan ke setiap panggilan `save`.

## **Buat HTML Responsif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/responsivehtmlcontroller/) menyediakan output HTML responsif melalui [HtmlFormatter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmlformatter/). Gunakan ini ketika halaman yang diekspor harus beradaptasi lebih baik dengan lebar browser.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Untuk tata letak responsif berbasis SVG, atur `SvgResponsiveLayout` pada [HtmlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmloptions/). Ini berguna ketika konten slide diekspor sebagai markup SVG yang dapat diskalakan.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Sertakan Catatan Pembicara dan Komentar**

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notescommentslayoutingoptions/) melalui `HtmlOptions.setSlidesLayoutOptions` untuk menyertakan catatan pembicara atau komentar. Catatan dan komentar tersembunyi secara default kecuali Anda memilih posisinya.

Misalkan presentasi sumber berisi catatan pembicara:

![Slide dengan catatan pembicara di PowerPoint](slide_with_notes.png)

Kode berikut mengekspor konten slide dengan catatan pembicara di bawah slide.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Output HTML termasuk area catatan:

![Output HTML dengan slide dan catatan pembicara](HTML_with_notes.png)

Untuk mengekspor komentar, atur `CommentsPosition`, misalnya ke `CommentsPositions.Right` atau `CommentsPositions.Bottom`. Jika Anda hanya membutuhkan komentar, hilangkan `NotesPosition`. Jika Anda membutuhkan keduanya, atur kedua properti.

## **Kendalikan Kualitas Gambar dan Area yang Dipotong**

Ekspor HTML dapat mengompres gambar slide untuk mengurangi ukuran keluaran. Atur `PicturesCompression` ke nilai dari [PicturesCompression](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturescompression/) ketika Anda memerlukan kualitas gambar yang lebih tinggi.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Secara default, area gambar yang dipotong dapat dihapus dari output yang diekspor. Simpan data yang dipotong hanya ketika pengguna harus dapat memulihkan atau memeriksa bagian gambar yang tersembunyi tersebut. Menyimpannya dapat meningkatkan ukuran HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Tambahkan CSS**

Untuk styling sederhana, berikan string CSS ke `HtmlFormatter.createDocumentFormatter`. Ini mengubah dokumen HTML di sekelilingnya sementara Aspose.Slides tetap merender konten slide.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Untuk header dokumen khusus, berkas CSS tertaut, atau markup khusus di sekitar slide dan bentuk, gunakan [HtmlFormatter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmlformatter/) dengan controller pemformatan.

## **Sematkan Font**

Jika lingkungan target mungkin tidak memiliki font presentasi yang terpasang, sematkan font dalam HTML dengan [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Menyematkan meningkatkan kesetiaan visual namun meningkatkan ukuran keluaran.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Kecualikan font hanya bila Anda yakin bahwa peramban atau sistem target sudah menyediakannya. Untuk font merek atau font yang tidak umum, menyematkan biasanya lebih aman.

## **Tautkan Berkas Font Alih-alih Menyematkannya**

Untuk mengurangi ukuran berkas HTML, Anda dapat menulis data font ke berkas WOFF terpisah dan menambahkan aturan `@font-face` ke HTML. Dalam Node.js via Java, skenario ini biasanya diimplementasikan dengan kelas pembantu Java kecil yang memperluas [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), menulis byte font ke direktori keluaran, dan menyisipkan aturan `@font-face` ke HTML yang dihasilkan. Kompilasikan pembantu tersebut, tambahkan ke classpath modul Node.js, lalu buat instansinya dari JavaScript dengan `java.newInstanceSync`.

Saat membangun pembantu seperti itu, pilih dua jalur secara sengaja:

- Jalur keluaran sistem file, tempat berkas font yang dihasilkan ditulis.
- Jalur URL, yang digunakan peramban dari dokumen HTML untuk memuat berkas font tersebut.

## **Simpan Sumber Daya Secara Eksternal**

HTML yang berdiri sendiri mudah dipindahkan, namun sumber daya Base64 yang disematkan dapat membuat berkas menjadi besar. Jika aplikasi Anda memerlukan berkas gambar, font, audio, atau video eksternal, gunakan kontroler ekspor yang menulis sumber daya ke direktori pilihan dan menghasilkan URL yang terlihat oleh peramban. Jaga agar jalur sistem file dan jalur URL selaras dengan tata letak penyebaran Anda.

## **Ekspor Berkas Media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) mengekspor berkas video dan audio serta menulis HTML yang dapat memutarnya di peramban. Konstruktornya menerima:

- `path`: direktori tempat berkas media yang dihasilkan akan ditulis.
- `fileName`: nama berkas HTML yang sedang dihasilkan.
- `baseUri`: awalan URI absolut yang digunakan dalam tautan HTML ke berkas media.

Jika berkas HTML adalah `html-output/presentation.html` dan berkas media disimpan di `html-output/media`, `path` harus menunjuk ke direktori media pada disk, sementara `baseUri` harus menunjuk ke direktori yang sama dari sudut pandang peramban. Untuk pratinjau lokal, Anda dapat membuat URI `file:///` dari direktori media. Untuk aplikasi yang disebarkan, gunakan URL absolut dari direktori media yang dipublikasikan.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Gunakan direktori keluaran yang unik per pekerjaan ekspor, khususnya dalam aplikasi server. Jalur keluaran yang dibagi dapat menyebabkan berkas dari konversi berbeda saling menimpa.

## **Kinerja dan Manajemen Sumber Daya**

Konversi HTML adalah operasi rendering, sehingga waktu pemrosesan dan penggunaan memori bergantung pada jumlah slide, resolusi gambar, font, efek, chart, dan media yang disematkan. Nilai DPI `PicturesCompression` yang lebih tinggi, font yang disematkan, output SVG, dan area gambar yang dipotong yang dipertahankan dapat meningkatkan kesetiaan namun biasanya meningkatkan ukuran keluaran.

Untuk konversi batch:

- Buang setiap instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dengan segera.
- Gunakan direktori keluaran terpisah untuk pekerjaan terpisah.
- Hindari menyematkan font umum kecuali kesetiaan memerlukannya.
- Turunkan DPI gambar ketika HTML untuk pratinjau atau thumbnail.
- Simpan presentasi sumber, HTML yang dihasilkan, dan sumber daya eksternal bersama sampai jalur penyebaran final.

## **FAQ**

**Apakah tautan hiper tetap terjaga dalam output HTML?**

Ya. Tautan hiper presentasi diekspor ke HTML dan tetap dapat diklik ketika URL target valid.

**Bisakah saya mengonversi presentasi ke HTML secara paralel?**

Ya, tetapi jangan berbagi satu instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) antar pekerja. Proses berkas yang berbeda dengan instance presentasi terpisah, aliran terpisah, dan direktori keluaran terpisah. Lihat panduan [multithreading](/slides/id/nodejs-java/multithreading/) untuk detailnya.

**Apakah objek Presentation thread‑safe?**

Tidak. Satu instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) harus dimuat, dimodifikasi, disimpan, dan dibuang dalam satu pekerja. Untuk pekerjaan paralel, buat instance independen per pekerja atau proses.

**Mengapa berkas HTML yang dihasilkan besar?**

Ekspor default dapat menyematkan sumber daya langsung ke dalam HTML. Font yang disematkan, gambar DPI tinggi, media, konten SVG, dan area gambar yang dipotong yang dipertahankan juga meningkatkan ukuran. Gunakan sumber daya eksternal, kecualikan font umum dari penyematan, dan turunkan `PicturesCompression` ketika ukuran lebih kecil lebih penting daripada kesetiaan maksimum.

**Mengapa ukuran font PowerPoint seperti 24 pt muncul sebagai 17.999819 pt di HTML?**

Hal ini dapat terjadi karena PowerPoint dan HTML menggunakan model DPI yang berbeda. PowerPoint menyimpan ukuran teks dalam satuan poin tipografis berbasis 72 DPI, sedangkan tata letak HTML berbasis piksel CSS pada model 96 DPI. Saat Aspose.Slides mengekspor presentasi ke HTML, ukuran font diterjemahkan antara kedua sistem, dan konversi dapat menghasilkan perbedaan pembulatan kecil.

Nilai‑nilai ini tidak menunjukkan perubahan visual sebenarnya pada ukuran font. Mereka hanya efek matematis sampingan dari konversi metrik teks antara PowerPoint dan HTML.

**Bagaimana saya harus memilih baseUri untuk ekspor media?**

Pilih `baseUri` dari sudut pandang peramban dan berikan sebagai URI absolut. Untuk pratinjau lokal, Anda dapat memproduksinya dari direktori keluaran dengan URI `file:///`. Untuk penyebaran, gunakan URL absolut dari direktori media yang dipublikasikan. Jalur sistem file `path` dan `baseUri` peramban tidak harus berupa string yang sama, tetapi harus menggambarkan lokasi sumber daya yang sama.

**Apakah saya dapat menyertakan slide tersembunyi?**

Ya. Atur `ShowHiddenSlides` ke `true` pada [HtmlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmloptions/) ketika slide tersembunyi harus diekspor.