---
title: Konversi Presentasi PowerPoint ke GIF Animasi dalam C++
linktitle: PowerPoint ke GIF
type: docs
weight: 65
url: /id/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF animasi
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke GIF
- presentasi ke GIF
- slide ke GIF
- PPT ke GIF
- PPTX ke GIF
- simpan PPT sebagai GIF
- simpan PPTX sebagai GIF
- ekspor PPT sebagai GIF
- ekspor PPTX sebagai GIF
- pengaturan default
- pengaturan khusus
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Dengan mudah mengonversi presentasi PowerPoint (PPT, PPTX) menjadi GIF animasi dengan Aspose.Slides untuk C++. Hasil cepat dan berkualitas tinggi."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda untuk mengonversi presentasi PowerPoint menjadi file GIF animasi dengan hanya beberapa baris kode. Ini berguna ketika Anda perlu membagikan konten slide dalam format animasi yang ringan, didukung secara luas, dan dapat disematkan di halaman web, messenger, atau dokumentasi. Artikel ini menjelaskan cara mengekspor presentasi ke GIF menggunakan pengaturan default dan cara menyesuaikan output dengan mengonfigurasi opsi seperti ukuran frame, penundaan slide, dan kecepatan frame transisi melalui [GifOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/gifoptions/).

## **Mengonversi Presentasi ke GIF Animasi dengan Pengaturan Default**

Kode contoh ini dalam C++ menunjukkan cara mengonversi presentasi ke GIF animasi menggunakan pengaturan standar:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

GIF animasi akan dibuat dengan parameter default. 

{{%  alert  title="TIP"  color="primary"  %}} 
Jika Anda lebih suka menyesuaikan parameter untuk GIF, Anda dapat menggunakan kelas [GifOptions](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.gif_options). Lihat kode contoh di bawah. 
{{% /alert %}} 

## **Mengonversi Presentasi ke GIF Animasi dengan Pengaturan Khusus**

Kode contoh ini menunjukkan cara mengonversi presentasi ke GIF animasi dengan pengaturan khusus dalam C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// ukuran GIF yang dihasilkan 
gifOptions->set_FrameSize(Size(960, 720));
// berapa lama setiap slide akan ditampilkan hingga diganti ke slide berikutnya
gifOptions->set_DefaultDelay(2000);
// tingkatkan FPS untuk kualitas animasi transisi yang lebih baik
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Anda mungkin ingin melihat konverter [Text to GIF](https://products.aspose.app/slides/id/text-to-gif) GRATIS yang dikembangkan oleh Aspose. 
{{% /alert %}}

## **FAQ**

**Bagaimana jika font yang digunakan dalam presentasi tidak terpasang di sistem?**

Pasang font yang hilang atau [konfigurasikan font fallback](/slides/id/cpp/powerpoint-fonts/). Aspose.Slides akan menggantinya, tetapi tampilannya mungkin berbeda. Untuk keperluan merek, selalu pastikan tipe huruf yang diperlukan tersedia secara eksplisit.

**Apakah saya dapat menambahkan watermark pada frame GIF?**

Ya. [Tambahkan objek/logo semi-transparan](/slides/id/cpp/watermark/) ke slide master atau ke slide individual sebelum mengekspor — watermark akan muncul pada setiap frame.