---
title: Kelola Bingkai Video dalam Presentasi Menggunakan Python
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/python-java/video-frame/
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
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatik dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via Java. Panduan cepat cara melakukannya."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam sebuah presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan dengan audiens Anda.

PowerPoint memungkinkan Anda menambahkan video ke slide dalam presentasi dengan dua cara:

* Tambahkan atau sematkan video lokal (disimpan di komputer Anda)
* Tambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke presentasi, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/id/python-java/aspose.slides/video/) , kelas [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) , dan tipe relevan lainnya.

## **Buat Bingkai Video Tersemat**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video dalam presentasi Anda.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/python-java/aspose.slides/video/) dan berikan data file video untuk menyematkan video ke dalam presentasi.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) untuk membuat bingkai bagi video.
1. Simpan presentasi yang telah dimodifikasi.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sebagai alternatif, Anda dapat menambahkan video dengan memberikan jalur file secara langsung ke metode [addVideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addVideoFrame) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint 2013 dan yang lebih baru](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) mendukung video YouTube dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) dan berikan tautan ke video.
1. Atur thumbnail untuk bingkai video.
1. Simpan presentasi.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Muat thumbnail.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Potong Bingkai Video**

Aspose.Slides memungkinkan Anda mengontrol bagian video yang diputar dengan mengatur nilai trim-from-start dan trim-from-end melalui [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#setTrimFromStart) dan [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#setTrimFromEnd) . Kedua nilai ditentukan dalam milidetik dan menentukan berapa banyak waktu yang dilewati dari awal dan akhir video masing‑masing. Pengaturan ini mengubah pengaturan pemutaran video dalam presentasi; mereka tidak memotong atau mengubah data biner video yang tersemat.

**Atur Pengaturan Pemangkasan**

Untuk membuat bingkai video dan mengatur pengaturan pemangkasan:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Tambahkan objek [Video](https://reference.aspose.com/slides/id/python-java/aspose.slides/video/) ke presentasi.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) ke slide.
1. Atur nilai trim-from-start dan trim-from-end melalui [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#setTrimFromStart) dan [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Simpan presentasi yang telah dimodifikasi.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Baca Pengaturan Pemangkasan**

Untuk memeriksa pengaturan pemangkasan yang ada, muat sebuah presentasi, temukan objek [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) di antara bentuk‑bentuk pada slide pertama, dan baca nilai‑nilainya melalui [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#getTrimFromStart) dan [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**Tambahkan Caption ke Bingkai Video**

Untuk menambahkan caption ke bingkai video:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Tambahkan video ke presentasi.
1. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) ke slide.
1. Gunakan [CaptionsCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/) yang dikembalikan oleh [getCaptionTracks](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#getCaptionTracks) untuk menambahkan trek caption WebVTT.
1. Simpan presentasi yang telah dimodifikasi.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Tambahkan trek caption baru dari file WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari sebuah stream.

**Ekstrak Caption dari Bingkai Video**

Untuk mengekstrak caption dari bingkai video:

1. Muat presentasi yang berisi video.
1. Temukan objek [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) target.
1. Iterasi melalui trek caption dalam [CaptionsCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/) .
1. Simpan setiap trek caption ke file `.vtt` .

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Simpan trek caption ke file WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Setiap objek [Captions](https://reference.aspose.com/slides/id/python-java/aspose.slides/captions/) menampilkan identifier caption, label, data biner, dan teks caption sebagai string UTF‑8.

**Hapus Caption dari Bingkai Video**

Untuk menghapus caption dari bingkai video:

1. Muat presentasi yang berisi video.
1. Dapatkan objek [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) target.
1. Hapus trek caption dari [CaptionsCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/) .
1. Simpan presentasi yang telah dimodifikasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Hapus semua caption dari bingkai video.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Jika Anda hanya perlu menghapus satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#removeAt) alih‑alih [clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/captionscollection/#clear) .

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang tersemat dalam presentasi.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) untuk memuat presentasi yang berisi video.
2. Iterasi semua objek [Slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/) .
3. Iterasi semua objek [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) untuk menemukan sebuah [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) .
4. Simpan video ke disk.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk VideoFrame?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#setPlayMode) (otomatis atau saat diklik) dan [looping](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#setPlayLoopMode) . Opsi‑opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) .

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Saat Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Saat Anda menambahkan video daring, hanya tautan dan thumbnail yang disematkan, sehingga peningkatan ukuran lebih kecil.

**Bisakah saya mengganti video dalam VideoFrame yang ada tanpa mengubah posisinya dan ukuran?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/#setEmbeddedVideo) di dalam bingkai sambil mempertahankan geometris bentuk; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang sudah ada.

**Dapatkah tipe konten (MIME) video yang tersemat ditentukan?**

Ya. Video yang tersemat memiliki [tipe konten](https://reference.aspose.com/slides/id/python-java/aspose.slides/video/#getContentType) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.