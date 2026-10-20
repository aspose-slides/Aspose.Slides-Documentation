---
title: Ubah Ukuran Bentuk pada Slide Presentasi di .NET
type: docs
weight: 130
url: /id/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /id/net/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Gambaran Umum**

Saat Anda mengubah ukuran slide presentasi, Anda mungkin juga perlu mengubah ukuran dan memposisikan kembali bentuk‑bentuknya agar sesuai dengan dimensi baru. Artikel ini menunjukkan cara memperbesar bentuk secara manual dan cara menangani tabel pada slide, master, dan tata letak.

## **Ubah Ukuran Bentuk**

Untuk mempertahankan posisi dan ukuran relatif setiap bentuk, kalikan koordinat horizontal dan lebar bentuk dengan rasio lebar slide baru terhadap lebar aslinya. Terapkan rasio tinggi yang sesuai pada koordinat vertikal dan tinggi bentuk.

Contoh pertama memuat presentasi yang slide‑nya tidak berisi tabel, mengubah ukuran slide menjadi A4, dan menyimpan hasilnya. Ia menggunakan [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) dengan [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) sehingga loop berikutnya mengontrol penskalaan. Rasio‑rasio tersebut tidak memiliki satuan; posisi dan dimensi bentuk diukur dalam poin. Rasio lebar dan tinggi yang berbeda dapat mendistorsi bentuk, dan mengubah dimensi bentuk tidak memperbesar ukuran fontnya.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Hitung faktor skala horizontal dan vertikal secara independen.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}

Tabel memerlukan penanganan terpisah: skalakan lebar kolom dan tinggi baris alih‑alih menetapkan lebar dan tinggi keseluruhan tabel. Tinggi baris mungkin tetap lebih besar daripada yang diminta jika isi sel memerlukan lebih banyak ruang.

{{% /alert %}}

Contoh kedua mendukung tabel dan memproses bentuk pada master dan tata letak serta slide individu sebelum menyimpan presentasi yang telah diubah ukurannya. Pembantunya menangani setiap [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) dengan memperbesar [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) dan [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Kemudian ia memperbesar posisi tabel tanpa memperbesar dimensi keseluruhannya secara terpisah.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Hitung faktor skala horizontal dan vertikal secara independen.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Ubah ukuran bentuk yang didefinisikan pada master dan tata letak serta slide individu.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Dimensi tabel dikontrol oleh lebar kolom dan tinggi baris.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **FAQ**

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Jika Anda mengubah ukuran slide tanpa menskala bentuk, bentuk‑bentuk tersebut mempertahankan posisi dan dimensi aslinya dan dapat melampaui batas slide. Menskala lebar dan tinggi dengan rasio yang berbeda juga dapat mendistorsi bentuk.

**Apakah kode yang diberikan berfungsi untuk semua jenis bentuk?**

Contoh pertama mengubah batas bentuk secara langsung dan ditujukan untuk slide tanpa tabel. Contoh kedua menangani tabel secara terpisah. Periksa tata letak hasil, terutama teks dan tabel, karena contoh‑contoh ini tidak memperbesar ukuran font dan konten tabel dapat membatasi tinggi baris.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Skalakan lebar kolom dengan rasio lebar dan tinggi baris minimum dengan rasio tinggi, kemudian skalakan posisi tabel, seperti yang ditunjukkan pada contoh kedua.

**Apakah perubahan ukuran ini akan bekerja untuk master slide dan layout slide?**

Ya. Contoh kedua mengiterasi melalui [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) dan setiap master’s [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) serta menerapkan logika pengubahan ukuran yang sama pada bentuk‑bentuknya.

**Bisakah saya mengubah orientasi slide (potret/lanskap) bersama dengan pengubahan ukuran?**

Ya. Tetapkan [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) setelah mengubah ukuran slide dan sebelum membaca dimensi target, sehingga faktor skala mencerminkan orientasi akhir.

**Apakah ada batasan ukuran slide yang dapat saya setel?**

Anda dapat menentukan dimensi slide khusus dengan [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Dimensi yang didukung juga bergantung pada format presentasi dan aplikasi yang digunakan untuk membuka file.

**Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Gunakan faktor skala yang sama untuk lebar dan tinggi. Untuk menyesuaikan tata letak asli dalam dimensi slide baru, gunakan rasio yang lebih kecil antara lebar dan tinggi untuk kedua dimensi dan posisi. Ini mempertahankan proporsi tetapi mungkin meninggalkan ruang yang tidak terpakai di satu sisi.