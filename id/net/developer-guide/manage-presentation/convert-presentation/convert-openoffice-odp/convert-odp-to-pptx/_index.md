---
title: Mengonversi ODP ke PPTX di .NET
linktitle: ODP ke PPTX
type: docs
weight: 10
url: /id/net/convert-odp-to-pptx/
keywords:
- mengonversi OpenDocument
- mengonversi presentasi
- mengonversi slide
- mengonversi ODP
- OpenDocument ke PPTX
- ODP ke PPTX
- menyimpan ODP sebagai PPTX
- mengekspor ODP ke PPTX
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Mengonversi ODP ke PPTX dengan Aspose.Slides untuk .NET. Contoh kode C# yang bersih, tips batch, dan hasil berkualitas tinggi—tanpa perlu PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi ODP ke format PPTX menggunakan Aspose.Slides.

## **Konversi ODP ke PPTX**

Aspose.Slides untuk .NET menawarkan kelas Presentation yang mewakili file presentasi. [**Presentation**](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) kelas ini kini juga dapat mengakses ODP melalui konstruktor Presentation saat objek dibuat. Contoh berikut menunjukkan cara mengonversi Presentasi ODP menjadi Presentasi PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Langkah: Mengonversi ODP ke PPTX dalam C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Langkah: Mengonversi ODP ke PowerPoint dalam C#</strong></a>

```c#
// Buka file ODP
 Presentation pres = new Presentation("AccessOpenDoc.odp");

// Menyimpan presentasi ODP ke format PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Contoh Langsung**

Anda dapat mengunjungi aplikasi web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/id/conversion/) yang dibangun dengan **Aspose.Slides API.** Aplikasi ini menunjukkan cara konversi ODP ke PPTX dapat diimplementasikan dengan Aspose.Slides API.

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint atau LibreOffice untuk mengonversi ODP ke PPTX?**

Tidak. Aspose.Slides berfungsi secara mandiri dan tidak memerlukan aplikasi pihak ketiga untuk membaca atau menulis ODP/PPTX.

**Apakah slide master, tata letak, dan tema dipertahankan selama konversi?**

Ya. Perpustakaan ini menggunakan model objek presentasi penuh dan mempertahankan struktur, termasuk slide master dan tata letak, sehingga desain tetap benar setelah konversi.

**Apakah saya dapat mengonversi file ODP yang dilindungi kata sandi?**

Ya. Aspose.Slides mendukung deteksi perlindungan, membuka dan bekerja dengan [protected presentations](/slides/id/net/password-protected-presentation/) (termasuk ODP) ketika Anda menyediakan kata sandi, serta mengonfigurasi enkripsi dan mengakses properti dokumen.

**Apakah Aspose.Slides cocok untuk layanan konversi berbasis cloud atau REST?**

Ya. Anda dapat menggunakan perpustakaan lokal di backend Anda sendiri atau [Aspose.Slides Cloud](https://products.aspose.cloud/slides/id/family/) (REST API); kedua opsi mendukung konversi ODP→PPTX.