---
title: Menggabungkan Presentasi secara Efisien di PHP
linktitle: Gabungkan Presentasi
type: docs
weight: 40
url: /id/php-java/merge-presentation/
keywords:
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- PHP
- Aspose.Slides
description: Gabungkan presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) dengan mudah menggunakan Aspose.Slides untuk PHP via Java, menyederhanakan alur kerja Anda.
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menggabungkan presentasi dengan mengkloning slide dari satu presentasi ke presentasi lain. Artikel ini menjelaskan cara menggabungkan seluruh presentasi atau slide tertentu, menggunakan slide master atau tata letak spesifik selama penggabungan, menangani presentasi dengan ukuran slide yang berbeda, dan menambahkan slide yang digabung ke dalam bagian presentasi. Artikel ini juga mencakup catatan praktis terkait konten yang digabung, termasuk catatan pembicara, komentar, file sumber yang dilindungi kata sandi, dan penggunaan thread.

## **Penggabungan Presentasi**

Saat Anda menggabungkan satu presentasi ke presentasi lain, Anda pada dasarnya menggabungkan slide‑slide mereka dalam satu presentasi untuk memperoleh satu berkas.

{{% alert title="Info" color="info" %}}

Sebagian besar program presentasi (PowerPoint atau OpenOffice) tidak memiliki fungsi yang memungkinkan pengguna menggabungkan presentasi dengan cara tersebut.

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/id/php-java/), bagaimanapun, memungkinkan Anda menggabungkan presentasi dengan berbagai cara. Anda dapat menggabungkan presentasi beserta semua bentuk, gaya, teks, pemformatan, komentar, animasi, dll. tanpa harus khawatir tentang kehilangan kualitas atau data.

**Lihat juga**

[Clone Slides](/slides/id/php-java/clone-slides/).

{{% /alert %}}

### **Apa yang Dapat Digabung**

Dengan Aspose.Slides, Anda dapat menggabungkan 

* seluruh presentasi. Semua slide dari presentasi tersebut berakhir dalam satu presentasi
* slide tertentu. Slide yang dipilih berakhir dalam satu presentasi
* presentasi dalam satu format (PPT ke PPT, PPTX ke PPTX, dll.) dan dalam format berbeda (PPT ke PPTX, PPTX ke ODP, dll.) satu sama lain. 

{{% alert title="Catatan" color="warning" %}} 

Selain presentasi, Aspose.Slides memungkinkan Anda menggabungkan file lain:

