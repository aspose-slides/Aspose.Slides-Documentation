---
title: Mengonversi Presentasi PowerPoint ke Video di Android
linktitle: PowerPoint ke Video
type: docs
weight: 130
url: /id/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengonversi presentasi PowerPoint ke video dalam Java. Temukan contoh kode dan teknik otomatisasi untuk menyederhanakan alur kerja Anda."
---
## **Pendahuluan**

Dengan mengonversi presentasi PowerPoint Anda ke video, Anda mendapatkan 

* **Peningkatan aksesibilitas:** Semua perangkat (tanpa memandang platform) dilengkapi dengan pemutar video secara default dibandingkan aplikasi pembuka presentasi, sehingga pengguna lebih mudah membuka atau memutar video.
* **Jangkauan lebih luas:** Dengan video, Anda dapat menjangkau audiens besar dan menyasar mereka dengan informasi yang mungkin terasa membosankan dalam presentasi. Sebagian besar survei dan statistik menunjukkan bahwa orang menonton dan mengonsumsi video lebih banyak daripada bentuk konten lain, dan mereka umumnya lebih menyukai konten tersebut.

{{% alert color="primary" %}} 

Anda mungkin ingin memeriksa [**Pengonversi PowerPoint ke Video Online**](https://products.aspose.app/slides/id/conversion/ppt-to-word) karena itu merupakan implementasi langsung dan efektif dari proses yang dijelaskan di sini.

{{% /alert %}} 

## **Konversi PowerPoint ke Video di Aspose.Slides**

Aspose.Slides mendukung konversi presentasi ke video.

* Gunakan **Aspose.Slides** untuk menghasilkan sekumpulan frame (dari slide presentasi) yang sesuai dengan FPS tertentu (frame per detik).
* Gunakan utilitas pihak ketiga seperti **ffmpeg** ([untuk java](https://github.com/bramp/ffmpeg-cli-wrapper)) untuk membuat video berbasis frame. 

### **Konversi PowerPoint ke Video**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Download ffmpeg [di sini](https://ffmpeg.org/download.html).

4. Jalankan kode Java untuk mengonversi PowerPoint ke video.

Kode Java ini menunjukkan cara mengonversi presentasi (yang berisi gambar dan dua efek animasi) menjadi video:

```java
Presentation presentation = new Presentation();
try {
    // Menambahkan shape senyum dan kemudian menganimasinya
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Konfigurasikan folder binari ffmpeg. Lihat halaman ini: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Efek Video**

Anda dapat menerapkan animasi pada objek di slide dan menggunakan transisi antar slide. 

{{% alert color="primary" %}} 

Anda mungkin ingin melihat artikel-artikel berikut: [Animasi PowerPoint](https://docs.aspose.com/slides/id/androidjava/powerpoint-animation/), [Animasi Bentuk](https://docs.aspose.com/slides/id/androidjava/shape-animation/), dan [Efek Bentuk](https://docs.aspose.com/slides/id/androidjava/shape-effect/).

{{% /alert %}} 

Animasi dan transisi membuat slideshow lebih menarik dan menyenangkan—dan mereka melakukan hal yang sama untuk video. Mari tambahkan slide dan transisi lain ke kode untuk presentasi sebelumnya:

```java
// Menambahkan shape senyum dan menganimasinya

// ...

// Menambahkan slide baru dan transisi yang dianimasikan

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides juga mendukung animasi untuk teks. Jadi kami menganimasikan paragraf pada objek, yang akan muncul satu demi satu (dengan jeda satu detik):

```java
Presentation presentation = new Presentation();
try {
    // Menambahkan teks dan animasi
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Konfigurasikan folder binari ffmpeg. Lihat halaman ini: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Kelas Konversi Video**

Untuk memungkinkan Anda melakukan tugas konversi PowerPoint ke video, Aspose.Slides menyediakan kelas [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationanimationsgenerator/) dan [PresentationPlayer](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationanimationsgenerator/) memungkinkan Anda mengatur ukuran frame untuk video (yang akan dibuat nanti) melalui konstruktornya. Jika Anda memberikan instance presentasi, `Presentation.SlideSize` akan digunakan dan ia menghasilkan animasi yang dipakai oleh [PresentationPlayer](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationplayer/).

Ketika animasi dihasilkan, sebuah peristiwa `NewAnimation` dibuat untuk setiap animasi berikutnya, yang memiliki parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationanimationplayer/). Yang terakhir adalah kelas yang mewakili pemutar untuk animasi terpisah.

Untuk bekerja dengan [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationanimationplayer/), properti [Duration](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (durasi penuh animasi) dan metode [SetTimePosition](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) digunakan. Setiap posisi animasi diatur dalam rentang *0 hingga durasi*, dan kemudian metode `GetFrame` akan mengembalikan BufferedImage yang sesuai dengan keadaan animasi pada saat itu:

```java
Presentation presentation = new Presentation();
try {
    // Menambahkan shape senyum dan menganimasinya
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // status animasi awal
            try {
                // bitmap status animasi awal
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // status akhir animasi
            try {
                // frame terakhir animasi
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Untuk membuat semua animasi dalam sebuah presentasi diputar bersamaan, kelas [PresentationPlayer](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationplayer/) digunakan. Kelas ini mengambil instance [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationanimationsgenerator/) dan FPS untuk efek dalam konstruktornya, kemudian memanggil peristiwa `FrameTick` untuk semua animasi agar diputar:

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Kemudian frame yang dihasilkan dapat dikompilasi menjadi video. Lihat bagian [Konversi PowerPoint ke Video](https://docs.aspose.com/slides/id/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animasi dan Efek yang Didukung**

**Masuk**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Fade** | ![didukung](v.png) | ![didukung](v.png) |
| **Fly In** | ![didukung](v.png) | ![didukung](v.png) |
| **Float In** | ![didukung](v.png) | ![didukung](v.png) |
| **Split** | ![didukung](v.png) | ![didukung](v.png) |
| **Wipe** | ![didukung](v.png) | ![didukung](v.png) |
| **Shape** | ![didukung](v.png) | ![didukung](v.png) |
| **Wheel** | ![didukung](v.png) | ![didukung](v.png) |
| **Random Bars** | ![didukung](v.png) | ![didukung](v.png) |
| **Grow & Turn** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Zoom** | ![didukung](v.png) | ![didukung](v.png) |
| **Swivel** | ![didukung](v.png) | ![didukung](v.png) |
| **Bounce** | ![didukung](v.png) | ![didukung](v.png) |

**Penekanan**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Color Pulse** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Teeter** | ![didukung](v.png) | ![didukung](v.png) |
| **Spin** | ![didukung](v.png) | ![didukung](v.png) |
| **Grow/Shrink** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Desaturate** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Darken** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Lighten** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Transparency** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Object Color** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Complementary Color** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Line Color** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Fill Color** | ![tidak didukung](x.png) | ![didukung](v.png) |

**Keluar**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Fade** | ![didukung](v.png) | ![didukung](v.png) |
| **Fly Out** | ![didukung](v.png) | ![didukung](v.png) |
| **Float Out** | ![didukung](v.png) | ![didukung](v.png) |
| **Split** | ![didukung](v.png) | ![didukung](v.png) |
| **Wipe** | ![didukung](v.png) | ![didukung](v.png) |
| **Shape** | ![didukung](v.png) | ![didukung](v.png) |
| **Random Bars** | ![didukung](v.png) | ![didukung](v.png) |
| **Shrink & Turn** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Zoom** | ![didukung](v.png) | ![didukung](v.png) |
| **Swivel** | ![didukung](v.png) | ![didukung](v.png) |
| **Bounce** | ![didukung](v.png) | ![didukung](v.png) |

**Jalur Gerakan**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![didukung](v.png) | ![didukung](v.png) |
| **Arcs** | ![didukung](v.png) | ![didukung](v.png) |
| **Turns** | ![didukung](v.png) | ![didukung](v.png) |
| **Shapes** | ![didukung](v.png) | ![didukung](v.png) |
| **Loops** | ![didukung](v.png) | ![didukung](v.png) |
| **Custom Path** | ![didukung](v.png) | ![didukung](v.png) |

## **FAQ**

**Apakah memungkinkan mengonversi presentasi yang dilindungi password?**

Ya, Aspose.Slides memungkinkan bekerja dengan [presentasi yang dilindungi password](/slides/id/androidjava/password-protected-presentation/). Saat memproses file tersebut, Anda perlu memberikan password yang benar agar perpustakaan dapat mengakses konten presentasi.

**Apakah Aspose.Slides mendukung penggunaan dalam solusi cloud?**

Ya, Aspose.Slides dapat diintegrasikan ke dalam aplikasi dan layanan cloud. Perpustakaan ini dirancang untuk bekerja di lingkungan server, memastikan kinerja tinggi dan skalabilitas untuk pemrosesan batch file.

**Apakah ada batasan ukuran untuk presentasi selama konversi?**

Aspose.Slides mampu menangani presentasi dengan ukuran apa pun secara praktis. Namun, saat bekerja dengan file yang sangat besar, sumber daya sistem tambahan mungkin diperlukan, dan terkadang disarankan untuk mengoptimalkan presentasi guna meningkatkan kinerja.