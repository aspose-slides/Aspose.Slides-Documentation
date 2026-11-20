---
title: Mengelola Frame Video dalam Presentasi Menggunakan Node.js
linktitle: Frame Video
type: docs
weight: 10
url: /id/nodejs-java/video-frame/
keywords:
- menambahkan video
- membuat video
- menyematkan video
- mengekstrak video
- mengambil video
- frame video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak frame video secara programatis dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java. Panduan cara cepat."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide dan melibatkan audiens. Aspose.Slides untuk Node.js via Java memungkinkan Anda menambahkan frame video ke slide, mengatur pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang disematkan.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan frame video, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) kelas [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) dan tipe terkait lainnya.

## **Buat Frame Video yang Disematkan**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat frame video untuk menyematkan video dalam presentasi Anda.

Contoh ini menyematkan video lokal pada slide pertama dari presentasi yang ada dan menyimpan hasilnya. Koordinat dan dimensi frame dalam satuan poin. Stream tetap terbuka sampai penyimpanan selesai karena [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) menguncinya selama presentasi menggunakannya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Anda juga dapat memberikan jalur video lokal secara langsung ke [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Contoh ini menyematkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Buat Frame Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Anda dapat membuat frame video yang menautkan ke video daring, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti identifier video untuk menggunakan video lain. Metode [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video daring.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Putar Video dalam Mode Layar Penuh**

Dalam presentasi pelatihan, Anda dapat memutar demonstrasi perangkat lunak dalam mode layar penuh sehingga audiens dapat melihat detailnya. Panggil [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) dengan `true` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka presentasi, menemukan [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi masukan harus berisi setidaknya satu slide dengan frame video yang ada pada slide pertama.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pemutaran layar penuh mengatur cara video ditampilkan. Secara terpisah, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) mengontrol apakah video dimulai secara otomatis atau saat diklik, dan [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) mengontrol apakah video diulang. Untuk memilih perilaku mulai, atur mode pemutaran ke [VideoPlayModePreset.Auto atau VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan mulai dan pengulangan yang ada.

## **Mundurkan Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awal membuatnya siap diputar kembali oleh presenter. Panggil [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) dengan `true` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka presentasi, menemukan [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) pertama pada slide pertama, dan mengaktifkan pemulangan. Ia menonaktifkan pengulangan sehingga pemutaran dapat selesai dan mengatur pemutaran untuk dimulai saat diklik. Presentasi masukan harus memiliki setidaknya satu slide dengan frame video yang ada pada slide pertama.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pemulangan mengembalikan video ke awal tanpa memulai kembali. Sebaliknya, memanggil [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) dengan `true` mengulangi pemutaran secara otomatis. Biarkan pengulangan dinonaktifkan ketika Anda ingin video selesai dan tetap siap diputar ulang. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) secara terpisah mengontrol pemutaran otomatis atau saat diklik; contoh ini menggunakan [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) sehingga presenter mengendalikan kapan pemutaran dimulai. Atur mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Pemulangan berfungsi terlepas dari [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Memangkas Frame Video**

Gunakan [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) dan [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) untuk melewati bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemangkasan mengubah pengaturan pemutaran tanpa memodifikasi data video yang disematkan.

**Setel Pengaturan Pemangkasan**

Contoh ini menyematkan video lokal dan melewati 2,5 detik pertama serta 1 detik terakhir selama pemutaran. Gunakan video yang lebih panjang dari 3,5 detik agar tetap ada segmen yang dapat diputar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Baca Pengaturan Pemangkasan**

Contoh ini mencetak nilai pemangkasan dari frame video pertama pada slide pertama dalam milidetik. Presentasi harus memiliki setidaknya satu slide. Jika slide tersebut tidak memiliki frame video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk frame video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

### **Tambahkan Caption ke Frame Video**

Contoh ini menyematkan video lokal dan menambahkan trek caption WebVTT berlabel English. Timestamp caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan captionnya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) juga menyediakan metode [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) untuk menambahkan caption dari sebuah stream.

### **Ekstrak Caption dari Frame Video**

Contoh ini menyimpan semua trek caption dari frame video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga file output tetap berbeda. Konsol melaporkan jumlah trek yang diekstrak. Presentasi harus memiliki setidaknya satu slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Setiap objek [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF-8.

### **Hapus Caption dari Frame Video**

Contoh ini menghapus semua caption dari frame video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Asumsinya slide dan shape ada serta shape tersebut adalah sebuah frame video.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) alih-alih [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

### **Cari Caption Video**

Metode [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) mengembalikan seluruh trek WebVTT, termasuk header, baris timing, dan teks caption. Anda dapat mencari teks caption di memori untuk menemukan frasa dan timestamp-nya. Misalnya, trek English pada slide 2 mungkin berisi cue berikut:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Contoh ini membuka `captioned_media.pptx` dan menggunakan [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) untuk membaca trek setiap frame video tingkat atas pada setiap slide. Dalam cue teks biasa, baris timing berisi `-->`, dan baris kosong mengakhiri cue. Untuk setiap caption yang berisi “café” dalam huruf apapun, contoh ini mencetak nomor slide, label trek, baris timing asli, dan caption lengkap.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mencari “café” menemukan satu kecocokan pada trek contoh. Pencarian melewati header trek dan mempertahankan pengaturan timing serta pemisah baris pada output.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

Contoh ini mengekstrak video yang disematkan dari setiap slide ke dalam file biner terpisah yang diberi nomor. Video yang ditautkan diabaikan karena tidak memiliki data yang disematkan. Konsol mencetak tipe MIME setiap video dan jumlah totalnya. Output menggunakan ekstensi umum `.bin`; ubah sesuai tipe media yang dilaporkan bila diperlukan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk sebuah frame video?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto atau saat klik) dan [pengulangan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Opsi-opsi ini tersedia melalui metode objek [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Saat Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Saat Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam frame video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) di dalam frame sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Bisakah tipe konten (MIME) video yang disematkan diketahui?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.