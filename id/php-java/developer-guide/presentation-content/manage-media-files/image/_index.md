---
title: Optimalkan Manajemen Gambar dalam Presentasi Menggunakan PHP
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/php-java/image/
keywords:
- menambahkan gambar
- menambahkan gambar
- menambahkan bitmap
- mengganti gambar
- mengganti gambar
- dari web
- latar belakang
- menambahkan PNG
- menambahkan JPG
- menambahkan SVG
- menambahkan EMF
- menambahkan WMF
- menambahkan TIFF
- PowerPoint
- OpenDocument
- presentasi
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Menyederhanakan manajemen gambar dalam PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java, mengoptimalkan kinerja dan mengotomatiskan alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan menarik. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar dari file, internet, atau lokasi lain ke dalam slide. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide dalam presentasi melalui prosedur yang berbeda. 

{{% alert  title="Tip" color="primary" %}} 

Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jika Anda ingin menambahkan gambar sebagai objek frame—terutama jika Anda berencana menggunakan opsi pemformatan standar untuk mengubah ukurannya, menambahkan efek, dan sebagainya—lihat [Bingkai Gambar](/slides/id/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Anda dapat memanipulasi operasi input/output yang melibatkan gambar dan presentasi PowerPoint untuk mengonversi gambar dari satu format ke format lain. Lihat halaman ini: konversi [gambar ke JPG](https://products.aspose.com/slides/id/php-java/conversion/image-to-jpg/); konversi [JPG ke gambar](https://products.aspose.com/slides/id/php-java/conversion/jpg-to-image/); konversi [JPG ke PNG](https://products.aspose.com/slides/id/php-java/conversion/jpg-to-png/), konversi [PNG ke JPG](https://products.aspose.com/slides/id/php-java/conversion/png-to-jpg/); konversi [PNG ke SVG](https://products.aspose.com/slides/id/php-java/conversion/png-to-svg/), konversi [SVG ke PNG](https://products.aspose.com/slides/id/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides mendukung operasi dengan gambar dalam format populer berikut: JPEG, PNG, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar di komputer Anda ke dalam slide pada presentasi. Kode contoh ini menunjukkan cara menambahkan gambar ke slide:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak tersedia di komputer Anda, Anda dapat menambahkan gambar tersebut langsung dari web. 

Kode contoh ini menunjukkan cara menambahkan gambar dari web ke slide :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menambahkan Gambar ke Slide Master**

Slide master adalah slide utama yang menyimpan dan mengontrol informasi (tema, tata letak, dll.) tentang semua slide di bawahnya. Jadi, ketika Anda menambahkan gambar ke slide master, gambar tersebut akan muncul pada setiap slide di bawah slide master itu. 

Kode contoh Java ini menunjukkan cara menambahkan gambar ke slide master:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menambahkan Gambar sebagai Latar Belakang Slide**

Anda mungkin memutuskan untuk menggunakan gambar sebagai latar belakang untuk slide tertentu atau beberapa slide. Dalam hal ini, Anda perlu melihat cara [Menetapkan Gambar sebagai Latar Belakang Slide](/slides/id/php-java/presentation-background/#set-an-image-as-a-slide-background).

## **Menambahkan SVG ke Presentasi**
Anda dapat menambahkan atau menyisipkan gambar apa pun ke dalam presentasi dengan menggunakan metode [addPictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addpictureframe/) yang merupakan bagian dari kelas [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/).

Untuk membuat objek gambar berdasarkan gambar SVG, Anda dapat melakukannya dengan cara berikut:

1. Buat objek SvgImage untuk menyisipkannya ke ImageShapeCollection
2. Buat objek PPImage dari ISvgImage
3. Buat objek PictureFrame menggunakan kelas PPImage

Kode contoh ini menunjukkan cara menerapkan langkah-langkah di atas untuk menambahkan gambar SVG ke dalam presentasi:
```php
  # Instansiasi kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengonversi SVG menjadi Sekelompok Bentuk**
![PowerPoint Popup Menu](img_01_01.png)

Fungsionalitas ini disediakan oleh salah satu overload metode [addGroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addgroupshape/) pada kelas [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/) yang menerima objek [SvgImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgimage/) sebagai argumen pertama.

Kode contoh ini menunjukkan cara menggunakan metode yang dijelaskan untuk mengonversi file SVG menjadi sekumpulan bentuk:

```php
  # Buat presentasi baru
  $presentation = new Presentation();
  try {
    # Baca konten file SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Buat objek SvgImage
    $svgImage = new SvgImage($svgContent);
    # Dapatkan ukuran slide
    $slideSize = $presentation->getSlideSize()->getSize();
    # Konversi gambar SVG menjadi grup bentuk dengan menskalakan ke ukuran slide
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Simpan presentasi dalam format PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Menambahkan Gambar sebagai EMF ke Slide**
Aspose.Slides untuk PHP via Java memungkinkan Anda menghasilkan gambar EMF dari lembar Excel dan menambahkan gambar tersebut sebagai EMF dalam slide dengan Aspose.Cells. 

Kode contoh ini menunjukkan cara melakukan tugas yang dijelaskan:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Simpan workbook ke aliran
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengganti Gambar dalam Koleksi Gambar**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi (termasuk yang digunakan oleh bentuk slide). Bagian ini menunjukkan beberapa pendekatan untuk memperbarui gambar dalam koleksi. API menyediakan metode sederhana untuk mengganti gambar menggunakan data byte mentah, instance [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/), atau gambar lain yang sudah ada dalam koleksi.

1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Muat gambar baru dari file ke dalam array byte.
3. Ganti gambar target dengan gambar baru menggunakan array byte.
4. Pada pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
5. Pada pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi.
6. Tulis presentasi yang dimodifikasi sebagai file PPTX.

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation("sample.pptx");
try {
    // Cara pertama.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Cara kedua.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
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

Dengan menggunakan konverter Aspose GRATIS [Text to GIF](https://products.aspose.app/slides/id/text-to-gif), Anda dapat dengan mudah menganimasikan teks, membuat GIF dari teks, dll. 

{{% /alert %}}

## **FAQ**

**Apakah resolusi gambar asli tetap utuh setelah penyisipan?**

Ya. Piksel sumber dipertahankan, namun penampilan akhir tergantung pada bagaimana [gambar](/slides/id/php-java/picture-frame/) diubah skalanya pada slide dan kompresi apa pun yang diterapkan saat menyimpan.

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Letakkan logo pada master slide atau tata letak dan ganti di koleksi gambar presentasi—pembaruan akan diterapkan ke semua elemen yang menggunakan sumber daya tersebut.

**Apakah SVG yang disisipkan dapat dikonversi menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi sekumpulan bentuk, setelah itu bagian‑bagian individu menjadi dapat diedit dengan properti bentuk standar.

**Bagaimana cara menetapkan gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Tetapkan gambar sebagai latar belakang](/slides/id/php-java/presentation-background/) pada master slide atau tata letak yang relevan—semua slide yang menggunakan master/tata letak tersebut akan mewarisi latar belakang.

**Bagaimana cara mencegah presentasi menjadi sangat besar karena banyak gambar?**

Gunakan kembali satu sumber gambar daripada duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan simpan grafik yang berulang pada master bila diperlukan.