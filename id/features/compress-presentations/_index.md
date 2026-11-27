---
title: Kompres presentasi
description: Kurangi ukuran presentasi dengan mengompres gambar dan menghapus konten yang tidak terpakai.
type: docs
url: /id/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Ikhtisar**

Kompres gambar, hapus area gambar yang dipotong ketika tidak lagi diperlukan, dan pilih pengaturan kompresi presentasi sebelum menyimpan. Ini berguna untuk deck dengan foto besar atau media yang berulang. Jumlah yang dihemat tergantung pada konten dan pengaturan yang Anda pilih.

## **Contoh Penggunaan**

Contoh C# ini memuat `input.pptx`, mengompres presentasi, dan menyimpannya sebagai `compressed.pptx`.

Gunakan Aspose.Slides untuk .NET 26.11 atau yang lebih baru. Untuk penyiapan, lihat [Instal Aspose.Slides untuk .NET](/slides/id/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Render gambar dengan skala identik sebelum dan sesudah kompresi, diikuti oleh batang ukuran file PPTX yang diukur dan dimensi gambar yang disimpan.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Diukur pada satu fixture grid‑detail sintetis: 584,030 → 128,323 byte. Kedua render menggunakan skala yang sama dan bingkai 252 × 336 poin. Kompresi menghapus margin yang dipotong dan mengurangi gambar yang disimpan menjadi 525 × 700 piksel; penghematan ukuran tergantung pada input.*
<!-- visual-explanation:compress-presentations:end -->

## **FAQ**

### **Apakah ini saklar optimasi satu berkas keseluruhan?**

Aspose.Slides untuk .NET 26.11 menambahkan [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), yang menggabungkan penghapusan layout/master yang tidak terpakai, subset font yang disematkan, dan kompresi gambar 150‑DPI. Ini secara permanen menghapus area gambar yang dipotong. Untuk pemrosesan hanya gambar, gunakan [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); untuk kontrol lebih halus, lihat [contoh kompresi gambar individual](/slides/id/net/examples/optimization-batch/compression/). Sejak versi 26.11, panggilan **whole-presentation** yang sama juga tersedia di Java, Node.js via Java, Python via .NET, dan C++. Contoh dan tautan pada halaman ini ditujukan untuk .NET.

### **Apakah kompresi gambar mengubah teks atau diagram yang dapat diedit?**

Kompresi gambar menargetkan data gambar, bukan teks yang dapat diedit atau data diagram. Tinjau gambar karena mengubah ukuran atau mengompresi ulang dapat mengurangi detailnya.

### **Bagaimana saya harus memilih resolusi untuk gambar presentasi?**

Pilih target berdasarkan ukuran gambar yang ditampilkan dan penggunaan layar atau cetak yang diinginkan. Pertahankan resolusi lebih tinggi untuk tampilan besar, pencetakan, dan diagram detail, serta bandingkan output yang di‑render sebelum membuang yang asli.

## **Panduan**

- [Kompres Seluruh Presentasi di .NET](/slides/id/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimalkan Manajemen Gambar dalam Presentasi di .NET](/slides/id/net/image/)

Fitur terkait: [Hapus master, layout, dan media yang tidak terpakai](/slides/id/features/remove-unused-content/).

## Contoh .NET yang Dapat Dijalankan

- [Kurangi Ukuran Presentasi](/slides/id/net/examples/optimization-batch/compression/)