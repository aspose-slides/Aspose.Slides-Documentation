---
title: Python'da Animasyonlarla PowerPoint Sunumlarını Geliştirin
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
- animasyon etkisi
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
description: "Aspose.Slides for Python via .NET'in PowerPoint animasyonlarını yönetme yeteneklerini keşfedin. Bu genel bakış, temel özellikleri vurgular ve sunumlarınızı geliştirmek için içgörüler sunar."
---
## **Giriş**

Sunumlar bilgi aktarmak amacıyla tasarlanır; bu nedenle görsel görünüm ve etkileşimli davranışlar oluşturulurken temel dikkate alınması gereken unsurlardır.

**PowerPoint animasyonu**, bir sunumu izleyiciler için çarpıcı ve ilgi çekici hale getirmede önemli bir rol oynar. Aspose.Slides for Python via .NET, PowerPoint sunumuna animasyon eklemek için geniş bir seçenek yelpazesi sunar. Şunları yapabilirsiniz:

- Şekillere, grafiklere, tablolara, OLE nesnelerine ve diğer öğelere çeşitli animasyon efektleri uygulayın.
- Tek bir şekle birden çok animasyon efekti ekleyin.
- Animasyon zaman çizelgesi aracılığıyla efektleri kontrol edin.
- Özel animasyonlar oluşturun.

Aspose.Slides for Python via .NET’te animasyon efektleri şekillere uygulanabilir. Bir slayttaki her öğe—metin, resim, OLE nesnesi ve tablo dahil—şekil olarak kabul edildiği için slayttaki herhangi bir öğeye animasyon efekti uygulayabilirsiniz.

[aspose.slides.animation](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/) ad alanı, PowerPoint animasyonlarıyla çalışmak için sınıfları sağlar.

## **Kurulum**

```bash
pip install aspose.slides
```

## **Python'da Bir Şekle Animasyon Efekti Ekleme**

Animasyon efektleri bir slaytın ana sırasına yerleştirilir. Bir şekil ekleyin, ardından `slide.timeline.main_sequence` üzerinde `add_effect` metodunu çağırarak, efekt tipini, alt tipini ve başlatıcıyı iletin.

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

Kaydedilen dosya, ilk slaytta bir efekt içerir: sunucu tıkladığında dikdörtgen iki saniye içinde soldan uçar. Dosyayı yeniden açıp `slide.timeline.main_sequence` okununca aynı efekt geri döner; böylece animasyon yalnızca bellek içinde kalmaz, turu tamamlar.

## **Animasyon Efektleri**

Aspose.Slides **150+ animasyon efekti** destekler; Bounce, PathFootball ve Zoom gibi temel efektlerin yanı sıra OLEObjectShow ve OLEObjectOpen gibi özel efektler de vardır. Tam listeyi [EffectType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttype/) enum’ında bulabilirsiniz.

Ayrıca bu animasyon efektleri aşağıdaki efektlerle birleştirilebilir:

- [ColorEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/seteffect/)

## **Özel Animasyon**

Tam Python örnekleri için, davranışları oluşturma, inceleme ve düzenleme ayrıca düzenlenebilir hareket yolları hakkında bilgi almak isterseniz [Custom Animation](/slides/tr/python-net/custom-animation/) sayfasına bakın.

Aspose.Slides’te **özel animasyonlar** oluşturabilir, birden fazla davranışı tek bir efekt içinde birleştirebilirsiniz.

[Behavior](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behavior/) bir PowerPoint animasyon efektinin yapı taşıdır. Bir efekti özelleştirmek için davranışları birleştirin veya önceden tanımlı bir efekti genişletmek için bir davranış ekleyin. Tekrarlama, ayrı bir tekrarlama davranışı yerine zamanlama ayarlarıyla yapılandırılır.

[Animation Point](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/point/) bir davranışın uygulandığı anı veya konumu (anahtar kare) işaretler.

## **Animasyon Zaman Çizelgesi**

[Sequence](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/) farklı şekillere hedeflenebilen bir animasyon efekti koleksiyonudur.

[Timeline](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/animationtimeline/) belirli bir slaytta kullanılan sıra setidir. PowerPoint 2002’de tanıtılmıştır. Önceki PowerPoint sürümlerinde animasyon eklemek zordu ve genellikle çözümler gerektiriyordu. Timeline, eski `AnimationSettings` sınıfının yerini alır ve PowerPoint animasyonu için daha net bir nesne modeli sunar. Her slayt yalnızca bir animasyon zaman çizelgesine sahip olabilir.

## **Etkileşimli Animasyon**

[Trigger](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) belirli bir animasyonu başlatan kullanıcı eylemlerini (ör. bir düğmeye tıklama) tanımlamanıza olanak verir. Tetikleyiciler yalnızca en yeni PowerPoint sürümlerinde eklenmiştir.

## **Şekil Animasyonu**

Aspose.Slides, metin, dikdörtgen, çizgi, çerçeve, OLE nesnesi ve daha fazlası gibi şekillere animasyon uygulamanızı sağlar.

{{% alert color="info" title="Note" %}}
Read more [**Şekil Animasyonu Hakkında**](/slides/tr/python-net/shape-animation/)
{{% /alert %}}

## **Animasyonlu Grafikler**

Animasyonlu grafikler oluşturmak için şekillerde kullandığınız sınıfları kullanın. Ancak PowerPoint animasyonları yalnızca grafik kategorilerine veya grafik serilerine uygulanabilir. Tek bir kategori öğesine veya seri öğesine de animasyon efekti uygulayabilirsiniz.

{{% alert color="info" title="Note" %}}
Read more [**Animasyonlu Grafikler Hakkında**](/slides/tr/python-net/animated-charts/)
{{% /alert %}}

## **Animasyonlu Metin**

Metni animasyonlamanın yanı sıra bir paragrafı da animasyonlayabilirsiniz.

{{% alert color="info" title="Note" %}}
Read more [**Animasyonlu Metin Hakkında**](/slides/tr/python-net/animated-text/)
{{% /alert %}}

## **SSS**

**Animasyonlar PDF'ye dışa aktarılırken korunacak mı?**

Hayır. PDF statik bir formattır, bu yüzden animasyonlar ve [slide transitions](/slides/tr/python-net/slide-transition/) oynatılmaz. Hareket ihtiyacınız varsa, bunun yerine [HTML5](/slides/tr/python-net/export-to-html5/), [animated GIF](/slides/tr/python-net/convert-powerpoint-to-animated-gif/) veya [video](/slides/tr/python-net/convert-powerpoint-to-video/) formatlarına dışa aktarın.

**Animasyonlu bir sunumu videoya dönüştürüp kare hızı ve kare boyutunu kontrol edebilir miyim?**

Evet. Sunumu [render the presentation as frames](/slides/tr/python-net/convert-powerpoint-to-video/) şeklinde karelere dönüştürüp, ffmpeg gibi bir araçla video olarak kodlayabilir, FPS ve çözünürlüğü seçebilirsiniz. Render sırasında animasyonlar ve slayt geçişleri oynatılır.

**ODP (sadece PPTX değil) ile çalışırken animasyonlar aynı kalacak mı?**

PPT, PPTX ve ODP, [reading](/slides/tr/python-net/open-presentation/) ve [writing](/slides/tr/python-net/save-presentation/) için desteklenir, ancak bu animasyonların korunacağı anlamına gelmez. ODP’ye dönüştürürken özel animasyon verileri kaybolabilir. Format uyumluluğunu kontrol etmek için örnekler ve rehberlik almak üzere [Custom Animation](/slides/tr/python-net/custom-animation/) sayfasına bakın.