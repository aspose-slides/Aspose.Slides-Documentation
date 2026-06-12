---
title: Konversi ODP ke PPTX dalam JavaScript
linktitle: ODP ke PPTX
type: docs
weight: 10
url: /id/nodejs-java/convert-odp-to-pptx/
keywords:
- konversi OpenDocument
- konversi presentasi
- konversi slide
- konversi ODP
- OpenDocument ke PPTX
- ODP ke PPTX
- simpan ODP sebagai PPTX
- ekspor ODP ke PPTX
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi ODP ke PPTX dengan Aspose.Slides untuk Node.js. Contoh kode JavaScript yang bersih, tips batch, dan hasil berkualitas tinggi—tanpa memerlukan PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi ODP ke format PPTX menggunakan Aspose.Slides.

## **Konversi ODP ke Presentasi PPTX/PPT**
Aspose.Slides untuk Node.js via Java menawarkan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang mewakili file presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) kini juga dapat mengakses ODP melalui konstruktor [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) saat objek diinstansiasi. Contoh berikut menunjukkan cara mengonversi Presentasi ODP menjadi Presentasi PPTX.

```javascript
// Buka file ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Menyimpan presentasi ODP ke format PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Contoh Langsung**
Anda dapat mengunjungi [**Aspose.Slides Conversion**](https://products.aspose.app/slides/id/conversion/) aplikasi web yang dibangun dengan **Aspose.Slides API**. Aplikasi ini menunjukkan bagaimana konversi ODP ke PPTX dapat diimplementasikan dengan Aspose.Slides API.

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint atau LibreOffice untuk mengonversi ODP ke PPTX?**

Tidak. Aspose.Slides berfungsi secara mandiri dan tidak memerlukan aplikasi pihak ketiga untuk membaca atau menulis ODP/PPTX.

**Apakah master slide, tata letak, dan tema dipertahankan selama konversi?**

Ya. Perpustakaan ini menggunakan model objek presentasi lengkap dan mempertahankan struktur, termasuk master slide dan tata letak, sehingga desain tetap benar setelah konversi.

**Apakah saya dapat mengonversi file ODP yang dilindungi kata sandi?**

Ya. Aspose.Slides mendukung deteksi perlindungan, membuka dan bekerja dengan [protected presentations](/slides/id/nodejs-java/password-protected-presentation/) (termasuk ODP) ketika Anda memberikan kata sandi, serta mengonfigurasi enkripsi dan mengakses properti dokumen.

**Apakah Aspose.Slides cocok untuk layanan konversi berbasis cloud atau REST?**

Ya. Anda dapat menggunakan perpustakaan lokal di backend Anda sendiri atau [Aspose.Slides Cloud](https://products.aspose.cloud/slides/id/family/) (REST API); kedua opsi mendukung konversi ODP → PPTX.