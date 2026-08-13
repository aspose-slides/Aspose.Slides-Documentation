---
title: Mengubah Ukuran Bentuk pada Slide Presentasi di .NET
type: docs
weight: 130
url: /id/net/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ganti ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET—mengotomatiskan penyesuaian tata letak slide dan meningkatkan produktivitas."
---
## **Ikhtisar**

Salah satu pertanyaan paling umum dari pelanggan Aspose.Slides for .NET adalah bagaimana cara mengubah ukuran bentuk sehingga, ketika ukuran slide berubah, data tidak terpotong. Artikel teknis singkat ini menunjukkan cara melakukannya.

## **Ubah Ukuran Bentuk**

Untuk mencegah bentuk menjadi tidak sejajar saat ukuran slide berubah, perbarui posisi dan dimensi setiap bentuk sehingga sesuai dengan tata letak slide yang baru.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Muat file presentasi.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Dapatkan ukuran slide asli.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Ubah ukuran slide tanpa menskalakan bentuk yang ada.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Dapatkan ukuran slide baru.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Ubah ukuran dan posisikan kembali bentuk pada setiap slide.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Menskalakan ukuran bentuk.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Menskalakan posisi bentuk.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Jika sebuah slide berisi tabel, kode di atas tidak akan berfungsi dengan benar. Dalam hal ini, setiap sel dalam tabel harus diubah ukurannya.
{{% /alert %}}

Gunakan kode berikut di sisi Anda untuk mengubah ukuran slide yang berisi tabel. Untuk tabel, skalakan tinggi baris dan lebar kolom individual alih-alih lebar dan tinggi bentuk—menerapkan keduanya akan menggandakan skala tabel dan menempelkannya ke luar slide.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Dapatkan ukuran slide asli.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Ubah ukuran slide tanpa menskalakan bentuk yang ada.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Dapatkan ukuran slide baru.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Menskalakan ukuran bentuk.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Menskalakan posisi bentuk.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Menskalakan ukuran bentuk.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Menskalakan posisi bentuk.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // Menskalakan ukuran tabel melalui baris dan kolomnya.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // Menskalakan ukuran bentuk.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Menskalakan posisi bentuk.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?

Saat mengubah ukuran slide, bentuk mempertahankan posisi dan ukuran aslinya kecuali skala diubah secara eksplisit. Hal ini dapat menyebabkan konten terpotong atau bentuk menjadi tidak sejajar.

### Apakah kode yang disediakan bekerja untuk semua tipe bentuk?

Contoh dasar bekerja untuk sebagian besar tipe bentuk (kotak teks, gambar, diagram, dll.). Namun, untuk tabel, Anda perlu menangani baris dan kolom secara terpisah, karena tinggi dan lebar tabel ditentukan oleh dimensi sel individual.

### Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?

Anda perlu mengulangi semua baris dan kolom tabel dan mengubah tinggi serta lebar mereka secara proporsional, seperti yang ditunjukkan pada contoh kode kedua.

### Apakah perubahan ukuran ini akan bekerja untuk master slide dan layout slide?

Ya, tetapi Anda juga harus mengulangi [Masters](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/masters/) dan [LayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/layoutslides/) serta menerapkan logika skala yang sama pada bentuk mereka untuk memastikan konsistensi di seluruh presentasi.

### Bisakah saya mengubah orientasi slide (potret/lanskap) bersama dengan perubahan ukuran?

Ya. Anda dapat mengatur [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/id/net/aspose.slides/islidesize/orientation/) untuk mengubah orientasi. Pastikan Anda menyesuaikan logika skala agar tata letak tetap terjaga.

### Apakah ada batasan ukuran slide yang dapat saya atur?

Aspose.Slides mendukung ukuran khusus, tetapi ukuran yang sangat besar dapat memengaruhi kinerja atau kompatibilitas dengan beberapa versi PowerPoint.

### Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?

Anda dapat memeriksa properti `AspectRatioLocked` dari bentuk sebelum melakukan skala. Jika terkunci, sesuaikan lebar atau tinggi secara proporsional alih-alih menskalakan masing-masing secara terpisah.