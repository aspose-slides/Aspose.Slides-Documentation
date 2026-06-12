---
title: Ekspor Presentasi ke XAML dalam C++
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML dalam C++ menggunakan Aspose.Slides—solusi cepat tanpa Office yang mempertahankan tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengenalan singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font cadangan, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa pemrograman deskriptif yang memungkinkan Anda membangun atau menulis antarmuka pengguna untuk aplikasi, terutama yang menggunakan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin Forms.  

XAML, yang merupakan bahasa berbasis XML, adalah varian Microsoft untuk mendeskripsikan GUI. Anda kemungkinan akan menggunakan desainer untuk mengerjakan file XAML sebagian besar waktu, tetapi Anda masih dapat menulis dan mengedit GUI Anda secara manual.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Kode C++ berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Anda dapat memilih opsi dari antarmuka [IXamlOptions](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.xaml.i_xaml_options) yang mengendalikan proses ekspor dan menentukan bagaimana Aspose.Slides mengekspor presentasi Anda ke XAML. 

Sebagai contoh, jika Anda ingin Aspose.Slides menambahkan slide tersembunyi dari presentasi Anda saat mengekspornya ke XAML, Anda dapat memberikan nilai true ke metode [set_ExportHiddenSlides()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Lihat contoh kode C++ berikut:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **FAQ**

**Bagaimana cara memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Gunakan [set_DefaultRegularFont](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) dalam [XamlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/) — font ini digunakan sebagai font cadangan ketika font asli tidak ada. Hal ini membantu menghindari substitusi yang tidak terduga.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat juga digunakan di stack XAML lain?**

XAML adalah bahasa markup UI umum yang digunakan di WPF, UWP, dan Xamarin.Forms. Ekspor menargetkan kompatibilitas dengan stack XAML Microsoft; perilaku dan dukungan untuk konstruksi tertentu bergantung pada platform target. Uji markup di lingkungan Anda.

**Apakah slide tersembunyi didukung, dan bagaimana cara mencegahnya diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengendalikan perilaku ini melalui [set_ExportHiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) dalam [XamlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export.xaml/xamloptions/) — biarkan opsi ini nonaktif jika Anda tidak perlu mengekspor slide tersembunyi.