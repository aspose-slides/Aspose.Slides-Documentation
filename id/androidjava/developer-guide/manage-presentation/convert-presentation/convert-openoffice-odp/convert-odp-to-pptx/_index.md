---
title: Konversi ODP ke PPTX di Android
linktitle: ODP ke PPTX
type: docs
weight: 10
url: /id/androidjava/convert-odp-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Konversi ODP ke PPTX dengan Aspose.Slides untuk Android. Contoh kode Java yang bersih, tips pemrosesan batch, dan hasil berkualitas tinggi—tanpa memerlukan PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi ODP ke format PPTX menggunakan Aspose.Slides.

## **Konversi ODP ke Presentasi PPTX/PPT**
Aspose.Slides untuk Android via Java menyediakan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang merepresentasikan file presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) kini juga dapat mengakses ODP melalui konstruktor [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) saat objek diinstansiasi. Contoh berikut menunjukkan cara mengonversi Presentasi ODP menjadi Presentasi PPTX.

```java
// Buka file ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Menyimpan presentasi ODP ke format PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Contoh Langsung**
Anda dapat mengunjungi aplikasi web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/id/conversion/) yang dibangun dengan **Aspose.Slides API.** Aplikasi ini menunjukkan bagaimana konversi ODP ke PPTX dapat diimplementasikan dengan Aspose.Slides API.

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint atau LibreOffice untuk mengonversi ODP ke PPTX?**

Tidak. Aspose.Slides dapat berjalan secara mandiri dan tidak memerlukan aplikasi pihak ketiga untuk membaca atau menulis ODP/PPTX.

**Apakah master slide, tata letak, dan tema tetap terjaga selama konversi?**

Ya. Perpustakaan ini menggunakan model objek presentasi penuh dan mempertahankan struktur, termasuk master slide dan tata letak, sehingga desain tetap benar setelah konversi.

**Apakah saya dapat mengonversi file ODP yang dilindungi kata sandi?**

Ya. Aspose.Slides mendukung deteksi perlindungan, membuka dan bekerja dengan [protected presentations](/slides/id/androidjava/password-protected-presentation/) (termasuk ODP) ketika Anda memberikan kata sandi, serta mengonfigurasi enkripsi dan akses ke properti dokumen.

**Apakah Aspose.Slides cocok untuk layanan konversi berbasis cloud atau REST?**

Ya. Anda dapat menggunakan perpustakaan lokal di backend Anda sendiri atau [Aspose.Slides Cloud](https://products.aspose.cloud/slides/id/family/) (REST API); kedua opsi mendukung konversi ODP → PPTX.