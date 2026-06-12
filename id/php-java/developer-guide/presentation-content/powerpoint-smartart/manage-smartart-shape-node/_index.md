---
title: Kelola Node Bentuk SmartArt dalam Presentasi Menggunakan PHP
linktitle: Node Bentuk SmartArt
type: docs
weight: 30
url: /id/php-java/manage-smartart-shape-node/
keywords:
- node SmartArt
- node anak
- tambah node
- posisi node
- akses node
- hapus node
- posisi kustom
- node asisten
- format isi
- render node
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola node bentuk SmartArt dalam PPT dan PPTX dengan Aspose.Slides untuk PHP via Java. Dapatkan contoh kode yang jelas dan tip untuk menyederhanakan presentasi Anda."
---
## **Ikhtisar**

Grafik SmartArt dalam presentasi PowerPoint diatur melalui node yang berisi teks dan mendefinisikan struktur diagram. Aspose.Slides memungkinkan Anda bekerja dengan node SmartArt ini secara programatis: menambahkan node baru dan node anak, menyisipkan node anak pada posisi tertentu, mengakses node yang ada, serta membaca teks, level, dan posisi mereka.

Artikel ini menjelaskan cara mengelola node bentuk SmartArt. Artikel ini menunjukkan cara menghapus node, bekerja dengan node anak berdasarkan indeks atau posisi, mengubah node asisten menjadi node normal, menyesuaikan posisi, ukuran, dan rotasi bentuk node SmartArt, mengatur format isi node, dan menghasilkan gambar miniatur untuk node anak SmartArt.

