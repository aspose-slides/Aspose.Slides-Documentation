---
title: Kelola Transisi Slide dalam Presentasi di .NET
linktitle: Transisi Slide
type: docs
weight: 90
url: /id/net/slide-transition/
keywords:
- transisi slide
- menambahkan transisi slide
- menerapkan transisi slide
- transisi slide lanjutan
- transisi morph
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan kemajuan slide otomatis, dan sesuaikan Morph serta efek transisi lain dengan Aspose.Slides untuk .NET."
---
## **Ikhtisar**

Transisi slide mengontrol bagaimana slide muncul selama pertunjukan slide. Dengan Aspose.Slides untuk .NET, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi kemajuan dengan klik mouse atau timer, dan menyesuaikan opsi spesifik untuk sebuah efek. Artikel ini menggunakan contoh C# untuk menerapkan transisi, mengatur durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan akses properti [SlideShowTransition](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/slideshowtransition/) slide. Atur [Type](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/type/)‑nya ke nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitiontype/), kemudian simpan presentasi.

Contoh berikut menerapkan transisi Circle pada slide pertama dan transisi Comb pada slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Menambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Properti‑properti berikut mengontrol perilaku ini:

- [AdvanceOnClick](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/advanceonclick/) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [AdvanceAfter](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/advanceafter/) mengaktifkan kemajuan otomatis.
- [AdvanceAfterTime](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/advanceaftertime/) menentukan penundaan sebelum kemajuan otomatis, dalam milidetik.

Aktifkan kedua kemajuan klik dan berjangka waktu agar penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk hanya menggunakan timer, atur [AdvanceOnClick](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/advanceonclick/) menjadi `false`. Penundaan mengontrol kapan pertunjukan slide melanjutkan; itu bukan durasi efek transisi visual.

Contoh ini menetapkan efek yang berbeda pada tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik masing‑masing. Klik mouse juga dapat melanjutkan slide‑slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Untuk memeriksa apakah kemajuan berjangka waktu diaktifkan, baca [AdvanceAfter](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/advanceafter/). Penundaan yang tersimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan penundaan lebih dari dua detik. Ia mengaktifkan klik mouse untuk slide‑slide tersebut dan menyimpan pengaturan yang diperbarui.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Mengontrol Waktu Transisi Secara Tepat**

Gunakan [Duration](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/duration/) untuk menentukan panjang tepat efek transisi dalam milidetik. Properti [SlideShowTransition](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/slideshowtransition/) slide mengekspos pengaturan ini melalui [ISlideShowTransition](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/):

| Properti | Tujuan |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/duration/) | Menetapkan durasi efek transisi itu sendiri, dalam milidetik. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Menetapkan penundaan sebelum slide maju secara otomatis, dalam milidetik. Aktifkan [AdvanceAfter](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/advanceafter/) untuk mengaktifkan timer ini. |
| [Speed](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/speed/) | Memilih kategori kecepatan yang telah ditentukan dari [TransitionSpeed](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium, atau Fast. Digunakan ketika durasi tepat tidak ditentukan. |

[Duration](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/duration/) mengontrol hanya efek transisi; ia tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan penundaan kemajuan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek dari jenis transisi dan nilai [Speed](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Terapkan Durasi yang Sama pada Setiap Slide**

Untuk ritme yang konsisten, terapkan efek yang sama dan durasi tepat pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitiontype/), dan memberi setiap transisi durasi 750 milidetik. Ia juga mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan melalui klik mouse, kemudian menyimpan hasilnya sebagai PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Konfigurasikan kemajuan otomatis secara terpisah dari durasi efek.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Atur Durasi Berbeda untuk Slide Individual**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengenalan bagian. Contoh ini menetapkan 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Koordinasikan Transisi dengan Output Animasi**

Saat menyiapkan [animated GIF](/slides/id/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/net/export-to-html5/), atau [video](/slides/id/net/convert-powerpoint-to-video/), atur durasi transisi yang tepat sebelum mengekspor untuk mencocokkan kecepatan yang diinginkan. Misalnya, gunakan fade 600 milidetik antara adegan, dan sesuaikan penundaan kemajuan tiap slide secara terpisah untuk memberi waktu narasi atau konten.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik setara dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi dalam pengaturan ekspor. Periksa efek dan opsi waktu yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Baca [Duration](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/duration/) sebelum mengubah transisi untuk menentukan apakah nilai eksplisit tersimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang diatur; nilai non‑negatif menentukan durasi yang tersimpan dalam milidetik. Nilai yang tidak diatur bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan jenis transisi dan [Speed](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/speed/) untuk menentukan durasi tersebut. Menetapkan jenis transisi dapat menginisialisasi durasi, jadi inspeksi pengaturan asli terlebih dahulu.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Transisi Morph**

Transisi Morph menganimasikan perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, klon slide, pindahkan atau ubah ukuran sebuah objek pada klon, dan terapkan transisi Morph pada slide kedua. Ini memberi transisi objek‑objek yang sesuai untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan kotak teks, mengklon slide, dan mengubah posisi serta ukuran kotak pada klon. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitiontype/) untuk slide kedua. Buka file yang disimpan di penampil presentasi yang mendukung Morph untuk melihat efek selama pertunjukan slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Jenis Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionmorphtype/) mengontrol bagaimana Morph mencocokkan dan menganimasikan konten:

- [ByObject](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionmorphtype/) memperlakukan setiap bentuk sebagai satu objek utuh.
- [ByWord](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionmorphtype/) menganimasikan teks dengan mencocokkan kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionmorphtype/) menganimasikan teks dengan mencocokkan karakter bila memungkinkan.

Atur [Type](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/type/) transisi menjadi Morph sebelum mengakses [Value](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/value/). Nilai tersebut kemudian menyediakan antarmuka [IMorphTransition](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/imorphtransition/), yang properti [MorphType](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/imorphtransition/morphtype/)‑nya memilih mode pencocokan.

Contoh ini membuka presentasi yang dibuat pada bagian sebelumnya dan mengkonfigurasi slide kedua untuk menggunakan animasi Morph berbasis kata.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Menetapkan Efek Transisi**

Beberapa transisi mengekspos opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada [Type](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/type/) transisi yang dipilih. Atur tipe terlebih dahulu, lalu gunakan antarmuka yang sesuai dari [Value](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/value/).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia mengatur [FromBlack](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) melalui [IOptionalBlackTransition](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/ioptionalblacktransition/) sehingga transisi dimulai dari layar hitam.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Gunakan [Duration](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/duration/) ketika Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [Speed](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/speed/) ketika kategori [TransitionSpeed](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionspeed/) yang telah ditentukan—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang diatur. Pengaturan ini mengontrol efek transisi secara terpisah dari penundaan kemajuan otomatis.

**Apakah saya dapat menempelkan audio ke transisi dan menjadikannya berulang?**

Ya. Tetapkan audio tersemat ke [Sound](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/sound/), atur [SoundMode](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/soundmode/) menjadi StartSound dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionsoundmode/), dan aktifkan [SoundLoop](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/soundloop/). Audio akan berulang hingga acara suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Loop melalui koleksi [Slides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slides/id/) presentasi dan atur [Type](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/type/) transisi setiap slide ke nilai yang sama. Atur opsi waktu dan efek apa pun dalam loop yang sama untuk menjaga perilaku konsisten di seluruh slide.

**Bagaimana saya dapat memeriksa transisi apa yang saat ini diterapkan pada slide?**

Baca properti [Type](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/type/) dari [SlideShowTransition](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/slideshowtransition/) slide. Ia mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitiontype/); None berarti tidak ada efek transisi yang diterapkan.