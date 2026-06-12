---
title: Mengonversi Presentasi PowerPoint ke HTML dengan Java
linktitle: PowerPoint ke HTML
type: docs
weight: 30
url: /id/java/convert-powerpoint-to-html/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPT
- mengonversi PPTX
- PowerPoint ke HTML
- presentasi ke HTML
- slide ke HTML
- PPT ke HTML
- PPTX ke HTML
- menyimpan PowerPoint sebagai HTML
- menyimpan presentasi sebagai HTML
- menyimpan slide sebagai HTML
- menyimpan PPT sebagai HTML
- menyimpan PPTX sebagai HTML
- mengekspor PPT ke HTML
- mengekspor PPTX ke HTML
- Java
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint ke HTML dengan Java. Gunakan Aspose.Slides untuk mengekspor berkas PPT dan PPTX, slide terpilih, catatan, font, gambar, SVG, dan media."
---
## **Gambaran Umum**

Aspose.Slides for Java dapat menyimpan presentasi PowerPoint sebagai HTML tanpa Microsoft PowerPoint. Konversi dasar adalah memuat satu [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan memanggil `save` dengan [SaveFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/). Gunakan [HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/) ketika Anda perlu mengontrol tata letak yang diekspor, font, gambar, catatan, komentar, output SVG, atau sumber daya yang ditautkan.

Panduan ini berfokus pada skenario ekspor HTML yang praktis:

- Mengekspor seluruh presentasi atau slide tertentu.
- Menghasilkan HTML dengan tata letak tetap, responsif, atau berbasis SVG.
- Menyertakan catatan pembicara dan komentar.
- Mengontrol kualitas gambar dan data gambar terpotong.
- Menyematkan font atau menyimpan berkas font secara terpisah.
- Memilih cara sumber daya eksternal dan berkas media ditulis dan dirujuk.

Secara default, ekspor HTML menghasilkan dokumen HTML mandiri di mana sebagian besar sumber daya disematkan. Ini memudahkan berbagi satu berkas, tetapi dapat meningkatkan ukuran keluaran. Untuk penerbitan web, pertimbangkan sumber daya eksternal, DPI gambar yang lebih rendah, dan hanya menyematkan font yang tidak dapat diandalkan tersedia di lingkungan target.

## **Mengonversi Presentasi ke HTML**

Untuk mengekspor presentasi ke HTML, muat dengan [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan simpan dengan [SaveFormat.Html](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Contoh ini menulis satu berkas HTML. Objek presentasi dibuang di blok `finally`, yang melepaskan pegangan berkas dan sumber daya rendering setelah ekspor.

## **Menggunakan HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/) adalah kelas konfigurasi utama untuk ekspor HTML. Pengaturan umum meliputi:

- `SlidesLayoutOptions`: menambahkan catatan, komentar, handout, atau informasi tata letak lainnya.
- `HtmlFormatter`: mengubah struktur dokumen HTML atau mendelegasikan pemformatan ke pengontrol.
- `SlideImageFormat`: mengubah cara slide direpresentasikan, misalnya sebagai SVG.
- `PicturesCompression`: mengontrol DPI gambar dan ukuran keluaran.
- `DeletePicturesCroppedAreas`: mempertahankan atau menghapus data gambar yang terpotong.
- `SvgResponsiveLayout`: membuat konten SVG yang diekspor menyesuaikan diri dengan kontainer.
- `ShowHiddenSlides`: menyertakan slide tersembunyi bila diperlukan.

Bagian berikut menampilkan opsi paling umum secara terpisah sehingga Anda dapat menggabungkan hanya yang diperlukan dalam alur kerja Anda.

## **Mengonversi Slide Terpilih ke HTML**

Overload `Presentation.save` yang menerima nomor slide menggunakan posisi slide berbasis 1. Loop di bawah menyimpan setiap slide ke berkas HTML terpisah.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Gunakan pola ini ketika situs web atau aplikasi memerlukan satu halaman HTML per slide. Jika setiap slide harus memiliki tata letak yang sama, buat satu instance [HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/) dan berikan ke setiap pemanggilan `save`.

## **Membuat HTML Responsif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/id/java/com.aspose.slides/responsivehtmlcontroller/) menyediakan output HTML responsif melalui [HtmlFormatter](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmlformatter/). Gunakan ketika halaman yang diekspor harus beradaptasi lebih baik dengan lebar peramban.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Untuk tata letak responsif berbasis SVG, atur `SvgResponsiveLayout` pada [HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/). Ini berguna ketika konten slide diekspor sebagai markup SVG yang dapat diskalakan.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Menyertakan Catatan Pembicara dan Komentar**

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/notescommentslayoutingoptions/) melalui `HtmlOptions.setSlidesLayoutOptions` untuk menyertakan catatan pembicara atau komentar. Catatan dan komentar disembunyikan secara default kecuali Anda menentukan posisinya.

Misalkan presentasi sumber berisi catatan pembicara:

![Slide dengan catatan pembicara di PowerPoint](slide_with_notes.png)

Kode berikut mengekspor konten slide dengan catatan pembicara di bawah slide.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

HTML yang diekspor menyertakan area catatan:

![Output HTML dengan slide dan catatan pembicara](HTML_with_notes.png)

Untuk mengekspor komentar, atur `CommentsPosition`, misalnya ke `CommentsPositions.Right` atau `CommentsPositions.Bottom`. Jika Anda hanya memerlukan komentar, hapus `NotesPosition`. Jika Anda memerlukan keduanya, atur kedua properti.

## **Mengontrol Kualitas Gambar dan Area Terpotong**

Ekspor HTML dapat mengompresi gambar slide untuk mengurangi ukuran keluaran. Atur `PicturesCompression` ke nilai dari [PicturesCompression](https://reference.aspose.com/slides/id/java/com.aspose.slides/picturescompression/) ketika Anda memerlukan kualitas gambar yang lebih tinggi.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Secara default, area terpotong pada gambar dapat dihapus dari output yang diekspor. Pertahankan data terpotong hanya ketika pengguna harus dapat memulihkan atau memeriksa bagian gambar yang tersembunyi tersebut. Menyimpannya dapat meningkatkan ukuran HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Menambahkan CSS**

Untuk penataan sederhana, berikan string CSS ke `HtmlFormatter.createDocumentFormatter`. Ini mengubah dokumen HTML di sekitarnya sementara Aspose.Slides tetap merender konten slide.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Untuk header dokumen khusus, berkas CSS yang ditautkan, atau markup khusus di sekitar slide dan shape, implementasikan [IHtmlFormattingController](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihtmlformattingcontroller/) dan berikan ke [HtmlFormatter](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmlformatter/) dengan `createCustomFormatter`.

## **Menyematkan Font**

Jika lingkungan target mungkin tidak memiliki font presentasi yang terinstal, sematkan font dalam HTML dengan [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/java/com.aspose.slides/embedallfontshtmlcontroller/). Penyematan meningkatkan fidelitas visual tetapi menambah ukuran keluaran.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Kecualikan font hanya ketika Anda yakin bahwa peramban atau sistem target sudah menyediakannya. Untuk font merek atau font yang kurang umum, penyematan biasanya lebih aman.

## **Menautkan Berkas Font Alih-alih Menyematkannya**

Untuk mengurangi ukuran berkas HTML, Anda dapat menulis data font ke berkas WOFF terpisah dan menambahkan aturan `@font-face` ke HTML. Pembantu di bawah memperluas [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/java/com.aspose.slides/embedallfontshtmlcontroller/) dan menimpa `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Dalam contoh ini, berkas font disimpan ke `html-output/fonts`, dan HTML merujuknya dengan URL seperti `fonts/BrandFont-normal-400.woff`. Jika berkas HTML dan font ditempatkan di lokasi lain, pilih `fontUrlPrefix` sehingga cocok dengan jalur URL yang dideploy.

## **Menyimpan Sumber Daya Secara Eksternal**

HTML mandiri mudah dipindahkan, tetapi sumber daya Base64 yang disematkan dapat membuat berkas menjadi besar. Jika aplikasi Anda memerlukan berkas gambar eksternal, implementasikan [ILinkEmbedController](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) dan berikan ke konstruktor [HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/).

Saat Anda mengeksternalisasi sumber daya, pilih dua jalur secara sengaja:

- Jalur output sistem berkas, tempat aplikasi Anda menulis gambar, font, audio, atau video yang dihasilkan.
- Jalur URL, yaitu apa yang digunakan peramban dari dokumen HTML untuk memuat berkas‑berkas tersebut.

## **Mengekspor Berkas Media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/id/java/com.aspose.slides/videoplayerhtmlcontroller/) mengekspor berkas video dan audio serta menulis HTML yang dapat memutarnya di peramban. Konstruktornya menerima:

- `path`: direktori tempat berkas media yang dihasilkan akan ditulis.
- `fileName`: nama berkas HTML yang sedang dihasilkan.
- `baseUri`: prefiks URI absolut yang digunakan dalam tautan HTML ke berkas media.

Jika berkas HTML berada di `html-output/presentation.html` dan berkas media disimpan di `html-output/media`, `path` harus menunjuk ke direktori media di disk, sedangkan `baseUri` harus menunjuk ke direktori yang sama dari sudut pandang peramban. Untuk pratinjau lokal, Anda dapat membangun URI `file:///` dari direktori media. Untuk aplikasi yang dideploy, gunakan URL absolut dari direktori media yang dipublikasikan.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Gunakan direktori output yang unik per pekerjaan ekspor, terutama pada aplikasi server. Jalur output yang dibagi dapat menyebabkan berkas dari konversi berbeda saling menimpa.

## **Kinerja dan Manajemen Sumber Daya**

Konversi HTML merupakan operasi rendering, sehingga waktu proses dan penggunaan memori bergantung pada jumlah slide, resolusi gambar, font, efek, diagram, dan media yang disematkan. Nilai DPI `PicturesCompression` yang lebih tinggi, font yang disematkan, output SVG, dan area gambar terpotong yang dipertahankan dapat meningkatkan fidelitas tetapi biasanya menambah ukuran keluaran.

Untuk konversi batch:

- Buang setiap instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) sesegera mungkin.
- Gunakan direktori output terpisah untuk pekerjaan terpisah.
- Hindari menyematkan font umum kecuali diperlukan untuk fidelitas.
- Turunkan DPI gambar ketika HTML hanya untuk pratinjau atau thumbnail.
- Simpan presentasi sumber, HTML yang dihasilkan, dan sumber daya eksternal bersama hingga jalur penyebaran final.

## **FAQ**

**Apakah tautan hiperpreserve dalam output HTML?**

Ya. Tautan hiperpresentasi diekspor ke HTML dan tetap dapat diklik ketika URL target valid.

**Bisakah saya mengonversi presentasi ke HTML secara paralel?**

Ya, tetapi jangan berbagi satu instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) di antara utas. Proses berkas yang berbeda dengan instance presentasi terpisah, aliran terpisah, dan direktori output terpisah. Lihat panduan [multithreading](/slides/id/java/multithreading/) untuk detailnya.

**Apakah objek Presentation bersifat thread‑safe?**

Tidak. Satu instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) harus dimuat, dimodifikasi, disimpan, dan dibuang pada satu utas. Untuk pekerjaan paralel, buat instance independen per utas atau proses.

