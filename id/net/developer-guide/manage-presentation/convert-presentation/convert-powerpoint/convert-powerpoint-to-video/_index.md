---
title: Mengonversi Presentasi PowerPoint ke Video di .NET
linktitle: PowerPoint ke Video
type: docs
weight: 130
url: /id/net/convert-powerpoint-to-video/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi PPT
- konversi PPTX
- PowerPoint ke video
- presentasi ke video
- PPT ke video
- PPTX ke video
- PowerPoint ke MP4
- presentasi ke MP4
- PPT ke MP4
- PPTX ke MP4
- simpan PPT sebagai MP4
- simpan PPTX sebagai MP4
- ekspor PPT ke MP4
- ekspor PPTX ke MP4
- konversi video
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengonversi presentasi PowerPoint ke video di .NET. Temukan contoh kode C# dan teknik otomasi untuk menyederhanakan alur kerja Anda."
---
## **Pendahuluan**

Dengan mengonversi presentasi PowerPoint atau OpenDocument Anda ke video, Anda mendapatkan:

**Aksesibilitas yang meningkat:** Semua perangkat, tanpa memandang platform, dilengkapi dengan pemutar video secara bawaan, sehingga memudahkan pengguna untuk membuka atau memutar video dibandingkan dengan aplikasi presentasi tradisional.

**Jangkauan yang lebih luas:** Video memungkinkan Anda menjangkau audiens yang lebih besar dan menyajikan informasi dalam format yang lebih menarik. Survei dan statistik menunjukkan bahwa orang lebih suka menonton dan mengonsumsi konten video dibandingkan bentuk lain, sehingga pesan Anda menjadi lebih berdampak.

{{% alert color="primary" %}} 
Lihat [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/id/video) kami karena menyediakan implementasi langsung dan efektif dari proses yang dijelaskan di sini.
{{% /alert %}} 

Di Aspose.Slides untuk .NET, kami telah menambahkan dukungan untuk mengonversi presentasi ke video.

* Gunakan Aspose.Slides untuk .NET untuk menghasilkan frame dari slide presentasi dengan laju frame tertentu (FPS).
* Kemudian, gunakan utilitas pihak ketiga seperti ffmpeg untuk mengompilasi frame-frame tersebut menjadi video.

## **Mengonversi Presentasi PowerPoint ke Video**

1. Gunakan perintah `dotnet add package` untuk menambahkan Aspose.Slides dan pustaka FFMpegCore ke proyek Anda:
   * jalankan `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * jalankan `dotnet add package FFMpegCore --version 4.8.0`
2. Unduh ffmpeg dari [sini](https://ffmpeg.org/download.html).
3. FFMpegCore mengharuskan Anda menentukan path ke ffmpeg yang diunduh (misalnya, diekstrak ke "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Jalankan kode konversi PowerPoint-ke-video.

Kode C# ini menunjukkan cara mengonversi presentasi (yang berisi sebuah shape dan dua efek animasi) menjadi video:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // akan menggunakan binary FFmpeg yang telah kami ekstrak ke C:\tools\ffmpeg sebelumnya.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan bentuk smile dan kemudian animasikan.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Konfigurasikan folder binary ffmpeg. Lihat halaman ini: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konversi frame menjadi video webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Efek Video**

Ketika mengonversi presentasi PowerPoint ke video menggunakan Aspose.Slides untuk .NET, Anda dapat menerapkan berbagai efek video untuk meningkatkan kualitas visual output. Efek-efek ini memungkinkan Anda mengontrol tampilan slide dalam video akhir dengan menambahkan transisi halus, animasi, dan elemen visual lainnya. Bagian ini menjelaskan opsi efek video yang tersedia dan menunjukkan cara menerapkannya.

{{% alert color="primary" %}} 
Lihat:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/id/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/id/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/id/net/shape-effect/)
{{% /alert %}} 

Animasi dan transisi membuat slideshow lebih menarik dan menarik — dan hal yang sama berlaku untuk video. Mari tambahkan slide lain dan transisi ke kode untuk presentasi sebelumnya:
```c#
// Tambahkan bentuk smile dan animasikan.
// ...

// Tambahkan slide baru dan transisi animasi.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides juga mendukung animasi teks. Dalam contoh ini, kami menganimasikan paragraf pada objek sehingga mereka muncul satu per satu, dengan jeda satu detik di antara mereka:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan teks dan animasi.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Konfigurasikan folder binary ffmpeg. Lihat halaman ini: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konversi frame menjadi video webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Kelas Konversi Video**

