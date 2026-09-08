---
title: Kelola Audio dalam Presentasi Menggunakan Python
linktitle: Kerangka Audio
type: docs
weight: 10
url: /id/python-java/audio-frame/
keywords:
- audio
- kerangka audio
- gambar miniatur
- menambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- Python
- Aspose.Slides
description: "Buat dan kendalikan kerangka audio di Aspose.Slides untuk Python via Java—contoh kode untuk menyematkan, memotong, mengulang, dan mengkonfigurasi pemutaran pada presentasi PPT, PPTX, dan ODP."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan frame audio di Aspose.Slides. Artikel ini menunjukkan cara menambahkan audio tersemat ke slide, menyesuaikan thumbnail frame audio, mengonfigurasi opsi pemutaran seperti volume, pengulangan, penyembunyian, pemangkasan, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi pertunjukan slide.

## **Buat Frame Audio**

Aspose.Slides for Python via Java memungkinkan Anda menambahkan file audio ke slide. File audio disematkan dalam slide sebagai frame audio. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Baca file audio yang ingin Anda sematkan ke dalam slide.
4. Tambahkan frame audio tersemat (yang berisi file audio) ke slide.
5. Atur [setPlayMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setPlayMode) dan [setVolume](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setVolume) yang disediakan oleh objek [AudioFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/).
6. Simpan presentasi yang telah dimodifikasi.

Kode Python ini menunjukkan cara menambahkan frame audio tersemat ke slide:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ubah Thumbnail Frame Audio**

Saat Anda menambahkan file audio ke presentasi, audio muncul sebagai frame dengan gambar standar default (lihat gambar pada bagian di bawah). Anda dapat mengubah gambar pratinjau frame audio (menetapkan gambar pilihan Anda).

Kode Python ini menunjukkan cara mengubah thumbnail atau gambar pratinjau frame audio:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ubah Opsi Pemutaran Audio**

Aspose.Slides for Python via Java memungkinkan Anda mengubah opsi yang mengendalikan pemutaran atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio agar diputar berulang, atau bahkan menyembunyikan ikon audio.

Panel **Audio Options** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/):

- **Start** drop-down list matches the [setPlayMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setPlayMode) method
- **Volume** matches the [setVolume](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setVolume) method
- **Play Across Slides** matches the [setPlayAcrossSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) method
- **Loop until Stopped** matches the [setPlayLoopMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setPlayLoopMode) method
- **Hide During Show** matches the [setHideAtShowing](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setHideAtShowing) method
- **Rewind after Playing** matches the [setRewindAudio](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setRewindAudio) method

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/) properties:

- **Fade In** matches the [setFadeInDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setFadeInDuration) method 
- **Fade Out** matches the [setFadeOutDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setFadeOutDuration) method 
- **Trim Audio Start Time** matches the [setTrimFromStart](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setTrimFromStart) method 
- **Trim Audio End Time** value equals the audio duration minus the value of [setTrimFromEnd](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setTrimFromEnd) method

The PowerPoint **Volume control** on the audio control panel corresponds to the [setVolumeValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setVolumeValue) method. It lets you change the audio volume as a percentage.

Berikut cara mengubah opsi Pemutaran Audio:

1. [Сreate](#create-audio-frames) atau dapatkan Audio Frame.
2. Atur nilai baru untuk properti Audio Frame yang ingin Anda ubah.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode Python berikut mendemonstrasikan operasi di mana opsi audio disesuaikan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Putar saat diklik dengan volume rendah, di seluruh slide, tanpa pengulangan.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Sembunyikan frame selama pertunjukan slide dan putar kembali setelah diputar.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Contoh Python ini menunjukkan cara menambahkan frame audio baru dengan audio tersemat, memotongnya, dan mengatur durasi fade:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Potong 1.5 detik dari awal dan 2 detik dari akhir.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Atur fade-in menjadi 200 ms dan fade-out menjadi 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Contoh kode berikut menunjukkan cara mengambil frame audio dengan audio tersemat dan mengatur volumenya menjadi 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Kelola Caption Audio**

Aspose.Slides memungkinkan Anda menambahkan caption tertutup ke sebuah frame audio melalui metode [getCaptionTracks](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#getCaptionTracks). Metode ini mengembalikan sebuah [CaptionsCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/), yang memungkinkan Anda menambahkan track caption WebVTT, mengiterasi track yang ada, dan menghapusnya bila diperlukan.

**Tambah Caption Audio**

Gunakan metode [getCaptionTracks](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#getCaptionTracks) untuk melampirkan satu atau lebih track caption ke sebuah frame audio. Pada contoh berikut, file audio ditambahkan ke slide, kemudian track caption baru dimuat dari file `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Tambahkan jalur caption baru dari file WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Ekstrak Caption Audio**

Anda dapat mengiterasi track caption yang terkait dengan sebuah frame audio dan menyimpannya sebagai file `.vtt`. Setiap track caption mengungkapkan data biner dan pengenal uniknya, yang dapat digunakan saat mengekspor caption.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Simpan track caption sebagai file .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Hapus Caption Audio**

Untuk menghapus caption dari sebuah frame audio, gunakan metode yang disediakan oleh [CaptionsCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/), seperti [clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#remove), atau [removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#removeAt). Contoh berikut menghapus semua track caption dari sebuah frame audio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Ekstrak Audio**

Aspose.Slides for Python via Java memungkinkan Anda mengekstrak suara yang digunakan dalam transisi pertunjukan slide. Misalnya, Anda dapat mengekstrak suara yang digunakan pada slide tertentu.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi audio.
2. Dapatkan referensi slide yang relevan melalui indeksnya.
3. Akses [slideshow transitions](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getSlideShowTransition) untuk slide tersebut.
4. Ekstrak suara dalam data byte.

Kode Python ini menunjukkan cara mengekstrak audio yang digunakan pada sebuah slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat menggunakan kembali aset audio yang sama pada beberapa slide tanpa memperbesar ukuran file?**

Ya. Tambahkan audio sekali ke [audio collection](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAudios) yang dibagikan dalam presentasi dan buat frame audio tambahan yang merujuk ke aset yang sudah ada. Ini menghindari duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara dalam frame audio yang sudah ada tanpa membuat ulang shape?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setLinkPathLong) agar mengarah ke file baru. Untuk suara yang tersemat, ganti objek [embedded audio](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setEmbeddedAudio) dengan yang lain dari [audio collection](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAudios) presentasi. Format frame dan sebagian besar pengaturan pemutaran tetap tidak berubah.

**Apakah pemangkasan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemangkasan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak tersentuh dan dapat diakses melalui audio tersemat atau koleksi audio presentasi.