---
title: Mengubah Ukuran Bentuk pada Slide Presentasi di .NET
type: docs
weight: 130
url: /id/net/re-sizing-shapes-on-slide/
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
## **Ringkasan**

Salah satu pertanyaan paling umum dari pelanggan Aspose.Slides untuk .NET adalah cara mengubah ukuran bentuk sehingga, ketika ukuran slide berubah, data tidak terpotong. Artikel teknis singkat ini menunjukkan cara melakukannya.

## **Ubah Ukuran Bentuk**

Untuk mencegah bentuk menjadi tidak selaras ketika ukuran slide berubah, perbarui posisi dan dimensi setiap bentuk agar sesuai dengan tata letak slide yang baru.

```c#
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

     // Ubah ukuran dan posisi kembali bentuk pada setiap slide.
     foreach (ISlide slide in presentation.Slides)
     {
         foreach (IShape shape in slide.Shapes)
         {
             // Skala ukuran bentuk.
             shape.Height *= heightRatio;
             shape.Width *= widthRatio;

             // Skala posisi bentuk.
             shape.Y *= heightRatio;
             shape.X *= widthRatio;
         }
     }

     presentation.Save("output.pptx", SaveFormat.Pptx);
 }
```

{{% alert color="primary" %}}
Jika sebuah slide berisi tabel, kode di atas tidak akan berfungsi dengan benar. Dalam kasus ini, setiap sel dalam tabel harus diubah ukurannya.
{{% /alert %}}

Gunakan kode berikut pada sisi Anda untuk mengubah ukuran slide yang berisi tabel. Untuk tabel, mengatur lebar atau tinggi merupakan kasus khusus: Anda harus menyesuaikan tinggi baris individu dan lebar kolom untuk mengubah ukuran keseluruhan tabel.

```c#
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
            // Skala ukuran bentuk.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skala posisi bentuk.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Skala ukuran bentuk.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Skala posisi bentuk.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Skala ukuran bentuk.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skala posisi bentuk.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Saat mengubah ukuran slide, bentuk mempertahankan posisi dan ukuran aslinya kecuali skala diubah secara eksplisit. Hal ini dapat menyebabkan konten terpotong atau bentuk menjadi tidak selaras.

**Apakah kode yang diberikan bekerja untuk semua tipe bentuk?**

Contoh dasar bekerja untuk sebagian besar tipe bentuk (kotak teks, gambar, bagan, dll.). Namun, untuk tabel, Anda perlu menangani baris dan kolom secara terpisah, karena tinggi dan lebar tabel ditentukan oleh dimensi sel individu.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Anda perlu melakukan iterasi pada semua baris dan kolom tabel serta mengubah tinggi dan lebar secara proporsional, seperti yang ditunjukkan pada contoh kode kedua.

**Apakah perubahan ukuran ini berfungsi untuk master slide dan layout slide?**

Ya, tetapi Anda juga harus melakukan iterasi pada [Masters](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/masters/) dan [LayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/layoutslides/) serta menerapkan logika skala yang sama pada bentuk mereka untuk memastikan konsistensi di seluruh presentasi.

**Apakah saya dapat mengubah orientasi slide (potret/lanskap) bersamaan dengan pengubahan ukuran?**

Ya. Anda dapat mengatur [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/id/net/aspose.slides/islidesize/orientation/) untuk mengubah orientasi. Pastikan Anda menyesuaikan logika skala secara tepat untuk mempertahankan tata letak.

**Apakah ada batasan ukuran slide yang dapat saya tetapkan?**

Aspose.Slides mendukung ukuran kustom, tetapi ukuran yang sangat besar dapat memengaruhi kinerja atau kompatibilitas dengan beberapa versi PowerPoint.

**Bagaimana cara mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Anda dapat memeriksa properti `AspectRatioLocked` pada bentuk sebelum melakukan skala. Jika terkunci, sesuaikan lebar atau tinggi secara proporsional daripada menskalakan keduanya secara terpisah.