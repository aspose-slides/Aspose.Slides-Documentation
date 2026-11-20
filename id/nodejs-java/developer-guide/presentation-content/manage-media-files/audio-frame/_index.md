---
title: Kelola Audio Frame dalam Presentasi Menggunakan JavaScript
linktitle: Audio Frame
type: docs
weight: 10
url: /id/nodejs-java/audio-frame/
keywords:
- audio
- audio frame
- thumbnail
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Sematkan audio ke dalam slide, ubah ikon audio, konfigurasikan pemutaran, kelola caption WebVTT, dan ekstrak suara transisi slide dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Audio frame memungkinkan Anda memutar suara pada slide. Dengan Aspose.Slides untuk Node.js via Java, Anda dapat menyematkan klip audio, memilih gambar yang mewakilinya, menyesuaikan pemutaran, dan melampirkan caption. Anda juga dapat mengambil suara yang ditetapkan pada transisi slide.

## **Membuat Audio Frame**

Gunakan [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) untuk menyematkan klip audio lokal pada slide pertama. Dua koordinat pertama menempatkan frame pada slide, dan dua nilai berikutnya menentukan lebar dan tinggi frame, semua dalam poin. Contoh ini memanggil [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) untuk memulai klip secara otomatis dan memanggil [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) untuk memilih preset volume keras.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ubah Thumbnail Audio Frame**

Secara default, audio frame menampilkan ikon speaker. Untuk menampilkan thumbnail khusus, tambahkan gambar ke presentasi dengan [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) dan atur pada gambar frame dengan [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). Contoh ini menggunakan `eagle.jpeg` sebagai thumbnail untuk klip audio yang disematkan.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ubah Opsi Pemutaran Audio**

Kontrol **Audio Options** pada PowerPoint menentukan kapan klip dimulai, seberapa keras suaranya, dan bagaimana perilakunya selama presentasi slide.

![Kontrol Audio Options PowerPoint untuk audio frame](audio_frame_0.png)

| Kontrol PowerPoint | Aspose.Slides for Node.js via Java method |
| --- | --- |
| Mulai | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Preset volume | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Putar di Seluruh Slide | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Loop hingga Dihentikan | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Sembunyikan Selama Pertunjukan | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Putar Ulang Setelah Memutar | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Pemangkasan waktu mulai Audio | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Pemangkasan waktu akhir Audio | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Slider volume | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

Contoh ini menemukan audio frame pertama pada slide pertama, memanggil [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) untuk memulai pemutaran saat diklik, dan memilih preset volume rendah. Klip berlanjut melewati slide dengan looping dinonaktifkan. Ikon tetap tersembunyi selama pertunjukan, dan klip diputar ulang setelah pemutaran.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Untuk klip yang lebih lama dari 3,5 detik, contoh ini melewatkan 1,5 detik pertama dan 2 detik terakhir. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) mengambil durasi yang harus dihilangkan dari akhir klip. Untuk mendapatkan waktu akhir yang ditampilkan di PowerPoint, kurangi offset tersebut dari durasi penuh klip. Klip yang dipangkas melakukan fade in selama 200 milidetik dan fade out selama 500 milidetik. Semua empat metode menerima nilai dalam milidetik.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk mengatur volume pemutaran ke persentase tertentu, gunakan [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Contoh ini mengatur audio frame pertama pada slide pertama menjadi 85%.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Kelola Caption Audio**

Setiap audio frame menyediakan akses ke track caption‑nya melalui [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Gunakan koleksi tersebut untuk melampirkan caption WebVTT ke klip, mengekspor track yang ada, atau menghapusnya.

### **Tambahkan Caption Audio**

Contoh ini menyematkan klip audio pada slide pertama dan menggunakan [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) untuk melampirkan track WebVTT lokal. Argumen pertama menyediakan label track, dan argumen kedua mengidentifikasi file yang berisi caption berwaktu.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ekstrak Caption Audio**

Contoh ini mengekspor setiap track caption yang terlampir pada audio frame di slide pertama. Ia menulis byte yang dikembalikan oleh [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) ke file WebVTT dan menggunakan identifier yang dikembalikan oleh [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) sebagai nama file sehingga setiap track memiliki output terpisah.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **Hapus Caption Audio**

Gunakan [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) untuk menghapus track tertentu. Contoh ini menggunakan [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) untuk menghapus semua caption dari audio frame pertama pada slide pertama sambil mempertahankan klip.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Temukan Baris dalam Caption Audio**

Untuk menemukan baris dalam caption audio pada slide pertama, cari teks yang dikembalikan oleh [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) dalam memori. Pada cue WebVTT teks biasa, baris waktu mengandung `-->`, baris caption mengikuti baris tersebut, dan baris kosong mengakhiri cue. Contoh ini mencetak label track dan setiap baris caption yang mengandung “café”.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ekstrak Audio**

Transisi slide dapat memiliki suara tersendiri. Untuk mengambilnya, panggil [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) pada transisi slide. Contoh ini mengakses byte yang dikembalikan oleh [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) dan mencetak jumlah byte. Jika slide pertama tidak memiliki suara transisi, ia mencetak pesan sebagai gantinya.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bisakah saya menggunakan kembali klip audio yang sama di beberapa slide tanpa menduplikasinya?**

Ya. Tambahkan klip sekali ke presentasi’s [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) dan gunakan objek audio yang sama pada [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) untuk setiap slide.

**Bisakah saya mengganti suara dalam audio frame yang ada?**

Ya. Untuk suara yang ditautkan, gunakan [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) untuk menunjuk ke file pengganti. Untuk suara yang disematkan, pilih klip lain dari [audio collection] presentasi dengan [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Kedua pendekatan mempertahankan frame yang ada.

**Apakah pemangkasan mengubah data audio yang disimpan dalam presentasi?**

Tidak. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) dan [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) menentukan batas pemutaran. Anda masih dapat mengambil klip penuh melalui [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).