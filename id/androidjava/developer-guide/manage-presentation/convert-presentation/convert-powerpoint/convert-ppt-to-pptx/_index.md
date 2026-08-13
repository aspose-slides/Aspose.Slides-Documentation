---
title: Mengonversi PPT ke PPTX di Android
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Konversi presentasi PPT lama ke PPTX modern dengan cepat menggunakan Java dan Aspose.Slides untuk Android — tutorial yang jelas, contoh kode gratis, tanpa ketergantungan Microsoft Office."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint dalam format PPT ke format PPTX menggunakan Java dan aplikasi konversi PPT ke PPTX daring. Topik berikut dibahas.

- Konversi PPT ke PPTX dengan Java

## **Konversi PPT ke PPTX di Android**

Untuk contoh kode Java yang mengonversi PPT ke PPTX, lihat bagian di bawah ini yaitu [Convert PPT to PPTX](#convert-ppt-to-pptx). Kode tersebut hanya memuat file PPT dan menyimpannya dalam format PPTX. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPT ke banyak format lain seperti PDF, XPS, ODP, HTML, dll. seperti dibahas dalam artikel-artikel berikut.

- [Convert PPT to PDF on Android](/slides/id/androidjava/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS on Android](/slides/id/androidjava/convert-powerpoint-to-xps/)
- [Convert PPT to HTML on Android](/slides/id/androidjava/convert-powerpoint-to-html/)
- [Convert PPT to ODP on Android](/slides/id/androidjava/save-presentation/)
- [Convert PPT to PNG on Android](/slides/id/androidjava/convert-powerpoint-to-png/)

## **Tentang Konversi PPT ke PPTX**
Konversi format PPT lama ke PPTX dengan Aspose.Slides API. Jika Anda perlu mengonversi ribuan presentasi PPT ke format PPTX, solusi terbaik adalah melakukannya secara programatis. Dengan Aspose.Slides API, hal ini dapat dilakukan hanya dalam beberapa baris kode. API mendukung kompatibilitas penuh untuk mengonversi presentasi PPT ke PPTX dan memungkinkan:

- Mengonversi struktur rumit master, layout, dan slide.
- Mengonversi presentasi dengan diagram.
- Mengonversi presentasi dengan grup shape, auto‑shape (seperti persegi panjang dan elips), shape dengan geometri khusus.
- Mengonversi presentasi yang memiliki tekstur dan gaya isian gambar untuk auto‑shape.
- Mengonversi presentasi dengan placeholder, bingkai teks, dan pemegang teks.

{{% alert color="info" %}} 

Lihatlah [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/id/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/id/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/id/conversion/ppt-to-pptx)

Aplikasi ini dibangun berdasarkan [**Aspose.Slides API**](https://products.aspose.com/slides/id/androidjava/), sehingga Anda dapat melihat contoh langsung kemampuan konversi dasar PPT ke PPTX. Aspose.Slides Conversion adalah aplikasi web, yang memungkinkan Anda menyeret file presentasi dalam format PPT dan mengunduhnya setelah dikonversi ke PPTX.

Temukan contoh lain yang aktif dari [**Aspose.Slides Conversion**](https://products.aspose.app/slides/id/conversion/) .

{{% /alert %}} 

## **Konversi PPT ke PPTX**
Aspose.Slides untuk Android via Java kini memudahkan pengembang mengakses PPT menggunakan instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dan mengonversinya ke format [PPTX](https://docs.fileformat.com/presentation/pptx/) yang bersesuaian. Saat ini, ia mendukung konversi parsial dari [PPT](https://docs.fileformat.com/presentation/ppt/) ke PPTX.

Aspose.Slides untuk Android via Java menyediakan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) yang mewakili file presentasi **PPTX**. Kelas Presentation kini juga dapat mengakses **PPT** melalui objek Presentation ketika diinstansiasi. Contoh berikut menunjukkan cara mengonversi presentasi PPT menjadi Presentasi PPTX.

```java
import com.aspose.slides.*;

// Instansiasi objek Presentation yang mewakili file PPT
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

Potongan kode di atas menghasilkan presentasi PPTX berikut setelah konversi

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Gambar: Presentasi PPTX yang Dihasilkan setelah Konversi**|

## **FAQ**

### Apa perbedaan antara format PPT dan PPTX?

PPT adalah format file biner lama yang digunakan oleh Microsoft PowerPoint, sedangkan PPTX adalah format berbasis XML yang lebih baru yang diperkenalkan pada Microsoft Office 2007. File PPTX menawarkan kinerja yang lebih baik, ukuran file yang lebih kecil, dan pemulihan data yang lebih baik.

### Apakah Aspose.Slides mendukung konversi batch banyak file PPT ke PPTX?

Ya, Anda dapat menggunakan Aspose.Slides dalam sebuah loop untuk mengonversi banyak file PPT ke PPTX secara programatis, sehingga cocok untuk skenario konversi batch.

### Apakah konten dan pemformatan tetap terjaga setelah konversi?

Aspose.Slides mempertahankan kesetiaan tinggi dalam mengonversi presentasi. Tata letak slide, animasi, shape, diagram, dan elemen desain lainnya dipertahankan selama konversi PPT ke PPTX.

### Bisakah saya mengonversi format lain seperti PDF atau HTML dari file PPT?

Ya, Aspose.Slides mendukung konversi file PPT ke [multiple formats](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/), termasuk PDF, XPS, HTML, ODP, dan format gambar seperti PNG serta JPEG.

### Apakah memungkinkan mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terinstal?

Ya, Aspose.Slides adalah API mandiri dan tidak memerlukan Microsoft PowerPoint atau perangkat lunak pihak ketiga lainnya untuk melakukan konversi.

### Apakah ada alat daring yang tersedia untuk konversi PPT ke PPTX?

Ya, Anda dapat menggunakan aplikasi web gratis [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx) untuk melakukan konversi langsung di peramban Anda tanpa menulis kode apa pun.