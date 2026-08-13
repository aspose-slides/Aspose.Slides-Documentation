---
title: Ölçmeli Lisanslama
type: docs
weight: 100
url: /tr/java/metered-licensing/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ölçmeli lisanslamanın, PowerPoint ve OpenDocument dosyalarını esnek bir şekilde işlemeyi ve yalnızca kullandıklarınız için ödeme yapmayı nasıl sağladığını öğrenin."
---
## **Giriş**

Ölçmeli lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız, ölçmeli lisanslamayı seçersiniz.

## **Ölçmeli Anahtarları Uygula**

{{% alert color="info" %}} 

Ölçmeli lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen yeni bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız, ölçmeli lisanslamayı seçersiniz.

Bir ölçmeli lisans satın aldığınızda, lisans dosyası yerine anahtarlar alırsınız. Bu ölçmeli anahtar, metrik işlemler için Aspose tarafından sağlanan [Metered](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/) sınıfı kullanılarak uygulanabilir. Daha fazla ayrıntı için [Ölçmeli Lisanslama SSS](https://purchase.aspose.com/faqs/licensing/metered) sayfasına bakın.

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/) sınıfının bir örneğini oluşturun.  

2. Genel ve özel anahtarlarınızı [setMeteredKey](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) metoduna gönderin.  

3. Biraz işleme yapın (görevleri gerçekleştirin).  

4. `Metered` sınıfının [getConsumptionQuantity](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/#getConsumptionQuantity--) metodunu çağırın.  

Şu ana kadar tükettiğiniz API isteklerinin miktarını/adetini görebilirsiniz.

Bu örnek kod, ölçmeli lisanslamayı nasıl kullanacağınızı gösterir:

```java
// Metered sınıfının bir örneğini oluşturur
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Metered nesnesine genel ve özel anahtarları gönderir
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // API çağrıları öncesinde tüketilen miktar değerini alır
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Aspose.Slides API'siyle burada bir şey yapın
    // ...

    // API çağrıları sonrasında tüketilen miktar değerini alır
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Ölçmeli lisanslamayı kullanmak için, lisanslama mekanizması hizmetlerimizle sürekli etkileşim kurup hesaplamalar yapabilmek amacıyla interneti kullandığından, sabit bir internet bağlantısına ihtiyacınız vardır.  

{{% /alert %}} 

## **SSS**

### Aynı uygulamada ölçmeli lisansı, kalıcı veya geçici bir lisansla birlikte kullanabilir miyim?

Evet. Ölçmeli, mevcut [lisanslama yöntemleri](/slides/tr/java/licensing/) ile birlikte kullanılabilen ek bir lisanslama mekanizmasıdır. Uygulama başladığında hangi mekanizmanın uygulanacağını seçersiniz.

### Ölçmeli lisans kapsamında tüketim olarak tam olarak ne sayılır: işlemler mi yoksa dosyalar mı?

API kullanımı sayılır, yani istek veya işlem sayısı. Mevcut tüketimi, [tüketim izleme yöntemleri](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/) aracılığıyla alabilirsiniz.

### Ölçmeli, sık sık yeniden başlatılan mikro hizmetler ve sunucusuz ortamlar için uygun mu?

Evet. Hesaplama API‑çağrı seviyesinde yapıldığı için, sık soğuk başlatmaların olduğu senaryolar, ölçmeli hesaplamalar için stabil bir ağ erişimi sağlandığı sürece uyumludur.

### Ölçmeli lisans kullanırken kütüphanenin işlevselliği kalıcı lisansa göre farklılık gösterir mi?

Hayır. Bu sadece lisanslama ve faturalandırma mekanizmasıyla ilgilidir; ürünün yetenekleri aynı kalır.

### Ölçmeli lisans, deneme sürümü ve geçici lisansla nasıl ilişkilidir?

Deneme sürümünün sınırlamaları ve filigranları vardır, [geçici lisans](https://purchase.aspose.com/temporary-license/) 30 gün boyunca sınırlamaları kaldırır, ölçmeli ise sınırlamaları kaldırır ve gerçek kullanım üzerinden ücretlendirir.

### Tüketim eşiği aşıldığında otomatik olarak tepki vererek bütçeyi kontrol edebilir miyim?

Evet. Yaygın bir uygulama, mevcut tüketimi periyodik olarak [izleme yöntemleri](https://reference.aspose.com/slides/tr/java/com.aspose.slides/metered/) ile okuyup, uygulama veya izleme seviyesinde kendi limitlerinizi veya uyarılarınızı uygulamaktır.