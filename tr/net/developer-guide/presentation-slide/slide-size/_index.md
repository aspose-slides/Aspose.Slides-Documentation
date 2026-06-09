---
title: "Sunum Slayt Boyutunu .NET'te Değiştirme"
linktitle: "Slayt Boyutu"
type: docs
weight: 70
url: /tr/net/slide-size/
keywords:
- "slayt boyutu"
- "en‑boy oranı"
- "standart"
- "geniş ekran"
- "4:3"
- "16:9"
- "slayt boyutunu ayarla"
- "slayt boyutunu değiştir"
- "özelleştirilmiş slayt boyutu"
- "özel slayt boyutu"
- "benzersiz slayt boyutu"
- "tam boyutlu slayt"
- "ekran tipi"
- "ölçekleme yapma"
- "uygunluğu sağla"
- "büyüt"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
descriptions: "PPT, PPTX ve ODP dosyalarında slaytları .NET ve Aspose.Slides ile nasıl hızlıca yeniden boyutlandıracağınızı öğrenin, kalite kaybı olmadan herhangi bir ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides for .NET, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekran görüntüsü için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En‑Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 En‑Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tüm slaytlara tek bir slayt boyutu ve en‑boy oranı uygulanır. En iyi sonuçlar için slayt boyutlarınızı sunum oluşturma sürecinin başında belirleyin, böylece komplikasyonlardan kaçınabilirsiniz.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Bir Sunumda Slayt Boyutunu Değiştirme**

Bu örnek, C# içinde Aspose.Slides kullanarak bir sunumun slayt boyutunu değiştirmeyi gösterir:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Özel Slayt Boyutlarını Belirleme**

Slayt boyutunu, benzersiz kağıt düzenleri veya ekran özellikleri gibi özel ihtiyaçlarınıza göre özelleştirmek faydalı olabilir. İşte Aspose.Slides for .NET ile özel bir slayt boyutu ayarlamanın yolu:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 kağıt boyutu
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini Yönetme**

Yeniden boyutlandırmadan sonra slayt içerikleri bozulabilir. Aspose.Slides'in bu yeniden boyutlandırmayı nasıl yöneteceğini kontrol edebilirsiniz:

- **`DoNotScale`**: Nesneleri orijinal boyutlarında tutarak ölçeklendirmeyi önler.
- **`EnsureFit`**: Nesneleri daha küçük slaytlara sığacak şekilde ölçeklendirir, içerik kaybını önler.
- **`Maximize`**: Daha büyük slaytlara uyacak şekilde nesneleri büyütür, estetik tutarlılık sağlar.

`Maximize` ayarını kullanarak slayt boyutu ayarlama örneği:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **SSS**

**İnç dışında birim kullanarak (örneğin, puan veya milimetre) özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puan birimini kullanır; 1 puan bir inçin 1/72'sine eşittir. Milimetre veya santimetre gibi herhangi bir birimi puana dönüştürerek slayt genişliğini ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, renderleme sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği birleştirildiğinde bellek tüketimi artar ve işlem süresi uzar. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için yalnızca gerektiğinde render ölçeğini ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Slayt boyutları farklı olduğu sürece [sunumları birleştiremezsiniz](/slides/tr/net/merge-presentation/) — önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) seçeneği ile seçebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya bir slaydın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutuna saygı gösterir mi?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage/) ve ayrıca [seçili şekiller](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/) için küçük resimler oluşturabilir. Oluşan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtır, tutarlı çerçeveleme ve geometriyi garanti eder.