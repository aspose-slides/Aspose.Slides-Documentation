---
title: SlaytGeçişi
type: docs
weight: 110
url: /tr/python-net/examples/elements/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişine eriş
- slayt geçişini kaldır
- geçiş süresi
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ile Aspose.Slides'de slayt geçişlerini kontrol edin: türleri, hızı, sesi ve zamanlamayı seçerek PPT, PPTX ve ODP sunumlarınıza son dokunuşları yapın."
---
**Aspose.Slides for Python via .NET** ile slayt geçiş efektleri ve zamanlamalarının uygulanmasını gösterir.

## **Slayt Geçişi Ekle**
İlk slayta bir solma geçiş efekti uygulayın.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Bir solma geçişi uygula.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Slayt Geçişine Erişim**
Bir slayta şu anda atanmış geçiş türünü okuyun.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Geçiş türüne eriş.
        transition_type = slide.slide_show_transition.type
```

## **Slayt Geçişini Kaldır**
`NONE` tipini ayarlayarak tüm geçiş efektini temizleyin.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Geçişi kaldırmak için none ayarlayın.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Geçiş Süresini Ayarla**
Slaydın otomatik ilerlemeden önce ne kadar süre görüntüleneceğini belirtin.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # milisaniye cinsinden.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```