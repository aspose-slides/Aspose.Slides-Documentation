---
title: ".NET'te PowerPoint Slaytlarını PNG'ye Dönüştür"
linktitle: "PowerPoint'ten PNG'ye"
type: docs
weight: 30
url: /tr/net/convert-powerpoint-to-png/
keywords:
- "PowerPoint dönüştür"
- "Sunumu dönüştür"
- "Slaytı dönüştür"
- "PPT dönüştür"
- "PPTX dönüştür"
- "PowerPoint'ten PNG'ye"
- "Sunumdan PNG'ye"
- "Slayttan PNG'ye"
- "PPT'den PNG'ye"
- "PPTX'ten PNG'ye"
- "PPT'yi PNG olarak kaydet"
- "PPTX'i PNG olarak kaydet"
- "PPT'yi PNG'ye dışa aktar"
- "PPTX'i PNG'ye dışa aktar"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET ile PowerPoint sunumlarını yüksek kalite PNG görüntülerine hızla dönüştürün, doğru ve otomatik sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını PNG görüntülerine dönüştürmeyi açıklar. PPT, PPTX ve ODP gibi formatlardaki sunum dosyalarını nasıl yükleyeceğinizi, slaytları görüntü olarak nasıl işleyebileceğinizi ve sonuçları PNG formatında nasıl kaydedeceğinizi gösterir.

Makale ayrıca, ölçek değerlerini ayarlayarak veya istenen genişlik ve yüksekliği belirterek oluşturulan PNG görüntülerini nasıl özelleştireceğinizi de gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfını örnekleyin.
2. [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/properties/slides) koleksiyonundan, [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide) arayüzü altında slide nesnesini alın.
3. İhtiyacınız olan ölçekte her slaytı oluşturmak için [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) yöntemini kullanın.
4. Slide küçük resmini PNG formatına kaydetmek için [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.ipresentation/save/methods/5) yöntemini kullanın.

Bu C# kodu, bir PowerPoint sunumunu PNG'ye nasıl dönüştüreceğinizi gösterir. Presentation nesnesi PPT, PPTX, ODP vb. dosyaları yükleyebilir; ardından sunumdaki her slide PNG formatına veya diğer görüntü formatlarına dönüştürülür.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Not:** Ölçek argümanları `1f, 1f` her slaytı tam boyutunda oluşturur, bu yüzden 720×540 pt slayt 720×540 px görüntü üretir. Parametresiz [GetImage()](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) aşırı yükleme çok daha küçük bir ön izleme küçük resmi döndürür.
{{% /alert %}} 

## **PowerPoint'i PNG'ye Özel Boyutlarla Dönüştür**

Belirli bir ölçeğe yakın PNG dosyaları elde etmek istiyorsanız, `desiredX` ve `desiredY` değerlerini ayarlayabilirsiniz; bu değerler ortaya çıkan küçük resmin boyutlarını belirler.

Bu C# kodu, açıklanan işlemi göstermektedir:

```c#
using Aspose.Slides;

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

## **PowerPoint'i PNG'ye Özel Boyutla Dönüştür**

Belirli bir boyuta yakın PNG dosyaları elde etmek istiyorsanız, `imageSize` için tercih ettiğiniz `width` ve `height` argümanlarını geçirebilirsiniz.

Bu kod, görüntüler için boyutu belirterek bir PowerPoint'i PNG'ye nasıl dönüştüreceğinizi gösterir: 

```c#
using System.Drawing;
using Aspose.Slides;

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

## **SSS**

### Sadece bir şekli (ör. grafik veya resim) tüm slayt yerine nasıl dışa aktarabilirim?

Aspose.Slides, [individual shapes için küçük resimler oluşturmayı](/slides/tr/net/create-shape-thumbnails/) destekler; bir şekli PNG görüntüsü olarak işleyebilirsiniz.

### Sunucuda paralel dönüşüm destekleniyor mu?

Evet, ancak tek bir presentation örneğini thread'ler arasında [paylaşmayın](/slides/tr/net/multithreading/). Her thread veya işlem için ayrı bir örnek kullanın.

### PNG'ye dışa aktarırken deneme sürümü sınırlamaları nelerdir?

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/net/licensing/) uygular.