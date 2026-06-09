---
title: PowerPoint Slaytlarını C++'da PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG
type: docs
weight: 30
url: /tr/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PNG
- sunumu PNG'ye
- slaytı PNG'ye
- PPT'yi PNG'ye
- PPTX'i PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarını yüksek kaliteli PNG görüntülerine hızlıca dönüştürün, kesin ve otomatik sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını PNG görüntülerine nasıl dönüştüreceğinizi açıklar. PPT, PPTX ve ODP gibi formatlarda sunum dosyalarını nasıl yükleyeceğinizi, slaytları görüntü olarak nasıl işleyebileceğinizi ve sonuçları PNG formatında nasıl kaydedeceğinizi gösterir.

Makale ayrıca, ölçek değerlerini ayarlayarak veya istenen genişlik ve yüksekliği belirterek oluşturulan PNG görüntülerinin nasıl özelleştirileceğini gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. [Presentation::get_Slides()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) koleksiyonundan, [ISlide](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_slide) arayüzü altında slayt nesnesini alın.
3. [ISlide::GetImage()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage) metodunu kullanarak her slayt için mini resmi alın.
4. Slide mini resmini PNG formatında kaydetmek için [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) metodunu kullanın.

Bu C++ kodu, bir PowerPoint sunumunu PNG'ye nasıl dönüştüreceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **PowerPoint'i PNG'ye Özelleştirilmiş Boyutlarla Dönüştür**

Belirli bir ölçeğe göre PNG dosyaları elde etmek istiyorsanız, sonuç mini resminin boyutlarını belirleyen `desiredX` ve `desiredY` değerlerini ayarlayabilirsiniz.

C++ kodu, açıklanan işlemi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **PowerPoint'i PNG'ye Özelleştirilmiş Boyutta Dönüştür**

Belirli bir boyutta PNG dosyaları elde etmek istiyorsanız, `ImageSize` için istediğiniz `width` ve `height` argümanlarını geçirebilirsiniz.

Bu kod, bir PowerPoint'i PNG'ye dönüştürürken görüntülerin boyutunu nasıl belirteceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **SSS**

**Bir slayın tamamı yerine yalnızca belirli bir şekli (ör. grafik veya resim) nasıl dışa aktarabilirim?**

Aspose.Slides, [generating thumbnails for individual shapes](/slides/tr/cpp/create-shape-thumbnails/) özelliğini destekler; bir şekli PNG görüntüsüne işleyebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet, ancak tek bir sunum örneğini iş parçacıkları arasında [don’t share](/slides/tr/cpp/multithreading/) etmeyin. Her iş parçacığı veya süreç için ayrı bir örnek kullanın.

**PNG olarak dışa aktarırken deneme sürümü sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve bir lisans uygulanana kadar [other restrictions](/slides/tr/cpp/licensing/) uygular.