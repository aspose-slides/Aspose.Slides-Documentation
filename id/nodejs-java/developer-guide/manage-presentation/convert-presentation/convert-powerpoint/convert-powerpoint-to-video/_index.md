---
title: Mengonversi Presentasi PowerPoint ke Video dengan JavaScript
linktitle: PowerPoint ke Video
type: docs
weight: 130
url: /id/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengonversi presentasi PowerPoint ke video menggunakan JavaScript. Temukan contoh kode dan teknik otomasi untuk menyederhanakan alur kerja Anda."
---
## **Pendahuluan**

Dengan mengonversi presentasi PowerPoint Anda menjadi video, Anda mendapatkan 

* **Peningkatan aksesibilitas:** Semua perangkat (tanpa memandang platform) dilengkapi pemutar video secara bawaan dibandingkan dengan aplikasi pembuka presentasi, sehingga pengguna lebih mudah membuka atau memutar video.
* **Jangkauan lebih luas:** Melalui video, Anda dapat menjangkau audiens yang besar dan menargetkan mereka dengan informasi yang mungkin terasa membosankan dalam presentasi. Sebagian besar survei dan statistik menunjukkan bahwa orang menonton dan mengonsumsi video lebih banyak daripada bentuk konten lain, dan mereka umumnya lebih menyukai konten tersebut.

{{% alert color="primary" %}} 
Anda mungkin ingin memeriksa [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/id/conversion/ppt-to-word) karena ini adalah implementasi langsung dan efektif dari proses yang dijelaskan di sini.
{{% /alert %}} 

## **Konversi PowerPoint ke Video di Aspose.Slides**

Aspose.Slides mendukung konversi presentasi ke video.

* Gunakan **Aspose.Slides** untuk menghasilkan sekumpulan frame (dari slide presentasi) yang sesuai dengan FPS (frame per detik) tertentu
* Gunakan utilitas pihak ketiga seperti **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) untuk membuat video berdasarkan frame. 

### **Konversi PowerPoint ke Video**

