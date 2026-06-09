---
title: Bir Sunumdan Tüm Slayt Arka Planını Görüntü Olarak Alın
linktitle: Tüm Slayt Arka Planı
type: docs
weight: 95
url: /tr/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slayt arka planı
- final arka planı
- arka plan çıkarma
- tam arka plan
- arka planı görüntüye
- PPT arka planı
- PPTX arka planı
- ODP arka planı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarından tam slayt arka planlarını görüntüler olarak çıkarın, görsel iş akışlarını basitleştirin."
---
## **Genel Bakış**

PowerPoint sunumlarında bir slayt arka planı, slayt arka plan görüntüsü, sunum teması, renk şeması ve ana slayt ya da yerleşim slaydına yerleştirilen nesneler gibi birden çok öğeden oluşabilir.

Bu makale, Aspose.Slides for .NET kullanarak tüm slayt arka planını bir görüntü olarak nasıl çıkarılacağını gösterir. Bu görev için tek bir yöntem olmadığından, yaklaşım seçilen slaytı geçici bir sunuma klonlamayı, slayt şekillerini kaldırmayı ve ardından elde edilen slayt arka planını bir görüntüye dönüştürmeyi içerir.

## **Tüm Slayt Arka Planını Alın**

Aspose.Slides for Android via Java, tüm sunum slayt arka planını bir görüntü olarak çıkarmak için basit bir yöntem sunmaz, ancak bu işlemi yapmak için aşağıdaki adımları izleyebilirsiniz:
1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Sunumdan slayt boyutunu alın.
1. Bir slayt seçin.
1. Geçici bir sunum oluşturun.
1. Geçici sunumda aynı slayt boyutunu ayarlayın.
1. Seçilen slaytı geçici sunuma klonlayın.
1. Klonlanan slayttan şekilleri silin.
1. Klonlanan slaytı bir görüntüye dönüştürün.

Aşağıdaki kod örneği, tüm sunum slayt arka planını bir görüntü olarak çıkarır.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **SSS**

**Bir ana slayttan gelen karmaşık degrade, doku veya resim dolgu öğeleri, oluşturulan arka plan görüntüsünde korunur mu?**

Evet. Aspose.Slides, slayt, yerleşim veya ana üzerinde tanımlanan degrade, resim ve doku dolgu öğelerini işler. Kalıtılan ana slaytlardan görünümü ayırmanız gerekiyorsa, dışa aktarmadan önce mevcut slayta [kendi arka planınızı ayarlayın](/slides/tr/androidjava/presentation-background/).

**Kaydetmeden önce oluşturulan arka plan görüntüsüne bir filigran ekleyebilir miyim?**

Evet. Çalışma [slayt kopyasına](/slides/tr/androidjava/clone-slides/) bir [filigran](/slides/tr/androidjava/watermark/) şekli veya resmi (diğer içeriklerin arkasına yerleştirilmiş) ekleyebilir ve ardından dışa aktarabilirsiniz. Bu, filigranın yerleştiği bir arka plan görüntüsü oluşturmanızı sağlar.

**Mevcut bir slayta bağlamadan belirli bir yerleşim veya ana için arka planı alabilir miyim?**

Evet. İstenen ana veya yerleşime erişin, bunu gerekli boyutta bir [geçici slayta](/slides/tr/androidjava/clone-slides/) uygulayın ve ardından o slaytı dışa aktararak yerleşim ya da ana üzerinden türetilen arka planı elde edin.

**Görüntü dışa aktarımını etkileyen lisans kısıtlamaları var mı?**

Render özellikleri, [geçerli bir lisans](/slides/tr/androidjava/licensing/) ile tamamen kullanılabilir. Değerlendirme modunda çıktı, filigran gibi kısıtlamalar içerebilir. Toplu dışa aktarımları çalıştırmadan önce lisansı süreç başına bir kez etkinleştirin.