---
title: Sayaçlı Lisanslama
type: docs
weight: 90
url: /tr/python-net/metered-licensing/
keywords:
- lisans
- sayaçlı lisans
- lisans anahtarları
- genel anahtar
- özel anahtar
- tüketim miktarı
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET sayaçlı lisanslamanın, PowerPoint ve OpenDocument dosyalarını esnek bir şekilde işlemenizi ve yalnızca kullandığınız kadar ödeme yapmanızı nasıl sağladığını öğrenin."
---
## **Giriş**

Metered lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız, metered lisanslamayı seçersiniz.

## **Metered Anahtarları Uygula**

{{% alert color="primary" %}} 

Metered lisanslama, mevcut lisanslama yöntemleriyle birlikte kullanılabilen yeni bir lisanslama mekanizmasıdır. Aspose.Slides API özelliklerini kullanımınıza göre faturalandırılmak istiyorsanız, metered lisanslamayı seçersiniz.

Metered lisans satın aldığınızda, bir lisans dosyası yerine anahtarlar alırsınız. Bu metered anahtar, Aspose'un metering işlemleri için sağladığı [Metered](https://reference.aspose.com/slides/tr/python-net/aspose.slides/metered/) sınıfı kullanılarak uygulanabilir. Daha fazla detay için, [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) sayfasına bakın.

{{% /alert %}} 

1. Bir [Metered](https://reference.aspose.com/slides/tr/python-net/aspose.slides/metered/) sınıfının bir örneğini oluşturun.
1. Genel ve özel anahtarlarınızı [set_metered_key](https://reference.aspose.com/slides/tr/python-net/aspose.slides/metered/set_metered_key/#str-str) metoduna aktarın.
1. Bazı işlemler yapın (görevleri yürütün).
1. `Metered` sınıfının [get_consumption_quantity](https://reference.aspose.com/slides/tr/python-net/aspose.slides/metered/get_consumption_quantity/#) metodunu çağırın.

Şu ana kadar tükettiğiniz API isteklerinin miktarını/adetini görmelisiniz.

Bu örnek kod, metered lisanslamayı nasıl kullanacağınızı gösterir:

```python
import aspose.slides as slides

# Metered sınıfının bir örneğini oluşturur
metered = slides.Metered()

# Metered nesnesine genel ve özel anahtarları geçirir
metered.set_metered_key("<valid public key>", "<valid private key>")

# API çağrılarından önce tüketilen miktar değerini alır
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Burada Aspose.Slides API ile bir şeyler yapın
# ...

# API çağrılarından sonra tüketilen miktar değerini alır
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Metered lisanslamayı kullanmak için, lisanslama mekanizmasının internete sürekli bağlanarak hizmetlerimizle etkileşime girmesi ve hesaplamalar yapması gerektiğinden, kararlı bir internet bağlantısına ihtiyacınız vardır.

{{% /alert %}} 

## **SSS**

**Aynı uygulamada metered lisansı, normal (süresiz veya geçici) bir lisansla birlikte kullanabilir miyim?**

Evet. Metered, mevcut [lisanslama yöntemleri](/slides/tr/python-net/licensing/) ile birlikte kullanılabilen ek bir lisanslama mekanizmasıdır. Uygulama başladığında hangi mekanizmanın uygulanacağını siz seçersiniz.

**Metered lisans altında tüketim olarak tam olarak ne sayılır: işlemler mi yoksa dosyalar mı?**

API kullanımı sayılır, yani istek ya da işlem sayısı. Mevcut tüketimi, [tüketim izleme yöntemleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides/metered/) aracılığıyla alabilirsiniz.

**Metered, sık sık yeniden başlatılan mikro hizmetler ve sunucusuz ortamlara uygun mu?**

Evet. Hesaplama API çağrısı seviyesinde yapıldığı için, sık soğuk başlangıçların olduğu senaryolar, metered hesaplamalar için kararlı ağ erişimi sağlandığı sürece uyumludur.

**Bir metered lisans kullanırken kütüphanenin işlevselliği, süresiz lisansa kıyasla farklılık gösterir mi?**

Hayır. Bu sadece lisanslama ve faturalama mekanizmasıyla ilgilidir; ürünün yetenekleri aynıdır.

**Metered, deneme sürümü ve geçici lisansla nasıl ilişkilidir?**

Deneme sürümünün kısıtlamaları ve filigranları vardır, [geçici lisans](https://purchase.aspose.com/temporary-license/) 30 gün boyunca kısıtlamaları kaldırır ve metered kısıtlamaları kaldırır ve gerçek kullanımına göre ücretlendirir.

**Tüketim eşiği aşıldığında otomatik olarak tepki vererek bütçeyi kontrol edebilir miyim?**

Evet. Yaygın bir yöntem, [izleme yöntemleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides/metered/) aracılığıyla düzenli olarak mevcut tüketimi okumak ve uygulama ya da izleme seviyesinde kendi limitlerinizi veya uyarılarınızı uygulamaktır.