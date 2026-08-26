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
- Node.js
- JavaScript
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan JavaScript untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Overview**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format saat ini dari sebuah presentasi tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API PresentationInfo dan DocumentProperties serta menunjukkan operasi umum untuk bekerja dengan metadata presentasi.

## **Check a Presentation Format**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format (PPT, PPTX, ODP, dan lain-lain) presentasi tersebut saat ini.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat kode JavaScript berikut:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Get Presentation Properties**

Kode JavaScript ini menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Anda mungkin ingin melihat properti di bawah kelas DocumentProperties.

## **Update Presentation Properties**

Aspose.Slides menyediakan metode PresentationInfo.updateDocumentProperties yang memungkinkan Anda melakukan perubahan pada properti presentasi.

Misalkan kita memiliki sebuah presentasi PowerPoint dengan properti dokumen yang ditampilkan di bawah.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Useful Links**

Untuk mendapatkan informasi lebih lanjut tentang sebuah presentasi dan atribut keamanannya, Anda mungkin menemukan tautan berikut berguna:

- [Presentasi yang Dilindungi Kata Sandi](/slides/id/nodejs-java/password-protected-presentation/)
- [Presentasi yang Dilindungi Penulisan](/slides/id/nodejs-java/write-protected-presentation/)

## **FAQ**

**Bagaimana cara saya memeriksa apakah font tertanam dan yang mana?**

Carilah informasi font-tertanam pada level presentasi, lalu bandingkan entri tersebut dengan kumpulan font yang sebenarnya digunakan dalam konten untuk mengidentifikasi font mana yang penting untuk rendering.

**Bagaimana cara cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasikan koleksi slide dan periksa flag visibilitas setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide khusus digunakan, serta apakah berbeda dari default?**

Ya. Bandingkan ukuran dan orientasi slide saat ini dengan preset standar; ini membantu memperkirakan perilaku saat mencetak dan mengekspor.

**Apakah ada cara cepat untuk melihat apakah diagram merujuk ke sumber data eksternal?**

Ya. Telusuri semua diagram, periksa sumber data mereka, dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang dapat memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan periksa gambar besar, transparansi, bayangan, animasi, dan multimedia; berikan skor kompleksitas kasar untuk menandai potensi titik panas kinerja.