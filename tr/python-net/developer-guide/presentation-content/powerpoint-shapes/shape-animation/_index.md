---
title: Python ile Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/python-net/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkar
- efekt ekle
- efekt al
- efekt çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarında şekil animasyonları oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [grafiklere](/slides/tr/python-net/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya bileşenlerine hayat verir. 

## **Sunumlarda Animasyon Kullanmanın Nedenleri?**

Animasyonları kullanarak 

* bilgi akışını kontrol et
* önemli noktaları vurgula
* izleyicileriniz arasında ilgi veya katılımı artır
* içeriği okumayı, özümsemeyi veya işlemeyi daha kolay hale getir
* okuyucularınızın veya izleyicilerinizin dikkatini sunumdaki önemli bölümlere çek

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorileri kapsamında animasyonlar ve animasyon efektleri için birçok seçenek ve araç sunar. 

## **Aspose.Slides’te Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmak için gereken sınıfları ve türleri [Aspose.Slides.Animation](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/) ad alanı altında sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttype/) sayımında **150’den fazla animasyon efekti** sunar. Bu efektler, temel olarak PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for Python via .NET, bir şeklin içindeki metne animasyon uygulamanıza olanak tanır. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. `rectangle` tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iautoshape/) ekleyin.  
4. `IAutoShape.TextFrame`'e metin ekleyin.  
5. Efektlerin ana dizisini alın.  
6. [IAutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iautoshape/) üzerine bir animasyon efekti ekleyin.  
7. `TextAnimation.BuildType` özelliğini `BuildType` sayımındaki bir değere ayarlayın.  
8. Sunumu PPTX dosyası olarak diske yazın.  

Bu Python kodu, `Fade` efektini AutoShape'e nasıl uygulayacağınızı ve metin animasyonunu *By 1st Level Paragraphs* değerine nasıl ayarlayacağınızı gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden bir sunum sınıfını örnekler.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Yeni bir AutoShape ekler ve metin ekler
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Slaydın ana dizisini alır.
    sequence = sld.timeline.main_sequence

    # Şekle Fade animasyon etkisi ekler
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Şekil metnini 1. seviye paragraflara göre canlandırır
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # PPTX dosyasını diske kaydeder
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Metinlere animasyon uygulamanın yanı sıra, tek bir [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iparagraph/) üzerine de animasyon uygulayabilirsiniz. Bkz [**Animated Text**](/slides/tr/python-net/animated-text/).

{{% /alert %}} 

## **PictureFrame’e Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ekleyin veya alın.  
4. Efektlerin ana dizisini alın.  
5. [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) üzerine bir animasyon efekti ekleyin.  
6. Sunumu PPTX dosyası olarak diske yazın.  

Bu Python kodu, bir picture frame'e `Fly` efektini nasıl uygulayacağınızı gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Bir sunum dosyasını temsil eden sunum sınıfını örnekler.
with slides.Presentation() as pres:
    # Sunumun görüntü koleksiyonuna eklenecek görüntüyü yükler
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Slayda bir resim çerçevesi ekler
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Slaydın ana dizisini alır.
    sequence = pres.slides[0].timeline.main_sequence

    # Resim çerçevesine Soldan Uçuş animasyon etkisi ekler
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # PPTX dosyasını diske kaydeder
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekle Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. `rectangle` tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iautoshape/) ekleyin.  
4. `Bevel` tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iautoshape/) ekleyin (bu nesne tıklandığında animasyon çalınır).  
5. `Bevel` şekli üzerinde bir efekt dizisi oluşturun.  
6. Özel bir `UserPath` oluşturun.  
7. `UserPath`'e hareket komutları ekleyin.  
8. Sunumu PPTX dosyası olarak diske yazın.  

Bu Python kodu, bir şekle `PathFootball` (path football) efektini nasıl uygulayacağınızı gösterir:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Bir PPTX dosyasını temsil eden Presentation sınıfını örnekler.
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Mevcut şekil için sıfırdan PathFootball efekti oluşturur.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # PathFootBall animasyon etkisini ekler.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Bir tür "buton" oluşturur.
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Buton için bir efekt dizisi oluşturur.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Özel bir kullanıcı yolu oluşturur. Nesnemiz sadece butona tıklandıktan sonra hareket edecek.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Oluşturulan yol boş olduğundan hareket komutları ekler.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # PPTX dosyasını diske yazar.
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekle Uygulanan Animasyon Efektlerini Almak**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [Sequence](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/) sınıfının `get_effects_by_shape` metodunun nasıl kullanılacağını gösterir.

**Örnek 1:** Normal bir slaytta bir şekle uygulanan animasyon efektlerini alın

