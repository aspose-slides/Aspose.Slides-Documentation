---
title: Tambahkan Video ke Presentasi dengan Python
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
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatik dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET. Panduan cara cepat."
---
## **Pengenalan**

Video yang ditempatkan dengan tepat dalam presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan dengan audiens Anda. 

PowerPoint memungkinkan Anda menambahkan video ke slide dalam presentasi dengan dua cara:

* Menambahkan atau menyematkan video lokal (disimpan di mesin Anda)
* Menambahkan video daring (dari sumber web seperti YouTube).

Agar Anda dapat menambahkan video (objek video) ke presentasi, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/) , kelas [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) , dan tipe relevan lainnya. 

## **Buat Bingkai Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/) dan berikan jalur file video untuk menyematkan video ke dalam presentasi. 
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) untuk membuat bingkai bagi video.  
1. Simpan presentasi yang telah dimodifikasi. 

Kode Python berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke presentasi:

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

Atau, Anda dapat menambahkan video dengan memberikan jalur file secara langsung ke metode `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint 2013 dan lebih baru](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) mendukung video YouTube dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) 
1. Dapatkan referensi slide melalui indeksnya. 
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/) dan berikan tautan ke video. 
1. Atur thumbnail untuk bingkai video. 
1. Simpan presentasi. 

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

## **Kelola Keterangan Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui properti [VideoFrame.caption_tracks](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/caption_tracks/) . 

**Tambahkan Caption ke Bingkai Video**

Untuk menambahkan caption ke bingkai video:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Tambahkan video ke presentasi. 
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) ke slide. 
1. Gunakan [CaptionsCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/) yang dikembalikan oleh [caption_tracks](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/caption_tracks/) untuk menambahkan trek caption WebVTT. 
1. Simpan presentasi yang telah dimodifikasi. 

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

Kelas [CaptionsCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari sebuah aliran. 

**Ekstrak Caption dari Bingkai Video**

Untuk mengekstrak caption dari bingkai video:

1. Muat presentasi yang berisi video. 
1. Temukan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) target. 
1. Iterasi melalui koleksi [caption_tracks](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/caption_tracks/) . 
1. Simpan setiap trek caption ke file `.vtt` . 

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

Setiap objek [Captions](https://reference.aspose.com/slides/id/python-net/aspose.slides/captions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF-8. 

**Hapus Caption dari Bingkai Video**

Untuk menghapus caption dari bingkai video:

1. Muat presentasi yang berisi video. 
1. Dapatkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) target. 
1. Hapus trek caption dari [CaptionsCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/) . 
1. Simpan presentasi yang telah dimodifikasi. 

Kode berikut menunjukkan cara menghapus semua caption dari bingkai video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Menghapus semua caption dari bingkai video.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/remove/) atau [remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/remove_at/) alih-alih [clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/captionscollection/clear/) . 

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk memuat presentasi yang berisi video. 
2. Iterasi melalui semua objek [Slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/) . 
3. Iterasi melalui semua objek [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) untuk menemukan [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) . 
4. Simpan video ke disk. 

Kode Python berikut menunjukkan cara mengekstrak video pada slide presentasi:

```python
import aspose.slides as slides

# Membuat objek Presentation yang mewakili file presentasi
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

Anda dapat mengontrol [playback mode](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/play_mode/) (otomatis atau saat diklik) dan [looping](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/play_loop_mode/) . Opsi-opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) . 

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Saat Anda menyematkan video lokal, data biner disertakan dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Saat Anda menambahkan video daring, hanya tautan dan thumbnail yang disematkan, sehingga peningkatan ukuran lebih kecil. 

**Apakah saya dapat mengganti video dalam VideoFrame yang ada tanpa mengubah posisi dan ukurannya?**

Ya. Anda dapat menukar [video content](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/embedded_video/) di dalam bingkai sambil mempertahankan geometri bentuk; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang ada. 

**Apakah tipe konten (MIME) video yang disematkan dapat ditentukan?**

Ya. Video yang disematkan memiliki [content type](https://reference.aspose.com/slides/id/python-net/aspose.slides/video/content_type/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.