1. Unduh ffmpeg [di sini](https://ffmpeg.org/download.html).
2. Jalankan kode JavaScript PowerPoint ke video.

Kode JavaScript ini menunjukkan cara mengonversi sebuah presentasi (yang berisi gambar dan dua efek animasi) menjadi video:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Menambahkan bentuk senyum dan kemudian menganimasikannya
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Konfigurasikan folder binari ffmpeg. Lihat halaman ini: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Efek Video**

Anda dapat menerapkan animasi pada objek di slide dan menggunakan transisi antar slide. 

{{% alert color="primary" %}} 
Anda mungkin ingin melihat artikel-artikel ini: [Animasi PowerPoint](https://docs.aspose.com/slides/id/nodejs-java/powerpoint-animation/), [Animasi Bentuk](https://docs.aspose.com/slides/id/nodejs-java/shape-animation/), dan [Efek Bentuk](https://docs.aspose.com/slides/id/nodejs-java/shape-effect/).
{{% /alert %}} 

Animasi dan transisi membuat slideshow lebih menarik dan menyenangkan—dan mereka melakukan hal yang sama untuk video. Mari tambahkan slide dan transisi lain ke kode untuk presentasi sebelumnya:

```javascript
// Menambahkan bentuk senyum dan menganimasikannya
// ...
// Menambahkan slide baru dan transisi yang dianimasikan
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides juga mendukung animasi untuk teks. Jadi kami menganimasikan paragraf pada objek, yang akan muncul satu per satu (dengan jeda satu detik):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Menambahkan teks dan animasi
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Konfigurasikan folder binari ffmpeg. Lihat halaman ini: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Kelas Konversi Video**

Untuk memungkinkan Anda melakukan tugas konversi PowerPoint ke video, Aspose.Slides menyediakan kelas [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationanimationsgenerator/) dan [PresentationPlayer](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationplayer/) .

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationanimationsgenerator/) memungkinkan Anda mengatur ukuran frame untuk video (yang akan dibuat kemudian) melalui konstruktor-nya. Jika Anda memberikan instance presentasi, `Presentation.getSlideSize` akan digunakan dan ia menghasilkan animasi yang digunakan oleh [PresentationPlayer](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationplayer/) .

Ketika animasi dihasilkan, sebuah peristiwa `NewAnimation` dihasilkan untuk setiap animasi berikutnya, yang memiliki parameter pemutar animasi presentasi. Yang terakhir adalah kelas yang mewakili pemutar untuk animasi terpisah.

Untuk bekerja dengan pemutar animasi presentasi, metode `getDuration` (durasi penuh animasi) dan metode `setTimePosition` digunakan. Setiap posisi animasi diatur dalam rentang *0 hingga durasi*, dan kemudian metode `getFrame` akan mengembalikan BufferedImage yang sesuai dengan keadaan animasi pada saat itu:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Menambahkan bentuk senyum dan menganimasinya
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// kondisi animasi awal
            try {
                // bitmap kondisi animasi awal
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// final state of the animation
            try {
                // frame terakhir animasi
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Untuk membuat semua animasi dalam sebuah presentasi diputar sekaligus, kelas [PresentationPlayer](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationplayer/) digunakan. Kelas ini mengambil instance [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationanimationsgenerator/) dan FPS untuk efek dalam konstruktor-nya, lalu memanggil peristiwa `FrameTick` untuk semua animasi agar diputar:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Kemudian frame yang dihasilkan dapat dikompilasi untuk membuat video. Lihat bagian [Konversi PowerPoint ke Video](https://docs.aspose.com/slides/id/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animasi dan Efek yang Didukung**

**Masuk**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Muncul** | ![not supported](x.png) | ![supported](v.png) |
| **Memudar** | ![supported](v.png) | ![supported](v.png) |
| **Terbang Masuk** | ![supported](v.png) | ![supported](v.png) |
| **Mengapung Masuk** | ![supported](v.png) | ![supported](v.png) |
| **Terbelah** | ![supported](v.png) | ![supported](v.png) |
| **Menyapu** | ![supported](v.png) | ![supported](v.png) |
| **Bentuk** | ![supported](v.png) | ![supported](v.png) |
| **Roda** | ![supported](v.png) | ![supported](v.png) |
| **Bar Acak** | ![supported](v.png) | ![supported](v.png) |
| **Tumbuh & Putar** | ![not supported](x.png) | ![supported](v.png) |
| **Zum** | ![supported](v.png) | ![supported](v.png) |
| **Berputar** | ![supported](v.png) | ![supported](v.png) |
| **Memantul** | ![supported](v.png) | ![supported](v.png) |

**Penekanan**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Nadi** | ![not supported](x.png) | ![supported](v.png) |
| **Nadi Warna** | ![not supported](x.png) | ![supported](v.png) |
| **Goangg** | ![supported](v.png) | ![supported](v.png) |
| **Berputar** | ![supported](v.png) | ![supported](v.png) |
| **Tumbuh/Menciut** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturasi** | ![not supported](x.png) | ![supported](v.png) |
| **Menggelapkan** | ![not supported](x.png) | ![supported](v.png) |
| **Mencerahkan** | ![not supported](x.png) | ![supported](v.png) |
| **Transparansi** | ![not supported](x.png) | ![supported](v.png) |
| **Warna Objek** | ![not supported](x.png) | ![supported](v.png) |
| **Warna Komplementer** | ![not supported](x.png) | ![supported](v.png) |
| **Warna Garis** | ![not supported](x.png) | ![supported](v.png) |
| **Warna Isi** | ![not supported](x.png) | ![supported](v.png) |

**Keluar**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Menghilang** | ![not supported](x.png) | ![supported](v.png) |
| **Memudar** | ![supported](v.png) | ![supported](v.png) |
| **Terbang Keluar** | ![supported](v.png) | ![supported](v.png) |
| **Mengapung Keluar** | ![supported](v.png) | ![supported](v.png) |
| **Terbelah** | ![supported](v.png) | ![supported](v.png) |
| **Menyapu** | ![supported](v.png) | ![supported](v.png) |
| **Bentuk** | ![supported](v.png) | ![supported](v.png) |
| **Bar Acak** | ![supported](v.png) | ![supported](v.png) |
| **Menciut & Putar** | ![not supported](x.png) | ![supported](v.png) |
| **Zum** | ![supported](v.png) | ![supported](v.png) |
| **Berputar** | ![supported](v.png) | ![supported](v.png) |
| **Memantul** | ![supported](v.png) | ![supported](v.png) |

**Jalur Gerak**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Garis** | ![supported](v.png) | ![supported](v.png) |
| **Busur** | ![supported](v.png) | ![supported](v.png) |
| **Belokan** | ![supported](v.png) | ![supported](v.png) |
| **Bentuk** | ![supported](v.png) | ![supported](v.png) |
| **Loop** | ![supported](v.png) | ![supported](v.png) |
| **Jalur Kustom** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Apakah memungkinkan mengonversi presentasi yang dilindungi kata sandi?**

Ya, Aspose.Slides memungkinkan bekerja dengan presentasi yang dilindungi kata sandi. Saat memproses file semacam itu, Anda perlu memberikan kata sandi yang benar agar perpustakaan dapat mengakses konten presentasi.

**Apakah Aspose.Slides mendukung penggunaan dalam solusi cloud?**

Ya, Aspose.Slides dapat diintegrasikan ke dalam aplikasi dan layanan cloud. Perpustakaan ini dirancang untuk bekerja di lingkungan server, memastikan kinerja tinggi dan skalabilitas untuk pemrosesan batch file.

**Apakah ada batasan ukuran untuk presentasi selama konversi?**

Aspose.Slides mampu menangani presentasi dengan ukuran apa pun secara virtual. Namun, saat bekerja dengan file yang sangat besar, sumber daya sistem tambahan mungkin diperlukan, dan terkadang disarankan untuk mengoptimalkan presentasi guna meningkatkan kinerja.