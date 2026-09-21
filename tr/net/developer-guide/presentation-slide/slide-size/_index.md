---
title: PowerPoint Sunumunda Slayt Boyutunu .NET ile Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/net/slide-size/
keywords:
- slayt boyutu
- en‑boy oranı
- standart
- geniş ekran
- 4:3
- 16:9
- slayt boyutunu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- eşsiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- ölçeklendirme yok
- uygun şekilde sığdır
- büyüt
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PPT, PPTX ve ODP dosyalarında .NET ve Aspose.Slides ile slaytları hızlıca yeniden boyutlandırmayı öğrenin, kaliteden ödün vermeden her ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides for .NET, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem baskı hem de ekranda görüntüleme için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En‑Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 En‑Boy Oranı)**: Modern projektör ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlayın; tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, slayt boyutlarınızı sunumu oluşturma sürecinin başında ayarlayın ve komplikasyonlardan kaçının.

{{% alert color="info" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

Not ve el ilanı sayfalarının boyutları normal slaytlardan ayrıdadır. Boyutlarını ve yönelimlerini değiştirmek için [Notes Page Size](/slides/tr/net/notes-size/) sayfasına bakın.

## **Sunumda Slayt Boyutunu Nasıl Değiştirilir**

Bu örnek, C# ile Aspose.Slides kullanarak bir sunumun slayt boyutunu nasıl değiştireceğinizi gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Özel Slayt Boyutlarını Belirleme**

Slayt boyutunu belirli ihtiyaçlarınıza göre özelleştirmek, örneğin benzersiz kağıt düzenleri veya ekran gereksinimleri için faydalı olabilir. .NET için Aspose.Slides ile özel bir slayt boyutu ayarlama yöntemi aşağıdadır:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 kağıt boyutu
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini Yönetme**

Yeniden boyutlandırmadan sonra slayt içeriği bozulabilir. Aspose.Slides'in bu yeniden boyutlandırmayı nasıl yöneteceğini kontrol edebilirsiniz:

- **`DoNotScale`**: Nesneleri orijinal boyutlarında tutarak ölçeklendirmeyi önler.
- **`EnsureFit`**: Nesneleri daha küçük slaytlara sığdırmak için ölçeklendirir, içerik kaybını önler.
- **`Maximize`**: Nesneleri daha büyük slaytlara uyacak şekilde büyütür, görsel tutarlılık sağlar.

`Maximize` ayarının slayt boyutu ayarlaması için kullanımına ilişkin örnek:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **SSS**

### Ölçü birimi olarak inç yerine (örneğin puan veya milimetre) birim kullanarak özel bir slayt boyutu belirleyebilir miyim?

Evet. Aspose.Slides dahili olarak puanları kullanır; 1 puan 1/72 inç’e eşittir. Herhangi bir birimi (milimetre veya santimetre gibi) puana dönüştürüp slayt genişliği ve yüksekliği olarak kullanabilirsiniz.

### Çok büyük bir özel slayt boyutu, render sırasında performans ve bellek kullanımını etkiler mi?

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği, bellek tüketimini artırır ve işlem süresini uzatır. Pratik bir slayt boyutu hedefleyin ve yalnızca istenen çıktı kalitesini elde etmek için render ölçeğini ayarlayın.

### Standart olmayan bir slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?

Farklı slayt boyutlarına sahip sunumları [merge presentations](/slides/tr/net/merge-presentation/) ile birleştiremezsiniz — önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırmanız gerekir. Slayt boyutunu değiştirirken mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutlar eşleştiğinde, formatlamayı koruyarak slaytları birleştirebilirsiniz.

### Bir slayttaki tek tek şekiller veya belirli bölgeler için küçük resimler oluşturabilir miyim ve yeni slayt boyutuna uyumlu olur mu?

Evet. Aspose.Slides, [entire slides](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage/) ve [selected shapes](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/) için küçük resimler oluşturabilir. Oluşturulan görüntüler geçerli slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometrik doğruuluk sağlar.