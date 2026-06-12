---
title: Kustomisasi Bentuk Presentasi di PHP
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/php-java/custom-shape/
keywords:
- bentuk kustom
- menambahkan bentuk
- membuat bentuk
- mengubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- titik edit
- menambah titik
- menghapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java: jalur geometri, sudut melengkung, bentuk gabungan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometri. Artikel ini menunjukkan cara menggunakan `GeometryPath` untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Artikel ini juga memperlihatkan cara membuat bentuk khusus dan gabungan, membangun bentuk dengan sudut melengkung, menentukan apakah geometri sebuah bentuk tertutup, serta mengonversi antara `GeometryPath` dan `java.awt.Shape` untuk skenario penyesuaian geometri tambahan.

## **Mengubah Bentuk Menggunakan Titik Edit**
Pertimbangkan sebuah persegi. Di PowerPoint, menggunakan **titik edit**, Anda dapat

* memindahkan sudut persegi ke dalam atau ke luar
* menentukan kelengkungan untuk sebuah sudut atau titik
* menambahkan titik baru ke persegi
* memanipulasi titik pada persegi, dll.

Intinya, Anda dapat melakukan tugas‑tugas yang dijelaskan pada bentuk apa pun. Dengan titik edit, Anda dapat mengubah bentuk atau membuat bentuk baru dari bentuk yang sudah ada.

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Sebelum Anda mulai menyunting bentuk PowerPoint melalui titik edit, ada beberapa hal yang perlu dipertimbangkan tentang bentuk:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Ketika sebuah bentuk tertutup, ia tidak memiliki titik awal atau akhir. Ketika sebuah bentuk terbuka, ia memiliki titik awal dan akhir. 
* Semua bentuk terdiri dari setidaknya 2 titik jangkar yang terhubung satu sama lain oleh garis.
* Sebuah garis dapat lurus atau melengkung. Titik jangkar menentukan sifat garis.
* Titik jangkar ada sebagai titik sudut, titik lurus, atau titik halus:
  * Titik sudut adalah titik di mana 2 garis lurus bergabung membentuk suatu sudut. 
  * Titik halus adalah titik di mana 2 pegangan berada dalam satu garis lurus dan segmen garis bergabung dalam lengkungan halus. Dalam kasus ini, semua pegangan dipisahkan dari titik jangkar dengan jarak yang sama. 
  * Titik lurus adalah titik di mana 2 pegangan berada dalam satu garis lurus dan segmen garis tersebut bergabung dalam lengkungan halus. Dalam kasus ini, pegangan tidak harus dipisahkan dari titik jangkar dengan jarak yang sama. 
* Dengan memindahkan atau menyunting titik jangkar (yang mengubah sudut garis), Anda dapat mengubah tampilan sebuah bentuk. 

Untuk menyunting bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [**GeometryPath**](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryPath).

