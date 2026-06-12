---
title: "Kelola Audio dalam Presentasi Menggunakan Java"
linktitle: "Bingkai Audio"
type: docs
weight: 10
url: /id/java/audio-frame/
keywords:
- audio
- bingkai audio
- gambar mini
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- Java
- Aspose.Slides
description: "Buat dan kontrol bingkai audio di Aspose.Slides untuk Java—contoh kode untuk menyematkan, memotong, mengulang, dan mengonfigurasi pemutaran pada presentasi PPT, PPTX, dan ODP."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan bingkai audio di Aspose.Slides. Ini menunjukkan cara menambahkan audio tersemat ke slide, menyesuaikan thumbnail bingkai audio, mengonfigurasi opsi pemutaran seperti volume, pengulangan, penyembunyian, pemotongan, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi slide show.

## **Buat Bingkai Audio**

Aspose.Slides for Java memungkinkan Anda menambahkan file audio ke slide. File audio disematkan di slide sebagai bingkai audio.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Muat aliran file audio yang ingin Anda sematkan di slide.
4. Tambahkan bingkai audio tersemat (yang berisi file audio) ke slide.
5. Atur [PlayMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/AudioPlayModePreset) dan `Volume` yang diekspos oleh objek [IAudioFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAudioFrame).
6. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara menambahkan bingkai audio tersemat ke slide:

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Memuat file suara wav ke dalam stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Menambahkan Bingkai Audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Mengatur Mode Pemutaran dan Volume Audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Menulis file PowerPoint ke disk
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Thumbnail Bingkai Audio**

Saat Anda menambahkan file audio ke presentasi, audio muncul sebagai bingkai dengan gambar standar default (lihat gambar pada bagian di bawah). Anda dapat mengubah gambar pratinjau bingkai audio (atur gambar pilihan Anda).

Kode Java berikut menunjukkan cara mengubah thumbnail atau gambar pratinjau bingkai audio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Menambahkan bingkai audio ke slide dengan posisi dan ukuran yang ditentukan.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Menambahkan gambar ke sumber daya presentasi.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Mengatur gambar untuk bingkai audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Saves the modified presentation to disk
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ubah Opsi Pemutaran Audio**

Aspose.Slides for Java memungkinkan Anda mengubah opsi yang mengontrol pemutaran atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio diputar berulang, atau bahkan menyembunyikan ikon audio.

Panel **Audio Options** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** PowerPoint yang sesuai dengan properti [AudioFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/AudioFrame) Aspose.Slides:

