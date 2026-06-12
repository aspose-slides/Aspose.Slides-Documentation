---
title: Mengambil dan Memperbarui Informasi Presentasi dalam JavaScript
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/nodejs-java/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- mendapatkan properti
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan JavaScript untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Ringkasan**

Artikel ini memperlihatkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format presentasi saat ini tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/) serta menunjukkan operasi umum untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format apa (PPT, PPTX, ODP, dan lainnya) yang sedang digunakan oleh presentasi tersebut.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat kode JavaScript berikut:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Dapatkan Properti Presentasi**

Kode JavaScript ini menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Anda mungkin ingin melihat [properti di bawah kelas DocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) yang memungkinkan Anda melakukan perubahan pada properti presentasi.

Misalkan kita memiliki sebuah presentasi PowerPoint dengan properti dokumen seperti yang ditunjukkan di bawah.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh kode ini menunjukkan cara mengedit beberapa properti presentasi:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Hasil perubahan properti dokumen ditampilkan di bawah.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang sebuah presentasi dan atribut keamanannya, Anda mungkin menemukan tautan berikut berguna:

- [Memeriksa apakah sebuah Presentasi dienkripsi](https://docs.aspose.com/slides/id/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Memeriksa apakah sebuah Presentasi dilindungi Tulisan (hanya-baca)](https://docs.aspose.com/slides/id/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Memeriksa apakah sebuah Presentasi dilindungi Kata Sandi Sebelum Memuatnya](https://docs.aspose.com/slides/id/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Mengonfirmasi Kata Sandi yang Digunakan untuk Melindungi Presentasi](https://docs.aspose.com/slides/id/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font di-embed dan mana saja yang di-embed?**

Cari informasi [embedded-font information](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) pada tingkat presentasi, kemudian bandingkan entri tersebut dengan kumpulan [fonts actually used across content](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getfonts/) untuk mengidentifikasi font mana yang penting untuk rendering.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasikan melalui [slide collection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/) dan periksa [visibility flag](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/gethidden/) setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah mereka berbeda dari nilai default?**

Ya. Bandingkan [slide size](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getslidesize/) dan orientasi saat ini dengan preset standar; ini membantu memprediksi perilaku saat pencetakan dan ekspor.

**Apakah ada cara cepat untuk melihat apakah diagram mengacu pada sumber data eksternal?**

Ya. Telusuri semua [charts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/), periksa [data source](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) mereka, dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang dapat memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, serta multimedia; berikan skor kompleksitas kasar untuk menandai potensi hotspot kinerja.