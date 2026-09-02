---
title: Optimalkan Manajemen Gambar dalam Presentasi Menggunakan PHP
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/php-java/image/
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
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Permudah manajemen gambar di PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java, mengoptimalkan kinerja dan mengotomatisasi alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan secara visual lebih menarik. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar ke slide dari file, internet, atau sumber lainnya. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide presentasi dengan beberapa cara.

{{% alert  title="Tip" color="primary" %}} 
Aspose menyediakan konverter gratis—[JPEG to PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG to PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan Anda dengan cepat membuat presentasi dari gambar. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Jika Anda ingin menambahkan gambar sebagai bingkai gambar—terutama jika Anda berencana untuk mengubah ukuran, menerapkan efek, atau menggunakan opsi pemformatan standar lainnya—lihat [Picture Frame](/slides/id/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Anda dapat mengonversi gambar dari satu format ke format lain. Lihat halaman berikut: konversi [image to JPG](https://products.aspose.com/slides/id/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/id/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/id/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/id/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/id/php-java/conversion/png-to-svg/), dan [SVG to PNG](https://products.aspose.com/slides/id/php-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides mendukung gambar dalam format populer seperti JPEG, PNG, BMP, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar yang disimpan di komputer Anda ke slide presentasi. Kode contoh PHP berikut menunjukkan cara menambahkan gambar ke slide:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Menambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak disimpan di komputer Anda, Anda dapat menambahkannya langsung dari web. 

Contoh kode PHP berikut menunjukkan cara menambahkan gambar dari web ke slide:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Menambahkan Gambar ke Slide Master**

Slide master menyimpan dan mengontrol informasi seperti tema dan tata letak untuk slide yang menggunakannya. Ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul di setiap slide yang berbasis master tersebut. 

Contoh kode PHP berikut menunjukkan cara menambahkan gambar ke slide master:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Menambahkan Gambar sebagai Latar Belakang Slide**

Anda dapat menggunakan gambar sebagai latar belakang untuk satu atau beberapa slide. Untuk detailnya, lihat *[Setting Images as Backgrounds for Slides](/slides/id/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Menambahkan SVG ke Presentasi**

Konten SVG dapat ditambahkan ke presentasi menggunakan kelas [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/). Objek gambar SVG yang dihasilkan kemudian dapat ditambahkan ke koleksi gambar presentasi dan digunakan untuk membuat bingkai gambar.

Contoh PHP berikut mengimpor string SVG yang berdiri sendiri. Semua gambar, gaya, dan sumber daya lain yang digunakan oleh SVG ini disematkan langsung dalam konten SVG.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mengimpor Konten SVG dengan Sumber Daya Eksternal**

File SVG yang diekspor dari alat desain, editor diagram, sistem ikon, dan pipeline web dapat merujuk pada sumber daya yang disimpan di luar dokumen SVG. Misalnya, SVG dapat berisi tautan gambar seperti `images/photo.png`, nilai CSS `url(...)`, atau URL font.

Untuk mengimpor konten SVG semacam itu, buat implementasi [ExternalResourceResolver](https://reference.aspose.com/slides/id/php-java/aspose.slides/externalresourceresolver/) dan berikan bersama dengan base URI ke konstruktor [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/) yang sesuai. Base URI mengidentifikasi lokasi dokumen SVG dan digunakan untuk menyelesaikan tautan relatif.

Objek gambar SVG menyediakan akses ke informasi tentang SVG yang diimpor:
- `getSvgContent()` mengembalikan markup SVG sebagai string.
- `getSvgData()` mengembalikan konten SVG sebagai array byte.
- `getBaseUri()` mengembalikan base URI yang digunakan untuk tautan relatif.
- `getExternalResourceResolver()` mengembalikan resolver yang ditetapkan pada gambar SVG.

### **Implementasikan Resolver Sumber Daya Eksternal**

Resolver memiliki dua metode:
- `resolveUri` menggabungkan base URI dan tautan sumber daya relatif serta mengembalikan URI absolut. Kembalikan `null` bila tautan tidak dapat diselesaikan atau tidak diizinkan.
- `getEntity` mengembalikan aliran yang dapat dibaca untuk URI sumber daya absolut. Kembalikan `null` bila sumber daya tidak ada, diblokir, atau tidak tersedia. Aliran cadangan juga dapat dikembalikan bila tepat.

Resolver berikut memuat sumber daya yang ditautkan hanya dari direktori lokal yang diizinkan. Sumber daya jaringan dan jalur di luar direktori yang diizinkan diblokir. Gambar cadangan opsional dikembalikan untuk tautan gambar yang tidak dapat diselesaikan.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Resolver ini sengaja hanya mengizinkan file lokal.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Gunakan fallback hanya untuk sumber daya gambar. Mengembalikan aliran gambar
            // untuk font atau stylesheet yang hilang tidak valid.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Menyelesaikan Sumber Daya Tertaut selama Impor SVG**

Anggap bahwa `assets/diagram.svg` berisi referensi relatif seperti:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Contoh PHP berikut memberikan URI file SVG sebagai base URI dan menyediakan resolver khusus. Resolver mengkonversi tautan gambar relatif menjadi URI absolut dan mengembalikan aliran yang berisi sumber daya tertaut saat Aspose.Slides memproses SVG.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Base URI mewakili lokasi dokumen SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Objek gambar SVG menampilkan konten sumber, data biner, base URI, dan resolver.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kelas `SvgImage` juga menyediakan overload yang menerima data SVG sebagai array byte atau aliran masukan, bersama dengan resolver sumber daya eksternal dan base URI.

{{% alert title="Important" color="warning" %}}
Resolver sumber daya membuat sumber daya eksternal tersedia saat Aspose.Slides memproses dan merender SVG. Itu tidak mengubah markup SVG asli atau secara otomatis menyematkan sumber daya yang telah diselesaikan ke dalamnya.

Ketika gambar SVG ditambahkan ke koleksi gambar presentasi, file PPTX dapat berisi representasi SVG asli serta gambar raster cadangan. Sumber daya yang ditautkan dapat muncul dalam gambar cadangan yang dihasilkan sementara tautan relatif seperti `images/photo.png` tetap tidak berubah dalam SVG yang disimpan. Aplikasi yang merender representasi SVG asli mungkin mengabaikan konten yang ditautkan ketika sumber daya eksternal asli tidak tersedia.
{{% /alert %}}

### **Buat Gambar SVG Portabel**

Untuk membuat gambar SVG yang tidak bergantung pada file eksternal, buat SVG berdiri sendiri sebelum membuat `SvgImage`. Misalnya, ganti URL gambar yang ditautkan dengan URI `data:` yang berisi data gambar:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Setelah semua sumber daya yang diperlukan disematkan dalam konten SVG, buat `SvgImage`, tambahkan ke koleksi gambar presentasi, dan sisipkan ke dalam bingkai gambar seperti pada contoh sebelumnya.

### **Tangani Sumber Daya yang Hilang atau Diblokir**

Kembalikan `null` dari `resolveUri` bila URI sumber daya tidak valid, dilarang, atau tidak dapat diselesaikan. Kembalikan `null` dari `getEntity` bila sumber daya tidak dapat dibaca. Aspose.Slides melanjutkan pemrosesan SVG tanpa sumber daya tersebut bila memungkinkan.

Aliran cadangan dapat dikembalikan untuk sumber daya yang hilang, tetapi isinya harus kompatibel dengan tipe sumber daya yang diminta. Misalnya, kembalikan aliran gambar hanya untuk gambar yang hilang, bukan untuk font atau stylesheet.

{{% alert title="Security" color="warning" %}}
Jangan menyelesaikan jalur file arbitrer atau URL jaringan tanpa batas dari file SVG yang tidak terpercaya. Batasi skema, direktori, dan host yang diizinkan. Untuk sumber daya jaringan, terapkan batas waktu koneksi, batas ukuran respons, dan validasi konten.
{{% /alert %}}

## **Mengonversi SVG menjadi Sekumpulan Bentuk**

Aspose.Slides dapat mengonversi SVG menjadi sekumpulan bentuk, mirip dengan fungsi yang bersesuaian di PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Fungsionalitas ini disediakan oleh overload metode [addGroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addgroupshape/) pada kelas [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/) yang menerima objek [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/) sebagai argumen pertama.

Contoh kode PHP berikut menunjukkan cara menggunakan metode ini untuk mengonversi file SVG menjadi sekumpulan bentuk:

```php
// Nama file SVG sumber.
$svgFileName = "sample.svg";

// Nama file presentasi output.
$outPptxPath = "presentation.pptx";

// Buat presentasi baru.
$presentation = new Presentation();
try {
    // Baca konten file SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Buat objek SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Dapatkan ukuran slide.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Konversi gambar SVG menjadi grup bentuk dan skalakan ke ukuran slide.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Simpan presentasi dalam format PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Menambahkan Gambar sebagai EMF ke Slide**

Aspose.Slides for PHP via Java memungkinkan Anda menghasilkan gambar EMF dari lembar kerja Excel dengan Aspose.Cells dan menambahkannya ke slide presentasi.

Contoh kode PHP berikut menunjukkan cara melakukannya:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Simpan workbook ke aliran.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Tambahkan file apa adanya sehingga gambar tetap menjadi vektor EMF alih-alih dirasterkan.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Mengganti Gambar dalam Koleksi Gambar**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi, termasuk gambar yang digunakan oleh bentuk slide. Bagian ini menjelaskan beberapa cara memperbarui gambar dalam koleksi. Anda dapat mengganti gambar menggunakan data byte mentah, instance [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/), atau gambar lain yang sudah ada dalam koleksi.

Ikuti langkah-langkah berikut:
1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Muat gambar baru dari file ke dalam array byte.
1. Ganti gambar target dengan gambar baru menggunakan array byte.
1. Pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
1. Pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

```php
// Membuat instance kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation("sample.pptx");
try {
    // Cara pertama.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Cara kedua.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // Cara ketiga.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Simpan presentasi ke file.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Dengan konverter gratis [Text to GIF](https://products.aspose.app/slides/id/text-to-gif) milik Aspose, Anda dapat dengan mudah menganimasikan teks dan membuat GIF dari teks. 
{{% /alert %}}

## **FAQ**

**Apakah resolusi gambar asli tetap utuh setelah penyisipan?**

Ya. Piksel sumber dipertahankan, tetapi tampilan akhir tergantung pada bagaimana [picture](/slides/id/php-java/picture-frame/) diskalakan pada slide dan kompresi yang diterapkan saat menyimpan.

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Letakkan logo pada master slide atau layout dan ganti di koleksi gambar presentasi—perubahan akan diterapkan ke semua elemen yang menggunakan sumber tersebut.

**Bisakah SVG yang disisipkan dikonversi menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi grup bentuk, setelah itu bagian individu dapat diedit dengan properti bentuk standar.

**Bagaimana saya dapat mengatur gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Assign the image as the background](/slides/id/php-java/presentation-background/) pada master slide atau layout yang relevan—setiap slide yang menggunakan master/layout tersebut akan mewarisi latar belakang.

**Bagaimana saya mencegah presentasi menjadi terlalu besar karena banyak gambar?**

Gunakan satu sumber gambar tunggal alih-alih duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan simpan grafik yang berulang pada master jika sesuai.