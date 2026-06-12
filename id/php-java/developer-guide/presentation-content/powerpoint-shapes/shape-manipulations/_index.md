---
title: Kelola Bentuk Presentasi di PHP
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/php-java/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- temukan bentuk
- klon bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk interop
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- selaraskan bentuk
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara membuat, mengedit, dan mengoptimalkan bentuk dalam Aspose.Slides untuk PHP via Java serta menyajikan presentasi PowerPoint berkinerja tinggi."
---
## **Ringkasan**

Artikel ini menjelaskan cara bekerja dengan bentuk pada presentasi menggunakan Aspose.Slides. Ini menunjukkan cara menemukan bentuk pada slide, mengklonnya, menghapusnya, menyembunyikannya, mengubah urutannya, mendapatkan ID bentuk Interop, dan menetapkan teks alternatif untuk identifikasi serta pemrosesan lebih lanjut.

Artikel ini juga membahas cara mengakses format tata letak untuk bentuk, merender bentuk sebagai SVG, menyelaraskan bentuk pada slide, dan menggunakan properti flip untuk pencerminan horizontal dan vertikal. Selain itu, artikel ini menyertakan FAQ singkat tentang penggabungan bentuk, urutan tumpukan, dan penguncian bentuk.

## **Temukan Bentuk pada Slide**
Topik ini akan menjelaskan teknik sederhana untuk memudahkan pengembang menemukan bentuk tertentu pada slide tanpa menggunakan Id internalnya. Penting untuk diketahui bahwa file Presentasi PowerPoint tidak memiliki cara lain untuk mengidentifikasi bentuk pada slide selain Id unik internal. Bagi pengembang, menemukan bentuk menggunakan Id unik internal dapat menjadi sulit. Semua bentuk yang ditambahkan ke slide memiliki beberapa Teks Alternatif. Kami menyarankan pengembang untuk menggunakan teks alternatif untuk menemukan bentuk tertentu. Anda dapat menggunakan MS PowerPoint untuk menentukan teks alternatif untuk objek yang akan Anda ubah di masa mendatang.

Setelah menetapkan teks alternatif pada bentuk yang diinginkan, Anda dapat membuka presentasi tersebut menggunakan Aspose.Slides for PHP via Java dan mengiterasi semua bentuk yang ditambahkan ke slide. Pada setiap iterasi, Anda dapat memeriksa teks alternatif bentuk tersebut dan bentuk dengan teks alternatif yang cocok akan menjadi bentuk yang Anda butuhkan. Untuk mendemonstrasikan teknik ini dengan lebih baik, kami telah membuat metode [findShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) yang melakukan pencarian bentuk spesifik pada slide dan mengembalikan bentuk tersebut.

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Teks alternatif bentuk yang akan dicari
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Klon Bentuk**
Untuk mengklon bentuk ke slide menggunakan Aspose.Slides for PHP via Java:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Akses koleksi bentuk slide sumber.
1. Tambahkan slide baru ke presentasi.
1. Klon bentuk dari koleksi bentuk slide sumber ke slide baru.
1. Simpan presentasi yang telah diubah sebagai file PPTX.

Contoh di bawah menambahkan bentuk grup ke slide.

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Menyimpan file PPTX ke disk
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hapus Bentuk**
Aspose.Slides for PHP via Java memungkinkan pengembang menghapus bentuk apa pun. Untuk menghapus bentuk dari slide mana pun, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Akses slide pertama.
1. Temukan bentuk dengan AlternativeText tertentu.
1. Hapus bentuk.
1. Simpan file ke disk.

```php
  # Buat objek Presentation
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan autoshape tipe persegi panjang
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Simpan presentasi ke disk
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sembunyikan Bentuk**
Aspose.Slides for PHP via Java memungkinkan pengembang menyembunyikan bentuk apa pun. Untuk menyembunyikan bentuk dari slide mana pun, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Akses slide pertama.
1. Temukan bentuk dengan AlternativeText tertentu.
1. Sembunyikan bentuk.
1. Simpan file ke disk.

```php
  # Instansiasi kelas Presentation yang mewakili PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan autoshape tipe persegi panjang
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Simpan presentasi ke disk
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ubah Urutan Bentuk**
Aspose.Slides for PHP via Java memungkinkan pengembang mengubah urutan bentuk. Mengubah urutan bentuk menentukan bentuk mana yang berada di depan atau di belakang. Untuk mengubah urutan bentuk pada slide, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan sebuah bentuk.
1. Tambahkan beberapa teks dalam frame teks bentuk.
1. Tambahkan bentuk lain dengan koordinat yang sama.
1. Ubah urutan bentuk.
1. Simpan file ke disk.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dapatkan ID Bentuk Interop**
Aspose.Slides for PHP via Java memungkinkan pengembang mendapatkan pengidentifikasi bentuk unik dalam ruang lingkup slide, berbeda dengan metode [getUniqueId](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getuniqueid/) yang memberikan pengidentifikasi unik dalam ruang lingkup presentasi. Metode [getOfficeInteropShapeId](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getofficeinteropshapeid/) telah ditambahkan ke kelas [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/). Nilai yang dikembalikan oleh metode [getOfficeInteropShapeId](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getofficeinteropshapeid/) sesuai dengan nilai Id dari objek Microsoft.Office.Interop.PowerPoint.Shape. Di bawah ini contoh kode yang diberikan.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Mendapatkan pengidentifikasi bentuk unik dalam ruang lingkup slide
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Setel Teks Alternatif untuk Bentuk**
Aspose.Slides for PHP via Java memungkinkan pengembang mengatur AlternateText pada bentuk apa pun. Bentuk dalam presentasi dapat dibedakan dengan `Alternative Text` atau metode [Shape Name](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/setname/). Metode [setAlternativeText](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/setalternativetext/) dan [getAlternativeText](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getalternativetext/) dapat dibaca atau diatur menggunakan Aspose.Slides maupun Microsoft PowerPoint. Dengan menggunakan metode ini, Anda dapat menandai sebuah bentuk dan melakukan operasi berbeda seperti Menghapus bentuk, Menyembunyikan bentuk, atau Mengubah urutan bentuk pada slide. Untuk mengatur AlternateText sebuah bentuk, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan bentuk apa pun ke slide.
1. Lakukan beberapa pekerjaan dengan bentuk yang baru ditambahkan.
1. Telusuri bentuk‑bentuk untuk menemukan bentuk yang diinginkan.
1. Atur AlternativeText.
1. Simpan file ke disk.