Daha önce PowerPoint sunumlarında şekillere animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slayttaki ilk şekle uygulanan efektleri nasıl alacağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Slaydın ana animasyon dizisini alır.
    sequence = first_slide.timeline.main_sequence

    # İlk slayttaki ilk şekli alır.
    shape = first_slide.shapes[0]

    # Şekle uygulanan animasyon efektlerini alır.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Örnek 2:** Yer tutuculardan miras alınanlar da dahil olmak üzere tüm animasyon efektlerini alın

Normal bir slayttaki bir şeklin, düzen slaydında ve/veya ana slaytta bulunan yer tutucuları varsa ve bu yer tutuculara animasyon efektleri eklenmişse, slayt gösterisi sırasında şeklin tüm efektleri oynatılır; bu, yer tutuculardan miras alınan efektleri de içerir.

Diyelim ki `sample.pptx` adlı bir PowerPoint sunum dosyamız var; tek bir slaytı var ve yalnızca altbilgi şekli içinde “Made with Aspose.Slides” metni bulunuyor ve **Random Bars** efekti bu şekle uygulanmış.

![Slayt şekil animasyon efekti](slide-shape-animation.png)

Ayrıca **Split** efektinin düzen slaydındaki altbilgi yer tutucusuna uygulandığını varsayalım.

![Düzen şekil animasyon efekti](layout-shape-animation.png)

Ve sonunda **Fly In** efektinin ana slayttaki altbilgi yer tutucusuna uygulandığını varsayalım.

![Ana şablon şekil animasyon efekti](master-shape-animation.png)

Aşağıdaki örnek kod, [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfının `get_base_placeholder` metodunu kullanarak şekil yer tutucularına erişmeyi ve altbilgi şekline, düzen ve ana slaytlardaki yer tutuculardan miras alınanlar da dahil olmak üzere uygulanan animasyon efektlerini almayı gösterir:

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Normal slayttaki şeklin animasyon efektlerini al.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Düzen slaydındaki yer tutucunun animasyon efektlerini al.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Ana slayttaki (master) yer tutucunun animasyon efektlerini al.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Animasyon Efekti Zamanlama Özelliklerini Değiştirme**

Aspose.Slides for Python via .NET, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Zamanlama bölmesidir:

![Animasyon Zamanlama paneli](shape-animation.png)

PowerPoint Zamanlama ile `Effect.Timing` özellikleri arasındaki eşleşmeler şunlardır:

- PowerPoint Zamanlama **Start** açılır listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) özelliğiyle eşleşir.  
- PowerPoint Zamanlama **Duration**, `Effect.Timing.Duration` özelliğiyle eşleşir. Bir animasyonun süresi (saniye cinsinden), animasyonun bir döngüyü tamamlaması için geçen toplam zamandır.  
- PowerPoint Zamanlama **Delay**, `Effect.Timing.TriggerDelayTime` özelliğiyle eşleşir.  

Effect Timing özelliklerini nasıl değiştirirsiniz:

