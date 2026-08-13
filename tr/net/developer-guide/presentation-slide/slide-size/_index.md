---
title: Sunum Slayt Boyutunu .NET'te Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/net/slide-size/
keywords:
- slayt boyutu
- en/boy oranı
- standart
- geniş ekran
- 4:3
- 16:9
- slayt boyutunu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- benzersiz slayt boyutu
- tam boyutlu slayt
- ekran türü
- ölçeklendirme yok
- uygun şekilde sığdır
- büyüt
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PPT, PPTX ve ODP dosyalarında .NET ve Aspose.Slides ile slaytları hızlıca yeniden boyutlandırmayı, kaliteden ödün vermeden herhangi bir ekrana uyacak şekilde sunumları optimize etmeyi öğrenin."
---
## **Giriş**

Aspose.Slides for .NET, PowerPoint sunumlarında slayt boyutunu ve en/boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem baskı hem de ekran görüntüsü için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En/Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En/Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en/boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, karmaşayı önlemek amacıyla sunum oluşturma sürecinin başında slayt boyutlarınızı ayarlayın.

{{% alert color="info" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en/boy oranını kullanır.
{{% /alert %}}

## **Bir Sunumda Slayt Boyutunu Nasıl Değiştirilir**

Bu örnek, C#'ta Aspose.Slides kullanarak bir sunumun slayt boyutunu değiştirmeyi gösterir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Özel Slayt Boyutlarını Belirtme**

Slayt boyutunu, benzersiz kağıt düzenleri veya ekran özellikleri gibi belirli ihtiyaçlarınıza göre uyarlamak faydalı olabilir. Aspose.Slides for .NET ile özel bir slayt boyutu ayarlamanın yolu aşağıdadır:

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

Yeniden boyutlandırmadan sonra slayt içerikleri bozulabilir. Aspose.Slides'in bu yeniden boyutlandırmayı nasıl yöneteceğini kontrol edebilirsiniz:

- **`DoNotScale`**: Nesneleri ölçeklendirmeyi önlemek için orijinal boyutlarında tutar.
- **`EnsureFit`**: Nesneleri daha küçük slaytlara sığdırmak için ölçeklendirir, içerik kaybını önler.
- **`Maximize`**: Daha büyük slaytlara uyacak şekilde nesneleri büyütür, estetik tutarlılık sağlar.

`Maximize` ayarını kullanarak slayt boyutu ayarlama örneği:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **SSS**

### İnç dışındaki birimler (örneğin, puant ya da milimetre) kullanarak özel bir slayt boyutu ayarlayabilir miyim?

Evet. Aspose.Slides dahili olarak puant kullanır; 1 puant 1/72 inçtir. Herhangi bir birimi (örneğin milimetre ya da santimetre) puanta dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

### Çok büyük bir özel slayt boyutu, oluşturma sırasında performansı ve bellek kullanımını etkiler mi?

Evet. Daha büyük slayt boyutları (puant cinsinden) ve yüksek oluşturma ölçeği, bellek tüketimini artırır ve işleme süresini uzatır. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için yalnızca gerektiğinde oluşturma ölçeğini ayarlayın.

### Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştirme](/slides/tr/net/merge-presentation/) yapılamaz — önce bir sunumu diğerine uyduracak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) seçeneğiyle seçebilirsiniz. Boyutlar hizalandıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

### Tek tek şekiller veya bir slaydın belirli bölgeleri için küçük resimler oluşturabilir miyim ve yeni slayt boyutuna uyacaklar mı?

Evet. Aspose.Slides, [tüm slaytlar]https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage/ ve ayrıca [seçili şekiller]https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/ için küçük resimler oluşturabilir. Oluşan görseller mevcut slayt boyutunu ve en/boy oranını yansıtarak tutarlı çerçeveleme ve geometriyi sağlar.