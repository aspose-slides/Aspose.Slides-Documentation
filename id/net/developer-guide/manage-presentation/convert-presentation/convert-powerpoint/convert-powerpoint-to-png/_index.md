---
title: Konversi Slide PowerPoint ke PNG di .NET
linktitle: PowerPoint ke PNG
type: docs
weight: 30
url: /id/net/convert-powerpoint-to-png/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke PNG
- presentasi ke PNG
- slide ke PNG
- PPT ke PNG
- PPTX ke PNG
- simpan PPT sebagai PNG
- simpan PPTX sebagai PNG
- ekspor PPT ke PNG
- ekspor PPTX ke PNG
- .NET
- C#
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke gambar PNG berkualitas tinggi dengan cepat menggunakan Aspose.Slides untuk .NET, memastikan hasil yang tepat dan otomatis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint menjadi gambar PNG menggunakan Aspose.Slides. Artikel ini menunjukkan cara memuat file presentasi dalam format seperti PPT, PPTX, dan ODP, merender slide sebagai gambar, dan menyimpan hasilnya dalam format PNG.

Artikel ini juga memperlihatkan cara menyesuaikan gambar PNG yang dihasilkan dengan mengatur nilai skala atau menentukan lebar dan tinggi yang diinginkan.

## **Konversi PowerPoint ke PNG**

1. Membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan objek slide dari koleksi [Presentation.Slides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/properties/slides) di bawah antarmuka [ISlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide).
3. Gunakan metode [ISlide.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/islide/getimage/) untuk mendapatkan thumbnail setiap slide.
4. Gunakan metode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.ipresentation/save/methods/5) untuk menyimpan thumbnail slide ke format PNG.

Kode C# ini memperlihatkan cara mengonversi presentasi PowerPoint ke PNG. Objek Presentation dapat memuat PPT, PPTX, ODP, dll, kemudian setiap slide dalam objek presentation dikonversi ke format PNG atau format gambar lainnya.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Jika Anda ingin mendapatkan file PNG dengan skala tertentu, Anda dapat mengatur nilai `desiredX` dan `desiredY`, yang menentukan dimensi thumbnail yang dihasilkan.

Kode ini dalam C# mendemonstrasikan operasi yang dijelaskan:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Jika Anda ingin mendapatkan file PNG dengan ukuran tertentu, Anda dapat memberikan argumen `width` dan `height` pilihan Anda untuk `imageSize`.

Kode ini memperlihatkan cara mengonversi PowerPoint ke PNG sambil menentukan ukuran gambar:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **FAQ**

**Bagaimana cara mengekspor hanya bentuk tertentu (mis., diagram atau gambar) alih-alih seluruh slide?**

Aspose.Slides mendukung [pembuatan thumbnail untuk bentuk individual](/slides/id/net/create-shape-thumbnails/); Anda dapat merender sebuah bentuk ke gambar PNG.

**Apakah konversi paralel didukung di server?**

Ya, tetapi [jangan berbagi](/slides/id/net/multithreading/) satu instance presentation di antara thread. Gunakan instance terpisah per thread atau proses.

**Apa batasan versi percobaan saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan memberlakukan [pembatasan lain](/slides/id/net/licensing/) hingga lisensi diterapkan.