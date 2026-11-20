---
title: Kelola Kerangka Audio dalam Presentasi di Android
linktitle: Kerangka Audio
type: docs
weight: 10
url: /id/androidjava/audio-frame/
keywords:
- audio
- kerangka audio
- gambar mini
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- Android
- Java
- Aspose.Slides
description: "Sematkan audio dalam slide, ubah ikon audio, konfigurasikan pemutaran, kelola caption WebVTT, dan ekstrak suara transisi slide dengan Aspose.Slides untuk Android via Java."
---
## **Ringkasan**

Kerangka audio memungkinkan Anda memutar suara pada slide. Dengan Aspose.Slides for Android via Java, Anda dapat menyematkan klip audio, memilih gambar yang mewakilinya, menyesuaikan pemutaran, dan melampirkan caption. Anda juga dapat mengambil suara yang ditetapkan pada transisi slide.

## **Buat Kerangka Audio**

Gunakan [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) untuk menyematkan klip audio lokal pada slide pertama. Dua koordinat pertama menentukan posisi kerangka pada slide, dan dua nilai berikutnya mengatur lebar dan tinggi, semuanya dalam point. Contoh ini memanggil [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) untuk memulai klip secara otomatis dan memanggil [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) untuk memilih preset keras.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ubah Thumbnail Kerangka Audio**

Secara default, kerangka audio menampilkan ikon speaker. Untuk menampilkan thumbnail khusus, tambahkan gambar ke presentasi dengan [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) dan atur pada gambar kerangka dengan [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). Contoh ini menggunakan JPEG sebagai thumbnail untuk klip audio yang disematkan.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ubah Opsi Pemutaran Audio**

Kontrol **Audio Options** di PowerPoint menentukan kapan klip dimulai, seberapa keras suaranya, dan bagaimana perilakunya selama pertunjukan slide.

![Kontrol Audio Options PowerPoint untuk kerangka audio](audio_frame_0.png)

| Kontrol PowerPoint | metode Aspose.Slides for Android via Java |
| --- | --- |
| Mulai | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Preset volume | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Putar di Seluruh Slide | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Loop sampai Dihentikan | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Sembunyikan selama Pertunjukan | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Putar Ulang setelah Memutar | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Potong waktu mulai Audio | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Potong waktu akhir Audio | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Slider volume | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Contoh ini menemukan kerangka audio pertama pada slide pertama, memanggil [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) untuk memulai pemutaran dengan klik, dan memilih preset volume rendah. Klip berlanjut ke slide berikutnya dengan looping dimatikan. Ikon tetap tersembunyi selama pertunjukan, dan klip diputar ulang setelah pemutaran.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Untuk klip yang lebih lama dari 3,5 detik, contoh ini melewatkan 1,5 detik pertama dan 2 detik terakhir. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) menerima durasi yang dihilangkan dari akhir klip. Untuk mendapatkan waktu akhir yang ditampilkan di PowerPoint, kurangi offset tersebut dari durasi penuh klip. Klip yang dipangkas fade in selama 200 milidetik dan fade out selama 500 milidetik. Semua empat metode menerima nilai dalam milidetik.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk mengatur volume pemutaran ke persentase tertentu, gunakan [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Contoh ini mengatur kerangka audio pertama pada slide pertama menjadi 85%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Kelola Caption Audio**

Setiap kerangka audio menyediakan akses ke jalur caption-nya melalui [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Gunakan koleksi tersebut untuk melampirkan caption WebVTT ke klip, mengekspor jalur yang ada, atau menghapusnya.

### **Tambahkan Caption Audio**

Contoh ini menyematkan klip audio pada slide pertama dan menggunakan [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) untuk melampirkan jalur WebVTT lokal. Argumen pertama memberikan label jalur, dan argumen kedua mengidentifikasi file yang berisi caption berwaktu.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ekstrak Caption Audio**

Contoh ini mengekspor setiap jalur caption yang dilampirkan pada kerangka audio di slide pertama. Ia menulis byte yang dikembalikan oleh [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) ke file WebVTT dan menggunakan pengidentifikasi yang dikembalikan oleh [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) sebagai nama file sehingga setiap jalur memiliki keluaran terpisah.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Hapus Caption Audio**

Gunakan [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) atau [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) untuk menghapus jalur individual. Contoh ini menggunakan [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) untuk menghapus semua caption dari kerangka audio pertama pada slide pertama sambil mempertahankan klip.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Temukan Baris dalam Caption Audio**

Untuk menemukan baris dalam caption audio pada slide pertama, cari teks yang dikembalikan oleh [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) di memori. Dalam cue WebVTT teks biasa, baris waktu berisi `-->`, baris caption mengikutinya, dan baris kosong mengakhiri cue. Contoh ini mencetak label jalur dan setiap baris caption yang mengandung “café”.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ekstrak Audio**

Transisi slide dapat memiliki suara sendiri. Untuk mengambilnya, panggil [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) pada transisi slide. Contoh ini mengakses byte yang dikembalikan oleh [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) dan mencetak jumlah byte. Jika slide pertama tidak memiliki suara transisi, ia mencetak pesan sebagai gantinya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat menggunakan kembali klip audio yang sama di beberapa slide tanpa menggandakannya?**

Ya. Tambahkan klip sekali ke [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) presentasi dan berikan objek audio yang sama ke [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) untuk setiap slide.

**Apakah saya dapat mengganti suara pada kerangka audio yang ada?**

Ya. Untuk suara yang ditautkan, gunakan [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) untuk menunjuk ke file pengganti. Untuk suara yang disematkan, pilih klip lain dari audio collection presentasi dengan [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Kedua pendekatan mempertahankan kerangka yang ada.

**Apakah pemangkasan mengubah data audio yang disimpan dalam presentasi?**

Tidak. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) dan [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) menetapkan batas pemutaran. Anda masih dapat mengambil klip penuh dari [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).