1. [Uygula](#apply-animation-to-shape) veya animasyon efektini alın.  
2. Gereken `Effect.Timing` özellikleri için yeni değerler ayarlayın.  
3. Değiştirilmiş PPTX dosyasını kaydedin.  

Bu Python kodu işlemi gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden bir sunum sınıfını örnekler.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Slaydın ana dizisini alır.
    sequence = pres.slides[0].timeline.main_sequence

    # Ana dizinin ilk efektini alır.
    effect = sequence[0]

    # Etkinin TriggerType özelliğini tıklandığında başlayacak şekilde değiştirir
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Etkinin Süresini değiştirir
    effect.timing.duration = 3

    # Etkinin TriggerDelayTime değerini değiştirir
    effect.timing.trigger_delay_time = 0.5

    # PPTX dosyasını diske kaydeder
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Animasyon Efekti Sesi**

Aspose.Slides, animasyon efektlerinde seslerle çalışmanıza olanak tanıyan aşağıdaki özellikleri sunar: 

- `sound`
- `stop_previous_sound`

### **Animasyon Efekti Sesi Ekleme**

Bu Python kodu, bir animasyon efekti sesi eklemeyi ve bir sonraki efekt başladığında sesi durdurmayı nasıl yapacağınızı gösterir:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Sunuma ses koleksiyonuna ses ekler
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Slaydın ana dizisini alır.
    sequence = first_slide.timeline.main_sequence

    # Ana dizinin ilk efektini alır
    first_effect = sequence[0]

    # Efekti "Ses Yok" için kontrol eder
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # İlk efekt için ses ekler
        first_effect.sound = effect_sound

    # Slaydın ilk etkileşimli dizisini alır.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Efektin "Önceki sesi durdur" bayrağını ayarlar
    interactive_sequence[0].stop_previous_sound = True

    # PPTX dosyasını diske yazar
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Animasyon Efekti Sesini Çıkarma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Efektlerin ana dizisini alın.  
4. Her animasyon efektine gömülü `sound` öğesini çıkarın.  

Bu Python kodu, bir animasyon efektine gömülü sesi nasıl çıkaracağınızı gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden bir sunum sınıfını örnekler.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Slaydın ana dizisini alır.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Efekt sesini bayt dizisi olarak çıkarır
        audio = effect.sound.binary_data
```

## **Animasyondan Sonra**

Aspose.Slides for .NET, bir animasyon efektinin **After animation** özelliğini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Efekti ve genişletilmiş menüdür:

![Animasyon Efekti ve genişletilmiş menü](shape-after-animation.png)

PowerPoint Effect **After animation** açılır listesi aşağıdaki özelliklere karşılık gelir: 

- `after_animation_type` özelliği, After animation türünü tanımlar:  
  * PowerPoint **More Colors** [COLOR](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) tipine karşılık gelir;  
  * PowerPoint **Don't Dim** öğesi, varsayılan after animation türü olan [DO_NOT_DIM](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) tipine karşılık gelir;  
  * PowerPoint **Hide After Animation** öğesi, [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) tipine karşılık gelir;  
  * PowerPoint **Hide on Next Mouse Click** öğesi, [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) tipine karşılık gelir;  
- `after_animation_color` özelliği, bir after animation renk formatı tanımlar. Bu özellik, [COLOR](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) tipiyle birlikte çalışır. Türü başka bir şeye değiştirirseniz, after animation rengi temizlenir.  

Bu Python kodu, bir after animation efektini nasıl değiştireceğinizi gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden bir sunum sınıfını örnekler.
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Ana dizinin ilk efektini alır
    first_effect = first_slide.timeline.main_sequence[0]

    # After animation türünü Color'a değiştirir
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # After animation karartma rengini ayarlar
    first_effect.after_animation_color.color = Color.alice_blue

    # PPTX dosyasını diske yazar
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Metni Canlandırma**

Aspose.Slides, bir animasyon efektinin *Animate text* bloğu ile çalışmanıza olanak tanıyan aşağıdaki özellikleri sağlar:

- `animate_text_type` efektin animasyon metni türünü tanımlar. Şekil metni şu şekilde canlandırılabilir:  
  - Hepsini birden ([ALL_AT_ONCE](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/animatetexttype/) tipi)  
  - Kelime kelime ([BY_WORD](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/animatetexttype/) tipi)  
  - Harf harf ([BY_LETTER](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/animatetexttype/) tipi)  
- `delay_between_text_parts` animasyonlu metin parçaları (kelimeler veya harfler) arasındaki gecikmeyi ayarlar. Pozitif bir değer efekt süresinin yüzdesini, negatif bir değer ise saniye cinsinden gecikmeyi belirtir.  

Effect Animate text özelliklerini şu şekilde değiştirebilirsiniz:

1. [Uygula](#apply-animation-to-shape) veya animasyon efektini alın.  
2. *By Paragraphs* animasyon modunu kapatmak için `build_type` özelliğini [AS_ONE_OBJECT](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/buildtype/) değerine ayarlayın.  
3. `animate_text_type` ve `delay_between_text_parts` özellikleri için yeni değerler ayarlayın.  
4. Değiştirilmiş PPTX dosyasını kaydedin.  

Bu Python kodu işlemi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Ana dizinin ilk efektini alır
    first_effect = first_slide.timeline.main_sequence[0]

    # Efektin Metin animasyon türünü "Tek Nesne Olarak" değiştirir
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Efektin Metni Canlandır türünü "Kelime Kelime" olarak değiştirir
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Kelimeler arasındaki gecikmeyi efekt süresinin %20'si olarak ayarlar
    first_effect.delay_between_text_parts = 20

    # PPTX dosyasını diske yazar
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **SSS**

**Sunumu web’e yayınlarken animasyonların korunmasını nasıl garanti edebilirim?**

[HTML5'e Dışa Aktar](/slides/tr/python-net/export-to-html5/) ve [shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/animate_shapes/) ile [transition](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/animate_transitions/) animasyonlarını etkinleştiren [options](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/) ayarlarını açın. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.

**Şekillerin z‑order (katman sırası) değişikliği animasyonu nasıl etkiler?**

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünme/gizlenme zamanını ve tipini kontrol ederken, [z_order](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/z_order_position/) hangi şeyin diğerinin üzerine geleceğini belirler. Görünür sonuç, ikisinin kombinasyonu ile tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efekt‑ve‑şekil modeli aynı mantığı izler.)

**Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?**

Genel olarak, [animasyonlar desteklenir](/slides/tr/python-net/convert-powerpoint-to-video/), ancak nadir durumlarda veya belirli efektlerde farklı render sonuçları oluşabilir. Kullandığınız efektlerle ve kütüphane sürümüyle test etmeniz önerilir.