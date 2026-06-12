---
title: Mengonversi ODP ke PPTX di Java
linktitle: ODP ke PPTX
type: docs
weight: 10
url: /id/java/convert-odp-to-pptx/
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
- Java
- Aspose.Slides
description: "Konversi ODP ke PPTX dengan Aspose.Slides untuk Java. Contoh kode Java yang bersih, tips batch, dan hasil berkualitas tinggi—tanpa PowerPoint diperlukan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi ODP ke format PPTX menggunakan Aspose.Slides.

## **Konversi ODP ke Presentasi PPTX/PPT**
Aspose.Slides untuk Java menyediakan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang mewakili file presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) kini juga dapat mengakses ODP melalui konstruktor [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) saat objek dibuat. Contoh berikut menunjukkan cara mengonversi Presentasi ODP menjadi Presentasi PPTX.

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
Anda dapat mengunjungi [**Aspose.Slides Conversion**](https://products.aspose.app/slides/id/conversion/) aplikasi web, yang dibangun dengan **Aspose.Slides API.** Aplikasi ini menunjukkan bagaimana konversi ODP ke PPTX dapat diimplementasikan dengan Aspose.Slides API.

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint atau LibreOffice untuk mengonversi ODP ke PPTX?**

Tidak. Aspose.Slides beroperasi secara mandiri dan tidak memerlukan aplikasi pihak ketiga untuk membaca atau menulis ODP/PPTX.

**Apakah slide master, tata letak, dan tema dipertahankan selama konversi?**

Ya. Perpustakaan ini menggunakan model objek presentasi lengkap dan mempertahankan struktur, termasuk slide master dan tata letak, sehingga desain tetap benar setelah konversi.

**Bisakah saya mengonversi file ODP yang dilindungi kata sandi?**

Ya. Aspose.Slides mendukung deteksi perlindungan, membuka dan bekerja dengan [protected presentations](/slides/id/java/password-protected-presentation/) (termasuk ODP) ketika Anda memberikan kata sandi, serta mengonfigurasi enkripsi dan akses ke properti dokumen.

**Apakah Aspose.Slides cocok untuk layanan konversi berbasis cloud atau REST?**

Ya. Anda dapat menggunakan perpustakaan lokal di backend Anda atau [Aspose.Slides Cloud](https://products.aspose.cloud/slides/id/family/) (REST API); kedua opsi mendukung konversi ODP → PPTX.