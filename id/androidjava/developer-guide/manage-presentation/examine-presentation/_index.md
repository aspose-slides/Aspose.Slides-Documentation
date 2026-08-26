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
- ambil properti
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
- Android
- Java
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Java untuk wawasan yang lebih cepat dan audit konten yang lebih cerdas."
---
## **Ikhtisar**

Artikel ini menunjukkan cara memeriksa informasi presentasi dalam Aspose.Slides. Artikel ini menjelaskan cara menentukan format presentasi saat ini tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/documentproperties/) dan memperagakan operasi umum untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format (PPT, PPTX, ODP, dan lainnya) dari presentasi tersebut saat ini.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat kode Java ini:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Anda mungkin ingin melihat [properti di bawah kelas DocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) yang memungkinkan Anda melakukan perubahan pada properti presentasi.

Misalkan kita memiliki presentasi PowerPoint dengan properti dokumen seperti yang ditunjukkan di bawah.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh kode ini menunjukkan cara mengedit beberapa properti presentasi:

```java
import com.aspose.slides.*;
import java.util.Date;

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

- [Presentasi Dilindungi Kata Sandi](/slides/id/androidjava/password-protected-presentation/)
- [Presentasi Dilindungi Penulisan](/slides/id/androidjava/write-protected-presentation/)

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font tersemat dan yang mana?**

Cari [informasi font tersemat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) pada level presentasi, kemudian bandingkan entri tersebut dengan kumpulan [font yang memang digunakan dalam konten](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsmanager/#getFonts--) untuk mengidentifikasi font mana yang penting untuk rendering.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasikan [koleksi slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidecollection/) dan periksa [bendera visibilitas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#getHidden--) setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Bandingkan [ukuran slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSlideSize--) dan orientasi saat ini dengan preset standar; ini membantu memperkirakan perilaku untuk pencetakan dan ekspor.

**Apakah ada cara cepat untuk melihat apakah chart merujuk ke sumber data eksternal?**

Ya. Telusuri semua [chart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/), periksa [sumber data](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chartdata/#getDataSourceType--), dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang dapat memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, serta multimedia; berikan skor kompleksitas kasar untuk menandai potensi titik panas kinerja.