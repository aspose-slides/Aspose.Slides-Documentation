---
title: .NET'te Sunum Slayt Boyutunu Değiştirin
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/net/slide-size/
keywords:
- slayt boyutu
- en-boy oranı
- standart
- geniş ekran
- 4:3
- 16:9
- slayt boyutu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- benzersiz slayt boyutu
- tam boyutlu slayt
- ekran türü
- ölçekleme yapma
- uygunluk sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET ve Aspose.Slides ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırmayı öğrenin, herhangi bir ekranda kalite kaybı olmadan sunumları optimize edin."
---
## **Giriş**

Aspose.Slides for .NET, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem yazdırma hem de ekranda görüntüleme için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En-Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En-Boy Oranı)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tüm slaytlara tek bir slayt boyutu ve en‑boy oranı uygulanır. En iyi sonuçlar için, karmaşaları önlemek amacıyla slayt boyutlarını sunum oluşturma sürecinin başında ayarlayın.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumda Slayt Boyutunu Nasıl Değiştirilir**

Bu örnek, Aspose.Slides kullanarak C#'ta bir sunumun slayt boyutunu nasıl değiştireceğinizi gösterir:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Özel Slayt Boyutlarını Belirleyin**

Slayt boyutunu özgün kağıt düzenleri veya ekran özellikleri gibi belirli ihtiyaçlarınıza göre özelleştirmek yararlı olabilir. Aspose.Slides for .NET ile özel bir slayt boyutu ayarlamanın yolu aşağıdadır:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 kağıt boyutu
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Kaydırma Sonrası Slayt İçeriğini Yönetme**

Boyutlandırma sonrası slayt içeriği bozulabilir. Aspose.Slides'in bu yeniden boyutlandırmayı nasıl yöneteceğini kontrol edebilirsiniz:

- **`DoNotScale`**: Nesneleri orijinal boyutlarında tutarak ölçeklendirmeyi önler.
- **`EnsureFit`**: Nesneleri daha küçük slaytlara sığdırmak için ölçeklendirir, içerik kaybını önler.
- **`Maximize`**: Daha büyük slaytlara uyacak şekilde nesneleri büyütür, estetik tutarlılık sağlar.

`Maximize` ayarını kullanarak slayt boyutu ayarlama örneği:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **SSS**

**İnç dışındaki birimler (örneğin, puan veya milimetre) kullanarak özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides içsel olarak puan (point) birimini kullanır; 1 puan 1/72 inçtir. Milimetre veya santimetre gibi herhangi bir birimi puana dönüştürerek slayt genişliğini ve yüksekliğini bu değerlerle belirleyebilirsiniz.

**Çok büyük bir özel slayt boyutu, işleme sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği birleştiğinde bellek tüketimi artar ve işlem süreleri uzar. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için render ölçeğini yalnızca gerektiğinde ayarlayın.

**Standart dışı bir slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece sunumları [sunumları birleştirme](/slides/tr/net/merge-presentation/) birleştiremezsiniz — önce bir sunumun boyutunu diğerine uyacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları eşitledikten sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya bir slaydın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutuna uyumlu olur mu?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage/) ve [seçili şekiller](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/) için küçük resimler oluşturabilir. Oluşturulan görüntüler, mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometriyi sağlar.