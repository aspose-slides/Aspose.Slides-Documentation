---
title: Python Kullanarak Sunumlarda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 90
url: /tr/python-net/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- morph geçişi
- geçiş türü
- geçiş efekti
- Python
- Aspose.Slides
description: "Aspose.Slides for Python’da .NET aracılığıyla slayt geçişlerini nasıl özelleştireceğinizi keşfedin; PowerPoint ve OpenDocument sunumları için adım adım rehberlik sunar."
---
## **Genel Bakış**

Aspose.Slides for Python, slayt geçişleri üzerinde tam kontrol sağlar; bir geçiş türü seçmekten zamanlamayı ve tetikleyicileri yapılandırmaya kadar otomatik sunum iş akışlarının bir parçası olarak kullanılabilir. Slaytların tıklama ile veya belirli bir gecikmeden sonra ilerlemesini ayarlayabilir ve siyahdan kesme veya yönlü girişler gibi efektlerle görsel davranışı iyileştirebilirsiniz. Kütüphane ayrıca PowerPoint 2019’da tanıtılan Morph geçişini de destekler; nesne, kelime veya karakter bazında morph modları sayesinde slaytlar arasında sorunsuz ve tutarlı bir hareket oluşturulur.

## **Slayt Geçişleri Ekle**

Bu örnek, Aspose.Slides for Python kullanarak basit slayt geçişlerini nasıl yöneteceğinizi gösterir. Geliştiriciler slaytlara farklı geçiş efektleri uygulayabilir ve davranışlarını özelleştirebilir. Basit bir slayt geçişi oluşturmak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. [TransitionType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitiontype/) enum’undan bir geçiş efekti uygulayın.
1. Değiştirilmiş sunum dosyasını kaydedin.

```py
import aspose.slides as slides

# Sunum dosyasını yüklemek için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("sample.pptx") as presentation:
    # 1. slayta daire geçişi uygula.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # 2. slayta tarak geçişi uygula.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Sunumu diske kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gelişmiş Slayt Geçişleri Ekle**

Bu bölümde, bir slayta basit bir geçiş efekti uyguladık. Bu efekti daha kontrollü ve pulsatör hâle getirmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. [TransitionType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitiontype/) enum’undan bir geçiş efekti uygulayın.
1. Geçişi **Advance On Click**, belirli bir zaman diliminden sonra veya her ikisine göre yapılandırın.
1. Değiştirilmiş sunum dosyasını kaydedin.

Eğer **Advance On Click** etkinleştirilmişse, slayt yalnızca kullanıcı tıkladığında ilerler. **Advance After Time** özelliği ayarlanmışsa, slayt belirtilen süreden sonra otomatik olarak ilerler.

```py
import aspose.slides as slides

# Sunum dosyasını açmak için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # 1. slayta daire geçişi uygula.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Tıklama ile ilerlemeyi etkinleştir ve 3 saniyelik otomatik ilerlemeyi ayarla.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # 2. slayta tarak geçişi uygula.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Tıklama ile ilerlemeyi etkinleştir ve 5 saniyelik otomatik ilerlemeyi ayarla.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # 3. slayta yakınlaştırma geçişi uygula.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Tıklama ile ilerlemeyi etkinleştir ve 7 saniyelik otomatik ilerlemeyi ayarla.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Sunumu diske kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph Geçişi**

Aspose.Slides for Python, bir slayttan diğerine sorunsuz hareketi animasyonlaştıran [Morph geçişi](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/morphtransition/) destekler. Bu bölüm, Morph geçişinin nasıl kullanılacağını açıklar. Etkili bir şekilde kullanmak için ortak bir nesne içeren iki slayta ihtiyacınız vardır. En kolay yöntem, bir slaytı çoğaltmak ve nesneyi ikinci slaytta farklı bir konuma taşımaktır.

Aşağıdaki kod örneği, metin içeren bir slaytı klonlayıp ikinci slayta Morph geçişi uygulamayı gösterir.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # İlk slaytı klonlayarak Morph sürekliliği için aynı şekillere sahip ikinci bir slayt oluştur.
    slide1 = presentation.slides.add_clone(slide0)

    # İkinci slaytta aynı dikdörtgeni seç ve konum ve boyutunu değiştir.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # İkinci slaytta Morph geçişini etkinleştirerek şekil değişikliklerini sorunsuz bir şekilde canlandır.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph Geçişi Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionmorphtype/) enum’u, farklı Morph slayt geçişi türlerini temsil eder.

Aşağıdaki kod örneği, bir slayta Morph geçişi uygulamayı ve morph tipini değiştirmeyi gösterir.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Geçiş Efektlerini Ayarla**

Aspose.Slides for Python, **From Black**, **From Left**, **From Right** gibi geçiş efektlerini ayarlamanıza izin verir. Bir geçiş efektini yapılandırmak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Slayta bir referans alın.
1. İstediğiniz geçiş etkisini ayarlayın.
1. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, çeşitli geçiş efektleri ayarladık.

```py
import aspose.slides as slides

# Sunum dosyasını açmak için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Cut geçişi uygula ve From Black seçeneğini etkinleştir.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Sunumu diske kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Geçişin [speed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/speed/) ayarını, [TransitionSpeed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionspeed/) (ör. slow/medium/fast) kullanarak belirleyebilirsiniz.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Geçiş için bir ses gömebilir ve ses modu, döngü gibi ayarlarla davranışını kontrol edebilirsiniz (ör. [sound](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), ek olarak [sound_is_built_in](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) ve [sound_name](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/) gibi meta veriler).

**Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?**

Her slaytın geçiş ayarlarında istenen geçiş tipini yapılandırın; geçişler slayt başına depolandığı için aynı tipi tüm slaytlara uygulamak tutarlı bir sonuç verir.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaytın [transition settings](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/slide_show_transition/) incelen ve [transition type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/type/) okunarak hangi efektin uygulandığını net olarak öğrenebilirsiniz.