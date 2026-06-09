---
title: Bir Sunumdan Tüm Slayt Arka Planını Görüntü Olarak Al
linktitle: Tüm Slayt Arka Planı
type: docs
weight: 95
url: /tr/net/get-the-entire-presentation-slide-background-as-an-image/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarından tam slayt arka planlarını görseller olarak çıkarın, görsel iş akışlarını kolaylaştırın."
---
## **Genel Bakış**

PowerPoint sunumlarında bir slayt arka planı, slayt arka plan görüntüsü, sunum teması, renk şeması ve ana slayt ya da yerleşim slaytına yerleştirilen nesneler gibi birden çok öğeden oluşabilir.

Bu makale, Aspose.Slides for .NET kullanarak tüm slayt arka planını bir görüntü olarak nasıl çıkaracağını gösterir. Bu görev için tek bir yöntem bulunmadığından, yaklaşım seçilen slaytı geçici bir sunuma kopyalamayı, slayt şekillerini kaldırmayı ve ardından ortaya çıkan slayt arka planını bir görüntüye dönüştürmeyi içerir.

## **Tüm Slayt Arka Planını Al**

Aspose.Slides for .NET, tüm sunum slayt arka planını bir görüntü olarak çıkarmak için basit bir yöntem sağlamaz, ancak aşağıdaki adımları izleyerek bunu yapabilirsiniz:
1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Sunumdan slayt boyutunu alın.
1. Bir slayt seçin.
1. Geçici bir sunum oluşturun.
1. Geçici sunumda aynı slayt boyutunu ayarlayın.
1. Seçilen slaytı geçici sunuma klonlayın.
1. Klonlanan slayttaki şekilleri silin.
1. Klonlanan slaytı bir görüntüye dönüştürün.

Aşağıdaki kod örneği, tüm sunum slayt arka planını bir görüntü olarak çıkarır.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **SSS**

**Ana slayttan gelen karmaşık gradyanlar, dokular veya resim doldurmaları oluşturulan arka plan görüntüsünde korunur mu?**

Evet. Aspose.Slides, slayt, yerleşim veya ana üzerinde tanımlanan gradyan, resim ve doku doldurmalarını işler. Kalıtılan ana slaytlardan görünümü izole etmeniz gerekiyorsa, dışa aktarmadan önce geçerli slaytta [kendi arka planınızı ayarlayın](/slides/tr/net/presentation-background/) ayarlayın.

**Kaydetmeden önce oluşturulan arka plan görüntüsüne bir filigran ekleyebilir miyim?**

Evet. [filigran ekleyin](/slides/tr/net/watermark/) şekli veya görüntüsü, diğer içeriklerin arkasına yerleştirilmiş bir çalışma [slayt kopyası](/slides/tr/net/clone-slides/) üzerine ekleyebilir ve ardından dışa aktarabilirsiniz. Bu, filigranın yerleşik olduğu bir arka plan görüntüsü oluşturmanızı sağlar.

**Mevcut bir slayta bağlamadan belirli bir yerleşim veya ana için arka planı alabilir miyim?**

Evet. İstenen ana ya da yerleşime erişin, gerekli boyutta bir [geçici slayt](/slides/tr/net/clone-slides/) üzerine uygulayın ve o slaytı dışa aktararak yerleşim ya da ana tarafından türetilen arka planı elde edin.

**Görüntü dışa aktarımını etkileyen lisans sınırlamaları var mı?**

Render özellikleri, [geçerli bir lisans](/slides/tr/net/licensing/) ile tamamen kullanılabilir. Değerlendirme modunda, çıktı bir filigran gibi sınırlamalar içerebilir. Toplu dışa aktarımları çalıştırmadan önce lisansı süreç başına bir kez etkinleştirin.