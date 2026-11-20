---
title: "Kelola Audio Frame dalam Presentasi Menggunakan Python"
linktitle: "Kerangka Audio"
type: docs
weight: 10
url: /id/python-net/audio-frame/
keywords:
  - audio
  - kerangka audio
  - miniatur
  - tambahkan audio
  - properti audio
  - opsi audio
  - ekstrak audio
  - WebVTT
  - Python
  - Aspose.Slides
description: "Menyematkan audio dalam slide, mengubah ikon audio, mengkonfigurasi pemutaran, mengelola caption WebVTT, dan mengekstrak suara transisi slide dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Audio frame memungkinkan Anda memutar suara pada slide. Dengan Aspose.Slides untuk Python via .NET, Anda dapat menyematkan klip audio, memilih gambar yang mewakilinya, mengatur pemutaran, dan menambahkan caption. Anda juga dapat mengambil suara yang ditetapkan untuk transisi slide.

## **Membuat Audio Frame**

Gunakan [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) untuk menyematkan klip audio lokal pada slide pertama. Dua koordinat pertama menentukan posisi frame pada slide, dan dua nilai berikutnya mengatur lebar dan tinggi, semuanya dalam poin. Contoh ini mengatur [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) agar memulai klip secara otomatis dan [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) ke preset keras.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengubah Thumbnail Audio Frame**

Secara default, audio frame menampilkan ikon speaker. Untuk menampilkan thumbnail khusus, tambahkan gambar ke presentasi dengan [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) dan tetapkan ke properti [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) frame. Contoh menggunakan JPEG sebagai thumbnail untuk klip audio yang disematkan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengubah Opsi Pemutaran Audio**

**Audio Options** PowerPoint mengontrol kapan klip dimulai, seberapa keras suaranya, dan bagaimana perilakunya selama tayangan slide.

![Kontrol Opsi Audio PowerPoint untuk frame audio](audio_frame_0.png)

| Kontrol PowerPoint | Properti Aspose.Slides |
| --- | --- |
| Mulai | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Preset volume | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Putar di Semua Slide | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Loop hingga Dihentikan | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Sembunyikan Selama Pertunjukan | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Putar Ulang Setelah Diputar | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Fade In | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Fade Out | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Memangkas Waktu Mulai Audio | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Memangkas Waktu Akhir Audio | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Slider Volume | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

Contoh menemukan audio frame pertama pada slide pertama, mengatur [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) agar memulai pemutaran saat diklik, dan memilih preset volume rendah. Klip terus berlanjut melewati slide dengan loop dinonaktifkan. Ikon tetap disembunyikan selama pertunjukan, dan klip diputar ulang setelah pemutaran.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Untuk klip lebih panjang dari 3,5 detik, contoh ini melewatkan 1,5 detik pertama dan 2 detik terakhir. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) mengukur durasi yang dihilangkan dari akhir klip. Untuk mendapatkan waktu akhir yang ditampilkan di PowerPoint, kurangi offset tersebut dari durasi keseluruhan klip. Klip yang dipangkas muncul perlahan selama 200 milidetik dan menghilang perlahan selama 500 milidetik. Keempat properti tersebut menerima nilai dalam milidetik.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Untuk mengatur volume pemutaran ke persentase tertentu, gunakan [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Contoh ini mengatur audio frame pertama pada slide pertama menjadi 85%.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengelola Caption Audio**

Setiap audio frame memiliki koleksi [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/). Gunakan untuk menambahkan caption WebVTT ke klip, mengekspor track yang ada, atau menghapusnya.

### **Menambahkan Caption Audio**

Contoh ini menyematkan klip audio pada slide pertama dan menggunakan [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) untuk menambahkan track WebVTT lokal. Argumen pertama berisi label track, dan argumen kedua mengidentifikasi file yang berisi caption berwaktu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Mengekspor Caption Audio**

Contoh ini mengekspor setiap caption track yang terlampir pada audio frame di slide pertama. Ia menulis [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) track ke file WebVTT dan menggunakan [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) sebagai nama file sehingga setiap track memiliki output terpisah.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **Menghapus Caption Audio**

Gunakan [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) atau [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) untuk menghapus track tertentu. Contoh ini menggunakan [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) untuk menghapus semua caption dari audio frame pertama pada slide pertama sambil mempertahankan klip.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Mencari Baris dalam Caption Audio**

Untuk menemukan baris dalam caption audio pada slide pertama, baca setiap [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) track dalam memori. Dalam cue WebVTT teks biasa, baris timing berisi `-->`, baris caption mengikutinya, dan baris kosong menandai akhir cue. Contoh ini mencetak label track dan setiap baris caption yang mengandung “café”.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **Mengekstrak Audio**

Transisi slide dapat memiliki suara sendiri. Untuk mengambilnya, bacalah properti [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) transisi. Contoh ini mengakses [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) suara dan mencetak ukuran dalam byte. Jika slide pertama tidak memiliki suara transisi, ia mencetak pesan sebagai gantinya.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **FAQ**

**Apakah saya dapat menggunakan kembali klip audio yang sama di beberapa slide tanpa menduplikasinya?**

Ya. Tambahkan klip sekali ke [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) presentasi dan berikan objek audio yang sama ke [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) untuk setiap slide.

**Apakah saya dapat mengganti suara dalam audio frame yang sudah ada?**

Ya. Untuk suara yang ditautkan, perbarui [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) agar mengarah ke file pengganti. Untuk suara yang disematkan, tetapkan klip lain dari audio collection presentasi ke [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Kedua pendekatan mempertahankan frame yang ada.

**Apakah pemangkasan mengubah data audio yang disimpan dalam presentasi?**

Tidak. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) dan [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) mengatur batas pemutaran. Anda masih dapat mengambil klip lengkap dari [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).