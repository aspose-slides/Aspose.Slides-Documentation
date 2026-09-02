---
title: PowerPoint Sunumlarını Python'da Animasyonlarla Geliştirin
linktitle: PowerPoint Animasyonu
type: docs
weight: 150
url: /tr/python-net/powerpoint-animation/
keywords:
- animasyon ekle
- animasyonu güncelle
- animasyonu değiştir
- animasyonu kaldır
- animasyonu yönet
- animasyonu kontrol et
- animasyon efekti
- PowerPoint animasyonu
- animasyon zaman çizelgesi
- etkileşimli animasyon
- özel animasyon
- şekil animasyonu
- animasyonlu grafik
- animasyonlu metin
- animasyonlu şekil
- animasyonlu OLE nesnesi
- animasyonlu resim
- animasyonlu tablo
- PowerPoint sunumu
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'in PowerPoint animasyonlarını yönetme yeteneklerini keşfedin. Bu genel bakış, temel özellikleri vurgular ve sunumlarınızı geliştirmeniz için içgörüler sunar."
---
## **Giriş**

Sunumlar bilgi iletmeyi amaçlar, bu nedenle görsel görünüşleri ve etkileşimli davranışları oluşturulurken temel hususlar arasında yer alır.

**PowerPoint animation** sunumun izleyiciler için göz alıcı ve ilgi çekici olmasını sağlamakta önemli bir rol oynar. Aspose.Slides for Python via .NET, bir PowerPoint sunumuna animasyon eklemek için geniş bir seçenek yelpazesi sunar. Şunları yapabilirsiniz:

- Şekillere, grafiklere, tablolara, OLE nesnelerine ve diğer öğelere çeşitli animasyon efektleri uygulayın.
- Tek bir şekil üzerinde birden fazla animasyon efekti kullanın.
- Animasyon zaman çizelgesi aracılığıyla efektleri kontrol edin.
- Özel animasyonlar oluşturun.

Aspose.Slides for Python via .NET içinde animasyon efektleri şekillere uygulanabilir. Bir slayttaki her öğe—metin, resimler, OLE nesneleri ve tablolar dahil—bir şekil olarak kabul edildiği için, slayttaki herhangi bir öğeye animasyon efekti uygulayabilirsiniz.

[aspose.slides.animation](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/) ad alanı, PowerPoint animasyonlarıyla çalışmak için sınıfları sağlar.

## **Kurulum**

```bash
pip install aspose.slides
```

## **Python'da Bir Şekle Animasyon Efekti Ekleme**

Animasyon efektleri bir slaydın ana sırasına yerleştirilir. Bir şekil ekleyin, ardından `slide.timeline.main_sequence` üzerinde `add_effect` metodunu çağırarak efekt tipini, alt tipini ve başlatan trigger'ı iletin.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Kaydedilen dosya, ilk slaytta bir efekt içerir: dikdörtgen, sunucu tıkladığında iki saniye içinde soldan uçarak gelir. Dosyayı yeniden açıp `slide.timeline.main_sequence` okununca aynı efekt döndürülür, böylece animasyon yalnızca bellek içinde kalmayıp dosyada da korunur.

## **Animasyon Efektleri**

Aspose.Slides **150+ animasyon efekti** desteği sunar; Bounce, PathFootball ve Zoom gibi temel efektlerin yanı sıra OLEObjectShow ve OLEObjectOpen gibi özel efektler de mevcuttur. Tam listeye [EffectType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttype/) sayımında ulaşabilirsiniz.

Ayrıca, bu animasyon efektleri aşağıdaki efektlerle birleştirilebilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/seteffect/)

## **Özel Animasyon**

Aspose.Slides içinde birden fazla davranışı tek bir efekt haline getirerek kendi **özel animasyonlarınızı** oluşturabilirsiniz.

