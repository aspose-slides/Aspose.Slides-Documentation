---
title: Mengambil dan Memperbarui Informasi Presentasi dalam PHP
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/php-java/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- dapatkan properti
- baca properti
- ubah properti
- modifikasi properti
- perbarui properti
- periksa PPTX
- periksa PPT
- periksa ODP
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP untuk wawasan yang lebih cepat dan audit konten yang lebih pintar."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format saat ini dari sebuah presentasi tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/) serta menunjukkan operasi tipikal untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format apa (PPT, PPTX, ODP, dan lainnya) yang sedang digunakan oleh presentasi tersebut.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat kode PHP berikut:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Dapatkan Properti Presentasi**

Kode PHP ini menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Anda mungkin ingin melihat [properti di bawah kelas DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) yang memungkinkan Anda melakukan perubahan pada properti presentasi.

Misalkan kita memiliki presentasi PowerPoint dengan properti dokumen yang ditampilkan di bawah ini.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh kode ini menunjukkan cara mengedit beberapa properti presentasi:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Hasil perubahan properti dokumen ditampilkan di bawah ini.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang presentasi dan atribut keamanannya, Anda mungkin menemukan tautan berikut berguna:

- [Memeriksa apakah Presentasi terenkripsi](https://docs.aspose.com/slides/id/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Memeriksa apakah Presentasi dilindungi dari penulisan (hanya-baca)](https://docs.aspose.com/slides/id/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Memeriksa apakah Presentasi dilindungi kata sandi sebelum dimuat](https://docs.aspose.com/slides/id/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Mengonfirmasi Kata Sandi yang Digunakan untuk Melindungi Presentasi](https://docs.aspose.com/slides/id/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font di-embed dan font mana saja?**

Cari [informasi font ter-embed](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getembeddedfonts/) pada tingkat presentasi, lalu bandingkan entri tersebut dengan kumpulan [font yang benar-benar digunakan dalam konten](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getfonts/) untuk mengidentifikasi font mana yang penting untuk proses rendering.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasikan melalui [kumpulan slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/) dan periksa [bendera visibilitas](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/gethidden/) pada setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari nilai default?**

Ya. Bandingkan [ukuran slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getslidesize/) dan orientasi saat ini dengan preset standar; hal ini membantu memperkirakan perilaku saat mencetak dan mengekspor.

**Apakah ada cara cepat untuk melihat apakah grafik merujuk ke sumber data eksternal?**

Ya. Telusuri semua [grafik](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/), periksa [sumber data](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getdatasourcetype/) mereka, dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang dapat memperlambat proses rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan periksa adanya gambar besar, transparansi, bayangan, animasi, serta multimedia; berikan skor kompleksitas kasar untuk menandai potensi titik panas kinerja.