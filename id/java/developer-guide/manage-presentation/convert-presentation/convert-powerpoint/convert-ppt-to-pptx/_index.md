---
title: Konversi PPT ke PPTX dengan Java
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/java/convert-ppt-to-pptx/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- PPT ke PPTX
- simpan PPT sebagai PPTX
- ekspor PPT ke PPTX
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Konversi presentasi PPT lama ke PPTX modern dengan cepat di Java menggunakan Aspose.Slides — tutorial jelas, contoh kode gratis, tanpa ketergantungan Microsoft Office."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPT ke format PPTX menggunakan Java dan aplikasi konversi online PPT ke PPTX. Topik berikut dibahas.

- Mengonversi PPT ke PPTX dengan Java

## **Mengonversi PPT ke PPTX dengan Java**

Untuk contoh kode Java yang mengonversi PPT ke PPTX, lihat bagian di bawah ini misalnya [Convert PPT to PPTX](#convert-ppt-to-pptx). Kode hanya memuat file PPT dan menyimpannya dalam format PPTX. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPT ke banyak format lain seperti PDF, XPS, ODP, HTML, dll. sebagaimana dibahas dalam artikel-artikel ini.

- [Mengonversi PPT ke PDF dengan Java](/slides/id/java/convert-powerpoint-to-pdf/)
- [Mengonversi PPT ke XPS dengan Java](/slides/id/java/convert-powerpoint-to-xps/)
- [Mengonversi PPT ke HTML dengan Java](/slides/id/java/convert-powerpoint-to-html/)
- [Mengonversi PPT ke ODP dengan Java](/slides/id/java/save-presentation/)
- [Mengonversi PPT ke PNG dengan Java](/slides/id/java/convert-powerpoint-to-png/)

## **Tentang Konversi PPT ke PPTX**
Konversi format PPT lama ke PPTX dengan Aspose.Slides API. Jika Anda perlu mengonversi ribuan presentasi PPT ke format PPTX, solusi terbaik adalah melakukannya secara programatis. Dengan Aspose.Slides API, hal ini dapat dilakukan hanya dengan beberapa baris kode. API mendukung kompatibilitas penuh untuk mengonversi presentasi PPT ke PPTX dan dapat:

- Mengonversi struktur rumit master, tata letak, dan slide.
- Mengonversi presentasi dengan diagram.
- Mengonversi presentasi dengan bentuk grup, auto-shape (seperti persegi panjang dan elips), bentuk dengan geometri khusus.
- Mengonversi presentasi yang memiliki tekstur dan gaya isi gambar untuk auto-shape.
- Mengonversi presentasi dengan placeholder, bingkai teks, dan pemegang teks.

{{% alert color="info" %}} 

Lihat [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/id/conversion/ppt-to-pptx) aplikasi:
[](https://products.aspose.app/slides/id/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/id/conversion/ppt-to-pptx)

Aplikasi ini dibangun berdasarkan [**Aspose.Slides API**](https://products.aspose.com/slides/id/java/), sehingga Anda dapat melihat contoh nyata kemampuan konversi dasar PPT ke PPTX. Aspose.Slides Conversion adalah aplikasi web, yang memungkinkan Anda menjatuhkan file presentasi dalam format PPT dan mengunduhnya setelah dikonversi ke PPTX.

Temukan contoh live lainnya dari [**Aspose.Slides Conversion**](https://products.aspose.app/slides/id/conversion/) .

{{% /alert %}} 

## **Mengonversi PPT ke PPTX**
Aspose.Slides untuk Java kini memudahkan pengembang mengakses PPT menggunakan instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan mengonversinya ke format [PPTX](https://docs.fileformat.com/presentation/pptx/) yang bersangkutan. Saat ini, ia mendukung konversi parsial dari [PPT](https://docs.fileformat.com/presentation/ppt/)to PPTX. Untuk detail lebih lanjut tentang fitur yang didukung dan tidak didukung dalam konversi PPT ke PPTX, silakan lihat dokumentasi ini [link](/slides/id/java/ppt-to-pptx-conversion/).

Aspose.Slides untuk Java menawarkan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) yang mewakili file presentasi **PPTX**. Kelas Presentation kini juga dapat mengakses **PPT** melalui Presentation saat objek diinstansiasi. Contoh berikut menunjukkan cara mengonversi presentasi PPT menjadi Presentasi PPTX.

```java
import com.aspose.slides.*;

// Membuat objek Presentation yang mewakili file PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
// Menyimpan presentasi PPT ke format PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Gambar : Presentasi PPT Sumber**|

The above code snippet generated the following PPTX presentation after conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Gambar: Presentasi PPTX yang Dihasilkan setelah konversi**|

## **FAQ**

### Apa perbedaan antara format PPT dan PPTX?

PPT adalah format file biner lama yang digunakan oleh Microsoft PowerPoint, sedangkan PPTX adalah format berbasis XML yang lebih baru yang diperkenalkan pada Microsoft Office 2007. File PPTX menawarkan kinerja yang lebih baik, ukuran file yang lebih kecil, dan pemulihan data yang lebih baik.

### Apakah Aspose.Slides mendukung konversi batch beberapa file PPT ke PPTX?

Ya, Anda dapat menggunakan Aspose.Slides dalam sebuah loop untuk mengonversi banyak file PPT ke PPTX secara programatis, menjadikannya cocok untuk skenario konversi batch.

### Apakah konten dan pemformatan akan dipertahankan setelah konversi?

Aspose.Slides mempertahankan tingkat kesetiaan tinggi dalam mengonversi presentasi. Tata letak slide, animasi, bentuk, diagram, dan elemen desain lainnya tetap terjaga selama konversi PPT ke PPTX.

### Apakah saya dapat mengonversi format lain seperti PDF atau HTML dari file PPT?

Ya, Aspose.Slides mendukung konversi file PPT ke [beberapa format](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/), termasuk PDF, XPS, HTML, ODP, dan format gambar seperti PNG dan JPEG.

### Apakah memungkinkan mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?

Ya, Aspose.Slides adalah API mandiri dan tidak memerlukan Microsoft PowerPoint atau perangkat lunak pihak ketiga apa pun untuk melakukan konversi.

### Apakah ada alat online tersedia untuk konversi PPT ke PPTX?

Ya, Anda dapat menggunakan [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx) aplikasi web gratis untuk melakukan konversi langsung di peramban Anda tanpa menulis kode apa pun.