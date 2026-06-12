---
title: Mengonversi Presentasi PowerPoint ke HTML di Android
linktitle: PowerPoint ke HTML
type: docs
weight: 30
url: /id/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke HTML di Android. Gunakan Aspose.Slides untuk Android via Java untuk mengekspor file PPT dan PPTX, slide terpilih, catatan, font, gambar, SVG, dan media."
---
## **Ikhtisar**

Aspose.Slides untuk Android via Java dapat menyimpan presentasi PowerPoint sebagai HTML tanpa Microsoft PowerPoint. Konversi dasar terdiri dari satu pemuatan [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan pemanggilan `save` dengan [SaveFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/). Gunakan [HtmlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmloptions/) ketika Anda perlu mengontrol tata letak, font, gambar, catatan, komentar, output SVG, atau sumber daya yang ditautkan.

Panduan ini berfokus pada skenario ekspor HTML yang praktis:

- Mengekspor seluruh presentasi atau slide yang dipilih.
- Menghasilkan HTML ber tata letak tetap, responsif, atau berbasis SVG.
- Menyertakan catatan pembicara dan komentar.
- Mengontrol kualitas gambar dan data gambar terpotong.
- Menyematkan font atau menyimpan file font secara terpisah.
- Memilih cara penulisan dan referensi sumber daya eksternal serta file media.

Secara bawaan, ekspor HTML menghasilkan dokumen HTML yang berdiri sendiri dengan sebagian besar sumber daya disematkan. Ini memudahkan berbagi satu file, tetapi dapat meningkatkan ukuran output. Untuk publikasi web, pertimbangkan sumber daya eksternal, DPI gambar yang lebih rendah, dan hanya menyematkan font yang tidak tersedia secara andal di lingkungan target.

## **Mengonversi Presentasi ke HTML**

Untuk mengekspor presentasi ke HTML, muat dengan [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan simpan dengan [SaveFormat.Html](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Contoh ini menulis satu file HTML. Objek presentasi dibuang di blok `finally`, yang melepaskan handle file dan sumber daya rendering setelah ekspor.

## **Menggunakan HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmloptions/) adalah kelas konfigurasi utama untuk ekspor HTML. Pengaturan umum meliputi:

- `SlidesLayoutOptions`: menambahkan catatan, komentar, handout, atau informasi tata letak lainnya.
- `HtmlFormatter`: mengubah struktur dokumen HTML atau mendelegasikan pemformatan ke kontroler.
- `SlideImageFormat`: mengubah cara slide direpresentasikan, misalnya sebagai SVG.
- `PicturesCompression`: mengontrol DPI gambar dan ukuran output.
- `DeletePicturesCroppedAreas`: menyimpan atau menghapus data gambar terpotong.
- `SvgResponsiveLayout`: membuat konten SVG yang diekspor menyesuaikan dengan wadahnya.
- `ShowHiddenSlides`: menyertakan slide tersembunyi bila diperlukan.

Bagian berikut menampilkan opsi paling umum secara terpisah sehingga Anda dapat menggabungkan hanya yang diperlukan dalam alur kerja Anda.

## **Mengonversi Slide Terpilih ke HTML**

Overload `Presentation.save` yang menerima nomor slide menggunakan posisi slide berbasis 1. Loop di bawah menyimpan setiap slide ke file HTML terpisah.

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

Gunakan pola ini ketika situs web atau aplikasi memerlukan satu halaman HTML per slide. Jika setiap slide harus memiliki tata letak yang sama, buat satu instance [HtmlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmloptions/) dan berikan ke setiap pemanggilan `save`.

## **Membuat HTML Responsif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/responsivehtmlcontroller/) menyediakan output HTML responsif melalui [HtmlFormatter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmlformatter/). Gunakan ketika halaman yang diekspor harus beradaptasi lebih baik dengan lebar browser.

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

Untuk tata letak responsif berbasis SVG, atur `SvgResponsiveLayout` pada [HtmlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmloptions/). Ini berguna ketika konten slide diekspor sebagai markup SVG yang dapat diskalakan.

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

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notescommentslayoutingoptions/) melalui `HtmlOptions.SlidesLayoutOptions` untuk menyertakan catatan pembicara atau komentar. Catatan dan komentar tersembunyi secara default kecuali Anda menentukan posisinya.

Misalkan presentasi sumber berisi catatan pembicara:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Kode berikut mengekspor konten slide beserta catatan pembicara di bawah slide.

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

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Untuk mengekspor komentar, atur `CommentsPosition`, misalnya ke `CommentsPositions.Right` atau `CommentsPositions.Bottom`. Jika Anda hanya membutuhkan komentar, hapus `NotesPosition`. Jika Anda membutuhkan kedua catatan dan komentar, atur kedua properti tersebut.

## **Mengontrol Kualitas Gambar dan Area Terpotong**

Ekspor HTML dapat mengompresi gambar slide untuk mengurangi ukuran output. Atur `PicturesCompression` ke nilai dari [PicturesCompression](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/picturescompression/) ketika Anda memerlukan kualitas gambar yang lebih tinggi.

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

Secara default, area terpotong gambar dapat dihapus dari output yang diekspor. Simpan data terpotong hanya ketika pengguna harus dapat memulihkan atau memeriksa bagian gambar yang tersembunyi tersebut. Menyimpannya dapat meningkatkan ukuran HTML.

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

Untuk header dokumen khusus, file CSS yang ditautkan, atau markup khusus di sekitar slide dan shape, implementasikan [IHtmlFormattingController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ihtmlformattingcontroller/) dan berikan ke [HtmlFormatter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmlformatter/) dengan `createCustomFormatter`.

## **Menyematkan Font**

Jika lingkungan target mungkin tidak memiliki font presentasi yang terpasang, sematkan font dalam HTML dengan [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). Menyematkan meningkatkan kesetiaan visual tetapi menambah ukuran output.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Kecualikan font hanya ketika Anda yakin browser atau sistem target sudah menyediakan font tersebut. Untuk font merek atau font yang kurang umum, menyematkan biasanya lebih aman.

## **Menautkan File Font Ali Menyematkannya**

Untuk mengurangi ukuran file HTML, Anda dapat menulis data font ke file WOFF terpisah dan menambahkan aturan `@font-face` ke HTML. Helper di bawah memperluas [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) dan menimpa `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Dalam contoh ini, file font disimpan ke `html-output/fonts`, dan HTML merujuknya dengan URL seperti `fonts/BrandFont-normal-400.woff`. Jika file HTML dan font ditempatkan di lokasi lain, pilih `fontUrlPrefix` sehingga cocok dengan jalur URL yang dideploy.

## **Menyimpan Sumber Daya Secara Eksternal**

HTML yang berdiri sendiri mudah dipindahkan, tetapi sumber daya Base64 yang disematkan dapat membuat file menjadi besar. Jika aplikasi Anda memerlukan file gambar eksternal, implementasikan [ILinkEmbedController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/) dan berikan ke konstruktor [HtmlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmloptions/).

Saat Anda mengeksternalisasi sumber daya, pilih dua jalur dengan hati-hati:

- Jalur output sistem file, tempat aplikasi Anda menulis gambar, font, audio, atau video yang dihasilkan.
- Jalur URL, yang digunakan browser dari dokumen HTML untuk memuat file tersebut.

## **Mengekspor File Media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) mengekspor file video dan audio serta menulis HTML yang dapat memutarnya di browser. Konstruktornya menerima:

- `path`: direktori tempat file media yang dihasilkan akan ditulis.
- `fileName`: nama file HTML yang sedang dihasilkan.
- `baseUri`: prefiks URI absolut yang digunakan dalam tautan HTML ke file media.

Jika file HTML berada di `html-output/presentation.html` dan file media disimpan di `html-output/media`, `path` harus menunjuk ke direktori media di disk, sementara `baseUri` harus menunjuk ke direktori yang sama dari perspektif browser. Untuk pratinjau lokal, Anda dapat membangun URI `file:///` dari direktori media. Untuk aplikasi yang dideploy, gunakan URL absolut dari direktori media yang dipublikasikan.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Gunakan direktori output yang unik per pekerjaan ekspor, terutama dalam aplikasi server. Jalur output yang dibagikan dapat menyebabkan file dari konversi berbeda menimpa satu sama lain.

## **Kinerja dan Manajemen Sumber Daya**

Konversi HTML merupakan operasi rendering, sehingga waktu proses dan penggunaan memori bergantung pada jumlah slide, resolusi gambar, font, efek, diagram, dan media yang disematkan. Nilai DPI `PicturesCompression` yang lebih tinggi, font yang disematkan, output SVG, dan area gambar terpotong yang dipertahankan dapat meningkatkan kesetiaan tetapi biasanya menambah ukuran output.

Untuk konversi batch:

- Buang setiap instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dengan segera.
- Gunakan direktori output terpisah untuk pekerjaan terpisah.
- Hindari menyematkan font umum kecuali kesetiaan memerlukannya.
- Turunkan DPI gambar ketika HTML hanya untuk pratinjau atau thumbnail.
- Simpan presentasi sumber, HTML yang dihasilkan, dan sumber daya eksternal bersama hingga jalur deployment final.

## **FAQ**

**Apakah hyperlink dipertahankan dalam output HTML?**

Ya. Hyperlink pada presentasi diekspor ke HTML dan tetap dapat diklik ketika URL target valid.

**Dapatkah saya mengonversi presentasi ke HTML secara paralel?**

Ya, tetapi jangan berbagi satu instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) di antara thread. Proses file yang berbeda dengan instance presentasi terpisah, aliran terpisah, dan direktori output terpisah. Lihat panduan [multithreading](/slides/id/androidjava/multithreading/) untuk detailnya.

**Apakah objek Presentation thread‑safe?**

Tidak. Satu instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) harus dimuat, dimodifikasi, disimpan, dan dibuang pada satu thread. Untuk kerja paralel, buat instance independen per thread atau proses.

