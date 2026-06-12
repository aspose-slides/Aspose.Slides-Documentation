---
title: Kelola Audio dalam Presentasi Menggunakan PHP
linktitle: Bingkai Audio
type: docs
weight: 10
url: /id/php-java/audio-frame/
keywords:
- audio
- bingkai audio
- gambar mini
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- PHP
- Aspose.Slides
description: "Buat dan kendalikan bingkai audio di Aspose.Slides untuk PHP—contoh kode untuk menyematkan, memotong, mengulang, dan mengonfigurasi pemutaran pada presentasi PPT, PPTX, dan ODP."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bingkai audio di Aspose.Slides. Artikel ini menunjukkan cara menambahkan audio tersemat ke slide, menyesuaikan thumbnail bingkai audio, mengonfigurasi opsi pemutaran seperti volume, pengulangan, penyembunyian, pemotongan, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi pertunjukan slide.

## **Membuat Bingkai Audio**

Aspose.Slides for PHP via Java memungkinkan Anda menambahkan file audio ke slide. File audio disematkan dalam slide sebagai bingkai audio.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Muat aliran file audio yang ingin Anda sematkan ke slide.
4. Tambahkan bingkai audio tersemat (yang berisi file audio) ke slide.
5. Atur [PlayMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/AudioPlayModePreset) dan `Volume` yang diekspos oleh objek [AudioFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/).
6. Simpan presentasi yang telah dimodifikasi.

Kode PHP berikut menunjukkan cara menambahkan bingkai audio tersemat ke slide:

