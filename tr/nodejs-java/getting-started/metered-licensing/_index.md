---
title: Metrikli Lisanslama
type: docs
weight: 100
url: /tr/nodejs-java/metered-licensing/
keywords:
- lisans
- metrikli lisans
- lisans anahtarları
- açık anahtar
- özel anahtar
- tüketim miktarı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'in Java aracılığıyla metrikli lisanslama ile, PowerPoint ve OpenDocument dosyalarını esnek bir şekilde işleyebileceğinizi ve sadece kullandığınız kadar ödeme yapabileceğinizi öğrenin."
---
## **Giriş**

Metrikli lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız, metrikli lisanslamayı seçersiniz.

## **Metrikli Anahtarları Uygulama**

Metrikli bir lisans satın aldığınızda, bir lisans dosyası yerine anahtarlar alırsınız. Bu metrikli anahtar, Aspose'un ölçüm işlemleri için sağladığı [Metered](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/metered/) sınıfı kullanılarak uygulanabilir. Daha fazla ayrıntı için [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) sayfasına bakın.

1. [Metered](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/metered/) sınıfının bir örneğini oluşturun.

1. Genel ve özel anahtarlarınızı [setMeteredKey](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/metered/#setMeteredKey) metoduna iletin.

1. Bazı işleme yapın (görevleri gerçekleştirin).

1. `Metered` sınıfının [getConsumptionQuantity](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) metodunu çağırın.

Şimdiye kadar tükettiğiniz API isteklerinin miktarını/gösterge sayısını görmelisiniz.

Bu örnek kod, metrikli lisanslamayı nasıl kullanacağınızı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Metered sınıfının bir örneğini oluşturur
var metered = new aspose.slides.Metered();

// Açık ve özel anahtarları Metered nesnesine geçirir
metered.setMeteredKey("<valid public key>", "<valid private key>");

// API çağrılarından önce tüketilen miktar değerini alır
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Burada Aspose.Slides API ile bir şeyler yapın
// ...

// API çağrılarından sonra tüketilen miktar değerini alır
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 

Metrikli lisanslamayı kullanmak için stabil bir internet bağlantısına ihtiyacınız vardır, çünkü lisanslama mekanizması, hizmetlerimizle sürekli etkileşimde bulunmak ve hesaplamalar yapmak için internete ihtiyaç duyar.

{{% /alert %}} 

## **SSS**

**Aynı uygulamada metrikli bir lisansı, normal (sürekli veya geçici) bir lisansla birlikte kullanabilir miyim?**

Evet. Metered, mevcut [licensing methods](/slides/tr/nodejs-java/licensing/) ile birlikte kullanılabilen ek bir lisanslama mekanizmasıdır. Hangi mekanizmanın uygulanacağını uygulama başlatıldığında seçersiniz.

**Metrikli lisans altında tam olarak ne tüketim olarak sayılır: işlemler mi yoksa dosyalar mı?**

API kullanımı sayılır, yani istek veya işlem sayısı. Mevcut tüketimi [consumption-tracking methods](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/metered/) aracılığıyla alabilirsiniz.

**Metrikli lisans, örneklerin sık sık yeniden başlatıldığı mikro servisler ve sunucusuz ortamlar için uygun mu?**

Evet. Hesaplama API çağrısı düzeyinde yapıldığı için, sık sık soğuk başlatmaların olduğu senaryolar, metrikli hesaplamalar için stabil bir ağ erişimi olduğu sürece uyumludur.

**Metrikli lisans kullanırken kütüphanenin işlevselliği, kalıcı bir lisansa kıyasla farklı mı?**

Hayır. Bu sadece lisanslama ve faturalandırma mekanizmasıyla ilgilidir; ürünün yetenekleri aynıdır.

**Metrikli lisans deneme sürümü ve geçici lisansla nasıl ilişkilidir?**

Deneme sürümünde sınırlamalar ve filigranlar bulunur, [temporary license](https://purchase.aspose.com/temporary-license/) 30 gün boyunca sınırlamaları kaldırır ve metrikli lisans sınırlamaları kaldırır ve gerçek kullanım üzerinden ücretlendirir.

**Tüketim eşiği aşıldığında otomatik olarak tepki vererek bütçeyi kontrol edebilir miyim?**

Evet. Yaygın bir uygulama, [tracking methods](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/metered/) aracılığıyla mevcut tüketimi periyodik olarak okumak ve uygulama ya da izleme seviyesinde kendi limitlerinizi veya uyarılarınızı uygulamaktır.