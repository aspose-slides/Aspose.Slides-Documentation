---
title: Kelola Audio dalam Presentasi Menggunakan JavaScript
linktitle: Kerangka Audio
type: docs
weight: 10
url: /id/nodejs-java/audio-frame/
keywords:
- audio
- kerangka audio
- miniatur
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan kendalikan kerangka audio di Aspose.Slides untuk Node.js—contoh untuk menyematkan, memotong, mengulang, dan mengonfigurasi pemutaran pada presentasi PPT, PPTX, dan ODP."
---
## **Overview**

Artikel ini menjelaskan cara bekerja dengan audio frame di Aspose.Slides. Artikel ini menunjukkan cara menambahkan audio tersemat ke slide, menyesuaikan thumbnail audio frame, mengonfigurasi opsi pemutaran seperti volume, pengulangan, penyembunyian, pemotongan, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi tayangan slide.

## **Create Audio Frames**

Aspose.Slides for Node.js via Java memungkinkan Anda menambahkan file audio ke slide. File audio tersebut disematkan dalam slide sebagai audio frame.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Muat aliran file audio yang ingin Anda sematkan ke dalam slide.
4. Tambahkan audio frame yang disematkan (yang berisi file audio) ke slide.
5. Atur [PlayMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AudioPlayModePreset) dan `Volume` yang disediakan oleh objek [AudioFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AudioFrame).
6. Simpan presentasi yang telah dimodifikasi.

Kode JavaScript berikut menunjukkan cara menambahkan audio frame yang disematkan ke slide:

```javascript
// Membuat instance kelas Presentation yang mewakili file presentasi
const pres = new aspose.slides.Presentation();
try {
    // Mengambil slide pertama
    const sld = pres.getSlides().get_Item(0);
    // Memuat file wav ke stream
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Menambahkan Audio Frame
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Mengatur Mode Putar dan Volume Audio
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Menulis file PowerPoint ke disk
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Change Audio Frame Thumbnail**

Saat Anda menambahkan file audio ke presentasi, audio muncul sebagai frame dengan gambar default standar (lihat gambar pada bagian di bawah). Anda dapat mengubah gambar pratinjau frame audio (atur gambar yang Anda inginkan).

Kode JavaScript berikut menunjukkan cara mengubah thumbnail atau gambar pratinjau audio frame:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Menambahkan audio frame ke slide dengan posisi dan ukuran yang ditentukan.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Menambahkan gambar ke sumber daya presentasi.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Mengatur gambar untuk audio frame.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Menyimpan presentasi yang dimodifikasi ke disk
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Change Audio Play Options**

Aspose.Slides for Node.js via Java memungkinkan Anda mengubah opsi yang mengendalikan pemutaran atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio untuk diputar berulang, atau bahkan menyembunyikan ikon audio.

Panel **Audio Options** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opsi **Audio** di PowerPoint yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/) adalah:
- **Start** drop-down list cocok dengan metode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** cocok dengan metode [AudioFrame.setVolume](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** cocok dengan metode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** cocok dengan metode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** cocok dengan metode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** cocok dengan metode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setRewindAudio).

Opsi **Editing** di PowerPoint yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/) adalah:
- **Fade In** cocok dengan metode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** cocok dengan metode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** cocok dengan metode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setTrimFromStart).
- **Trim Audio End Time** nilai sama dengan durasi audio dikurangi nilai metode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd).

Kontrol **Volume** pada panel kontrol audio di PowerPoint sesuai dengan metode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Kontrol ini memungkinkan Anda mengubah volume audio dalam persentase.

Berikut cara mengubah opsi Pemutaran Audio:
1. [Buat](#create-audio-frame) atau dapatkan Audio Frame.
2. Atur nilai baru untuk properti Audio Frame yang ingin Anda ubah.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode JavaScript berikut mendemonstrasikan operasi di mana opsi audio disesuaikan:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Mengambil bentuk AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Mengatur mode Putar menjadi diputar saat klik
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Mengatur volume menjadi Rendah
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Mengatur audio untuk diputar di seluruh slide
    audioFrame.setPlayAcrossSlides(true);
    // Menonaktifkan pengulangan untuk audio
    audioFrame.setPlayLoopMode(false);
    // Menyembunyikan AudioFrame selama pertunjukan slide
    audioFrame.setHideAtShowing(true);
    // Memundurkan audio ke awal setelah diputar
    audioFrame.setRewindAudio(true);
    // Menyimpan file PowerPoint ke disk
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Contoh JavaScript ini menunjukkan cara menambahkan audio frame baru dengan audio tersemat, memotongnya, dan mengatur durasi fade:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Menetapkan offset pemotongan awal ke 1,5 detik
    audioFrame.setTrimFromStart(1500);
    // Menetapkan offset pemotongan akhir ke 2 detik
    audioFrame.setTrimFromEnd(2000);

    // Menetapkan durasi fade-in ke 200 ms
    audioFrame.setFadeInDuration(200);
    // Menetapkan durasi fade-out ke 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Contoh kode berikut menunjukkan cara mengambil audio frame dengan audio tersemat dan mengatur volumenya menjadi 85%:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Mengambil bentuk audio frame
    const audioFrame = slide.getShapes().get_Item(0);

    // Mengatur volume audio menjadi 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Manage Audio Captions**

Aspose.Slides memungkinkan Anda menambahkan teks tertutup (closed captions) ke audio frame melalui metode [getCaptionTracks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Metode ini mengembalikan sebuah [CaptionsCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/), yang memungkinkan Anda menambahkan trek caption WebVTT, mengiterasi trek yang ada, dan menghapusnya bila diperlukan.

**Add Audio Captions**

Gunakan metode [getCaptionTracks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) untuk melampirkan satu atau lebih trek caption ke audio frame. Pada contoh berikut, file audio ditambahkan ke slide, lalu trek caption baru dimuat dari file `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Tambah trek caption baru dari file WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extract Audio Captions**

