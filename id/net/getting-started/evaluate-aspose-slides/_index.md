---
title: Evaluasi Aspose.Slides
type: docs
weight: 75
url: /id/net/evaluate-aspose-slides/
keywords:
- evaluasi Aspose.Slides
- evaluasi Aspose.Slides
- versi evaluasi
- fungsi penuh
- watermark evaluasi
- beli Aspose.Slides
- batasan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Evaluasi Aspose.Slides untuk .NET dan jelajahi fitur API untuk presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) — mulailah percobaan gratis Anda."
---
## **Evaluasi Aspose.Slides**

Anda dapat mengunduh Aspose.Slides untuk evaluasi. Paket evaluasi sama dengan paket yang dibeli; paket tersebut menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

Tanpa lisensi, Aspose.Slides menyediakan semua fungsionalitasnya dalam mode evaluasi, dengan dua batasan: ia menambahkan kotak teks watermark evaluasi ke setiap slide dari setiap presentasi yang disimpannya, dan teks yang dibaca kode Anda dari sebuah presentasi dipotong hingga beberapa karakter pertama, diikuti dengan pemberitahuan tentang batasan evaluasi. Teks yang ditulis kode Anda disimpan secara lengkap.

![Sebuah slide dengan watermark evaluasi](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Jika Anda ingin menguji Aspose.Slides tanpa batasan versi evaluasi, Anda dapat meminta **Lisensi Sementara 30 Hari**. Silakan merujuk ke [Cara Mendapatkan Lisensi Sementara?](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}}

## **Instal Paket Evaluasi**

```bash
dotnet add package Aspose.Slides.NET
```

Di Linux dan macOS, Anda dapat menggunakan paket Aspose.Slides.NET6.CrossPlatform sebagai gantinya; lihat [Instalasi](/slides/id/net/installation/).

## **Terapkan Lisensi**

Inilah "beberapa baris kode" yang mengubah paket evaluasi menjadi paket berlisensi. Terapkan lisensi sekali pada saat aplikasi dimulai, sebelum objek `Presentation` mana pun dibuat — sebuah presentasi yang dibuat sebelumnya tetap menyimpan watermark evaluasi.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` juga menerima `Stream`, yang merupakan opsi yang lebih baik ketika lisensi dikirim sebagai sumber daya tersemat daripada file di disk. Jika path salah atau file sudah kedaluwarsa, pemanggilan akan melempar pengecualian, sehingga kegagalan muncul segera pada saat mulai alih-alih diam-diam kembali ke mode evaluasi.

Setelah lisensi diterapkan, presentasi yang disimpan tidak lagi menampilkan watermark, dan teks dibaca secara lengkap.

## **FAQ**

### Apakah saya dapat menguji banyak presentasi secara paralel di thread yang berbeda dalam mode evaluasi?

Ya. Anda dapat memproses dokumen yang berbeda secara paralel; Anda tidak boleh berbagi objek presentasi yang sama [di antar thread](/slides/id/net/multithreading/). Mode evaluasi tidak mempengaruhi hal ini.

### Apakah saya perlu menginstal Microsoft PowerPoint untuk mengevaluasi perpustakaan ini di server atau dalam CI?

Tidak. Aspose.Slides adalah mesin mandiri dan tidak memerlukan PowerPoint terinstal baik untuk evaluasi maupun produksi.

### Apakah saya dapat menguji sepenuhnya konversi PPT/PPTX ke PDF dan gambar dalam mode evaluasi?

Ya. [Konverter](/slides/id/net/convert-presentation/) berfungsi; output akan menyertakan watermark.

### Apakah saya dapat menggunakan lisensi sementara untuk pengujian beban tanpa watermark?

Ya. Lisensi sementara selama 30 hari menghapus batasan mode evaluasi dan memungkinkan pengujian tanpa watermark.