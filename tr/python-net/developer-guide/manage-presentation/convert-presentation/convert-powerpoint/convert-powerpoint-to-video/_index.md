---
title: PowerPoint Sunumlarını Python'da Videoya Dönüştür
linktitle: PowerPoint'ten Video
type: docs
weight: 130
url: /tr/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint'ten videoya
- PowerPoint'i videoya dönüştür
- sunumu videoya
- sunumu videoya dönüştür
- PPT'den videoya
- PPT'yi videoya dönüştür
- PPTX'ten videoya
- PPTX'i videoya dönüştür
- ODP'den videoya
- ODP'yi videoya dönüştür
- PowerPoint'ten MP4'e
- PowerPoint'i MP4'e dönüştür
- sunumu MP4'e
- sunumu MP4'e dönüştür
- PPT'den MP4'e
- PPT'yi MP4'e dönüştür
- PPTX'ten MP4'e
- PPTX'i MP4'e dönüştür
- PowerPoint'ten video dönüşümü
- sunumu video dönüşümü
- PPT'den video dönüşümü
- PPTX'ten video dönüşümü
- ODP'den video dönüşümü
- Python video dönüşümü
- PowerPoint
- Python
- Aspose.Slides
description: "Python kullanarak PowerPoint ve OpenDocument sunumlarını videoya nasıl dönüştüreceğinizi öğrenin. İş akışınızı kolaylaştırmak için örnek kod ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint veya OpenDocument sunumunuzu videoya dönüştürerek şunları elde edersiniz:

**Artırılmış erişilebilirlik:** Tüm cihazlar, platform fark etmeksizin, varsayılan olarak video oynatıcılarla donatılmıştır, bu da kullanıcıların geleneksel sunum uygulamalarına göre videoları açmasını veya oynatmasını kolaylaştırır.

**Daha geniş erişim:** Videolar daha büyük bir izleyici kitlesine ulaşmanızı ve bilgiyi daha çekici bir formatta sunmanızı sağlar. Anketler ve istatistikler, insanların diğer biçimlere göre video içeriğini izlemeyi tercih ettiğini gösteriyor, bu da mesajınızın daha etkili olmasını sağlar.