**Mengapa berkas HTML yang dihasilkan berukuran besar?**

Ekspor default dapat menyematkan sumber daya langsung ke dalam HTML. Font yang disematkan, gambar DPI tinggi, media, konten SVG, dan area gambar terpotong yang dipertahankan juga meningkatkan ukuran. Gunakan sumber daya eksternal, kecualikan font umum dari penyematan, dan turunkan `PicturesCompression` ketika ukuran kecil lebih penting daripada fidelitas maksimum.

**Mengapa ukuran font PowerPoint seperti 24 pt muncul sebagai 17.999819 pt di HTML?**

Hal ini dapat terjadi karena PowerPoint dan HTML menggunakan model DPI yang berbeda. PowerPoint menyimpan ukuran teks dalam poin tipografi berdasarkan 72 DPI, sementara tata letak HTML berbasis piksel CSS dalam model 96 DPI. Saat Aspose.Slides mengekspor presentasi ke HTML, ukuran font diterjemahkan antara kedua sistem tersebut, dan konversi dapat menyebabkan perbedaan pembulatan kecil.

Nilai‑nilai ini tidak menunjukkan perubahan ukuran font visual yang sebenarnya. Mereka hanya efek samping matematis dari konversi metrik teks antara PowerPoint dan HTML.

**Bagaimana saya harus memilih baseUri untuk ekspor media?**

Pilih `baseUri` dari sudut pandang peramban dan berikan sebagai URI absolut. Untuk pratinjau lokal, Anda dapat menghasilkannya dari direktori output dengan `mediaDirectory.toUri().toString()`. Untuk penyebaran, gunakan URL absolut dari direktori media yang dipublikasikan. `path` sistem berkas dan `baseUri` peramban tidak harus berupa string yang sama, tetapi harus menggambarkan lokasi sumber daya yang sama.

**Bisakah saya menyertakan slide tersembunyi?**

Ya. Atur `ShowHiddenSlides` menjadi `true` pada [HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/) ketika slide tersembunyi harus diekspor.