---
title: Kelola Audio dalam Presentasi Menggunakan Python
linktitle: Bingkai Audio
type: docs
weight: 10
url: /id/python-java/audio-frame/
keywords:
- audio
- bingkai audio
- pratinjau
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- Python
- Aspose.Slides
description: "Buat dan kontrol bingkai audio di Aspose.Slides untuk Python melalui Java—contoh kode untuk menyematkan, memotong, mengulang, dan mengonfigurasi pemutaran pada presentasi PPT, PPTX, dan ODP."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bingkai audio di Aspose.Slides. Artikel ini menunjukkan cara menambahkan audio tersemat ke slide, menyesuaikan thumbnail bingkai audio, mengonfigurasi opsi pemutaran seperti volume, pengulangan, penyembunyian, pemotongan, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi pertunjukan slide.

## **Buat Bingkai Audio**

Aspose.Slides for Python via Java memungkinkan Anda menambahkan file audio ke slide. File audio disematkan dalam slide sebagai bingkai audio. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Baca file audio yang ingin Anda sematkan ke slide.
4. Tambahkan bingkai audio tersemat (yang berisi file audio) ke slide.
5. Gunakan [setPlayMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setPlayMode) dan [setVolume](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setVolume) yang disediakan oleh objek [AudioFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/).
6. Simpan presentasi yang telah dimodifikasi.

Kode Python berikut menunjukkan cara menambahkan bingkai audio tersemat ke slide:

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

## **Ubah Thumbnail Bingkai Audio**

Saat Anda menambahkan file audio ke presentasi, audio muncul sebagai bingkai dengan gambar default standar (lihat gambar di bagian berikut). Anda dapat mengubah gambar pratinjau bingkai audio menjadi gambar pilihan Anda.

Kode Python berikut menunjukkan cara mengubah thumbnail atau gambar pratinjau bingkai audio:

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

Aspose.Slides for Python via Java memungkinkan Anda mengubah opsi yang mengontrol pemutaran audio atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio untuk berulang, atau bahkan menyembunyikan ikon audio.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/) :

- **Start** daftar drop-down cocok dengan metode [setPlayMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** cocok dengan metode [setVolume](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** cocok dengan metode [setPlayAcrossSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** cocok dengan metode [setPlayLoopMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** cocok dengan metode [setHideAtShowing](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** cocok dengan metode [setRewindAudio](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setRewindAudio)

Pilihan **Editing** PowerPoint yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/) :

- **Fade In** cocok dengan metode [setFadeInDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** cocok dengan metode [setFadeOutDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** cocok dengan metode [setTrimFromStart](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** nilai sama dengan durasi audio dikurangi nilai yang ditetapkan oleh metode [setTrimFromEnd](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setTrimFromEnd)

Kontrol **Volume** PowerPoint pada panel kontrol audio sesuai dengan metode [setVolumeValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setVolumeValue). Ini memungkinkan Anda mengubah volume audio dalam persentase.

Berikut cara mengubah opsi Pemutaran Audio:

1. [Buat](#create-audio-frames) atau dapatkan bingkai audio.
2. Tetapkan nilai baru untuk properti bingkai audio yang ingin Anda sesuaikan.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode Python berikut memperlihatkan operasi di mana opsi audio disesuaikan:

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
        # Putar ketika diklik dengan volume rendah, melintasi slide, tanpa pengulangan.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Sembunyikan bingkai selama pertunjukan slide dan putar mundur setelah diputar.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Contoh Python berikut menunjukkan cara menambahkan bingkai audio baru dengan audio tersemat, memotongnya, dan mengatur durasi fade:

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

    # Potong 1,5 detik dari awal dan 2 detik dari akhir.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Atur fade-in menjadi 200 ms dan fade-out menjadi 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Contoh kode berikut menunjukkan cara mengambil bingkai audio dengan audio tersemat dan mengatur volumenya ke 85%:

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

Aspose.Slides memungkinkan Anda menambahkan caption tertutup ke bingkai audio melalui metode [getCaptionTracks](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#getCaptionTracks). Metode ini mengembalikan sebuah [CaptionsCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/), yang memungkinkan Anda menambahkan trek caption WebVTT, mengiterasi trek yang ada, dan menghapusnya bila diperlukan.

**Tambah Caption Audio**

Gunakan metode [getCaptionTracks](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#getCaptionTracks) untuk melampirkan satu atau lebih trek caption ke bingkai audio. Pada contoh berikut, file audio ditambahkan ke slide, dan kemudian trek caption baru dimuat dari file `.vtt`.

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

    # Tambahkan trek caption baru dari file WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Ekstrak Caption Audio**

Anda dapat mengiterasi trek caption yang terkait dengan bingkai audio dan menyimpannya sebagai file `.vtt`. Setiap trek caption mengungkapkan data biner dan pengidentifikasi uniknya, yang dapat digunakan saat mengekspor caption.

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
                # Simpan trek caption sebagai file .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Hapus Caption Audio**

Untuk menghapus caption dari bingkai audio, gunakan metode yang disediakan oleh [CaptionsCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/), seperti [clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#remove), atau [removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#removeAt). Contoh berikut menghapus semua trek caption dari bingkai audio.

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
2. Dapatkan referensi ke slide yang relevan berdasarkan indeksnya.
3. Akses [slideshow transitions](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getSlideShowTransition) untuk slide tersebut.
4. Ekstrak suara sebagai data byte.

Kode Python berikut menunjukkan cara mengekstrak audio yang digunakan pada slide:

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

**Apakah saya dapat menggunakan kembali aset audio yang sama di beberapa slide tanpa memperbesar ukuran file?**

Ya. Tambahkan audio sekali ke [audio collection](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAudios) bersama pada presentasi, dan buat bingkai audio tambahan yang merujuk ke aset yang ada. Ini menghindari duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara dalam bingkai audio yang ada tanpa membuat ulang bentuk?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setLinkPathLong) agar menunjuk ke file baru. Untuk suara yang tersemat, tukar objek [embedded audio](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/#setEmbeddedAudio) dengan yang lain dari [audio collection](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAudios) presentasi. Pemformatan bingkai dan sebagian besar pengaturan pemutaran tetap tidak berubah.

**Apakah pemotongan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemotongan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak tersentuh dan dapat diakses melalui audio tersemat atau [audio collection](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getAudios) presentasi.