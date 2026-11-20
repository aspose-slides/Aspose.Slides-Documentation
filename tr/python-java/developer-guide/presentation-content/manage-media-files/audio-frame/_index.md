---
title: Python Kullanarak Sunumlarda Ses Çerçevelerini Yönetme
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/python-java/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkar
- Python
- Aspose.Slides
description: "Sesleri slaytlara gömün, ses simgesini değiştirin, oynatmayı yapılandırın, WebVTT altyazılarını yönetin ve Aspose.Slides for Python via Java ile slayt geçiş seslerini çıkarın."
---
## **Genel Bakış**

Bir ses çerçevesi, bir slaytta ses çalmanızı sağlar. Aspose.Slides for Python via Java ile bir ses klibi gömebilir, onu temsil eden görüntüyü seçebilir, oynatmayı ayarlayabilir ve altyazılar ekleyebilirsiniz. Ayrıca bir slayt geçişine atanmış bir sesi de alabilirsiniz.

## **Ses Çerçeveleri Oluşturma**

`audio.wav` dosyasının baytlarını sunumun ses koleksiyonuna ekleyin, ardından [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) kullanarak yerel bir ses klibini ilk slayta gömün. İlk iki koordinat çerçeveyi slaytta konumlandırır, sonraki iki değer ise genişliğini ve yüksekliğini puan cinsinden ayarlar. Bu örnek, klibi otomatik olarak başlatmak için [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) ve yüksek ses ön ayarını seçmek için [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) metodlarını çağırır.

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
## **Ses Çerçevesi Küçük Resmini Değiştirme**

Varsayılan olarak, bir ses çerçevesi hoparlör simgesini gösterir. Özel bir küçük resim göstermek için, sunuma [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) ile bir görüntü ekleyin ve çerçevenin resmine [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) ile ayarlayın. Örnek, gömülü bir ses klibi için küçük resim olarak bir JPEG kullanır.

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
## **Ses Oynatma Seçeneklerini Değiştirme**

PowerPoint’in **Ses Seçenekleri** denetimleri, bir klibin ne zaman başlayacağını, ses seviyesini ve slayt gösterisi sırasında nasıl davranacağını belirler.

![Bir ses çerçevesi için PowerPoint Ses Seçenekleri denetimleri](audio_frame_0.png)

| PowerPoint denetimi | Aspose.Slides for Python via Java yöntemi |
| --- | --- |
| Başlat | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Ses ön ayarı | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Slaytlar Arasında Çal | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Durdurulana Kadar Döngü | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Gösterim Sırasında Gizle | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Oynatmadan Sonra Geri Sar | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| İçeri Kararma | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Dışarı Kararma | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Ses Başlangıç Zamanını Kes | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Ses Bitiş Zamanını Kes | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Ses Kaydırıcısı | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

Örnek, ilk slayttaki ilk ses çerçevesini bulur, tıklamayla oynatmayı başlatmak için [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) metodunu çağırır ve düşük ses ön ayarını seçer. Klip, döngü devre dışı bırakılarak slaytlar arasında devam eder. Simge gösterim sırasında gizli kalır ve klip oynatmadan sonra geri sarar.

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
        # Tıklamayla düşük ses seviyesinde, slaytlar arasında, döngüsüz çal.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Çerçeveyi slayt gösterisi sırasında gizle ve oynatmadan sonra geri sar.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

3,5 saniyeden uzun bir klip için bu örnek, ilk 1,5 saniyeyi ve son 2 saniyeyi atlar. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) klibin sonundan çıkarılacak süreyi alır. PowerPoint'te gösterilen bitiş zamanını elde etmek için bu ofseti tam klip süresinden çıkarın. Kesilen klip 200 milisaniye içinde içeri karar ve 500 milisaniye içinde dışarı karar. Tüm dört metod milisaniye cinsinden değer alır.

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

    # Başlangıçtan 1,5 saniye ve sondan 2 saniye kesin.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # İçeri kararmayı 200 ms, dışarı kararmayı 500 ms olarak ayarla.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Oynatma ses seviyesini belirli bir yüzdeye ayarlamak için [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) kullanın. Bu örnek, ilk slayttaki ilk ses çerçevesini %85 olarak ayarlar.

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
## **Ses Altyazılarını Yönetme**

Her ses çerçevesi, [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks) aracılığıyla altyazı izlerine erişim sağlar. Koleksiyonu, klibe WebVTT altyazıları eklemek, mevcut izleri dışa aktarmak veya silmek için kullanın.

### **Ses Altyazıları Ekleme**

Örnek, ilk slayta bir ses klibi gömer ve [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) kullanarak yerel bir WebVTT izi ekler. İlk argüman iz etiketini, ikincisi zamanlanmış altyazıları içeren dosyayı belirler.

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

    # WebVTT dosyasından yeni bir altyazı izi ekle.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Ses Altyazılarını Çıkarma**

Bu örnek, ilk slayttaki bir ses çerçevesine eklenmiş her altyazı izini dışa aktarır. [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) tarafından döndürülen baytları bir WebVTT dosyasına yazar ve [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) tarafından döndürülen tanımlayıcıyı dosya adı olarak kullanır; böylece her iz ayrı bir çıktı elde eder.

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
                # Altyazı izini .vtt dosyası olarak kaydet.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```
### **Ses Altyazılarını Kaldırma**

Tek bir izi silmek için [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) kullanın. Örnek, klibi korurken ilk slayttaki ilk ses çerçevesinden tüm altyazıları kaldırmak için [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) metodunu kullanır.

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
### **Ses Altyazılarında Bir Satırı Bulma**

İlk slayttaki ses altyazılarında bir satır bulmak için, bellekte [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) tarafından döndürülen metni arayın. Düz metin bir WebVTT ipucu içinde zaman satırı `-->` içerir, altyazı satırları onu takip eder ve boş bir satır ipucunu sonlandırır. Bu örnek, iz etiketini ve “café” içeren her altyazı satırını yazdırır.

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
## **Ses Çıkarma**

Bir slayt geçişinin kendi sesi olabilir. Bunu almak için slayt geçişinde [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) metodunu çağırın. Örnek, [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) tarafından döndürülen baytlara erişir ve bayt sayısını yazdırır. Eğer ilk slaytta geçiş sesi yoksa, bunun yerine bir mesaj yazdırır.

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
## **SSS**

**Aynı ses klibini birden fazla slaytta, kopyalamadan yeniden kullanabilir miyim?**

Evet. Klibi sunumun [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) içine bir kez ekleyin ve her slayt için aynı ses nesnesini [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) metoduna geçirin.

**Mevcut bir ses çerçevesindeki sesi değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, değiştirme dosyasına işaret etmek üzere [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) kullanın. Gömülü bir ses için, sunumun ses koleksiyonundan başka bir klibi [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio) ile seçin. Her iki yöntemde de mevcut çerçeve korunur.

**Kesme işlemi, sunumda saklanan ses verisini değiştirir mi?**

Hayır. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) ve [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) oynatma sınırlarını belirler. Tam klibi hâlâ [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) ile alabilirsiniz.