Anda dapat mengiterasi trek caption yang terkait dengan audio frame dan menyimpannya sebagai file `.vtt`. Setiap trek caption menyediakan data biner dan pengidentifikasi unik, yang dapat digunakan saat mengekspor caption.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Simpan trek caption sebagai file .vtt.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Remove Audio Captions**

Untuk menghapus caption dari audio frame, gunakan metode yang disediakan oleh [CaptionsCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/), seperti [clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/#remove), atau [removeAt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/#removeAt). Contoh berikut menghapus semua trek caption dari audio frame.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // tipe: aspose.slides.AudioFrame

    // Hapus semua trek caption dari audio frame.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extract Audio**

Aspose.Slides for Node.js via Java memungkinkan Anda mengekstrak suara yang digunakan dalam transisi tayangan slide. Misalnya, Anda dapat mengekstrak suara yang digunakan pada slide tertentu.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dan muat presentasi yang berisi audio.
2. Dapatkan referensi slide yang relevan melalui indeksnya.
3. Akses [slideshow transitions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) untuk slide tersebut.
4. Ekstrak suara dalam bentuk data byte.

Kode JavaScript berikut menunjukkan cara mengekstrak audio yang digunakan pada slide:

```javascript
// Membuat instance kelas Presentation yang mewakili file presentasi
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Mengakses slide yang diinginkan
    const slide = pres.getSlides().get_Item(0);
    // Mengambil efek transisi tayangan slide untuk slide tersebut
    const transition = slide.getSlideShowTransition();
    // Mengestrak suara dalam array byte
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat menggunakan kembali aset audio yang sama di beberapa slide tanpa memperbesar ukuran file?**

Ya. Tambahkan audio sekali ke presentasi’s shared [audio collection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getaudios/) dan buat audio frame tambahan yang merujuk ke aset yang sudah ada. Ini mencegah duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara dalam audio frame yang ada tanpa membuat ulang shape?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) sehingga mengarah ke file baru. Untuk suara yang tersemat, ganti objek [embedded audio](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) dengan yang lain dari presentasi’s [audio collection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getaudios/). Formatting frame dan sebagian besar pengaturan pemutaran tetap tidak berubah.

**Apakah pemotongan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemotongan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak tersentuh dan dapat diakses melalui audio tersemat atau audio collection presentasi.