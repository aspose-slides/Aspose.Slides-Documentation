---
title: Ekspor Presentasi ke XAML dengan Python
linktitle: Ekspor ke XAML
type: docs
weight: 30
url: /id/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML dalam Python menggunakan Aspose.Slides—solusi cepat tanpa Office yang mempertahankan tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengantar singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font cadangan, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa pemrograman deskriptif yang memungkinkan Anda membangun atau menulis antarmuka pengguna untuk aplikasi, terutama yang menggunakan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin Forms.  

XAML, yang merupakan bahasa berbasis XML, adalah varian Microsoft untuk menggambarkan GUI. Anda kemungkinan besar akan menggunakan desainer untuk mengerjakan file XAML sebagian besar waktu, tetapi Anda masih dapat menulis dan mengedit GUI Anda. 

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Kode Python berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Anda dapat memilih opsi dari kelas [XamlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/) yang mengontrol proses ekspor dan menentukan bagaimana Aspose.Slides mengekspor presentasi Anda ke XAML. 

Misalnya, jika Anda ingin Aspose.Slides menambahkan slide tersembunyi dari presentasi Anda saat mengekspor ke XAML, Anda dapat mengatur properti [export_hidden_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) ke `True`. Lihat contoh kode Python ini: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**Bagaimana saya dapat memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Setel [default_regular_font](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) di [XamlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/) — ia digunakan sebagai font cadangan ketika font asli tidak ada. Ini membantu menghindari substitusi yang tidak terduga.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat digunakan di stack XAML lainnya juga?**

XAML adalah bahasa markup UI umum yang digunakan di WPF, UWP, dan Xamarin.Forms. Ekspor ditujukan untuk kompatibilitas dengan stack XAML Microsoft; perilaku tepat dan dukungan untuk konstruk khusus bergantung pada platform target. Uji markup tersebut di lingkungan Anda.

**Apakah slide tersembunyi didukung, dan bagaimana saya dapat mencegahnya diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [export_hidden_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) di [XamlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.xaml/xamloptions/) — biarkan nonaktif jika Anda tidak perlu mengekspornya.