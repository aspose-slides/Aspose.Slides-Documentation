---
title: Ekspor Presentasi ke XAML dalam Java
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML dalam Java menggunakan Aspose.Slides—solusi cepat tanpa Office yang menjaga tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengenalan singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font cadangan, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa pemrograman deskriptif yang memungkinkan Anda membangun atau menulis antarmuka pengguna untuk aplikasi, terutama yang menggunakan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin Forms.  

XAML, yang merupakan bahasa berbasis XML, adalah varian Microsoft untuk mendeskripsikan GUI. Anda kemungkinan besar akan menggunakan desainer untuk bekerja dengan file XAML sebagian besar waktu, tetapi Anda tetap dapat menulis dan mengedit GUI Anda.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Kode Java berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Anda dapat memilih opsi dari antarmuka [IXamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/IXamlOptions) yang mengontrol proses ekspor dan menentukan bagaimana Aspose.Slides mengekspor presentasi Anda ke XAML. 

Misalnya, jika Anda ingin Aspose.Slides menambahkan slide tersembunyi dari presentasi Anda saat mengekspornya ke XAML, Anda dapat mengatur properti [ExportHiddenSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) menjadi true. Lihat contoh kode Java berikut:

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

Atur [a default regular font](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) di [XamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/) — font ini digunakan sebagai font cadangan ketika font asli tidak ada. Hal ini membantu menghindari substitusi yang tidak diharapkan.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat digunakan di stack XAML lain juga?**

XAML adalah bahasa markup UI umum yang digunakan di WPF, UWP, dan Xamarin.Forms. Ekspor ditujukan untuk kompatibilitas dengan stack XAML Microsoft; perilaku tepat dan dukungan untuk konstruksi tertentu bergantung pada platform target. Uji markup di lingkungan Anda.

**Apakah slide tersembunyi didukung, dan bagaimana saya dapat mencegahnya diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) di [XamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/) — biarkan nonaktif jika Anda tidak perlu mengekspornya.