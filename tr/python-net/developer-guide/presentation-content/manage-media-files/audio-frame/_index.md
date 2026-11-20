---
title: Python Kullanarak Sunumlarda Ses Çerçevelerini Yönetme
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/python-net/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkarma
- WebVTT
- Python
- Aspose.Slides
description: "Sesleri slaytlara yerleştirin, ses simgesini değiştirin, oynatmayı yapılandırın, WebVTT altyazılarını yönetin ve Aspose.Slides for Python via .NET ile slayt geçiş seslerini çıkarın."
---
## **Genel Bakış**

Bir ses çerçevesi, bir slaytta ses çalmanızı sağlar. Aspose.Slides for Python via .NET ile bir ses klibini yerleştirebilir, onu temsil eden görüntüyü seçebilir, oynatmayı ayarlayabilir ve altyazılar ekleyebilirsiniz. Ayrıca bir slayt geçişine atanmış sesi de alabilirsiniz.

## **Ses Çerçeveleri Oluşturma**

Yerel bir ses klibini ilk slayta yerleştirmek için [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) kullanın. İlk iki koordinat çerçeveyi slaytta konumlandırır, sonraki iki değer ise genişlik ve yüksekliğini, hepsi puan cinsinden, ayarlar. Bu örnek, klibi otomatik olarak başlatmak için [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) ve yüksek ses ön ayarını seçmek için [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) ayarlar.

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
## **Ses Çerçevesi Küçük Resmini Değiştirme**

Varsayılan olarak, bir ses çerçevesi bir hoparlör simgesi gösterir. Özel bir küçük resim göstermek için sunuma [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) ile bir görüntü ekleyin ve bunu çerçevenin [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) özelliğine atayın. Örnek, yerleştirilmiş bir ses klibi için küçük resim olarak bir JPEG kullanır.

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
## **Ses Oynatma Seçeneklerini Değiştirme**

PowerPoint’in **Audio Options** kontrolleri, bir klibin ne zaman başlayacağını, ses seviyesini ve slayt gösterisi sırasında nasıl davranacağını belirler.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint kontrolü | Aspose.Slides özelliği |
| --- | --- |
| Başlat | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Ses ön ayarı | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Slaytlar Arasında Oynat | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Durdurulana Kadar Döngü | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Gösterim Sırasında Gizle | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Çalma Sonrası Geri Sar | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Yavaşça Giriş | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Yavaşça Çıkış | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Ses Başlangıç Zamanını Kırp | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Ses Bitiş Zamanını Kırp | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Ses Kaydırıcısı | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

Örnek, ilk slayttaki ilk ses çerçevesini bulur, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) ayarını tıklamayla çalmaya başlatacak şekilde belirler ve düşük ses ön ayarını seçer. Klib, döngü devre dışı bırakılarak slaytlar arasında devam eder. Simge gösterim sırasında gizli kalır ve klip çalma sonrasında tekrar oynatılır.

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
3,5 saniyeden uzun bir klip için bu örnek ilk 1,5 saniyeyi ve son 2 saniyeyi atlar. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) klibin sonundan çıkarılacak süreyi ölçer. PowerPoint’te gösterilen bitiş zamanını elde etmek için bu ofseti tam klip süresinden çıkarın. Kırpılan klip 200 milisaniye içinde yavaşça girer ve 500 milisaniye içinde yavaşça çıkar. Tüm dört özellik milisaniye cinsinden değer alır.

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
Oynatma ses seviyesini belirli bir yüzdeye ayarlamak için [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) kullanın. Bu örnek, ilk slayttaki ilk ses çerçevesini %85 olarak ayarlar.

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
## **Ses Altyazılarını Yönetme**

Her ses çerçevesinin bir [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) koleksiyonu vardır. Bu koleksiyonu klibe WebVTT altyazıları eklemek, mevcut izleri dışa aktarmak veya silmek için kullanın.

### **Ses Altyazısı Ekle**

Örnek, ilk slayta bir ses klibi yerleştirir ve yerel bir WebVTT izini eklemek için [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) kullanır. İlk argüman iz etiketini verir, ikinci argüman zamanlı altyazıları içeren dosyayı belirtir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```
### **Ses Altyazılarını Dışa Aktarma**

Bu örnek, ilk slayttaki bir ses çerçevesine eklenmiş her altyazı izini dışa aktarır. İz’in [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) değerini bir WebVTT dosyasına yazar ve dosya adını [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) değerine göre belirler, böylece her iz ayrı bir çıktı elde eder.

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
### **Ses Altyazılarını Kaldırma**

Bireysel bir iz silmek için [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) veya [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) kullanın. Örnek, klibi korurken ilk slayttaki ilk ses çerçevesinden tüm altyazıları kaldırmak için [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) yöntemini kullanır.

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
### **Ses Altyazılarında Bir Satır Bulma**

İlk slayttaki ses altyazılarında bir satır bulmak için, her izin [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) değerini bellekte okuyun. Düz metin bir WebVTT ipucunda zaman satırı `-->` içerir, alttaki satırlar altyazı satırlarıdır ve boş bir satır ipucunu sonlandırır. Bu örnek, iz etiketini ve “café” içeren her altyazı satırını yazdırır.

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
## **Ses Çıkarma**

Bir slayt geçişinin kendi sesi olabilir. Onu almak için geçişin [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) özelliğini okuyun. Örnek, sesin [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) değerine erişir ve bayt cinsinden boyutunu yazdırır. İlk slaytta geçiş sesi yoksa, bunun yerine bir mesaj yazdırır.

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
## **SSS**

**Aynı ses klibini birden fazla slaytta tekrarlamadan kullanabilir miyim?**

Evet. Klibi sunumun [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) içine bir kez ekleyin ve aynı ses nesnesini her slayt için [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) metoduna iletin.

**Mevcut bir ses çerçevesindeki sesi değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) değerini değiştirilmek istenen dosyayı gösterecek şekilde güncelleyin. Yerleştirilmiş bir ses için, sunumun ses koleksiyonundan başka bir klibi [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) özelliğine atayın. Her iki yaklaşım da mevcut çerçeveyi korur.

**Kırpma, sunumda depolanan ses verisini değiştirir mi?**

Hayır. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) ve [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) çalma sınırlarını belirler. Tam klibi hâlâ [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) üzerinden alabilirsiniz.