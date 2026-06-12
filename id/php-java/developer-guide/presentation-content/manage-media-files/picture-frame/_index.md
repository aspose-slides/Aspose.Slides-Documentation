---
title: Kelola Bingkai Gambar dalam Presentasi Menggunakan PHP
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/php-java/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- tambahkan gambar
- buat gambar
- ekstrak gambar
- gambar raster
- gambar vektor
- potong gambar
- area terpotong
- properti StretchOff
- pemformatan bingkai gambar
- properti bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- transparansi gambar
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Tambahkan bingkai gambar ke presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java. Permudah alur kerja Anda dan tingkatkan desain slide."
---
## **Pendahuluan**

Bingkai gambar adalah sebuah bentuk yang berisi gambar—mirip dengan gambar dalam sebuah bingkai.  

Anda dapat menambahkan gambar ke slide melalui bingkai gambar. Dengan cara ini, Anda dapat memformat gambar dengan memformat bingkai gambar.

{{% alert title="Tip" color="primary" %}} 
Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 
{{% /alert %}} 

## **Buat Bingkai Gambar**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dengan menambahkan gambar ke [ImageCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk. 
4. Tentukan lebar dan tinggi gambar. 
5. Buat [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) berdasarkan lebar dan tinggi gambar melalui metode `addPictureFrame` yang disediakan oleh objek shape yang terkait dengan slide yang direferensikan. 
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide. 
7. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX. 

