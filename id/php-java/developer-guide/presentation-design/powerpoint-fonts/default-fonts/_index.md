---
title: Tentukan Font Presentasi Default di PHP
linktitle: Font Default
type: docs
weight: 30
url: /id/php-java/default-font/
keywords:
- font default
- font reguler
- font normal
- font Asia
- ekspor PDF
- ekspor XPS
- ekspor gambar
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Atur font default di Aspose.Slides untuk PHP via Java agar konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) ke PDF, XPS, dan gambar berjalan dengan baik."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan ketika presentasi dirender. Ini berguna saat membuat thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui `LoadOptions` sebelum presentasi dimuat.

Metode `setDefaultRegularFont` menentukan font default untuk teks reguler, sedangkan `setDefaultAsianFont` menentukan font default untuk teks Asia. Setelah opsi-opsi ini diatur, presentasi dapat dimuat dan dirender menggunakan font yang telah ditentukan.

## **Gunakan Font Default untuk Merender Presentasi**
Aspose.Slides memungkinkan Anda mengatur font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Artikel ini menunjukkan cara mendefinisikan DefaultRegularFont dan DefaultAsianFont untuk digunakan sebagai font default. Silakan ikuti langkah-langkah di bawah ini untuk memuat font dari direktori eksternal menggunakan Aspose.Slides untuk PHP via Java API:

1. Buat sebuah instance dari [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/LoadOptions).
1. [Setel DefaultRegularFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) ke font yang diinginkan. Pada contoh berikut, saya menggunakan Wingdings.
1. [Setel DefaultAsianFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) ke font yang diinginkan. Saya menggunakan Wingdings dalam contoh berikut.
1. Muat presentasi menggunakan Presentation dan mengatur opsi pemuatan.
1. Sekarang, buat thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.

Implementasi di atas diberikan di bawah.

```php
  # Gunakan opsi pemuatan untuk menentukan font regular dan Asian default
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Muat presentasi
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Buat thumbnail slide
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # simpan gambar ke disk.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Buat PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Buat XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tanya Jawab**

**Apa sebenarnya yang dipengaruhi oleh DefaultRegularFont dan DefaultAsianFont—hanya ekspor, atau juga thumbnail, PDF, XPS, HTML, dan SVG?**

Mereka berpartisipasi dalam pipeline rendering untuk semua output yang didukung. Ini mencakup thumbnail slide, [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/php-java/convert-powerpoint-to-xps/), [gambar raster](/slides/id/php-java/convert-powerpoint-to-png/), [HTML](/slides/id/php-java/convert-powerpoint-to-html/), dan [SVG](/slides/id/php-java/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glyph yang sama di semua target tersebut.

**Apakah font default diterapkan saat hanya membaca dan menyimpan PPTX tanpa rendering apa pun?**

Tidak. Font default penting ketika teks harus diukur dan digambar. Membuka dan menyimpan presentasi secara langsung tidak mengubah rentang font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengalirkan kembali teks.

**Jika saya menambahkan folder font saya sendiri atau menyediakan font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Sumber font khusus](/slides/id/php-java/custom-font/) memperluas katalog keluarga dan glyph yang tersedia untuk engine. Font default dan setiap [aturan fallback](/slides/id/php-java/fallback-font/) akan terlebih dahulu menyelesaikan ke sumber tersebut, memberikan cakupan yang lebih dapat diandalkan pada server dan dalam kontainer.

**Apakah font default memengaruhi metrik teks (kerning, kemajuan) dan dengan demikian pemenggalan baris serta pembungkusan?**

Ya. Mengubah font mengubah metrik glyph dan dapat mengubah pemenggalan baris, pembungkusan, serta paginasi selama rendering. Untuk stabilitas tata letak, [sematkan font asli](/slides/id/php-java/embedded-font/) atau pilih keluarga default dan fallback yang kompatibel secara metrik.

**Apakah ada gunanya mengatur font default jika semua font yang digunakan dalam presentasi sudah disematkan?**

Sering kali tidak diperlukan, karena [font yang disematkan](/slides/id/php-java/embedded-font/) sudah memastikan tampilan konsisten. Font default tetap berguna sebagai jaring pengaman untuk karakter yang tidak tercakup dalam subset yang disematkan atau ketika sebuah file mencampur teks yang disematkan dan tidak disematkan.