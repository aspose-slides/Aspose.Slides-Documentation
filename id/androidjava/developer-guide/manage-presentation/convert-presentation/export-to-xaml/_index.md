---
title: Ekspor Presentasi ke XAML di Android
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML dalam Java menggunakan Aspose.Slides untuk Android—solusi cepat tanpa Office yang mempertahankan tata letak Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengenalan singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font fallback, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa pemrograman deskriptif yang memungkinkan Anda membangun atau menulis antarmuka pengguna untuk aplikasi, terutama aplikasi yang menggunakan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin Forms.  

XAML, yang merupakan bahasa berbasis XML, adalah varian Microsoft untuk mendeskripsikan GUI. Anda kemungkinan besar akan menggunakan desainer untuk mengerjakan file XAML sebagian besar waktu, tetapi Anda tetap dapat menulis dan menyunting GUI Anda.

## **Ekspor Presentasi ke XAML dengan Opsi Standar**

Kode Java ini menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Anda dapat memilih opsi dari antarmuka [IXamlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IXamlOptions) yang mengontrol proses ekspor dan menentukan bagaimana Aspose.Slides mengekspor presentasi Anda ke XAML.

Sebagai contoh, jika Anda ingin Aspose.Slides menambahkan slide tersembunyi dari presentasi Anda ketika mengekspornya ke XAML, Anda dapat mengatur properti [ExportHiddenSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) ke true. Lihat contoh kode Java berikut:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bagaimana saya dapat memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Atur [font reguler default](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) di [XamlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/xamloptions/) — font ini akan digunakan sebagai font fallback ketika font asli tidak ada. Hal ini membantu menghindari substitusi yang tidak diharapkan.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat juga digunakan di stack XAML lainnya?**

XAML adalah bahasa markup UI umum yang digunakan di WPF, UWP, dan Xamarin.Forms. Ekspor ditujukan untuk kompatibilitas dengan stack XAML Microsoft; perilaku tepat dan dukungan untuk konstruk tertentu bergantung pada platform target. Uji markup di lingkungan Anda.

**Apakah slide tersembunyi didukung, dan bagaimana saya dapat mencegah mereka diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) di [XamlOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/xamloptions/) — biarkan opsi ini nonaktif jika Anda tidak perlu mengekspor slide tersembunyi.