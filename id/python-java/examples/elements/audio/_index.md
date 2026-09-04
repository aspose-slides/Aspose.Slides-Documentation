---
title: Audio
type: docs
weight: 70
url: /id/python-java/examples/elements/audio/
keywords:
- contoh kode
- audio
- bingkai audio
- tambahkan audio
- akses audio
- hapus audio
- pemutaran audio
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Gunakan Aspose.Slides for Python via Java untuk menambahkan, mengakses, menghapus, dan mengonfigurasi bingkai audio dalam presentasi PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara menyematkan bingkai audio dan mengontrol pemutaran menggunakan **Aspose.Slides for Python via Java**. Contoh-contoh berikut menunjukkan operasi audio dasar.

Instal paket seperti yang dijelaskan pada [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Add an Audio Frame**
Masukkan bingkai audio kosong yang kemudian dapat menampung data suara yang disematkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # Buat bingkai audio kosong (audio akan disematkan nanti).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Access an Audio Frame**
Kode ini mengambil bingkai audio pertama pada slide.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Akses bingkai audio pertama pada slide.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **Remove an Audio Frame**
Hapus bingkai audio yang sebelumnya ditambahkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Hapus bingkai audio.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Set Audio Playback**
Atur bingkai audio agar diputar secara otomatis saat slide muncul.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Mainkan secara otomatis saat slide muncul.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```