[Behavior](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behavior/) herhangi bir PowerPoint animasyon efektinin temel yapı taşıdır. Her animasyon efekti temelde bir zaman çizelgesi ya da strateji içinde düzenlenmiş davranışlar kümesidir. Davranışları bir kez birleştirip bir özel animasyon oluşturabilir ve bunu diğer sunumlarda yeniden kullanabilirsiniz. Standart bir PowerPoint animasyon efektine yeni bir davranış eklediğinizde, bu bir özel animasyon haline gelir; örneğin, animasyonun birkaç kez tekrarlanmasını sağlamak için bir tekrar davranışı eklemek.

[Animation Point](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/point/) bir davranışın uygulandığı anı veya konumu (ana kare) işaretler.

## **Animasyon Zaman Çizelgesi**

[Sequence](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/) belirli bir şekle uygulanan animasyon efektlerinin bir koleksiyonudur.

[Timeline](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/animationtimeline/) belirli bir slaytta kullanılan sekansların kümesidir. PowerPoint 2002'de tanıtıldı. PowerPoint'in önceki sürümlerinde animasyon efektleri eklemek zordu ve genellikle geçici çözümler gerekirti. Timeline, eski `AnimationSettings` sınıfının yerini alır ve PowerPoint animasyonu için daha net bir nesne modeli sunar. Her slayt yalnızca bir animasyon zaman çizelgesine sahip olabilir.

## **Etkileşimli Animasyon**

[Trigger](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) belirli bir animasyonu başlatan kullanıcı eylemlerini (örn. bir düğmeye tıklama) tanımlamanıza olanak sağlar. Trigger'lar yalnızca PowerPoint'in son sürümlerine eklenmiştir.

## **Şekil Animasyonu**

Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE nesnesi ve daha fazlası gibi şekillere animasyon uygulamanıza olanak tanır.

{{% alert color="primary" %}}
Daha fazla bilgi [**Şekil Animasyonu Hakkında**](/slides/tr/python-net/shape-animation/).
{{% /alert %}}

## **Animasyonlu Grafikler**

Animasyonlu grafikler oluşturmak için şekillerde kullandığınız aynı sınıfları kullanın. Ancak PowerPoint animasyonları yalnızca grafik kategorilerine veya seri gruplarına uygulanabilir. Ayrıca bir kategori öğesine veya seri öğesine ayrı ayrı animasyon efekti uygulayabilirsiniz.

{{% alert color="primary" %}}
Daha fazla bilgi [**Animasyonlu Grafikler Hakkında**](/slides/tr/python-net/animated-charts/).
{{% /alert %}}

## **Animasyonlu Metin**

Metni hareket ettirmenin yanı sıra bir paragraf üzerine de animasyon uygulayabilirsiniz.

{{% alert color="primary" %}}
Daha fazla bilgi [**Animasyonlu Metin Hakkında**](/slides/tr/python-net/animated-text/).
{{% /alert %}}

## **SSS**

### PDF'ye dışa aktarırken animasyonlar korunur mu?
Hayır. PDF statik bir format olduğundan animasyonlar ve [slide transitions](/slides/tr/python-net/slide-transition/) oynatılmaz. Hareketli içerik gerekiyorsa, bunun yerine [HTML5](/slides/tr/python-net/export-to-html5/), [animated GIF](/slides/tr/python-net/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/python-net/convert-powerpoint-to-video/) formatına dışa aktarın.

### Animasyonlu bir sunumu videoya dönüştürüp kare hızı ve boyutunu kontrol edebilir miyim?
Evet. Sunumu [render the presentation as frames](/slides/tr/python-net/convert-powerpoint-to-video/) olarak render edip videoya (ör. ffmpeg ile) kodlayabilir, FPS ve çözünürlüğü seçebilirsiniz. Animasyonlar ve slayt geçişleri render sırasında oynatılır.

### ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalır mı?
PPT, PPTX ve ODP, [reading](/slides/tr/python-net/open-presentation/) ve [writing](/slides/tr/python-net/save-presentation/) için desteklenir, ancak format farkları bazı efektlerin biraz farklı görünmesine veya davranmasına neden olabilir. Kritik durumları gerçek örneklerle doğrulayın.