## **Menambahkan Node SmartArt**
Aspose.Slides for PHP via Java telah menyediakan API termudah untuk mengelola bentuk SmartArt dengan cara paling sederhana. Kode contoh berikut akan membantu menambahkan node dan node anak di dalam bentuk SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) dan ubah tipe bentuk terpilih menjadi [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) jika memang SmartArt.  
1. [Add a new Node](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnodecollection/#addNode) di koleksi **NodeCollection** bentuk SmartArt dan setel teks di TextFrame.  
1. Sekarang, [Add](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnodecollection/#addNode) **Child Node** di Node SmartArt yang baru ditambahkan dan setel teks di TextFrame.  
1. Simpan Presentasi.

```php
  # Muat presentasi yang diinginkan
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Telusuri setiap bentuk di dalam slide pertama
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Periksa apakah bentuk berjenis SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ubah tipe bentuk menjadi SmartArt
        $smart = $shape;
        # Menambahkan Node SmartArt baru
        $TemNode = $smart->getAllNodes()->addNode();
        # Menambahkan teks
        $TemNode->getTextFrame()->setText("Test");
        # Menambahkan node anak baru dalam node induk. Node ini akan ditambahkan di akhir koleksi
        $newNode = $TemNode->getChildNodes()->addNode();
        # Menambahkan teks
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Menyimpan Presentasi
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menambahkan Node SmartArt pada Posisi Tertentu**
Pada contoh kode berikut kami menjelaskan cara menambahkan node anak yang menjadi bagian dari node masing‑masing pada bentuk SmartArt pada posisi tertentu.

1. Buat instance kelas Presentation.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Tambahkan bentuk [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArt) bertipe [**StackedList**](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArtLayoutType#StackedList) pada slide yang diakses.  
1. Akses node pertama pada SmartArt yang ditambahkan.  
1. Sekarang, tambahkan **Child Node** untuk **Node** yang dipilih pada posisi 2 dan setel teksnya.  
1. Simpan Presentasi.

```php
  # Membuat instance presentasi
  $pres = new Presentation();
  try {
    # Akses slide presentasi
    $slide = $pres->getSlides()->get_Item(0);
    # Tambahkan Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Mengakses node SmartArt pada indeks 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Menambahkan node anak baru pada posisi 2 di node induk
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Tambahkan Teks
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Simpan Presentasi
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengakses Node SmartArt**
Kode contoh berikut akan membantu mengakses node di dalam bentuk SmartArt. Harap dicatat bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya ditetapkan saat bentuk SmartArt ditambahkan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) dan ubah tipe bentuk terpilih menjadi [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) jika memang SmartArt.  
1. Telusuri semua **Nodes** di dalam Bentuk SmartArt.  
1. Akses dan tampilkan informasi seperti posisi Node SmartArt, level, dan Teks.

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Dapatkan slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Telusuri setiap bentuk di dalam slide pertama
    foreach($slide->getShapes() as $shape) {
      # Periksa apakah bentuk berjenis SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ubah tipe bentuk menjadi SmartArt
        $smart = $shape;
        # Telusuri semua node di dalam SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Mengakses node SmartArt pada indeks i
          $node = $smart->getAllNodes()->get_Item($i);
          # Mencetak parameter node SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengakses Node Anak SmartArt**
Kode contoh berikut akan membantu mengakses node anak yang menjadi bagian dari node masing‑masing pada bentuk SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) dan ubah tipe bentuk terpilih menjadi [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) jika memang SmartArt.  
1. Telusuri semua **Nodes** di dalam Bentuk SmartArt.  
1. Untuk setiap **Node** SmartArt yang dipilih, telusuri semua **Child Nodes** di dalam node tertentu.  
1. Akses dan tampilkan informasi seperti posisi, level, dan Teks **Child Node**.

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Dapatkan slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Telusuri setiap bentuk di dalam slide pertama
    foreach($slide->getShapes() as $shape) {
      # Periksa apakah bentuk berjenis SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ubah tipe bentuk menjadi SmartArt
        $smart = $shape;
        # Telusuri semua node di dalam SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Mengakses node SmartArt pada indeks i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Menelusuri node anak dalam node SmartArt pada indeks i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Mengakses node anak dalam node SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Mencetak parameter node anak SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengakses Node Anak SmartArt pada Posisi Tertentu**
Pada contoh ini, kami akan mempelajari cara mengakses node anak pada posisi tertentu yang menjadi bagian dari node masing‑masing pada bentuk SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Tambahkan bentuk SmartArt bertipe [**StackedList**](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArtLayoutType#StackedList).  
1. Akses bentuk SmartArt yang ditambahkan.  
1. Akses node pada indeks 0 untuk bentuk SmartArt yang diakses.  
1. Sekarang, akses **Child Node** pada posisi 1 untuk node SmartArt yang diakses menggunakan metode **get_Item()**.  
1. Akses dan tampilkan informasi seperti posisi, level, dan Teks **Child Node**.

```php
  # Membuat instance presentasi
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan bentuk SmartArt di slide pertama
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Mengakses node SmartArt pada indeks 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Mengakses node anak pada posisi 1 di node induk
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Mencetak parameter node anak SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menghapus Node SmartArt**
Pada contoh ini, kami akan mempelajari cara menghapus node di dalam bentuk SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) dan ubah tipe bentuk terpilih menjadi [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) jika memang SmartArt.  
1. Periksa apakah SmartArt memiliki lebih dari 0 node.  
1. Pilih node SmartArt yang akan dihapus.  
1. Sekarang, hapus node yang dipilih menggunakan metode [**removeNode**](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Simpan Presentasi.

```php
  # Muat presentasi yang diinginkan
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Telusuri setiap bentuk di dalam slide pertama
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Periksa apakah bentuk berjenis SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ubah tipe bentuk menjadi SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Mengakses node SmartArt pada indeks 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Menghapus node yang dipilih
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Simpan Presentasi
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menghapus Node SmartArt dari Posisi Tertentu**
Pada contoh ini, kami akan mempelajari cara menghapus node di dalam bentuk SmartArt pada posisi tertentu.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) dan ubah tipe bentuk terpilih menjadi [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) jika memang SmartArt.  
1. Pilih node bentuk SmartArt pada indeks 0.  
1. Sekarang, periksa apakah node SmartArt yang dipilih memiliki lebih dari 2 node anak.  
1. Sekarang, hapus node pada **Position 1** menggunakan metode [**removeNode**](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Simpan Presentasi.

```php
  # Muat presentasi yang diinginkan
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Telusuri setiap bentuk di dalam slide pertama
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Periksa apakah bentuk berjenis SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ubah tipe bentuk menjadi SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Mengakses node SmartArt pada indeks 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Menghapus node anak pada posisi 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Simpan Presentasi
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menetapkan Posisi Kustom untuk Node Anak dalam Objek SmartArt**
Aspose.Slides for PHP via Java mendukung penetapan properti [SmartArtShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#setX) dan [Y](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#setY). Potongan kode di bawah ini menunjukkan cara menetapkan posisi, ukuran, dan rotasi SmartArtShape secara kustom; juga harap dicatat bahwa menambahkan node baru menyebabkan perhitungan ulang posisi dan ukuran semua node. Dengan pengaturan posisi kustom, pengguna dapat menempatkan node sesuai kebutuhan.

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Pindahkan bentuk SmartArt ke posisi baru
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Ubah lebar bentuk SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Ubah tinggi bentuk SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Ubah rotasi bentuk SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Memeriksa Node Asisten**
{{% alert color="primary" %}} 

Dalam artikel ini kami akan menelusuri lebih jauh fitur bentuk SmartArt yang ditambahkan ke slide presentasi secara programatis menggunakan Aspose.Slides for PHP via Java.

{{% /alert %}} 

Kami akan menggunakan bentuk SmartArt sumber berikut untuk penyelidikan pada bagian‑bagian artikel ini.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|

Pada kode contoh berikut kami akan menyelidiki cara mengidentifikasi **Assistant Nodes** dalam koleksi node SmartArt dan mengubahnya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide kedua dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) dan ubah tipe bentuk terpilih menjadi [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) jika memang SmartArt.  
1. Telusuri semua node di dalam bentuk SmartArt dan periksa apakah mereka adalah **Assistant Nodes**.  
1. Ubah status Assistant Node menjadi node normal.  
1. Simpan Presentasi.

```php
  # Membuat instance presentasi
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Telusuri setiap bentuk di dalam slide pertama
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Periksa apakah bentuk berjenis SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Ubah tipe bentuk menjadi SmartArt
        $smart = $shape;
        # Menelusuri semua node pada bentuk SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Periksa apakah node adalah node Asisten
          if ($node->isAssistant()) {
            # Mengatur node Asisten menjadi false dan menjadikannya node normal
            $node->isAssistant();
          }
        }
      }
    }
    # Simpan Presentasi
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **Menetapkan Format Isi Node**
Aspose.Slides for PHP via Java memungkinkan penambahan bentuk SmartArt khusus dan penetapan format isi mereka. Artikel ini menjelaskan cara membuat dan mengakses bentuk SmartArt serta menetapkan format isi menggunakan Aspose.Slides for PHP via Java.

Ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).  
1. Dapatkan referensi slide menggunakan indeksnya.  
1. Tambahkan bentuk [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) dengan menetapkan **LayoutType**‑nya.  
1. Tetapkan **Fill Format** untuk node bentuk SmartArt.  
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```php
  # Membuat instance presentasi
  $pres = new Presentation();
  try {
    # Mengakses slide
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan bentuk SmartArt dan node
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Menetapkan warna isi node
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Simpan presentasi
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menghasilkan Thumbnail Node Anak SmartArt**
Pengembang dapat menghasilkan thumbnail dari node anak SmartArt dengan mengikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).  
1. [Add SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnodecollection/#addNode).  
1. Dapatkan referensi node dengan menggunakan Indeksnya.  
1. Dapatkan gambar thumbnail.  
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Tambahkan SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Dapatkan referensi node dengan menggunakan Indeksnya
    $node = $smart->getNodes()->get_Item(1);
    # Dapatkan thumbnail
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Simpan thumbnail
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah animasi SmartArt didukung?**

Ya. SmartArt diperlakukan sebagai bentuk biasa, sehingga Anda dapat [apply standard animations](/slides/id/php-java/shape-animation/) (masuk, keluar, penekanan, jalur gerak) dan menyesuaikan waktu. Anda juga dapat memberi animasi pada bentuk di dalam node SmartArt bila diperlukan.

**Bagaimana cara menemukan SmartArt tertentu pada slide jika ID internalnya tidak diketahui?**

Tetapkan dan cari berdasarkan [alternative text](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getalternativetext/). Menetapkan AltText yang khas pada SmartArt memungkinkan Anda menemukannya secara programatis tanpa bergantung pada pengidentifikasi internal.

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi presentasi ke PDF?**

Ya. Aspose.Slides merender SmartArt dengan fidelitas visual tinggi selama [PDF export](/slides/id/php-java/convert-powerpoint-to-pdf/), mempertahankan tata letak, warna, dan efek.

**Bisakah saya mengekstrak gambar seluruh SmartArt (untuk pratinjau atau laporan)?**

Ya. Anda dapat merender bentuk SmartArt ke [raster formats](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) atau ke [SVG](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/writeassvg/) untuk output vektor skalabel, sehingga cocok untuk thumbnail, laporan, atau penggunaan web.