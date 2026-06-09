---
title: Bir Sunumdan Tüm Slayt Arka Planını Resim Olarak Alın
linktitle: Tüm Slayt Arka Planı
type: docs
weight: 95
url: /tr/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slayt arka planı
- tam arka plan
- arka planı çıkar
- tüm arka plan
- arka planı resme
- PPT arka planı
- PPTX arka planı
- ODP arka planı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarından tam slayt arka planlarını resim olarak çıkarın, görsel iş akışlarını basitleştirir."
---
## **Genel Bakış**

PowerPoint sunumlarında, bir slayt arka planı slayt arka plan resmi, sunum teması, renk şeması ve ana slayt veya düzen slaytına yerleştirilen nesneler gibi birden çok öğeden oluşabilir.

Bu makale, Aspose.Slides kullanarak tüm slayt arka planını bir resim olarak nasıl çıkaracağınızı gösterir. Bu görev için tek bir yöntem olmadığından, yaklaşım seçilen slaytı geçici bir sunuma klonlamayı, slayt şekillerini kaldırmayı ve ardından ortaya çıkan slayt arka planını bir resme dönüştürmeyi içerir.

## **Tüm Slayt Arka Planını Alın**

Aspose.Slides for Node.js via Java, tüm sunum slayt arka planını bir resim olarak çıkarmak için basit bir yöntem sağlamaz, ancak aşağıdaki adımları izleyerek bunu yapabilirsiniz:
1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Sunumdan slayt boyutunu alın.
1. Bir slayt seçin.
1. Geçici bir sunum oluşturun.
1. Geçici sunumda aynı slayt boyutunu ayarlayın.
1. Seçilen slaytı geçici sunuma klonlayın.
1. Klonlanan slayttaki şekilleri silin.
1. Klonlanan slaytı bir resme dönüştürün.

Aşağıdaki kod örneği, tüm sunum slayt arka planını bir resim olarak çıkarır.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **SSS**

**Bir ana slayttan gelen karmaşık degrade, doku veya resim doldurmaları, ortaya çıkan arka plan resminde korunur mu?**

Evet. Aspose.Slides, slayt, düzen veya ana slaytta tanımlanan degrade, resim ve doku doldurmalarını işler. Kalıtlardan miras alınan görünümleri izole etmeniz gerekiyorsa, dışa aktarmadan önce geçerli slaytta [kendi arka planınızı ayarlayın](/slides/tr/nodejs-java/presentation-background/).

**Kaydetmeden önce ortaya çıkan arka plan resmine bir filigran ekleyebilir miyim?**

Evet. Çalışma [slayt kopyası](/slides/tr/nodejs-java/clone-slides/) üzerine [filigran ekleyebilir](/slides/tr/nodejs-java/watermark/) (diğer içeriğin arkasına yerleştirilen) bir şekil veya resim ekleyip ardından dışa aktarabilirsiniz. Böylece filigranı içinde barındıran bir arka plan resmi üretebilirsiniz.

**Mevcut bir slayta bağlamadan belirli bir düzen veya ana slayt için arka planı alabilir miyim?**

Evet. İstediğiniz ana slayta veya düzene erişin, gerekli boyutta bir [geçici slayta](/slides/tr/nodejs-java/clone-slides/) uygulayın ve o slaytı dışa aktararak o düzen ya da ana slayttan türetilen arka planı elde edin.

**Görüntü dışa aktarımını etkileyen lisans sınırlamaları var mı?**

Render özellikleri, [geçerli bir lisans](/slides/tr/nodejs-java/licensing/) ile tamamen kullanılabilir. Değerlendirme modunda, çıktı bir filigran gibi sınırlamalar içerebilir. Toplu dışa aktarımları çalıştırmadan önce süreç başına bir kez lisansı etkinleştirin.