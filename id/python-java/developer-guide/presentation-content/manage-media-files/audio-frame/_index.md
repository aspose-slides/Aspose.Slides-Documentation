---
title: Kelola Audio Frame dalam Presentasi Menggunakan Python
linktitle: Kerangka Audio
type: docs
weight: 10
url: /id/python-java/audio-frame/
keywords:
- audio
- kerangka audio
- gambar mini
- tambahkan audio
- properti audio
- opsi audio
- ekstrak audio
- Python
- Aspose.Slides
description: "Sematkan audio pada slide, ubah ikon audio, konfigurasikan pemutaran, kelola caption WebVTT, dan ekstrak suara transisi slide dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Audio frame memungkinkan Anda memutar suara pada slide. Dengan Aspose.Slides for Python via Java, Anda dapat menyematkan klip audio, memilih gambar yang mewakilinya, menyesuaikan pemutaran, dan menambahkan caption. Anda juga dapat mengambil suara yang ditetapkan pada transisi slide.

## **Membuat Audio Frame**

Tambahkan byte dari `audio.wav` ke koleksi audio presentasi, lalu gunakan [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) untuk menyematkan klip audio lokal pada slide pertama. Dua koordinat pertama menentukan posisi frame pada slide, dan dua nilai berikutnya mengatur lebar dan tinggi, semuanya dalam poin. Contoh ini memanggil [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) untuk memulai klip secara otomatis dan memanggil [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) untuk memilih preset keras.

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

## **Mengubah Thumbnail Audio Frame**

Secara default, audio frame menampilkan ikon speaker. Untuk menampilkan thumbnail khusus, tambahkan gambar ke presentasi dengan [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) dan atur pada gambar frame dengan [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). Contoh menggunakan JPEG sebagai thumbnail untuk klip audio yang disematkan.

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

    audio_data = Path("audio.wav").read_bytes()
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

## **Mengubah Opsi Pemutaran Audio**

**Audio Options** PowerPoint mengontrol kapan klip dimulai, seberapa keras suaranya, dan bagaimana perilakunya selama pertunjukan slide.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Kontrol PowerPoint | Metode Aspose.Slides for Python via Java |
| --- | --- |
| Mulai | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Preset volume | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Putar di Seluruh Slide | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Loop hingga Dihentikan | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Sembunyikan Selama Pertunjukan | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Putar Ulang setelah Memutar | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Pemangkasan waktu mulai Audio | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Pemangkasan waktu akhir Audio | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Slider volume | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

Contoh menemukan audio frame pertama pada slide pertama, memanggil [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) untuk memulai pemutaran saat diklik, dan memilih preset volume rendah. Klip berlanjut melewati slide dengan looping dimatikan. Ikon tetap tersembunyi selama pertunjukan, dan klip diputar ulang setelah selesai.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Putar saat klik dengan volume rendah, di seluruh slide, tanpa looping.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Sembunyikan frame selama pertunjukan slide dan putar ulang setelah diputar.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Untuk klip yang lebih lama dari 3,5 detik, contoh ini melewatkan 1,5 detik pertama dan 2 detik terakhir. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) menerima durasi yang akan dihilangkan dari akhir klip. Untuk mendapatkan waktu akhir yang ditampilkan di PowerPoint, kurangi offset tersebut dari durasi penuh klip. Klip yang dipangkas melakukan fade in selama 200 milidetik dan fade out selama 500 milidetik. Semua empat metode menerima nilai dalam milidetik.

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

    audio_data = Path("audio.wav").read_bytes()
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

Untuk mengatur volume pemutaran ke persentase tertentu, gunakan [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Contoh ini mengatur audio frame pertama pada slide pertama ke 85%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Mengelola Caption Audio**

Setiap audio frame menyediakan akses ke track caption‑nya melalui [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Gunakan koleksi tersebut untuk menambahkan caption WebVTT ke klip, mengekspor track yang ada, atau menghapusnya.

### **Menambahkan Caption Audio**

Contoh ini menyematkan klip audio pada slide pertama dan menggunakan [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) untuk melampirkan track WebVTT lokal. Argumen pertama menyediakan label track, dan argumen kedua mengidentifikasi file yang berisi caption berwaktu.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Tambahkan trek caption baru dari file WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Mengekspor Caption Audio**

Contoh ini mengekspor setiap track caption yang terlampir pada audio frame di slide pertama. Ia menulis byte yang dikembalikan oleh [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) ke file WebVTT dan menggunakan identifier yang dikembalikan oleh [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) sebagai nama file sehingga setiap track memiliki output terpisah.

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
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Menghapus Caption Audio**

Gunakan [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) untuk menghapus track tertentu. Contoh ini menggunakan [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) untuk menghapus semua caption dari audio frame pertama pada slide pertama sambil mempertahankan klip.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Mencari Baris dalam Caption Audio**

Untuk mencari baris dalam caption audio pada slide pertama, cari teks yang dikembalikan oleh [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) di memori. Dalam cue WebVTT teks biasa, baris waktu berisi `-->`, baris caption mengikutinya, dan baris kosong menandai akhir cue. Contoh ini mencetak label track dan setiap baris caption yang mengandung “café”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Mengekstrak Audio**

Transisi slide dapat memiliki suaranya sendiri. Untuk mengambilnya, panggil [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) pada transisi slide. Contoh mengakses byte yang dikembalikan oleh [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) dan mencetak jumlah byte. Jika slide pertama tidak memiliki suara transisi, ia mencetak pesan sebagai gantinya.

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat menggunakan kembali klip audio yang sama di beberapa slide tanpa menduplikasinya?**

Ya. Tambahkan klip sekali ke [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) presentasi dan berikan objek audio yang sama ke [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) untuk setiap slide.

**Apakah saya dapat mengganti suara dalam audio frame yang sudah ada?**

Ya. Untuk suara yang ditautkan, gunakan [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) untuk mengarahkan ke file pengganti. Untuk suara yang disematkan, pilih klip lain dari audio collection presentasi dengan [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Kedua pendekatan mempertahankan frame yang ada.

**Apakah pemangkasan mengubah data audio yang disimpan di presentasi?**

Tidak. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) dan [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) mengatur batas pemutaran. Anda masih dapat mengambil klip penuh melalui [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).