- **Start** dropdown list sesuai dengan metode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** sesuai dengan metode [AudioFrame.setVolume](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** sesuai dengan metode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** sesuai dengan metode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** sesuai dengan metode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** sesuai dengan metode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

Opsi **Editing** PowerPoint yang sesuai dengan properti [AudioFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/AudioFrame) Aspose.Slides:

- **Fade In** sesuai dengan metode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** sesuai dengan metode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Trim Audio Start Time** sesuai dengan metode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Trim Audio End Time** nilainya sama dengan durasi audio dikurangi nilai metode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

Kontrol **Volume** pada panel kontrol audio PowerPoint sesuai dengan metode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Ini memungkinkan Anda mengubah volume audio sebagai persentase.

Berikut cara mengubah opsi Pemutaran Audio:

1. [Сreate](#create-audio-frame) atau dapatkan Audio Frame.
2. Atur nilai baru untuk properti Audio Frame yang ingin Anda sesuaikan.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode Java berikut mendemonstrasikan operasi di mana opsi audio disesuaikan:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Mendapatkan bentuk AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Mengatur mode Pemutaran menjadi diputar pada klik
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Mengatur volume menjadi Rendah
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Mengatur audio agar diputar di seluruh slide
    audioFrame.setPlayAcrossSlides(true);

    // Menonaktifkan pengulangan untuk audio
    audioFrame.setPlayLoopMode(false);

    // Menyembunyikan AudioFrame selama pertunjukan slide
    audioFrame.setHideAtShowing(true);

    // Memutar ulang audio ke awal setelah diputar
    audioFrame.setRewindAudio(true);

    // Menyimpan file PowerPoint ke disk
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Contoh Java ini menunjukkan cara menambahkan bingkai audio baru dengan audio tersemat, memotongnya, dan mengatur durasi fade:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Mengatur offset pemotongan mulai ke 1,5 detik
    audioFrame.setTrimFromStart(1500f);
    // Mengatur offset pemotongan akhir ke 2 detik
    audioFrame.setTrimFromEnd(2000f);

    // Mengatur durasi fade-in ke 200 ms
    audioFrame.setFadeInDuration(200f);
    // Mengatur durasi fade-out ke 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Potongan kode berikut menunjukkan cara mengambil bingkai audio dengan audio tersemat dan mengatur volumenya menjadi 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Mendapatkan bentuk bingkai audio
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Mengatur volume audio menjadi 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Kelola Caption Audio**

Aspose.Slides memungkinkan Anda menambahkan caption tertutup ke bingkai audio melalui metode [getCaptionTracks](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Metode ini mengembalikan [ICaptionsCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/icaptionscollection/), yang memungkinkan Anda menambahkan trek caption WebVTT, mengiterasi trek yang ada, dan menghapusnya bila diperlukan.

**Tambahkan Caption Audio**

Gunakan metode [getCaptionTracks](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) untuk melampirkan satu atau lebih trek caption ke bingkai audio. Pada contoh berikut, file audio ditambahkan ke slide, kemudian trek caption baru dimuat dari file `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Tambahkan trek caption baru dari file WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ekstrak Caption Audio**

Anda dapat mengiterasi trek caption yang terkait dengan bingkai audio dan menyimpannya sebagai file `.vtt`. Setiap trek caption mengekspor data biner dan pengenal uniknya, yang dapat digunakan saat mengekspor caption.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Simpan trek caption sebagai file .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Hapus Caption Audio**

Untuk menghapus caption dari bingkai audio, gunakan metode yang disediakan oleh [ICaptionsCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/icaptionscollection/), seperti [clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), atau [removeAt](https://reference.aspose.com/slides/id/java/com.aspose.slides/icaptionscollection/#removeAt-int-). Contoh berikut menghapus semua trek caption dari bingkai audio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Hapus semua trek caption dari bingkai audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ekstrak Audio**

Aspose.Slides for Java memungkinkan Anda mengekstrak suara yang digunakan dalam transisi slide show. Misalnya, Anda dapat mengekstrak suara yang digunakan pada slide tertentu.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dan muat presentasi yang berisi audio.
2. Dapatkan referensi slide yang relevan melalui indeksnya.
3. Akses [slideshow transitions](https://reference.aspose.com/slides/id/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) untuk slide tersebut.
4. Ekstrak suara dalam data byte.

Kode Java berikut menunjukkan cara mengekstrak audio yang digunakan pada slide:

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Mengakses slide yang diinginkan
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Mendapatkan efek transisi slideshow untuk slide
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Mengekstrak suara dalam array byte
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menggunakan kembali aset audio yang sama di banyak slide tanpa membuat ukuran file membengkak?**

Ya. Tambahkan audio sekali ke [audio collection](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getAudios--) bersama presentasi dan buat bingkai audio tambahan yang merujuk ke aset yang ada. Ini menghindari duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara dalam bingkai audio yang ada tanpa membuat ulang shape?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) agar mengarah ke file baru. Untuk suara yang tersemat, ganti objek [embedded audio](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) dengan yang lain dari [audio collection](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getAudios--) presentasi. Format bingkai dan sebagian besar pengaturan pemutaran tetap utuh.

**Apakah pemotongan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemotongan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak tersentuh dan dapat diakses melalui audio tersemat atau koleksi audio presentasi.