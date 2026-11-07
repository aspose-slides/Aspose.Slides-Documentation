---
title: Operasi Presentasi Low-Code di .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /id/net/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- gabungkan presentasi
- iterasi slide
- iterasi shape
- iterasi teks
- kumpulkan shape
- kompres presentasi
- hapus slide master yang tidak terpakai
- hapus slide tata letak yang tidak terpakai
- kompres font tertanam
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides di .NET untuk mengonversi dan menggabungkan presentasi, iterasi konten, mengumpulkan shape, dan mengurangi ukuran presentasi."
---
## **Ringkasan**

Namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) menyediakan kelas pembantu statis untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan ke dalam metode terfokus, sehingga Anda dapat mengonversi atau menggabungkan file, memproses elemen presentasi, mengumpulkan shape, dan menghapus konten yang tidak terpakai dengan lebih sedikit kode.

Pembantu low-code paling berguna ketika operasi berlaku untuk seluruh file atau presentasi dan alur kerja default sesuai dengan kebutuhan Anda. Gunakan [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) secara lengkap ketika Anda memerlukan kontrol detail atas slide individual, master, tata letak, shape, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Pembantu | Gunakan untuk |
| --- | --- |
| [Konversi](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Mengonversi presentasi ke format lain dengan pemanggilan file-ke-file langsung. |
| [Penggabungan](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Menggabungkan file presentasi lengkap dengan format yang sama. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Menjalankan aksi untuk setiap slide, shape, paragraf, atau bagian teks. |
| [Koleksi](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Mengambil shape dari seluruh presentasi untuk pemrosesan atau analisis berulang. |
| [Kompres](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Menghapus master/tata letak yang tidak terpakai, mengurangi data font tertanam, dan mengompres gambar. |

## **Konversi Presentasi**

Gunakan [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) ketika ekstensi file output cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari jalur output, dan menuliskan hasilnya.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Kelas [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) juga menyediakan metode khusus untuk output PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek lengkap ketika Anda perlu memeriksa atau memodifikasi presentasi sebelum ekspor atau mengonfigurasi opsi ekspor yang tidak disediakan oleh pembantu yang dipilih. Lihat [Konversi Presentasi](/slides/id/net/convert-presentation/) untuk alur kerja dan opsi spesifik format.

## **Gabungkan Presentasi**

Gunakan [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) untuk menggabungkan file presentasi lengkap dengan satu panggilan. Presentasi masukan harus memiliki format file yang sama.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Pembantu ini cocok ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan ulang secara individual. Gunakan model objek lengkap ketika Anda perlu menggabungkan slide terpilih, menerapkan master atau tata letak tujuan, mempertahankan bagian secara eksplisit, atau menyelaraskan ukuran slide yang berbeda. Lihat [Gabungkan Presentasi](/slides/id/net/merge-presentation/) untuk skenario tersebut.

## **Iterasi Elemen Presentasi**

Kelas [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) memanggil kembali (callback) untuk setiap tipe elemen presentasi yang diminta. Ini menghindari loop koleksi bersarang dan memudahkan inspeksi atau perubahan format pada seluruh presentasi.

Contoh berikut menggunakan [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), dan [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) untuk memeriksa elemen‑elemen yang bersangkutan:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Secara default, penelusuran shape dan teks pada seluruh presentasi mencakup slide normal, master, dan tata letak. Overload dengan parameter `includeNotes` juga dapat memproses slide catatan. Gunakan loop koleksi langsung ketika urutan penelusuran, keluar dini, penyaringan sebelum pemanggilan kembali, atau kontrol induk‑anak yang detail menjadi penting.

## **Koleksi Shape**

Gunakan [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) ketika Anda memerlukan kumpulan semua shape dalam sebuah presentasi alih‑alih callback untuk setiap shape. Ini berguna ketika set yang sama akan disaring, dihitung, atau diproses lebih dari satu kali.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Gunakan [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) sebagai gantinya ketika setiap shape dapat ditangani segera dan Anda tidak perlu menyimpan hasil koleksi.

## **Kompres Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font tertanam:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) menghapus slide tata letak yang tidak direferensikan oleh slide normal mana pun.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) menghapus slide master yang tidak lagi digunakan.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) menghapus karakter yang tidak dipakai dari font tertanam.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Hapus tata letak yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak direferensikan setelah pembersihan tata letak juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin membutuhkan master, tata letak, atau data font tertanam lengkap di kemudian hari. Untuk detail lebih lanjut, lihat [Slide Master](/slides/id/net/slide-master/) dan [Embedded Font](/slides/id/net/embedded-font/).

### **Kompres Seluruh Presentasi**

Aspose.Slides untuk .NET 26.11 menambahkan [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Ini menggabungkan penghapusan slide tata letak/master yang tidak terpakai, penyaringan font tertanam ke karakter yang digunakan, dan kompresi gambar pada 150 DPI. Gunakan operasi individual di atas ketika Anda perlu mengendalikan perubahan mana yang diterapkan.

Instal [Aspose.Slides for .NET](/slides/id/net/installation/) 26.11 atau yang lebih baru dan sediakan `input.pptx`. Simpan ke file terpisah: tata letak yang dihapus, karakter font, dan piksel gambar yang dipangkas mungkin diperlukan untuk penyuntingan nanti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Kompres Gambar pada Resolusi Pilihan**

Gunakan [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) untuk memproses gambar yang memenuhi syarat tanpa juga menghapus tata letak atau menyaring font. Contoh ini menggunakan 96 DPI; pilih nilai [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) lain untuk kebutuhan output Anda.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Kedua pembantu menggunakan ruang lingkup pemrosesan gambar berikut:

| Konten | Penanganan |
| --- | --- |
| Gambar raster dan isian gambar shape pada slide normal, master, dan tata letak, termasuk shape yang dikelompokkan | Memenuhi syarat untuk kompresi. |
| Gambar yang sudah berada pada atau di bawah resolusi yang diminta | Tidak diperbesar. Area yang dipangkas masih dapat dihapus. |
| Area gambar yang dipangkas | Piksel tersembunyi dihapus secara permanen dan offset panggasan direset. |
| Latar belakang slide dan isian sel tabel | Tidak diproses oleh pembantu ini. |
| Internal Chart/SmartArt, GIF, dan format vektor seperti SVG, EMF, dan WMF | Di luar ruang lingkup kompresi gambar yang didokumentasikan. |

Pada 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) menghindari downsampling berbasis resolusi pada gambar yang tidak dipangkas, tetapi **tidak mempertahankan piksel yang dipangkas**. Gambar yang dipangkas masih dapat ditulis ulang dengan area tersembunyi dihapus. Tidak ada pembantu yang menawarkan opsi preserve‑crop. Untuk kontrol individual, lihat [contoh kompresi per gambar](/slides/id/net/examples/optimization-batch/compression/).

Bandingkan tampilan dan ukuran file hasil sebelum menggantikan yang asli. Penghematan tergantung pada gambar sumber, ukuran tampilan, dan konten yang tidak terpakai; kompresi tidak menjamin file yang lebih kecil. Lihat [Embedded Fonts](/slides/id/net/embedded-font/) untuk implikasi penyaringan font.

## **Tanya Jawab**

**Kapan saya harus menggunakan API low-code alih‑alih model objek lengkap?**

Gunakan pembantu low-code ketika operasi standar berlaku untuk seluruh file atau presentasi dan tidak memerlukan kontrol detail atas elemen individual. Gunakan model objek lengkap ketika Anda perlu memilih slide tertentu, mengendalikan hubungan master dan tata letak, memeriksa keadaan menengah, atau mengonfigurasi perilaku yang tidak disediakan pembantu.

**Apakah Merger dapat menggabungkan presentasi dengan format file yang berbeda?**

Tidak. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) memerlukan presentasi masukan dalam format yang sama. Konversi file masukan ke format umum terlebih dahulu, misalnya dengan [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), lalu gabungkan file yang telah dikonversi.

**Apakah ForEach memproses slide master, layout, dan catatan?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) mengiterasi slide presentasi normal. [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), dan [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) mencakup slide normal, master, dan tata letak secara default. Gunakan overload dengan `includeNotes` disetel ke `true` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach.Shape dan Collect.Shapes?**

Gunakan [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) untuk memproses setiap shape segera melalui callback. Gunakan [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) ketika Anda memerlukan hasil enumerable yang dapat disimpan, disaring, dihitung, atau diiterasi berkali‑kali.

**Apakah Compress selalu membuat file presentasi lebih kecil?**

Tidak selalu. Penghematan tergantung pada tata letak/master yang tidak terpakai, font tertanam dengan karakter yang tidak dipakai, dan gambar yang mendapat manfaat dari kompresi. Pembantu [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) mungkin tidak mengubah ukuran atau bahkan menghasilkan file yang lebih besar untuk beberapa input. Bandingkan ukuran serta kualitas render, dan simpan versi asli.

**Apakah perubahan yang dibuat oleh ForEach atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) atau menjalankan [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), panggil [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) untuk menuliskan hasilnya.

## **Artikel Terkait**

- [Konversi Presentasi](/slides/id/net/convert-presentation/)
- [Gabungkan Presentasi](/slides/id/net/merge-presentation/)
- [Slide Master](/slides/id/net/slide-master/)
- [Manage Text Box](/slides/id/net/manage-textbox/)
- [Embedded Font](/slides/id/net/embedded-font/)