```php
// Membuat instance kelas Presentation yang mewakili file presentasi
$pres = new Presentation();
try {
    # Mendapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Memuat file suara wav ke aliran
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Menambahkan Bingkai Audio
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Mengatur Mode Pemutaran dan Volume Audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Menulis file PowerPoint ke disk
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Mengubah Thumbnail Bingkai Audio**

Saat Anda menambahkan file audio ke presentasi, audio muncul sebagai bingkai dengan gambar standar bawaan (lihat gambar pada bagian di bawah). Anda dapat mengubah gambar pratinjau bingkai audio (tetapkan gambar pilihan Anda).

Kode PHP berikut menunjukkan cara mengubah thumbnail atau gambar pratinjau bingkai audio:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Menambahkan bingkai audio ke slide dengan posisi dan ukuran yang ditentukan.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Menambahkan gambar ke sumber daya presentasi.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Mengatur gambar untuk bingkai audio.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Menyimpan presentasi yang dimodifikasi ke disk
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Mengubah Opsi Pemutaran Audio**

Aspose.Slides for PHP via Java memungkinkan Anda mengubah opsi yang mengontrol pemutaran atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio agar diputar berulang, atau bahkan menyembunyikan ikon audio.

Panel **Audio Options** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** PowerPoint yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/):

- Daftar drop‑down **Start** cocok dengan metode [AudioFrame::setPlayMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** cocok dengan metode [AudioFrame::setVolume](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** cocok dengan metode [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** cocok dengan metode [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** cocok dengan metode [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** cocok dengan metode [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setRewindAudio)

Opsi **Editing** PowerPoint yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/):

- **Fade In** cocok dengan metode [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** cocok dengan metode [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** cocok dengan metode [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setTrimFromStart)
- Nilai **Trim Audio End Time** sama dengan durasi audio dikurangi nilai metode [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setTrimFromEnd)

Kontrol **Volume** pada panel kontrol audio PowerPoint sesuai dengan metode [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#setVolumeValue). Metode ini memungkinkan Anda mengubah volume audio dalam persentase.

Berikut cara mengubah opsi Pemutaran Audio:

1. [Сreate](#create-audio-frame) atau dapatkan Bingkai Audio.
2. Atur nilai baru untuk properti Bingkai Audio yang ingin Anda ubah.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode PHP berikut mendemonstrasikan operasi di mana opsi audio disesuaikan:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Mendapatkan shape AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Mengatur mode pemutaran menjadi pada klik
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Mengatur volume menjadi rendah
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Mengatur audio untuk diputar di semua slide
    $audioFrame->setPlayAcrossSlides(true);
    # Menonaktifkan pengulangan untuk audio
    $audioFrame->setPlayLoopMode(false);
    # Menyembunyikan AudioFrame selama pertunjukan slide
    $audioFrame->setHideAtShowing(true);
    # Memutar ulang audio ke awal setelah diputar
    $audioFrame->setRewindAudio(true);
    # Menyimpan file PowerPoint ke disk
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Contoh PHP ini menunjukkan cara menambahkan bingkai audio baru dengan audio tersemat, memotongnya, dan mengatur durasi fade:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Mengatur offset pemotongan awal menjadi 1,5 detik
    $audioFrame->setTrimFromStart(1500);
    // Mengatur offset pemotongan akhir menjadi 2 detik
    $audioFrame->setTrimFromEnd(2000);

    // Mengatur durasi fade-in menjadi 200 ms
    $audioFrame->setFadeInDuration(200);
    // Mengatur durasi fade-out menjadi 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Cuplikan kode berikut menunjukkan cara mendapatkan bingkai audio dengan audio tersemat dan mengatur volumenya menjadi 85 %:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Mendapatkan shape bingkai audio
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Mengatur volume audio menjadi 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Mengelola Caption Audio**

Aspose.Slides memungkinkan Anda menambahkan caption tertutup ke bingkai audio melalui metode [getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#getCaptionTracks). Metode ini mengembalikan sebuah [CaptionsCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/), yang memungkinkan Anda menambahkan trek caption WebVTT, mengiterasi trek yang ada, dan menghapusnya bila diperlukan.

**Menambahkan Caption Audio**

Gunakan metode [getCaptionTracks](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/#getCaptionTracks) untuk melampirkan satu atau lebih trek caption ke bingkai audio. Pada contoh berikut, file audio ditambahkan ke slide, lalu trek caption baru dimuat dari file `.vtt`.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Tambahkan trek caption baru dari file WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Mengekstrak Caption Audio**

Anda dapat mengiterasi trek caption yang terkait dengan bingkai audio dan menyimpannya sebagai file `.vtt`. Setiap trek caption mengekspos data biner dan pengidentifikasi uniknya, yang dapat digunakan saat mengekspor caption.

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // Simpan setiap trek caption sebagai file .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Menghapus Caption Audio**

Untuk menghapus caption dari bingkai audio, gunakan metode yang disediakan oleh [CaptionsCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/), seperti [clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#remove), atau [removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/captionscollection/#removeAt). Contoh berikut menghapus semua trek caption dari bingkai audio.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // tipe: AudioFrame

    // Hapus semua trek caption dari bingkai audio.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mengekstrak Audio**

Aspose.Slides for PHP via Java memungkinkan Anda mengekstrak suara yang digunakan dalam transisi pertunjukan slide. Misalnya, Anda dapat mengekstrak suara yang digunakan pada slide tertentu.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dan muat presentasi yang berisi audio.
2. Dapatkan referensi slide yang bersangkutan melalui indeksnya.
3. Akses [slideshow transitions](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getSlideShowTransition) untuk slide tersebut.
4. Ekstrak suara dalam bentuk data byte.

Kode berikut menunjukkan cara mengekstrak audio yang digunakan pada slide:

```php
# Membuat instance kelas Presentation yang mewakili file presentasi
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Mengakses slide yang diinginkan
	$slide = $pres->getSlides()->get_Item(0);
	# Mendapatkan efek transisi pertunjukan slide untuk slide
	$transition = $slide->getSlideShowTransition();
	# Mengekstrak suara dalam array byte
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Apakah saya dapat menggunakan kembali aset audio yang sama di beberapa slide tanpa memperbesar ukuran file?**

Ya. Tambahkan audio satu kali ke [audio collection](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getaudios/) bersama presentasi dan buat bingkai audio tambahan yang merujuk ke aset yang sudah ada. Cara ini menghindari duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara pada bingkai audio yang sudah ada tanpa membuat ulang shape?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/setlinkpathlong/) agar menunjuk ke file baru. Untuk suara yang tersemat, ganti objek [embedded audio](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/setembeddedaudio/) dengan audio lain dari [audio collection](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getaudios/) presentasi. Format bingkai dan sebagian besar pengaturan pemutaran tetap tidak berubah.

**Apakah pemotongan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemotongan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak tersentuh dan dapat diakses melalui audio tersemat atau melalui audio collection presentasi.