{{% alert color="primary" %}} 
Şu anda açıklanan sürecin canlı ve etkili bir uygulamasını sunduğu için lütfen [**PowerPoint'ten Video'ya Çevrimiçi Dönüştürücü**](https://products.aspose.app/slides/tr/video) kontrol edin.
{{% /alert %}} 

[Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/tr/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) sürümünde, sunumları videoya dönüştürme desteği ekledik.

* Sunum slaytlarından belirtilen kare hızı (FPS) ile kareler oluşturmak için Aspose.Slides for Python kullanın.  
* Ardından, bu kareleri bir videoya derlemek için ffmpeg gibi üçüncü taraf bir yardımcı program kullanın.

## **PowerPoint Sunumunu Videoya Dönüştür**

1. Projeye Aspose.Slides for Python eklemek için pip install komutunu kullanın: `pip install aspose-slides==24.4.0`
2. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin veya paket yöneticisi aracılığıyla kurun.
3. ffmpeg'in `PATH` içinde olduğundan emin olun. Aksi takdirde, ffmpeg'i ikili dosyanın tam yolu ile başlatın (ör. Windows'ta `C:\ffmpeg\ffmpeg.exe` veya Linux'ta `/opt/ffmpeg/ffmpeg`).
4. PowerPoint'ten video dönüşüm kodunu çalıştırın.

Bu Python kodu, bir şekil ve iki animasyon efekti içeren bir sunumu videoya nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **Video Efektleri**

PowerPoint sunumunu Aspose.Slides for Python ile videoya dönüştürürken, çıktının görsel kalitesini artırmak için çeşitli video efektleri uygulayabilirsiniz. Bu efektler, slaytların son videodaki görünümünü pürüzsüz geçişler, animasyonlar ve diğer görsel öğeler ekleyerek kontrol etmenizi sağlar. Bu bölüm, mevcut video efekt seçeneklerini açıklar ve nasıl uygulanacağını gösterir.

{{% alert color="primary" %}} 
Bakınız [PowerPoint Animasyonu](https://docs.aspose.com/slides/tr/python-net/powerpoint-animation/), [Şekil Animasyonu](https://docs.aspose.com/slides/tr/python-net/shape-animation/), ve [Şekil Efekti](https://docs.aspose.com/slides/tr/python-net/shape-effect/).
{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha ilgi çekici ve eğlenceli hâle getirir — videolar için de aynı şey geçerlidir. Önceki sunum koduna bir başka slayt ve geçiş ekleyelim:

```python
import aspose.pydrawing as drawing

# Bir gülümseme şekli ekleyin ve hareketlendirin.
# ...

# Yeni bir slayt ekleyin ve animasyonlu bir geçiş ekleyin.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python ayrıca metin animasyonlarını da destekler. Bu örnekte, nesneler üzerindeki paragrafları birbiri ardına, aralarında bir saniyelik gecikme ile canlandırıyoruz:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Metin ve animasyon ekle.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Çerçeveleri videoya dönüştür.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Video Dönüştürme Sınıfları**

PowerPoint'ten video dönüşüm görevlerini etkinleştirmek için Aspose.Slides for Python, [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/presentationenumerableframesgenerator/) sağlar.

`PresentationEnumerableFramesGenerator` size videonun (daha sonra oluşturulacak) kare boyutunu ve FPS (saniyedeki kare sayısı) değerini yapıcı üzerinden ayarlama imkanı verir. Bir sunum örneği geçirirseniz, onun `Presentation.SlideSize` değeri kullanılacaktır.

Tüm animasyonların aynı anda oynatılmasını istiyorsanız, `PresentationEnumerableFramesGenerator.enumerate_frames` metodunu kullanın. Bu metod, bir slayt koleksiyonu alır ve sırasıyla [EnumerableFrameArgs](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/enumerableframeargs/) döndürür. Ardından, her bir video karesini elde etmek için `EnumerableFrameArgs.get_frame()` kullanın.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Oluşturulan kareler daha sonra bir videoya derlenebilir. Daha fazla ayrıntı için [PowerPoint'i Videoya Dönüştür](https://docs.aspose.com/slides/tr/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video) bölümüne bakın.

## **Desteklenen Animasyonlar ve Efektler**

PowerPoint sunumunu Aspose.Slides for Python ile videoya dönüştürürken, çıktıda hangi animasyon ve efektlerin desteklendiğini anlamak önemlidir. Aspose.Slides, solma, uçuş, yakınlaştırma ve döndürme gibi yaygın giriş, çıkış ve vurgu efektlerinin geniş bir yelpazesini destekler. Ancak bazı gelişmiş veya özel animasyonlar tam olarak korunmayabilir veya video içinde farklı görünebilir. Bu bölüm, desteklenen animasyon ve efektleri özetler.

**Giriş**:

| **Animasyon Türü** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Vurgu**:

| **Animasyon Türü** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Çıkış**:

| **Animasyon Türü** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Hareket Yolları**:

| **Animasyon Türü** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Desteklenen Slayt Geçiş Efektleri**

Slayt geçiş efektleri, bir videodaki slaytlar arasındaki değişimleri sorunsuz ve görsel olarak çekici hâle getirmede önemli bir rol oynar. Aspose.Slides for Python, orijinal sunumunuzun akışını ve stilini korumak için çeşitli yaygın geçiş efektlerini destekler. Bu bölüm, dönüşüm sırasında hangi geçiş efektlerinin desteklendiğini gösterir.

**İnce**:

| **Animasyon Türü** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Heyecan Verici**:

| **Animasyon Türü** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dinamik İçerik**:

| **Animasyon Türü** | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **SSS**

**Şifre korumalı sunumları dönüştürmek mümkün müdür?**

Evet, Aspose.Slides for Python şifre korumalı sunumlarla çalışmayı destekler. Bu tür dosyaları işlerken, kütüphanenin sunum içeriğine erişebilmesi için doğru şifreyi sağlamanız gerekir.

**Aspose.Slides for Python bulut çözümlerinde kullanımını destekliyor mu?**

Evet, Aspose.Slides for Python bulut uygulamaları ve hizmetleriyle bütünleştirilebilir. Kütüphane, dosya toplu işleme için yüksek performans ve ölçeklenebilirlik sağlamak üzere sunucu ortamlarında çalışacak şekilde tasarlanmıştır.

**Dönüştürme sırasında sunumlar için herhangi bir boyut sınırlaması var mı?**

Aspose.Slides for Python neredeyse her boyutta sunumu işleyebilir. Ancak çok büyük dosyalarla çalışırken ek sistem kaynakları gerekebilir ve performansı artırmak için sunumu optimize etmek önerilir.