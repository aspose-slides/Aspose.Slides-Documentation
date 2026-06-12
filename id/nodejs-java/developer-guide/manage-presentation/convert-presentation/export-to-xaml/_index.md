---
title: Ekspor Presentasi ke XAML dalam JavaScript
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengonversi slide PowerPoint dan OpenDocument ke XAML dalam JavaScript menggunakan Aspose.Slides untuk Node.js—solusi cepat tanpa Office yang mempertahankan tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengantar singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font fallback, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa pemrograman deskriptif yang memungkinkan Anda membangun atau menulis kelas pengguna untuk aplikasi, terutama yang menggunakan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin Forms.

XAML, yang merupakan bahasa berbasis XML, adalah varian Microsoft untuk mendeskripsikan antarmuka pengguna (GUI). Anda mungkin akan menggunakan desainer untuk mengerjakan file XAML kebanyakan waktu, tetapi Anda tetap dapat menulis dan mengedit GUI Anda.

## **Mengekspor Presentasi ke XAML dengan Opsi Default**

Kode JavaScript berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengekspor Presentasi ke XAML dengan Opsi Kustom**

Anda dapat memilih opsi dari kelas [XamlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/) yang mengontrol proses ekspor dan menentukan bagaimana Aspose.Slides mengekspor presentasi Anda ke XAML.

Sebagai contoh, jika Anda ingin Aspose.Slides menambahkan slide tersembunyi dari presentasi Anda saat mengekspornya ke XAML, Anda dapat mengatur metode [setExportHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) ke true. Lihat contoh kode JavaScript ini:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Bagaimana saya dapat memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Gunakan [setDefaultRegularFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) di [XamlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/) — font ini digunakan sebagai font cadangan ketika font asli tidak ada. Hal ini membantu menghindari substitusi yang tidak terduga.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat juga digunakan di stack XAML lain?**

XAML adalah bahasa markup UI umum yang digunakan di WPF, UWP, dan Xamarin.Forms. Ekspor ditujukan untuk kompatibilitas dengan stack XAML Microsoft; perilaku tepat dan dukungan untuk konstruksi tertentu bergantung pada platform target. Uji markup tersebut di lingkungan Anda.

**Apakah slide tersembunyi didukung, dan bagaimana saya dapat mencegahnya diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) di [XamlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/) — biarkan nonaktif jika Anda tidak perlu mengekspornya.