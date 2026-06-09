---
title: Ölçmeli Lisanslama
type: docs
weight: 90
url: /tr/net/metered-licensing/
keywords:
- lisans
- ölçmeli lisans
- lisans anahtarları
- genel anahtar
- özel anahtar
- tüketim miktarı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ölçmeli lisanslamanın PowerPoint ve OpenDocument dosyalarını esnek bir şekilde işlemenizi ve yalnızca kullandığınız kadar ödeme yapmanızı nasıl sağladığını öğrenin."
---
## **Giriş**

Metered licensing, mevcut lisanslama yöntemleriyle birlikte kullanılabilen bir lisans mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız ölçmeli lisanslamayı seçersiniz.

## **Ölçmeli Anahtarları Uygula**

Bir ölçmeli lisans satın aldığınızda anahtarlar alırsınız (ve bir lisans dosyası almazsınız). Bu ölçmeli anahtar, Aspose’un ölçüm işlemleri için sağladığı [Metered](https://reference.aspose.com/slides/tr/net/aspose.slides/metered/) sınıfı kullanılarak uygulanabilir. Daha fazla ayrıntı için [Ölçmeli Lisanslama SSS](https://purchase.aspose.com/faqs/licensing/metered) sayfasına bakın.

1. [Metered](https://reference.aspose.com/slides/tr/net/aspose.slides/metered/) sınıfının bir örneğini oluşturun.  
1. Genel ve özel anahtarlarınızı [SetMeteredKey](https://reference.aspose.com/slides/tr/net/aspose.slides/metered/setmeteredkey/) metoduna geçirin.  
1. Biraz işleme yapın (görevleri gerçekleştirin).  
1. `Metered` sınıfının [GetConsumptionQuantity](https://reference.aspose.com/slides/tr/net/aspose.slides/metered/getconsumptionquantity/) metodunu çağırın.

Şu ana kadar tükettiğiniz API isteklerinin miktarını/adetini görebilmelisiniz.

Bu örnek kod, ölçmeli lisanslamayı nasıl kullanacağınızı gösterir:

```cs
// Metered sınıfının bir örneğini oluşturur
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Genel ve özel anahtarları Metered nesnesine geçirir
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// API çağrısından önce ölçmeli veri miktarını alır
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Burada Aspose.Slides API ile bir şeyler yapın
// ...

// API çağrısından sonra ölçmeli veri miktarını alır
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOT"  %}} 
Ölçmeli lisanslamayı kullanmak için, lisans mekanizması hizmetlerimizle sürekli etkileşimde bulunmak ve hesaplamalar yapmak için internete ihtiyaç duyduğundan, sabit bir internet bağlantısına ihtiyacınız vardır.
{{% /alert %}} 

## **SSS**

**Aynı uygulamada ölçmeli lisansı, normal bir (kalıcı veya geçici) lisansla birlikte kullanabilir miyim?**

Evet. Ölçmeli, mevcut [lisanslama yöntemleri](/slides/tr/net/licensing/) ile birlikte kullanılabilen ek bir lisans mekanizmasıdır. Uygulama başladığında hangi mekanizmayı uygulayacağınıza siz karar verirsiniz.

**Ölçmeli lisans altında tüketim olarak tam olarak ne sayılır: işlemler mi dosyalar mı?**

API kullanımı sayılır, yani istek veya işlem sayısı. Mevcut tüketimi [tüketim-izleme yöntemleri](https://reference.aspose.com/slides/tr/net/aspose.slides/metered/) aracılığıyla alabilirsiniz.

**Ölçmeli, örneklerin sık sık yeniden başlatıldığı mikro hizmetler ve sunucusuz ortamlar için uygun mu?**

Evet. Hesaplama API çağrı düzeyinde yapıldığından, sık soğuk başlatma senaryoları, ölçmeli hesaplamalar için istikrarlı bir ağ erişimi sağlandığı sürece uyumludur.

**Kalıcı bir lisansla karşılaştırıldığında ölçmeli lisans kullanıldığında kütüphanenin işlevselliği farklı mı?**

Hayır. Bu sadece lisans ve faturalandırma mekanizmasıyla ilgilidir; ürünün yetenekleri aynı kalır.

**Ölçmeli, deneme sürümü ve geçici lisansla nasıl ilişkilidir?**

Deneme sürümünün sınırlamaları ve filigranları vardır, [geçici lisans](https://purchase.aspose.com/temporary-license/) sınırlamaları 30 gün için kaldırır ve ölçmeli sınırlamaları kaldırarak gerçek kullanım bazında ücretlendirir.

**Bir tüketim eşiği aşıldığında otomatik olarak tepki vererek bütçeyi kontrol edebilir miyim?**

Evet. Yaygın bir uygulama, mevcut tüketimi periyodik olarak [izleme yöntemleri](https://reference.aspose.com/slides/tr/net/aspose.slides/metered/) okuyup, uygulama veya izleme seviyesinde kendi limitlerinizi veya uyarılarınızı uygulamaktır.