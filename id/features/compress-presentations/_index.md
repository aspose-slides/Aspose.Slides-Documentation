---
title: Kompres presentasi
description: Kurangi ukuran presentasi dengan mengompres gambar dan menghapus konten yang tidak terpakai.
type: docs
url: /id/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operasi
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Gambaran Umum**

Kompres gambar, hapus area gambar yang dipotong ketika tidak lagi diperlukan, dan pilih pengaturan kompresi presentasi sebelum menyimpan. Ini berguna untuk deck dengan foto berukuran besar atau media berulang. Jumlah yang dihemat tergantung pada konten dan pengaturan yang Anda pilih.

## **Contoh Penggunaan**

Contoh C# ini memuat `input.pptx`, mengompres presentasi, dan menyimpannya sebagai `compressed.pptx`.

Gunakan Aspose.Slides for .NET 26.11 atau yang lebih baru. Untuk penyiapan, lihat [Pasang Aspose.Slides untuk .NET](/slides/id/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Apakah ini saklar optimalisasi satu berkas secara keseluruhan?**

Aspose.Slides for .NET 26.11 menambahkan [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), yang menggabungkan penghapusan layout/master yang tidak terpakai, subsetting font tersemat, dan kompresi gambar 150 DPI. Ini secara permanen menghapus area gambar yang dipotong. Untuk pemrosesan hanya gambar, gunakan [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); untuk kontrol lebih detail, lihat [contoh kompresi gambar individual](/slides/id/net/examples/optimization-batch/compression/). Pembantu baru ini spesifik untuk versi .NET yang disebutkan; periksa panduan yang sesuai untuk SDK lainnya.

### **Apakah kompresi gambar mengubah teks yang dapat diedit atau diagram?**

Kompresi gambar menargetkan data gambar, bukan teks yang dapat diedit atau data diagram. Tinjau gambar karena mengubah ukuran atau mengompres kembali dapat mengurangi detailnya.

### **Bagaimana cara memilih resolusi untuk gambar presentasi?**

Pilih target berdasarkan ukuran gambar yang ditampilkan dan penggunaan layar atau cetak yang diinginkan. Pertahankan resolusi lebih tinggi untuk tampilan besar, pencetakan, dan diagram detail, serta bandingkan hasil render sebelum membuang yang asli.

## **Panduan**

- [Kompres Seluruh Presentasi di .NET](/slides/id/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimalkan Manajemen Gambar dalam Presentasi di .NET](/slides/id/net/image/)

Fitur terkait: [Hapus master, tata letak, dan media yang tidak digunakan](/slides/id/features/remove-unused-content/).

## Contoh .NET yang Dapat Dijalan

- [Kurangi Ukuran Presentasi](/slides/id/net/examples/optimization-batch/compression/)