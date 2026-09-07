---
title: "Python'da PowerPoint Sunumlarını Videoya Dönüştür"
linktitle: "PowerPoint'tan Video"
type: docs
weight: 130
url: /tr/python-java/convert-powerpoint-to-video/
keywords:
  - "PowerPoint dönüştür"
  - "sunumu dönüştür"
  - "PPT dönüştür"
  - "PPTX dönüştür"
  - "PowerPoint'tan video"
  - "sunumdan video"
  - "PPT'den video"
  - "PPTX'den video"
  - "PowerPoint'tan MP4"
  - "sunumdan MP4"
  - "PPT'den MP4"
  - "PPTX'den MP4"
  - "PPT'yi MP4 olarak kaydet"
  - "PPTX'i MP4 olarak kaydet"
  - "PPT'yi MP4'e dışa aktar"
  - "PPTX'i MP4'e dışa aktar"
  - "video dönüşümü"
  - "PowerPoint"
  - "Python"
  - "Java"
  - "Aspose.Slides"
description: "Python üzerinden Java ile PowerPoint sunumlarını MP4 video olarak dönüştürün. Aspose.Slides ile çerçeveler oluşturun ve FFmpeg ile kodlayın, animasyonlar ve geçişler dahil."
---
## **Genel Bakış**

PowerPoint veya OpenDocument sunumunu videoya dönüştürmek, izleyicilerin bir sunum uygulaması açmadan içeriği bir video oynatıcıda izlemesini sağlar. Aspose.Slides for Python via Java, sunum animasyonlarını ve geçişlerini görüntü çerçevelerine render eder. FFmpeg gibi ayrı bir kodlayıcı, bu çerçeveleri bir video dosyasında birleştirir.

{{% alert color="info" title="Not" %}}
Çevrimiçi [PowerPoint to Video dönüştürücü](https://products.aspose.app/slides/tr/video) deneyerek sunumdan videoya dönüşümü eylemde görebilirsiniz.
{{% /alert %}}

## **PowerPoint'ı Videoya Dönüştür**

Dönüştürme iki aşamadan oluşur: seçilen kare hızıyla PNG çerçevelerini oluşturmak, ardından görüntü dizisini MP4 olarak kodlamak. Animasyon zamanlamasını korumak için her iki aşamada da aynı kare hızını kullanın.

**Örneği çalıştırmadan önce:**

1. Kurulum [Aspose.Slides for Python via Java](/slides/tr/python-java/installation/).
2. FFmpeg'i indirin ve yürütülebilir dosyasını `PATH` üzerinde erişilebilir hâle getirin. Örnek, `libx264` kodlayıcısına sahip bir derleme kullanır.
3. Aşağıdaki Python kodunu yazılabilir bir dizinde çalıştırın.

Örnek, giriş ve çıkış animasyonlarına sahip gülümseyen bir şekil oluşturur, çerçeveleri 30 FPS'de render eder ve FFmpeg'i `output.mp4` oluşturmak için çağırır. Yeni bir çerçeve dizini, önceki çalışmalardan gelen çerçevelerin videoya dahil edilmesini önler.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Mevcut bir dosyayı dönüştürmek için, yolunu vererek [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) başlatın ve şekil‑oluşturma ile animasyon‑oluşturma ifadelerini atlayın.

FFmpeg komutu, numaralı bir [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2) okur, tek boyutları çift değerlere yuvarlar ve `yuv420p` piksel formatıyla H.264 video yazar. `-n` seçeneği mevcut bir çıktı dosyasının üzerine yazılmasını önler. Oluşturulan PNG dosyaları çerçeve dizininde kalır; ihtiyaç kalmadığında silin.

{{% alert color="info" title="Not" %}}
Bu örnek yalnızca görüntü çerçevelerini kodlar. Çıktı videosuna anlatım veya gömülü sunum sesi eklemez.
{{% /alert %}}

## **Video Efektleri**

Animasyonlar, slayt nesnelerinin nasıl görüneceğini, hareket edeceğini veya kaybolacağını kontrol eder. Geçişler, slaytlar arasındaki değişimi kontrol eder. Bu efektleri video çerçeveleri oluşturmadan önce ekleyin.

See [PowerPoint Animasyonu](/slides/tr/python-java/powerpoint-animation/), [Şekil Animasyonu](/slides/tr/python-java/shape-animation/), [Şekil Efektleri](/slides/tr/python-java/shape-effect/), and [Slayt Geçişleri](/slides/tr/python-java/slide-transition/).

### **Slayt Geçişi Ekle**

Aşağıdaki bağımsız örnek, iki slayttan oluşan bir sunum oluşturur. İkinci slayt, magenta arka plana ve push (itme) geçişine sahiptir. Sunumu kaydedin, ardından yukarıdaki çerçeve‑oluşturma örneği için girdi olarak kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Paragrafları Canlandır**

Metin paragraf paragraf görünebilir. Bu örnek, ardışık solma giriş efektlerine sahip üç paragraf oluşturur, her biri bir önceki efektten bir saniye sonra gecikmeli. Kaydedilen `paragraphs.pptx` dosyasını video‑dönüştürme örneği için girdi olarak kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Video Dönüştürme Sınıfları**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationanimationsgenerator/) slaytlar için animasyon olayları üretir. Bir sunumdan oluşturulması, çerçeveler için sunumun slayt boyutunu kullanır. Varsayılan gecikmeyi milisaniye cinsinden ayarlamak için [setDefaultDelay](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) kullanın.

