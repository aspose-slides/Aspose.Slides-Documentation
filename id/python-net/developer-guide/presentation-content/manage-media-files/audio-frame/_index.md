---
title: Kelola Audio dalam Presentasi Menggunakan Python
linktitle: Kerangka Audio
type: docs
weight: 10
url: /id/python-net/audio-frame/
keywords:
- tambahkan audio
- sematkan audio
- kerangka audio
- file audio
- properti audio
- ekstrak audio
- ambil audio
- ubah audio
- opsi pemutaran
- mode pemutaran
- putar lintas slide
- ulangi hingga dihentikan
- sembunyikan selama pertunjukan
- mundurkan setelah diputar
- volume audio
- gambar default
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Tambahkan, ekstrak, dan kelola kerangka audio dengan mudah dalam PPT, PPTX, dan ODP menggunakan Aspose.Slides untuk Python via .NET. Jelajahi contoh kode & tingkatkan presentasi Anda hari ini."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan audio frame di Aspose.Slides. Artikel ini menunjukkan cara menambahkan audio tersemat ke slide, menyesuaikan thumbnail audio frame, mengonfigurasi opsi pemutaran seperti volume, looping, penyembunyian, pemotongan, dan durasi fade, serta mengekstrak audio yang digunakan dalam transisi slide show.

## **Buat Audio Frame**

Aspose.Slides for Python via .NET memungkinkan Anda menambahkan file audio ke slide. File audio disematkan dalam slide sebagai audio frame.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Muat stream file audio yang ingin Anda sematkan ke slide.
4. Tambahkan audio frame yang disematkan (berisi file audio) ke slide.
5. Atur [PlayMode](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioplaymodepreset) dan `Volume` yang tersedia pada objek [IAudioFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/).
6. Simpan presentasi yang telah dimodifikasi.

Kode Python ini menunjukkan cara menambahkan audio frame yang disematkan ke slide:

