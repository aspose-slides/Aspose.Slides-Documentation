---
title: Sunumdan Tüm Slayt Arka Planını Görüntü Olarak Al
linktitle: Tam Slayt Arka Planı
type: docs
weight: 95
url: /tr/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slayt arka planı
- nihai arka plan
- arka planı çıkar
- tam arka plan
- arka planı görüntüye
- PPT arka planı
- PPTX arka planı
- ODP arka planı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarından tam slayt arka planlarını görüntü olarak çıkararak görsel iş akışlarını kolaylaştırın."
---
## **Genel Bakış**

PowerPoint sunumlarında bir slayt arka planı, slayt arka plan resmi, sunum teması, renk şeması ve ana slayt veya düzen slaytına yerleştirilen nesneler gibi birden fazla öğeden oluşabilir.

Bu makale, Aspose.Slides kullanarak tüm slayt arka planını bir resim olarak nasıl çıkaracağınızı gösterir. Bu görev için tek bir yöntem bulunmadığından, yaklaşım seçilen slaytı geçici bir sunuma kopyalamayı, slayt şekillerini kaldırmayı ve ardından elde edilen slayt arka planını bir resme dönüştürmeyi içerir.

## **Tüm Slayt Arka Planını Al**

Aspose.Slides for C++ tüm sunum slayt arka planını bir resim olarak çıkarmak için basit bir yöntem sunmaz, ancak aşağıdaki adımları izleyerek bunu yapabilirsiniz:
1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Sunumdan slayt boyutunu alın.
1. Bir slayt seçin.
1. Geçici bir sunum oluşturun.
1. Geçici sunumda aynı slayt boyutunu ayarlayın.
1. Seçilen slaytı geçici sunuma klonlayın.
1. Klonlanan slayttaki şekilleri silin.
1. Klonlanan slaytı bir görüntüye dönüştürün.

Aşağıdaki kod örneği tüm sunum slayt arka planını bir resim olarak çıkarır.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **SSS**

**Ana slayttan gelen karmaşık gradyanlar, dokular veya resim doldurmaları sonuç arka plan görüntüsünde korunur mu?**

Evet. Aspose.Slides, slayt, düzen veya ana şablonda tanımlanan gradyan, resim ve doku doldurmalarını işler. Kalıtsal ana şablonlardan görünümü izole etmeniz gerekiyorsa, dışa aktarmadan önce geçerli slaytta **kendi arka planınızı ayarlayın**[/slides/tr/cpp/presentation-background/].

**Kaydetmeden önce sonuç arka plan görüntüsüne bir filigran ekleyebilir miyim?**

Evet. Çalışma **slayt kopyası**[/slides/tr/cpp/clone-slides/] üzerine bir **filigran**[/slides/tr/cpp/watermark/] şekli veya resmi ekleyebilir (diğer içeriğin arkasına yerleştirerek) ve ardından dışa aktarabilirsiniz. Bu sayede filigranın gömülü olduğu bir arka plan resmi oluşturabilirsiniz.

**Mevcut bir slayta bağlamadan belirli bir düzenin veya ana şablonun arka planını alabilir miyim?**

Evet. İstenen ana şablona veya düzene erişin, gereken boyutta **geçici bir slayt**[/slides/tr/cpp/clone-slides/] uygulayın ve o slaytı dışa aktararak ilgili düzen ya da ana şablondan türetilen arka planı elde edin.

**Görüntü dışa aktarımını etkileyen lisans sınırlamaları var mı?**

Render özellikleri geçerli bir **lisans**[/slides/tr/cpp/licensing/] ile tam olarak kullanılabilir. Değerlendirme modunda çıktı bir filigran gibi sınırlamalar içerebilir. Toplu dışa aktarımları çalıştırmadan önce süreç başına bir kez lisansı etkinleştirin.