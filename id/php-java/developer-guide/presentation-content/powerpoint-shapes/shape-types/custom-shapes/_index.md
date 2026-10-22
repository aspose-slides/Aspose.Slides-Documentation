---
title: Sesuaikan Bentuk Presentasi di PHP
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/php-java/custom-shape/
keywords: 
- bentuk kustom
- tambahkan bentuk
- buat bentuk
- ubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- titik edit
- tambah titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java: jalur geometri, sudut melengkung, bentuk komposit."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan geometry paths. Artikel ini menunjukkan cara bekerja dengan [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan path dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Artikel ini juga memperlihatkan cara membuat bentuk khusus dan komposit, membangun bentuk dengan sudut melengkung, menentukan apakah geometri bentuk tertutup, memeriksa elemen bentuk, dan mengonversi outline teks Java AWT menjadi geometry paths.

## **Mengubah Bentuk Menggunakan Titik Edit**

Di PowerPoint, Anda dapat menggunakan **Edit Points** untuk memodifikasi sebuah persegi:

* Memindahkan sudut ke dalam atau ke luar.
* Menyesuaikan kelengkungan pada sebuah titik.
* Menambahkan titik baru.

Menyunting titik memungkinkan Anda mengubah kontur sebuah bentuk atau menggunakan bentuk yang ada sebagai dasar untuk bentuk baru.

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Saat menyunting bentuk PowerPoint, perhatikan konsep berikut:

* Sebuah bentuk (atau path‑nya) dapat berupa tertutup atau terbuka.
* Path sebuah bentuk terdiri dari anchor points yang dihubungkan oleh segmen.
* Sebuah segmen dapat lurus atau melengkung. Anchor points dan control handles menentukan bentuknya.
* Anchor points dapat berupa corner points, straight points, atau smooth points:
  * Pada corner point, segmen‑segmen yang berdekatan dapat bertemu dengan sudut.
  * Pada smooth point, dua control handle berada pada satu garis dan berjarak sama dari anchor point.
  * Pada straight point, dua control handle berada pada satu garis namun dapat memiliki jarak yang berbeda dari anchor point.
* Memindahkan anchor points atau menyesuaikan handle‑nya mengubah kontur bentuk.

