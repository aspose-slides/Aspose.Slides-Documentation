---
title: Menambahkan Video ke Presentasi dengan Python
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/python-net/video-frame/
keywords:
- menambahkan video
- membuat video
- menyematkan video
- mengekstrak video
- mengambil video
- bingkai video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatik di slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET. Panduan cepat langkah demi langkah."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam sebuah presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan audiens. 

PowerPoint memungkinkan Anda menambahkan video ke slide dalam sebuah presentasi dengan dua cara:

* Menambahkan atau menyematkan video lokal (disimpan di komputer Anda)
* Menambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke sebuah presentasi, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/) , kelas [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) , dan tipe terkait lainnya. 

## **Buat Bingkai Video Tersemat**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video ke dalam presentasi Anda. 

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [Video](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/) dan berikan jalur file video untuk menyematkan video ke dalam presentasi. 
4. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) untuk membuat bingkai bagi video.  
5. Simpan presentasi yang telah dimodifikasi. 

Kode Python berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke dalam presentasi:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Mendapatkan slide pertama dan menambahkan bingkai video
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Menyimpan presentasi ke disk
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Selain itu, Anda dapat menambahkan video dengan memberikan jalur file secara langsung ke metode `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Versi terbaru Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) mendukung video daring dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [Video](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/) dan berikan tautan ke video.
4. Atur thumbnail untuk bingkai video. 
5. Simpan presentasi. 

Kode Python berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Menambahkan videoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Memuat thumbnail
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Pangkas Bingkai Video**

Aspose.Slides memungkinkan Anda mengontrol bagian video yang diputar dengan mengatur nilai trim-from-start dan trim-from-end melalui [VideoFrame.trim_from_start](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/trim_from_start/) dan [VideoFrame.trim_from_end](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/trim_from_end/). Kedua nilai ditentukan dalam milidetik dan mendefinisikan berapa banyak waktu yang dilewati dari awal dan akhir video, masing-masing. Pengaturan ini mengubah pengaturan pemutaran video dalam presentasi; tidak memotong atau memodifikasi data biner video yang disematkan.

**Atur Pengaturan Pemangkasan**

Untuk membuat bingkai video dan mengatur pengaturan pemangkasannya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Tambahkan objek [Video](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/) ke presentasi.
3. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) ke slide.
4. Atur nilai trim-from-start dan trim-from-end melalui [VideoFrame.trim_from_start](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/trim_from_start/) dan [VideoFrame.trim_from_end](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/trim_from_end/) .
5. Simpan presentasi yang telah dimodifikasi.

Contoh kode berikut melewatkan 2,5 detik pertama dan 1 detik terakhir dari video yang disematkan selama pemutaran:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Baca Pengaturan Pemangkasan**

Untuk memeriksa pengaturan pemangkasan yang ada, muat sebuah presentasi, temukan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) di antara bentuk‑bentuk pada slide pertama, dan baca nilai‑nilainya melalui [VideoFrame.trim_from_start](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/trim_from_start/) dan [VideoFrame.trim_from_end](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/trim_from_end/) .

Contoh kode berikut menemukan bingkai video pertama pada slide pertama dan melaporkan pengaturan pemangkasan dalam milidetik:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui properti [VideoFrame.caption_tracks](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/caption_tracks/) .

**Tambahkan Caption ke Bingkai Video**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Tambahkan video ke presentasi.
3. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) ke slide.
4. Gunakan [CaptionsCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/) yang dikembalikan oleh [caption_tracks](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/caption_tracks/) untuk menambahkan trek caption WebVTT.
5. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menambahkan caption ke bingkai video:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Menambahkan trek caption baru dari file WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari aliran data.

**Ekstrak Caption dari Bingkai Video**

1. Muat presentasi yang berisi video.
2. Temukan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) target.
3. Iterasi melalui koleksi [caption_tracks](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/caption_tracks/) .
4. Simpan setiap trek caption ke file `.vtt` .

Kode berikut menunjukkan cara mengekstrak caption dari bingkai video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Menyimpan trek caption ke file WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Setiap objek [Captions](https://reference.aspose.com/slides/id/python-net/aspose.slides/captions/) menampilkan pengidentifikasi caption, label, data biner, dan teks caption sebagai string UTF-8.

**Hapus Caption dari Bingkai Video**

1. Muat presentasi yang berisi video.
2. Dapatkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) target.
3. Hapus trek caption dari [CaptionsCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/) .
4. Simpan presentasi yang telah dimodifikasi.

Kode berikut menunjukkan cara menghapus semua caption dari bingkai video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # tipe: slides.VideoFrame

    # Menghapus semua caption dari bingkai video.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda hanya perlu menghapus satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/remove/) atau [remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/remove_at/) alih‑alih [clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/clear/) .

## **Ekstrak Video Dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk memuat presentasi yang berisi video. 
2. Iterasi melalui semua objek [Slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/) .
3. Iterasi melalui semua objek [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) untuk menemukan [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) . 
4. Simpan video ke disk.

Kode Python berikut menunjukkan cara mengekstrak video pada slide presentasi:

```python
import aspose.slides as slides

# Menginstansiasi objek Presentation yang merepresentasikan file presentasi
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk VideoFrame?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/play_mode/) (otomatis atau saat diklik) dan [pengulangan](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/play_loop_mode/). Opsi‑opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) .

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner dimasukkan ke dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menambahkan video daring, hanya tautan dan thumbnail yang disematkan, sehingga peningkatan ukuran lebih kecil.

**Bisakah saya mengganti video dalam VideoFrame yang ada tanpa mengubah posisinya dan ukurannya?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/embedded_video/) dalam bingkai sambil mempertahankan geometri bentuk; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang sudah ada.

**Apakah tipe konten (MIME) dari video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [tipe konten](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/content_type/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.