* [Images](https://products.aspose.com/slides/id/php-java/merger/image-to-image/), seperti [JPG ke JPG](https://products.aspose.com/slides/id/php-java/merger/jpg-to-jpg/) atau [PNG ke PNG](https://products.aspose.com/slides/id/php-java/merger/png-to-png/)
* Dokumen, seperti [PDF ke PDF](https://products.aspose.com/slides/id/php-java/merger/pdf-to-pdf/) atau [HTML ke HTML](https://products.aspose.com/slides/id/php-java/merger/html-to-html/)
* Dan dua file berbeda seperti [image ke PDF](https://products.aspose.com/slides/id/php-java/merger/image-to-pdf/) atau [JPG ke PDF](https://products.aspose.com/slides/id/php-java/merger/jpg-to-pdf/) atau [TIFF ke PDF](https://products.aspose.com/slides/id/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opsi Penggabungan**

Anda dapat menerapkan opsi yang menentukan apakah

* setiap slide dalam presentasi output mempertahankan gaya unik
* gaya tertentu digunakan untuk semua slide dalam presentasi output. 

Untuk menggabungkan presentasi, Aspose.Slides menyediakan metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) (dari kelas [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/)). Ada beberapa implementasi metode `addClone` yang menentukan parameter proses penggabungan presentasi. Setiap objek Presentation memiliki koleksi [slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getslides/), sehingga Anda dapat memanggil metode `addClone` dari presentasi yang ingin Anda tambahkan slide.

Metode `addClone` mengembalikan objek `Slide`, yang merupakan klon dari slide sumber. Slide dalam presentasi output hanyalah salinan slide dari sumber. Karena itu, Anda dapat mengubah slide hasil (misalnya, menerapkan gaya atau opsi pemformatan atau tata letak) tanpa harus khawatir presentasi sumber terpengaruh. 

## **Menggabungkan Presentasi** 

Aspose.Slides menyediakan metode [addClone(Slide)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) yang memungkinkan Anda menggabungkan slide sambil mempertahankan tata letak dan gaya slide (parameter default).

Kode PHP berikut menunjukkan cara menggabungkan presentasi:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Menggabungkan Presentasi dengan Slide Master**

Aspose.Slides menyediakan metode [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) yang memungkinkan Anda menggabungkan slide sambil menerapkan templat slide master. Dengan cara ini, bila diperlukan, Anda dapat mengubah gaya slide dalam presentasi output.

Kode berikut mendemonstrasikan operasi yang dijelaskan:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Catatan" color="warning" %}} 

Tata letak slide untuk slide master ditentukan secara otomatis. Ketika tata letak yang sesuai tidak dapat ditentukan, jika parameter boolean `allowCloneMissingLayout` pada metode `addClone` diatur ke true, tata letak untuk slide sumber akan digunakan. Jika tidak, [PptxEditException](https://reference.aspose.com/slides/id/php-java/aspose.slides/PptxEditException) akan dilempar.

{{% /alert %}}

Jika Anda menginginkan slide dalam presentasi output memiliki tata letak slide yang berbeda, gunakan metode [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) sebagai gantinya saat menggabungkan.

## **Menggabungkan Slide Tertentu dari Presentasi**

Menggabungkan slide tertentu dari beberapa presentasi berguna untuk membuat dek slide khusus. Aspose.Slides for PHP via Java memungkinkan Anda memilih dan mengimpor hanya slide yang Anda perlukan. API menjaga pemformatan, tata letak, dan desain slide asli.

Kode PHP berikut membuat presentasi baru, menambahkan slide judul dari dua presentasi lain, dan menyimpan hasilnya ke file:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Menggabungkan Presentasi dengan Tata Letak Slide**

Kode PHP ini menunjukkan cara menggabungkan slide dari presentasi sambil menerapkan tata letak slide pilihan Anda sehingga menghasilkan satu presentasi output:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda**

{{% alert title="Catatan" color="warning" %}} 

Anda tidak dapat menggabungkan presentasi dengan ukuran slide yang berbeda. 

{{% /alert %}}

Untuk menggabungkan 2 presentasi dengan ukuran slide yang berbeda, Anda harus mengubah ukuran salah satu presentasi agar ukurannya cocok dengan presentasi yang lain. 

Kode contoh berikut mendemonstrasikan operasi yang dijelaskan:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Menggabungkan Slide ke Bagian Presentasi**

Kode PHP ini menunjukkan cara menggabungkan slide tertentu ke sebuah bagian dalam presentasi:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

Slide ditambahkan di akhir bagian. 

## **Lihat Juga**


Aspose menyediakan [FREE Online Collage Maker](https://products.aspose.app/slides/id/collage). Dengan layanan online ini, Anda dapat menggabungkan [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [photo grids](https://products.aspose.app/slides/id/collage/photo-grid), dan lainnya.

Coba [Aspose FREE Online Merger](https://products.aspose.app/slides/id/merger). Layanan ini memungkinkan Anda menggabungkan presentasi PowerPoint dalam format yang sama (misalnya PPT ke PPT, PPTX ke PPTX) atau antara format yang berbeda (misalnya PPT ke PPTX, PPTX ke ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/id/merger)

## **FAQ**

**Apakah ada batasan jumlah slide saat menggabungkan presentasi?**

Tidak ada batasan ketat. Aspose.Slides dapat menangani berkas besar, tetapi kinerja tergantung pada ukuran berkas dan sumber daya sistem. Untuk presentasi yang sangat besar, disarankan menggunakan JVM 64‑bit dan menyediakan memori heap yang cukup.

**Apakah saya dapat menggabungkan presentasi dengan video atau audio yang disematkan?**

Ya, Aspose.Slides mempertahankan konten multimedia yang disematkan dalam slide, tetapi presentasi akhir mungkin menjadi jauh lebih besar.

**Apakah font akan dipertahankan saat menggabungkan presentasi?**

Ya. Font yang digunakan dalam presentasi sumber dipertahankan dalam berkas output, dengan asumsi font tersebut terpasang di sistem atau [embedded](/slides/id/php-java/embedded-font/).