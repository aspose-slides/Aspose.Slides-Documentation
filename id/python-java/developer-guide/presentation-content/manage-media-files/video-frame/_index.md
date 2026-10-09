---
title: Kelola Frame Video dalam Presentasi Menggunakan Python
linktitle: Frame Video
type: docs
weight: 10
url: /id/python-java/video-frame/
keywords:
- menambahkan video
- membuat video
- menyematkan video
- mengekstrak video
- mengambil video
- frame video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak frame video secara programatik dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via Java. Panduan singkat cepat."
---
## **Pendahuluan**

Video dapat membantu menjelaskan ide-ide dan menarik perhatian audiens. Aspose.Slides untuk Python via Java memungkinkan Anda menambahkan frame video ke slide, menyesuaikan pengaturan pemutaran, mengelola caption, dan mengekstrak data video yang tertanam.

PowerPoint mendukung video lokal dan tautan ke video daring, seperti video YouTube.

Untuk merepresentasikan data video dan frame video, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) , kelas [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) , dan tipe relevan lainnya.

## **Membuat Frame Video yang Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat frame video untuk menanam video ke dalam presentasi.

Contoh ini menanam video lokal pada slide pertama dari presentasi yang sudah ada dan menyimpan hasilnya. Koordinat dan dimensi frame dalam satuan poin. Python membaca byte video dari disk, dan JPype mengkonversinya menjadi array byte Java sebelum video ditambahkan ke presentasi.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Anda juga dapat memberikan jalur video lokal langsung ke [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Contoh ini menanam video pada slide pertama dari presentasi baru. Video harus tetap dapat diakses hingga presentasi disimpan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Membuat Frame Video dengan Video dari Sumber Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) mendukung video daring dalam presentasi. Anda dapat membuat frame video yang menautkan ke video daring, seperti video YouTube.

Contoh ini menambahkan tautan video YouTube dan thumbnail ke slide pertama. Ganti pengidentifikasi video untuk menggunakan video lain. Metode [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) meminta pemutaran otomatis. Mengunduh thumbnail dan memutar video memerlukan akses internet. Penampil presentasi juga harus mendukung pemutaran video daring.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Memutar Video dalam Mode Layar Penuh**

Dalam presentasi pelatihan, Anda dapat memutar demonstrasi perangkat lunak dalam mode layar penuh agar audiens dapat melihat detailnya. Panggil [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) dengan `True` untuk mengaktifkan perilaku ini selama pemutaran.

Contoh ini membuka presentasi, menemukan [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) pertama pada slide pertama, dan mengaktifkan pemutaran layar penuh. Presentasi input harus berisi setidaknya satu slide dengan frame video yang sudah ada pada slide pertama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pemutaran layar penuh mengontrol cara video ditampilkan. Secara terpisah, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) mengontrol apakah video mulai otomatis atau saat diklik, dan [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) mengontrol apakah video berulang. Untuk memilih perilaku mulai, atur mode pemutaran ke [VideoPlayModePreset.Auto atau VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Contoh ini mempertahankan pengaturan mulai dan loop yang sudah ada.

## **Membalik Video Setelah Pemutaran**

Dalam presentasi pelatihan, mengembalikan video demonstrasi ke awal membuatnya siap untuk diputar lagi oleh presenter. Panggil [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) dengan `True` untuk mengembalikan video ke awal setelah pemutaran selesai.

Contoh ini membuka presentasi, menemukan [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) pertama pada slide pertama, dan mengaktifkan pembalikan. Contoh ini menonaktifkan looping agar pemutaran dapat selesai dan mengatur pemutaran agar dimulai saat diklik. Presentasi input harus berisi setidaknya satu slide dengan frame video yang sudah ada pada slide pertama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pembalikan mengembalikan video ke awal tanpa memulai ulang. Sebaliknya, memanggil [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) dengan `True` akan mengulang pemutaran secara otomatis. Biarkan looping dinonaktifkan ketika Anda ingin video selesai dan tetap siap diputar kembali. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) secara terpisah mengontrol mulai otomatis atau saat diklik; contoh ini menggunakan [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) sehingga presenter mengendalikan kapan pemutaran dimulai. Atur mode pemutaran setelah pengaturan loop, seperti yang ditunjukkan dalam contoh. Pembalikan berfungsi secara independen dari [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Memotong Frame Video**

Gunakan [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) dan [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) untuk melewatkan bagian awal atau akhir video selama pemutaran. Kedua nilai dalam milidetik. Pemotongan mengubah pengaturan pemutaran tanpa mengubah data video yang tertanam.

**Mengatur Pengaturan Pemotongan**

Contoh ini menanam video lokal dan melewatkan 2,5 detik pertama serta satu detik terakhir selama pemutaran. Gunakan video yang lebih panjang dari 3,5 detik sehingga segmen yang dapat diputar tetap ada.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Membaca Pengaturan Pemotongan**

Contoh ini mencetak nilai pemotongan dari frame video pertama pada slide pertama dalam milidetik. Presentasi harus berisi setidaknya satu slide. Jika slide tersebut tidak memiliki frame video, tidak ada yang dicetak. Contoh sebelumnya menghasilkan nilai 2500 dan 1000.

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

## **Mengelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola caption tertutup untuk frame video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Menambahkan Caption ke Frame Video**

Contoh ini menanam video lokal dan menambahkan trek caption WebVTT dengan label English. Stempel waktu caption harus cocok dengan video. Presentasi yang disimpan mencakup video dan captionnya.

```python
from pathlib import Path

import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Tambahkan trek caption baru dari file WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) juga menyediakan overload yang memungkinkan Anda menambahkan caption dari sebuah stream.

**Mengekstrak Caption dari Frame Video**

Contoh ini menyimpan semua trek caption dari frame video pada slide pertama sebagai file WebVTT terpisah. Nomor berurutan menjaga file keluaran tetap berbeda. Konsol melaporkan jumlah trek yang diekstrak. Presentasi harus berisi setidaknya satu slide.

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Setiap objek [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) menampilkan pengidentifikasi caption, label, data biner, dan teks caption sebagai string UTF-8.

**Menghapus Caption dari Frame Video**

Contoh ini menghapus semua caption dari frame video pada posisi shape pertama pada slide pertama dan menyimpan hasilnya. Contoh ini mengasumsikan bahwa slide dan shape ada serta shape tersebut adalah frame video.

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
        # Hapus semua caption dari frame video.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Jika Anda perlu menghapus hanya satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) alih-alih [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Mengekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang tertanam dalam presentasi.

Contoh ini mengekstrak video tertanam dari setiap slide ke dalam file biner bernomor terpisah. Video yang ditautkan dilewati karena tidak memiliki data tertanam. Konsol mencetak tipe MIME setiap video dan total jumlahnya. Output menggunakan ekstensi `.bin` generik; ubah sesuai tipe media yang dilaporkan bila diperlukan.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk sebuah frame video?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (otomatis atau pada klik) dan [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Opsi-opsi ini tersedia melalui metode objek [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menanam video lokal, data biner disertakan dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menautkan ke video daring dan menambahkan thumbnail, presentasi menyimpan tautan dan gambar pratinjau alih-alih data video, sehingga peningkatan ukuran biasanya lebih kecil.

**Bisakah saya mengganti video dalam frame video yang sudah ada tanpa mengubah posisi dan ukuran?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) di dalam frame sambil mempertahankan geometri shape; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang sudah ada.

**Apakah tipe konten (MIME) video yang tertanam dapat ditentukan?**

Ya. Video yang tertanam memiliki [tipe konten](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.