Untuk memungkinkan tugas konversi PowerPoint ke video, Aspose.Slides untuk .NET menyediakan kelas [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/net/aspose.slides.export/presentationanimationsgenerator/) dan [PresentationPlayer](https://reference.aspose.com/slides/id/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` memungkinkan Anda mengatur ukuran frame untuk video (yang akan dibuat nanti) dan nilai FPS (frame per detik) melalui konstruktornya. Jika Anda memberikan instance presentasi, `Presentation.SlideSize`‑nya akan digunakan dan ia menghasilkan animasi yang digunakan oleh [PresentationPlayer](https://reference.aspose.com/slides/id/net/aspose.slides.export/presentationplayer/).

Ketika animasi dihasilkan, peristiwa `NewAnimation` dipicu untuk setiap animasi berikutnya, yang menyertakan parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipresentationanimationplayer/). Kelas ini mewakili pemutar untuk satu animasi.

Untuk bekerja dengan [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipresentationanimationplayer/), Anda menggunakan properti [Duration](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipresentationanimationplayer/duration/) (yang memberikan durasi penuh animasi) dan metode [SetTimePosition](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Setiap posisi animasi diatur dalam rentang *0 sampai duration*, dan metode `GetFrame` kemudian mengembalikan Bitmap yang mewakili keadaan animasi pada titik waktu tersebut.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan bentuk smile dan animasikan.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // Keadaan animasi awal.
            Bitmap bitmap = animationPlayer.GetFrame();  // Bitmap keadaan animasi awal.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Keadaan akhir animasi.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Frame terakhir animasi.
            lastBitmap.Save("last.png");
        };
    }
}
```

Untuk membuat semua animasi dalam sebuah presentasi diputar sekaligus, kelas [PresentationPlayer](https://reference.aspose.com/slides/id/net/aspose.slides.export/presentationplayer/) digunakan. Kelas ini menerima instance [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/net/aspose.slides.export/presentationanimationsgenerator/) dan nilai FPS untuk efek dalam konstruktornya, lalu memanggil peristiwa `FrameTick` untuk semua animasi agar diputar:
```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

Kemudian frame yang dihasilkan dapat dikompilasi menjadi video. Lihat bagian [Convert a PowerPoint Presentation to Video](/slides/id/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Animasi dan Efek yang Didukung**

Ketika mengonversi presentasi PowerPoint ke video menggunakan Aspose.Slides untuk .NET, penting untuk memahami animasi dan efek mana yang didukung dalam output. Aspose.Slides mendukung berbagai efek masuk, keluar, dan penekanan umum seperti fade, fly in, zoom, dan spin. Namun, beberapa animasi lanjutan atau kustom mungkin tidak sepenuhnya dipertahankan atau muncul berbeda dalam video akhir. Bagian ini merangkum animasi dan efek yang didukung.

**Entrance**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Emphasis**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Exit**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Motion Paths**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Efek Transisi Slide yang Didukung**

Efek transisi slide berperan penting dalam menciptakan perubahan yang halus dan menarik secara visual antara slide dalam video. Aspose.Slides untuk .NET mendukung berbagai efek transisi yang umum digunakan untuk membantu mempertahankan alur dan gaya presentasi asli Anda. Bagian ini menyoroti efek transisi mana yang didukung selama proses konversi.

**Halus**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Menarik**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Konten Dinamis**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Apakah memungkinkan mengonversi presentasi yang dilindungi kata sandi?**

Ya, Aspose.Slides untuk .NET memungkinkan bekerja dengan presentasi yang dilindungi kata sandi. Saat memproses file semacam itu, Anda perlu menyediakan kata sandi yang benar agar perpustakaan dapat mengakses konten presentasi.

**Apakah Aspose.Slides untuk .NET mendukung penggunaan dalam solusi cloud?**

Ya, Aspose.Slides untuk .NET dapat diintegrasikan ke dalam aplikasi dan layanan cloud. Perpustakaan ini dirancang untuk bekerja di lingkungan server, memastikan kinerja tinggi dan skalabilitas untuk pemrosesan batch file.

**Apakah ada batasan ukuran untuk presentasi selama konversi?**

Aspose.Slides untuk .NET mampu menangani presentasi dengan ukuran apa pun secara praktis. Namun, saat bekerja dengan file yang sangat besar, sumber daya sistem tambahan mungkin diperlukan, dan seringkali disarankan untuk mengoptimalkan presentasi guna meningkatkan kinerja.