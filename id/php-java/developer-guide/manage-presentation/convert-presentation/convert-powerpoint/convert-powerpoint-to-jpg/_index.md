---
title: Konversi PPT dan PPTX ke JPG di PHP
linktitle: PowerPoint ke JPG
type: docs
weight: 60
url: /id/php-java/convert-powerpoint-to-jpg/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke JPG
- presentasi ke JPG
- slide ke JPG
- PPT ke JPG
- PPTX ke JPG
- simpan PowerPoint sebagai JPG
- simpan presentasi sebagai JPG
- simpan slide sebagai JPG
- simpan PPT sebagai JPG
- simpan PPTX sebagai JPG
- ekspor PPT ke JPG
- ekspor PPTX ke JPG
- PHP
- Aspose.Slides
description: "Mengonversi slide PowerPoint (PPT, PPTX) menjadi gambar JPG berkualitas tinggi di PHP dengan Aspose.Slides untuk PHP menggunakan contoh kode yang cepat dan dapat diandalkan."
---
## **Pengantar**

Mengonversi presentasi PowerPoint dan OpenDocument ke gambar JPG membantu dalam berbagi slide, mengoptimalkan kinerja, dan menyematkan konten ke situs web atau aplikasi. Aspose.Slides memungkinkan Anda mengubah file PPTX, PPT, dan ODP menjadi gambar JPEG berkualitas tinggi. Panduan ini menjelaskan berbagai metode konversi.

Dengan fitur-fitur ini, mudah untuk mengimplementasikan penampil presentasi Anda sendiri dan membuat thumbnail untuk setiap slide. Ini dapat berguna jika Anda ingin melindungi slide presentasi dari penyalinan atau menampilkan presentasi dalam mode hanya-baca. Aspose.Slides memungkinkan Anda mengonversi seluruh presentasi atau slide tertentu ke format gambar.

## **Konversi PowerPoint PPT/PPTX ke JPG**

1. Buat instance tipe [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan objek slide tipe [Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/) dari koleksi [Presentation::getSlides()](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation#getSlides--).
3. Buat thumbnail setiap slide dan kemudian konversi ke JPG. Metode [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) digunakan untuk mendapatkan thumbnail sebuah slide. Metode [getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) harus dipanggil dari slide yang diperlukan tipe [Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/), skala thumbnail yang dihasilkan diberikan ke metode.
4. Setelah Anda mendapatkan thumbnail slide, panggil metode [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/id/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) dari objek thumbnail. Berikan nama file yang dihasilkan dan format gambar ke dalamnya.

{{% alert color="primary" %}}
**Catatan**: Konversi PPT/PPTX ke JPG berbeda dari konversi ke tipe lain dalam API Aspose.Slides. Untuk tipe lain, biasanya Anda menggunakan metode [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/save/), tetapi di sini Anda perlu metode [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/id/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Membuat gambar skala penuh
      $slideImage = $sld->getImage(1.0, 1.0);
      # Menyimpan gambar ke disk dalam format JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konversi PowerPoint PPT/PPTX ke JPG dengan Dimensi yang Disesuaikan**
Untuk mengubah dimensi thumbnail dan gambar JPG yang dihasilkan, Anda dapat mengatur nilai *ScaleX* dan *ScaleY* dengan melewatkannya ke metode [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage).

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Mendefinisikan dimensi
    $desiredX = 1200;
    $desiredY = 800;
    # Mendapatkan nilai skala X dan Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Membuat gambar skala penuh
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Menyimpan gambar ke disk dalam format JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Render Komentar Saat Menyimpan Slide sebagai Gambar**
Aspose.Slides untuk PHP via Java menyediakan fasilitas yang memungkinkan Anda merender komentar pada slide presentasi saat mengonversi slide tersebut menjadi gambar. Kode PHP ini menunjukkan operasinya:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose menyediakan [aplikasi web Collage GRATIS](https://products.aspose.app/slides/id/collage). Dengan layanan online ini, Anda dapat menggabungkan [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [grid foto](https://products.aspose.app/slides/id/collage/photo-grid), dan sebagainya. 

Dengan prinsip yang sama seperti yang dijelaskan dalam artikel ini, Anda dapat mengonversi gambar dari satu format ke format lain. Untuk informasi lebih lanjut, lihat halaman berikut: konversi [image to JPG](https://products.aspose.com/slides/id/php-java/conversion/image-to-jpg/); konversi [JPG to image](https://products.aspose.com/slides/id/php-java/conversion/jpg-to-image/); konversi [JPG to PNG](https://products.aspose.com/slides/id/php-java/conversion/jpg-to-png/), konversi [PNG to JPG](https://products.aspose.com/slides/id/php-java/conversion/png-to-jpg/); konversi [PNG to SVG](https://products.aspose.com/slides/id/php-java/conversion/png-to-svg/), konversi [SVG to PNG](https://products.aspose.com/slides/id/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Apakah metode ini mendukung konversi batch?**

Ya, Aspose.Slides memungkinkan konversi batch banyak slide ke JPG dalam satu operasi.

**Apakah konversi mendukung SmartArt, diagram, dan objek kompleks lainnya?**

Ya, Aspose.Slides merender semua konten, termasuk SmartArt, diagram, tabel, bentuk, dan lainnya. Namun, akurasi render dapat sedikit berbeda dibandingkan PowerPoint, terutama ketika menggunakan font khusus atau yang tidak tersedia.

**Apakah ada batasan jumlah slide yang dapat diproses?**

Aspose.Slides sendiri tidak memberlakukan batasan ketat pada jumlah slide yang dapat Anda proses. Namun, Anda mungkin mengalami kesalahan out-of-memory saat bekerja dengan presentasi besar atau gambar beresolusi tinggi.

## **Lihat Juga**

Lihat opsi lain untuk mengonversi PPT/PPTX menjadi gambar seperti:

- [Konversi PPT/PPTX ke SVG](/slides/id/php-java/render-a-slide-as-an-svg-image/).