```python
import aspose.slides as slides

# Membuat instance kelas presentasi yang merepresentasikan file presentasi
with slides.Presentation() as pres:
    # Mendapatkan slide pertama
    sld = pres.slides[0]

    # Memuat file suara wav ke stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Menambahkan Audio Frame
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Mengatur Mode Pemutaran dan Volume Audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Menulis file PowerPoint ke disk
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ubah Thumbnail Audio Frame**

Ketika Anda menambahkan file audio ke presentasi, audio muncul sebagai frame dengan gambar default standar (lihat gambar pada bagian di bawah). Anda dapat mengubah thumbnail audio frame (menetapkan gambar pilihan Anda).

Kode Python ini menunjukkan cara mengubah thumbnail atau gambar pratinjau audio frame:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Menambahkan audio frame ke slide dengan posisi dan ukuran yang ditentukan.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Menambahkan gambar ke sumber daya presentasi.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Mengatur gambar untuk audio frame.
        audioFrame.picture_format.picture.image = audioImage
        
        #Menyimpan presentasi yang telah dimodifikasi ke disk
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ubah Opsi Pemutaran Audio**

Aspose.Slides for Python via .NET memungkinkan Anda mengubah opsi yang mengontrol pemutaran atau properti audio. Misalnya, Anda dapat menyesuaikan volume audio, mengatur audio diputar berulang, atau bahkan menyembunyikan ikon audio.

Panel **Audio Options** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** PowerPoint yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/) :

- **Start** daftar drop-down cocok dengan properti [AudioFrame.play_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/play_mode/)
- **Volume** cocok dengan properti [AudioFrame.volume](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/volume/)
- **Play Across Slides** cocok dengan properti [AudioFrame.play_across_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/play_across_slides/)
- **Loop until Stopped** cocok dengan properti [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/play_loop_mode/)
- **Hide During Show** cocok dengan properti [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/hide_at_showing/)
- **Rewind after Playing** cocok dengan properti [AudioFrame.rewind_audio](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/rewind_audio/)

Opsi **Editing** PowerPoint yang sesuai dengan properti Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/) :

- **Fade In** cocok dengan properti [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/fade_in_duration/)
- **Fade Out** cocok dengan properti [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/fade_out_duration/)
- **Trim Audio Start Time** cocok dengan properti [AudioFrame.trim_from_start](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/trim_from_start/)
- **Trim Audio End Time** nilai sama dengan durasi audio dikurangi nilai properti [AudioFrame.trim_from_end](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/trim_from_end/)

Kontrol **Volume** PowerPoint pada panel kontrol audio sesuai dengan properti [AudioFrame.volume_value](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/volume_value/). Ini memungkinkan Anda mengubah volume audio dalam persentase.

Berikut cara mengubah opsi Pemutaran Audio:

1. [Buat](#create-audio-frame) atau dapatkan Audio Frame.
2. Atur nilai baru untuk properti Audio Frame yang ingin Anda ubah.
3. Simpan file PowerPoint yang telah dimodifikasi.

Kode Python ini mendemonstrasikan operasi di mana opsi audio disesuaikan:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Mendapatkan bentuk AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Mengatur mode Pemutaran menjadi pemutaran pada klik
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Mengatur Volume menjadi Rendah
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Mengatur audio untuk diputar lintas slide
    audioFrame.play_across_slides = True

    # Menonaktifkan loop untuk audio
    audioFrame.play_loop_mode = False

    # Menyembunyikan AudioFrame selama pertunjukan slide
    audioFrame.hide_at_showing = True

    # Mengembalikan audio ke awal setelah diputar
    audioFrame.rewind_audio = True

    # Menyimpan file PowerPoint ke disk
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Contoh Python ini menunjukkan cara menambahkan audio frame baru dengan audio tersemat, memotongnya, dan mengatur durasi fade:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Mengatur offset pemotongan awal menjadi 1,5 detik
    audio_frame.trim_from_start = 1500.0
    # Mengatur offset pemotongan akhir menjadi 2 detik
    audio_frame.trim_from_end = 2000.0

    # Mengatur durasi fade-in menjadi 200 ms
    audio_frame.fade_in_duration = 200.0
    # Mengatur durasi fade-out menjadi 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Contoh kode berikut menunjukkan cara mengambil audio frame dengan audio tersemat dan mengatur volumenya menjadi 85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Mendapatkan bentuk audio frame
    audio_frame = pres.slides[0].shapes[0]

    # Mengatur volume audio menjadi 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kelola Caption Audio**

Aspose.Slides memungkinkan Anda menambahkan caption tertutup ke audio frame melalui properti [caption_tracks](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/caption_tracks/). Properti ini mengembalikan [CaptionsCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/), yang memungkinkan Anda menambahkan trek caption WebVTT, mengiterasi trek yang ada, dan menghapusnya bila diperlukan.

**Tambah Caption Audio**

Gunakan properti [caption_tracks](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/caption_tracks/) untuk melampirkan satu atau lebih trek caption ke audio frame. Pada contoh berikut, file audio ditambahkan ke slide, kemudian trek caption baru dimuat dari file `.vtt`.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Tambahkan trek caption baru dari file WebVTT.
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Ekstrak Caption Audio**

Anda dapat mengiterasi trek caption yang terkait dengan audio frame dan menyimpannya sebagai file `.vtt`. Setiap trek caption mengungkapkan data biner dan pengidentifikasi uniknya, yang dapat digunakan saat mengekspor caption.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Simpan trek caption sebagai file .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Hapus Caption Audio**

Untuk menghapus caption dari audio frame, gunakan metode yang disediakan oleh [CaptionsCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/), seperti [clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/remove/), atau [remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/remove_at/). Contoh berikut menghapus semua trek caption dari audio frame.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # tipe: slides.AudioFrame

    # Hapus semua trek caption dari audio frame.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Ekstrak Audio**

Aspose.Slides for Python via .NET memungkinkan Anda mengekstrak suara yang digunakan dalam transisi slide show. Misalnya, Anda dapat mengekstrak suara yang digunakan pada slide tertentu.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi yang berisi audio.
2. Dapatkan referensi slide yang relevan melalui indeksnya.
3. Akses transisi slideshow untuk slide tersebut.
4. Ekstrak suara dalam bentuk data byte.

Kode Python ini menunjukkan cara mengekstrak audio yang digunakan pada slide:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Mengakses slide yang diinginkan
    slide = pres.slides[0]  

    # Mendapatkan efek transisi slideshow untuk slide
    transition = slide.slide_show_transition

    #Ekstrak suara dalam array byte
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Apakah saya dapat menggunakan kembali aset audio yang sama di beberapa slide tanpa memperbesar ukuran file?**

Ya. Tambahkan audio sekali ke [audio collection](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/audios/) bersama presentasi dan buat audio frame tambahan yang merujuk ke aset yang sudah ada. Ini mencegah duplikasi data media dan menjaga ukuran presentasi tetap terkendali.

**Apakah saya dapat mengganti suara dalam audio frame yang ada tanpa membuat ulang shape?**

Ya. Untuk suara yang ditautkan, perbarui [link path](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/link_path_long/) agar mengarah ke file baru. Untuk suara yang disematkan, gantikan objek [embedded audio](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/embedded_audio/) dengan yang lain dari [audio collection](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/audios/) presentasi. Format frame dan sebagian besar pengaturan pemutaran tetap utuh.

**Apakah pemotongan mengubah data audio dasar yang disimpan dalam presentasi?**

Tidak. Pemotongan hanya menyesuaikan batas pemutaran. Byte audio asli tetap tidak berubah dan dapat diakses melalui audio tersemat atau koleksi audio presentasi.