Untuk menyunting bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) mewakili geometry path dari objek [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Untuk mengambil [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) dari instance [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), Anda dapat menggunakan metode [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Untuk menetapkan [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) pada sebuah bentuk, Anda dapat menggunakan metode: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) untuk bentuk dengan satu path dan [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) untuk bentuk dengan banyak path.
* Untuk menambah segmen, Anda dapat menggunakan metode‑metode di bawah [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Menggunakan metode [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) dan [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), Anda dapat mengatur tampilan geometry path.
* Menggunakan metode [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), Anda dapat mengambil geometry path dari sebuah [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) sebagai array segmen path.
* Untuk mengakses opsi kustomisasi geometri bentuk tambahan, Anda dapat membaca sebuah [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) melalui [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)‑nya dan memutar ulang segmen‑segmen pada sebuah [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Operasi Penyuntingan Sederhana**

Gunakan metode berikut untuk menyunting geometry path. Overload yang menerima indeks menyisipkan segmen pada posisi berbasis nol dalam array segmen path.

| Operasi | Metode |
| --- | --- |
| Menambahkan atau menyisipkan garis lurus. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Menambahkan atau menyisipkan kurva Bézier kubik dengan dua titik kontrol dan sebuah titik akhir. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Menambahkan atau menyisipkan kurva Bézier kuadratik dengan satu titik kontrol dan sebuah titik akhir. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Menambahkan sebuah busur elips dengan dimensi dan sudut yang ditentukan dalam derajat. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Menutup figur saat ini dengan menghubungkan titik akhirnya ke titik awalnya. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Menetapkan titik awal sebuah figur. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Menghapus segmen pada indeks berbasis nol. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Menambah Titik Kustom ke Sebuah Bentuk**

Contoh ini menyisipkan dua titik ke dalam bentuk persegi panjang menggunakan [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) dan menerapkan path yang telah disunting dengan [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Koordinat bersifat lokal terhadap bentuk: kedua titik baru berada di tengahnya, 100 poin dari kiri dan 50 poin dari atas. Indeks segmen 1 dan 4 menempatkannya pada tepi atas dan bawah, menarik tepi‑tepi tersebut ke dalam.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Menghapus Titik dari Sebuah Bentuk**

Contoh ini mengubah outline berbentuk hati dengan menghapus segmen pada indeks berbasis nol 2 menggunakan [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Menerapkan path yang telah dimodifikasi dengan [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) memperbarui kontur bentuk.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Membuat Bentuk Kustom**

Contoh ini membangun sebuah bintang lima titik menggunakan [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Jari‑jari luar dan dalam yang bergantian sebesar 100 dan 50 poin menentukan ujung serta cekungan; langkah 72 derajat menempatkan kelima ujung secara merata. Path ditutup dengan [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) dan diterapkan ke bentuk persegi panjang menggunakan [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), menggantikan outline‑nya.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Membuat Bentuk Kustom Komposit**

Contoh ini mendefinisikan dua [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) tertutup untuk sepertiga atas dan bawah sebuah bentuk. Menerapkan kedua path dengan [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) menghasilkan satu bentuk komposit dengan celah di sepertiga tengahnya.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Membuat Bentuk Kustom dengan Sudut Melengkung**

Contoh ini menggabungkan segmen lurus dengan [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) untuk membuat bentuk dengan sudut melengkung ke dalam. Setiap ukuran sudut menetapkan lebar dan tinggi busur dalam poin, dan sweep –90 derajat menggambar seperempat elips berlawanan arah jarum jam. Path yang selesai diterapkan dengan [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), dan presentasi disimpan dalam format PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menentukan Apakah Geometry Bentuk Tertutup**

Helper berikut memeriksa apakah setiap geometry path yang tidak kosong diakhiri dengan segmen penutup. Helper membaca [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) dan membandingkan perintah akhir segmen [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) dengan [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Helper mengembalikan false ketika tidak ada path yang tidak kosong. Pemeriksaan ini memeriksa perintah akhir tiap path; ia tidak memeriksa setiap sub‑figur dalam sebuah path. Contoh mencetak `true` untuk sebuah persegi panjang.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Mengekstrak dan Memeriksa Elemen Bentuk**

Gunakan [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) untuk memeriksa sebuah bentuk yang ada sebagai elemen‑elemen yang berisi titik‑titik path dan tipe‑tipe titik. Gunakan setiap [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) yang dikembalikan untuk mengambil array titik dan tipe melalui metode [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) dan [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Representasi ini berguna untuk analisis kontur atau untuk mengirimkan geometri ke alat menggambar kustom.

Contoh membuka `input.pptx`, menemukan geometry shape pertama tepat pada slide pertama, dan mencetak segmen‑segmen path‑nya. Gunakan sebuah presentasi yang berisi bentuk dengan segmen lurus dan melengkung untuk melihat kedua jenis output. Contoh tidak mencari di dalam grup.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Simpan tipe segmen, kecuali flag.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Array‑array tersebut bersesuaian berdasarkan indeks: `$points[$i]` adalah sebuah titik dan `$types[$i]` menjelaskan perannya. Tipe `0` memulai sebuah figur, dan tipe `1` menggambar sebuah garis dari titik sebelumnya ke titik saat ini. Sebuah segmen Bézier kubik dimulai dari titik akhir sebelumnya dan menggunakan tiga entri tipe‑`3` berurutan: dua titik kontrol diikuti oleh titik akhir baru. Loop mengonsumsi ketiga entri tersebut sekaligus dan memeriksa titik akhir untuk penutupan.

Tipe‑tipe titik juga mengandung flag. Mask dengan `0x07` untuk mengidentifikasi tipe segmen, dan uji `0x80` secara terpisah untuk mendeteksi sub‑path tertutup. Sebagai contoh, `129` (`0x81`) berarti titik akhir garis yang menutup sub‑path, dan `131` (`0x83`) berarti titik akhir Bézier yang menutup satu sub‑path. PHP/Java Bridge mengembalikan array byte sebagai string biner; melakukan unpack dengan `"C*"` menghasilkan nilai byte tak bertanda. Masking menjaga nilai bit yang dimaksud. Membandingkan nilai mentah hanya dengan `1` atau `3` akan melewatkan kasus ini. Flag lain, seperti dash (`0x10`) dan marker (`0x20`), tidak mengubah tipe segmen dasar.

**Koordinat dan transformasi.** Titik diukur dalam poin (1/72 inci), dengan X meningkat ke kanan dan Y meningkat ke bawah. Untuk bentuk yang tidak tergabung, koordinat yang diekstrak sudah mencakup posisi yang dikembalikan oleh [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) dan [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) serta mencerminkan lebar dan tinggi saat ini. Sebagai contoh, sebuah persegi panjang tidak berputar pada `(100, 200)` dengan ukuran `120 × 80` memiliki batas kontur `(100, 200)`–`(220, 280)`. Jangan menambahkan posisi bentuk lagi. Kurangi X dan Y untuk memperoleh koordinat relatif terhadap kerangka tidak berputar.

Poin yang diekstrak tidak menerapkan rotasi bentuk, yang dikembalikan oleh [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), atau pembalikan horizontal dan vertikal. Untuk mereproduksi kontur yang ditampilkan, terapkan transformasi tersebut di sekitar pusat bentuk. Untuk bentuk yang tergabung, perhitungkan juga pemetaan koordinat grup dan transformasinya; jangan mengasumsikan bahwa poin yang diekstrak sudah merupakan koordinat slide akhir atau menerapkan translasi atau skala dua kali bila sudah tercermin dalam kerangka anak.

**Inspeksi vs penyuntingan.** Array yang diekstrak menjelaskan kontur; mengubahnya tidak memperbarui bentuk asli. Pilih pendekatan ini ketika analisis atau kode gambar Anda membutuhkan array titik/tipe. Gunakan [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) bila Anda memerlukan perintah geometri dalam sistem koordinat lokal bentuk atau ingin menyunting geometriya. Terapkan path yang disunting melalui [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) atau [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Mengonversi Java AWT Shape menjadi GeometryPath**

Contoh ini menggabungkan outline persegi panjang dengan teks yang dikonversi menjadi geometri. Metode [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) pada outline menonaktifkan isinya. Sebuah [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) membuat outline teks dalam sebuah [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)‑nya menyediakan segmen move, line, quadratic, cubic, dan closing, yang kemudian diputar ulang pada sebuah [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Contoh menggunakan array float Java sehingga PHP/Java Bridge mempertahankan koordinat yang ditulis oleh iterator. Teks menggunakan font Arial 40 poin. Outline dialihkan 20 poin secara horizontal dan diposisikan dengan bagian atas visualnya 10 poin di bawah tepi atas bentuk. Path teks diisi, sementara persegi panjang asli tetap berupa outline. Menerapkan kedua path dengan [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) menghasilkan satu bentuk yang berisi persegi panjang dan teks.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Apa yang terjadi pada isian dan outline setelah mengganti geometri?**

Gaya tetap melekat pada bentuk; hanya kontur yang berubah. Isian dan outline secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk kustom bersama geometri secara benar?**

Gunakan metode [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Apakah saya dapat mengonversi bentuk kustom menjadi gambar untuk "mengunci" hasilnya?**

Ya. Ekspor area [slide](/slides/id/php-java/convert-powerpoint-to-png/) yang diperlukan atau [shape](/slides/id/php-java/create-shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan pekerjaan selanjutnya dengan geometri kompleks.