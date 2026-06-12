---
title: Mengklon Slide Presentasi di PHP
linktitle: Klon Slide
type: docs
weight: 35
url: /id/php-java/clone-slides/
keywords:
- klon slide
- salin slide
- simpan slide
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Duplikat slide PowerPoint dengan cepat menggunakan Aspose.Slides untuk PHP. Ikuti contoh kode kami yang jelas untuk mengotomatisasi pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Kloning adalah proses membuat salinan atau tiruan persis dari sesuatu. Aspose.Slides for PHP via Java juga memungkinkan membuat salinan atau klon dari slide mana pun dan kemudian menyisipkan slide yang diklon ke presentasi saat ini atau presentasi lain yang terbuka. Proses kloning slide menghasilkan slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengklon slide:

- Klon di Akhir dalam Presentasi.
- Klon di Posisi Lain dalam Presentasi.
- Klon di Akhir dalam Presentasi lain.
- Klon di Posisi Lain dalam Presentasi lain.
- Klon pada posisi tertentu dalam Presentasi lain.

Di Aspose.Slides for PHP via Java, (sebuah koleksi objek [Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/Slide)) yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) menyediakan metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone) dan [insertClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#insertClone) untuk melakukan tipe kloning slide di atas

## **Klon Slide di Akhir Presentasi**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone) sesuai langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Dapatkan objek [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) dengan merujuk ke koleksi slide yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone) yang diekspor oleh objek [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) dan berikan slide yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone).
1. Tuliskan file presentasi yang sudah dimodifikasi.

Pada contoh di bawah ini, kami telah mengklon sebuah slide (berposisi pertama – indeks nol – dalam presentasi) ke akhir presentasi.

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Mengklon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Menulis presentasi yang telah dimodifikasi ke disk
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klon Slide ke Posisi Lain dalam Presentasi**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [insertClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#insertClone):

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Dapatkan objek [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection) dengan merujuk ke koleksi [**Slides**](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#insertClone) yang diekspor oleh objek [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) dan berikan slide yang akan diklon bersama dengan indeks posisi baru sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#insertClone).
1. Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengklon sebuah slide (berposisi indeks nol – posisi 1 – dalam presentasi) ke indeks 1 – Posisi 2 – dalam presentasi.

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Mengklon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    $slds = $pres->getSlides();
    # Mengklon slide yang diinginkan ke indeks yang ditentukan dalam presentasi yang sama
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Menulis presentasi yang telah dimodifikasi ke disk
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klon Slide di Akhir Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) yang berisi presentasi sumber slide yang akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Dapatkan objek [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection) dengan merujuk ke koleksi [**Slides**](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) yang diekspor oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone) yang diekspor oleh objek [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) dan berikan slide dari presentasi sumber sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengklon sebuah slide (dari indeks pertama presentasi sumber) ke akhir presentasi tujuan.

```php
  # Membuat instance kelas Presentation untuk memuat file presentasi sumber
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Membuat instance kelas Presentation untuk PPTX tujuan (tempat slide akan diklon)
    $destPres = new Presentation();
    try {
      # Mengklon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Menulis presentasi tujuan ke disk
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klon Slide ke Posisi Lain dalam Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi tertentu:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) yang berisi presentasi sumber slide yang akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Dapatkan kelas [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) dengan merujuk ke koleksi Slides yang diekspor oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#insertClone) yang diekspor oleh objek [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) dan berikan slide dari presentasi sumber bersama dengan posisi yang diinginkan sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#insertClone).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengklon sebuah slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) pada presentasi tujuan.

```php
  # Membuat instance kelas Presentation untuk memuat file presentasi sumber
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Membuat instance kelas Presentation untuk PPTX tujuan (tempat slide akan diklon)
    $destPres = new Presentation();
    try {
      # Mengklon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Menulis presentasi tujuan ke disk
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klon Slide pada Posisi Tertentu dalam Presentasi Lain**
Jika Anda perlu mengklon slide dengan master slide dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus terlebih dahulu mengklon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian Anda harus menggunakan master slide tersebut untuk mengklon slide dengan master slide. Metode [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide beserta master, ikuti langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) yang berisi presentasi sumber slide yang akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan diklon.
1. Akses slide yang akan diklon bersama dengan master slide.
1. Instansiasi kelas [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/MasterSlideCollection) dengan merujuk ke koleksi Masters yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone) yang diekspor oleh objek [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/MasterSlideCollection) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone).
1. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) dengan menetapkan referensi ke koleksi Slides yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone) yang diekspor oleh objek [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSlides) dan berikan slide dari presentasi sumber yang akan diklon serta master slide sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengklon sebuah slide dengan master (berposisi indeks nol pada presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```php
  # Membuat instance kelas Presentation untuk memuat file presentasi sumber
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Membuat instance kelas Presentation untuk presentasi tujuan (tempat slide akan diklon)
    $destPres = new Presentation();
    try {
      # Membuat instance ISlide dari koleksi slide dalam presentasi sumber bersama dengan
      # Master slide
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
      # Presentasi tujuan
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
      # Presentasi tujuan
      $iSlide = $masters->addClone($SourceMaster);
      # Klon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
      # Koleksi slide dalam presentasi tujuan
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Simpan presentasi tujuan ke disk
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klon Slide di Akhir Seksi yang Ditentukan**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada seksi yang berbeda, gunakan metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection/#addClone) yang diekspor oleh kelas [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java memungkinkan mengklon slide dari seksi pertama dan kemudian menyisipkan slide yang diklon ke seksi kedua dari presentasi yang sama.

Potongan kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke seksi yang ditentukan.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Simpan presentasi tujuan ke disk
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Apakah catatan pembicara dan komentar reviewer diklon?**

Ya. Halaman catatan dan komentar review termasuk dalam klon. Jika Anda tidak menginginkannya, [hilangkan](/slides/id/php-java/presentation-notes/) setelah penyisipan.

**Bagaimana chart dan sumber data mereka ditangani?**

Objek chart, pemformatan, dan data tersemat disalin. Jika chart terhubung ke sumber eksternal (mis., workbook OLE-tersemat), hubungan tersebut dipertahankan sebagai [objek OLE](/slides/id/php-java/manage-ole/). Setelah dipindahkan antar file, periksa ketersediaan data dan perilaku penyegaran.

**Bisakah saya mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [seksi](/slides/id/php-java/slide-section/) yang dipilih. Jika seksi target belum ada, buat terlebih dahulu lalu pindahkan slide ke dalamnya.