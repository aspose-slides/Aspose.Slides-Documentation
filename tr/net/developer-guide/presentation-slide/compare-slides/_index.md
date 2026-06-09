---
title: .NET'te Sunum Slaytlarını Karşılaştır
linktitle: Slaytları Karşılaştır
type: docs
weight: 50
url: /tr/net/compare-slides/
keywords:
- slaytları karşılaştır
- slayt karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarını programlı olarak karşılaştırın. Kod içinde slayt farklılıklarını hızlıca belirleyin."
---
## **Genel Bakış**

Aspose.Slides, `IBaseSlide` arayüzü ve `BaseSlide` sınıfı tarafından sağlanan `Equals` yöntemini kullanarak slaytları, düzen slaytlarını ve ana slaytları karşılaştırmanıza olanak tanır. Bu yöntem, karşılaştırılan slaytlar yapı ve statik içerik açısından aynı olduğunda `true` döndürür.

## **İki Slaytı Karşılaştır**

`Equals` yöntemi, [IBaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide) arayüzüne ve [BaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslide) sınıfına eklenmiştir. Yapı ve statik içerik açısından aynı olan slayt/düzen ve slayt/ana slaytlar için `true` döndürür.

İki slayt, tüm şekiller, stiller, metinler, animasyonlar ve diğer ayarlar aynı olduğunda eşittir. vb. Karşılaştırma, SlideId gibi benzersiz tanımlayıcı değerleri ve Tarih Yer Tutucusu'ndaki geçerli tarih değeri gibi dinamik içeriği dikkate almaz.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **SSS**

**Bir slaytın gizli olması, slaytların kendisinin karşılaştırmasını etkiler mi?**

[Hidden status](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/hidden/) bir sunum/oynatım seviyesindeki özelliktir, görsel içerik değildir. İki belirli slaytın eşitliği, yapı ve statik içerikleriyle belirlenir; bir slaytın gizli olması, slaytları farklı kılmaz.

**Köprüler ve parametreleri dikkate alınıyor mu?**

Evet. Bağlantılar slaytın statik içeriğinin bir parçasıdır. URL veya köprü eylemi farklıysa, bu genellikle statik içerikte bir fark olarak değerlendirilir.

**Bir grafik dış bir Excel dosyasına referans veriyorsa, o dosyanın içeriği dikkate alınır mı?**

Hayır. Karşılaştırma sadece slaytların kendisine dayanarak yapılır. Dış veri kaynakları genellikle karşılaştırma sırasında okunmaz; sadece slaytın yapısında ve statik durumunda bulunanlar dikkate alınır.