```php
  # Membuat instance kelas Presentation yang mewakili PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan autoshape tipe persegi panjang
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Simpan presentasi ke disk
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Akses Format Tata Letak untuk Bentuk**
Aspose.Slides for PHP via Java menyediakan API sederhana untuk mengakses format tata letak sebuah bentuk. Artikel ini menunjukkan cara mengakses format tata letak.

Contoh kode di bawah diberikan.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Render Bentuk sebagai SVG**
Sekarang Aspose.Slides for PHP via Java mendukung render bentuk sebagai SVG. Metode [writeAsSvg](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/writeassvg/) (beserta overload‑nya) telah ditambahkan ke kelas [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/). Metode ini memungkinkan menyimpan konten bentuk sebagai file SVG. Potongan kode di bawah menunjukkan cara mengekspor bentuk slide ke file SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Selaraskan Bentuk**
Aspose.Slides memungkinkan menyelaraskan bentuk baik relatif terhadap margin slide maupun relatif terhadap satu sama lain. Untuk tujuan ini, metode berlebih [SlidesUtil::alignShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/alignshapes/) telah ditambahkan. Enumerasi [ShapesAlignmentType](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapesalignmenttype/) mendefinisikan opsi penyelarasan yang tersedia.

**Contoh 1**

Kode sumber di bawah menyelaraskan bentuk dengan indeks 1, 2, dan 4 sepanjang batas atas slide.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Contoh 2**

Contoh di bawah menunjukkan cara menyelaraskan seluruh koleksi bentuk relatif terhadap bentuk paling bawah dalam koleksi.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Properti Flip**

Di Aspose.Slides, kelas [ShapeFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeframe/) menyediakan kontrol atas pencerminan horizontal dan vertikal bentuk melalui properti `flipH` dan `flipV`. Kedua properti bertipe [NullableBool](https://reference.aspose.com/slides/id/php-java/aspose.slides/nullablebool/), memungkinkan nilai `True` untuk mencerminkan, `False` untuk tidak mencerminkan, atau `NotDefined` untuk menggunakan perilaku bawaan. Nilai‑nilai ini dapat diakses dari [Frame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getFrame) sebuah bentuk.

Untuk mengubah pengaturan flip, sebuah instance baru [ShapeFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeframe/) dibangun dengan posisi dan ukuran saat ini, nilai yang diinginkan untuk `flipH` dan `flipV`, serta sudut rotasi. Menetapkan instance ini ke [Frame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getFrame) bentuk dan menyimpan presentasi akan menerapkan transformasi cermin dan menyimpannya ke file output.

Misalkan kita memiliki file sample.pptx di mana slide pertama berisi satu bentuk dengan pengaturan flip default, seperti yang ditunjukkan di bawah.

![Bentuk yang akan diputar](shape_to_be_flipped.png)

Contoh kode berikut mengambil properti flip bentuk saat ini dan memutarannya baik secara horizontal maupun vertikal.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Mengambil properti flip horizontal dari bentuk.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Mengambil properti flip vertikal dari bentuk.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Balik secara horizontal.
    $flipV = NullableBool::True; // Balik secara horizontal.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Bentuk yang diputar](flipped_shape.png)

## **FAQ**

**Apakah saya dapat menggabungkan bentuk (union/intersect/subtract) pada slide seperti di editor desktop?**

Tidak ada API operasi Boolean bawaan. Anda dapat memperkirakannya dengan membangun kontur yang diinginkan secara manual—misalnya, menghitung geometri hasil (via [GeometryPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometrypath/)) dan membuat bentuk baru dengan kontur tersebut, serta opsional menghapus bentuk asli.

**Bagaimana cara mengontrol urutan tumpukan (z-order) sehingga sebuah bentuk selalu berada di atas?**

Ubah urutan penyisipan/perpindahan dalam koleksi [shapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getShapes) slide. Untuk hasil yang dapat diprediksi, selesaikan urutan z setelah semua modifikasi slide lainnya.

**Bisakah saya "mengunci" sebuah bentuk agar pengguna tidak dapat mengeditnya di PowerPoint?**

Ya. Tetapkan flag proteksi pada tingkat bentuk (misalnya, kunci pemilihan, pergerakan, perubahan ukuran, atau edit teks). Jika diperlukan, terapkan pembatasan serupa pada master atau tata letak. Perlu diingat bahwa ini adalah proteksi level UI, bukan fitur keamanan; untuk perlindungan yang lebih kuat, kombinasikan dengan pembatasan tingkat file seperti rekomendasi baca‑saja atau kata sandi ([read‑only recommendations or passwords](/slides/id/php-java/password-protected-presentation/)).