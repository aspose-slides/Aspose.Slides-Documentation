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
description: "Konversi presentasi PPT lama ke PPTX modern dengan cepat menggunakan Java dan Aspose.Slides — tutorial jelas, contoh kode gratis, tanpa ketergantungan Microsoft Office."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi Presentasi PowerPoint berformat PPT ke format PPTX menggunakan Java dan aplikasi konversi PPT ke PPTX online. Topik berikut dibahas.

- Mengonversi PPT ke PPTX dengan Java

## **Mengonversi PPT ke PPTX dengan Java**

Untuk contoh kode Java yang mengonversi PPT ke PPTX, lihat bagian di bawah ini yaitu [Convert PPT to PPTX](#convert-ppt-to-pptx). Kode ini cukup memuat file PPT dan menyimpannya dalam format PPTX. Dengan menentukan format penyimpanan yang berbeda, Anda juga dapat menyimpan file PPT ke banyak format lain seperti PDF, XPS, ODP, HTML, dll. seperti yang dibahas dalam artikel-artikel berikut.

- [Convert PPT to PDF in Java](/slides/id/java/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS in Java](/slides/id/java/convert-powerpoint-to-xps/)
- [Convert PPT to HTML in Java](/slides/id/java/convert-powerpoint-to-html/)
- [Convert PPT to ODP in Java](/slides/id/java/save-presentation/)
- [Convert PPT to PNG in Java](/slides/id/java/convert-powerpoint-to-png/)

## **Tentang Konversi PPT ke PPTX**
Konversi format PPT lama ke PPTX dengan Aspose.Slides API. Jika Anda perlu mengonversi ribuan presentasi PPT ke format PPTX, solusi terbaik adalah melakukannya secara programatik. Dengan Aspose.Slides API hal ini dapat dilakukan hanya dengan beberapa baris kode. API mendukung kompatibilitas penuh untuk mengonversi presentasi PPT ke PPTX dan memungkinkan untuk:

- Mengonversi struktur rumit master, tata letak, dan slide.
- Mengonversi presentasi dengan bagan.
- Mengonversi presentasi dengan grup bentuk, auto‑bentuk (seperti persegi panjang dan elips), bentuk dengan geometri khusus.
- Mengonversi presentasi dengan tekstur dan gaya isi gambar untuk auto‑bentuk.
- Mengonversi presentasi dengan placeholder, bingkai teks, dan penahan teks.

{{% alert color="primary" %}} 

Lihat [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/id/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/id/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/id/conversion/ppt-to-pptx)

Aplikasi ini dibangun berdasarkan [**Aspose.Slides API**](https://products.aspose.com/slides/id/java/), sehingga Anda dapat melihat contoh langsung kemampuan konversi dasar PPT ke PPTX. Aspose.Slides Conversion adalah aplikasi web, yang memungkinkan Anda menyeret file presentasi berformat PPT dan mengunduhnya setelah dikonversi ke PPTX.

Temukan contoh live lainnya dari [**Aspose.Slides Conversion**](https://products.aspose.app/slides/id/conversion/) .

{{% /alert %}} 

## **Mengonversi PPT ke PPTX**
Aspose.Slides for Java kini memudahkan pengembang mengakses PPT menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan mengonversinya ke format [PPTX](https://docs.fileformat.com/presentation/pptx/) yang sesuai. Saat ini, ia mendukung konversi parsial dari [PPT](https://docs.fileformat.com/presentation/ppt/) ke PPTX. Untuk detail lebih lanjut tentang fitur yang didukung dan tidak didukung dalam konversi PPT ke PPTX, silakan lihat dokumentasi ini [link](/slides/id/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java menawarkan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) yang merepresentasikan file presentasi **PPTX**. Kelas Presentation kini juga dapat mengakses **PPT** melalui Presentation saat objek diinstansiasi. Contoh berikut menunjukkan cara mengonversi presentasi PPT menjadi Presentasi PPTX.

```java
// Instansiasi objek Presentation yang mewakili file PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
    // Menyimpan presentasi PPTX ke format PPTX
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

**Apa perbedaan antara format PPT dan PPTX?**

PPT adalah format file biner lama yang digunakan oleh Microsoft PowerPoint, sedangkan PPTX adalah format berbasis XML yang lebih baru diperkenalkan pada Microsoft Office 2007. File PPTX menawarkan kinerja lebih baik, ukuran file yang lebih kecil, dan pemulihan data yang lebih baik.

**Apakah Aspose.Slides mendukung konversi batch banyak file PPT ke PPTX?**

Ya, Anda dapat menggunakan Aspose.Slides dalam loop untuk mengonversi banyak file PPT ke PPTX secara programatik, sehingga cocok untuk skenario konversi batch.

**Apakah konten dan pemformatan akan tetap terjaga setelah konversi?**

Aspose.Slides mempertahankan kesetiaan tinggi dalam mengonversi presentasi. Tata letak slide, animasi, bentuk, bagan, dan elemen desain lainnya dipertahankan selama konversi PPT ke PPTX.

**Bisakah saya mengonversi format lain seperti PDF atau HTML dari file PPT?**

Ya, Aspose.Slides mendukung konversi file PPT ke [multiple formats](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/), termasuk PDF, XPS, HTML, ODP, dan format gambar seperti PNG serta JPEG.

**Apakah mungkin mengonversi PPT ke PPTX tanpa menginstal Microsoft PowerPoint?**

Ya, Aspose.Slides adalah API mandiri dan tidak memerlukan Microsoft PowerPoint atau perangkat lunak pihak ketiga lainnya untuk melakukan konversi.

**Apakah ada alat online untuk konversi PPT ke PPTX?**

Ya, Anda dapat menggunakan aplikasi web gratis [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx) untuk melakukan konversi langsung di peramban tanpa menulis kode apa pun.