---
title: Ölçümlü Lisanslama
type: docs
weight: 100
url: /tr/python-java/metered-licensing/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ölçümlü lisanslamanın, PowerPoint ve OpenDocument dosyalarını esnek bir şekilde işlemenizi ve yalnızca kullandığınız kadar ödeme yapmanızı nasıl sağladığını öğrenin."
---
## **Giriş**

Ölçümlü lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırmak istiyorsanız, ölçümlü lisanslamayı seçin.

## **Ölçümlü Anahtarları Uygulayın**

{{% alert color="info" title="Not" %}}

Ölçümlü lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen yeni bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırmak istiyorsanız, ölçümlü lisanslamayı seçin.

Ölçümlü bir lisans satın aldığınızda, lisans dosyası yerine anahtarlar alırsınız. Bu ölçümlü anahtar, Aspose tarafından ölçüm işlemleri için sağlanan [Ölçümlü](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/) sınıfı ile uygulanabilir. Daha fazla ayrıntı için [Ölçümlü Lisanslama SSS](https://purchase.aspose.com/faqs/licensing/metered) bölümüne bakın.

{{% /alert %}}

1. [Ölçümlü](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/) sınıfından bir örnek oluşturun.

1. Genel ve özel anahtarlarınızı [setMeteredKey](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/#setMeteredKey) yöntemine geçirin.

1. Birkaç işlem (görev) gerçekleştirin.

1. [Ölçümlü](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/) sınıfının [getConsumptionQuantity](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/#getConsumptionQuantity) yöntemini çağırın.

Şimdiye kadar tükettiğiniz API isteklerinin miktarını/adetini göreceksiniz.

Bu örnek kod, ölçümlü lisanslamanın nasıl kullanılacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Metered sınıfının bir örneğini oluştur.
metered = Metered()

try:
    # Genel ve özel anahtarları Metered nesnesine aktar.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # API çağrılarından önce tüketilen miktarı al.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Burada Aspose.Slides API ile bir şeyler yap.
    # ...

    # API çağrılarından sonra tüketilen miktarı al.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Uyarı" %}}

Ölçümlü lisanslamayı kullanmak için istikrarlı bir internet bağlantısına ihtiyacınız vardır; çünkü lisanslama mekanizması hizmetlerimizle sürekli etkileşim kurmak ve hesaplamalar yapmak için interneti kullanır.

{{% /alert %}}

## **SSS**

**Ölçümlü bir lisansı aynı uygulamada normal (sürekli ya da geçici) bir lisansla birlikte kullanabilir miyim?**

Evet. Ölçümlü, mevcut [lisanslama yöntemleri](/slides/tr/python-java/licensing/) ile birlikte kullanılabilen ek bir lisanslama mekanizmasıdır. Uygulama başlatıldığında hangi mekanizmanın kullanılacağına siz karar verirsiniz.

**Ölçümlü bir lisans altında tüketim tam olarak neyi ifade eder: işlemler mi dosyalar mı?**

API kullanımı sayılır; yani istek veya işlem sayısı. Mevcut tüketimi [tüketim takibi yöntemleri](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/) aracılığıyla alabilirsiniz.

**Ölçümlü lisans, örneklerin sık sık yeniden başlatıldığı mikro hizmetler ve sunucusuz ortamlar için uygun mu?**

Evet. Hesaplama API çağrısı düzeyinde yapıldığı için soğuk başlangıçların sık olduğu senaryolar, ölçümlü hesaplamalar için istikrarlı bir ağ bağlantısı olduğu sürece uyumludur.

**Ölçümlü lisans kullanırken kütüphanenin işlevselliği sürekli lisansa göre farklılık gösterir mi?**

Hayır. Bu sadece lisanslama ve faturalama mekanizmasıyla ilgilidir; ürünün yetenekleri aynı kalır.

**Ölçümlü lisans deneme sürümü ve geçici lisansla nasıl ilişkilidir?**

Deneme sürümünün sınırlamaları ve filigranları vardır, [geçici lisans](https://purchase.aspose.com/temporary-license/) 30 gün için sınırlamaları kaldırır ve ölçümlü lisans sınırlamaları kaldırır ve kullanımınıza göre ücretlendirme yapar.

**Tüketim eşiği aşıldığında otomatik olarak tepki vererek bütçeyi kontrol edebilir miyim?**

Evet. Yaygın bir uygulama, mevcut tüketimi periyodik olarak [takip yöntemleri](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/) ile okuyup, uygulama ya da izleme seviyesinde kendi limitlerinizi veya uyarılarınızı uygulamaktır.