Kode PHP ini menunjukkan cara membuat bingkai gambar:

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengambil slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Membuat instance kelas Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Menambahkan bingkai gambar dengan tinggi dan lebar gambar yang sama
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Menulis file PPTX ke disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Bingkai gambar memungkinkan Anda membuat slide presentasi dengan cepat berdasarkan gambar. Ketika Anda menggabungkan bingkai gambar dengan opsi penyimpanan Aspose.Slides, Anda dapat memanipulasi operasi input/output untuk mengonversi gambar dari satu format ke format lain. Anda mungkin ingin melihat halaman berikut: konversi [gambar ke JPG](https://products.aspose.com/slides/id/php-java/conversion/image-to-jpg/); konversi [JPG ke gambar](https://products.aspose.com/slides/id/php-java/conversion/jpg-to-image/); konversi [JPG ke PNG](https://products.aspose.com/slides/id/php-java/conversion/jpg-to-png/), konversi [PNG ke JPG](https://products.aspose.com/slides/id/php-java/conversion/png-to-jpg/); konversi [PNG ke SVG](https://products.aspose.com/slides/id/php-java/conversion/png-to-svg/), konversi [SVG ke PNG](https://products.aspose.com/slides/id/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Buat Bingkai Gambar dengan Skala Relatif**

Dengan mengubah skala relatif gambar, Anda dapat membuat bingkai gambar yang lebih kompleks. 

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan gambar ke koleksi gambar presentasi. 
4. Buat objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dengan menambahkan gambar ke [ImageCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk. 
5. Tentukan lebar dan tinggi relatif gambar dalam bingkai gambar. 
6. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX. 

Kode PHP ini menunjukkan cara membuat bingkai gambar dengan skala relatif:

```php
  # Membuat instance kelas Presentation yang mewakili PPTX
  $pres = new Presentation();
  try {
    # Mengambil slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Membuat instance kelas Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Menambahkan Bingkai Gambar dengan tinggi dan lebar yang sama dengan Gambar
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Mengatur skala relatif lebar dan tinggi
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Menulis file PPTX ke disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ekstrak Gambar Raster dari Bingkai Gambar**

Anda dapat mengekstrak gambar raster dari objek [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) dan menyimpannya dalam format PNG, JPG, dan format lainnya. Contoh kode di bawah ini menunjukkan cara mengekstrak gambar dari dokumen "sample.pptx" dan menyimpannya dalam format PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Ekstrak Gambar SVG dari Bingkai Gambar**

Ketika sebuah presentasi berisi grafik SVG yang ditempatkan di dalam bentuk [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/), Aspose.Slides untuk PHP via Java memungkinkan Anda mengambil gambar vektor asli dengan fidelitas penuh. Dengan menelusuri koleksi bentuk slide, Anda dapat mengidentifikasi setiap [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/), memeriksa apakah [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) yang mendasarinya berisi konten SVG, dan kemudian menyimpan gambar tersebut ke disk atau stream dalam format SVG aslinya.

Contoh kode berikut menunjukkan cara mengekstrak gambar SVG dari sebuah bingkai gambar:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Dapatkan Transparansi Gambar**

Aspose.Slides memungkinkan Anda mendapatkan efek transparansi yang diterapkan pada sebuah gambar. Kode PHP ini menunjukkan operasi tersebut:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Pemformatan Bingkai Gambar**

Aspose.Slides menyediakan banyak opsi pemformatan yang dapat diterapkan pada bingkai gambar. Dengan menggunakan opsi tersebut, Anda dapat mengubah bingkai gambar agar sesuai dengan kebutuhan spesifik.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dengan menambahkan gambar ke [ImageCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk. 
4. Tentukan lebar dan tinggi gambar. 
5. Buat `PictureFrame` berdasarkan lebar dan tinggi gambar melalui metode [addPictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addpictureframe/) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/) yang terkait dengan slide yang direferensikan. 
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide. 
7. Setel warna garis bingkai gambar. 
8. Setel lebar garis bingkai gambar. 
9. Putar bingkai gambar dengan memberikan nilai positif atau negatif.  
   * Nilai positif memutar gambar searah jarum jam.  
   * Nilai negatif memutar gambar berlawanan arah jarum jam.  
10. Tambahkan bingkai gambar (yang berisi gambar) ke slide. 
11. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX. 

Kode PHP ini menunjukkan proses pemformatan bingkai gambar:

```php
  # Membuat instance kelas Presentation yang mewakili PPTX
  $pres = new Presentation();
  try {
    # Mengambil slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Membuat instance kelas Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Menambahkan Bingkai Gambar dengan tinggi dan lebar yang sama dengan Gambar
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Menerapkan beberapa pemformatan ke PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Menulis file PPTX ke disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose baru-baru ini mengembangkan [free Collage Maker](https://products.aspose.app/slides/id/collage). Jika Anda pernah perlu [menggabungkan JPG/JPEG](https://products.aspose.app/slides/id/collage/jpg) atau gambar PNG, [membuat grid dari foto](https://products.aspose.app/slides/id/collage/photo-grid), Anda dapat menggunakan layanan ini. 
{{% /alert %}}

## **Tambahkan Gambar sebagai Tautan**

Untuk menghindari ukuran presentasi yang besar, Anda dapat menambahkan gambar (atau video) melalui tautan alih-alih menyematkan file secara langsung ke dalam presentasi. Kode PHP ini menunjukkan cara menambahkan gambar dan video ke placeholder:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Pangkas Gambar**

Kode PHP ini menunjukkan cara memangkas gambar yang ada pada slide:

```php
  $pres = new Presentation();
  # Membuat objek gambar baru
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Menambahkan PictureFrame ke Slide
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Memotong gambar (nilai persentase)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Menyimpan hasil
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hapus Area yang Dipangkas pada Gambar**

Jika Anda ingin menghapus area yang dipangkas dari gambar yang terdapat dalam bingkai, Anda dapat menggunakan metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Metode ini mengembalikan gambar yang dipangkas atau gambar asli jika pemangkasan tidak diperlukan.

Kode PHP ini menunjukkan operasi tersebut:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Mengambil PictureFrame dari slide pertama
    $picFrame = $slide->getShapes()->get_Item(0);
    # Menghapus area terpotong gambar PictureFrame dan mengembalikan gambar yang dipotong
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Menyimpan hasil
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) menambahkan gambar yang dipangkas ke koleksi gambar presentasi. Jika gambar hanya digunakan dalam [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) yang diproses, pengaturan ini dapat mengurangi ukuran presentasi. Jika tidak, jumlah gambar dalam presentasi yang dihasilkan akan meningkat.  

Metode ini mengonversi file metafile WMF/EMF menjadi gambar PNG raster dalam operasi pemangkasan. 
{{% /alert %}}

## **Kompres Gambar**

Anda dapat mengompres gambar dalam presentasi menggunakan metode [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Metode ini mengompres gambar dengan mengurangi ukurannya berdasarkan ukuran bentuk dan resolusi yang ditentukan, dengan opsi menghapus area yang dipangkas.  

Metode ini menyesuaikan ukuran dan resolusi gambar serupa dengan fitur **Picture Format -> Compress Pictures -> Resolution** di PowerPoint.  

Contoh PHP berikut menunjukkan cara mengompres gambar dalam presentasi dengan menentukan resolusi target dan secara opsional menghapus area yang dipangkas:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Memampatkan gambar dengan resolusi target 150 DPI (resolusi Web) dan menghapus area yang terpotong.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Memeriksa hasil kompresi.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Atau menggunakan nilai DPI khusus secara langsung:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Memampatkan gambar ke 150 DPI (resolusi web), menghapus area yang dipotong.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Metode ini mengonversi gambar ke resolusi lebih rendah berdasarkan ukuran bentuk dan DPI yang diberikan. Area yang dipangkas juga dapat dihapus untuk mengoptimalkan ukuran file.  
Jika gambar berupa metafile (WMF/EMF) atau SVG, kompresi tidak akan diterapkan. Selain itu, kualitas JPEG dipertahankan atau sedikit berkurang berdasarkan resolusi, serupa dengan cara PowerPoint menangani JPEG beresolusi tinggi. 
{{% /alert %}}

## **Kunci Rasio Aspek**

Jika Anda ingin suatu bentuk yang berisi gambar mempertahankan rasio aspeknya bahkan setelah mengubah dimensi gambar, Anda dapat menggunakan metode [setAspectRatioLocked](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) untuk mengatur pengaturan *Lock Aspect Ratio*.  

Kode PHP ini menunjukkan cara mengunci rasio aspek sebuah bentuk:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # atur shape agar mempertahankan rasio aspek saat mengubah ukuran
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Pengaturan *Lock Aspect Ratio* ini hanya mempertahankan rasio aspek bentuk, bukan gambar yang terkandung di dalamnya. 
{{% /alert %}}

## **Gunakan Properti StretchOff**

Dengan menggunakan metode [setStretchOffsetLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) dan [setStretchOffsetBottom](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/), Anda dapat menentukan sebuah persegi panjang isian.  

Saat stretching ditentukan untuk sebuah gambar, persegi panjang sumber diskalakan untuk menyesuaikan persegi panjang isian yang ditentukan. Setiap sisi persegi panjang isian didefinisikan oleh offset persentase dari sisi yang bersesuaian dari kotak pembatas bentuk. Persentase positif menunjukkan inset sementara persentase negatif menunjukkan outset.  

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .  
2. Dapatkan referensi slide melalui indeksnya.  
3. Tambahkan sebuah `AutoShape` berupa persegi panjang.  
4. Buat sebuah gambar.  
5. Setel tipe isian shape.  
6. Setel mode isian gambar shape.  
7. Tambahkan gambar yang ditetapkan untuk mengisi shape.  
8. Tentukan offset gambar dari sisi yang bersesuaian dari kotak pembatas shape.  
9. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.  

Kode PHP ini menunjukkan proses penggunaan properti StretchOff:

```php
  # Membuat instance kelas Prseetation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengambil slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Membuat instance kelas ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Menambahkan AutoShape dengan tipe Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Menetapkan tipe isian shape
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Menetapkan mode isian gambar shape
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Menetapkan gambar untuk mengisi shape
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Menentukan offset gambar dari tepi yang bersesuaian dari kotak pembatas shape
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Menulis file PPTX ke disk
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bagaimana saya dapat mengetahui format gambar apa yang didukung untuk PictureFrame?**  
Aspose.Slides mendukung baik gambar raster (PNG, JPEG, BMP, GIF, dll.) maupun gambar vektor (misalnya SVG) melalui objek gambar yang ditetapkan ke sebuah [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/). Daftar format yang didukung umumnya tumpang tindih dengan kemampuan mesin konversi slide dan gambar.

**Bagaimana penambahan puluhan gambar berukuran besar memengaruhi ukuran dan kinerja PPTX?**  
Menyematkan gambar berukuran besar meningkatkan ukuran file dan penggunaan memori; menautkan gambar membantu menjaga ukuran presentasi tetap kecil tetapi memerlukan file eksternal tetap dapat diakses. Aspose.Slides menyediakan kemampuan menambahkan gambar dengan tautan untuk mengurangi ukuran file.

**Bagaimana saya dapat mengunci objek gambar agar tidak secara tidak sengaja dipindahkan atau diubah ukurannya?**  
Gunakan [shape locks](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/getpictureframelock/) untuk sebuah [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) (misalnya, nonaktifkan pemindahan atau perubahan ukuran). Mekanisme penguncian didukung untuk berbagai jenis shape, termasuk [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/).

**Apakah fidelitas vektor SVG tetap terjaga saat mengekspor presentasi ke PDF/gambar?**  
Aspose.Slides memungkinkan mengekstrak SVG dari sebuah [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) sebagai vektor asli. Saat [mengekspor ke PDF](/slides/id/php-java/convert-powerpoint-to-pdf/) atau [format raster](/slides/id/php-java/convert-powerpoint-to-png/), hasilnya mungkin dirasterisasi tergantung pada pengaturan ekspor; fakta bahwa SVG asli disimpan sebagai vektor dikonfirmasi oleh perilaku ekstraksi.