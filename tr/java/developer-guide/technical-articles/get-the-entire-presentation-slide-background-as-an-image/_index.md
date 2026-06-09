---
title: Sunumdan Tüm Slayt Arka Planını Görüntü Olarak Alın
linktitle: Tam Slayt Arka Planı
type: docs
weight: 95
url: /tr/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slayt arka planı
- final arka planı
- arka planı çıkar
- tam arka plan
- arka planı görüntüye
- PPT arka planı
- PPTX arka planı
- ODP arka planı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarından tam slayt arka planlarını görüntüler olarak çıkarın, görsel iş akışlarını kolaylaştırın."
---
## **Genel Bakış**

PowerPoint sunumlarında, bir slayt arka planı slayt arka plan resmi, sunum teması, renk şeması ve ana slayt ya da düzen slaytına yerleştirilen nesneler gibi birden çok öğeden oluşabilir.

Bu makale, Aspose.Slides for .NET kullanarak tüm slayt arka planını bir görüntü olarak nasıl çıkarılacağını gösterir. Bu görev için tek bir yöntem olmadığından, yaklaşım seçilen slaytı geçici bir sunuma kopyalamayı, slayt şekillerini kaldırmayı ve ardından elde edilen slayt arka planını bir görüntüye dönüştürmeyi içerir.

## **Tüm Slayt Arka Planını Al**

Aspose.Slides for Java, tüm sunum slayt arka planını bir görüntü olarak çıkarmak için basit bir yöntem sağlamaz, ancak aşağıdaki adımları izleyerek bunu yapabilirsiniz:
1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Sunumdan slayt boyutunu alın.
1. Bir slayt seçin.
1. Geçici bir sunum oluşturun.
1. Geçici sunumda aynı slayt boyutunu ayarlayın.
1. Seçilen slaytı geçici sunuma kopyalayın.
1. Kopyalanan slayttaki şekilleri silin.
1. Kopyalanan slaytı bir görüntüye dönüştürün.

Aşağıdaki kod örneği, tüm sunum slayt arka planını bir görüntü olarak çıkarır.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **SSS**

**Ana slayttan gelen karmaşık gradyanlar, dokular veya resim dolguları, oluşturulan arka plan görüntüsünde korunacak mı?**

Evet. Aspose.Slides, slayt, düzen veya ana üzerinde tanımlı gradyan, resim ve doku dolgularını işler. Kalıtılmış master'lardan görünümü ayırmanız gerekiyorsa, dışa aktarmadan önce geçerli slayta [kendi arka planını ayarlayın](/slides/tr/java/presentation-background/).

**Kaydetmeden önce oluşturulan arka plan görüntüsüne bir filigran ekleyebilir miyim?**

Evet. Çalışma [slayt kopyasına](/slides/tr/java/clone-slides/) (diğer içeriklerin arkasına yerleştirilmiş) bir [filigran](/slides/tr/java/watermark/) şekli veya resmi ekleyebilir ve ardından dışa aktarabilirsiniz. Bu, filigranın gömülü olduğu bir arka plan görüntüsü oluşturmanıza olanak tanır.

**Mevcut bir slayta bağlamadan belirli bir düzen veya master için arka planı alabilir miyim?**

Evet. İstenen master veya düzene erişin, gerekli boyutta bir [geçici slayta](/slides/tr/java/clone-slides/) uygulayın ve o slaytı dışa aktararak düzen veya master'dan türetilen arka planı elde edin.

**Görüntü dışa aktarmayı etkileyen lisans sınırlamaları var mı?**

Renderleme özellikleri, bir [geçerli lisans](/slides/tr/java/licensing/) ile tam olarak kullanılabilir. Değerlendirme modunda, çıktı bir filigran gibi sınırlamalar içerebilir. Toplu dışa aktarmaları çalıştırmadan önce süreç başına bir kez lisansı etkinleştirin.