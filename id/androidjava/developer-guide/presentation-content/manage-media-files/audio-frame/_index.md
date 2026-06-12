---
title: Kelola Audio dalam Presentasi di Android
linktitle: Kerangka Audio
type: docs
weight: 10
url: /id/androidjava/audio-frame/
keywords:
- audio
- kerangka audio
- miniatur
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- Android
- Java
- Aspose.Slides
description: "Buat dan kontrol kerangka audio di Aspose.Slides untuk Android—contoh Java untuk menyematkan, memotong, mengulang, dan mengatur pemutaran pada presentasi PPT, PPTX, dan ODP."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan frame audio di Aspose.Slides. Artikel ini menunjukkan cara menambahkan audio tersemat ke slide, menyesuaikan thumbnail frame audio, mengonfigurasi opsi pemutaran seperti volume, pengulangan, menyembunyikan, memotong, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi slide show.

## **Buat Frame Audio**
Aspose.Slides for Android via Java memungkinkan Anda menambahkan file audio ke slide. File audio disematkan dalam slide sebagai frame audio.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Muat aliran file audio yang ingin Anda sematkan ke slide.
4. Tambahkan frame audio tersemat (yang berisi file audio) ke slide.
5. Atur [PlayMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AudioPlayModePreset) dan `Volume` yang disediakan oleh objek [IAudioFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IAudioFrame).
6. Simpan presentasi yang telah dimodifikasi.

Kode Java ini menunjukkan cara menambahkan frame audio tersemat ke slide:

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Memuat file suara wav ke aliran
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Menambahkan Audio Frame
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Mengatur Play Mode dan Volume Audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Menulis file PowerPoint ke disk
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Thumbnail Frame Audio**

Saat Anda menambahkan file audio ke sebuah presentasi, audio muncul sebagai frame dengan gambar default standar (lihat gambar pada bagian di bawah). Anda dapat mengubah gambar pratinjau frame audio (tentukan gambar pilihan Anda).

Kode Java ini menunjukkan cara mengubah thumbnail atau gambar pratinjau frame audio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Menambahkan frame audio ke slide dengan posisi dan ukuran yang ditentukan.
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

    // Mengatur gambar untuk frame audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Menyimpan presentasi yang dimodifikasi ke disk
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ubah Opsi Pemutaran Audio**

Aspose.Slides for Android via Java memungkinkan Anda mengubah opsi yang mengontrol pemutaran atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio untuk diputar berulang, atau bahkan menyembunyikan ikon audio.

Panel **Audio Options** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** PowerPoint yang sesuai dengan properti [AudioFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AudioFrame) Aspose.Slides:

- **Start** dropdown list cocok dengan properti [AudioFrame.PlayMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** cocok dengan properti [AudioFrame.Volume](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** cocok dengan properti [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** cocok dengan properti [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** cocok dengan properti [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** cocok dengan properti [AudioFrame.RewindAudio](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

Opsi **Editing** PowerPoint yang sesuai dengan properti [AudioFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/audioframe/) Aspose.Slides:

- **Fade In** cocok dengan properti [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** cocok dengan properti [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** cocok dengan properti [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** nilai sama dengan durasi audio dikurangi nilai [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

Kontrol **Volume** pada panel kontrol audio PowerPoint berkorespondensi dengan properti [AudioFrame.VolumeValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/audioframe/#getVolumeValue--). Ini memungkinkan Anda mengubah volume audio dalam persentase.

Berikut cara mengubah opsi pemutaran audio:

1. [Buat](#create-audio-frame) atau dapatkan Audio Frame.
2. Atur nilai baru untuk properti Audio Frame yang ingin Anda sesuaikan.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode Java ini menunjukkan operasi di mana opsi audio disesuaikan:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Mendapatkan bentuk AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Mengatur mode Putar menjadi putar saat klik
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Mengatur volume menjadi Rendah
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Mengatur audio untuk diputar di seluruh slide
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

Contoh Java ini menunjukkan cara menambahkan frame audio baru dengan audio tersemat, memotongnya, dan mengatur durasi fade:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Mengatur titik awal pemangkasan ke 1.5 detik
    audioFrame.setTrimFromStart(1500f);
    // Mengatur titik akhir pemangkasan ke 2 detik
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

Contoh kode berikut menunjukkan cara mengambil frame audio dengan audio tersemat dan mengatur volumenya menjadi 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Mendapatkan bentuk frame audio
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

Aspose.Slides memungkinkan Anda menambahkan caption tertutup ke sebuah frame audio melalui metode [getCaptionTracks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Metode ini mengembalikan sebuah [ICaptionsCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/), yang memungkinkan Anda menambahkan track caption WebVTT, mengiterasi track yang ada, dan menghapusnya bila diperlukan.

**Tambahkan Caption Audio**

Gunakan metode [getCaptionTracks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) untuk melampirkan satu atau lebih track caption ke sebuah frame audio. Pada contoh berikut, file audio ditambahkan ke slide, kemudian track caption baru dimuat dari file `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Tambahkan track caption baru dari file WebVTT.

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ekstrak Caption Audio**

Anda dapat mengiterasi track caption yang terkait dengan sebuah frame audio dan menyimpannya sebagai file `.vtt`. Setiap track caption menampilkan data biner serta pengenal uniknya, yang dapat dipakai saat mengekspor caption.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Simpan track caption sebagai file .vtt.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**Hapus Caption Audio**

Untuk menghapus caption dari sebuah frame audio, gunakan metode yang disediakan oleh [ICaptionsCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/), seperti [clear](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), atau [removeAt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). Contoh berikut menghapus semua track caption dari sebuah frame audio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Hapus semua track caption dari frame audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ekstrak Audio**

Aspose.Slides for Android via Java memungkinkan Anda mengekstrak suara yang digunakan dalam transisi slideshow. Misalnya, Anda dapat mengekstrak suara yang digunakan pada slide tertentu.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dan muat presentasi yang berisi audio.
2. Dapatkan referensi slide yang relevan melalui indeksnya.
3. Akses [slideshow transitions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) untuk slide tersebut.
4. Ekstrak suara dalam bentuk data byte.

Kode Java ini menunjukkan cara mengekstrak audio yang digunakan pada sebuah slide:

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Mengakses slide yang diinginkan
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Mendapatkan efek transisi slideshow untuk slide
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Mengekstrak suara dalam array byte
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menggunakan kembali aset audio yang sama di beberapa slide tanpa memperbesar ukuran file?**

Ya. Tambahkan audio sekali ke [audio collection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getAudios--) bersama presentasi dan buat frame audio tambahan yang merujuk ke aset yang sudah ada. Ini menghindari duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara dalam frame audio yang sudah ada tanpa membuat ulang bentuk?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) agar menunjuk ke file baru. Untuk suara yang tersemat, ganti objek [embedded audio](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) dengan audio lain dari [audio collection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getAudios--) presentasi. Format frame dan sebagian besar pengaturan pemutaran tetap tidak berubah.

**Apakah pemotongan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemotongan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak tersentuh dan dapat diakses melalui audio tersemat atau koleksi audio presentasi.