* Sebuah [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryPath) mewakili jalur geometri dari objek [GeometryShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometryshape/).
* Untuk mengambil `GeometryPath` dari instance `GeometryShape`, Anda dapat menggunakan metode [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Untuk mengatur `GeometryPath` bagi sebuah bentuk, Anda dapat menggunakan metode berikut: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometryshape/#setGeometryPath) untuk *bentuk padat* dan [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometryshape/#setGeometryPaths) untuk *bentuk gabungan*.
* Untuk menambahkan segmen, Anda dapat menggunakan metode‑metode di bawah [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometrypath/).
* Dengan menggunakan metode [GeometryPath::setStroke](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometrypath/setstroke/) dan [GeometryPath::setFillMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometrypath/setfillmode/), Anda dapat mengatur tampilan jalur geometri.
* Dengan menggunakan metode [GeometryPath::getPathData](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometrypath/getpathdata/), Anda dapat mengambil jalur geometri dari sebuah `GeometryShape` sebagai array segmen jalur.
* Untuk mengakses opsi penyesuaian geometri bentuk tambahan, Anda dapat mengonversi [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometrypath/) ke [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
* Gunakan metode [geometryPathToGraphicsPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) dan [graphicsPathToGeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (dari kelas [ShapeUtil](https://reference.aspose.com/slides/id/php-java/aspose.slides/ShapeUtil)) untuk mengonversi [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometrypath/) ke [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) bolak‑balik.

## **Operasi Penyuntingan Sederhana**

Kode PHP ini menunjukkan cara

**Menambahkan sebuah garis** ke akhir jalur

```php

```
**Menambahkan sebuah garis** pada posisi tertentu di jalur:

```php

```
**Menambahkan kurva Bezier kubik** di akhir jalur:

```php

```
**Menambahkan kurva Bezier kubik** pada posisi tertentu di jalur:

```php

```
**Menambahkan kurva Bezier kuadratik** di akhir jalur:

```php

```
**Menambahkan kurva Bezier kuadratik** pada posisi tertentu di jalur:

```php

```
**Menambahkan sebuah busur** ke jalur:

```php

```
**Menutup gambar saat ini** pada jalur:

```php

```
**Menetapkan posisi untuk titik berikutnya**:

```php

```
**Menghapus segmen jalur** pada indeks tertentu:

```php

```

## **Menambahkan Titik Khusus ke Bentuk**
1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryShape) dan atur tipe [ShapeType::Rectangle](https://reference.aspose.com/slides/id/php-java/aspose.slides/ShapeType).
2. Dapatkan instance kelas [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryPath) dari bentuk tersebut.
3. Tambahkan titik baru di antara dua titik atas pada jalur.
4. Tambahkan titik baru di antara dua titik bawah pada jalur.
5. Terapkan jalur ke bentuk.

Kode PHP ini menunjukkan cara menambahkan titik khusus ke sebuah bentuk:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **Menghapus Titik dari Bentuk**

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryShape) dan atur tipe [ShapeType::Heart](https://reference.aspose.com/slides/id/php-java/aspose.slides/ShapeType).
2. Dapatkan instance kelas [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryPath) dari bentuk tersebut.
3. Hapus segmen pada jalur.
4. Terapkan jalur ke bentuk.

Kode PHP ini menunjukkan cara menghapus titik dari sebuah bentuk:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

## **Membuat Bentuk Khusus**

1. Hitung titik‑titik untuk bentuk.
2. Buat instance kelas [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryPath).
3. Isi jalur dengan titik‑titik tersebut.
4. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryShape).
5. Terapkan jalur ke bentuk.

Java ini menunjukkan cara membuat bentuk khusus:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **Membuat Bentuk Gabungan Khusus**

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryShape).
2. Buat instance pertama kelas [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryPath).
3. Buat instance kedua kelas [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryPath).
4. Terapkan jalur‑jalur ke bentuk.

Kode PHP ini menunjukkan cara membuat bentuk gabungan khusus:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **Membuat Bentuk Khusus dengan Sudut Melengkung**

Kode PHP ini menunjukkan cara membuat bentuk khusus dengan sudut melengkung (ke dalam);

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menentukan Apakah Geometri Bentuk Tertutup**

Sebuah bentuk tertutup didefinisikan sebagai bentuk yang semua sisinya terhubung, membentuk satu batas tanpa celah. Bentuk tersebut dapat berupa bentuk geometris sederhana atau kontur khusus yang kompleks. Contoh kode berikut menunjukkan cara memeriksa apakah geometri sebuah bentuk tertutup:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **Mengonversi GeometryPath ke java.awt.Shape** 

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryShape).
2. Buat instance kelas [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Konversi instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) ke instance [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/GeometryPath) menggunakan [ShapeUtil](https://reference.aspose.com/slides/id/php-java/aspose.slides/ShapeUtil).
4. Terapkan jalur‑jalur ke bentuk.

Kode PHP—implementasi langkah‑langkah di atas—menunjukkan proses konversi **GeometryPath** ke **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Buat bentuk baru
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Dapatkan jalur geometri dari bentuk
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Buat jalur grafik baru dengan teks
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Konversi jalur grafik ke jalur geometri
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Atur kombinasi jalur geometri baru dan jalur geometri asal ke bentuk
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Apa yang terjadi pada isi dan outline setelah mengganti geometri?**

Gaya tetap melekat pada bentuk; hanya kontur yang berubah. Isi dan outline secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk khusus bersamaan dengan geometri-nya?**

Gunakan metode [setRotation](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/setrotation/) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Bisakah saya mengonversi bentuk khusus menjadi gambar untuk “mengunci” hasilnya?**

Ya. Ekspor area [slide](/slides/id/php-java/convert-powerpoint-to-png/) yang diperlukan atau [shape](/slides/id/php-java/create-shape-thumbnails/) itu sendiri ke format raster; hal ini menyederhanakan pekerjaan selanjutnya dengan geometri yang berat.