[PresentationPlayer](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationplayer/) oluşturulan animasyonları yapılandırıcıya verilen kare hızında örnekler. JPype üzerinden bir Python geri çağrısı kaydetmek için [setFrameTick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationplayer/#setFrameTick) kullanın, ardından çerçeveleri oluşturmak için [run](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationanimationsgenerator/#run) çağırın. İlk örnek, dosya adlarının FFmpeg'in giriş dizisiyle eşleşmesi için kendi sıfır‑tabanlı sayacını kullanır.

Bireysel animasyon durumları için, [setNewAnimation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation) ile bir geri çağrı kaydedin. Geri çağrı, seçili bir zaman diliminde konumlandırılabilen bir animasyon oynatıcı alır. Aşağıdaki örnek, her oluşturulan animasyonun ilk ve son çerçevelerini benzersiz dosya adlarıyla kaydeder:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Desteklenen Animasyonlar ve Efektler**

Aşağıdaki tablolar, Java dönüşüm makalesinde açıklanan render desteğini özetler. Bir sunum desteklenmeyen efektler kullandığında oluşturulan çerçeveleri ön izleyin.

**Giriş**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | Hayır | Evet |
| **Fade** | Evet | Evet |
| **Fly In** | Evet | Evet |
| **Float In** | Evet | Evet |
| **Split** | Evet | Evet |
| **Wipe** | Evet | Evet |
| **Shape** | Evet | Evet |
| **Wheel** | Evet | Evet |
| **Random Bars** | Evet | Evet |
| **Grow & Turn** | Hayır | Evet |
| **Zoom** | Evet | Evet |
| **Swivel** | Evet | Evet |
| **Bounce** | Evet | Evet |

**Vurgu**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | Hayır | Evet |
| **Color Pulse** | Hayır | Evet |
| **Teeter** | Evet | Evet |
| **Spin** | Evet | Evet |
| **Grow/Shrink** | Hayır | Evet |
| **Desaturate** | Hayır | Evet |
| **Darken** | Hayır | Evet |
| **Lighten** | Hayır | Evet |
| **Transparency** | Hayır | Evet |
| **Object Color** | Hayır | Evet |
| **Complementary Color** | Hayır | Evet |
| **Line Color** | Hayır | Evet |
| **Fill Color** | Hayır | Evet |

**Çıkış**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | Hayır | Evet |
| **Fade** | Evet | Evet |
| **Fly Out** | Evet | Evet |
| **Float Out** | Evet | Evet |
| **Split** | Evet | Evet |
| **Wipe** | Evet | Evet |
| **Shape** | Evet | Evet |
| **Random Bars** | Evet | Evet |
| **Shrink & Turn** | Hayır | Evet |
| **Zoom** | Evet | Evet |
| **Swivel** | Evet | Evet |
| **Bounce** | Evet | Evet |

**Hareket Yolları**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Evet | Evet |
| **Arcs** | Evet | Evet |
| **Turns** | Evet | Evet |
| **Shapes** | Evet | Evet |
| **Loops** | Evet | Evet |
| **Custom Path** | Evet | Evet |

## **SSS**

**Aspose.Slides doğrudan bir MP4 dosyası oluşturur mu?**

Hayır. Aspose.Slides sunum çerçeveleri üretir. Bunları bir MP4 dosyasına birleştirmek için FFmpeg gibi bir video kodlayıcı kullanın.

**Video beklenenden daha hızlı ya da daha yavaş neden oynatılıyor?**

Çerçeve oluşturma ve kodlayıcının giriş kare hızı için aynı FPS'i kullanın. Uyumsuzluk, görüntü dizisinin oynatma süresini değiştirir.

**Şifre korumalı bir sunumu dönüştürebilir miyim?**

Evet. [Şifre korumalı sunumu yüklerken](/slides/tr/python-java/password-protected-presentation/) doğru şifreyi sağlayın, ardından yüklenen içerikten çerçeveler oluşturun.

**Bu iş akışı sunum sesini korur mu?**

Örnekler görüntü çerçevelerini dışa aktarır, bu nedenle oluşan video sessizdir. Ses eklemek için video kodlama sırasında ayrı bir ses parçası sağlayın.

**Geçici disk kullanımını nasıl azaltabilirim?**

Daha küçük bir çerçeve boyutu veya daha düşük bir FPS kullanın ve başarılı kodlamadan sonra geçici PNG dosyalarını silin. Ayarları azaltırken oluşan video kalitesini kontrol edin.