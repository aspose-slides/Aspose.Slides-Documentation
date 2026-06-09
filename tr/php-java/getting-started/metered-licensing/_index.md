---
title: Varlıklı Lisanslama
type: docs
weight: 100
url: /tr/php-java/metered-licensing/
keywords:
- lisans
- varlık lisansı
- lisans anahtarları
- açık anahtar
- özel anahtar
- tüketim miktarı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java varlık lisanslamasının PowerPoint ve OpenDocument dosyalarını esnek bir şekilde işlemenize ve yalnızca kullandığınız kadar ödeme yaparak nasıl yardımcı olduğunu öğrenin."
---
## **Giriş**

Varlıklı lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız, varlık lisanslamayı seçersiniz.

## **Varlıklı Anahtarları Uygula**

Bir varlık lisansı satın aldığınızda, lisans dosyası yerine anahtarlar alırsınız. Bu varlık anahtarı, Aspose'in ölçüm işlemleri için sağladığı [Metered](https://reference.aspose.com/slides/tr/php-java/aspose.slides/metered/) sınıfı kullanılarak uygulanabilir. Daha fazla ayrıntı için [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) sayfasına bakın.

1. [Metered](https://reference.aspose.com/slides/tr/php-java/aspose.slides/metered/) sınıfının bir örneğini oluşturun.

2. Genel ve özel anahtarlarınızı [setMeteredKey](https://reference.aspose.com/slides/tr/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) metoduna iletin.

3. Birkaç işleme (görev yürütme) yapın.

4. `Metered` sınıfının [getConsumptionQuantity](https://reference.aspose.com/slides/tr/php-java/aspose.slides/metered/#getConsumptionQuantity--) metodunu çağırın.

Şimdiye kadar tükettiğiniz API isteklerinin miktarını/gazını görebilirsiniz.

Bu örnek kod, varlık lisanslamanın nasıl kullanılacağını gösterir:

```php
// Metered sınıfının bir örneğini oluşturur
$metered = new Metered();

try {
    // Genel ve özel anahtarları Metered nesnesine geçirir
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // API çağrılarından önce tüketilen miktar değerini alır
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Burada Aspose.Slides API ile bir şeyler yapın
    // ...

    // API çağrılarından sonra tüketilen miktar değerini alır
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOT"  %}} 
Varlıklı lisanslamayı kullanmak için sabit bir internet bağlantısına ihtiyaç duyarsınız; çünkü lisanslama mekanizması, hizmetlerimizle sürekli etkileşime girmek ve hesaplamalar yapmak için internete bağlanır.
{{% /alert %}} 

## **SSS**

**Aynı uygulamada varlık lisansını normal (kalıcı veya geçici) bir lisansla birlikte kullanabilir miyim?**  
Evet. Varlıklı, mevcut [lisanslama yöntemleri](/slides/tr/php-java/licensing/) ile birlikte kullanılabilen ek bir lisanslama mekanizmasıdır. Uygulama başladığında hangi mekanizmanın uygulanacağını seçersiniz.

**Varlıklı lisans altında tüketim olarak tam olarak ne sayılır: işlemler mi dosyalar mı?**  
API kullanımı sayılır, yani istek veya işlem sayısı. Mevcut tüketimi [tüketim izleme yöntemleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/metered/) aracılığıyla alabilirsiniz.

**Varlıklı lisans, örneklerin sık sık yeniden başlatıldığı mikro hizmetler ve serverless ortamlar için uygun mu?**  
Evet. Hesaplama API çağrı seviyesinde yapıldığı için, sık soğuk başlatma durumları stabil bir ağ erişimi sağlandığı sürece uyumludur.

**Varlıklı lisans kullanırken kütüphanenin işlevselliği kalıcı lisansa göre farklılık gösterir mi?**  
Hayır. Bu sadece lisanslama ve faturalandırma mekanizmasıyla ilgilidir; ürünün yetenekleri aynı kalır.

**Varlıklı lisans, deneme sürümü ve geçici lisansla nasıl ilişkilidir?**  
Deneme sürümünde sınırlamalar ve filigranlar vardır, [geçici lisans](https://purchase.aspose.com/temporary-license/) 30 gün boyunca sınırlamaları kaldırır ve varlık lisanslama sınırlamaları kaldırır ve gerçek kullanım üzerinden ücretlendirir.

**Tüketim eşiği aşıldığında otomatik olarak tepki vererek bütçeyi kontrol edebilir miyim?**  
Evet. Yaygın bir yöntem, [takip yöntemleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/metered/) aracılığıyla mevcut tüketimi periyodik olarak okuyup, uygulama veya izleme düzeyinde kendi limitlerinizi veya uyarılarınızı uygulamaktır.