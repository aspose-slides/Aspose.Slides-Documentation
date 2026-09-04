---
title: Ses
type: docs
weight: 70
url: /tr/python-java/examples/elements/audio/
keywords:
- kod örneği
- ses
- ses çerçevesi
- ses ekle
- sese erişim
- sesi kaldır
- ses çalma
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'ı kullanarak PowerPoint ve OpenDocument sunumlarında ses çerçevelerini ekleyin, erişin, kaldırın ve yapılandırın."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak ses çerçevelerini gömmeyi ve çalma kontrolünü göstermektedir. Aşağıdaki örnekler temel ses işlemlerini göstermektedir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` kütüphanesini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Ses Çerçevesi Ekle**

Daha sonra gömülü ses verisini tutabilecek boş bir ses çerçevesi ekleyin.

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

    # Boş bir ses çerçevesi oluştur (ses daha sonra gömülecek).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Ses Çerçevesine Erişim**

Bu kod, bir slayttaki ilk ses çerçevesini alır.

```python
import jpype
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

    # Slayttaki ilk ses çerçevesine erişim.
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

## **Ses Çerçevesini Kaldır**

Daha önce eklenmiş bir ses çerçevesini silin.

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

    # Ses çerçevesini kaldır.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Ses Çalma Ayarları**

Ses çerçevesini, slayt göründüğünde otomatik olarak çalacak şekilde yapılandırın.

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

    # Slayt göründüğünde otomatik olarak çal.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```