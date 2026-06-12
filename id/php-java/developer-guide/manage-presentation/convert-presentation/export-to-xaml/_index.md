---
title: Ekspor Presentasi ke XAML dalam PHP
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/php-java/export-to-xaml/
keywords:
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- PowerPoint ke XAML
- OpenDocument ke XAML
- presentasi ke XAML
- PPT ke XAML
- PPTX ke XAML
- ODP ke XAML
- simpan PPT sebagai XAML
- simpan PPTX sebagai XAML
- simpan ODP sebagai XAML
- ekspor PPT ke XAML
- ekspor PPTX ke XAML
- ekspor ODP ke XAML
- PHP
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML menggunakan Aspose.Slides untuk PHP melalui Java — solusi cepat tanpa Office yang menjaga tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Ini mencakup pengantar singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font fallback, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa pemrograman deskriptif yang memungkinkan Anda membangun atau menulis antarmuka pengguna untuk aplikasi, terutama yang menggunakan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin forms.  

XAML, yang merupakan bahasa berbasiskan XML, adalah varian Microsoft untuk mendeskripsikan GUI. Anda kemungkinan besar akan menggunakan desainer untuk bekerja pada file XAML sebagian besar waktu, tetapi Anda tetap dapat menulis dan mengedit GUI Anda.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Kode PHP ini menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Anda dapat memilih opsi dari kelas [XamlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/) yang mengontrol proses ekspor dan menentukan bagaimana Aspose.Slides mengekspor presentasi Anda ke XAML.

Sebagai contoh, jika Anda ingin Aspose.Slides menambahkan slide tersembunyi dari presentasi Anda saat mengekspornya ke XAML, Anda dapat menggunakan metode [setExportHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/setexporthiddenslides/) dengan nilai `true`. Lihat contoh kode PHP berikut:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bagaimana saya dapat memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Atur [font reguler default](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) di [XamlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/) — font ini akan digunakan sebagai font fallback ketika font asli tidak ada. Ini membantu menghindari substitusi yang tidak diharapkan.

**Apakah XAML yang diekspor dimaksudkan hanya untuk WPF, atau dapat digunakan di stack XAML lain juga?**

XAML adalah bahasa markup UI umum yang digunakan di WPF, UWP, dan Xamarin.Forms. Target ekspor kompatibel dengan stack XAML Microsoft; perilaku spesifik dan dukungan untuk konstruk tertentu tergantung pada platform target. Uji markup di lingkungan Anda.

**Apakah slide tersembunyi didukung, dan bagaimana saya dapat mencegahnya agar tidak diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/setexporthiddenslides/) di [XamlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/xamloptions/) — biarkan nonaktif jika Anda tidak perlu mengekspornya.