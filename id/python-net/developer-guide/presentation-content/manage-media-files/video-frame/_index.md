---
title: Kelola Bingkai Video dalam Presentasi dengan Python
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/python-net/video-frame/
keywords:
- tambahkan video
- buat video
- sematkan video
- ekstrak video
- ambil video
- bingkai video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatik dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET. Panduan singkat yang cepat."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide dan menarik perhatian audiens. Aspose.Slides untuk Python via .NET memungkinkan Anda menambahkan bingkai video ke slide, menyesuaikan pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang disematkan.

PowerPoint mendukung video lokal dan tautan ke video online, seperti video YouTube.

Untuk merepresentasikan data video dan bingkai video, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/), kelas [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) , dan tipe terkait lainnya.

## **Buat Bingkai Video yang Disematkan**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda.

Contoh ini menyematkan video lokal pada slide pertama dari presentasi yang sudah ada dan menyimpan hasilnya. Koordinat bingkai dan dimensinya dalam poin. Aliran tetap terbuka hingga penyimpanan selesai karena [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) menguncinya selama presentasi menggunakannya.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Anda juga dapat memberikan jalur video lokal secara langsung ke [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Contoh ini menyematkan video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video online dalam presentasi. Anda dapat membuat bingkai video yang menautkan ke video online, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti pengenal video untuk menggunakan video lain. Pengaturan [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video online.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Putar Video dalam Mode Layar Penuh**

Dalam presentasi pelatihan, Anda dapat memutar demonstrasi perangkat lunak dalam mode layar penuh agar audiens dapat melihat detailnya. Atur [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) ke `True` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka presentasi, menemukan [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi input harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

Pemutaran layar penuh mengontrol cara video ditampilkan. Secara terpisah, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) mengontrol apakah video mulai secara otomatis atau pada klik, dan [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) mengontrol apakah video berulang. Untuk memilih perilaku mulai, setel mode pemutaran ke [VideoPlayModePreset.AUTO atau VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan mulai dan putar ulang yang ada.

## **Putar Ulang Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awal membuatnya siap bagi presenter untuk memutar kembali. Atur [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) ke `True` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka presentasi, menemukan [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) pertama pada slide pertama, dan mengaktifkan putar ulang. Contoh ini menonaktifkan putar berulang sehingga pemutaran dapat selesai dan mengatur pemutaran untuk mulai pada klik. Presentasi input harus berisi setidaknya satu slide dengan bingkai video yang ada pada slide pertama.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Putar ulang mengembalikan video ke awal tanpa memulai kembali. Sebaliknya, mengaktifkan [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) akan mengulang pemutaran secara otomatis. Biarkan putar berulang dinonaktifkan ketika Anda ingin video selesai dan tetap siap diputar kembali. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) secara terpisah mengendalikan startup otomatis atau pada klik; contoh ini menggunakan [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) sehingga presenter yang mengontrol kapan pemutaran dimulai. Atur mode pemutaran setelah pengaturan putar berulang, seperti yang ditunjukkan dalam contoh. Putar ulang bekerja terlepas dari [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Potong Bingkai Video**

Gunakan [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) dan [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) untuk melewatkan bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemotongan mengubah pengaturan pemutaran tanpa memodifikasi data video yang disematkan.

**Atur Pengaturan Pemotongan**

Contoh ini menyematkan video lokal dan melewatkan 2,5 detik pertama serta 1 detik terakhir selama pemutaran. Gunakan video yang lebih panjang dari 3,5 detik agar segmen yang dapat diputar tetap ada.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Baca Pengaturan Pemotongan**

Contoh ini mencetak nilai pemotongan dari bingkai video pertama pada slide pertama dalam milidetik. Presentasi harus berisi setidaknya satu slide. Jika slide tersebut tidak memiliki bingkai video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui properti [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**Tambahkan Caption ke Bingkai Video**

Contoh ini menyematkan video lokal dan menambahkan jalur caption WebVTT berlabel English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan captionnya.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari aliran.

**Ekstrak Caption dari Bingkai Video**

Contoh ini menyimpan semua jalur caption dari bingkai video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga file keluaran tetap berbeda. Konsol melaporkan jumlah jalur yang diekstrak. Presentasi harus berisi setidaknya satu slide.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Setiap objek [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) menampilkan pengenal caption, label, data biner, dan teks caption sebagai string UTF-8.

**Hapus Caption dari Bingkai Video**

Contoh ini menghapus semua caption dari bingkai video pada posisi shape pertama di slide pertama dan menyimpan hasilnya. Contoh mengasumsikan bahwa slide dan shape ada serta shape tersebut adalah bingkai video.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda perlu menghapus hanya satu jalur caption, gunakan metode [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) atau [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) alih-alih [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

Contoh ini mengekstrak video yang disematkan dari setiap slide ke file biner terpisah yang diberi nomor. Video yang ditautkan dilewati karena tidak memiliki data yang disematkan. Konsol mencetak tipe MIME setiap video serta total jumlahnya. Output menggunakan ekstensi umum `.bin`; ubah sesuai tipe media yang dilaporkan bila diperlukan.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk bingkai video?**

Anda dapat mengontrol [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (otomatis atau pada klik) dan [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Opsi-opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner dimasukkan ke dalam dokumen, sehingga ukuran presentasi bertambah proporsional dengan ukuran file video. Ketika Anda menautkan ke video online dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam bingkai video yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) di dalam bingkai sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada.

**Bisakah tipe konten (MIME) video yang disematkan diketahui?**

Ya. Video yang disematkan memiliki [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.