---
title: Kompres presentasi
description: Kurangi ukuran presentasi dengan kompresi gambar dan simpan pengaturan.
type: docs
url: /id/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operasi
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Gambaran Umum**

Kompres gambar, hapus area gambar yang dipotong ketika tidak lagi diperlukan, dan pilih pengaturan kompresi presentasi sebelum menyimpan. Ini berguna untuk dek dengan foto berukuran besar atau media yang berulang. Jumlah penghematan tergantung pada konten dan pengaturan yang Anda pilih.

## **Contoh Penggunaan**

Contoh C# ini menggunakan Aspose.Slides for .NET. Secara visual menghasilkan PNG gradasi berukuran 1600 × 900 piksel, menyisipkannya ke dalam bingkai gambar kecil, dan menyimpan *before.pptx*. Kemudian gambar tersebut dikompres ke resolusi target 96 DPI dan disimpan sebagai *compressed.pptx*. Bandingkan ukuran file dan pratinjau keduanya: penghematan tergantung pada gambar input dan ukuran tampilan. Untuk penyiapan, lihat [Instal Aspose.Slides for .NET](/slides/id/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **FAQ**

### **Apakah ini saklar optimasi satu file keseluruhan?**

Aspose.Slides for .NET 26.11 menambahkan [Compress.CompressPresentation](/slides/id/net/low-code-presentation-operations/#compress-the-whole-presentation), yang menggabungkan penghapusan tata letak/master yang tidak terpakai, subsetting font yang disematkan, dan kompresi gambar 150 DPI. Itu secara permanen menghapus area gambar yang dipotong. Untuk pemrosesan hanya gambar, gunakan Compress.CompressImages; untuk kontrol yang lebih halus, pertahankan alur kerja per-gambar di atas. Pembantu baru ini khusus untuk versi .NET yang disebutkan; periksa panduan yang sesuai untuk SDK lain.

### **Apakah kompresi gambar mengubah teks yang dapat diedit atau diagram?**

Kompresi gambar menargetkan data gambar, bukan teks yang dapat diedit atau data diagram. Tinjau gambar karena mengubah ukuran atau kompresi ulang dapat mengurangi detailnya.

### **Bagaimana saya harus memilih resolusi untuk gambar presentasi?**

Pilih target berdasarkan ukuran gambar yang ditampilkan dan penggunaan pada layar atau cetakan yang dimaksud. Pertahankan resolusi lebih tinggi untuk tampilan besar, pencetakan, dan diagram detail, dan bandingkan hasil render sebelum membuang yang asli.

## **Panduan**

- [Optimalkan Manajemen Gambar dalam Presentasi di .NET](/slides/id/net/image/)

Fitur terkait: [Hapus master, tata letak, dan media yang tidak terpakai](/slides/id/features/remove-unused-content/).

## Contoh .NET yang Dapat Dijalankan

- [Kurangi Ukuran Presentasi](/slides/id/net/examples/optimization-batch/compression/)