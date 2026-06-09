---
title: Ölçümlü Lisanslama
type: docs
weight: 100
url: /tr/java/metered-licensing/
keywords:
- lisans
- ölçümlü lisans
- lisans anahtarları
- genel anahtar
- özel anahtar
- tüketim miktarı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ölçümlü lisanslamasının PowerPoint ve OpenDocument dosyalarını esnek bir şekilde işlemenizi ve yalnızca kullandıklarınız için ödeme yapmanızı nasıl sağladığını öğrenin."
---
## **Giriş**

Ölçümlü lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız ölçümlü lisanslamayı seçersiniz.

## **Ölçümlü Anahtarları Uygula**

{{% alert color="primary" %}} 

Ölçümlü lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen yeni bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız ölçümlü lisanslamayı seçersiniz.

Ölçümlü bir lisans satın aldığınızda anahtarlar (ve lisans dosyası yerine) elde edersiniz. Bu ölçümlü anahtar, Aspose'un ölçüm işlemleri için sağladığı [Metered](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/) sınıfı kullanılarak uygulanabilir. Daha fazla ayrıntı için [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) sayfasına bakın.

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/) sınıfının bir örneğini oluşturun.

1. Genel ve özel anahtarlarınızı [setMeteredKey](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) yöntemine geçirin.

1. Birkaç işlem (görev) gerçekleştirin.

1. `Metered` sınıfının [getConsumptionQuantity](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/#getConsumptionQuantity--) yöntemini çağırın.

Şu ana kadar tükettiğiniz API isteklerinin miktarını/adetini görmelisiniz.

Bu örnek kod, ölçümlü lisanslamanın nasıl kullanılacağını gösterir:

```java
// Metered sınıfının bir örneğini oluşturur
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Genel ve özel anahtarları Metered nesnesine geçirir
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // API çağrılarından önce tüketilen miktar değerini alır
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Burada Aspose.Slides API ile bir şeyler yapın
    // ...

    // API çağrılarından sonra tüketilen miktar değerini alır
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Ölçümlü lisanslamayı kullanmak için, lisanslama mekanizmasının hizmetlerimizle sürekli etkileşime girmesi ve hesaplamaları gerçekleştirmesi nedeniyle kararlı bir internet bağlantısına ihtiyacınız vardır.

{{% /alert %}} 

## **SSS**

**Ölçümlü bir lisansı, aynı uygulamada normal bir lisans (süresiz veya geçici) ile birlikte kullanabilir miyim?**

Evet. Ölçümlü, mevcut [lisanslama yöntemleri](/slides/tr/java/licensing/) ile birlikte kullanılabilen ek bir lisanslama mekanizmasıdır. Uygulama başladığında hangi mekanizmayı uygulayacağınızı seçersiniz.

**Ölçümlü lisans kapsamında tüketim tam olarak neyi sayar: işlemler mi dosyalar mı?**

API kullanımı sayılır, yani istek veya işlem sayısı. Mevcut tüketimi [tüketim izleme yöntemleri](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/) ile elde edebilirsiniz.

**Sık sık yeniden başlatılan örneklerin olduğu mikroservis ve sunucusuz ortamlarda ölçümlü lisanslama uygun mu?**

Evet. Hesaplama API çağrı seviyesi yapıldığı için sık soğuk başlatma senaryoları, ölçümlü hesaplamalar için kararlı ağ erişimi olduğu sürece uyumludur.

**Kalıcı bir lisans yerine ölçümlü lisans kullanıldığında kütüphanenin işlevselliği değişir mi?**

Hayır. Bu sadece lisans ve faturalandırma mekanizmasıyla ilgilidir; ürünün yetenekleri aynı kalır.

**Ölçümlü lisans, deneme sürümü ve geçici lisansla nasıl ilişkilidir?**

Deneme sürümünde sınırlamalar ve filigranlar vardır, [geçici lisans](https://purchase.aspose.com/temporary-license/) 30 gün için sınırlamaları kaldırır ve ölçümlü lisans sınırlamaları kaldırır ve gerçek kullanım üzerinden ücretlendirir.

**Tüketim eşiği aşıldığında otomatik olarak tepki vererek bütçeyi kontrol edebilir miyim?**

Evet. Yaygın bir uygulama, mevcut tüketimi periyodik olarak [tüketim izleme yöntemleri](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/) ile okuyup uygulama veya izleme seviyesinde kendi limitlerinizi veya uyarılarınızı uygulamaktır.