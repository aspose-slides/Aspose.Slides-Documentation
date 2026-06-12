---
title: Ambil dan Perbarui Informasi Presentasi dalam Java
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Java untuk wawasan yang lebih cepat dan audit konten yang lebih cerdas."
---
## **Ikhtisar**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format presentasi saat ini tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh‑contohnya didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/documentproperties/) serta memperagakan operasi umum untuk bekerja dengan metadata presentasi.

## **Memeriksa Format Presentasi**

Sebelum bekerja pada sebuah presentasi, Anda mungkin ingin mengetahui format (PPT, PPTX, ODP, dan lain‑lain) apa yang sedang digunakan oleh presentasi tersebut.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat contoh kode Java berikut:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Mendapatkan Properti Presentasi**

Contoh kode Java berikut menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Anda mungkin ingin melihat [properties under the DocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/documentproperties/#DocumentProperties--) kelas.

## **Memperbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) yang memungkinkan Anda melakukan perubahan pada properti presentasi.

Misalkan kami memiliki sebuah presentasi PowerPoint dengan properti dokumen seperti yang ditampilkan di bawah ini.

![Original document properties of the PowerPoint presentation](input_properties.png)

Contoh kode berikut menunjukkan cara mengedit beberapa properti presentasi:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Hasil perubahan properti dokumen ditampilkan di bawah ini.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang sebuah presentasi dan atribut keamanannya, Anda mungkin menemukan tautan‑tautan berikut berguna:

- [Memeriksa apakah Presentasi Terenkripsi](https://docs.aspose.com/slides/id/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Memeriksa apakah Presentasi Dilindungi Tulisan (baca‑saja)](https://docs.aspose.com/slides/id/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Memeriksa apakah Presentasi Dilindungi Kata Sandi Sebelum Memuatnya](https://docs.aspose.com/slides/id/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Mengonfirmasi Kata Sandi yang Digunakan untuk Melindungi Presentasi](https://docs.aspose.com/slides/id/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Bagaimana cara memeriksa apakah font tersemat dan font apa saja yang tersemat?**

Cari informasi [embedded-font](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) pada tingkat presentasi, kemudian bandingkan entri‑entri tersebut dengan kumpulan [fonts actually used across content](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/#getFonts--) untuk mengidentifikasi font mana yang penting untuk rendering.

**Bagaimana cara cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasi melalui [slide collection](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidecollection/) dan periksa setiap [visibility flag](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#getHidden--) pada slide.

**Bisakah saya mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Bandingkan [slide size](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSlideSize--) dan orientasi saat ini dengan preset standar; hal ini membantu memprediksi perilaku saat mencetak dan mengekspor.

**Apakah ada cara cepat untuk melihat apakah diagram mengacu pada sumber data eksternal?**

Ya. Telusuri semua [charts](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/), periksa [data source](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getDataSourceType--) mereka, dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana cara menilai slide “berat” yang dapat memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, serta multimedia; berikan skor kompleksitas kasar untuk menandai potensi titik kinerja yang lambat.