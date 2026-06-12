---
title: Mengambil dan Memperbarui Informasi Presentasi di Android
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/androidjava/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- mengambil properti
- membaca properti
- mengubah properti
- memodifikasi properti
- memperbarui properti
- memeriksa PPTX
- memeriksa PPT
- memeriksa ODP
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Java untuk wawasan yang lebih cepat dan audit konten yang lebih cerdas.
---
## **Ikhtisar**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format saat ini dari sebuah presentasi tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/documentproperties/) serta menunjukkan operasi tipikal untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format (PPT, PPTX, ODP, dan lainnya) apa yang sedang digunakan presentasi tersebut.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat kode Java berikut:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Dapatkan Properti Presentasi**

Kode Java ini menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Anda mungkin ingin melihat properti di bawah kelas [DocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) yang memungkinkan Anda membuat perubahan pada properti presentasi.

Misalkan kita memiliki presentasi PowerPoint dengan properti dokumen yang ditampilkan di bawah ini.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh kode ini menunjukkan cara mengedit beberapa properti presentasi:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Hasil perubahan properti dokumen ditampilkan di bawah.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang sebuah presentasi dan atribut keamanannya, Anda mungkin menemukan tautan berikut berguna:

- [Memeriksa apakah Presentasi Terenkripsi](https://docs.aspose.com/slides/id/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Memeriksa apakah Presentasi Dilindungi Penulisan (hanya-baca)](https://docs.aspose.com/slides/id/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Memeriksa apakah Presentasi Dilindungi Kata Sandi Sebelum Memuatnya](https://docs.aspose.com/slides/id/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Mengonfirmasi Kata Sandi yang Digunakan untuk Melindungi Presentasi](https://docs.aspose.com/slides/id/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font disematkan dan yang mana?**

Cari informasi font yang disematkan pada level presentasi, lalu bandingkan entri tersebut dengan kumpulan font yang sebenarnya digunakan di seluruh konten untuk mengidentifikasi font mana yang penting untuk penampilan.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasi melalui koleksi slide dan periksa flag visibilitas tiap slide.

**Bisakah saya mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Bandingkan ukuran dan orientasi slide saat ini dengan preset standar; ini membantu memperkirakan perilaku untuk pencetakan dan ekspor.

**Apakah ada cara cepat untuk melihat apakah bagan merujuk ke sumber data eksternal?**

Ya. Telusuri semua bagan, periksa sumber data mereka, dan catat apakah datanya internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang mungkin memperlambat render atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, dan multimedia; berikan skor kompleksitas kasar untuk menandai potensi hotspot kinerja.