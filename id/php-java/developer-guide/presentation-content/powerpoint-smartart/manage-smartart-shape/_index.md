---
title: Kelola Grafik SmartArt dalam Presentasi Menggunakan PHP
linktitle: Grafik SmartArt
type: docs
weight: 20
url: /id/php-java/manage-smartart-shape/
keywords:
- objek SmartArt
- grafik SmartArt
- gaya SmartArt
- warna SmartArt
- membuat SmartArt
- menambahkan SmartArt
- mengedit SmartArt
- mengubah SmartArt
- mengakses SmartArt
- tipe tata letak SmartArt
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Automatisasi pembuatan, penyuntingan, dan penataan SmartArt PowerPoint di PHP menggunakan Aspose.Slides, menampilkan contoh kode ringkas dan panduan berfokus pada kinerja."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membuat dan mengelola grafik SmartArt dalam presentasi PowerPoint secara programatis. Artikel ini menjelaskan cara menambahkan bentuk SmartArt ke slide, mengakses bentuk SmartArt yang ada, menemukan SmartArt berdasarkan tipe tata letak tertentu, dan memperbarui tampilannya dengan mengubah gaya SmartArt atau gaya warna.

Contoh-contoh menunjukkan cara bekerja dengan bentuk SmartArt melalui koleksi bentuk slide presentasi, memeriksa apakah sebuah bentuk adalah SmartArt, lalu memodifikasi atau memeriksa propertinya.

## **Membuat Bentuk SmartArt**
Aspose.Slides untuk PHP via Java telah menyediakan API untuk membuat bentuk SmartArt. Untuk membuat bentuk SmartArt dalam sebuah slide, ikuti langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide dengan menggunakan Index‑nya.
3. [Tambahkan bentuk SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addSmartArt) dengan mengatur [LayoutType](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArtLayoutType).
4. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```php
  # Membuat Instance Kelas Presentation
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Tambahkan Bentuk Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Menyimpan presentasi
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Gambar: Bentuk SmartArt ditambahkan ke slide**|

## **Mengakses Bentuk SmartArt pada Slide**
Kode berikut akan digunakan untuk mengakses bentuk SmartArt yang ditambahkan dalam slide presentasi. Dalam contoh kode kami akan menelusuri setiap bentuk di dalam slide dan memeriksa apakah itu merupakan bentuk [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArt). Jika bentuk tersebut bertipe SmartArt, kami akan melakukan typecast ke instance [**SmartArt**](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArt).

```php
  # Muat presentasi yang diinginkan
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Jelajahi setiap bentuk di dalam slide pertama
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Periksa apakah bentuk bertipe SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Lakukan typecast bentuk ke SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengakses Bentuk SmartArt dengan Tipe Tata Letak Tertentu**
Contoh kode berikut akan membantu mengakses bentuk [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArt) dengan LayoutType tertentu. Perhatikan bahwa Anda tidak dapat mengubah LayoutType dari SmartArt karena bersifat read‑only dan hanya ditetapkan saat bentuk [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArt) ditambahkan.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dan muat presentasi yang berisi Bentuk SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Telusuri setiap bentuk di dalam slide pertama.
4. Periksa apakah bentuk tersebut bertipe [SmartArt] dan lakukan typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
5. Periksa bentuk SmartArt dengan LayoutType tertentu dan lakukan apa yang diperlukan setelahnya.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Jelajahi setiap bentuk di dalam slide pertama
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Periksa apakah bentuk bertipe SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Lakukan typecast bentuk ke SmartArtEx
        $smart = $shape;
        # Memeriksa Tata Letak SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengubah Gaya Bentuk SmartArt**
Dalam contoh ini, kita akan belajar mengubah gaya cepat untuk setiap bentuk SmartArt.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dan muat presentasi yang berisi Bentuk SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Telusuri setiap bentuk di dalam slide pertama.
4. Periksa apakah bentuk tersebut bertipe [SmartArt] dan lakukan typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
5. Temukan bentuk SmartArt dengan Style tertentu.
6. Tetapkan Style baru untuk bentuk SmartArt.
7. Simpan Presentasi.

```php
  # Membuat Instance Kelas Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Dapatkan slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Jelajahi setiap bentuk di dalam slide pertama
    foreach($slide->getShapes() as $shape) {
      # Periksa apakah bentuk bertipe SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Lakukan typecast bentuk ke SmartArtEx
        $smart = $shape;
        # Memeriksa gaya SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Mengubah Gaya SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Menyimpan presentasi
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Gambar: Bentuk SmartArt dengan Style yang diubah**|

## **Mengubah Gaya Warna Bentuk SmartArt**
Dalam contoh ini, kita akan belajar mengubah gaya warna untuk setiap bentuk SmartArt. Pada contoh kode berikut, kita akan mengakses bentuk SmartArt dengan gaya warna tertentu dan mengubah gayanya.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dan muat presentasi yang berisi Bentuk SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
3. Telusuri setiap bentuk di dalam slide pertama.
4. Periksa apakah bentuk tersebut bertipe [SmartArt] dan lakukan typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
5. Temukan bentuk SmartArt dengan Color Style tertentu.
6. Tetapkan Color Style baru untuk bentuk SmartArt.
7. Simpan Presentasi.

```php
  # Membuat Instance Kelas Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Dapatkan slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Jelajahi setiap bentuk di dalam slide pertama
    foreach($slide->getShapes() as $shape) {
      # Periksa apakah bentuk bertipe SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Lakukan typecast bentuk ke SmartArtEx
        $smart = $shape;
        # Memeriksa tipe warna SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Mengubah tipe warna SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Menyimpan presentasi
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Gambar: Bentuk SmartArt dengan Color Style yang diubah**|

## **FAQ**

**Apakah saya dapat menganimasikan SmartArt sebagai satu objek?**

Ya. SmartArt adalah sebuah bentuk, sehingga Anda dapat menerapkan [animasi standar](/slides/id/php-java/powerpoint-animation/) melalui API animasi (masuk, keluar, penekanan, jalur gerak) seperti pada bentuk lainnya.

**Bagaimana saya dapat menemukan SmartArt tertentu pada slide jika saya tidak mengetahui ID internalnya?**

Tetapkan dan gunakan Teks Alternatif (AltText) kemudian cari bentuk berdasarkan nilai tersebut—ini merupakan cara yang disarankan untuk menemukan bentuk target.

**Apakah saya dapat mengelompokkan SmartArt dengan bentuk lain?**

Ya. Anda dapat mengelompokkan SmartArt dengan bentuk lain (gambar, tabel, dll.) dan kemudian [memanipulasi grup](/slides/id/php-java/group/).

**Bagaimana cara mendapatkan gambar SmartArt tertentu (misalnya, untuk pratinjau atau laporan)?**

Ekspor thumbnail/gambar bentuk; pustaka dapat [merender bentuk individual](/slides/id/php-java/create-shape-thumbnails/) ke file raster (PNG/JPG/TIFF).

**Apakah tampilan SmartArt akan tetap terjaga ketika mengonversi seluruh presentasi ke PDF?**

Ya. Mesin render menargetkan fidelitas tinggi untuk [ekspor PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), dengan berbagai opsi kualitas dan kompatibilitas.