---
title: PowerPoint Slaytlarını .NET'te PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/net/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PNG'ye
- sunumdan PNG'ye
- slayttan PNG'ye
- PPT'den PNG'ye
- PPTX'ten PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarını yüksek kalitede PNG görüntülerine hızlıca dönüştürerek, kesin ve otomatik sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını PNG görüntülerine nasıl dönüştüreceğinizi açıklar. PPT, PPTX ve ODP gibi formatlardaki sunum dosyalarını nasıl yükleyeceğinizi, slaytları görüntü olarak nasıl render edeceğinizi ve sonuçları PNG formatında nasıl kaydedeceğinizi gösterir.

Makale ayrıca, ölçek değerlerini ayarlayarak veya istenen genişlik ve yüksekliği belirterek oluşturulan PNG görüntülerini nasıl özelleştirebileceğinizi gösterir.

## **PowerPoint'i PNG'e Dönüştür**

Bu adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.
2. ISlide arayüzü altında bulunan Presentation.Slides koleksiyonundan slayt nesnesini alın. 
3. Her bir slaytın önizlemesini almak için ISlide.GetImage metodunu kullanın. 
4. Slayt önizlemesini PNG formatında kaydetmek için IPresentation.Save(String, SaveFormat, ISaveOptions) metodunu kullanın. 

Bu C# kodu, bir PowerPoint sunumunu PNG'ye nasıl dönüştüreceğinizi gösterir. Presentation nesnesi PPT, PPTX, ODP vb. formatları yükleyebilir ve ardından sunumdaki her bir slayt PNG formatına veya diğer görüntü formatlarına dönüştürülür.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Özel Boyutlarla PowerPoint'i PNG'e Dönüştür**

Belirli bir ölçeğe yakın PNG dosyaları elde etmek istiyorsanız, sonuç önizlemesinin boyutlarını belirleyen `desiredX` ve `desiredY` değerlerini ayarlayabilirsiniz. 

Bu C# kodu, açıklanan işlemi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Özel Boyutlarla PowerPoint'i PNG'e Dönüştür**

Belirli bir boyuta yakın PNG dosyaları elde etmek istiyorsanız, `imageSize` için tercih ettiğiniz `width` ve `height` parametrelerini geçebilirsiniz. 

Bu kod, görüntüler için boyutu belirterek bir PowerPoint'i PNG'ye nasıl dönüştüreceğinizi gösterir: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **FAQ**

**Bir slaytın tamamı yerine yalnızca belirli bir şekli (ör. grafik veya resim) nasıl dışa aktarabilirim?**

Aspose.Slides, bireysel şekiller için önizlemeler oluşturmayı destekler; bir şekli PNG görüntüsü olarak render edebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet, ancak tek bir sunum örneğini birden fazla iş parçacığı arasında paylaşmayın. İş parçacığı veya süreç başına ayrı bir örnek kullanın.

**PNG'ye dışa aktarırken deneme sürümünün sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar diğer kısıtlamaları uygular.