---
title: Optimalkan Manajemen Gambar dalam Presentasi Menggunakan Java
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/java/image/
keywords:
- tambahkan gambar
- tambahkan foto
- tambahkan bitmap
- ganti gambar
- ganti foto
- dari web
- latar belakang
- tambahkan PNG
- tambahkan JPG
- tambahkan SVG
- sumber daya SVG eksternal
- resolver SVG
- gambar SVG tertaut
- font SVG
- tambahkan EMF
- tambahkan WMF
- tambahkan TIFF
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Permudah manajemen gambar di PowerPoint dan OpenDocument dengan Aspose.Slides untuk Java, mengoptimalkan kinerja dan mengautomasi alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan secara visual lebih menarik. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar ke slide dari file, internet, atau sumber lain. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide presentasi dengan beberapa cara.

{{% alert title="Tip" color="primary" %}} 
Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan Anda dengan cepat membuat presentasi dari gambar. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Jika Anda ingin menambahkan gambar sebagai bingkai gambar—terutama bila Anda berencana mengubah ukurannya, menerapkan efek, atau menggunakan opsi pemformatan standar lainnya—lihat [Bingkai Gambar](/slides/id/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Catatan" color="warning" %}}
Anda dapat mengonversi gambar dari satu format ke format lain. Lihat halaman berikut: konversi [gambar ke JPG](https://products.aspose.com/slides/id/java/conversion/image-to-jpg/), [JPG ke gambar](https://products.aspose.com/slides/id/java/conversion/jpg-to-image/), [JPG ke PNG](https://products.aspose.com/slides/id/java/conversion/jpg-to-png/), [PNG ke JPG](https://products.aspose.com/slides/id/java/conversion/png-to-jpg/), [PNG ke SVG](https://products.aspose.com/slides/id/java/conversion/png-to-svg/), dan [SVG ke PNG](https://products.aspose.com/slides/id/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides mendukung gambar dalam format populer seperti JPEG, PNG, BMP, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau lebih gambar yang disimpan di komputer Anda ke slide presentasi. Kode contoh Java berikut menunjukkan cara menambahkan gambar ke slide:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Menambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak disimpan di komputer Anda, Anda dapat menambahkannya langsung dari web. 

Kode contoh Java berikut menunjukkan cara menambahkan gambar dari web ke slide:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Menambahkan Gambar ke Slide Master**

Slide master menyimpan dan mengontrol informasi seperti tema dan tata letak untuk slide yang menggunakannya. Ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul di setiap slide yang menggunakan master tersebut. 

Kode contoh Java berikut menunjukkan cara menambahkan gambar ke slide master:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Menambahkan Gambar sebagai Latar Belakang Slide**

Anda dapat menggunakan gambar sebagai latar belakang untuk satu atau lebih slide. Untuk detail, lihat *[Menetapkan Gambar sebagai Latar Belakang Slide](/slides/id/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Menambahkan SVG ke Presentasi**

Konten SVG dapat ditambahkan ke presentasi menggunakan kelas [SvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgimage/). Objek [ISvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgimage/) yang dihasilkan kemudian dapat ditambahkan ke koleksi gambar presentasi dan digunakan untuk membuat bingkai gambar. 

Contoh Java berikut mengimpor string SVG yang berdiri sendiri. Semua gambar, gaya, dan sumber daya lain yang digunakan oleh SVG ini disematkan langsung dalam konten SVG. 

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengimpor Konten SVG dengan Sumber Daya Eksternal**

File SVG yang diekspor dari alat desain, editor diagram, sistem ikon, dan pipeline web dapat merujuk ke sumber daya yang disimpan di luar dokumen SVG. Misalnya, sebuah SVG dapat berisi tautan gambar seperti `images/photo.png`, nilai CSS `url(...)`, atau URL font. 

Untuk mengimpor konten SVG semacam itu, buat implementasi [IExternalResourceResolver](https://reference.aspose.com/slides/id/java/com.aspose.slides/iexternalresourceresolver/) dan berikan bersama dengan URI dasar ke konstruktor [SvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgimage/) yang sesuai. URI dasar mengidentifikasi lokasi dokumen SVG dan digunakan untuk menyelesaikan tautan relatif. 

Antarmuka [ISvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgimage/) menyediakan akses ke informasi tentang SVG yang diimpor: 

- `getSvgContent()` mengembalikan markup SVG sebagai string. 
- `getSvgData()` mengembalikan konten SVG sebagai array byte. 
- `getBaseUri()` mengembalikan URI dasar yang digunakan untuk tautan relatif. 
- `getExternalResourceResolver()` mengembalikan resolver yang ditetapkan pada gambar SVG. 

### **Implementasikan Resolver Sumber Daya Eksternal**

Resolver memiliki dua metode: 

- `resolveUri` menggabungkan URI dasar dan tautan sumber daya relatif serta mengembalikan URI absolut. Kembalikan `null` ketika tautan tidak dapat diselesaikan atau tidak diizinkan. 
- `getEntity` mengembalikan aliran yang dapat dibaca untuk URI sumber daya absolut. Kembalikan `null` ketika sumber daya tidak ada, diblokir, atau tidak tersedia. Aliran fallback juga dapat dikembalikan bila tepat. 

Resolver berikut memuat sumber daya yang ditautkan hanya dari direktori lokal yang diizinkan. Sumber daya jaringan dan jalur di luar direktori yang diizinkan diblokir. Gambar fallback opsional dikembalikan untuk tautan gambar yang tidak dapat diselesaikan. 

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Resolver ini sengaja hanya mengizinkan file lokal.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Gunakan fallback hanya untuk sumber daya gambar. Mengembalikan aliran gambar
            // untuk font atau stylesheet yang hilang tidak akan valid.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Menyelesaikan Sumber Daya yang Ditautkan Selama Impor SVG**

Misalkan `assets/diagram.svg` berisi referensi relatif seperti: 

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Contoh Java berikut memberikan URI file SVG sebagai URI dasar dan menyediakan resolver khusus. Resolver mengkonversi tautan gambar relatif menjadi URI absolut dan mengembalikan aliran yang berisi sumber daya yang ditautkan saat Aspose.Slides memproses SVG. 

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// URI dasar mewakili lokasi dokumen SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kelas `SvgImage` juga menyediakan overload yang menerima data SVG sebagai array byte atau aliran input, bersama dengan resolver sumber daya eksternal dan URI dasar. 

{{% alert title="Penting" color="warning" %}} 
Resolver sumber daya membuat sumber daya eksternal tersedia saat Aspose.Slides memproses dan merender SVG. Ia tidak memodifikasi markup SVG asli atau secara otomatis menyematkan sumber daya yang telah diselesaikan ke dalamnya. 

Ketika sebuah `ISvgImage` ditambahkan ke koleksi gambar presentasi, file PPTX dapat berisi baik representasi SVG asli maupun gambar raster fallback. Sumber daya yang ditautkan dapat muncul dalam gambar fallback yang dihasilkan sementara tautan relatif seperti `images/photo.png` tetap tidak berubah dalam SVG yang disimpan. Aplikasi yang merender representasi SVG asli mungkin akan mengabaikan konten yang ditautkan ketika sumber daya eksternal asli tidak tersedia. 
{{% /alert %}}

### **Buat Gambar SVG Portabel**

Untuk membuat gambar SVG yang tidak bergantung pada file eksternal, jadikan SVG berdiri sendiri sebelum membuat `SvgImage`. Misalnya, ganti URL gambar yang ditautkan dengan URI `data:` yang berisi data gambar: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Setelah semua sumber daya yang diperlukan disematkan dalam konten SVG, buat `SvgImage`, tambahkan ke koleksi gambar presentasi, dan sisipkan ke dalam bingkai gambar seperti yang ditunjukkan pada contoh sebelumnya. 

### **Tangani Sumber Daya yang Hilang atau Diblokir**

Kembalikan `null` dari `resolveUri` ketika URI sumber daya tidak valid, dilarang, atau tidak dapat diselesaikan. Kembalikan `null` dari `getEntity` ketika sumber daya tidak dapat dibaca. Aspose.Slides melanjutkan proses SVG tanpa sumber daya tersebut bila memungkinkan. 

Aliran fallback dapat dikembalikan untuk sumber daya yang hilang, tetapi isinya harus kompatibel dengan tipe sumber daya yang diminta. Misalnya, kembalikan aliran gambar hanya untuk gambar yang hilang, bukan untuk font atau stylesheet. 

{{% alert title="Keamanan" color="warning" %}} 
Jangan menyelesaikan jalur file sembarangan atau URL jaringan yang tidak dibatasi dari file SVG yang tidak tepercaya. Batasi skema, direktori, dan host yang diizinkan. Untuk sumber daya jaringan, terapkan juga batas waktu koneksi, batas ukuran respons, dan validasi konten. 
{{% /alert %}}

## **Mengonversi SVG menjadi Sekumpulan Bentuk**

Aspose.Slides dapat mengonversi SVG menjadi sekumpulan bentuk, mirip dengan fungsionalitas yang sesuai di PowerPoint: 

![PowerPoint Popup Menu](img_01_01.png)

Fungsionalitas ini disediakan oleh overload metode [addGroupShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection) yang menerima objek [ISvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISvgImage) sebagai argumen pertama. 

Kode contoh Java berikut menunjukkan cara menggunakan metode ini untuk mengonversi file SVG menjadi sekumpulan bentuk: 

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nama file SVG sumber.
String svgFileName = "sample.svg";

// Nama file presentasi output.
String outPptxPath = "presentation.pptx";

// Buat presentasi baru.
IPresentation presentation = new Presentation();
try {
    // Baca konten file SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Buat objek SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dapatkan ukuran slide.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Konversi gambar SVG menjadi grup bentuk dan skala ke ukuran slide.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Simpan presentasi dalam format PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Menambahkan Gambar sebagai EMF ke Slide**

Aspose.Slides for Java memungkinkan Anda menghasilkan gambar EMF dari lembar kerja Excel dengan Aspose.Cells dan menambahkannya ke slide presentasi. 

Kode contoh Java berikut menunjukkan cara melakukannya: 

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Simpan workbook ke aliran.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Tambahkan file apa adanya sehingga gambar tetap vektor EMF bukan raster.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Mengganti Gambar dalam Koleksi Gambar**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi, termasuk gambar yang digunakan oleh bentuk slide. Bagian ini menjelaskan beberapa cara untuk memperbarui gambar dalam koleksi. Anda dapat mengganti gambar menggunakan data byte mentah, instance [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/), atau gambar lain yang sudah ada dalam koleksi. 

Ikuti langkah-langkah di bawah ini: 

1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). 
1. Muat gambar baru dari file ke dalam array byte. 
1. Ganti gambar target dengan gambar baru menggunakan array byte. 
1. Pada pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut. 
1. Pada pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi. 
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX. 

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Cara pertama.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Cara kedua.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Cara ketiga.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Simpan presentasi ke file.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}} 
Dengan konverter gratis [Text to GIF](https://products.aspose.app/slides/id/text-to-gif) dari Aspose, Anda dapat dengan mudah menganimasikan teks dan membuat GIF dari teks. 
{{% /alert %}}

## **FAQ**

**Apakah resolusi gambar asli tetap utuh setelah penyisipan?**

Ya. Piksel sumber dipertahankan, tetapi penampilan akhir tergantung pada bagaimana [gambar](/slides/id/java/picture-frame/) diskalakan pada slide dan kompresi apa pun yang diterapkan saat menyimpan. 

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Letakkan logo pada master slide atau tata letak dan ganti di koleksi gambar presentasi—pembaruan akan menyebar ke semua elemen yang menggunakan sumber daya tersebut. 

**Apakah SVG yang disisipkan dapat dikonversi menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi grup bentuk, setelah itu bagian individual menjadi dapat diedit dengan properti bentuk standar. 

**Bagaimana cara menetapkan gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Tetapkan gambar sebagai latar belakang](/slides/id/java/presentation-background/) pada master slide atau tata letak yang relevan—setiap slide yang menggunakan master/tata letak tersebut akan mewarisi latar belakang. 

**Bagaimana saya mencegah presentasi menjadi terlalu besar karena banyak gambar?**

Gunakan kembali satu sumber daya gambar alih-alih duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan simpan grafik yang berulang pada master bila sesuai.