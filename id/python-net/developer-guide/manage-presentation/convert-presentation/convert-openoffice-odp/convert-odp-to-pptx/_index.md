---
title: Mengonversi ODP ke PPTX di Python
linktitle: ODP ke PPTX
type: docs
weight: 10
url: /id/python-net/convert-odp-to-pptx/
keywords:
- konversi OpenDocument
- konversi ODP
- OpenDocument ke PPTX
- ODP ke PPTX
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Mengonversi ODP ke PPTX dengan Aspose.Slides untuk Python via .NET. Contoh kode bersih, tips batch, dan hasil berkualitas tinggi—tanpa memerlukan PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi ODP ke format PPTX menggunakan Aspose.Slides.

## **Ekspor ODP ke PPTX**

Aspose.Slides untuk Python via .NET menyediakan kelas Presentation yang mewakili file presentasi. Kelas [**Presentation**](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) kini juga dapat mengakses ODP melalui konstruktor Presentation saat objek dibuat. Contoh berikut menunjukkan cara mengonversi Presentasi ODP menjadi Presentasi PPTX.

```py
# Impor Aspose.Slides untuk Python via .NET modul
import aspose.slides as slides

# Buka file ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Menyimpan presentasi ODP ke format PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Contoh Langsung**

Anda dapat mengunjungi aplikasi web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/id/conversion/) yang dibangun dengan **Aspose.Slides API**. Aplikasi ini menunjukkan bagaimana konversi ODP ke PPTX dapat diimplementasikan dengan Aspose.Slides API.

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint atau LibreOffice untuk mengonversi ODP ke PPTX?**

Tidak. Aspose.Slides dapat beroperasi secara mandiri dan tidak memerlukan aplikasi pihak ketiga untuk membaca atau menulis ODP/PPTX.

**Apakah master slide, tata letak, dan tema dipertahankan selama konversi?**

Ya. Perpustakaan ini menggunakan model objek presentasi lengkap dan mempertahankan struktur, termasuk master slide dan tata letak, sehingga desain tetap benar setelah konversi.

**Apakah saya dapat mengonversi file ODP yang dilindungi kata sandi?**

Ya. Aspose.Slides mendukung deteksi perlindungan, membuka dan bekerja dengan [presentasi yang dilindungi](/slides/id/python-net/password-protected-presentation/) (termasuk ODP) ketika Anda memberikan kata sandi, serta mengonfigurasi enkripsi dan akses ke properti dokumen.

**Apakah Aspose.Slides cocok untuk layanan konversi berbasis cloud atau REST?**

Ya. Anda dapat menggunakan perpustakaan lokal di backend Anda sendiri atau [Aspose.Slides Cloud](https://products.aspose.cloud/slides/id/family/) (REST API); kedua opsi mendukung konversi ODP → PPTX.