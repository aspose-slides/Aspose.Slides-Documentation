---
title: Evaluasi Aspose.Slides
type: docs
weight: 120
url: /id/net/evaluate-aspose-slides/
keywords:
- evaluasi Aspose.Slides
- evaluasi Aspose.Slides
- versi evaluasi
- fungsi penuh
- watermark evaluasi
- pembelian Aspose.Slides
- batasan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Evaluasi Aspose.Slides untuk .NET dan jelajahi fitur API untuk presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) — mulai percobaan gratis Anda."
---
## **Aspose.Slides Evaluasi**

Anda dapat dengan mudah mengunduh Aspose.Slides untuk evaluasi. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi cukup menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi. 

Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsionalitas penuh produk, tetapi menambahkan watermark evaluasi di bagian atas dokumen saat dibuka dan disimpan. Anda juga dibatasi satu slide saat mengekstrak teks dari slide presentasi.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 
Jika Anda ingin menguji Aspose.Slides tanpa batasan versi evaluasi, Anda dapat meminta **Lisensi Sementara 30 Hari**. Silakan lihat [Cara mendapatkan Lisensi Sementara?](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}}

## **Instal Paket Evaluasi**

```bash
dotnet add package Aspose.Slides.NET
```

## **Terapkan Lisensi**

Berikut adalah "beberapa baris kode" yang mengubah paket evaluasi menjadi berlisensi. Terapkan lisensi satu kali saat aplikasi mulai, sebelum objek `Presentation` apa pun dibuat — presentasi yang dibangun sebelumnya tetap menampilkan watermark evaluasi.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` juga menerima `Stream`, yang merupakan opsi yang lebih baik ketika lisensi dikirim sebagai sumber daya tertanam daripada file di disk. Jika jalur salah atau file telah kedaluwarsa, panggilan akan melempar pengecualian, sehingga kegagalan muncul segera saat start-up alih‑alih secara diam‑diam kembali ke mode evaluasi.

Setelah lisensi diterapkan, watermark menghilang dan batasan ekstraksi teks satu slide diangkat.

## **FAQ**

### Bisakah saya menguji beberapa presentasi secara paralel di thread berbeda dalam mode evaluasi?

Ya. Anda dapat memproses dokumen yang berbeda secara paralel; Anda tidak boleh membagikan objek presentasi yang sama [across threads](/slides/id/net/multithreading/). Mode evaluasi tidak mempengaruhi hal ini.

### Apakah saya perlu menginstal Microsoft PowerPoint untuk mengevaluasi perpustakaan ini di server atau di CI?

Tidak. Aspose.Slides adalah mesin mandiri dan tidak memerlukan PowerPoint terinstal baik untuk evaluasi maupun produksi.

### Bisakah saya sepenuhnya menguji konversi PPT/PPTX ke PDF dan gambar dalam mode evaluasi?

Ya. [konverter](/slides/id/net/convert-presentation/) berfungsi; output akan mencakup watermark.

### Bisakah saya menggunakan lisensi sementara untuk pengujian beban tanpa watermark?

Ya. Lisensi sementara selama 30 hari menghapus batasan mode evaluasi dan memungkinkan pengujian tanpa watermark.