**Mengapa file HTML yang dihasilkan berukuran besar?**

Ekspor bawaan dapat menyematkan sumber daya langsung di dalam HTML. Font yang disematkan, gambar DPI tinggi, media, konten SVG, dan area gambar terpotong yang dipertahankan juga meningkatkan ukuran. Gunakan sumber daya eksternal, kecualikan font umum dari penyematan, dan turunkan `PicturesCompression` ketika ukuran output lebih penting daripada kesetiaan maksimum.

**Mengapa ukuran font PowerPoint seperti 24 pt muncul sebagai 17.999819 pt di HTML?**

Hal ini dapat terjadi karena PowerPoint dan HTML menggunakan model DPI yang berbeda. PowerPoint menyimpan ukuran teks dalam point tipografi berdasarkan 72 DPI, sedangkan tata letak HTML menggunakan piksel CSS dalam model 96 DPI. Saat Aspose.Slides mengekspor presentasi ke HTML, ukuran font diterjemahkan antara kedua sistem tersebut, dan konversi dapat memperkenalkan perbedaan pembulatan kecil.

Nilai tersebut tidak menunjukkan perubahan visual ukuran font yang sebenarnya. Itu hanya efek matematis samping dari konversi metrik teks antara PowerPoint dan HTML.

**Bagaimana cara memilih baseUri untuk ekspor media?**

Pilih `baseUri` dari perspektif browser dan berikan sebagai URI absolut. Untuk pratinjau lokal, Anda dapat menurunkannya dari direktori output dengan `mediaDirectory.toUri().toString()`. Untuk deployment, gunakan URL absolut dari direktori media yang dipublikasikan. `path` sistem file dan `baseUri` browser tidak harus berupa string yang sama, tetapi harus menggambarkan lokasi sumber daya yang sama.

**Dapatkah saya menyertakan slide tersembunyi?**

Ya. Atur `ShowHiddenSlides` ke `true` pada [HtmlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/htmloptions/) ketika slide tersembunyi harus diekspor.