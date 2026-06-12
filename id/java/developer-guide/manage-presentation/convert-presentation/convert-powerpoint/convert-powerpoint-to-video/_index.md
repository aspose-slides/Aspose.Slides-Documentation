---
title: Mengonversi Presentasi PowerPoint ke Video dalam Java
linktitle: PowerPoint ke Video
type: docs
weight: 130
url: /id/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Pelajari cara mengonversi presentasi PowerPoint ke video dalam Java. Temukan contoh kode dan teknik otomatisasi untuk menyederhanakan alur kerja Anda."
---
## **Pendahuluan**

Dengan mengonversi presentasi PowerPoint atau OpenDocument Anda ke video, Anda memperoleh:

**Aksesibilitas yang meningkat:** Semua perangkat, terlepas dari platformnya, dilengkapi pemutar video secara default, sehingga lebih mudah bagi pengguna untuk membuka atau memutar video dibandingkan aplikasi presentasi tradisional.

**Jangkauan lebih luas:** Video memungkinkan Anda menjangkau audiens yang lebih besar dan menyajikan informasi dalam format yang lebih menarik. Survei dan statistik menunjukkan bahwa orang lebih suka menonton dan mengonsumsi konten video dibandingkan bentuk lainnya, sehingga pesan Anda menjadi lebih berdampak.

{{% alert color="primary" %}} 
Anda mungkin ingin memeriksa [**PowerPoint ke Video Pengonversi Online**](https://products.aspose.app/slides/id/conversion/ppt-to-word) karena itu merupakan implementasi langsung dan efektif dari proses yang dijelaskan di sini.
{{% /alert %}} 

## **Konversi PowerPoint ke Video di Aspose.Slides**

Dalam [Aspose.Slides 22.11](https://docs.aspose.com/slides/id/java/aspose-slides-for-java-22-11-release-notes/), kami menambahkan dukungan untuk konversi presentasi ke video. 

* Gunakan **Aspose.Slides** untuk menghasilkan sekumpulan frame (dari slide presentasi) yang sesuai dengan FPS (frame per detik) tertentu
* Gunakan utilitas pihak ketiga seperti **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) untuk membuat video berdasarkan frame-frame tersebut. 

### **Konversi PowerPoint ke Video**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Unduh ffmpeg [di sini](https://ffmpeg.org/download.html).

4. Jalankan kode Java PowerPoint ke video.

Kode Java ini menunjukkan cara mengonversi sebuah presentasi (yang berisi gambar dan dua efek animasi) menjadi video:
```java
Presentation presentation = new Presentation();
try {
    // Menambahkan bentuk senyum dan kemudian memberi animasi padanya
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

    // Mengonfigurasi folder binari ffmpeg. Lihat halaman ini: https://github.com/rosenbjerg/FFMpegCore#installation
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
Anda mungkin ingin melihat artikel-artikel ini: [Animasi PowerPoint](https://docs.aspose.com/slides/id/java/powerpoint-animation/), [Animasi Bentuk](https://docs.aspose.com/slides/id/java/shape-animation/), dan [Efek Bentuk](https://docs.aspose.com/slides/id/java/shape-effect/).
{{% /alert %}} 

Animasi dan transisi membuat pertunjukan slide lebih menarik dan menarik—dan mereka melakukan hal yang sama untuk video. Mari tambahkan slide lain dan transisi ke kode untuk presentasi sebelumnya:
```java
// Menambahkan bentuk senyum dan memberi animasi padanya

// ...

// Menambahkan slide baru dan transisi animasi

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides juga mendukung animasi untuk teks. Jadi kami memberi animasi pada paragraf pada objek, yang akan muncul satu per satu (dengan jeda diatur satu detik):
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

    // Mengonfigurasi folder binari ffmpeg. Lihat halaman ini: https://github.com/rosenbjerg/FFMpegCore#installation
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

Untuk memungkinkan Anda melakukan tugas konversi PowerPoint ke video, Aspose.Slides menyediakan kelas [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationanimationsgenerator/) dan [PresentationPlayer](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationplayer/). 

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationanimationsgenerator/) memungkinkan Anda mengatur ukuran frame untuk video (yang akan dibuat nanti) melalui konstruktornya. Jika Anda memberikan instance presentasi, `Presentation.SlideSize` akan digunakan dan ia menghasilkan animasi yang digunakan oleh [PresentationPlayer](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationplayer/). 

Ketika animasi dihasilkan, sebuah peristiwa `NewAnimation` dihasilkan untuk setiap animasi berikutnya, yang memiliki parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationanimationplayer/). Yang terakhir adalah kelas yang mewakili pemutar untuk animasi terpisah.

Untuk bekerja dengan [IPresentationAnimationPlayer](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationanimationplayer/), properti [Duration](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (durasi penuh animasi) dan metode [SetTimePosition](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) digunakan. Setiap posisi animasi diatur dalam rentang *0 hingga duration*, dan kemudian metode `GetFrame` akan mengembalikan BufferedImage yang sesuai dengan keadaan animasi pada saat itu:
```java
Presentation presentation = new Presentation();
try {
    // Menambahkan bentuk senyum dan memberi animasi padanya
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
            animationPlayer.setTimePosition(0); // keadaan animasi awal
            try {
                // bitmap keadaan animasi awal
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // keadaan akhir animasi
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

Untuk membuat semua animasi dalam sebuah presentasi diputar sekaligus, kelas [PresentationPlayer](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationplayer/) digunakan. Kelas ini mengambil instance [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationanimationsgenerator/) dan FPS untuk efek dalam konstruktornya, lalu memanggil peristiwa `FrameTick` untuk semua animasi agar diputar:
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

Kemudian frame yang dihasilkan dapat dikompilasi menjadi video. Lihat bagian [Convert PowerPoint to Video](https://docs.aspose.com/slides/id/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animasi dan Efek yang Didukung**

**Masuk**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
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

**Penekanan**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
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

**Keluar**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
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

**Jalur Gerak**:

| Tipe Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Apakah memungkinkan untuk mengonversi presentasi yang dilindungi kata sandi?**

Ya, Aspose.Slides memungkinkan bekerja dengan [presentasi yang dilindungi kata sandi](/slides/id/java/password-protected-presentation/). Saat memproses file semacam itu, Anda harus memberikan kata sandi yang benar agar perpustakaan dapat mengakses konten presentasi.

**Apakah Aspose.Slides mendukung penggunaan dalam solusi cloud?**

Ya, Aspose.Slides dapat diintegrasikan ke dalam aplikasi dan layanan cloud. Perpustakaan ini dirancang untuk bekerja di lingkungan server, memastikan kinerja tinggi dan skalabilitas untuk pemrosesan batch file.

**Apakah ada batasan ukuran untuk presentasi saat konversi?**

Aspose.Slides mampu menangani presentasi dengan ukuran apa pun secara praktis. Namun, saat bekerja dengan file yang sangat besar, mungkin diperlukan sumber daya sistem tambahan, dan terkadang disarankan untuk mengoptimalkan presentasi guna meningkatkan kinerja.