---
title: Mengelola Grafik SmartArt dalam Presentasi di .NET
linktitle: Grafik SmartArt
type: docs
weight: 20
url: /id/net/manage-smartart-shape/
keywords:
- objek SmartArt
- grafik SmartArt
- gaya SmartArt
- warna SmartArt
- buat SmartArt
- tambahkan SmartArt
- sunting SmartArt
- ubah SmartArt
- akses SmartArt
- tipe tata letak SmartArt
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Otomatisasi pembuatan, penyuntingan, dan penataan SmartArt PowerPoint di .NET menggunakan Aspose.Slides, dengan contoh kode singkat dan panduan yang berfokus pada kinerja."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membuat dan mengelola grafik SmartArt dalam presentasi PowerPoint secara programatis. Artikel ini menjelaskan cara menambahkan bentuk SmartArt ke slide, mengakses bentuk SmartArt yang ada, menemukan SmartArt berdasarkan tipe tata letak tertentu, dan memperbarui penampilan visualnya dengan mengubah gaya SmartArt atau gaya warna.

Contoh-contoh menunjukkan cara bekerja dengan bentuk SmartArt melalui koleksi bentuk pada slide presentasi, memeriksa apakah sebuah bentuk merupakan SmartArt, dan kemudian mengubah atau memeriksa propertinya.

## **Buat Bentuk SmartArt**
Aspose.Slides for .NET now facilitates to add custom SmartArt shapes in their slides from scratch. Aspose.Slides for .NET has provided the simplest API to create SmartArt shapes in an easiest way. To create a SmartArt shape in a slide, please follow the steps below:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan bentuk SmartArt dengan mengatur LayoutType-nya.
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```c#
// Instansiasi presentasi
using (Presentation pres = new Presentation())
{

    // Akses slide presentasi
    ISlide slide = pres.Slides[0];

    // Tambahkan Bentuk Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Menyimpan presentasi
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Akses Bentuk SmartArt pada Slide**
Kode berikut akan digunakan untuk mengakses bentuk SmartArt yang ditambahkan pada slide presentasi. Dalam contoh kode, kami akan menelusuri setiap bentuk di dalam slide dan memeriksa apakah itu merupakan bentuk SmartArt. Jika bentuk tersebut bertipe SmartArt, maka akan kami cast menjadi instance SmartArt.

```c#
// Muat presentasi yang diinginkan
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Telusuri setiap bentuk di dalam slide pertama
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape is ISmartArt)
        {
            // Cast bentuk menjadi SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```



## **Akses Bentuk SmartArt dengan Tipe Tata Letak Tertentu**
Kode contoh berikut akan membantu mengakses bentuk SmartArt dengan LayoutType tertentu. Harap dicatat bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya ditetapkan saat bentuk SmartArt ditambahkan.

- Buat instance dari kelas `Presentation` dan muat presentasi yang berisi Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut bertipe SmartArt dan cast bentuk yang dipilih menjadi SmartArt jika memang SmartArt.
- Periksa bentuk SmartArt dengan LayoutType tertentu dan lakukan apa yang diperlukan setelahnya.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Telusuri setiap bentuk di dalam slide pertama
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape is ISmartArt)
        {
            // Cast bentuk menjadi SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Memeriksa Tata Letak SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```



## **Ubah Gaya Bentuk SmartArt**
Kode contoh berikut akan membantu mengakses bentuk SmartArt dengan LayoutType tertentu.

- Buat instance dari kelas `Presentation` dan muat presentasi yang berisi Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut bertipe SmartArt dan cast bentuk yang dipilih menjadi SmartArt jika memang SmartArt.
- Temukan bentuk SmartArt dengan Gaya tertentu.
- Tetapkan Gaya baru untuk bentuk SmartArt.
- Simpan Presentasi.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Telusuri setiap bentuk di dalam slide pertama
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape is ISmartArt)
        {
            // Cast bentuk menjadi SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Memeriksa gaya SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Mengubah Gaya SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Menyimpan Presentasi
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **Ubah Gaya Warna Bentuk SmartArt**
Dalam contoh ini, kami akan mempelajari cara mengubah gaya warna untuk setiap bentuk SmartArt. Pada kode contoh berikut, akan diakses bentuk SmartArt dengan gaya warna tertentu dan gaya tersebut akan diubah.

- Buat instance dari kelas `Presentation` dan muat presentasi yang berisi Bentuk SmartArt.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Telusuri setiap bentuk di dalam slide pertama.
- Periksa apakah bentuk tersebut bertipe SmartArt dan cast bentuk yang dipilih menjadi SmartArt jika memang SmartArt.
- Temukan bentuk SmartArt dengan Gaya Warna tertentu.
- Tetapkan Gaya Warna baru untuk bentuk SmartArt.
- Simpan Presentasi.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Telusuri setiap bentuk di dalam slide pertama
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape is ISmartArt)
        {
            // Cast bentuk menjadi SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Memeriksa tipe warna SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Mengubah tipe warna SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Menyimpan Presentasi
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat menganimasikan SmartArt sebagai satu objek?**

Ya. SmartArt adalah sebuah bentuk, sehingga Anda dapat menerapkan [animasi standar](/slides/id/net/powerpoint-animation/) melalui API animasi (masuk, keluar, penekanan, jalur gerakan) seperti pada bentuk lainnya.

**Bagaimana saya dapat menemukan SmartArt tertentu pada slide jika saya tidak mengetahui ID internalnya?**

Atur dan gunakan Teks Alternatif (AltText) serta cari bentuk tersebut berdasarkan nilai itu—ini merupakan cara yang disarankan untuk menemukan bentuk target.

**Apakah saya dapat mengelompokkan SmartArt dengan bentuk lain?**

Ya. Anda dapat mengelompokkan SmartArt dengan bentuk lain (gambar, tabel, dll.) dan kemudian [memanipulasi grup](/slides/id/net/group/).

**Bagaimana cara mendapatkan gambar dari SmartArt tertentu (misalnya untuk pratinjau atau laporan)?**

Ekspor thumbnail/gambar bentuk; pustaka dapat [merender bentuk individual](/slides/id/net/create-shape-thumbnails/) ke file raster (PNG/JPG/TIFF).

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi seluruh presentasi ke PDF?**

Ya. Mesin rendering menargetkan kesetiaan tinggi untuk [ekspor PDF](/slides/id/net/convert-powerpoint-to-pdf/), dengan berbagai opsi kualitas dan kompatibilitas.