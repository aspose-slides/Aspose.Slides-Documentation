---
title: Multithreading dalam Aspose.Slides untuk .NET
linktitle: Multithreading
type: docs
weight: 310
url: /id/net/multithreading/
keywords:
- multithreading
- beberapa thread
- pekerjaan paralel
- mengonversi slide
- slide ke gambar
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Multithreading Aspose.Slides untuk .NET meningkatkan pemrosesan PowerPoint dan OpenDocument. Temukan praktik terbaik untuk alur kerja presentasi yang efisien."
---
## **Pendahuluan**

Meskipun pekerjaan paralel dengan presentasi memungkinkan (selain parsing/memuat/menduplikat) dan semuanya berjalan baik (biasanya), ada kemungkinan kecil Anda mendapatkan hasil yang tidak tepat ketika menggunakan pustaka ini di beberapa thread.

Kami sangat menyarankan agar Anda **tidak** menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dalam lingkungan multi-threading karena dapat menyebabkan kesalahan atau kegagalan yang tidak dapat diprediksi dan sulit terdeteksi. 

Tidak **aman** untuk memuat, menyimpan, dan/atau menduplikat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dalam beberapa thread. Operasi semacam itu **tidak** didukung. Jika Anda perlu melakukan tugas tersebut, Anda harus memparalelkan operasi dengan menggunakan beberapa proses single-threaded—dan setiap proses tersebut harus menggunakan instance presentasi masing‑masing. 

## **Mengonversi Slide Presentasi menjadi Gambar secara Paralel**

Misalkan kita ingin mengonversi semua slide dari sebuah presentasi PowerPoint menjadi gambar PNG secara paralel. Karena tidak aman menggunakan satu instance `Presentation` dalam beberapa thread, kita membagi slide presentasi menjadi presentasi terpisah dan mengonversi slide menjadi gambar secara paralel, dengan menggunakan setiap presentasi dalam thread terpisah. Contoh kode berikut menunjukkan cara melakukannya.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Ekstrak slide i ke dalam presentasi terpisah.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Konversi slide menjadi gambar dalam tugas terpisah.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **FAQ**

**Apakah saya harus memanggil pengaturan lisensi di setiap thread?**

Tidak. Cukup lakukan sekali per proses/domain aplikasi sebelum thread dimulai. Jika [license setup](/slides/id/net/licensing/) dapat dipanggil secara bersamaan (misalnya, selama inisialisasi malas), sinkronkan pemanggilan tersebut karena metode pengaturan lisensi tidak bersifat thread-safe.

**Bisakah saya mengirim objek `Presentation` atau `Slide` antar thread?**

Melewatkan objek presentasi yang “live” antar thread tidak disarankan: gunakan instance independen per thread atau buat sebelumnya presentasi/kontainer slide terpisah untuk setiap thread. Pendekatan ini mengikuti rekomendasi umum untuk tidak membagikan satu instance presentasi di antara thread.

**Apakah aman memparalelkan ekspor ke format berbeda (PDF, HTML, gambar) dengan asumsi setiap thread memiliki instance `Presentation` masing‑masing?**

Ya. Dengan instance independen dan jalur output terpisah, tugas semacam itu biasanya dapat diparalelkan dengan benar; hindari penggunaan objek presentasi bersama serta aliran I/O yang dibagi.

**Apa yang harus saya lakukan dengan pengaturan font global (folder, substitusi) dalam multithreading?**

Inisialisasi semua pengaturan font global sebelum memulai thread dan jangan mengubahnya selama pekerjaan paralel. Ini menghilangkan kondisi balapan saat mengakses sumber daya font yang dibagi.