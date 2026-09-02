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
- hapus master slide yang tidak terpakai
- hapus layout slide yang tidak terpakai
- kompres font tertanam
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides di .NET untuk mengonversi dan menggabungkan presentasi, mengiterasi konten, mengumpulkan shape, serta mengurangi ukuran presentasi."
---
## **Gambaran Umum**

Namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/) menyediakan kelas pembantu statis untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan ke dalam metode yang fokus, sehingga Anda dapat mengonversi atau menggabungkan file, memproses elemen presentasi, mengumpulkan shape, dan menghapus konten yang tidak terpakai dengan lebih sedikit kode.

Pembantu low‑code paling berguna ketika operasi diterapkan pada seluruh file atau presentasi dan alur kerja default memenuhi kebutuhan Anda. Gunakan model objek lengkap [Aspose.Slides](https://reference.aspose.com/slides/id/net/aspose.slides/) ketika Anda memerlukan kontrol yang lebih rinci atas slide individu, master, layout, shape, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Helper | Digunakan untuk |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/convert/) | Mengonversi presentasi ke format lain dengan panggilan file‑ke‑file langsung. |
| [Merger](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/merger/) | Menggabungkan file presentasi lengkap dengan format yang sama. |
| [ForEach](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/) | Menjalankan aksi untuk setiap slide, shape, paragraf, atau bagian teks. |
| [Collect](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/collect/) | Mengambil shape dari seluruh presentasi untuk pemrosesan atau analisis berulang. |
| [Compress](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/) | Menghapus master dan layout yang tidak terpakai serta mengurangi data font yang tertanam. |

## **Mengonversi Presentasi**

Gunakan [Convert.AutoByExtension](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/convert/autobyextension/) ketika ekstensi file output cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari jalur output, dan menulis hasilnya.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Kelas [Convert](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/convert/) juga menyediakan metode khusus untuk output PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek penuh ketika Anda perlu memeriksa atau memodifikasi presentasi sebelum ekspor atau mengonfigurasi opsi ekspor yang tidak disediakan oleh pembantu yang dipilih. Lihat [Convert Presentation](/net/convert-presentation/) untuk alur kerja dan opsi spesifik format.

## **Menggabungkan Presentasi**

Gunakan [Merger.Process](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/merger/process/) untuk menggabungkan file presentasi lengkap dengan satu panggilan. Presentasi masukan harus memiliki format file yang sama.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Pembantu ini tepat ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan ulang secara individual. Gunakan model objek penuh ketika Anda perlu menggabungkan slide terpilih, menerapkan master atau layout tujuan, mempertahankan seksi secara eksplisit, atau menyelaraskan ukuran slide yang berbeda. Lihat [Merge Presentations](/net/merge-presentation/) untuk skenario tersebut.

## **Iterasi Elemen Presentasi**

Kelas [ForEach](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/) memanggil callback untuk setiap tipe elemen presentasi yang diminta. Ini menghindari loop koleksi bersarang dan nyaman untuk inspeksi atau perubahan format di seluruh presentasi.

Contoh berikut menggunakan [ForEach.Slide](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/paragraph/), dan [ForEach.Portion](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/portion/) untuk memeriksa elemen yang bersangkutan:

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

Secara default, traversing shape dan teks di seluruh presentasi mencakup slide normal, master, dan layout. Overload dengan parameter `includeNotes` juga dapat memproses slide catatan. Gunakan loop koleksi langsung ketika urutan traversing, keluar lebih awal, penyaringan sebelum pemanggilan callback, atau kontrol detail induk‑anak penting.

## **Kumpulkan Shape**

Gunakan [Collect.Shapes](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/collect/shapes/) ketika Anda memerlukan koleksi semua shape dalam presentasi alih‑alih callback untuk setiap shape. Ini berguna ketika set yang sama akan disaring, dihitung, atau diproses lebih dari sekali.

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

Gunakan [ForEach.Shape](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/shape/) sebagai gantinya ketika setiap shape dapat diproses langsung dan Anda tidak perlu menyimpan hasil yang dikumpulkan.

## **Kompres Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font yang tertanam:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) menghapus slide layout yang tidak direferensikan oleh slide normal apa pun.  
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) menghapus slide master yang tidak lagi digunakan.  
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/compressembeddedfonts/) menghapus karakter yang tidak terpakai dari font yang tertanam.

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

Hapus layout yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak direferensikan setelah pembersihan layout juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin membutuhkan master, layout, atau data font yang tertanam lengkap di kemudian hari. Untuk detail lebih lanjut, lihat [Slide Master](/net/slide-master/) dan [Embedded Font](/net/embedded-font/).

## **FAQ**

**Kapan saya harus menggunakan API low‑code daripada model objek penuh?**

Gunakan pembantu low‑code ketika operasi standar diterapkan pada seluruh file atau presentasi dan tidak memerlukan kontrol detail atas elemen individu. Gunakan model objek penuh ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan layout, memeriksa keadaan menengah, atau mengonfigurasi perilaku yang tidak disediakan pembantu.

**Apakah Merger dapat menggabungkan presentasi dalam format file yang berbeda?**

Tidak. [Merger.Process](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/merger/process/) memerlukan presentasi masukan dengan format yang sama. Konversi file masukan ke format umum terlebih dahulu, misalnya dengan [Convert.AutoByExtension](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/convert/autobyextension/), kemudian gabungkan file yang telah dikonversi.

**Apakah ForEach memproses slide master, layout, dan catatan?**

[ForEach.Slide](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/slide/) mengiterasi slide presentasi normal. [ForEach.Shape](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/paragraph/), dan [ForEach.Portion](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/portion/) mencakup slide normal, master, dan layout secara default. Gunakan overload mereka dengan `includeNotes` disetel ke `true` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach.Shape dan Collect.Shapes?**

Gunakan [ForEach.Shape](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/shape/) untuk memproses setiap shape secara langsung melalui callback. Gunakan [Collect.Shapes](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/collect/shapes/) ketika Anda memerlukan hasil yang dapat dipertahankan, disaring, dihitung, atau dilalui berkali‑kali.

**Apakah Compress selalu membuat file presentasi lebih kecil?**

Tidak selalu. Hasilnya tergantung pada apakah presentasi berisi layout yang tidak terpakai, master yang tidak terpakai, atau font tertanam dengan karakter yang tidak terpakai. Jika tidak ada yang tersebut, operasi [Compress](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/) yang bersangkutan mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dilakukan oleh ForEach atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/foreach/) atau menjalankan [Compress](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/), panggil [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) untuk menulis hasilnya.

## **Artikel Terkait**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)