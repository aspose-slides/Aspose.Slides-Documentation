---
title: Bir Sunumdan Tüm Slayt Arka Planını Görüntü Olarak Alın
linktitle: Tam Slayt Arka Planı
type: docs
weight: 95
url: /tr/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slayt arka planı
- tam arka plan
- arka planı çıkar
- tam arka plan
- arkaplanı görüntüye
- PPT arka planı
- PPTX arka planı
- ODP arka planı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarından tam slayt arka planlarını görüntü olarak çıkarın, görsel iş akışlarını hızlandırın."
---
## **Genel Bakış**

PowerPoint sunumlarında bir slayt arka planı, slayt arka plan görüntüsü, sunum teması, renk şeması ve ana slayt ya da düzen slaytına yerleştirilen nesneler gibi birden çok öğeden oluşabilir.

Bu makale, Aspose.Slides kullanarak tüm slayt arka planını bir görüntü olarak nasıl çıkaracağınızı gösterir. Bu görev için tek bir yöntem bulunmadığından, yaklaşım seçilen slaytı geçici bir sunuma kopyalamayı, slayt şekillerini kaldırmayı ve ardından elde edilen slayt arka planını bir görüntüye dönüştürmeyi içerir.

## **Tüm Slayt Arka Planını Alın**

Aspose.Slides for PHP via Java, tüm sunum slayt arka planını bir görüntü olarak çıkarmak için basit bir yöntem sunmaz, ancak aşağıdaki adımları izleyerek bunu yapabilirsiniz:
1. Sunumu [Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Sunumdan slayt boyutunu alın.
1. Bir slayt seçin.
1. Geçici bir sunum oluşturun.
1. Geçici sunumda aynı slayt boyutunu ayarlayın.
1. Seçilen slaytı geçici sunuma klonlayın.
1. Klonlanmış slayttaki şekilleri silin.
1. Klonlanmış slaytı bir görüntüye dönüştürün.

Aşağıdaki kod örneği, tüm sunum slayt arka planını bir görüntü olarak çıkarır.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **SSS**

**Karmaşık geçişler, dokular veya bir ana slayttan resim dolgu öğeleri, elde edilen arka plan görüntüsünde korunur mu?**

Evet. Aspose.Slides, slayt, düzen veya ana slaytta tanımlanan gradyan, resim ve doku dolgu öğelerini işler. Kalıtılmış ana slaytlardan görünümü izole etmeniz gerekiyorsa, dışa aktarmadan önce mevcut slayta [kendi arka planınızı ayarlayın](/slides/tr/php-java/presentation-background/).

**Kaydetmeden önce elde edilen arka plan görüntüsüne bir filigran ekleyebilir miyim?**

Evet. Çalışma [slayt kopyası](/slides/tr/php-java/clone-slides/) üzerine (diğer içeriğin arkasına yerleştirilecek) bir [filigran ekleyin](/slides/tr/php-java/watermark/) şekli veya resmi ekleyebilir ve ardından dışa aktarabilirsiniz. Bu, filigranın yerleştirildiği bir arka plan görüntüsü oluşturmanızı sağlar.

**Mevcut bir slayta bağlamadan belirli bir düzen veya ana slaytın arka planını alabilir miyim?**

Evet. İstenen ana slaytı veya düzeni alın, gerekli boyutta bir [geçici slayta](/slides/tr/php-java/clone-slides/) uygulayın ve o slaytı dışa aktararak o düzen veya ana slayttan türetilen arka planı elde edin.

**Görüntü dışa aktarmayı etkileyen lisans sınırlamaları var mı?**

Render özellikleri, bir [geçerli lisans](/slides/tr/php-java/licensing/) ile tamamen kullanılabilir. Değerlendirme modunda, çıktı bir filigran gibi sınırlamalar içerebilir. Toplu dışa aktarmaları çalıştırmadan önce işlem başına bir kez lisansı etkinleştirin.